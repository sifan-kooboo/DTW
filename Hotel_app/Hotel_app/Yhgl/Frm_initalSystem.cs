using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace Hotel_app.Yhgl
{
    public partial class Frm_initalSystem : DevExpress.XtraEditors.XtraForm
    {
        public Frm_initalSystem()
        {
            InitializeComponent();
        }
        private int XtraSelectedPageIndex = -1;
        //private void b_save_Click(object sender, EventArgs e)
        //{
        //    if (tb_qymc.Text.Trim() == "")
        //    {
        //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确填写企业名称."); return;
        //    }
        //    if (tB_yydh.Text.Trim() == "")
        //    {
        //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确填写营业名称."); return;
        //    }
        //    if (tb_server.Text.Trim() == "")
        //    {
        //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确填写服务器IP地址."); return;
        //    }
        //    if (tB_databaseName.Text.Trim() == "")
        //    {
        //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确填写服务数据库名称."); return;
        //    }
        //    if (tb_userName.Text.Trim() == "")
        //    {
        //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确填写数据库用户名."); return;
        //    }
        //    if (tb_pwd.Text.Trim() == "")
        //    {
        //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确填写数据库密码."); return;
        //    }
        //    try
        //    {
        //        common_file.Common_initalSystem.SaveConfig("qymc", tb_qymc.Text.Trim());
        //        common_file.Common_initalSystem.SaveConfig("yydh", tB_yydh.Text.Trim());
        //        common_file.Common_initalSystem.SaveConfig("qybh",tb_qybh.Text.Trim());
        //        common_file.Common_initalSystem.SaveConfig("is_inital", "true");
        //        common_file.Common_initalSystem.SaveConfig("appversion", tb_SysteVersion.Text.Trim());
        //        common_file.Common_initalSystem.SaveConfig("shlz",tb_shlz.Text.Trim());
        //        common_file.Common_initalSystem.SaveConfig("webServer", tb_webserver.Text.Trim());

        //        //保存数据库信息
        //        string connStr = "Data Source=" + tb_server.Text.Trim() + ";Initial Catalog=" + tB_databaseName.Text.Trim() + ";User ID=" + tb_userName.Text.Trim() + ";Password=" + tb_pwd.Text.Trim() + ";";
        //        common_file.Common_initalSystem.SaveConfig("conStr", connStr);
        //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "系统初始信息设置成功,请重新登录");
        //        this.DialogResult = DialogResult.OK;
        //    }
        //    catch (Exception ee)
        //    {
        //        throw new Exception(ee.Message);
        //    }
        //}

        //private void Frm_initalSystem_Load(object sender, EventArgs e)
        //{
        //    //初始读取
        //    tb_qymc.Text = common_file.Common_initalSystem.ReadNameValueSectionValue("qyinfo", "qymc");
        //    tB_yydh.Text = common_file.Common_initalSystem.ReadNameValueSectionValue("qyinfo", "yydh");
        //    tb_qybh.Text = common_file.Common_initalSystem.ReadNameValueSectionValue("qyinfo", "qybh");
 
        //    tb_shlz.Text = common_file.Common_initalSystem.ReadNameValueSectionValue("qyinfo", "shlz");
        //    tb_webserver.Text = common_file.Common_initalSystem.ReadNameValueSectionValue("qyinfo", "webServer");
        //    tb_SysteVersion.Text = common_file.Common_initalSystem.ReadNameValueSectionValue("qyinfo", "appversion");
             
        //    //加载数据库信息
        //    //string[] connectionInfo = ConfigurationManager.ConnectionStrings[1].ConnectionString.Split(';');
        //    string[] connectionInfo = ConfigurationManager.AppSettings["conStr"].Split(';');
        //    tb_server.Text = connectionInfo[0].Split('=')[1];
        //    tB_databaseName.Text = connectionInfo[1].Split('=')[1];
        //    tb_userName.Text = connectionInfo[2].Split('=')[1];
        //    tb_pwd.Text = connectionInfo[3].Split('=')[1];
        //}

        //private void b_exit_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void b_TestConnect_Click(object sender, EventArgs e)
        //{
        //    common_file.common_app.get_czsj();


        //    string serverIP = tb_server.Text.Trim();
        //    string database = tB_databaseName.Text.Trim();
        //    string user = tb_userName.Text.Trim();
        //    string pwd = tb_pwd.Text.Trim();
        //    string connStr="Data Source="+serverIP+";Initial Catalog="+database+";User ID="+user+";Password="+pwd+";";
        //    System.Data.SqlClient.SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection(connStr);
        //    try
        //    {
        //        if (sqlCon != null)
        //            sqlCon.Open(); 
        //            common_file.common_app.Message_box_show(common_file.common_app.message_title, "数据库配置正确,请继续初始化其它信息");
        //    }
        //    catch (Exception ee)
        //    {
        //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "数据库配置不正确,请正确填写连接信息"+ee.ToString());
        //    }
        //    Cursor.Current = Cursors.Default;
        //}

        //private void b_TestServer_Click(object sender, EventArgs e)
        //{
        //    common_file.common_app.get_czsj();

        //   string url = common_file.common_app.service_url + "Service1.asmx";
        //   object result = Hotel_app.DynamicWebServiceCall.InvokeWebService(url,"HelloServer",null);
        //   if (result != null && result.ToString() == common_file.common_app.get_suc)
        //   {
        //       common_file.common_app.Message_box_show(common_file.common_app.message_title, "服务端配置正确");
        //   }
        //   else
        //   {
        //       common_file.common_app.Message_box_show(common_file.common_app.message_title, "服务端配置不正确,请确认URL地址");
        //       return;                
        //   }
        //   Cursor.Current = Cursors.Default;
        //}


        //private void btn_click(object sender, EventArgs e)
        //{
        //    //新系统初始化
        //    if (((Button)sender).Tag.ToString().Equals("1"))
        //    {
        //        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你正在执行系统初始化操作,系统会删除当前所有的测试数据回去初始状态,你确定要执行初始化操作嘛?") == true)
        //        {
        //            DbHelperSQLP sqlp_new = new DbHelperSQLP();
        //            //sqlp_new.RunProcedure(
        //        }
 
        //    }
        //}


        //记录当前的账单类型
        string jzd_now = "A4";
        string yjd_now = "A4";
        string djb_now = "A4";
        decimal tqts = 0;
        void LoadInfo(int pageIndex)
        {
            if (pageIndex == 0)
            {
                txt_jdmc.Text = common_file.common_app.qymc;
                txt_SoftName.Text = common_file.common_app.SoftName;
                txt_yydh.Text = common_file.common_app.yydh;
                txt_Softversion.Text = common_file.common_app.softVerSion;
            }
            if (pageIndex == 2)
            {
                List<Model.Qcounter> list = new List<Hotel_app.Model.Qcounter>();
                BLL.Qcounter bll = new Hotel_app.BLL.Qcounter();
                list = bll.GetModelList(" id>=0  and  yydh='" + common_file.common_app.yydh + "'");
                if (list != null && list.Count > 0)
                {
                    string printzdtype = list[0].printzdpd.ToString();

                    string jzd_type = printzdtype.Substring(0, 2);
                    string yjd_type = printzdtype.Substring(2, 2);
                    string djb_type = printzdtype.Substring(4, 2);

                    if (jzd_type.Equals("11"))
                    {
                        jzd_now = cb_jzd.Text = "A4";
                    }
                    else
                    {
                        jzd_now = cb_jzd.Text = "A5";
                    }

                    if (yjd_type.Equals("11"))
                    {
                        yjd_now = cb_yjd.Text = "A4";
                    }
                    else
                    {
                        yjd_now = cb_yjd.Text = "A5";
                    }

                    if (djb_type.Equals("11"))
                    {
                        djb_now= cb_djb.Text = "A4";
                    }
                    else
                    {
                       djb_now= cb_djb.Text = "A5";
                    }


                   tqts= txt_yqsts.Value = list[0].ybtqts;

                    
                    //11----A4有表头结账单
                    //21----A5有表头-结账单

                    //11---A4有表头押金单
                   //21----A5有表头押金单






                }
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_app.message_box_show_select("提示", "您确定要执行当前的操作嘛?"))
            {
                if (ExcutePorc(int.Parse(((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString())))
                {
                    common_file.common_app.Message_box_show("提示", "初始房态分析数据成功");
                }
            }
            
        }
        
        private bool ExcutePorc(int ClearType)
        {
            bool result = false;
            DbHelperSQLP proc = new DbHelperSQLP();
            int rowsAffected=0;
            SqlParameter[] paras = new SqlParameter[5];
            paras[0] = new SqlParameter("@clearType", SqlDbType.Int);
            paras[1] = new SqlParameter("@czy", SqlDbType.VarChar,100);
            paras[2] = new SqlParameter("@czsj", SqlDbType.VarChar, 100);
            paras[3] = new SqlParameter("@clearType_remark", SqlDbType.VarChar, 2000);
            paras[4] = new SqlParameter("@rowaffect", SqlDbType.Int);

            paras[0].Value = ClearType;
            paras[1].Value = common_file.common_app.czy;
            paras[2].Value = DateTime.Now.ToString();
            if (ClearType.Equals(1))
            {
                paras[3].Value = "清除试用数据信息（包含主单，报表和账务）";
            }
            if (ClearType.Equals(2))
            {
                paras[3].Value = "清除协议相关信息（包含会员，协议单位）";
            }
            if (ClearType.Equals(3))
            {
                paras[3].Value = "初始化房态信息（房态状态，分析数据）";
            }
            if (ClearType.Equals(4))
            {
                paras[3].Value = "新系统初始化（只保留基础数据）";
            }
            paras[4].Direction = ParameterDirection.Output;
            proc.RunProcedure("initalSystem", paras, out  rowsAffected);
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }

        private void Frm_initalSystem_Load(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex =XtraSelectedPageIndex= 0;
            txt_Softversion.Enabled = false;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadInfo(((DevExpress.XtraTab.XtraTabControl)sender).SelectedTabPageIndex);
        }

        private void btn_save(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton  simpbtn=(DevExpress.XtraEditors.SimpleButton)sender;
            if(simpbtn.Tag.Equals("Simbtn_save_basic"))
            {
                if (!txt_jdmc.Text.Equals(common_file.common_app.qymc) || !txt_yydh.Text.Equals(common_file.common_app.yydh) || !txt_SoftName.Text.Equals(common_file.common_app.SoftName))
                {
                    common_file.common_app.get_czsj();
                    Model.Xqyxx qyxx = new Hotel_app.Model.Xqyxx();
                    BLL.Xqyxx bll = new Hotel_app.BLL.Xqyxx();
                    List<Model.Xqyxx> list = bll.GetModelList(" id>=0  and  yydh='" + common_file.common_app.yydh + "'");
                    if (list != null && list.Count > 0)
                    {
                        qyxx = list[0];
                        int id = qyxx.id;
                        qyxx.qymc = txt_jdmc.Text;
                        qyxx.yydh = txt_yydh.Text;
                        qyxx.Softname = txt_SoftName.Text;
                        qyxx.id = id;
                        if (bll.Update(qyxx))
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "更新酒店基本信息成功");
                            
                        }
                    }
                }
            }
            if (simpbtn.Tag.Equals("Simbtn_save_zdInfo"))
            {
                if (!cb_jzd.SelectedItem.Equals(jzd_now) || !cb_yjd.SelectedItem.Equals(yjd_now) || !cb_djb.SelectedItem.Equals(djb_now) || !txt_yqsts.Value.Equals(tqts))
                {
                    jzd_now = cb_jzd.Text.Equals("A4") ? "11" : "21";
                    yjd_now = cb_yjd.Text.Equals("A4") ? "11" : "21";
                    djb_now = cb_djb.Text.Equals("A4") ? "11" : "21";

                    BLL.Qcounter bll = new Hotel_app.BLL.Qcounter();
                    Model.Qcounter counter = new Hotel_app.Model.Qcounter();
                    List<Model.Qcounter> list = bll.GetModelList(" id>=0  and  yydh='" + common_file.common_app.yydh + "'");
                    if (list != null && list.Count > 0)
                    {
                        counter = list[0];
                        int id = counter.ID;
                        counter.printzdpd = int.Parse(jzd_now + yjd_now + djb_now);
                        counter.ID=id;
                        if (bll.Update(counter))
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "更新成功,你现在可以直接连接打印机打印您设置的账单");
                        }
                    }
                }
            }              
        }
    }
}