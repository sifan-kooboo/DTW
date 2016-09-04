using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using System.Data;
namespace Hotel_app.common_file
{
    public class common_yhuser
    {
       
        public static string GetUser_mm(string mm)
        {
            string usercs_mm =mm; //用户初始密码
            return usercs_mm;
            //string PassWord_value = DbHelperSQL.md5("123456", 16);//用户密码
 
        }

        //根据用户编号查询相关信息
        public static string GetUser(string userNo, int typeid)
        {

            Model.YH_user M_YH_user = new Model.YH_user();
            BLL.YH_user B_YH_user = new BLL.YH_user();
            string struserinfo = "";
            M_YH_user = B_YH_user.GetModelList("yhbh='" + userNo + "'" + common_app.yydh_select + "")[0];
            if (typeid == 1)
            {
                struserinfo = M_YH_user.yhmm;
 
            }
            else if (typeid == 2)
            {
                struserinfo = M_YH_user.yhxm;
            }
            else if (typeid == 3)
            {
                struserinfo = M_YH_user.R_lsbh;

            }
            else
            {
                struserinfo = M_YH_user.RoleName;
 
            }
            return struserinfo;
        }
        //邦定用户ComboBox列表
        public static void Bindyh(ComboBox cB_hyrx)  //会员类型邦定
        {
            cB_hyrx.Items.Clear();
            Model.YH_user M_YH_user = new Model.YH_user();
            BLL.YH_user B_YH_user = new BLL.YH_user();
            List<Model.YH_user> list = B_YH_user.GetModelList("");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cB_hyrx.Items.Add(list[i].yhxm.ToString());
               
                    
                }
            }
        }
        //验证用户用户名和密码
        public static int YHLogin(string YHbh, string YHpwd_Value)
        {
            int num = 0;
            string StrSql = "select * from YH_user where yhbh='" + YHbh + "' and yhmm='" + YHpwd_Value + "'" + common_app.yydh_select + "";
            object obj_yh = DbHelperSQL.GetSingle(StrSql);
            if (obj_yh != null)
            {
                num = 1;
 
            }
            return num;
 
        }

        


    }
}
