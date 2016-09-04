using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Hotel_app.Qyddj
{
    //说明，此类在表Q_tt_temp_krlb里面生成临时数据
   public   class Q_tt_krlb_0
    {
       //public string ddbh = "";//TT主单的订单编号
       public DataSet  insert_Q_tt_temp_krlb(string ddbh)
       {
           BLL.Common B_common = new Hotel_app.BLL.Common();
           DataSet ds = null;
           StringBuilder sb;
           B_common.ExecuteSql(" delete from  Q_tt_temp_krlb  where  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  czy_temp='" + common_file.common_app.czy + "'");
           sb = new StringBuilder();
           sb.Append("  insert into Q_tt_temp_krlb(yydh,qymc,ddbh,lsbh,krxm,krly,ddsj,lksj,fjrb,fjbh,lzfs,sjfjjg,xsy,czy_temp)");
           sb.Append("  select  yydh,qymc,ddbh,lsbh,krxm,krly,ddsj,lksj,fjrb,fjbh,lzfs,sjfjjg,xsy,'" + common_file.common_app.czy + "'  from  VIEW_tt_krlb  ");
           sb.Append("  where  main_sec='" + common_file.common_app.main_sec_main + "'  and yydh='" + common_file.common_app.yydh + "'  and  ddbh='" + ddbh + "'  and  fjbh!=''  ");
           B_common.ExecuteSql(sb.ToString());
           ds = B_common.GetList(" select *  from Q_tt_temp_krlb", " id>=0  and ddbh='" + ddbh + "'  and yydh='" + common_file.common_app.yydh + "'  and czy_temp='" + common_file.common_app.czy + "'order by fjbh Asc");
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
               {
                   //更新其它客人信息到主单记录中
                   string krxm = ds.Tables[0].Rows[j]["krxm"].ToString();
                   string lsbh = ds.Tables[0].Rows[j]["lsbh"].ToString();
                   string fjbh = ds.Tables[0].Rows[j]["fjbh"].ToString();
                   string fjrb = ds.Tables[0].Rows[j]["fjrb"].ToString();

                   DataSet ds_temp_0 = B_common.GetList("  select  * from   VIEW_tt_krlb", "    lsbh='" + lsbh + "'  and    ddbh='" + ddbh + "'  and  fjbh='" + fjbh + "'  and fjrb='" + fjrb + "' and yydh='" + common_file.common_app.yydh + "'  and  main_sec='" + common_file.common_app.main_sec_sec + "'  and  krxm!=''  ");
                   if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                   {
                       for (int k = 0; k < ds_temp_0.Tables[0].Rows.Count; k++)
                       {
                           krxm +="|"+ds_temp_0.Tables[0].Rows[k]["krxm"].ToString();
                       }
                   }
                   B_common.ExecuteSql("  update  Q_tt_temp_krlb  set  krxm='" + krxm + "'  where id>=0  and  lsbh='" + lsbh + "'  and  ddbh='" + ddbh + "'  and  fjbh='" + fjbh + "'  and fjrb='" + fjrb + "' and yydh='" + common_file.common_app.yydh + "'  and  czy_temp='" + common_file.common_app.czy + "' ");
               }
           }

           //最后生成要获取的数据
           ds = B_common.GetList("  select * from  Q_tt_temp_krlb", " id>=0  and ddbh='" + ddbh + "'  and yydh='" + common_file.common_app.yydh + "'  and czy_temp='" + common_file.common_app.czy + "'");
           return ds;
       }
    }
}
