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
namespace Hotel_app.Server.Szwgl
{
    public class S_jb_jk_fx
    {


        public string Sjzmx_or_bak_ls_add_app(string yydh, string qymc, string czy, string cssj, string jssj, string xxzs,string czy_GUID)
        {
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "";

            sql_s = "delete from BS_jzmx_ls where yydh='" + yydh + "' and czy_temp='" + czy_GUID + "'";
            B_Common.ExecuteSql(sql_s);

            sql_s = "insert into BS_jzmx_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,shsc,czy_bc,czzt,tfsj,czsj,syzd,jzzt,fkfs,mxbh,czy_temp)";
            sql_s = sql_s + "select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,shsc,czy_bc,czzt,tfsj,czsj,syzd,jzzt,fkfs,mxbh,'" + czy_GUID + "' from Sjzmx where yydh='" + yydh + "' and xfdr='" + common_file.common_app.fkdr + "' and (czsj >= '" + cssj + "' and czsj <'" + jssj + "')";



            B_Common.ExecuteSql(sql_s);

            get_result = common_file.common_app.get_suc;
            return get_result;

        }


        public void insert_mx(BLL.Common B_Common, string yydh, string qymc, string lsbh, string syzd, string syy, string syy_rb_visible, string fkfs)
        {
            string sql_s = "insert into S_jbmx(yydh,qymc,lsbh,syzd,syy,syy_rb_visible,fkfs,qtfk,ysk,t_ysk,qtsk_t_ysk,t_ysk_qt,ysk_fs) values ('" + yydh + "','" + qymc + "','" + lsbh + "','" + syzd + "','" + syy + "','" + syy_rb_visible + "','" + fkfs + "',0,0,0,0,0,0)";
            B_Common.ExecuteSql(sql_s);

        }



        /// <summary>
        /// 获取预收款余额和发生额
        /// </summary>
        /// <param name="DS_temp"></param>
        /// <param name="B_Common"></param>
        /// <param name="sel_cond_yj"></param>
        /// <param name="sql_s"></param>
        /// <param name="yydh"></param>
        /// <param name="lsbh"></param>
        /// <param name="ysk_zd"></param>
        /// <param name="table_name"></param>
        public void add_yj_app(DataSet DS_temp, BLL.Common B_Common, string sel_cond_yj, string sql_s, string yydh, string lsbh, string ysk_zd, string table_name, string jb_jk_rx)
        {
            int i_0 = 0; int j_0 = 0;


            DS_temp = B_Common.GetList("select czy,fkfs,sum(sjxfje) as sjxfje from " + table_name, "id>=0 " + sel_cond_yj + " group by czy,fkfs");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set " + ysk_zd + "=" + ysk_zd + "+'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and fkfs='" + DS_temp.Tables[0].Rows[i_0]["fkfs"].ToString() + "' and syy='" + DS_temp.Tables[0].Rows[i_0]["czy"].ToString() + "'";
                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }


            DS_temp = B_Common.GetList("select czy,sum(sjxfje) as sjxfje from " + table_name, "id>=0 " + sel_cond_yj + " group by czy");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set " + ysk_zd + "=" + ysk_zd + "+'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and syy='" + DS_temp.Tables[0].Rows[i_0]["czy"].ToString() + "' and fkfs='合计'";
                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }



            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from " + table_name, "id>=0 " + sel_cond_yj + " group by fkfs");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set " + ysk_zd + "=" + ysk_zd + "+'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and fkfs='" + DS_temp.Tables[0].Rows[i_0]["fkfs"].ToString() + "' and syy='累计'";
                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }


            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from " + table_name, "id>=0 " + sel_cond_yj);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set " + ysk_zd + "=" + ysk_zd + "+'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and fkfs='合计' and syy='累计'";
                        B_Common.ExecuteSql(sql_s);

                        sql_s = "update S_jbzd set " + ysk_zd + "=" + ysk_zd + "+'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "'";
                        B_Common.ExecuteSql(sql_s);
                        if (table_name == "Syjcz" && ysk_zd == "ysk")
                        {
                            if (jb_jk_rx == common_zw.jb_jk_jk)
                            {
                                sql_s = "insert into Syjcz_jb(yydh,qymc,jzbh,lsbh,lsbh_jb,id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt) ";
                                sql_s = sql_s + "select yydh,qymc,jzbh,lsbh,'" + lsbh + "',id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt from " + table_name + " where id>=0 ";
                            }
                            else
                            {
                                sql_s = "insert into Syjcz_jb(yydh,qymc,jzbh,lsbh,lsbh_jb,id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt) ";
                                sql_s = sql_s + "select yydh,qymc,jzbh,lsbh,'" + lsbh + "',id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt from " + table_name + " where id>=0 " + sel_cond_yj;
                            }
                            B_Common.ExecuteSql(sql_s);
                        }
                        else
                            if ((table_name == "Syjcz" && ysk_zd == "ysk_fs") || (table_name == "Syjcz_temp" && ysk_zd == "ysk_fs") || (table_name == "Syjcz_bak" && ysk_zd == "ysk_fs"))
                            {
                                sql_s = "insert into Syjcz_jb_fs(yydh,qymc,jzbh,lsbh,lsbh_jb,id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt) ";
                                sql_s = sql_s + "select yydh,qymc,jzbh,lsbh,'" + lsbh + "',id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt from " + table_name + " where id>=0 " + sel_cond_yj;
                                B_Common.ExecuteSql(sql_s);
                            }
                            else
                                if (table_name == "Syjcz_temp" && ysk_zd == "t_ysk_qt")
                                {
                                    sql_s = "insert into Syjcz_jb_td(yydh,qymc,jzbh,lsbh,lsbh_jb,id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt,czsj) ";
                                    sql_s = sql_s + "select yydh,qymc,jzbh,lsbh,'" + lsbh + "',id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt,czsj from " + table_name + " where id>=0 " + sel_cond_yj;
                                    B_Common.ExecuteSql(sql_s);

                                }


                    }
                    else
                    {
                        if (table_name == "Syjcz" && ysk_zd == "ysk")
                        {
                            if (jb_jk_rx == common_zw.jb_jk_jk)
                            {
                                sql_s = "insert into Syjcz_jb(yydh,qymc,jzbh,lsbh,lsbh_jb,id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt) ";
                                sql_s = sql_s + "select yydh,qymc,jzbh,lsbh,'" + lsbh + "',id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt from " + table_name + " where id>=0 "; B_Common.ExecuteSql(sql_s);
                            }
                            
                        }
                    }
                }
            }
            else
            {
                if (table_name == "Syjcz" && ysk_zd == "ysk")
                {
                    if (jb_jk_rx == common_zw.jb_jk_jk)
                    {
                        sql_s = "insert into Syjcz_jb(yydh,qymc,jzbh,lsbh,lsbh_jb,id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt) ";
                        sql_s = sql_s + "select yydh,qymc,jzbh,lsbh,'" + lsbh + "',id_app,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,syzd,czzt from " + table_name + " where id>=0 "; B_Common.ExecuteSql(sql_s);
                    }
                    
                }
            }
        }



        //获取付款方式 
        public void add_all_fkfs(DataSet DS_temp, ref string zd_fx, ref  string[] arg_fkfs_cy0, int h_0)
        {

            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (zd_fx == "")
                {
                    zd_fx = "'" + DS_temp.Tables[0].Rows[0]["fkfs"].ToString() + "'";
                }
                else
                {
                    zd_fx = zd_fx + ",'" + DS_temp.Tables[0].Rows[0]["fkfs"].ToString() + "'";
                }
                arg_fkfs_cy0[0] = DS_temp.Tables[0].Rows[0]["fkfs"].ToString();
                for (h_0 = 1; h_0 < DS_temp.Tables[0].Rows.Count; h_0++)
                {
                    zd_fx = zd_fx + ",'" + DS_temp.Tables[0].Rows[h_0]["fkfs"].ToString() + "'";
                    arg_fkfs_cy0[h_0] = DS_temp.Tables[0].Rows[h_0]["fkfs"].ToString();
                }

            }

        }



        //获取收银员 
        public void add_all_czy(DataSet DS_temp, ref string zd_fx, ref  string[] arg_czy_cy0, int h_0)
        {

            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (zd_fx == "")
                {
                    zd_fx = "'" + DS_temp.Tables[0].Rows[0]["czy"].ToString() + "'";
                }
                else
                {
                    zd_fx = zd_fx + ",'" + DS_temp.Tables[0].Rows[0]["czy"].ToString() + "'";
                }
                arg_czy_cy0[0] = DS_temp.Tables[0].Rows[0]["czy"].ToString();
                for (h_0 = 1; h_0 < DS_temp.Tables[0].Rows.Count; h_0++)
                {
                    zd_fx = zd_fx + ",'" + DS_temp.Tables[0].Rows[h_0]["czy"].ToString() + "'";
                    arg_czy_cy0[h_0] = DS_temp.Tables[0].Rows[h_0]["czy"].ToString();
                }

            }

        }



        /// <summary>
        /// 交班或交款，主要是用来交款，也可改造用来交款
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="syzd"></param>
        /// <param name="czy_jb"></param>
        /// <param name="czy_sb"></param>
        /// <param name="j_s_bc"></param>
        /// <param name="czsj"></param>
        /// <param name="czy"></param>
        /// <param name="bz"></param>
        /// <param name="xxzs"></param>
        public string add_jb_app(string yydh, string qymc, string syzd, string czy_jb, string czy_sb, string j_s_bc, DateTime czsj, string czy, string bz, string jb_jk_rx, string xxzs,string  czy_GUID)
        {
            string get_result = common_file.common_app.get_failure;
            DateTime cssj = DateTime.Parse("1800-01-01");
            BLL.Common B_Common = new Hotel_app.BLL.Common();


            string sql_s = "";
            if (jb_jk_rx == common_zw.jb_jk_jk)
            {
                sql_s = "delete from S_jbzd where czsj='" + czsj + "' and jb_jk_rx='" + common_zw.jb_jk_jk + "' and yydh='" + yydh + "'";
                B_Common.ExecuteSql(sql_s);
            }



            DataSet DS_temp = B_Common.GetList("select top 1 * from S_jbzd", " yydh='" + yydh + "' and syzd='" + syzd + "' and jb_jk_rx='" + jb_jk_rx + "' and id>=0 and czsj<'" + czsj.ToString() + "' order by id desc");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                cssj = DateTime.Parse(DS_temp.Tables[0].Rows[0]["czsj"].ToString());
            }
            DateTime jssj = czsj;
            string lsbh = common_file.common_ddbh.ddbh("jbbh", "lsbhdate", "lsbhcounter", 6);



            string sel_cond = " and yydh='" + yydh + "' and (czsj >= '" + cssj.ToString() + "' and czsj<'" + jssj.ToString() + "')";
            if (syzd != "")
            {
                sel_cond = sel_cond + " and syzd='" + syzd + "'";
            }
            string sel_cond_yj = " and yydh='" + yydh + "' and (xfsj >= '" + cssj.ToString() + "' and xfsj<'" + jssj.ToString() + "')";
            if (syzd != "")
            {
                sel_cond_yj = sel_cond_yj + " and syzd='" + syzd + "'";
            }
            //退订的条件
            string sel_cond_td = " and yydh='" + yydh + "' and (czsj >= '" + cssj.ToString() + "' and czsj<'" + jssj.ToString() + "')";
            if (syzd != "")
            {
                sel_cond_td = sel_cond_td + " and syzd='" + syzd + "'";
            }
            //已退
            //string czzt_cond_yt = " and (czzt='" + common_file.common_jzzt.czzt_gz + "' or czzt='" + common_file.common_jzzt.czzt_jz + "' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "' or czzt='" + common_file.common_jzzt.czzt_jzzgz + "')";
            //前台
            string czzt_cond_qt = " and (czzt!='" + common_file.common_jzzt.czzt_gz + "' and czzt!='" + common_file.common_jzzt.czzt_jz + "' and czzt!='" + common_file.common_jzzt.czzt_gzzjz + "' and czzt!='" + common_file.common_jzzt.czzt_jzzgz + "')";

            sql_s = "insert into S_jbzd(yydh,qymc,lsbh,syzd,czy_jb,czy_sb,j_s_bc,cssj,czsj,czy,bz,jb_jk_rx) values ('" + yydh + "','" + qymc + "','" + lsbh + "','" + syzd + "','" + czy_jb + "','" + czy_sb + "','" + j_s_bc + "','" + cssj.ToString() + "','" + czsj.ToString() + "','" + czy + "','" + bz + "','" + jb_jk_rx + "')";
            B_Common.ExecuteSql(sql_s);


            Sjzmx_or_bak_ls_add_app(yydh, qymc, czy, cssj.ToString(), jssj.ToString(), xxzs,czy_GUID);


            //以下获取所有的付款方式
            string zd_fx = "";
            int h_0 = 0;
            //当前的
            string temp = "id>=0  " + sel_cond_yj;
            DS_temp = B_Common.GetList("select distinct fkfs from Syjcz", "id>=0  " + sel_cond_yj);
            string[] arg_fkfs_cy0 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_fkfs(DS_temp, ref  zd_fx, ref  arg_fkfs_cy0, h_0);
            //直接退的发生的
            string temp1 = "id>=0  " + sel_cond_yj + " and fkfs not in (" + zd_fx + ")";
            if (zd_fx.Trim() != "")
            {
                DS_temp = B_Common.GetList("select distinct fkfs from Syjcz_temp", "id>=0  " + sel_cond_yj + " and fkfs not in (" + zd_fx + ")");
            }
            else
            {
                DS_temp = B_Common.GetList("select distinct fkfs from Syjcz_temp", "id>=0  " + sel_cond_yj + "  ");
            }

            string[] arg_fkfs_cy1 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_fkfs(DS_temp, ref  zd_fx, ref  arg_fkfs_cy1, h_0);
            //直接退的退订的
            temp = "id>=0  " + sel_cond_td + " and fkfs not in (" + zd_fx + ")";
            if (zd_fx.Trim() != "")
            {
                DS_temp = B_Common.GetList("select distinct fkfs from Syjcz_temp", "id>=0  " + sel_cond_td + " and fkfs not in (" + zd_fx + ")");
            }
            else
            {
                DS_temp = B_Common.GetList("select distinct fkfs from Syjcz_temp", "id>=0  " + sel_cond_td + " ");
            }
            string[] arg_fkfs_cy2 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_fkfs(DS_temp, ref  zd_fx, ref  arg_fkfs_cy2, h_0);

            //转入账务的押金
            temp = "id>=0  " + sel_cond_yj + " and fkfs not in ('" + zd_fx + "')";
            if (zd_fx.Trim() != "")
            {
                DS_temp = B_Common.GetList("select distinct fkfs from Syjcz_bak", "id>=0  " + sel_cond_yj + " and fkfs not in (" + zd_fx + ")");
            }
            else
            {
                DS_temp = B_Common.GetList("select distinct fkfs from Syjcz_bak", "id>=0  " + sel_cond_yj + " ");

            }
            string[] arg_fkfs_cy3 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_fkfs(DS_temp, ref  zd_fx, ref  arg_fkfs_cy3, h_0);

            //直接结算的往来款
            if (zd_fx.Trim() != "")
            {
                temp = "czy_temp='" + czy_GUID + "' and xfdr='" + common_file.common_app.fkdr + "' and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + " and fkfs not in('" + zd_fx + "')";
                DS_temp = B_Common.GetList("select distinct fkfs from BS_jzmx_ls ", "czy_temp='" + czy_GUID + "' and xfdr='" + common_file.common_app.fkdr + "' and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + " and fkfs not in(" + zd_fx + ")");
            }
            else
            {
                DS_temp = B_Common.GetList("select distinct fkfs from BS_jzmx_ls ", "czy_temp='" + czy_GUID + "' and xfdr='" + common_file.common_app.fkdr + "' and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + " ");

            }
            string[] arg_fkfs_cy4 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_fkfs(DS_temp, ref  zd_fx, ref  arg_fkfs_cy4, h_0);


            int fkfs_sl = arg_fkfs_cy0.Length + arg_fkfs_cy1.Length + arg_fkfs_cy2.Length + arg_fkfs_cy3.Length + arg_fkfs_cy4.Length;
            string[] arg_fkfs = new string[fkfs_sl];
            int i_0 = 0;
            int j_0 = 0;
            int k_0 = 0;
            i_0 = fkfs_sl;
            fkfs_sl = 0;
            h_0 = 0;
            for (h_0 = 0; h_0 < arg_fkfs_cy0.Length; h_0++)
            {
                arg_fkfs[fkfs_sl + h_0] = arg_fkfs_cy0[h_0];
            }
            fkfs_sl = fkfs_sl + arg_fkfs_cy0.Length;

            h_0 = 0;
            for (h_0 = 0; h_0 < arg_fkfs_cy1.Length; h_0++)
            {
                arg_fkfs[fkfs_sl + h_0] = arg_fkfs_cy1[h_0];
            }
            fkfs_sl = fkfs_sl + arg_fkfs_cy1.Length;

            h_0 = 0;
            for (h_0 = 0; h_0 < arg_fkfs_cy2.Length; h_0++)
            {
                arg_fkfs[fkfs_sl + h_0] = arg_fkfs_cy2[h_0];
            }
            fkfs_sl = fkfs_sl + arg_fkfs_cy2.Length;

            h_0 = 0;
            for (h_0 = 0; h_0 < arg_fkfs_cy3.Length; h_0++)
            {
                arg_fkfs[fkfs_sl + h_0] = arg_fkfs_cy3[h_0];
            }
            fkfs_sl = fkfs_sl + arg_fkfs_cy3.Length;

            h_0 = 0;
            for (h_0 = 0; h_0 < arg_fkfs_cy4.Length; h_0++)
            {
                arg_fkfs[fkfs_sl + h_0] = arg_fkfs_cy4[h_0];
            }
            fkfs_sl = fkfs_sl = arg_fkfs_cy0.Length + arg_fkfs_cy1.Length + arg_fkfs_cy2.Length + arg_fkfs_cy3.Length + arg_fkfs_cy4.Length;
            //以上获取所有的付款方式







            //以下获取收银员



            zd_fx = "";
            h_0 = 0;
            //当前的
            DS_temp = B_Common.GetList("select distinct czy from Syjcz", "id>=0" + sel_cond_yj);
            string[] arg_czy_cy0 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_czy(DS_temp, ref  zd_fx, ref  arg_czy_cy0, h_0);
            //直接退的发生的
            if (zd_fx.Trim() != "")
            {
                DS_temp = B_Common.GetList("select distinct czy from Syjcz_temp", "id>=0" + sel_cond_yj + " and czy not in (" + zd_fx + ")");
            }
            else
            {
                DS_temp = B_Common.GetList("select distinct czy from Syjcz_temp", "id>=0" + sel_cond_yj + " ");
            }
            string[] arg_czy_cy1 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_czy(DS_temp, ref  zd_fx, ref  arg_czy_cy1, h_0);
            //直接退的退订的
            if (zd_fx.Trim() != "")
            {
                DS_temp = B_Common.GetList("select distinct czy from Syjcz_temp", "id>=0" + sel_cond_td + " and czy not in (" + zd_fx + ")");
            }
            else
            {
                DS_temp = B_Common.GetList("select distinct czy from Syjcz_temp", "id>=0" + sel_cond_td + " ");
            }
            string[] arg_czy_cy2 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_czy(DS_temp, ref  zd_fx, ref  arg_czy_cy2, h_0);

            //转入账务的押金
            if (zd_fx.Trim() != "")
            {
                DS_temp = B_Common.GetList("select distinct czy from Syjcz_bak", "id>=0" + sel_cond_yj + " and czy not in (" + zd_fx + ")");
            }
            else
            {
                DS_temp = B_Common.GetList("select distinct czy from Syjcz_bak", "id>=0" + sel_cond_yj + " ");
            }
            string[] arg_czy_cy3 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_czy(DS_temp, ref  zd_fx, ref  arg_czy_cy3, h_0);

            //直接结算的往来款
            if (zd_fx.Trim() != "")
            {
                DS_temp = B_Common.GetList("select distinct czy from BS_jzmx_ls ", "czy_temp='" + czy_GUID + "' and xfdr='" + common_file.common_app.fkdr + "' and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + " and czy not in(" + zd_fx + ")");
            }
            else
            {
                DS_temp = B_Common.GetList("select distinct czy from BS_jzmx_ls ", "czy_temp='" + czy_GUID + "' and xfdr='" + common_file.common_app.fkdr + "' and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + " ");
            }
            string[] arg_czy_cy4 = new string[DS_temp.Tables[0].Rows.Count];
            add_all_czy(DS_temp, ref  zd_fx, ref  arg_czy_cy4, h_0);


            int syy_sl = arg_czy_cy0.Length + arg_czy_cy1.Length + arg_czy_cy2.Length + arg_czy_cy3.Length + arg_czy_cy4.Length;
            string[] arg_syy = new string[syy_sl];
            i_0 = 0;
            j_0 = 0;
            k_0 = 0;
            i_0 = syy_sl;
            syy_sl = 0;
            h_0 = 0;
            for (h_0 = 0; h_0 < arg_czy_cy0.Length; h_0++)
            {
                arg_syy[syy_sl + h_0] = arg_czy_cy0[h_0];
            }
            syy_sl = syy_sl + arg_czy_cy0.Length;

            h_0 = 0;
            for (h_0 = 0; h_0 < arg_czy_cy1.Length; h_0++)
            {
                arg_syy[syy_sl + h_0] = arg_czy_cy1[h_0];
            }
            syy_sl = syy_sl + arg_czy_cy1.Length;

            h_0 = 0;
            for (h_0 = 0; h_0 < arg_czy_cy2.Length; h_0++)
            {
                arg_syy[syy_sl + h_0] = arg_czy_cy2[h_0];
            }
            syy_sl = syy_sl + arg_czy_cy2.Length;

            h_0 = 0;
            for (h_0 = 0; h_0 < arg_czy_cy3.Length; h_0++)
            {
                arg_syy[syy_sl + h_0] = arg_czy_cy3[h_0];
            }
            syy_sl = syy_sl + arg_czy_cy3.Length;

            h_0 = 0;
            for (h_0 = 0; h_0 < arg_czy_cy4.Length; h_0++)
            {
                arg_syy[syy_sl + h_0] = arg_czy_cy4[h_0];
            }
            syy_sl = arg_czy_cy0.Length + arg_czy_cy1.Length + arg_czy_cy2.Length + arg_czy_cy3.Length + arg_czy_cy4.Length;




            //以上获取收银员









            //增加项目
            for (i_0 = 0; i_0 < arg_syy.Length; i_0++)
            {
                for (j_0 = 0; j_0 < arg_fkfs.Length; j_0++)
                {
                    insert_mx(B_Common, yydh, qymc, lsbh, syzd, arg_syy[i_0], "", arg_fkfs[j_0]);
                }
                insert_mx(B_Common, yydh, qymc, lsbh, syzd, arg_syy[i_0], arg_syy[i_0], "合计");
            }


            for (j_0 = 0; j_0 < arg_fkfs.Length; j_0++)
            {
                insert_mx(B_Common, yydh, qymc, lsbh, syzd, "累计", "", arg_fkfs[j_0]);
            }
            insert_mx(B_Common, yydh, qymc, lsbh, syzd, "累计", "总计", "合计");





            //填充预收金额
            //余额,这边的目的不是为了获取余额,而是为了获取明细,余额在下面会去扣除,这边的明细值会与扣除后余额不相等,因为这边只考虑当天的明细值,如果有重做,这边得到的值,可能会更少!
            add_yj_app(DS_temp, B_Common, sel_cond_yj, sql_s, yydh, lsbh, "ysk", "Syjcz", jb_jk_rx);


            //发生额
            add_yj_app(DS_temp, B_Common, sel_cond_yj, sql_s, yydh, lsbh, "ysk_fs", "Syjcz", jb_jk_rx);
            add_yj_app(DS_temp, B_Common, sel_cond_yj, sql_s, yydh, lsbh, "ysk_fs", "Syjcz_temp", jb_jk_rx);
            add_yj_app(DS_temp, B_Common, sel_cond_yj, sql_s, yydh, lsbh, "ysk_fs", "Syjcz_bak", jb_jk_rx);








            //退订发生的,因为时间字段不一样,不能调用同一个过程

            add_yj_app(DS_temp, B_Common, sel_cond_td, sql_s, yydh, lsbh, "t_ysk_qt", "Syjcz_temp", jb_jk_rx);








            //退订发生的

            //填充退押金额-结账退的.

            DS_temp = B_Common.GetList("select czy,fkfs,sum(sjxfje) as sjxfje from BS_jzmx_ls", "czy_temp='" + czy_GUID + "' and id>=0 and xfrb='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt + " group by czy,fkfs");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set t_ysk=t_ysk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and fkfs='" + DS_temp.Tables[0].Rows[i_0]["fkfs"].ToString() + "' and syy='" + DS_temp.Tables[0].Rows[i_0]["czy"].ToString() + "'";
                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }


            DS_temp = B_Common.GetList("select czy,sum(sjxfje) as sjxfje from BS_jzmx_ls", "czy_temp='" + czy_GUID + "' and id>=0  and xfrb='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt + " group by czy");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set t_ysk=t_ysk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and syy='" + DS_temp.Tables[0].Rows[i_0]["czy"].ToString() + "' and fkfs='合计'";
                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }



            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BS_jzmx_ls", "czy_temp='" + czy_GUID + "' and id>=0  and xfrb='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt + " group by fkfs");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set t_ysk=t_ysk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and fkfs='" + DS_temp.Tables[0].Rows[i_0]["fkfs"].ToString() + "' and syy='累计'";
                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }


            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BS_jzmx_ls", "czy_temp='" + czy_GUID + "' and id>=0  and xfrb='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set t_ysk=t_ysk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and fkfs='合计' and syy='累计'";
                        B_Common.ExecuteSql(sql_s);

                        sql_s = "update S_jbzd set t_ysk=t_ysk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "'";
                        B_Common.ExecuteSql(sql_s);

                        sql_s = " insert into BS_jzmx_ls_jb (yydh,qymc,id_app,jzbh,lsbh,lsbh_jb,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,shsc,czy_bc,czzt,tfsj,czsj,syzd,jzzt,fkfs,mxbh) select ";
                        sql_s = sql_s + " yydh,qymc,id_app,jzbh,lsbh,'" + lsbh + "',krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,shsc,czy_bc,czzt,tfsj,czsj,syzd,jzzt,fkfs,mxbh from BS_jzmx_ls where czy_temp='" + czy_GUID + "' and id>=0  and xfrb='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt;

                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }

            //填充退押金额


            //正常前台款项


            DS_temp = B_Common.GetList("select czy,fkfs,sum(sjxfje) as sjxfje from BS_jzmx_ls", "czy_temp='" + czy_GUID + "' and id>=0  and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt + " group by czy,fkfs");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set qtfk=qtfk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and fkfs='" + DS_temp.Tables[0].Rows[i_0]["fkfs"].ToString() + "' and syy='" + DS_temp.Tables[0].Rows[i_0]["czy"].ToString() + "'";
                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }


            DS_temp = B_Common.GetList("select czy,sum(sjxfje) as sjxfje from BS_jzmx_ls", "czy_temp='" + czy_GUID + "' and id>=0   and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt + " group by czy");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set qtfk=qtfk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and syy='" + DS_temp.Tables[0].Rows[i_0]["czy"].ToString() + "' and fkfs='合计'";
                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }



            DS_temp = B_Common.GetList("select fkfs,sum(sjxfje) as sjxfje from BS_jzmx_ls", "czy_temp='" + czy_GUID + "' and id>=0   and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt + " group by fkfs");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set qtfk=qtfk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and fkfs='" + DS_temp.Tables[0].Rows[i_0]["fkfs"].ToString() + "' and syy='累计'";
                        B_Common.ExecuteSql(sql_s);
                    }
                }
            }


            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from BS_jzmx_ls", "czy_temp='" + czy_GUID + "' and id>=0   and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sql_s = "update S_jbmx set qtfk=qtfk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "' and fkfs='合计' and syy='累计'";

                        B_Common.ExecuteSql(sql_s);


                        sql_s = "update S_jbzd set qtfk=qtfk-'" + common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString()), 2, common_file.common_sswl.selectMode_sel).ToString() + "' where yydh='" + yydh + "' and lsbh='" + lsbh + "'";
                        B_Common.ExecuteSql(sql_s);

                        sql_s = " insert into BS_jzmx_ls_jb (yydh,qymc,id_app,jzbh,lsbh,lsbh_jb,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,shsc,czy_bc,czzt,tfsj,czsj,syzd,jzzt,fkfs,mxbh) select ";
                        sql_s = sql_s + " yydh,qymc,id_app,jzbh,lsbh,'" + lsbh + "',krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,shsc,czy_bc,czzt,tfsj,czsj,syzd,jzzt,fkfs,mxbh from BS_jzmx_ls where czy_temp='" + czy_GUID + "' and id>=0   and xfrb!='" + common_file.common_app.dj_ysk + "' " + sel_cond + czzt_cond_qt;

                        B_Common.ExecuteSql(sql_s);

                    }
                }
            }



            //正常前台款项




            //预书款余额与（退预收款和正常前台款项的合计）


            sql_s = "update S_jbmx set ysk=ysk_fs-t_ysk-t_ysk_qt where yydh='" + yydh + "' and lsbh='" + lsbh + "'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "update S_jbzd set ysk=ysk_fs-t_ysk-t_ysk_qt where yydh='" + yydh + "' and lsbh='" + lsbh + "'";
            B_Common.ExecuteSql(sql_s);



            sql_s = "update S_jbmx set qt_yyk=qtfk+t_ysk where yydh='" + yydh + "' and lsbh='" + lsbh + "'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "update S_jbzd set qt_yyk=qtfk+t_ysk where yydh='" + yydh + "' and lsbh='" + lsbh + "'";
            B_Common.ExecuteSql(sql_s);




            sql_s = "update S_jbmx set qtsk_t_ysk=ysk+qtfk+t_ysk where yydh='" + yydh + "' and lsbh='" + lsbh + "'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "update S_jbzd set qtsk_t_ysk=ysk+qtfk+t_ysk where yydh='" + yydh + "' and lsbh='" + lsbh + "'";
            B_Common.ExecuteSql(sql_s);









            string cznr_0 = "";
            string czbz_0 = "";
            string czzy_0 = "";
            DateTime czsj_0 = DateTime.Now;
            if (jb_jk_rx == Szwgl.common_zw.jb_jk_jb)
            {

                cznr_0 = "交班";
                czbz_0 = j_s_bc + "_" + "交班人员：" + czy_jb;
                czzy_0 = "接班人员：" + czy_sb;
                czsj_0 = czsj;
            }
            else
                if (jb_jk_rx == Szwgl.common_zw.jb_jk_jk)
                { cznr_0 = "生成交款明细"; }
            common_file.common_czjl.add_czjl(yydh, qymc, czy, cznr_0, czzy_0, czbz_0, czsj_0);

            if (jb_jk_rx == common_zw.jb_jk_jk)
            {
                string ins_s_0 = "insert into Szwmx_wj(yydh,qymc,lsbh_jk,czsj_jk,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh,jzzt,ddsj,lksj,krly,xydw)";
                ins_s_0 = ins_s_0 + " SELECT yydh,qymc,'" + lsbh + "','" + czsj + "','" + "0" + "','" + "0" + "',id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,'" + "0" + "',czy_bc,'" + "在住散客未结" + "',czsj,syzd,'" + "1" + "',mxbh,krxm,ddsj,lksj,krly,xydw FROM VIEW_zwmx_wj_sk where jzbh='' and xfsj<='"+czsj+"' order by id";
                B_Common.ExecuteSql(ins_s_0);

                ins_s_0 = "insert into Szwmx_wj(yydh,qymc,lsbh_jk,czsj_jk,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh,jzzt,ddsj,lksj,krly,xydw)";
                ins_s_0 = ins_s_0 + " SELECT yydh,qymc,'" + lsbh + "','" + czsj + "','" + "0" + "','" + "0" + "',id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,'" + "0" + "',czy_bc,'" + "在住团队未结" + "',czsj,syzd,'" + "1" + "',mxbh,krxm_tt,ddsj,lksj,krly,xydw FROM VIEW_zwmx_wj_tt where jzbh='' and xfsj<='" + czsj + "'  order by id";
                B_Common.ExecuteSql(ins_s_0);

                ins_s_0 = "insert into Szwmx_wj(yydh,qymc,lsbh_jk,czsj_jk,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh,jzzt,ddsj,lksj,krly,xydw)";
                ins_s_0 = ins_s_0 + " SELECT yydh,qymc,'" + lsbh + "','" + czsj + "','" + "0" + "','" + "0" + "',id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,'" + "0" + "',czy_bc,'" + "挂账未结" + "',czsj,syzd,'" + "1" + "',mxbh,jzzt,ddsj,lksj,krly,xydw FROM VIEW_S_jz_jzORgz where (czzt='" + common_file.common_jzzt.czzt_gz + "' or czzt='" + common_file.common_jzzt.czzt_jzzgz + "') and czsj<='" + czsj + "' order by id";
                B_Common.ExecuteSql(ins_s_0);


                ins_s_0 = "insert into Szwmx_wj(yydh,qymc,lsbh_jk,czsj_jk,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh,jzzt,ddsj,lksj,krly,xydw)";
                ins_s_0 = ins_s_0 + " SELECT yydh,qymc,'" + lsbh + "','" + czsj + "','" + "0" + "','" + "0" + "',id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,'" + "0" + "',czy_bc,'" + "记账未结" + "',czsj,syzd,'" + "1" + "',mxbh,jzzt,ddsj,lksj,krly,xydw FROM VIEW_S_jz_jzORgz where (czzt='" + common_file.common_jzzt.czzt_jz + "' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "') and czsj<='" + czsj + "' order by id";
                B_Common.ExecuteSql(ins_s_0);


                DateTime cssj_1_0 = DateTime.Parse(common_file.common_app.cssj);
                DS_temp = B_Common.GetList("select top 1 * from Ssyxfmx_kc_temp", " ID >=0 order by czsj_jk desc");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["czsj_jk"].ToString() != "")
                    {
                        cssj_1_0 = DateTime.Parse(DS_temp.Tables[0].Rows[0]["czsj_jk"].ToString());
                    }
                }
                ins_s_0 = "insert into Ssyxfmx_kc_temp (yydh,qymc,lsbh_jk,czsj_jk,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,is_visible,mxbh,shbd)";
                ins_s_0 = ins_s_0 + " SELECT yydh,qymc,'" + lsbh + "','" + czsj + "',0,0,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,0,czy_bc,1,mxbh,0 FROM Ssyxfmx where (xfsj>'" + cssj_1_0.ToString() + "' and xfsj<='" + czsj.ToString() + "') and (xfdr<>'" + common_zw.dr_ff + "' and xfdr<>'" + common_zw.dr_ds + "')";
                B_Common.ExecuteSql(ins_s_0);
                ins_s_0 = "insert into Ssyxfmx_kc (yydh,qymc,lsbh_jk,czsj_jk,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,is_visible,mxbh,shbd)";
                ins_s_0 = ins_s_0 + " SELECT yydh,qymc,'" + lsbh + "','" + czsj + "',0,0,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,0,czy_bc,1,mxbh,0 FROM VIEW_syxf_kc_temp where (xfsj>'" + cssj_1_0.ToString() + "' and xfsj<='" + czsj.ToString() + "') and (xfdr<>'" + common_zw.dr_ff + "' and xfdr<>'" + common_zw.dr_ds + "')";
                B_Common.ExecuteSql(ins_s_0);

                 
                DataSet  ds_000=B_Common.GetList(" SELECT id_app FROM VIEW_syxf_kc_temp "," (xfsj>'" + cssj_1_0.ToString() + "' and xfsj<='" + czsj.ToString() + "') and (xfdr<>'" + common_zw.dr_ff + "' and xfdr<>'" + common_zw.dr_ds + "')");
                if(ds_000!=null&&ds_000.Tables[0].Rows.Count>0)
                {
                DbHelperSQLP sp = new DbHelperSQLP();
                for (int ii = 0; ii < ds_000.Tables[0].Rows.Count; ii++)
                {
                   string  id_app_temp_0= ds_000.Tables[0].Rows[ii]["id_app"].ToString();
                   sp.RunProcedure("Update_Ssyxfmx_kc_temp", new SqlParameter[] { new SqlParameter("@id_app",id_app_temp_0) });
                }

                //ins_s_0 = "update Ssyxfmx_kc_temp set shbd=1 where  shbd=0  and   id_app  in(SELECT id_app FROM VIEW_syxf_kc_temp where (xfsj>'" + cssj_1_0.ToString() + "' and xfsj<='" + czsj.ToString() + "') and (xfdr<>'" + common_zw.dr_ff + "' and xfdr<>'" + common_zw.dr_ds + "'))";
                //B_Common.ExecuteSql(ins_s_0);
                common_file.common_czjl.add_czjl(yydh, qymc, czy, "生成库存及未结费用", "", "", czsj_0);
                }
            }

            //退预收款和正常前台款项的合计
            DS_temp.Clear();
            DS_temp.Dispose();
            //DS_temp_0.Clear();
            //DS_temp_0.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
        }

        public string cz_jk_app(string yydh, string qymc, string czy_jb, string czy_sb, string j_s_bc, DateTime czsj, string czy, string bz, string jb_jk_rx, string xxzs, string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Xsyzd", "id>=0 order by id");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {

                for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {

                    add_jb_app( yydh,  qymc, DS_temp.Tables[0].Rows[j_0]["syzd"].ToString(), czy_jb,  czy_sb,  j_s_bc,  czsj,  czy,  bz,  jb_jk_rx,  xxzs,czy_GUID);

                }


            }
            DS_temp.Clear();
            DS_temp.Dispose();
            s = common_file.common_app.get_suc;
            return s;


        }


    }
}
