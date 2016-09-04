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
    public class Xxfmx
    {
        public string Xxfmx_add_edit(string id, string yydh, string qymc, string drbh, string xfdr, string xrbh, string xfxr,string mxbh,string xfmx, string xfje,string zjm,string xfgg,string jjje,string xftm,string xfcd,string xfdw,string jldw,bool is_tj_kc,string kcsl,string add_edit_delete, string xxzs)
        {


            string s = common_file.common_app.get_failure;
            BLL.Xxfmx B_Xxfmx = new Hotel_app.BLL.Xxfmx();
            Model.Xxfmx M_Xxfmx = new Hotel_app.Model.Xxfmx();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xxfmx.yydh = yydh;
                M_Xxfmx.qymc = qymc;
                M_Xxfmx.drbh = drbh;
                M_Xxfmx.xfdr = xfdr;
                M_Xxfmx.xrbh = xrbh;
                M_Xxfmx.xfxr = xfxr;
                M_Xxfmx.mxbh = mxbh;
                M_Xxfmx.xfmx = xfmx;
                M_Xxfmx.zjm = zjm;
                M_Xxfmx.xfje = common_file_server.common_app.ValideStringCheck(xfje,0);// Convert.ToDecimal(xfje);
                M_Xxfmx.xfgg = xfgg;
                M_Xxfmx.jjje = common_file_server.common_app.ValideStringCheck(jjje, 0);// Convert.ToDecimal(jjje);
                M_Xxfmx.xftm = xftm;
                M_Xxfmx.xf_cd = xfcd;
                M_Xxfmx.xf_dw = xfdw;
                M_Xxfmx.jldw = jldw;
                M_Xxfmx.is_tj_kc = is_tj_kc;
                M_Xxfmx.kcsl = common_file_server.common_app.ValideStringCheck(kcsl, 1);// Convert.ToDecimal(kcsl);

                if (B_Xxfmx.Add(M_Xxfmx) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xxfmx = B_Xxfmx.GetModel(Convert.ToInt32(id));
                    M_Xxfmx.yydh = yydh;
                    M_Xxfmx.qymc = qymc;
                    M_Xxfmx.drbh = drbh;
                    M_Xxfmx.xfdr = xfdr;
                    M_Xxfmx.xrbh = xrbh;
                    M_Xxfmx.xfxr = xfxr;
                    M_Xxfmx.mxbh = mxbh;
                    M_Xxfmx.xfmx = xfmx;
                    M_Xxfmx.zjm = zjm;
                    M_Xxfmx.xfje = Convert.ToDecimal(xfje);
                    M_Xxfmx.xfgg = xfgg;
                    M_Xxfmx.jjje = Convert.ToDecimal(jjje);
                    M_Xxfmx.xftm = xftm;
                    M_Xxfmx.xf_cd = xfcd;
                    M_Xxfmx.xf_dw = xfdw;
                    M_Xxfmx.jldw = jldw;
                    M_Xxfmx.is_tj_kc = is_tj_kc;
                    M_Xxfmx.kcsl = Convert.ToDecimal(kcsl);
                    //M_Xxfxr.is_top = Convert.ToBoolean(is_top);
                    //M_Xxfxr.is_select = Convert.ToBoolean(is_select);
                    M_Xxfmx.id = int.Parse(id);
                    if (B_Xxfmx.Update(M_Xxfmx))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xxfmx.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
