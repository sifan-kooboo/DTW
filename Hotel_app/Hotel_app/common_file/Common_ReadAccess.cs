using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace Hotel_app.common_file
{
    class Common_ReadAccess
    {

        //读Excel文件，返回数据集
        public DataSet ReadDataToDataSet()
        {
            // 创建DataSet，用于存储数据.
            DataSet testDataSet = new DataSet(); 
        /// <summary>
        /// Access 的数据库连接字符串.
        /// </summary>
        /// 
            string IDCardsInfoDBPath = Application.StartupPath + "\\IDcardsInfoDB\\HX_ScanDb.mdb";
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + IDCardsInfoDBPath;

        /// <summary>
        /// 用于查询的 SQL 语句.
        /// </summary>
         const string SQL = "SELECT *   FROM   ScanResult ";


            // 建立数据库连接.
            OleDbConnection conn = new OleDbConnection(connString);

            // 创建一个适配器
            OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, conn);

            // 执行查询，并将数据导入DataSet.
            adapter.Fill(testDataSet, "SfzScanResult");
            
            // 关闭数据库连接.
            conn.Close();
            return testDataSet;
            // 处理DataSet中的每一行数据.
            //foreach (DataRow testRow in testDataSet.Tables["SfzScanResult"].Rows)
            //{
            //    // 将检索出来的数据，输出到屏幕上.
            //    Console.WriteLine("ID: {0}   Name: {1}",
            //        testRow["member_type_code"], testRow["member_type_name"]
            //        );
            //}
        }


    }
}
