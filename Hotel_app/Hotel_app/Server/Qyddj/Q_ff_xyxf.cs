using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Qyddj
{
    public class Q_ff_xyxf
    {

        public string add_edit_delete_Q_ff_xyxf(string id, string yydh, string qymc, string fyrx, string xfdr, string xfrb, string xfxm, decimal xfsl, decimal xfje, string add_edit_delete, string czy, DateTime czsj, string cznr, string xxzs, decimal jjje,string mxbh)
        {
            string s = common_file.common_app.get_failure;
            BLL.Q_ff_xyxf B_Q_ff_xyxf = new Hotel_app.BLL.Q_ff_xyxf();
            Model.Q_ff_xyxf M_Q_ff_xyxf = new Hotel_app.Model.Q_ff_xyxf();
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Q_ff_xyxf.yydh = yydh;
                M_Q_ff_xyxf.qymc = qymc;
                M_Q_ff_xyxf.fyrx = fyrx;
                M_Q_ff_xyxf.xfdr = xfdr;
                M_Q_ff_xyxf.xfrb = xfrb;
                M_Q_ff_xyxf.xfxm = xfxm;
                M_Q_ff_xyxf.xfsl = xfsl;
                M_Q_ff_xyxf.jjje = jjje;
                M_Q_ff_xyxf.xfje = xfje;
                M_Q_ff_xyxf.mxbh = mxbh;
                B_Q_ff_xyxf.Add(M_Q_ff_xyxf);
                s = common_file.common_app.get_suc;
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Q_ff_xyxf = B_Q_ff_xyxf.GetModel(int.Parse(id));
                    M_Q_ff_xyxf.fyrx = fyrx;
                    M_Q_ff_xyxf.xfdr = xfdr;
                    M_Q_ff_xyxf.xfrb = xfrb;
                    M_Q_ff_xyxf.xfxm = xfxm;
                    M_Q_ff_xyxf.xfsl = xfsl;
                    M_Q_ff_xyxf.jjje = jjje;
                    M_Q_ff_xyxf.xfje = xfje;
                    M_Q_ff_xyxf.mxbh = mxbh;
                    B_Q_ff_xyxf.Update(M_Q_ff_xyxf);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        B_Q_ff_xyxf.Delete(int.Parse(id));
                        s = common_file.common_app.get_suc;
                    }
            return s;

        }

        public void Qyddj_otherfee_add(string yydh, string qymc, string lsbh, string krxm, string sktt, string fjbh,string czy)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string insert_s = "";
            insert_s = "insert into Qyddj_otherfee(yydh,qymc,lsbh,krxm,sktt,fjbh,fyrx,xfdr,xfrb,xfxm,xfsl,jjje,xfje,shsc,czy,cznr,czsj,sdcz,mxbh)";
            insert_s = insert_s + "select '" + yydh + "','" + qymc + "','" + lsbh + "','" + krxm + "','" + sktt + "','" + fjbh + "',fyrx,xfdr,xfrb,xfxm,xfsl,jjje,xfje,0,'" + czy + "','',getdate(),0,mxbh from Q_ff_xyxf";
            B_Common.ExecuteSql(insert_s);
            //insert into Qyddj_otherfee(yydh,qymc,lsbh,krxm,sktt,fjbh,fyrx,xfdr,xfrb,xfxm,xfsl,jjje,xfje,shsc,czy,cznr,czsj,sdcz) 
            //select @yydh,@qymc,@lsbh,@krxm,@sktt,@fjbh,fyrx,xfdr,xfrb,xfxm,xfsl,jjje,xfje,0,@czy,'',getdate(),0 from Q_ff_xyxf
        }


    }
}
