using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;

namespace Hotel_app.Hhygl
{
    public partial class Hhygl_hysj : Form
    {
        Model.Hhyjb M_hyjb = new Model.Hhyjb();
        BLL.Hhyjb B_hyjb = new BLL.Hhyjb();
        public  Hhygl_browse parent_form;
        public string Hhygl_id = "";
        public string Hhyjfdf_id = "";
        public string strhykh = "";
        public decimal sjjf = 0;
        public string judge_add_edit = common_file.common_app.get_add;
        public Hhygl_hysj()
        {
            InitializeComponent();
            common_file.common_hy.Bindhyrx(cB_hyrx);
        }
        public Hhygl_hysj(Hhygl_browse Form_temp)
        {
            InitializeComponent();
            common_file.common_hy.Bindhyrx(cB_hyrx);
            this.parent_form = Form_temp;
        }
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            string strsjrx = this.cB_hyrx.Text.Trim();//升级类型
            string strhyrx = this.tB_hyrx.Text.Trim();//会员类型
            int statejbxs = Getjbxs(strhyrx);  //会员系数
            int Maxjbxs = Getjbxs(strsjrx);    //升级会员系数
            decimal strhyjf = Convert.ToDecimal(tB_hyjf.Text.Trim());//会员现在积分 

            if (strsjrx == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，请选择升级类型");
                cB_hyrx.Focus();
            }
            else
            {
                //升级类型不能相同
                if (strsjrx == tB_hyrx.Text)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，升级类型不能与现在类型相同");
                    cB_hyrx.Focus();

                }
               else if (statejbxs>Maxjbxs)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，高级别不能升级为低级别");
                    cB_hyrx.Focus();

                }
                else
                {

                    sjjf = getdfjf(statejbxs,Maxjbxs);//读出兑换积分  
                    if (strhyjf < sjjf)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title,"对不起，您目前的积分还不够升级到"+strsjrx+"。");
                        cB_hyrx.Focus();

                    }
                    else if (strhyjf >= sjjf)
                    {
                        if (save_new() == common_file.common_app.get_suc) //添加到会员兑换记录里
                        {
                            decimal hysxjf = strhyjf - sjjf;
                            //strhykh = this.tB_hykh.Text;
                            string strSql = " update Hhygl set hyrx='" + strsjrx + "',hyjf=" + hysxjf + ",shxg=1,xgsj=getdate()  where hykh='" + strhykh + "'";
                            int isok = DbHelperSQL.ExecuteSql(strSql);
                            if (isok > 0)
                            {

                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "恭喜您，成为" + strsjrx + "会员。");
                                common_file.common_hy.Hhygl_browse_new.refresh_app();
                                common_file.common_hy.Hhygl_browse_new.open_record();
                                cB_hyrx.Text = "";
                                cB_hyrx.Focus();

                            }
                        }


 
                    }
                }

            }
            Cursor.Current = Cursors.Default;

        }
        //添加到会员兑换记录里
        public string  save_new()
        {



                string lsbh_df = common_file.common_ddbh.ddbh("df", "lsbhdfdate", "lsbhdfcounter", 6);
                //common_file.common_app.Message_box_show(common_file.common_app.message_title,lsbh_df);
                string s = common_file.common_app.get_failure;
                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                object[] args = new object[13];
                args[0] = Hhyjfdf_id;
                args[1] = common_file.common_app.yydh;
                args[2] = common_file.common_app.qymc;
                args[3] = strhykh;
                args[4] = tB_hykh_bz.Text.Trim().Replace("'", "-");
                args[5] = tB_krxm.Text.Trim().Replace("'", "-");
                args[6] = sjjf.ToString();
                args[7] = "升级"+cB_hyrx.Text;
                args[8] = "1";
                args[9] = lsbh_df;
                args[10] = common_file.common_hy.GetHygl(tB_hykh_bz.Text);
                args[11] = judge_add_edit;
                args[12] = common_file.common_app.xxzs;

                Hotel_app.Server.Hhygl.Hhyjf_df Hhyjf_df_services = new Hotel_app.Server.Hhygl.Hhyjf_df();
                string result=Hhyjf_df_services.Hhyjfdf_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString());
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjfdf_add_edit", args);
                if (result== common_file.common_app.get_suc)
                {
                    common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "会员升级", "" + Hhyjfdf_id + "", "会员卡号" + tB_hykh_bz.Text + "名称:" + tB_krxm.Text + "升级名称：" + cB_hyrx.Text + "", DateTime.Now);

                    s = common_file.common_app.get_suc;


                }
                return s;
                    
  
        }
       

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //根据类型读出系数
        public int Getjbxs(string hyrx)
        {
            int s = 0;

            DataSet ds_rx = B_hyjb.GetList("id>=0 and  yydh='" + common_file.common_app.yydh + "' and hyrx='" + hyrx + "'");
            if (ds_rx.Tables[0].Rows.Count > 0)
            {
                s = int.Parse(ds_rx.Tables[0].Rows[0]["jbxs"].ToString());
            }
            return s;

        }

        //根据系数读出兑换积分
        public decimal getjf(int xs)
        {
            decimal s = 0;

            DataSet ds_xs = B_hyjb.GetList("id>=0 and  yydh='" + common_file.common_app.yydh + "' and jbxs=" + xs);
            if (ds_xs.Tables[0].Rows.Count > 0)
            {
                s = decimal.Parse(ds_xs.Tables[0].Rows[0]["dfjf"].ToString());
            }
            return s;

        }
        //取出升级兑换总积分
        public decimal getdfjf(int stxs,int endxs)
        {
            decimal s = 0;

            if (endxs > stxs)
            {
                if (stxs + 1 == endxs)  //如果只升级1级的话就读起兑换积分
                {
                    s = getjf(endxs);

                }
                else
                {
                    for (int i = stxs; i <= endxs; i++)  //如果夸级的话就读起他们的系数，根据系数读起兑换积分
                    {

                        s += getjf(i);

                    }
                }


            }
          

            //else
            //{
            //    s = getjf(endxs);//从高级升级到小级直接扣除要升级到的积分
            //}
            return s;

 
        }

        private void bt_dk_Click(object sender, EventArgs e)
        {
            Hhygl.H_hygl_k H_hygl_k_new = new Hotel_app.Hhygl.H_hygl_k();
            H_hygl_k_new.add_hy_info_01("", true, ref tB_hykh_bz, ref tB_hyrx,ref  tB_krxm,ref tB_hyjf);
            //if (hykh != "")
            //{
            //    tB_krly.Focus();
            //}
        }
    }
}