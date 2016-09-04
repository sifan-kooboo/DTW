using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Hotel_app.Server.BBfx
{
    public class B_syxfmx_ls_add
    {
        /// <summary>
        /// 向这张表插入临时数据
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="czy"></param>
        /// <param name="cssj"></param>
        /// <param name="jssj"></param>
        /// <param name="add_type"></param>///销售员xsy,协议单位xydw；客人来源krly
        /// <param name="xxzs"></param>
        public string Ssyxfmx_ls_add_app(string yydh, string qymc, string czy, string cssj, string jssj, string add_type, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "";
            if (add_type == common_bb.xsy_krly_xydw_krly || add_type == common_bb.xsy_krly_xydw_xydw || add_type == common_bb.xsy_krly_xydw_pq || add_type == common_bb.xsy_krly_xydw_krgj || add_type == common_bb.xsy_krly_xydw_gj_sf || add_type == common_bb.xsy_krly_xydw_gj_cs)
            {
                sql_s = "delete from BQ_syxfmx_ls where yydh='"+yydh+"' and czy_temp='"+czy+"'";
                B_Common.ExecuteSql(sql_s);
                sql_s = "insert into BQ_syxfmx_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfsj,xfdr,xfrb,xfxm,sjxfje,xfsl,xsy,krly,xydw,czy_temp,pq,krgj,gj_sf,gj_cs)";
                sql_s = sql_s + "select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfsj,xfdr,xfrb,xfxm,sjxfje,xfsl,xsy,krly,xydw,'" + czy + "',pq,krgj,gj_sf,gj_cs  from VS_syxfmx_cz where yydh='" + yydh + "' and  xfsj between '" + cssj + "' and '" + jssj + "'";
                B_Common.ExecuteSql(sql_s);
            }
            if (add_type == common_bb.xsy_krly_xydw_xsy)
            {
                sql_s = "delete from BQ_syxfmx_ls where czy_temp='" + czy + "'";
                B_Common.ExecuteSql(sql_s);
                sql_s = "insert into BQ_syxfmx_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfsj,xfdr,xfrb,xfxm,sjxfje,xfsl,xsy,krly,xydw,czy_temp)";
                sql_s = sql_s + "select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfsj,xfdr,xfrb,xfxm,sjxfje,xfsl,xsy,krly,xydw,'" + czy + "' from VS_syxfmx_xsy where yydh='" + yydh + "' and  xfsj between '" + cssj + "' and '" + jssj + "'";
                B_Common.ExecuteSql(sql_s);
            }
            get_result = common_file.common_app.get_suc;
            return get_result;
        }


        public string Sjzmx_or_bak_ls_add_app(string yydh, string qymc, string czy, string cssj, string jssj,string czzt, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "";
            sql_s = "delete from BS_jzmx_ls where yydh='" + yydh + "' and czy_temp='" + czy + "'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from BS_jzmx_bak_ls where yydh='" + yydh + "' and czy_temp='" + czy + "'";
            B_Common.ExecuteSql(sql_s);
            try
            {
                sql_s = "insert into BS_jzmx_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,czy_temp)";
                sql_s = sql_s + "select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,'" + czy + "' from Sjzmx where yydh='" + yydh + "' and (tfsj between '" + cssj + "' and '" + jssj + "' or czsj between '" + cssj + "' and '" + jssj + "')" + czzt;
                B_Common.ExecuteSql(sql_s);
                sql_s = "insert into BS_jzmx_bak_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,czy_temp)";
                sql_s = sql_s + "select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czzt,tfsj,czsj,jzzt,fkfs,'" + czy + "' from Sjzmx_bak where yydh='" + yydh + "'  and (tfsj between '" + cssj + "' and '" + jssj + "' or czsj between '" + cssj + "' and '" + jssj + "')" + czzt + common_file_server.common_jzzt.czzt_bak_not_like_tf;
                B_Common.ExecuteSql(sql_s);

            }
            catch 
            {
                common_file.common_czjl.add_errorlog(sql_s, "", DateTime.Now.ToString());
                
            }

            get_result = common_file.common_app.get_suc;
            return get_result;

        }



    }
}
