using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Fwx_other_add_edit : Form
    {
        public String Fwx_other_id = "";
        public string zyzt = common_file.common_fjzt.wxf;
        public string judge_add_edit = common_file.common_app.get_add;
        BLL.Fwx_other B_Fwx_other = new Hotel_app.BLL.Fwx_other();
        Model.Fwx_other M_Fwx_other = new Hotel_app.Model.Fwx_other();
        Fwx_other_browse Fwx_other_browse_temp_app;
        public Fwx_other_add_edit(Fwx_other_browse Fwx_other_browse_temp, string id)
        {
            InitializeComponent();
            Fwx_other_id = id;
            if (id != "")
            {
                M_Fwx_other = B_Fwx_other.GetModel(int.Parse(id));

                tB_fjrb.Text = M_Fwx_other.fjrb;
                tB_fjbh.Text = M_Fwx_other.fjbh;
                dT_ddsj_date.Value = M_Fwx_other.ddsj;
                dT_ddsj_time.Value = M_Fwx_other.ddsj;
                dT_lksj_date.Value = M_Fwx_other.lksj;
                dT_lksj_time.Value = M_Fwx_other.lksj;
                zyzt = M_Fwx_other.zyzt;
                tB_bz.Text = M_Fwx_other.bz;
            }
            Fwx_other_browse_temp_app = Fwx_other_browse_temp;
        }
        public Fwx_other_add_edit()
        {
            InitializeComponent();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if ((dT_ddsj_date.Value < DateTime.Today) && (judge_add_edit == common_file.common_app.get_add))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "初始时间不能小于当天！");

            }
            else
            {
                if (DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()) < DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()))
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "结束时间不能小于操作时间！");
                }
                else
                {
                    if (common_file.common_used_fjzt.get_dataset_usedfjzt(zyzt, Convert.ToDateTime(dT_ddsj_date.Value.ToShortDateString() + " 00:00:00"), Convert.ToDateTime(dT_lksj_date.Value.ToShortDateString() + " 23:59:59"), tB_fjrb.Text.Trim(), tB_fjbh.Text.Trim(), tB_fjbh.Text.Trim(), Fwx_other_id, common_file.common_app.is_contain_wx) == false)
                    {
                        string url = common_file.common_app.service_url + "Ffjzt/Ffjzt_app.asmx";
                        object[] args = new object[16];
                        if (Fwx_other_id == "")
                            args[0] = 0;
                        else
                            args[0] = int.Parse(Fwx_other_id);
                        args[1] = common_file.common_app.yydh;
                        args[2] = common_file.common_app.qymc;
                        args[3] = common_file.common_ddbh.ddbh("wxqt", "lfdate", "lfcounter", 3);
                        args[4] = tB_fjrb.Text.Trim().Replace("'", "//");
                        args[5] = tB_fjbh.Text.Trim().Replace("'", "//");
                        args[6] = DateTime.Parse(dT_ddsj_date.Value.ToShortDateString());
                        args[7] = DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " 23:59:59");
                        args[8] = tB_bz.Text.Trim().Replace("'", "//");
                        args[9] = zyzt;
                        args[10] = common_file.common_app.czy;
                        args[11] = DateTime.Now.ToString();
                        args[12] = false;
                        args[13] = false;
                        args[14] = judge_add_edit;
                        args[15] = common_file.common_app.xxzs;

                        Hotel_app.Server.Ffjzt.Fwx_other Fwx_other_services = new Hotel_app.Server.Ffjzt.Fwx_other();
                        string result = Fwx_other_services.set_wx_other(int.Parse(args[0].ToString()), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), DateTime.Parse(args[6].ToString()), DateTime.Parse(args[7].ToString()), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), bool.Parse(args[12].ToString()), bool.Parse(args[13].ToString()), args[14].ToString(), args[15].ToString());
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "set_wx_other", args);
                        if (result== common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                            if (Fwx_other_browse_temp_app != null)
                            {
                                Fwx_other_browse_temp_app.refresh_app();
                            }
                            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
                            DataSet ds_temp_0 = B_Ffjzt.GetList("fjbh='" + tB_fjbh.Text + "'");
                            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                            {
                                if (ds_temp_0.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.wxf || ds_temp_0.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.qtf)
                                {
                                    if (Ffjzt.common_form.Ffjzt_pic_big_new != null)
                                    {
                                        if (Ffjzt.common_form.Ffjzt_pic_big_new.UC_room_pic_0_select != null)
                                        {
                                            common_file.common_room_state.room_state(Ffjzt.common_form.Ffjzt_pic_big_new.UC_room_pic_0_select, ds_temp_0, 0);
                                        }
                                    }
                                }
                            }
                            ds_temp_0.Dispose();
                            this.Close();
                        }
                        else
                            if (result.ToString() == common_file.common_app.get_failure) common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }
    }
}