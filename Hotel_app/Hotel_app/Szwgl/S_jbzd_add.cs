using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class S_jbzd_add : Form
    {

        public string jb_jk =common_zw.jb_jk_jb;

        BLL.Common B_Common = new Hotel_app.BLL.Common();
        DataSet DS_temp;
        public S_jbzd_add()
        {
            InitializeComponent();
            initialize_cb();
        }

        public void initialize_cb()
        {
            int i_0;
            DS_temp = B_Common.GetList("select * from Xsyzd", " id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    cB_syzd.Items.Add(DS_temp.Tables[0].Rows[i_0]["syzd"].ToString());
                }
            }
            DS_temp = B_Common.GetList("select * from Xbc", " id>=0 order by bc_order");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    cB_j_s_bc.Items.Add(DS_temp.Tables[0].Rows[i_0]["bc"].ToString());
                }
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            string url = common_file.common_app.service_url;
            if (cB_syzd.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title,"对不起，请先选择营业点！");
                cB_syzd.Focus();
            }
            else
                if (cB_j_s_bc.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，请先选择班次！");
                    cB_j_s_bc.Focus();
                }
                else
                {
                    url += "Szwgl/Szwgl_app.asmx";
                    object[] args = new object[12];
                    args[0] = common_file.common_app.yydh;
                    args[1] = common_file.common_app.qymc;
                    args[2] = cB_syzd.Text.Trim();
                    args[3] = tB_czy_jb.Text.Trim();
                    args[4] = tB_czy_sb.Text.Trim();
                    args[5] = cB_j_s_bc.Text.Trim();
                    args[6] = DateTime.Now;
                    args[7] = common_file.common_app.czy;
                    args[8] = tB_bz.Text.Trim();
                    args[9] =jb_jk;
                    args[10] = common_file.common_app.xxzs_zsvalue;
                    args[11] = common_file.common_app.czy_GUID;

                    Hotel_app.Server.Szwgl.S_jb_jk_fx S_jb_jk_fx_services = new Hotel_app.Server.Szwgl.S_jb_jk_fx();
                    string result = S_jb_jk_fx_services.add_jb_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(),DateTime.Parse(args[6].ToString()), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString());
                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "add_jb_app", args);
                    if (result!=null&&result== common_file.common_app.get_suc)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                    }

                } Cursor.Current = Cursors.Default;
        }

        private void cB_syzd_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.return_KeyPress(sender, e);
        }

        private void cB_j_s_bc_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.return_KeyPress(sender, e);
        }



    }
}