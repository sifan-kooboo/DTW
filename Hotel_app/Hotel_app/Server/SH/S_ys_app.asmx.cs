using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Hotel_app.Server.SH;

namespace Hotel_app.Server.SH
{
    /// <summary>
    /// S_ys_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class S_ys_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        //夜审
        [WebMethod]
        public string New_ys(string yydh, string qymc, string czy, DateTime czsj, string syzd, string czy_bc, bool sh_ds, string bz, string xxzs, string czy_GUID)
        {
            string s = Hotel_app.common_file.common_app.get_failure;
            SH.S_ys S_ys_new = new S_ys();
            s = S_ys_new.New_ys(yydh, qymc, czy, czsj, syzd, czy_bc, sh_ds, bz, xxzs, czy_GUID);
            return s;
        }

    }
}
