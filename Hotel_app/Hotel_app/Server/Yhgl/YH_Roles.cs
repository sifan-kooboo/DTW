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
    public class YH_Roles
    {
        
        	//RoleID,yydh,qymc,R_lsbh,R_RolesName,R_Bz,is_top,is_select
        public string YHRoles_add_edit(string id, string yydh, string qymc, string R_lsbh, string R_RolesName, string R_bz,string R_ts, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;

            BLL.YH_Roles B_YhRoles = new BLL.YH_Roles();
            Model.YH_Roles M_YhRoles = new Model.YH_Roles();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_YhRoles.yydh = yydh;
                M_YhRoles.qymc = qymc;
                M_YhRoles.R_lsbh = R_lsbh;
                M_YhRoles.R_RolesName = R_RolesName;
                M_YhRoles.R_Bz = R_bz;
                M_YhRoles.R_ts = int.Parse(R_ts);



                if (B_YhRoles.Add(M_YhRoles) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_YhRoles = B_YhRoles.GetModel(Convert.ToInt32(id));
                    M_YhRoles.R_Bz = R_bz;
                    M_YhRoles.R_lsbh = R_lsbh;
                    M_YhRoles.R_RolesName = R_RolesName;
                    M_YhRoles.R_ts = int.Parse(R_ts);
                    M_YhRoles.ID = Convert.ToInt32(id);
                    B_YhRoles.Update(M_YhRoles);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_YhRoles.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
