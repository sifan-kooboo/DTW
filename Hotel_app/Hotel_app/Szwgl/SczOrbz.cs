using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class SczOrbz : Form
    {

        string old_id_app = "";//对哪条记录进行冲，补帐
        string id_app_new = "";//新生成的记录
        string jzbh = "";
        string lsbh = "";
        string xfdr = "";    
        string xfrb = "";
        string fjbh_ls = "";//冲补账的时候,如果没有任何备注信息，那么则把房号当成备注信息
        string ddsj = common_file.common_app.cssj;
        string lksj = common_file.common_app.cssj;

        string mxbh = "";//0502新增
        string CzOrBz = "";//是冲帐还是补帐
        DataSet ds_temp = null;
        BLL.Common B_common = new Hotel_app.BLL.Common();
        public SczOrbz()
        {
            InitializeComponent();
            initalApp(old_id_app,jzbh,lsbh, CzOrBz);
        }

        public void initalApp(string _id_app,string _jzbh,string _lsbh, string _CzOrBz)
        {
            old_id_app = _id_app;
            this.jzbh = _jzbh;
            CzOrBz = _CzOrBz;
            this.lsbh = _lsbh;
            this.Text = CzOrBz;

            if (old_id_app.Trim() != ""&&jzbh.Trim()=="")
            {
                ds_temp =B_common.GetList("select  *  from Szw_temp"," id_app='" + old_id_app+"'  and  yydh='"+common_file.common_app.yydh+"' and czy_temp='"+common_file.common_app.czy_GUID+"'");
            }
            if (old_id_app.Trim() != "" && jzbh.Trim() != "")
            {
                ds_temp = B_common.GetList("select  *  from Sjzmx ", " id_app='" + old_id_app + "'  and  jzbh='" + jzbh + "'  and yydh='" + common_file.common_app.yydh + "'");
            }
            if(ds_temp!=null&&ds_temp.Tables[0].Rows.Count>0)
            {
                xfdr = ds_temp.Tables[0].Rows[0]["xfdr"].ToString();
                xfrb = ds_temp.Tables[0].Rows[0]["xfrb"].ToString();
                mxbh = ds_temp.Tables[0].Rows[0]["mxbh"].ToString();
                tB_xfxm.Text = ds_temp.Tables[0].Rows[0]["xfxm"].ToString();
                tB_xfje.Text = ds_temp.Tables[0].Rows[0]["sjxfje"].ToString();
                if (old_id_app.Trim() != "" && jzbh.Trim() == "")
                {
                     DataSet  ds_0=B_common.GetList(" select * from View_Qskzd "," id>=0  "+common_file.common_app.yydh_select+" and  lsbh='"+lsbh+"'");
                    if(ds_0!=null&&ds_0.Tables[0].Rows.Count>0)
                    {
                        ddsj=ds_0.Tables[0].Rows[0]["ddsj"].ToString();
                        lksj=ds_0.Tables[0].Rows[0]["lksj"].ToString();
                        fjbh_ls = ds_0.Tables[0].Rows[0]["fjbh"].ToString();
                    }
                    else
                    {
                        ds_0 = B_common.GetList(" select * from View_Qttzd ", " id>=0  " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'");
                        if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                        {
                            ddsj = ds_0.Tables[0].Rows[0]["ddsj"].ToString();
                            lksj = ds_0.Tables[0].Rows[0]["lksj"].ToString();
                        }
                    }

                }
                if (old_id_app.Trim() != "" && jzbh.Trim() != "")
                {
                    DataSet ds_0 = B_common.GetList(" select * from Sjzzd ", " id>=0  " + common_file.common_app.yydh_select + " and  jzbh='" + jzbh + "'");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        ddsj = ds_0.Tables[0].Rows[0]["ddsj"].ToString();
                        lksj = ds_0.Tables[0].Rows[0]["tfsj"].ToString();
                        fjbh_ls = ds_0.Tables[0].Rows[0]["fjbh"].ToString();
                    }
                }
                tB_je.Text = "0.0";
                tB_sj.Text = DateTime.Now.ToString();
                tB_sl.Text = "0.0";
                tb_bz.Text = "";
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_xfxm.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请关闭此窗体，选择冲帐项目");
                return;
            }
          else
              if (((Maticsoft.Common.PageValidate.IsDecimal(tB_je.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_je.Text.Trim())) == false))
              {
                  common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的数量不是有效数值！");
                  tB_je.Focus();
                  tB_je.SelectAll(); return;
              }
              else
                  if (((Maticsoft.Common.PageValidate.IsDecimalSign(tB_sl.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumberSign(tB_sl.Text.Trim())) == false))
                  {
                      common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的数量不是有效数值！");
                      tB_sl.Focus();
                      tB_sl.SelectAll(); return;
                  }
            id_app_new = common_file.common_ddbh.ddbh("xfmx", "lsbhdate", "lsbhcounter", 6);
            Hotel_app.Server.Szwgl.Szwmx Szwmx_serverice = new Hotel_app.Server.Szwgl.Szwmx();

            string Result = Szwmx_serverice.Szwmx_add_edit("", "", old_id_app, common_file.common_app.yydh, common_file.common_app.qymc, id_app_new, DateTime.Parse(tB_sj.Text.Trim()).ToString("yyyy-MM-dd"), tB_sj.Text.Trim(), common_file.common_app.czy, xfdr, xfrb, tB_xfxm.Text.Trim().Replace("'", "-"), GetBzInfo(tb_bz.Text), CzOrBz, common_file.common_sswl.Round_sswl(double.Parse(tB_je.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString(), "", common_file.common_sswl.Round_sswl(double.Parse(tB_je.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString(), tB_sl.Text.Trim().Replace("'", "-"),
                common_file.common_app.czy_bc, CzOrBz, DateTime.Now.ToString(), common_file.common_app.syzd, common_file.common_app.get_add, common_file.common_app.xxzs, "0", "", "", mxbh, ddsj, lksj);
            if(Result.Equals(common_file.common_app.get_suc))
            {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
            }
            else
	{
        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败");
	}



            //string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
            //id_app_new = common_file.common_ddbh.ddbh("xfmx", "lsbhdate", "lsbhcounter", 6);
            //object[] args = new object[30];
            ////zd_id,sktt,old_id_app, yydh, qymc, id_app, xfrq

            //args[0] ="";
            //args[1] ="";
            //args[2] = old_id_app;  //要冲补帐的那条
            //args[3] = common_file.common_app.yydh;
            //args[4] = common_file.common_app.qymc;
            //args[5] = id_app_new;   //新生成的id_app
            ////xfrq, xfsj, czy
            //args[6] = DateTime.Parse(tB_sj.Text.Trim()).ToString("yyyy-MM-dd");   // DateTime.Now.ToString("yyyy-MM-dd");
            //args[7] = tB_sj.Text.Trim();
            //args[8] = common_file.common_app.czy;
            ////xfdr, xfrb, xfxm, xfbz, xfzy, xfje, yh, sjxfje, xfsl, czy_bc, czzt,
            //args[9] = xfdr;
            //args[10] = xfrb;
            //args[11] = tB_xfxm.Text.Trim().Replace("'", "-");
            //args[12] = GetBzInfo(tb_bz.Text);//tb_bz.Text.Trim().Replace("'", "-");
            //args[13] = CzOrBz;
            //args[14] = common_file.common_sswl.Round_sswl(double.Parse(tB_je.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
            //args[15] = "";
            //args[16] = common_file.common_sswl.Round_sswl(double.Parse(tB_je.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
            //args[17] = tB_sl.Text.Trim().Replace("'", "-");
            //args[18] = common_file.common_app.czy_bc;
            //args[19] = CzOrBz;//这里要根据主单的yddj的类型(预订，在住，记帐，挂帐）
            //args[20] = DateTime.Now.ToString();
            //args[21] = common_file.common_app.syzd;
            //args[22] = common_file.common_app.get_add;
            //args[23] = common_file.common_app.xxzs;
            //args[24] = "0";
            //args[25] = "";
            //args[26] = "";
            //args[27] = mxbh;
            //args[28] = ddsj;
            //args[29] = lksj;
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Szwmx_add_edit", args);
            //{
            //    if (result != null && result.ToString() == common_file.common_app.get_suc)
            //    {
            //        //common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功");
            //        this.DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            //    else
            //    {
            //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败");
            //    }
            //}




        }

        private void SetControlText()
        {
            this.Text = CzOrBz;
            if (this.CzOrBz == common_zw.zwcl_bz)
            {
                lbl_xm.Text = "补账项目";
                lbl_sj.Text = "补账时间";
                lbl_je_2.Text = "补账金额";
                lbl_sl.Text = "补账数量";
                lbl_bz.Text = "补账备注";
            }
        }

        private void tB_je_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void tB_sl_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);

        }

        private void SczOrbz_Load(object sender, EventArgs e)
        {
            tB_je.Focus();
        }

        private string GetBzInfo(string ls_bz)
        {
            if (ls_bz.Replace("'", "").Trim().Equals(""))
            {
                return fjbh_ls;
            }
            else
            {
                return tb_bz.Text.Trim().Replace("'", "-");
            }
        }
    }
}