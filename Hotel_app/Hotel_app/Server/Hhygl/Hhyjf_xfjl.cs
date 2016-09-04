using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Hhygl
{
    public class Hhyjf_xfjl
    {

        public void Hhyjf_gc_app(string krly, string hykh, string yydh, string qymc, string krxm, string id_app, string lsbh, string fjrb, string fjbh, string xfdr, string xfrb, string xfxm, string sjxfje, string czy, DateTime czsj, string xxzs)
        {
            if (hykh != null && hykh != "")
            {
                if (xfdr == Szwgl.common_zw.dr_ff)
                {
                    string hyjf = "0";
                    string hyrx = "";
                    string hykh_bz = "";
                    string parent_hykh = "";
                    BLL.Common B_Common = new Hotel_app.BLL.Common();
                    DataSet DS_temp = B_Common.GetList("select * from Hhygl", "hykh='" + hykh + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        hyrx = DS_temp.Tables[0].Rows[0]["hyrx"].ToString();
                        hykh_bz = DS_temp.Tables[0].Rows[0]["hykh_bz"].ToString();
                        parent_hykh = DS_temp.Tables[0].Rows[0]["parent_hykh"].ToString();
                    }
                    int judeg_zc = 1;
                    float jfbl = 0;
                    if (krly == common_file.common_app.krly_hy)
                    {
                        judeg_zc = 2;
                    }
                    if (judeg_zc != 2)
                    {
                        if (krly != "")
                        {
                            if (hyrx != "")
                            {
                                DS_temp = B_Common.GetList("select * from Hhyjf_bl", "krly='" + krly + "' and hyrx='" + hyrx + "'");
                                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                                {
                                    jfbl = float.Parse(DS_temp.Tables[0].Rows[0]["jfbl"].ToString());
                                }
                                else
                                { judeg_zc = 2; }

                            }

                        }
                        else
                        {
                            if (hyrx != "")
                            {
                                judeg_zc = 2;
                            }
                        }
                    }
                    if (judeg_zc == 2)
                    {
                        DS_temp = B_Common.GetList("select * from Hhyjf_bl", "krly='" + common_file.common_hy.hyrx_krly + "' and hyrx='" + hyrx + "'");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            jfbl = float.Parse(DS_temp.Tables[0].Rows[0]["jfbl"].ToString());
                        }

                    }
                    if (jfbl > 0)
                    {
                        hyjf = Convert.ToString(common_file.common_sswl.Round_sswl(double.Parse(Convert.ToString(jfbl * (float.Parse(sjxfje)))), 0, common_file.common_sswl.selectMode_sel));

                        Hhyjfxfjl_add_edit("", yydh, qymc, hykh, hykh_bz, krxm, id_app, lsbh, fjrb, fjbh, hyjf, "", xfdr, xfrb, xfxm, sjxfje, common_file.common_app.get_add, czy, czsj, parent_hykh, xxzs);
                    }
                    DS_temp.Clear();
                    DS_temp.Dispose();
                }
            }
        }
        //id,qymc,yydh,hykh,hykh_bz,krxm,id_app,lsbh,fjrb,fjbh,xfsj,hyjf,bz,xfxm,sjxmje,shsc,scsj,is_top,is_select
        public string Hhyjfxfjl_add_edit(string id, string yydh, string qymc, string hykh, string hykh_bz, string krxm, string id_app, string lsbh, string fjrb, string fjbh, string hyjf, string bz, string xfdr, string xfrb, string xfxm, string sjxmje, string add_edit_delete, string czy, DateTime czsj, string parent_hykh, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Hhyjf_xfjl B_Hhyjf_xfjl = new Hotel_app.BLL.Hhyjf_xfjl();
            Model.Hhyjf_xfjl M_Hhyjf_xfjl = new Hotel_app.Model.Hhyjf_xfjl();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                //  判断是否有被验证



                M_Hhyjf_xfjl.yydh = yydh;
                M_Hhyjf_xfjl.qymc = qymc;
                M_Hhyjf_xfjl.lsbh_df = common_file.common_ddbh.ddbh("hyjf", "lsbhdate", "lsbhcounter", 6); ;
                M_Hhyjf_xfjl.hykh = hykh;
                M_Hhyjf_xfjl.hykh_bz = hykh_bz;
                M_Hhyjf_xfjl.krxm = krxm;
                M_Hhyjf_xfjl.id_app = id_app;

                M_Hhyjf_xfjl.lsbh = lsbh;
                M_Hhyjf_xfjl.fjrb = fjrb;
                M_Hhyjf_xfjl.fjbh = fjbh;
                M_Hhyjf_xfjl.xfrq = DateTime.Parse(czsj.ToShortDateString());
                M_Hhyjf_xfjl.xfsj = czsj;
                M_Hhyjf_xfjl.hyjf = Convert.ToDecimal(hyjf);
                M_Hhyjf_xfjl.bz = bz;
                M_Hhyjf_xfjl.xfdr = xfdr;
                M_Hhyjf_xfjl.xfrb = xfrb;
                M_Hhyjf_xfjl.xfxm = xfxm;
                M_Hhyjf_xfjl.sjxfje = Convert.ToDecimal(sjxmje);
                M_Hhyjf_xfjl.parent_hykh = parent_hykh;
                M_Hhyjf_xfjl.scsj = common_file.common_app.czsj;


                M_Hhyjf_xfjl.czy = czy;
                if (B_Hhyjf_xfjl.Add(M_Hhyjf_xfjl) > 0)
                {
                    s = common_file.common_app.get_suc;


                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    //M_Hhyjf_xfjl = B_Hhyjf_xfjl.GetModel(Convert.ToInt32(id));

                    //M_Hhyjf_xfjl.hykh = hykh;
                    //M_Hhyjf_xfjl.hykh_bz = hykh_bz;
                    //M_Hhyjf_xfjl.id_app = id_app;
                    //M_Hhyjf_xfjl.krxm = krxm;
                    //M_Hhyjf_xfjl.lsbh = lsbh;
                    //M_Hhyjf_xfjl.sjxfje = Convert.ToDecimal(sjxmje);
                    //M_Hhyjf_xfjl.xfxm = xfxm;
                    //M_Hhyjf_xfjl.hyjf = Convert.ToDecimal(hyjf);
                    //M_Hhyjf_xfjl.fjrb = fjrb;
                    //M_Hhyjf_xfjl.fjbh = fjbh;
                    //M_Hhyjf_xfjl.bz = bz;
                    //M_Hhyjf_xfjl.lsbh_df = lsbh_df;

                    //M_Hhyjf_xfjl.id = Convert.ToInt32(id);
                    //B_Hhyjf_xfjl.Update(M_Hhyjf_xfjl);
                    //s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        //if (id != "")
                        //{
                        //    B_Hhyjf_xfjl.Delete(Convert.ToInt32(id));
                        //    s = common_file.common_app.get_suc;

                        //}
                    }
            return s;
        }


        public string Hhyjf_gc_app_news(string hykh, string yydh, string qymc,string lsbh,string sjxfje, string czy)
        {
            string s = common_file.common_app.get_failure;
            if (hykh != null && hykh != "")
            {
                    DateTime czsj = DateTime.Now;
                    string hyjf = "0";
                    string hyrx = "";
                    string hykh_bz = "";
                    string parent_hykh = "";
                    string krxm = "";
                    BLL.Common B_Common = new Hotel_app.BLL.Common();
                    DataSet DS_temp = B_Common.GetList("select * from Hhygl", "hykh='" + hykh + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        hyrx = DS_temp.Tables[0].Rows[0]["hyrx"].ToString();
                        hykh_bz = DS_temp.Tables[0].Rows[0]["hykh_bz"].ToString();
                        parent_hykh = DS_temp.Tables[0].Rows[0]["parent_hykh"].ToString();
                        krxm = DS_temp.Tables[0].Rows[0]["krxm"].ToString();
                    }
                    int judeg_zc = 2;
                    float jfbl = 0;
                    
                        DS_temp = B_Common.GetList("select * from Hhyjf_bl", "krly='" + common_file.common_hy.hyrx_krly + "' and hyrx='" + hyrx + "'");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            jfbl = float.Parse(DS_temp.Tables[0].Rows[0]["jfbl"].ToString());
                        }

                
                    if (jfbl > 0)
                    {
                        hyjf = Convert.ToString(common_file.common_sswl.Round_sswl(double.Parse(Convert.ToString(jfbl * (float.Parse(sjxfje)))), 0, common_file.common_sswl.selectMode_sel));
                        string id_app_a = common_file.common_ddbh.ddbh("xfmx", "lsbhdate", "lsbhcounter", 6);
                        Hhyjfxfjl_add_edit("", yydh, qymc, hykh, hykh_bz, krxm, id_app_a, lsbh, "增补", "增补", hyjf, "", "", "", "审核累加房费", sjxfje, common_file.common_app.get_add, czy, czsj, parent_hykh,common_file.common_app.xxzs_zsvalue);
                    }
                    s = common_file.common_app.get_suc;
                    DS_temp.Clear();
                    DS_temp.Dispose();
            
            }
            return s;
        }
    }
}
