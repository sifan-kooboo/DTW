using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Sjzcz : Form
    {
        public Sjzcz()
        {
            InitializeComponent();
        }
        public string jjType = "";//记帐，挂帐
        public string lsbh = "";//挂帐时用lsbh来标识
        public string krxm = "";//客人姓名
        public string sk_tt = "";//散客团体

        public bool shyj = false;//标识是否为右键用途

        public string get_jzzt = "";

        public string xf = "0"; public string info = "";
        SzwclHelper SzwclHelper_new = new SzwclHelper();
        //shyj  是否是右键中用到
        public void initalApp(string jjType, string lsbh, string krxm, string sk_tt, bool shyj, string _xf)
        {
            this.jjType = jjType;
            this.lsbh = lsbh;
            this.sk_tt = sk_tt;
            this.krxm = krxm;
            this.shyj = shyj;
            this.xf = _xf;
            SetControlText();
        }

        public void SetControlText()
        {
            //2012-03-31再加一个用于右键处理的部分
            if (this.jjType == common_file.common_jzzt.czzt_jz)//记帐
            {
                lbl_jz_gz.Text = "记帐客人";
                tB_gzdw.ReadOnly = false;
                tB_gzdw.Text = this.krxm;
                b_xydw.Visible = false;
                tB_gzdw.SelectAll();
                b_save.Text = "记账";
            }
            if (this.jjType == common_file.common_jzzt.czzt_gz)//挂帐
            {
                lbl_jz_gz.Text = "挂账单位";
                tB_gzdw.ReadOnly = true;
                b_xydw.Visible = true;
                if (!shyj)
                {
                    b_save.Text = "挂账";
                }
                else//是右键用的情况
                {
                    b_save.Text = "转成挂账";
                }
            }
        }

        private void b_xydw_Click(object sender, EventArgs e)
        {
            if (b_save.Text.Trim() == "挂账")
            { common_file.common_app.display_new_commonform_1("Yxydw", tB_gzdw, common_file.common_xydw.xyrx_gzdw); }
            if (b_save.Text.Trim() == "转成挂账")
            {
                common_file.common_app.display_new_commonform_1("Yxydw", tB_gzdw, common_file.common_xydw.xyrx_gzdw);
                get_jzzt = tB_gzdw.Text.Trim();
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            string s = common_file.common_app.get_failure;
            common_file.common_app.get_czsj();

            //右键菜单中用到的
            if (b_save.Text == "转成挂账")
            {
                if (tB_gzdw.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择挂账单位");
                    return;
                }
                    get_jzzt = tB_gzdw.Text;
                    if (common_zw.Check_gzed(common_zw.GetXyhByXxydw(tB_gzdw.Text.Trim()), tB_gzdw.Text.Trim(), decimal.Parse(xf), out info))
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, info);
                        return;
                    }
                    this.Close();
            }
            if(b_save.Text=="挂账")
            {
                if (tB_gzdw.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择挂帐单位");
                    return;
                }
                if (common_zw.Check_gzed(common_zw.GetXyhByXxydw(tB_gzdw.Text.Trim()), tB_gzdw.Text.Trim(), decimal.Parse(xf), out info))
                {
                    if (SzwclHelper_new.Fun_zw(lsbh, jjType, sk_tt, tB_gzdw.Text.Trim(), common_file.common_app.czy) == common_file.common_app.get_suc)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        if (jjType == common_file.common_jzzt.czzt_gz)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "挂账处理失败,请与系统管理员联系");
                        }
                    }
                    
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, info);
                    return;
                }
            }
            if (b_save.Text == "记账")
            {
                if (tB_gzdw.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请填写记帐信息");
                    return;
                }
                if (common_zw.Check_jzed(xf, out info))
                {
                    if (SzwclHelper_new.Fun_zw(lsbh, jjType, sk_tt, tB_gzdw.Text.Trim(), common_file.common_app.czy) == common_file.common_app.get_suc)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "记账处理失败,请与系统管理员联系");
                    }
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, info);
                    return;
                }
            }
             Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}