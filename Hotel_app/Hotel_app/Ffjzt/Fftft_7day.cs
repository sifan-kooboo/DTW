using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    class Fftft_7day
    {

        public void F_ftfx_7days_add(string yydh,string qymc,BLL.Common B_Common, string czy,string Table_name)
        {
            common_file.common_app.get_czsj();
            string insert_s = "";
            insert_s = "delete from "+Table_name+" where czy='"+czy+"'";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "总房数" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "维修房" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "其他房" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            common_file.common_app.get_czsj();
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "可租房数" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "预计离店" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "预计到店" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "当日抵离" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "占用房数" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            common_file.common_app.get_czsj();
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "在店人数" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "出租率" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "预计房费" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "平均房价" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            common_file.common_app.get_czsj();
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "预计散客" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "预计团体" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "预计会议" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,czy) values ('" + yydh + "','" + qymc + "','" + "可用房数" + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);
            Cursor.Current = Cursors.Default;
        
        }
        public void update_record(BLL.Common B_Common, string yydh,string qymc,string czy,string update_value, string update_cond,string Table_name,string colu_name)
        {
            
            string update_s = "update "+Table_name+" set "+colu_name+"='"+update_value+"' where czy='"+czy+"'"+update_cond;
            B_Common.ExecuteSql(update_s);
        }
        public void set_7day(string yydh, string qymc, BLL.Common B_Common,DateTime rq, string czy, DateTime czsj,string Table_name,string colu_name, string xxzs)
        {


            common_file.common_app.get_czsj();
           
            DataSet DS_temp;

            //F_ftfx_7days_add(yydh, qymc, B_Common, czy, "F_ftfx_7days");

            DS_temp= B_Common.GetList("select count(id) as zfs from Ffjzt", "id>=0");


            //总房数
            float zfs = 1;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zfs = float.Parse(DS_temp.Tables[0].Rows[0]["zfs"].ToString());
            }
            update_record(B_Common, yydh,qymc,czy,zfs.ToString(), " and zyzt='"+"总房数"+"'",Table_name,colu_name);
            //维修房
            float wxf = 0;
            DS_temp = B_Common.GetList("select count(*) as zfs from Fwx_other", "id>=0 and (ddsj<='" + rq.ToShortDateString() + " 23:59:59" + "' and lksj>='" + rq.ToShortDateString() + "') and zyzt='" + common_file.common_fjzt.wxf + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                wxf = float.Parse(DS_temp.Tables[0].Rows[0]["zfs"].ToString());
            }
            update_record(B_Common, yydh, qymc, czy, wxf.ToString(), " and zyzt='" + "维修房" + "'", Table_name, colu_name);
            //其他房
            float qtf = 0;
            DS_temp = B_Common.GetList("select count(*) as zfs from Fwx_other", "id>=0 and (ddsj<='" + rq.ToShortDateString() + " 23:59:59" + "' and lksj>='" + rq.ToShortDateString() + "') and zyzt='" + common_file.common_fjzt.qtf + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                qtf = float.Parse(DS_temp.Tables[0].Rows[0]["zfs"].ToString());
            }
            update_record(B_Common, yydh, qymc, czy, qtf.ToString(), " and zyzt='" + "其他房" + "'", Table_name, colu_name);
            //可租房数其他房
            float kzfs = 0;
            kzfs = zfs - wxf - qtf;
            Ffjzt.Fftfx_c Fftfx_c_new = new Fftfx_c();
            update_record(B_Common, yydh, qymc, czy, kzfs.ToString(), " and zyzt='" + "可租房数" + "'", Table_name, colu_name);
            //预计离店
            float yjld_fs = 0;
            float yjld_rs = 0;
            Fftfx_c_new.dr_fx_dd_lk_yjld(B_Common, DS_temp, ref yjld_fs, ref yjld_rs, rq);
            update_record(B_Common, yydh, qymc, czy, yjld_fs.ToString(), " and zyzt='" + "预计离店" + "'", Table_name, colu_name);
            //预计到店
            float yjdd_fs = 0;
            float yjdd_rs = 0;
            Fftfx_c_new.dr_fx_dd_lk_yjdd(B_Common, DS_temp, ref yjdd_fs, ref yjdd_rs, rq);
            update_record(B_Common, yydh, qymc, czy, yjdd_fs.ToString(), " and zyzt='" + "预计到店" + "'", Table_name, colu_name);
            //当日抵离
            float drdl_fs = 0;
            float drdl_rs = 0;
            Fftfx_c_new.dr_fx_dd_lk_drdl(B_Common, DS_temp, ref drdl_fs, ref drdl_rs, rq);
            update_record(B_Common, yydh, qymc, czy, drdl_fs.ToString(), " and zyzt='" + "当日抵离" + "'", Table_name, colu_name);
            common_file.common_app.get_czsj();
            //总房数、可用房数，维修房数，预订在住房数，预订在住人数，
            float zfs_0 = 1;
            float kyfs = 0;
            float yd_zz_zy = 0;
            float yd_zz_rs = 0;
            float wx_other_zy = 0;
            common_file.common_used_fjzt.get_zyfs_fx("", rq, common_file.common_app.is_contain_wx, ref yd_zz_zy, true, ref yd_zz_rs, ref wx_other_zy, ref zfs_0, ref kyfs);
            update_record(B_Common, yydh, qymc, czy, yd_zz_zy.ToString(), " and zyzt='" + "占用房数" + "'", Table_name, colu_name);
            update_record(B_Common, yydh, qymc, czy, yd_zz_rs.ToString(), " and zyzt='" + "在店人数" + "'", Table_name, colu_name);
            update_record(B_Common, yydh, qymc, czy, kyfs.ToString(), " and zyzt='" + "可用房数" + "'", Table_name, colu_name);
            common_file.common_app.get_czsj();
            //出租率
            string czl = Convert.ToString(Math.Floor(yd_zz_zy / zfs * 10000) / 100) + "%";
            update_record(B_Common, yydh, qymc, czy, czl, " and zyzt='" + "出租率" + "'", Table_name, colu_name);

            common_file.common_app.get_czsj();
            //预计房费
            float zzff = 0; float yjzff = 0;
            Fftfx_c_new.get_ff_app(yydh, qymc, czy, czsj, rq, xxzs, ref zzff, ref yjzff);
            update_record(B_Common, yydh, qymc, czy, yjzff.ToString(), " and zyzt='" + "预计房费" + "'", Table_name, colu_name);

            //平均房价
            if (yd_zz_zy == 0) { yd_zz_zy =float.Parse("1"); }
            string pjfj = Convert.ToString(common_file.common_sswl.Round_sswl(double.Parse(Convert.ToString(yjzff / yd_zz_zy)), 0, common_file.common_sswl.selectMode_sel));
            update_record(B_Common, yydh, qymc, czy, pjfj, " and zyzt='" + "平均房价" + "'", Table_name, colu_name);
            //if (yd_zz_zy == float.Parse("1")) { yd_zz_zy = 0; }
            DS_temp = B_Common.GetList("select sktt,sum(lzfs) as fs from Qskyd_fjrb", "id>=0  and fjrb<>'' and lzfs>0 and (lksj>='" + rq.AddDays(1).ToShortDateString() + "' and ddsj<'" + rq.ToShortDateString() + " 23:59:59" + "') group by sktt");
            string get_value_sk = "";
            //散客
            get_sktt_fs(yydh, qymc, ref get_value_sk, rq, DS_temp, common_file.common_sktt.sktt_sk, zfs);
            update_record(B_Common, yydh, qymc, czy, get_value_sk, " and zyzt='" + "预计散客" + "'", Table_name, colu_name);
            string get_value_tt = "";
            common_file.common_app.get_czsj();
            //团体
            get_sktt_fs(yydh, qymc, ref get_value_tt, rq, DS_temp, common_file.common_sktt.sktt_tt, zfs);
            update_record(B_Common, yydh, qymc, czy, get_value_tt, " and zyzt='" + "预计团体" + "'", Table_name, colu_name);
            string get_value_hy = "";
            //会议
            get_sktt_fs(yydh, qymc, ref get_value_hy, rq, DS_temp, common_file.common_sktt.sktt_hy, zfs);
            update_record(B_Common, yydh, qymc, czy, get_value_hy, " and zyzt='" + "预计会议" + "'", Table_name, colu_name);
            Cursor.Current = Cursors.Default;
        }


        public void get_sktt_fs(string yydh, string qymc,ref string get_value,DateTime rq,DataSet DS_temp,string sktt,float zfs)
        {
            get_value = "";
            string czl = "0 %";
            float zyfs = 0;
            for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
            {
                if (DS_temp.Tables[0].Rows[j_0]["fs"].ToString() != "")
                {
                    if (DS_temp.Tables[0].Rows[j_0]["sktt"].ToString() == sktt)
                    {
                        zyfs = float.Parse(DS_temp.Tables[0].Rows[j_0]["fs"].ToString());
                        czl = Convert.ToString(Math.Floor(zyfs / zfs * 10000) / 100) + "%";
                        
                    }
                }
            }
            get_value = zyfs.ToString() + "   " + czl;
        }



        public void set_7day_app(string yydh, string qymc, DateTime start_rq, string czy, DateTime czsj,string xxzs)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            common_file.common_app.get_czsj();
            F_ftfx_7days_add(yydh, qymc, B_Common, czy, "F_ftfx_7days");
            for (int i_0 = 1; i_0 < 8; i_0++)
            {
                common_file.common_app.get_czsj();
                set_7day(yydh, qymc,B_Common, start_rq, czy, czsj, "F_ftfx_7days", "fx_value_" + i_0.ToString(), xxzs);
                start_rq=start_rq.AddDays(1);
            }
            Cursor.Current = Cursors.Default;
        }




    }
}
