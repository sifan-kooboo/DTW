using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szw_Common_check : Form
    {
        //需要的参数
        public string lsbh="";//要结帐的LSBH
        public string jj_type = "";//是记帐,结帐，还是要挂帐
        public Image btnImage;//动态设置弹出窗的图标
        public string sk_tt="";//结帐时只判断(sk,tt)
        string  add_ff=common_zw.ff_jsbtfy;//加收半天还是全天

        bool flage_status = false;//用来检测当前加收半天或者前天是否正确对待 

        public DataSet ds_temp;

       public  Hotel_app.BLL.Flfsz   B_Flfsz=new Hotel_app.BLL.Flfsz();
        public Hotel_app.BLL.Qskyd_mainrecord  B_Qskyd_mainrecord=new Hotel_app.BLL.Qskyd_mainrecord();
        public Hotel_app.BLL.Qttyd_mainrecord  B_Qttyd_mainrecord =new Hotel_app.BLL.Qttyd_mainrecord();
        public Hotel_app.BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        public BLL.Common B_common = new Hotel_app.BLL.Common();


        public Szw_Common_check()
        {
            InitializeComponent();
        }



        public  void InitalApp(string jj_type,string lsbh,string sk_tt)
        {
            this.jj_type=jj_type;
            this.lsbh = lsbh;
            this.sk_tt = sk_tt;
            this.dg_jzgl.AutoGenerateColumns = false;
            this.dg_jzgl.DataSource = null;

            //根据结帐类型动态显示按妞以及图标
            SetBtnStatus(this.jj_type);

            //初始数据
            BindData();

        }

        private void BindData()
        {
            if (this.lsbh != "" &&sk_tt=="sk")
            {
                //登记，散客
                string temp = "lsbh in (select  lsbh from Flfsz  where  shlz=1  and   lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "' and yydh='" + common_file.common_app.yydh;
                ds_temp = B_common.GetList("  select  * from  Qskyd_fjrb ", " lsbh in (select  lsbh from Flfsz  where lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "' and yydh='" + common_file.common_app.yydh + "'   and  shlz='1'     )  and  shlz='1')");
                if (ds_temp.Tables[0].Rows.Count == 0)
                {
                    ds_temp = B_Qskyd_fjrb.GetList("id>=0   " + common_file.common_app.yydh_select + "  and  lsbh='" + this.lsbh + "'");
                }
            }
            if (this.lsbh != "" && sk_tt == "tt")
            {
               // ds_temp = B_Qttyd_mainrecord.GetList("id>=0 " + common_file.common_app.yydh_select + "  and lsbh='" + lsbh + "'");
                BLL.Common B_common = new Hotel_app.BLL.Common();
                ds_temp = B_common.GetList("  select  *   from  View_Qskzd ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  ddbh  in (select ddbh from Qttyd_mainrecord   where  yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "')");
            }
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                ds_jzgl.DataSource = ds_temp.Tables[0];
                dg_jzgl.DataSource = ds_jzgl;
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_jz_1_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            flage_status = CheckValue();
            if (flage_status)
            {
                common_file.common_app.get_czsj();
                Add_btff();
                //记帐||挂帐
                if (jj_type == common_file.common_jzzt.czzt_jz || jj_type == common_file.common_jzzt.czzt_gz)
                {
                    common_file.common_app.get_czsj();
                    Szwcz Frm_Szwcz_new = new Szwcz();
                    Frm_Szwcz_new.InitalApp(jj_type, lsbh, "", sk_tt, "Szw_Common");
                    Frm_Szwcz_new.StartPosition = FormStartPosition.CenterScreen;
                    if (Frm_Szwcz_new.ShowDialog() == DialogResult.OK)
                    {
                        common_file.common_app.get_czsj();
                        this.Close();
                    }
                    //common_file.common_form.ShowFrm_Szwcz_new(jj_type, lsbh,"", sk_tt, "Szw_Common");
                }
                //分结
                if (b_jz_1.Text == "分结")
                {
                    this.Close();
                    common_file.common_form.ShowFrm_Sfjcz_new(common_file.common_jzzt.czzt_bfsz, lsbh, sk_tt,"");
                }
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "加收类型选择不一致，请更正，加收半天或者加收全天");
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_jz_2_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            flage_status = CheckValue();
            if (flage_status)
            {
                common_file.common_app.get_czsj();
                Add_btff();
                //结帐
                if (jj_type == common_file.common_jzzt.czzt_sz)
                {
                    common_file.common_app.get_czsj();
                    Szwcz Frm_Szwcz_new = new Szwcz();
                    Frm_Szwcz_new.InitalApp(common_file.common_jzzt.czzt_sz, lsbh, "", sk_tt, "Szw_Common");
                    Frm_Szwcz_new.StartPosition = FormStartPosition.CenterScreen;
                    if (Frm_Szwcz_new.ShowDialog() == DialogResult.OK)
                    { this.Close(); }
                    //common_file.common_form.ShowFrm_Szwcz_new(common_file.common_jzzt.czzt_sz, lsbh,"", sk_tt, "Szw_Common");
                }
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "加收类型选择不一致，请更正，加收半天或者加收全天");
            }
            Cursor.Current = Cursors.Default;
        }

        private void SetBtnStatus(string jzType)
        {
            //根据jj_type
            if (jj_type == common_file.common_jzzt.czzt_jz)
            {
                b_jz_1.Visible = true;
                b_jz_1.Text = "记帐";
                //btnImage = Image.FromFile(common_file.common_app.BtnBgImgFilePath("a-9.ICO"));
                //b_jz_1.Image = btnImage;
                this.Text = "客人记帐";
                b_jz_2.Visible = false;

            }
            if (jj_type == common_file.common_jzzt.czzt_gz)
            {
                b_jz_1.Visible = true;
                b_jz_1.Text = "挂帐";
                //btnImage = Image.FromFile(common_file.common_app.BtnBgImgFilePath("a-8.ICO"));
                //b_jz_1.Image = btnImage;
                this.Text = "客人挂帐";
                b_jz_2.Visible = false;
            }
            if (jj_type == common_file.common_jzzt.czzt_sz)
            {
                b_jz_1.Visible = true;
                b_jz_1.Text = "分结";
                //btnImage = Image.FromFile(common_file.common_app.BtnBgImgFilePath("b_jfdf.ICO"));
                //b_jz_1.Image = btnImage;
                b_jz_2.Visible = true;
                b_jz_2.Text = "结帐";
                //btnImage = Image.FromFile(common_file.common_app.BtnBgImgFilePath("a-7.ICO"));
                //b_jz_2.Image = btnImage;
                this.Text = "客人结帐";
            }
            b_exit.Visible = true;
        }

        private void Add_btff()
        {
                string[] list_lsbh = new string[100];
                int temp_count = 0;
                for (int i = 0; i < list_lsbh.Length; i++)
                {
                    list_lsbh[i] = "";//初始化为空
                }
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds_temp.Tables[0].Rows.Count ; j++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_jzgl.Rows[j].Cells[2].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_jzgl.Rows[j].Cells[2].GetEditedFormattedValue(j, ss)) == true)
                        {
                            if (this.dg_jzgl.Rows[j].Cells["fjbh"].Value != null)
                            {
                                add_ff = common_zw.ff_jsbtfy;
                                list_lsbh[j] = ds_temp.Tables[0].Rows[dg_jzgl.Rows[j].Index]["lsbh"].ToString();
                            }
                        }
                        if (this.dg_jzgl.Rows[j].Cells[3].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_jzgl.Rows[j].Cells[3].GetEditedFormattedValue(j, ss)) == true)
                        {
                            if (this.dg_jzgl.Rows[j].Cells["fjbh"].Value != null)
                            {
                                add_ff = common_zw.ff_jsqtfy;
                                int i_0 = 0;

                                DataRowView dgr = dg_jzgl.Rows[j].DataBoundItem as DataRowView;
                                i_0 = ds_temp.Tables[0].Rows.IndexOf(dgr.Row);

                                list_lsbh[j] = ds_temp.Tables[0].Rows[i_0]["lsbh"].ToString();
                            }
                        }
                    }
                }
              //判断当前的数组里面是否有值
                foreach (string  ss_temp in list_lsbh)
                {
                    if (ss_temp.Trim() != "")
                    { temp_count += 1;
                    break;
                }
                }

                if (temp_count > 0)
                {

                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要对以上所选的房间加收" + add_ff + "?") == true)
                    {
                        common_file.common_app.get_czsj();
                        string url = common_file.common_app.service_url;
                        url += "Szwgl/Szwgl_app.asmx";
                        object[] args = new object[10];
                        args[0] = common_file.common_app.yydh;
                        args[1] = common_file.common_app.qymc;
                        args[2] = list_lsbh;
                        args[3] = add_ff;//半天还是全天
                        args[4] = "bbd";
                        args[5] = common_file.common_app.czy_bc;
                        args[6] = common_file.common_app.syzd;
                        args[7] = common_file.common_app.czy;
                        args[8] = DateTime.Now;
                        args[9] = common_file.common_app.xxzs;

                        Hotel_app.Server.Szwgl.Szwmx Szwmx_services = new Hotel_app.Server.Szwgl.Szwmx();
                        string result = Szwmx_services.New_muli_fjfy(args[0].ToString(), args[1].ToString(), list_lsbh, args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), DateTime.Parse(args[8].ToString()), args[9].ToString());
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "New_muli_fjfy", args);
                        if (result != null && result== common_file.common_app.get_suc)
                        {
                            //common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                        }
                    }
                }
        }

        //检查当前dg的checkBox列，2列和3列，只能有一列中有选择(混合选择返回false)
        private  bool CheckValue()
        {
            bool flage = true ;
            if (ds_temp!=null&&ds_temp.Tables[0].Rows.Count <= 1)
            {
                if (ds_temp.Tables[0].Rows.Count == 1)
                {
                   if(bool.Parse(dg_jzgl.Rows[0].Cells[2].FormattedValue.ToString())==true&&bool.Parse(dg_jzgl.Rows[0].Cells[3].FormattedValue.ToString())==true)
                   {return flage=false;}
                }
                return flage = true;
            }
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count >1)
            {
                bool firstValue = bool.Parse(dg_jzgl.Rows[0].Cells[2].FormattedValue.ToString());
                for (int   i_0 = 1; i_0 <  ds_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (bool.Parse(dg_jzgl.Rows[i_0].Cells[2].FormattedValue.ToString()) != firstValue)
                        return false;
                    else
                    {
                        continue;
                    }
                }
            }
            //for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
            //{
            //    if (ds_temp.Tables[0].Rows[i]["fjbh"] != null && ds_temp.Tables[0].Rows[i]["fjbh"].ToString().Trim()!="")
            //    {
            //        if (bool.Parse( dg_jzgl.Rows[i].Cells[2].FormattedValue.ToString()))
            //        {
            //            for (int j = 0; j < dg_jzgl.Rows.Count-1; j++)
            //            {
            //                if (bool.Parse(dg_jzgl.Rows[j].Cells[3].FormattedValue.ToString()))
            //                {
            //                    flage = false;
            //                    //common_file.common_app.Message_box_show(common_file.common_app.message_title, "加收类型选择不一致，请更正，加收半天或者加收全天");
            //                    return flage = false;
            //                }
            //            }
            //            flage =  true;
            //            break;
            //        }
            //        if (bool.Parse( dg_jzgl.Rows[i].Cells[3].FormattedValue.ToString()))
            //        {
            //            for (int j = 0; j < dg_jzgl.Rows.Count - 1; j++)
            //            {
            //                if (bool.Parse( dg_jzgl.Rows[j].Cells[2].FormattedValue.ToString() ))
            //                {
            //                    flage = false; 
            //                    //common_file.common_app.Message_box_show(common_file.common_app.message_title, "加收类型选择不一致，请更正，加收半天或者加收全天");
            //                    return flage = false;
            //                }
            //            }
            //            flage = true;
            //            break;
            //        }
            //        if (i == dg_jzgl.Rows.Count - 2)
            //        {
            //            flage = true;//到最后一行都没有选择性
            //        }
            //    }
            //}
            return flage;
        }

        private void Szw_Common_check_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Szw_Common_check_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (common_file.common_form.Szwcl_new != null)
            {
                common_file.common_form.Szwcl_new.BindData(lsbh, common_file.common_app.czy_GUID);  
            }
        }
    }
}