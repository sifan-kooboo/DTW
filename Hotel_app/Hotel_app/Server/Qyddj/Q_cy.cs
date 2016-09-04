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
    public class Q_cy
    {

        public void insert_cy(BLL.Common B_Common, string yydh, string qymc, string czy, string krxm, string lsbh, string fjbh, string sjfjjg, string shqh, string xydw, string krly, string sktt, string shtt, string ddsj, string lksj, string lz, string lzbh, string fjdh, string dhfj, string fkje, string xfje, string yj_xfje, string ye)
        {

            string insert_s = "insert into BB_ysk_cy (yydh, qymc,czy, krxm, lsbh, fjbh, sjfjjg, shqh, xydw, krly, sktt, shtt, ddsj, lksj, lz, lzbh, fjdh, dhfj, fkje, xfje, yj_xfje,ye)";
            insert_s = insert_s + " values ('" + yydh + "', '" + qymc + "','" + czy + "', '" + krxm + "', '" + lsbh + "', '" + fjbh + "', '" + sjfjjg + "', '" + shqh + "', '" + xydw + "', '" + krly + "', '" + sktt + "', '" + shtt + "', '" + ddsj + "', '" + lksj + "', '" + lz + "', '" + lzbh + "', '" + fjdh + "', '" + dhfj + "', '" + fkje + "', '" + xfje + "', '" + yj_xfje + "', '" + ye + "')";
            B_Common.ExecuteSql(insert_s);
        }


        public void tt_cy(string yydh, string qymc, DateTime czrq, string cybl, string czy, BLL.Common B_Common)
        {
            DataSet DS_temp = B_Common.GetList("select * from Qttyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "' order by ddsj");
            DataSet DS_temp_0 = B_Common.GetList("select * from Qttyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "'");
            decimal yj_xfje = 0; decimal cybl_0 = decimal.Parse(cybl);
            decimal fkje = 0; decimal xfje = 0;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    fkje = 0; xfje = 0;
                    DS_temp_0 = B_Common.GetList("select sum(sjxfje) as xfje from Szwmx ", "  lsbh='" + DS_temp.Tables[0].Rows[i_0]["lsbh"].ToString() + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        if (DS_temp_0.Tables[0].Rows[0]["xfje"].ToString() != "")
                        {
                            xfje = decimal.Parse(DS_temp_0.Tables[0].Rows[0]["xfje"].ToString());
                        }

                    DS_temp_0 = B_Common.GetList("select sum(sjxfje) as xfje from Syjcz ", "  lsbh='" + DS_temp.Tables[0].Rows[i_0]["lsbh"].ToString() + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        if (DS_temp_0.Tables[0].Rows[0]["xfje"].ToString() != "")
                        {
                            fkje = decimal.Parse(DS_temp_0.Tables[0].Rows[0]["xfje"].ToString());
                        }

                    yj_xfje = 0;
                    if (DateTime.Parse(DS_temp.Tables[0].Rows[i_0]["lksj"].ToString()) >= czrq.AddDays(1))
                    {
                        DS_temp_0 = B_Common.GetList("select sum(sjfjjg) as fjjg from Qskyd_fjrb ", " lsbh in (select lsbh from Qskyd_mainrecord where ddbh='" + DS_temp.Tables[0].Rows[i_0]["ddbh"].ToString() + "')");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                            if (DS_temp_0.Tables[0].Rows[0]["fjjg"].ToString() != "")
                            {
                                yj_xfje = decimal.Parse(DS_temp_0.Tables[0].Rows[0]["fjjg"].ToString()) * cybl_0;
                            }
                    }
                    yj_xfje = yj_xfje + xfje;
                    if (yj_xfje > fkje)
                    {
                        insert_cy(B_Common, yydh, qymc, czy, DS_temp.Tables[0].Rows[i_0]["krxm"].ToString(), DS_temp.Tables[0].Rows[i_0]["lsbh"].ToString(), DS_temp.Tables[0].Rows[i_0]["sktt"].ToString(), "0", "", DS_temp.Tables[0].Rows[i_0]["xydw"].ToString(), DS_temp.Tables[0].Rows[i_0]["krly"].ToString(), DS_temp.Tables[0].Rows[i_0]["sktt"].ToString(), "1", DS_temp.Tables[0].Rows[i_0]["ddsj"].ToString(), DS_temp.Tables[0].Rows[i_0]["lksj"].ToString(), "", "", "", "", fkje.ToString(), xfje.ToString(), yj_xfje.ToString(), Convert.ToString(yj_xfje - fkje));
                    }


                }
            }

            DS_temp.Clear();
            DS_temp_0.Clear();
            DS_temp.Dispose();
            DS_temp_0.Dispose();

        }

        public void sk_cy(string yydh, string qymc, DateTime czrq, string cybl, string czy, BLL.Common B_Common)
        {

            int lzbh = 0;
            DataSet DS_temp = B_Common.GetList("select distinct lfbh from VIEW_lf_zd", "yddj='" + common_file.common_yddj.yddj_dj + "' order by lfbh");
            DataSet DS_temp_0 = B_Common.GetList("select distinct lfbh from VIEW_lf_zd", "yddj='" + common_file.common_yddj.yddj_dj + "'");
            decimal yj_xfje = 0; decimal cybl_0 = decimal.Parse(cybl);
            decimal fkje = 0; decimal xfje = 0;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    fkje = 0; xfje = 0;
                    DS_temp_0 = B_Common.GetList("select sum(sjxfje) as xfje from Szwmx ", "  lsbh in (select lsbh from VIEW_lf_zd where lfbh='" + DS_temp.Tables[0].Rows[i_0]["lfbh"].ToString() + "')");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        if (DS_temp_0.Tables[0].Rows[0]["xfje"].ToString() != "")
                        {
                            xfje = decimal.Parse(DS_temp_0.Tables[0].Rows[0]["xfje"].ToString());
                        }

                    DS_temp_0 = B_Common.GetList("select sum(sjxfje) as xfje from Syjcz ", "  lsbh in (select lsbh from VIEW_lf_zd where lfbh='" + DS_temp.Tables[0].Rows[i_0]["lfbh"].ToString() + "')");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        if (DS_temp_0.Tables[0].Rows[0]["xfje"].ToString() != "")
                        {
                            fkje = decimal.Parse(DS_temp_0.Tables[0].Rows[0]["xfje"].ToString());
                        }

                    yj_xfje = 0;

                    DS_temp_0 = B_Common.GetList("select * from View_Qskzd_fjzt", " lsbh in (select lsbh from VIEW_lf_zd where lfbh='" + DS_temp.Tables[0].Rows[i_0]["lfbh"].ToString() + "')  and main_sec='" + common_file.common_app.main_sec_main + "' and lksj>='" + czrq.AddDays(1).ToString() + "' and ffzf=0 order by fjbh");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        for (int k_0 = 0; k_0 < DS_temp_0.Tables[0].Rows.Count; k_0++)
                        {
                            //yj_xfje = yj_xfje + decimal.Parse(DS_temp_0.Tables[0].Rows[k_0]["sjfjjg"].ToString()) * cybl_0;

                            if (DS_temp_0.Tables[0].Rows[k_0]["sktt"].ToString() == common_file.common_sktt.sktt_tt || DS_temp_0.Tables[0].Rows[k_0]["sktt"].ToString() == common_file.common_sktt.sktt_hy)
                            {
                                if (DS_temp_0.Tables[0].Rows[k_0]["ffzf"].ToString() == "False")
                                {
                                   // yj_xfje = 0;
                                }
                                else
                                {
                                    yj_xfje = yj_xfje + decimal.Parse(DS_temp_0.Tables[0].Rows[k_0]["sjfjjg"].ToString()) * cybl_0;
                                }

                            }
                            else
                            {
                                yj_xfje = yj_xfje + decimal.Parse(DS_temp_0.Tables[0].Rows[k_0]["sjfjjg"].ToString()) * cybl_0;
                            }
                        
                        }
                    }





                    yj_xfje = yj_xfje + xfje;
                    if (yj_xfje > fkje)
                    {
                        lzbh = lzbh + 1;
                        DS_temp_0 = B_Common.GetList("select * from View_Qskzd_fjzt", " lsbh in (select lsbh from VIEW_lf_zd where lfbh='" + DS_temp.Tables[0].Rows[i_0]["lfbh"].ToString() + "')  and main_sec='" + common_file.common_app.main_sec_main + "'  order by fjbh");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            for (int j_0 = 0; j_0 < DS_temp_0.Tables[0].Rows.Count; j_0++)
                            {
                                insert_cy(B_Common, yydh, qymc, czy, DS_temp_0.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["lsbh"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["fjbh"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["sjfjjg"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["shqh"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["xydw"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["krly"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["sktt"].ToString(), "0", DS_temp_0.Tables[0].Rows[j_0]["ddsj"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["lksj"].ToString(), "ÁªÕË", lzbh.ToString() + "ºÅÁªÕË", DS_temp_0.Tables[0].Rows[j_0]["fjdh"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["dhfj"].ToString(), fkje.ToString(), xfje.ToString(), yj_xfje.ToString(), Convert.ToString(yj_xfje - fkje));

                            }
                        }
                    }





                }
            }




            DS_temp_0 = B_Common.GetList("select * from View_Qskzd_fjzt", " lsbh not in (select lsbh from VIEW_lf_zd )  and main_sec='" + common_file.common_app.main_sec_main + "'");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                for (int j_0 = 0; j_0 < DS_temp_0.Tables[0].Rows.Count; j_0++)
                {
                    fkje = 0; xfje = 0;
                    DS_temp = B_Common.GetList("select sum(sjxfje) as xfje from Szwmx ", "  lsbh ='" + DS_temp_0.Tables[0].Rows[j_0]["lsbh"].ToString() + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        if (DS_temp.Tables[0].Rows[0]["xfje"].ToString() != "")
                        {
                            xfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["xfje"].ToString());
                        }

                    DS_temp = B_Common.GetList("select sum(sjxfje) as xfje from Syjcz ", "  lsbh ='" + DS_temp_0.Tables[0].Rows[j_0]["lsbh"].ToString() + "'");
                    if (DS_temp != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        if (DS_temp.Tables[0].Rows[0]["xfje"].ToString() != "")
                        {
                            fkje = decimal.Parse(DS_temp.Tables[0].Rows[0]["xfje"].ToString());
                        }

                    yj_xfje = 0;
                    if (DateTime.Parse(DS_temp_0.Tables[0].Rows[j_0]["lksj"].ToString()) >= czrq.AddDays(1))
                    {
                        DS_temp = B_Common.GetList("select * from View_Qskzd ", " lsbh ='" + DS_temp_0.Tables[0].Rows[j_0]["lsbh"].ToString() + "' and main_sec='"+common_file.common_app.main_sec_main+"'");
                        if (DS_temp != null && DS_temp_0.Tables[0].Rows.Count > 0)
                            if (DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString() != "")
                            {
                                yj_xfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString()) * cybl_0;
                            }
                        if (DS_temp.Tables[0].Rows[0]["sktt"].ToString() == common_file.common_sktt.sktt_tt || DS_temp.Tables[0].Rows[0]["sktt"].ToString() == common_file.common_sktt.sktt_hy)
                        {
                            if (DS_temp.Tables[0].Rows[0]["ffzf"].ToString() == "False")
                            {
                                yj_xfje = 0;
                            }

                        }
                    }
                    yj_xfje = yj_xfje + xfje;
                    if (yj_xfje > fkje)
                    {
                        insert_cy(B_Common, yydh, qymc, czy, DS_temp_0.Tables[0].Rows[j_0]["krxm"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["lsbh"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["fjbh"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["sjfjjg"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["shqh"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["xydw"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["krly"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["sktt"].ToString(), "0", DS_temp_0.Tables[0].Rows[j_0]["ddsj"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["lksj"].ToString(), "", "", DS_temp_0.Tables[0].Rows[j_0]["fjdh"].ToString(), DS_temp_0.Tables[0].Rows[j_0]["dhfj"].ToString(), fkje.ToString(), xfje.ToString(), yj_xfje.ToString(), Convert.ToString(yj_xfje - fkje));

                    }
                }

            }




            DS_temp.Clear();
            DS_temp_0.Clear();
            DS_temp.Dispose();
            DS_temp_0.Dispose();



        }



        public string cy_app(string yydh, string qymc, string czy, string cybl, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DateTime czrq = DateTime.Parse(czsj.ToShortDateString());
            B_Common.ExecuteSql("delete from BB_ysk_cy where czy='" + czy + "'");

            tt_cy(yydh, qymc, DateTime.Parse(czsj.ToShortDateString()), cybl, czy, B_Common);

            sk_cy(yydh, qymc, DateTime.Parse(czsj.ToShortDateString()), cybl, czy, B_Common);

            s = common_file.common_app.get_suc;
            return s;
        }



    }
}
