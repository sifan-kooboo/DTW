using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;

namespace Hotel_app.Server.Szwgl
{
    public static class common_zw
    {
        public static string zwcl_caiz = "拆账";
        public static string zwcl_bz = "补账";
        public static string zwcl_congz = "冲账";

        public static string jbjk_jb = "jb";//交班
        public static string jbjk_jk = "jb";//交款

        public static string zwzz_sk_tt = "单间-团队";
        public static string zwzz_sk_sk = "单间-单间";
        public static string zwzz_tt_sk = "团队-单间";
        public static string zwzz_tt_tt = "团队-团队";

        //从jjzwll里进入时有这几种状态
        public static string zwzz_jz_tt = "记账-团队";
        public static string zwzz_jz_sk = "记账-单间";

        public static string zwzz_gz_tt = "挂账-团队";
        public static string zwzz_gz_sk = "挂账-单间";

        public static string fwrx_abl = "按百分比率";
        public static string fwrx_sjje = "按实际金额";

        public static string dr_ff = "房费";
        public static string qtff = "其他费用";
        public static string dr_ds = "代收";
        public static string ff_kffy = "审核房费";
        //public static string ff_sqff = "审前房费";如果要分出单审的房费把这个启用，其余关闭

        public static string ff_jsqtfy = "加收全天房费";
        public static double ff_jsqtfy_sl = 1.0;
        public static string ff_jsbtfy = "加收半天房费";
        public static double ff_jsbtfy_sl = 0.5;
        public static string ff_jcfy = "加床房费";
        public static double ff_jcfy_sl = 0.5;
        public static string mx_xfxm_ff = "mx0000";//新增0502
        public static string jb_jk_jb = "jb";
        public static string jb_jk_jk = "jk";
        public static string gzpj_flage = "挂账批结";//这个只是用来标识是挂账批结的，不允许其撤销

        //注意这两个方法的不同,一个针对主单，一个针对账务的,意义不同
        //这里指jzzt获取协议号
        public static string GetxyhByxydw(string jzzt, string yydh)
        {
            if (jzzt.Trim() != "")
            {
                object xyh = DbHelperSQL.GetSingle("select top 1  xyh  from  Yxydw where  id>0  and xydw='" + jzzt + "'");
                if (xyh != null)
                {
                    return xyh.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        //通过主单获取xydw
        public static void GetxydwFromMainRecord(string lsbh, string jzbh, string yydh, string sk_tt, ref string xydw, ref string krly)
        {
            DataSet ds_temp = null;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            if (jzbh.Trim() != "")//以结账务
            {
                if (sk_tt == "sk")
                {
                    //从备份表里面找
                    ds_temp = B_common.GetList("select * from  Qskyd_mainrecord_bak", "  yydh='" + yydh + "'   and jzbh='" + jzbh + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        xydw = ds_temp.Tables[0].Rows[0]["xydw"].ToString();
                        krly = ds_temp.Tables[0].Rows[0]["krly"].ToString();
                    }
                }
                else if (sk_tt == "tt")
                {
                    //从备份表里面找
                    ds_temp = B_common.GetList("select * from  Qttyd_mainrecord_bak", "  yydh='" + yydh + "'  and  jzbh='" + jzbh + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        xydw = ds_temp.Tables[0].Rows[0]["xydw"].ToString();
                        krly = ds_temp.Tables[0].Rows[0]["krly"].ToString();
                    }
                    else
                    {
                        ds_temp = B_common.GetList(" select * from  Qttyd_mainrecord_bak ", "  yydh='" + yydh + "'  and  ddbh=(select ddbh  from  Qskyd_mainrecord_bak  where   jzbh='" + jzbh + "')  ");
                        {
                            xydw = ds_temp.Tables[0].Rows[0]["xydw"].ToString();
                            krly = ds_temp.Tables[0].Rows[0]["krly"].ToString();
                        }
                    }

                }
            }
            if (jzbh.Trim() == "")//未结账务
            {
                if (sk_tt == "sk")
                {
                    //从主单里面找
                    ds_temp = B_common.GetList("select * from  Qskyd_mainrecord", "  yydh='" + yydh + "' and  lsbh='" + lsbh + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        xydw = ds_temp.Tables[0].Rows[0]["xydw"].ToString();
                        krly = ds_temp.Tables[0].Rows[0]["krly"].ToString();
                    }
                }

                if (sk_tt == "tt")
                {

                    //从主单里面找
                    ds_temp = B_common.GetList("select * from  Qttyd_mainrecord", "  yydh='" + yydh + "' and  lsbh='" + lsbh + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        xydw = ds_temp.Tables[0].Rows[0]["xydw"].ToString();
                        krly = ds_temp.Tables[0].Rows[0]["krly"].ToString();
                    }
                    else
                    {
                        ds_temp = B_common.GetList(" select * from  Qttyd_mainrecord_bak ", "  yydh='" + yydh + "'  and  ddbh=(select ddbh  from  Qskyd_mainrecord_bak  where  lsbh='" + lsbh + "'  and  jzbh='" + jzbh + "')  ");
                        {
                            xydw = ds_temp.Tables[0].Rows[0]["xydw"].ToString();
                            krly = ds_temp.Tables[0].Rows[0]["krly"].ToString();
                        }
                    }
                }
            }
        }


        //20110611  更新(sjzzd与bak增加三个字段)
        //显示联账客人，联账房号，到达时间
        //返回结账主单的相关信息,联账客人要都写入到krxm_lz，fjbh_lz
        public static  void GetJZinfo(ref string krxm_lz, ref string fjbh_lz, ref  string ddsj, string lsbh, string yydh, string sktt)
        {
            krxm_lz = "";
            fjbh_lz = "";
            ddsj = "";
            BLL.Common B_common = new Hotel_app.BLL.Common();
            if (sktt == "sk")
            {
                DataSet ds_temp1 = B_common.GetList(" select * from Qskyd_fjrb ", "id>=0  and lsbh='" + lsbh + "'  and yydh='" + yydh + "'  order by  fjbh ");
                if (ds_temp1 != null && ds_temp1.Tables[0].Rows.Count > 0)
                {
                    krxm_lz = ds_temp1.Tables[0].Rows[0]["krxm"].ToString();
                    fjbh_lz = ds_temp1.Tables[0].Rows[0]["fjbh"].ToString();
                    ddsj = ds_temp1.Tables[0].Rows[0]["ddsj"].ToString();
                }
                DataSet ds_temp0 = B_common.GetList(" select * from Flfsz  ", " id>=0  and  lfbh in ( select lfbh from  Flfsz where lsbh='" + lsbh + "' and yydh='" + yydh + "'  and  shlz='1'  and fjbh!=''  )  and lsbh!='" + lsbh + "' ");
                if (ds_temp0 != null && ds_temp0.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_temp0.Tables[0].Rows.Count; i++)
                    {

                        krxm_lz += "|" + ds_temp0.Tables[0].Rows[i]["krxm"].ToString();
                        fjbh_lz += "|" + ds_temp0.Tables[0].Rows[i]["fjbh"].ToString();
                        //取当前lsbh的到达时间为到达时间
                    }
                }
            }
            if (sktt == "tt")
            {
                krxm_lz = "";
                fjbh_lz = "";
                ddsj = "";
                DataSet ds_temp1 = B_common.GetList(" select * from Qttyd_mainrecord ", "id>=0  and lsbh='" + lsbh + "'  and yydh='" + yydh + "'");
                if (ds_temp1 != null && ds_temp1.Tables[0].Rows.Count > 0)
                {
                    krxm_lz = ds_temp1.Tables[0].Rows[0]["krxm"].ToString();
                    ddsj = ds_temp1.Tables[0].Rows[0]["ddsj"].ToString();
                }
            }
        }

    }    
}
