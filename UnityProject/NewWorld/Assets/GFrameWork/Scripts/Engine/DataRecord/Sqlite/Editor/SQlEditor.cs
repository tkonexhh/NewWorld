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
using System.Text;

namespace GFrame.Editor
{
    public class SQlEditor : UnityEditor.Editor
    {
        [MenuItem("Assets/GFrame/SQL/Table To C#")]
        public static void SQLTableToCSharp()
        {
            //读取文件信息



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

                    string dirName = Application.dataPath + "/" + ProjectPathConfig.tableCsharpPath + "Sql/Genetate/" + dbName + "/" + tableName + "/";
                    GenerateDataFile(tableName, tableReader, dirName);
                    GenerateDataTableFile(dbName, tableName, tableReader, dirName);
                    string dirExtendName = Application.dataPath + "/" + ProjectPathConfig.tableCsharpPath + "Sql/Extend/" + dbName + "/" + tableName + "/";
                    GenratteDataTableExtendFile(tableName, dirExtendName);

                }
            }

            AssetDatabase.Refresh();
        }

        private static void GenerateDataFile(string tableName, SqliteDataReader tableReader, string dirName)
        {
            string tmplPath = Application.dataPath + "/GFrameWork/InternalResources/template/Data.tmpl";

            string className = tableName;

            string textData = FileHelper.ReadText(tmplPath);
            textData = textData.Replace("{{.NameSpace}}", ProjectDefaultConfig.defaultNameSpace);
            textData = textData.Replace("{{.ClassName}}", tableName);
            StringBuilder variable = new StringBuilder();
            StringBuilder member = new StringBuilder();
            while (tableReader.Read())
            {
                string name = (string)tableReader[1];
                string typeName = (string)tableReader[2];

                variable.Append("\t\tprivate " + SQLMgr.GetTypeStr(typeName) + " m_" + name + ";\n");
                member.Append("\t\tpublic " + SQLMgr.GetTypeStr(typeName) + " " + name + "\n");
                member.Append("\t\t{\n");
                member.Append("\t\t\tget {return m_" + name + ";}\n");
                member.Append("\t\t}\n");
            }
            textData = textData.Replace("{{.Attribute}}}", variable.ToString());
            textData = textData.Replace("{{.Mebmber}}", member.ToString());


            FileHelper.CreateDirctory(dirName);
            string outputPath = dirName + "TD" + className + ".cs";
            FileHelper.WriteText(outputPath, textData.ToString());
        }

        private static void GenerateDataTableFile(string databaseName, string tableName, SqliteDataReader tableReader, string dirName)
        {
            string tmplPath = Application.dataPath + "/GFrameWork/InternalResources/template/DataTable.tmpl";

            string className = tableName;
            string textData = FileHelper.ReadText(tmplPath);
            textData = textData.Replace("{{.NameSpace}}", ProjectDefaultConfig.defaultNameSpace);
            textData = textData.Replace("{{.ClassName}}", tableName);
            textData = textData.Replace("{{.DataBaseName}}", databaseName);
            textData = textData.Replace("{{.TableName}}", tableName);
            textData = textData.Replace("{{.KeyType}}", "long");
            textData = textData.Replace("{{.KeyPropName}}", "id");

            FileHelper.CreateDirctory(dirName);
            string outputPath = dirName + "TD" + className + "Table.cs";
            FileHelper.WriteText(outputPath, textData.ToString());
        }

        private static void GenratteDataTableExtendFile(string tableName, string dirName)
        {
            string className = tableName;
            string outputPath = dirName + "TD" + className + "TableExtend.cs";
            if (FileHelper.IsExists(outputPath)) return;

            string tmplPath = Application.dataPath + "/GFrameWork/InternalResources/template/DataTableExtend.tmpl";
            string textData = FileHelper.ReadText(tmplPath);
            textData = textData.Replace("{{.NameSpace}}", ProjectDefaultConfig.defaultNameSpace);
            textData = textData.Replace("{{.ClassName}}", tableName);
            FileHelper.CreateDirctory(dirName);
            FileHelper.WriteText(outputPath, textData.ToString());
        }

    }
}