using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace jdgl_res_head_app.common_file
{
   public class common_app
    {
        public static string xxzs_xxvalue = "xx";//学习版
        public static string xxzs_zsvalue = "zs";//正式版

        public static string Inital = "inital";
       public static string url = common_file.Common.ReadXML("add", "url");
       public static string xydwsc = common_file.Common.ReadXML("add", "xydw_sc");//读取协议单位是否上传
       public static string xydwxz = common_file.Common.ReadXML("add", "xydw_xz");//读取协议单位是否下载
       public static string yydh = Common.Getqyxx(1);
       public static string yydh_select = " and yydh='" + common_file.common_app.yydh + "' ";
       public static string qymc = Common.Getqyxx(2);
       public static string qybh = Common.Getqyxx(3);
       public static string hyjfrx = Common.Getqyxx(4);

        public static string get_suc = "success";//成功的值；
        public static string get_failure = "failure";//成功的值；

        public static string get_add = "add";//增加的值；
        public static string get_edit = "edit";//编辑的值；



       public static string ddyy = "预订中心";
        public static string yddj_yd = "预订";
       public static string sktt_sk = "散客";
       public static string sktt_tt = "团体";
       public static string cznr_add = "新增";
       public static string czy = "网上预定中心";

        public static string yddj_qryd = "确认预订";
        public static string yddj_dj = "登记";
        public static string yddj_ydzdj = "预订转登记";
        public static string yddj_qx = "取消";
        public static string yddj_wd = "未到";
        public static string ddly = "旅游";

        public static string Yxydw_xydw = "协议单位";
        public static string Yxydw_gzdw = "挂账单位";

        public static int x()//鼠标位置X
        {
            return Control.MousePosition.X;
        }
        public static int y()//鼠标位置Y
        {
            return Control.MousePosition.Y;
        }
        public static string message_title = "系统工程师陈志永提醒您！";//信息题目;
        //自定义一个message_box.show
        public static bool message_box_show_select(string F_title, string content)
        {
            jdgl_res_head_app.common_file.Message_box F_Message_box = new Message_box(F_title, content, 2);
            if (F_Message_box.ShowDialog() == DialogResult.Yes)
            {
                return true;
            }
            return false;
            F_Message_box.Dispose();

        }

        public static void Message_box_show(string F_title, string content)
        {
            jdgl_res_head_app.common_file.Message_box F_Message_box = new Message_box(F_title, content, 1);
            F_Message_box.ShowDialog();
        }
        //向listBox中增加信息
        public static void AddMsg(ListBox listBox1a, string msgStr)
        {
             listBox1a.Items.Add(msgStr);

        }

    }
}
