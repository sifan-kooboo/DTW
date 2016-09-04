using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Data;
namespace Hotel_app.common_file
{
    public static class common_hy
    {
        public static string hyrx_yk = "银卡";
        public static string hyrx_zjk = "准金卡";
        public static string hyrx_jk = "金卡";
        public static string hyrx_zbjk = "准铂金卡";
        public static string hyrx_bjk = "铂金卡";
        public static string hyrx_zzsk = "准钻石卡";
        public static string hyrx_zsk = "钻石卡";
        public static string hyrx_krly = "正常";
        public static Hhygl.Hhygl_add_edit Hhygl_add_edit_new;
        public static Hhygl.Hhygl_hyhk Hhygl_hyhk_new;
        public static Hhygl.Hhygl_browse Hhygl_browse_new;
        public static Fmain Fmain_new;
        public static string hymm = md5("123456", 32);//会员密码
       


        public static void Form_hygl_add_edit(string id, string ad_edit, Fmain MdiFmain)
        {
            if (Hhygl_add_edit_new == null || Hhygl_add_edit_new.IsDisposed)
            {
                Hhygl_add_edit_new = new Hotel_app.Hhygl.Hhygl_add_edit();
                Hhygl_add_edit_new.MdiParent = MdiFmain;
                Hhygl_add_edit_new.Show();
            }
            Hhygl_add_edit_new.Activate();
            Hhygl_add_edit_new.Hhygl_1(id, ad_edit);
        }

      

        public static void Form_hygl_browse(Fmain MdiFmain)
        {
            if (Hhygl_browse_new == null || Hhygl_browse_new.IsDisposed)
            {
                Hhygl_browse_new = new Hotel_app.Hhygl.Hhygl_browse(MdiFmain);
                Hhygl_browse_new.MdiParent = MdiFmain;
                Hhygl_browse_new.Show();
            }
            Hhygl_browse_new.Activate();
            Hhygl_browse_new.Show();
        }

        public static void Form_hygl_browse_new()
        {
            if (Hhygl_browse_new == null || Hhygl_browse_new.IsDisposed)
            {
                Hhygl_browse_new = new Hotel_app.Hhygl.Hhygl_browse();
                Hhygl_browse_new.MdiParent = Fmain_new;
                Hhygl_browse_new.Show();
            }
            Hhygl_browse_new.Activate();
            Hhygl_browse_new.Show();
        }

        public static void Form_hygl_browse()
        {
            if (Hhygl_browse_new == null || Hhygl_browse_new.IsDisposed)
            {
                Hhygl_browse_new = new Hotel_app.Hhygl.Hhygl_browse(Fmain_new);
                Hhygl_browse_new.MdiParent = Fmain_new;
                Hhygl_browse_new.Show();
            }
            Hhygl_browse_new.Activate();
            Hhygl_browse_new.Show();
        }


        public static void Bindhyrx(ComboBox cB_hyrx)  //会员类型邦定
        {
            cB_hyrx.Items.Clear();
            Model.Hhyjb M_hyjb = new Model.Hhyjb();
            BLL.Hhyjb B_hyjb = new BLL.Hhyjb();
            List<Model.Hhyjb> list = B_hyjb.GetModelList("");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cB_hyrx.Items.Add(list[i].hyrx.ToString());
                }
            }
        }



        //计算会员总的积分
        public static int SumJF(string strhykh)
        {
            int zongjifen = GetzJiFen(strhykh);  //总积分
            int duijifen = GetDhJiFen(strhykh); //已兑换积分
            int nowjifen = zongjifen - duijifen;                                //目前积分
            return nowjifen;

        }
        #region ///添加的一些方法 2012年5月23日
        /// <summary>
        /// 获取会员总积分
        /// </summary>
        /// <param name="hyxm"></param>
        /// <param name="hykh"></param>
        /// <returns></returns>
        public static int GetzJiFen(string hykh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(hyjf) from Hhyjf_xfjl");
            strSql.Append(" where  hykh=@hykh");
            SqlParameter[] parameters = {
					
                    new SqlParameter("@hykh", SqlDbType.NVarChar,200)};
    
            parameters[0].Value = hykh;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            else
            {
                //return Convert.ToInt32(obj.ToString());
                return decimalToInt(obj);
            }
        }
        /// <summary>
        /// 获取会员兑换过的积分
        /// </summary>
        /// <param name="hyxm"></param>
        /// <param name="hykh"></param>
        /// <returns></returns>
        public static int GetDhJiFen(string hykh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(dfjf) from Hhyjf_df");
            strSql.Append(" where hykh=@hykh ");
            SqlParameter[] parameters = {
					
                    new SqlParameter("@hykh", SqlDbType.NVarChar,200)};
     
            parameters[0].Value = hykh;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            else
            {
                //return Convert.ToInt32(obj.ToString());
                return decimalToInt(obj);
            }
        }
        #endregion
        //会员的删除操作  主单id，调用的URL
        public static string Delete_Hygl(string id, string url)
        {
            string s = common_app.get_failure;
            //执行删除
            string[] args = new string[35];
            args[0] = id.ToString();
            args[1] = "";
            args[2] = "";
            args[3] = "";
            args[4] = "";
            args[5] = "";
            args[6] = "";
            args[7] = "";
            args[8] = "";
            args[9] = "";
            args[10] = "";
            args[11] = "";
            args[12] = "";
            args[13] = "";
            args[14] = "";
            args[15] = "";
            args[16] = "";
            args[17] = "";
            args[18] = "";
            args[19] = "";
            args[20] = "";
            args[21] = "";
            args[22] = "";
            args[23] = "";
            args[24] = "";
            args[25] = "";
            args[26] = "";
            args[27] = "";
            args[28] = "";
            args[29] ="";
            args[30] = "";
            args[31] = ""; args[32] = "";
            args[33] = common_file.common_app.get_delete;
            args[34] = "";

            Hotel_app.Server.Hhygl.Hhygl_add_edit Hhygl_add_edit_sevices = new Hotel_app.Server.Hhygl.Hhygl_add_edit();
            string result=Hhygl_add_edit_sevices.Hhygl_add_edit_delete_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(),
               args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString(), args[30].ToString(), args[31].ToString(),
                args[32].ToString(), args[33].ToString(), args[34].ToString());


           // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhygl_add_edit_delete_app", args);
            if (result!=null&&result.ToString() == common_app.get_suc)
            { s = common_app.get_suc; }
            return s;
        }
        //2012-05-17日新的验证方法
        //1.查看有没有手机号/卡号+证件号相同的用户
        public static int RegisterCheck(string hykh, string zjhm)
        {
            int num = 0;
            string sql = string.Format("select count(1) from Hhygl where 1=1 ");
            string sql_hykh = string.Format(" and hykh_bz='{0}' and zjhm='{1}' ", hykh, zjhm);
            string sql_hykh_01 = string.Format(" and hykh_bz='{0}' ", hykh);
            string sql_hysj = string.Format(" and krsj='{0}' ", hykh);
            object obj_hykh = DbHelperSQL.GetSingle(sql + sql_hykh);
            object obj_hykh_01 = DbHelperSQL.GetSingle(sql + sql_hykh_01);
            object obj_hysj = DbHelperSQL.GetSingle(sql + sql_hysj);
            if (int.Parse(obj_hykh.ToString()) > 0)
            {
                num = 1;

            }
            else if (int.Parse(obj_hykh_01.ToString()) > 0)
            {
                num = 1;
            }
            else if (int.Parse(obj_hysj.ToString()) > 0)
            {
                num = 1;
            }
            else
            {
                num = 0;
            }

            return num;
        }

        //2012-05-17日新的验证方法
        //1.查看有没有手机号/卡号+证件号相同的用户
        public static int RegisterCheck(string hykh, string zjhm, string hysj, int Hid)
        {
            int num = 0;
            string sql = string.Format("select count(1) from Hhygl where id<>'" + Hid + "' ");
            string sql_hykh = string.Format(" and hykh_bz='{0}' and zjhm='{1}' ", hykh, zjhm);//会员卡号和证件号
            string sql_hykh_01 = string.Format(" and hykh_bz='{0}' ", hysj);//会员卡号
            string sql_hysj = string.Format(" and krsj='{0}' ", hysj);   //手机
            string sql_hysj_02 = string.Format(" and krsj='{0}' and  zjhm='{1}'", hysj, zjhm); //手机和证件号
            string sql_zjhm_03 = string.Format(" and zjhm='{0}'", zjhm);//证件号码
            object obj_hykh = DbHelperSQL.GetSingle(sql + sql_hykh);
            object obj_hykh_01 = DbHelperSQL.GetSingle(sql + sql_hykh_01);
            object obj_hykh_02 = DbHelperSQL.GetSingle(sql + sql_hysj_02);
            object obj_hysj = DbHelperSQL.GetSingle(sql + sql_hysj);
            object obj_zjhm_03 = DbHelperSQL.GetSingle(sql + sql_zjhm_03);
            if (int.Parse(obj_hykh.ToString()) > 0)
            {
                num = 1;

            }
            else if (int.Parse(obj_hykh_01.ToString()) > 0)
            {
                num = 1;
            }
            else if (int.Parse(obj_hysj.ToString()) > 0)
            {
                num = 1;
            }
            else if (int.Parse(obj_hykh_02.ToString()) > 0)
            {
                num = 1;
            }
            else if (int.Parse(obj_zjhm_03.ToString()) > 0)
            {
                num = 1;
            }
            else
            {
                num = 0;
            }

            return num;





        }



        #region "MD5加密"
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {
            string strEncrypt = string.Empty;
            if (code == 16)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
            }

            if (code == 32)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }

            return strEncrypt;
        }
        #endregion


        #region "decimalToInt"
        /// <summary>
        /// decimalToInt 把有小数点3位数的 decimal 转换成Int
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int decimalToInt(object num)
        {
            int i = 0;
            if ((Object.Equals(num, null)) || (Object.Equals(num, System.DBNull.Value)))
            {
                i = 0;
            }
            else
            {
                i = Convert.ToInt32(num);
            }
            return i;
        }
        public static string decimalToStr(object num)
        {
            string s = "0";
            if ((Object.Equals(num, null)) || (Object.Equals(num, System.DBNull.Value)))
            {
                s = "0";
            }
            else
            {
                s = Convert.ToInt32(num).ToString();
                if (s == "0")
                {
                    s = "0";
                }
            }
            return s;
        }
        #endregion

        //根据hykh_bz读取hykh
        public static string GetHygl(string hykh_bz)
        {
            string get_value = "";
            BLL.Hhygl B_Hhygl = new BLL.Hhygl();
            Model.Hhygl M_Hhygl = new Model.Hhygl();
            DataSet ds = B_Hhygl.GetList("hykh_bz='" + hykh_bz + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {

                get_value = ds.Tables[0].Rows[0]["parent_hykh"].ToString();

            }

            return get_value;

        }


    }
    


}
