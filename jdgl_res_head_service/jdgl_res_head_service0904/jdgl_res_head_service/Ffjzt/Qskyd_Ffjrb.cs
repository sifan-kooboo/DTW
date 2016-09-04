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

    public class Qskyd_Ffjrb
    {


        ////2012.05.11修改(上传二张表的ds 处理加到Q_ZB_FS_FX表里)这个没用了
        //public string Q_ZB_FS_FX_add(DataSet DS_Fwxother, DataSet DS_Qskydfjrb)
        //{
        //    BLL.Fwx_other B_Fwx_other = new BLL.Fwx_other();
        //    BLL.Qskyd_fjrb B_Qskydfjrb = new BLL.Qskyd_fjrb();
        //    string s = common_file.common_app.get_failure;
        //    if (Fwx_other_UploadDS(DS_Fwxother) == common_file.common_app.get_suc)//添加到远程的Fwx_other表成功
        //    {
        //        DataSet ds_wxf = B_Fwx_other.GetList("1=1");
        //        if (Add_Q_ZB_FS_FX(ds_wxf, 2) == common_file.common_app.get_suc)//添加到Q_ZB_Fs_fx表里
        //        {
        //            s = common_file.common_app.get_suc;

        //        }

        //    }
        //    if (Qskyd_fjrb_UploadDS(DS_Qskydfjrb) == common_file.common_app.get_suc)//添加到远程的Qskyd_fjrb表成功
        //    {
        //        DataSet ds = B_Qskydfjrb.GetList("1=1");
        //        if (Add_Q_ZB_FS_FX(ds, 1) == common_file.common_app.get_suc)//添加到Q_ZB_Fs_fx表里
        //        {
        //            s = common_file.common_app.get_suc;
        //        }

        //    }
        //    return s;
        //}
        //2012.05.11修改上传二张表的DS,然后加到各自的临时表 Qskyd_fjrb_temp,
        public string Qskyd_fjrb_temp_ADD(DataSet DS_Fwxother, DataSet DS_Qskydfjrb)
        {
            BLL.Fwx_other_temp B_Fwx_other = new BLL.Fwx_other_temp();
            BLL.Qskyd_fjrb_temp B_Qskydfjrb = new BLL.Qskyd_fjrb_temp();

            string s = common_file.common_app.get_failure;
            string stryydh = DS_Qskydfjrb.Tables[0].Rows[0]["yydh"].ToString();
            if (DS_Fwxother.Tables[0].Rows.Count > 0)
            {
                s = Fwx_other_upload(DS_Fwxother, stryydh);
                //if (Fwx_other_UploadDS(DS_Fwxother) == common_file.common_app.get_suc)//添加到远程的Fwx_other_temp表成功
                //{
                //    DataSet ds_Fwx_other_temp = B_Fwx_other.GetList("yydh='" + stryydh + "'");
                //    if (Add_Fwx_other(ds_Fwx_other_temp, stryydh) == common_file.common_app.get_suc)//添加到Qskyd_fjrb表里
                //    {
                //        s = common_file.common_app.get_suc;
                //    }
                //}
            }
            if (DS_Qskydfjrb.Tables[0].Rows.Count > 0)
            {
                s = Qskyd_fjrb_upload(DS_Qskydfjrb, stryydh);
                //if (Qskyd_fjrb_UploadDS(DS_Qskydfjrb) == common_file.common_app.get_suc)//添加到远程的Qskyd_fjrb_temp表成功
                //{
                //    DataSet ds = B_Qskydfjrb.GetList("yydh='"+stryydh+"'");
                //    if (Add_Qskyd_fjrb(ds,stryydh) == common_file.common_app.get_suc)//添加到Qskyd_fjrb表里
                //    {
                //        s = common_file.common_app.get_suc;
                //    }

                //}
            }
            return s;


        }


        public string Fwx_other_upload(DataSet DS_Fwxother, string yydh)
        {
            string s = common_file.common_app.get_failure;
            string table_name = "tablename"; string stryydh = yydh;

            table_name = stryydh + "Fwx_other" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            DbHelperSQLP DbHelperSQLP_new = new DbHelperSQLP();
            IDataParameter[] IDP_args ={ new SqlParameter("@pm", SqlDbType.VarChar, 50) };
            IDP_args[0].Value = table_name;
            DbHelperSQLP_new.RunProcedure("pB_Fwx_other_temp", IDP_args);
            if (DS_Fwxother != null && DS_Fwxother.Tables[0].Rows.Count > 0)
            {
                string insert_s = "";
                foreach (DataRow dr in DS_Fwxother.Tables[0].Rows)
                {
                    insert_s = "insert into " + table_name + " (yydh,qymc,lsbh,fjrb,fjbh,ddsj,lksj,bz,zyzt,czsj,cznr,czy,is_top,is_select,shsc) values ";
                    insert_s = insert_s + "('" + dr["yydh"].ToString() + "','" + dr["qymc"].ToString() + "','" + dr["lsbh"].ToString() + "','" + dr["fjrb"].ToString() + "','" + dr["fjbh"].ToString() + "','" + dr["ddsj"].ToString() + "','" + dr["lksj"].ToString() + "','" + dr["bz"].ToString() + "','" + dr["zyzt"].ToString() + "','" + dr["czsj"].ToString() + "','" + dr["cznr"].ToString() + "','" + dr["czy"].ToString() + "',1,1,1)";
                    DbHelperSQL.ExecuteSql(insert_s);
                }
                string strSql = "select * from " + table_name + "";
                DataSet ds_Fwx_other_temp = DbHelperSQL.Query(strSql);
                if (Add_Fwx_other(ds_Fwx_other_temp, stryydh) == common_file.common_app.get_suc)//添加到Qskyd_fjrb表里
                {
                    s = common_file.common_app.get_suc;
                }

            }

            DbHelperSQL.ExecuteSql("IF EXISTS (SELECT * FROM sysobjects WHERE name = '" + table_name + "') BEGIN DROP TABLE " + table_name + " END;");
            DS_Fwxother.Dispose();
            return s;
        }


        public string Qskyd_fjrb_upload(DataSet DS_Qskydfjrb, string yydh)
        {
            string s = common_file.common_app.get_failure;
            string table_name = "tablename"; string stryydh = yydh;

            table_name = stryydh + "Qskyd_fjrb" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            DbHelperSQLP DbHelperSQLP_new = new DbHelperSQLP();
            IDataParameter[] IDP_args ={ new SqlParameter("@pm", SqlDbType.VarChar, 50) };
            IDP_args[0].Value = table_name;
            DbHelperSQLP_new.RunProcedure("pB_Qskyd_fjrb_temp", IDP_args);
            if (DS_Qskydfjrb != null && DS_Qskydfjrb.Tables[0].Rows.Count > 0)
            {
                string insert_s = "";
                foreach(DataRow dr in DS_Qskydfjrb.Tables[0].Rows)
                {
                    insert_s = "insert into " + table_name + " (yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,fjbm) values ";
                    insert_s = insert_s + "('" + dr["yydh"].ToString() + "','" + dr["qymc"].ToString() + "','" + dr["lsbh"].ToString() + "','" + dr["krxm"].ToString() + "','" + dr["sktt"].ToString() + "','" + dr["yddj"].ToString() + "','" + dr["fjrb"].ToString() + "','" + dr["fjbh"].ToString() + "','" + dr["ddsj"].ToString() + "','" + dr["lksj"].ToString() + "','" + dr["lzfs"].ToString() + "','" + dr["shqh"].ToString() + "','" + dr["fjjg"].ToString() + "','" + dr["sjfjjg"].ToString() + "','" + dr["yh"].ToString() + "','" + dr["yhbl"].ToString() + "','" + dr["bz"].ToString() + "',1,1,1,'" + dr["czy"].ToString() + "','" + dr["czsj"].ToString() + "','" + dr["cznr"].ToString() + "',1,'" + dr["fjbm"].ToString() + "')";
                    DbHelperSQL.ExecuteSql(insert_s);
                }
                string strSql = "select * from " + table_name + "";
                DataSet ds = DbHelperSQL.Query(strSql);
                if (Add_Qskyd_fjrb(ds, stryydh) == common_file.common_app.get_suc)//添加到Qskyd_fjrb表里
                {
                    s = common_file.common_app.get_suc;
                }

            }

            DbHelperSQL.ExecuteSql("IF EXISTS (SELECT * FROM sysobjects WHERE name = '" + table_name + "') BEGIN DROP TABLE " + table_name + " END;");
            DS_Qskydfjrb.Dispose();
            return s;
        }



        public string Fwx_other_UploadDS(DataSet DS_Fwxother) //上传Fwx_other ds添加到远程表里
        {
            DbHelperSQLP Helpsql = new DbHelperSQLP();
            string s = common_file.common_app.get_failure;
            //id,yydh,qymc,lsbh,fjrb,fjbh,ddsj,lksj,bz,zyzt,czsj,cznr,czy,is_top,is_select,shsc
            BLL.Fwx_other_temp B_Fwx_other = new BLL.Fwx_other_temp();
            Model.Fwx_other_temp M_Fwx_other = new Model.Fwx_other_temp();
            if (DS_Fwxother != null && DS_Fwxother.Tables[0].Rows.Count > 0)
            {
                string dsqymc = DS_Fwxother.Tables[0].Rows[0]["yydh"].ToString();
                DbHelperSQL.ExecuteSql("delete from Fwx_other_temp where yydh='" + dsqymc + "'");
                foreach (DataRow dr in DS_Fwxother.Tables[0].Rows)
                {

                    SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@bz", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
                    parameters[0].Value = dr[1];
                    parameters[1].Value = dr[2];
                    parameters[2].Value = dr[3];
                    parameters[3].Value = dr[4];
                    parameters[4].Value = dr[5];
                    parameters[5].Value = Convert.ToDateTime(dr[6]);
                    parameters[6].Value = Convert.ToDateTime(dr[7]);
                    parameters[7].Value = dr[8];
                    parameters[8].Value = dr[9];
                    parameters[9].Value = Convert.ToDateTime(dr[10]);
                    parameters[10].Value = dr[11];
                    parameters[11].Value = dr[12];
                    parameters[12].Value = Convert.ToBoolean(dr[13]);
                    parameters[13].Value = Convert.ToBoolean(dr[14]);
                    parameters[14].Value = true;
                    Helpsql.RunProcedure("Fwx_other_temp_ADD", parameters);
                    s = common_file.common_app.get_suc;
                }

            }
            return s;

        }

        public string Qskyd_fjrb_UploadDS(DataSet DS_Qskydfjrb)  //上传Qskyd_fjrb ds添加到远程Qskyd_fjrb_tem临时表
        {
            //id,yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,fjbm
            string s = common_file.common_app.get_failure;
            BLL.Qskyd_fjrb_temp B_Qskydfjrb = new BLL.Qskyd_fjrb_temp();
            Model.Qskyd_fjrb_temp M_Qskydfjrb = new Model.Qskyd_fjrb_temp();

            if (DS_Qskydfjrb != null && DS_Qskydfjrb.Tables[0].Rows.Count > 0)
            {
                string dsqymc = DS_Qskydfjrb.Tables[0].Rows[0]["yydh"].ToString();
                DbHelperSQL.ExecuteSql("delete from Qskyd_fjrb_temp where yydh='" + dsqymc + "'");
                foreach (DataRow dr in DS_Qskydfjrb.Tables[0].Rows)
                {
                    //string hykh_service = dr["lsbh"].ToString();
                    M_Qskydfjrb.yydh = dr["yydh"].ToString();
                    M_Qskydfjrb.qymc = dr["qymc"].ToString();
                    M_Qskydfjrb.lsbh = dr["lsbh"].ToString();
                    M_Qskydfjrb.krxm = dr["krxm"].ToString();
                    M_Qskydfjrb.sktt = dr["sktt"].ToString();
                    M_Qskydfjrb.yddj = dr["yddj"].ToString();
                    M_Qskydfjrb.fjrb = dr["fjrb"].ToString();
                    M_Qskydfjrb.fjbh = dr["fjbh"].ToString();
                    M_Qskydfjrb.ddsj = Convert.ToDateTime(dr["ddsj"].ToString());
                    M_Qskydfjrb.lksj = Convert.ToDateTime(dr["lksj"].ToString());
                    M_Qskydfjrb.lzfs = Convert.ToDecimal(dr["lzfs"].ToString());
                    M_Qskydfjrb.shqh = dr["shqh"].ToString();
                    M_Qskydfjrb.fjjg = Convert.ToDecimal(dr["fjjg"].ToString());
                    M_Qskydfjrb.sjfjjg = Convert.ToDecimal(dr["sjfjjg"].ToString());
                    M_Qskydfjrb.yh = dr["yh"].ToString();
                    M_Qskydfjrb.yhbl = Convert.ToDecimal(dr["yhbl"].ToString());
                    M_Qskydfjrb.bz = dr["bz"].ToString();
                    M_Qskydfjrb.shsc = true;
                    M_Qskydfjrb.czy = dr["czy"].ToString();
                    M_Qskydfjrb.czsj = Convert.ToDateTime(dr["czsj"].ToString());
                    M_Qskydfjrb.cznr = dr["cznr"].ToString();
                    M_Qskydfjrb.sdcz = Convert.ToBoolean(dr["sdcz"].ToString());
                    M_Qskydfjrb.fjbm = dr["fjbm"].ToString();
                    if (B_Qskydfjrb.Add(M_Qskydfjrb) > 0)
                    {

                        s = common_file.common_app.get_suc;
                    }
                }

            }
            return s;
        }

        //2012.5.11本地传到远程的Qskyd_fjrb_temp然后在添加到Qskyd_fjrb表
        //1.如果有相同的lsbh就修改，否者添加。
        //2.最后和Qskyd_fjrb_temp这张表对比，如果Qskyd_fjrb not in(lsbh)的条件就删除
        //这样做是怕本的删除了远程有可能还有这条记录在
        public static string Add_Qskyd_fjrb(DataSet DS_Qskyd_fjrb, string yydh)
        {
            // id,yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,
            //is_select,shsc,czy,czsj,cznr,sdcz,fjbm,jcje
            string s = common_file.common_app.get_failure;
            if (DS_Qskyd_fjrb != null && DS_Qskyd_fjrb.Tables[0].Rows.Count > 0)
            {
                Model.Qskyd_fjrb M_Qskyd_fjrb = new Model.Qskyd_fjrb();
                BLL.Qskyd_fjrb B_Qskyd_fjrb = new BLL.Qskyd_fjrb();
                string strlsbh_ds = ""; //记录总的lsbh以“，”号隔开
                foreach (DataRow dr in DS_Qskyd_fjrb.Tables[0].Rows)
                {
                    string strLsbh = dr["lsbh"].ToString();
                    M_Qskyd_fjrb.lsbh = dr["lsbh"].ToString();
                    M_Qskyd_fjrb.yydh = dr["yydh"].ToString();
                    M_Qskyd_fjrb.qymc = dr["qymc"].ToString();
                    M_Qskyd_fjrb.krxm = dr["krxm"].ToString();
                    M_Qskyd_fjrb.sktt = dr["sktt"].ToString();
                    M_Qskyd_fjrb.yddj = dr["yddj"].ToString();
                    M_Qskyd_fjrb.fjrb = dr["fjrb"].ToString();
                    M_Qskyd_fjrb.fjbh = dr["fjbh"].ToString();
                    M_Qskyd_fjrb.ddsj = Convert.ToDateTime(dr["ddsj"].ToString());
                    M_Qskyd_fjrb.lksj = Convert.ToDateTime(dr["lksj"].ToString());
                    M_Qskyd_fjrb.lzfs = Convert.ToDecimal(dr["lzfs"].ToString());
                    M_Qskyd_fjrb.shqh = dr["shqh"].ToString();
                    M_Qskyd_fjrb.fjjg = Convert.ToDecimal(dr["fjjg"].ToString());
                    M_Qskyd_fjrb.sjfjjg = Convert.ToDecimal(dr["sjfjjg"].ToString());
                    M_Qskyd_fjrb.yh = "";
                    M_Qskyd_fjrb.yhbl = 0;
                    M_Qskyd_fjrb.bz = "";
                    M_Qskyd_fjrb.is_top = false;
                    M_Qskyd_fjrb.is_select = false;
                    M_Qskyd_fjrb.shsc = true;
                    M_Qskyd_fjrb.czy = dr["czy"].ToString();
                    M_Qskyd_fjrb.czsj = Convert.ToDateTime(dr["czsj"].ToString());
                    M_Qskyd_fjrb.cznr = dr["cznr"].ToString();

                    //如果有相同lsbh就修改，，然后添加。
                    DataSet ds = B_Qskyd_fjrb.GetList("lsbh='" + strLsbh + "' and fjrb='" + dr["fjrb"].ToString() + "'");

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        int fid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                        M_Qskyd_fjrb.id = fid;
                        if (B_Qskyd_fjrb.Update(M_Qskyd_fjrb))
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                    else
                    {

                        //添加到Qskyd_fjrb表里
                        if (B_Qskyd_fjrb.Add(M_Qskyd_fjrb) > 0)
                        {

                            s = common_file.common_app.get_suc;
                        }


                    }

                    strlsbh_ds += "'" + strLsbh + "'" + ",";  //累加lsbh以“，”号相隔

                }
                s = common_file.common_app.get_suc;
                //相反不相等的话就删除，防止本地删除中央服务器还没有删除lsbh not in
                if (strlsbh_ds.Length != 0)
                {
                    strlsbh_ds = strlsbh_ds.Remove(strlsbh_ds.Length - 1, 1);//删除最后一个，号
                    string strsql = "delete from Qskyd_fjrb where lsbh not in(" + strlsbh_ds + ") and yydh='" + yydh + "'";

                    DbHelperSQL.Exists(strsql);
                    s = common_file.common_app.get_suc;
                }

            }
            return s;




        }






        //从Fwx_other_temp表里添加到Fwx_other表
        public static string Add_Fwx_other(DataSet DS_Fwx_other_temp, string yydh)
        {
            string s = common_file.common_app.get_failure;
            if (DS_Fwx_other_temp != null && DS_Fwx_other_temp.Tables[0].Rows.Count > 0)
            {
                Model.Fwx_other M_Fwx_other = new Model.Fwx_other();
                BLL.Fwx_other B_Fwx_other = new BLL.Fwx_other();
                string strlsbh_ds = ""; //记录总的lsbh以“，”号隔开
                foreach (DataRow dr in DS_Fwx_other_temp.Tables[0].Rows)
                {
                    string strLsbh = dr["lsbh"].ToString();

                    M_Fwx_other.yydh = dr["yydh"].ToString();
                    M_Fwx_other.qymc = dr["qymc"].ToString();
                    M_Fwx_other.lsbh = dr["lsbh"].ToString();
                    M_Fwx_other.fjrb = dr["fjrb"].ToString();
                    M_Fwx_other.fjbh = dr["fjbh"].ToString();
                    M_Fwx_other.ddsj = Convert.ToDateTime(dr["ddsj"].ToString());
                    M_Fwx_other.lksj = Convert.ToDateTime(dr["lksj"].ToString());
                    M_Fwx_other.bz = dr["bz"].ToString();
                    M_Fwx_other.zyzt = dr["zyzt"].ToString();
                    M_Fwx_other.czsj = Convert.ToDateTime(dr["czsj"].ToString());
                    M_Fwx_other.cznr = dr["cznr"].ToString();
                    M_Fwx_other.czy = dr["czy"].ToString();
                    M_Fwx_other.shsc = true;

                    //如果有相同lsbh就修改，，然后添加。
                    DataSet ds = B_Fwx_other.GetList("lsbh='" + strLsbh + "'");

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        int fid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                        M_Fwx_other.id = fid;
                        if (B_Fwx_other.Update(M_Fwx_other))
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                    else
                    {

                        //添加到Qskyd_fjrb表里
                        if (B_Fwx_other.Add(M_Fwx_other) > 0)
                        {

                            s = common_file.common_app.get_suc;
                        }


                    }

                    strlsbh_ds += "'" + strLsbh + "'" + ",";  //累加lsbh以“，”号相隔

                }
                s = common_file.common_app.get_suc;
                //相反不相等的话就删除，防止本地删除中央服务器还没有删除lsbh not in
                if (strlsbh_ds.Length != 0)
                {
                    strlsbh_ds = strlsbh_ds.Remove(strlsbh_ds.Length - 1, 1);//删除最后一个，号
                    string strsql = "delete from Fwx_other where lsbh not in(" + strlsbh_ds + ") and yydh='" + yydh + "'";
                    DbHelperSQL.Exists(strsql);
                    s = common_file.common_app.get_suc;
                }

            }
            return s;




        }



        ////（将ds加到Q_ZB_FS_FX过程type=1为Qskyd_fjrb 的ds,type=2时为表Fwx_other的ds）这个不用了
        //public static string Add_Q_ZB_FS_FX(DataSet DS_Qskyd_fjrb,int type)
        //{
        //    string s = common_file.common_app.get_failure;
        //        //id,yydh,qymc,lsbh,fjrb,fjbh,ddrq,lkrq,ddsj,lksj,lzfs,zyzt
        //    if (DS_Qskyd_fjrb != null && DS_Qskyd_fjrb.Tables[0].Rows.Count > 0)
        //    {
        //        Model.Q_zb_fs_fx M_Qzbfsfx = new Model.Q_zb_fs_fx();
        //        BLL.Q_zb_fs_fx B_Qzbfsfx = new BLL.Q_zb_fs_fx();
        //        string strlsbh_ds = "";

        //        foreach (DataRow dr in DS_Qskyd_fjrb.Tables[0].Rows)
        //        {
        //            string strLsbh = dr["lsbh"].ToString();
        //            M_Qzbfsfx.yydh = dr["yydh"].ToString();
        //            M_Qzbfsfx.qymc = dr["qymc"].ToString();
        //            M_Qzbfsfx.lsbh = dr["lsbh"].ToString();
        //            M_Qzbfsfx.fjrb = dr["fjrb"].ToString();
        //            M_Qzbfsfx.fjbh = dr["fjbh"].ToString();
        //            M_Qzbfsfx.ddsj = Convert.ToDateTime(dr["ddsj"].ToString());
        //            M_Qzbfsfx.lksj = Convert.ToDateTime(dr["lksj"].ToString());

        //            M_Qzbfsfx.lkrq = Convert.ToDateTime(dr["lksj"].ToString()).Date;
        //            DateTime lkrq = Convert.ToDateTime(dr["lksj"].ToString()).Date;
        //            DateTime ddrq = Convert.ToDateTime(dr["ddsj"].ToString()).Date;
        //            M_Qzbfsfx.lkrq = lkrq;
        //            M_Qzbfsfx.ddrq = ddrq;
        //            if (type == 1)  //从Qskyd_fjrb加入
        //            {
        //                M_Qzbfsfx.lzfs = Convert.ToDecimal(dr["lzfs"].ToString());
        //                if (lkrq == ddrq) //如果离开日期等于低达日期lzfs=0
        //                {
        //                    M_Qzbfsfx.lzfs = 0;
        //                }
        //                else if (lkrq > ddrq)  //如果离开日期>低达日期 哪么离开日期要往前加1天
        //                {
        //                    M_Qzbfsfx.lkrq = lkrq.AddDays(-1);
        //                }
        //                M_Qzbfsfx.zyzt = dr["yddj"].ToString();

        //            }
        //            else if (type == 2)//从Fwx_other加入
        //            {
        //                M_Qzbfsfx.lzfs = 1;
        //                M_Qzbfsfx.zyzt = dr["zyzt"].ToString();

        //            }


        //            //如果有相同lsbh就修改，相反不相等的话就删除，然后添加。
        //            DataSet ds = B_Qzbfsfx.GetList("lsbh='" + strLsbh + "'");

        //            if (ds != null && ds.Tables[0].Rows.Count > 0)
        //            {
        //                int fid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
        //                M_Qzbfsfx.id = fid;
        //                if (B_Qzbfsfx.Update(M_Qzbfsfx))
        //                {
        //                    s = common_file.common_app.get_suc;
        //                }
        //            }
        //            else
        //            {
        //                //int fid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
        //                //如果没有的话有可能是本的删除但还保留在Q_zb_fs_fx表里,所以这时候就要先删除在添加

        //                //B_Qzbfsfx.Delete(fid);
        //                //添加到Q_zb_fs_fx表里
        //                if (B_Qzbfsfx.Add(M_Qzbfsfx) > 0)
        //                {

        //                    s = common_file.common_app.get_suc;
        //                }


        //            }
        //            strlsbh_ds+="'"+strLsbh+"'"+",";

        //        }
        //        if (strlsbh_ds.Length != 0)
        //        {
        //            string strwhere = " and zyzt='维修房' or zyzt='其它房'";
        //            if (type == 1)
        //            {
        //                strwhere = " and zyzt in('预订','登记')";

        //            }
        //            strlsbh_ds = strlsbh_ds.Remove(strlsbh_ds.Length - 1, 1);//删除最后一个，号
        //            string strsql = "delete from Q_zb_fs_fx where lsbh not in(" + strlsbh_ds + ") " + strwhere + "";
        //            DbHelperSQL.Exists(strsql);
        //            s = common_file.common_app.get_suc;
        //        }



        //    }
        //    return  s ;

        //}

        //public static void PlAdd_Fwx_other(string yydh)
        //{
        //    Fwx_other_delete(yydh);
        //    string strSql = "insert into Fwx_other(yydh,qymc,lsbh,fjrb,fjbh,ddsj,lksj,bz,zyzt,czsj,cznr,czy,is_top,is_select,shsc)";
        //    strSql += "select yydh,qymc,lsbh,fjrb,fjbh,ddsj,lksj,bz,zyzt,czsj,cznr,czy,is_top,is_select,shsc from Fwx_other_temp  where yydh='" + yydh + "'";
        //    DbHelperSQL.ExecuteSql(strSql);

        //}

        //public static void Fwx_other_delete(string yydh)
        //{
        //    SqlParameter[] sp = {
        //                new SqlParameter("@yydh", SqlDbType.VarChar,50)
        //            };
        //    sp[0].Value = yydh;

        //    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Fwx_other_Deleate", sp);

        //}


    }
}
