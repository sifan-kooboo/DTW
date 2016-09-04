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
    public class Xkrrx
    {
        public string Xkrrx_add_edit(string id, string yydh, string qymc, string krrx, string zjm, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Xkrrx B_Xkrrx = new Hotel_app.BLL.Xkrrx();
            Model.Xkrrx M_Xkrrx = new Hotel_app.Model.Xkrrx();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xkrrx.yydh = yydh; 
                M_Xkrrx.qymc = qymc; 
                M_Xkrrx.krrx = krrx;
                M_Xkrrx.zjm = zjm;
                if (B_Xkrrx.Add(M_Xkrrx) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xkrrx = B_Xkrrx.GetModel(Convert.ToInt32(id));
                    M_Xkrrx.krrx = krrx;
                    M_Xkrrx.zjm = zjm;
                    B_Xkrrx.Update(M_Xkrrx);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xkrrx.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
