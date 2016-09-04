using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Hotel_app.Server.Hhygl
{
    /// <summary>
    /// Hhygl_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Hhygl_app : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "会员的增删改")]
        public string Hhygl_add_edit_delete_app(string id, string yydh, string qymc, string hykh, string hyrx, string hykh_bz, string krxm, string krgj, string krmz, string yxzj, string zjhm, string krsr, string krxb, string krdh, string krsj, string krEmail, string krdz, string krzy, string krdw, string qzrx, string qzhm, string zjyxq, string tlyxq, string tjrq, string lzka, string bz, string hyjf, string shxg, string xgsj,string parent_hykh,string hymm,string xsy,string czy,string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhygl_add_edit Hhygl_add_edit_new = new Hhygl.Hhygl_add_edit();
            s = Hhygl_add_edit_new.Hhygl_add_edit_delete_app(id, yydh, qymc, hykh, hyrx, hykh_bz, krxm, krgj, krmz, yxzj, zjhm, krsr, krxb, krdh, krsj, krEmail, krdz, krzy, krdw, qzrx, qzhm, zjyxq, tlyxq, tjrq, lzka, bz, hyjf, shxg, xgsj,parent_hykh,hymm, xsy,czy,add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description="会员级别增册改")]
        public string Hhyjb_add_edit(string id, string yydh, string qymc, string jbxs, string hyrx, string dfjf, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjb Hhyjb_add_edit_new = new Hhyjb();
            s = Hhyjb_add_edit_new.Hhyjb_add_edit(id, yydh, qymc, jbxs, hyrx, dfjf, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "会员积分比例增册改")]
        public string Hhyjfbl_add_edit(string id, string yydh, string qymc, string krly, string hyrx, string jfbl, string hyjfrx, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_bl Hhyjfbl_add_edit_new = new Hhyjf_bl();
            s = Hhyjfbl_add_edit_new.Hhyjfbl_add_edit(id, yydh, qymc,krly, hyrx,jfbl,hyjfrx, add_edit_delete, xxzs);
            return s;
        }
 
        [WebMethod(Description = "会员积分兑换增册改")]
        public string Hhyjfdf_add_edit(string id, string yydh, string qymc, string hykh, string hykh_bz, string krxm, string dfjf, string dfxm, string dfsl, string lsbh_df, string parent_hykh, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_df Hhyjfdf_add_edit_new = new Hhyjf_df();
            s = Hhyjfdf_add_edit_new.Hhyjfdf_add_edit(id, yydh, qymc, hykh, hykh_bz, krxm, dfjf, dfxm, dfsl,lsbh_df,parent_hykh, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "会员积分奖品增册改")]
        public string Hhyjfjp_add_edit(string id, string yydh, string qymc,string classname, string title, string jpjf, string simg, string bimg, string info, string bz, string hyjfrx, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_jp Hhyjfjp_add_edit_new = new Hhyjf_jp();
            s = Hhyjfjp_add_edit_new.Hhyjfjp_add_edit(id, yydh, qymc, classname, title, jpjf, simg, bimg, info, bz, hyjfrx, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "奖品类型增册改")]
        public string Hhyjfjpclass_add_edit(string id, string title, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_jp_class Hhyjfjpclass_add_edit_new = new Hhyjf_jp_class();
            s = Hhyjfjpclass_add_edit_new.Hhyjfjpclass_add_edit(id,title,add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "增补会员积分消费")]
        public string Hhyjf_gc_app_news(string hykh, string yydh, string qymc,string lsbh, string sjxfje, string czy)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_xfjl Hhyjfxfjl_add_edit_new = new Hhyjf_xfjl();
            s = Hhyjfxfjl_add_edit_new.Hhyjf_gc_app_news(hykh, yydh, qymc,lsbh, sjxfje, czy);
            return s;
        }

        [WebMethod(Description = "会员房价增册改")]
        public string Hhyfj_add_edit(string id, string yydh, string qymc, string hyrx, string fjrb, string hyfj, string bz, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyfj Hhyfj_add_edit_new = new Hhyfj();
            s = Hhyfj_add_edit_new.Hhyfj_add_edit(id, yydh, qymc, hyrx, fjrb, hyfj, bz, add_edit_delete, xxzs);
            return s;
        }


        //用于验证验证码
        [WebMethod(Description = "用于验证验证码")]
        public string Hhygl_verifyCode(string phoneNo,string local_VerifyCode, string yydh, string qymc, string bz, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            s = common_file.common_app.get_failure;
            Hhygl_verifyCode Hhygl_verifyCode_new = new Hhygl_verifyCode();
            s = Hhygl_verifyCode_new.CheckVerifyCode(phoneNo,local_VerifyCode, yydh, qymc, bz, add_edit_delete, xxzs);
            return s;
        }

        //用于生成验证码并发送手机短信
        [WebMethod(Description = "生成验证码")]
        public string Hhygl_generateVerifyCode(string phoneNo, string krxm, string Sendtime, string yydh, string qymc, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            s = common_file.common_app.get_failure;
            Hhygl_verifyCode Hhygl_verifyCode_new = new Hhygl_verifyCode();
            s = Hhygl_verifyCode_new.generateVerifyCode(phoneNo, krxm,Sendtime, yydh, qymc,xxzs);
            return s;
        }
        //用于向会员发送手机提示短信（登记，续住，退房）
        [WebMethod(Description = "用于向会员发送提示信息")]
        public string Hhygl_SendMsm(string phoneNo, string msm_title, string yydh, string qymc, string hyAction, string timeNow, string ddsj, string lksj, string fx, string hykh, string xf, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            s = common_file.common_app.get_failure;
            Hhygl_verifyCode Hhygl_verifyCode_new = new Hhygl_verifyCode();
            s = Hhygl_verifyCode_new.Hhygl_SendMsm(phoneNo, msm_title, yydh, qymc, hyAction, timeNow, ddsj, lksj, fx, hykh, xf, xxzs);
            return s;
        }
        [WebMethod(Description = "用于向所选的人员发送短信息（临时发送的）")]
        public string[] Hhygl_SendMsm_temporay(string phoneNo, string krxm, string content, string yydh, string qymc, string hyAction, string xxzs)
        {
            string[] retureResult = new string[2];
            retureResult[0] = common_file.common_app.get_failure;//指示是否发送成功
            retureResult[1] = "";//存储发送的代码返回值
            Hhygl_verifyCode Hhygl_verifyCode_new = new Hhygl_verifyCode();
            retureResult = Hhygl_verifyCode_new.Hhygl_SendMsm_temporay(phoneNo, krxm, content, yydh, qymc, hyAction, xxzs);
            return retureResult;
        }
    }
}
