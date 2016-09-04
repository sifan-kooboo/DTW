using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.OleDb;
using System.Data.SqlClient;
using Hotel_app.common_file;

namespace Hotel_app.dxpt
{
    class common_dxpt
    {
        public static string dx_table_source_ks = "Qskyd_mainrecord_lskr";
        public static string dx_table_source_hy = "Hhygl";
        public static string dx_table_source_xydw = "Yxydw";
        public static string dx_table_wb = "外部导入";


        /// <summary>
        /// 分页代码
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="l_totalPage"></param>
        /// <param name="l_currentPage"></param>
        /// <param name="dt"></param>
        /// <param name="tableName"></param>
        /// <param name="dg_infoSource"></param>
        /// <param name="GetSelCond"></param>
        public static void linkButtion_Click(object operation_sender, int PageSize, int PageCount, ref  int CurrentPage, Label l_totalPage, Label l_currentPage, DataTable dt, string tableName, DataGridViewSummary dg_infoSource, string GetSelCond)
        {
            int tempCount = -1;
            if ((LinkLabel)operation_sender != null)
            {
                LinkLabel linklable = operation_sender as LinkLabel;
                if (linklable.Name.Equals("lb_first"))
                {
                    CurrentPage = 1;
                    l_totalPage.Text = PageCount.ToString();
                    l_currentPage.Text = CurrentPage.ToString();
                    dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, PageSize, "*", GetSelCond, "", ref tempCount);
                    dg_infoSource.DataSource = dt;

                }
                if (linklable.Name.Equals("lb_pre"))
                {
                    if (CurrentPage >= 2)
                    {
                        CurrentPage -= 1;
                    }
                    l_totalPage.Text = PageCount.ToString();
                    l_currentPage.Text = CurrentPage.ToString();
                    dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, PageSize, "*", GetSelCond, "", ref tempCount);
                    dg_infoSource.DataSource = dt;
                }
                if (linklable.Name.Equals("lb_next"))
                {
                    if (CurrentPage < PageCount)
                    {
                        CurrentPage += 1;
                    }
                    else
                    {
                        CurrentPage = PageCount;
                    }
                    l_totalPage.Text = PageCount.ToString();
                    l_currentPage.Text = CurrentPage.ToString();
                    dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, PageSize, "*", GetSelCond, "", ref tempCount);
                    dg_infoSource.DataSource = dt;
                }
                if (linklable.Name.Equals("lb_last"))
                {
                    CurrentPage = PageCount;
                    l_totalPage.Text = PageCount.ToString();
                    l_currentPage.Text = CurrentPage.ToString();
                    dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, PageSize, "*", GetSelCond, "", ref tempCount);
                    dg_infoSource.DataSource = dt;
                }
            }
        }

        public static void searchButtion_Click(int tempCount, DataTable dt, string tableName, ref  int CurrentPage, int PageSize, ref  int PageCount, Label l_totalPage, Label l_currentPage, DataGridViewSummary dg_infoSource, string GetSelCond, TabControl tabControl1)
        {
            common_file.common_app.get_czsj();
            tempCount = -1;
            dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, PageSize, "*", GetSelCond, "", ref tempCount);
            if ((tempCount % PageSize) == 0)
            {
                PageCount = tempCount / PageSize;
            }
            else
            {
                PageCount = tempCount / PageSize + 1;
            }
            l_totalPage.Text = PageCount.ToString();
            l_currentPage.Text = CurrentPage.ToString();
            dg_infoSource.AutoGenerateColumns = false;
            dg_infoSource.DataSource = dt;
            tabControl1.SelectedIndex = 0;
            tabControl1.TabPages[0].Focus();
            Cursor.Current = Cursors.Default;
        }

        //实现excel导入
        static public DataSet ExcelToDataSet(string filename)
        {
            DataSet ds;
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                            "Extended Properties=Excel 8.0;" +
                            "data source=" + filename;
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [Sheet1$]";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            ds = new DataSet();
            myCommand.Fill(ds);
            myConn.Close();
            return ds;
        }

        //实现短信群发
        static public void SendDxMuliti(string krsj_0, string krxm_0, string txt_sendContent)
        {
            //检查发送信息（号码和姓名）的完整性
            if (!krxm_0.Equals("") && krsj_0.Length >= 11)
            {
                krxm_0 = "您好"+krxm_0+",";
                //信息完整进行发送
                bool check = System.Text.RegularExpressions.Regex.IsMatch(krsj_0, @"^[1]+[3,4,5,6,8]+\d{9}");
                if (check)
                {
                    krsj_0 = krsj_0.Substring(0, 11);
                    string timeNowSend = DateTime.Now.ToString();//记录发送时间 
                    string[] retureResult = new string[2];
                    retureResult[0] = common_file.common_app.get_failure;//指示是否发送成功
                    retureResult[1] = "";//存储发送的代码返回值

                    //发送短信
                    //Hotel_app.Hhygl_app.Hhygl_app Hhygl_app_services_new = new Hotel_app.Hhygl_app.Hhygl_app();
                    //Hhygl_app_services_new.Url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                    Hotel_app.Server.Hhygl.Hhygl_verifyCode Hhygl_verifyCode_services = new Hotel_app.Server.Hhygl.Hhygl_verifyCode();
                    object result = Hhygl_verifyCode_services.Hhygl_SendMsm_temporay(krsj_0, krxm_0, txt_sendContent, common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_hyAction.hy_Action_dxqf, common_file.common_app.xxzs);
                    //记录发送的详细信息
                    if (result != null)
                    {
                        string[] aa = (string[])result;
                        DbHelperSQLP sqlp = new DbHelperSQLP();
                        SqlParameter[] parms1 = new SqlParameter[9];

                        parms1[0] = new SqlParameter("@phoneNo", SqlDbType.VarChar, 100);
                        parms1[1] = new SqlParameter("@userName", SqlDbType.VarChar, 100);
                        parms1[2] = new SqlParameter("@information", SqlDbType.VarChar, 8000);
                        parms1[3] = new SqlParameter("@yydh", SqlDbType.VarChar, 100);
                        parms1[4] = new SqlParameter("@qymc", SqlDbType.VarChar, 100);
                        parms1[5] = new SqlParameter("@sendTime", SqlDbType.DateTime);
                        parms1[6] = new SqlParameter("@sendStatus", SqlDbType.VarChar, 300);
                        parms1[7] = new SqlParameter("@sendStatusCode", SqlDbType.VarChar, 100);
                        parms1[8] = new SqlParameter("@czy", SqlDbType.VarChar, 100);

                        parms1[0].Value = krsj_0;
                        parms1[1].Value = krxm_0;
                        parms1[2].Value = txt_sendContent.Trim().Replace("'", "-");
                        parms1[3].Value = common_file.common_app.yydh;
                        parms1[4].Value = common_file.common_app.qymc;
                        parms1[5].Value = timeNowSend;
                        parms1[6].Value = aa[0];
                        parms1[7].Value = aa[1];
                        parms1[8].Value = common_file.common_app.czy;

                        try
                        {
                            sqlp.RunProcedure("AddDxDetailIntoDx_details", parms1);
                        }
                        catch (Exception ee)
                        {
                            common_czjl.add_errorlog(parms1.ToString(), ee.ToString(), DateTime.Now.ToString());

                        }
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "记录" + "lvi" + "不符合要求,系统请求删除!");
                    }
                }
            }
        }
    }
}
