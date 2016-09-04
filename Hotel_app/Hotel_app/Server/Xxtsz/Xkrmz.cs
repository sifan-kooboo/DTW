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
    public class Xkrmz
    {
        public string Xkrmz_add_edit(string id, string yydh, string qymc, string krmz, string zjm, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Xkrmz B_Xkrmz = new Hotel_app.BLL.Xkrmz();
            Model.Xkrmz M_Xkrmz = new Hotel_app.Model.Xkrmz();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xkrmz.yydh = yydh;
                M_Xkrmz.qymc = qymc;
                M_Xkrmz.krmz = krmz;
                M_Xkrmz.zjm = zjm;
                if (B_Xkrmz.Add(M_Xkrmz) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xkrmz = B_Xkrmz.GetModel(Convert.ToInt32(id));
                    M_Xkrmz.krmz = krmz;
                    M_Xkrmz.zjm = zjm;
                    B_Xkrmz.Update(M_Xkrmz);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xkrmz.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }

    }
}
