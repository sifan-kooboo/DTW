using System;
using System.Data;
using System.Configuration;


namespace Hotel_app.Server.Ffjzt
{
    /// <summary>
    /// void Ffjzt_xgft()修改房态的类
    /// 
    /// </summary>
    public partial class Ffjzt_add_edit
    {
        //房类
        public string Ffjrb_add_edit(string id, string yydh, string qymc, string fjrb_code, string fjrb, string sjjg,string zyrs, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Ffjrb B_Ffjrb = new Hotel_app.BLL.Ffjrb();
            Model.Ffjrb M_Ffjrb = new Hotel_app.Model.Ffjrb();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Ffjrb.yydh = yydh; M_Ffjrb.qymc = qymc; M_Ffjrb.fjrb_code = fjrb_code;
                M_Ffjrb.fjrb = fjrb; M_Ffjrb.sjjg = Convert.ToDecimal(sjjg); M_Ffjrb.zyrs = Convert.ToDecimal(zyrs);
                B_Ffjrb.Add(M_Ffjrb);
                s = common_file.common_app.get_suc;
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Ffjrb = B_Ffjrb.GetModel(Convert.ToInt32(id));
                    M_Ffjrb.fjrb_code = fjrb_code;
                    M_Ffjrb.fjrb = fjrb;
                    M_Ffjrb.sjjg = Convert.ToDecimal(sjjg);
                    B_Ffjrb.Update(M_Ffjrb);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "" )
                            
                        {
                            B_Ffjrb.Delete( Convert.ToInt32(id) );
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;

        }

        //房间
        public string Ffjzt_add_edit_delete(string id, string yydh, string qymc, string jdlh, string jdlh_name, string jdcs, string jdcs_name, string fjrb, string fjrb_code, string fjbh, string fjdh, string dhfj, string bz, string add_edit_delete, string xxzs) 
        {
            string s = common_file.common_app.get_failure;
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            BLL.Ffjzt B_Ffjzt_new = new Hotel_app.BLL.Ffjzt();
            Model.Ffjzt M_Ffjzt=new Hotel_app.Model.Ffjzt();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            s = add_edit_delete;
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Ffjzt.yydh = yydh; M_Ffjzt.qymc = qymc; M_Ffjzt.jdlh = jdlh;
                M_Ffjzt.jdlh_name = jdlh_name; M_Ffjzt.jdcs = jdcs; M_Ffjzt.jdcs_name = jdcs_name;
                M_Ffjzt.fjrb = fjrb; M_Ffjzt.fjrb_code = fjrb_code;
                M_Ffjzt.fjbh = fjbh; M_Ffjzt.fjdh = fjdh; M_Ffjzt.dhfj = dhfj; M_Ffjzt.bz = bz;
                M_Ffjzt.yd_ddsj = M_Ffjzt.yd_lksj = M_Ffjzt.ddsj=M_Ffjzt.lksj = DateTime.Parse(common_file.common_app.cssj);
                M_Ffjzt.czsj = DateTime.Now;
                M_Ffjzt.zyzt = common_file.common_fjzt.gjf;
                M_Ffjzt.zyzt_second = "";
                if (B_Ffjzt_new.Add(M_Ffjzt) > 0)//调用自定义类初始化房间
                {
                    s = common_file.common_app.get_suc;
                
                }
                
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Ffjzt = B_Ffjzt.GetModel(Convert.ToInt32(id));
                    M_Ffjzt.jdlh = jdlh; M_Ffjzt.jdlh_name = jdlh_name;
                    M_Ffjzt.jdcs = jdcs; M_Ffjzt.jdcs_name = jdcs_name;
                    M_Ffjzt.fjrb = fjrb; M_Ffjzt.fjrb_code = fjrb_code;
                    M_Ffjzt.fjdh = fjdh; M_Ffjzt.dhfj = dhfj; M_Ffjzt.bz = bz;
                    M_Ffjzt.czsj = DateTime.Now;
                    if (B_Ffjzt.Update(M_Ffjzt))
                    {
                        s = common_file.common_app.get_suc;
                    }
                  
                }
            else 
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if(id!=null)
                        if (id != "")
                        {
                            if (B_Ffjzt.Delete(Convert.ToInt32(id)))
                            {
                                s = common_file.common_app.get_suc;
                            }
                        }
                        
                    }
            return s;
        }

        public void Ffjzt_xgft(string zyzt, string zyzt_second, string zybz, string fjbh, string krxm, DateTime ddsj, DateTime lksj, DateTime yd_ddsj, DateTime yd_lksj, bool shlf, bool shts, bool shvip,bool fjbm, string sktt, string lsbh,DateTime czsj,string czy,string cznr, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            Model.Ffjzt M_Ffjzt = new Hotel_app.Model.Ffjzt();
            DataSet ds_temp;
            ds_temp = B_Common.GetList("select id from Ffjzt","fjbh='"+fjbh+"'");
            int id = 0;
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                id = Convert.ToInt32(ds_temp.Tables[0].Rows[0]["id"].ToString());
                M_Ffjzt = B_Ffjzt.GetModel(id);
                M_Ffjzt.zybz = zybz;
                if (zyzt == common_file.common_fjzt.zzf && M_Ffjzt.zyzt == common_file.common_fjzt.zf)
                { M_Ffjzt.zybz = common_file.common_fjzt.yjf; }
                M_Ffjzt.zyzt = zyzt; M_Ffjzt.zyzt_second = zyzt_second; 



                M_Ffjzt.krxm = krxm; M_Ffjzt.ddsj = ddsj; M_Ffjzt.lksj = lksj;
                M_Ffjzt.yd_ddsj = yd_ddsj; M_Ffjzt.yd_lksj = yd_lksj; M_Ffjzt.shlf = shlf; M_Ffjzt.fjbm = fjbm;
                M_Ffjzt.shts = shts; M_Ffjzt.shvip = shvip; M_Ffjzt.sktt = sktt;
                M_Ffjzt.lsbh = lsbh; M_Ffjzt.czsj = DateTime.Now; M_Ffjzt.czy = czy; M_Ffjzt.cznr = cznr;
                if (B_Ffjzt.Update(M_Ffjzt))
                {
                    s = common_file.common_app.get_suc;
                }

            } 
            ds_temp.Dispose();
        }
        //房态修改时要判断这些值是否要重新加载
        public void set_fj_value(out string krxm0, out string sktt0, out string lsbh0,out string zyzt_second0,out DateTime yd_ddsj0,out DateTime yd_lksj0, out bool shlf0, out bool shts0,out bool shvip0, out bool fjbm0, string sel_condition)
        {
            DataSet ds_temp;
            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            krxm0 = ""; sktt0 = ""; lsbh0 = "";
            zyzt_second0 = "";
            yd_ddsj0 =DateTime.Parse(common_file.common_app.cssj);
            yd_lksj0 =DateTime.Parse( common_file.common_app.cssj);
            shlf0 = false; shts0 = false; shvip0 = false; fjbm0 = false;
            ds_temp = B_Qskyd_fjrb.GetList(sel_condition);
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                krxm0 = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                sktt0 = ds_temp.Tables[0].Rows[0]["sktt"].ToString();
                lsbh0 = ds_temp.Tables[0].Rows[0]["lsbh"].ToString();
                shlf0 = common_file.common_fjzt.Islf(lsbh0);   //判断是否联房
                shts0 = common_file.common_fjzt.Ists(lsbh0);//判断是否特殊
                shvip0 = common_file.common_fjzt.IsVIP(lsbh0);//判断是否VIP或会员
                fjbm0 = common_file.common_fjzt.Isbm(lsbh0);
                zyzt_second0 = common_file.common_fjzt.ydf;
                yd_ddsj0 = DateTime.Parse(ds_temp.Tables[0].Rows[0]["ddsj"].ToString());
                yd_lksj0 = DateTime.Parse(ds_temp.Tables[0].Rows[0]["lksj"].ToString());
            }
            ds_temp.Dispose();
        }


        /// <summary>
        /// 改房态时修改预订的初始值
        /// </summary>
        /// <param name="zyzt"></param>
        /// <param name="fjbh"></param>
        /// <param name="ddsj"></param>
        /// <param name="lksj"></param>
        /// <param name="czsj"></param>
        /// <param name="cznr"></param>
        /// <param name="czy"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string set_yd_ft(string zyzt, string fjbh, DateTime ddsj, DateTime lksj, string czsj, string cznr, string czy, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            string krxm0 = ""; string sktt0 = ""; string lsbh0 = "";
            string zyzt_second0 = "";
            DateTime yd_ddsj0 = DateTime.Parse(common_file.common_app.cssj);
            DateTime yd_lksj0 = DateTime.Parse(common_file.common_app.cssj);
            bool shlf0 = false; bool shts0 = false; bool shvip0 = false;bool fjbm0=false;

            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            DataSet ds_temp = B_Ffjzt.GetList("fjbh='" + fjbh + "'");
            if (ds_temp.Tables[0].Rows.Count > 0)
            {
                Model.Ffjzt M_Ffjzt = B_Ffjzt.GetModel(int.Parse(ds_temp.Tables[0].Rows[0]["id"].ToString()));
                //设置初始值
                set_fj_value(out krxm0, out sktt0, out lsbh0, out zyzt_second0, out yd_ddsj0, out yd_lksj0, out shlf0, out shts0, out shvip0,out fjbm0, "fjbh='" + fjbh + "' and ddsj='" + M_Ffjzt.yd_ddsj + "' and lksj='" + M_Ffjzt.yd_lksj + "'");

                Ffjzt_xgft(zyzt, M_Ffjzt.zyzt_second, M_Ffjzt.zybz, M_Ffjzt.fjbh, krxm0, ddsj, lksj, M_Ffjzt.yd_ddsj, M_Ffjzt.yd_lksj, shlf0, shts0, shvip0, fjbm0,  sktt0, lsbh0, DateTime.Parse(czsj), czy, cznr, xxzs);
                s = common_file.common_app.get_suc;
            }
            ds_temp.Dispose();
            return s;

        }




    }
}
