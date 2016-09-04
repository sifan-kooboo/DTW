using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Hotel_app.Server.Yyxzx;

namespace Hotel_app.Server.Yyxzx
{
    /// <summary>
    /// Yyxzx_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Yyxzx_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "用于协议单位的增删改")]
        public string Yxydw_add_edit(string id, string yydh, string qymc, string zjm, string xyrx, string xyh_inner, string xydw, string nxr, string krdh, string kremail, string krcz, string krdz, string xsy, string bz,string krly, byte[] sign_image,string rx,string xyh, string add_edit_delete, string xxzs,string  sxed)
        {
            string s = Hotel_app.common_file.common_app.get_failure;
  
            Yyxzx.Yxydw Yxydw_add_edit_new = new Yxydw();

            s = Yxydw_add_edit_new.Yxydw_add_edit(id, yydh, qymc,zjm,xyrx,xyh_inner,xydw,nxr,krdh,kremail,krcz,krdz,xsy,bz,krly,sign_image,rx,xyh,add_edit_delete, xxzs,sxed);
            return s;
        }
        [WebMethod(Description = "用于销售员的增删改")]
        public string Yxsy_add_edit(string id, string yydh, string qymc, string zjm, string xsy, string add_edit_delete, string xxzs)
        {
            string s = common_file_server.common_app.get_failure;
            Yyxzx.Yxsy Yxsy_add_edit_new = new Yxsy();
            s = Yxsy_add_edit_new.Yxsy_add_edit(id, yydh, qymc, zjm, xsy, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "设置协议单位的fjrb")]
        public string Yxydw_fjrb_add_edit(string id, string yydh, string qymc, string fjrb_code, string fjrb, string sjjg, string xyh, string xydw, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Yyxzx.Yxydw_fjrb Yxydw_fjrb_new = new Hotel_app.Server.Yyxzx.Yxydw_fjrb();
            s = Yxydw_fjrb_new.Yxydw_fjrb_add_edit(id, yydh, qymc, fjrb_code, fjrb, sjjg, xyh, xydw, add_edit_delete, xxzs);
            return s;
        }
    }
}
