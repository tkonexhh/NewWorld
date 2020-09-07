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
        [MenuItem("Assets/GFrame/SQL/Close Sql")]
        public static void CloseSQL()
        {
            SQLMgr.S.Close();
        }


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
                    GenerateDataExtendFile(tableName, dirExtendName);
                    GenerateDataTableExtendFile(tableName, dirExtendName);

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
            StringBuilder initValue = new StringBuilder();
            int index = 0;
            while (tableReader.Read())
            {
                string name = (string)tableReader[1];
                string typeName = (string)tableReader[2];

                string typeStr = SQLMgr.GetTypeStr(typeName);

                variable.Append("\t\tprivate " + typeStr + " m_" + name + ";\n");

                member.Append("\t\tpublic " + typeStr + " " + name + "{ get => m_" + name + ";}\n");

                initValue.Append("\t\tm_" + name + " = (" + typeStr + ")reader[" + index + "];\n");
                index++;
            }
            textData = textData.Replace("{{.Attribute}}}", variable.ToString());
            textData = textData.Replace("{{.Mebmber}}", member.ToString());
            textData = textData.Replace("{{.InitValue}}", initValue.ToString());

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
            textData = textData.Replace("{{.KeyPropName}}", "ID");

            FileHelper.CreateDirctory(dirName);
            string outputPath = dirName + "TD" + className + "Table.cs";
            FileHelper.WriteText(outputPath, textData.ToString());
        }

        private static void GenerateDataExtendFile(string tableName, string dirName)
        {
            string className = tableName;
            string outputPath = dirName + "TD" + className + "Extend.cs";
            if (FileHelper.IsExists(outputPath)) return;

            string tmplPath = Application.dataPath + "/GFrameWork/InternalResources/template/DataExtend.tmpl";
            string textData = FileHelper.ReadText(tmplPath);
            textData = textData.Replace("{{.NameSpace}}", ProjectDefaultConfig.defaultNameSpace);
            textData = textData.Replace("{{.ClassName}}", tableName);
            FileHelper.CreateDirctory(dirName);
            FileHelper.WriteText(outputPath, textData.ToString());
        }

        private static void GenerateDataTableExtendFile(string tableName, string dirName)
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