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


        public static void Fjzt_delete(string yydh)
        {
            SqlParameter[] sp = {
						new SqlParameter("@yydh", SqlDbType.VarChar,50)
					};
            sp[0].Value = yydh;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ffjzt_Deleate", sp);

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
