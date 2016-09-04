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
    public class Yxydw
    {
        public string Yxydw_add_edit(string id, string yydh, string qymc, string zjm, string xyrx, string xyh_inner, string xydw, string nxr, string krdh, string kremail, string krcz, string krdz, string xsy, string bz,string krly,byte[] sign_image,string rx,string xyh,string add_edit_delete, string xxzs,string sxed)
        {
           

            string s = common_file.common_app.get_failure;
            BLL.Yxydw B_Yxydw = new Hotel_app.BLL.Yxydw();
            Model.Yxydw M_Yxydw = new Hotel_app.Model.Yxydw();
            Decimal sxed_get = 0;
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            try
            {
                sxed_get = decimal.Parse(sxed);
            }
            catch 
            {
                sxed_get = 0;
            } 
             
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Yxydw.yydh = yydh;
                M_Yxydw.qymc = qymc;
                M_Yxydw.zjm = zjm;
                M_Yxydw.xyrx =xyrx;
                M_Yxydw.xyh_inner = xyh_inner;
                M_Yxydw.xydw = xydw;
                M_Yxydw.nxr = nxr;
                M_Yxydw.krdh = krdh;
                M_Yxydw.krEmail = kremail;
                M_Yxydw.krcz = krcz;
                M_Yxydw.krdz = krdz;
                M_Yxydw.xsy = xsy;
                M_Yxydw.bz = bz;
                M_Yxydw.krly = krly;
                M_Yxydw.rx = rx;
                M_Yxydw.xyh = xyh;

                //M_Yxydw.sign_image = System.Text.Encoding.Default.GetBytes(sign_image);
                M_Yxydw.sign_image = sign_image;
                M_Yxydw.xsed = sxed_get;
                M_Yxydw.clsj = DateTime.Now;
                //M_Yxydw.is_top =is_top;
                //M_Yxydw.is_select =is_select;


                //int ss = B_Yxydw.Add(M_Yxydw);

                if (B_Yxydw.Add(M_Yxydw) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Yxydw = B_Yxydw.GetModel(Convert.ToInt32(id));
                    M_Yxydw.yydh = yydh;
                    M_Yxydw.qymc = qymc;
                    M_Yxydw.zjm = zjm;
                    M_Yxydw.xyrx = xyrx;
                    M_Yxydw.xyh_inner = xyh_inner;
                    M_Yxydw.xydw = xydw;
                    M_Yxydw.nxr = nxr;
                    M_Yxydw.krdh = krdh;
                    M_Yxydw.krEmail = kremail;
                    M_Yxydw.krcz = krcz;
                    M_Yxydw.krdz = krdz;
                    M_Yxydw.xsy = xsy;
                    M_Yxydw.bz = bz;
                    M_Yxydw.krly = krly;
                    M_Yxydw.rx = rx;
                    M_Yxydw.xyh = xyh;
                    M_Yxydw.shsc = false;
                    M_Yxydw.id = int.Parse(id);
                   // M_Yxydw.sign_image = System.Text.Encoding.Default.GetBytes(sign_image);
                    //M_Yxydw.is_top = is_top;
                    //M_Yxydw.is_select = is_select;
                    M_Yxydw.sign_image = sign_image;
                    M_Yxydw.xsed = sxed_get;
                    if (B_Yxydw.Update(M_Yxydw))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Yxydw.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
