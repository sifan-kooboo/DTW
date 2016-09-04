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
    /// <summary>
    /// 投诉建议
    /// 客人喜好
    /// </summary>
    public class Qyddj_other
    {
        /// <summary>
        /// 新增主要用来增加投诉建议、修改用来增加处理意见
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="lsbh"></param>
        /// <param name="fjbh"></param>
        /// <param name="sktt"></param>
        /// <param name="krxm"></param>
        /// <param name="krsj"></param>
        /// <param name="zjhm"></param>
        /// <param name="xyh"></param>
        /// <param name="xydw"></param>
        /// <param name="hykh"></param>
        /// <param name="tsrx"></param>
        /// <param name="tsnr"></param>
        /// <param name="tssj"></param>
        /// <param name="czy"></param>
        /// <param name="clbm"></param>
        /// <param name="clnr"></param>
        /// <param name="clsj"></param>
        /// <param name="cly"></param>
        /// <returns></returns>
        public string Qtsjy_add_edit(string id, string yydh, string qymc, string lsbh, string fjbh, string sktt, string krxm, string krsj, string zjhm, string xyh, string xydw, string hykh, string tsrx, string tsnr, DateTime tssj, string czy, string clbm, string clnr, DateTime clsj, string cly, string add_edit, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Qtsjy B_Qtsjy = new Hotel_app.BLL.Qtsjy();
            Model.Qtsjy M_Qtsjy = new Hotel_app.Model.Qtsjy();
            if (add_edit == common_file.common_app.get_add)
            {
                M_Qtsjy.yydh = yydh; M_Qtsjy.qymc = qymc; M_Qtsjy.lsbh = lsbh;
                M_Qtsjy.fjbh = fjbh; M_Qtsjy.sktt = sktt; M_Qtsjy.krxm = krxm; M_Qtsjy.krsj = krsj; M_Qtsjy.zjhm = zjhm;
                M_Qtsjy.xyh = xyh; M_Qtsjy.xydw = xydw; M_Qtsjy.hykh = hykh; M_Qtsjy.tsrx = tsrx; M_Qtsjy.tsnr = tsnr;
                M_Qtsjy.tssj = tssj; M_Qtsjy.czy = czy; M_Qtsjy.clbm = clbm; M_Qtsjy.clnr = clnr; M_Qtsjy.clsj = clsj;
                M_Qtsjy.cly = cly;
                if (B_Qtsjy.Add(M_Qtsjy) > 0)
                {
                    s = common_file.common_app.get_suc;
                }

            }
            else
                if (add_edit == common_file.common_app.get_edit)
                {
                    if (id != "")
                    {
                        M_Qtsjy = B_Qtsjy.GetModel(int.Parse(id));
                        if (M_Qtsjy != null)
                        {



                            M_Qtsjy.clbm = clbm; M_Qtsjy.clnr = clnr; M_Qtsjy.clsj = clsj;
                            M_Qtsjy.cly = cly;
                            if (B_Qtsjy.Update(M_Qtsjy) == true)
                            {
                                s = common_file.common_app.get_suc;
                            }

                        }
                    }

                }
            return s;
        }

        public string Qkrxh_add_edit_delete(string id, string yydh, string qymc, string krxm, string krsj, string zjhm, string hykh, string xhrx, string krxh, string bz, string czy, DateTime czsj, string add_edit, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Qkrxh B_Qkrxh = new Hotel_app.BLL.Qkrxh();
            Model.Qkrxh M_Qkrxh = new Hotel_app.Model.Qkrxh();
            if (add_edit == common_file.common_app.get_add)
            {
                M_Qkrxh.yydh=yydh;  M_Qkrxh.qymc=qymc; M_Qkrxh.krxm=krxm; M_Qkrxh.krsj=krsj;
                M_Qkrxh.zjhm=zjhm;M_Qkrxh.hykh=hykh;M_Qkrxh.xhrx=xhrx;M_Qkrxh.krxh=krxh;
                M_Qkrxh.bz = bz; M_Qkrxh.czy = czy; M_Qkrxh.czsj = czsj;
                if (B_Qkrxh.Add(M_Qkrxh) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            if (add_edit == common_file.common_app.get_edit)
            {
                M_Qkrxh = B_Qkrxh.GetModel(int.Parse(id));
                if (M_Qkrxh != null)
                {
                    M_Qkrxh.yydh = yydh; M_Qkrxh.qymc = qymc; M_Qkrxh.krxm = krxm; M_Qkrxh.krsj = krsj;
                    M_Qkrxh.zjhm = zjhm; M_Qkrxh.hykh = hykh; M_Qkrxh.xhrx = xhrx; M_Qkrxh.krxh = krxh;
                    M_Qkrxh.bz = bz; M_Qkrxh.czy = czy; M_Qkrxh.czsj = czsj;
                    M_Qkrxh.id = int.Parse(id);
                    if (B_Qkrxh.Update(M_Qkrxh))
                    {
                        s = common_file.common_app.get_suc;   
                    }
                }
            }
            else
                if (add_edit == common_file.common_app.get_delete)
                {
                    if (B_Qkrxh.Delete(int.Parse(id)) == true)
                    {
                        s = common_file.common_app.get_suc;
                    }

                }
            return s;
        }
    }
}
