using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
namespace Hotel_app.common_file
{
    /// <summary>
    /// 验证身份证用的
    /// </summary>
    class common_sfz
    {
        //验证身份证号
        public static bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }

            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }

            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");

            DateTime time = new DateTime();

            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }

            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');

            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');

            char[] Ai = Id.Remove(17).ToCharArray();

            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }

            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }

            return true;//符合GB11643-1999标准
        }

        private static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }

            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");

            DateTime time = new DateTime();

            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }

            return true;//符合15位身份证标准
        }

        //由身份证号码得到生日时间
        public static string GetBirthdateByIDCard(string IDCardNo)
        {
            string birthday = DateTime.Now.ToShortDateString();
            StringBuilder sb = new StringBuilder();
            sb.Append(IDCardNo.Substring(6, 4) + "-");
            sb.Append(IDCardNo.Substring(10, 2) + "-");
            sb.Append(IDCardNo.Substring(12, 2));
            return birthday = Convert.ToDateTime(sb.ToString()).ToShortDateString();
        }

        //由身份证号码得到个人相关信息
        public static void GetPersonInfo(string IDCardNo, out string out_IDCardNo, out string sr, out string xb, out string dz, out string jg)
        {
            sr = "1800-01-01";
            xb = "性别未知";
            dz = "";
            jg = "";
            out_IDCardNo = IDCardNo;
            if (IDCardNo.Length == 15 || IDCardNo.Length == 18)
            {
                string s_temp = "";
                try
                {
                    if (IDCardNo.Trim().Length == 18)
                    {
                        {
                            s_temp = IDCardNo.Substring(0, 17);
                            if (Maticsoft.Common.PageValidate.IsNumber(s_temp) == false)
                            {
                                common_app.Message_box_show(common_app.message_title, "对不起，身份证号码输入有误！");
                                //out_IDCardNo = "";
                                return;
                            }

                            //获取生日
                            string birthday = DateTime.Now.ToShortDateString();
                            StringBuilder sb = new StringBuilder();
                            sb.Append(IDCardNo.Substring(6, 4) + "-");
                            sb.Append(IDCardNo.Substring(10, 2) + "-");
                            sb.Append(IDCardNo.Substring(12, 2));
                            try
                            {
                                sr = Convert.ToDateTime(sb.ToString()).ToShortDateString();
                            }
                            catch (Exception)
                            {
                                common_app.Message_box_show(common_app.message_title, " 证件号码日期输入有误！");
                            }

                            //获取性别
                            xb = (int.Parse(IDCardNo.Substring(16, 1)) % 2 == 1) ? "男" : "女";
                        }
                        if (IDCardNo.Trim().Length == 15)
                        {
                            s_temp = IDCardNo.Substring(0, 15);
                            if (Maticsoft.Common.PageValidate.IsNumber(s_temp) == false)
                            {
                                common_app.Message_box_show(common_app.message_title, "对不起，身份证号码输入有误！");
                                //out_IDCardNo = "";
                                return;
                            }

                            //获取生日
                            string birthday = DateTime.Now.ToShortDateString();
                            StringBuilder sb = new StringBuilder();
                            sb.Append(IDCardNo.Substring(6, 2) + "-");
                            sb.Append(IDCardNo.Substring(8, 2) + "-");
                            sb.Append(IDCardNo.Substring(10, 2));
                            sr = Convert.ToDateTime(sb.ToString()).ToShortDateString();

                            //获取性别
                            xb = (int.Parse(IDCardNo.Substring(14, 1)) % 2 == 1) ? "男" : "女";
                        }
                        //获取地址和籍贯
                        GetValue(IDCardNo, ref  jg, ref  dz);
                    }
                    else
                    {
                        common_app.Message_box_show(common_app.message_title, "对不起，身份证号码输入有误！");
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        //引用SERVER端的
        //gj_dq---查询到的是客人身份证地址
        //
        private static void GetValue(string zjhm, ref string krjg,ref string krdz)
        {
            //421181198707130925
            //421181198504040831
            //身份证信息确定(省份，城市，地区)
            string gj_dq = ""; string gj_cs = ""; string gj_sf = "";
            if (zjhm.Trim() != "")
            {
                string gj_sf_temp = zjhm.Substring(0, 2);
                string gj_cs_temp = zjhm.Substring(2, 2);
                string gj_dq_temp = zjhm.Substring(4, 2);
                string sfzdm_temp = zjhm.Substring(0, 6);

                BLL.Xsfzdq B_Xsfzdq = new Hotel_app.BLL.Xsfzdq();
                BLL.Common B_common = new Hotel_app.BLL.Common();
                object string_temp = DbHelperSQL.GetSingle("SELECT  SFMC  FROM   Xsfzdq  where  sfdm='" + gj_sf_temp + "'");
                if (string_temp != null)
                {
                    gj_sf = string_temp.ToString();
                }
                string_temp = DbHelperSQL.GetSingle("SELECT  csmc  FROM   Xsfzdq  where  csdm='" + gj_cs_temp + "'  and  sfdm='" + gj_sf_temp + "'");
                if (string_temp != null)
                {
                    gj_cs = string_temp.ToString();
                    string_temp = DbHelperSQL.GetSingle("select sfzdq from Xsfzdq where  sfzdm='" + sfzdm_temp + "'");
                    if (string_temp != null)
                    {
                        gj_dq = string_temp.ToString();
                    }
                    else
                    {
                        gj_dq = "其它";
                    }
                }
                else
                {
                    gj_cs = "其它"; gj_dq = "其它";
                }
            }
            else
            {
                gj_sf = "其它"; gj_cs = "其它"; gj_dq = "其它";
            }


            //生成籍贯和地址返回
            if (gj_sf == "其它")
            {
                krdz = "";
                krjg = "";
            }
            else if (gj_cs == "其它")
            {
                krdz = gj_sf;
                krjg = gj_sf;
            }
            else if (gj_dq == "其它")
            {
                krdz = gj_sf + gj_cs;
                krjg = gj_sf + gj_cs;
            }
            else
            {
                krdz = gj_dq; krjg = gj_dq;
            }
            ////krgj确定pq
            //if (krgj.Trim() == "")
            //{ pq = "其它"; }
            //else
            //{
            //    object obj = DbHelperSQL.GetSingle("select  pq from Xkrgj  where krgj='" + krgj + "'  and yydh='" + yydh + "' ");
            //    if (obj != null)
            //    { pq = obj.ToString(); }
            //    else
            //    {
            //        pq = "其它";
            //    }
            //}
        }
    }
}
