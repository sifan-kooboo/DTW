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
    public class Hhyjf_jp
    {

        //ID,yydh,qymc,classid,Title,jpjf,simg,bimg,info,bz,isTuiJian,isshow,shsc,hyjfrx,is_top,is_select
        public string Hhyjfjp_add_edit(string id, string yydh, string qymc,string classname, string title, string jpjf, string simg, string bimg, string info, string bz, string hyjfrx, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Hhyjf_jp B_Hhyjfjp = new Hotel_app.BLL.Hhyjf_jp();
            Model.Hhyjf_jp M_Hhyjfjp = new Hotel_app.Model.Hhyjf_jp();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Hhyjfjp.yydh = yydh;
                M_Hhyjfjp.qymc = qymc;
                M_Hhyjfjp.classname = classname;
                M_Hhyjfjp.Title = title;
                M_Hhyjfjp.jpjf = Convert.ToDecimal(jpjf);
                M_Hhyjfjp.simg = simg;
                M_Hhyjfjp.bimg = bimg;
                M_Hhyjfjp.info = info;
                M_Hhyjfjp.bz = bz;


                

                if (B_Hhyjfjp.Add(M_Hhyjfjp) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Hhyjfjp = B_Hhyjfjp.GetModel(Convert.ToInt32(id));

                    M_Hhyjfjp.classname = classname;
                    M_Hhyjfjp.Title = title;
                    M_Hhyjfjp.jpjf = Convert.ToDecimal(jpjf);
                    M_Hhyjfjp.simg = simg;
                    M_Hhyjfjp.bimg = bimg;
                    M_Hhyjfjp.info = info;
                    M_Hhyjfjp.bz = bz;
                    M_Hhyjfjp.ID = int.Parse(id);
                    B_Hhyjfjp.Update(M_Hhyjfjp);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Hhyjfjp.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
