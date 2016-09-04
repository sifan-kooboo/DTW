using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using Maticsoft.DBUtility;
using System.IO;
namespace jdgl_res_head_app.common_file
{
     public class Common_Shsc
    {
        //上传完后修改本地表shsc=1,tablename为表名
        public static void Updatshsc(DataSet DS, string tablename)
        {
            string Local_lsbh = "";
            if (DS != null && DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    Local_lsbh = dr["id"].ToString();
                    DbHelperSQLP helper = new DbHelperSQLP();
                    SqlParameter[] para = new SqlParameter[]{
                                new SqlParameter("@id", SqlDbType.VarChar,1000),
                                new SqlParameter("@TableName", SqlDbType.VarChar,100)
                            };
                    para[0].Value = Local_lsbh;
                    para[1].Value = tablename;
                    helper.RunProcedure("TableName_Shsc", para);
                }
            }
        }
         public static void UpdateHYJF(string hykh,int hyjf)
         {
             DbHelperSQLP helper = new DbHelperSQLP();
             SqlParameter[] para = new SqlParameter[]{
                                new SqlParameter("@hykh", SqlDbType.VarChar,1000),
                                new SqlParameter("@hyjf", SqlDbType.Int)
                      
                            };
             para[0].Value = hykh;
             para[1].Value = hyjf;
             helper.RunProcedure("TableName_Hhyjf", para);
         }

         public static int GetRowCount(DataSet DS)
         {
             int i = 0;
             if (DS != null && DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
             {
                 i = DS.Tables[0].Rows.Count;
             }
             return i;
         }


    }
}
