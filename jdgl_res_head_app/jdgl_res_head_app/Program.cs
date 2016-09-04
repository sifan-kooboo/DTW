using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace jdgl_res_head_app
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //避免同时运行两个相同的程序
            bool createdNew; //返回是否赋予了使用线程的互斥体初始所属权 
            System.Threading.Mutex instance = new System.Threading.Mutex(true, "F_main_S8", out createdNew); //同步基元变量 
            if (createdNew) //赋予了线程初始所属权，也就是首次使用互斥体 
            {
                Application.Run(new F_main_S8()); 
                instance.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("只允许运行一个上传应用程序！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        //应用程序出错自动重启
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Application.Restart();
        }
    }
}