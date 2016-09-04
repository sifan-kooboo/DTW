using System;
using System.Data;
using System.Configuration;

namespace Hotel_app.Server.Ffjzt
{
    public partial class Fwx_other
    {
        public string set_wx_other(int id, string yydh, string qymc, string lsbh, string fjrb, string fjbh, DateTime ddsj, DateTime lksj, string bz, string zyzt, string czy, string czsj, bool is_top, bool is_select, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            DateTime yd_ddsj0 = DateTime.Parse(common_file.common_app.cssj);
            DateTime yd_lksj0 = DateTime.Parse(common_file.common_app.cssj);
            BLL.Fwx_other B_Fwx_other = new Hotel_app.BLL.Fwx_other();
            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();

            Model.Fwx_other M_Fwx_other = new Hotel_app.Model.Fwx_other();
            Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Hotel_app.Server.Ffjzt.Ffjzt_add_edit();
            if (add_edit_delete == common_file.common_app.get_add)
            {
                s = common_file.common_app.get_failure;
                M_Fwx_other.yydh = yydh; M_Fwx_other.qymc = qymc; M_Fwx_other.lsbh = lsbh;
                M_Fwx_other.fjrb = fjrb; M_Fwx_other.fjbh = fjbh; M_Fwx_other.ddsj = ddsj;
                M_Fwx_other.lksj = lksj; M_Fwx_other.bz = bz; M_Fwx_other.zyzt = zyzt;
                M_Fwx_other.czy = czy; M_Fwx_other.czsj = DateTime.Now; M_Fwx_other.cznr = common_file.common_app.chinese_add;
                M_Fwx_other.is_top = false;
                M_Fwx_other.is_select = false;
                if (B_Fwx_other.Add(M_Fwx_other) > 0)
                {
                    s = common_file.common_app.get_suc;

                    if (ddsj >= DateTime.Now.Date && ddsj < DateTime.Now.Date.AddDays(1))
                    //当天维修才去修改房态
                    {
                        s = common_file.common_app.get_failure;
                        s = Ffjzt_add_edit_new.set_yd_ft(zyzt, fjbh, ddsj, lksj, czsj, "修改房态成" + zyzt, czy, xxzs);
                        s = common_file.common_app.get_suc;
                    }
                }


            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    s = common_file.common_app.get_failure;
                    M_Fwx_other = B_Fwx_other.GetModel(id);
                    //先修改原来如果有占用房态的房间要先清除掉
                    DateTime ddsj_temp = M_Fwx_other.ddsj;
                    DateTime lksj_temp = M_Fwx_other.lksj;
                    DataSet ds_temp0 = B_Ffjzt.GetList("zyzt='" + zyzt + "' and ddsj='" + ddsj_temp.ToString() + "' and lksj='" + lksj_temp.ToString() + "'");
                    if ((ddsj < DateTime.Now.Date || ddsj >= DateTime.Now.Date.AddDays(1)) && (ds_temp0.Tables[0].Rows.Count > 0))
                    {
                        s = Ffjzt_add_edit_new.set_yd_ft(common_file.common_fjzt.zf, fjbh, DateTime.Parse(common_file.common_app.cssj), DateTime.Parse(common_file.common_app.cssj), czsj, zyzt + "自动修改房态成" + common_file.common_fjzt.zf, czy, xxzs);

                    }
                    ds_temp0.Dispose();
                    M_Fwx_other.ddsj = ddsj;
                    M_Fwx_other.lksj = lksj; M_Fwx_other.bz = bz; M_Fwx_other.zyzt = zyzt;
                    M_Fwx_other.czy = czy; M_Fwx_other.czsj = DateTime.Now; M_Fwx_other.cznr = common_file.common_app.chinese_edit;
                    if (B_Fwx_other.Update(M_Fwx_other) == true)
                    {
                        s = common_file.common_app.get_suc;

                        if ((ddsj >= DateTime.Now.Date && ddsj < DateTime.Now.Date.AddDays(1)))
                        //不能限制当天维修才去修改房态,因为有可能离开时间延长或变短了!
                        {
                            s = common_file.common_app.get_failure;
                            s = Ffjzt_add_edit_new.set_yd_ft(zyzt, fjbh, ddsj, lksj, czsj, "修改房态成" + zyzt, czy, xxzs);
                            s = common_file.common_app.get_suc;

                        }
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        s = common_file.common_app.get_failure;
                        M_Fwx_other = B_Fwx_other.GetModel(id);
                        //先修改原来如果有占用房态的房间要先清除掉
                        DateTime ddsj_temp = M_Fwx_other.ddsj;
                        DateTime lksj_temp = M_Fwx_other.lksj;
                        DataSet ds_temp0 = B_Ffjzt.GetList("zyzt='" + zyzt + "' and fjbh='" + fjbh + "' and ddsj='" + ddsj_temp.ToString() + "' and lksj='" + lksj_temp.ToString() + "'");
                        if ((ds_temp0.Tables[0].Rows.Count > 0))
                        {
                            s = Ffjzt_add_edit_new.set_yd_ft(common_file.common_fjzt.zf, fjbh, DateTime.Parse(common_file.common_app.cssj), DateTime.Parse(common_file.common_app.cssj), czsj, zyzt + "自动修改房态成" + common_file.common_fjzt.zf, czy, xxzs);

                        }
                        ds_temp0.Dispose();
                        B_Fwx_other.Delete(id);
                        s = common_file.common_app.get_suc;
                    }

            return s;
        }





    }
}
