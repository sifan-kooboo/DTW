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
    public class Xqyxx
    {
        
      
        public string Xqyxx_add_edit(string id, string yydh, string qymc,string zjm,string qybh,string qydh,string qycz,string email,string nxr,string qydz,string add_edit_delete, string xxzs)
        {
            
            string s = common_file.common_app.get_failure;
            BLL.Xqyxx B_Xqyxx = new Hotel_app.BLL.Xqyxx();
            Model.Xqyxx M_Xqyxx = new Hotel_app.Model.Xqyxx();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xqyxx.yydh = yydh;
                M_Xqyxx.qymc = qymc;
                M_Xqyxx.zjm = zjm;
               
                M_Xqyxx.qybh = qybh;
                M_Xqyxx.qydh = qydh;
                M_Xqyxx.qycz=qycz;
                M_Xqyxx.Email=email;
                M_Xqyxx.nxr=nxr;
                M_Xqyxx.qydz=qydz;
              

               
                if (B_Xqyxx.Add(M_Xqyxx) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xqyxx = B_Xqyxx.GetModel(Convert.ToInt32(id));
                    M_Xqyxx.zjm = zjm;
                   
                    M_Xqyxx.qybh = qybh;
                    M_Xqyxx.qydh = qydh;
                    M_Xqyxx.qycz = qycz;
                    M_Xqyxx.Email = email;
                    M_Xqyxx.nxr = nxr;
                    M_Xqyxx.qydz = qydz;
                  
                    if (B_Xqyxx.Update(M_Xqyxx))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xqyxx.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
