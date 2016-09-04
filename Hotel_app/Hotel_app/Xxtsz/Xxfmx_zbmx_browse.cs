using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_zbmx_browse : Form
    {
        public int dg_count = 0;//记录初期加载行数
        BLL.Xxfmx_zbmx B_Xxfmx_zbmx = new BLL.Xxfmx_zbmx();
        Model.Xxfmx_zbmx M_Xxfmx_zbmx = new Model.Xxfmx_zbmx();
        public Xxfmx_zbzd_browse parent_form;
        DataSet DS_Xxfmx;
        public string strlsbh = "";
        public string sel_condition = "";
        public Xxfmx_zbmx_browse(Xxfmx_zbzd_browse Form_temp,string lsbh)
        {
            InitializeComponent();
            strlsbh = lsbh;
            InitializeApp();
            this.parent_form = Form_temp;
            boolshsh(lsbh);
        }
        public void InitializeApp()
        {

            DS_Xxfmx = B_Xxfmx_zbmx.GetList("id>=0" + common_file.common_app.yydh_select + " and lsbh='"+strlsbh+"' order by id");
            bindingSource1.DataSource = DS_Xxfmx.Tables[0];
            dg_count = DS_Xxfmx.Tables[0].Rows.Count;
            this.dg_xfmx_lkmx.AutoGenerateColumns = false;
        }
        public void boolshsh(string lsbhsh)
        {
            if (Getshsh(lsbhsh))
            {
                this.b_new.Enabled=false;
                this.b_delete.Enabled = false;
                this.b_sh.Enabled = false;
                
                
               
            }
        }
        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xxfmx_zbmx_add_edit Xxfmx_zbmx_add_edit_new = new Xxfmx_zbmx_add_edit(this);
            Xxfmx_zbmx_add_edit_new.lsbh = strlsbh;
            Xxfmx_zbmx_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
            Xxfmx_zbmx_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            if (dg_xfmx_lkmx.CurrentRow != null)
            {
                int i = dg_xfmx_lkmx.CurrentRow.Index;
                if (DS_Xxfmx.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xxfmx_zbmx_add_edit Xxfmx_zbmx_add_edit_new = new Xxfmx_zbmx_add_edit(this);
                    //id, yydh, qymc, lsbh, lksj, czsj, czy, bz,
                    //drbh, xfdr, xrbh,xfxr,xfmx, mxbh, xfsl, add_edit_delete, xxzs
                    Xxfmx_zbmx_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    Xxfmx_zbmx_add_edit_new.judge_add_edit = common_file.common_app.get_edit;

                    string strlsbhzd = DS_Xxfmx.Tables[0].Rows[i]["lsbh"].ToString();
                    Xxfmx_zbmx_add_edit_new.Xxfxr_id = DS_Xxfmx.Tables[0].Rows[i]["id"].ToString();

                    Xxfmx_zbmx_add_edit_new.tB_xfrb.Text = DS_Xxfmx.Tables[0].Rows[i]["xfxr"].ToString();
                    Xxfmx_zbmx_add_edit_new.tB_xfxm.Text = DS_Xxfmx.Tables[0].Rows[i]["xfmx"].ToString();


                    if (Getshsh(strlsbhzd))
                    {
                        Xxfmx_zbmx_add_edit_new.tB_xfsl.Enabled = false;
                        Xxfmx_zbmx_add_edit_new.b_save.Enabled = false;
                    }
                    Xxfmx_zbmx_add_edit_new.lsbh = strlsbhzd;
                    Xxfmx_zbmx_add_edit_new.xrbh = DS_Xxfmx.Tables[0].Rows[i]["xrbh"].ToString();
                    Xxfmx_zbmx_add_edit_new.drbh = DS_Xxfmx.Tables[0].Rows[i]["drbh"].ToString();
                    Xxfmx_zbmx_add_edit_new.xfdr = DS_Xxfmx.Tables[0].Rows[i]["xfdr"].ToString();
                    Xxfmx_zbmx_add_edit_new.mxbh = DS_Xxfmx.Tables[0].Rows[i]["mxbh"].ToString();
                    Xxfmx_zbmx_add_edit_new.xftm = DS_Xxfmx.Tables[0].Rows[i]["xftm"].ToString();
                    Xxfmx_zbmx_add_edit_new.tB_xftm.Text = DS_Xxfmx.Tables[0].Rows[i]["xftm"].ToString();
                    Xxfmx_zbmx_add_edit_new.tB_mxbh.Text = DS_Xxfmx.Tables[0].Rows[i]["mxbh"].ToString();


                    //判断下主单是否审核，如果审核了就不能修改
                    Xxfmx_zbmx_add_edit_new.tB_xfsl.Text = DS_Xxfmx.Tables[0].Rows[i]["zb_sl"].ToString();
                    Xxfmx_zbmx_add_edit_new.b_xslb.Visible = false;
                    Xxfmx_zbmx_add_edit_new.btn_xfmx_select.Visible = false;
                  
                    Xxfmx_zbmx_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }
        //根据lsbh查询是不是审核主单
        public bool Getshsh(string lsbhzd)
        {
            bool sh_sh = false;
            string issh = common_file.common_app.is_wsh;
            BLL.Xxfmx_zbzd B_Xxfmx_zbzd = new BLL.Xxfmx_zbzd();
            Model.Xxfmx_zbzd M_Xxfmx_zbzd = new Model.Xxfmx_zbzd();
            DataSet ds = B_Xxfmx_zbzd.GetList("lsbh='" + lsbhzd + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                issh = ds.Tables[0].Rows[0]["is_sh"].ToString();
                if (issh == common_file.common_app.is_sh)
                {
                    sh_sh = true;
                }
            }


            return sh_sh;
        }


        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_xfmx_lkmx.CurrentRow != null)
            {
                int i = dg_xfmx_lkmx.CurrentRow.Index;
                DataRowView dgr = dg_xfmx_lkmx.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Xxfmx.Tables[0].Rows.IndexOf(dgr.Row);
                if (DS_Xxfmx.Tables[0].Rows[i]["id"].ToString() != "")
                {

                    string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                    object[] args = new object[18];
                    args[0] = DS_Xxfmx.Tables[0].Rows[i]["id"].ToString();
                    args[1] = common_file.common_app.yydh;
                    args[2] = common_file.common_app.qymc;
                    args[3] = "";
                    args[4] = "";
                    args[5] = "";
                    args[6] = "";
                    args[7] = "";
                    args[8] = DS_Xxfmx.Tables[0].Rows[i]["mxbh"].ToString(); ;
                    args[9] = "";
                    args[10] = "";
                    args[11] = "";
                    args[12] = "";
                    args[13] = DS_Xxfmx.Tables[0].Rows[i]["zb_sl"].ToString(); ;
                    args[14] = "";
                    args[15] = common_file.common_app.get_delete;
                    args[16] = common_file.common_app.xxzs;
                    args[17] = "0";
                    Hotel_app.Server.Xxtsz.Xxfmx_zbmx Xxfmx_zbmx_services = new Hotel_app.Server.Xxtsz.Xxfmx_zbmx();
                    string result = Xxfmx_zbmx_services.Xxfmx_zbmx_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(),args[17].ToString());
                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xxfmx_zbmx_add_edit", args);
                    if (result!=null&&result== common_file.common_app.get_suc)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功！");
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除不成功！");
                    }
                }
                  InitializeApp();
                }
            Cursor.Current = Cursors.Default;
        }

        private void tB_select_TextChanged(object sender, EventArgs e)
        {
            string strSelect=this.tB_select.Text.Trim();
            string strSql = "id>=0" + common_file.common_app.yydh_select + " and lsbh='" + strlsbh + "'";
            strSql += " and (drbh like '%" + strSelect + "%' or xfdr like '%" + strSelect + "%' or xrbh like '%" + strSelect + "%' or xfxr like '%" + strSelect + "%' or mxbh like '%" + strSelect + "%' or xfmx like '%" + strSelect + "%' or xftm like '%" + strSelect + "%'  )";
            DS_Xxfmx = B_Xxfmx_zbmx.GetList(strSql);
            bindingSource1.DataSource = DS_Xxfmx.Tables[0];
            dg_count = DS_Xxfmx.Tables[0].Rows.Count;
            this.dg_xfmx_lkmx.AutoGenerateColumns = false;

        }

        private void b_sh_Click(object sender, EventArgs e)
        {
            string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
            object[] args = new object[2];
            args[0] = strlsbh;
            args[1] = common_file.common_app.czy;

            Hotel_app.Server.Xxtsz.Xxfmx_zbzd Xxfmx_zbzd_services = new Hotel_app.Server.Xxtsz.Xxfmx_zbzd();
            string result = Xxfmx_zbzd_services.Update_issh(args[0].ToString(), args[1].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url,"Update_issh", args);
            if (result== common_file.common_app.get_suc)
            {
                parent_form.InitializeApp();
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "审核成功！");

            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "审核不成功！");

            }
        }
      
    }
}