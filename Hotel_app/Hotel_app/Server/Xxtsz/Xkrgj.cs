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
    public class Xkrgj
    {
        public string Xkrgj_add_edit(string id, string yydh, string qymc, string krgj, string zjm,string pq,string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Xkrgj B_Xkrgj = new Hotel_app.BLL.Xkrgj();
            Model.Xkrgj M_Xkrgj = new Hotel_app.Model.Xkrgj();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xkrgj.yydh = yydh; 
                M_Xkrgj.qymc = qymc; 
                M_Xkrgj.krgj = krgj;
                M_Xkrgj.pq = pq;
                M_Xkrgj.zjm = zjm;
                if (B_Xkrgj.Add(M_Xkrgj) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xkrgj = B_Xkrgj.GetModel(Convert.ToInt32(id));
                    M_Xkrgj.krgj = krgj;
                    M_Xkrgj.zjm = zjm;
                    M_Xkrgj.pq = pq;
                    M_Xkrgj.id = int.Parse(id);
                    B_Xkrgj.Update(M_Xkrgj);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xkrgj.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
