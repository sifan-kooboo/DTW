using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Text;

namespace Hotel_app.common_file_server
{
    public class Common_pl_Qskyd_mainRecord_add
    {
        /// <summary>
        /// 删除时批量添加 到Qskyd_mainrecord_temp表
        /// </summary>
        /// //public static string Pladd(string lsbh_old, string lsbh_new, string ddbh_new, string czy, string czsj)
        public static string Pladd(string yydh, string qymc, string lsbh_old, string lsbh_new, string ddbh_new, string czy, string czsj, string krxm, string sktt)
        {
            string s = common_app.get_failure;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Qskyd_mainrecord(yydh,qymc,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,main_sec,sdcz,syzd,vip_type,tsyq,ddly)");
            strSql.Append(" select yydh,qymc,'" + lsbh_new + "','" + ddbh_new + "',is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + common_app.chinese_add + "','" + "0" + "',sktt,yddj,'" + "0" + "','" + common_app.main_sec_main + "',sdcz,syzd,vip_type,tsyq,ddly from Qskyd_mainrecord");
            strSql.Append(" where lsbh='" + lsbh_old + "'");

            string krxm0 = ""; string sktt0 = "";
            DataSet DS_temp = B_common.GetList("select sktt,krxm from Qskyd_mainrecord", " lsbh='" + lsbh_old + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                krxm0 = DS_temp.Tables[0].Rows[0]["krxm"].ToString();
                sktt0 = DS_temp.Tables[0].Rows[0]["sktt"].ToString();
            }
            Hotel_app.Server.Qyddj.Q_ff_xyxf Q_ff_xyxf_new = new Hotel_app.Server.Qyddj.Q_ff_xyxf();
            Q_ff_xyxf_new.Qyddj_otherfee_add(yydh, qymc, lsbh_new, krxm0, sktt0, "", czy);


            if (B_common.ExecuteSql(strSql.ToString()) > 0)
            {
                s = common_app.get_suc;
            }
            return s;
        }

        //团体的批量增加
        public static string TT_plAdd(string lsbh_old, string lsbh_new, string krxm, string czy, string czsj, string xxzs)
        {//Hotel_app\common_file_server\Common_pl_Qskyd_mainRecord_add.cs
            string s = common_app.get_failure;
            StringBuilder strSql = new StringBuilder();
            //提取Qttyd中的信息，给新增的成员赋值
            strSql.Append("insert into Qskyd_mainrecord(yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krgj,krEmail,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,zyzt,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,main_sec,sdcz,ddly,tsyq,syzd)");
            strSql.Append(" select yydh,qymc,'" + lsbh_new + "',ddbh,is_top,is_select,'" + krxm + "',krgj,krEmail,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,zyzt,ddsj,'1',lksj,qtyq,'" + czy + "','" + czsj + "','" + common_app.chinese_add + "','" + "0" + "',sktt,yddj,ffshys,'" + common_app.main_sec_main + "',sdcz,ddly,tsyq,syzd from Qttyd_mainrecord");
            strSql.Append(" where lsbh='" + lsbh_old + "'");
            BLL.Common B_common = new Hotel_app.BLL.Common();
            if (B_common.ExecuteSql(strSql.ToString()) > 0)
            {
                string lfbh_News = common_file.common_ddbh.ddbh("lf", "lfdate", "lfcounter", 6);
                DataSet DS_temp = B_common.GetList("select * from Flfsz", "lsbh in (select lsbh from Qskyd_mainrecord where ddbh in(select ddbh from Qttyd_mainrecord where lsbh='" + lsbh_old + "'))");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    lfbh_News = DS_temp.Tables[0].Rows[0]["lfbh"].ToString();
                }
                else
                {
                    lfbh_News = common_file.common_ddbh.ddbh("lf", "lfdate", "lfcounter", 6);
                }
                DS_temp = B_common.GetList("select * from Qskyd_fjrb", "lsbh='" + lsbh_new + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    Hotel_app.Server.Ffjzt.Flfsz_add_edit Flfsz_add_edit_new = new Hotel_app.Server.Ffjzt.Flfsz_add_edit();
                    Flfsz_add_edit_new.Flfsz_add_edit_delete("", DS_temp.Tables[0].Rows[0]["yydh"].ToString(), DS_temp.Tables[0].Rows[0]["qymc"].ToString(), lfbh_News, DS_temp.Tables[0].Rows[0]["lsbh"].ToString(), DS_temp.Tables[0].Rows[0]["fjbh"].ToString(), DS_temp.Tables[0].Rows[0]["krxm"].ToString(), DS_temp.Tables[0].Rows[0]["sktt"].ToString(), DS_temp.Tables[0].Rows[0]["yddj"].ToString(), czy, czsj, false, common_app.get_add, xxzs);
                    //(string id, string yydh, string qymc, string lfbh, string lsbh, string fjbh, string krxm, string sktt, string yddj, string czy, string czsj, bool shlz, string add_edit_delete, string xxzs)
                }
                DS_temp.Dispose();
                s = common_app.get_suc;
            }
            return s;
        }
    }
}
