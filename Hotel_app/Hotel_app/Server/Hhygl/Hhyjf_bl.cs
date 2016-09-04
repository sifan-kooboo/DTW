using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Hhygl
{
    public class Hhyjf_bl
    {
        //id,yydh,qymc,krly,hyrx,jfbl,hyjfrx,is_top,is_select
        public string Hhyjfbl_add_edit(string id, string yydh, string qymc, string krly, string hyrx, string jfbl,string hyjfrx, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Hhyjf_bl B_Hhyjfbl = new Hotel_app.BLL.Hhyjf_bl();
            Model.Hhyjf_bl M_Hhyjfbl = new Hotel_app.Model.Hhyjf_bl();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Hhyjfbl.yydh = yydh;
                M_Hhyjfbl.qymc = qymc;
                M_Hhyjfbl.krly = krly;
                M_Hhyjfbl.hyrx = hyrx;
                M_Hhyjfbl.jfbl = Convert.ToDecimal(jfbl);
                M_Hhyjfbl.hyjfrx = hyjfrx;
                if (B_Hhyjfbl.Add(M_Hhyjfbl) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Hhyjfbl = B_Hhyjfbl.GetModel(Convert.ToInt32(id));

                    M_Hhyjfbl.krly = krly;
                    M_Hhyjfbl.hyrx = hyrx;
                    M_Hhyjfbl.jfbl = Convert.ToDecimal(jfbl);
                    M_Hhyjfbl.id = int.Parse(id);
                    B_Hhyjfbl.Update(M_Hhyjfbl);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Hhyjfbl.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
