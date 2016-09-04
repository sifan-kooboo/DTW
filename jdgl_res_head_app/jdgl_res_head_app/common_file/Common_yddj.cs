using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace jdgl_res_head_app.common_file
{
    public class Common_yddj
    {
        public static string url = "";
        public static string qymc = "";
        //用于错误日志
        public static string errorInfo = "";
        //用于标识错误出现位置
        public static string postion = "";
        public string ss = common_app.get_failure;
        //下载网上预订的方法
        public static int Download_orderFrom400()
        {
            Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Model.Qskyd_mainrecord();
            BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new BLL.Qskyd_mainrecord();
            string lsbh = ""; string ddbh = "";
            int dlsum = 0;
            string ss = common_app.get_failure;
            url = common_file.Common.ReadXML("add", "url") + "/Qyddj/Qyddj_app.asmx";
            DataSet DS_downloadData = new DataSet();
            qymc = common_file.Common.Getqyxx(2);
            int rows = 0;
            bool status = false;

            object[] obj = new object[4];
            obj[0] = qymc;
            obj[1] = rows;
            obj[2] = status;
            obj[3] = DS_downloadData;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "yddj_download_DS", obj);
            ss = result.ToString();
            if (ss == common_app.get_suc)
            {
                #region  预订中心数据处理
                try
                {
                    DS_downloadData = (DataSet)obj[3];
                    foreach (DataRow dr in DS_downloadData.Tables[0].Rows)
                    {
                        string sktt_value = dr[30].ToString();
                        //第一步，生成本地临时编号
                        string lflsbh = common_file.common_ddbh.ddbh("lf", "skyddate", "skydcounter", 6); ;//联房编号
                        string Remote_lsbh = dr[3].ToString();//远程lsbh
                        string Local_yydh = dr[1].ToString();//中心服务的yydh
                        string yydh = dr[1].ToString();
                        qymc = dr[2].ToString();
                        int xfCount = 0;

                        //如果是团体直接添加到本地Qttyd_mainrecord表中和中心服务器Qydlsbhbg_yy表插入数据
                        if (sktt_value == common_app.sktt_tt)
                        {
                            //id,yydh,qymc,lsbh,ddbh,hykh,hykh_bz,hyrx,krxm,krbh,ydrxm,
                            //krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,
                            //qtyq,krly,xyh,xydw,xsy,ddsj,lksj,czy,ydsj,sktt,
                            //yddj,vip_type,fjrb,fjbh,sjjg,jsjg,lzfs,lzts,lzrs,sfqr,
                            //ydxg,shxg,shsc
                            Model.Qttyd_mainrecord M_Qttyd_mainrecord = new Model.Qttyd_mainrecord();
                            BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new BLL.Qttyd_mainrecord();
                            lsbh = common_file.common_ddbh.ddbh("ttyd", "ttyddate", "ttydcounter", 6);
                            ddbh = common_file.common_ddbh.ddbh("ttyd", "ttyddate", "ttydcounter", 6);
                            M_Qttyd_mainrecord.cznr = common_app.cznr_add;
                            M_Qttyd_mainrecord.czsj = DateTime.Now;
                            M_Qttyd_mainrecord.czy = dr[28].ToString();
                            M_Qttyd_mainrecord.ddbh = ddbh;
                            M_Qttyd_mainrecord.ddly = common_app.ddly;
                            M_Qttyd_mainrecord.ddrx = "";
                            M_Qttyd_mainrecord.ddsj = Convert.ToDateTime(dr[26].ToString()).AddHours(12);
                            M_Qttyd_mainrecord.ddwz = "";
                            M_Qttyd_mainrecord.ddyy = "";
                            M_Qttyd_mainrecord.ffshys = false;
                            M_Qttyd_mainrecord.krbh = dr[9].ToString();
                            M_Qttyd_mainrecord.krdh = dr[17].ToString();
                            M_Qttyd_mainrecord.krdz = dr[20].ToString();
                            M_Qttyd_mainrecord.krEmail = dr[19].ToString();
                            M_Qttyd_mainrecord.krgj = dr[11].ToString();
                            M_Qttyd_mainrecord.krly = dr[22].ToString();
                            M_Qttyd_mainrecord.krsj = dr[18].ToString();
                            M_Qttyd_mainrecord.krxm = dr[8].ToString();
                            M_Qttyd_mainrecord.lksj = Convert.ToDateTime(dr[27].ToString()).AddHours(12);
                            M_Qttyd_mainrecord.lsbh = lsbh;
                            M_Qttyd_mainrecord.lzts = Convert.ToInt32(dr[38].ToString());
                            M_Qttyd_mainrecord.qtyq = dr[21].ToString();
                            M_Qttyd_mainrecord.qymc = qymc;
                            M_Qttyd_mainrecord.sdcz = false;
                            M_Qttyd_mainrecord.shsc = true;
                            M_Qttyd_mainrecord.sktt = common_app.sktt_tt;
                            M_Qttyd_mainrecord.syzd = "";
                            M_Qttyd_mainrecord.tsyq = "";
                            M_Qttyd_mainrecord.xsy = dr[25].ToString();
                            M_Qttyd_mainrecord.xydw = dr[24].ToString();
                            M_Qttyd_mainrecord.xyh = dr[23].ToString();
                            M_Qttyd_mainrecord.yddj = common_app.yddj_yd;
                            M_Qttyd_mainrecord.ydrxm = dr[10].ToString();
                            M_Qttyd_mainrecord.yydh = yydh;
                            M_Qttyd_mainrecord.zyzt = "";
                            M_Qttyd_mainrecord.ddyy =common_app.ddyy;//标志网上预订
                            M_Qskyd_mainrecord.zyzt = common_app.yddj_yd;
                            B_Qttyd_mainrecord.Add(M_Qttyd_mainrecord);
                            //向中心服务器加本地的新生成的lsbh，成功后修改web_skyd的shsc = 1都放在同一个存储过程注意，
                            InsertToQyddjlsbhbg_yy(Remote_lsbh, lsbh, Local_yydh);
                        }
                        //第二步，1.sktt=散客，根据房间数量生成相对应的Qskyd_mainrecord主单和中心服务器Qydlsbhbg_yy表插入数据，修改Qskyd_fjrb表里的fjrb,lzfs,shsc，并且添加到联房。
                        //        2.sktt=团体，如果是第一条房型的话就直接修改Qskyd_fjrb，第二种房型就直接加到Qskyd_fjrb表
                        DataSet DS_Fjrb = Qskydfjrb_ds(qymc, Remote_lsbh);
                        foreach (DataRow rb in DS_Fjrb.Tables[0].Rows)
                        {
                            xfCount++;
                            string lzfs = rb[12].ToString().Substring(0, rb[12].ToString().TrimEnd().IndexOf("."));
                            int qc_lzfsa = int.Parse(lzfs.ToString());
                            string qc_fjrb = rb[8].ToString(); //房间类别
                            decimal qc_lzfs = Convert.ToDecimal(rb[12].ToString());//入住房数
                            decimal qc_fjjg = Convert.ToDecimal(rb[14].ToString());
                            if (qc_lzfsa > 0)
                            {
                                #region 如果sktt=散客。
                                if (sktt_value == common_app.sktt_sk)//如果是散客
                                {
                                    for (int i = 0; i <= qc_lzfsa - 1; i++)
                                    {
                                        //id,yydh,qymc,lsbh,ddbh,hykh,hykh_bz,hyrx,krxm,krbh,ydrxm,
                                        //krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,
                                        //qtyq,krly,xyh,xydw,xsy,ddsj,lksj,czy,ydsj,sktt,
                                        //yddj,vip_type,fjrb,fjbh,sjjg,jsjg,lzfs,lzts,lzrs,sfqr,
                                        //ydxg,shxg,shsc
                                        lsbh = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                                        ddbh = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                                        string krxm = dr[8].ToString();
                                        M_Qskyd_mainrecord.lsbh = lsbh;
                                        M_Qskyd_mainrecord.yydh = yydh;
                                        M_Qskyd_mainrecord.qymc = qymc;
                                        M_Qskyd_mainrecord.ddbh = ddbh;
                                        M_Qskyd_mainrecord.hykh = dr[5].ToString();
                                        M_Qskyd_mainrecord.hyrx = dr[7].ToString();
                                        M_Qskyd_mainrecord.krxm = krxm;
                                        M_Qskyd_mainrecord.krgj = dr[11].ToString();
                                        M_Qskyd_mainrecord.krmz = dr[12].ToString();
                                        M_Qskyd_mainrecord.yxzj = dr[13].ToString();
                                        M_Qskyd_mainrecord.zjhm = dr[14].ToString();
                                        M_Qskyd_mainrecord.krxb = dr[15].ToString();
                                        M_Qskyd_mainrecord.krsj = dr[18].ToString();
                                        M_Qskyd_mainrecord.krEmail = dr[19].ToString();
                                        M_Qskyd_mainrecord.krdz = dr[20].ToString();
                                        M_Qskyd_mainrecord.krly = dr[22].ToString();
                                        M_Qskyd_mainrecord.yddj = common_app.yddj_yd;
                                        M_Qskyd_mainrecord.sktt = common_app.sktt_sk;
                                        M_Qskyd_mainrecord.ddly = common_app.ddly;
                                        M_Qskyd_mainrecord.cznr = common_app.cznr_add;
                                        M_Qskyd_mainrecord.xyh = dr[23].ToString();
                                        M_Qskyd_mainrecord.xydw = dr[24].ToString();
                                        M_Qskyd_mainrecord.xsy = dr[25].ToString();
                                        M_Qskyd_mainrecord.ddsj = Convert.ToDateTime(dr[26].ToString()).AddHours(12);
                                        M_Qskyd_mainrecord.lksj = Convert.ToDateTime(dr[27].ToString()).AddHours(12);
                                        M_Qskyd_mainrecord.czy = dr[28].ToString();
                                        M_Qskyd_mainrecord.hykh_bz = dr[6].ToString();
                                        M_Qskyd_mainrecord.lzts = Convert.ToInt32(dr[38].ToString());
                                        M_Qskyd_mainrecord.shsc = true;
                                        M_Qskyd_mainrecord.ddyy = common_app.ddyy;//标志网上预订
                                        M_Qskyd_mainrecord.zyzt = common_app.yddj_yd;
                                        M_Qskyd_mainrecord.qtyq = dr[21].ToString();//其它要求
                                        B_Qskyd_mainrecord.Add(M_Qskyd_mainrecord);

                                        //向中心服务器加本的新生成的lsbh成功后修改web_skyd各web_Qskyd_fjrb中字段shsc = 1都放在同一个存储过程注意;
                                        InsertToQyddjlsbhbg_yy(Remote_lsbh, lsbh, Local_yydh);
                                        //下载完后修改本地Qskyd_fjrb表fjrb，fjjg等
                                        Qskyd_fjrb_Update(lsbh, qc_fjrb,1, qc_fjjg, qc_fjjg);
                                        //下载完后添加到联房里
                                        Common_flfsz.Flfsz_add(yydh, qymc, lflsbh, lsbh, "", krxm, common_app.sktt_sk, common_app.yddj_yd,dr[28].ToString());
                                    }
                                    dlsum = int.Parse(DS_downloadData.Tables[0].Rows.Count.ToString());//返回行数
                                }
                                #endregion
                                #region   如果是团体
                                else if (sktt_value == common_app.sktt_tt)//如果是团体
                                {
                                    //修改本地Qskyd_fjrb表中的房型
                                    //1.如果是第一条房型的话就直接修改Qskyd_fjrb。
                                    //2.除第一条其它数据就直接添加房型
                                    if (xfCount == 1)
                                    {
                                        Qskyd_fjrb_Update(lsbh, qc_fjrb, qc_lzfs, qc_fjjg, qc_fjjg);
                                    }
                                    else
                                    {
                                        
                                        Model.Qskyd_fjrb M_fjrb = new Model.Qskyd_fjrb();
                                        BLL.Qskyd_fjrb B_fjrb = new BLL.Qskyd_fjrb();
                                        M_fjrb.yydh = yydh;
                                        M_fjrb.yddj = common_app.yddj_yd;
                                        M_fjrb.sktt = common_app.sktt_tt;
                                        M_fjrb.sjfjjg = Convert.ToDecimal(rb[15].ToString());
                                        M_fjrb.shsc = true;
                                        M_fjrb.shqh = rb[13].ToString();
                                        M_fjrb.qymc = qymc;
                                        M_fjrb.lzfs = Convert.ToDecimal(rb[12].ToString());
                                        M_fjrb.lsbh = lsbh;
                                        M_fjrb.lksj = Convert.ToDateTime(dr[27].ToString()).AddHours(12);
                                        M_fjrb.krxm = rb[5].ToString();
                                        M_fjrb.fjrb = rb[8].ToString();
                                        M_fjrb.fjjg = Convert.ToDecimal(rb[15].ToString());
                                        M_fjrb.fjbh = "";
                                        M_fjrb.fjbm = "";
                                        M_fjrb.ddsj = Convert.ToDateTime(dr[26].ToString()).AddHours(12);
                                        M_fjrb.bz = rb[16].ToString();
                                        M_fjrb.cznr = common_app.cznr_add;
                                        M_fjrb.czy = dr[28].ToString();
                                        B_fjrb.Add(M_fjrb);
                                    }
                                    dlsum = int.Parse(DS_downloadData.Tables[0].Rows.Count.ToString());//返回行数
                                }
                             #endregion
                                //UpdateWeb_skyd_fjrb_shsc(int.Parse(rb[0].ToString()));
                            }
                        }
                    }
                    return dlsum;
                }
                catch (Exception ee)
                {
                    errorInfo = ee.Message.ToString();
                    postion = "向本地Qskyd_mainrecord插入数据之后到修改远程服务器下载数据的过程之中";
                    Common.WriteLog(errorInfo, postion);
                }
                #endregion
            }
            return dlsum;
        }



        //用于向中心服务器Qyddjlsbhbg_yy插入数据的方法
        public static void InsertToQyddjlsbhbg_yy(string yclsbh, string bdlsbh, string bdyydh)
        {
            try
            {
                url = common_file.Common.ReadXML("add", "url") + "/Qyddj/Qyddj_app.asmx";
                object[] obj = new object[3];
                obj[0] = yclsbh;
                obj[1] = bdlsbh;
                obj[2] = bdyydh;
                object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "InsertToQyddjlsbhbg_yy", obj);
            }
            catch (Exception ee)
            {
                errorInfo = ee.Message.ToString();
                postion = "向中心服务器Qyddjlsbhbg_yy插入数据之后到修改远程服务器下载数据的过程之中";
                Common.WriteLog(errorInfo, postion);
            }
        }

        //读取lsbh相对应的房型的ds
        public static DataSet Qskydfjrb_ds(string qymc, string lsbh)
        {
            string ss = common_app.get_failure;
            url = common_file.Common.ReadXML("add", "url") + "/Qyddj/Qyddj_app.asmx";
            DataSet DS_downloadData = new DataSet();
            qymc = common_file.Common.Getqyxx(2);
            int rows = 0;
            object[] obj = new object[4];
            obj[0] = qymc;
            obj[1] = lsbh;
            obj[2] = rows;
            obj[3] = DS_downloadData;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "WebQskyd_fjrb_DS", obj);
            ss = result.ToString();
            if (ss == common_app.get_suc)
            {
                DS_downloadData = (DataSet)obj[3];

            }
            return DS_downloadData;


        }


        //用于向中心服务器修改Web_skyd_fjrb表中shsc=1的方法
        public static void UpdateWeb_skyd_fjrb_shsc(int id)
        {
            try
            {
                url = common_file.Common.ReadXML("add", "url") + "/Qyddj/Qyddj_app.asmx";
                object[] obj = new object[3];
                obj[0] = id;
                object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Web_Qskyd_fjrb_Updateshsc", obj);
            }
            catch (Exception ee)
            {
                errorInfo = ee.Message.ToString();
                postion = "向中心服务器Qyddjlsbhbg_yy插入数据之后到修改远程服务器下载数据的过程之中";
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



        //用于网上预定门店确认后，向中心服务器表：Qttyd_ydzxqr  插入数据,并修改本地Qttyd_ydzxqr表的shsc为1
        public static string InsertToQttyd_ydzxqr()
        {
            string ss = common_app.get_failure;
            Model.Qyqskyd_ydzxqr M_Qyqskyd_ydzxqr = new Model.Qyqskyd_ydzxqr();
            BLL.Qyqskyd_ydzxqr B_Qyqskyd_ydzxqr = new BLL.Qyqskyd_ydzxqr();
            DataSet DS_UploadData = B_Qyqskyd_ydzxqr.GetList(" shsc='0'  ");
            if (DS_UploadData != null && DS_UploadData.Tables[0].Rows.Count > 0)
            {
                try
                {
                    //调用webservices(整体成功后才修改本地的状态)
                    url = common_file.Common.ReadXML("add", "url") + "/Qyddj/Qyddj_app.asmx";
                    object[] obj = new object[1];
                    obj[0] = DS_UploadData;
                    object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qyqskyd_ydzxqr_ad", obj);
                    if (result.ToString() ==common_app.get_suc)
                    {

                        Common_Shsc.Updatshsc(DS_UploadData, "Qyqskyd_ydzxqr");//修改本地shsc=1
                        
                    }
                }
                //错误生成之后,写错误日志，执行重启操作
                catch (Exception ee)
                {
                    //开始写日志
                    errorInfo = ee.Message.ToString();
                    postion = "向中心服务器表:Qttyd_ydzxqr 插入数据之后的过程";
                    Common.WriteLog(errorInfo, postion);
                  
                }
            }
            return ss;
        }

        //用于网上预定门店确认后转入住的明细Qyqskyd_ydzlzmx

        public static string InsertToQttyd_ydzlzmx()
        {
            string ss = common_app.get_failure;
            Model.Qyqskyd_ydzlzmx M_Qyqskyd_ydzlzmx = new Model.Qyqskyd_ydzlzmx();
            BLL.Qyqskyd_ydzlzmx B_Qyqskyd_ydzlzmx = new BLL.Qyqskyd_ydzlzmx();
            DataSet DS_UploadData = B_Qyqskyd_ydzlzmx.GetList(" shsc='0'  ");
            if (DS_UploadData != null && DS_UploadData.Tables[0].Rows.Count > 0)
            {
                try
                {
                    //调用webservices(整体成功后才修改本地的状态)
                    url = common_file.Common.ReadXML("add", "url") + "/Qyddj/Qyddj_app.asmx";
                    object[] obj = new object[1];
                    obj[0] = DS_UploadData;
                    object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Qyqskyd_ydzlzmx_ad", obj);
                    if (result.ToString() == common_app.get_suc)
                    {

                        Common_Shsc.Updatshsc(DS_UploadData, "Qyqskyd_ydzlzmx");//修改本地shsc=1

                    }
                }
                //错误生成之后,写错误日志，执行重启操作
                catch (Exception ee)
                {
                    //开始写日志
                    errorInfo = ee.Message.ToString();
                    postion = "向中心服务器表:Qttyd_ydzxqr 插入数据之后的过程";
                    Common.WriteLog(errorInfo, postion);

                }
            }
            return ss;
        }



        //下载网上预订的方法
        public static int Download_orderFrom400_test()
        {
            Model.MT_Order M_Order = new Model.MT_Order();
            BLL.MT_Order B_Order = new BLL.MT_Order();
            string lsbh = ""; string ddbh = "";
            int dlsum = 0;
            string ss = "failure";
            url = common_file.Common.ReadXML("add", "url") + "/Qyddj/Qyddj_app.asmx";
            DataSet DS_downloadData = new DataSet();
            qymc = common_file.Common.Getqyxx(2);
            int rows = 0;
            bool status = false;

            object[] obj = new object[4];
            obj[0] = qymc;
            obj[1] = rows;
            obj[2] = status;
            obj[3] = DS_downloadData;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "yddj_download_DS_test", obj);
            ss = result.ToString();
            if (ss == common_app.get_suc)
            {

              
                try
                {
                    DS_downloadData = (DataSet)obj[3];
                    foreach (DataRow dr in DS_downloadData.Tables[0].Rows)
                    {

                        M_Order.add_time = DateTime.Now;
                        M_Order.category_id = int.Parse(dr[10].ToString());
                        M_Order.channel_id = int.Parse(dr[10].ToString());
                        M_Order.content = dr["content"].ToString();
                        M_Order.crs = int.Parse(dr["crs"].ToString());
                        M_Order.fjrx_id = int.Parse(dr["fjrx_id"].ToString());
                        M_Order.is_rz = int.Parse(dr["is_rz"].ToString());
                        M_Order.order_lsbh = dr["order_lsbh"].ToString();
                        M_Order.state = int.Parse(dr["state"].ToString());
                        M_Order.user_id = int.Parse(dr["user_id"].ToString());
                        M_Order.xhrs = int.Parse(dr["xhrs"].ToString());
                        M_Order.yd_ddsj = dr["yd_ddsj"].ToString();
                        M_Order.yd_endtime = Convert.ToDateTime(dr["yd_endtime"].ToString());
                        M_Order.yd_jg = Convert.ToDecimal(dr["yd_jg"].ToString());
                        M_Order.yd_js = int.Parse(dr["yd_js"].ToString());
                        M_Order.yd_name = dr["yd_name"].ToString();
                      
                        M_Order.yd_ts = Convert.ToDecimal(dr["yd_ts"].ToString());
                        M_Order.yd_statetime = DateTime.Now;
                        B_Order.Add(M_Order);
                        


                    }
                    dlsum = int.Parse(DS_downloadData.Tables[0].Rows.Count.ToString());//返回行数
                    return dlsum;

                }
                catch (Exception ee)
                {
                    errorInfo = ee.Message.ToString();
                    postion = "向本地Qskyd_mainrecord插入数据之后到修改远程服务器下载数据的过程之中";
                    Common.WriteLog(errorInfo, postion);
                }
          
            }
            return dlsum;
        }


    }
}
