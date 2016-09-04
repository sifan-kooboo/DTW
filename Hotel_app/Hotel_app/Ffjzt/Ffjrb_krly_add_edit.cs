using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjrb_krly_add_edit : Form
    {
        Model.Ffjrb M_Ffjrb = new Hotel_app.Model.Ffjrb();
        BLL.Ffjrb B_Ffjrb = new Hotel_app.BLL.Ffjrb();
        Model.Ffjrb_krly M_Ffjrb_krly = new Hotel_app.Model.Ffjrb_krly();
        BLL.Ffjrb_krly B_Ffjrb_krly = new Hotel_app.BLL.Ffjrb_krly();

        public string fjrb_code = "";
        public string Hhyfj_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Ffjrb_krly_browse parent_form;//传递父窗体
        public Ffjrb_krly_add_edit()
        {
            InitializeComponent();
        }

        public Ffjrb_krly_add_edit(Ffjrb_krly_browse F_temp)
        {
            InitializeComponent();

            parent_form = F_temp;
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_krly.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人来源不能为空");
                tB_krly.Focus();
            }
            else if (tB_fjrb.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房间类型不能为空");
                tB_fjrb.Focus();

            }
            else if (tB_hyfj.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房价不能为空");
                tB_hyfj.Focus();
            }
            else if ((Maticsoft.Common.PageValidate.IsDecimal(tB_hyfj.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_hyfj.Text.Trim())) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的价格不是有效数值！");
                tB_hyfj.Focus();

            }
            else
            {
                save_new();
            }
            Cursor.Current = Cursors.Default;

        }


        public void save_new()
        {
            string strfjrb = this.tB_fjrb.Text;
            string strkrly = this.tB_krly.Text;
            //添加里判断有没有相同协议单位的房间类型相同的数据存在
            if (judge_add_edit == common_file.common_app.get_add)
            {

                if (B_Ffjrb_krly.GetModelList("fjrb='" + strfjrb + "' and krly='" + strkrly + "' ").Count > 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "已经存在相同数据了");
                    return;
                }
            }

            //修改里同样也要判断有没有相同的数据存在
            if (judge_add_edit == common_file.common_app.get_edit)
            {
                if (B_Ffjrb_krly.GetModelList("fjrb='" + strfjrb + "' and krly='" + strkrly + "' and id<>" + Hhyfj_id + "").Count > 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "已经存在相同数据了");
                    return;
                }
            }



            string url = common_file.common_app.service_url + "Ffjzt/Ffjzt_app.asmx";
            object[] args = new object[9];
            args[0] = Hhyfj_id;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = fjrb_code;
            args[4] = tB_fjrb.Text.Trim().Replace("'", "-");
            args[5] = tB_hyfj.Text.Trim().Replace("'", "-");
            args[6] = tB_krly.Text.Trim().Replace("'", "-");
            args[7] = judge_add_edit;
            args[8] = common_file.common_app.xxzs;

            Hotel_app.Server.Ffjzt.Ffjrb_krly Ffjrb_krly_services = new Hotel_app.Server.Ffjzt.Ffjrb_krly();
           string result= Ffjrb_krly_services.Ffjrb_krly_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args
[8].ToString());


            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Ffjrb_krly_add_edit", args);
            if (result== common_file.common_app.get_suc)
            {
               
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功");
                if (judge_add_edit == common_file.common_app.get_add)
                {
                    common_file.common_app.get_czsj();
                    parent_form.refresh_app();

   
                    tB_hyfj.Text = "";
         
                }
                else if (judge_add_edit == common_file.common_app.get_edit)
                {
                    parent_form.refresh_app();
                    this.Close();
                }




            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
            }



        }

        private void b_dfxm_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Ffjzt.Ffjrb_select Ffjrb_select_new = new Hotel_app.Ffjzt.Ffjrb_select();
            Ffjrb_select_new.Left = common_file.common_app.x();
            Ffjrb_select_new.Top = common_file.common_app.y();
            if (Ffjrb_select_new.ShowDialog() == DialogResult.OK)
            {
                tB_fjrb.Text = Ffjrb_select_new.get_fjrb;
                fjrb_code = Ffjrb_select_new.get_fjrb_code;
                tB_hyfj.Text = common_file.common_get_fjjg.get_fjjg(Ffjrb_select_new.get_fjrb, "", "", DateTime.Now, DateTime.Now, "", "");

                //tB_fjjg.Text = Ffjrb_select_new.get_sjjg;
            }
            Ffjrb_select_new.Dispose();
            tB_fjrb.Focus();
            Cursor.Current = Cursors.Default;
        }
        private void display_new_commonform_1(string judge_type_0, int left_0, int top_0, TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = common_file.common_app.x();
            X_common_one_new.Top = common_file.common_app.y();
            //X_common_one_new.StartPosition = FormStartPosition.CenterScreen;
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void b_krly_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xkrly", tB_krly.Left, tB_krly.Top + 150, tB_krly);
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}