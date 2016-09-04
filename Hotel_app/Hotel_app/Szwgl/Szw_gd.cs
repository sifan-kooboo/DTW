using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szw_gd : Form
    {
        public Szw_gd(string jzbh,string lsbh,string sktt,string gd_type)
        {
            //注意:sktt只和lsbh和用,代表着在住类型的改单,而只要jzbh不为空时,sktt就为空
            InitializeComponent();
            this.jzbh_gd = jzbh;
            this.lsbh_gd = lsbh;
            this.gd_type = gd_type;
            this.sktt = sktt;
            initalData("inital","");
            calc(ref xf,ref   fk, ds_bind);
        }
        public string jzbh_gd = "";
        public string lsbh_gd = "";
        public string sktt = "";
        public string gd_type = "";//有两个值jz,zz(一个是结账，一个是在住)
        public DataSet ds_gd = null;
        public DataView ds_bind = null;
        public string filterStr = "";
        StringBuilder sb = new StringBuilder();
        BLL.Common B_common = new Hotel_app.BLL.Common();
        string  xf = "0";
        string fk = "0";
        decimal xf_temp_1 = 0;
        decimal fk_temp_1 = 0;

        float zd_fkje = 0;
        float zd_xfje = 0;


        string zd_fjbh = "";
        string zd_krxm_lz = "";
        string zd_fjbh_lz = "";
        string zd_ddsj = "";

        public void  initalData(string Type,string Filter)
        {
            sb = new StringBuilder();

            if (Type == "inital")
            {
                B_common.ExecuteSql(" delete from Sjzmx_gd_temp where czy_temp='" + common_file.common_app.czy_GUID + "' and yydh='" + common_file.common_app.yydh + "'");
                sb = new StringBuilder();
                if (gd_type == "jz")
                {
                    sb.Append(" insert into  Sjzmx_gd_temp(yydh, qymc, is_select, is_top, id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, jjje, xfje, yh, sjxfje, xfsl, shsc, czy_bc, czzt, tfsj, czsj, syzd, is_visible, xyh, jzzt, fkfs, mxbh, czy_temp,zd_fkje,zd_xfje,zd_ddsj,zd_tfsj,zd_fjbh,zd_krxm_lz,zd_fjbh_lz)");
                    sb.Append(" select  Sjzmx.yydh, Sjzmx.qymc, Sjzmx.is_select, Sjzmx.is_top, Sjzmx.id_app, Sjzmx.jzbh, Sjzmx.lsbh, Sjzmx.krxm, Sjzmx.fjrb,Sjzmx.fjbh, Sjzmx.sktt, Sjzmx.xfrq, Sjzmx.xfsj, Sjzmx.czy, Sjzmx.xfdr, Sjzmx.xfrb, Sjzmx.xfxm, Sjzmx.xfbz, Sjzmx.xfzy, Sjzmx.jjje, Sjzmx.xfje, Sjzmx.yh, Sjzmx.sjxfje, Sjzmx.xfsl, Sjzmx.shsc, Sjzmx.czy_bc, Sjzmx.czzt, Sjzmx.tfsj, Sjzmx.czsj, Sjzmx.syzd, Sjzmx.is_visible,Sjzmx.xyh, Sjzmx.jzzt, Sjzmx.fkfs, Sjzmx.mxbh,'" + common_file.common_app.czy_GUID + "',Sjzzd.fkje,Sjzzd.xfje,Sjzzd.ddsj,Sjzzd.tfsj,Sjzzd.fjbh,Sjzzd.krxm_lz,Sjzzd.fjbh_lz  from  Sjzmx,Sjzzd  where Sjzzd.yydh='" + common_file.common_app.yydh + "' and  Sjzmx.jzbh=Sjzzd.jzbh  and Sjzmx.jzbh='" + jzbh_gd + "'");
                    B_common.ExecuteSql(sb.ToString());
                }
                if (gd_type == "zz")
                {
                    sb.Append( "insert into  Sjzmx_gd_temp(yydh, qymc,id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, jjje, xfje, yh, sjxfje, xfsl, shsc, czy_bc, czzt, tfsj, czsj, syzd, is_visible, xyh, jzzt, fkfs, mxbh, czy_temp,zd_fkje,zd_xfje,zd_ddsj,zd_tfsj,zd_fjbh,zd_krxm_lz,zd_fjbh_lz)");
                    sb.Append(" select                                 yydh, qymc,id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, jjje, xfje, yh, sjxfje, xfsl, shsc, '','','" + DateTime.Now.ToString() + "',czsj,'',1,'',krxm,fkfs, mxbh, '"+common_file.common_app.czy_GUID+"',0,0,'1800-01-01','1800-01-01','','',''  from Szw_temp  where czy_temp='" + common_file.common_app.czy_GUID + "' ");
                    B_common.ExecuteSql(sb.ToString());


                    // 更改其它的一些信息
                     zd_fjbh = "";
                     zd_krxm_lz = "";
                     zd_fjbh_lz = "";
                     zd_ddsj = common_file.common_app.cssj;
                    string zd_lksj = common_file.common_app.cssj;

                    if (sktt == "sk")
                    {
                        DataSet ds_0 = B_common.GetList(" select * from View_Qskzd  ", " id>=0   and   lsbh='" + lsbh_gd + "' and yydh='" + common_file.common_app.yydh + "'   and main_sec='"+common_file.common_app.main_sec_main+"'");
                        if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                        {
                            zd_fjbh = ds_0.Tables[0].Rows[0]["fjbh"].ToString();
                            zd_ddsj = ds_0.Tables[0].Rows[0]["ddsj"].ToString();
                        }
                        DataSet ds_1 = B_common.GetList(" select * from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh_gd + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  ) ");
                        if (ds_1 != null && ds_1.Tables[0].Rows.Count > 0)
                        {
                            StringBuilder sb_fjbh = new StringBuilder();
                            StringBuilder sb_krxm = new StringBuilder();
                            for (int i = 0; i < ds_1.Tables[0].Rows.Count; i++)
                            {
                                DataSet ds_3 = B_common.GetList(" select * from View_Qskzd  ", " id>=0   and   lsbh='" + ds_1.Tables[0].Rows[i]["lsbh"].ToString() + "' and yydh='" + common_file.common_app.yydh + "' ");
                                if (ds_3 != null && ds_3.Tables[0].Rows.Count > 0)
                                {
                                    sb_fjbh.Append(ds_3.Tables[0].Rows[0]["fjbh"].ToString());
                                    sb_krxm.Append(ds_3.Tables[0].Rows[0]["krxm"].ToString());
                                    if (i < ds_1.Tables[0].Rows.Count - 1)
                                    {
                                        sb_fjbh.Append("|");
                                        sb_krxm.Append("|");
                                    }
                                }
                            }
                            zd_fjbh_lz = sb_fjbh.ToString();
                            zd_krxm_lz = sb_krxm.ToString();
                        }
                        else
                        {
                            zd_fjbh = ds_0.Tables[0].Rows[0]["fjbh"].ToString();
                            zd_ddsj = ds_0.Tables[0].Rows[0]["ddsj"].ToString();
                            zd_fjbh_lz = ds_0.Tables[0].Rows[0]["fjbh"].ToString();
                            zd_krxm_lz = ds_0.Tables[0].Rows[0]["krxm"].ToString();
                        }
                    }
                    if (sktt == "tt")
                    {
                        DataSet ds_0 = B_common.GetList(" select * from View_Qttzd  ", " id>=0   and   lsbh='" + lsbh_gd + "' and yydh='" + common_file.common_app.yydh + "'  ");
                        zd_fjbh = "";
                        zd_krxm_lz = ds_0.Tables[0].Rows[0]["krxm"].ToString();
                        string  zd_ddbh = ds_0.Tables[0].Rows[0]["ddbh"].ToString();
                        zd_ddsj = ds_0.Tables[0].Rows[0]["ddsj"].ToString();

                        StringBuilder sb_fjbh = new StringBuilder();
                        DataSet ds_1 = B_common.GetList(" select * from View_Qskzd  ", " id>=0   and   ddbh='" + zd_ddbh + "' and yydh='" + common_file.common_app.yydh + "'   and main_sec='" + common_file.common_app.main_sec_main + "'");
                        if (ds_1 != null && ds_1.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds_1.Tables[0].Rows.Count ; i++)
                            {
                                sb_fjbh.Append(ds_1.Tables[0].Rows[0]["fjbh"].ToString());
                                if (i < ds_1.Tables[0].Rows.Count - 1)
                                {
                                    sb_fjbh.Append("|");
                                }
                            }
                            zd_fjbh_lz = sb_fjbh.ToString();
                        }
                    }
                    string temp = " update Sjzmx_gd_temp  Set  tfsj='" + DateTime.Now.ToString() + "',zd_fjbh='" + zd_fjbh_lz + "',zd_krxm_lz='" + zd_krxm_lz + "',zd_xfje='" + zd_xfje + "',zd_fkje='" + zd_fkje + "',zd_ddsj='" + zd_ddsj + "',zd_tfsj='" + DateTime.Now.ToString() + "'   where czy_temp='" + common_file.common_app.czy_GUID + "'  ";
                    //更新临时表
                    B_common.ExecuteSql(" update Sjzmx_gd_temp  Set  tfsj='" + DateTime.Now.ToString() + "',zd_fjbh_lz='" + zd_fjbh_lz + "',zd_krxm_lz='" + zd_krxm_lz + "',zd_xfje='" + zd_xfje + "',zd_fkje='" + zd_fkje + "',zd_ddsj='" + zd_ddsj + "',zd_tfsj='" + DateTime.Now.ToString() + "'   where czy_temp='" + common_file.common_app.czy_GUID + "'  ");




                }
            }
            //结账账务的改单
            if (jzbh_gd.Trim() != "")
            {
                ds_gd = B_common.GetList("select * from Sjzmx_gd_temp", "id>=0 and  czy_temp='" + common_file.common_app.czy_GUID + "' and jzbh='" + jzbh_gd + "'");
                if (ds_gd != null && ds_gd.Tables[0].Rows.Count > 0)
                {
                    dg_gd.AutoGenerateColumns = false;
                     ds_bind = null;
                    if (Filter.Trim() == "")
                    {
                        //bindingSource_gd.DataSource = ds_gd.Tables[0].DefaultView;
                        ds_bind = ds_gd.Tables[0].DefaultView;
                    }
                    if (Filter.Trim() != "")
                    {
                        ds_gd.Tables[0].DefaultView.RowFilter = Filter;
                        ds_bind = ds_gd.Tables[0].DefaultView;
                    }
                    bindingSource_gd.DataSource = ds_bind;
                    dg_gd.DataSource = bindingSource_gd;
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有任何消费明细.");
                }
            }
            //在住类型的改单
            if (jzbh_gd.Trim() == "" && lsbh_gd.Trim() != ""&&sktt.Trim()!="")
            {
                ds_gd = B_common.GetList("select * from Sjzmx_gd_temp", "id>=0 and  czy_temp='" + common_file.common_app.czy_GUID + "' ");
                if (ds_gd != null && ds_gd.Tables[0].Rows.Count > 0)
                {
                    dg_gd.AutoGenerateColumns = false;
                    ds_bind = null;
                    if (Filter.Trim() == "")
                    {
                        //bindingSource_gd.DataSource = ds_gd.Tables[0].DefaultView;
                        ds_bind = ds_gd.Tables[0].DefaultView;
                    }
                    if (Filter.Trim() != "")
                    {
                        ds_gd.Tables[0].DefaultView.RowFilter = Filter;
                        ds_bind = ds_gd.Tables[0].DefaultView;
                    }
                    bindingSource_gd.DataSource = ds_bind;
                    dg_gd.DataSource = bindingSource_gd;
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有任何消费明细.");
                }

            }
        }

        private void b_zd_Click(object sender, EventArgs e)
        {
            if (gd_type == "jz")
            {
                Szw_gd_zd Frm_szw_gd_zd = new Szw_gd_zd(jzbh_gd,"","","","","","","jz");
                Frm_szw_gd_zd.StartPosition = FormStartPosition.CenterScreen;
                Frm_szw_gd_zd.ShowDialog();
            }
            if (gd_type == "zz")
            {
                Szw_gd_zd Frm_szw_gd_zd = new Szw_gd_zd("",lsbh_gd,sktt,zd_fjbh,zd_krxm_lz,zd_fjbh_lz,zd_ddsj,"zz");
                Frm_szw_gd_zd.StartPosition = FormStartPosition.CenterScreen;
                Frm_szw_gd_zd.ShowDialog();
 
            }


        }

        private void b_xg_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            //if (common_file.common_roles.get_user_qx("B_Sjjzwll_gd", common_file.common_app.user_type) == false)
            //{ return; }
            if (dg_gd.CurrentRow != null && dg_gd.CurrentRow.Index > -1 && dg_gd.CurrentRow.Index < ds_gd.Tables[0].Rows.Count && ds_gd.Tables[0].Rows[dg_gd.CurrentRow.Index]["id_app"] != null)
            {
                // int i = dg_zzll.CurrentRow.Index;
                DataRowView dgr = dg_gd.SelectedRows[0].DataBoundItem as DataRowView;
                if (dgr != null)
                {
                    int i = ds_gd.Tables[0].Rows.IndexOf(dgr.Row);
                    if (i > -1 && i < dg_gd.Rows.Count)//当前行为内容行
                    {
                        //string xfxm_old = ds_gd.Tables[0].Rows[dg_zzll.CurrentRow.Index]["xfxm"].ToString();
                        //string xfje_old = ds_gd.Tables[0].Rows[dg_zzll.CurrentRow.Index]["sjxfje"].ToString();
                       // string xfbz_old = ds_gd.Tables[0].Rows[dg_zzll.CurrentRow.Index]["xfbz"].ToString();
                        //string xfzy_old = ds_gd.Tables[0].Rows[dg_zzll.CurrentRow.Index]["xfzy"].ToString();
                        //DateTime xfsj = DateTime.Parse(ds_gd.Tables[0].Rows[dg_zzll.CurrentRow.Index]["xfsj"].ToString());
                        string id_app = ds_gd.Tables[0].Rows[i]["id_app"].ToString();
                        //lsbh = ds_gd.Tables[0].Rows[i]["lsbh"].ToString();
                        //jzbh = v.Tables[0].Rows[i]["jzbh"].ToString();
                        //fjbh = ds_gd.Tables[0].Rows[i]["fjbh"].ToString();
                        //sk_tt = v.Tables[0].Rows[i]["sktt"].ToString();
                        Szw_gd_xg Frm_Szw_gd_xg = new Szw_gd_xg(id_app);
                        Frm_Szw_gd_xg.StartPosition = FormStartPosition.CenterScreen;
                        if (Frm_Szw_gd_xg.ShowDialog() == DialogResult.OK)
                        {
                            initalData("refresh","");
                            calc(ref xf, ref fk, ds_bind);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_dy_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcz_print", common_file.common_app.user_type) == false)
            { return; }
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要打印此账单嘛?") == true)
            {
                //Szw_print_jzd Szw_print_jzd_new;
                common_file.common_app.get_czsj();
                common_file.common_PrintFrm PrintFrm = new Hotel_app.common_file.common_PrintFrm(lsbh_gd, tB_fk.Text.Trim(), tB_xf.Text.Trim(), "Sjzmx", "jzd_gd", sktt, jzbh_gd);
                //Szw_print_jzd_new = new Szw_print_jzd(lsbh_gd, tB_fk.Text.Trim(), tB_xf.Text.Trim(), "Sjzmx", "jzd_gd", sktt, jzbh_gd); Szw_print_jzd_new.Visible = false;
                string gd_bz = "";
                if (jzbh_gd.Trim() == "")
                { gd_bz = "结账前的改单打印"; }
                if (jzbh_gd.Trim() != "")
                {
                    gd_bz = "结账后的改单打印";
                }
                common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "改单打印", "改单的临时编号为:" + lsbh_gd+"当前为:"+gd_bz, "改单后的消费金额为:" + tB_xf.Text.Trim() + "改单后付款金额为:" + tB_fk.Text.Trim(), DateTime.Now);
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_tc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_sc_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            //if (common_file.common_roles.get_user_qx("B_Sjjzwll_gd", common_file.common_app.user_type) == false)
            //{ return; }
            if (dg_gd.CurrentRow != null && dg_gd.CurrentRow.Index > -1 && dg_gd.CurrentRow.Index < ds_gd.Tables[0].Rows.Count && ds_gd.Tables[0].Rows[dg_gd.CurrentRow.Index]["id_app"] != null)
            {
                // int i = dg_zzll.CurrentRow.Index;
                DataRowView dgr = dg_gd.SelectedRows[0].DataBoundItem as DataRowView;
                if (dgr != null)
                {
                    int i = ds_gd.Tables[0].Rows.IndexOf(dgr.Row);
                    if (i > -1 && i < dg_gd.Rows.Count)//当前行为内容行
                    {
                        string id_app = ds_gd.Tables[0].Rows[i]["id_app"].ToString();

                        if (B_common.ExecuteSql("delete from Sjzmx_gd_temp where id_app='"+id_app+"' and czy_temp='"+common_file.common_app.czy_GUID+"'")>0&&common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要删除这笔消费嘛(这里删除完全不会影响原始账单)?") == true)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功!");
                            initalData("refresh",""); calc(ref xf, ref fk, ds_bind);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_cz_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要放弃当前改单内容,重做改单嘛?(选是会丢失当前以有的改单内容)") == true)
            {
                initalData("inital","");
                calc(ref xf, ref fk, ds_bind);
            }
        }
        //计算当前的消费金额和付款金额
        private void calc(ref  string xf, ref string fk, DataView ds)
        {

            xf = "0";
            fk = "0";
            xf_temp_1 = 0;
            fk_temp_1 = 0;
            if (ds != null && ds.Table.Rows.Count > 0)
            {
                for (int i = 0; i < ds.Table.Rows.Count; i++)
                {
                    if (ds.Table.Rows[i]["xfdr"].ToString() != common_file.common_app.fkdr)
                    {
                        xf_temp_1 += decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds.Table.Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    }
                    if (ds.Table.Rows[i]["xfdr"].ToString() == common_file.common_app.fkdr)
                    {
                        fk_temp_1 += decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds.Table.Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    }
                }
            }
            else
            {
                xf_temp_1 = 0;
                fk_temp_1 = 0;
            }

            xf = xf_temp_1.ToString();
            fk = (Math.Abs(fk_temp_1)).ToString();
            tB_fk.Text = fk;
            tB_xf.Text = xf;
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            Sxfxm Sxfxm_new = new Sxfxm("xf_gd");
            if (gd_type == "jz")
            {
                Sxfxm_new.gd_jzzd = jzbh_gd;
                Sxfxm_new.gd_lsbh = "";
            }
            if (gd_type == "zz")
            {
                Sxfxm_new.gd_jzzd = "";
                Sxfxm_new.gd_lsbh = lsbh_gd;
                Sxfxm_new.sk_tt = sktt;
            }
            Sxfxm_new.StartPosition = FormStartPosition.CenterScreen;
            if (Sxfxm_new.ShowDialog()== DialogResult.OK)
            {
                initalData("refresh","");
                calc(ref xf, ref fk, ds_bind);
            }
        }

        private void b_tj_Click(object sender, EventArgs e)
        {
            //显示过滤
            //if (ds_gd != null && ds_gd.Tables[0].Rows.Count > 0)
            //{
            //    Szw_gd_tj Frm_Szw_gd_tj = new Szw_gd_tj();
            //    if (Frm_Szw_gd_tj.ShowDialog() == DialogResult.OK)
            //    {
            //        this.filterStr = Frm_Szw_gd_tj.getFilter;
            //        initalData("refresh", filterStr);
            //        calc(ref xf, ref fk, ds_bind);
            //    }
            //}
            DataSet ds_tj = B_common.GetList(" select  xfxm,sum(sjxfje) as xmjeTotal  from Sjzmx_gd_temp ", " id>=0  and  czy_temp='" + common_file.common_app.czy + "' and yydh='" + common_file.common_app.yydh + "'  group by xfxm ");
            if (ds_tj != null && ds_tj.Tables[0].Rows.Count > 0)
            {
                List<int> lists = new List<int>();//临时用来存储统计项目的
                for (int i = 0; i < ds_tj.Tables[0].Rows.Count; i++)
                {
                    string ls_xfxm = ds_tj.Tables[0].Rows[i]["xfxm"].ToString();
                    string ls_xfjeTotal = ds_tj.Tables[0].Rows[i]["xmjeTotal"].ToString();

                    for (int j = 0; j < ds_gd.Tables[0].Rows.Count; j++)
                    {
                        if (ds_gd.Tables[0].Rows[j]["xfxm"].ToString().Trim().Equals(ls_xfxm))
                        {
                            int  ls_id=int.Parse(ds_gd.Tables[0].Rows[j]["id"].ToString());

                            //执行汇总
                            B_common.ExecuteSql(" update  Sjzmx_gd_temp  set   sjxfje='" + ls_xfjeTotal + "'  where id=" + ls_id);
                            B_common.ExecuteSql(" delete from Sjzmx_gd_temp  where id!=" + ls_id + "  and   xfxm='" + ls_xfxm + "'  and  czy_temp='" + common_file.common_app.czy + "'  and  yydh='"+common_file.common_app.yydh+"' ");
                            //删除其它不要的条目
                            break;
                        }
                    }
                }
            }

            initalData("refresh", "");
            calc(ref xf, ref fk, ds_bind);
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            initalData("refresh","");
            calc(ref xf, ref fk, ds_bind);
        }
    }
}