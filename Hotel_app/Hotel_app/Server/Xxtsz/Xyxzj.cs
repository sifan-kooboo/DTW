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
    public class Xyxzj
    {


        public string Xyxzj_add_edit(string id, string yydh, string qymc, string zjm, string yxzj, string add_edit_delete, string xxzs)
        {
            
            string s = common_file.common_app.get_failure;
            BLL.Xyxzj B_Xyxzj = new Hotel_app.BLL.Xyxzj();
            Model.Xyxzj M_Xyxzj = new Hotel_app.Model.Xyxzj();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xyxzj.yydh = yydh;
                M_Xyxzj.qymc = qymc;
                M_Xyxzj.zjm = zjm;
                M_Xyxzj.yxzj =yxzj;
                //M_Xyxzj.is_top =is_top;
                //M_Xyxzj.is_select =is_select;


                //int ss = B_Xyxzj.Add(M_Xyxzj);

                if (B_Xyxzj.Add(M_Xyxzj) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xyxzj = B_Xyxzj.GetModel(Convert.ToInt32(id));
                    M_Xyxzj.yydh = yydh;
                    M_Xyxzj.qymc = qymc;
                    M_Xyxzj.zjm = zjm;
                    M_Xyxzj.yxzj =yxzj;
                    //M_Xyxzj.is_top = is_top;
                    //M_Xyxzj.is_select = is_select;
                    M_Xyxzj.id = int.Parse(id); 
                    if (B_Xyxzj.Update(M_Xyxzj))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xyxzj.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
