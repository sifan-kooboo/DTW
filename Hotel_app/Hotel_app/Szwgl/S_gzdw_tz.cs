using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class S_gzdwz_tz : Form
    {
        public string jzbh = "";
        private string gzdw = "";
        private string xyh="";
        BLL.Common B_common = new Hotel_app.BLL.Common();
        public S_gzdwz_tz(string jzbh_tz)
        {
            this.jzbh = jzbh_tz;
            InitializeComponent();
            InitalApp(jzbh);
        }

        public void InitalApp(string  _jzbh)
        {
            jzbh = _jzbh;
            DataSet ds_temp_0 = B_common.GetList(" select  *  from  Sjzzd ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  jzbh='" + this.jzbh + "'");
            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
            {
                tB_gzdw_old.Text=ds_temp_0.Tables[0].Rows[0]["jzzt"].ToString();
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_gzdw_new.Text.Trim().Equals(tB_gzdw_old.Text.Trim()))//没有修改任何内容
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "你没有更改挂账单位！！！");
                return;
            }
            if (tB_gzdw_new.Text.Trim()=="")
            {
                common_file.common_app.get_czsj();
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择挂账单位");
                return;
            }
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你确定要调整当前帐务的挂账单位嘛？") == true)
            {
                common_file.common_app.get_czsj();
                decimal   xf =0;string info="";
                DataSet ds_0 = B_common.GetList(" select sum(sjxfje)  as   xfje  from  VIEW_S_gz_ye ", " yydh='" + common_file.common_app.yydh + "'   and  xfdr!='"+common_file.common_app.fkdr+"'   and  jzbh='" + this.jzbh + "'");
                if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                {
                    if (ds_0.Tables[0].Rows[0]["xfje"] != null && ds_0.Tables[0].Rows[0]["xfje"].ToString() != "")
                    {
                        xf =decimal.Parse(ds_0.Tables[0].Rows[0]["xfje"].ToString());
                    }
                }
                if (common_zw.Check_gzed(common_zw.GetXyhByXxydw(tB_gzdw_new.Text.Trim()), tB_gzdw_new.Text.Trim(), xf, out info))
                {

                    if (tB_gzdw_new.Text.Trim() != "")
                    {
                        xyh = common_zw.GetxyhByxydw(tB_gzdw_new.Text.Trim(), common_file.common_app.yydh, common_zw.xydw_gz);

                        StringBuilder sb = new StringBuilder();
                        sb.Append(" update Sjzzd set  jzzt='" + tB_gzdw_new.Text.Trim() + "', xyh='" + xyh + "',czsj='" + DateTime.Now.ToString() + "',czy='" + common_file.common_app.czy + "'   where  yydh='" + common_file.common_app.yydh + "' and jzbh='" + jzbh + "' ");
                        if (B_common.ExecuteSql(sb.ToString()) > 0)
                        {
                            common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "修改挂账单位", "原来的挂账单位为:" + tB_gzdw_old.Text.Trim(), "账务新的挂账单位为:" + tB_gzdw_new.Text.Trim(), DateTime.Now);
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "修改账务的挂账单位成功！");
                            this.DialogResult = DialogResult.OK;
                        }
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

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_gzdw_Click(object sender, EventArgs e)
        {
            common_file.common_app.display_new_commonform_1("Yxydw", tB_gzdw_new,"挂账单位");
        }
    }
}