using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
namespace Hotel_app.Szwgl
{
    public partial class Szwcl : Form
    {
        public string lsbh = "";//点击成员节点时候绑定数据时会用到
        public string lsbh_ttzd = "";//团结主单结帐时会用到
        public string sk_tt = "sk";//tt
        public string czy = "";
        public DataSet ds_zwmx;
        public DataSet ds_xfxm;
        public DataSet ds_temp;
        public string lfbh_temp = "";
        public string ddbh_temp = "";
        public string lsbh_temp = "";
        public string fjbh_temp = "";
        public string[] Nodes_Text;
        public string url = common_file.common_app.service_url;

        public string yddj = "";//注意，当为预定的时候，只有交取押金，其它的全部的消费按纽都不能用;

        public string id = "";  //这里是散客或者团体的主单ID

        public string gl_sel_con = "";//右键中条件
        public decimal xf = 0;
        public decimal fk = 0;

        string[] list_lsbh = new string[300];

        public bool Add_btff = false;//是否加收半天房费

        //更新20120613,是否为历史查询
        public bool is_his = false;//是否为历史记录查询


        public Hotel_app.Model.Qskyd_mainrecord M_Qskyd_mainrecord;
        public Hotel_app.BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
        public Hotel_app.Model.Qttyd_mainrecord M_Qttyd_mainrecord = new Hotel_app.Model.Qttyd_mainrecord();
        public Hotel_app.BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
        public Hotel_app.Model.Qskyd_fjrb M_Qskyd_fjrb;
        public Hotel_app.BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        public Hotel_app.BLL.Flfsz B_Flfsz = new Hotel_app.BLL.Flfsz();
        public List<Hotel_app.Model.Qskyd_fjrb> lists = new List<Hotel_app.Model.Qskyd_fjrb>();
        BLL.Qskyd_mainrecord_bak B_Qskyd_mainrecord_bak = new Hotel_app.BLL.Qskyd_mainrecord_bak();
        BLL.Qttyd_mainrecord_bak B_Qttyd_mainrecord_bak = new Hotel_app.BLL.Qttyd_mainrecord_bak();
        Model.Qttyd_mainrecord_bak M_Qttyd_mainrecord_bak;
        Model.Qskyd_mainrecord_bak M_Qskyd_mainrecord_bak;
        BLL.Qskyd_fjrb_bak B_Qskyd_fjrb_bak = new Hotel_app.BLL.Qskyd_fjrb_bak();
        Model.Qskyd_fjrb_bak M_Qskyd_fjrb_bak;

        //实现过虑的panel的拖动
        Point mouse_offset = new Point();


        SzwclHelper SzwclHelper_new = new SzwclHelper();

        public BLL.Common B_common = new Hotel_app.BLL.Common();

        public Szwcl(string lsbh, string sk_tt,bool _is_his)
        {
            InitializeComponent();
            this.lsbh=lsbh;
            this.sk_tt=sk_tt;
            this.is_his=_is_his;
        }

        ///直接通过前台来处理

        public void BindData(string lsbh, string czy)
        {
            if (!is_his)
            {
                Cms_cbz.Enabled = true;
                this.lsbh = lsbh;
                ds_zwmx = null;
                ds_xfxm = null;
                Bind_zwmx.DataSource = null;
                Bind_xfxm.DataSource = null;
                ds_zwmx = SzwclHelper_new.Zzwcl_Search(this.lsbh, this.sk_tt, czy);
                ds_xfxm = SzwclHelper_new.Zzwcl_hz(this.lsbh, czy);
                if (ds_zwmx != null && ds_zwmx.Tables[0].Rows.Count > 0)
                {
                    Bind_zwmx.DataSource = ds_zwmx.Tables[0];
                    if (gl_sel_con != "")
                    {
                        ds_zwmx.Tables[0].DefaultView.RowFilter = gl_sel_con;
                    }
                    Bind_xfxm.DataSource = ds_xfxm.Tables[0];
                }
                dgv_xfxm.AutoGenerateColumns = false;
                dgv_zwmx.AutoGenerateColumns = false;
                dgv_zwmx.DataSource = Bind_zwmx;
                dgv_xfxm.DataSource = Bind_xfxm;

                //右下角两个统计框赋值
                xf = 0;
                fk = 0;

                for (int i = 0; i < ds_zwmx.Tables[0].Rows.Count; i++)
                {
                    if (ds_zwmx.Tables[0].Rows[i]["xfdr"].ToString() == common_file.common_app.fkdr)
                    {
                        fk += decimal.Parse(ds_zwmx.Tables[0].Rows[i]["sjxfje"].ToString());
                    }
                    else
                    {
                        xf += decimal.Parse(ds_zwmx.Tables[0].Rows[i]["sjxfje"].ToString());
                    }
                }
                //这里更改成为行值来计算

                tB_xf.Text = Math.Abs(xf).ToString();
                tB_fk.Text = Math.Abs(fk).ToString();
            }
            if (is_his)
            {
                 // 绑定数据
                Cms_cbz.Enabled = false;
                this.lsbh = lsbh;
                ds_zwmx = null;
                ds_xfxm = null;
                Bind_zwmx.DataSource = null;
                Bind_xfxm.DataSource = null;
                ds_zwmx = SzwclHelper_new.GetZwData_ls(this.lsbh);
                ds_xfxm = SzwclHelper_new.GetZwData_hz(this.lsbh);
                if (ds_zwmx != null && ds_zwmx.Tables[0].Rows.Count > 0)
                {
                    Bind_zwmx.DataSource = ds_zwmx.Tables[0];
                    if (gl_sel_con != "")
                    {
                        ds_zwmx.Tables[0].DefaultView.RowFilter = gl_sel_con;
                    }
                    Bind_xfxm.DataSource = ds_xfxm.Tables[0];
                }
                dgv_xfxm.AutoGenerateColumns = false;
                dgv_zwmx.AutoGenerateColumns = false;
                dgv_zwmx.DataSource = Bind_zwmx;
                dgv_xfxm.DataSource = Bind_xfxm;

                //右下角两个统计框赋值
                xf = 0;
                fk = 0;

                for (int i = 0; i < ds_zwmx.Tables[0].Rows.Count; i++)
                {
                    if (ds_zwmx.Tables[0].Rows[i]["xfdr"].ToString() == common_file.common_app.fkdr)
                    {
                        fk += decimal.Parse(ds_zwmx.Tables[0].Rows[i]["sjxfje"].ToString());
                    }
                    else
                    {
                        xf += decimal.Parse(ds_zwmx.Tables[0].Rows[i]["sjxfje"].ToString());
                    }
                }
                //这里更改成为行值来计算

                tB_xf.Text = Math.Abs(xf).ToString();
                tB_fk.Text = Math.Abs(fk).ToString();
            }

            //更新20120704,预收款为红色
            if (dgv_zwmx.Rows.Count>0)
            {
                for (int m = 0; m < dgv_zwmx.Rows.Count; m++)
                {
                    int mm_0 = 0;
                    DataRowView dgr = dgv_zwmx.Rows[m].DataBoundItem as DataRowView;
                    mm_0 = ds_zwmx.Tables[0].Rows.IndexOf(dgr.Row);
                    if (ds_zwmx.Tables[0].Rows[mm_0]["xfxm"].ToString() == common_file.common_app.dj_ysk)
                    {
                        dgv_zwmx.Rows[m].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    
                }
            }




        }

        //初始化textBox的值
        public void Inital_app(string lsbh, string sk_tt,bool  _is_his, string czy)
        {
            this.lsbh = lsbh;
            this.sk_tt = sk_tt;
            this.is_his = _is_his;
            if (!is_his)
            {
                CreateTree();
            }
            if (is_his)
            {
                CreateTree_ls();
            }
        }

        private void CreateTree_ls()
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            if (!Tv_display.IsDisposed)
            {
                Tv_display.Nodes[0].Nodes.Clear();
            }
            //是散客的情况
            if (this.lsbh != "" && this.sk_tt == "sk")
            {
                //有三种情况(A  没有联房，B只联房没有联账，C  联房联账的)

                //联房也联账的时候，加载所有节点


                //考虑联房联账的情况

                ds_temp = B_Common.GetList(" select * from Flfsz_bak  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz_bak  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  ) ");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Text = ds_temp.Tables[0].Rows[i]["fjbh"].ToString() + "." + ds_temp.Tables[0].Rows[i]["krxm"].ToString();
                        childNode.Tag = (object)(ds_temp.Tables[0].Rows[i]["lsbh"].ToString() + "|" + ds_temp.Tables[0].Rows[i]["fjbh"].ToString());
                        Tv_display.Nodes["parent_xfjl"].Nodes.Add(childNode);
                    }
                }
                else//没联房，或者联房没联账的
                {
                    TreeNode childNode = new TreeNode();
                    ds_temp = B_common.GetList(" select * from Qskyd_fjrb_bak  ", " id>=0  and  lsbh='" + lsbh + "'  and yydh='" + common_file.common_app.yydh + "'  ");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        childNode.Text = ds_temp.Tables[0].Rows[0]["fjbh"].ToString() + "." + ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                        childNode.Tag = (object)(ds_temp.Tables[0].Rows[0]["lsbh"].ToString() + "|" + ds_temp.Tables[0].Rows[0]["fjbh"].ToString());
                        Tv_display.Nodes[0].Nodes.Add(childNode);
                    }
                }
                //确定yddj
                DataSet ds_temp_0 = B_common.GetList(" select * from Qskyd_mainRecord_bak ", "id>=0  and  lsbh='" + lsbh + "' and  yydh='" + common_file.common_app.yydh + "'  ");
                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                {
                    yddj = ds_temp_0.Tables[0].Rows[0]["yddj"].ToString();
                }
                if (Tv_display.Nodes[0].Nodes.Count > 0)
                {
                    Tv_display.SelectedNode = Tv_display.Nodes[0].Nodes[0];
                }
                Tv_display.ExpandAll();
            }
            else if (lsbh != "" && sk_tt == "tt")//是团体主单
            {
                List<Model.Qskyd_fjrb_bak> lists_ls = new List<Hotel_app.Model.Qskyd_fjrb_bak>();
                if (B_Qttyd_mainrecord_bak.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and   lsbh='" + this.lsbh + "'").Count > 0)
                {
                    M_Qttyd_mainrecord_bak = B_Qttyd_mainrecord_bak.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + this.lsbh + "'")[0];
                    ddbh_temp = M_Qttyd_mainrecord_bak.ddbh;
                    lsbh_temp = this.lsbh;
                    yddj = M_Qttyd_mainrecord_bak.yddj;
                    //获取ddbh_temp下所有的成员的记录(团体下所有的lsbh)
                    ds_temp = B_Qskyd_mainrecord_bak.GetList("id>=0  " + common_file.common_app.yydh_select + "  and   ddbh='" + ddbh_temp + "'   and  main_sec='" + common_file.common_app.main_sec_main + "'");
                    lists_ls = new List<Hotel_app.Model.Qskyd_fjrb_bak>();//重新实例化一次就可以处理掉重复生成子节点
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
                        {
                            lists_ls=B_Qskyd_fjrb_bak.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + ds_temp.Tables[0].Rows[i]["lsbh"] + "'  and  fjbh!='' ");
                            if (lists_ls.Count > 0)
                            {
                                M_Qskyd_fjrb_bak = lists_ls[0]; lists_ls.Add(M_Qskyd_fjrb_bak);
                            }
                            
                        }
                    }

                    //找出团体下面有排房的所有成员的记录
                    //团体的情况
                    Tv_display.Nodes[0].Text = "消费记录";

                    //首先增加两个二级节点，分别记录（团体总账务和成员详细账务)
                    TreeNode subNode = new TreeNode();
                    subNode.Text = "团体总账务";
                    subNode.Tag = (object)(lsbh_temp + "|" + "   ");
                    subNode.Name = "ttzw_total";
                    Tv_display.Nodes[0].Nodes.Add(subNode);

                    //增加总帐务下的节点，显示团体总帐务名细
                    subNode = new TreeNode();
                    subNode.Text = M_Qttyd_mainrecord_bak.krxm;//显示团体名称
                    subNode.Tag = (object)(M_Qttyd_mainrecord_bak.lsbh + "|" + "  ");
                    Tv_display.Nodes[0].Nodes["ttzw_total"].Nodes.Add(subNode);
                    //初始化textBox中的内容
                    FillValue(new string[] { M_Qttyd_mainrecord_bak.yddj, M_Qttyd_mainrecord_bak.sktt,"", M_Qttyd_mainrecord_bak.krxm, M_Qttyd_mainrecord_bak.ddsj.ToString(), M_Qttyd_mainrecord_bak.lksj.ToString(), M_Qttyd_mainrecord_bak.krly, M_Qttyd_mainrecord_bak.xydw, "", "", M_Qttyd_mainrecord_bak.tsyq, "" });

                    subNode = new TreeNode();
                    subNode.Text = "成员详细账务";
                    subNode.Name = "ttzw_cy_detail";
                    Tv_display.Nodes[0].Nodes.Add(subNode);
                    Tv_display.Nodes[0].Nodes["ttzw_cy_detail"].Nodes.Clear();
                    if (lists_ls != null && lists_ls.Count > 0)
                    {
                        //添加到tv中（Tag保留lsbh）
                        foreach (Model.Qskyd_fjrb_bak temp in lists_ls)
                        {
                            subNode = new TreeNode();
                            subNode.Text = temp.fjbh + "." + temp.krxm;
                            subNode.Tag = (object)(temp.lsbh + "|" + temp.fjbh);
                            Tv_display.Nodes[0].Nodes["ttzw_cy_detail"].Nodes.Add(subNode);
                        }
                    }
                }
            }
        }

        private void b_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tv_display_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }

        private void Tv_display_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //根据选择的节点的不同

            if (e.Node != null)
            {
                TreeNode selectNode = e.Node;
                if ((selectNode.Tag != null && selectNode.Name == "ttzw_total") || (selectNode.Tag != null && selectNode.Name == "ttzw_cy_detail"))
                { }
                else if (selectNode.Tag != null && selectNode.Name != "parent_xfjl")
                {
                    display_costDetail(selectNode);
                }
            }
        }

        //点击节点，显示账务详细
        private void display_costDetail(TreeNode tn)
        {
            if (!is_his)
            {
                lsbh_temp = "";
                fjbh_temp = "";
                string[] info = tn.Tag.ToString().Split('|');
                lsbh_temp = info[0];
                fjbh_temp = info[1];
                if (lsbh_temp != "" && fjbh_temp.Trim() != "")//选择的是团体成员节点
                {
                    //更新右边区域中的信息
                    M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh_temp + "'")[0];
                    M_Qskyd_fjrb = B_Qskyd_fjrb.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh_temp + "'")[0];
                    FillValue(new string[] { M_Qskyd_mainrecord.yddj, M_Qskyd_mainrecord.sktt,
                M_Qskyd_mainrecord.hykh_bz,M_Qskyd_mainrecord.krxm,M_Qskyd_mainrecord.ddsj.ToString(),
                M_Qskyd_mainrecord.lksj.ToString(), M_Qskyd_mainrecord.krly,M_Qskyd_mainrecord.krdw,
                M_Qskyd_fjrb.fjbh,M_Qskyd_fjrb.sjfjjg.ToString(),M_Qskyd_mainrecord.tsyq,M_Qskyd_fjrb.bz});
                    sk_tt = "sk";
                    yddj = M_Qskyd_mainrecord.yddj;
                }
                else if (lsbh_temp != "" && fjbh_temp.Trim() == "" && tn.Parent != null && tn.Parent.Name == "ttzw_total") //选择的是团体主单
                {
                    M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh_temp + "'")[0];
                    FillValue(new string[] { M_Qttyd_mainrecord.yddj, M_Qttyd_mainrecord.sktt, "", M_Qttyd_mainrecord.krxm, M_Qttyd_mainrecord.ddsj.ToString(), M_Qttyd_mainrecord.lksj.ToString(), M_Qttyd_mainrecord.krly, M_Qttyd_mainrecord.xydw, "", "", M_Qttyd_mainrecord.tsyq, "" });
                    sk_tt = "tt";
                    yddj = M_Qttyd_mainrecord.yddj;
                }
                BindData(lsbh_temp, common_file.common_app.czy_GUID);
                this.lsbh = lsbh_temp;//选择节点后，改变lsbh的值为当前节点
            }
            if (is_his)
            {
                lsbh_temp = "";
                fjbh_temp = "";
                string[] info = tn.Tag.ToString().Split('|');
                lsbh_temp = info[0];
                fjbh_temp = info[1];
                if (lsbh_temp != "" && fjbh_temp.Trim() != "")//选择的是团体成员节点
                {
                    //更新右边区域中的信息
                    M_Qskyd_mainrecord_bak = B_Qskyd_mainrecord_bak.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh_temp + "'")[0];
                    M_Qskyd_fjrb_bak = B_Qskyd_fjrb_bak.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh_temp + "'")[0];
                    FillValue(new string[] { M_Qskyd_mainrecord_bak.yddj, M_Qskyd_mainrecord_bak.sktt,
                M_Qskyd_mainrecord_bak.hykh,M_Qskyd_mainrecord_bak.krxm,M_Qskyd_mainrecord_bak.ddsj.ToString(),
                M_Qskyd_mainrecord_bak.lksj.ToString(), M_Qskyd_mainrecord_bak.krly,M_Qskyd_mainrecord_bak.krdw,
                M_Qskyd_fjrb_bak.fjbh,M_Qskyd_fjrb_bak.fjjg.ToString(),M_Qskyd_mainrecord_bak.tsyq,M_Qskyd_fjrb_bak.bz});
                    sk_tt = "sk";
                }
                else if (lsbh_temp != "" && fjbh_temp.Trim() == "" && tn.Parent != null && tn.Parent.Name == "ttzw_total") //选择的是团体主单
                {
                    M_Qttyd_mainrecord_bak = B_Qttyd_mainrecord_bak.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh_temp + "'")[0];
                    FillValue(new string[] { M_Qttyd_mainrecord_bak.yddj, M_Qttyd_mainrecord_bak.sktt, "", M_Qttyd_mainrecord_bak.krxm, M_Qttyd_mainrecord_bak.ddsj.ToString(), M_Qttyd_mainrecord_bak.lksj.ToString(), M_Qttyd_mainrecord_bak.krly, M_Qttyd_mainrecord_bak.xydw, "", "", M_Qttyd_mainrecord_bak.tsyq, "" });
                    sk_tt = "tt";
                }
                BindData(lsbh_temp, common_file.common_app.czy_GUID);
                this.lsbh = lsbh_temp;//选择节点后，改变lsbh的值为当前节点
            }
        }

        //根据节点内容，填空textbox的值(共12个参数）
        private void FillValue(string[] ss)
        {
            tB_yddj.Text = ss[0];// M_Qttyd_mainrecord.yddj;
            tB_sktt.Text = ss[1];// M_Qttyd_mainrecord.sktt;
            tB_hykh.Text = ss[2];//  "";
            tB_krxm.Text = ss[3];//  M_Qttyd_mainrecord.krxm;
            tB_ddsj.Text = ss[4];// M_Qttyd_mainrecord.ddsj.ToString();
            tB_lksj.Text = ss[5];// M_Qttyd_mainrecord.lksj.ToString();
            tB_krly.Text = ss[6];// M_Qttyd_mainrecord.krly;
            tB_krdw.Text = ss[7];//  M_Qttyd_mainrecord.xydw;// 临时显示为协议单位
            tB_fjbh.Text = ss[8];//  "";//团体不显示
            tB_fjjg.Text = ss[9];//  "";//团体不显示
            tB_tsyq.Text = ss[10];//  M_Qttyd_mainrecord.tsyq;
            tB_bz.Text = ss[11];//  "";
        }

        private void b_xf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcl_xfxm", common_file.common_app.user_type) == false)
            { return; }
            if (is_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "历史查询状态下只能查看");
                return;
            }

            //散客--登记   团体主单的话是没有限制的
            if ((sk_tt=="sk"&&yddj == common_file.common_yddj.yddj_dj)||sk_tt=="tt")//登记状态下才能消费
            {
                Szwgl.Sxfxm Frm_Sxfxm = new Sxfxm("xf");
                Frm_Sxfxm.StartPosition = FormStartPosition.CenterScreen;
                Frm_Sxfxm.lsbh = this.lsbh;
                Frm_Sxfxm.sk_tt = this.sk_tt;
                Frm_Sxfxm.ShowDialog();
            }
        }

        //记帐
        private void b_jz_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcl_jz", common_file.common_app.user_type) == false)
            { return; }
            if (is_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "历史查询状态下只能查看");
                return;
            }
            Btn_operate_zw(common_file.common_jzzt.czzt_jz);
        }
        //挂帐
        private void b_gz_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcl_gz", common_file.common_app.user_type) == false)
            { return; }
            if (is_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "历史查询状态下只能查看");
                return;
            }
            Btn_operate_zw(common_file.common_jzzt.czzt_gz);
        }
        //结帐
        private void b_sz_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcl_sz", common_file.common_app.user_type) == false)
            { return; }
            if (is_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "历史查询状态下只能查看");
                return;
            }
            Btn_operate_zw(common_file.common_jzzt.czzt_sz);
        }

        private void b_ys_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcl_yjcz", common_file.common_app.user_type) == false)
            { return; }
            if (is_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "历史查询状态下只能查看");
                return;
            }
            Szwgl.Syjcz Frm_Syjcz = new Syjcz();
            Frm_Syjcz.sk_tt = this.sk_tt;
            Frm_Syjcz.lsbh = this.lsbh;
            Frm_Syjcz.openfrom = "Szwcl";
            Frm_Syjcz.StartPosition = FormStartPosition.CenterScreen;
            if (Frm_Syjcz.ShowDialog() == DialogResult.OK)
            {
                BindData(lsbh, common_file.common_app.czy_GUID);
            }
        }

        // 在住的转帐
        private void b_zz_Click(object sender, EventArgs e)
        {


            if (common_file.common_roles.get_user_qx("B_zwcl_zwzz", common_file.common_app.user_type) == false)
            { return; }
            if (is_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "历史查询状态下只能查看");
                return;
            }
            //打开分结介面（传zz)
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                common_file.common_form.ShowFrm_Sfjcz_new(common_file.common_jzzt.czzt_zz, lsbh, sk_tt,"");
            }
        }

        //写一个方法优化上面的帐务操作
        private void Btn_operate_zw(string jjType)
        {
            if (yddj == common_file.common_yddj.yddj_dj)//登记状态下才能挂帐
            {
                if (jjType == common_file.common_jzzt.czzt_gz || jjType == common_file.common_jzzt.czzt_jz)
                {
                    if (sk_tt == "tt")
                    {
                        if (SzwclHelper_new.CheckTTcyZwStatus(lsbh) == false)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "团体成员帐务没有结清,团体无法结帐");
                            return;
                        }
                        else
                        {
                            if (jjType == common_file.common_jzzt.czzt_jz)
                            {
                                //common_file.common_form.ShowFrm_Szw_Common_check_new(common_file.common_jzzt.czzt_jz, lsbh, sk_tt);
                                Szw_Common_check Frm_Szw_Common_check = new Szw_Common_check();
                                Frm_Szw_Common_check.InitalApp(common_file.common_jzzt.czzt_jz, lsbh, sk_tt);
                                Frm_Szw_Common_check.StartPosition = FormStartPosition.CenterScreen; 
                                Frm_Szw_Common_check.ShowDialog();
                            }
                            if (jjType == common_file.common_jzzt.czzt_gz)
                            {
                                //common_file.common_form.ShowFrm_Szw_Common_check_new(common_file.common_jzzt.czzt_gz, lsbh, sk_tt);
                                Szw_Common_check Frm_Szw_Common_check = new Szw_Common_check();
                                Frm_Szw_Common_check.InitalApp(common_file.common_jzzt.czzt_gz, lsbh, sk_tt);
                                Frm_Szw_Common_check.StartPosition = FormStartPosition.CenterScreen; 
                                Frm_Szw_Common_check.ShowDialog();
                            }
                        }

                    }
                    else
                    {
                        if (jjType == common_file.common_jzzt.czzt_jz)
                        {
                            //common_file.common_form.ShowFrm_Szw_Common_check_new(common_file.common_jzzt.czzt_jz, lsbh, sk_tt);
                            Szw_Common_check Frm_Szw_Common_check = new Szw_Common_check();
                            Frm_Szw_Common_check.InitalApp(common_file.common_jzzt.czzt_jz, lsbh, sk_tt); Frm_Szw_Common_check.StartPosition = FormStartPosition.CenterScreen; 

                            Frm_Szw_Common_check.ShowDialog();
                        }
                        if (jjType == common_file.common_jzzt.czzt_gz)
                        {
                            //common_file.common_form.ShowFrm_Szw_Common_check_new(common_file.common_jzzt.czzt_gz, lsbh, sk_tt);
                            Szw_Common_check Frm_Szw_Common_check = new Szw_Common_check();
                            Frm_Szw_Common_check.InitalApp(common_file.common_jzzt.czzt_gz, lsbh, sk_tt); Frm_Szw_Common_check.StartPosition = FormStartPosition.CenterScreen; 

                            Frm_Szw_Common_check.ShowDialog();
                        }
                    }
                }
                if (jjType == common_file.common_jzzt.czzt_sz)
                {
                    if (sk_tt == "tt")
                    {
                        if (SzwclHelper_new.CheckTTcyZwStatus(lsbh) == false)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "团体成员帐务没有结清,团体无法结帐");
                            return;
                        }
                        else
                        {
                            //common_file.common_form.ShowFrm_Szw_Common_check_new(common_file.common_jzzt.czzt_sz, lsbh, sk_tt);
                            Szw_Common_check Frm_Szw_Common_check = new Szw_Common_check();
                            Frm_Szw_Common_check.InitalApp(common_file.common_jzzt.czzt_sz, lsbh, sk_tt); Frm_Szw_Common_check.StartPosition = FormStartPosition.CenterScreen; 

                            Frm_Szw_Common_check.ShowDialog();
                        }

                    }
                    else
                    {
                        //common_file.common_form.ShowFrm_Szw_Common_check_new(common_file.common_jzzt.czzt_sz, lsbh, sk_tt);
                        Szw_Common_check Frm_Szw_Common_check = new Szw_Common_check();
                        Frm_Szw_Common_check.InitalApp(common_file.common_jzzt.czzt_sz, lsbh, sk_tt); Frm_Szw_Common_check.StartPosition = FormStartPosition.CenterScreen; 

                        Frm_Szw_Common_check.ShowDialog();
                    }
                }
            }
        }

        public void CreateTree()
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();

            if (!Tv_display.IsDisposed)
            {
                Tv_display.Nodes[0].Nodes.Clear();
            }
            //是散客的情况
            if (this.lsbh != "" && this.sk_tt == "sk")
            {
                //有三种情况(A  没有联房，B只联房没有联账，C  联房联账的)

                //联房也联账的时候，加载所有节点


                //考虑联房联账的情况

                ds_temp = B_Common.GetList(" select * from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'   and shlz='1'  )   and shlz='1' ");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Text = ds_temp.Tables[0].Rows[i]["fjbh"].ToString() + "." + ds_temp.Tables[0].Rows[i]["krxm"].ToString();
                        childNode.Tag = (object)(ds_temp.Tables[0].Rows[i]["lsbh"].ToString() + "|" + ds_temp.Tables[0].Rows[i]["fjbh"].ToString());
                        if(ds_temp.Tables[0].Rows[i]["lsbh"].ToString()==this.lsbh)
                        {
                            childNode.Name = "selectNode";
                        }
                        Tv_display.Nodes["parent_xfjl"].Nodes.Add(childNode);
                    }
                }
                else//没联房，或者联房没联账的
                {
                    TreeNode childNode = new TreeNode();
                    ds_temp = B_common.GetList(" select * from Qskyd_fjrb  ", " id>=0  and  lsbh='" + lsbh + "'  and yydh='" + common_file.common_app.yydh + "'  ");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        childNode.Text = ds_temp.Tables[0].Rows[0]["fjbh"].ToString() + "." + ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                        childNode.Tag = (object)(ds_temp.Tables[0].Rows[0]["lsbh"].ToString() + "|" + ds_temp.Tables[0].Rows[0]["fjbh"].ToString());
                        Tv_display.Nodes[0].Nodes.Add(childNode);
                    }
                }
                //确定yddj
                DataSet ds_temp_0 = B_common.GetList(" select * from Qskyd_mainRecord ", "id>=0  and  lsbh='" + lsbh + "' and  yydh='" + common_file.common_app.yydh + "'  ");
                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                {
                    yddj = ds_temp_0.Tables[0].Rows[0]["yddj"].ToString();
                }
                if (Tv_display.Nodes[0].Nodes.Count > 1)
                {
                    Tv_display.SelectedNode = Tv_display.Nodes[0].Nodes["selectNode"];
                    //Tv_display.SelectedNode=Tv_display.Nodes[0].Nodes[
                }
                if (Tv_display.Nodes[0].Nodes.Count == 1)
                {
                    Tv_display.SelectedNode = Tv_display.Nodes[0].Nodes[0];
                }
                Tv_display.ExpandAll();
            }
            else if (lsbh != "" && sk_tt == "tt")//是团体主单
            {
                if (B_Qttyd_mainrecord.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and   lsbh='" + this.lsbh + "'").Count > 0)
                {
                    M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + this.lsbh + "'")[0];
                    ddbh_temp = M_Qttyd_mainrecord.ddbh;
                    lsbh_temp = this.lsbh;
                    yddj = M_Qttyd_mainrecord.yddj;
                }
                //获取ddbh_temp下所有的成员的记录(团体下所有的lsbh)
                ds_temp = B_Qskyd_mainrecord.GetList("id>=0  " + common_file.common_app.yydh_select + "  and   ddbh='" + ddbh_temp + "'   and  main_sec='" + common_file.common_app.main_sec_main + "'");
                lists = new List<Hotel_app.Model.Qskyd_fjrb>();//重新实例化一次就可以处理掉重复生成子节点
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
                    {
                        List<Hotel_app.Model.Qskyd_fjrb> list_temp = new List<Hotel_app.Model.Qskyd_fjrb>();
                        list_temp=B_Qskyd_fjrb.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + ds_temp.Tables[0].Rows[i]["lsbh"] + "'  and  fjbh!='' ");
                        if(list_temp.Count>0)
                        {
                            M_Qskyd_fjrb = list_temp[0];
                            lists.Add(M_Qskyd_fjrb);
                        }
                    }
                }

                //找出团体下面有排房的所有成员的记录
                //团体的情况
                Tv_display.Nodes[0].Text = "消费记录";

                //首先增加两个二级节点，分别记录（团体总账务和成员详细账务)
                TreeNode subNode = new TreeNode();
                subNode.Text = "团体总账务";
                subNode.Tag = (object)(lsbh_temp + "|" + "   ");
                subNode.Name = "ttzw_total";
                Tv_display.Nodes[0].Nodes.Add(subNode);

                //增加总帐务下的节点，显示团体总帐务名细
                subNode = new TreeNode();
                subNode.Text = M_Qttyd_mainrecord.krxm;//显示团体名称
                subNode.Tag = (object)(M_Qttyd_mainrecord.lsbh + "|" + "  ");
                Tv_display.Nodes[0].Nodes["ttzw_total"].Nodes.Add(subNode);
                //初始化textBox中的内容
                FillValue(new string[] { M_Qttyd_mainrecord.yddj, M_Qttyd_mainrecord.sktt, "", M_Qttyd_mainrecord.krxm, M_Qttyd_mainrecord.ddsj.ToString(), M_Qttyd_mainrecord.lksj.ToString(), M_Qttyd_mainrecord.krly, M_Qttyd_mainrecord.xydw, "", "", M_Qttyd_mainrecord.tsyq, "" });

                subNode = new TreeNode();
                subNode.Text = "成员详细账务";
                subNode.Name = "ttzw_cy_detail";
                Tv_display.Nodes[0].Nodes.Add(subNode);
                Tv_display.Nodes[0].Nodes["ttzw_cy_detail"].Nodes.Clear();
                if (lists != null && lists.Count > 0)
                {
                    //添加到tv中（Tag保留lsbh）
                    foreach (Model.Qskyd_fjrb temp in lists)
                    {
                        subNode = new TreeNode();
                        subNode.Text = temp.fjbh + "." + temp.krxm;
                        subNode.Tag = (object)(temp.lsbh + "|" + temp.fjbh);
                        Tv_display.Nodes[0].Nodes["ttzw_cy_detail"].Nodes.Add(subNode);
                    }
                }
            }
        }

        private void Szwcl_Load(object sender, EventArgs e)
        {
            CreateTree();
            if (dgv_zwmx.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_zwmx.Rows.Count; i++)
                {
                    if (dgv_zwmx.Rows[i].Cells[0].Value != null)
                    {
                        if (dgv_zwmx.Rows[i].Cells[0]. Value.ToString() == common_file.common_app.dj_ysk)
                        {
                            dgv_zwmx.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                        }
                    }
                    
                }
 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcl_dfff", common_file.common_app.user_type) == false)
            { return; }
            if (is_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "历史查询状态下只能查看");
                return;
            }
            if (yddj == common_file.common_yddj.yddj_yd)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "主单处于预定状态,要生成房费请先转入登记");
                return;  
            }
            if (sk_tt == "sk")
            {

                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title,"是否要对此房间累加一天的房费？") == true)
                {
                    common_file.common_app.get_czsj();
                    string url = common_file.common_app.service_url;
                    url += "Szwgl/Szwgl_app.asmx";
                    object[] args = new object[10];
                    args[0] = common_file.common_app.yydh;
                    args[1] = common_file.common_app.qymc;
                    args[2] = lsbh;
                    args[3] = Szwgl.common_zw.ff_kffy;
                    args[4] = "bbd";
                    args[5] = common_file.common_app.czy_bc;
                    args[6] = common_file.common_app.syzd;
                    args[7] = common_file.common_app.czy;
                    args[8] = DateTime.Now;
                    args[9] = common_file.common_app.xxzs;

                    Hotel_app.Server.Szwgl.Szwmx Szwmx_services = new Hotel_app.Server.Szwgl.Szwmx();
                    string result = Szwmx_services.New_fjfy(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(),DateTime.Parse(args[8].ToString()), args[9].ToString());
                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "New_fjfy", args);
                    if (result!=null&&result== common_file.common_app.get_suc)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                        BindData(lsbh,common_file.common_app.czy_GUID);
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "增加房费失败");
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            else
                if (sk_tt == "tt")
                {
                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要对此"+M_Qttyd_mainrecord.sktt+"所有成员累加一天的房费？") == true)
                    {
                        common_file.common_app.get_czsj();
                        string url = common_file.common_app.service_url;
                        url += "Szwgl/Szwgl_app.asmx";
                        object[] args = new object[9];
                        args[0] = common_file.common_app.yydh;
                        args[1] = common_file.common_app.qymc;
                        args[2] = M_Qttyd_mainrecord.ddbh;
                        args[3] = "bbd";
                        args[4] = common_file.common_app.czy_bc;
                        args[5] = common_file.common_app.syzd;
                        args[6] = common_file.common_app.czy;
                        args[7] = DateTime.Now;
                        args[8] = common_file.common_app.xxzs;

                        Hotel_app.Server.Szwgl.Szwmx Szwmx_services = new Hotel_app.Server.Szwgl.Szwmx();
                        string result = Szwmx_services.New_tt_fjfy(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(),DateTime.Parse(args[7].ToString()), args[8].ToString());


                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "New_tt_fjfy", args);
                        if (result.ToString() == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                            BindData(lsbh, common_file.common_app.czy_GUID);
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, result.ToString());
                        }
                        Cursor.Current = Cursors.Default;
                    }
                }
        }

        private void Tsmi_chongZhang_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcl_congz", common_file.common_app.user_type) == false)
            { return; }
            if (dgv_zwmx.CurrentRow!=null&&dgv_zwmx.CurrentRow.Index > -1 && dgv_zwmx.CurrentRow.Index < ds_zwmx.Tables[0].Rows.Count)
            {
                if (dgv_zwmx.CurrentRow!=null&&dgv_zwmx.CurrentRow.Index > -1 && dgv_zwmx.CurrentRow.Index < ds_zwmx.Tables[0].Rows.Count)
                {
                    int j_0 = 0;

                    DataRowView dgr = dgv_zwmx.CurrentRow.DataBoundItem as DataRowView;
                    j_0 = ds_zwmx.Tables[0].Rows.IndexOf(dgr.Row);


                    string xfxm_temp_0 = ds_zwmx.Tables[0].Rows[j_0]["xfxm"].ToString();
                    if (xfxm_temp_0 != common_file.common_app.dj_ysk && xfxm_temp_0 != common_zw.dr_ff)
                    {
                        string id_app_0 = ds_zwmx.Tables[0].Rows[j_0]["id_app"].ToString();
                        string jzbh_0 = ds_zwmx.Tables[0].Rows[j_0]["jzbh"].ToString();
                        SczOrbz Frm_sczorbz = new SczOrbz();
                        Frm_sczorbz.initalApp(id_app_0,jzbh_0,lsbh, common_zw.zwcl_congz);
                        Frm_sczorbz.StartPosition = FormStartPosition.CenterScreen;
                        if (Frm_sczorbz.ShowDialog() == DialogResult.OK)
                        {
                            BindData(lsbh, common_file.common_app.czy_GUID);
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "冲帐成功");
                        }
                    }
                }

            }
            Cursor.Current = Cursors.Default;
        }

        private void Tsmi_buzhang_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcl_buz", common_file.common_app.user_type) == false)
            { return; }
            if (dgv_zwmx.CurrentRow!=null&&dgv_zwmx.CurrentRow.Index > -1 && dgv_zwmx.CurrentRow.Index < ds_zwmx.Tables[0].Rows.Count)
            {

                int j_0 = 0;
                DataRowView dgr = dgv_zwmx.CurrentRow.DataBoundItem as DataRowView;
                j_0 = ds_zwmx.Tables[0].Rows.IndexOf(dgr.Row);


                string xfxm_temp_0 = ds_zwmx.Tables[0].Rows[j_0]["xfxm"].ToString();
                if (xfxm_temp_0 != common_file.common_app.dj_ysk&&xfxm_temp_0!=common_zw.dr_ff)
                {
                    string id_app_0 = ds_zwmx.Tables[0].Rows[j_0]["id_app"].ToString();
                    string jzbh_0 = ds_zwmx.Tables[0].Rows[j_0]["jzbh"].ToString();
                    SczOrbz Frm_sczorbz = new SczOrbz();
                    Frm_sczorbz.initalApp(id_app_0,jzbh_0,lsbh, common_zw.zwcl_bz);
                    Frm_sczorbz.StartPosition = FormStartPosition.CenterScreen;
                    if (Frm_sczorbz.ShowDialog() == DialogResult.OK)
                    {
                        BindData(lsbh, common_file.common_app.czy_GUID);
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "补帐成功");
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Tsmi_tuiding_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcl_yjcz_td", common_file.common_app.user_type) == false)
            { return; }
            if (dgv_zwmx.CurrentRow.Index > -1 && dgv_zwmx.CurrentRow.Index < ds_zwmx.Tables[0].Rows.Count)
            {
                int j_0 = 0;
                DataRowView dgr = dgv_zwmx.CurrentRow.DataBoundItem as DataRowView;
                j_0 = ds_zwmx.Tables[0].Rows.IndexOf(dgr.Row);



                string xfxm_temp_0 = ds_zwmx.Tables[0].Rows[j_0]["xfxm"].ToString();
                if (xfxm_temp_0 != common_file.common_app.dj_ysk)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "此功能不能应用于此项");
                    return;
                }
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要退订此款项嘛？") == true)
                {
                    object id_0 = DbHelperSQL.GetSingle("select  id  from Syjcz where id_app='" + ds_zwmx.Tables[0].Rows[j_0]["id_app"].ToString() + "' and yydh='" + common_file.common_app.yydh + "'");
                    if (id_0 != null)
                    {
                        if (common_cms.del_ysq(id_0.ToString()) == common_file.common_app.get_suc)
                        {
                            BindData(lsbh, common_file.common_app.czy_GUID);
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "退订成功");
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        //退订预授权
        private string del_ysq(string id)//ID为押金或者预授权的ID
        {
            string s = common_file.common_app.get_failure;
            //id, yydh, qymc, id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, 
            //xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, fkfs, xfje, sjxfje, czy_bc, syzd, add_edit_delete, xxzs
            string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
            object[] args = new object[26];
            args[0] = id;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = "";
            args[4] = "";//结帐前jzbh为空
            args[5] = lsbh;
            args[6] = "";
            args[7] = "";
            args[8] = "";
            args[9] = "";
            args[10] = DateTime.Now.ToString("yyyy-MM-dd");
            args[11] = DateTime.Now.ToString();
            args[12] = common_file.common_app.czy;
            args[13] = common_file.common_app.fkdr;
            args[14] = common_file.common_app.dj_ysk;
            args[15] = "";
            args[16] = "";
            args[17] = "";
            args[18] = "";
            args[19] = "";
            args[20] = "";
            args[21] = common_file.common_app.czy_bc;
            args[22] = common_file.common_app.syzd;
            args[23] = common_file.common_app.get_delete;//删除
            args[24] = common_file.common_app.xxzs;
            args[25] = DateTime.Now.ToString();
            Hotel_app.Server.Szwgl.Syjcz Syjcz_new = new Hotel_app.Server.Szwgl.Syjcz();
            string result = Syjcz_new.Syjcz_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Syjcz_add_edit", args);
            if (result != null && result== common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        //销账
        private void Tsmi_xiaozhang_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();

            if (common_file.common_roles.get_user_qx("B_zwcl_xiaoz", common_file.common_app.user_type) == false)
            { return; }
            if (dgv_zwmx.CurrentRow!=null&&dgv_zwmx.CurrentRow.Index > -1 && dgv_zwmx.CurrentRow.Index < ds_zwmx.Tables[0].Rows.Count)
            {

                int j_0 = 0;
                DataRowView dgr = dgv_zwmx.CurrentRow.DataBoundItem as DataRowView;
                j_0 = ds_zwmx.Tables[0].Rows.IndexOf(dgr.Row);



                string xfxm_temp_0 = ds_zwmx.Tables[0].Rows[j_0]["xfxm"].ToString();
                if (xfxm_temp_0 == common_file.common_app.dj_ysk)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "此功能不能应用于此项");
                    return;
                }
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "您是否真的要删除此笔账？") == true)
                {
                    common_file.common_app.get_czsj();
                    string id_app_0 = ds_zwmx.Tables[0].Rows[j_0]["id_app"].ToString();
                    if (id_app_0 != null && id_app_0.Trim() != "")
                    {
                        string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                        object[] args = new object[30];
                        args[0] = "";
                        args[1] = "";
                        args[2] = "";
                        args[3] = common_file.common_app.yydh;
                        args[4] = common_file.common_app.qymc;
                        args[5] = id_app_0;
                        args[6] = DateTime.Now.ToString("yyyy-MM-dd");
                        args[7] = DateTime.Now.ToString();
                        args[8] = common_file.common_app.czy;
                        //xfdr, xfrb, xfxm, xfbz, xfzy, xfje, yh, sjxfje, xfsl, czy_bc, czzt,
                        args[9] = "";//这里是找出节点的付款大类
                        args[10] = "";//消费小类
                        args[11] = "";//消费明细
                        args[12] = "";
                        args[13] = "";
                        args[14] = "";
                        args[15] = "";
                        args[16] = "";
                        args[17] = "";
                        args[18] = common_file.common_app.czy_bc;
                        args[19] = "";
                        args[20] = DateTime.Now.ToString();
                        args[21] = common_file.common_app.syzd;
                        args[22] = common_file.common_app.get_delete;
                        args[23] = common_file.common_app.xxzs;
                        args[24] = "";
                        args[25] = "";
                        args[26] = "";
                        args[27] = "";
                        args[28] = DateTime.Now.ToString();
                        args[29] = DateTime.Now.ToString();

                        Hotel_app.Server.Szwgl.Szwmx Szwmx_services = new Hotel_app.Server.Szwgl.Szwmx();
                        string result = Szwmx_services.Szwmx_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString());
                       // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Szwmx_add_edit", args);
                        if (result!=null&&result== common_file.common_app.get_suc)
                        {
                            BindData(lsbh, common_file.common_app.czy_GUID);
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "消账成功！");
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Tsmi_gl_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcl_gl", common_file.common_app.user_type) == false)
            { return; }
            p_gl.Left = dgv_zwmx.Left + 100;
            p_gl.Top = dgv_zwmx.Top + 100;
            p_gl.Visible = true;
            gl_sel_con = "";
            p_gl.Show();
            p_gl.BringToFront();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            gl_sel_con = "  1=1  ";
            DateTime startTime = DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString());
            DateTime endTime = DateTime.Parse(dT_ddsj_js.Value.ToShortDateString().Replace('/', '-') + "  23:59:59");
            if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) == DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) == DateTime.Parse(common_file.common_app.cssj))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请先选择好消费时间！");
            }
            else if (startTime > endTime)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "结束时间小于起始时间！");
            }
            else
            {
                gl_sel_con =gl_sel_con+ " and (xfsj>='" + dT_ddsj_cs.Value.ToShortDateString() + "' and  xfsj<='" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
            }

            if (tB_xfxm.Text.Trim().Replace("'", "-") != "")
            {
                gl_sel_con = gl_sel_con + " and xfxm like'%" + tB_xfxm.Text.Trim().Replace("'", "-") + "%'";
            }

            if (tB_xfzy.Text.Trim().Replace("'", "-") != "")
            {
                gl_sel_con = gl_sel_con + " and xfzy like'%" + tB_xfzy.Text.Trim().Replace("'", "-") + "%'";
            }

            if (tB_xfbz.Text.Trim().Replace("'", "-") != "")
            {
                gl_sel_con = gl_sel_con + " and xfbz like'%" + tB_xfbz.Text.Trim().Replace("'", "-") + "%'";
            }
            BindData(lsbh, common_file.common_app.czy);
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            p_gl.Visible = false;
            BindData(lsbh, common_file.common_app.czy_GUID);
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            gl_sel_con = "";
            BindData(lsbh, common_file.common_app.czy_GUID);
        }

        private void Tsmi_print_Click(object sender, EventArgs e)
        {
            if (ds_zwmx != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                //DataGridViewPrint DataGridViewPrint_new = new DataGridViewPrint(dgv_zwmx);
                //DataGridViewPrint_new.Print();
                dgvprint_app print_app_new = new dgvprint_app(lsbh,gl_sel_con,"single",null);
                print_app_new.print();
            }
        }

        private void dgv_zwmx_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv_zwmx.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_zwmx.Rows.Count; i++)
                {
                    if (dgv_zwmx.Rows[i].Cells[0].Value != null)
                    {
                        if (dgv_zwmx.Rows[i].Cells[0].Value.ToString() == common_file.common_app.dj_ysk)
                        {
                            dgv_zwmx.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                        }
                    }

                }

            }
        }

        private void p_gl_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset =new Point(-(e.X+groupBox1.Location.X), -(e.Y+groupBox1.Location.Y));
        }

        private void p_gl_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}