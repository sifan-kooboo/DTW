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
    public class Hhygl_add_edit
    {

        public string Hhygl_add_edit_delete_app(string id,string yydh,string qymc,string hykh,string hyrx,string hykh_bz,string krxm,string krgj,string krmz,string yxzj,string zjhm,string krsr,string krxb,string krdh,string krsj,string krEmail,string krdz,string krzy,string krdw,string qzrx,string qzhm,string zjyxq,string tlyxq,string tjrq,string lzka,string bz,string hyjf,string shxg,string xgsj,string parent_hykh,string hymm,string xsy,string czy,string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Hhygl B_Hhygl = new BLL.Hhygl();
            Model.Hhygl M_Hhygl = new Model.Hhygl();
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Hhygl.yydh = yydh;
                M_Hhygl.zjhm = zjhm;
                M_Hhygl.zjyxq = Convert.ToDateTime(zjyxq);
                M_Hhygl.bz = bz;
                M_Hhygl.hyjf = Convert.ToDecimal(hyjf);
                M_Hhygl.hykh = hykh;
                M_Hhygl.hyrx = hyrx;
                M_Hhygl.krdh = krdh;
                M_Hhygl.krdw = krdw;
                M_Hhygl.krdz = krdz;
                M_Hhygl.krEmail = krEmail;
                M_Hhygl.krgj = krgj;
                M_Hhygl.krmz = krmz;
                M_Hhygl.krsj = krsj;
                M_Hhygl.krsr = Convert.ToDateTime(krsr);
                M_Hhygl.krxb = krxb;
                M_Hhygl.krxm = krxm;
                M_Hhygl.krzy = krzy;
                M_Hhygl.hykh_bz = hykh_bz;
                M_Hhygl.lzka = lzka;
                M_Hhygl.qymc = qymc;
                M_Hhygl.qzhm = qzhm;
                M_Hhygl.qzrx = qzrx;
                M_Hhygl.shxg = Convert.ToBoolean(shxg);
                M_Hhygl.tjrq = Convert.ToDateTime(tjrq);
                M_Hhygl.tlyxq = Convert.ToDateTime(tlyxq);
                M_Hhygl.xgsj = Convert.ToDateTime(xgsj);
                M_Hhygl.yxzj = yxzj;
                M_Hhygl.parent_hykh = parent_hykh;
                M_Hhygl.hymm = hymm;
                M_Hhygl.shqr = true;
                M_Hhygl.xsy = xsy;
                M_Hhygl.czy = czy;
                M_Hhygl.djsj = DateTime.Now;
                M_Hhygl.scsj =DateTime.Parse(common_file.common_app.cssj);
                if (hhygl_shqr.hygl_shqr_add(yydh))
                {
                    M_Hhygl.shqr = false;
                }
                else
                {
                    M_Hhygl.shqr = true;
                }

                if (B_Hhygl.Add(M_Hhygl)> 0)
                {
                    s = common_file.common_app.get_suc;
                    if(hhygl_shqr.hygl_shqr_add(yydh))
                    {
                        string dx_bz = "";
                    Hhygl_verifyCode Hhygl_verifyCode_new = new Hhygl_verifyCode();
                    if (Hhygl_verifyCode_new.Hhygl_SendMsm(hykh_bz, "", yydh, qymc, common_file.common_hyAction.hy_Action_HyNew, "", "", "", "", hykh_bz, "", xxzs).Equals(common_file.common_app.get_suc))
                    {
                        dx_bz = "发送成功";
                    }
                    else
                    {
                        dx_bz = "发送失败";
                    }
                    common_file.common_czjl.add_czjl(yydh, qymc, czy, "新增会员", "短信提醒", dx_bz, DateTime.Parse(xgsj.ToString()));
                    }
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {

                    M_Hhygl = B_Hhygl.GetModel(Convert.ToInt32(id));
                    M_Hhygl.id = Convert.ToInt32(id);
                    M_Hhygl.yydh = yydh;
                    M_Hhygl.zjhm = zjhm;
                    M_Hhygl.zjyxq = Convert.ToDateTime(zjyxq);
                    M_Hhygl.bz = bz;
                    M_Hhygl.hyjf = Convert.ToDecimal(hyjf);
                    M_Hhygl.hykh = hykh;
                    M_Hhygl.hyrx = hyrx;
                    M_Hhygl.krdh = krdh;
                    M_Hhygl.krdw = krdw;
                    M_Hhygl.krdz = krdz;
                    M_Hhygl.krEmail = krEmail;
                    M_Hhygl.krgj = krgj;
                    M_Hhygl.krmz = krmz;
                    M_Hhygl.krsj = krsj;
                    M_Hhygl.krsr = Convert.ToDateTime(krsr);
                    M_Hhygl.krxb = krxb;
                    M_Hhygl.krxm = krxm;
                    M_Hhygl.krzy = krzy;
                    M_Hhygl.hykh_bz = hykh_bz;
                    M_Hhygl.lzka = lzka;
                    M_Hhygl.qymc = qymc;
                    M_Hhygl.qzhm = qzhm;
                    M_Hhygl.qzrx = qzrx;
                    M_Hhygl.shxg = Convert.ToBoolean(shxg);
                    M_Hhygl.tjrq = Convert.ToDateTime(tjrq);
                    M_Hhygl.tlyxq = Convert.ToDateTime(tlyxq);
                    M_Hhygl.xgsj = Convert.ToDateTime(xgsj);
                    M_Hhygl.yxzj = yxzj;
                    M_Hhygl.parent_hykh = parent_hykh;
                    M_Hhygl.hymm = hymm;
                    M_Hhygl.shqr = true;
                    M_Hhygl.xsy = xsy;
                    M_Hhygl.czy = czy;
                    if (B_Hhygl.Update(M_Hhygl))
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
                else
                {
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            Model.Hhygl  M_Hhygl_new = B_Hhygl.GetModel(int.Parse(id));
                            if (M_Hhygl_new != null)
                            {
                                BLL.Common B_common = new Hotel_app.BLL.Common();
                                B_common.ExecuteSql(" delete from  Hhyjf_xfjl  where  hykh_bz='" + M_Hhygl_new.hykh_bz + "'");
                                B_common.ExecuteSql(" delete from  Hhyjf_df  where  hykh_bz='" + M_Hhygl_new.hykh_bz + "'");
                                B_Hhygl.Delete(Convert.ToInt32(id));
                            }
                            s = common_file.common_app.get_suc;
                        }
                    }
                }
            return s;
        }
    }
}
