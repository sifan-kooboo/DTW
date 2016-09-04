using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Hotel_app.Hhygl
{
    class H_hygl_k
    {
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //外部函数声明：让设备发出声响
        [DllImport("OUR_MIFARE.dll", EntryPoint = "pcdbeep")]
        static extern byte pcdbeep(ulong xms);//xms单位为毫秒 
        //------------------------------------------------------------------------------------------------------------------------------------------------------    
        //读取设备编号，可做为软件加密狗用,也可以根据此编号在公司网站上查询保修期限
        [DllImport("OUR_MIFARE.dll", EntryPoint = "pcdgetdevicenumber")]
        static extern byte pcdgetdevicenumber(byte[] devicenumber);//devicenumber用于返回编号 
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //轻松读卡
        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccreadex")]
        static extern byte piccreadex(byte ctrlword, byte[] serial, byte area, byte keyA1B0, byte[] picckey, byte[] piccdata0_2);
        //参数：说明
        //ctrlword：控制字
        //serial：卡序列号数组，用于指定或返回卡序列号
        //area：指定读卡区号
        //keyA1B0：指定用A或B密码认证,一般是用A密码，只有特殊用途下才用B密码，在这不做详细解释。
        //picckey：指定卡密码，6个字节，卡出厂时的初始密码为6个0xff
        //piccdata0_2：用于返回卡该区第0块到第2块的数据，共48个字节.
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //轻松写卡
        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccwriteex")]
        static extern byte piccwriteex(byte ctrlword, byte[] serial, byte area, byte keyA1B0, byte[] picckey, byte[] piccdata0_2);
        //参数：说明
        //ctrlword：控制字
        //serial：卡序列号数组，用于指定或返回卡序列号
        //area：指定读卡区号
        //keyA1B0：指定用A或B密码认证,一般是用A密码，只有特殊用途下才用B密码，在这不做详细解释。
        //picckey：指定卡密码，6个字节，卡出厂时的初始密码为6个0xff
        //piccdata0_2：用于返回卡该区第0块到第2块的数据，共48个字节.
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //修改卡单区的密码
        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccchangesinglekey")]
        static extern byte piccchangesinglekey(byte ctrlword, byte[] serial, byte area, byte keyA1B0, byte[] piccoldkey, byte[] piccnewkey);
        //参数：说明
        //ctrlword：控制字
        //serial：卡序列号数组，用于指定或返回卡序列号
        //area：指定读卡区号
        //keyA1B0：指定用A或B密码认证,一般是用A密码，只有特殊用途下才用B密码，在这不做详细解释。
        //piccoldkey：//旧密码
        //piccnewkey：//新密码.
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //发送显示内容到读卡器
        [DllImport("OUR_MIFARE.dll", EntryPoint = "lcddispfull")]
        static extern byte lcddispfull(string lcdstr);
        //参数：说明
        //lcdstr：显示内容
        public const byte BLOCK0_EN = 0x01;//操作第0块
        public const byte BLOCK1_EN = 0x02;//操作第1块
        public const byte BLOCK2_EN = 0x04;//操作第2块
        public const byte NEEDSERIAL = 0x08;//仅对指定序列号的卡操作
        public const byte EXTERNKEY = 0x10;
        string s = "0";
        //变成、转换ASII码
        public void get_write_asii()
        {
            // UTF-16字符串
            string MyString = "Hello World";
            ASCIIEncoding AE1 = new ASCIIEncoding();
            byte[] ByteArray1 = AE1.GetBytes(MyString);
            //打印出ASCII码
            for (int x = 0; x <= ByteArray1.Length - 1; x++)
            {
                Console.Write("{0} ", ByteArray1[x]);
            }
            Console.Write("\n");
            //把ASCII码转化为对应的字符
            ASCIIEncoding AE2 = new ASCIIEncoding();
            byte[] ByteArray2 = { 72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100 };
            char[] CharArray = AE2.GetChars(ByteArray2);
            for (int x = 0; x <= CharArray.Length - 1; x++)
            {
                Console.Write(CharArray[x]);
            }
            Console.Write("\n");
        }
        public void write_hykh(string hykh)
        {
            byte i;
            byte status;//存放返回值
            byte myareano;//区号
            byte authmode;//密码类型，用A密码或B密码
            byte myctrlword;//控制字
            byte[] mypicckey = new byte[6];//密码
            byte[] mypiccserial = new byte[4];//卡序列号
            byte[] mypiccdata = new byte[48]; //卡数据缓冲
            string strls = hykh;
            //控制字指定,控制字的含义请查看本公司网站提供的动态库说明
            myctrlword = BLOCK0_EN + BLOCK1_EN + BLOCK2_EN + EXTERNKEY;
            //指定区号
            myareano = 8;//指定为第8区
            //批定密码模式
            authmode = 1;//大于0表示用A密码认证，推荐用A密码认证
            //指定密码
            mypicckey[0] = 0xff;
            mypicckey[1] = 0xff;
            mypicckey[2] = 0xff;
            mypicckey[3] = 0xff;
            mypicckey[4] = 0xff;
            mypicckey[5] = 0xff;
            //汉字编码解析
            ASCIIEncoding AE1 = new ASCIIEncoding();
            byte[] ByteArray1 = AE1.GetBytes(hykh);
            for (i = 0; i < 48; i++)
            {
                mypiccdata[i] = 0;
            }
            //指定卡数据
            for (i = 0; i < ByteArray1.Length; i++)
            {
                mypiccdata[i] = ByteArray1[i];
            }
            status = piccwriteex(myctrlword, mypiccserial, myareano, authmode, mypicckey, mypiccdata);
            //在下面设定断点，然后查看mypiccserial、mypiccdata，
            //调用完 piccreadex函数可读出卡序列号到 mypiccserial，读出卡数据到mypiccdata，
            //开发人员根据自己的需要处理mypiccserial、mypiccdata 中的数据了。
            //处理返回函数
            switch (status)
            {
                case 0:
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "写卡成功!");
                    break;
                //......
                case 8:
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请将卡放在感应区!");
                    break;

                default:
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "写卡错误，请确认是否有连接好设备！再不行请联系电脑工程师!");
                    break;
            }
        }
        public string  get_hykh()
        {
            string hykh = "";
            byte i;
            byte status;//存放返回值
            byte myareano;//区号
            byte authmode;//密码类型，用A密码或B密码
            byte myctrlword;//控制字
            byte[] mypicckey = new byte[6];//密码
            byte[] mypiccserial = new byte[4];//卡序列号
            byte[] mypiccdata = new byte[48]; //卡数据缓冲
            string strls = hykh;
            //控制字指定,控制字的含义请查看本公司网站提供的动态库说明
            myctrlword = BLOCK0_EN + BLOCK1_EN + BLOCK2_EN + EXTERNKEY;
            //指定区号
            myareano = 8;//指定为第8区
            //批定密码模式
            authmode = 1;//大于0表示用A密码认证，推荐用A密码认证
            //指定密码
            mypicckey[0] = 0xff;
            mypicckey[1] = 0xff;
            mypicckey[2] = 0xff;
            mypicckey[3] = 0xff;
            mypicckey[4] = 0xff;
            mypicckey[5] = 0xff;
            status = piccreadex(myctrlword, mypiccserial, myareano, authmode, mypicckey, mypiccdata);
            //在下面设定断点，然后查看mypiccserial、mypiccdata，
            //调用完 piccreadex函数可读出卡序列号到 mypiccserial，读出卡数据到mypiccdata，
            //开发人员根据自己的需要处理mypiccserial、mypiccdata 中的数据了。
            //处理返回函数
            switch (status)
            {
                case 0:
                    //把ASCII码转化为对应的字符
                    ASCIIEncoding AE2 = new ASCIIEncoding();
                    byte[] ByteArray2 = mypiccdata;
                    //char[] CharArray = AE2.GetChars(ByteArray2);
                    //string s_1 = new string(CharArray);
                    //hykh = s_1;
                    string s2 = AE2.GetString(ByteArray2,0,48);
                    hykh = s2;
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "读卡成功!");
                    break;
                //......
                case 8:
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请将卡放在感应区!");
                    break;

                default :
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "写卡错误，请确认是否有连接好设备！再不行请联系电脑工程师!");
                    break;
            }
            return hykh;
        }
        public void add_hy_info(string hykh_bz_input,bool shdk,ref TextBox TB_hykh_bz, ref string hyrx,ref string hykh, ref TextBox TB_krxm, ref TextBox TB_krgj, ref TextBox TB_yxzj, ref TextBox TB_zjhm, ref TextBox TB_krmz, ref ComboBox CB_krxb, ref DateTimePicker DT_krsr, ref TextBox TB_krdh, ref TextBox TB_krsj, ref TextBox TB_krEmail, ref TextBox TB_krdz, ref TextBox TB_krzy, ref TextBox TB_krdw, ref TextBox TB_qzrx, ref TextBox TB_qzhm, ref DateTimePicker DT_zjyxq, ref DateTimePicker DT_tlyxq,ref DateTimePicker DT_tjrq,ref TextBox TB_lzka)
        {
            string hykh_bz ="";
            if (shdk == true)
            {
                hykh_bz = get_hykh();
            }
            else 
            {
                hykh_bz = hykh_bz_input;
            }
            if (hykh_bz != "")
            { 
                BLL.Common B_Common=new Hotel_app.BLL.Common();
                DataSet DS_temp = B_Common.GetList("select * from Hhygl","hykh_bz='"+hykh_bz+"'  and  shqr=1");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                { 
                    TB_hykh_bz.Text=DS_temp.Tables[0].Rows[0]["hykh_bz"].ToString();
                    hykh = DS_temp.Tables[0].Rows[0]["hykh"].ToString();
                    hyrx=DS_temp.Tables[0].Rows[0]["hyrx"].ToString();
                    TB_krxm.Text=DS_temp.Tables[0].Rows[0]["krxm"].ToString();
                    TB_krgj.Text=DS_temp.Tables[0].Rows[0]["krgj"].ToString();
                    TB_yxzj.Text=DS_temp.Tables[0].Rows[0]["yxzj"].ToString(); 
                    TB_zjhm.Text=DS_temp.Tables[0].Rows[0]["zjhm"].ToString();
                    TB_krmz.Text=DS_temp.Tables[0].Rows[0]["krmz"].ToString(); 
                    CB_krxb.Text=DS_temp.Tables[0].Rows[0]["krxb"].ToString(); 
                    DT_krsr.Value=DateTime.Parse(DS_temp.Tables[0].Rows[0]["krsr"].ToString());
                    TB_krdh.Text=DS_temp.Tables[0].Rows[0]["krdh"].ToString(); 
                    TB_krsj.Text=DS_temp.Tables[0].Rows[0]["krsj"].ToString();
                    TB_krEmail.Text=DS_temp.Tables[0].Rows[0]["krEmail"].ToString(); 
                    TB_krdz.Text=DS_temp.Tables[0].Rows[0]["krdz"].ToString(); 
                    TB_krzy.Text=DS_temp.Tables[0].Rows[0]["krzy"].ToString(); 
                    TB_krdw.Text=DS_temp.Tables[0].Rows[0]["krdw"].ToString();
                    TB_qzrx.Text=DS_temp.Tables[0].Rows[0]["qzrx"].ToString(); 
                    TB_qzhm.Text=DS_temp.Tables[0].Rows[0]["qzhm"].ToString(); 
                    DT_zjyxq.Value=DateTime.Parse(DS_temp.Tables[0].Rows[0]["zjyxq"].ToString());
                    DT_tlyxq.Value=DateTime.Parse(DS_temp.Tables[0].Rows[0]["tlyxq"].ToString());
                    DT_tjrq.Value=DateTime.Parse(DS_temp.Tables[0].Rows[0]["tjrq"].ToString());
                    TB_lzka.Text = DS_temp.Tables[0].Rows[0]["lzka"].ToString();
                }
            }
        }
        public void add_hy_info_01(string hykh_bz_input, bool shdk, ref TextBox TB_hykh_bz, ref TextBox TB_hyrx, ref TextBox TB_krxm,ref TextBox TB_hyjf)
        {
            string hykh_bz = "";
            if (shdk == true)
            {
                hykh_bz = get_hykh();
            }
            else
            {
                hykh_bz = hykh_bz_input;
            }
            if (hykh_bz != "")
            {
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                DataSet DS_temp = B_Common.GetList("select * from Hhygl", "hykh_bz='" + hykh_bz + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    TB_hykh_bz.Text = DS_temp.Tables[0].Rows[0]["hykh_bz"].ToString();
                    TB_krxm.Text = DS_temp.Tables[0].Rows[0]["krxm"].ToString();
                    TB_hyrx.Text = DS_temp.Tables[0].Rows[0]["hyrx"].ToString();
                    TB_hyjf.Text = common_file.common_hy.SumJF(DS_temp.Tables[0].Rows[0]["hykh"].ToString()).ToString() ;
                }
            }
        }
        public void add_hy_info_02(string hykh_bz_input, bool shdk, ref TextBox TB_hykh_bz)
        {
            string hykh_bz = "";
            if (shdk == true)
            {
                hykh_bz = get_hykh();
            }
            else
            {
                hykh_bz = hykh_bz_input;
            }
            if (hykh_bz != "")
            {
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                DataSet DS_temp = B_Common.GetList("select * from Hhygl", "hykh_bz='" + hykh_bz + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    TB_hykh_bz.Text = DS_temp.Tables[0].Rows[0]["hykh_bz"].ToString();
                }
            }
        }
    }
}
