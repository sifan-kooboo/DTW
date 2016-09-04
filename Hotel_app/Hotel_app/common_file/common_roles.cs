using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Hotel_app.common_file
{
    public class common_roles
    {
        public static string connectionString = PubConstant.ConnectionString;
        //添加新权用到的
        public static bool Add(string yydh, string qymc, string appdr, string p_lsbh, string appname)
        {
            SqlParameter[] parameters ={
                    new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,100),
					new SqlParameter("@p_lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@A_Appdr", SqlDbType.VarChar,50),
					new SqlParameter("@A_AppName", SqlDbType.VarChar,50)};
            parameters[0].Value = yydh;
            parameters[1].Value = qymc;
            parameters[2].Value = p_lsbh;
            parameters[3].Value = appdr;
            parameters[4].Value = appname;
            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "YH_Applications_add", parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //修改权限
        public static void Update_Role(int id, bool p_value)
        {

            DbHelperSQLP helper = new DbHelperSQLP();
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@P_Value", SqlDbType.Bit,1)
			};
            parameters[0].Value = id;
            parameters[1].Value = p_value;
            helper.RunProcedure("YH_RolePermission_Update", parameters);

        }

        //添加用户角色
        public static bool YH_Roles_Add(string yydh, string qymc, string R_lsbh, string R_rolesname, string R_Bz, int R_ts)
        {
            SqlParameter[] parameters ={
                    new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,100),
					new SqlParameter("@R_lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@R_rolesname", SqlDbType.VarChar,50),
					new SqlParameter("@R_Bz", SqlDbType.VarChar,100),
                    new SqlParameter("@R_ts",SqlDbType.Int,4)
           };
            parameters[0].Value = yydh;
            parameters[1].Value = qymc;
            parameters[2].Value = R_lsbh;
            parameters[3].Value = R_rolesname;
            parameters[4].Value = R_Bz;
            parameters[5].Value = R_ts;
            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "YH_Roles_add", parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //复制权限用到的存储过程
        public static bool Copy_Roles(string yydh, string qymc, string R_lsbh, string R_lsbh_new, string R_rolesname)
        {

            SqlParameter[] parameters ={
                    new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,100),
					new SqlParameter("@R_lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@R_lsbh_new", SqlDbType.VarChar,50),
					new SqlParameter("@R_rolesname", SqlDbType.VarChar,50)};
            parameters[0].Value = yydh;
            parameters[1].Value = qymc;
            parameters[2].Value = R_lsbh;
            parameters[3].Value = R_lsbh_new;
            parameters[4].Value = R_rolesname;
            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Copy_YH_Roles", parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //根据P_lsbh编号读取相关信息
        public static string GetYH_Applications(string p_lsbh, int type)
        {
            string strRoles = "";
            Model.YH_Applications M_YH_Applications = new Model.YH_Applications();
            BLL.YH_Applications B_YH_Applications = new BLL.YH_Applications();
            M_YH_Applications = B_YH_Applications.GetModelList("p_lsbh='" + p_lsbh + "'")[0];
            if (M_YH_Applications != null)
            {
                if (type == 1)
                {
                    strRoles = M_YH_Applications.A_Appdr;

                }
                else if (type == 2)
                {
                    strRoles = M_YH_Applications.A_AppName;
                }
                else
                {
                    strRoles = M_YH_Applications.yydh;
                }
            }
            return strRoles;

        }


        //初始化菜单全部为不可用
        //初始化一级菜单
        public static void InitMenuItem(MenuStrip menuStrip1)
        {
            string sql = "select * from YH_Applications where a_appdr=a_appname "; //一级菜单，其父菜单id为0 
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = dr[3].ToString(); //menuname 
                item.Text = dr[4].ToString();

                menuStrip1.Items[item.Name].Enabled = false;
                InitSubMenuItem(menuStrip1.Items[item.Name]);//初始化一级菜单的所有子菜单 
            }


        }
        //初始化一级菜单的所有子菜单 

        public static void InitSubMenuItem(ToolStripItem item)
        {
            string mname = item.Name;
            string strappdr = item.Text;
            //string strappdr = common_file.common_roles.GetYH_Applications(mname, 1);
            //common_file.common_app.Message_box_show(common_file.common_app.message_title, "" + mname + "");
            //return;
            ToolStripMenuItem pItem = (ToolStripMenuItem)item;
            //根据父菜单项加载子菜单 
            string sql = "select * from YH_Applications where A_appdr='" + strappdr + "' and p_lsbh<>'" + mname + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();  //子菜单
                    subItem.Name = dr[3].ToString();
                    subItem.Text = dr[4].ToString();
                    try
                    {
                        pItem.DropDownItems[subItem.Name].Enabled = false;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }





        // 根据用户在用户权限表中的权限动态的设置能使用的菜单项。    
        //对一级菜单进行权限设置 
        public static void SetMenuItemByRole(MenuStrip menuStrip1)
        {
            string sql = "select* from YH_RolePermission where r_lsbh='" + common_app.user_type + "' and a_appdr=a_appname";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = dr[5].ToString();//一级菜单的menuname 

                menuStrip1.Items[item.Name].Enabled = Convert.ToBoolean(dr[8].ToString());//各一级菜单是主菜单menuStrip2集合的项 
                SetSubMenuItemByRole(menuStrip1.Items[item.Name]);//将一级菜单对应主菜单menuStrip2集合的项传给子菜单设置函数 
            }
        }

        //对一级菜单的所有子菜单进行设置 
        public static void SetSubMenuItemByRole(ToolStripItem item)
        {
            string mname = item.Name;
            string strappdr2 = item.Text;
            // string strappdr2 = common_file.common_roles.GetYH_Applications(mname, 1);
            ToolStripMenuItem pItem = (ToolStripMenuItem)item;
            //根据父菜单项加载子菜单 
            string sql = "select * from YH_RolePermission where A_appdr='" + strappdr2 + "' and p_lsbh<>'" + mname + "' and R_lsbh='" + common_app.user_type + "'";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();
                    subItem.Name = dr[5].ToString();
                    try
                    {
                        pItem.DropDownItems[subItem.Name].Enabled = Convert.ToBoolean(dr[8].ToString());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            else
            {
            }
        }

        public static void set_menu_is_visible(MenuStrip mS_temp, string user_type)
        {
            common_file.common_app.get_czsj();
            for (int i_0 = 0; i_0 < mS_temp.Items.Count; i_0++)
            {
                if (mS_temp.Items[i_0].Name.ToString() != "MB_about")
                {
                    ToolStripItem item = mS_temp.Items[i_0];
                    sub_menu_ddi_is_visible(item, user_type);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        public static void sub_menu_ddi_is_visible(ToolStripItem item, string user_type)
        {
            common_file.common_app.get_czsj();
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp;
            ToolStripMenuItem pItem = (ToolStripMenuItem)item;
            for (int j_0 = 0; j_0 < pItem.DropDownItems.Count; j_0++)
            {

                DS_temp = B_Common.GetList("select * from YH_RolePermission", " p_lsbh='" + pItem.DropDownItems[j_0].Name.ToString() + "' and p_value=1 and R_lsbh='" + user_type + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    pItem.DropDownItems[j_0].Enabled = true;

                }
                else
                {
                    pItem.DropDownItems[j_0].Enabled = false;

                }
                if (pItem.DropDownItems[j_0].GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    sub_menu_ddi_is_visible(pItem.DropDownItems[j_0], user_type);
                }

            }
            Cursor.Current = Cursors.Default;
        }

        public static bool get_user_qx(string yh_qx, string user_type)
        {
            common_file.common_app.get_czsj();
            int i_0 = 1;
            bool get_result = false;
            string sql_s = "";
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from YH_lo_ex_trace_current", " yydh='" + common_app.yydh + "' and yhbh='" + common_app.userNo + "'");
            //if (DS_temp != null)
            //    if (DS_temp.Tables[0].Rows.Count > 1)
            //    {
            //        if (common_app.message_box_show_select(common_app.message_title, "出现重复登录的用户，如果不把原来的用户注销掉将不能继续操作，是否确定要注销原来的用户？") == true)
            //        {

            //            sql_s = "delete from YH_lo_ex_trace_current where yydh='" + common_app.yydh + "' and yhbh='" + common_app.userNo + "' and login_time<>'" + common_app.login_time.ToString() + "'";
            //            B_Common.ExecuteSql(sql_s);

            //        }
            //        else
            //        {
            //            i_0 = 2;
            //        }

            //    }
            //DS_temp = B_Common.GetList("select * from YH_lo_ex_trace_current", " yydh='" + common_app.yydh + "' and yhbh='" + common_app.userNo + "'    and login_time='" + common_app.login_time.ToString() + "'");
            //if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            //{ }
            //else
            //{
            //    common_app.Message_box_show(common_app.message_title, "对不起，目前用户已经被最新的同工号的用户重新登录了，已经不能再继续操作了！请重新登录用户！");
            //    i_0 = 2;
            //}
            if (i_0 == 1)
            {
                DS_temp = B_Common.GetList("select * from YH_RolePermission", " p_lsbh='" + yh_qx + "' and p_value=1 and R_lsbh='" + user_type + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    get_result = true;
                }
                else
                {
                    common_app.Message_box_show(common_app.message_title, "对不起，您暂时不能进行此操作,如有需要,请联系系统管理员！");
                }
            }
            Cursor.Current = Cursors.Default;
            return get_result;
        }


        public static bool get_user_qx(string yh_qx, string user_type, bool showMsg)
        {
            common_file.common_app.get_czsj();
            int i_0 = 1;
            bool get_result = false;
            string sql_s = "";
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from YH_lo_ex_trace_current", " yydh='" + common_app.yydh + "' and yhbh='" + common_app.userNo + "'");
            //if (DS_temp != null)
            //    if (DS_temp.Tables[0].Rows.Count > 1)
            //    {
            //        if (common_app.message_box_show_select(common_app.message_title, "出现重复登录的用户，如果不把原来的用户注销掉将不能继续操作，是否确定要注销原来的用户？") == true)
            //        {

            //            sql_s = "delete from YH_lo_ex_trace_current where yydh='" + common_app.yydh + "' and yhbh='" + common_app.userNo + "' and login_time<>'" + common_app.login_time.ToString() + "'";
            //            B_Common.ExecuteSql(sql_s);

            //        }
            //        else
            //        {
            //            i_0 = 2;
            //        }

            //    }
            //DS_temp = B_Common.GetList("select * from YH_lo_ex_trace_current", " yydh='" + common_app.yydh + "' and yhbh='" + common_app.userNo + "'    and login_time='" + common_app.login_time.ToString() + "'");
            //if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            //{ }
            //else
            //{
            //    if (showMsg == true)
            //    {
            //        common_app.Message_box_show(common_app.message_title, "对不起，目前用户已经被最新的同工号的用户重新登录了，已经不能再继续操作了！请重新登录用户！");
            //    }
            //    i_0 = 2;
            //}
            if (i_0 == 1)
            {
                DS_temp = B_Common.GetList("select * from YH_RolePermission", " p_lsbh='" + yh_qx + "' and p_value=1 and R_lsbh='" + user_type + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    get_result = true;
                }
                else
                {
                    if (showMsg == true)
                    {
                        common_app.Message_box_show(common_app.message_title, "对不起，您没有此操作权限！");
                    }
                }
            }
            return get_result;
            Cursor.Current = Cursors.Default;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<Hotel_app.Model.YH_Applications> DataTableToList(DataTable dt)
        {
            List<Hotel_app.Model.YH_Applications> modelList = new List<Hotel_app.Model.YH_Applications>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Hotel_app.Model.YH_Applications model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Hotel_app.Model.YH_Applications();
                    if (dt.Rows[n]["A_Appdr"] != null && dt.Rows[n]["A_Appdr"].ToString() != "")
                    {
                        model.A_Appdr = dt.Rows[n]["A_Appdr"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

    }
}
