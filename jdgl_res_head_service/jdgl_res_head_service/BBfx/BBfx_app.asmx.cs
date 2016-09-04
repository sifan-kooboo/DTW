using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace jdgl_res_head_service.BBfx
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
        [WebMethod(Description = "消费名细上传")]
        public string Ssyxfmx_UpLoadDS(DataSet DS)
        {
            string s = common_file.common_app.get_failure;
            BBfx.Ssyxfmx ssyxfmx_new = new BBfx.Ssyxfmx();

            s = ssyxfmx_new.Ssyxfmx_UpLoadDS(DS);
            return s;
        }
        [WebMethod(Description = "消费名细操作上传")]
        public string Ssyxfmx_cz_UpLoadDS(DataSet DS)
        {
            string s = common_file.common_app.get_failure;
            BBfx.Ssyxfmx_cz ssyxfmx_cz_new = new BBfx.Ssyxfmx_cz();

            s = ssyxfmx_cz_new.Ssyxfmx_cz_UpLoadDS(DS);
            return s;
        }
        [WebMethod(Description = "消费名细销售员上传")]
        public string Ssyxfmx_xsy_UpLoadDS(DataSet DS)
        {
            string s = common_file.common_app.get_failure;
            BBfx.Ssyxfmx_xsy ssyxfmx_new = new BBfx.Ssyxfmx_xsy();

            s = ssyxfmx_new.Ssyxfmx_xsy_UpLoadDS(DS);
            return s;
        }
        [WebMethod(Description = "删除ds里的日期报表")]
        public string BBzhrbb_Delete(string yydh, DataSet ds)
        {
            string s = common_file.common_app.get_failure;
            BBfx.BSzhrbb BBzhrbb_new = new BBfx.BSzhrbb();
            s = BBzhrbb_new.BSzhrbb_Delete(yydh, ds);
            return s;
 
        }
        [WebMethod(Description = "综合日报表上传")]
        public string BSzhrbb_UpLoadDS(DataSet DS)
        {
            string s = common_file.common_app.get_failure;
            BBfx.BSzhrbb BBzhrbb_new = new BBfx.BSzhrbb();
            s = BBzhrbb_new.BSzhrbb_UpLoadDS(DS);
            return s;
        }
        [WebMethod(Description = "综合日报表分录上传")]
        public string BSzhrbbfl_UpLoadDS(DataSet DS)
        {
            string s = common_file.common_app.get_failure;
            BBfx.BSzhrbbfl BSzhrbbfl_new = new BBfx.BSzhrbbfl();
            s = BSzhrbbfl_new.BSzhrbbfl_UpLoadDS(DS);
            return s;
        }
    }
}
