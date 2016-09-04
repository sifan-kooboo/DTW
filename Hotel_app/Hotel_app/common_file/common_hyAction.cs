using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_app.common_file
{
    class common_hyAction
    {
        //会员的动作（标识要发送什么短信）
        public static string hy_Action_djNew = "新增散客(会员)登记";
        public static string hy_Action_djxg = "散客(会员)登记修改";
        public static string hy_Action_hytf = "退房(会员)";


        public static string hy_Action_ydNew = "新增散客(会员)预订";
        public static string hy_Action_ydxg = "散客(会员)预订修改";
        public static string hy_Action_yddel = "散客(会员)预订删除";


        public static string hy_Action_HyNew = "新增会员";
        public static string hy_Action_hyqr = "会员验证成功";


        //同服务端
        public static bool hygl_shqr_add(string yydh)
        {
            bool flage_hyrq_add = false;
            BLL.Qcounter B_qcounter_new = new Hotel_app.BLL.Qcounter();
            List<Model.Qcounter> list = new List<Model.Qcounter>();
            list = B_qcounter_new.GetModelList(" id>=0  and  yydh='" + yydh + "'");
            Model.Qcounter M_qcounter = null;
            if (list != null && list.Count >= 1)
            {
                flage_hyrq_add = bool.Parse(list[0].Hhygl_qyqr.ToString());
            }

            return flage_hyrq_add;
        }


        //针对短信平台
        public static string hy_Action_dxqf = "号码短信群发";
        public static string hy_Action_dxqf_error = "无法发送";//如果出现这个错误,错误出在发送之前
    }
}
