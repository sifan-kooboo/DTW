using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Maticsoft.DBUtility;

namespace jdgl_res_head_app.common_file
{
   public static  class   common_sjtb
    {
        //系统登记时设置客户端与服务端的时间同步
        [DllImport("kernel32.dll")]
        private static extern bool SetLocalTime(ref SYSTEMTIME time);
        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            public short year;
            public short month;
            public short dayOfWeek;
            public short day;
            public short hour;
            public short minute;
            public short second;
            public short milliseconds;
        }

        public static void SetDate()
        {
            SYSTEMTIME st;
            DateTime dt =DateTime.Parse("1800-01-01  00:00:00");
            object obj = DbHelperSQL.GetSingle("  select  getDate()  ");
            if (obj != null)
            {
                dt = DateTime.Parse(obj.ToString());
            }
            st.year = (short)dt.Year;
            st.month = (short)dt.Month;
            st.dayOfWeek = (short)dt.DayOfWeek;
            st.day = (short)dt.Day;
            st.hour = (short)dt.Hour;
            st.minute = (short)dt.Minute;
            st.second = (short)dt.Second;
            st.milliseconds = (short)dt.Millisecond;

            SetLocalTime(ref st);
        }
    }
}
