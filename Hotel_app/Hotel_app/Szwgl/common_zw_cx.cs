using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Hotel_app.Szwgl
{
    //此类处理所有账务中涉及到的撤销操作
    //是否能撤销，房间是否有冲突产生，都是在前台来判断的，可以撤销时才会调用后台的撤销过程
    class common_zw_cx
    {

        BLL.Common B_Common = new Hotel_app.BLL.Common();
        string result_all = "";

        private string CheckFjStatus(string fjbh, string fjrb,out  string  Result)
        {
            string  fjCanUse = common_file.common_app.get_failure; BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            Result = "";
            DataSet Ds_temp = B_Ffjzt.GetList("id>=0 and yydh='" + common_file.common_app.yydh + "'  and fjbh='" + fjbh + "'  and fjrb='" + fjrb + "'");
            if (Ds_temp != null && Ds_temp.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Ds_temp.Tables[0].Rows.Count; i++)
                {
                    fjCanUse = common_file.common_app.get_failure;
                    string zyzt = Ds_temp.Tables[0].Rows[i]["zyzt"].ToString();
                    if (zyzt == common_file.common_fjzt.gjf || zyzt == common_file.common_fjzt.zf)//为赃房或者干净房的时候是可以撤销的
                    { fjCanUse = common_file.common_app.get_suc; continue; }
                    else
                    {
                        Result +="["+ Ds_temp.Tables[0].Rows[i]["fjrb"].ToString() + "-" + Ds_temp.Tables[0].Rows[i]["fjbh"].ToString() + "当前的占用状态为:" + Ds_temp.Tables[0].Rows[i]["zyzt"].ToString() + "]  ";
                    }
                }
            }
            else
            { Result +="["+ fjrb + "-" + fjbh + "-" + "没有找到此房间,系统无法撤销 ]"; }
            result_all+= Result;
            return fjCanUse;
        }
        //returnInfo指的是：返回的信息
        public string  CheckCx(string lsbh,string jzbh,string czzt,string sk_tt,string fjbh,out string  Info)
        {
            string s = common_file.common_app.get_failure;
            result_all = "";
            Info = "";
            DataSet ds_temp_0 = null;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            if (lsbh != "" && jzbh != "" && czzt != "")
            {
                if (czzt == common_file.common_jzzt.czzt_bfsz)
                {
                    ds_temp_0 = B_common.GetList("select * from Qskyd_mainrecord", "   lsbh='" + lsbh + "' and   yydh='" + common_file.common_app.yydh + "'");
                    if (ds_temp_0 != null&&ds_temp_0.Tables[0].Rows.Count>0)
                    { s = common_file.common_app.get_suc; }
                    else
                    {
                        ds_temp_0 = B_Common.GetList(" SELECT * FROM Qttyd_mainrecord", " lsbh='" + lsbh + "' and   yydh='" + common_file.common_app.yydh + "'");
                        if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                        { s = common_file.common_app.get_suc; }
                        else
                        {
                            Info = "找不到主单信息，无法撤销";
                        }
                    }
                }

                if (czzt == common_file.common_jzzt.czzt_gzfj || czzt == common_file.common_jzzt.czzt_jzfj)
                {
                    DataSet ds_temp_9 = B_Common.GetList("  select * from  Sjzzd_bak ", "   jzbh_new='" + jzbh + "'  and yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "'");
                    if (ds_temp_9 != null && ds_temp_9.Tables[0].Rows.Count > 0)
                    {
                        string  czzt_temp=(czzt == common_file.common_jzzt.czzt_gzfj)?common_file.common_jzzt.czzt_gz: common_file.common_jzzt.czzt_jz;
                        DataSet ds_temp_10 = B_common.GetList(" select  *  from Sjzzd  ", "  lsbh='" + lsbh + "'  and yydh='" + common_file.common_app.yydh + "'  and czzt='" + czzt_temp + "'");
                        if (ds_temp_10 != null && ds_temp_10.Tables[0].Rows.Count > 0)
                        {
                            s = common_file.common_app.get_suc;
                        }
                        else
                        {
                            Info += "原始帐单以经全部结帐，无法撤销";
                        }
                    }
                    else
                    {
                        Info += "找不到分结的原始帐单，无法撤销";
                    }
                }


                if (czzt == common_file.common_jzzt.czzt_sz || czzt == common_file.common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_jzzgz || czzt == common_file.common_jzzt.czzt_gzzjz || czzt == common_file.common_jzzt.czzt_gz)
                {
                    if (sk_tt == "sk")
                    {
                        //判断是否有联帐
                        DataSet  ds_temp_1=null;
                        ds_temp_1 = B_common.GetList(" select  lsbh from Flfsz_bak ", "  Shlz=1  and   lfbh in (select lfbh from Flfsz_bak where lsbh='" + lsbh + "'  and yydh='" + common_file.common_app.yydh + "')");
                        if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
                        {
                            for (int i_0 = 0; i_0 < ds_temp_1.Tables[0].Rows.Count; i_0++)
                            {
                                s = common_file.common_app.get_failure;
                                string lsbh_0 = ds_temp_1.Tables[0].Rows[i_0]["lsbh"].ToString();
                               // ds_temp_0 = B_common.GetList("select * from Sjzzd", " id>=0 and  yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh_0 + "'");
                               // if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 1)
                               // {
                                   // Info += "有部分结帐存在,无法直接撤销这笔帐";
                                //}
                                //else
                               // {
                                    //检查房态
                                    DataSet ds_temp_3 = B_Common.GetList("select * from Qskyd_fjrb_bak ", " id>=0 and  yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh_0 + "'");
                                    if (ds_temp_3 != null && ds_temp_3.Tables[0].Rows.Count > 0)
                                    {
                                        string fjrb = ds_temp_3.Tables[0].Rows[0]["fjrb"].ToString();
                                        string fjbh_0 = ds_temp_3.Tables[0].Rows[0]["fjbh"].ToString();
                                        if (CheckFjStatus(fjbh_0, fjrb, out  Info) == common_file.common_app.get_suc)
                                        {
                                            s = common_file.common_app.get_suc;
                                        }
                                    }
                               // }
                            }
                            if (s == common_file.common_app.get_suc)
                            {
                                s = common_file.common_app.get_suc;
                            }
                        }
                        else
                        {
                            //ds_temp_0 = B_common.GetList("select * from Sjzzd", " id>=0 and  yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "'");
                            //if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 1)
                            //{
                            //    Info += "有部分结帐存在,请先撤销部分结帐,再撤销当前这笔帐";
                            //}
                            //else
                            //{
                                //直接判断房态
                                DataSet ds_temp_3 = B_Common.GetList("select * from Qskyd_fjrb_bak ", " id>=0 and  yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "'");
                                if (ds_temp_3 != null && ds_temp_3.Tables[0].Rows.Count > 0)
                                {
                                    string fjrb = ds_temp_3.Tables[0].Rows[0]["fjrb"].ToString();
                                    if (fjbh.Trim() == "")//如果以前没有房号,直接可以撤消
                                    {
                                        s = common_file.common_app.get_suc; 
                                    }
                                    else if (CheckFjStatus(fjbh, fjrb, out  Info) == common_file.common_app.get_suc)
                                    {
                                        s = common_file.common_app.get_suc;
                                    }
                                }
                            //}
                        }
                    }


                    if(sk_tt=="tt")
                    {
                         //首先要检查成员单结的情况
                        if (fjbh.Trim() == "")
                        {
                            DataSet Ds_temp4 = B_common.GetList("select distinct lsbh  from Qskyd_mainrecord_bak", "  ddbh  in (select ddbh from Qttyd_mainrecord_bak  where lsbh='" + lsbh + "' and yydh='" + common_file.common_app.yydh + "')");
                            if (Ds_temp4 != null && Ds_temp4.Tables[0].Rows.Count > 0)
                            {
                                s = common_file.common_app.get_suc;

                                // 检查是否有成员单结
                                //for (int i_2 = 0; i_2 < Ds_temp4.Tables[0].Rows.Count; i_2++)
                                //{
                                //    s = common_file.common_app.get_failure;
                                //    string lsbh_2 = Ds_temp4.Tables[0].Rows[i_2]["lsbh"].ToString();
                                //    DataSet ds_temp_5 = B_common.GetList(" select * from Sjzzd ", " id>=0 and  yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh_2 + "'");
                                //    if (ds_temp_5 != null && ds_temp_5.Tables[0].Rows.Count > 0)
                                //    {
                                //        result_all += "[该团下房间编号为:" + ds_temp_5.Tables[0].Rows[0]["fjbh"].ToString() + "有单独结帐,该团帐务无法撤销]";
                                //    }
                                //    else
                                //    {
                                //        s = common_file.common_app.get_suc;
                                //    }
                                //}

                                if (s == common_file.common_app.get_suc && result_all.Trim() == "")
                                {
                                   s=common_file.common_app.get_failure;
                                    {
                                        for (int i_3 = 0; i_3 < Ds_temp4.Tables[0].Rows.Count; i_3++)
                                        {
                                            s = common_file.common_app.get_failure;
                                            string lsbh_3 = Ds_temp4.Tables[0].Rows[i_3]["lsbh"].ToString();
                                                //判断房态
                                            DataSet ds_temp_6 = B_Common.GetList("select * from Qskyd_fjrb_bak ", " id>=0 and  yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh_3 + "'");
                                            if (ds_temp_6 != null && ds_temp_6.Tables[0].Rows.Count > 0)
                                            {
                                                string fjrb = ds_temp_6.Tables[0].Rows[0]["fjrb"].ToString();
                                                string fjbh_1 = ds_temp_6.Tables[0].Rows[0]["fjbh"].ToString();
                                                if (CheckFjStatus(fjbh_1, fjrb, out  Info) == common_file.common_app.get_suc)
                                                {
                                                    s = common_file.common_app.get_suc;
                                                }
                                            }
                                        }
                                    }
                                }
                                //if (s == common_file.common_app.get_suc&&Info.Trim()=="")
                                    if (s == common_file.common_app.get_suc &&result_all.Trim() == "")
                                {
                                    s = common_file.common_app.get_suc;
                                }
                            }
                            else//说明该团下没有成员入住过
                            {
                                Info += ""; s = common_file.common_app.get_suc;
                            }
                        }
                        else if (fjbh != "")//团体的成员
                        {
                            //首先判断其是否有分结存在
                            //DataSet ds_temp8 = B_common.GetList("select * from Sjzzd", " id>=0 and  yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "'");
                            //if (ds_temp8 != null && ds_temp8.Tables[0].Rows.Count > 1)
                            //{
                            //    Info += "有部分结帐存在,请先撤销部分结帐,再撤销当前这笔帐";
                            //}
                            //else
                            {
                                //判断其属于的团体当前是否存在
                                DataSet ds_temp_7 = B_common.GetList(" select * from Qttyd_mainrecord ", "  ddbh=(select ddbh from Qskyd_mainrecord_bak  where yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "' and main_sec='"+common_file.common_app.main_sec_main+"')");
                                if (ds_temp_7 != null && ds_temp_7.Tables[0].Rows.Count > 0)
                                {
                                    //判断房间否可用
                                    DataSet ds_temp_8 = B_Common.GetList("select * from Qskyd_fjrb_bak ", " id>=0 and  yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "'");
                                    if (ds_temp_8 != null && ds_temp_8.Tables[0].Rows.Count > 0)
                                    {
                                        string fjrb = ds_temp_8.Tables[0].Rows[0]["fjrb"].ToString();
                                        if (CheckFjStatus(fjbh, fjrb, out  Info) == common_file.common_app.get_suc)
                                        {
                                            s = common_file.common_app.get_suc;
                                        }
                                    }
                                    else
                                    {
                                        Info += "当前房间被占用，不能撤销";
                                    }
                                }
                                else
                                {
                                    Info += "当前房间所属的团体主单以经不存在，不能撤销";
                                }
                            }
                        }
                    }
                }

                if (czzt == common_file.common_jzzt.czzt_gzzsz || czzt == common_file.common_jzzt.czzt_jzzsz)
                {
                     //判断其是否有分结
                    DataSet ds_temp_11 = B_Common.GetList("select * from Sjzzd ", "  id>=0 and yydh='" + common_file.common_app.yydh + "' and lsbh='" + lsbh + "'");
                    //if (ds_temp_11 != null && ds_temp_11.Tables[0].Rows.Count > 1)
                   // {
                        //Info += "当前帐务有分结过,不能撤销";
                   // }
                   // else
                   // {
                        if (ds_temp_11 != null && ds_temp_11.Tables[0].Rows[0]["bz"].ToString() == common_zw.gzpj_flage)
                        {
                            Info += "对不起,此账务为挂账批结的账务，不允许撤销";
                        }
                        else
                        {
                            s = common_file.common_app.get_suc;
                        }
                  //  }
                }
            }
            Info += result_all;
            return s;
        }
    }
}
