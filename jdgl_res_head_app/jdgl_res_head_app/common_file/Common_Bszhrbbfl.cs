using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace jdgl_res_head_app.common_file
{
   public class Common_Bszhrbbfl
    {
        
       public static string Bszhrbbfl_Uploand()
        {
            string s = common_app.get_failure;
            BLL.BSzhrbbfl B_BSzhrbbfl = new BLL.BSzhrbbfl();
            DataSet DS_BSzhrbbfl = B_BSzhrbbfl.GetList(200," ID>=0 and shsc=0","id");
            if (DS_BSzhrbbfl != null && DS_BSzhrbbfl.Tables[0].Rows.Count > 0)
            {
                string url = common_file.Common.ReadXML("add", "url") + "/BBfx/BBfx_app.asmx";
                object[] args = new object[1];
                args[0] = DS_BSzhrbbfl;

                object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "BSzhrbbfl_UpLoadDS", args);
                if (result.ToString() == common_file.common_app.get_suc)
                {

                    Common_Shsc.Updatshsc(DS_BSzhrbbfl, "Bszhrbbfl");//上传完修改本地shsc=1
                    Common.AddMsg(DS_BSzhrbbfl, "上传报表分录");
                    s = common_app.get_suc;
                }
                

            }
            return s;


        }

    }
}
