using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Spzcz_tz : Form
    {
       public   string id_app= "";//平帐收款项的id_app
        public string jzbh = "";
        private string fkfs = "";
        private string xfbz = "";
        private decimal  je_pzsk = 0;
        BLL.Common B_common = new Hotel_app.BLL.Common();
        public Spzcz_tz()
        {
            InitializeComponent();
            InitalApp(id_app,jzbh);
        }

        public void InitalApp(string _id_app,string  _jzbh)
        {
            id_app = _id_app;
            jzbh = _jzbh;

            DataSet ds_temp_0 = B_common.GetList(" select  *  from  Sjzmx ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  id_app='" + id_app + "'");
            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
            {
                tB_pzdh.Text=ds_temp_0.Tables[0].Rows[0]["sjxfje"].ToString();
                tB_fkfs.Text = ds_temp_0.Tables[0].Rows[0]["fkfs"].ToString();
                fkfs = ds_temp_0.Tables[0].Rows[0]["fkfs"].ToString();
                xfbz = ds_temp_0.Tables[0].Rows[0]["xfbz"].ToString();
                tB_bz.Text = ds_temp_0.Tables[0].Rows[0]["xfbz"].ToString();
                je_pzsk = decimal.Parse(ds_temp_0.Tables[0].Rows[0]["sjxfje"].ToString());
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            if (((Maticsoft.Common.PageValidate.IsDecimalSign(tB_pzdh.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumberSign(tB_pzdh.Text.Trim())) == false))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，当前的输入不是有效的数值！");
                tB_pzdh.Focus();
                return;
            }
            if (je_pzsk <= 0)
            {
                if ((decimal.Parse(tB_pzdh.Text.Trim())-je_pzsk<0)||decimal.Parse(tB_pzdh.Text.Trim())>0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "调整的金额不能大于当前的金额");
                    return;
                }
            }
            if (je_pzsk > 0)
            {
                if ((decimal.Parse(tB_pzdh.Text.Trim()) - je_pzsk > 0) || decimal.Parse(tB_pzdh.Text.Trim()) <0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "调整的金额不能大于当前的金额");
                    return;
                }
            }

            if (tB_bz.Text.Trim().Equals(xfbz) && tB_fkfs.Text.Trim().Equals(fkfs) && (decimal.Parse(tB_pzdh.Text.Trim()) - je_pzsk== 0))//没有修改任何内容
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "你没有更改任何内容");
                return;
            }
                common_file.common_app.get_czsj();
                string id_app_old_xt = "";
                string id_app_new = "";
                id_app_old_xt = common_file.common_ddbh.ddbh("pztz", "lsbhdate", "lsbhcounter", 6);
                id_app_new = common_file.common_ddbh.ddbh("pztz", "lsbhdate", "lsbhcounter", 6);

               
             
                //id,yydh,qymc,id_app,jzbh,,lsbh,krxm,fjrb,fjbh,sktt,
                string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                object[] args = new object[30];
                args[0] ="";
                args[1] = common_file.common_app.yydh;
                args[2] = common_file.common_app.qymc;
                args[3] = id_app;
                args[4] = jzbh;//初始jzbh为空
                args[5] = id_app_old_xt;
                args[6] = id_app_new;
                args[7] = tB_pzdh.Text.Trim();
                args[8] = "";
                args[9] = "";
                //xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy
                args[10] = DateTime.Now.ToString("yyyy-MM-dd");
                args[11] = DateTime.Now.ToString();
                args[12] = common_file.common_app.czy;
                args[13] = common_file.common_app.fkdr;//这里是找出节点的付款大类
                args[14] = common_file.common_app.dj_pzsk;
                args[15] = common_file.common_app.dj_pzsk;
                args[16] = tB_bz.Text.Trim();
                args[17] = common_file.common_app.dj_pzsk;
                args[18] = "";
                args[19] = "";
                args[20] = "";
                args[21] = "1";
                args[22] = common_file.common_app.czy_bc;
                args[23] = "";
                //czsj, syzd, is_visible, add_edit_delete, xxzs,jjje
                args[24] = DateTime.Now.ToString();
                args[25] = common_file.common_app.syzd;
                args[26] = common_file.common_app.get_edit;
                args[27] = common_file.common_app.xxzs;
                args[28] = tB_fkfs.Text.Trim();
                args[29] = common_file.common_app.czy_GUID;
                Hotel_app.Server.Szwgl.Szw_jzOrgzOrSZ Szw_jzOrgzOrSZ_services = new Hotel_app.Server.Szwgl.Szw_jzOrgzOrSZ();
                string result = Szw_jzOrgzOrSZ_services.Sjzmx_pz(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(),
               args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString());
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Fun_PZ", args);
                if (result != null && result == common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "修改平帐收款的付款方式成功");
                    this.DialogResult = DialogResult.OK;
                }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_fkfs_Click(object sender, EventArgs e)
        {
            common_file.common_app.display_new_commonform_1("Xfkfs", tB_fkfs, common_file.common_app.dj_ysq);
        }
    }
}