using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

namespace Hotel_app.Server.Hhygl
{
    public class hhygl_shqr
    {

        public static bool hygl_shqr_add(string  yydh)
        {
            bool flage_hyrq_add = false;
            BLL.Qcounter B_qcounter_new = new Hotel_app.BLL.Qcounter();
            List<Model.Qcounter>  list=new List<Hotel_app.Model.Qcounter>();
            list=B_qcounter_new.GetModelList(" id>=0  and  yydh='"+yydh+"'");
            Model.Qcounter   M_qcounter=null;
            if (list != null&&list.Count>=1)
            {
                flage_hyrq_add = bool.Parse(list[0].Hhygl_qyqr.ToString());
            }

            return flage_hyrq_add;
        }
    }
}
