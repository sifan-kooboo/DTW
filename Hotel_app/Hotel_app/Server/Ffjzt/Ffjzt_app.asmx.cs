using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Hotel_app.Server.Ffjzt
{
    /// <summary>
    /// Ffjzt 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Ffjzt_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string Ffjrb_add_edit(string id, string yydh, string qymc, string fjrb_code, string fjrb, string sjjg, string zyrs, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Ffjzt_add_edit();
            s = Ffjzt_add_edit_new.Ffjrb_add_edit(id, yydh, qymc, fjrb_code, fjrb, sjjg, zyrs, add_edit_delete,xxzs);
            return s;
        }
        [WebMethod]
        public string Ffjzt_add_edit_delete(string id, string yydh, string qymc, string jdlh, string jdlh_name, string jdcs, string jdcs_name, string fjrb, string fjrb_code, string fjbh, string fjdh, string dhfj, string bz, string add_edit_delete, string xxzs) 
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Ffjzt_add_edit();
            s = Ffjzt_add_edit_new.Ffjzt_add_edit_delete(id, yydh, qymc, jdlh, jdlh_name, jdcs, jdcs_name, fjrb, fjrb_code, fjbh, fjdh, dhfj, bz, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "联房设置增册改")]
        public string Flfsz_add_edit(string id, string yydh, string qymc, string lfbh, string lsbh, string fjbh, string krxm, string sktt, string yddj, string czy, string czsj, bool shlz, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;

            Ffjzt.Flfsz_add_edit Flfsz_add_edit_new = new Flfsz_add_edit();
            s = Flfsz_add_edit_new.Flfsz_add_edit_delete(id, yydh, qymc, lfbh, lsbh, fjbh, krxm, sktt, yddj, czy, czsj,shlz,add_edit_delete, xxzs);
            return s;
        }

        [WebMethod(Description = "设置维修房")]
        public string set_wx_other(int id, string yydh, string qymc, string lsbh, string fjrb, string fjbh, DateTime ddsj, DateTime lksj, string bz, string zyzt, string czy, string czsj, bool is_top, bool is_select, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Fwx_other Fwx_other_new = new Fwx_other();
            s = Fwx_other_new.set_wx_other(id, yydh, qymc, lsbh, fjrb, fjbh, ddsj, lksj, bz, zyzt, czy, czsj, is_top, is_select, add_edit_delete, xxzs);
            return s;
        }

        [WebMethod(Description = "修改房态-干净、脏房、已洁房、在住脏房、取消在住脏房")]
        public string set_gj_zf_yj_zzzf_qxzz(string id, string yydh, string qymc, string fjbh, string xgzt, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Fgj_z_yj_zzzf Fgj_z_yj_zzzf_new = new Fgj_z_yj_zzzf();
            s = Fgj_z_yj_zzzf_new.set_gj_zf_yj_zzzf_qxzz(id, yydh, qymc, fjbh, xgzt, czy, czsj, xxzs);
            return s;
        }
        [WebMethod(Description = "批量增加联房")]
        public string set_pl_lf(string yydh, string qymc, string old_lsbh, string lfbh, string[] id_arg, bool shlz, string czy, string czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Flfsz_add_edit Flfsz_add_edit_new = new Flfsz_add_edit();
            s = Flfsz_add_edit_new.set_pl_lf(yydh, qymc, old_lsbh, lfbh, id_arg, shlz, czy, czsj, xxzs);
            return s;
        }

        [WebMethod(Description = "设置客人来源的fjrb")]
        public string Ffjrb_krly_add_edit(string id, string yydh, string qymc, string fjrb_code, string fjrb, string sjjg, string krly, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Ffjrb_krly Ffjrb_krly_add_edit_new = new Hotel_app.Server.Ffjzt.Ffjrb_krly();
            s = Ffjrb_krly_add_edit_new.Ffjrb_krly_add_edit(id, yydh, qymc, fjrb_code, fjrb, sjjg, krly, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "设置客人来源的fjrb")]
        public string dr_ft_fx(string yydh, string qymc, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.F_ftfx F_ftfx_new = new F_ftfx();
            s = F_ftfx_new.dr_ft_fx(yydh, qymc, czy, czsj, xxzs);
            return s;
        }

    }
}
