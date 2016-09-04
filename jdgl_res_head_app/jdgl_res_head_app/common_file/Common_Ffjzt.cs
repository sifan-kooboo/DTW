using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace jdgl_res_head_app.common_file
{
    public class Common_Ffjzt
    {
        //房间状态上传
        public static void M_UpLoad_Ffjzt()
        {
            BLL.Ffjzt B_Ffjzt = new BLL.Ffjzt();
            DataSet DS_Ffjzt = B_Ffjzt.GetList(" ID>=0");
            if (DS_Ffjzt != null && DS_Ffjzt.Tables[0].Rows.Count > 0)
            {
                string url = common_file.Common.ReadXML("add", "url") + "/Ffjzt/Ffjzt_app.asmx";
                object[] args = new object[1];
                args[0] = DS_Ffjzt;

                object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Ffjzt_UpLoadDS", args);
                //if (result.ToString() == common_file.common_app.get_suc)
                //{
                //    common_file.common_app.Message_box_show(common_file.common_app.message_title, "上传房间状态成功！");

                //}
                //else
                //{
                //    common_file.common_app.Message_box_show(common_file.common_app.message_title, "上传房间状态失败！");

                //}

            }


        }

        //房间状态上传
        public static void M_UpLoad_Ffjzt_new()
        {
            BLL.Ffjzt B_Ffjzt = new BLL.Ffjzt();
            DataSet DS_Ffjzt = B_Ffjzt.GetList(" ID>=0");
            if (DS_Ffjzt != null && DS_Ffjzt.Tables[0].Rows.Count > 0)
            {
                string url = common_file.Common.ReadXML("add", "url") + "/Ffjzt/Ffjzt_app.asmx";
                object[] args = new object[2];
                args[0] = DS_Ffjzt;
                args[1] = common_app.yydh;
                object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Ffjzt_upload", args);
               

            }


        }

    }
}
