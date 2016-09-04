using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Hotel_app.Server.BBfx
{
    /// <summary>
    /// BBfx_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class BBfx_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //生成所有报表或者分别生成营业、账务、未结
        [WebMethod]
        public string New_zhrbb_app(string yydh, string qymc, DateTime rq, string czy, DateTime czsj, int judge_rx, string xxzs)
        {
            string s = "";
            BBfx.B_zhrbb B_zhrbb_new = new B_zhrbb();
            s = B_zhrbb_new.New_zhrbb_app( yydh,  qymc,  rq,  czy,  czsj,  judge_rx,  xxzs);
            return s;
        }


        //添加临时消费数据
        [WebMethod]
        public string Ssyxfmx_ls_add_app(string yydh, string qymc, string czy, string cssj, string jssj, string add_type, string xxzs)
        {
            string s = "";
            BBfx.B_syxfmx_ls_add B_syxfmx_ls_add_new = new B_syxfmx_ls_add();
            s = B_syxfmx_ls_add_new.Ssyxfmx_ls_add_app( yydh,  qymc,  czy,  cssj,  jssj,  add_type,  xxzs);
            return s;
        }

        //生成各种消费分析
        [WebMethod]
        public string bbfx_add_app(string yydh, string qymc, string xsy_krly_xydw, string xsy_krly_xydw_value, bool is_second, string second_value, string other_cond, string czy, string cssj, string jssj, DateTime czsj, string xxzs)
        {
            string s = "";
            BBfx.B_xsy_krly_xydw B_xsy_krly_xydw_new = new B_xsy_krly_xydw();
            s = B_xsy_krly_xydw_new.bbfx_add_app(yydh, qymc, xsy_krly_xydw, xsy_krly_xydw_value, is_second, second_value, other_cond, czy, cssj, jssj, czsj, xxzs);
            return s;
        }


        



        //添加临时账务数据
        [WebMethod]
        public string Sjzmx_or_bak_ls_add_app(string yydh, string qymc, string czy, string cssj, string jssj, string add_type, string xxzs)
        {
            string s = "";
            //BBfx.B_syxfmx_ls_add B_syxfmx_ls_add_new = new B_syxfmx_ls_add();
            //s = B_syxfmx_ls_add_new.Sjzmx_or_bak_ls_add_app( yydh,  qymc,  czy,  cssj,  jssj,  xxzs);
            return s;
        }
        
        
        //

        [WebMethod]
        public string get_g_j_ye(string yydh, string qymc, string type, string czy_temp, string ls_cond, string czsj, string xxzs)
        {
            string s = "";
            BBfx.B_g_j_fx B_g_j_fx_new = new B_g_j_fx();
            s = B_g_j_fx_new.get_g_j_ye(yydh, qymc, type, czy_temp, ls_cond,czsj, xxzs);
            return s;
        }

        //挂记账分析
        [WebMethod]
        public string get_g_j_fx_app(string yydh, string qymc, string cssj, string jssj, string sel_cond, string type, string czy, string czsj, string xxzs)
        {
            string s = "";
            BBfx.B_g_j_fx B_g_j_fx_new = new B_g_j_fx();
            s = B_g_j_fx_new.get_g_j_fx_app(yydh, qymc, cssj, jssj, sel_cond, type, czy, czsj, xxzs);
            return s;
        }

        [WebMethod(Description = "记挂明细分类分析")]
        public string get_g_j_mxfx_app(string yydh, string qymc, string cssj, string jssj, string other_cond, string type, string jzzt, string czy_temp, string czsj, string xxzs)
        {
            string s = "";
            BBfx.B_g_j_fx B_g_j_fx_new = new B_g_j_fx();
            s = B_g_j_fx_new.get_g_j_mxfxData(yydh, qymc, cssj, jssj, other_cond, type, jzzt, czy_temp, czsj, xxzs);
            return s;
        }

        [WebMethod(Description="在店客人明细")]
        public string get_zzkr_mxfx_app(string qymc, string yydh, string czy_temp, string czsj, string xxzs,string searchType)
        {
            string s = "";
            BBfx.B_zdkr_mxfx B_zdkr_mxfx_new = new B_zdkr_mxfx();
            s = B_zdkr_mxfx_new.Get_zdkr_mxData(qymc, yydh, czy_temp, czsj, xxzs, searchType);
            return s;
        }

        [WebMethod(Description = "在店预离分析")]
        public string get_zzkr_ylfx_app(string qymc, string yydh, string cssj, string jssj, string czy_temp, string czsj, string xxzs)
        {
            string s = "";
            BBfx.B_zdkr_ylfx B_zdkr_ylfx_new = new B_zdkr_ylfx();
            s=B_zdkr_ylfx_new.Get_zdkr_ylData( qymc,  yydh,  cssj,  jssj,  czy_temp,  czsj,  xxzs);
            return s;
        }

        [WebMethod(Description = "代收分析")]
        public string get_ds_fx(string yydh, string qymc, string cssj, string jssj, string czsj, string czy_temp, string xxzs)
        {
            string s = "";
            BBfx.B_dsfx B_dsfx_new = new B_dsfx();
            s = B_dsfx_new.ds_fx(yydh, qymc, cssj, jssj, czsj, czy_temp, xxzs);
            return s;
        }


        //生成会员消费分析
        [WebMethod]
        public string bbfx_add_app_hykh(string yydh, string qymc, string xsy_hykh, string xsy_hykh_value, bool is_second, string second_value, string other_cond, string czy, string cssj, string jssj, DateTime czsj, string xxzs)
        {
            string s = "";
            BBfx.B_xsy_hykh B_xsy_krly_xydw_new = new B_xsy_hykh();
            s = B_xsy_krly_xydw_new.bbfx_add_app_hykh(yydh, qymc, xsy_hykh, xsy_hykh_value, is_second, second_value, other_cond, czy, cssj, jssj, czsj, xxzs);
            return s;
        }


        [WebMethod]
        public string BB_kc_y_r_cbtj_app(string qymc, string yydh, string rq, string rx, string czy_temp, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            B_kc B_kc_new = new B_kc();
            s=B_kc_new.BB_kc_y_r_cbtj( qymc,  yydh,  rq,  rx,  czy_temp,  xxzs);
            return s;
        }



    }
}
