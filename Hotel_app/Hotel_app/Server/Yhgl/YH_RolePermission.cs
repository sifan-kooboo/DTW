using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace Hotel_app.Server.Yhgl
{
    public class YH_RolePermission
    {
        //ID,yydh,qymc,R_lsbh,R_RolesName,p_lsbh,A_AppName,P_Value,is_top,is_select
        public string YHRolesp_add_edit(string id, string yydh, string qymc, string R_lsbh, string R_RolesName, string p_lsbh,string A_Appdr,string A_AppName,string p_value, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;

            BLL.YH_RolePermission B_YhRolesp = new BLL.YH_RolePermission();
            Model.YH_RolePermission M_YhRolesp = new Model.YH_RolePermission();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                //string strsql = "delete from YH_RolePermission where r_lsbh='" + R_lsbh + "' and yydh='"+yydh+"'";
                //DbHelperSQL.ExecuteSql(strsql);

                M_YhRolesp.yydh = yydh;
                M_YhRolesp.qymc = qymc;
                M_YhRolesp.R_lsbh = R_lsbh;
                M_YhRolesp.R_RolesName = R_RolesName;
                M_YhRolesp.p_lsbh = p_lsbh;
                M_YhRolesp.A_AppName = A_AppName;
                M_YhRolesp.A_Appdr = A_Appdr;
                M_YhRolesp.P_Value = Convert.ToBoolean(p_value);




                if (B_YhRolesp.Add(M_YhRolesp) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_YhRolesp = B_YhRolesp.GetModel(Convert.ToInt32(id));
                    M_YhRolesp.P_Value = Convert.ToBoolean(p_value);
                    M_YhRolesp.p_lsbh = p_lsbh;
                    M_YhRolesp.A_AppName = A_AppName;
                    M_YhRolesp.R_lsbh = R_lsbh;
                    M_YhRolesp.R_RolesName = R_RolesName;
                    M_YhRolesp.A_Appdr = A_Appdr;
                    M_YhRolesp.ID = Convert.ToInt32(id);
                    B_YhRolesp.Update(M_YhRolesp);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_YhRolesp.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
