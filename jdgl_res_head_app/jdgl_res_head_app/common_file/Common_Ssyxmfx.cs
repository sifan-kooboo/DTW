using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using Maticsoft.DBUtility;
using System.IO;
namespace jdgl_res_head_app.common_file
{
   public class Common_Ssyxmfx
    {
       public static void Cs_Ssyxmfx()
       {
            BLL.Ssyxfmx B_Ssyxfmx = new BLL.Ssyxfmx();
            DataSet DS_Ssyxfmx = B_Ssyxfmx.GetList(200," ID>=0 and shsc=0","id");
            if (DS_Ssyxfmx != null && DS_Ssyxfmx.Tables[0].Rows.Count > 0)
            {
                   string url = common_file.Common.ReadXML("add", "url") + "/BBfx/BBfx_app.asmx";
                   object[] args = new object[1];
                    args[0] = DS_Ssyxfmx;
                    object result =jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Ssyxfmx_UpLoadDS", args);
                    if (result.ToString() == common_file.common_app.get_suc)
                    {
                        Common_Shsc.Updatshsc(DS_Ssyxfmx, "Ssyxfmx");//修改本地shsc
                        Common.AddMsg(DS_Ssyxfmx,"上传所有消费明细");
                    }
            }
            DS_Ssyxfmx.Dispose();
         

          
        }
       public static void Cs_Ssyxfmx_cz()
       {
      
           BLL.Ssyxfmx_cz B_Ssyxfmx_cz = new BLL.Ssyxfmx_cz();
           DataSet DS_Ssyxfmx_cz = B_Ssyxfmx_cz.GetList(200," ID>=0 and shsc=0","id");
           if (DS_Ssyxfmx_cz != null && DS_Ssyxfmx_cz.Tables[0].Rows.Count > 0)
           {
               string url = common_file.Common.ReadXML("add", "url") + "/BBfx/BBfx_app.asmx";
               object[] args = new object[1];
               args[0] = DS_Ssyxfmx_cz;
               object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Ssyxfmx_cz_UpLoadDS", args);
               if (result.ToString() == common_file.common_app.get_suc)
               {
                   Common_Shsc.Updatshsc(DS_Ssyxfmx_cz, "Ssyxfmx_cz");//修改本地shsc
                   Common.AddMsg(DS_Ssyxfmx_cz, "上传Ssyxfmx_cz");
               }


           }
           DS_Ssyxfmx_cz.Dispose();
     


       }
       public static void Cs_Ssyxfmx_xsy()
       {

           BLL.Ssyxfmx_xsy B_Ssyxfmx_xsy = new BLL.Ssyxfmx_xsy();
           DataSet DS_Ssyxfmx_xsy = B_Ssyxfmx_xsy.GetList(200," ID>=0 and shsc=0","id");
           if (DS_Ssyxfmx_xsy != null && DS_Ssyxfmx_xsy.Tables[0].Rows.Count > 0)
           {
               string url = common_file.Common.ReadXML("add", "url") + "/BBfx/BBfx_app.asmx";
               object[] args = new object[1];
               args[0] = DS_Ssyxfmx_xsy;
               object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Ssyxfmx_xsy_UpLoadDS", args);
               if (result.ToString() == common_file.common_app.get_suc)
               {
                   Common_Shsc.Updatshsc(DS_Ssyxfmx_xsy, "Ssyxfmx_xsy");//修改本地shsc
                   Common.AddMsg(DS_Ssyxfmx_xsy, "上传Ssyxfmx_xsy");

               }


           }
           DS_Ssyxfmx_xsy.Dispose();
   

       }


       
    }
}
