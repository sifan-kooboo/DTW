using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.IO;
namespace jdgl_res_head_service.common_file
{
    public class common_is_select
    {
        //上传完后修改本地表is_select=1,tablename为表名
        public static void Updat_is_select(DataSet DS, string tablename)
        {
            string Local_lsbh = "";

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
                helper.RunProcedure("TableName_select", para);


            }


        }
    }
}
