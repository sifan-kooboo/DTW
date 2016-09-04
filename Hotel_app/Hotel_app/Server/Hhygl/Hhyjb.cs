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
    public class Hhyjb
    {
        	//id,yydh,qymc,jbxs,hyrx,dfjf,is_top,is_select
        public string Hhyjb_add_edit(string id, string yydh, string qymc, string jbxs, string hyrx, string dfjf, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Hhyjb B_Hhyjb = new Hotel_app.BLL.Hhyjb();
            Model.Hhyjb M_Hhyjb = new Hotel_app.Model.Hhyjb();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Hhyjb.yydh = yydh;
                M_Hhyjb.qymc = qymc;
                M_Hhyjb.jbxs = Convert.ToInt32(jbxs);
                M_Hhyjb.hyrx = hyrx;
                M_Hhyjb.dfjf = Convert.ToDecimal(dfjf);
                if (B_Hhyjb.Add(M_Hhyjb) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Hhyjb = B_Hhyjb.GetModel(Convert.ToInt32(id));
                 
                    M_Hhyjb.jbxs = Convert.ToInt32(jbxs);
                    M_Hhyjb.hyrx = hyrx;
                    M_Hhyjb.dfjf = Convert.ToDecimal(dfjf);
                    M_Hhyjb.id = int.Parse(id);
                    B_Hhyjb.Update(M_Hhyjb);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Hhyjb.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
