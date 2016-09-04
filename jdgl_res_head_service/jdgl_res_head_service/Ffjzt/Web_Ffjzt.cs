using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
namespace jdgl_res_head_service.Ffjzt
{
    public class Web_Ffjzt
    {
        public string Ffjzt_UpLoadDS(DataSet DS)
        {
            //id,yydh,qymc,zyzt,zyzt_second,zybz,fjrb_code,fjrb,fjbh,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name,krxm,ddsj,lksj,yd_ddsj,yd_lksj,bz,shlf,shts,shvip,lsbh,sktt,is_select,is_top,use_time,is_secret,czsj,cznr,czy,fjbm
            string s = common_file.common_app.get_failure;

            if (DS != null && DS.Tables[0].Rows.Count > 0)
            {
                string stryydh=DS.Tables[0].Rows[0]["yydh"].ToString();
                Fjzt_delete(stryydh);
                foreach (DataRow dr in DS.Tables[0].Rows)
                {

                    SqlParameter[] parameters = {
                    new SqlParameter("@yydh", SqlDbType.VarChar,50),
                    new SqlParameter("@qymc", SqlDbType.VarChar,50),
                    new SqlParameter("@zyzt", SqlDbType.VarChar,50),
                    new SqlParameter("@zyzt_second", SqlDbType.VarChar,50),
                    new SqlParameter("@zybz", SqlDbType.VarChar,50),
                    new SqlParameter("@fjrb_code", SqlDbType.VarChar,50),
                    new SqlParameter("@fjrb", SqlDbType.VarChar,50),
                    new SqlParameter("@fjbh", SqlDbType.VarChar,50),
                    new SqlParameter("@fjdh", SqlDbType.VarChar,50),
                    new SqlParameter("@dhfj", SqlDbType.VarChar,50),
                    new SqlParameter("@jdlh", SqlDbType.VarChar,50),
                    new SqlParameter("@jdlh_name", SqlDbType.VarChar,50),
                    new SqlParameter("@jdcs", SqlDbType.VarChar,50),
                    new SqlParameter("@jdcs_name", SqlDbType.VarChar,50),
                    new SqlParameter("@krxm", SqlDbType.VarChar,120),
                    new SqlParameter("@ddsj", SqlDbType.DateTime),
                    new SqlParameter("@lksj", SqlDbType.DateTime),
                    new SqlParameter("@yd_ddsj", SqlDbType.DateTime),
                    new SqlParameter("@yd_lksj", SqlDbType.DateTime),
                    new SqlParameter("@bz", SqlDbType.VarChar,1000),
                    new SqlParameter("@shlf", SqlDbType.Bit,1),
                    new SqlParameter("@shts", SqlDbType.Bit,1),
                    new SqlParameter("@shvip", SqlDbType.Bit,1),
                    new SqlParameter("@lsbh", SqlDbType.VarChar,50),
                    new SqlParameter("@sktt", SqlDbType.VarChar,50),
                    new SqlParameter("@is_select", SqlDbType.Bit,1),
                    new SqlParameter("@is_top", SqlDbType.Bit,1),
                    new SqlParameter("@use_time", SqlDbType.Decimal,9),
                    new SqlParameter("@is_secret", SqlDbType.Bit,1),
                    new SqlParameter("@czsj", SqlDbType.DateTime),
                    new SqlParameter("@cznr", SqlDbType.VarChar,200),
                    new SqlParameter("@czy", SqlDbType.VarChar,50),
                    new SqlParameter("@fjbm", SqlDbType.Bit,1)};
                    parameters[0].Value = dr[1];
                    parameters[1].Value = dr[2];
                    parameters[2].Value = dr[3];
                    parameters[3].Value = dr[4];
                    parameters[4].Value = dr[5];
                    parameters[5].Value = dr[6];
                    parameters[6].Value = dr[7];
                    parameters[7].Value = dr[8];
                    parameters[8].Value = dr[9];
                    parameters[9].Value = dr[10];
                    parameters[10].Value = dr[11];
                    parameters[11].Value = dr[12];
                    parameters[12].Value = dr[13];
                    parameters[13].Value = dr[14];
                    parameters[14].Value = dr[15];
                    parameters[15].Value = Convert.ToDateTime(dr[16]);
                    parameters[16].Value = Convert.ToDateTime(dr[17]);
                    parameters[17].Value = Convert.ToDateTime(dr[18]);
                    parameters[18].Value = Convert.ToDateTime(dr[19]);
                    parameters[19].Value = dr[20];
                    parameters[20].Value = Convert.ToBoolean(dr[21]);
                    parameters[21].Value = Convert.ToBoolean(dr[22]);
                    parameters[22].Value = Convert.ToBoolean(dr[23]);
                    parameters[23].Value = dr[24];
                    parameters[24].Value = dr[25];
                    parameters[25].Value = Convert.ToBoolean(dr[26]);
                    parameters[26].Value = Convert.ToBoolean(dr[27]);
                    parameters[27].Value = Convert.ToDecimal(dr[28]);
                    parameters[28].Value = Convert.ToBoolean(dr[29]);
                    parameters[29].Value = Convert.ToDateTime(dr[30]);
                    parameters[30].Value = dr[31];
                    parameters[31].Value = dr[32];
                    parameters[32].Value =  Convert.ToBoolean(dr[33]);
                    int rows = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ffjzt_ADD", parameters);
                    if (rows > 0)
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
                ////添加完临时表后往Ffjzt_temp表加数据
                //PlAdd_fjzt(stryydh);
            }
            return s;
        }


        public static string Update_fjzt(DataSet DS_fjzt, string yydh)
        {
            // id,yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,
            //is_select,shsc,czy,czsj,cznr,sdcz,fjbm,jcje
            string s = common_file.common_app.get_failure;
            if (DS_fjzt != null && DS_fjzt.Tables[0].Rows.Count > 0)
            {
                
                string strlsbh_ds = ""; //记录总的lsbh以“，”号隔开
                foreach (DataRow dr in DS_fjzt.Tables[0].Rows)
                {
                    SqlParameter[] parameters = {
                    new SqlParameter("@yydh", SqlDbType.VarChar,50),
                    new SqlParameter("@qymc", SqlDbType.VarChar,50),
                    new SqlParameter("@zyzt", SqlDbType.VarChar,50),
                    new SqlParameter("@zyzt_second", SqlDbType.VarChar,50),
                    new SqlParameter("@zybz", SqlDbType.VarChar,50),
                    new SqlParameter("@fjrb_code", SqlDbType.VarChar,50),
                    new SqlParameter("@fjrb", SqlDbType.VarChar,50),
                    new SqlParameter("@fjbh", SqlDbType.VarChar,50),
                    new SqlParameter("@fjdh", SqlDbType.VarChar,50),
                    new SqlParameter("@dhfj", SqlDbType.VarChar,50),
                    new SqlParameter("@jdlh", SqlDbType.VarChar,50),
                    new SqlParameter("@jdlh_name", SqlDbType.VarChar,50),
                    new SqlParameter("@jdcs", SqlDbType.VarChar,50),
                    new SqlParameter("@jdcs_name", SqlDbType.VarChar,50),
                    new SqlParameter("@krxm", SqlDbType.VarChar,120),
                    new SqlParameter("@ddsj", SqlDbType.DateTime),
                    new SqlParameter("@lksj", SqlDbType.DateTime),
                    new SqlParameter("@yd_ddsj", SqlDbType.DateTime),
                    new SqlParameter("@yd_lksj", SqlDbType.DateTime),
                    new SqlParameter("@bz", SqlDbType.VarChar,1000),
           
                    new SqlParameter("@lsbh", SqlDbType.VarChar,50),
                    new SqlParameter("@sktt", SqlDbType.VarChar,50),
            
                    new SqlParameter("@czsj", SqlDbType.DateTime),
                    new SqlParameter("@cznr", SqlDbType.VarChar,200),
                    new SqlParameter("@czy", SqlDbType.VarChar,50),
                    new SqlParameter("@fjbm", SqlDbType.Bit,1)};
                    parameters[0].Value = dr[1];
                    parameters[1].Value = dr[2];
                    parameters[2].Value = dr[3];
                    parameters[3].Value = dr[4];
                    parameters[4].Value = dr[5];
                    parameters[5].Value = dr[6];
                    parameters[6].Value = dr[7];
                    parameters[7].Value = dr[8];
                    parameters[8].Value = dr[9];
                    parameters[9].Value = dr[10];
                    parameters[10].Value = dr[11];
                    parameters[11].Value = dr[12];
                    parameters[12].Value = dr[13];
                    parameters[13].Value = dr[14];
                    parameters[14].Value = dr[15];
                    parameters[15].Value = Convert.ToDateTime(dr[16]);
                    parameters[16].Value = Convert.ToDateTime(dr[17]);
                    parameters[17].Value = Convert.ToDateTime(dr[18]);
                    parameters[18].Value = Convert.ToDateTime(dr[19]);
                    parameters[19].Value = dr[20];
     
                    parameters[20].Value = dr[24];
                    parameters[21].Value = dr[25];

                    parameters[22].Value = DateTime.Now;
                    parameters[23].Value = dr[31];
                    parameters[24].Value = dr[32];
                    parameters[25].Value = Convert.ToBoolean(dr[33]);
                    int rows = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ffjzt_Update", parameters);
                    if (rows > 0)
                    {
                        s = common_file.common_app.get_suc;

                    }
                }

            }
            return s;




        }

        public static void Fjzt_delete(string yydh)
        {
            SqlParameter[] sp = {
						new SqlParameter("@yydh", SqlDbType.VarChar,50)
					};
            sp[0].Value = yydh;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ffjzt_Deleate", sp);

        }



        public string Ffjzt_upload(DataSet DS_Fjzt, string yydh)
        {
            string s = common_file.common_app.get_failure;
            string table_name = "tablename"; string stryydh = yydh;

            table_name = stryydh + "Ffjzt" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            DbHelperSQLP DbHelperSQLP_new = new DbHelperSQLP();
            IDataParameter[] IDP_args ={ new SqlParameter("@pm", SqlDbType.VarChar, 50) };
            IDP_args[0].Value = table_name;
            DbHelperSQLP_new.RunProcedure("pB_Ffjzt_temp", IDP_args);
            if (DS_Fjzt != null && DS_Fjzt.Tables[0].Rows.Count > 0)
            {
                string insert_s = "";
                foreach (DataRow dr in DS_Fjzt.Tables[0].Rows)
                {
                    insert_s = "insert into " + table_name + " (yydh,qymc,zyzt,zyzt_second,zybz,fjrb_code,fjrb,fjbh,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name,krxm,ddsj,lksj,yd_ddsj,yd_lksj,bz,shlf,shts,shvip,lsbh,sktt,is_select,is_top,use_time,is_secret,czsj,cznr,czy,fjbm) values ";
                    insert_s = insert_s + "( '" + dr["yydh"].ToString() + "','" + dr["qymc"].ToString() + "','" + dr["zyzt"].ToString() + "','" + dr["zyzt_second"].ToString() + "','" + dr["zybz"].ToString() + "','" + dr["fjrb_code"].ToString() + "','" + dr["fjrb"].ToString() + "','" + dr["fjbh"].ToString() + "','" + dr["fjdh"].ToString() + "','" + dr["dhfj"].ToString() + "','" + dr["jdlh"].ToString() + "','" + dr["jdlh_name"].ToString() + "','" + dr["jdcs"].ToString() + "','" + dr["jdcs_name"].ToString() + "','" + dr["krxm"].ToString() + "','" + dr["ddsj"].ToString() + "','" + dr["lksj"].ToString() + "','" + dr["yd_ddsj"].ToString() + "','" + dr["yd_lksj"].ToString() + "','" + dr["bz"].ToString() + "',1,1,1,'" + dr["lsbh"].ToString() + "','" + dr["sktt"].ToString() + "',1,1,'" + dr["use_time"].ToString() + "',1,'" + dr["czsj"].ToString() + "','" + dr["cznr"].ToString() + "','" + dr["czy"].ToString() + "',1)";
                    DbHelperSQL.ExecuteSql(insert_s);
                }
                string strSql = "select * from " + table_name + "";
                DataSet ds = DbHelperSQL.Query(strSql);
                if (Update_fjzt(ds, stryydh) == common_file.common_app.get_suc)//添加到Qskyd_fjrb表里
                {
                    s = common_file.common_app.get_suc;
                }

            }

            DbHelperSQL.ExecuteSql("IF EXISTS (SELECT * FROM sysobjects WHERE name = '" + table_name + "') BEGIN DROP TABLE " + table_name + " END;");
            DS_Fjzt.Dispose();
            return s;
        }


        //public static void Fjzt_temp_delete(string yydh)
        //{
        //    SqlParameter[] sp = {
        //                new SqlParameter("@yydh", SqlDbType.VarChar,50)
        //            };
        //    sp[0].Value = yydh;

        //    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ffjzt_temp_Deleate", sp);

        //}
        //public static void PlAdd_fjzt(string yydh)
        //{
        //    Fjzt_temp_delete(yydh);
        //    string strSql="insert into Ffjzt_temp(yydh,qymc,zyzt,zyzt_second,zybz,fjrb_code,fjrb,fjbh,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name,krxm,ddsj,lksj,yd_ddsj,yd_lksj,bz,shlf,shts,shvip,lsbh,sktt,is_select,is_top,use_time,is_secret,czsj,cznr,czy,fjbm)";
        //    strSql += "select yydh,qymc,zyzt,zyzt_second,zybz,fjrb_code,fjrb,fjbh,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name,krxm,ddsj,lksj,yd_ddsj,yd_lksj,bz,shlf,shts,shvip,lsbh,sktt,is_select,is_top,use_time,is_secret,czsj,cznr,czy,fjbm from Ffjzt where yydh='"+yydh+"'";
        //    DbHelperSQL.ExecuteSql(strSql);

        //}
    }
}
