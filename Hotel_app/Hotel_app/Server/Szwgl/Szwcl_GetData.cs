using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Szwgl
{
    public class Szwcl_GetData
    {
        public Hotel_app.Model.Szw_temp M_Szw_temp;
        public Hotel_app.Model.Syjcz M_Syjcz;
        public Hotel_app.BLL.Szw_temp B_Szw_temp = new Hotel_app.BLL.Szw_temp();
        public Hotel_app.BLL.Ssyxfmx B_Ssyxfmc = new Hotel_app.BLL.Ssyxfmx();
        public Hotel_app.BLL.Syjcz B_Syjcz = new Hotel_app.BLL.Syjcz();
        public Hotel_app.BLL.Common B_common = new Hotel_app.BLL.Common();
        int id = 0;
        DataSet ds_temp_xfmx;

        //获取消费名细记录
        //查询(yjcz,以及Ssyxfmx表相关内容，批量增加到Szw_temp里面,返回数据集
        public DataSet Zzwcl_Search(string lsbh, string yddj, string sktt, string czy, string czy_GUID)
        {
            //查询当前操作员(lsbh+czy)是否在Szw_temp是否有记录，有就删除，没有就直接查询，填充该表
            //ds_temp_xfmx = B_Szw_temp.GetList("lsbh='" + lsbh + "'  and  czy='" + czy + "'");
            ds_temp_xfmx = B_Szw_temp.GetList("czy_temp='" + czy_GUID + "'");
            if (ds_temp_xfmx != null && ds_temp_xfmx.Tables[0].Rows.Count > 0)//记录存在，执行删除
            {
                for (int i = 0; i < ds_temp_xfmx.Tables[0].Rows.Count; i++)
                {
                    id = Convert.ToInt32(ds_temp_xfmx.Tables[0].Rows[i]["id"].ToString());
                    B_Szw_temp.Delete(id);
                }
            }
            System.Text.StringBuilder strSql = new System.Text.StringBuilder();
            //查询yjcz表里面的数据，向szw_temp添加
            strSql.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
            strSql.Append(" select  yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,'" + czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,'',sjxfje,'1',shsc,'0','',xfsj,'"+czy_GUID+"'  from Syjcz");
            strSql.Append("  where  lsbh='" + lsbh + "'");
            B_common.ExecuteSql(strSql.ToString());
            //查询Ssyxfmx表里面的数据，向szw_temp添加
            strSql = new System.Text.StringBuilder();
            strSql.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp )");
            strSql.Append(" select yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,'" + czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,'',xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,'" + czy_GUID + "'  from Szwmx");
            strSql.Append("  where  lsbh='" + lsbh + "'");
            B_common.ExecuteSql(strSql.ToString());

            ds_temp_xfmx = B_Szw_temp.GetList("  lsbh='" + lsbh + "'  and  czy_temp='" + czy_GUID + "'");
            return ds_temp_xfmx;
        }

    
        //获取消费项目列表
        public  DataSet Zzwcl_hz(string lsbh, string yddj, string sktt, string czy)
        {
            string sql = "select  xfxm,Sum(sjxfje) as  sjxfje  from  Szw_temp";
            ds_temp_xfmx = B_common.GetList(sql, " lsbh='" + lsbh + "'  group by xfxm  order by xfxm desc");
            return ds_temp_xfmx;
        }
    }
}
