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
namespace Hotel_app.Server.BBfx
{
    public class B_g_j_fx
    {


        public void clear_cs(ref string jzzt, ref float zfh, ref float ds, ref float qt, ref float zyye, ref float zzz, ref float zgz_zjz, ref float zsz, ref float wj)
        {
            jzzt = "";
            zfh = 0; ds = 0; qt = 0; zyye = 0; zzz = 0;
            zgz_zjz = 0; zsz = 0; wj = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="cssj"></param>
        /// <param name="jssj"></param>
        /// <param name="sel_cond"></param>
        /// <param name="type"></param>挂账gz或记账jz
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        /// 

        public void insert_s(BLL.Common B_Common, string yydh, string qymc, string jzzt, string type, float zfh, float ds, float qt, float zyye, float zzzz, float zgz_zjz, float zsz, float wj, string czy_temp, string cssj, string jssj)
        {
            string sql_s = "insert into BS_g_j_fx( yydh, qymc, jzzt, type, zfh, ds, qt, zyye, zzz, zgz_zjz, zsz, wj, czy_temp, cssj, jssj)";
            sql_s = sql_s + " values ('" + yydh + "', '" + qymc + "', '" + jzzt + "', '" + type + "', '" + zfh + "', '" + ds + "', '" + qt + "', '" + zyye + "', '" + zzzz + "', '" + zgz_zjz + "', '" + zsz + "', '" + wj + "', '" + czy_temp + "', '" + cssj + "', '" + jssj + "')";
            B_Common.ExecuteSql(sql_s);
        }

        public void update_s(BLL.Common B_Common, string update_nr, string yydh, string jzzt, string czy, string cssj, string jssj)
        {
            //B_Common.ExecuteSql("update BS_g_j_fx set zyye=zyye+'" + zyye.ToString() + "' where jzzt='" + jzzt + "' and yydh='" + yydh + "' and czy_temp='" + czy + "' and cssj='" + cssj + "' and jssj='" + jssj + "'");
            B_Common.ExecuteSql("update BS_g_j_fx " + update_nr + " where jzzt='" + jzzt + "' and yydh='" + yydh + "' and czy_temp='" + czy + "' and cssj='" + cssj + "' and jssj='" + jssj + "'");

        }



        public void add_fs(BLL.Common B_Common, DataSet DS_temp, string yydh, string qymc, string czy, string cssj, string jssj, string jzzt, ref float zfh_z, ref float ds_z, ref float qt_z, ref float zyye_z)
        {
            float zfh = 0; float ds = 0; float qt = 0; float zyye = 0;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int k_0 = 0; k_0 < DS_temp.Tables[0].Rows.Count; k_0++)
                {
                    if (DS_temp.Tables[0].Rows[k_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ff)
                    {
                        if (DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                        {
                            zfh = zfh + float.Parse(DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString());
                            //zyye = zyye + zfh;
                        }
                    }
                    else
                        if (DS_temp.Tables[0].Rows[k_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ds)
                        {
                            if (DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                            {
                                ds = ds + float.Parse(DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString());
                                //zyye = zyye + ds;
                            }
                        }
                        else
                        {
                            if (DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                            {
                                qt = qt + float.Parse(DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString());
                                //zyye = zyye + qt;
                            }
                        }
                }
                zyye = ds + zfh + qt;
                zfh_z = zfh_z + zfh; ds_z = ds_z + ds; qt_z = qt_z + qt; zyye_z = zyye_z + zyye;
                update_s(B_Common, " set zyye=zyye+'" + zyye + "',zfh=zfh+'" + zfh + "',ds=ds+'" + ds + "',qt=qt+'" + qt + "' ", yydh, jzzt, czy, cssj, jssj);
            }

        }

        /// <summary>
        /// 挂记账的分析
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="cssj"></param>
        /// <param name="jssj"></param>
        /// <param name="sel_cond"></param>绑定次条件,例:如果要具体查询某个挂账单位就要在这里绑定" and jzzt like '%'陈志永'%'"
        /// <param name="type"></param>//common_bb里的两个值gz_type = "gz";jz_type = "jz";
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string get_g_j_fx_app(string yydh, string qymc, string cssj, string jssj, string sel_cond, string type, string czy, string czsj, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            string czzt_cond = "";
            string czzt_cond_bak = "";
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            if (type == BBfx.common_bb.gz_type)
            {
                czzt_cond = " and (czzt like '%" + common_file_server.common_jzzt.czzt_gz_xg + "%'  and czzt!='" + common_file.common_jzzt.czzt_gzzjz + "')";
                czzt_cond_bak = " and (czzt='" + common_file_server.common_jzzt.czzt_gzzzz + "')";
            }
            else
                if (type == BBfx.common_bb.jz_type)
                {
                    czzt_cond = " and (czzt like '%" + common_file_server.common_jzzt.czzt_jz_xg + "%'  and czzt!='" + common_file.common_jzzt.czzt_jzzgz + "')";
                    czzt_cond_bak = " and (czzt='" + common_file_server.common_jzzt.czzt_jzzzz + "')";
                }
            if (czzt_cond != "")
            {
                string sql_s = "delete from BS_g_j_fx where yydh='" + yydh + "' and czy_temp='" + czy + "'";
                B_Common.ExecuteSql(sql_s);

                string sel_cond_fs = " and yydh='" + yydh + "' and czy_temp='" + czy + "' and (tfsj between '" + cssj + "' and '" + jssj + "')";
                if (sel_cond != "")
                { sel_cond_fs = sel_cond_fs + sel_cond; }


                string sel_cond_fs_b_c = " and yydh='" + yydh + "' and czy_temp='" + czy + "'  and ((tfsj between '" + cssj + "' and '" + jssj + "') and ((convert(varchar(10),xfsj,120) >convert(varchar(10),tfsj,120))) and (xfzy='" + Szwgl.common_zw.zwcl_bz + "' or xfzy='" + Szwgl.common_zw.zwcl_congz + "'))";
                if (sel_cond != "")
                { sel_cond_fs_b_c = sel_cond_fs_b_c + sel_cond; }


                string sel_cond_cz = " and yydh='" + yydh + "'  and czy_temp='" + czy + "' and (czsj between '" + cssj + "' and '" + jssj + "')";
                if (sel_cond != "")
                { sel_cond_cz = sel_cond_cz + sel_cond; }

                string xfsj_cod = " and yydh='" + yydh + "'  and czy_temp='" + czy + "' and ((xfsj between '" + cssj + "' and '" + jssj + "') and ((convert(varchar(10),xfsj,120) >convert(varchar(10),tfsj,120))) and (xfzy='" + Szwgl.common_zw.zwcl_bz + "' or xfzy='" + Szwgl.common_zw.zwcl_congz + "'))";
                if (sel_cond != "")
                { xfsj_cod = xfsj_cod + sel_cond; }


                string jzzt = "";
                float zfh = 0; float ds = 0; float qt = 0; float zyye = 0; float zzz = 0;
                float zgz_zjz = 0; float zsz = 0; float wj = 0;

                float zfh_z = 0; float ds_z = 0; float qt_z = 0; float zyye_z = 0; float zzz_z = 0;
                float zgz_zjz_z = 0; float zsz_z = 0; float wj_z = 0;



                if (type == BBfx.common_bb.gz_type)
                {
                    czzt_cond = " and (czzt like '%" + common_file_server.common_jzzt.czzt_gz_xg + "%'  or czzt='" + common_file.common_jzzt.czzt_gzzzz + "')" + common_file_server.common_jzzt.czzt_like_sz;

                }
                else
                    if (type == BBfx.common_bb.jz_type)
                    {
                        czzt_cond = " and (czzt like '%" + common_file_server.common_jzzt.czzt_jz_xg + "%'  or  czzt='" + common_file.common_jzzt.czzt_jzzzz + "')" + common_file_server.common_jzzt.czzt_like_sz;

                    }
                BBfx.B_syxfmx_ls_add B_syxfmx_ls_add_new = new B_syxfmx_ls_add();
                B_syxfmx_ls_add_new.Sjzmx_or_bak_ls_add_app(yydh, qymc, czy, cssj, jssj, czzt_cond, xxzs);








                int i_0 = 0;
                DataSet DS_temp = B_Common.GetList("select distinct jzzt from BS_jzmx_ls", "yydh='" + yydh + "' and id>=0" + czzt_cond);
                DataSet DS_temp_0 = B_Common.GetList("select distinct jzzt from BS_jzmx_bak_ls", "yydh='" + yydh + "' and id>=0" + czzt_cond);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {
                        clear_cs(ref  jzzt, ref  zfh, ref  ds, ref  qt, ref  zyye, ref  zzz, ref  zgz_zjz, ref  zsz, ref  wj);
                        jzzt = DS_temp.Tables[0].Rows[i_0]["jzzt"].ToString();
                        insert_s(B_Common, yydh, qymc, jzzt, type, zfh, ds, qt, zyye, zzz, zgz_zjz, zsz, wj, czy, cssj, jssj);
                    }
                }

                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                    {
                        clear_cs(ref  jzzt, ref  zfh, ref  ds, ref  qt, ref  zyye, ref  zzz, ref  zgz_zjz, ref  zsz, ref  wj);
                        jzzt = DS_temp_0.Tables[0].Rows[i_0]["jzzt"].ToString();
                        DS_temp = B_Common.GetList("select id from BS_g_j_fx", "jzzt='" + jzzt + "' and yydh='" + yydh + "' and czy_temp='" + czy + "' and cssj='" + cssj + "' and jssj='" + jssj + "'");

                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            insert_s(B_Common, yydh, qymc, jzzt, type, zfh, ds, qt, zyye, zzz, zgz_zjz, zsz, wj, czy, cssj, jssj);
                        }
                    }
                }







                //查询所有已经有的JZZT
                DataSet DS_temp_jzzt = B_Common.GetList("select distinct jzzt from BS_g_j_fx", " yydh='" + yydh + "' and czy_temp='" + czy + "' and cssj='" + cssj + "' and jssj='" + jssj + "'");
                if (DS_temp_jzzt != null && DS_temp_jzzt.Tables[0].Rows.Count > 0)
                {
                    for (int j_0 = 0; j_0 < DS_temp_jzzt.Tables[0].Rows.Count; j_0++)
                    {
                        //发生额

                        //正常发生
                        if (type == BBfx.common_bb.gz_type)
                        {
                            czzt_cond = " and (czzt like '%" + common_file_server.common_jzzt.czzt_gz_xg + "%'  and czzt!='" + common_file.common_jzzt.czzt_jzzgz + "') and (id_app not in (select id_app from VIEW_S_jzmx_bak_jzzgz where jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "'))";
                            czzt_cond_bak = " and (czzt='" + common_file_server.common_jzzt.czzt_gzzzz + "' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "')";
                        }
                        else
                            if (type == BBfx.common_bb.jz_type)
                            {
                                czzt_cond = " and (czzt like '%" + common_file_server.common_jzzt.czzt_jz_xg + "%'   and czzt!='" + common_file.common_jzzt.czzt_gzzjz + "') and (id_app not in (select id_app from VIEW_S_jzmx_bak_gzzjz where jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "'))";
                                czzt_cond_bak = " and (czzt='" + common_file_server.common_jzzt.czzt_jzzzz + "' or czzt='" + common_file.common_jzzt.czzt_jzzgz + "')";
                            }
                        DS_temp = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from BS_jzmx_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_fs + czzt_cond + "group by xfdr order by xfdr");
                        add_fs(B_Common, DS_temp, yydh, qymc, czy, cssj, jssj, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), ref  zfh_z, ref  ds_z, ref  qt_z, ref  zyye_z);
                        DS_temp_0 = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje From BS_jzmx_bak_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and   xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_fs + czzt_cond_bak + "group by xfdr order by xfdr");
                        add_fs(B_Common, DS_temp_0, yydh, qymc, czy, cssj, jssj, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), ref  zfh_z, ref  ds_z, ref  qt_z, ref  zyye_z);





                        //只有把这一步加上才不会对退房后的冲补账多调整
                        DS_temp = B_Common.GetList("select xfdr,-sum(sjxfje) as sjxfje from BS_jzmx_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_fs_b_c + czzt_cond + "group by xfdr order by xfdr");
                        add_fs(B_Common, DS_temp, yydh, qymc, czy, cssj, jssj, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), ref  zfh_z, ref  ds_z, ref  qt_z, ref  zyye_z);
                        DS_temp_0 = B_Common.GetList("select xfdr,-sum(sjxfje) as sjxfje From BS_jzmx_bak_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and   xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_fs_b_c + czzt_cond_bak + "group by xfdr order by xfdr");
                        add_fs(B_Common, DS_temp_0, yydh, qymc, czy, cssj, jssj, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), ref  zfh_z, ref  ds_z, ref  qt_z, ref  zyye_z);











                        //记转挂或挂转记而发生

                        if (type == BBfx.common_bb.gz_type)
                        {
                            czzt_cond = " and (czzt='" + common_file.common_jzzt.czzt_jzzgz + "')";
                            czzt_cond_bak = " and (czzt='" + common_file.common_jzzt.czzt_jzzgz + "')";
                        }
                        else
                            if (type == BBfx.common_bb.jz_type)
                            {
                                czzt_cond = " and (czzt='" + common_file.common_jzzt.czzt_gzzjz + "')";
                                czzt_cond_bak = " and (czzt='" + common_file.common_jzzt.czzt_gzzjz + "')";
                            }
                        DS_temp = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from BS_jzmx_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_cz + czzt_cond + "group by xfdr order by xfdr");
                        add_fs(B_Common, DS_temp, yydh, qymc, czy, cssj, jssj, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), ref  zfh_z, ref  ds_z, ref  qt_z, ref  zyye_z);
                        DS_temp_0 = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje From BS_jzmx_bak_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and   xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_cz + czzt_cond_bak + "group by xfdr order by xfdr");
                        add_fs(B_Common, DS_temp_0, yydh, qymc, czy, cssj, jssj, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), ref  zfh_z, ref  ds_z, ref  qt_z, ref  zyye_z);








                        ////退房后的冲、补账
                        if (type == BBfx.common_bb.gz_type)
                        {
                            czzt_cond = " and (czzt = '" + common_file.common_jzzt.czzt_gzzjz + "' or czzt = '" + common_file.common_jzzt.czzt_gzfj + "' or czzt = '" + common_file.common_jzzt.czzt_gzzsz + "' or czzt = '" + common_file.common_jzzt.czzt_gz + "')";
                            czzt_cond_bak = " and (czzt = '" + common_file.common_jzzt.czzt_gzzzz + "') ";
                        }
                        else
                            if (type == BBfx.common_bb.jz_type)
                            {
                                czzt_cond = " and (czzt = '" + common_file.common_jzzt.czzt_jzzgz + "' or czzt = '" + common_file.common_jzzt.czzt_jzfj + "' or czzt = '" + common_file.common_jzzt.czzt_jzzsz + "' or czzt = '" + common_file.common_jzzt.czzt_jz + "') ";
                                czzt_cond_bak = "  and (czzt = '" + common_file.common_jzzt.czzt_jzzzz + "') ";
                            }
                        DS_temp = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from BS_jzmx_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and  xfdr<>'" + common_file.common_app.fkdr + "'" + xfsj_cod + czzt_cond + "group by xfdr order by xfdr");
                        add_fs(B_Common, DS_temp, yydh, qymc, czy, cssj, jssj, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), ref  zfh_z, ref  ds_z, ref  qt_z, ref  zyye_z);
                        DS_temp_0 = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje From BS_jzmx_bak_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and   xfdr<>'" + common_file.common_app.fkdr + "'" + xfsj_cod + czzt_cond_bak + "group by xfdr order by xfdr");
                        add_fs(B_Common, DS_temp_0, yydh, qymc, czy, cssj, jssj, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), ref  zfh_z, ref  ds_z, ref  qt_z, ref  zyye_z);




                        //转在住
                        if (type == BBfx.common_bb.gz_type)
                        {
                            czzt_cond = " ";
                            czzt_cond_bak = "and (czzt='" + common_file.common_jzzt.czzt_gzzzz + "')";
                        }
                        else
                            if (type == BBfx.common_bb.jz_type)
                            {
                                czzt_cond = " ";
                                czzt_cond_bak = "and (czzt='" + common_file.common_jzzt.czzt_jzzzz + "')";
                            }

                        DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje From BS_jzmx_bak_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and   xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_cz + czzt_cond_bak);
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                            {
                                zzz_z = zzz_z + float.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString());
                                update_s(B_Common, " set zzz=zzz+'" + DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() + "' ", yydh, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), czy, cssj, jssj);
                            }
                        }

                        //转记账或转挂账
                        if (type == BBfx.common_bb.gz_type)
                        {
                            czzt_cond = "and (czzt='" + common_file.common_jzzt.czzt_gzzjz + "')";
                            czzt_cond_bak = "and (czzt='" + common_file.common_jzzt.czzt_gzzjz + "')";
                        }
                        else
                            if (type == BBfx.common_bb.jz_type)
                            {
                                czzt_cond = "and (czzt='" + common_file.common_jzzt.czzt_jzzgz + "')";
                                czzt_cond_bak = "and (czzt='" + common_file.common_jzzt.czzt_jzzgz + "')";
                            }


                        DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje From BS_jzmx_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and   xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_cz + czzt_cond);
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                            {
                                zgz_zjz_z = zgz_zjz_z + float.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                                update_s(B_Common, " set zgz_zjz=zgz_zjz+'" + DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() + "' ", yydh, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), czy, cssj, jssj);
                            }
                        }


                        DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje From BS_jzmx_bak_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and   xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_cz + czzt_cond_bak);
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                            {
                                zgz_zjz_z = zgz_zjz_z + float.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString());
                                update_s(B_Common, " set zgz_zjz=zgz_zjz+'" + DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() + "' ", yydh, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), czy, cssj, jssj);
                            }
                        }


                        //转结账
                        if (type == BBfx.common_bb.gz_type)
                        {
                            czzt_cond = "and (czzt='" + common_file.common_jzzt.czzt_gzzsz + "' or czzt='" + common_file.common_jzzt.czzt_gzfj + "')";
                            czzt_cond_bak = "";
                        }
                        else
                            if (type == BBfx.common_bb.jz_type)
                            {
                                czzt_cond = "and (czzt='" + common_file.common_jzzt.czzt_jzzsz + "' or czzt='" + common_file.common_jzzt.czzt_jzfj + "')";
                                czzt_cond_bak = "";
                            }


                        DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje From BS_jzmx_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and   xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_cz + czzt_cond);
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                            {
                                zsz_z = zsz_z + float.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                                update_s(B_Common, " set zsz=zsz+'" + DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() + "' ", yydh, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), czy, cssj, jssj);
                            }
                        }






                        //未结
                        if (type == BBfx.common_bb.gz_type)
                        {
                            czzt_cond = "and (czzt='" + common_file.common_jzzt.czzt_gz + "' or czzt='" + common_file.common_jzzt.czzt_jzzgz + "')";
                            czzt_cond_bak = "";
                        }
                        else
                            if (type == BBfx.common_bb.jz_type)
                            {
                                czzt_cond = "and (czzt='" + common_file.common_jzzt.czzt_jz + "' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "')";
                                czzt_cond_bak = "";
                            }


                        DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje From BS_jzmx_ls", "jzzt='" + DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString() + "' and   xfdr<>'" + common_file.common_app.fkdr + "'" + sel_cond_cz + czzt_cond);
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                            {
                                wj_z = wj_z + float.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                                update_s(B_Common, " set wj=wj+'" + DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() + "' ", yydh, DS_temp_jzzt.Tables[0].Rows[j_0]["jzzt"].ToString(), czy, cssj, jssj);
                            }
                        }





                    }


                    string id = "";
                    DS_temp = B_Common.GetList("select max(id) as id from BS_g_j_fx", " yydh='" + yydh + "' and czy_temp='" + czy + "' and cssj='" + cssj + "' and jssj='" + jssj + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        id = DS_temp.Tables[0].Rows[0]["id"].ToString();
                    }
                    sql_s = "insert into BS_g_j_fx( yydh, qymc, jzzt, type, zfh, ds, qt, zyye, zzz, zgz_zjz, zsz, wj, czy_temp, cssj, jssj)";
                    sql_s = sql_s + "select  yydh, qymc, jzzt, type, zfh, ds, qt, zyye, zzz, zgz_zjz, zsz, wj, czy_temp, cssj, jssj from BS_g_j_fx where  yydh='" + yydh + "' and czy_temp='" + czy + "' and cssj='" + cssj + "' and jssj='" + jssj + "' order by zyye desc";
                    B_Common.ExecuteSql(sql_s);
                    sql_s = "delete from BS_g_j_fx where  yydh='" + yydh + "' and czy_temp='" + czy + "' and cssj='" + cssj + "' and jssj='" + jssj + "' and id<='" + id + "'";
                    B_Common.ExecuteSql(sql_s);
                    sql_s = "update BS_g_j_fx set jzzt='" + "其他" + "' where  yydh='" + yydh + "' and czy_temp='" + czy + "' and cssj='" + cssj + "' and jssj='" + jssj + "' and jzzt='" + "" + "'";
                    B_Common.ExecuteSql(sql_s);
                    insert_s(B_Common, yydh, qymc, "合计", type, zfh_z, ds_z, qt_z, zyye_z, zzz_z, zgz_zjz_z, zsz_z, wj_z, czy, cssj, jssj);


                    //sql_s = "delete from  BS_g_j_fx  where  yydh='" + yydh + "' and czy_temp='" + czy + "' and (zfh=0 and ds=0 and qt=0 and zyye=0 and zzz=0 and zgz_zjz=0 and zsz=0 and wj=0)";
                    //B_Common.ExecuteSql(sql_s);



                }


                DS_temp.Clear();
                DS_temp_0.Clear();
                DS_temp_jzzt.Clear();
                DS_temp.Dispose();
                DS_temp_0.Dispose();
                DS_temp_jzzt.Dispose();
            }
            get_result = common_file.common_app.get_suc;
            return get_result;
        }





        //新增2012-05-21(By wu)

        /// <summary>
        /// 记、挂明细分析数据的获取
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="cssj"></param>
        /// <param name="jssj"></param>
        /// <param name="sel_cond"></param>
        /// <param name="type">common_bb里面获取</param>
        /// <param name="jzzt">挂账单位或者记账主体</param>
        /// <param name="czy_temp"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns>生成的数据，放在BB_g_j_mxfx_temp表中</returns>
        public string get_g_j_mxfxData(string yydh, string qymc, string cssj, string jssj, string other_cond, string type, string jzzt, string czy_temp, string czsj, string xxzs)
        {
            string result = common_file.common_app.get_failure;
            if (GetDataFromSjzmxAndSjzmx_bak(yydh, qymc, cssj, jssj, other_cond, type, jzzt, czy_temp, czsj, xxzs) == common_file.common_app.get_suc)
            {
                result = common_file.common_app.get_suc;
            }
            return result;

        }
        private string GetDataFromSjzmxAndSjzmx_bak(string yydh, string qymc, string cssj, string jssj, string other_cond, string type, string jzzt, string czy_temp, string czsj, string xxzs)
        {
            string result = common_file.common_app.get_failure;
            BLL.Common B_common = new Hotel_app.BLL.Common();

            B_common.ExecuteSql("  delete  from   BB_g_j_mxfx_ls  where  id>=0  and  yydh='" + yydh + "'  and  czy_temp='" + czy_temp + "'");
            B_common.ExecuteSql("  delete  from  BB_g_j_mxfx_hz_temp where  id>=0  and yydh='" + yydh + "' and czy_temp='" + czy_temp + "'");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string sel_cond = " id>=0  and   yydh='" + yydh + "'  and   tfsj>='" + cssj + "'  and  tfsj<='" + jssj + "'   and    xfdr!='" + common_file.common_app.fkdr + "'  ";
            if (type == common_bb.gz_type)
            {
                if (jzzt.Trim() != "")
                {
                    sel_cond = sel_cond + "  and  jzzt  like '%" + jzzt + "%'  ";
                }
                sel_cond += other_cond;
                string sel_cond_sjzmx_select = sel_cond + "   and  czzt like '%" + common_file_server.common_jzzt.czzt_gz_xg + "%'   and   czzt!='" + common_file.common_jzzt.czzt_gzzjz + "'  ";
                sb = new System.Text.StringBuilder();
                sb.Append(" insert into  BB_g_j_mxfx_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,tfsj,czsj,syzd,xyh,jzzt,fkfs,mxbh,czy_temp)");
                sb.Append(" select  yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,tfsj,czsj,syzd,xyh,jzzt,fkfs,mxbh,'" + czy_temp + "' from Sjzmx");
                sb.Append(" where   " + sel_cond_sjzmx_select);
                B_common.ExecuteSql(sb.ToString());


                string sel_cond_sjzmx_bak_select = sel_cond + "  and czzt='" + common_file.common_jzzt.czzt_gzzzz + "'";
                sb = new System.Text.StringBuilder();
                sb.Append(" insert into  BB_g_j_mxfx_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,tfsj,czsj,syzd,xyh,jzzt,fkfs,mxbh,czy_temp)");
                sb.Append("  select  yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,tfsj,czsj,syzd,xyh,jzzt,fkfs,mxbh,'" + czy_temp + "' from Sjzmx_bak");
                sb.Append("  where  " + sel_cond_sjzmx_bak_select);
                B_common.ExecuteSql(sb.ToString());


                //以下生成汇总数据
                DataSet ds_temp_0 = B_common.GetList("  select   *  from  BB_g_j_mxfx_ls ", "id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   czy_temp='" + czy_temp + "'");
                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                {
                    //查询出所有的jzzt
                    DataSet ds_temp_1 = B_common.GetList(" select distinct  xyh,jzzt  from BB_g_j_mxfx_ls", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and czy_temp='" + czy_temp + "'");
                    if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_temp_1.Tables[0].Rows.Count; i++)
                        {
                            string jzzt_temp = ds_temp_1.Tables[0].Rows[i]["jzzt"].ToString();
                            string xyh_temp = ds_temp_1.Tables[0].Rows[i]["xyh"].ToString();
                            sb = new System.Text.StringBuilder();
                            sb.Append("  insert into  BB_g_j_mxfx_hz_temp(yydh,qymc,jzzt,xyh,xfdr,xfxm,sjxfje,czy_temp)");
                            sb.Append(" select   '" + yydh + "','" + qymc + "','" + jzzt_temp + "','" + xyh_temp + "',xfdr,xfxm,sum(sjxfje),'" + czy_temp + "' from BB_g_j_mxfx_ls ");
                            sb.Append("  where   jzzt='" + jzzt_temp + "' and xyh='" + xyh_temp + "'  and  czy_temp='" + czy_temp + "'    group by xfxm,xfdr,qymc,yydh,jzzt,xyh   order by jzzt,xyh ");
                            B_common.ExecuteSql(sb.ToString());

                            //增加合计行：
                            sb = new System.Text.StringBuilder();
                            sb.Append(" insert into BB_g_j_mxfx_hz_temp(yydh,qymc,jzzt,xyh,xfdr,xfxm,sjxfje,czy_temp)");
                            sb.Append("  select '" + yydh + "','" + qymc + "', '合计','','','',sum(sjxfje),'" + czy_temp + "' from  BB_g_j_mxfx_ls ");
                            sb.Append("  where  jzzt='" + jzzt_temp + "'  and xyh='" + xyh_temp + "'  and czy_temp='" + czy_temp + "'");
                            B_common.ExecuteSql(sb.ToString());
                        }

                    }
                }
            }
            if (type == common_bb.jz_type)
            {
                if (jzzt.Trim() != "")
                {
                    sel_cond = sel_cond + "  and  jzzt  like '%" + jzzt + "%'  ";
                }
                sel_cond += other_cond;
                string sel_cond_sjzmx_select = sel_cond + "   and  czzt like '%" + common_file_server.common_jzzt.czzt_jz_xg + "%'   and   czzt!='" + common_file.common_jzzt.czzt_jzzgz + "'  ";
                sb = new System.Text.StringBuilder();
                sb.Append(" insert into  BB_g_j_mxfx_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,tfsj,czsj,syzd,xyh,jzzt,fkfs,mxbh,czy_temp)");
                sb.Append(" select  yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,tfsj,czsj,syzd,xyh,jzzt,fkfs,mxbh,'" + czy_temp + "' from Sjzmx");
                sb.Append(" where   " + sel_cond_sjzmx_select);
                B_common.ExecuteSql(sb.ToString());


                string sel_cond_sjzmx_bak_select = sel_cond + "  and czzt='" + common_file.common_jzzt.czzt_jzzzz + "'";
                sb = new System.Text.StringBuilder();
                sb.Append(" insert into  BB_g_j_mxfx_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,tfsj,czsj,syzd,xyh,jzzt,fkfs,mxbh,czy_temp)");
                sb.Append("  select  yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,tfsj,czsj,syzd,xyh,jzzt,fkfs,mxbh,'" + czy_temp + "' from Sjzmx_bak");
                sb.Append("  where  " + sel_cond_sjzmx_bak_select);
                B_common.ExecuteSql(sb.ToString());


                //以下生成汇总数据
                DataSet ds_temp_0 = B_common.GetList("  select   *  from  BB_g_j_mxfx_ls ", "id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   czy_temp='" + czy_temp + "'");
                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                {
                    //查询出所有的jzzt(这里是记账客人)
                    DataSet ds_temp_1 = B_common.GetList(" select distinct  xyh,jzzt  from BB_g_j_mxfx_ls", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and czy_temp='" + czy_temp + "'");
                    if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_temp_1.Tables[0].Rows.Count; i++)
                        {
                            string jzzt_temp = ds_temp_1.Tables[0].Rows[i]["jzzt"].ToString();
                            //string xyh_temp = ds_temp_1.Tables[0].Rows[i]["xyh"].ToString();
                            sb = new System.Text.StringBuilder();
                            sb.Append("  insert into  BB_g_j_mxfx_hz_temp(yydh,qymc,jzzt,xyh,xfdr,xfxm,sjxfje,czy_temp)");
                            sb.Append(" select   '" + yydh + "','" + qymc + "','" + jzzt_temp + "','',xfdr,xfxm,sum(sjxfje),'" + czy_temp + "' from BB_g_j_mxfx_ls ");
                            sb.Append("  where   jzzt='" + jzzt_temp + "' and   czy_temp='" + czy_temp + "'    group by xfxm,xfdr,qymc,yydh,jzzt  order by jzzt ");
                            B_common.ExecuteSql(sb.ToString());

                            //增加合计行：
                            sb = new System.Text.StringBuilder();
                            sb.Append(" insert into BB_g_j_mxfx_hz_temp(yydh,qymc,jzzt,xyh,xfdr,xfxm,sjxfje,czy_temp)");
                            sb.Append("  select '" + yydh + "','" + qymc + "', '合计','','','',sum(sjxfje),'" + czy_temp + "' from  BB_g_j_mxfx_ls ");
                            sb.Append("  where  jzzt='" + jzzt_temp + "'   and czy_temp='" + czy_temp + "'");
                            B_common.ExecuteSql(sb.ToString());
                        }
                    }
                }
            }
            return result = common_file.common_app.get_suc;
        }


        //以下是统计记、挂账余额
        public string get_g_j_ye(string yydh, string qymc, string type, string czy_temp, string ls_cond, string czsj, string xxzs)
        {
            string result = common_file.common_app.get_failure;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            string jzzt_temp = "";
            string xydw_temp = "";
            string table_name = "";
            decimal ff_total_temp = 0;
            decimal ds_total_temp = 0;
            decimal qt_total_temp = 0;
            decimal ye_total_temp = 0;
            DataSet ds_jzzt = null;

            clearTable("BBfx_s_g_j_ye_ls", czy_temp);

            if (type == "jz")
            {
                ds_jzzt = B_common.GetList(" SELECT distinct jzzt from Sjzzd ", "  id>=0  and yydh='" + yydh + "'  and czzt='" + common_file.common_jzzt.czzt_jz + "' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "'  ");
                table_name = "VIEW_S_jz_ye";

            }
            if (type == "gz")
            {
                ds_jzzt = B_common.GetList(" SELECT distinct jzzt from Sjzzd ", "  id>=0  and yydh='" + yydh + "'  and czzt='" + common_file.common_jzzt.czzt_gz + "' or czzt='" + common_file.common_jzzt.czzt_jzzgz + "'  ");
                table_name = "VIEW_S_gz_ye";
            }
            //B_common.ExecuteSql(" delete from  BBfx_s_g_j_ye_ls  where czy_temp='" + czy_temp + "'");

            if (ds_jzzt != null && ds_jzzt.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds_jzzt.Tables[0].Rows.Count; i++)
                {
                    jzzt_temp = ds_jzzt.Tables[0].Rows[i]["jzzt"].ToString();
                    xydw_temp = "";
                    ff_total_temp = 0;
                    ds_total_temp = 0;
                    qt_total_temp = 0;
                    ye_total_temp = 0;

                    string sql = "";
                    sql = " SELECT SUM(sjxfje) AS 房费 FROM " + table_name + " WHERE jzzt = '" + jzzt_temp + "' AND xfdr = '" + Szwgl.common_zw.dr_ff + "'   ";
                    object ff_ls = DbHelperSQL.GetSingle(sql);
                    if (ff_ls != null && ff_ls.ToString() != "")
                    {
                        ff_total_temp = decimal.Parse(ff_ls.ToString());
                    }
                    sql = " SELECT SUM(sjxfje) AS 代收 FROM " + table_name + " WHERE jzzt = '" + jzzt_temp + "' AND xfdr = '" + Szwgl.common_zw.dr_ds + "'  ";
                    object ds_ls = DbHelperSQL.GetSingle(sql);
                    if (ds_ls != null && ds_ls.ToString() != "")
                    {
                        ds_total_temp = decimal.Parse(ds_ls.ToString());
                    }
                    sql = " SELECT SUM(sjxfje) AS 其它 FROM " + table_name + " WHERE jzzt = '" + jzzt_temp + "'   AND xfdr != '" + Szwgl.common_zw.dr_ff + "'   AND xfdr != '" + Szwgl.common_zw.dr_ds + "' ";
                    object qt_total_ls = DbHelperSQL.GetSingle(sql);
                    if (qt_total_ls != null && qt_total_ls.ToString() != "")
                    {
                        qt_total_temp = decimal.Parse(qt_total_ls.ToString());
                    }
                    ye_total_temp = ff_total_temp + ds_total_temp + qt_total_temp;
                    sql = " insert into BBfx_s_g_j_ye_ls(yydh,qymc,jzzt,xydw,ff_total,ds_total,qt_total,ye_total,czy_temp)  values('" + yydh + "','" + qymc + "','" + jzzt_temp + "','" + xydw_temp + "'," + ff_total_temp + "," + ds_total_temp + "," + qt_total_temp + "," + ye_total_temp + ",'" + czy_temp + "')";
                    B_common.ExecuteSql(sql);
                }
            }
            result = common_file.common_app.get_suc;
            return result;
        }

        private void clearTable(string p, string czy_temp)
        {
            if (p.Trim() != "" && czy_temp.Trim() != "")
            {
                string sql = " delete from  " + p + "  where  czy_temp='" + czy_temp + "'  ";
                DbHelperSQL.ExecuteSql(sql);
            }
        }
    }
}
