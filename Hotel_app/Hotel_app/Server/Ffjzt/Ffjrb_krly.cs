using System;
using System.Data;
using System.Configuration;
namespace Hotel_app.Server.Ffjzt
{
    public class Ffjrb_krly
    {
        //id,yydh,qymc,krly,fjrb,fjrb_code,sjjg,is_top,is_select
        public string Ffjrb_krly_add_edit(string id, string yydh, string qymc, string fjrb_code, string fjrb, string sjjg, string krly, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Ffjrb_krly B_Ffjrb_krly = new Hotel_app.BLL.Ffjrb_krly();
            Model.Ffjrb_krly M_Ffjrb_krly = new Hotel_app.Model.Ffjrb_krly();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Ffjrb_krly.yydh = yydh; M_Ffjrb_krly.qymc = qymc; M_Ffjrb_krly.fjrb_code = fjrb_code;
                M_Ffjrb_krly.fjrb = fjrb; M_Ffjrb_krly.sjjg = Convert.ToDecimal(sjjg);
                M_Ffjrb_krly.krly = krly;
                B_Ffjrb_krly.Add(M_Ffjrb_krly);
                s = common_file.common_app.get_suc;
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Ffjrb_krly = B_Ffjrb_krly.GetModel(Convert.ToInt32(id));
                    M_Ffjrb_krly.fjrb_code = fjrb_code;
                    M_Ffjrb_krly.fjrb = fjrb;
                    M_Ffjrb_krly.sjjg = Convert.ToDecimal(sjjg);
                    M_Ffjrb_krly.krly = krly;
                    B_Ffjrb_krly.Update(M_Ffjrb_krly);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Ffjrb_krly.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;

        }
    }
}
