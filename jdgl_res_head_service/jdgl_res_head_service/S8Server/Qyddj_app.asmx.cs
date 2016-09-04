using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using Maticsoft.DBUtility;

namespace jdgl_res_head_service.S8Server
{
    /// <summary>
    /// Qyddj_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Qyddj_app : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //向InsertToQyddjlsbhbg_yy添加数据
        [WebMethod(Description = "向InsertToQyddjlsbhbg_yy添加数据")]
        public string InsertToQyddjlsbhbg_yy(string yclsbh, string bdlsbh, string bdyydh)
        {
            string s = common_file.common_app.get_failure;
            S8Server.web_skyd web_skyd_new = new web_skyd();
            s = web_skyd_new.InsertToQyddjlsbhbg_yy(yclsbh, bdlsbh, bdyydh);
            return s;
        }

        [WebMethod(Description = "获取需下载的订单数据")]
        public DataSet GetOrderFromSite(int intOrderState)
        {
            return web_skyd.GetDownLoadOrders(intOrderState);
        }

        [WebMethod(Description="用于门店订单确认后,修改网站订单的状态")]
        public string  SetAcceptOrderStatus(string bdlsbh, string yydh, int OrderStatus)
        {
            string RetVal = common_file.common_app.get_failure;
            object  Ovalue=DbHelperSQL.GetSingle(string.Format(@"select  yclsbh from Qyddjlsbhbg_yy  where  bdlsbh='{0}'   ", bdlsbh));
            if (Ovalue != null)
            {
                BLL.MT_Order bll = new BLL.MT_Order();
                int i = DbHelperSQL.ExecuteSql(string.Format(@" Update MT_Order  set  state={0}  where  order_lsbh='{1}'  ", OrderStatus, Ovalue.ToString()));
                return RetVal = i > 0 ? common_file.common_app.get_suc : common_file.common_app.get_failure;
            }
            return RetVal;
        }
    }
}
