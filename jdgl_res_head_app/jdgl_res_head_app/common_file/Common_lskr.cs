using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
namespace jdgl_res_head_app.common_file
{
   public class Common_lskr
   {
       public static string url = common_file.Common.ReadXML("add", "url") + "/Lskr/Lskr_app.asmx";

       public static string ss = common_file.common_app.get_failure;
       public static string yydh = common_file.Common.Getqyxx(1);//营业代码

       //上传历史客人
       public static void UpLoad_lskr()
       {
           UpLoad_Qskyd_mainrecord_lskr();
           UpLoad_Qskyd_fjrb_lskr();
           UpLoad_Qskyd_lskr_delete();
       }
       //下载历史客人
       public static void Download_lskr()
       {
           Download_Qskyd_mainrecord_lskr();
           Download_Qskyd_fjrb_lskr();
           Download_Qskyd_lskr_delete();
 
       }

        #region  客史上传部分
       //上传Qskyd_fjrb_lskr
       public static void UpLoad_Qskyd_fjrb_lskr()
       {

           BLL.Qskyd_fjrb_lskr B_Qskyd_fjrb_lskr = new BLL.Qskyd_fjrb_lskr();
           string strdat = DateTime.Now.ToString("yyyy-MM-dd");
           DataSet DS_fjrb_lskr = B_Qskyd_fjrb_lskr.GetList(1000, "ID>=0 and shsc=0 and convert(varchar(10),czsj,120)<'" + strdat + "' and yydh='" + yydh + "'", "id");
           if (DS_fjrb_lskr != null && DS_fjrb_lskr.Tables[0].Rows.Count > 0)
           {
               object[] args = new object[1];
               args[0] = DS_fjrb_lskr;
               object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_lskr_UploadDS", args);
               if (result.ToString() == common_file.common_app.get_suc)
               {

                   Common_Shsc.Updatshsc(DS_fjrb_lskr, "Qskyd_fjrb_lskr");//上传后修改本地shsh=1

               }
           }

           DS_fjrb_lskr.Dispose();
       }
       //上传Qskyd_mainrecord_lskr
       public static void UpLoad_Qskyd_mainrecord_lskr()
       {
           BLL.Qskyd_mainrecord_lskr B_Qskyd_mainrecord_lskr = new BLL.Qskyd_mainrecord_lskr();
           string strdat = DateTime.Now.ToString("yyyy-MM-dd");
           DataSet DS_Qskyd_mainrecord_lskr = B_Qskyd_mainrecord_lskr.GetList(1000, "ID>=0 and shsc=0 and convert(varchar(10),czsj,120)<'" + strdat + "' and yydh='" + yydh + "'", "id");
           if (DS_Qskyd_mainrecord_lskr != null && DS_Qskyd_mainrecord_lskr.Tables[0].Rows.Count > 0)
           {
               object[] args = new object[1];
               args[0] = DS_Qskyd_mainrecord_lskr;
               object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qskyd_mainrecord_lskr_UploadDS", args);
               if (result.ToString() == common_file.common_app.get_suc)
               {
                   Common_Shsc.Updatshsc(DS_Qskyd_mainrecord_lskr, "Qskyd_mainrecord_lskr");//上传后修改本地shsh=1
               }
               else
               {
                   common_file.Common.WriteLog("现在时间" + strdat, "上传历史客人成功但是修改本地shsc=1时出错");
               }
           }
           DS_Qskyd_mainrecord_lskr.Dispose();
       }
       //上传Qskyd_lskr_delete
       public static void UpLoad_Qskyd_lskr_delete()
       {
           BLL.Qskyd_lskr_delete B_Qskyd_lskr_delete = new BLL.Qskyd_lskr_delete();
           string strdat = DateTime.Now.ToString("yyyy-MM-dd");
           DataSet DS_Qskyd_lskr_delete = B_Qskyd_lskr_delete.GetList(200, "ID>=0 and shsc=0 and convert(varchar(10),czsj,120)<'" + strdat + "' and yydh='" + yydh + "'", "id");
           if (DS_Qskyd_lskr_delete != null && DS_Qskyd_lskr_delete.Tables[0].Rows.Count > 0)
           {
               object[] args = new object[1];
               args[0] = DS_Qskyd_lskr_delete;
               object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qskyd_lskr_delete_UploadDS", args);
               if (result.ToString() == common_file.common_app.get_suc)
               {
                   Common_Shsc.Updatshsc(DS_Qskyd_lskr_delete, "Qskyd_lskr_delete");//上传后修改本地shsh=1
               }
           }

           DS_Qskyd_lskr_delete.Dispose();
       }
        #endregion

       #region  客史下载部分
       public static void Download_Qskyd_fjrb_lskr()
       {
           BLL.Qskyd_fjrb_lskr B_Qskyd_fjrb_lskr = new BLL.Qskyd_fjrb_lskr();
           Model.Qskyd_fjrb_lskr M_Qskyd_fjrb_lskr = new Model.Qskyd_fjrb_lskr();
           DataSet DS_download = new DataSet();
           object[] args = new object[2];
           args[0] = yydh;
           args[1] = DS_download;
           object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_lskr_download", args);
           if (result.ToString() == common_file.common_app.get_suc)
           {
               DS_download = (DataSet)args[1];
               foreach (DataRow dr in DS_download.Tables[0].Rows)
               {
                   string hykh_service = dr["lsbh"].ToString();
                   SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,100),
					new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@yhbl", SqlDbType.Decimal,9),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@fjbm", SqlDbType.VarChar,50),
					new SqlParameter("@jcje", SqlDbType.Decimal,9),
                    new SqlParameter("@DB_Option_Action_", SqlDbType.VarChar,50),
                   };
                   parameters[0].Value = dr["yydh"];
                   parameters[1].Value = dr["qymc"];
                   parameters[2].Value = dr["jzbh"];
                   parameters[3].Value = dr["lsbh"];
                   parameters[4].Value = dr["krxm"];
                   parameters[5].Value = dr["sktt"];
                   parameters[6].Value = dr["yddj"];
                   parameters[7].Value = dr["fjrb"];
                   parameters[8].Value = dr["fjbh"];
                   parameters[9].Value = Convert.ToDateTime(dr["ddsj"]);
                   parameters[10].Value = Convert.ToDateTime(dr["lksj"]);
                   parameters[11].Value = Convert.ToDecimal(dr["lzfs"]);
                   parameters[12].Value = dr["shqh"];
                   parameters[13].Value = Convert.ToDecimal(dr["fjjg"]);
                   parameters[14].Value = Convert.ToDecimal(dr["sjfjjg"]);
                   parameters[15].Value = dr["yh"];
                   parameters[16].Value = Convert.ToDecimal(dr["yhbl"]);
                   parameters[17].Value = dr["bz"];
                   parameters[18].Value = Convert.ToBoolean(dr["is_top"]);
                   parameters[19].Value = Convert.ToBoolean(dr["is_select"]);
                   parameters[20].Value = true;
                   parameters[21].Value = dr["czy"];
                   parameters[22].Value = Convert.ToDateTime(dr["czsj"]);
                   parameters[23].Value = dr["cznr"];
                   parameters[24].Value = Convert.ToBoolean(dr["sdcz"]);
                   parameters[25].Value = false;
                   parameters[26].Value = dr["fjbm"];
                   parameters[27].Value = Convert.ToDecimal(dr["jcje"]);
                   parameters[28].Value = "Insert";
                   SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qskyd_fjrb_lskr_InsertUpdateDelete", parameters);
               }
           }
       }
       public static void Download_Qskyd_mainrecord_lskr()
       {
           BLL.Qskyd_mainrecord_lskr B_Qskyd_mainrecord_lskr = new BLL.Qskyd_mainrecord_lskr();
           Model.Qskyd_mainrecord_lskr M_Qskyd_mainrecord_lskr = new Model.Qskyd_mainrecord_lskr();


           DataSet DS_download = new DataSet();
           object[] args = new object[2];
           args[0] = yydh;
           args[1] = DS_download;
           object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qskyd_mainrecord_lskr_download", args);
           if (result.ToString() == common_file.common_app.get_suc)
           {
               DS_download = (DataSet)args[1];
               foreach (DataRow dr in DS_download.Tables[0].Rows)
               {
                   string hykh_service = dr["lsbh"].ToString();
                   SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,100),
					new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@ddbh", SqlDbType.VarChar,100),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@tlkr", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,50),
					new SqlParameter("@krjg", SqlDbType.VarChar,50),
					new SqlParameter("@krdw", SqlDbType.VarChar,50),
					new SqlParameter("@krzy", SqlDbType.VarChar,50),
					new SqlParameter("@cxmd", SqlDbType.VarChar,50),
					new SqlParameter("@qzrx", SqlDbType.VarChar,50),
					new SqlParameter("@qzhm", SqlDbType.VarChar,50),
					new SqlParameter("@zjyxq", SqlDbType.DateTime),
					new SqlParameter("@tlyxq", SqlDbType.DateTime),
					new SqlParameter("@tjrq", SqlDbType.DateTime),
					new SqlParameter("@lzka", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddrx", SqlDbType.VarChar,50),
					new SqlParameter("@ddwz", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@krrx", SqlDbType.VarChar,50),
					new SqlParameter("@kr_children", SqlDbType.Int,4),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@ddyy", SqlDbType.VarChar,200),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@qtyq", SqlDbType.VarChar,800),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@ffshys", SqlDbType.Bit,1),
					new SqlParameter("@ffzf", SqlDbType.Bit,1),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@vip_type", SqlDbType.VarChar,100),
					new SqlParameter("@tsyq", SqlDbType.VarChar,800),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@ddly", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,50),
                    new SqlParameter("@DB_Option_Action_", SqlDbType.VarChar,50)};
                   parameters[0].Value = dr["yydh"];
                   parameters[1].Value = dr["qymc"];
                   parameters[2].Value = dr["jzbh"];
                   parameters[3].Value = dr["lsbh"];
                   parameters[4].Value = dr["ddbh"];
                   parameters[5].Value = Convert.ToBoolean(dr["is_top"]);
                   parameters[6].Value = Convert.ToBoolean(dr["is_select"]);
                   parameters[7].Value = dr["hykh"];
                   parameters[8].Value = dr["hyrx"];
                   parameters[9].Value = dr["krxm"];
                   parameters[10].Value = dr["tlkr"];
                   parameters[11].Value = dr["krgj"];
                   parameters[12].Value = dr["krmz"];
                   parameters[13].Value = dr["yxzj"];
                   parameters[14].Value = dr["zjhm"];
                   parameters[15].Value = dr["krxb"];
                   parameters[16].Value = dr["krsr"];
                   parameters[17].Value = dr["krdh"];
                   parameters[18].Value = dr["krsj"];
                   parameters[19].Value = dr["krEmail"];
                   parameters[20].Value = dr["krdz"];
                   parameters[21].Value = dr["krjg"];
                   parameters[22].Value = dr["krdw"];
                   parameters[23].Value = dr["krzy"];
                   parameters[24].Value = dr["cxmd"];
                   parameters[25].Value = dr["qzrx"];
                   parameters[26].Value = dr["qzhm"];
                   parameters[27].Value = dr["zjyxq"];
                   parameters[28].Value = Convert.ToDateTime(dr["tlyxq"]);
                   parameters[29].Value = Convert.ToDateTime(dr["tjrq"]);
                   parameters[30].Value = dr["lzka"];
                   parameters[31].Value = dr["krly"];
                   parameters[32].Value = dr["xyh"];
                   parameters[33].Value = dr["xydw"];
                   parameters[34].Value = dr["xsy"];
                   parameters[35].Value = dr["ddrx"];
                   parameters[36].Value = dr["ddwz"];
                   parameters[37].Value = dr["zyzt"];
                   parameters[38].Value = dr["krrx"];
                   parameters[39].Value = Convert.ToInt32(dr["kr_children"]);
                   parameters[40].Value = Convert.ToDateTime(dr["ddsj"]);
                   parameters[41].Value = dr["ddyy"];
                   parameters[42].Value = Convert.ToInt32(dr["lzts"]);
                   parameters[43].Value = Convert.ToDateTime(dr["lksj"]);
                   parameters[44].Value = dr["qtyq"];
                   parameters[45].Value = dr["czy"];
                   parameters[46].Value = Convert.ToDateTime(dr["czsj"]);
                   parameters[47].Value = dr["cznr"];
                   parameters[48].Value = true;
                   parameters[49].Value = dr["sktt"];
                   parameters[50].Value = dr["yddj"];
                   parameters[51].Value = Convert.ToBoolean(dr["ffshys"]);
                   parameters[52].Value = Convert.ToBoolean(dr["ffzf"]);
                   parameters[53].Value = dr["main_sec"];
                   parameters[54].Value = true;
                   parameters[55].Value = dr["syzd"];
                   parameters[56].Value = dr["vip_type"];
                   parameters[57].Value = dr["tsyq"];
                   parameters[58].Value = true;
                   parameters[59].Value = dr["ddly"];
                   parameters[60].Value = dr["hykh_bz"];
                   parameters[61].Value = "Insert";
                   SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qskyd_mainrecord_lskr_InsertUpdateDelete", parameters);
               }
           }
       }
       public static void Download_Qskyd_lskr_delete()
       {
           BLL.Qskyd_lskr_delete B_Qskyd_lskr_delete = new BLL.Qskyd_lskr_delete();
           Model.Qskyd_lskr_delete M_Qskyd_lskr_delete = new Model.Qskyd_lskr_delete();
           string csdatatime = "1800-01-01";
           string jsdatatime = "1800-01-01";

           DataSet DS_download = new DataSet();
           object[] args = new object[4];
           args[0] = yydh;
           args[1] = csdatatime;
           args[2] = jsdatatime;
           args[3] = DS_download;
           object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qskyd_lskr_delete_download", args);
           jsdatatime = (String)args[2];
           if (result.ToString() == common_file.common_app.get_suc)
           {
               DS_download = (DataSet)args[3];//下载好后把值传给本地数据库
               jsdatatime = (String)args[2];  //读取结束时间
               csdatatime = (String)args[1];//读取初始时间

               foreach (DataRow dr in DS_download.Tables[0].Rows)
               {
                   string hykh_service = dr["lsbh"].ToString();
                   SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czsj", SqlDbType.DateTime),
                    new SqlParameter("@DB_Option_Action_",SqlDbType.VarChar,50)
                   };
                   parameters[0].Value = dr["yydh"];
                   parameters[1].Value = dr["qymc"];
                   parameters[2].Value = dr["lsbh"];
                   parameters[3].Value = true;
                   parameters[4].Value = Convert.ToDateTime(dr["czsj"]);
                   parameters[5].Value = "Insert";
                   SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qskyd_lskr_delete_InsertUpdateDelete", parameters);
               }
               //下载完后删除门店lsbh相同的信息这个写在添加的触发器
           }
           common_file.Common_lskr.DownLoadUpdate(jsdatatime); //用于下载成功后修改远程服务下载时间
       }
       #endregion

       //用于下载成功后修改远程服务下载时间
       public static string DownLoadUpdate(string jsdatatime)
       {          
           string ss = common_file.common_app.get_failure;
           object[] obj = new object[2];
           obj[0] = yydh;
           obj[1] = jsdatatime;
           object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Lskr_scxzsj", obj);
           ss = result.ToString();
           return ss;
       
       }

       #region  客史的初始化
       public static void Download_Qskyd_fjrb_lskr_cs()
       {
           BLL.Qskyd_fjrb_lskr B_Qskyd_fjrb_lskr = new BLL.Qskyd_fjrb_lskr();
           Model.Qskyd_fjrb_lskr M_Qskyd_fjrb_lskr = new Model.Qskyd_fjrb_lskr();
           DataSet DS_download = new DataSet();
           object[] args = new object[2];
           args[0] = yydh;
           args[1] = DS_download;
           object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_lskr_download_cs", args);
           if (result.ToString() == common_file.common_app.get_suc)
           {
               DS_download = (DataSet)args[1];//下载好后把值传给本地数据库
               foreach (DataRow dr in DS_download.Tables[0].Rows)
               {
                   string hykh_service = dr["lsbh"].ToString();
                   SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,100),
					new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@yhbl", SqlDbType.Decimal,9),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@fjbm", SqlDbType.VarChar,50),
					new SqlParameter("@jcje", SqlDbType.Decimal,9),
                    new SqlParameter("@DB_Option_Action_", SqlDbType.VarChar,50),
                   };
                   parameters[0].Value = dr["yydh"];
                   parameters[1].Value = dr["qymc"];
                   parameters[2].Value = dr["jzbh"];
                   parameters[3].Value = dr["lsbh"];
                   parameters[4].Value = dr["krxm"];
                   parameters[5].Value = dr["sktt"];
                   parameters[6].Value = dr["yddj"];
                   parameters[7].Value = dr["fjrb"];
                   parameters[8].Value = dr["fjbh"];
                   parameters[9].Value = Convert.ToDateTime(dr["ddsj"]);
                   parameters[10].Value = Convert.ToDateTime(dr["lksj"]);
                   parameters[11].Value = Convert.ToDecimal(dr["lzfs"]);
                   parameters[12].Value = dr["shqh"];
                   parameters[13].Value = Convert.ToDecimal(dr["fjjg"]);
                   parameters[14].Value = Convert.ToDecimal(dr["sjfjjg"]);
                   parameters[15].Value = dr["yh"];
                   parameters[16].Value = Convert.ToDecimal(dr["yhbl"]);
                   parameters[17].Value = dr["bz"];
                   parameters[18].Value = Convert.ToBoolean(dr["is_top"]);
                   parameters[19].Value = Convert.ToBoolean(dr["is_select"]);
                   parameters[20].Value = true;
                   parameters[21].Value = dr["czy"];
                   parameters[22].Value = Convert.ToDateTime(dr["czsj"]);
                   parameters[23].Value = dr["cznr"];
                   parameters[24].Value = Convert.ToBoolean(dr["sdcz"]);
                   parameters[25].Value = false;
                   parameters[26].Value = dr["fjbm"];
                   parameters[27].Value = Convert.ToDecimal(dr["jcje"]);
                   parameters[28].Value = "Insert";
                   SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qskyd_fjrb_lskr_InsertUpdateDelete", parameters);
               }
           }
       }
       public static void Download_Qskyd_mainrecord_lskr_cs()
       {
           BLL.Qskyd_mainrecord_lskr B_Qskyd_mainrecord_lskr = new BLL.Qskyd_mainrecord_lskr();
           Model.Qskyd_mainrecord_lskr M_Qskyd_mainrecord_lskr = new Model.Qskyd_mainrecord_lskr();


           DataSet DS_download = new DataSet();
           object[] args = new object[2];
           args[0] = yydh;
           args[1] = DS_download;
           object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, " Qskyd_mainrecord_lskr_download_cs", args);
           if (result.ToString() == common_file.common_app.get_suc)
           {
               DS_download = (DataSet)args[1];//下载好后把值传给本地数据库
               foreach (DataRow dr in DS_download.Tables[0].Rows)
               {
                   string hykh_service = dr["lsbh"].ToString();
                   SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,100),
					new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@ddbh", SqlDbType.VarChar,100),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@tlkr", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,50),
					new SqlParameter("@krjg", SqlDbType.VarChar,50),
					new SqlParameter("@krdw", SqlDbType.VarChar,50),
					new SqlParameter("@krzy", SqlDbType.VarChar,50),
					new SqlParameter("@cxmd", SqlDbType.VarChar,50),
					new SqlParameter("@qzrx", SqlDbType.VarChar,50),
					new SqlParameter("@qzhm", SqlDbType.VarChar,50),
					new SqlParameter("@zjyxq", SqlDbType.DateTime),
					new SqlParameter("@tlyxq", SqlDbType.DateTime),
					new SqlParameter("@tjrq", SqlDbType.DateTime),
					new SqlParameter("@lzka", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddrx", SqlDbType.VarChar,50),
					new SqlParameter("@ddwz", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@krrx", SqlDbType.VarChar,50),
					new SqlParameter("@kr_children", SqlDbType.Int,4),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@ddyy", SqlDbType.VarChar,200),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@qtyq", SqlDbType.VarChar,800),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@ffshys", SqlDbType.Bit,1),
					new SqlParameter("@ffzf", SqlDbType.Bit,1),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@vip_type", SqlDbType.VarChar,100),
					new SqlParameter("@tsyq", SqlDbType.VarChar,800),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@ddly", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,50),
                    new SqlParameter("@DB_Option_Action_", SqlDbType.VarChar,50)};
                   parameters[0].Value = dr["yydh"];
                   parameters[1].Value = dr["qymc"];
                   parameters[2].Value = dr["jzbh"];
                   parameters[3].Value = dr["lsbh"];
                   parameters[4].Value = dr["ddbh"];
                   parameters[5].Value = Convert.ToBoolean(dr["is_top"]);
                   parameters[6].Value = Convert.ToBoolean(dr["is_select"]);
                   parameters[7].Value = dr["hykh"];
                   parameters[8].Value = dr["hyrx"];
                   parameters[9].Value = dr["krxm"];
                   parameters[10].Value = dr["tlkr"];
                   parameters[11].Value = dr["krgj"];
                   parameters[12].Value = dr["krmz"];
                   parameters[13].Value = dr["yxzj"];
                   parameters[14].Value = dr["zjhm"];
                   parameters[15].Value = dr["krxb"];
                   parameters[16].Value = dr["krsr"];
                   parameters[17].Value = dr["krdh"];
                   parameters[18].Value = dr["krsj"];
                   parameters[19].Value = dr["krEmail"];
                   parameters[20].Value = dr["krdz"];
                   parameters[21].Value = dr["krjg"];
                   parameters[22].Value = dr["krdw"];
                   parameters[23].Value = dr["krzy"];
                   parameters[24].Value = dr["cxmd"];
                   parameters[25].Value = dr["qzrx"];
                   parameters[26].Value = dr["qzhm"];
                   parameters[27].Value = dr["zjyxq"];
                   parameters[28].Value = Convert.ToDateTime(dr["tlyxq"]);
                   parameters[29].Value = Convert.ToDateTime(dr["tjrq"]);
                   parameters[30].Value = dr["lzka"];
                   parameters[31].Value = dr["krly"];
                   parameters[32].Value = dr["xyh"];
                   parameters[33].Value = dr["xydw"];
                   parameters[34].Value = dr["xsy"];
                   parameters[35].Value = dr["ddrx"];
                   parameters[36].Value = dr["ddwz"];
                   parameters[37].Value = dr["zyzt"];
                   parameters[38].Value = dr["krrx"];
                   parameters[39].Value = Convert.ToInt32(dr["kr_children"]);
                   parameters[40].Value = Convert.ToDateTime(dr["ddsj"]);
                   parameters[41].Value = dr["ddyy"];
                   parameters[42].Value = Convert.ToInt32(dr["lzts"]);
                   parameters[43].Value = Convert.ToDateTime(dr["lksj"]);
                   parameters[44].Value = dr["qtyq"];
                   parameters[45].Value = dr["czy"];
                   parameters[46].Value = Convert.ToDateTime(dr["czsj"]);
                   parameters[47].Value = dr["cznr"];
                   parameters[48].Value = true;
                   parameters[49].Value = dr["sktt"];
                   parameters[50].Value = dr["yddj"];
                   parameters[51].Value = Convert.ToBoolean(dr["ffshys"]);
                   parameters[52].Value = Convert.ToBoolean(dr["ffzf"]);
                   parameters[53].Value = dr["main_sec"];
                   parameters[54].Value = true;
                   parameters[55].Value = dr["syzd"];
                   parameters[56].Value = dr["vip_type"];
                   parameters[57].Value = dr["tsyq"];
                   parameters[58].Value = true;
                   parameters[59].Value = dr["ddly"];
                   parameters[60].Value = dr["hykh_bz"];
                   parameters[61].Value = "Insert";
                   SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qskyd_mainrecord_lskr_InsertUpdateDelete", parameters);
               }
           }
       }
#endregion
       
    }
}
