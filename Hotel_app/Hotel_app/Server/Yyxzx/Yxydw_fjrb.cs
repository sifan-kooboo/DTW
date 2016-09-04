using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Yyxzx
{
    public class Yxydw_fjrb
    {
       // id,yydh,qymc,xyh,xydw,fjrb,fjrb_code,sjjg,is_top,is_select
        public string Yxydw_fjrb_add_edit(string id, string yydh, string qymc, string fjrb_code, string fjrb, string sjjg, string xyh,string xydw, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Yxydw_fjrb B_Yxydw_fjrb = new Hotel_app.BLL.Yxydw_fjrb();
            Model.Yxydw_fjrb M_Yxydw_fjrb = new Hotel_app.Model.Yxydw_fjrb();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Yxydw_fjrb.yydh = yydh; M_Yxydw_fjrb.qymc = qymc; M_Yxydw_fjrb.fjrb_code = fjrb_code;
                M_Yxydw_fjrb.fjrb = fjrb; M_Yxydw_fjrb.sjjg = Convert.ToDecimal(sjjg);
               
                M_Yxydw_fjrb.xyh = xyh;
                M_Yxydw_fjrb.xydw = xydw;

                B_Yxydw_fjrb.Add(M_Yxydw_fjrb);
                s = common_file.common_app.get_suc;
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Yxydw_fjrb = B_Yxydw_fjrb.GetModel(Convert.ToInt32(id));
                    M_Yxydw_fjrb.fjrb_code = fjrb_code;
                    M_Yxydw_fjrb.fjrb = fjrb;
                    M_Yxydw_fjrb.sjjg = Convert.ToDecimal(sjjg);
                   
                    M_Yxydw_fjrb.xyh = xyh;
                    M_Yxydw_fjrb.xydw = xydw;
                    B_Yxydw_fjrb.Update(M_Yxydw_fjrb);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Yxydw_fjrb.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;

        }
    }
}
