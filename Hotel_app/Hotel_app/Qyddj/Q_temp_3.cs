using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    class Q_temp_3
    {

        //[DllImport("Sdtapi.dll")]

        //private static extern int InitComm(int iPort);//初始化


        [DllImport("termb.dll")]
        private static extern int InitComm(int iPort);


        //[DllImport("Sdtapi.dll")]

        //private static extern int Authenticate();//卡认证

        [DllImport("termb.dll")]
        private static extern int Authenticate();


        //[DllImport("Sdtapi.dll")]

        //private static extern int ReadBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder Folk, StringBuilder BirthDay, StringBuilder Code,StringBuilder Address, StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd);//读取数据，推荐使用



        [DllImport("termb.dll")]

        private static extern int ReadBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder Folk, StringBuilder BirthDay, StringBuilder Code,StringBuilder Address, StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd);//读取数据，推荐使用


        
        //[DllImport("Sdtapi.dll")]

        //private static extern int CloseComm();//关闭端口


        [DllImport("termb.dll")]
        private static extern int CloseComm();



        [DllImport("Sdtapi.dll")]

        private static extern int ReadBaseMsg(byte[] pMsg, ref int len);//读取数据，这里不用

        [DllImport("Sdtapi.dll")]

        private static extern int ReadBaseMsgW(byte[] pMsg, ref int len);//读取数据，这里不用

        [DllImport("kernel32.dll")]

        private static extern int Beep(int dwFreq, int dwDuration);//用来大吼一声

       //2、读卡方法

        private string[] arrys = null;//声明用来保存身份证信息的数组

        public void OnTimer()

        {

            StringBuilder Name = new StringBuilder(31);

            StringBuilder Gender = new StringBuilder(3);

            StringBuilder Folk = new StringBuilder(10);

            StringBuilder BirthDay = new StringBuilder(9);

            StringBuilder Code = new StringBuilder(19);

            StringBuilder Address = new StringBuilder(71);

            StringBuilder Agency = new StringBuilder(31);

            StringBuilder ExpireStart = new StringBuilder(9);

            StringBuilder ExpireEnd = new StringBuilder(9);

            //int len = 0;

            //string[] temp;

            char[] param = { '0' };

            byte[] pMsg = new byte[256];

            string[] baseinfo = new string[9];

 

            //打开端口

            int intOpenRet = InitComm(1001);

            if (intOpenRet != 1)

            {

                //SetText("阅读机具未连接", lblMsg);

                return;

            }

            //卡认证

            //int intReadRet = Authenticate();

            //if (intReadRet != 1)

            //{

            //    //SetText("卡认证失败", lblMsg);

            //    CloseComm();

            //    return;

            //}
            Authenticate();
            //ReadBaseInfos（推荐使用）

            int intReadBaseInfosRet = ReadBaseInfos(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd);

            if (intReadBaseInfosRet != 1)

            {

                //SetText("读卡失败", lblMsg);

                CloseComm();

                return;

            }

            Beep(2047, 200);

            arrys = new string[10];

            arrys[0] = Code.ToString().Trim();

            arrys[1] = Name.ToString().Trim();

            arrys[2] = Gender.ToString().Trim();

            arrys[3] = Folk.ToString().Trim();

            arrys[4] = BirthDay.ToString().Trim();

            arrys[5] = Address.ToString().Trim();

            arrys[6] = Agency.ToString().Trim();

            arrys[7] = ExpireStart.ToString().Trim();

            arrys[8] = ExpireEnd.ToString().Trim();

            arrys[9] = System.IO.Directory.GetCurrentDirectory() + "//photo.bmp";

            //SetText("读卡成功", lblMsg);

            //SetText("证件号码：" + Code.ToString(), label1);

            //SetText("姓名：" + Name.ToString(), label2);

            //SetText("性别：" + Gender.ToString(), label3);

            //SetText("民族：" + Folk.ToString(), label4);

            //SetText("出生日期：" + BirthDay.ToString(), label5);

            //SetText("地址：" + Address.ToString(), label6);

            //SetText("签发机关：" + Agency.ToString(), label7);

            //SetText("签发时间：" + ExpireStart.ToString(), label8);

            //SetText("有效截止时间：" + ExpireEnd.ToString(), label9);

            //SetImage("photo.bmp", pictureBox1);

            CloseComm();

        }





    }
}
