using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using jdgl_res_head_app.common_file;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace jdgl_res_head_app.Com
{
    /// <summary>
    /// 订单帮助类
    /// </summary>
    public class OrderHelper
    {

        public static string url = "";
        public static string yydh = common_app.yydh;
        public static string qymc = common_app.qymc;
        //用于错误日志
        public static string errorInfo = "";
        //用于标识错误出现位置
        public static string postion = "";
        public string ss = common_app.get_failure;


        /// <summary>
        /// 下载订单信息
        /// </summary>
        public static void DownLoadOrderFromSite()
        {
            string lsbh;
            string ddbh;
            Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Model.Qskyd_mainrecord();
            BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new BLL.Qskyd_mainrecord();

            DataSet ds = null;
            //获取订单
            ds = GetOrderFromSite(1);
            //处理订单
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lsbh = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                    ddbh = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                    string krxm = "";
                    M_Qskyd_mainrecord.lsbh = lsbh;
                    M_Qskyd_mainrecord.yydh = Com.ConfigInfo.yydh;
                    M_Qskyd_mainrecord.qymc = Com.ConfigInfo.qymc;
                    M_Qskyd_mainrecord.ddbh = ddbh;
                    M_Qskyd_mainrecord.hykh = dr["user_id"].ToString();
                    M_Qskyd_mainrecord.hyrx = Com.Common.hyrx_site;
                    M_Qskyd_mainrecord.krxm = dr["yd_name"].ToString();
                    //M_Qskyd_mainrecord.krgj = Com.Common.hyrx_site;
                    //M_Qskyd_mainrecord.krmz = dr[12].ToString();
                    //M_Qskyd_mainrecord.yxzj = dr[13].ToString();
                    //M_Qskyd_mainrecord.zjhm = dr[14].ToString();
                    M_Qskyd_mainrecord.krxb = dr["yd_sex"].ToString();
                    M_Qskyd_mainrecord.krsj = dr["yd_mobile"].ToString();
                    M_Qskyd_mainrecord.krEmail = dr["yd_email"].ToString();
                    //M_Qskyd_mainrecord.krdz = dr[20].ToString();
                    M_Qskyd_mainrecord.krly = Com.Common.hyrx_site;
                    M_Qskyd_mainrecord.yddj = common_app.yddj_yd;
                    M_Qskyd_mainrecord.sktt = common_app.sktt_sk;
                    M_Qskyd_mainrecord.ddly = common_app.ddly;
                    M_Qskyd_mainrecord.cznr = common_app.cznr_add;
                    //M_Qskyd_mainrecord.xyh = dr[23].ToString();
                    //M_Qskyd_mainrecord.xydw = dr[24].ToString();
                    M_Qskyd_mainrecord.xsy = Com.Common.xsy_site;
                    M_Qskyd_mainrecord.ddsj = Convert.ToDateTime(dr["yd_statetime"].ToString());
                    M_Qskyd_mainrecord.lksj = Convert.ToDateTime(dr["yd_endtime"].ToString()).AddHours(12);
                    //M_Qskyd_mainrecord.czy = dr[28].ToString();
                    //M_Qskyd_mainrecord.hykh_bz = dr[6].ToString();
                    //M_Qskyd_mainrecord.lzts = Convert.ToInt32(dr[38].ToString());
                    M_Qskyd_mainrecord.shsc = true;
                    M_Qskyd_mainrecord.ddyy = common_file.Common.ReadXML("add", "hyrx_site");       //Com.Common.hyrx_site;//标志网上预订
                    M_Qskyd_mainrecord.zyzt = common_app.yddj_yd;
                    M_Qskyd_mainrecord.qtyq = dr["content"].ToString();//其它要求
                    B_Qskyd_mainrecord.Add(M_Qskyd_mainrecord);
                    string Remote_lsbh = dr["order_lsbh"].ToString();
                    //向中心服务器加本的新生成的lsbh成功后修改web_skyd各web_Qskyd_fjrb中字段shsc = 1都放在同一个存储过程注意;
                    InsertToQyddjlsbhbg_yy(Remote_lsbh, lsbh, yydh);
                    //下载完后修改本地Qskyd_fjrb表fjrb，fjjg等
                    string qc_fjrb = dr["title"].ToString();
                    decimal qc_fjjg = Com.CommFunc.GetDecimalValue(dr["yd_jg"].ToString());
                    Qskyd_fjrb_Update(lsbh, qc_fjrb, 1, qc_fjjg, qc_fjjg);
                    string lflsbh = common_file.common_ddbh.ddbh("lf", "skyddate", "skydcounter", 6);//联房编号
                    //下载完后添加到联房里
                    Common_flfsz.Flfsz_add(yydh, qymc, lflsbh, lsbh, "", krxm, common_app.sktt_sk, common_app.yddj_yd, Com.Common.xsy_site);
                }
            }
        }

        /// <summary>
        /// 更新订单信息
        /// </summary>
        public static void RefreshOrderStatus()
        {
            //获取需要更新状态的订单 shsc=0
            DataSet ds = DbHelperSQL.Query(" select  *  from  Qyqskyd_ydzxqr where shsc=0 ");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int OrderState = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    OrderState = (string.Equals("确认", dr["qrzt"].ToString(), StringComparison.OrdinalIgnoreCase)) ? 2 : 3;
                    try
                    {
                        url = common_file.Common.ReadXML("add", "url") + "/S8Server/Qyddj_app.asmx";
                        object[] obj = new object[3];
                        obj[0] = dr["lsbh"].ToString();
                        obj[1] = dr["yydh"].ToString();
                        obj[2] = OrderState;
                        object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "SetAcceptOrderStatus", obj);
                        if (result != null)
                        {
                            if (string.Equals(result.ToString(), common_app.get_suc, StringComparison.OrdinalIgnoreCase))
                            {
                                DbHelperSQL.ExecuteSql(string.Format(@"  Update    Qyqskyd_ydzxqr  set   shsc=1  where  id={0}  ", int.Parse(dr["id"].ToString())));
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }


        private static DataSet GetOrderFromSite(int orderState)
        {
            DataSet ds = null;
            try
            {
                url = common_file.Common.ReadXML("add", "url") + "/S8Server/Qyddj_app.asmx";
                object[] obj = new object[1];
                obj[0] = orderState;
                object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "GetOrderFromSite", obj);
                if (result != null)
                {
                    ds = result as DataSet;
                }
            }
            catch
            {
                return null;
            }
            return ds;
        }


        //用于向中心服务器Qyddjlsbhbg_yy插入数据的方法
        public static void InsertToQyddjlsbhbg_yy(string yclsbh, string bdlsbh, string bdyydh)
        {
            try
            {
                url = common_file.Common.ReadXML("add", "url") + "/S8Server/Qyddj_app.asmx";
                object[] obj = new object[3];
                obj[0] = yclsbh;
                obj[1] = bdlsbh;
                obj[2] = bdyydh;
                object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "InsertToQyddjlsbhbg_yy", obj);
                if (result != null && result.ToString().Equals(common_app.get_suc, StringComparison.OrdinalIgnoreCase))
                {
                    Common.WriteLog("写入Qyddjlsbhbg_yy正常", "下载订单插入到网站Qyddjlsbhbg_yy表");
                }
                else
                {
                    Common.WriteLog("写入Qyddjlsbhbg_yy失败,请检查表中心数据库上面Qyddjlsbhbg_yy表是否存在以及存储过程[InsertToQyddjlsbhbg_yy]是否存在", "下载订单插入到网站Qyddjlsbhbg_yy表");
                }
            }
            catch (Exception ee)
            {
                errorInfo = ee.Message.ToString();
                postion = "向网站数据库Qyddjlsbhbg_yy插入数据之后到修改mt_order相关订单为已下载过程之中";
                Common.WriteLog(errorInfo, postion);
            }
        }


        //门店下载网上预定数据后，修改本地Qskyd_fjrb表入住数，fjbh等信息
        public static string Qskyd_fjrb_Update(string lsbh, string fjrb, decimal lzfs, decimal fjjg, decimal sjfjjg)
        {
            string s = common_app.get_failure;
            SqlParameter[] sp = {
						new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9)};
            sp[0].Value = lsbh;
            sp[1].Value = fjrb;
            sp[2].Value = lzfs;
            sp[3].Value = fjjg;
            sp[4].Value = sjfjjg;
            int rows = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qskyd_fjrb_Update", sp);
            if (rows > 0)
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        //增加到联房表里面
        public static void Flfsz_add(string yydh, string qymc, string lfbh, string lsbh, string fjbh, string krxm, string sktt, string yddj, string czy)
        {
            SqlParameter[] sp = {
				    new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lfbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@shlz", SqlDbType.Bit,1)};
            sp[0].Value = yydh;
            sp[1].Value = qymc;
            sp[2].Value = lfbh;
            sp[3].Value = lsbh;
            sp[4].Value = fjbh;
            sp[5].Value = krxm;
            sp[6].Value = sktt;
            sp[7].Value = yddj;
            sp[8].Value = czy;
            sp[9].Value = "新增";
            sp[10].Value = DateTime.Now;
            sp[11].Value = 1;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Flfsz_ADD", sp);
        }

    }

    /// <summary>
    /// 订单状态
    /// </summary>
    enum OrderState
    {
        预订 = 1,
        未上传 = 2,
        已上传 = 3,
        已完成 = 4
    }
}
