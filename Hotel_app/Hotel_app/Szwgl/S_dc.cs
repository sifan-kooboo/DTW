using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class S_dc : Form
    {
        public S_dc()
        {
            InitializeComponent();
        }

        string xfxm="";
        string xfje="";
        string xfsj="";
        string id_app_old="";
        string id_app_new="";
        string union_lzbh_temp="";
        string  czzt="";
        private void b_save_Click(object sender, EventArgs e)
        {

            tB_xfxm.Text = xfxm;
            tB_xfje.Text = xfje;
            tB_sj.Text = xfsj;
            if (((Maticsoft.Common.PageValidate.IsDecimal(tB_fcje.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_fcje.Text.Trim())) == false))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "分拆金额填写不正确");
                return;
            }
            if (decimal.Parse(tB_fcje.Text.Trim()).Equals(0))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请填写分拆金额");
                return;
            }
            if(common_file.common_app.message_box_show_select(common_file.common_app.message_title,"你确定要分拆这条记录嘛?")==true)
            {

                decimal  je_need=decimal.Parse(tB_fcje.Text.Trim());
                decimal  je_last=decimal.Parse(tB_xfje.Text.Trim())-je_need;
                //执行分拆
                SfjczHelper.Fun_fj_chaizhang(id_app_old,id_app_new,union_lzbh_temp,je_need,je_last,czzt,DateTime.Now.ToString(),"2");
                this.DialogResult=DialogResult.OK;
                this.Close();
            }
        }

        private void S_dc_Load(object sender, EventArgs e)
        {
            tB_xfxm.Text=xfxm;
            tB_xfje.Text=xfje;
            tB_sj.Text=xfsj;
            tB_fcje.Text = "0.0";
            tb_bz.Text = "";
        }
    
        internal void inital(string _xfxm,string _xfje,string  _xfsj,string _id_app_old,string  _id_app_new,string  _union_lzbh_temp,string _czzt)
        {
            xfxm=_xfxm;
            xfje=_xfje;
            xfsj=_xfsj;
            id_app_new = _id_app_new;
            id_app_old=_id_app_old;
            union_lzbh_temp=_union_lzbh_temp;
            czzt=_czzt;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}