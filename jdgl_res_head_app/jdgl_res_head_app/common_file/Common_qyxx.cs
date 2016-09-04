using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Windows.Forms;

namespace jdgl_res_head_app.common_file
{
   public class Common_qyxx
    {
       public static void CS_qyxx()
       {
           BLL.Xqyxx B_Xqyxx = new jdgl_res_head_app.BLL.Xqyxx();
           DataSet DS_Xqyxx = B_Xqyxx.GetList(" ID>=0 ");
           if (DS_Xqyxx != null && DS_Xqyxx.Tables[0].Rows.Count > 0)
           {
               string url = common_file.Common.ReadXML("add", "url") + "/Xxtsz/Xxtsz_app.asmx";
               object[] args = new object[2];
               args[0] = DS_Xqyxx;
               args[1] = common_file.common_app.xxzs_zsvalue;
               object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Xqyxx_add_DS", args);
               if (result.ToString() == common_file.common_app.get_suc)
               {
                   Common.AddMsg(DS_Xqyxx, "初始企业信息");
                   common_file.common_app.Message_box_show(common_file.common_app.message_title, "初始成功！");
               }
               else
               {
                   common_file.common_app.Message_box_show(common_file.common_app.message_title, "初始失败！");
               }
           }
           DS_Xqyxx.Dispose();
       }
    }
}
