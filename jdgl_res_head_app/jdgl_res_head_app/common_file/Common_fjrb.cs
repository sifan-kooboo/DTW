using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace jdgl_res_head_app.common_file
{
   public class Common_fjrb
    {
        /// <summary>
        /// 房类的初始时，同时初始房类与房态
        /// </summary>
        public static void M_Ts_Ffjrb()
        {
            BLL.Ffjrb B_Ffjrb = new BLL.Ffjrb();
            BLL.Ffjzt B_Ffjzt = new BLL.Ffjzt();
            DataSet DS_Ffjrb_0 = B_Ffjrb.GetList(" ID>=0 " + common_app.yydh_select + " ");
            DataSet Ds_Ffjzt_1 = B_Ffjzt.GetList("  ID>=0 " + common_app.yydh_select + " ");
            DataSet DS_Ffjrb = new DataSet();
            DataTable dt = DS_Ffjrb_0.Tables[0].Copy();
            dt.TableName = "dt_Ffjrb";
            DS_Ffjrb.Tables.Add(dt);
            DataTable dt1 = Ds_Ffjzt_1.Tables[0].Copy();
            dt1.TableName = "dt_Ffjzt";
            DS_Ffjrb.Tables.Add(dt1);
            if (DS_Ffjrb != null &&( DS_Ffjrb.Tables[0].Rows.Count > 0||DS_Ffjrb.Tables[1].Rows.Count>0))
            {
                  string  url = common_file.Common.ReadXML("add", "url") + "/Ffjzt/Ffjzt_app.asmx";
                  object[] args = new object[2];
                  args[0] = DS_Ffjrb;
                  args[1]=common_app.Inital;
                  object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "fjrb_UpLoadDS", args);
                  if (result!=null&&result.ToString() == common_file.common_app.get_suc)
                    {
                        //common_file.Common_Ffjzt.M_UpLoad_Ffjzt();//初始房间状态表主要是计算房间总数
                        Common.AddMsg(DS_Ffjrb, "初始房态与房类");
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "初始成功！");
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "初始失败！");
                    }
            }
        }
    }
}
