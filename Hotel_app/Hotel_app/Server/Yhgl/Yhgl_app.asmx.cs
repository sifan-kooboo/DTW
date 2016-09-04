using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Hotel_app.Server.Yhgl;

namespace Hotel_app.Server.Yhgl
{
    /// <summary>
    /// Yhgl_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Yhgl_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "用于角色的增删改")]
        public string YHRoles_add_edit(string id, string yydh, string qymc, string R_lsbh, string R_RolesName, string R_bz,string R_ts, string add_edit_delete, string xxzs)
        {
            string s = Hotel_app.common_file.common_app.get_suc;
            Yhgl.YH_Roles YH_Roles_add_edit_new = new YH_Roles();
            s = YH_Roles_add_edit_new.YHRoles_add_edit(id, yydh, qymc, R_lsbh, R_RolesName, R_bz,R_ts, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于角色应用权限表的增删改")]
        public string YHRolesp_add_edit(string id, string yydh, string qymc, string R_lsbh, string R_RolesName, string p_lsbh,string A_Appdr,string A_AppName, string p_value, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_suc;
            Yhgl.YH_RolePermission YH_RolePermission_new = new YH_RolePermission();
            s = YH_RolePermission_new.YHRolesp_add_edit(id, yydh, qymc, R_lsbh, R_RolesName, p_lsbh,A_Appdr,A_AppName, p_value, add_edit_delete, xxzs);
            return s;
 
        }
        [WebMethod(Description = "用于用户信息的增删改")]
        public string YHUser_add_edit(string id, string yydh, string qymc, string yhbh, string yhxm, string yhmm, string R_lsbh, string R_RolesName,string yhbm, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_suc;
            Yhgl.YH_User YH_user_new = new YH_User();
            s = YH_user_new.YHUser_add_edit(id, yydh, qymc, yhbh, yhxm, yhmm, R_lsbh, R_RolesName,yhbm,add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于用户部门的增删改")]
        public string YH_bmsz_add_edit(string id, string yydh, string qymc, string zjm, string yhbm, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_suc;
            Yhgl.YH_bmsz YH_bmsz_new = new YH_bmsz();
            s = YH_bmsz_new.YH_bmsz_add_edit(id, yydh, qymc, zjm, yhbm, add_edit_delete, xxzs);
            return s;
        }
    }
}
