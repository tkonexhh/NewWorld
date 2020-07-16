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
        [MenuItem("Assets/GFrame/SQL/Table To C#", false, 0)]
        public static void SQLTableToCSharp()
        {
            var folder = FileHelper.GetDictionary(Application.dataPath + "/" + ProjectPathConfig.DataBasePath);
            var db = folder.GetFiles("*.db");
            for (int i = 0; i < db.Length; i++)
            {
                string dbName = PathHelper.FileNameWithoutSuffix(db[i].Name);
                SqliteDatabase database = SQLMgr.S.Open(dbName);
                //获取该数据库下面的所有表
                var reader = database.GetAllTableName();
                while (reader.Read())
                {
                    //获取表信息
                    string tableName = (string)reader[0];
                    var tableReader = database.GetTableInfo(tableName);

                    string tdClassName = "TD" + tableName;

                    CodeTypeDeclaration tdClass = new CodeTypeDeclaration(tdClassName); //生成类
                    tdClass.IsPartial = true;
                    tdClass.IsClass = true;
                    tdClass.TypeAttributes = TypeAttributes.Public;

                    while (tableReader.Read())
                    {
                        string name = (string)tableReader[1];
                        string typeName = (string)tableReader[2];

                        CodeMemberField member = new CodeMemberField(SQLMgr.GetType(typeName), "m_" + name); //生成字段
                        //添加注释
                        //member.Comments.Add(new CodeCommentStatement("asdasdasd"));
                        member.Attributes = MemberAttributes.Private;
                        tdClass.Members.Add(member); //把生成的字段加入到生成的类中

                        CodeMemberProperty property = new CodeMemberProperty();
                        property.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                        property.Type = member.Type;
                        property.HasGet = true;
                        property.Name = name;
                        // 返回属性值
                        CodeMethodReturnStatement ret = new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), member.Name));
                        property.GetStatements.Add(ret);
                        tdClass.Members.Add(property);
                    }

                    string dirName = Application.dataPath + "/" + ProjectPathConfig.tableCsharpPath + "Sql/Genetate/" + dbName + "/" + tableName + "/";
                    FileHelper.CreateDirctory(dirName);

                    string outputPath = dirName + tdClassName + ".cs";     //指定文件的输出路径
                    WriteCode(outputPath, tdClass);


                    //Table
                    string tdTableClassName = tdClassName + "Table";
                    string outputTablePath = dirName + tdTableClassName + ".cs";
                    CodeTypeDeclaration tdTableClass = new CodeTypeDeclaration(tdTableClassName); //生成类
                    tdTableClass.IsPartial = true;
                    tdTableClass.IsClass = true;
                    tdTableClass.TypeAttributes = TypeAttributes.Public;
                    WriteCode(outputTablePath, tdTableClass);

                    //Extend
                    string dirExtendName = Application.dataPath + "/" + ProjectPathConfig.tableCsharpPath + "Sql/Extend/" + dbName + "/" + tableName + "/";
                    FileHelper.CreateDirctory(dirExtendName);
                    string outputPathExtend = dirExtendName + tdClassName + "Extend.cs";
                    GenerateExtend(outputPathExtend, tdClassName);

                    string outputPathTabelExtend = dirExtendName + tdTableClassName + "Extend.cs";
                    GenerateExtend(outputPathTabelExtend, tdTableClassName);
                }

            }
            AssetDatabase.Refresh();

        }

        private static void GenerateExtend(string path, string className)
        {
            if (!FileHelper.IsExists(path))
            {
                CodeTypeDeclaration tdExtendClass = new CodeTypeDeclaration(className); //生成类
                tdExtendClass.IsPartial = true;
                tdExtendClass.IsClass = true;
                tdExtendClass.TypeAttributes = TypeAttributes.Public;

                WriteCode(path, tdExtendClass);
            }
        }

        private static void WriteCode(string path, CodeTypeDeclaration classDeclaration)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();    //代码生成风格
            options.BracingStyle = "C";
            options.BlankLinesBetweenMembers = true;

            using (StreamWriter sw = new StreamWriter(path))
            {
                provider.GenerateCodeFromType(classDeclaration, sw, options); //生成文件
            }
        }

    }
}