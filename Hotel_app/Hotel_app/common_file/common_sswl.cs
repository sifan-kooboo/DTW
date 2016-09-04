using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
    public static class common_sswl
    {


        public static int sswl_ws = 1;//四舍五入位数

        public static string selectMode_normal = "normal";//正常四舍五入
        public static string selectMode_Add = "Add";//向上加四舍五入
        public static string selectMode_subtraction = "subtraction";//向下减四舍五入

        public static string selectMode_sel = selectMode_normal;

        public static double Round_sswl(double v, int x, string selectMode)
        {
            if ((!v.ToString().Contains(".")) || (v.ToString().Contains(".") && v.ToString().Split(new char[] { '.' })[1].Length <= x))
            {
                return v;
            }
            bool isNegative = false;        //如果是负数 
            if (v < 0)
            {

                isNegative = true; v = -v;

            }

            int IValue = 1;

            for (int i = 1; i <= x; i++)
            {

                IValue = IValue * 10;

            }
            double Int = 1;
            if (selectMode == "normal")//正常的四舍五入
            { Int = Math.Floor(v * IValue + 0.5); }

            //--只增
            if (selectMode == "Add")
            { Int = Math.Round(v * IValue + 0.5, 0); }

            //只减
            if (selectMode == "subtraction")
            { Int = Math.Round(v * IValue - 0.5, 0); }

            v = Int / IValue;

            if (isNegative)
            {

                v = -v;

            }

            return v;
        }




    }
}
