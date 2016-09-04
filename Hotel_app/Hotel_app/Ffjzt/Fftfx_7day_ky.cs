using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    class Fftfx_7day_ky
    {


        string hj_value = "合计";
        public void add_7day_ky(string yydh, string qymc, BLL.Common B_Common, string czy, string Table_name)
        {
            common_file.common_app.get_czsj();
            string insert_s = "delete from " + Table_name + " where czy='" + czy + "'";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,frhj,czy) select '" + yydh + "','" + qymc + "',fjrb,count(id),'" + czy + "' from Ffjzt group by fjrb";
            B_Common.ExecuteSql(insert_s);
            insert_s = "insert into " + Table_name + " (yydh,qymc,zyzt,frhj,czy)  select '" + yydh + "','" + qymc + "','" + hj_value + "',count(id),'" + czy + "' from Ffjzt";
            B_Common.ExecuteSql(insert_s);
            insert_s = "update " + Table_name + " set fx_value_yl_1=0,fx_value_1=frhj,fx_value_yl_2=0,fx_value_2=frhj,fx_value_yl_3=0,fx_value_3=frhj,fx_value_yl_4=0,fx_value_4=frhj,fx_value_yl_5=0,fx_value_5=frhj,fx_value_yl_6=0,fx_value_6=frhj,fx_value_yl_7=0,fx_value_7=frhj";
            B_Common.ExecuteSql(insert_s);
            Cursor.Current = Cursors.Default;
        }

        public void update_record(BLL.Common B_Common, string yydh, string qymc, string czy, string colu_name, string update_value, string colu_name_yd, string update_value_yd, string update_cond, string Table_name)
        {
            common_file.common_app.get_czsj();
            string update_s = "update " + Table_name + " set " + colu_name + "='" + update_value + "'," + colu_name_yd + "='" + update_value_yd + "' where czy='" + czy + "'" + update_cond;
            B_Common.ExecuteSql(update_s);
            Cursor.Current = Cursors.Default;
        }

        public void set_ftfx_7day_ky(string yydh, string qymc, BLL.Common B_Common, string czy, DateTime rq, DateTime czsj, string colu_name, string colu_name_yd, string Table_name, String sel_cond_bhwx)
        {
            common_file.common_app.get_czsj();
            DataSet DS_temp = B_Common.GetList("select fjrb,count(id) as fs from Ffjzt", "id>=0 group by fjrb");
            int j_0 = 0;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                string[] args_fjrb = new string[DS_temp.Tables[0].Rows.Count + 1];
                float[] args_fs = new float[DS_temp.Tables[0].Rows.Count + 1];
                float[] args_fs_yl = new float[DS_temp.Tables[0].Rows.Count + 1];
                float hj_fs = 0;
                float hj_fs_yl = 0;
                for (j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {
                    common_file.common_app.get_czsj();
                    args_fjrb[j_0] = DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString();
                    args_fs_yl[j_0] = 0;
                    args_fs[j_0] = 0;
                    //int.Parse(Math.Math.Floor(float.Parse(DS_temp.Tables[0].Rows[j_0]["fs"].ToString())));
                    //总房数、可用房数，维修房数，预订在住房数，预订在住人数，
                    float zfs_0 = 1;
                    float kyfs = 0;
                    float yd_zz_zy = 0;
                    float yd_zz_rs = 0;
                    float wx_other_zy = 0;

                    //为了能实现下面的维修其他的再次分析，在以下的分析里先把common_file.common_app.is_contain_wx直接为False
                    common_file.common_used_fjzt.get_zyfs_fx(DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), rq, false, ref yd_zz_zy, false, ref yd_zz_rs, ref wx_other_zy, ref zfs_0, ref kyfs);

                    DataSet DS_temp_0;


                    wx_other_zy = 0;
                    if (sel_cond_bhwx == common_Ffjzt.fsfx_zh_yd)
                    {

                        DS_temp_0 = B_Common.GetList("select count(id) as zyfs from Fwx_other", "id>=0 and (lksj>='" + rq.ToShortDateString() + "' and ddsj<'" + rq.ToShortDateString() + " 23:59:59" + "')" + "and fjrb='" + DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString() + "'");

                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            wx_other_zy = float.Parse(DS_temp_0.Tables[0].Rows[0]["zyfs"].ToString());

                        }
                    }


                    args_fs[j_0] = kyfs + wx_other_zy;

                    hj_fs = hj_fs + kyfs;
                    //预计到店DS_temp = B_Common.GetList("select sum(lzfs) as lzfs  from Qskyd_fjrb", "fjrb='" + DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString() + "' and lksj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
                     DS_temp_0 = B_Common.GetList("select sum(lzfs) as lzfs  from Qskyd_fjrb", "fjrb='" + DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString() + "'  and fjrb<>'' and lzfs>0  and  lksj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        if (DS_temp_0.Tables[0].Rows[0]["lzfs"].ToString() != "")
                        {
                            string temp_0 = DS_temp_0.Tables[0].Rows[0]["lzfs"].ToString();
                            args_fs_yl[j_0] = float.Parse(temp_0);
                            hj_fs_yl = hj_fs_yl + float.Parse(temp_0);
                        }
                    }
                    //表示要包含维修和其他为可用


                    hj_fs = hj_fs + wx_other_zy;
                    DS_temp_0.Clear();
                    DS_temp_0.Dispose();


                }


                args_fjrb[j_0] = hj_value;
                args_fs[j_0] = hj_fs;
                args_fs_yl[j_0] = hj_fs_yl;




                DS_temp.Clear();
                DS_temp.Dispose();
                common_file.common_app.get_czsj();
                for (int i_0 = 0; i_0 < j_0 + 1; i_0++)
                {
                    update_record(B_Common, yydh, qymc, czy, colu_name, args_fs[i_0].ToString(), colu_name_yd, args_fs_yl[i_0].ToString(), " and zyzt='" + args_fjrb[i_0] + "'", Table_name);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        public void set_ftfx_7day_ky_app(string yydh, string qymc, string czy, DateTime start_rq, DateTime czsj, String sel_cond_bhwx)
        {
            common_file.common_app.get_czsj();
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string Table_name = "F_ftfx_7days_ky";
            add_7day_ky(yydh, qymc, B_Common, czy, Table_name);

            for (int i_0 = 1; i_0 < 8; i_0++)
            {
                set_ftfx_7day_ky(yydh, qymc, B_Common, czy, start_rq, DateTime.Now, "fx_value_" + i_0.ToString(), "fx_value_yl_" + i_0.ToString(), Table_name, sel_cond_bhwx);
                start_rq = start_rq.AddDays(1);
            }
            Cursor.Current = Cursors.Default;
        }



    }
}
