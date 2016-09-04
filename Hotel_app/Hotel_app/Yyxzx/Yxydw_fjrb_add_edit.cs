using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yyxzx
{
    public partial class Yxydw_fjrb_add_edit : Form
    {
        BLL.Yxydw_fjrb B_Yxydw_fjrb = new Hotel_app.BLL.Yxydw_fjrb();
        Model.Yxydw_fjrb M_Yxydw_fjrb = new Hotel_app.Model.Yxydw_fjrb();

        public string xyh = "";
        public string fjrb_code = "";
        public string Hhyfj_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Yxydw_fjrb_browse parent_form;//传递父窗体
        public Yxydw_browse parent_form2;
        public Yxydw_fjrb_add_edit()
        {
            InitializeComponent();
        }
        public Yxydw_fjrb_add_edit(Yxydw_fjrb_browse F_temp)
        {
            InitializeComponent();

            parent_form = F_temp;
        }


        public Yxydw_fjrb_add_edit(Yxydw_browse F_temp)
        {
            InitializeComponent();

            parent_form2 = F_temp;
        }




        private void b_krly_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Yyxzx.Yxydw_select Yxydw_select_new = new Hotel_app.Yyxzx.Yxydw_select();
            Yxydw_select_new.Left = common_file.common_app.x();
            Yxydw_select_new.Top = common_file.common_app.y();
            if (Yxydw_select_new.ShowDialog() == DialogResult.OK)
            {
                tB_xydw.Text = Yxydw_select_new.get_xydw;
                xyh = Yxydw_select_new.get_xyh;
            }
            Yxydw_select_new.Dispose();
            tB_xydw.Focus();
            Cursor.Current = Cursors.Default;
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
                tB_hyfj.Text = common_file.common_get_fjjg.get_fjjg(Ffjrb_select_new.get_fjrb,"","",DateTime.Now,DateTime.Now,"","");
                //(string fjrb, string krly, string xyh, DateTime ddsj, DateTime lksj,string hykh,string hyrx)
                //tB_fjjg.Text = Ffjrb_select_new.get_sjjg;
            }
            Ffjrb_select_new.Dispose();
            tB_fjrb.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_xydw.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，协议单位不能为空");
                tB_xydw.Focus();
            }
            else if (tB_fjrb.Text == "")
            {
                common_file.common_app.get_czsj();

                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房间类型不能为空");
                tB_fjrb.Focus();

            }
            else if (tB_hyfj.Text == "")
            {
                common_file.common_app.get_czsj();

                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房价不能为空");
                tB_hyfj.Focus();
            }
            else if ((Maticsoft.Common.PageValidate.IsDecimal(tB_hyfj.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_hyfj.Text.Trim())) == false)
            {
                common_file.common_app.get_czsj();

                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的价格不是有效数值！");
                tB_hyfj.Focus();

            }
            else
            {
                common_file.common_app.get_czsj();


                save_new();
            }
            Cursor.Current = Cursors.Default;

        }


        public void save_new()
        {

            //添加里判断有没有相同协议单位的房间类型相同的数据存在
            if (judge_add_edit == common_file.common_app.get_add)
            {
                common_file.common_app.get_czsj();

                if (B_Yxydw_fjrb.GetModelList("fjrb='" + tB_fjrb.Text + "' and xyh='" + xyh + "' ").Count > 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "已经存在相同数据了");
                    return;
                }
                Cursor.Current = Cursors.Default;

            }

            //修改里同样也要判断有没有相同的数据存在
            if (judge_add_edit == common_file.common_app.get_edit)
            {
                if (B_Yxydw_fjrb.GetModelList("fjrb='" + tB_fjrb.Text + "' and xyh='" + xyh + "' and id<>" + Hhyfj_id + "").Count > 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "已经存在相同数据了");
                    return;
                }
            }
            common_file.common_app.get_czsj();


            string url = common_file.common_app.service_url + "Yyxzx/Yyxzx_app.asmx";
            object[] args = new object[10];
            args[0] = Hhyfj_id;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = fjrb_code;
            args[4] = tB_fjrb.Text.Trim().Replace("'", "-");
            args[5] = tB_hyfj.Text.Trim().Replace("'", "-");
            args[6] = xyh;
            args[7] = tB_xydw.Text.Trim().Replace("'", "-");
            args[8] = judge_add_edit;
            args[9] = common_file.common_app.xxzs;

            Hotel_app.Server.Yyxzx.Yxydw_fjrb Yxydw_fjrb_services = new Hotel_app.Server.Yyxzx.Yxydw_fjrb();
            string result = Yxydw_fjrb_services.Yxydw_fjrb_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Yxydw_fjrb_add_edit", args);
            if (result== common_file.common_app.get_suc)
            {
                try
                {
                    common_file.common_app.get_czsj();

                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功");
                    if (judge_add_edit == common_file.common_app.get_add)
                    {

                        parent_form.refresh_app();
                        tB_fjrb.Text = "";
                        tB_hyfj.Text = "";
                        //tB_xydw.Text = "";
                    }
                    else if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        common_file.common_app.get_czsj();

                        parent_form.refresh_app();
                        this.Close();
                    }
                }
                catch
                { }
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
            }

            Cursor.Current = Cursors.Default;


        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}