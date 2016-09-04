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
    public class Xkrly
    {
        public string Xkrly_add_edit(string id, string yydh, string qymc, string krly, string zjm, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Xkrly B_Xkrly = new Hotel_app.BLL.Xkrly();
            Model.Xkrly M_Xkrly = new Hotel_app.Model.Xkrly();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xkrly.yydh = yydh; 
                M_Xkrly.qymc = qymc; 
                M_Xkrly.krly = krly;
                M_Xkrly.zjm = zjm;
                if (B_Xkrly.Add(M_Xkrly) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xkrly = B_Xkrly.GetModel(Convert.ToInt32(id));
                    M_Xkrly.krly = krly;
                    M_Xkrly.zjm = zjm;
                    B_Xkrly.Update(M_Xkrly);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xkrly.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
