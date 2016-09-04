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
    public class Hhyjf_df
    {
        //id,yydh,qymc,hykh,hykh_bz,krxm,dfjf,dfxm,dfsl,xfsj,shsc,scsj,is_top,is_select
        public string Hhyjfdf_add_edit(string id, string yydh, string qymc, string hykh, string hykh_bz, string krxm, string dfjf, string dfxm, string dfsl,string lsbh_df,string parent_hykh, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Hhyjf_df B_Hhyjfdf = new Hotel_app.BLL.Hhyjf_df();
            Model.Hhyjf_df M_Hhyjfdf = new Hotel_app.Model.Hhyjf_df();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Hhyjfdf.yydh = yydh;
                M_Hhyjfdf.qymc = qymc;
                M_Hhyjfdf.hykh=hykh;
                M_Hhyjfdf.hykh_bz=hykh_bz;
                M_Hhyjfdf.krxm=krxm;
                M_Hhyjfdf.dfjf=Convert.ToDecimal(dfjf);
                M_Hhyjfdf.dfxm=dfxm;
                M_Hhyjfdf.dfsl=Convert.ToDecimal(dfsl);
                M_Hhyjfdf.lsbh_df = lsbh_df;
                M_Hhyjfdf.xfrq = DateTime.Now.Date;
                M_Hhyjfdf.parent_hykh = parent_hykh;
                if (B_Hhyjfdf.Add(M_Hhyjfdf) > 0)
                {
                    s = common_file.common_app.get_suc;
                    
            
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Hhyjfdf = B_Hhyjfdf.GetModel(Convert.ToInt32(id));

                    M_Hhyjfdf.hykh=hykh;
                    M_Hhyjfdf.hykh_bz=hykh_bz;
                    M_Hhyjfdf.krxm=krxm;
                    M_Hhyjfdf.dfjf=Convert.ToDecimal(dfjf);
                    M_Hhyjfdf.dfxm=dfxm;
                    M_Hhyjfdf.lsbh_df = lsbh_df;
                    M_Hhyjfdf.id = int.Parse(id);
                    M_Hhyjfdf.parent_hykh = parent_hykh;
                    B_Hhyjfdf.Update(M_Hhyjfdf);
                    s = common_file.common_app.get_suc;
                    //common_file.common_czjl.add_czjl(yydh, qymc, czy, "积分兑换", "卡号：" + hykh_bz + "姓名：" + krxm + "", "积分：" + dfjf + " 兑换名称：" + dfxm + "", DateTime.Now);
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Hhyjfdf.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                            
                        }
                    }
            return s;
        }
     
    }
}
