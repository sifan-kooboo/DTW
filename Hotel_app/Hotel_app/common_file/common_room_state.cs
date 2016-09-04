using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
    public static class common_room_state
    {
        public static void room_state(control_user.UC_room_pic_0 UC_room_pic_0_temp, DataSet DS_fjbh_temp, int row_no)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + DS_fjbh_temp.Tables[0].Rows[row_no]["fjbh"].ToString() + "'");
            UC_room_pic_0_temp.MP_i_g_m_l_c = "";//用来判断入住、预订房间的占用类型-散客、团体、会议、长住、钟点 
            UC_room_pic_0_temp.MP_charge = "";//房费
            UC_room_pic_0_temp.MP_room_clean = 0;//判断是否出现已洁房,1显示，其余不显示
            UC_room_pic_0_temp.MP_room_special = 0;//判断是否出现特殊要求房,1显示，其余不显示
            UC_room_pic_0_temp.MP_arrival = 0;//判断是否出现预抵房,1显示，其余不显示
            UC_room_pic_0_temp.MP_leaving = 0;//判断是否出现预离房,1显示，2显示超期，其余不显示
            UC_room_pic_0_temp.MP_room_union = 0;//判断是否出现联房,1显示，其余不显示
            UC_room_pic_0_temp.MP_room_VIP = 0;//判断是否出现VIP、回头客,1显示，其余不显示
            UC_room_pic_0_temp.MP_guestname = "";//客人名称

            string sktt_0 = "";
            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.gjf)
            {
                UC_room_pic_0_temp.MP_room_state = 1;
                room_state_yd(B_Common, DS_temp,UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zybz"].ToString() == common_fjzt.lszy)
                { UC_room_pic_0_temp.MP_lszy = 1; }
            }//"干净房"
            else
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zf)
                {
                    UC_room_pic_0_temp.MP_room_state = 2;
                    room_state_yj_zzzf(UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                    room_state_yd(B_Common, DS_temp, UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                    if (DS_fjbh_temp.Tables[0].Rows[row_no]["zybz"].ToString() == common_fjzt.lszy)
                    { UC_room_pic_0_temp.MP_lszy = 1; }
                }//"脏房";
                else
                    if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.wxf)
                    {
                        UC_room_pic_0_temp.MP_room_state = 3;
                        room_state_yd(B_Common, DS_temp, UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                    }//"维修房";
                    else
                        if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                        {
                            UC_room_pic_0_temp.MP_room_state = 5;
                            room_statei_g_m_l_c_(UC_room_pic_0_temp, sktt_0, row_no);////用来判断入住、预订房间的占用类型-散客、团体、会议、长住、钟点 
                            
                            //UC_room_pic_0_temp.MP_guestname = DS_fjbh_temp.Tables[0].Rows[row_no]["krxm"].ToString();
                            
                            

                            //设置房价

                            


                            DS_temp = B_Common.GetList("select * from View_Qskzd", " fjbh='" + DS_fjbh_temp.Tables[0].Rows[row_no]["fjbh"].ToString() + "' and yddj='" + common_yddj.yddj_dj + "'");
                            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                            {
                                sktt_0 = DS_temp.Tables[0].Rows[0]["sktt"].ToString();
                                DataSet DS_temp_0 = B_Common.GetList("select * from Qcounter","id>=0");
                                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                                {

                                    if (DS_fjbh_temp.Tables[0].Rows[row_no]["fjbm"].ToString() != "True")
                                    {
                                        if (DS_temp_0.Tables[0].Rows[0]["ft_xs_fjjg"].ToString() == "True")
                                        {
                                            UC_room_pic_0_temp.MP_charge = DS_temp.Tables[0].Rows[0]["fjjg"].ToString();
                                        }
                                    }
                                    if (DS_temp_0.Tables[0].Rows[0]["ft_xs_krxm"].ToString() == "True")
                                    {
                                        //客人名称原来在下面(115),目前移到这个位置,只在登记时才显示
                                        UC_room_pic_0_temp.MP_guestname = DS_temp.Tables[0].Rows[0]["krxm"].ToString(); ;//客人姓名
                                    }
                                }
                                DS_temp_0.Clear();
                                DS_temp_0.Dispose();
                            }



                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["shlf"].ToString() == "True")
                            {
                                UC_room_pic_0_temp.MP_room_union = 1;
                            }
                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["shts"].ToString() == "True")
                            {
                                UC_room_pic_0_temp.MP_room_special = 1;
                            }
                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["shvip"].ToString() == "True")
                            {
                                UC_room_pic_0_temp.MP_room_VIP = 1;
                            }

                            room_statei_g_m_l_c_(UC_room_pic_0_temp, sktt_0, row_no);

                            room_state_yj_zzzf(UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                            room_state_yd(B_Common, DS_temp, UC_room_pic_0_temp, DS_fjbh_temp, row_no);

                            if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["lksj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["lksj"].ToString()) < DateTime.Now.Date.AddDays(1))
                            {
                                UC_room_pic_0_temp.MP_leaving = 1;

                            }
                            else
                                if (DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["lksj"].ToString()) < DateTime.Now.Date)
                                { UC_room_pic_0_temp.MP_leaving = 2; }

                            

                        }//"在住房";
                        else
                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.qtf)
                            {
                                UC_room_pic_0_temp.MP_room_state = 4;

                            }//"其他房"; 

            //UC_room_pic_0_temp.MP_Border_select = 1;//边框颜色


            //客人姓名的原来位置
            //UC_room_pic_0_temp.MP_guestname = DS_fjbh_temp.Tables[0].Rows[row_no]["krxm"].ToString(); ;//客人姓名
            DS_temp.Clear();
            DS_temp.Dispose();

        }
        /// <summary>
        /// 判断是哪一种状态，I散客，G团体，M会议，L长住，C钟点
        /// </summary>
        /// <param name="UC_room_pic_0_temp"></param>
        /// <param name="DS_fjbh_temp"></param>
        /// <param name="row_no"></param>
        public static void room_statei_g_m_l_c_(control_user.UC_room_pic_0 UC_room_pic_0_temp, string sktt_0, int row_no)//用来判断入住、预订房间的占用类型-散客、团体、会议、长住、钟点 
        {
            if (sktt_0 == common_file.common_sktt.sktt_sk)
            {
                UC_room_pic_0_temp.MP_i_g_m_l_c = "In";
            }
            else
                if (sktt_0 == common_file.common_sktt.sktt_tt)
                { UC_room_pic_0_temp.MP_i_g_m_l_c = "Gr"; }
                else
                    if (sktt_0 == common_file.common_sktt.sktt_hy)
                    { UC_room_pic_0_temp.MP_i_g_m_l_c = "Me"; }
                    else
                        if (sktt_0 == common_file.common_sktt.sktt_cz)
                        { UC_room_pic_0_temp.MP_i_g_m_l_c = "Lo"; }
                        else
                            if (sktt_0 == common_file.common_sktt.sktt_zd)
                            { UC_room_pic_0_temp.MP_i_g_m_l_c = "Co"; }
        }
        /// <summary>
        /// 判断已洁房和在住脏房
        /// </summary>
        /// <param name="UC_room_pic_0_temp"></param>
        /// <param name="DS_fjbh_temp"></param>
        /// <param name="row_no"></param>
        public static void room_state_yj_zzzf(control_user.UC_room_pic_0 UC_room_pic_0_temp, DataSet DS_fjbh_temp, int row_no)//用来判断入住、预订房间的占用类型-散客、团体、会议、长住、钟点 
        {
            //脏房本来就是要打算的,不需要这个字段标识的
            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zzf )//|| DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zf)
            {
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zybz"].ToString() == common_file.common_fjzt.yjf)
                {
                    UC_room_pic_0_temp.MP_room_clean = 1;

                }
            }

        }
        /// <summary>
        /// 设置预订房
        /// </summary>
        /// <param name="UC_room_pic_0_temp"></param>
        /// <param name="DS_fjbh_temp"></param>
        /// <param name="row_no"></param>
        public static void room_state_yd(BLL.Common B_Common_0,DataSet DS_temp, control_user.UC_room_pic_0 UC_room_pic_0_temp, DataSet DS_fjbh_temp, int row_no)//用来判断入住、预订房间的占用类型-散客、团体、会议、长住、钟点 
        {
            string sktt_0 = "";
            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt_second"].ToString() == common_file.common_fjzt.ydf)
            {
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.gjf)
                {
                    UC_room_pic_0_temp.MP_room_state = 11;
                    if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString()) < DateTime.Now.Date.AddDays(1))
                    {
                        UC_room_pic_0_temp.MP_arrival = 1;

                    }

                }
                else
                    if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zf)
                    {
                        UC_room_pic_0_temp.MP_room_state = 21;
                        if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString()) < DateTime.Now.Date.AddDays(1))
                        {
                            UC_room_pic_0_temp.MP_arrival = 1;

                        }
                    }
                    else
                        if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.wxf)
                        {
                            UC_room_pic_0_temp.MP_room_state = 31;
                            if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString()) < DateTime.Now.Date.AddDays(1))
                            {
                                UC_room_pic_0_temp.MP_arrival = 1;

                            }
                        }
                        else
                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                            {
                                UC_room_pic_0_temp.MP_room_state = 51;
                                if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString()) < DateTime.Now.Date.AddDays(1))
                                {
                                    UC_room_pic_0_temp.MP_arrival = 1;

                                }
                            }
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() != common_file.common_fjzt.zzf)
                {
                    DS_temp = B_Common_0.GetList("select * from View_Qskzd", "fjbh='" + DS_fjbh_temp.Tables[0].Rows[row_no]["fjbh"].ToString() + "' and ddsj='" + DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString() + "' and  lksj='" + DS_fjbh_temp.Tables[0].Rows[row_no]["yd_lksj"].ToString() + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {


                        sktt_0 = DS_temp.Tables[0].Rows[0]["sktt"].ToString();
                        DataSet DS_temp_0 = B_Common_0.GetList("select * from Qcounter", "id>=0");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {

                            if (DS_temp_0.Tables[0].Rows[0]["ft_xs_fjjg"].ToString() == "True")
                            {
                                if (DS_fjbh_temp.Tables[0].Rows[row_no]["fjbm"].ToString() != "True")
                                {
                                    //设置房价
                                    UC_room_pic_0_temp.MP_charge = DS_temp.Tables[0].Rows[0]["fjjg"].ToString();
                                }
                            }
                            if (DS_temp_0.Tables[0].Rows[0]["ft_xs_krxm"].ToString() == "True")
                            {
                                //客人名称原来在下面(115),目前移到这个位置,只在登记时才显示
                                UC_room_pic_0_temp.MP_guestname = DS_temp.Tables[0].Rows[0]["krxm"].ToString(); ;//客人姓名
                            }
                        }
                        DS_temp_0.Clear();
                        DS_temp_0.Dispose();

                    }
                    room_statei_g_m_l_c_(UC_room_pic_0_temp, sktt_0, row_no);
                }
            }

        }

    }
}
