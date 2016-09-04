using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_zbmx_add_edit : Form
    {
        public string Xxfxr_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Xxfmx_zbmx_browse parent_form;
        public string Xxfxr_xrbh = "";//消费小类:bh|名称
        public string drbh = "";
        public string xfdr = "";
        public string xfxr = "";
        public string mxbh = "";



        public decimal xfje = 0;
        public decimal jjje = 0;



        public string xfmx = "";
        public string xrbh = "";
        public string lsbh = "";
        public string xftm = "";


        BLL.Xxfmx B_Xxfmx = new Hotel_app.BLL.Xxfmx();
        #region 自定义方法
        public Xxfmx_zbmx_add_edit(Xxfmx_zbmx_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
        }
        #endregion

        public Xxfmx_zbmx_add_edit()
        {

            InitializeComponent();
        }


        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_xfrb.Text.Trim() == "" || tB_xfxm.Text.Trim() == "" || tB_zbdj.Text.Trim() == "")
            {
                if (tB_xfrb.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择消费类别"); tB_xfrb.Focus();

                    return;
                }
                if (tB_xfxm.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择消费项目"); tB_xfxm.Focus();
                    return; 

                }
                if (tB_zbdj.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择消费项目"); tB_zbdj.Focus();
                    return;

                }

            }
            else
                if (((Maticsoft.Common.PageValidate.IsDecimalSign(tB_xfsl.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumberSign(tB_xfsl.Text.Trim())) == false))
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的数量不是有效数值！");
                    tB_xfsl.Focus();
                    tB_xfsl.SelectAll();
                }
                else
                {
                    SaveNew_xfmx();
                }


            Cursor.Current = Cursors.Default;


        }
        //保存主单
        private void SaveNew_xfmx()
        {
            //id, yydh, qymc, lsbh, lksj, czsj, czy, bz,
            //drbh, xfdr, xrbh,xfxr,xfmx, mxbh, xfsl, add_edit_delete, xxzs
            string zbsl = tB_xfsl.Text.Trim().Replace("'", "_");
            if (is_value(lsbh, mxbh, out Xxfxr_id))
            {
                judge_add_edit = common_file.common_app.get_edit;

            }

            //  id, yydh, qymc, lsbh, drbh, xfdr, xrbh, xfxr, xfmx, mxbh, xftm, zb_sj, zb_czy, zb_sl, zb_zt, add_edit_delete, xxzs
            string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
            object[] args = new object[18];
            args[0] = Xxfxr_id;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = lsbh;
            args[4] = drbh;
            args[5] = xfdr;
            args[6] = xrbh;
            args[7] = tB_xfrb.Text.Trim().Replace("'", "_");
            args[8] = tB_xfxm.Text.Trim().Replace("'", "_");
            args[9] = mxbh;
            args[10] = tB_xftm.Text.Trim().Replace("'", "_");
            args[11] = DateTime.Now.ToString();
            args[12] = common_file.common_app.czy;
            args[13] = zbsl;
            if (Convert.ToDecimal(zbsl) > 0)
            {
                args[14] = common_file.common_app.zb_zt_zj;

            }
            else
            {
                args[14] = common_file.common_app.zb_zt_kj;

            }
            args[15] = judge_add_edit;
            args[16] = common_file.common_app.xxzs;
            args[17] = tB_zbdj.Text.Trim();

            Hotel_app.Server.Xxtsz.Xxfmx_zbmx Xxfmx_zbmx_services = new Hotel_app.Server.Xxtsz.Xxfmx_zbmx();
            string result = Xxfmx_zbmx_services.Xxfmx_zbmx_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xxfmx_zbmx_add_edit", args);
            if (result== common_file.common_app.get_suc)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                if (judge_add_edit == common_file.common_app.get_add)
                {
                    parent_form.InitializeApp();
                    tB_xfxm.Text = "";
                    tB_mxbh.Text = "";
                    tB_xfsl.Text = "";
                    tB_xftm.Text = "";
                    tB_zjm.Text = "";
                    tB_xfrb.Text = "";
                    tB_xftm.Focus();
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



        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string GetDrbh(string xfdr)
        {
            string drbh = "";
            BLL.Xxfdr B_Xxfdr = new BLL.Xxfdr();
            Model.Xxfdr M_Xxfdr = new Model.Xxfdr();
            DataSet ds = B_Xxfdr.GetList("xfdr='" + xfdr + "'");

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



        public string get_xfdr(string xrbh_0, int type)
        {
            string xfdr_0 = "";
            BLL.Xxfxr B_Xxfxr = new Hotel_app.BLL.Xxfxr();
            DataSet DS_temp = B_Xxfmx.GetList("xrbh='" + xrbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (type == 1)
                {
                    xfdr_0 = DS_temp.Tables[0].Rows[0]["xfdr"].ToString();
                }
                else
                {
                    xfdr_0 = DS_temp.Tables[0].Rows[0]["drbh"].ToString();

                }

            }
            DS_temp.Dispose();
            return xfdr_0;

        }
        private void b_xslb_Click(object sender, EventArgs e)
        {
            Szwgl.Sxfrb F_Sxfrb = new Szwgl.Sxfrb();
            F_Sxfrb.Location = new Point(common_file.common_app.x(), common_file.common_app.y());
            if (F_Sxfrb.ShowDialog() == DialogResult.OK)
            {
                Xxfxr_xrbh = F_Sxfrb.get_xfxm_bh;// 格式:bh|名称
                if (Xxfxr_xrbh.Trim() != "")//小类编号
                {
                    string[] info = Xxfxr_xrbh.Split('|');
                    xrbh = (info[0].Split(':'))[1];
                    xfdr = get_xfdr(xrbh, 1);
                    drbh = get_xfdr(xrbh, 2);
                    tB_xfrb.Text = info[1];
                    tB_xfxm.Text = "";
                    tB_xftm.Text = "";
                    tB_zjm.Text = "";
                    tB_xfsl.Text = "1";
               
                    tB_xfxm.Focus();
                }
            }
        }

        private void btn_xfmx_select_Click(object sender, EventArgs e)
        {
            Szwgl.common_zw.display_new_commonform_1("Xxfmx",out xftm, out xrbh, out xfmx, btn_xfmx_select.Left, btn_xfmx_select.Top, xrbh);
            if (xrbh != "" && xfmx != "")
            {

                common_file.Common_lk.Get_xf_info(xrbh, xfmx, out xfdr, out xfxr, out mxbh, out xftm, out xfmx);
                tB_xfxm.Text = xfmx;
                tB_xfrb.Text = xfxr;
                tB_xfsl.Text = "1.0";
                tB_mxbh.Text = mxbh;
                tB_xftm.Text = xftm;



            }
        }

        private void tB_mxbh_Leave(object sender, EventArgs e)
        {
            if (tB_mxbh.Text.Trim() != "")
            {
                string strmxbh = this.tB_mxbh.Text;
                common_file.Common_lk.Getmxbh(strmxbh, "", out drbh, out xfdr, out xrbh, out xfxr, out xfmx, out xftm, out mxbh);
                mxbh = strmxbh;

            }
            else if (tB_xftm.Text.Trim() != "")
            {
                string strxftm = this.tB_xftm.Text;
                common_file.Common_lk.Getmxbh("", strxftm, out drbh, out xfdr, out xrbh, out xfxr, out xfmx, out xftm, out mxbh);
                tB_mxbh.Text = mxbh;
            }

            tB_xfrb.Text = xfxr;
            tB_xftm.Text = xftm;
            tB_xfxm.Text = xfmx;
            tB_xfsl.Text = "1.0";


        }
        public bool is_value(string strlsbh, string xrbh, out string Xxfxr_id)
        {
            Xxfxr_id = "";
            bool f = false;
            BLL.Xxfmx_zbmx B_lkmx = new Hotel_app.BLL.Xxfmx_zbmx();
            DataSet ds = B_lkmx.GetList("lsbh='" + strlsbh + "' and mxbh='" + xrbh + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                Xxfxr_id = ds.Tables[0].Rows[0]["id"].ToString();
                f = true;
            }
            return f;

        }
        public static int Get_Xxfmx_kcsl(string mxbh)
        {

            int kcsl = 0;
            BLL.Common B_Common = new BLL.Common();
            DataSet ds = B_Common.GetList("select * from Xxfmx", "mxbh='" + mxbh + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                kcsl = Convert.ToInt32(ds.Tables[0].Rows[0]["kcsl"].ToString());

            }
            return kcsl;
        }

        private void tB_xftm_TextChanged(object sender, EventArgs e)
        {
            string strxftm = this.tB_xftm.Text;
            if (strxftm != "" && strxftm != null)
            {
                GetXfmx("xftm='" + strxftm + "'", "xftm");
            }
            //else
            //{
                //common_file.common_app.Message_box_show(common_file.common_app.message_title, "请到消费项目里先添加该产品");

           // }



        }
        void GetXfmx(string strWhere, string type)
        {
            BLL.Xxfmx B_Xxfmx = new Hotel_app.BLL.Xxfmx();
            DataSet ds = B_Xxfmx.GetList(strWhere);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (type == "zjm")
                {
                    tB_xftm.Text = ds.Tables[0].Rows[0]["xftm"].ToString();
                }
                else
                {
                    tB_zjm.Text = ds.Tables[0].Rows[0]["zjm"].ToString();

                }

                tB_mxbh.Text = ds.Tables[0].Rows[0]["mxbh"].ToString();
                tB_xfrb.Text = ds.Tables[0].Rows[0]["xfxr"].ToString();
                tB_xfxm.Text = ds.Tables[0].Rows[0]["xfmx"].ToString();
                drbh = ds.Tables[0].Rows[0]["drbh"].ToString();
                xfdr = ds.Tables[0].Rows[0]["xfdr"].ToString();
                xrbh = ds.Tables[0].Rows[0]["xrbh"].ToString();
                mxbh = ds.Tables[0].Rows[0]["mxbh"].ToString();
                tB_xfsl.Text = "1";
                tB_xfsl.Focus();

            }

        }

        private void tB_xfsl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    b_save_Click(sender, e);
            //}
            //else
            //    if (e.KeyCode == Keys.Escape) { b_exit_Click(sender, e); }
        }

        private void tB_zjm_TextChanged(object sender, EventArgs e)
        {
            string strzjm = this.tB_zjm.Text;
            if (strzjm != "" && strzjm != null)
            {
                GetXfmx("zjm='" + strzjm + "'", "zjm");
            }
        }

        private void tB_xfsl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                b_save_Click(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { b_exit_Click(sender, e); }
        }

        private void Xxfmx_zbmx_add_edit_Load(object sender, EventArgs e)
        {
            if (judge_add_edit == common_file.common_app.get_edit)
            {
                tB_xftm.ReadOnly = true;
                tB_zjm.ReadOnly = true;
                tB_mxbh.ReadOnly = true;
                tB_xfrb.ReadOnly = true;
                tB_xfxm.ReadOnly = true;
            }
        }











    }
}