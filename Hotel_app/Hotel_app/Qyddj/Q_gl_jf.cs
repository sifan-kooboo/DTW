using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_gl_jf : Form
    {
        public Q_gl_jf()
        {
            InitializeComponent();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            //if (tb_jfsx.Text.Trim()!= "")
           // { common_file.common_app.Message_box_show(common_file.common_app.message_title, "请填写积分上限的值!"); return; }
            common_file.common_app.get_czsj();
            if (dT_qssj.Value > dT_jssj.Value)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "起始时间不能大于结束时间,请正确选择时间范围");
                return;
            }
            if (DateTime.Parse(dT_qssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dT_jssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                common_file.common_app.get_czsj();
                Getlskr(dT_qssj.Text, dT_jssj.Text, tb_jfsx.Text.Trim(), tb_krxm.Text.Trim());
            }
            else
            {
                common_file.common_app.get_czsj();
                Getlskr("1800-01-01", "9999-01-01", tb_jfsx.Text.Trim(), tb_krxm.Text.Trim());
            }
            Cursor.Current = Cursors.Default;
        }

        private void tb_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void Q_gl_jf_Load(object sender, EventArgs e)
        {
            dT_jssj.Text = common_file.common_app.cssj;
            dT_qssj.Text = common_file.common_app.cssj;
            tb_jfsx.Text = "";
            tb_krxm.Text = "";

        }


        private void Getlskr(string time_start, string time_end, string jfsx,string krxm)
        {
            DataSet ds_lskr = null;
            string sql_con = "";
            float costTotal = 0;
            if (jfsx.Trim() == "")
            {
                costTotal = 0;
            }
            else
            {
                costTotal = float.Parse(tb_jfsx.Text.Trim());
            }
            sql_con=" id>=0   and  yydh='" + common_file.common_app.yydh + "'  and  xfdr='"+Szwgl.common_zw.dr_ff+"'  and zjhm!='' and  xfsj>='" + time_start + "'  and  xfsj<='" + time_end + "'  and krxm like '%"+krxm+"%'    group by  krxm,yxzj,zjhm  having sum(sjxfje)>="+costTotal;

            BLL.Common B_common = new Hotel_app.BLL.Common();
            ds_lskr = B_common.GetList("select krxm,yxzj,zjhm,sum(sjxfje) as totalCost  from View_ssyxfmx_lskr_mx ", sql_con);
            if (ds_lskr != null && ds_lskr.Tables[0].Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                Q_lskr_xf Q_lskr_xf_new = new Q_lskr_xf(ds_lskr,time_start,time_end);
                Q_lskr_xf_new.StartPosition = FormStartPosition.CenterScreen;
                Q_lskr_xf_new.MdiParent = common_file.common_form.Fmain_new;
                Q_lskr_xf_new.Show();
                
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,没有任何会员的历史消费额达到当前的设置的消费上限值!");
            }
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dT_qssj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }

        private void dT_jssj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }
    }
}