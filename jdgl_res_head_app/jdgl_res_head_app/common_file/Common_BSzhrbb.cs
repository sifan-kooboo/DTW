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
   public class Common_BSzhrbb
    {
       //先查询出没有上传的日期5天的数据
       //删除中心服务器上要上传日期的记录
       //添加日报表
      public static string url = common_file.Common.ReadXML("add", "url") + "/BBfx/BBfx_app.asmx";

      

        //用于报表服务—<第一步,查询前5天的时间>更新于：2012-05-25
       public static string ServicesForBB_step1(string yydh, DataSet Ds_searchDate)
        {
            string result = common_app.get_failure;
            //执行查找未传的日期
            object[] ob_args = new object[2];
            ob_args[0] = yydh;
            ob_args[1] = Ds_searchDate;
            object temp = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "BBzhrbb_Delete", ob_args);
            result = temp.ToString();
            return result;
        }

        //用于报表服务--<第二步,添加到中心服务器>更新于：2012-05-25
       public static string ServicesForBB_step2(DataSet ds)
        {
            string result = common_app.get_failure;
            try
            {
                result = common_app.get_failure;
                object[] ob_args = new object[1];

                ob_args[0] = ds;
                object temp_all = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "BSzhrbb_UpLoadDS", ob_args);
                if (temp_all.ToString() == common_app.get_suc)
                {

                    Common_Shsc.Updatshsc(ds, "BSzhrbb");
                    Common.AddMsg(ds, "上传综合日报表");
                    result= common_app.get_suc;
                        
                  
                }
            }
            catch (Exception ee)
            {
                //txtMessage.Text = "出错,详细信息为:" + ee.Message;
                throw new Exception(ee.Message);
            }
            return result;
        }

       public static void BSzhrbb_uploand()
       {
           DataSet Ds_searchDate;
           DataSet Ds_searchAllunuploadData;
           string stryydh = common_app.yydh;
           DbHelperSQLP helper = new DbHelperSQLP();
           SqlParameter[] sp ={ new SqlParameter("@yydh", SqlDbType.VarChar) };
           sp[0].Value = stryydh;
           try
           {
               
               Ds_searchDate = helper.RunProcedure("searchDate_Bszhrbb", sp, "Table_time");
               
               SqlParameter[] sp1 ={ new SqlParameter("@yydh", SqlDbType.VarChar) };
               sp1[0].Value = stryydh;
         
               Ds_searchAllunuploadData = helper.RunProcedure("searchAll_Bszhrbb", sp1, "Table_all");
               //删除服务器上的数据
               if (ServicesForBB_step1(stryydh, Ds_searchDate) == "success")
               {
                   ServicesForBB_step2(Ds_searchAllunuploadData);//上传数据 
               }
           }
           catch (Exception ee)
           {

               //开始写日志
             
               Common.WriteLog(ee.Message.ToString(),"查询报表数据后，在删除中心服务器上报表数据时出错");

           }
       }
       
    }
}
