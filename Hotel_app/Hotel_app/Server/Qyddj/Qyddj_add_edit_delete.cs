using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Qyddj
{
    public class Qyddj_add_edit_delete
    {

        public string get_htk(string krxm, string zjhm)
        {
            string get_result = "";
            if (krxm != "" && zjhm != "")
            {
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                DataSet DS_temp = B_Common.GetList("select id from Qskyd_mainrecord_lskr", " krxm='" + krxm + "' and zjhm='" + zjhm + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    get_result = common_file.common_app.krrx_htk;
                }
                DS_temp.Clear();
                DS_temp.Dispose();
            }
            return get_result;
        }

        public string get_hy(string hykh)
        {
            string get_result = "";
            if (hykh != "")
            {
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                DataSet DS_temp = B_Common.GetList("select id from Hhygl", " hykh='" + hykh + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    get_result = common_file.common_app.krly_hy;
                }
                DS_temp.Clear();
                DS_temp.Dispose();
            }
            return get_result;
        }

        public string Qskdj_add_edit_delete(string id, string yydh,
            string qymc, string lsbh,
            string ddbh, string hykh,
            string hyrx, string krxm, string tlkr, string krgj,
            string krmz, string yxzj, string zjhm, string krxb,
            string krsr, string krdh, string krsj, string krEmail,
            string krdz, string krjg, string krdw, string krzy,
            string cxmd, string qzrx, string qzhm, string zjyxq,
            string tlyxq, string tjrq, string lzka, string krly,
            string xyh, string xydw, string xsy, string ddrx,
            string ddwz, string zyzt, string krrx, string kr_children,
            string ddsj, string lzts, string lksj, string qtyq, string czy,
            string czsj, string cznr, string sktt, string yddj,
            string main_sec, string yddj_rx,
            string syzd, string vip_type, string tsyq, string add_edit_delete, string xxzs, string ddly, string hykh_bz)
        {
            string s = common_file.common_app.get_failure;
            BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
            Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Hotel_app.Model.Qskyd_mainrecord();
            BLL.Qskyd_mainrecord_new B_Qskyd_mainrecord_new = new Hotel_app.BLL.Qskyd_mainrecord_new();
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            Model.Ffjzt M_Ffjzt = new Hotel_app.Model.Ffjzt();
            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            Model.Qskyd_fjrb M_Qskyd_fjrb = new Hotel_app.Model.Qskyd_fjrb();
            BLL.Common B_Common = new Hotel_app.BLL.Common();

            if (add_edit_delete == common_file.common_app.get_add)
            {
                if (main_sec == common_file.common_app.main_sec_sec)
                {
                    M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(int.Parse(id));

                }
                M_Qskyd_mainrecord.yydh = yydh;
                M_Qskyd_mainrecord.qymc = qymc;
                M_Qskyd_mainrecord.syzd = syzd;
                M_Qskyd_mainrecord.lsbh = lsbh;
                M_Qskyd_mainrecord.ddbh = ddbh;
                M_Qskyd_mainrecord.hykh = hykh;
                M_Qskyd_mainrecord.hyrx = hyrx;
                M_Qskyd_mainrecord.krxm = krxm;
                M_Qskyd_mainrecord.tlkr = tlkr;
                M_Qskyd_mainrecord.krgj = krgj;
                M_Qskyd_mainrecord.krmz = krmz;
                M_Qskyd_mainrecord.yxzj = yxzj;
                M_Qskyd_mainrecord.zjhm = zjhm;
                M_Qskyd_mainrecord.krxb = krxb;
                M_Qskyd_mainrecord.krsr = Convert.ToDateTime(krsr);
                M_Qskyd_mainrecord.krdh = krdh;
                M_Qskyd_mainrecord.krsj = krsj;
                M_Qskyd_mainrecord.krEmail = krEmail;
                M_Qskyd_mainrecord.krdz = krdz;
                M_Qskyd_mainrecord.krjg = krjg;
                M_Qskyd_mainrecord.krdw = krdw;
                M_Qskyd_mainrecord.krzy = krzy;
                M_Qskyd_mainrecord.cxmd = cxmd;
                M_Qskyd_mainrecord.qzrx = qzrx;
                M_Qskyd_mainrecord.qzhm = qzhm;
                M_Qskyd_mainrecord.zjyxq = Convert.ToDateTime(zjyxq);
                M_Qskyd_mainrecord.tlyxq = Convert.ToDateTime(tlyxq);
                M_Qskyd_mainrecord.tjrq = Convert.ToDateTime(tjrq);
                M_Qskyd_mainrecord.czy = czy;
                M_Qskyd_mainrecord.czsj = Convert.ToDateTime(czsj);
                M_Qskyd_mainrecord.cznr = cznr;
                M_Qskyd_mainrecord.main_sec = main_sec;
                M_Qskyd_mainrecord.vip_type = vip_type;
                M_Qskyd_mainrecord.hykh_bz = hykh_bz;
                M_Qskyd_mainrecord.krrx = krrx;
                string krrx_0 = get_htk(krxm, zjhm);
                if (krrx_0 != "")
                {
                    M_Qskyd_mainrecord.krrx = krrx_0;
                }
                if (main_sec == common_file.common_app.main_sec_main)
                {
                    M_Qskyd_mainrecord.lzka = lzka;

                    M_Qskyd_mainrecord.krly = krly;
                    if (krly == "")
                    {
                        string krly_0 = get_hy(hykh);
                        if (krly_0 != "")
                        {
                            M_Qskyd_mainrecord.krly = krly_0;
                        }
                    }
                    M_Qskyd_mainrecord.xyh = xyh;
                    M_Qskyd_mainrecord.xydw = xydw;
                    M_Qskyd_mainrecord.xsy = xsy;
                    M_Qskyd_mainrecord.ddrx = ddrx;
                    M_Qskyd_mainrecord.ddwz = ddwz;
                    M_Qskyd_mainrecord.zyzt = zyzt;
                    M_Qskyd_mainrecord.kr_children = Convert.ToInt32(kr_children);
                    M_Qskyd_mainrecord.ddsj = Convert.ToDateTime(ddsj);
                    M_Qskyd_mainrecord.lzts = Convert.ToInt32(lzts);
                    M_Qskyd_mainrecord.lksj = Convert.ToDateTime(lksj);
                    M_Qskyd_mainrecord.qtyq = qtyq;
                    M_Qskyd_mainrecord.sktt = sktt;
                    M_Qskyd_mainrecord.yddj = yddj;
                    M_Qskyd_mainrecord.tsyq = tsyq;
                    M_Qskyd_mainrecord.ddly = ddly;
                }
                B_Qskyd_mainrecord.Add(M_Qskyd_mainrecord);
                {
                    if (main_sec == common_file.common_app.main_sec_main)
                    {
                        Q_ff_xyxf Q_ff_xyxf_new = new Q_ff_xyxf();
                        Q_ff_xyxf_new.Qyddj_otherfee_add(yydh, qymc, lsbh, krxm, sktt, "", czy);
                    }
                }
                s = common_file.common_app.get_suc;
            }
            else if (add_edit_delete == common_file.common_app.get_edit)
            {
                //M_Qskyd_mainrecord.id = int.Parse(id);
                M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(int.Parse(id));
                DateTime ddsj_temp = M_Qskyd_mainrecord.ddsj;
                DateTime lksj_temp = M_Qskyd_mainrecord.lksj;
                string krxm_temp = M_Qskyd_mainrecord.krxm;
                DataSet DS_temp;
                string fjbh_temp = "";
                DS_temp = B_Qskyd_fjrb.GetList("lsbh='" + M_Qskyd_mainrecord.lsbh + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    fjbh_temp = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                    if (fjbh_temp != "")
                    {
                        //这边要判断是否有一间房间，两个主单的情况，另外如抵离时间有变动，房态里的抵离时间也要跟着变动
                        if (yddj == common_file.common_yddj.yddj_yd)
                        {
                            if (ddsj_temp != DateTime.Parse(ddsj))
                            {
                                //清除
                                if (ddsj_temp >= DateTime.Now.Date && ddsj_temp < DateTime.Now.Date.AddDays(1))
                                {
                                    //清除预订
                                    Qyddj.Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Qskyd_fjrb_add_edit_delete();
                                    s = Qskyd_fjrb_add_edit_delete_new.clear_old_yd_fjzt(fjbh_temp, M_Qskyd_mainrecord.ddsj, M_Qskyd_mainrecord.lksj, DateTime.Parse(czsj), czy, xxzs);
                                }


                                B_Common.ExecuteSql("update Qskyd_mainrecord set ddsj='" + ddsj + "',shsc=0,czsj='" + czsj + "' where lsbh in(select lsbh from View_Qskzd where fjbh='" + fjbh_temp + "' and ddsj='" + ddsj_temp + "' and lksj='" + lksj_temp + "')");
                                //B_Common.ExecuteSql("update Qskyd_fjrb set ddsj='" + ddsj + "',shsc=0,czsj='" + czsj + "' where lsbh in(select lsbh from View_Qskzd where fjbh='" + fjbh_temp + "' and ddsj='" + ddsj_temp + "' and lksj='" + lksj_temp + "')");
                                //判断新的预订是否要改房态
                                if (DateTime.Parse(ddsj) >= DateTime.Now.Date && DateTime.Parse(ddsj) < DateTime.Now.Date.AddDays(1))
                                {
                                    Qyddj.Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Qskyd_fjrb_add_edit_delete();
                                    Qskyd_fjrb_add_edit_delete_new.add_fjbh_yd_fjzt(M_Qskyd_mainrecord.lsbh, fjbh_temp, M_Qskyd_mainrecord.sktt, DateTime.Parse(czsj), czy, xxzs);
                                }
                            }
                            if (lksj_temp != DateTime.Parse(lksj))
                            {
                                string s_temp = "update Qskyd_mainrecord set lksj='" + lksj + "',shsc=0,czsj='" + czsj + "' where lsbh in(select lsbh from View_Qskzd where fjbh='" + fjbh_temp + "' and ddsj='" + ddsj + "' and lksj='" + lksj_temp + "')";
                                B_Common.ExecuteSql(s_temp);
                                //B_Common.ExecuteSql("update Qskyd_fjrb set lksj='" + lksj + "',shsc=0,czsj='" + czsj + "' where lsbh in(select lsbh from View_Qskzd where fjbh='" + fjbh_temp + "' and ddsj='" + ddsj_temp + "' and lksj='" + lksj_temp + "')");
                                s_temp = "update Ffjzt set yd_lksj='" + lksj + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + fjbh_temp + "' and yd_ddsj='" + ddsj + "' and yd_lksj='" + lksj_temp + "'";
                                B_Common.ExecuteSql(s_temp);
                            }

                        }
                        else
                            if (yddj == common_file.common_yddj.yddj_dj)
                            {
                                if (lksj_temp != DateTime.Parse(lksj))
                                {
                                    B_Common.ExecuteSql("update Qskyd_mainrecord set lksj='" + lksj + "',shsc=0,czsj='" + czsj + "' where lsbh in(select lsbh from View_Qskzd where fjbh='" + fjbh_temp + "' and ddsj='" + ddsj_temp + "' and lksj='" + lksj_temp + "')");
                                    // B_Common.ExecuteSql("update Qskyd_fjrb set lksj='" + lksj + "',shsc=0,czsj='" + czsj + "' where lsbh in(select lsbh from View_Qskzd where fjbh='" + fjbh_temp + "' and ddsj='" + ddsj_temp + "' and lksj='" + lksj_temp + "')");
                                    B_Common.ExecuteSql("update Ffjzt set lksj='" + lksj + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + fjbh_temp + "' and ddsj='" + ddsj_temp + "' and lksj='" + lksj_temp + "'");
                                }
                            }

                    }
                }
                DS_temp.Dispose();
                M_Qskyd_mainrecord.yydh = yydh;
                M_Qskyd_mainrecord.qymc = qymc;
                M_Qskyd_mainrecord.lsbh = lsbh;
                M_Qskyd_mainrecord.ddbh = ddbh;
                M_Qskyd_mainrecord.hykh = hykh;
                M_Qskyd_mainrecord.hyrx = hyrx;
                M_Qskyd_mainrecord.krxm = krxm;
                M_Qskyd_mainrecord.tlkr = tlkr;
                M_Qskyd_mainrecord.krgj = krgj;
                M_Qskyd_mainrecord.krmz = krmz;
                M_Qskyd_mainrecord.yxzj = yxzj;
                M_Qskyd_mainrecord.zjhm = zjhm;
                M_Qskyd_mainrecord.krxb = krxb;
                M_Qskyd_mainrecord.krsr = Convert.ToDateTime(krsr);
                M_Qskyd_mainrecord.krdh = krdh;
                if (M_Qskyd_mainrecord.ddyy != common_file.common_app.ydzx_flag)
                {
                    M_Qskyd_mainrecord.xsy = xsy;
                    M_Qskyd_mainrecord.xyh = xyh;
                    M_Qskyd_mainrecord.xydw = xydw;
                    M_Qskyd_mainrecord.krly = krly;
                }
                //if(M_Qskyd_mainrecord.ddyy != common_file.common_app.ydzx_flage&&M_Qskyd_mainrecord.krly != common_file.common_app.krly_xydw_flage)
                //{
                //    M_Qskyd_mainrecord.xsy = xsy;
               // }

                M_Qskyd_mainrecord.krsj = krsj;
                M_Qskyd_mainrecord.krEmail = krEmail;
                M_Qskyd_mainrecord.krdz = krdz;
                M_Qskyd_mainrecord.krjg = krjg;
                M_Qskyd_mainrecord.krdw = krdw;
                M_Qskyd_mainrecord.krzy = krzy;
                M_Qskyd_mainrecord.cxmd = cxmd;
                M_Qskyd_mainrecord.qzrx = qzrx;
                M_Qskyd_mainrecord.qzhm = qzhm;
                M_Qskyd_mainrecord.zjyxq = Convert.ToDateTime(zjyxq);
                M_Qskyd_mainrecord.tlyxq = Convert.ToDateTime(tlyxq);
                M_Qskyd_mainrecord.tjrq = Convert.ToDateTime(tjrq);
                M_Qskyd_mainrecord.lzka = lzka;

                if (krly == "")
                {
                    string krly_0 = get_hy(hykh);
                    if (krly_0 != "")
                    {
                        M_Qskyd_mainrecord.krly = krly_0;
                    }
                }

                
                M_Qskyd_mainrecord.ddrx = ddrx;
                M_Qskyd_mainrecord.ddwz = ddwz;
                M_Qskyd_mainrecord.zyzt = zyzt;
                M_Qskyd_mainrecord.krrx = krrx;
                string krrx_0 = get_htk(krxm, zjhm);
                if (krrx_0 != "")
                {
                    M_Qskyd_mainrecord.krrx = krrx_0;
                }
                M_Qskyd_mainrecord.kr_children = Convert.ToInt32(kr_children);

                if (M_Qskyd_mainrecord.yddj != common_file.common_yddj.yddj_dj)
                {
                    M_Qskyd_mainrecord.ddsj = Convert.ToDateTime(ddsj);
                }

                M_Qskyd_mainrecord.lzts = Convert.ToInt32(lzts);
                M_Qskyd_mainrecord.lksj = Convert.ToDateTime(lksj);
                M_Qskyd_mainrecord.qtyq = qtyq;
                M_Qskyd_mainrecord.czy = czy;
                M_Qskyd_mainrecord.czsj = Convert.ToDateTime(czsj);
                M_Qskyd_mainrecord.cznr = cznr;
                //M_Qskyd_mainrecord.sktt = sktt;
                //M_Qskyd_mainrecord.yddj = yddj;
                //M_Qskyd_mainrecord.main_sec = main_sec;
                M_Qskyd_mainrecord.vip_type = vip_type;
                M_Qskyd_mainrecord.tsyq = tsyq;
                M_Qskyd_mainrecord.ddly = ddly;
                M_Qskyd_mainrecord.hykh_bz = hykh_bz;
                //common_file.common_Qskyd_mainrecord.PlInter(int.Parse(id), "修改");//删除前批量添加到备份表里
                B_Qskyd_mainrecord_new.Pladd(int.Parse(id), common_file.common_app.chinese_edit, "", czy, czsj, "xg", "");
                B_Qskyd_mainrecord.Update(M_Qskyd_mainrecord);
                fjbh_temp = "";
                string shlf_temp = "0";
                bool shlf0 = common_file.common_fjzt.Islf(M_Qskyd_mainrecord.lsbh);
                if (shlf0 == true) shlf_temp = "1";
                string shts_temp = "0";
                bool shts0 = common_file.common_fjzt.Ists(M_Qskyd_mainrecord.lsbh);
                if (shts0 == true) shts_temp = "1";
                string shvip_temp = "0";
                bool shvip0 = common_file.common_fjzt.IsVIP(M_Qskyd_mainrecord.lsbh);
                if (shvip0 == true) shvip_temp = "1";
                string fjbm_temp = "0";
                bool fjbm0 = common_file.common_fjzt.Isbm(M_Qskyd_mainrecord.lsbh);
                if (fjbm0 == true) fjbm_temp = "1";
                string krxm0 = M_Qskyd_mainrecord.krxm;
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    fjbh_temp = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                    if (yddj == common_file.common_yddj.yddj_dj)
                    {
                        B_Common.ExecuteSql("update Ffjzt set krxm='" + krxm0 + "',shlf='" + shlf_temp + "',shts='" + shts_temp + "',shvip='" + shvip_temp + "',fjbm='" + fjbm_temp + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + fjbh_temp + "'");

                    }
                    else
                        if (yddj == common_file.common_yddj.yddj_yd)
                        {
                            B_Common.ExecuteSql("update Ffjzt set krxm='" + krxm0 + "',shlf='" + shlf_temp + "',shts='" + shts_temp + "',shvip='" + shvip_temp + "',fjbm='" + fjbm_temp + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + fjbh_temp + "' and yd_ddsj='" + M_Qskyd_mainrecord.ddsj + "' and yd_lksj='" + M_Qskyd_mainrecord.lksj + "' and zyzt<>'" + common_file.common_fjzt.zzf + "'");
                        }
                }
                s = common_file.common_app.get_suc;
            }
            else if (add_edit_delete == common_file.common_app.get_delete)
            {

                s = delete_sz_xgft(id, "sc", cznr, qtyq, "", czy, czsj, xxzs);
                //通过qtyq传递取消原因过来
            }
            return s;
        }

        //成批删除散客记录，主要用来webservice一次性调用，内部就不必这样了。
        public string delete_sk_multi(string[] id_arg, string czzt, string czbz, string qxyy, string jzbh, string czy, string czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            foreach (string id_0 in id_arg)
            {
                if (id_0 != null)
                {
                    s = delete_sz_xgft(id_0, czzt, czbz, qxyy, jzbh, czy, czsj, xxzs);

                }

            }
            return s;
        }


        /// <summary>
        /// 用来删除主单或退房时单据的删除和修改房态及备份相应记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="czzt"></param>两个值,一个是删除“sc”，一个是结账"jz"
        /// <param name="czbz"></param>主要是两个值，一个是“取消”，一个“未到”到common_yddj里去找
        /// <param name="qxyy"></param>取消原因
        /// <param name="jzbh"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string delete_sz_xgft(string id, string czzt, string czbz, string qxyy, string jzbh, string czy, string czsj, string xxzs)
        {
            int i_temp = 8;//用来M_Qskyd_mainrecord =NULL时判断
            string s = common_file.common_app.get_failure;
            BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
            Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Hotel_app.Model.Qskyd_mainrecord();
            BLL.Qskyd_mainrecord_new B_Qskyd_mainrecord_new = new Hotel_app.BLL.Qskyd_mainrecord_new();
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            Model.Ffjzt M_Ffjzt = new Hotel_app.Model.Ffjzt();
            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            Model.Qskyd_fjrb M_Qskyd_fjrb = new Hotel_app.Model.Qskyd_fjrb();
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            if (id != "")
            {
                DataSet DS_temp;
                M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(int.Parse(id));
                //判断预订的记录有两条房类时删除同一个主单避免出错
                if (M_Qskyd_mainrecord == null)
                { i_temp = 9; }
                else
                {
                    DS_temp = B_Qskyd_fjrb.GetList(" lsbh='" + M_Qskyd_mainrecord.lsbh + "'");
                    string fjbh_temp = "";
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {



                        //fjbh_temp = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();



                        for (int k_0 = 0; k_0 < DS_temp.Tables[0].Rows.Count; k_0++)
                        {
                            if (DS_temp.Tables[0].Rows[k_0]["fjbh"].ToString() != "")
                            {
                                fjbh_temp = DS_temp.Tables[0].Rows[k_0]["fjbh"].ToString();
                            }
                        }



                        s = common_file.common_app.get_suc;
                        if (fjbh_temp != "")
                        {
                            DS_temp = B_Ffjzt.GetList(" fjbh='" + fjbh_temp + "'");
                            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                            {
                                M_Ffjzt = B_Ffjzt.GetModel(int.Parse(DS_temp.Tables[0].Rows[0]["id"].ToString()));

                                //修改房态,把在住房改成脏房后,再判断是否有两个主单共用一个房间如有再把它改成在住.
                                if (M_Qskyd_mainrecord.yddj == common_file.common_yddj.yddj_dj)
                                {
                                    s = common_file.common_app.get_failure;
                                    //改成脏房
                                    Ffjzt.Fgj_z_yj_zzzf Fgj_z_yj_zzzf_new = new Hotel_app.Server.Ffjzt.Fgj_z_yj_zzzf();
                                    s = Fgj_z_yj_zzzf_new.set_gj_zf_yj_zzzf_qxzz(M_Ffjzt.id.ToString(), M_Qskyd_mainrecord.yydh, M_Qskyd_mainrecord.qymc, M_Ffjzt.fjbh, "zf", czy, DateTime.Parse(czsj), xxzs);
                                    //是否有两个主单共用一个房间如有再把它改成在住.
                                    DS_temp = B_Qskyd_fjrb.GetList(" fjbh='" + fjbh_temp + "' and yddj='" + common_file.common_yddj.yddj_dj + "' and lsbh<>'" + M_Qskyd_mainrecord.lsbh + "'");
                                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                                    {
                                        s = common_file.common_app.get_failure;
                                        Qyddj.Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Qskyd_fjrb_add_edit_delete();
                                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(DS_temp.Tables[0].Rows[0]["id"].ToString()));
                                        Qskyd_fjrb_add_edit_delete_new.add_fjbh_dj_fjzt(fjbh_temp, M_Qskyd_fjrb, DateTime.Parse(czsj), czy, xxzs);
                                        //把入住房数改成1
                                        B_Common.ExecuteSql("update Qskyd_fjrb set lzfs=1,czsj='" + DateTime.Now.ToString() + "',shsc=0 where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                                        s = common_file.common_app.get_suc;
                                    }
                                }
                                else
                                    if (M_Qskyd_mainrecord.yddj == common_file.common_yddj.yddj_yd)
                                    {
                                        s = common_file.common_app.get_failure;
                                        //清除预订
                                        Qyddj.Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Qskyd_fjrb_add_edit_delete();
                                        s = Qskyd_fjrb_add_edit_delete_new.clear_old_yd_fjzt(fjbh_temp, M_Qskyd_mainrecord.ddsj, M_Qskyd_mainrecord.lksj, DateTime.Parse(czsj), czy, xxzs);
                                        //是否有两个主单共用一个房间如有再把它改成预订.
                                        DS_temp = B_Qskyd_fjrb.GetList(" fjbh='" + fjbh_temp + "' and yddj='" + common_file.common_yddj.yddj_yd + "' and lsbh<>'" + M_Qskyd_mainrecord.lsbh + "' and ddsj>='" + DateTime.Now.Date.ToString() + "' and ddsj<'" + DateTime.Now.Date.AddDays(1) + "'");
                                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                                        {
                                            s = common_file.common_app.get_failure;
                                            Qskyd_fjrb_add_edit_delete_new.add_fjbh_yd_fjzt(M_Qskyd_fjrb.lsbh, fjbh_temp, M_Qskyd_fjrb.sktt, DateTime.Parse(czsj), czy, xxzs);
                                            //把入住房数改成1
                                            B_Common.ExecuteSql("update Qskyd_fjrb set lzfs=1,czsj='" + DateTime.Now.ToString() + "',shsc=0 where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                                            s = common_file.common_app.get_suc;
                                        }
                                    }

                            }
                        }
                    }

                    //DS_temp.Dispose();
                    if (s == common_file.common_app.get_suc)
                    {
                        s = common_file.common_app.get_failure;
                        //清除入住记录
                        int strid = int.Parse(id);
                        //common_file.common_Qskyd_mainrecord.PlInter(int.Parse(id), "删除");
                        B_Qskyd_mainrecord_new.Pladd(strid, czbz, qxyy, czy, czsj, czzt, jzbh);//删除前批量添加到备份表里

                        M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(strid);
                        if (M_Qskyd_mainrecord != null)
                        {
                            //为了避免触发器成批删除时只触发最后一条,删除两次
                            B_Common.ExecuteSql("delete from Qskyd_mainrecord where lsbh='" + M_Qskyd_mainrecord.lsbh + "' and main_sec='" + common_file.common_app.main_sec_main + "'");

                            B_Common.ExecuteSql("delete from Qskyd_mainrecord where lsbh='" + M_Qskyd_mainrecord.lsbh + "' and main_sec<>'" + common_file.common_app.main_sec_main + "'");

                        }

                        //if (B_Qskyd_mainrecord.Delete(strid) == true)
                        //{
                        s = common_file.common_app.get_suc;
                        //}

                    }


                }

                if (i_temp == 9)
                {
                    s = common_file.common_app.get_suc;
                }
            }



            return s;
        }


    }


}
