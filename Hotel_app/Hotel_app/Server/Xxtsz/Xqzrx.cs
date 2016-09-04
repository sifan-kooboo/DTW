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
    public class Xqzrx
    {

       
        public string Xqzrx_add_edit(string id, string yydh, string qymc, string zjm, string qzrx,string add_edit_delete, string xxzs)
        {
            
            string s = common_file.common_app.get_failure;
            BLL.Xqzrx B_Xqzrx = new Hotel_app.BLL.Xqzrx();
            Model.Xqzrx M_Xqzrx = new Hotel_app.Model.Xqzrx();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xqzrx.yydh = yydh;
                M_Xqzrx.qymc = qymc;
                M_Xqzrx.zjm = zjm;
                M_Xqzrx.qzrx =qzrx;
                //M_Xqzrx.is_top =is_top;
                //M_Xqzrx.is_select =is_select;


                //int ss = B_Xqzrx.Add(M_Xqzrx);

                if (B_Xqzrx.Add(M_Xqzrx) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xqzrx = B_Xqzrx.GetModel(Convert.ToInt32(id));
                    M_Xqzrx.yydh = yydh;
                    M_Xqzrx.qymc = qymc;
                    M_Xqzrx.zjm = zjm;
                    M_Xqzrx.qzrx = qzrx;
                    //M_Xqzrx.is_top = is_top;
                    //M_Xqzrx.is_select = is_select;
                
                    if (B_Xqzrx.Update(M_Xqzrx))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xqzrx.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
