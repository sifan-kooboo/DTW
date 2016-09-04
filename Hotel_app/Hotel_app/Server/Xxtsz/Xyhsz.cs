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
    public class Xyhsz
    {


        public string Xyhsz_add_edit(string id, string yydh, string qymc, string yhbl, string yh, string add_edit_delete, string xxzs)
        {
            
            string s = common_file.common_app.get_failure;
            BLL.Xyhsz B_Xyhsz = new Hotel_app.BLL.Xyhsz();
            Model.Xyhsz M_Xyhsz = new Hotel_app.Model.Xyhsz();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xyhsz.yydh = yydh;
               
                M_Xyhsz.qymc = qymc;


                M_Xyhsz.yhbl = common_file_server.common_app.ValideStringCheck(yhbl,1);  // decimal.Parse(yhbl);
                M_Xyhsz.yh =yh;
                //M_Xyxzj.is_top =is_top;
                //M_Xyxzj.is_select =is_select;


                //int ss = B_Xyxzj.Add(M_Xyxzj);

                if (B_Xyhsz.Add(M_Xyhsz) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xyhsz = B_Xyhsz.GetModel(Convert.ToInt32(id));
                    M_Xyhsz.yydh = yydh;
                    M_Xyhsz.qymc = qymc;
                    M_Xyhsz.yhbl = decimal.Parse(yhbl);
                    M_Xyhsz.yh = yh;
                    //M_Xyxzj.is_top = is_top;
                    //M_Xyxzj.is_select = is_select;
                    M_Xyhsz.ID = int.Parse(id);
                    if (B_Xyhsz.Update(M_Xyhsz))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xyhsz.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
