using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Yhgl
{
    public class YH_User
    {
        //ID,yydh,qymc,yhbh,yhxm,yhmm,R_lsbh,RoleName,is_top,is_select
        public string YHUser_add_edit(string id, string yydh, string qymc,string yhbh,string yhxm,string yhmm,string R_lsbh, string R_RolesName,string yhbm,string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;

            BLL.YH_user B_Yhuser = new BLL.YH_user();
            Model.YH_user M_Yhuser = new Model.YH_user();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Yhuser.yydh = yydh;
                M_Yhuser.qymc = qymc;
                M_Yhuser.yhbh = yhbh;
                M_Yhuser.yhxm = yhxm;
                M_Yhuser.R_lsbh = R_lsbh;
                M_Yhuser.RoleName = R_RolesName;
                M_Yhuser.yhmm =yhmm;
                M_Yhuser.yhbm = yhbm;
         



                if (B_Yhuser.Add(M_Yhuser) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Yhuser = B_Yhuser.GetModel(Convert.ToInt32(id));
                    M_Yhuser.RoleName = R_RolesName;
                    M_Yhuser.R_lsbh = R_lsbh;
                    M_Yhuser.yhxm = yhxm;
                    M_Yhuser.yhbm = yhbm;
                    //M_Yhuser.yhmm = yhmm;
                    M_Yhuser.ID = Convert.ToInt32(id);
                    B_Yhuser.Update(M_Yhuser);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Yhuser.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
