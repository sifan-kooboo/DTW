using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using Maticsoft.DBUtility;

namespace jdgl_res_head_app.common_file
{
   public class Common_Qskyd_fjrb
    {
       public static string url = common_file.Common.ReadXML("add", "url") + "/Ffjzt/Ffjzt_app.asmx";
       public static int temp_result = 0;
        
       /// <summary>
       /// 门店上传散客房间到中心服务器
       /// </summary>
       /// <returns></returns>
        public static int UpLoad_Qskyd_fjrb()
        {
            int i = 0;
            string s = common_app.get_failure;

            Model.Qskyd_fjrb M_Qskyd_fjrb=new Model.Qskyd_fjrb();
            BLL.Qskyd_fjrb B_Qskyd_fjrb=new BLL.Qskyd_fjrb();
            BLL.Fwx_other B_Fwx_other = new BLL.Fwx_other();
            DataSet DS_Qskyd_fjrb = new  DataSet();
            DataSet DS_Fwx_other = new DataSet();

            DS_Qskyd_fjrb = B_Qskyd_fjrb.GetList("1=1");
            DS_Fwx_other = B_Fwx_other.GetList("1=1");
            if (DS_Qskyd_fjrb != null && DS_Qskyd_fjrb.Tables[0].Rows.Count > 0)
            {
                object[] args = new object[2];
                args[0] =DS_Fwx_other;
                args[1] = DS_Qskyd_fjrb;
                object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_temp_ADD", args);
                if (result.ToString() == common_file.common_app.get_suc)
                {
                        Common_Shsc.Updatshsc(DS_Qskyd_fjrb, "Qskyd_fjrb");
                        Common_Shsc.Updatshsc(DS_Fwx_other, "Fwx_other");
                        i += Common_Shsc.GetRowCount(DS_Qskyd_fjrb);
                        i += Common_Shsc.GetRowCount(DS_Fwx_other);
                        Common.AddMsg(DS_Qskyd_fjrb,"上传房间类别");
                        Common.AddMsg(DS_Fwx_other, "上传维修房");
                }
            }
            return i++;
        }
       //public static int UpLoad_Fwx_other(DataSet DS_Fwx_other)
       //{
           
       //        int i=0;
       //        object[] args = new object[1];
       //        args[0] = DS_Fwx_other;
       //        object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Fwx_other_UploadDS", args);
       //        if (result.ToString() == common_file.common_app.get_suc)
       //        {
       //            if (Updat_Fwx_other_shsc(DS_Fwx_other) > 0)
       //            {

       //                i = Updat_Fwx_other_shsc(DS_Fwx_other);

       //            }
       //        }
       //        return i;
         
 
       //}

       //上传完Qskyd_fjrb后修改本地shsc=1
       //public static int Updat_Qskyd_fjrb_shsc(DataSet DS_Qskyd_fjrb)
       //{
       //    int i = 0;
       //    foreach (DataRow dr in DS_Qskyd_fjrb.Tables[0].Rows)
       //    {
       //        string Local_lsbh = dr["lsbh"].ToString();
       //        DbHelperSQLP helper = new DbHelperSQLP();

       //        SqlParameter[] para = new SqlParameter[]{
       //                         new SqlParameter("@lsbh", SqlDbType.VarChar),
       //                         new SqlParameter("@rows", SqlDbType.Int) ,
       //                     };
       //        para[0].Value = Local_lsbh;
       //        para[1].Direction = ParameterDirection.Output;
       //        helper.RunProcedure("Qskyd_fjrb_Status", para, out temp_result);
       //        temp_result = Convert.ToInt32(para[1].Value.ToString());
       //        if (temp_result > 0)
       //        {
       //            i += temp_result;

       //            continue;
       //        }
       //        else
       //        {

       //            break;
       //        }
       //    }
       //    return i;
       //}


       //上传完Fwx_other后修改本地shsc=1
       //public static int Updat_Fwx_other_shsc(DataSet DS_Fwx_other)
       //{
       //    int i = 0;
       //    foreach (DataRow dr in DS_Fwx_other.Tables[0].Rows)
       //    {
       //        string Local_lsbh = dr["lsbh"].ToString();
       //        DbHelperSQLP helper = new DbHelperSQLP();

       //        SqlParameter[] para = new SqlParameter[]{
       //                         new SqlParameter("@lsbh", SqlDbType.VarChar),
       //                         new SqlParameter("@rows", SqlDbType.Int) ,
       //                     };
       //        para[0].Value = Local_lsbh;
       //        para[1].Direction = ParameterDirection.Output;
       //        helper.RunProcedure("Fwx_other_Status", para, out temp_result);
       //        temp_result = Convert.ToInt32(para[1].Value.ToString());
       //        if (temp_result > 0)
       //        {
       //            i += temp_result;

       //            continue;
       //        }
       //        else
       //        {

       //            break;
       //        }
       //    }
       //    return i;
       //}

    }
}
