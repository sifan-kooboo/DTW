using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_add_edit : Form
    {
        public string Xxfxr_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Xxfmx_browse parent_form;
         #region 自定义方法
        public Xxfmx_add_edit(Xxfmx_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
        }
        #endregion

        public Xxfmx_add_edit()
        {

            InitializeComponent();
        }

        private bool get_judge_void_local()
        {
            common_file.common_app.get_czsj();
            bool bl_temp = false;
            if (common_file.common_app.get_judge_void(tB_mxbh, "X_mxbh", "对不起，消费编号不能为空！") == true)
            if (common_file.common_app.get_judge_void(tB_xfdr, "X_xfdr", "对不起，消费大类不能为空！") == true)
                if (common_file.common_app.get_judge_void(tB_xfxr, "X_xfxr", "对不起，消费小类不能为空！") == true)
                    if (common_file.common_app.get_judge_void(tB_xfmx, "X_xfmx", "对不起，消费名细不能为空！") == true)
                        if (common_file.common_app.get_judge_void(tB_xfje, "X_xfje", "对不起，消费金额不能为空！") == true)
                            if (common_file.common_app.get_judge_void(tB_xfgg, "X_xfgg", "对不起，规格不能为空！") == true)
                                if (common_file.common_app.get_judge_void(tB_jjje, "X_jjje", "对不起，进价金额不能为空！") == true)
                                    if (common_file.common_app.get_judge_void(tB_xftm, "X_xftm", "对不起，条码不能为空！") == true)
                                        if (common_file.common_app.get_judge_void(tB_xfcd, "X_xfcd", "对不起，生产地不能为空！") == true)
                                            if (common_file.common_app.get_judge_void(tB_xfdw, "X_xfdw", "对不起，生产商不能为空！") == true)
                                                if (common_file.common_app.get_judge_void(tB_xfjl, "X_jldw", "对不起，计量单位不能为空！") == true)

                                                                bl_temp = true;
            return bl_temp;

        }
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();

            if (get_judge_void_local() == true)//判断输入框是否为空
            {
                int judge_save = 3;//3保存，其余不保存
                judge_save = common_file.common_app.get_judge_repeat("Xxfmx", "mxbh", "消费编号已经存在了", tB_mxbh.Text, judge_add_edit, Xxfxr_id);
                if (judge_save == 3)
                {
                    judge_save = common_file.common_app.get_judge_repeat("Xxfmx", "xfmx", "对不起，消费名细原来就存在了！", tB_xfmx.Text, judge_add_edit, Xxfxr_id);
                    if ((Maticsoft.Common.PageValidate.IsDecimal(tB_xfje.Text.Trim())||Maticsoft.Common.PageValidate.IsNumber(tB_xfje.Text.Trim())) == false  )
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，售价进额所输入的金额不是有效数字！");
                        tB_xfje.Focus();
                        tB_xfje.SelectAll();
                        return;
                    }
                    if ((Maticsoft.Common.PageValidate.IsDecimal(tB_jjje.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_jjje.Text.Trim())) == false)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，进价金额所输入的进价金额不是有效数字！");
                        tB_jjje.Focus();
                        tB_jjje.SelectAll();
                        return;
 
                    }
                    if ((Maticsoft.Common.PageValidate.IsDecimal(tB_kcsl.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_kcsl.Text.Trim())) == false)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，库存数量所输入的进价金额不是有效数字！");
                        tB_kcsl.Focus();
                        tB_kcsl.SelectAll();
                        return;

                    }
                    else
                    {
                        SaveNew_xfmx();

                    }

                }
                //if (judge_save == 3)
                //{
                //    SaveNew_xfmx();

                //}
            }
            Cursor.Current = Cursors.Default;
          
            
        }
          //保存主单
        private void SaveNew_xfmx()
        {
            string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
            object[] args = new object[21];
            args[0] = Xxfxr_id;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = GetDrbh(tB_xfdr.Text);
            //xfgg,jjje,xftm,xfcd,xfdw,jldw,
            args[4] = tB_xfdr.Text.Trim().Replace("'", "_");
            args[5] = Getxrbh(tB_xfxr.Text);
            args[6] = tB_xfxr.Text.Trim().Replace("'", "_");
            args[7] = tB_mxbh.Text.Trim().Replace("'", "_");
            args[8] = tB_xfmx.Text.Trim().Replace("'", "_");
            args[9] = tB_xfje.Text.Trim().Replace("'", "_");
            args[10] = tB_zjm.Text.Trim().Replace("'", "_");
            args[11] = tB_xfgg.Text.Trim().Replace("'", "_");
            args[12] = tB_jjje.Text.Trim().Replace("'", "_");
            args[13] = tB_xftm.Text.Trim().Replace("'", "_");
            args[14] = tB_xfcd.Text.Trim().Replace("'", "_");
            args[15] = tB_xfdw.Text.Trim().Replace("'", "_");
            args[16] = tB_xfjl.Text.Trim().Replace("'", "_");

            args[17] = Cb_is_tj_kc.Checked;
            args[18] = tB_kcsl.Text.Trim().Replace("'", "_");
            args[19] = judge_add_edit;
            args[20] = common_file.common_app.xxzs;

            Hotel_app.Server.Xxtsz.Xxfmx Xxfmx_services = new Hotel_app.Server.Xxtsz.Xxfmx();
            string result = Xxfmx_services.Xxfmx_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(),bool.Parse(args[17].ToString()), args[18].ToString(), args[19].ToString(), args[20].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xxfmx_add_edit", args);
            if (result!=null&&result== common_file.common_app.get_suc)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                if (judge_add_edit == common_file.common_app.get_add)
                {
                    parent_form.refresh_app();
                    //tB_xfxr.Text = "";
                    //tB_xfdr.Text = "";
                    tB_mxbh.Focus();
                    tB_mxbh.Text = "";
                    tB_xfmx.Text = "";
                    tB_zjm.Text = "";
                    tB_xfje.Text = "";
                    tB_xfgg.Text = "";
                    tB_xftm.Text = "";
                    tB_xfcd.Text = "";
                    tB_xfdw.Text = "";
                    tB_xfjl.Text = "";
                    tB_jjje.Text = "";

                }
                else if (judge_add_edit == common_file.common_app.get_edit) 
                {
                    parent_form.InitializeApp(); 
                    this.Close(); 
                }

            }
            else
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
 
        }

        private void b_xsy_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xxfdr",tB_xfdr);
        }
        private void display_new_commonform_1(string judge_type_0,TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = common_file.common_app.x();
            X_common_one_new.Top = common_file.common_app.y();
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                tB_xfxr.Text = "";
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;

        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string GetDrbh(string xfdr)
        {
            string drbh = "";
            BLL.Xxfdr B_Xxfdr= new BLL.Xxfdr();
            Model.Xxfdr M_Xxfdr = new Model.Xxfdr();
            DataSet ds = B_Xxfdr.GetList("xfdr='"+xfdr+"'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                drbh = ds.Tables[0].Rows[0]["drbh"].ToString();
            }
            else
            {
                drbh = "";
            }

            return drbh;
        }
        public string Getxrbh(string xfxr)
        {
            string xrbh = "";
            BLL.Xxfxr B_Xxfdr = new BLL.Xxfxr();
            Model.Xxfxr M_Xxfdr = new Model.Xxfxr();
            DataSet ds = B_Xxfdr.GetList("xfxr='" + xfxr + "'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                xrbh = ds.Tables[0].Rows[0]["xrbh"].ToString();
            }
            else
            {
                xrbh = "";
            }

            return xrbh;
        }

        private void b_xfxr_Click(object sender, EventArgs e)
        {
            if (tB_xfdr.Text.Trim().Replace("'", "").Equals(""))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请先选择消费大类");
                return;
            }
            display_new_commonform_2("Xxfxr",tB_xfxr);
        }
        private void display_new_commonform_2(string judge_type_0,TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one(tB_xfdr.Text);
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = common_file.common_app.x();
            X_common_one_new.Top = common_file.common_app.y();
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {

                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;

        }

        private void Xxfmx_add_edit_Load(object sender, EventArgs e)
        {

        }

        private void Xxfmx_add_edit_Load_1(object sender, EventArgs e)
        {
            if (judge_add_edit == common_file.common_app.get_edit)
            {
                tB_kcsl.ReadOnly = true;
            }
        }
    }
}