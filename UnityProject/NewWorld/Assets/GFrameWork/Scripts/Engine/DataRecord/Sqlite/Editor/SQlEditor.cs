using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Mono.Data.Sqlite;
using System;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace GFrame.Editor
{
    public class SQlEditor : UnityEditor.Editor
    {
        // [MenuItem("Tools/GFrame/SQL Init", false, 0)]
        // public static void SQLInit()
        // {

        // }

        [MenuItem("Assets/GFrame/SQL/Table To C#", false, 0)]
        public static void SQLTableToCSharp()
        {
            var folder = FileHelper.GetDictionary(Application.dataPath + "/" + ProjectPathConfig.DataBasePath);
            var db = folder.GetFiles("*.db");
            for (int i = 0; i < db.Length; i++)
            {

                //获取该数据库下面的所有表
                string dbName = PathHelper.FileNameWithoutSuffix(db[i].Name);


                string className = PathHelper.FileNameWithoutSuffix(db[i].Name);
                Debug.LogError(className);

                string tdClassName = "TD" + className;
                CodeTypeDeclaration myClass = new CodeTypeDeclaration(tdClassName); //生成类
                myClass.IsClass = true;
                myClass.TypeAttributes = TypeAttributes.Public;

                string type = "int";
                string filed = "test";
                CodeMemberField member = new CodeMemberField(typeof(Int32), "m_" + filed); //生成字段
                member.Attributes = MemberAttributes.Private;
                myClass.Members.Add(member); //把生成的字段加入到生成的类中

                CodeMemberMethod method = new CodeMemberMethod();
                method.Name = filed;
                method.Attributes = MemberAttributes.Public;
                myClass.Members.Add(method);

                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                CodeGeneratorOptions options = new CodeGeneratorOptions();    //代码生成风格
                options.BracingStyle = "C";
                options.BlankLinesBetweenMembers = true;

                string dirName = Application.dataPath + "/" + ProjectPathConfig.tableCsharpPath + "Sql/" + dbName + "/" + className + "/";
                FileHelper.CreateDirctory(dirName);
                string outputPath = dirName + tdClassName + ".cs";     //指定文件的输出路径

                using (StreamWriter sw = new StreamWriter(outputPath))
                {
                    provider.GenerateCodeFromType(myClass, sw, options); //生成文件
                }

                AssetDatabase.Refresh();

            }
        }

    }
}