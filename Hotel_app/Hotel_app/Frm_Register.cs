using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;
using System.Management;

namespace Hotel_app
{
    public partial class Frm_Register : Form
    {
        public Frm_Register()
        {
            InitializeComponent();

        }

        public bool IsRegister { get; set; }

        private void b_next_Click(object sender, EventArgs e)
        {
            thCheckRegist2();
        }

        private void CheckRegist()
        {
            try
            {
                //打开注册表文件看是否有注册
                //RegistryKey retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("MThotelSoft").CreateSubKey("MThotelSoft.INI");
                RegistryKey retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE", true).OpenSubKey("MThotelSoft", true);
                if (retkey != null && retkey.SubKeyCount > 0)
                {
                    foreach (string strRNum in retkey.GetValueNames())//判断是否注册
                    {
                        string TempValue = retkey.GetValue(strRNum).ToString();
                        if (TempValue == Txt_RegisterKey.Text.Trim())//clsTools.getRNum())
                        {
                            //成功后写入时间以及更改学习正式版本和注册信息
                            try
                            {
                                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "RegisterKey", TempValue);//保存注册码
                                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "xxzs", common_file.common_app.xxzs_zs);//保存注册码
                                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "startTime", DateTime.Now.AddMinutes(-100).ToString());//保存注册码
                                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "endTime", DateTime.Now.AddDays(100).ToString());//保存注册码

                                IsRegister = true;
                                MessageBox.Show(this, "感谢您的注册,你当前可以使用100天。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show(this, "对不起,注册失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "对不起,没有找到注册信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                if (!IsRegister)
                {
                     MessageBox.Show("注册码错误");
                     return;
                }
            }
            catch 
            {
                        MessageBox.Show("注册码错误");
                        return;
                //打不开,说明根本没有注册,那么调用试用的界面
               // Thread th2 = new Thread(new ThreadStart(thCheckRegist2));
               // th2.Start();
            }
        }


        //获得CPU的序列号
        public static string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }


        public static string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"d:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>
        /// 验证试用次数
        /// </summary>
        private void thCheckRegist2()
        {
            MessageBox.Show("您现在使用的是试用版，该软件可以免费试用30次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Int32 tLong;
            Int32 lastTyeTime;
            try
            {
                tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\MThotelSoft", "UseTimes", 0);
                lastTyeTime=30-tLong;
                MessageBox.Show("感谢您已使用了" + tLong + "次,您还可以免费使用"+lastTyeTime, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\MThotelSoft", "UseTimes", 0, RegistryValueKind.DWord);
                MessageBox.Show("欢迎新用户使用本软件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\MThotelSoft", "UseTimes", 0);
            if (tLong < 30)
            {
                int Times = tLong + 1;
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\MThotelSoft", "UseTimes", Times);
                IsRegister = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("试用次数已到", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void b_getRegisterKey_Click(object sender, EventArgs e)
        {
            //调用注册码生成器来验证注册码是否正确
            if (Txt_RegisterKey.Text.Trim().Equals(""))
            {
                MessageBox.Show("请填写注册码");
                return;
            }
            //调用验证程序验证验证码是否合法
            string[] args = new string[4];
            args[0] =Txt_CpuID.Text.Trim();
            args[1] = Txt_DiskID.Text.Trim();
            args[2] = Txt_McKey.Text.Trim();
            args[3] = Txt_RegisterKey.Text.Trim();

            string argsString = args[0] + " " + args[1] + " " + args[2] + " " + args[3];
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "MT_Hotel_app_Console.exe");
                p.StartInfo.Arguments = argsString;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                string ss = p.StandardOutput.ReadToEnd();
                common_file.common_czjl.add_czjl("", "", "", ss, ss, ss, DateTime.Now);
                p.WaitForExit();
                //Process.Start(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "MT_Hotel_app_Console.exe"), argsString);
                //p.Kill();
                CheckRegist();
            }
            catch (Exception)
            {
                MessageBox.Show("注册失败!");
                this.Close();
            }
        }

        private void Frm_Register_Load(object sender, EventArgs e)
        {
            Txt_CpuID.Text = getCpu();
            Txt_DiskID.Text = GetDiskVolumeSerialNumber();
            Txt_McKey.Text = getCpu() + GetDiskVolumeSerialNumber();
        }

        private void b_getRegisterKey_Click_1(object sender, EventArgs e)
        {
            string url = common_file.common_app.service_url + "Register.aspx";
            string args = "?diskID=" + Txt_DiskID.Text.Trim() + "&cupID=" + Txt_CpuID.Text.Trim() + "&MachineID=" + Txt_McKey.Text;
            url += args;
            System.Diagnostics.Process.Start("IEXPLORE.EXE", url);
        }
    }
}
