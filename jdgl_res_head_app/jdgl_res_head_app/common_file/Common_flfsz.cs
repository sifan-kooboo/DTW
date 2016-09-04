using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace jdgl_res_head_app.common_file
{
    public class Common_flfsz
    {
        //id,yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,czy,cznr,czsj,shlz,is_top,is_select
        //添加到联房
        public static void Flfsz_add(string yydh, string qymc, string lfbh, string lsbh,string fjbh,string krxm,string sktt,string yddj,string czy)
       {
           SqlParameter[] sp = {
				    new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lfbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@shlz", SqlDbType.Bit,1)};
           sp[0].Value = yydh;
           sp[1].Value = qymc;
           sp[2].Value = lfbh;
           sp[3].Value = lsbh;
           sp[4].Value = fjbh;
           sp[5].Value = krxm;
           sp[6].Value = sktt;
           sp[7].Value = yddj;
           sp[8].Value = czy;
           sp[9].Value = "新增";
           sp[10].Value = DateTime.Now;
           sp[11].Value = 1;
           
           SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Flfsz_ADD", sp);
          

       }
    }
}
