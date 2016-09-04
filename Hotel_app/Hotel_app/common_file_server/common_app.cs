using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace Hotel_app.common_file_server
{
    public static class common_app
    {
        public static string cssj = "1800-01-01";
        public static string yydh = Get_QyInfo("yydh");
        public static string qymc = Get_QyInfo("qymc");
        public static string qybh = Get_QyInfo("qybh");
        public static string yydh_select = " and yydh='" + common_file.common_app.yydh + "' ";

        public static string xxzs = "zs";//学习版或正式版
        public static string xxzs_xxvalue = "xx";//学习版
        public static string xxzs_zsvalue = "zs";//正式版

        public static string fy_qh = "全含";//房费全含
        public static string fy_bqh = "不全含";//房费不全含
        public static string fjbm_bm = "保密";//房价保密
        public static string fjbm_bbm = "不保密";//房价不保密

        public static string main_sec_main = "main";//主要；
        public static string main_sec_sec = "sec";//次要；

        public static string syzd = "大堂收银台";
        public static string yxzj_sfz = "身份证";
        public static string krgj_zg = "中国";
        //public static bool shlz = false;//对应Qcounter里的shlz这个字段
        public static bool shlz = bool.Parse(common_file.Common_initalSystem.ReadNameValueSectionValue("qyinfo", "shlz"));
        
        public static string krrx_htk = "回头客";
        public static string krrx_hmd = "黑名单";

        public static string krly_hy = "会员";
        public static string hyrx_yk = "银卡";
        public static decimal hyrx_yk_xs = 1;
        public static string hyrx_jk = "金卡";
        public static string hyykTojk = "升级金卡";
        public static string hyykTojkjfsx = "20000";//银卡升级金卡的积分限额
        public static string message_title = "系统工程师陈志永提醒您！";//信息题目;

        public static DateTime czsj = Convert.ToDateTime("1949-10-01");//获取最新的操作时间，锁屏时或许会用到。
        public static DateTime old_czsj = Convert.ToDateTime("1949-10-01");//获取前次的操作时间，锁屏时或许会用到。
        public static void get_czsj()
        {
            common_app.old_czsj = czsj;
            common_app.czsj = DateTime.Now;

        }
        public static string get_suc = "success";//成功的值；
        public static string get_failure = "failure";//成功的值；
        public static bool is_contain_wx =bool.Parse(common_file.Common_initalSystem.ReadNameValueSectionValue("qyinfo", "is_contain_wx"));
        public static string ydzx_flage = "预订中心";


        public static string get_add = "add";//增加的值；
        public static string get_edit = "edit";//编辑的值；
        public static string get_delete = "delete";//删除的值；
        public static string get_his = "his";//获得历史记录,只能查看,不能修改；

        public static string chinese_add = "新增";//增加的值；
        public static string chinese_edit = "修改";//编辑的值；
        public static string chinese_delete = "删除";//删除的值；
        public static string chinese_sz = "结账";//结账的值；
        public static string chinese_gz = "挂账";//挂账的值；
        public static string chinese_jz = "记账";//记账的值；
        public static string chinese_gzzsz = "挂账";//挂账转结账的值；
        public static string chinese_jzzsz = "记账";//记账转结账的值；
        public static string pljz_flage = "批量结账";
        public static string fkdr = "付款";
        public static string dj_ysk = "预收款项";
        public static string dj_pzsk = "平账收款";//
        public static string dj_ysq = "预授权";

        //2012-12-13 lwj新增
        public static string is_sh = "已审核";
        public static string is_wsh = "未审核";
        public static string zb_zt_zj = "增加";
        public static string zb_zt_kj = "扣减";

        public static string hykh_rx = "银卡";
        public static string Get_QyInfo(string info_item)
        {
            string info = "";
            BLL.Xqyxx B_Xqyxx = new Hotel_app.BLL.Xqyxx();
            List<Model.Xqyxx> lists = B_Xqyxx.GetModelList("");
            if (lists.Count > 0)
            {
                Model.Xqyxx M_Xqyxx = lists[0];
                if (info_item == "qymc")
                {
                    info = M_Xqyxx.qymc;
                }
                if (info_item == "yydh")
                { info = M_Xqyxx.yydh; }
                if (info_item == "qybh")
                { info = M_Xqyxx.qybh; }
            }
            else
            {
                info = "000000";
            }
            return info;
        }

       //数值校验
        public static decimal ValideStringCheck(string tempStr,decimal  defaultValue)
        {
            decimal retureData = defaultValue;
            try
            {
                retureData = decimal.Parse(tempStr);
            }
            catch
            {
                retureData = defaultValue;
            }
            return retureData;
        }
    }
}
