using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;

namespace Hotel_app.common_file
{
    public static class common_app
    {

        public static int x()//鼠标位置X
        {
            return Control.MousePosition.X;
        }
        public static int y()//鼠标位置Y
        {
            return Control.MousePosition.Y;
        }

        public static string yydh = get_qyxx_result("yydh", "ytjm005");
        public static string qymc = get_qyxx_result("qymc", "怡庭嘉湖酒店");
        public static string qybh =get_qyxx_result("qybh", "YTJH");
        public static string hyjfrx = get_qyxx_result("hyjfrx", "夏商旅游");
        public static string SoftName = "摩通";
        public static string softVerSion = "1.0.0.5";
        public static string yydh_select = " and yydh='" + common_file.common_app.yydh + "' ";
        public static DateTime login_time = DateTime.Parse("1800-01-01 01:00:01");
        public static string lo_ex_lo = "登录";
        public static string lo_ex_qf = "切换";
        public static string lo_ex_ex = "退出";
        public static string xxzs = "xx";//学习版或正式版

        public static string xxzs_zs = "zs";//学习版或正式版
        public static string xxzs_xx = "xx";//学习版或正式版
        public static string xxzs_xxvalue = "xx";//学习版
        public static string xxzs_zsvalue = "zs";//正式版

        public static string message_title = "系统工程师提醒您！";//信息题目;

        public static string service_url = Common_initalSystem.ReadNameValueSectionValue("qyinfo", "webServer");//"http://localhost:1659/";
        //public static string service_url = Common_initalSystem.ReadXML("add","webServer");

        public static string user_type = "administrator";
        public static string superUser = "administrator";//配置超级管理员
        public static string userNo = "xs001";
        public static string czy = "SB";//用这个来标识用户（不是唯一）
        public static string czy_GUID = "";//用这个来做帐务的唯一用户标识
        public static int user_ts = 7;//用户查询的最多天数

        public static bool flag_mulit_select = false;


        public static string syzd = "大堂收银台";
        public static string yxzj_sfz = "身份证";
        public static string krgj_zg = "中国";
        public static string krrx_htk = "回头客";
        public static string krrx_hmd = "黑名单";
        public static string krrx_pt = "普通";
        public static string krly_hy = "会员";


        public static string fy_qh = "全含";//房费全含
        public static string fy_bqh = "不全含";//房费不全含

        public static string fjbm_bm = "保密";//房价保密
        public static string fjbm_bbm = "不保密";//房价不保密


        //
        public static string is_sh = "已审核";
        public static string is_wsh = "未审核";
        public static string zb_zt_zj = "增加";
        public static string zb_zt_kj = "扣减";

        //是否启用会员短信提醒
        public static bool enable_hy_msm_notice = true;



        //public static bool shlz = false;//对应Qcounter里的shlz这个字段,判断是否要马上联房的时候,自动就联账了.
        public static bool shlz = bool.Parse(Common_initalSystem.ReadNameValueSectionValue("qyinfo", "shlz"));// false;//对应Qcounter里的shlz这个字段



        //房态是否要自动刷新 <!-- 房态是否要自动刷新,配合数据库里的Qcounter 的 ft_auto_refresh一起使用 -->
        public static bool ft_sh_ztsx = bool.Parse(Common_initalSystem.ReadNameValueSectionValue("qyinfo", "ft_sh_ztsx"));// 



        //网上预订中心的单据是否要弹出
        public static bool Qskyd_www_open = bool.Parse(Common_initalSystem.ReadNameValueSectionValue("qyinfo", "Qskyd_www_open"));// 
        
        
        
        //用于会员验证的新加字段
        public static int VerifyCode_length = 0;
        public static bool enable_checkMember = bool.Parse(Common_initalSystem.ReadNameValueSectionValue("qyinfo", "enable_checkMember"));// 




        public static string cssj = "1800-01-01";
        public static DateTime czsj = Convert.ToDateTime("1949-10-01");//获取最新的操作时间，锁屏时或许会用到。
        public static DateTime old_czsj = Convert.ToDateTime("1949-10-01");//获取前次的操作时间，锁屏时或许会用到。
        public static void get_czsj()
        {
            Cursor.Current = Cursors.WaitCursor;
            common_app.old_czsj = czsj;
            common_app.czsj = DateTime.Now;

        }
        public static string get_suc = "success";//成功的值；
        public static string get_failure = "failure";//成功的值；

        public static string get_add = "add";//增加的值；
        public static string get_edit = "edit";//编辑的值；
        public static string get_delete = "delete";//删除的值；
        public static string get_his = "his";//获得历史记录,只能查看,不能修改；

        public static string chinese_add = "新增";//增加的值；
        public static string chinese_edit = "修改";//编辑的值；
        public static string chinese_delete = "删除";//删除的值；
        public static string chinese_his = "历史";//删除的值；

        public static string main_sec_main = "main";//主要；
        public static string main_sec_sec = "sec";//次要；

        public static string shqh_qh = "全含";//房费全含；
        public static string shqh_bqh = "不全含";//房费不全含；

        public static string ICOPath = Application.StartupPath+"\\image\\NewsIco\\";  //图片文件或者ico文件的相对路径

        public static string fkdr = "付款";
        public static string dj_ysk = "预收款项";
        public static string dj_pzsk = "平账收款";//
       // public static string dj_pzzq = "平帐找钱";//
        public static string dj_ysq = "预授权";
        public static string czy_bc = "早班";  //操作员班次
        public static string ydzx_flag = "网站预订";

        public static string yddj_type_personal = "personal";//选房间类别时预订登记是散客
        public static string yddj_type_group = "group";//选房间类别时预订登记是团体会议
        public static bool is_contain_wx = false;//////TRUE可用（在预订时有时可用），FALSE不可用。

        #region update2013-12-20 防止在fjrb表中没有配置房型房价而导致界面出错的静态值 
        public static string li_fjjg_dispalyText = "当前房型房价未知";
        public static string pljz_flage = "批量结账";
        #endregion

        //动态生成调用图片的全路径
        public  static   string BtnBgImgFilePath(string fileName)
        {
            return ICOPath + fileName;
        }


        //自定义一个message_box.show
        public static bool message_box_show_select(string F_title, string content)
        {
            Hotel_app.common_file.Message_box F_Message_box = new Message_box(F_title, content, 2);
            F_Message_box.TopMost = true;
            if (F_Message_box.ShowDialog() == DialogResult.Yes)
            {
                return true;
            }
            return false;

        }

        public static void Message_box_show(string F_title, string content)
        {
            Hotel_app.common_file.Message_box F_Message_box = new Message_box(F_title, content, 1);
            F_Message_box.TopMost = true;
            F_Message_box.ShowDialog();
        }



        public static void Num_KeyPress(object sender, KeyPressEventArgs e)
        {
            //阻止从键盘输入键
            e.Handled = true;
            //当输入为0-9的数字、小数点、回车、负数符号和退格键时不阻止
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.' || e.KeyChar == 13 || e.KeyChar == 45 || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        public static void return_KeyPress(object sender, KeyPressEventArgs e)
        {
            //阻止从键盘输入键
            e.Handled = true;
            if (e.KeyChar == 13 || e.KeyChar == 45 || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }


        //判断输入框是否为空
        public static bool get_judge_void(TextBox TB_ls, string judge_type, string massage_content)
        {

            BLL.Common B_Common_temp = new Hotel_app.BLL.Common();

            DataSet DS_temp_0 = B_Common_temp.GetList("select id from X_judge_void", "judge_type='" + judge_type + "' and judge_value=1 and yydh='" + common_file.common_app.yydh + "'");

            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (TB_ls.Text.Trim() != "")
                {
                    return true; 
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, massage_content);
                    TB_ls.Focus();
                    DS_temp_0.Dispose();
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        //判断是否记录里面有否重复的字段
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="object_name">字段名</param>
        /// <param name="massage_content">提示信息</param>
        /// <param name="input_content">输入框内容</param>
        /// <param name="judge_add_edit">新增或修改</param>
        /// <param name="id_temp">所选择字段的ID</param>
        /// <returns></returns>
        public static int get_judge_repeat(string table_name, string object_name, string massage_content, string input_content, string judge_add_edit, string id_temp)
        {
            int judge_save = 3;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select count(id) as sl from " + table_name, object_name + "='" + input_content + "'" + common_file.common_app.yydh_select + "");

            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {

                if (Convert.ToDecimal(DS_temp.Tables[0].Rows[0]["sl"].ToString()) > 0)
                {
                    judge_save = 4;
                    if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        DS_temp = B_Common.GetList("select id from " + table_name, object_name + "='" + input_content + "'" + common_file.common_app.yydh_select + "");
                        if (DS_temp.Tables[0].Rows[0]["id"].ToString() == id_temp)
                        {
                            judge_save = 3;
                        }

                    }
                    if (judge_save == 4)
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, massage_content);
                }

            }
            DS_temp.Dispose();
            return judge_save;
            //if (judge_save == 3) return true;
            //else return false;

        }

        public static bool CheckTime(string timeFormer, string timeLater)
        {
            bool flage = false;
            DateTime dt_former = Convert.ToDateTime(timeFormer);
            DateTime dt_Later = Convert.ToDateTime(timeLater);
            if (dt_Later > dt_former)
            {
                flage = true;
            }
            else
            {
                Message_box_show("警告", "离开时间不能早于到达时间,请正确选择离开时间");
            }
            return flage;
        }

        public static void display_new_commonform_1(string judge_type_0, TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = x();
            X_common_one_new.Top = y();
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;
        }
        public static void display_new_commonform_1(string judge_type_0, TextBox TB_ls, string parameter)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.parameter = parameter;
            X_common_one_new.Left = x()-150;
            X_common_one_new.Top = y()-200;
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;
        }

        public static string get_week(DateTime rq)
        {
            string get_value = "";
            string week_0 = rq.DayOfWeek.ToString();
            switch (week_0)
                    {
                        case "Monday":
                            get_value="一";
                            break;
                        case "Tuesday":
                            get_value = "二";
                            break;
                        case "Wednesday":
                            get_value = "三";
                            break;
                        case "Thursday":
                            get_value = "四";
                            break;
                        case "Friday":
                            get_value = "五";
                            break;
                        case "Saturday":
                            get_value = "六";
                            break;
                        case "Sunday":
                            get_value = "七";
                            break;
                    }
                    return get_value;
        }


        //打印公共信息
        public static void GetPrintInfo(ref  string qymc, ref string qymc_english, ref  string Address_chinese, ref  string Address_english, ref  string qydh, ref string qycz, ref string qyyb, ref  string website)
        {
            BLL.Xqyxx B_Xqyxx = new Hotel_app.BLL.Xqyxx();
            List<Model.Xqyxx> lists = B_Xqyxx.GetModelList("");
            if (lists.Count > 0)
            {
                Model.Xqyxx M_Xqyxx = lists[0];
                qymc = M_Xqyxx.qymc;
                qymc_english = M_Xqyxx.qydzyw;
                Address_chinese = M_Xqyxx.qydz;
                Address_english = M_Xqyxx.qydzyw;
                qydh = M_Xqyxx.qydh;
                qycz = M_Xqyxx.qycz;
                qyyb = "361000";
                website = M_Xqyxx.wz;
            }
            else
            {
                qymc = "";
                qymc_english = "";
                Address_chinese = "";
                Address_english = "";
                qydh = "";
                qycz = "";
                qyyb = "";
                website = "";
            }
        }

        //获取数据库连接信息
        public static void GetDBLoginInfo(ref string server, ref  string dbName, ref string userName, ref  string pwd)
        {
            string sqlcon = ConfigurationManager.ConnectionStrings["Hotel_app.Properties.Settings.Hotel_dataConnectionString"].ConnectionString; //("Hotel_app.Properties.Settings.Hotel_dataConnectionString");
            string[] sql = sqlcon.Split(';');
            if (sql.Length > 0)
            {
                server = sql[0].Split('=')[1];
                dbName = sql[1].Split('=')[1];
                userName = sql[2].Split('=')[1];
                pwd = sql[3].Split('=')[1];
            }
            else
            {
                server = "";
                dbName = "";
                userName = "";
                pwd = "";
            }
        }

        public static void add_lo_ex_re(string yydh, string qymc,string syzd, string yhbh, string yhxm, string lo_ex, DateTime login_time, DateTime exit_time)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "insert into YH_lo_ex_trace(yydh,qymc,syzd,yhbh,yhxm,lo_ex,login_time,exit_time) values ('" + yydh + "','" + qymc + "','" + syzd + "','" + yhbh + "','" + yhxm + "','" + lo_ex + "','" + login_time.ToString() + "','" + exit_time.ToString() + "')";
            B_Common.ExecuteSql(sql_s);
            if (lo_ex == common_app.lo_ex_ex)
            {
                sql_s = "delete from YH_lo_ex_trace_current where yydh='"+common_app.yydh+"' and qymc='"+common_app.qymc+"' and login_time='"+common_app.login_time.ToString()+"'";
                B_Common.ExecuteSql(sql_s);
            }
        
        }
        public static void add_lo_ex_re_current(string yydh, string qymc, string syzd, string yhbh, string yhxm, string lo_ex, DateTime login_time, DateTime login_time_yl)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "delete from YH_lo_ex_trace_current where yydh='" + yydh + "' and yhbh='" + yhbh + "' and login_time='" + login_time_yl.ToString() + "'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "insert into YH_lo_ex_trace_current(yydh,qymc,syzd,yhbh,yhxm,lo_ex,login_time) values ('" + yydh + "','" + qymc + "','" + syzd + "','" + yhbh + "','" + yhxm + "','" + lo_ex + "','" + login_time.ToString() + "')";
            B_Common.ExecuteSql(sql_s);

        }



        public static string get_qyxx_result(string rx,string mr)
        {
            string get_result = mr;
            BLL.Common B_Common=new Hotel_app.BLL.Common();
            DataSet ds_temp=B_Common.GetList("select * from Xqyxx","id>=0");
            if(ds_temp!=null && ds_temp.Tables[0].Rows.Count>0)
            {
                get_result = ds_temp.Tables[0].Rows[0][rx].ToString();
            }
            ds_temp.Clear();
            ds_temp.Dispose();
            return get_result;
        }


        public static void GetCurrentTime(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            dtp.Value = DateTime.Now;
        }

        //返回皮肤文件名
        public static string SetSkin(string skinName)
        {
            return Application.StartupPath + @"\skin\"+skinName+".ssk";
        }





        ///房号，房态来返回图标的名称
        ///
        public static string  GetIco(string fjbh,string fjrb)
        {
            string icoName = "a-4.ico";//默认显示哪个 
            if (!fjbh.Equals("") && !fjrb.Equals(""))
            {
                BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
                List<Model.Qskyd_fjrb> list = B_Qskyd_fjrb.GetModelList(" id>=0  and   fjbh='" + fjbh + "'   and   yddj='"+common_yddj.yddj_dj+"' ");
                if (list.Count > 0)
                {
                    if (list[0].sktt.Equals(common_sktt.sktt_sk))
                    { icoName = ""; return icoName; ; };
                    if (list[0].sktt.Equals(common_sktt.sktt_cz))
                    { icoName = "house.ico"; return icoName; };
                    if (list[0].sktt.Equals(common_sktt.sktt_zd))
                    { icoName = "c-4.ico"; return icoName; };
                    if (list[0].sktt.Equals(common_sktt.sktt_tt))
                    { icoName = "tuanti.ico"; return icoName; };
                    if (list[0].sktt.Equals(common_sktt.sktt_hy))
                    { icoName = "a-11.ico"; return icoName; };
                }
            }
            return icoName;
        }

        //定位
     public   static void setPosition(object  Objfrm)
        {
            if (Objfrm.GetType().BaseType == typeof(System.Windows.Forms.Form))
            {
                Form Frm = (Form)Objfrm;
                Frm.StartPosition = FormStartPosition.CenterScreen;
                Frm.ShowDialog();
            }
        }

     //安装devAssembly到GAC中
     public static string InstallDevToGAC()
     {
         string meg = get_failure;
         Process pro = new Process();
         try
         {
             pro.StartInfo.UseShellExecute = true;
             pro.StartInfo.FileName = Application.StartupPath + "\\register.bat";
             pro.StartInfo.CreateNoWindow = false;
             if (pro.Start())
             {
                 meg = get_suc;
             }
         }
         catch (Exception ee)
         {
             meg = get_failure;
         }
         finally
         {
             if (pro != null)
             {
                 pro.Close();
             }
         }
         return meg;
     }
    }
}
