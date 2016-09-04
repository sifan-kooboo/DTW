using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Yhgl
{
    public class YH_bmsz
    {
        public string YH_bmsz_add_edit(string id, string yydh, string qymc, string zjm, string yhbm, string add_edit_delete, string xxzs)
        {

            string s = common_file.common_app.get_failure;
            BLL.YH_bmsz B_Bmsz= new Hotel_app.BLL.YH_bmsz();
            Model.YH_bmsz M_Bmsz = new Hotel_app.Model.YH_bmsz();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Bmsz.yydh = yydh;
                M_Bmsz.qymc = qymc;
                M_Bmsz.zjm = zjm;
                M_Bmsz.yhbm = yhbm;
                if (B_Bmsz.Add(M_Bmsz) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Bmsz = B_Bmsz.GetModel(Convert.ToInt32(id));
                    M_Bmsz.yydh = yydh;
                    M_Bmsz.qymc = qymc;
                    M_Bmsz.zjm = zjm;
                    M_Bmsz.yhbm =yhbm;
                    if (B_Bmsz.Update(M_Bmsz))
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Bmsz.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
