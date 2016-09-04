using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

namespace Hotel_app.common_file_server
{
    public class common_hyAction
    {
        //会员的动作（标识要发送什么短信）
        public static string hy_Action_djNew = "新增散客(会员)登记";
        public static string hy_Action_djxg = "散客(会员)登记修改";
        public static string hy_Action_hytf = "退房(会员)";

        public static string hy_Action_xydw_jftx = "会员验证成功";

        public static string hy_Action_ydNew = "新增散客(会员)预订";
        public static string hy_Action_ydxg = "散客(会员)预订修改";
        public static string hy_Action_yddel = "散客(会员)预订删除";
        public static string hy_Action_HyNew = "新增会员";


        public static string hy_Action_promoteType = "会员升级";
        public static string hy_Action_hyqr = "会员验证成功";





        //针对短信平台
        public static string hy_Action_dxqf = "号码短信群发";
        public static string hy_Action_dxqf_error = "无法发送";//如果出现这个错误,错误出在发送之前

    }
}
