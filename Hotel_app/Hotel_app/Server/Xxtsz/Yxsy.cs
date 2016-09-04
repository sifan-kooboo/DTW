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
    public class Yxsy
    {


        public string Yxsy_add_edit(string id, string yydh, string qymc, string zjm, string xsy, string add_edit_delete, string xxzs)
        {
            
            string s = common_file.common_app.get_failure;
            BLL.Yxsy B_Yxsy = new Hotel_app.BLL.Yxsy();
            Model.Yxsy M_Yxsy = new Hotel_app.Model.Yxsy();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Yxsy.yydh = yydh;
                M_Yxsy.qymc = qymc;
                M_Yxsy.zjm = zjm;
                M_Yxsy.xsy =xsy;
                //M_Yxsy.is_top =is_top;
                //M_Yxsy.is_select =is_select;


                //int ss = B_Yxsy.Add(M_Yxsy);

                if (B_Yxsy.Add(M_Yxsy) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Yxsy = B_Yxsy.GetModel(Convert.ToInt32(id));
                    M_Yxsy.yydh = yydh;
                    M_Yxsy.qymc = qymc;
                    M_Yxsy.zjm = zjm;
                    M_Yxsy.xsy =xsy;
                    //M_Yxsy.is_top = is_top;
                    //M_Yxsy.is_select = is_select;
                    M_Yxsy.id = int.Parse(id);
                    if (B_Yxsy.Update(M_Yxsy))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Yxsy.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
