using System;
using System.Collections.Generic;
using System.Text;

namespace jdgl_res_head_app.Com
{
    class CommFunc
    {
        public static decimal GetDecimalValue(string strValue)
        {
            decimal DecRetVal = 0;
            try
            {
                DecRetVal = decimal.Parse(strValue);
            }
            catch (Exception)
            {
                DecRetVal = 0;
            }
            return DecRetVal;
        }

        //用于测试WEBservice是否正常,正常的时候返回值为1
        public static  int TestRemoteServerStatus(ref string  RetInfo)
        {
            string url = common_file.Common.ReadXML("add", "url") + "/Xxtsz/Xxtsz_app.asmx";
            int status = -1;
            try
            {
                object temp = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "HelloServer", null);
                if (temp.ToString() == "1")
                {
                    RetInfo = "恭喜,远程服务器连接成功";
                    status = Convert.ToInt32(temp.ToString());
                }
                else
                {
                    RetInfo = "远程服务器连接出错";
                    common_file.Common.WriteLog(RetInfo, "测试连接");
                }
            }
            catch (Exception RemoteException)
            {
                RetInfo = RemoteException.Message.ToString();
                //postion = "远程服务器连接出错";
                common_file.Common.WriteLog(RetInfo, "测试连接");
            }
            return status;
        }

    }
}
