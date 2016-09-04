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
    public class Xxfsz
    {
        public string Xxfsz_add_edit(string id, string yydh, string qymc, string drbh, string xfdr, string xrbh, string xfxr, string xfje,bool is_visible_bb, string add_edit_delete, string xxzs)
        {


            string s = common_file.common_app.get_failure;
            BLL.Xxfxr B_Xxfxr = new Hotel_app.BLL.Xxfxr();
            Model.Xxfxr M_Xxfxr = new Hotel_app.Model.Xxfxr();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xxfxr.yydh = yydh;
                M_Xxfxr.qymc = qymc;
                M_Xxfxr.drbh = drbh;
                M_Xxfxr.xfdr = xfdr;
                M_Xxfxr.xrbh = xrbh;
                M_Xxfxr.xfxr = xfxr;
                M_Xxfxr.is_visible_bb = is_visible_bb;
                M_Xxfxr.xfje = Convert.ToDecimal(xfje);
                //M_Xxfxr.is_top = Convert.ToBoolean(is_top);
                //M_Xxfxr.is_select = Convert.ToBoolean(is_select);

                if (B_Xxfxr.Add(M_Xxfxr) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xxfxr = B_Xxfxr.GetModel(Convert.ToInt32(id));
                    M_Xxfxr.yydh = yydh;
                    M_Xxfxr.qymc = qymc;
                    M_Xxfxr.drbh = drbh;
                    M_Xxfxr.xfdr = xfdr;
                    M_Xxfxr.xrbh = xrbh;
                    M_Xxfxr.xfxr = xfxr;
                    M_Xxfxr.is_visible_bb = is_visible_bb;
                    M_Xxfxr.xfje = Convert.ToDecimal(xfje);
                    //M_Xxfxr.is_top = Convert.ToBoolean(is_top);
                    //M_Xxfxr.is_select = Convert.ToBoolean(is_select);
                    M_Xxfxr.id = int.Parse(id);
                    if (B_Xxfxr.Update(M_Xxfxr))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xxfxr.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
