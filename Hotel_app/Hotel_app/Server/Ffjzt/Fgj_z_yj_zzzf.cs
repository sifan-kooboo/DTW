using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Ffjzt
{
    public partial class Fgj_z_yj_zzzf
    {
        /// <summary>
        /// 修改干净、脏房、已洁房、在住脏房、取消在住脏房
        /// </summary>
        /// <param name="id"></param>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="fjbh"></param>
        /// <param name="xgzt"></param>"干净gj","脏zf","已洁yj","在住脏zzzf","取消在住脏qxzz"
        /// <param name="add_edit_delete"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string set_gj_zf_yj_zzzf_qxzz(string id, string yydh, string qymc, string fjbh, string xgzt, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            //common_file.common_czjl common_czjl_new = new Hotel_app.common_file.common_czjl();

            Model.Ffjzt M_Ffjzt = B_Ffjzt.GetModel(int.Parse(id));
            string update_s = "";
            switch (xgzt)
            {
                case "gj":
                    if (M_Ffjzt.zyzt == common_file.common_fjzt.wxf || M_Ffjzt.zyzt == common_file.common_fjzt.qtf)
                    {
                        B_Common.ExecuteSql("delete from Fwx_other where fjbh='" + fjbh + "' and ddsj='" + M_Ffjzt.ddsj.ToString() + "' and lksj='" + M_Ffjzt.lksj.ToString() + "'");
                    
                    }
                    update_s = "update Ffjzt set zyzt='" + common_file.common_fjzt.gjf + "',lsbh='',krxm='',sktt='',zybz='',zyzt_second='',shlf=0,shts=0,shvip=0,fjbm=0,yd_ddsj='" + common_file.common_app.cssj + "',yd_lksj='" + common_file.common_app.cssj + "',ddsj='" + common_file.common_app.cssj + "',lksj='" + common_file.common_app.cssj + "',czy='" + czy + "',cznr='" + "修改房态-干净房" + "',czsj='" + DateTime.Now.ToString() + "' where id='" + id + "' and zyzt_second<>'" + common_file.common_fjzt.ydf + "'";
                    if (B_Common.ExecuteSql(update_s) > 0)
                    {
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "修改房间状态" + M_Ffjzt.zyzt + "-" + common_file.common_fjzt.gjf, fjbh, "", czsj);
                        s = common_file.common_app.get_suc;
                    }
                    update_s = "update Ffjzt set zyzt='" + common_file.common_fjzt.gjf + "',ddsj='" + common_file.common_app.cssj + "',lksj='" + common_file.common_app.cssj + "',czy='" + czy + "',cznr='" + "修改房态-干净房" + "',czsj='" + DateTime.Now.ToString() + "' where id='" + id + "' and zyzt_second='" + common_file.common_fjzt.ydf + "'";
                    if (B_Common.ExecuteSql(update_s) > 0)
                    {
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "修改房间状态" + M_Ffjzt.zyzt + "-" + common_file.common_fjzt.gjf, fjbh, "", czsj);
                        s = common_file.common_app.get_suc;
                    }
                    break;
                case "zf":
                    if (M_Ffjzt.zyzt == common_file.common_fjzt.wxf || M_Ffjzt.zyzt == common_file.common_fjzt.qtf)
                    {
                        B_Common.ExecuteSql("delete from Fwx_other where fjbh='" + fjbh + "' and ddsj='" + M_Ffjzt.ddsj.ToString() + "' and lksj='" + M_Ffjzt.lksj.ToString() + "'");

                    }
                    update_s = "update Ffjzt set zyzt='" + common_file.common_fjzt.zf + "',lsbh='',krxm='',sktt='',zybz='',zyzt_second='',shlf=0,shts=0,shvip=0,fjbm=0,yd_ddsj='" + common_file.common_app.cssj + "',yd_lksj='" + common_file.common_app.cssj + "',ddsj='" + common_file.common_app.cssj + "',lksj='" + common_file.common_app.cssj + "',czy='" + czy + "',cznr='" + "修改房态-脏房" + "',czsj='" + DateTime.Now.ToString() + "' where id='" + id + "' and zyzt_second<>'" + common_file.common_fjzt.ydf + "'";
                    if (B_Common.ExecuteSql(update_s) > 0)
                    {
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "修改房间状态" + M_Ffjzt.zyzt + "-" + common_file.common_fjzt.zf, fjbh, "", czsj);
                        s = common_file.common_app.get_suc;
                    }
                    update_s = "update Ffjzt set zyzt='" + common_file.common_fjzt.zf + "',zybz='" + "" + "',ddsj='" + common_file.common_app.cssj + "',lksj='" + common_file.common_app.cssj + "',czy='" + czy + "',cznr='" + "修改房态-脏房" + "',czsj='" + DateTime.Now.ToString() + "' where id='" + id + "' and zyzt_second='" + common_file.common_fjzt.ydf + "'";
                    if (B_Common.ExecuteSql(update_s) > 0)
                    {
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "修改房间状态" + M_Ffjzt.zyzt + "-" + common_file.common_fjzt.zf, fjbh, "", czsj);
                        s = common_file.common_app.get_suc;
                    }
                    break;
                case "yj":
                    update_s = "update Ffjzt set zybz='" + common_file.common_fjzt.yjf + "',czy='" + czy + "',cznr='" + "修改房态-已洁房" + "',czsj='" + DateTime.Now.ToString() + "' where id='" + id + "'";
                    if (B_Common.ExecuteSql(update_s) > 0)
                    {

                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "设置已洁房", fjbh, "", czsj);
                        s = common_file.common_app.get_suc;

                    }
                    break;
                case "zzzf":
                    update_s = "update Ffjzt set zybz='" + common_file.common_fjzt.yjf + "',czy='" + czy + "',cznr='" + "修改房态-在住脏房" + "',czsj='" + DateTime.Now.ToString() + "' where id='" + id + "'";
                    if (B_Common.ExecuteSql(update_s) > 0)
                    {

                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "设置在住脏房", fjbh, "", czsj);
                        s = common_file.common_app.get_suc;
                    }
                    break;
                case "qxzz":
                    update_s = "update Ffjzt set zybz='" + "" + "',czy='" + czy + "',cznr='" + "修改房态-取消在住脏房" + "',czsj='" + DateTime.Now.ToString() + "' where id='" + id + "'";
                    if (B_Common.ExecuteSql(update_s) > 0)
                    {
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "取消在住脏房", fjbh, "", czsj);
                        s = common_file.common_app.get_suc;
                   }
                    break;
                case "lszyf":
                    update_s = "update Ffjzt set zybz='" + common_file.common_fjzt.lszy + "',czy='" + czy + "',cznr='" + "修改房态-临时占用房" + "',czsj='" + DateTime.Now.ToString() + "' where id='" + id + "'";
                    if (B_Common.ExecuteSql(update_s) > 0)
                    {

                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "设置临时占用房", fjbh, "", czsj);
                        s = common_file.common_app.get_suc;
                    }
                    break;

                case "qxlszyf":
                    update_s = "update Ffjzt set zybz='" + "" + "',czy='" + czy + "',cznr='" + "修改房态-取消临时占用房" + "',czsj='" + DateTime.Now.ToString() + "' where id='" + id + "'";
                    if (B_Common.ExecuteSql(update_s) > 0)
                    {
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "取消临时占用房", fjbh, "", czsj);
                        s = common_file.common_app.get_suc;
                    }
                    break;

            }
            return s;



        }
    }

}
