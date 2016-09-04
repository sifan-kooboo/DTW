using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;

namespace Hotel_app
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //addSecurityPwd
            //Configuration config = ConfigurationManager.OpenExeConfiguration(Application.StartupPath + "\\Hotel_app.exe");
            ////config.AppSettings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            //config.ConnectionStrings.SectionInformation.ProtectSection(null);
            //config.Save(ConfigurationSaveMode.Full);
            //CheckDevAssemBlyInstall
            //try
            //{
            //    bool flage = false;
            //    if (common_file.Common_initalSystem.ReadXML("add", "isInstallDevAssembly").Equals("false"))
            //    {
            //        flage = common_file.common_app.InstallDevToGAC().Equals(common_file.common_app.get_suc);
            //        common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "isInstallDevAssembly", "true");
            //    }
            //    else
            //    {
            //        flage = true;
            //    }
            //    if (flage)
            //    {
            //        Application.Run(new Fmain());
            //    }
            //    else
            //    {

            //    }
            //}
            //catch
            //{
            //    common_file.common_app.Message_box_show("提示", "检测到您的电脑未安装本系统必需的插件,请点击确定,系统将自启动插件修复功能.....");
            //    if (common_file.common_app.InstallDevToGAC().Equals(common_file.common_app.get_suc))
            //    {
            //        MessageBox.Show("插件安装成功,请手动重启应用程序");

            //    }
            //}
            Application.Run(new Fmain());
        }
    }
}