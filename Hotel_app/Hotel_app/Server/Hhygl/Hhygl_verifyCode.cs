using System;
using System.Data;
using System.Configuration;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Diagnostics;
namespace Hotel_app.Server.Hhygl
{
    public class Hhygl_verifyCode
    {
        BLL.Common B_common = new Hotel_app.BLL.Common();
        DataSet ds = new DataSet();
        //生成验证码
        //先写入本地表
        //然后把本地的验证码发送给会员
        public string generateVerifyCode(string phoneNo, string krxm, string Sendtime, string yydh, string qymc, string xxzs)
        {
            string result = common_file.common_app.get_failure;
            if (String.IsNullOrEmpty(phoneNo) || String.IsNullOrEmpty(yydh) || String.IsNullOrEmpty(qymc) || String.IsNullOrEmpty(xxzs)||!System.Text.RegularExpressions.Regex.IsMatch(phoneNo, @"^[1]+[3,4,5,6,8]+\d{9}"))
            { return result; }
            else
            {
                //生成验证码
                string local_VerifyCode = common_file.common_generateVerifyCode.CreateCode();
                if (String.IsNullOrEmpty(local_VerifyCode))
                { return result; }
                else
                {
                    //防止重新发送时原来有，先删除以前的
                    DbHelperSQL.ExecuteSql(" delete from  Hhyyz  where  yydh='" + yydh + "' and  hysj='" + phoneNo + "'");
                    //写入本地表
                    if (DbHelperSQL.ExecuteSql("insert into  Hhyyz(yydh,qymc,krxm,hysj,yzm,yzdate,yzzt)  values('" + yydh + "','" + qymc + "','" + krxm + "','" + phoneNo + "','" + local_VerifyCode + "','','1')") > 0)
                    {
                        //本地验证码生成成功后,向客户发送短信验证

                        Hotel_app.cn.b2m.eucp.sdkhttp.SDKService msm = new Hotel_app.cn.b2m.eucp.sdkhttp.SDKService();
                        string serialNo = ConfigurationManager.AppSettings["msm_serialNo"].ToString();
                        string msm_key = ConfigurationManager.AppSettings["msm_key"].ToString();
                        string[] phoneStr = phoneNo.Split(new char[] { '|' });
                        int resultCode = msm.sendSMS(serialNo, msm_key, "", phoneStr, "您的验证码为:" + local_VerifyCode + "请输入完成验证[" + qymc + "]", "", "GBK", 5);
                        if (resultCode <= 0)
                        {
                            result = common_file.common_app.get_suc;
                        }
                    }
                }
            }
            return result;
        }
        //对比验证码
        public string CheckVerifyCode(string phoneNo, string local_VerifyCode, string yydh, string qymc, string bz, string add_edit_delete, string xxzs)
        {
            string result = common_file.common_app.get_failure;
            if (String.IsNullOrEmpty(phoneNo) || String.IsNullOrEmpty(yydh) || String.IsNullOrEmpty(qymc))
            { return result; }
            else
            {
                BLL.Hhyyz B_Hhyyz_new = new Hotel_app.BLL.Hhyyz();
                List<Model.Hhyyz> list = new List<Hotel_app.Model.Hhyyz>();
                list = B_Hhyyz_new.GetModelList("  id>=0  and  hysj='" + phoneNo + "'  and   yzm='" + local_VerifyCode + "' and yydh='" + yydh + "'");
                if (list != null && list.Count > 0)
                {
                    result = common_file.common_app.get_suc;
                }
            }
            return result;
        }
        //发送短信
        //当预订和登记时，ddsj和lksj才有效，其它时留空就行
        //hykh,xf只有在退房时才有用到
        //fx房型只有在删除时才有用
        public string Hhygl_SendMsm(string phoneNo, string msm_title, string yydh, string qymc, string hyAction, string timeNow, string ddsj, string lksj, string fx, string hykh, string xf, string xxzs)
        {
            string result = common_file.common_app.get_failure;




            if (String.IsNullOrEmpty(phoneNo) || String.IsNullOrEmpty(hyAction) || String.IsNullOrEmpty(xxzs) || System.Text.RegularExpressions.Regex.IsMatch(phoneNo, @"^[1]+[3,4,5,6,8]+\d{9}"))
            {
                return result;
            }
            else
            {


                try
                {


                    Hotel_app.cn.b2m.eucp.sdkhttp.SDKService msm = new Hotel_app.cn.b2m.eucp.sdkhttp.SDKService();

                    string serialNo = ConfigurationManager.AppSettings["msm_serialNo"].ToString();
                    string msm_key = ConfigurationManager.AppSettings["msm_key"].ToString();
                    string[] phoneStr = phoneNo.Split(new char[] { '|' });

                    string sms_temp_0 = "";//短消息的内容
                    string sms_temp_1 = "";//短消息的内容
                    string sms_temp_2 = "";//短消息的内容
                    string sms_temp_3 = "";//短消息的内容
                    string sms_temp_4 = "";//短消息的内容

                    int tc_time = 0;//延迟发送时间,以分钟计算
                    string time_SendMsm = "";//为空时保持空，表示马上发送
                    if (!timeNow.ToString().Equals(""))
                    {
                        time_SendMsm = timeNow;
                    }
                    Model.hhyyz_dx M_Hhhyzz_dx = new Hotel_app.Model.hhyyz_dx();
                    List<Model.hhyyz_dx> list_0 = new List<Hotel_app.Model.hhyyz_dx>();
                    BLL.hhyyz_dx B_hhyzz_dx = new Hotel_app.BLL.hhyyz_dx();
                    list_0 = B_hhyzz_dx.GetModelList(" yydh='" + yydh + "'  and   hy_action_flage='" + hyAction + "'");
                    string content = "";//最后发送的消息
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    if (list_0 != null && list_0.Count > 0)
                    {
                        M_Hhhyzz_dx = list_0[0];
                        tc_time = M_Hhhyzz_dx.dxycsj;
                        if (!time_SendMsm.Equals(""))
                        {
                            time_SendMsm = (DateTime.Parse(time_SendMsm)).AddMinutes(tc_time).ToString();//发送时间
                        }
                        sms_temp_0 = M_Hhhyzz_dx.msm_content;
                        sms_temp_1 = M_Hhhyzz_dx.msm_content_2;
                        sms_temp_2 = M_Hhhyzz_dx.msm_content_3;
                        sms_temp_3 = M_Hhhyzz_dx.msm_content_4;
                        sms_temp_4 = M_Hhhyzz_dx.msm_content_5;


                        // sb.Append(M_Hhhyzz_dx.msm_content);
                        if (hyAction == common_file.common_hyAction.hy_Action_djNew)
                        {
                            sb.Append(sms_temp_0);
                            sb.Append("[" + qymc + "]");
                            //sb.Append(sms_temp_1);
                            //sb.Append(":");
                            // sb.Append(ddsj + "到" + lksj);
                            sb.Append(sms_temp_2);
                            sb.Append(sms_temp_3);
                            sb.Append(sms_temp_4);
                        }//登记新增
                        if (hyAction == common_file.common_hyAction.hy_Action_djxg)
                        {
                            sb.Append(sms_temp_0);
                            sb.Append("[" + qymc + "]");
                            sb.Append(sms_temp_1);
                            //sb.Append("您当前的入住时间为:");
                            //sb.Append(ddsj + "到" + lksj);
                            sb.Append(sms_temp_2);
                            sb.Append(sms_temp_3);
                            sb.Append(sms_temp_4);
                        }//登记修改
                        if (hyAction == common_file.common_hyAction.hy_Action_HyNew)
                        {
                            sb.Append(sms_temp_0);
                            sb.Append("卡号" + phoneNo);
                            sb.Append(",密码123456,");
                            sb.Append(sms_temp_1);
                            sb.Append(sms_temp_2);
                            sb.Append(sms_temp_3);
                            sb.Append(sms_temp_4);
                        }//新增会员
                        if (hyAction == common_file.common_hyAction.hy_Action_hytf)
                        {
                            sb.Append(sms_temp_0);
                            sb.Append(sms_temp_1);
                            sb.Append(xf + ",");
                            sb.Append(sms_temp_2);
                            sb.Append(msm_title);//总积分存在这里，传值的时候
                            sb.Append(sms_temp_3);
                            sb.Append(sms_temp_4);
                        }//会员退房
                        if (hyAction == common_file.common_hyAction.hy_Action_ydNew)
                        {
                            sb.Append(sms_temp_0);
                            sb.Append(",");
                            sb.Append(sms_temp_1);
                            //sb.Append(":");
                            //sb.Append(ddsj + "到" + lksj);
                            sb.Append(sms_temp_2);
                            sb.Append(sms_temp_3);
                            sb.Append(sms_temp_4);
                        }//预订新增
                        if (hyAction == common_file.common_hyAction.hy_Action_ydxg)
                        {
                            sb.Append(sms_temp_0);
                            sb.Append(",");
                            sb.Append(msm_title);
                            sb.Append(sms_temp_1);
                            sb.Append(sms_temp_2);
                            sb.Append(sms_temp_3);
                            sb.Append(sms_temp_4);
                        }//预订修改
                        if (hyAction == common_file.common_hyAction.hy_Action_yddel)
                        {
                            sb.Append(sms_temp_0);
                            sb.Append("(" + qymc + ")");
                            sb.Append(sms_temp_1);
                            sb.Append("您当前预订单的入住时间为");
                            sb.Append(ddsj + "－" + lksj);
                            //sb.Append("  fx ");
                            sb.Append(sms_temp_2);
                            sb.Append(sms_temp_3);
                            sb.Append(sms_temp_4);
                        }//预订删除

                        //会员升级
                        if (hyAction == common_file_server.common_hyAction.hy_Action_promoteType)
                        {
                            sb.Append(sms_temp_0);
                            sb.Append("(" + qymc + ")");
                            sb.Append("您升级后的积分余额为");
                            sb.Append(msm_title + "。");
                            sb.Append(sms_temp_2);
                            sb.Append(sms_temp_3);
                            sb.Append(sms_temp_4);
                        }
                        if (hyAction == common_file.common_hyAction.hy_Action_hyqr)
                        {
                            sb.Append(sms_temp_0);
                            sb.Append(sms_temp_1);
                            sb.Append(sms_temp_2);
                            sb.Append(sms_temp_3);
                            sb.Append(sms_temp_4);
                        }


                    }
                    content = sb.ToString();
                    if (!time_SendMsm.Equals(""))
                    { time_SendMsm = DateTime.Parse(time_SendMsm.ToString()).ToString("yyyyMMddHHmmss"); }
                    if (!content.Equals(""))
                    {






                        object resultCode = msm.sendSMS(serialNo, msm_key, time_SendMsm.ToString(), phoneStr, content, "", "GBK", 5);
                        if (resultCode != null && int.Parse(resultCode.ToString()) <= 0)
                        {
                            result = common_file.common_app.get_suc;
                        }





                    }

                }
                catch
                {

                    //return result;
                }

            }
            return result;
        }
        internal string[] Hhygl_SendMsm_temporay(string phoneNo, string krxm, string content, string yydh, string qymc, string hyAction, string xxzs)
        {
            string[] retureResult = new string[2];
            retureResult[0] = common_file.common_app.get_failure;//指示是否发送成功
            retureResult[1] = common_file.common_hyAction.hy_Action_dxqf_error;//存储发送的代码返回值

            if (!content.Equals("") && !phoneNo.Equals("") && !krxm.Equals(""))
            {
                Hotel_app.cn.b2m.eucp.sdkhttp.SDKService msm = new Hotel_app.cn.b2m.eucp.sdkhttp.SDKService();
                string serialNo = ConfigurationManager.AppSettings["msm_serialNo"].ToString();
                string msm_key = ConfigurationManager.AppSettings["msm_key"].ToString();
                string[] phoneStr = new string[] { phoneNo };
                object resultCode = msm.sendSMS(serialNo, msm_key, "", phoneStr, content, "", "GBK", 5);
                if (resultCode != null && int.Parse(resultCode.ToString()) <= 0)
                {
                    retureResult[1] = resultCode.ToString();
                    retureResult[0] = common_file.common_app.get_suc;
                }
                else if (resultCode != null && int.Parse(resultCode.ToString()) > 0)
                {
                    retureResult[1] = resultCode.ToString();
                }
                else
                {
                    retureResult[1] = common_file.common_hyAction.hy_Action_dxqf_error;
                }
            }
            return retureResult;

        }
    }
}
