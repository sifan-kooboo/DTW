using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.BBfx
{
    public class B_zhrbb_zw
    {

        string d_space = "      ";
        string s_space = "   ";
        string t_space = " ";

        string y_z_w_z = "z";
        string y_z_w_w = "w";
        decimal gztj_fl = 0;
        decimal jztj_fl = 0;
        decimal sztj_fl = 0;
        decimal yjds_fl = 0;
        decimal ljwj_fl = 0;
        decimal ljyf_fl = 0;
        decimal ljgz_fl = 0;
        decimal ljjz_fl = 0;


        public void Sjzmx_ls_add(string yydh, string cssj, string jssj, string czy, DateTime czsj)
        {
            //string cssj = csrq.ToShortDateString();
            //string jssj = jsrq.ToShortDateString() + " 23:59:59";
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "insert into BBFX_jzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,czy_temp)";
            sql_s = sql_s + "   select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,'" + czy + "' from Sjzmx where (tfsj between '" + cssj + "' and '" + jssj + "' or czsj between '" + cssj + "' and '" + jssj + "') and (xfzy<>'" + Szwgl.common_zw.zwcl_bz + "' and xfzy<>'" + Szwgl.common_zw.zwcl_congz + "')";
            B_Common.ExecuteSql(sql_s);


            //退房后的冲、补账
            string xfsj_cod = " and (((xfsj between '" + cssj + "' and '" + jssj + "') or tfsj between '" + cssj + "' and '" + jssj + "' or czsj between '" + cssj + "' and '" + jssj + "')and (xfzy='" + Szwgl.common_zw.zwcl_bz + "' or xfzy='" + Szwgl.common_zw.zwcl_congz + "'))";
            sql_s = "insert into BBFX_jzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,czy_temp)";
            sql_s = sql_s + "   select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,'" + czy + "' from Sjzmx where id>0" + xfsj_cod;
            B_Common.ExecuteSql(sql_s);



            sql_s = "insert into BBFX_jzmx_bak(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,czy_temp)";
            sql_s = sql_s + "  select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,'" + czy + "' from Sjzmx_bak where (tfsj between '" + cssj + "' and '" + jssj + "' or czsj between '" + cssj + "' and '" + jssj + "') and (xfzy<>'" + Szwgl.common_zw.zwcl_bz + "' and xfzy<>'" + Szwgl.common_zw.zwcl_congz + "')";
            B_Common.ExecuteSql(sql_s);


            //退房后的冲、补账
             xfsj_cod = " and (((xfsj between '" + cssj + "' and '" + jssj + "') or tfsj between '" + cssj + "' and '" + jssj + "' or czsj between '" + cssj + "' and '" + jssj + "')and (xfzy='" + Szwgl.common_zw.zwcl_bz + "' or xfzy='" + Szwgl.common_zw.zwcl_congz + "'))";
            sql_s = "insert into BBFX_jzmx_bak(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,czy_temp)";
            sql_s = sql_s + "  select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,'" + czy + "' from Sjzmx_bak where id>0" + xfsj_cod;
            B_Common.ExecuteSql(sql_s);


        }



        public void Insert_SQL_bbfx(BLL.Common B_Common, string table_name, string yydh, string qymc, string sbzd, string xfrb, string sjxfje, string czy, string y_r, string y_z_w, DateTime bbrq)
        {
            string sql_s = "insert into " + table_name + " (yydh,qymc,sbzd,xfrb,sjxfje,czy_temp,y_r,y_z_w,bbrq)";
            sql_s = sql_s + " values ('" + yydh + "','" + qymc + "','" + sbzd + "','" + xfrb + "','" + sjxfje.ToString() + "','" + czy + "','" + y_r + "','" + y_z_w + "','" + bbrq.ToShortDateString() + "')";
            B_Common.ExecuteSql(sql_s);
        }


        public void zhrbb_yy_zw_add(string yydh, string qymc, BLL.Common B_Common, DataSet DS_temp, string sbzd, string xfrb, string czy, string table_name, string y_r, DateTime rq, string fk_xf)
        {
            //string sql_s = "";
            decimal sjxfje = 0;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {

                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["fkfs"].ToString() == xfrb)
                    {
                        if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                        {
                            sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());
                            if (fk_xf == "fk")
                            {
                                sjxfje = -sjxfje;
                            }

                        }
                    }

                }
            }
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + xfrb, sjxfje.ToString(), czy, y_r, y_z_w_z, rq);
        }



        public void zhrbb_zw_add(string yydh, string qymc, BLL.Common B_Common, string czy, string czsj, string xxzs, string y_r, string cssj, string jssj, DateTime rq)
        {
            string table_name = "BBfx_yyjl"; string sbzd = "";
            //BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp;

            string tfsj_cod = " and (tfsj between '" + cssj + "' and '" + jssj + "')";
            string czsj_cod = " and (czsj between '" + cssj + "' and '" + jssj + "')";
            string xfsj_cod = " and ((xfsj between '" + cssj + "' and '" + jssj + "') and ((convert(varchar(10),xfsj,120) >convert(varchar(10),tfsj,120))) and (xfzy='" + Szwgl.common_zw.zwcl_bz + "' or xfzy='" + Szwgl.common_zw.zwcl_congz + "'))";
            //只有把这一步加上才不会对退房后的冲补账多调整
            string tfsj_cod_b_c = " and ((tfsj between '" + cssj + "' and '" + jssj + "') and ((convert(varchar(10),xfsj,120) >convert(varchar(10),tfsj,120))) and (xfzy='" + Szwgl.common_zw.zwcl_bz + "' or xfzy='" + Szwgl.common_zw.zwcl_congz + "'))";
            string fk_cod = " and ()";

            sbzd = "z_z_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "账务处理分析", "", czy, y_r, y_z_w_z, rq);

            //空格1
            sbzd = "z_sp_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_z, rq);
            //挂账金额合计
            decimal sjxfje = 0; decimal gzzzz_je = 0;
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + tfsj_cod + " and (czzt like '%" + common_file_server.common_jzzt.czzt_gz_xg + "%'  and czzt!='" + common_file.common_jzzt.czzt_jzzgz + "')  and (id_app not in (select id_app from VIEW_S_jzmx_bak_jzzgz))");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            //只有把这一步加上才不会对退房后的冲补账多调整
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + tfsj_cod_b_c + " and (czzt like '%" + common_file_server.common_jzzt.czzt_gz_xg + "%'  and czzt!='" + common_file.common_jzzt.czzt_jzzgz + "')  and (id_app not in (select id_app from VIEW_S_jzmx_bak_jzzgz))");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje-decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }



            //记账转挂账

            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + czsj_cod + " and czzt like '%" + common_file.common_jzzt.czzt_jzzgz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + czsj_cod + " and czzt like '%" + common_file.common_jzzt.czzt_jzzgz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }

            //退房后的冲、补账
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + xfsj_cod + " and (czzt = '" + common_file.common_jzzt.czzt_gzzjz + "' or czzt = '" + common_file.common_jzzt.czzt_gzfj + "' or czzt = '" + common_file.common_jzzt.czzt_gzzsz + "' or czzt = '" + common_file.common_jzzt.czzt_gz + "') ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + xfsj_cod + " and (czzt = '" + common_file.common_jzzt.czzt_gzzzz + "') ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }


            //转在住
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + tfsj_cod + " and (czzt like '%" + common_file.common_jzzt.czzt_gzzzz + "%' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    gzzzz_je = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }

            //只有把这一步加上才不会对退房后的冲补账多调整
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + tfsj_cod_b_c + " and (czzt like '%" + common_file.common_jzzt.czzt_gzzzz + "%' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    gzzzz_je = gzzzz_je-decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }

            sbzd = "z_gzje_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "挂账金额合计", Convert.ToString(sjxfje + gzzzz_je), czy, y_r, y_z_w_z, rq);
            if (y_r == "r")
            {
                gztj_fl = sjxfje + gzzzz_je;
            }




            //挂账转在住
            gzzzz_je = 0;
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + czsj_cod + " and czzt like '%" + common_file.common_jzzt.czzt_gzzzz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    gzzzz_je = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            sbzd = "z_gzzzz_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "挂账转在住", Convert.ToString(gzzzz_je), czy, y_r, y_z_w_z, rq);




            //挂账转记账
            sjxfje = 0;
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and czzt like '%" + common_file.common_jzzt.czzt_gzzjz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and czzt like '%" + common_file.common_jzzt.czzt_gzzjz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }


            sbzd = "z_gzzjz_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "挂账转记账", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);

            //挂账转结账
            sjxfje = 0;
            string str_temp_1 = " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr='" + common_file.common_app.fkdr + "' and (czzt like '%" + common_file.common_jzzt.czzt_gzzsz + "%' or czzt like '%" + common_file.common_jzzt.czzt_gzfj + "%') group by fkfs";
            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BBFX_jzmx", str_temp_1);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());

                    }
                }

            }


            sjxfje = -sjxfje;
            sbzd = "z_gzzsz_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "挂账转结账", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);


            //挂账转结账付款
            //显示具体可显示付款方式的金额
            sjxfje = 0;
            DataSet DS_temp_0 = B_Common.GetList("select distinct fkfs from Xfkfs", " fkfs<>'" + common_file.common_app.dj_ysq + "' and is_visible_bb=1");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                {
                    sbzd = "z_gzzsz_m_" + i_0.ToString();
                    zhrbb_yy_zw_add(yydh, qymc, B_Common, DS_temp, sbzd, DS_temp_0.Tables[0].Rows[i_0]["fkfs"].ToString(), czy, table_name, y_r, rq, "fk");
                }
            }

            //显示具体没有显示付款方式的归为其他的金额
            sjxfje = 0;
            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BBFX_jzmx", " fkfs in(select fkfs from Xfkfs where fkfs<>'" + common_file.common_app.dj_ysq + "' and is_visible_bb=0) and" + str_temp_1);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());

                    }
                }

            }
            sjxfje = -sjxfje;
            sbzd = "z_gzzsz_m_qt_0";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "其他", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);





            //空格2
            sbzd = "z_sp_2";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_z, rq);
            //记账金额合计
            sjxfje = 0; decimal jzzzz_je = 0;
            string s_temo_00 = "select * from BBFX_jzmx where czy_temp='" + czy + "'" + tfsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and (czzt like '%" + common_file_server.common_jzzt.czzt_jz_xg + "%' and czzt !='" + common_file.common_jzzt.czzt_gzzjz + "')  and (id_app not in (select id_app from VIEW_S_jzmx_bak_gzzjz))";
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", " czy_temp='" + czy + "'" + tfsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and (czzt like '%" + common_file_server.common_jzzt.czzt_jz_xg + "%' and czzt !='" + common_file.common_jzzt.czzt_gzzjz + "')  and (id_app not in (select id_app from VIEW_S_jzmx_bak_gzzjz))");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            //只有把这一步加上才不会对退房后的冲补账多调整
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", " czy_temp='" + czy + "'" + tfsj_cod_b_c + " and  xfdr<>'" + common_file.common_app.fkdr + "' and (czzt like '%" + common_file_server.common_jzzt.czzt_jz_xg + "%' and czzt !='" + common_file.common_jzzt.czzt_gzzjz + "')  and (id_app not in (select id_app from VIEW_S_jzmx_bak_gzzjz))");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje-decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }




            //挂账转记账
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and czzt like '%" + common_file.common_jzzt.czzt_gzzjz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and czzt like '%" + common_file.common_jzzt.czzt_gzzjz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }


            //退房后的冲、补账
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + xfsj_cod + " and (czzt = '" + common_file.common_jzzt.czzt_jzzgz + "' or czzt = '" + common_file.common_jzzt.czzt_jzfj + "' or czzt = '" + common_file.common_jzzt.czzt_jzzsz + "' or czzt = '" + common_file.common_jzzt.czzt_jz + "') ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + xfsj_cod + " and (czzt = '" + common_file.common_jzzt.czzt_jzzzz + "') ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }





            //记账转在住
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "'" + tfsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and (czzt like '%" + common_file.common_jzzt.czzt_jzzzz + "%'  or czzt='" + common_file.common_jzzt.czzt_jzzgz + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    jzzzz_je = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            //只有把这一步加上才不会对退房后的冲补账多调整
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "'" + tfsj_cod_b_c + " and  xfdr<>'" + common_file.common_app.fkdr + "' and (czzt like '%" + common_file.common_jzzt.czzt_jzzzz + "%'  or czzt='" + common_file.common_jzzt.czzt_jzzgz + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    jzzzz_je = jzzzz_je-decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }




            sbzd = "z_jzje_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "记账金额合计", Convert.ToString(sjxfje + jzzzz_je), czy, y_r, y_z_w_z, rq);
            if (y_r == "r")
            {
                jztj_fl = sjxfje + jzzzz_je;
            }

            //记账转在住
            jzzzz_je = 0;
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and czzt like '%" + common_file.common_jzzt.czzt_jzzzz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    jzzzz_je = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            sbzd = "z_jzzzz_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "记账转在住", Convert.ToString(jzzzz_je), czy, y_r, y_z_w_z, rq);


            //记账转挂账
            sjxfje = 0;
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", "czy_temp='" + czy + "'" + czsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and czzt like '%" + common_file.common_jzzt.czzt_jzzgz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx_bak", " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr<>'" + common_file.common_app.fkdr + "' and czzt like '%" + common_file.common_jzzt.czzt_jzzgz + "%' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }

            }




            sbzd = "z_jzzjz_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "记账转挂账", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);


            //记账转结账
            sjxfje = 0;
            str_temp_1 = " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr='" + common_file.common_app.fkdr + "' and (czzt like '%" + common_file.common_jzzt.czzt_jzzsz + "%' or czzt like '%" + common_file.common_jzzt.czzt_jzfj + "%') group by fkfs";
            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BBFX_jzmx", str_temp_1);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());

                    }
                }

            }
            sjxfje = -sjxfje;

            sbzd = "z_jzzsz_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "记账转结账", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);


            //记账转结账付款
            //显示具体可显示付款方式的金额
            sjxfje = 0;
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                {
                    sbzd = "z_jzzsz_m_" + i_0.ToString();
                    zhrbb_yy_zw_add(yydh, qymc, B_Common, DS_temp, sbzd, DS_temp_0.Tables[0].Rows[i_0]["fkfs"].ToString(), czy, table_name, y_r, rq, "fk");
                }

            }

            //显示具体没有显示付款方式的归为其他的金额
            sjxfje = 0;
            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BBFX_jzmx", " fkfs in(select fkfs from Xfkfs where fkfs<>'" + common_file.common_app.dj_ysq + "' and is_visible_bb=0) and" + str_temp_1);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());

                    }
                }

            }
            sjxfje = -sjxfje;
            sbzd = "z_jzzsz_m_qt_0";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "其他", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);













            //空格3
            sbzd = "z_sp_3";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_z, rq);



            //前台结账合计
            sjxfje = 0;
            str_temp_1 = " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr='" + common_file.common_app.fkdr + "' and (czzt like '%" + common_file.common_jzzt.czzt_sz + "%' or czzt like '%" + common_file.common_jzzt.czzt_bfsz + "%') group by fkfs";
            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BBFX_jzmx", str_temp_1);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());

                    }
                }

            }
            sjxfje = -sjxfje;
            sbzd = "z_qtjzje_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "前台结账合计", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);
            //结账付款
            //显示具体可显示付款方式的金额
            sjxfje = 0;
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                {
                    sbzd = "z_qtjz_m_" + i_0.ToString();
                    zhrbb_yy_zw_add(yydh, qymc, B_Common, DS_temp, sbzd, DS_temp_0.Tables[0].Rows[i_0]["fkfs"].ToString(), czy, table_name, y_r, rq, "fk");
                }

            }
            //显示具体没有显示付款方式的归为其他的金额
            sjxfje = 0;
            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BBFX_jzmx", " fkfs in(select fkfs from Xfkfs where fkfs<>'" + common_file.common_app.dj_ysq + "' and is_visible_bb=0) and" + str_temp_1);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());

                    }
                }

            }
            sjxfje = -sjxfje;
            sbzd = "z_qtjz_m_qt_0";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "其他", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);























            string czzt_hj = " and (czzt like '%" + common_file.common_jzzt.czzt_sz + "%' or czzt like '%" + common_file.common_jzzt.czzt_bfsz + "%' or czzt like '%" + common_file.common_jzzt.czzt_jzzsz + "%' or czzt like '%" + common_file.common_jzzt.czzt_jzfj + "%' or czzt like '%" + common_file.common_jzzt.czzt_gzzsz + "%' or czzt like '%" + common_file.common_jzzt.czzt_gzfj + "%') ";


            //空格4
            sbzd = "z_sp_4";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_z, rq);






            //结账合计
            sjxfje = 0;
            str_temp_1 = " czy_temp='" + czy + "'" + czsj_cod + " and  xfdr='" + common_file.common_app.fkdr + "'" + czzt_hj + " group by fkfs";
            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BBFX_jzmx", str_temp_1);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());

                    }
                }

            }
            sjxfje = -sjxfje;
            sbzd = "z_zjzje_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "已结付款合计", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);
            if (y_r == "r")
            {
                sztj_fl = sjxfje;
            }
            //结账付款
            //显示具体可显示付款方式的金额
            sjxfje = 0;
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                {
                    sbzd = "z_zjz_m_" + i_0.ToString();
                    zhrbb_yy_zw_add(yydh, qymc, B_Common, DS_temp, sbzd, DS_temp_0.Tables[0].Rows[i_0]["fkfs"].ToString(), czy, table_name, y_r, rq, "fk");
                }

            }
            //显示具体没有显示付款方式的归为其他的金额
            sjxfje = 0;
            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BBFX_jzmx", " fkfs in(select fkfs from Xfkfs where fkfs<>'" + common_file.common_app.dj_ysq + "' and is_visible_bb=0) and" + str_temp_1);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());

                    }
                }

            }
            sjxfje = -sjxfje;
            sbzd = "z_zjz_m_qt_0";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "其他", Convert.ToString(sjxfje), czy, y_r, y_z_w_z, rq);









            //空格5
            sbzd = "z_sp_5";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_z, rq);


            //代收
            {
                sjxfje = 0;
                //for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                //{
                DS_temp_0 = B_Common.GetList("select xfrb,sum(sjxfje) as sjxfje from BBFX_jzmx", "czy_temp='" + czy + "'" + czsj_cod + " and xfdr='" + Szwgl.common_zw.dr_ds + "' and xfrb in(select xfxr from Xxfxr where is_visible_bb=1) " + czzt_hj + " group by xfrb");
                sjxfje = 0;
                sbzd = "z_ds_z";
                //大类费用
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    for (int k_0 = 0; k_0 < DS_temp_0.Tables[0].Rows.Count; k_0++)
                    {
                        if (DS_temp_0.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                        {
                            sjxfje = sjxfje + decimal.Parse(DS_temp_0.Tables[0].Rows[k_0]["sjxfje"].ToString());
                        }
                    }
                }

                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "已结代收总额", sjxfje.ToString(), czy, y_r, y_z_w_z, rq);
                if (y_r == "r")
                {
                    yjds_fl = sjxfje;
                }


                DataSet DS_temp_1 = B_Common.GetList("select xfxr from Xxfxr", "is_visible_bb=1 and xfdr='" + Szwgl.common_zw.dr_ds + "'");

                if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
                {
                    DS_temp_0 = B_Common.GetList("select xfrb as fkfs,sum(sjxfje) as sjxfje from BBFX_jzmx", "czy_temp='" + czy + "'" + czsj_cod + " and xfdr='" + Szwgl.common_zw.dr_ds + "' and xfrb in(select xfxr from Xxfxr where is_visible_bb=1) " + czzt_hj + " group by xfrb");
                    for (int k_0 = 0; k_0 < DS_temp_1.Tables[0].Rows.Count; k_0++)
                    {
                        zhrbb_yy_zw_add(yydh, qymc, B_Common, DS_temp_0, "z_ds_" + k_0.ToString(), DS_temp_1.Tables[0].Rows[k_0]["xfxr"].ToString(), czy, table_name, y_r, rq, "xf");
                    }
                }
                //未列入显示的小类
                sjxfje = 0; sbzd = "z_dsqt_1";
                DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje from BBFX_jzmx", "czy_temp='" + czy + "'" + czsj_cod + " and xfdr='" + Szwgl.common_zw.dr_ds + "' and xfrb in(select xfxr from Xxfxr where is_visible_bb=0)" + czzt_hj);
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString());
                    }
                }

                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "其他", sjxfje.ToString(), czy, y_r, y_z_w_z, rq);


                DS_temp_1.Clear();
                DS_temp_1.Dispose();

                //}
            }





            DS_temp_0.Clear();
            DS_temp_0.Dispose();
            DS_temp.Clear();
            DS_temp.Dispose();
        }



        public string zhrbb_zw_app(string yydh, string qymc, string czy, DateTime rq, string czsj, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "delete from BBfx_yyjl where czy_temp='" + czy + "' and y_z_w='" + y_z_w_z + "'";
            B_Common.ExecuteSql(sql_s);
            //日
            sql_s = "delete from BBfx_jzmx where czy_temp='" + czy + "'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from BBfx_jzmx_bak where czy_temp='" + czy + "'";
            B_Common.ExecuteSql(sql_s);
            Sjzmx_ls_add(yydh, rq.ToShortDateString(), rq.ToShortDateString() + " 23:59:59", czy, DateTime.Parse(czsj));

            zhrbb_zw_add(yydh, qymc, B_Common, czy, czsj.ToString(), xxzs, "r", rq.ToShortDateString(), rq.ToShortDateString() + " 23:59:59", rq);
            //月
            //月
            int ybtqts = 0;
            DataSet DS_temp;
            DS_temp = B_Common.GetList("select ybtqts from Qcounter", " id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["ybtqts"].ToString() != "")
                {
                    ybtqts = int.Parse(DS_temp.Tables[0].Rows[0]["ybtqts"].ToString());
                }
            }
            DateTime yfcssj = common_bb.judge_yfcssj(rq, ybtqts);
            sql_s = "delete from BBfx_jzmx where czy_temp='" + czy + "'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from BBfx_jzmx_bak where czy_temp='" + czy + "'";
            B_Common.ExecuteSql(sql_s);
            Sjzmx_ls_add(yydh, yfcssj.ToShortDateString(), rq.ToShortDateString() + " 23:59:59", czy, DateTime.Parse(czsj));
            zhrbb_zw_add(yydh, qymc, B_Common, czy, czsj.ToString(), xxzs, "y", yfcssj.ToShortDateString(), rq.ToShortDateString() + " 23:59:59", rq);


            //把最终结果转移到正式的地方存储
            sql_s = "delete from BBfx_yyjl_last_save where bbrq='" + rq.ToShortDateString() + "' and y_z_w='z'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "insert into BBfx_yyjl_last_save (yydh,qymc,sbzd,xfrb,sjxfje,czy,y_r,y_z_w,bbrq) select yydh,qymc,sbzd,xfrb,sjxfje,'" + czy + "',y_r,y_z_w,'" + rq.ToShortDateString() + "' from BBfx_yyjl where czy_temp='" + czy + "' and bbrq='" + rq.ToShortDateString() + "' and y_z_w='z' order by id";
            B_Common.ExecuteSql(sql_s);



            sql_s = "";
            DS_temp = B_Common.GetList("select id from BSzhrbbfl", "yydh='" + yydh + "' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                sql_s = "update BSzhrbbfl set gztj='" + gztj_fl.ToString() + "',jztj='" + jztj_fl.ToString() + "',sztj='" + sztj_fl.ToString() + "',yjds='" + yjds_fl.ToString() + "',ljwj='" + ljwj_fl.ToString() + "',ljyf='" + ljyf_fl.ToString() + "',ljgz='" + ljgz_fl.ToString() + "',ljjz='" + ljjz_fl.ToString() + "' where yydh='" + yydh + "' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'";
            }
            else
            {
                sql_s = "insert into BSzhrbbfl(yydh,qymc,bbrq,gztj,jztj,sztj,yjds,ljwj,ljyf,ljgz,ljjz) values('" + yydh + "','" + qymc + "','" + rq.ToShortDateString() + "','" + gztj_fl.ToString() + "','" + jztj_fl.ToString() + "','" + sztj_fl.ToString() + "','" + yjds_fl.ToString() + "','" + ljwj_fl.ToString() + "','" + ljyf_fl.ToString() + "','" + ljgz_fl.ToString() + "','" + ljjz_fl.ToString() + "')";

            }
            if (sql_s != "")
            {
                B_Common.ExecuteSql(sql_s);
            }

            common_file.common_czjl.add_czjl(yydh, qymc, czy, "生成日报表-账务", "", "", DateTime.Parse(czsj));
            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
        }








        /// <summary>
        /// 预收、未结
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <param name="y_r"></param>
        /// <param name="cssj"></param>
        /// <param name="jssj"></param>
        public void zhrbb_zw_ys_wj(string yydh, string qymc, string czy, string czsj, string xxzs, string y_r, string cssj, string jssj, DateTime rq)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            decimal sjxfje = 0;
            decimal lj_wj_hj = 0;
            decimal wj_fy_hj = 0;
            decimal qt_wj_fy = 0;
            decimal gz_wj_fy = 0;
            decimal jz_wj_fy = 0;
            decimal wj_ds_hj = 0;
            decimal qt_wj_ds = 0;
            decimal gz_wj_ds = 0;
            decimal jz_wj_ds = 0;

            string table_name = "BBfx_yyjl";
            string xfsj_cond = " and xfsj <='" + jssj + "' ";
            string czsj_cond = " and czsj <='" + jssj + "' ";

            //空格1
            string sbzd = "w_sp_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_w, rq);
            //空格2
            sbzd = "w_sp_2";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_w, rq);

            //预收款合计

            //报表在分析预收款时到底到扣除什么项目1排除预授权，0全部
            int ysk_pc = 0;
            DataSet DS_temp = B_Common.GetList("select * from Qcounter", " id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["ysk_pc"].ToString() != "")
                {
                    ysk_pc = int.Parse(DS_temp.Tables[0].Rows[0]["ysk_pc"].ToString());
                }

            }
            //选择的附加条件
            string ysk_cond_add = "";
            if (ysk_pc == 1)
            { ysk_cond_add = " and (fkfs<>'" + common_file.common_app.dj_ysq + "')"; }

            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from Syjcz", "id>=0 " + xfsj_cond + ysk_cond_add + " group by fkfs");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int k_0 = 0; k_0 < DS_temp.Tables[0].Rows.Count; k_0++)
                {
                    if (DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString());
                    }
                }
            }
            sbzd = "w_ys_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "累计预收款余额", sjxfje.ToString(), czy, y_r, y_z_w_w, rq);
            if (y_r == "r")
            {
                ljyf_fl = sjxfje;
            }

            //空格3
            sbzd = "w_sp_3_0";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_w, rq);
            sjxfje = 0;
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Syjcz", "id>=0 and xfsj>='" + cssj + "'" + xfsj_cond + ysk_cond_add);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }
            }
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Syjcz_temp", "id>=0 and xfsj>='" + cssj + "'" + xfsj_cond + ysk_cond_add);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }
            }
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Syjcz_bak", "id>=0  and xfsj>='" + cssj + "'" + xfsj_cond + ysk_cond_add);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }
            }
            decimal ysk_ze = sjxfje;
            sbzd = "w_ys_1_0";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "当期预收款发生额", sjxfje.ToString(), czy, y_r, y_z_w_w, rq);




            sjxfje = 0;
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Syjcz_temp", "id>=0 and czsj>='" + cssj + "' and czsj<='" + jssj + "'" + ysk_cond_add);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }
            }
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from VIEW_yj_bak", "id>=0 and czsj>='" + cssj + "' and czsj<='" + jssj + "'" + ysk_cond_add);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = sjxfje + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }
            }
            decimal ysk_t = sjxfje;
            sbzd = "w_ys_1_2";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "当期退还预收款金额", sjxfje.ToString(), czy, y_r, y_z_w_w, rq);


            //sjxfje = 0;
            //DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Syjcz", "id>=0 and xfsj>='" + cssj + "'" + xfsj_cond + ysk_cond_add);
            //if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            //{
            //if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
            //{
            //sjxfje = sjxfje + float.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
            //}
            //}

            sbzd = "w_ys_1_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "当期预收款余额", Convert.ToString(ysk_ze - ysk_t), czy, y_r, y_z_w_w, rq);














            //空格3
            sbzd = "w_sp_3";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_w, rq);






            lj_wj_hj = 0;
            wj_fy_hj = 0;
            qt_wj_fy = 0;
            gz_wj_fy = 0;
            jz_wj_fy = 0;
            wj_ds_hj = 0;
            qt_wj_ds = 0;
            gz_wj_ds = 0;
            jz_wj_ds = 0;


            //累计未结
            //sjxfje = 0;
            //DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Szwmx", "id>=0 " + xfsj_cond);
            //if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            //{
            //if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
            //{
            //sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
            //}
            //}



            ////未结合计
            //sjxfje = 0;
            //DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Szwmx", "id>=0" + xfsj_cond + " and xfdr!='" + Szwgl.common_zw.dr_ds + "'");
            //if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            //{
            //if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
            //{
            //sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
            //}
            //}




            string sj_tj = " and (bbrq between '" + DateTime.Parse(jssj).ToShortDateString() + "' and '" + jssj + "')";
            string qt_czzt_cond = "";
            //前台未结合计
            if (DateTime.Parse(jssj).ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                sjxfje = 0;
                DS_temp = B_Common.GetList("select sum(zfh) as zfh,sum(qt) as qt from BB_sh_wj", "id>=0 " + sj_tj);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["zfh"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["zfh"].ToString());
                        qt_wj_fy = sjxfje;
                    }

                    if (DS_temp.Tables[0].Rows[0]["qt"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["qt"].ToString());
                        qt_wj_fy = qt_wj_fy + sjxfje;
                    }

                }
            }
            else
            {
                sjxfje = 0;
                qt_czzt_cond = " and (czzt!='" + common_file.common_jzzt.czzt_jz + "' and czzt!='" + common_file.common_jzzt.czzt_gz + "' and czzt!='" + common_file.common_jzzt.czzt_gzzjz + "' and czzt!='" + common_file.common_jzzt.czzt_jzzgz + "')";
                DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Szwmx", "jzbh='' and id>=0 " + xfsj_cond + "  and xfdr!='" + Szwgl.common_zw.dr_ds + "'" + qt_czzt_cond);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                        qt_wj_fy = sjxfje;
                    }
                }
            }

            //挂账未结合计
            sjxfje = 0;
            if (DateTime.Parse(jssj).ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                DS_temp = B_Common.GetList("select sum(zfh) as zfh,sum(qt) as qt from BB_sh_wj_gj", "id>=0  and fx_zt='" + common_file.common_jzzt.czzt_gz + "' " + sj_tj);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["zfh"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["zfh"].ToString());
                        gz_wj_fy = sjxfje;
                    }

                    if (DS_temp.Tables[0].Rows[0]["qt"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["qt"].ToString());
                        gz_wj_fy = gz_wj_fy + sjxfje;
                    }

                }

            }
            else
            {
                sjxfje = 0;
                qt_czzt_cond = " and ( czzt='" + common_file.common_jzzt.czzt_gz + "' or  czzt='" + common_file.common_jzzt.czzt_jzzgz + "')";
                DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from VIEW_S_jz_jzORgz", "id>=0 " + czsj_cond + " and xfdr!='" + Szwgl.common_zw.dr_ds + "'" + qt_czzt_cond);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                        gz_wj_fy = sjxfje;
                    }
                }
            }
            if (y_r == "r")
            {
                ljgz_fl = gz_wj_fy;
            }

            //记账未结合计

            sjxfje = 0;
            if (DateTime.Parse(jssj).ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                DS_temp = B_Common.GetList("select sum(zfh) as zfh,sum(qt) as qt from BB_sh_wj_gj", "id>=0  and fx_zt='" + common_file.common_jzzt.czzt_jz + "' " + sj_tj);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["zfh"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["zfh"].ToString());
                        jz_wj_fy = sjxfje;
                    }

                    if (DS_temp.Tables[0].Rows[0]["qt"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["qt"].ToString());
                        jz_wj_fy = jz_wj_fy + sjxfje;
                    }

                }
            }
            else
            {
                sjxfje = 0;
                qt_czzt_cond = " and ( czzt='" + common_file.common_jzzt.czzt_jz + "' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "')";
                DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from VIEW_S_jz_jzORgz", "id>=0 " + czsj_cond + " and xfdr!='" + Szwgl.common_zw.dr_ds + "'" + qt_czzt_cond);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                        jz_wj_fy = sjxfje;
                    }
                }
            }
            if (y_r == "r")
            {
                ljjz_fl = jz_wj_fy;
            }



            ////代收合计
            //sjxfje = 0;
            //DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Szwmx", "id>=0" + xfsj_cond + " and xfdr='" + Szwgl.common_zw.dr_ds + "'");
            //if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            //{
            //if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
            //{
            //sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
            //}
            //}



            //前台代收合计
            sjxfje = 0;
            if (DateTime.Parse(jssj).ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                DS_temp = B_Common.GetList("select sum(ds) as ds from BB_sh_wj", "id>=0 " + sj_tj);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["ds"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["ds"].ToString());
                        qt_wj_ds = sjxfje;
                    }

                }

            }
            else
            {
                sjxfje = 0;
                qt_czzt_cond = " and (czzt!='" + common_file.common_jzzt.czzt_jz + "' and czzt!='" + common_file.common_jzzt.czzt_gz + "' and czzt!='" + common_file.common_jzzt.czzt_gzzjz + "' and czzt!='" + common_file.common_jzzt.czzt_jzzgz + "')";
                DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Szwmx", "jzbh='' and id>=0 " + xfsj_cond + " and xfdr='" + Szwgl.common_zw.dr_ds + "'" + qt_czzt_cond);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                        qt_wj_ds = sjxfje;
                    }
                }
            }


            //挂账代收合计



            sjxfje = 0;
            if (DateTime.Parse(jssj).ToShortDateString() != DateTime.Now.ToShortDateString())
            {

                DS_temp = B_Common.GetList("select sum(ds) as ds from BB_sh_wj_gj", "id>=0  and fx_zt='" + common_file.common_jzzt.czzt_gz + "' " + sj_tj);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["ds"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["ds"].ToString());
                        gz_wj_ds = sjxfje;
                    }


                }
            }
            else
            {
                sjxfje = 0;
                qt_czzt_cond = " and ( czzt='" + common_file.common_jzzt.czzt_gz + "' or  czzt='" + common_file.common_jzzt.czzt_jzzgz + "')";
                DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from VIEW_S_jz_jzORgz", "id>=0 " + czsj_cond + "  and xfdr='" + Szwgl.common_zw.dr_ds + "'" + qt_czzt_cond);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                        gz_wj_ds = sjxfje;
                    }
                }

            }
            if (y_r == "r")
            {
                ljgz_fl = ljgz_fl + gz_wj_ds;
            }



            //记账代收合计
            sjxfje = 0;
            if (DateTime.Parse(jssj).ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                DS_temp = B_Common.GetList("select sum(ds) as ds from BB_sh_wj_gj", "id>=0  and fx_zt='" + common_file.common_jzzt.czzt_jz + "' " + sj_tj);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["ds"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["ds"].ToString());
                        jz_wj_ds = sjxfje;
                    }
                }
            }
            else
            {

                sjxfje = 0;
                qt_czzt_cond = " and ( czzt='" + common_file.common_jzzt.czzt_jz + "' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "')";
                DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from VIEW_S_jz_jzORgz", "id>=0 " + czsj_cond + "  and xfdr='" + Szwgl.common_zw.dr_ds + "'" + qt_czzt_cond);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                        jz_wj_ds = sjxfje;
                    }
                }
            }

            if (y_r == "r")
            {
                ljjz_fl = ljjz_fl + jz_wj_ds;
            }


            //累计未结合计
            if (y_r == "r")
            {
                ljwj_fl = jz_wj_ds + gz_wj_ds + qt_wj_ds + jz_wj_fy + gz_wj_fy + qt_wj_fy;
            }
            sbzd = "w_wjz_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "累计未结合计", ljwj_fl.ToString(), czy, y_r, y_z_w_w, rq);
            //未结费用合计
            sbzd = "w_wjz_wj_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "未结费用合计", Convert.ToString(jz_wj_fy + gz_wj_fy + qt_wj_fy), czy, y_r, y_z_w_w, rq);
            //前台未结费用
            sbzd = "w_qtwjz_wj_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "前台未结费用", qt_wj_fy.ToString(), czy, y_r, y_z_w_w, rq);
            //挂账未结费用
            sbzd = "w_gzwjz_wj_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "挂账未结费用", gz_wj_fy.ToString(), czy, y_r, y_z_w_w, rq);
            //记账未结费用
            sbzd = "w_jzwjz_wj_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "记账未结费用", jz_wj_fy.ToString(), czy, y_r, y_z_w_w, rq);
            //未结代收合计
            sbzd = "w_wjz_ds_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "未结代收合计", Convert.ToString(jz_wj_ds + gz_wj_ds + qt_wj_ds), czy, y_r, y_z_w_w, rq);
            //前台未结代收
            sbzd = "w_qtwjz_ds_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "前台未结代收", qt_wj_ds.ToString(), czy, y_r, y_z_w_w, rq);
            //挂账未结代收
            sbzd = "w_gzwjz_ds_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "挂账未结代收", gz_wj_ds.ToString(), czy, y_r, y_z_w_w, rq);
            //记账未结代收
            sbzd = "w_jzwjz_ds_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "记账未结代收", jz_wj_ds.ToString(), czy, y_r, y_z_w_w, rq);










            //zhrbb_yy_zw_add(yydh, qymc, B_Common, DS_temp_0, "z_ds_" + k_0.ToString(), DS_temp_1.Tables[0].Rows[k_0]["xfxr"].ToString(), czy, table_name, y_r,rq);

            DS_temp.Clear();
            DS_temp.Dispose();
        }



        public string zhrbb_zw_ys_wj_app(string yydh, string qymc, string czy, DateTime rq, string czsj, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "delete from BBfx_yyjl where czy_temp='" + czy + "' and y_z_w='" + y_z_w_w + "'";
            B_Common.ExecuteSql(sql_s);



            //日

            zhrbb_zw_ys_wj(yydh, qymc, czy, czsj, xxzs, "r", rq.ToShortDateString(), rq.ToShortDateString() + " 23:59:59", rq);



            //月
            //月
            int ybtqts = 0;

            DataSet DS_temp;
            DS_temp = B_Common.GetList("select ybtqts from Qcounter", " id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["ybtqts"].ToString() != "")
                {
                    ybtqts = int.Parse(DS_temp.Tables[0].Rows[0]["ybtqts"].ToString());
                }
            }
            DateTime yfcssj = common_bb.judge_yfcssj(rq, ybtqts);

            zhrbb_zw_ys_wj(yydh, qymc, czy, czsj, xxzs, "y", yfcssj.ToShortDateString(), rq.ToShortDateString() + " 23:59:59", rq);


            //把最终结果转移到正式的地方存储
            sql_s = "delete from BBfx_yyjl_last_save where bbrq='" + rq.ToShortDateString() + "' and y_z_w='w'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "insert into BBfx_yyjl_last_save (yydh,qymc,sbzd,xfrb,sjxfje,czy,y_r,y_z_w,bbrq) select yydh,qymc,sbzd,xfrb,sjxfje,'" + czy + "',y_r,y_z_w,'" + rq.ToShortDateString() + "' from BBfx_yyjl where czy_temp='" + czy + "' and bbrq='" + rq.ToShortDateString() + "' and y_z_w='w'";
            B_Common.ExecuteSql(sql_s);





            sql_s = "";
            DS_temp = B_Common.GetList("select id from BSzhrbbfl", "yydh='" + yydh + "' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                sql_s = "update BSzhrbbfl set gztj='" + gztj_fl.ToString() + "',jztj='" + jztj_fl.ToString() + "',sztj='" + sztj_fl.ToString() + "',yjds='" + yjds_fl.ToString() + "',ljwj='" + ljwj_fl.ToString() + "',ljyf='" + ljyf_fl.ToString() + "',ljgz='" + ljgz_fl.ToString() + "',ljjz='" + ljjz_fl.ToString() + "' where yydh='" + yydh + "' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'";
            }
            else
            {
                sql_s = "insert into BSzhrbbfl(yydh,qymc,bbrq,gztj,jztj,sztj,yjds,ljwj,ljyf,ljgz,ljjz) values('" + yydh + "','" + qymc + "','" + rq.ToShortDateString() + "','" + gztj_fl.ToString() + "','" + jztj_fl.ToString() + "','" + sztj_fl.ToString() + "','" + yjds_fl.ToString() + "','" + ljwj_fl.ToString() + "','" + ljyf_fl.ToString() + "','" + ljgz_fl.ToString() + "','" + ljjz_fl.ToString() + "')";

            }
            if (sql_s != "")
            {
                B_Common.ExecuteSql(sql_s);
            }


            common_file.common_czjl.add_czjl(yydh, qymc, czy, "生成日报表-未结", "", "", DateTime.Parse(czsj));
            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
        }


    }

}
