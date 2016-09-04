using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
    //public partial class Common_Hook
    //{
    //    // 取得当前线程编号
    //    [DllImport("kernel32")]
    //    public static extern int GetCurrentThreadId();
    //    // 安装钩子
    //    [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    //    public static extern int SetWindowsHookEx(HookType idHook, HOOKPROC lpfn, int hmod, int dwThreadId);
    //    // 继续下一个钩子
    //    [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    //    public static extern int CallNextHookEx(int idHook, int nCode, int wParam, int lParam);
    //    // 卸载钩子
    //    [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    //    public static extern bool UnHookWindowsHookEx(int hhk);

    //    public enum HookType
    //    {
    //        WH_KEYBOARD = 2
    //    }

    //    public delegate int HOOKPROC(int nCode, int wParam, int lParam);

    //    public static int hKeyboardHook = 0;//如果hKeyboardHook不为0则说明钩子安装成功


    //    public void SetHook()
    //    {
    //        // set the keyboard hook 
    //        hKeyboardHook = SetWindowsHookEx(HookType.WH_KEYBOARD, new HOOKPROC(this.MyKeyboardProc), 0, GetCurrentThreadId());
    //    }

    //    public int MyKeyboardProc(int nCode, int wParam, int lParam)
    //    {
    //        //在这里放置你的处理代码
    //        int iresult = 0;
    //        if (nCode <= 0)
    //        {
    //            iresult = CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
    //            return iresult;
    //        }
    //        if ((wParam >= 48 && wParam <= 57) || (wParam >= 65 && wParam <= 90) || (wParam >= 97 && wParam <= 122))
    //        {
    //            //Form1.rrrr += Convert.ToChar(wParam);
    //            return 0;
    //        }

    //        return 0;
    //    }
    //    public bool UnHook()
    //    {
    //        return UnHookWindowsHookEx(hKeyboardHook);
    //    }







    //}
    public partial class Common_Hook
    {
        [Flags()]
        public enum KeyModifiers
        { None = 0, Alt = 1, Control = 2, Shift = 4, Windows = 8 }
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, // handle to window                
            int id,            // hot key identifier                
            KeyModifiers fsModifiers,  // key-modifier options                
            Keys vk            // virtual-key code            
            );
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,  // handle to window                
            int id      // hot key identifier            
            ); 
    }
}
