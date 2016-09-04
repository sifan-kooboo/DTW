using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    class Q_temp_0
    {

        [DllImport("termb.dll")]
        private static extern int GetPeopleAddress(StringBuilder szAddress, int iLen);

        public void get_add(ref TextBox tBadd)
        {

            StringBuilder szAddress = new StringBuilder(70);
            for (int j_0 = 0; j_0 < 70; j_0++)
            {
                szAddress.Append("*");
            }
            int i = GetPeopleAddress(szAddress, 70);
            //common_file.common_app.Message_box_show("122",i.ToString()+ mychars.Length.ToString());
            //tBadd.Text = szAddress.ToString();
            //szAddress.Length = 0;
            //object[] args = new object[2];
            //args[0] = szAddress;
            //args[1] = 70;
            //Hotel_app.Qyddj.Q_temp_1.WinDllInvoke("termb.dll", "GetPeopleAddress", args, typeof(int));
            tBadd.Text = szAddress.ToString();


        }
    }
}
