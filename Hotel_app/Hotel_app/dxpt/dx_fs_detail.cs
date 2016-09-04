using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.dxpt
{
    public partial class dx_fs_detail : Form
    {
        DataSet _ds;
        public dx_fs_detail()
        {
            InitializeComponent();
        }
        string get_sel_cond = "";
        private string GetSelCond()
        {
             get_sel_cond = "    1=1   ";
            if (tB_0.Text.Trim() != "")
            {
                get_sel_cond += "  and  userName  like '%" + tB_0.Text.Trim() + "%'  ";
            }
            if (tB_1.Text.Trim() != "")
            {
                get_sel_cond += "  and   phoneNo  like '%" + tB_1.Text.Trim().Replace("'", "-") + "%'  ";
            }
            if (tB_2.Text.Trim() != "")
            {
                get_sel_cond += "  and  information   like '%" + tB_2.Text.Trim().Replace("'", "-") + "%'  ";
            }
            if (tB_3.Text.Trim().Equals("成功"))
            {
                get_sel_cond += "  and  sendStatusCode='0'  ";
            }
            if (tB_3.Text.Trim().Equals("失败"))
            {
                get_sel_cond += "  and  sendStatusCode!='0'  ";
            }

            if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                get_sel_cond = get_sel_cond + " and (sendTime between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
            }
            return get_sel_cond;
        }
        private void dx_fs_detail_Load(object sender, EventArgs e)
        {
            RestControlText(sender, e);
            //dg_detail.AutoGenerateColumns = false;
        }
        private void RestControlText(object sender, EventArgs e)
        {
            tB_0.Text = tB_1.Text = tB_2.Text = tB_3.Text  = "";
            dT_ddsj_cs.Text = dT_ddsj_js.Text = common_file.common_app.cssj;
            tB_0.Focus();
        }
        private void dT_ddsj_cs_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetSelCond();
            if (get_sel_cond.Trim() != "")
            {
                BLL.Common B_common = new Hotel_app.BLL.Common();
                _ds = B_common.GetList(" select * from  dx_details ", get_sel_cond);
                if (_ds != null && _ds.Tables[0].Rows.Count > 0)
                {
                    dg_detail.AutoGenerateColumns = false;
                    dg_detail.DataSource = _ds.Tables[0].DefaultView;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_reSend_Click(object sender, EventArgs e)
        {
            if (dg_detail.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgvr_temp in dg_detail.Rows)
                {
                    DataGridViewCheckBoxCell chk = dgvr_temp.Cells[0] as DataGridViewCheckBoxCell;

                    if (bool.Parse(chk.EditingCellFormattedValue.ToString()))
                    {
                        int i = dgvr_temp.Index;
                        DataRowView dgr = dg_detail.Rows[i].DataBoundItem as DataRowView;
                        i = _ds.Tables[0].Rows.IndexOf(dgr.Row);//获取到ds中对应的行
                        if (!_ds.Tables[0].Rows[i]["sendStatusCode"].ToString().Equals("0"))//已经成功发送的不再重发
                        {
                            //进行重发
                            string krsj_0 = _ds.Tables[0].Rows[i]["phoneNo"].ToString();
                            string krxm_0 = _ds.Tables[0].Rows[i]["userName"].ToString();
                            string txt_sendContent = _ds.Tables[0].Rows[i]["information"].ToString();
                            common_dxpt.SendDxMuliti(krsj_0, krxm_0, txt_sendContent.Trim());
                        }
                    }
                }
            }
        }
    }
}