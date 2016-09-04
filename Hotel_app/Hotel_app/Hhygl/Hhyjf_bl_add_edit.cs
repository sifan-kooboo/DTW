using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    
    public partial class Hhyjf_bl_add_edit : Form
    {
        public string Hhyjfbl_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Hhyjf_bl_browse parent_form;
           #region 自定义方法
        public Hhyjf_bl_add_edit(Hhyjf_bl_browse Form_temp)
        {
            InitializeComponent();
            common_file.common_hy.Bindhyrx(cB_hyrx);
            Bindkrly();
            this.parent_form = Form_temp;
        }
        #endregion

        public Hhyjf_bl_add_edit()
        {
            InitializeComponent();
            common_file.common_hy.Bindhyrx(cB_hyrx);
            Bindkrly();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_jfbl.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，积分比率不能为空");
                tB_jfbl.Focus();
            }
           else if ((Maticsoft.Common.PageValidate.IsDecimal(tB_jfbl.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_jfbl.Text.Trim())) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的积分比率不是有效数字！");
                tB_jfbl.Focus();
            }
            else
            {
                Save_new();
 
            }
            Cursor.Current = Cursors.Default;

        }
        void Save_new()
        {
            //id,yydh,qymc,jbxs,hyrx,dfjf,is_top,is_select
            int judge_save = 3;//3保存，其余不保存
            
            if (judge_save == 3)
            {

                //id,yydh,qymc,krly,hyrx,jfbl,hyjfrx,is_top,is_select
                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                object[] args = new object[9];
                args[0] = Hhyjfbl_id;
                args[1] = common_file.common_app.yydh;
                args[2] = common_file.common_app.qymc;
                args[3] = cB_krly.Text.Trim().Replace("'", "-");
                args[4] = cB_hyrx.Text.Trim().Replace("'", "-");
                args[5] = tB_jfbl.Text.Trim().Replace("'", "-");
                args[6] = common_file.common_app.hyjfrx;
                args[7] = judge_add_edit;
                args[8] = common_file.common_app.xxzs;
                Hotel_app.Server.Hhygl.Hhyjf_bl Hhyjf_bl_services = new Hotel_app.Server.Hhygl.Hhyjf_bl();
                string result = Hhyjf_bl_services.Hhyjfbl_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString());
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjfbl_add_edit", args);
                if (result.ToString() == common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                    if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app(); tB_jfbl.Text = ""; tB_jfbl.Focus(); }
                    else if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        parent_form.refresh_app();
                        this.Close();
                    }

                }
                else
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

            }
        }
        private void Bindkrly()
        {
            cB_krly.Items.Clear();
            cB_hyrx.Items.Add(common_file.common_hy.hyrx_krly);
            Model.Xkrly M_krly = new Model.Xkrly();
            BLL.Xkrly B_krly = new BLL.Xkrly();
            List<Model.Xkrly> list = B_krly.GetModelList("");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cB_krly.Items.Add(list[i].krly.ToString());
                }
            }
        }
        

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Hhyjf_bl_add_edit_Load(object sender, EventArgs e)
        {
            cB_krly.Items.Add(common_file.common_hy.hyrx_krly);
        }

       
    }
}