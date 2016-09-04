using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace Hotel_app.update
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

        public static string message_title = "系统工程师提醒您！";//信息题目;

        //自定义一个message_box.show
        public static bool message_box_show_select(string F_title, string content)
        {
            Message_box F_Message_box = new Message_box(F_title, content, 2);
            F_Message_box.TopMost = true;
            if (F_Message_box.ShowDialog() == DialogResult.Yes)
            {
                return true;
            }
            return false;

        }

        public static void Message_box_show(string F_title, string content)
        {
            Message_box F_Message_box = new Message_box(F_title, content, 1);
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

            //当输入为0-9的数字、小数点、回车、负数符号和退格键时不阻止
            if (e.KeyChar == 13 || e.KeyChar == 45 || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
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


        public static void GetCurrentTime(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            dtp.Value = DateTime.Now;
        }

    }
}
