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
    public class Qydcx
    {


        /// <summary>
        /// //散客预订撤销
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="lsbh"></param>
        /// <param name="input_cznr"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string skyd_cx(string yydh, string qymc, string lsbh, string input_cznr, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string insert_s = "";
            string delete_s = "";
            string cznr_0 = "撤销预订";
            string czzy_0 = "";
            string czbz_0 = "";
            DataSet DS_temp = B_Common.GetList("select * from Qskyd_mainrecord_temp", " lsbh='" + lsbh + "' and cznr='" + input_cznr + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                czzy_0 = DS_temp.Tables[0].Rows[0]["krxm"].ToString() + "/" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString();
                czbz_0 = DS_temp.Tables[0].Rows[0]["ddsj"].ToString() + "/" + DS_temp.Tables[0].Rows[0]["lksj"].ToString();
            }
            insert_s = "insert into Qskyd_mainrecord (yydh,qymc,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz)";
            insert_s = insert_s + " select yydh,qymc,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + cznr_0 + "',shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz from Qskyd_mainrecord_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Qskyd_mainrecord_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(delete_s);


            //提前还原的目的,才不会丢掉联账的图标.
            insert_s = "insert into Flfsz (yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,czy,cznr,czsj,is_top,is_select)";
            insert_s = insert_s + " select yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,'" + czy + "','" + cznr_0 + "','" + czsj + "',is_top,is_select from Flfsz_temp";
            insert_s = insert_s + " where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Flfsz_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(delete_s);




            DS_temp = B_Common.GetList("select * from Qskyd_fjrb_temp", " lsbh='" + lsbh + "' and cznr='" + input_cznr + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                Qskyd_fjrb_add_edd_delete_1 Qskyd_fjrb_add_edd_delete_1_new = new Qskyd_fjrb_add_edd_delete_1();
                int i = 1;
                for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {

                    if (i == 2)
                    {
                        Qskyd_fjrb_add_edd_delete_1_new.Qskyd_fjrb_add_edit_delete_app_1("", yydh, qymc, lsbh, DS_temp.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp.Tables[0].Rows[j_0]["sktt"].ToString(), DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["lksj"].ToString()), Decimal.Parse(DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString()), DS_temp.Tables[0].Rows[j_0]["shqh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["fjjg"].ToString()), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["sjfjjg"].ToString()), DS_temp.Tables[0].Rows[j_0]["yh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["yhbl"].ToString()), DS_temp.Tables[0].Rows[j_0]["bz"].ToString(), czy, czsj, cznr_0, DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), common_file.common_app.get_add, xxzs, DS_temp.Tables[0].Rows[j_0]["fjbm"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["jcje"].ToString()));
                    }
                    else
                        if (i == 1)
                        {
                            DataSet DS_temp_0 = B_Common.GetList("select * from Qskyd_fjrb", " lsbh='" + lsbh + "'");
                            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                            {
                                Qskyd_fjrb_add_edd_delete_1_new.Qskyd_fjrb_add_edit_delete_app_1(DS_temp_0.Tables[0].Rows[0]["id"].ToString(), yydh, qymc, lsbh, DS_temp.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp.Tables[0].Rows[j_0]["sktt"].ToString(), DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["lksj"].ToString()), Decimal.Parse(DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString()), DS_temp.Tables[0].Rows[j_0]["shqh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["fjjg"].ToString()), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["sjfjjg"].ToString()), DS_temp.Tables[0].Rows[j_0]["yh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["yhbl"].ToString()), DS_temp.Tables[0].Rows[j_0]["bz"].ToString(), czy, czsj, cznr_0, DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), common_file.common_app.get_edit, xxzs, DS_temp.Tables[0].Rows[j_0]["fjbm"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["jcje"].ToString()));
                                i = 2;
                            }
                            else
                            {
                                i = 2;
                            }
                            DS_temp_0.Dispose();
                        }
                }
            }

            delete_s = "delete  from Qskyd_fjrb_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(delete_s);

            DS_temp = B_Common.GetList("select * from Szwzd_temp", " lsbh='" + lsbh + "' and cznr='" + input_cznr + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                B_Common.ExecuteSql("update Szwzd set fkje='" + DS_temp.Tables[0].Rows[0]["fkje"].ToString() + "',xfje='" + DS_temp.Tables[0].Rows[0]["xfje"].ToString() + "' where lsbh='" + lsbh + "'");
            }
            else
            {
                insert_s = "insert into Szwzd (yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select)";
                insert_s = insert_s + "select yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select from Szwzd_temp ";
                insert_s = insert_s + "where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
                B_Common.ExecuteSql(insert_s);
            }
            DS_temp.Clear();
            DS_temp.Dispose();
            delete_s = "delete  from Szwzd_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(delete_s);




            insert_s = "insert into Qyddj_otherfee (yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,czy,cznr,czsj,sdcz,is_top,is_select,mxbh)";
            insert_s = insert_s + "  select yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,'" + czy + "','" + cznr_0 + "','" + czsj + "',sdcz,is_top,is_select,mxbh from Qyddj_otherfee_temp";
            insert_s = insert_s + "  where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Qyddj_otherfee_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(delete_s);
            common_file.common_czjl.add_czjl(yydh, qymc, czy, cznr_0, czzy_0, czbz_0, czsj);
            s = common_file.common_app.get_suc;
            return s;
        }


        /// <summary>
        /// //团体预订撤销
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="lsbh"></param>
        /// <param name="input_cznr"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string ttyd_cx(string yydh, string qymc, string lsbh, string input_cznr, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string insert_s = "";
            string delete_s = "";
            string czzy_0 = "";
            string czbz_0 = "";
            string cznr_0 = "撤销预订";

            DataSet DS_temp = B_Common.GetList("select * from Qttyd_mainrecord_temp", " lsbh='" + lsbh + "' and cznr='" + input_cznr + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                czzy_0 = DS_temp.Tables[0].Rows[0]["krxm"].ToString() + "/" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString();
                czbz_0 = DS_temp.Tables[0].Rows[0]["ddsj"].ToString() + "/" + DS_temp.Tables[0].Rows[0]["lksj"].ToString();
                string sel_0 = " cznr='" + input_cznr + "' and ddbh='" + DS_temp.Tables[0].Rows[0]["ddbh"].ToString() + "'";
                DataSet DS_temp_0 = B_Common.GetList("select * from Qskyd_mainrecord_temp", sel_0);
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    for (int j_0 = 0; j_0 < DS_temp_0.Tables[0].Rows.Count; j_0++)
                    {
                        skyd_cx(yydh, qymc, DS_temp_0.Tables[0].Rows[j_0]["lsbh"].ToString(), input_cznr, czy, czsj, xxzs);
                    }
                }
                DS_temp_0.Dispose();

            }

            insert_s = "insert into Qttyd_mainrecord (yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,sdcz,syzd,tsyq,ddly)";
            insert_s = insert_s + " select yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + cznr_0 + "',shsc,sktt,yddj,ffshys,sdcz,syzd,tsyq,ddly from Qttyd_mainrecord_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Qttyd_mainrecord_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(delete_s);






            DS_temp = B_Common.GetList("select * from Qskyd_fjrb_temp", " lsbh='" + lsbh + "' and cznr='" + input_cznr + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                Qskyd_fjrb_add_edd_delete_1 Qskyd_fjrb_add_edd_delete_1_new = new Qskyd_fjrb_add_edd_delete_1();
                int i = 1;
                for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {

                    if (i == 2)
                    {
                        Qskyd_fjrb_add_edd_delete_1_new.Qskyd_fjrb_add_edit_delete_app_1("", yydh, qymc, lsbh, DS_temp.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp.Tables[0].Rows[j_0]["sktt"].ToString(), DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["lksj"].ToString()), Decimal.Parse(DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString()), DS_temp.Tables[0].Rows[j_0]["shqh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["fjjg"].ToString()), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["sjfjjg"].ToString()), DS_temp.Tables[0].Rows[j_0]["yh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["yhbl"].ToString()), DS_temp.Tables[0].Rows[j_0]["bz"].ToString(), czy, czsj, cznr_0, DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), common_file.common_app.get_add, xxzs, DS_temp.Tables[0].Rows[j_0]["fjbm"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["jcje"].ToString()));
                    }
                    else
                        if (i == 1)
                        {
                            DataSet DS_temp_0 = B_Common.GetList("select * from Qskyd_fjrb", " lsbh='" + lsbh + "'");
                            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                            {
                                Qskyd_fjrb_add_edd_delete_1_new.Qskyd_fjrb_add_edit_delete_app_1(DS_temp_0.Tables[0].Rows[0]["id"].ToString(), yydh, qymc, lsbh, DS_temp.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp.Tables[0].Rows[j_0]["sktt"].ToString(), DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["lksj"].ToString()), Decimal.Parse(DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString()), DS_temp.Tables[0].Rows[j_0]["shqh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["fjjg"].ToString()), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["sjfjjg"].ToString()), DS_temp.Tables[0].Rows[j_0]["yh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["yhbl"].ToString()), DS_temp.Tables[0].Rows[j_0]["bz"].ToString(), czy, czsj, cznr_0, DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), common_file.common_app.get_edit, xxzs, DS_temp.Tables[0].Rows[j_0]["fjbm"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["jcje"].ToString()));
                                i = 2;
                            }
                            else
                            {
                                i = 2;
                            }
                            DS_temp_0.Clear();
                            DS_temp_0.Dispose();
                        }
                }
            }

            delete_s = "delete  from Qskyd_fjrb_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(delete_s);

            DS_temp = B_Common.GetList("select * from Szwzd_temp", " lsbh='" + lsbh + "' and cznr='" + input_cznr + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                B_Common.ExecuteSql("update Szwzd set fkje='" + DS_temp.Tables[0].Rows[0]["fkje"].ToString() + "',xfje='" + DS_temp.Tables[0].Rows[0]["xfje"].ToString() + "' where lsbh='" + lsbh + "'");
            }
            else
            {
                insert_s = "insert into Szwzd (yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select)";
                insert_s = insert_s + "select yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select from Szwzd_temp ";
                insert_s = insert_s + "where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
                B_Common.ExecuteSql(insert_s);
            }
            DS_temp.Clear();
            DS_temp.Dispose();
            delete_s = "delete  from Szwzd_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(delete_s);

            insert_s = "insert into Qyddj_otherfee (yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,czy,cznr,czsj,sdcz,is_top,is_select,mxbh)";
            insert_s = insert_s + "  select yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,'" + czy + "','" + cznr_0 + "','" + czsj + "',sdcz,is_top,is_select,mxbh from Qyddj_otherfee_temp";
            insert_s = insert_s + "  where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Qyddj_otherfee_temp where lsbh='" + lsbh + "' and cznr='" + input_cznr + "'";
            B_Common.ExecuteSql(delete_s);
            common_file.common_czjl.add_czjl(yydh, qymc, czy, cznr_0, czzy_0, czbz_0, czsj);
            s = common_file.common_app.get_suc;
            return s;
        }











        ////撤销账务备份还原

        public string yd_bak_cx(string yydh, string qymc, string jzbh, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_tem = B_Common.GetList("select jzbh from Qttyd_mainrecord_bak","jzbh='"+jzbh+"'");
            if (DS_tem != null && DS_tem.Tables[0].Rows.Count > 0)
            {
                ttbak_cx(yydh, qymc, jzbh, czy, czsj, xxzs);
            }
            DS_tem = B_Common.GetList("select jzbh from Qskyd_mainrecord_bak", "jzbh='" + jzbh + "'");
            if (DS_tem != null && DS_tem.Tables[0].Rows.Count > 0)
            {
                skbak_cx(yydh, qymc, jzbh,"", czy, czsj, xxzs);
            }
            DS_tem.Clear();
            DS_tem.Dispose();
            s = common_file.common_app.get_suc;
            return s;
        }


        /// <summary>
        /// //散客备份还原
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="lsbh"></param>
        /// <param name="input_cznr"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string skbak_cx(string yydh, string qymc, string jzbh, string ttlsbh, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string insert_s = "";
            string delete_s = "";
            string cznr_0 = "账务撤销";
            string czzy_0 = "";
            string czbz_0 = "";
            insert_s = "insert into Qskyd_mainrecord (yydh,qymc,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz)";
            insert_s = insert_s + " select yydh,qymc,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + cznr_0 + "',shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz from Qskyd_mainrecord_bak where  jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Qskyd_mainrecord_bak where  jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(delete_s);
            string sel_cond = "";
            if (ttlsbh == "")
            {
                sel_cond = "  jzbh='" + jzbh + "'";
            }
            else
            {
                sel_cond = "  jzbh='" + jzbh + "' and lsbh<>'" + ttlsbh + "'";
            }

            //提前还原的目的,才不会丢掉联账的图标.
            insert_s = "insert into Flfsz (yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,czy,cznr,czsj,is_top,is_select)";
            insert_s = insert_s + " select yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,'" + czy + "','" + cznr_0 + "','" + czsj + "',is_top,is_select from Flfsz_bak";
            insert_s = insert_s + " where jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Flfsz_bak where jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(delete_s);



            DataSet DS_temp = B_Common.GetList("select * from Qskyd_fjrb_bak", sel_cond + "  order by lsbh");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                Qyddj.Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edd_delete_new = new Qyddj.Qskyd_fjrb_add_edit_delete();
                
                for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {
                    string lsbh_0 = DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString();
                    DataSet DS_temp_0 = B_Common.GetList("select * from Qskyd_fjrb", " lsbh='" + lsbh_0 + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        Qskyd_fjrb_add_edd_delete_new.Qskyd_fjrb_add_edit_delete_app(DS_temp_0.Tables[0].Rows[0]["id"].ToString(), yydh, qymc, DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString(), DS_temp.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp.Tables[0].Rows[j_0]["sktt"].ToString(), DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["lksj"].ToString()), Decimal.Parse(DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString()), DS_temp.Tables[0].Rows[j_0]["shqh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["fjjg"].ToString()), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["sjfjjg"].ToString()), DS_temp.Tables[0].Rows[j_0]["yh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["yhbl"].ToString()), DS_temp.Tables[0].Rows[j_0]["bz"].ToString(), czy, czsj, cznr_0, DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), common_file.common_app.get_edit, xxzs, DS_temp.Tables[0].Rows[j_0]["fjbm"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["jcje"].ToString()));

                    }
                    else
                    {
                        Qskyd_fjrb_add_edd_delete_new.Qskyd_fjrb_add_edit_delete_app("", yydh, qymc, DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString(), DS_temp.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp.Tables[0].Rows[j_0]["sktt"].ToString(), DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["lksj"].ToString()), Decimal.Parse(DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString()), DS_temp.Tables[0].Rows[j_0]["shqh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["fjjg"].ToString()), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["sjfjjg"].ToString()), DS_temp.Tables[0].Rows[j_0]["yh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["yhbl"].ToString()), DS_temp.Tables[0].Rows[j_0]["bz"].ToString(), czy, czsj, cznr_0, DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), common_file.common_app.get_add, xxzs, DS_temp.Tables[0].Rows[j_0]["fjbm"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["jcje"].ToString()));

                    }
                    DS_temp_0.Dispose();

                }
            }

            delete_s = "delete  from Qskyd_fjrb_bak where " + sel_cond;
            B_Common.ExecuteSql(delete_s);

            DS_temp = B_Common.GetList("select * from Szwzd_bak", " jzbh='" + jzbh + "' and lsbh<>'" + ttlsbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {

                for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {
                    if (B_Common.ExecuteSql("update Szwzd set fkje='" + DS_temp.Tables[0].Rows[j_0]["fkje"].ToString() + "',xfje='" + DS_temp.Tables[0].Rows[j_0]["xfje"].ToString() + "' where lsbh='" + DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString() + "'") > 0)
                    { 

                    }
                    else
                    {
                        insert_s = "insert into Szwzd (yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select)";
                        insert_s = insert_s + " select yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select from Szwzd_bak";
                        insert_s = insert_s + " where jzbh='" + jzbh + "' and lsbh<>'" + ttlsbh + "' and lsbh='" + DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString() + "'";
                        B_Common.ExecuteSql(insert_s);
                    }
                
                }


                
            }

            DS_temp.Clear();
            DS_temp.Dispose();
            delete_s = "delete from Szwzd_bak where jzbh='" + jzbh + "' and lsbh<>'" + ttlsbh + "'";
            B_Common.ExecuteSql(delete_s);

            //insert_s = "insert into Flfsz (yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,czy,cznr,czsj,is_top,is_select)";
            //insert_s = insert_s + " select yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,'" + czy + "','" + cznr_0 + "','" + czsj + "',is_top,is_select from Flfsz_bak";
            //insert_s = insert_s + " where jzbh='" + jzbh + "'";
            //B_Common.ExecuteSql(insert_s);
            //delete_s = "delete  from Flfsz_bak where jzbh='" + jzbh + "'";
            //B_Common.ExecuteSql(delete_s);

            insert_s = "insert into Qyddj_otherfee (yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,czy,cznr,czsj,sdcz,is_top,is_select,mxbh)";
            insert_s = insert_s + "  select yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,'" + czy + "','" + cznr_0 + "','" + czsj + "',sdcz,is_top,is_select,mxbh from Qyddj_otherfee_bak";
            insert_s = insert_s + "  where jzbh='" + jzbh + "' and lsbh<>'" + ttlsbh + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Qyddj_otherfee_bak where jzbh='" + jzbh + "' and lsbh<>'" + ttlsbh + "'";
            B_Common.ExecuteSql(delete_s);
            
            s = common_file.common_app.get_suc;
            return s;
        }


        /// <summary>
        /// //团体备份还原
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="lsbh"></param>
        /// <param name="input_cznr"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string ttbak_cx(string yydh, string qymc, string jzbh, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string insert_s = "";
            string delete_s = "";
            //string czzy_0 = "";
            //string czbz_0 = "";
            string cznr_0 = "账务撤销";

            DataSet DS_temp = B_Common.GetList("select * from Qttyd_mainrecord_bak", " jzbh='" + jzbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                //czzy_0 = DS_temp.Tables[0].Rows[0]["krxm"].ToString() + "/" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString();
                //czbz_0 = DS_temp.Tables[0].Rows[0]["ddsj"].ToString() + "/" + DS_temp.Tables[0].Rows[0]["lksj"].ToString();
                DataSet DS_temp_0 = B_Common.GetList("select * from Qskyd_mainrecord_bak", " jzbh='" + jzbh + "' and ddbh='" + DS_temp.Tables[0].Rows[0]["ddbh"].ToString() + "'");
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    for (int j_0 = 0; j_0 < DS_temp_0.Tables[0].Rows.Count; j_0++)
                    {
                        skbak_cx(yydh, qymc, jzbh,DS_temp.Tables[0].Rows[0]["lsbh"].ToString(), czy, czsj, xxzs);
                    }
                }
                DS_temp_0.Dispose();

            }

            insert_s = "insert into Qttyd_mainrecord (yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,sdcz,syzd,tsyq,ddly)";
            insert_s = insert_s + " select yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + cznr_0 + "',shsc,sktt,yddj,ffshys,sdcz,syzd,tsyq,ddly from Qttyd_mainrecord_bak where jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Qttyd_mainrecord_bak where  jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(delete_s);

            DS_temp = B_Common.GetList("select * from Qskyd_fjrb_bak", " jzbh='" + jzbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edd_delete_new = new Qskyd_fjrb_add_edit_delete();
                int i = 1;
                for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {

                    if (i == 2)
                    {
                        Qskyd_fjrb_add_edd_delete_new.Qskyd_fjrb_add_edit_delete_app("", yydh, qymc, DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString(), DS_temp.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp.Tables[0].Rows[j_0]["sktt"].ToString(), DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["lksj"].ToString()), Decimal.Parse(DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString()), DS_temp.Tables[0].Rows[j_0]["shqh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["fjjg"].ToString()), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["sjfjjg"].ToString()), DS_temp.Tables[0].Rows[j_0]["yh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["yhbl"].ToString()), DS_temp.Tables[0].Rows[j_0]["bz"].ToString(), czy, czsj, cznr_0, DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), common_file.common_app.get_add, xxzs, DS_temp.Tables[0].Rows[j_0]["fjbm"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["jcje"].ToString()));
                    }
                    else
                        if (i == 1)
                        {
                            DataSet DS_temp_0 = B_Common.GetList("select * from Qskyd_fjrb", " lsbh='" + DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString() + "'");
                            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                            {
                                Qskyd_fjrb_add_edd_delete_new.Qskyd_fjrb_add_edit_delete_app(DS_temp_0.Tables[0].Rows[0]["id"].ToString(), yydh, qymc, DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString(), DS_temp.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp.Tables[0].Rows[j_0]["sktt"].ToString(), DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DS_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(DS_temp.Tables[0].Rows[j_0]["lksj"].ToString()), Decimal.Parse(DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString()), DS_temp.Tables[0].Rows[j_0]["shqh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["fjjg"].ToString()), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["sjfjjg"].ToString()), DS_temp.Tables[0].Rows[j_0]["yh"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["yhbl"].ToString()), DS_temp.Tables[0].Rows[j_0]["bz"].ToString(), czy, czsj, cznr_0, DS_temp.Tables[0].Rows[j_0]["yddj"].ToString(), common_file.common_app.get_edit, xxzs, DS_temp.Tables[0].Rows[j_0]["fjbm"].ToString(), decimal.Parse(DS_temp.Tables[0].Rows[j_0]["jcje"].ToString()));
                                i = 2;
                            }
                            else
                            {
                                i = 2;
                            }
                            DS_temp_0.Clear();
                            DS_temp_0.Dispose();
                        }
                }
            }

            delete_s = "delete  from Qskyd_fjrb_bak where jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(delete_s);

            DS_temp = B_Common.GetList("select * from Szwzd_bak", " jzbh='" + jzbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                B_Common.ExecuteSql("update Szwzd set fkje='" + DS_temp.Tables[0].Rows[0]["fkje"].ToString() + "',xfje='" + DS_temp.Tables[0].Rows[0]["xfje"].ToString() + "' where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
            }
            else
            {
                insert_s = "insert into Szwzd (yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select)";
                insert_s = insert_s + " select yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select from Szwzd_bak ";
                insert_s = insert_s + " where jzbh='" + jzbh + "'";
                B_Common.ExecuteSql(insert_s);
            }
            DS_temp.Clear();
            DS_temp.Dispose();
            delete_s = "delete  from Szwzd_bak where jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(delete_s);

            insert_s = "insert into Qyddj_otherfee (yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,czy,cznr,czsj,sdcz,is_top,is_select,mxbh)";
            insert_s = insert_s + "  select yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,'" + czy + "','" + cznr_0 + "','" + czsj + "',sdcz,is_top,is_select,mxbh from Qyddj_otherfee_bak";
            insert_s = insert_s + "  where jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(insert_s);
            delete_s = "delete  from Qyddj_otherfee_bak where jzbh='" + jzbh + "'";
            B_Common.ExecuteSql(delete_s);
            //common_file.common_czjl.add_czjl(yydh, qymc, czy, cznr_0, czzy_0, czbz_0, czsj);
            s = common_file.common_app.get_suc;
            return s;
        }




    }
}
