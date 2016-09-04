using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace jdgl_res_head_service.S8Server
{
    public class web_skyd
    {
        public  static  DataSet    GetDownLoadOrders(int intOrderState)
        {
            string sql = string.Format(@" SELECT 
     order_lsbh
      ,user_id
      ,fjrx_id
      ,yd_name
      ,yd_sex
      ,yd_mobile
      ,yd_email
      ,crs
      ,xhrs
      ,yd_ddsj
      ,yd_js
      ,MT_Order.content
      ,yd_ts
      ,[yd_jg]
      ,yd_statetime
      ,yd_endtime
      ,is_rz
      ,state
      ,MT_Order.add_time,title,msj from MT_Order,MT_Fjrx  where MT_Order.fjrx_id=MT_Fjrx.id and  MT_Order.state={0} ", intOrderState);
          return   DbHelperSQL.Query(sql);

        }


        //向InsertToQyddjlsbhbg_yy添加数据
        public string InsertToQyddjlsbhbg_yy(string yclsbh, string bdlsbh, string bdyydh)
        {
            string ss = common_file.common_app.get_failure;
            SqlParameter[] sp ={ 
            new SqlParameter("@yclsbh",SqlDbType.VarChar),
            new SqlParameter("@bdlsbh",SqlDbType.VarChar),
            new SqlParameter("@bdyydh",SqlDbType.VarChar),
            new SqlParameter("@rows",SqlDbType.Int)
            };
            sp[0].Value = yclsbh;
            sp[1].Value = bdlsbh;
            sp[2].Value = bdyydh;
            sp[3].Direction = ParameterDirection.Output;
            DbHelperSQLP helperSQLP = new DbHelperSQLP();
            helperSQLP.RunProcedure("InsertToQyddjlsbhbg_yy", sp);
            int result = Convert.ToInt32(sp[3].Value.ToString());
            if (result > 0)
            {
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }
    }
}