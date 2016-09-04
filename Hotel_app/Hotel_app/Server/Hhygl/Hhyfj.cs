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
    public class Hhyfj
    {
        
        //id,yydh,qymc,hyrx,fjrb,hyfj,bz,shsc,is_top,is_select
        public string Hhyfj_add_edit(string id, string yydh, string qymc, string hyrx, string fjrb, string hyfj, string bz, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Hhyfj B_Hhyfj = new Hotel_app.BLL.Hhyfj();
            Model.Hhyfj M_Hhyfj = new Hotel_app.Model.Hhyfj();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Hhyfj.yydh = yydh;
                M_Hhyfj.qymc = qymc;
                M_Hhyfj.hyrx = hyrx;
                M_Hhyfj.fjrb = fjrb;
                M_Hhyfj.bz = bz;
                M_Hhyfj.hyfj = Convert.ToDecimal(hyfj);
          
                if (B_Hhyfj.Add(M_Hhyfj) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Hhyfj = B_Hhyfj.GetModel(Convert.ToInt32(id));

                    M_Hhyfj.qymc = qymc;
                    M_Hhyfj.hyrx = hyrx;
                    M_Hhyfj.fjrb = fjrb;
                    M_Hhyfj.bz = bz;
                    M_Hhyfj.hyfj = Convert.ToDecimal(hyfj);

                    M_Hhyfj.id = int.Parse(id);
                    B_Hhyfj.Update(M_Hhyfj);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Hhyfj.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
