using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Hotel_app.Qyddj
{
    class Q_zjgl
    {
        ///身份证
        [DllImport("WltRS.dll")]
        private static extern int GetBmp(char Wlt_File, int intf);
        [DllImport("termb.dll")]
        private static extern int InitComm(int iPort);
        [DllImport("termb.dll")]
        private static extern int Authenticate();
        [DllImport("termb.dll")]
        private static extern int Read_Content(int iActive);
        [DllImport("termb.dll")]
        private static extern int CloseComm();
        [DllImport("termb.dll")]
        private static extern int GetPeopleName(StringBuilder szName, int iLen);
        [DllImport("termb.dll")]
        private static extern int GetPeopleSex(StringBuilder szSex, int iLen);
        [DllImport("termb.dll")]
        private static extern int GetPeopleNation(StringBuilder szNation, int iLen);
        [DllImport("termb.dll")]
        private static extern int GetPeopleBirthday(StringBuilder szBirthday, int iLen);
        [DllImport("termb.dll")]
        private static extern int GetPeopleAddress(StringBuilder szAddress, int iLen);
        [DllImport("termb.dll")]
        private static extern int GetPeopleIDCode(StringBuilder szID, int iLen);
        [DllImport("termb.dll")]
        private static extern int GetDepartment(StringBuilder szDepartment, int iLen);
        [DllImport("termb.dll")]
        private static extern int GetStartDate(StringBuilder szStartDate, int iLen);
        [DllImport("termb.dll")]
        private static extern int GetEndDate(StringBuilder szEndDate, int iLen);
        [DllImport("kernel32.dll")]
        private static extern int Beep(int dwFreq, int dwDuration);//




        const int NameLen = 18;
        const int SexLen = 8;
        const int NationLen = 8;
        const int DateLen = 16;
        const int AddrLen = 70;
        const int IdLen = 22;
        const int DepartmentLen = 30;
        const int StartdateLen = 16;
        const int EnddateLen = 16;
        const int ReserveLen = 50;
        public static int UsePort=-1;
        public string bs = "*";
        public PictureBox PictureBox_nw_1;

        //先把值先赋*
        public void add_info(ref StringBuilder s_0, int s_len)
        {
            for (int j_0 = 0; j_0 < s_len; j_0++)
            {
                s_0.Append(bs);
            }
        }

        /// <summary>
        /// 读取身份证信息并填入输入框中
        /// </summary>
        /// <param name="tBkrxm_0"></param>
        /// <param name="cBkrxb_0"></param>
        /// <param name="tBnation_0"></param>
        /// <param name="tBadd_0"></param>
        /// <param name="tBid_0"></param>
        /// <param name="tBkrsr_0"></param>
        /// <param name="tBkrgj0"></param>
        /// <param name="tByxzj0"></param>
        public void get_sfz_info_tb(ref TextBox tBkrxm_0, ref ComboBox cBkrxb_0, ref TextBox tBnation_0, ref TextBox tBadd_0, ref TextBox tBid_0, ref DateTimePicker tBkrsr_0, ref TextBox tBkrgj0, ref TextBox tByxzj0, bool sh_massage)
        {
            string tBkrxm = ""; string tBkrxb = ""; string tBnation = "";
            string tBadd = ""; string tBid = ""; string tBkrsr = "";
            string tBdepart = ""; string tBstart = ""; string tBend = "";
            string massage_nr = "";
            byte[] imakrxp = new byte[0];
            get_sfz_info(ref  tBkrxm, ref  tBkrxb, ref  tBnation, ref  tBadd, ref  tBid, ref  tBkrsr, ref  tBdepart, ref  tBstart, ref  tBend, ref imakrxp, sh_massage, ref massage_nr);
            if (tBkrxm != "")
            {
                tBkrxm_0.Text = tBkrxm;
                cBkrxb_0.Text = tBkrxb;
                tBnation_0.Text = tBnation;
                tBadd_0.Text = tBadd;
                tBid_0.Text = tBid;
                tBkrsr_0.Value = DateTime.Parse(tBkrsr.Substring(0, 4) + "-" + tBkrsr.Substring(4, 2) + "-" + tBkrsr.Substring(6, 2));
                if (tBid != "")
                {
                    tBkrgj0.Text = common_file.common_app.krgj_zg;
                    tByxzj0.Text = common_file.common_app.yxzj_sfz;
                }
            }
            //tBdepart_0.Text = tBdepart;
            //tBstart_0.Text = tBstart;
            //tBend_0.Text = tBend;

        }

        /// <summary>
        /// 读取身份证信息
        /// </summary>
        /// <param name="tBkrxm"></param>
        /// <param name="tBkrxb"></param>
        /// <param name="tBnation"></param>
        /// <param name="tBadd"></param>
        /// <param name="tBid"></param>
        /// <param name="tBkrsr"></param>
        /// <param name="tBdepart"></param>
        /// <param name="tBstart"></param>
        /// <param name="tBend"></param>
        /// <param name="imakrxp"></param>
        /// <param name="sh_massage"></param>
        /// <param name="massage_nr"></param>
        /// <returns></returns>
        public string get_sfz_info(ref string tBkrxm, ref string tBkrxb, ref string tBnation, ref string tBadd, ref string tBid, ref string tBkrsr, ref string tBdepart, ref string tBstart, ref string tBend, ref byte[] imakrxp, bool sh_massage, ref string massage_nr)
        {
            string s_0 = "";
            int tempReturn = 0;
            bool usbPort = false;

            try
            {
                for (int port = 1001; port <= 1006; port++)
                {
                    tempReturn = InitComm(port);
                    if (tempReturn == 1)
                    {
                        usbPort = true;
                        UsePort = port;
                        break;
                    }
                }
                //检测串口的机具连接
                if (!usbPort)
                {
                    for (int port = 1; port <= 6; port++)
                    {
                        tempReturn = InitComm(port);
                        if (tempReturn == 1)
                        {
                            usbPort = false;
                            UsePort=port;
                            break;
                        }
                    }
                }
            }
            catch(Exception  e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {

            }


            if (tempReturn != 1)
            {
                if (sh_massage == true)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "端口打开失败,请检测相应的端口或者重新连接读卡器!");

                }
                else
                {
                    massage_nr = "端口打开失败,请检测相应的端口或者重新连接读卡器!";
                }
                try
                {
                    CloseComm();
                }
                catch 
                {
                }
            }
            else
            {

                try
                {
                    CloseComm();
                    InitComm(UsePort);
                    Authenticate();
                    if (Read_Content(1) != 1)
                    {
                        if (sh_massage == true)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "读卡失败，请确认是否把有效的二代身份证放在读卡器上!");

                        }
                        else
                        {
                            massage_nr = "读卡失败，请确认是否把有效的二代身份证放在读卡器上!";
                        }
                        CloseComm();
                    }
                    else
                    {
                        string cznr = "";
                        string czzy = "";
                        string czbz = "";
                        try
                        {



                            int i = 0;
                            StringBuilder szName = new StringBuilder(NameLen);
                            add_info(ref szName, NameLen);
                            czzy = "1" + szName.ToString();
                            i = GetPeopleName(szName, NameLen);
                            czzy = "1" + szName.ToString();
                            tBkrxm = szName.ToString().Trim().Replace(bs, "");

                            cznr = "客人姓名";

                            StringBuilder szSex = new StringBuilder(SexLen);
                            add_info(ref szSex, SexLen);
                            czzy = "2" + szSex.ToString();
                            i = GetPeopleSex(szSex, SexLen);
                            czzy = "2" + szSex.ToString();
                            tBkrxb = szSex.ToString().Trim().Replace(bs, "");

                            cznr = "性别";

                            StringBuilder szNation = new StringBuilder(NationLen);
                            add_info(ref szNation, NationLen);
                            czzy = "3" + szNation.ToString();
                            i = GetPeopleNation(szNation, NationLen);
                            czzy = "3" + szNation.ToString();
                            tBnation = szNation.ToString().Trim().Replace(bs, "");

                            cznr = "民族";

                            StringBuilder szBirthday = new StringBuilder(DateLen);
                            add_info(ref szBirthday, DateLen);
                            czzy = "4" + szBirthday.ToString();
                            i = GetPeopleBirthday(szBirthday, DateLen);
                            czzy = "4" + szBirthday.ToString();
                            tBkrsr = szBirthday.ToString().Trim().Replace(bs, "");

                            cznr = "生日";


                            StringBuilder szID = new StringBuilder(IdLen);
                            add_info(ref szID, IdLen);
                            czzy = "5" + szID.ToString();
                            i = GetPeopleIDCode(szID, IdLen);
                            czzy = "5" + szID.ToString();
                            tBid = szID.ToString().Trim().Replace(bs, "");


                            cznr = "号码";


                            StringBuilder szStartDate = new StringBuilder(StartdateLen);
                            add_info(ref szStartDate, StartdateLen);
                            czzy = "6" + szStartDate.ToString();
                            i = GetStartDate(szStartDate, StartdateLen);
                            czzy = "6" + szStartDate.ToString();
                            tBstart = szStartDate.ToString().Trim().Replace(bs, "");


                            cznr = "开始";

                            StringBuilder szEndDate = new StringBuilder(EnddateLen);
                            add_info(ref szEndDate, EnddateLen);
                            czzy = "7" + szEndDate.ToString();
                            i = GetEndDate(szEndDate, EnddateLen);
                            czzy = "7" + szEndDate.ToString();
                            tBend = szEndDate.ToString().Trim().Replace(bs, "");

                            cznr = "结束";

                            StringBuilder szDepartment = new StringBuilder(DepartmentLen);
                            add_info(ref szDepartment, DepartmentLen);
                            czzy = "8" + szDepartment.ToString();
                            i = GetDepartment(szDepartment, DepartmentLen);
                            czzy = "8" + szDepartment.ToString();
                            tBdepart = szDepartment.ToString().Trim().Replace(bs, "");


                            cznr = "部门";


                            StringBuilder szAddress = new StringBuilder(AddrLen);
                            add_info(ref szAddress, AddrLen);
                            czzy = "9" + szAddress.ToString();
                            i = GetPeopleAddress(szAddress, AddrLen);
                            czzy = "9" + szAddress.ToString();
                            tBadd = szAddress.ToString().Trim().Replace(bs, "");

                            cznr = "地址";


                            Beep(2047, 300);
                            CloseComm();



                            if (tBid != "")
                            {
                                BLL.Q_sfz_save B_Q_sfz_save = new Hotel_app.BLL.Q_sfz_save();
                                DataSet ds_temp = B_Q_sfz_save.GetList("zjhm='" + tBid + "'");
                                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                                { }
                                else
                                {

                                    cznr = "输入数据"; czzy = cznr;
                                    byte[] imageb = new byte[0];
                                    string savePath = Application.StartupPath + @"\ZP.bmp";
                                    FileStream fs = File.OpenRead(savePath);
                                    
                                    imageb = new byte[fs.Length];
                                    cznr = "读图前"; czzy = cznr;
                                    fs.Read(imageb, 0, imageb.Length);
                                    cznr = "读图后"; czzy = cznr;
                                    Model.Q_sfz_save M_Q_sfz_save = new Hotel_app.Model.Q_sfz_save();
                                    cznr = "生成模前"; czzy = cznr;
                                    M_Q_sfz_save.zjhm = tBid;
                                    cznr = "生成模" + tBid; czzy = cznr;
                                    M_Q_sfz_save.krdz = tBadd;
                                    cznr = "生成模" + tBadd; czzy = cznr;
                                    M_Q_sfz_save.krmz = tBnation;
                                    cznr = "生成模" + tBnation; czzy = cznr;
                                    M_Q_sfz_save.krsr = DateTime.Parse(tBkrsr.Substring(0, 4) + "-" + tBkrsr.Substring(4, 2) + "-" + tBkrsr.Substring(6, 2));
                                    cznr = "生成模" + M_Q_sfz_save.krsr; czzy = cznr;
                                    M_Q_sfz_save.krxb = tBkrxb;
                                    cznr = "生成模" + tBkrxb; czzy = cznr;
                                    M_Q_sfz_save.krxm = tBkrxm;
                                    cznr = "生成模" + tBkrxm; czzy = cznr;

                                    fs.Flush();
                                    fs.Close();

                                    if (tBstart.Length > 9)
                                    {
                                        M_Q_sfz_save.startdate = DateTime.Parse(tBstart.Substring(0, 4) + "-" + tBstart.Substring(4, 2) + "-" + tBstart.Substring(6, 2));
                                        cznr = "生成模始" + tBstart.Substring(0, 4) + "-" + tBstart.Substring(4, 2) + "-" + tBstart.Substring(6, 2); czzy = cznr;
                                    }
                                    else { M_Q_sfz_save.startdate = DateTime.Parse(common_file.common_app.cssj); }
                                    if (tBend.Length > 9)
                                    {
                                        M_Q_sfz_save.enddate = DateTime.Parse(tBend.Substring(0, 4) + "-" + tBend.Substring(4, 2) + "-" + tBend.Substring(6, 2));
                                        cznr = "生成模尾" + tBend.Substring(0, 4) + "-" + tBend.Substring(4, 2) + "-" + tBend.Substring(6, 2); czzy = cznr;
                                    }
                                    else
                                    { M_Q_sfz_save.enddate = DateTime.Parse(common_file.common_app.cssj); }
                                    M_Q_sfz_save.department = tBdepart;
                                    cznr = "生成模尾" + tBdepart; czzy = cznr;
                                    if (imageb.Length > 0)
                                    {
                                        M_Q_sfz_save.krxp = imageb;
                                    }
                                    cznr = "获取片"; czzy = cznr;
                                    B_Q_sfz_save.Add(M_Q_sfz_save);
                                    imakrxp = imageb;
                                    cznr = "保存后"; czzy = cznr;
                                }
                                //PictureBox PictureBox_new = new PictureBox();
                                //PictureBox_new.ImageLocation = Application.StartupPath + @"\ZP.bmp";
                                //PictureBox_nw_1 = PictureBox_new;
                            }
                        }
                        catch
                        {
                            common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "检查身份证刷新问题", czzy, cznr, DateTime.Now);
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "读卡成功了，但转换数据时有问题了，请重新刷卡试试，如不行请重启酒店系统!");
                            CloseComm();
                        }
                        finally
                        {

                        }
                    }
                }
                catch (Exception  ee)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title,"读证错误,请关闭此窗体,打开重新读证.");
                }



            }
            return s_0;
        }


        /// <summary>
        /// 临时增加身份证，用来最后转入房间
        /// </summary>
        /// <returns></returns>
        public string add_ls_sfz()
        {
            string result_0 = "";
            string tBkrxm = ""; string tBkrxb = ""; string tBnation = "";
            string tBadd = ""; string tBid = ""; string tBkrsr = "";
            string tBdepart = ""; string tBstart = ""; string tBend = "";
            bool sh_massage = false;
            string massage_nr = "";
            byte[] imakrxp = new byte[0];

            get_sfz_info(ref  tBkrxm, ref  tBkrxb, ref  tBnation, ref  tBadd, ref  tBid, ref  tBkrsr, ref  tBdepart, ref  tBstart, ref  tBend, ref imakrxp, sh_massage, ref massage_nr);
            result_0 = massage_nr;
            if (tBkrxm != "")
            {
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                DataSet DS_temp = B_Common.GetList("select * from Q_sfz_temp", " zjhm='" + tBid + "' and shcl=0");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    BLL.Q_sfz_temp B_Q_sfz_temp = new Hotel_app.BLL.Q_sfz_temp();
                    Model.Q_sfz_temp M_Q_sfz_temp = new Hotel_app.Model.Q_sfz_temp();
                    M_Q_sfz_temp.zjhm = tBid;
                    M_Q_sfz_temp.krxm = tBkrxm;
                    M_Q_sfz_temp.krxb = tBkrxb;
                    M_Q_sfz_temp.krmz = tBnation;
                    M_Q_sfz_temp.krdz = tBadd;
                    M_Q_sfz_temp.krsr = DateTime.Parse(tBkrsr.Substring(0, 4) + "-" + tBkrsr.Substring(4, 2) + "-" + tBkrsr.Substring(6, 2));
                    M_Q_sfz_temp.department = tBdepart;
                    if (tBstart.Length > 7)
                    {
                        M_Q_sfz_temp.startdate = DateTime.Parse(tBstart.Substring(0, 4) + "-" + tBstart.Substring(4, 2) + "-" + tBstart.Substring(6, 2));
                    }
                    else
                    {
                        M_Q_sfz_temp.startdate = DateTime.Parse(common_file.common_app.cssj);
                    }
                    if (tBend.Length > 8)//注意:这个字段有个可能是:长期  这样一个值,不一这下是时间
                    {
                        M_Q_sfz_temp.enddate = DateTime.Parse(tBend.Substring(0, 4) + "-" + tBend.Substring(4, 2) + "-" + tBend.Substring(6, 2));
                    }
                    else
                    {
                        M_Q_sfz_temp.enddate = DateTime.Parse(common_file.common_app.cssj);
                    }
                    M_Q_sfz_temp.krxp = imakrxp;
                    B_Q_sfz_temp.Add(M_Q_sfz_temp);
                }
            }
            return result_0;
        }


        public void get_add(ref TextBox tBadd)
        {
            StringBuilder szAddress = new StringBuilder();
            int i = GetPeopleAddress(szAddress, AddrLen);
            tBadd.Text = szAddress.ToString();
            for (int j_0 = 0; j_0 < 150; j_0++)
            {
                try
                {
                    szAddress.Remove(j_0, 1);
                }
                catch
                { }
                finally
                { }
            }
        }




    }
}
