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
    public class Hhyjf_jp_class
    {
        public string Hhyjfjpclass_add_edit(string id, string title, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Hhyjf_jp_Class B_Hhyjfjpclass = new Hotel_app.BLL.Hhyjf_jp_Class();
            Model.Hhyjf_jp_Class M_Hhyjfjpclass = new Hotel_app.Model.Hhyjf_jp_Class();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {

                M_Hhyjfjpclass.Title = title;





                if (B_Hhyjfjpclass.Add(M_Hhyjfjpclass) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Hhyjfjpclass = B_Hhyjfjpclass.GetModel(Convert.ToInt32(id));


                    M_Hhyjfjpclass.Title = title;

                    M_Hhyjfjpclass.ID = Convert.ToInt32(id);
                    B_Hhyjfjpclass.Update(M_Hhyjfjpclass);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Hhyjfjpclass.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
