using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public class Qyddj_c
    {
        public void delete_fjrb(DataGridViewSummary dg_fjrb, Model.Qskyd_fjrb M_Qskyd_fjrb,BLL.Qskyd_fjrb B_Qskyd_fjrb)
        {
            common_file.common_app.get_czsj();
            if (dg_fjrb.Rows.Count > 0 && dg_fjrb.Rows[0].Cells["id"].Value != null && dg_fjrb.Rows[0].Cells["id"].Value.ToString() != string.Empty)
            {
                if (dg_fjrb.CurrentRow.Index >= 0 || dg_fjrb.Rows.Count > 0)
                {
                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要删除所选的记录吗？") == true)
                    {
                        string id = dg_fjrb.Rows[dg_fjrb.CurrentRow.Index].Cells["id"].Value.ToString();
                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(id));
                        if (M_Qskyd_fjrb != null)
                        {
                            if (M_Qskyd_fjrb.fjbh == "" && M_Qskyd_fjrb.fjrb == "")
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,当前记录只能修改！");
                                return;
                            }
                            if (M_Qskyd_fjrb.fjbh != "" && M_Qskyd_fjrb.fjrb != "")
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,排房记录不能在此删除！若要删除，请到主单去操作！");
                                return;
                            }
                            if (M_Qskyd_fjrb.fjbh == "" && M_Qskyd_fjrb.fjrb != "")
                            {
                                BLL.Common B_Common = new Hotel_app.BLL.Common();
                                DataSet ds_temp = B_Common.GetList("select * from Qskyd_fjrb", "lsbh='" + M_Qskyd_fjrb.lsbh + "'");
                                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 1)
                                {
                                    common_file.common_app.get_czsj();
                                    string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";
                                    object[] args = new object[26];
                                    args[0] = id;
                                    args[1] = common_file.common_app.yydh;
                                    args[2] = common_file.common_app.qymc;
                                    args[3] = M_Qskyd_fjrb.lsbh;
                                    args[4] = M_Qskyd_fjrb.krxm;
                                    args[5] = M_Qskyd_fjrb.sktt;
                                    args[6] = M_Qskyd_fjrb.yddj;
                                    args[7] = M_Qskyd_fjrb.fjrb;
                                    args[8] = M_Qskyd_fjrb.fjbh;
                                    args[9] = M_Qskyd_fjrb.ddsj;
                                    args[10] = M_Qskyd_fjrb.lksj;
                                    args[11] = M_Qskyd_fjrb.lzfs;
                                    args[12] = M_Qskyd_fjrb.shqh;
                                    args[13] = M_Qskyd_fjrb.fjjg;
                                    args[14] = M_Qskyd_fjrb.sjfjjg;
                                    args[15] = M_Qskyd_fjrb.yh;
                                    args[16] = M_Qskyd_fjrb.yhbl;
                                    args[17] =M_Qskyd_fjrb.bz;
                                    args[18] = common_file.common_app.czy;
                                    args[19] = DateTime.Now;
                                    args[20] = common_file.common_app.chinese_delete;
                                    args[21] = M_Qskyd_fjrb.yddj;//有三种状态,一种预订、一种登记、一种预订转登记
                                    args[22] = common_file.common_app.get_delete;
                                    args[23] = common_file.common_app.xxzs;
                                    args[24] = "";
                                    args[25] = decimal.Parse("0");

                                    Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edit_delete();
                                    string result = Qskyd_fjrb_add_edit_delete_services.Qskyd_fjrb_add_edit_delete_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), DateTime.Parse(args[9].ToString()), DateTime.Parse(args[10].ToString()), Decimal.Parse(args[11].ToString()), args[12].ToString(), Decimal.Parse(args[13].ToString()),
               Decimal.Parse(args[14].ToString()), args[15].ToString(), Decimal.Parse(args[16].ToString()), args[17].ToString(), args[18].ToString(), DateTime.Parse(args[19].ToString()), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), Decimal.Parse(args[25].ToString()));
                                   // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_add_edit_delete_app", args);
                                    if (result== common_file.common_app.get_suc)
                                    {
                                        dg_fjrb.Rows.Remove(dg_fjrb.CurrentRow);
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功！");
                                    }
                                    else
                                    {
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                                    }
                                }
                                else
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,单条记录不能在此删除！若要删除，请到主单去操作！");
                                }

                            }
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "你好,找不到相应的记录！");
                        }


                    }
                }

                else
                {
                    //提示
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "你好,你没有选择任何信息！");
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
