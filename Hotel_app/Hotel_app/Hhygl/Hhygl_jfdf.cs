using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
namespace Hotel_app.Hhygl
{
    public partial class Hhygl_jfdf : Form
    {
        public string Hhyjfdf_id = "";
        Model.Hhyjf_jp M_Hhyjfjp = new Model.Hhyjf_jp();
        BLL.Hhyjf_jp B_Hhyjfjp = new BLL.Hhyjf_jp();
        Model.Hhygl M_Hhygl=new Model.Hhygl();
        BLL.Hhygl B_Hhygl=new BLL.Hhygl();
        public Hhygl_browse parent_form;
        public string judge_add_edit = common_file.common_app.get_add;
        public string hykh = "";

        public Hhygl_jfdf(Hhygl_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
        }
        public Hhygl_jfdf()
        {
            InitializeComponent();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_classname.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，项目类型不能为空");
                tB_classname.Focus();
 
            }
            else if (tB_title.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，项目名称不能为空");
                tB_title.Focus();
            }
            else if (tB_dfsl.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，兑换数量不能为空");
                tB_dfsl.Focus();

            }
           else if ((Maticsoft.Common.PageValidate.IsDecimal(tB_dfsl.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_dfsl.Text.Trim())) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的数量不是有效数值！");
                tB_dfsl.Focus();
             
            }
            else
            {
                M_Hhygl = B_Hhygl.GetModelList(" id>=0  " + common_file.common_app.yydh_select + "  and   hykh='" + hykh+ "'")[0];
                decimal strdfjf = Convert.ToDecimal(tB_dfjf.Text.Trim());
               
                if (M_Hhygl.hyjf < strdfjf)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，您的积分不够。");
                    tB_classname.Focus();

                }
                else
                {
                    if (save_new() == common_file.common_app.get_suc)
                    {
                        decimal strhyzjf = M_Hhygl.hyjf - strdfjf;//会员兑换完后的积分
                        string strSql = " update Hhygl set hyjf=" + strhyzjf + ",shxg=1,xgsj=getdate() where hykh='" + hykh + "'";
                        int isok = DbHelperSQL.ExecuteSql(strSql);
                        if (isok > 0)
                        {
                           
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "恭喜您，" + tB_title.Text + "兑换成功。");

                            common_file.common_hy.Hhygl_browse_new.refresh_app();
                            common_file.common_hy.Hhygl_browse_new.open_record();
                            tB_title.Text = "";
                            tB_dfsl.Text = "1.0";
                            tB_dfjf.Text = "";
                            tB_classname.Text = "";

                        }
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，兑换失败。");
                    }
                            
                }
            }
            Cursor.Current = Cursors.Default;

        }
        public string save_new()
        {

            string lsbh_df = common_file.common_ddbh.ddbh("df", "lsbhdfdate", "lsbhdfcounter", 6);
            string s = common_file.common_app.get_failure;
            string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
            object[] args = new object[13];
            args[0] = Hhyjfdf_id;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = hykh;
            args[4] = M_Hhygl.hykh_bz;
            args[5] = M_Hhygl.krxm;
            args[6] = tB_dfjf.Text.Trim().Replace("'", "-");
            args[7] = tB_title.Text.Trim().Replace("'", "-");
            args[8] = tB_dfsl.Text.Trim().Replace("'", "-");
            args[9] = lsbh_df;
            args[10] = M_Hhygl.parent_hykh;
            args[11] = judge_add_edit;
            args[12] = common_file.common_app.xxzs;

            Hotel_app.Server.Hhygl.Hhyjf_df Hhyjf_df_services = new Hotel_app.Server.Hhygl.Hhyjf_df();
            string result = Hhyjf_df_services.Hhyjfdf_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjfdf_add_edit", args);
            if (result== common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_suc;
                common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "积分兑换成功", "" + lsbh_df + "", "会员卡号" + M_Hhygl.hykh_bz + "名称:" + tB_title.Text+ "兑换积分："+tB_dfjf.Text+"", DateTime.Now);
            }
            return s;
        }
        private void b_jpclass_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Hhyjf_jp_Class", tB_classname.Left+150, tB_classname.Top + 100, tB_classname,"");
        }
        private void display_new_commonform_1(string judge_type_0, int left_0, int top_0, TextBox TB_ls,string parameter)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.parameter = parameter;
            X_common_one_new.Left = left_0;
            X_common_one_new.Top = top_0;
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void b_dfxm_Click(object sender, EventArgs e)
        {
            try
            {
                if (tB_classname.Text != "")
                {

                    display_new_commonform_1("Hhyjf_jp", tB_title.Left + 150, tB_title.Top + 100, tB_title, tB_classname.Text);
                    //通过消费小类名称和消费项目的名称，检索价格，数量默认1
                    M_Hhyjfjp = B_Hhyjfjp.GetModelList("classname='" + tB_classname.Text.Trim() + "'  and id>=0  " + common_file.common_app.yydh_select + "  and   title='" + tB_title.Text.Trim() + "'")[0];
                    tB_dfsl.Text = "1.0";
                    tB_dfjf.Text = ((M_Hhyjfjp.jpjf) * (Decimal.Parse(tB_dfsl.Text))).ToString();

                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，项目类型不能为空");
                    tB_classname.Focus();
                }
            }
            catch
            { }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tB_dfsl_Leave(object sender, EventArgs e)
        {
            if ((Maticsoft.Common.PageValidate.IsDecimal(tB_dfsl.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_dfsl.Text.Trim())) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的数量不是有效数值！");
                tB_dfsl.Focus();
                tB_dfsl.SelectAll();
                return;
            }
            tB_dfjf.Text = ((M_Hhyjfjp.jpjf) * (Decimal.Parse(tB_dfsl.Text))).ToString();
        }

    }
}