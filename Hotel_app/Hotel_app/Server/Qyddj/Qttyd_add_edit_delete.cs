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
    public class Qttyd_add_edit_delete
    {
        public string Qttyd_add_edit_delete_app(string id, string yydh, string qymc, string lsbh, string ddbh, string krxm, string krbh, string yddj, string sktt, string krgj, string krdz, string krly, string xyh, string xydw, string xsy, string krdh, string krsj, string kremail, string ydrxm, string ddsj, string lzts, string lksj, string qtyq, string ddrx, string ddwz, string zyzt, string czy, string cznr, string czsj, string syzd, string tsyq, string add_edit_delete, string xxzs, string ddly)
        {
            string s = common_file.common_app.get_failure;
            Model.Qttyd_mainrecord M_Qttyd_mainrecord = new Hotel_app.Model.Qttyd_mainrecord();
            BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
            //DataSet Ds_temp;
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Qttyd_mainrecord.cznr = cznr;
                M_Qttyd_mainrecord.czsj = Convert.ToDateTime(czsj);
                M_Qttyd_mainrecord.czy = czy;
                M_Qttyd_mainrecord.ddbh = ddbh;
                M_Qttyd_mainrecord.ddrx = ddrx;
                M_Qttyd_mainrecord.ddsj = Convert.ToDateTime(ddsj);
                M_Qttyd_mainrecord.ddwz = ddwz;
                M_Qttyd_mainrecord.krbh = krbh;
                M_Qttyd_mainrecord.krdh = krdh;
                M_Qttyd_mainrecord.krdz = krdz;
                M_Qttyd_mainrecord.krEmail = kremail;
                M_Qttyd_mainrecord.krgj = krgj;
                M_Qttyd_mainrecord.krly = krly;
                M_Qttyd_mainrecord.krsj = krsj;
                M_Qttyd_mainrecord.krxm = krxm;
                M_Qttyd_mainrecord.lksj = Convert.ToDateTime(lksj);
                M_Qttyd_mainrecord.lsbh = lsbh;
                M_Qttyd_mainrecord.lzts = Convert.ToInt32(lzts);
                M_Qttyd_mainrecord.qtyq = qtyq;
                M_Qttyd_mainrecord.qymc = qymc;
                M_Qttyd_mainrecord.sktt = sktt;
                M_Qttyd_mainrecord.syzd = syzd;
                M_Qttyd_mainrecord.tsyq = tsyq;
                M_Qttyd_mainrecord.xsy = xsy;
                M_Qttyd_mainrecord.xydw = xydw;
                M_Qttyd_mainrecord.xyh = xyh;
                M_Qttyd_mainrecord.yddj = yddj;
                M_Qttyd_mainrecord.ydrxm = ydrxm;
                M_Qttyd_mainrecord.yydh = yydh;
                M_Qttyd_mainrecord.zyzt = zyzt;
                M_Qttyd_mainrecord.ddly = ddly;
                int IsAdd = B_Qttyd_mainrecord.Add(M_Qttyd_mainrecord);
                if (IsAdd > 0)
                {
                    s = common_file.common_app.get_suc;
                }

            }
            else if (add_edit_delete == common_file.common_app.get_edit)
            {
                M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModel(int.Parse(id));
                if (M_Qttyd_mainrecord != null)
                {
                    DateTime ddsj_temp = M_Qttyd_mainrecord.ddsj;
                    DateTime lksj_temp = M_Qttyd_mainrecord.lksj;
                    M_Qttyd_mainrecord.id = int.Parse(id);
                    M_Qttyd_mainrecord.cznr = cznr;
                    M_Qttyd_mainrecord.czsj = Convert.ToDateTime(czsj);
                    M_Qttyd_mainrecord.czy = czy;
                    M_Qttyd_mainrecord.ddbh = ddbh;
                    M_Qttyd_mainrecord.ddrx = ddrx;
                    M_Qttyd_mainrecord.ddsj = Convert.ToDateTime(ddsj);
                    M_Qttyd_mainrecord.ddwz = ddwz;
                    M_Qttyd_mainrecord.krbh = krbh;
                    M_Qttyd_mainrecord.krdh = krdh;
                    M_Qttyd_mainrecord.krdz = krdz;
                    M_Qttyd_mainrecord.krEmail = kremail;
                    M_Qttyd_mainrecord.krgj = krgj;

                    M_Qttyd_mainrecord.krsj = krsj;
                    M_Qttyd_mainrecord.krxm = krxm;
                    M_Qttyd_mainrecord.lksj = Convert.ToDateTime(lksj);
                    M_Qttyd_mainrecord.lsbh = lsbh;
                    M_Qttyd_mainrecord.lzts = Convert.ToInt32(lzts);
                    M_Qttyd_mainrecord.qtyq = qtyq;
                    M_Qttyd_mainrecord.qymc = qymc;
                    M_Qttyd_mainrecord.sktt = sktt;
                    M_Qttyd_mainrecord.syzd = syzd;
                    M_Qttyd_mainrecord.tsyq = tsyq;

                    M_Qttyd_mainrecord.yddj = yddj;
                    M_Qttyd_mainrecord.ydrxm = ydrxm;
                    M_Qttyd_mainrecord.yydh = yydh;
                    M_Qttyd_mainrecord.zyzt = zyzt;
                    M_Qttyd_mainrecord.ddly = ddly;

                    if (M_Qttyd_mainrecord.ddyy != common_file_server.common_app.ydzx_flage)
                    {
                        M_Qttyd_mainrecord.xsy = xsy;
                        M_Qttyd_mainrecord.xydw = xydw;
                        M_Qttyd_mainrecord.krly = krly;
                        M_Qttyd_mainrecord.xyh = xyh;
                    }
                    //if (M_Qttyd_mainrecord.ddyy != common_file.common_app.ydzx_flage&&M_Qttyd_mainrecord.krly != common_file.common_app.krly_xydw_flage)
                    //{
                   //     M_Qttyd_mainrecord.xsy = xsy;
                   // }


                    if (ddsj_temp != M_Qttyd_mainrecord.ddsj || lksj_temp != M_Qttyd_mainrecord.lksj)
                    {
                        DataSet ds_temp_0;
                        BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
                        ds_temp_0 = B_Qskyd_mainrecord.GetList("ddbh='" + M_Qttyd_mainrecord.ddbh + "'");
                        if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                        {
                            Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Hotel_app.Model.Qskyd_mainrecord();
                            for (int i_temp_0 = 0; i_temp_0 < ds_temp_0.Tables[0].Rows.Count; i_temp_0++)
                            {
                                M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(int.Parse(ds_temp_0.Tables[0].Rows[i_temp_0]["id"].ToString()));
                                if (M_Qskyd_mainrecord != null)
                                {
                                    Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Qyddj_add_edit_delete();
                                    Qyddj_add_edit_delete_new.Qskdj_add_edit_delete(M_Qskyd_mainrecord.id.ToString(), M_Qskyd_mainrecord.yydh,
            M_Qskyd_mainrecord.qymc, M_Qskyd_mainrecord.lsbh,
            M_Qskyd_mainrecord.ddbh, M_Qskyd_mainrecord.hykh,
            M_Qskyd_mainrecord.hyrx, M_Qskyd_mainrecord.krxm, M_Qskyd_mainrecord.tlkr, M_Qskyd_mainrecord.krgj,
            M_Qskyd_mainrecord.krmz, M_Qskyd_mainrecord.yxzj, M_Qskyd_mainrecord.zjhm, M_Qskyd_mainrecord.krxb,
            M_Qskyd_mainrecord.krsr.ToString(), M_Qskyd_mainrecord.krdh, M_Qskyd_mainrecord.krsj, M_Qskyd_mainrecord.krEmail,
            M_Qskyd_mainrecord.krdz, M_Qskyd_mainrecord.krjg, M_Qskyd_mainrecord.krdw, M_Qskyd_mainrecord.krzy,
            M_Qskyd_mainrecord.cxmd, M_Qskyd_mainrecord.qzrx, M_Qskyd_mainrecord.qzhm, M_Qskyd_mainrecord.zjyxq.ToString(),
            M_Qskyd_mainrecord.tlyxq.ToString(), M_Qskyd_mainrecord.tjrq.ToString(), M_Qskyd_mainrecord.lzka, M_Qskyd_mainrecord.krly,
            M_Qttyd_mainrecord.xyh, M_Qttyd_mainrecord.xydw, M_Qttyd_mainrecord.xsy, M_Qttyd_mainrecord.ddrx,
            M_Qttyd_mainrecord.ddwz, M_Qttyd_mainrecord.zyzt, M_Qskyd_mainrecord.krrx, M_Qskyd_mainrecord.kr_children.ToString(),
            M_Qttyd_mainrecord.ddsj.ToString(), M_Qttyd_mainrecord.lzts.ToString(), M_Qttyd_mainrecord.lksj.ToString(), M_Qskyd_mainrecord.qtyq, czy,
            czsj, cznr, M_Qttyd_mainrecord.sktt, M_Qttyd_mainrecord.yddj,
            M_Qskyd_mainrecord.main_sec, M_Qskyd_mainrecord.yddj,
            M_Qttyd_mainrecord.syzd, M_Qskyd_mainrecord.vip_type, M_Qskyd_mainrecord.tsyq, add_edit_delete, xxzs, M_Qttyd_mainrecord.ddly, M_Qskyd_mainrecord.hykh_bz);

                                }

                            }

                        }
                        ds_temp_0.Dispose();

                    }
                    if (B_Qttyd_mainrecord.Update(M_Qttyd_mainrecord))
                    {
                        s = common_file.common_app.get_suc;

                    }


                }


            }
            else if (add_edit_delete == common_file.common_app.get_delete)
            {
                if (id != "")
                {

                    s = delete_sz_ttyd(id, "sc", cznr, qtyq, "", czy, czsj, xxzs);
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
        public string delete_sz_ttyd(string id, string czzt, string czbz, string qxyy, string jzbh, string czy, string czsj, string xxzs)
        {
            int i_temp = 8;//用来M_Qskyd_mainrecord =NULL时判断
            string s = common_file.common_app.get_failure;
            BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
            Model.Qttyd_mainrecord M_Qttyd_mainrecord = new Hotel_app.Model.Qttyd_mainrecord();
            BLL.Qttyd_mainrecord_new B_Qttyd_mainrecord_new = new Hotel_app.BLL.Qttyd_mainrecord_new();
            Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Qyddj_add_edit_delete();
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            if (id != "")
            {
                DataSet DS_temp;
                M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModel(int.Parse(id));
                //判断预订的记录有两条房类时删除同一个主单避免出错
                if (M_Qttyd_mainrecord == null)
                { i_temp = 9; }
                else
                {
                    s = common_file.common_app.get_suc;
                    DS_temp = B_Common.GetList("select * from Qskyd_mainrecord", "ddbh='" + M_Qttyd_mainrecord.ddbh + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        s = common_file.common_app.get_failure;
                        for (int i_temp_0 = 0; i_temp_0 < DS_temp.Tables[0].Rows.Count; i_temp_0++)
                        {
                            s = Qyddj_add_edit_delete_new.delete_sz_xgft(DS_temp.Tables[0].Rows[i_temp_0]["id"].ToString(), czzt, czbz, qxyy, jzbh, czy, czsj, xxzs);
                        }

                    }
                    if (s == common_file.common_app.get_suc)
                    {
                        s = common_file.common_app.get_failure;
                        //清除入住记录
                        int strid = int.Parse(id);
                        //common_file.common_Qskyd_mainrecord.PlInter(int.Parse(id), "删除");
                        B_Qttyd_mainrecord_new.Pladd(strid, czbz, qxyy, czy, czsj, czzt, jzbh);//删除前批量添加到备份表里
                        if (B_Qttyd_mainrecord.Delete(strid) == true)
                        {
                            //s = common_file.common_app.get_suc;
                        }

                    }
                }
                if (i_temp == 9)
                {
                    //s = common_file.common_app.get_suc;
                }
            }


            s = common_file.common_app.get_suc;
            return s;
        }








        /// <summary>
        /// 处理团体排房
        /// </summary>
        /// <param name="tt_id">团体房间类别表的ID</param>
        /// <param name="fjrb"></param>
        /// <param name="fjjg"></param>
        /// <param name="shqh"></param>
        /// <param name="yh"></param>
        /// <param name="yhbl"></param>
        /// <param name="bz"></param>
        /// <returns></returns>
        public string tt_pf(string tt_id, string lsbh, string fjrb, string fjbh, string fjjg, string shqh, string yh, string bz, string czy, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            string lsbh_new = "";
            string krxm_temp = "";
            int id_temp = 0;
            DateTime czsj = DateTime.Now;
            Hotel_app.Model.Qskyd_fjrb M_Qskyd_fjrb;
            Hotel_app.BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            Hotel_app.Model.Qttyd_mainrecord M_Qttyd_mainrecord;
            Hotel_app.BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
            Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Qskyd_fjrb_add_edit_delete();

            //获取公共信息
            M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("lsbh='" + lsbh + "'")[0];
            //生成新的临时编号

            if (M_Qttyd_mainrecord.yddj == common_file.common_yddj.yddj_dj)
            {
                lsbh_new = common_file.common_ddbh.ddbh("skdj", "skdjdate", "skdjcounter", 6);
            }
            else
                if (M_Qttyd_mainrecord.yddj == common_file.common_yddj.yddj_yd)
                {
                    lsbh_new = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                }
            //生成客人的临时姓名(团体名称+房间编号)
            krxm_temp = M_Qttyd_mainrecord.krxm + fjbh;

            s = common_file_server.Common_pl_Qskyd_mainRecord_add.TT_plAdd(lsbh, lsbh_new, krxm_temp, czy, czsj.ToString(), xxzs);//根据lsbh读起主单信息，添加一条有房号的记录。
            //增加配置费用
            Q_ff_xyxf Q_ff_xyxf_new = new Q_ff_xyxf();
            Q_ff_xyxf_new.Qyddj_otherfee_add(M_Qttyd_mainrecord.yydh, M_Qttyd_mainrecord.qymc, M_Qttyd_mainrecord.lsbh, "", M_Qttyd_mainrecord.sktt, "", czy);




            if (s == common_file.common_app.get_suc)//增加成功
            {
                s = common_file.common_app.get_failure;
                #region 修改成员主单的房间类别表的信息
                M_Qskyd_fjrb = B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh_new + "'")[0];
                id_temp = M_Qskyd_fjrb.id;
                M_Qskyd_fjrb.fjbh = fjbh;
                M_Qskyd_fjrb.fjrb = fjrb;
                M_Qskyd_fjrb.shqh = shqh;
                M_Qskyd_fjrb.fjjg = decimal.Parse(fjjg);
                M_Qskyd_fjrb.yh = yh;
                M_Qskyd_fjrb.yhbl = Get_yhblByYh(yh);
                M_Qskyd_fjrb.bz = bz;
                M_Qskyd_fjrb.lzfs = 1;
                M_Qskyd_fjrb.id = id_temp;

                //新增的成员主单修改成功后,更新lzfs(这里调用Qskyd_fjrb_add_edit_delete这个类的方法，注意里面有修改房态的部分)
                //if (B_Qskyd_fjrb.Update(M_Qskyd_fjrb))
                if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id_temp.ToString(), M_Qskyd_fjrb.yydh, M_Qskyd_fjrb.qymc, lsbh_new, GetStringValue(M_Qskyd_fjrb.krxm), common_file.common_sktt.sktt_tt, GetStringValue(M_Qskyd_fjrb.yddj), fjrb, fjbh, M_Qskyd_fjrb.ddsj, M_Qskyd_fjrb.lksj, decimal.Parse("1"), shqh, decimal.Parse(fjjg), decimal.Parse(fjjg), yh, Get_yhblByYh(yh), bz, czy, DateTime.Now, "新增", GetStringValue(M_Qskyd_fjrb.yddj), common_file.common_app.get_edit, common_file.common_app.xxzs, M_Qskyd_fjrb.fjbm, M_Qskyd_fjrb.jcje) == common_file.common_app.get_suc)
                {
                    M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(tt_id));
                    M_Qskyd_fjrb.lzfs -= 1;
                    M_Qskyd_fjrb.id = int.Parse(tt_id);
                    if (B_Qskyd_fjrb.Update(M_Qskyd_fjrb))
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
                #endregion
            }
            return s;
        }

        //通过yh获取yhbl
        public decimal Get_yhblByYh(string yh)
        {
            BLL.YHuser_yhbl B_YHuser_yhbl = new Hotel_app.BLL.YHuser_yhbl();
            if (yh != "" && yh != null)
            {
                return decimal.Parse(B_YHuser_yhbl.GetModelList("yh='" + yh + "'")[0].yhbl.ToString());
            }
            else
            {
                return decimal.Parse("1");
            }
        }

        //处理object类型ToString()的值
        public string GetStringValue(object obj)
        {
            if (obj == null)
                return "";
            else
            {
                return obj.ToString();
            }
        }

        //团体多间排房
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tt_id"></param>
        /// <param name="lsbh"></param>
        /// <param name="fjrb"></param>
        /// <param name="strs_fjbh">fjbh的列表</param>
        /// <param name="fjjg"></param>
        /// <param name="shqh"></param>
        /// <param name="yh"></param>
        /// <param name="bz"></param>
        /// <param name="czy"></param>
        /// <returns></returns>
        public string tt_pf_multi(string tt_id, string lsbh, string fjrb, string[] strs_fjbh, string fjjg, string shqh, string yh, string bz, string czy, string czsj, string cznr, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            string lsbh_new = "";
            string krxm_temp = "";
            int id_temp = 0;
            Hotel_app.Model.Qskyd_fjrb M_Qskyd_fjrb;
            Hotel_app.BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            Hotel_app.Model.Qttyd_mainrecord M_Qttyd_mainrecord;
            Hotel_app.BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
            Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Qskyd_fjrb_add_edit_delete();
            Ffjzt.Flfsz_add_edit Flfsz_add_edit_new = new Hotel_app.Server.Ffjzt.Flfsz_add_edit();
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id from Xqyxx", "id>=0");
            //获取公共信息
            M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("lsbh='" + lsbh + "'")[0];
            string lfbh_news = ""; int judge_get_lfbh = 2;
            foreach (string fjbh in strs_fjbh)
            {
                if (fjbh != null&&fjbh.Trim()!="")
                {
                    //生成新的临时编号
                    if (M_Qttyd_mainrecord.yddj == common_file.common_yddj.yddj_dj)
                    {
                        lsbh_new = common_file.common_ddbh.ddbh("skdj", "skdjdate", "skdjcounter", 6);
                    }
                    else
                        if (M_Qttyd_mainrecord.yddj == common_file.common_yddj.yddj_yd)
                        {
                            lsbh_new = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                        }

                    //生成客人的临时姓名(团体名称+房间编号)
                    krxm_temp = M_Qttyd_mainrecord.krxm + "_" + fjbh;

                    s = common_file_server.Common_pl_Qskyd_mainRecord_add.TT_plAdd(lsbh, lsbh_new, krxm_temp, czy, czsj.ToString(), xxzs);//根据lsbh读起主单信息，添加一条有房号的记录。

                    //增加配置费用
                    Q_ff_xyxf Q_ff_xyxf_new = new Q_ff_xyxf();
                    //Q_ff_xyxf_new.Qyddj_otherfee_add(M_Qttyd_mainrecord.yydh, M_Qttyd_mainrecord.qymc, lsbh_new, "", M_Qttyd_mainrecord.sktt, "", czy);
                    Q_ff_xyxf_new.Qyddj_otherfee_add(M_Qttyd_mainrecord.yydh, M_Qttyd_mainrecord.qymc, lsbh_new, krxm_temp, M_Qttyd_mainrecord.sktt, "", czy);//把名称加进去
                    if (s == common_file.common_app.get_suc)//增加成功
                    {
                        s = common_file.common_app.get_failure;
                        #region 修改成员主单的房间类别表的信息
                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh_new + "'")[0];
                        id_temp = M_Qskyd_fjrb.id;
                        M_Qskyd_fjrb.fjbh = fjbh;
                        M_Qskyd_fjrb.fjrb = fjrb;
                        M_Qskyd_fjrb.shqh = shqh;
                        M_Qskyd_fjrb.fjjg = decimal.Parse(fjjg);
                        M_Qskyd_fjrb.yh = yh;
                        M_Qskyd_fjrb.yhbl = Get_yhblByYh(yh);
                        M_Qskyd_fjrb.bz = bz;
                        M_Qskyd_fjrb.lzfs = 1;
                        M_Qskyd_fjrb.id = id_temp;

                        DS_temp = B_Common.GetList("select * from Qskyd_fjrb", "id='" + tt_id + "'");
                        if(DS_temp!=null && DS_temp.Tables[0].Rows.Count>0)
                        {
                            M_Qskyd_fjrb.fjbm = DS_temp.Tables[0].Rows[0]["fjbm"].ToString();
                        }


                        //新增的成员主单修改成功后,更新lzfs(这里调用Qskyd_fjrb_add_edit_delete这个类的方法，注意里面有修改房态的部分)
                        //if (B_Qskyd_fjrb.Update(M_Qskyd_fjrb))
                        if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id_temp.ToString(), M_Qskyd_fjrb.yydh, M_Qskyd_fjrb.qymc, lsbh_new, GetStringValue(M_Qskyd_fjrb.krxm), common_file.common_sktt.sktt_tt, GetStringValue(M_Qskyd_fjrb.yddj), fjrb, fjbh, M_Qskyd_fjrb.ddsj, M_Qskyd_fjrb.lksj, decimal.Parse("1"), shqh, decimal.Parse(fjjg), decimal.Parse(fjjg), yh, Get_yhblByYh(yh), bz, czy, DateTime.Now, "新增", GetStringValue(M_Qskyd_fjrb.yddj), common_file.common_app.get_edit, common_file.common_app.xxzs, M_Qskyd_fjrb.fjbm, M_Qskyd_fjrb.jcje) == common_file.common_app.get_suc)
                        {
                            M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(tt_id));
                            M_Qskyd_fjrb.lzfs -= 1;
                            M_Qskyd_fjrb.id = int.Parse(tt_id);
                            if (B_Qskyd_fjrb.Update(M_Qskyd_fjrb))
                            {

                                //if (judge_get_lfbh != 3)
                                //{
                                //    DS_temp = B_Common.GetList("select lfbh from Flfsz", "lsbh in(select lsbh from Qskyd_mainrecord where ddbh='" + M_Qttyd_mainrecord.ddbh + "')");
                                //    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                                //    {
                                //        lfbh_news = DS_temp.Tables[0].Rows[0]["lfbh"].ToString();
                                //        judge_get_lfbh = 3;
                                //    }
                                //    else
                                //    {
                                //        lfbh_news = common_file.common_ddbh.ddbh("lf", "lfdate", "lfcounter", 6);
                                //        judge_get_lfbh = 3;
                                //    }
                                //}



                                //s = Flfsz_add_edit_new.Flfsz_add_edit_delete("", M_Qskyd_fjrb.yydh, M_Qskyd_fjrb.qymc, lfbh_news, lsbh_new, fjbh, M_Qskyd_fjrb.krxm, M_Qskyd_fjrb.sktt, M_Qskyd_fjrb.yddj, czy, czsj.ToString(), false, common_file.common_app.get_add, xxzs);

                                s = common_file.common_app.get_suc;

                            }
                        }
                        #endregion
                    }
                }
            }
            DS_temp.Dispose();
            return s;
        }

    }

}
