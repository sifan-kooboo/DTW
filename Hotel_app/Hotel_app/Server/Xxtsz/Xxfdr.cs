using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Xxtsz
{
    public class Xxfdr
    {
        public string Xxfdr_add_edit(string id, string yydh, string qymc, string drbh, string xfdr, string xfje, bool is_visible_bb,string add_edit_delete, string xxzs)
        {


            string s = common_file.common_app.get_failure;
            BLL.Xxfdr B_Xxfdr = new Hotel_app.BLL.Xxfdr();
            Model.Xxfdr M_Xxfdr = new Hotel_app.Model.Xxfdr();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xxfdr.yydh = yydh;
                M_Xxfdr.qymc = qymc;
                M_Xxfdr.drbh = drbh;
                M_Xxfdr.xfdr = xfdr;
                M_Xxfdr.is_visible_bb = is_visible_bb;
                M_Xxfdr.xfje = Convert.ToDecimal(xfje);
               

                if (B_Xxfdr.Add(M_Xxfdr) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xxfdr = B_Xxfdr.GetModel(Convert.ToInt32(id));
                    M_Xxfdr.yydh = yydh;
                    M_Xxfdr.qymc = qymc;
                    M_Xxfdr.drbh = drbh;
                    M_Xxfdr.xfdr = xfdr;
                  
                    M_Xxfdr.xfje = Convert.ToDecimal(xfje);
                    M_Xxfdr.is_visible_bb = is_visible_bb;
                    M_Xxfdr.id = int.Parse(id);
                    if (B_Xxfdr.Update(M_Xxfdr))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xxfdr.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
