using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class X_common_one : Form
    {
        public int dg_count = 0;
        public string table_name = "Xkrly";
        public string judge_type = "Xkrly";//判断选择哪一张表
        public string display_data = "krly";
        public string sel_content = "select id,krly as krly,zjm from ";
        public string sel_condition = "id>=0"+common_file.common_app.yydh_select;
        public string get_value = "";
        public string get_bh = "";
        public string get_xfdr = "";
        public string get_tm = "";
        public string parameter = "";
        public BLL.Common B_Common = new Hotel_app.BLL.Common();
        DataSet DS_Common;


        public X_common_one(string xfdr)
        {
            get_xfdr = xfdr;
            InitializeComponent();
 
        }
        public X_common_one()
        {
            InitializeComponent();
            //InitializeApp(table_name, sel_condition);

        }

        public void insert_content(string[] info)
        {
            this.Text = info[0];
            display_data = info[1];
            dg_common.Columns[0].HeaderText = info[2];
            table_name = judge_type;
            sel_condition = info[3];
            sel_content = info[4];
        }



        public void initialize_content()
        {
            string s_0 = "";
            switch (judge_type)
            {
                case "Xkrly":
                    insert_content(new string[] { "客人来源", "krly", "客人来源", "id>=0" + common_file.common_app.yydh_select + " order by krly", "select id,krly as krly,zjm from " });
                    break;
                case "Xkrrx":
                    insert_content(new string[] { "客人类型", "krrx", "客人类型", "id>=0" + common_file.common_app.yydh_select + "order by krrx", "select id,krrx as krly,zjm from " });
                    break;
                case "Xkrmz":
                    insert_content(new string[] { "民族", "krmz", "民族", "id>=0" + common_file.common_app.yydh_select + "order by krmz", "select id,krmz as krly,zjm from " });
                    break;
                case "Xqzrx":
                    insert_content(new string[] { "签证类型", "qzrx", "签证类型", "id>=0" + common_file.common_app.yydh_select + "order by qzrx", "select id,qzrx as krly,zjm from " });
                    break;
                case "Xyxzj":
                    insert_content(new string[] { "证件", "yxzj", "证件", "id>=0" + common_file.common_app.yydh_select + "order by yxzj", "select id,yxzj as krly,zjm from " });
                    break;
                case "Yxsy":
                    insert_content(new string[] { "销售员", "xsy", "销售员", "id>=0" + common_file.common_app.yydh_select + "order by xsy", "select id,xsy as krly,zjm from " });
                    break;
                case "Xxfdr":
                    insert_content(new string[] { "消费大类", "xfdr", "消费大类", "id>=0 " + common_file.common_app.yydh_select + "order by xfdr", "select id,xfdr as krly,drbh from " });
                    break;
                case "Xxfxr":
                    s_0 = "";
                    if (get_xfdr != "")
                    { s_0 = " and  xfdr='" + get_xfdr + "' "; } 
                    insert_content(new string[] { "消费小类", "xfxr", "消费小类", "id>=0 " + common_file.common_app.yydh_select + s_0 + "  order by xfxr  ", "select id,xfxr as krly,xfdr from " });
                    break;
                case "Hhyjf_jp_Class":
                    insert_content(new string[] { "奖品类型", "title", "奖品类型", "id>=0 order by id", "select id,title as krly from " });
                    break;
                case "Hhyjf_jp":
                    insert_content(new string[] { "奖品明细", "title", "奖品明细", "id>=0" + common_file.common_app.yydh_select + " and classname='" + parameter + "'  order by id", "select id,title as krly from " });
                    break;
                case "Ffjrb":
                    insert_content(new string[] { "房间类型", "fjrb", "房间类型", "id>=0" + common_file.common_app.yydh_select + "   order by id", "select id,fjrb as krly from " });
                    break;
                case "Xfkfs":
                    s_0 = "";
                    if (parameter != "")
                    { s_0 = " and  fkfs!='" + parameter + "' "; }
                    insert_content(new string[] { "付款方式", "fkfs", "付款方式", "id>=0" + common_file.common_app.yydh_select + s_0 + "  order by ID", "select id,fkfs as krly,zjm from " });
                    break;
                case "Xxfmx":
                    s_0 = "";
                    if (parameter != "")
                    { s_0 = " and  xrbh='" + parameter + "' "; }
                    insert_content(new string[] { "消费明细", "xfmx", "消费明细", "id>=0" + common_file.common_app.yydh_select + s_0 + " order by xfmx", "select id,xrbh,xfmx as krly,xftm,zjm from " });
                    break;
                case "Yxydw":
                    s_0 = "";
                    if (parameter != "")
                    { s_0 = "  and  rx='" + parameter + "'  "; }
                    insert_content(new string[] { "协议单位", "xydw", "协议单位", "Id>=0   and  yydh='"+common_file.common_app.yydh+"' " + s_0 + "  order by xydw", "select id,xydw as krly,zjm  from  " });
                    break;

                case "Sjzzd":
                    s_0 = "";
                    if (parameter != "")
                    { s_0 = "  and  jzzt='%" + parameter + "%'"; }
                    insert_content(new string[] { "结账主体", "jzzt", "结账主体", "id>=0" + common_file.common_app.yydh_select + "  order by xydw", " select id,jzzt  as krly,''  as zjm  from   " });
                    break;

                case  "X_wy_lang_type":
                    insert_content(new string[] { "语种", "language_type", "语种", "id>=0 " + common_file.common_app.yydh_select + "  order by language_type", "select id,language_type as krly from " });
                    break;


                case "YH_user":
                    insert_content(new string[] { "门店用户", "yhxm", "用户姓名", "id>=0" + common_file.common_app.yydh_select + "order by id", "select id,yhxm as krly,zjm from " });
                    break;

                //default:
            }


        }

        public void InitializeApp(string sel_condition_0)
        {
            DS_Common = B_Common.GetList(sel_content + table_name, sel_condition_0);
            bindingSource1.DataSource = DS_Common.Tables[0];
            dg_count = DS_Common.Tables[0].Rows.Count;
            this.dg_common.SummaryColumns = new string[] { dg_common.Columns[0].DataPropertyName.ToString() };
            this.dg_common.AutoGenerateColumns = false;
            
        }

        private void X_common_one_Load(object sender, EventArgs e)
        {
            initialize_content();
            InitializeApp(sel_condition);
           
        }

        private void dg_common_DoubleClick(object sender, EventArgs e)
        {
            if (dg_count>0 &&dg_common.CurrentRow.Index<dg_count&& DS_Common!=null && DS_Common.Tables[0].Rows[dg_common.CurrentRow.Index][dg_common.Columns[0].DataPropertyName.ToString()].ToString() != "")
            {
                get_value = DS_Common.Tables[0].Rows[dg_common.CurrentRow.Index][dg_common.Columns[0].DataPropertyName.ToString()].ToString();
                if (judge_type == "Xxfmx")
                {
                    get_bh = DS_Common.Tables[0].Rows[dg_common.CurrentRow.Index]["xrbh"].ToString();
                    get_tm = DS_Common.Tables[0].Rows[dg_common.CurrentRow.Index]["xftm"].ToString();
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void tB_select_TextChanged(object sender, EventArgs e)
        {
            if (judge_type != "Sjzzd" && judge_type!="Xxfxr"&&parameter!=common_file.common_xydw.xyrx_gzdw)
            {
                InitializeApp("id>=0" + common_file.common_app.yydh_select + " and (" + display_data + " like '%" + tB_select.Text.Trim() + "%' or zjm like '%" + tB_select.Text.Trim() + "%')");
            }
            else if (judge_type == "Yxydw" && parameter == common_file.common_xydw.xyrx_gzdw)
            {
                InitializeApp("id>=0" + common_file.common_app.yydh_select + " and (" + display_data + " like '%" + tB_select.Text.Trim() + "%' or zjm like '%" + tB_select.Text.Trim() + "%')    and   rx='"+parameter+"'  ");
            }
            else
            {
                InitializeApp("id>=0" + common_file.common_app.yydh_select + " and (" + display_data + " like '%" + tB_select.Text.Trim() + "%')");
            }
        }

        private void dg_common_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dg_common_DoubleClick(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { this.Close(); }
        }

        private void X_common_one_Shown(object sender, EventArgs e)
        {
            tB_select.Focus();
        }



    }
}