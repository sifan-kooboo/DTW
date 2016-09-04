using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public class Fkfxsfx
    {


        public void find_column(int fjrb_arg_sl, string[] fjrb_arg, string yydh, string qymc, string fjrb, ref string zd_fs, ref string zd_ff)
        {
            for (int k_0 = 1; k_0 < (fjrb_arg_sl+1); k_0++)
            {
                if (fjrb_arg[k_0-1] == fjrb)
                {
                    zd_fs = "fjrb_fs_" + k_0.ToString();
                    zd_ff = "fjrb_fy_" + k_0.ToString();
                }
            }
        }

        public string get_update_cond(int fjrb_arg_sl, string[] fjrb_arg, DataSet DS_temp, string yydh, string qymc, ref float ljyyze, ref float ljlzfs)
        {
            string get_result = "";
            string zd_fs = "";
            string zd_ff = "";
            ljyyze = 0;
            ljlzfs = 0;



            for (int k_0 = 0; k_0 < DS_temp.Tables[0].Rows.Count; k_0++)
            {
                zd_fs = "";
                zd_ff = "";
                if (DS_temp.Tables[0].Rows[k_0]["fjrb"].ToString() != "")
                {
                    find_column(fjrb_arg_sl, fjrb_arg, yydh, qymc, DS_temp.Tables[0].Rows[k_0]["fjrb"].ToString(), ref   zd_fs, ref zd_ff);
                    if (DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() != "" && zd_ff != "")
                    {
                        get_result = get_result +","+zd_ff +"='" +float.Parse(DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString()) + "'";
                        ljyyze = ljyyze + float.Parse(DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString());
                    }
                    if (DS_temp.Tables[0].Rows[k_0]["xfsl"].ToString() != "" && zd_fs != "")
                    {
                        get_result = get_result + "," + zd_fs + "='" + float.Parse(DS_temp.Tables[0].Rows[k_0]["xfsl"].ToString()) + "'";
                        ljlzfs = ljlzfs + float.Parse(DS_temp.Tables[0].Rows[k_0]["xfsl"].ToString());
                    }
                }

            }
            return get_result;
        }

        //来源日分析
        public void update_contain(string yydh, string qymc, DataSet DS_temp, int i_0, BLL.Common B_Common, DataSet DS_temp_0, string table_name, DateTime cssj, DateTime jssj, int fjrb_arg_sl, string[] fjrb_arg, float zfs, float zyye, DateTime cssj_yf, DateTime cssj_year, string fx_cond)
        {
            string update_s = "";
            update_s = "krly=krly";
            string sql_s = "";

            //if(krly_if==true)

            //

            //{
            DS_temp_0 = B_Common.GetList("select fjrb,sum(sjxfje) as sjxfje,sum(xfsl) as xfsl from " + table_name, "yydh='" + yydh + "' and xfdr!='" + Szwgl.common_zw.dr_ds + "' and xfdr='" + Szwgl.common_zw.dr_ff + "'  " + fx_cond + "  and (xfsj between '" + cssj + "' and '" + jssj + "') group by fjrb");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                float ljyyze = 0; float ljlzfs = 0;
                update_s = update_s+get_update_cond(fjrb_arg_sl, fjrb_arg, DS_temp_0, yydh, qymc, ref  ljyyze, ref  ljlzfs);
                if (update_s != "")
                {
                    string pjfj_0 = "0";
                    string pjczl = "0%";
                    string pjbl = "0%";
                    string jcb = "0";
                    if (ljlzfs != 0)
                    {
                        pjfj_0 = Convert.ToString(Math.Floor(ljyyze / ljlzfs * 10) / 10);
                        pjczl = Convert.ToString(Math.Floor(ljlzfs / zfs * 10000) / 100) + "%";
                        pjbl = Convert.ToString(Math.Floor(ljyyze / zyye * 10000) / 100) + "%";
                        jcb = Convert.ToString(Math.Floor((ljyyze / ljlzfs) * (ljlzfs / zfs) * 10) / 10);
                    }
                    update_s = update_s + ",hj_r_fs='" + ljlzfs.ToString() + "',hj_r_fy='" + ljyyze.ToString() + "',pjfj='" + pjfj_0 + "',pjczl='" + pjczl + "',pjbl='" + pjbl + "',jcb='"+jcb+"'";

                }
            }


            //月份
            DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje,sum(xfsl) as xfsl from VS_syxfmx_cz", "yydh='" + yydh + "' and xfdr!='" + Szwgl.common_zw.dr_ds + "' and xfdr='" + Szwgl.common_zw.dr_ff + "'  " + fx_cond + " and (xfsj between '" + cssj_yf + "' and '" + jssj + "')");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    update_s = update_s + ",hj_y_fy='" +float.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString())+ "'";
                }
                if (DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString() != "")
                {
                    update_s = update_s + ",hj_y_fs='" + float.Parse(DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString()) + "'";
                }
            }
            //年份
            DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje,sum(xfsl) as xfsl from VS_syxfmx_cz", "yydh='" + yydh + "' and xfdr!='" + Szwgl.common_zw.dr_ds + "' and xfdr='" + Szwgl.common_zw.dr_ff + "'  " + fx_cond + " and (xfsj between '" + cssj_year + "' and '" + jssj + "')");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    update_s = update_s + ",hj_n_fy='" + float.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString()) + "'";
                }
                if (DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString() != "")
                {
                    update_s = update_s + ",hj_n_fs='" + float.Parse(DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString()) + "'";
                }
            }
            sql_s = "update F_kfxsfx set " + update_s + " where id='" + DS_temp.Tables[0].Rows[i_0]["id"].ToString() + "'";
            B_Common.ExecuteSql(sql_s);


            //}



        }


        //来源年、月分析

        public void update_contain_y_n(string yydh, string qymc, DataSet DS_temp, int i_0, BLL.Common B_Common, DataSet DS_temp_0, string table_name, DateTime cssj, DateTime jssj, int fjrb_arg_sl, string[] fjrb_arg, float zfs, float zyye, DateTime cssj_yf, DateTime cssj_year, string fx_cond)
        {
            string update_s = "";
            update_s = "krly=krly";
            string sql_s = "";

            DS_temp_0 = B_Common.GetList("select fjrb,sum(sjxfje) as sjxfje,sum(xfsl) as xfsl from VS_syxfmx_cz", "yydh='" + yydh + "' and xfdr!='" + Szwgl.common_zw.dr_ds + "' and xfdr='" + Szwgl.common_zw.dr_ff + "'  " + fx_cond + " group by fjrb");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                float ljyyze = 0; float ljlzfs = 0;
                update_s = update_s+get_update_cond(fjrb_arg_sl, fjrb_arg, DS_temp_0, yydh, qymc, ref  ljyyze, ref  ljlzfs);
                if (update_s != "")
                {
                    string pjfj_0 = "0";
                    string pjczl = "0%";
                    string pjbl = "0%";
                    if (ljlzfs != 0)
                    {
                        pjfj_0 = Convert.ToString(Math.Floor(ljyyze / ljlzfs * 10) / 10);
                        pjczl = Convert.ToString(Math.Floor(ljlzfs / zfs * 10000) / 100) + "%";
                        pjbl = Convert.ToString(Math.Floor(ljyyze / zyye * 10000) / 100) + "%";
                    }
                    update_s = update_s + ",hj_r_fs='" + ljlzfs.ToString() + "',hj_r_fy='" + ljyyze.ToString() + "',pjfj='',pjczl='',pjbl='',hj_y_fy='',hj_y_fs='',hj_n_fy='',hj_n_fs='',jcb=''";

                }
            }


            sql_s = "update F_kfxsfx set " + update_s + " where id='" + DS_temp.Tables[0].Rows[i_0]["id"].ToString() + "'";
            B_Common.ExecuteSql(sql_s);


            //}



        }





        public int F_ftxsfx(string yydh, string qymc, DateTime fxrq, string czy)
        {
            //返回多少个房型涉及到多少个字段
            common_file.common_app.get_czsj();
            int get_result = 0;
            string sql_s = "";
            string table_name = "VS_syxfmx_cz";
            DateTime cssj_year = Convert.ToDateTime(fxrq.Year.ToString() + "-01-01");

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            B_Common.ExecuteSql("delete from F_kfxsfx where czy_temp='"+czy+"'");
            DataSet DS_temp;
            int ybtqts = 0;
            DS_temp = B_Common.GetList("select ybtqts from Qcounter", " id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["ybtqts"].ToString() != "")
                {
                    ybtqts = int.Parse(DS_temp.Tables[0].Rows[0]["ybtqts"].ToString());
                }
            }


            DateTime cssj_yf = BBfx.common_bb.judge_yfcssj(fxrq, ybtqts);

            DateTime cssj = Convert.ToDateTime(fxrq.ToShortDateString());
            DateTime jssj = Convert.ToDateTime(fxrq.ToShortDateString() + " 23:59:59");
            DataSet DS_temp_0;



            //获取总房数
            float zfs = 1;
            DS_temp_0 = B_Common.GetList("select sum(zfs) as zfs from BSzhrbbfl", " yydh='" + yydh + "' and bbrq between '" + cssj + "' and '" + jssj + "'");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (DS_temp_0.Tables[0].Rows[0]["zfs"].ToString() != "")
                {
                    zfs = float.Parse(DS_temp_0.Tables[0].Rows[0]["zfs"].ToString());
                }
            }


            //获取营业额
            string sel_cond_0 = " yydh='" + yydh + "' and xfdr!='" + Szwgl.common_zw.dr_ds + "' and (xfsj between '" + cssj + "' and '" + jssj + "')";
            float zyye = 1;
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje from Ssyxfmx", sel_cond_0);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    zyye = float.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }
            }



            DS_temp_0 = B_Common.GetList("select fjrb from Ffjrb", "id>=0 order by id");
            DataSet DS_temp_1 = B_Common.GetList("select distinct fjrb from VS_syxfmx_cz", "id>=0 and fjrb!=''  and xfsj>='" + cssj_year.ToString() + "' and fjrb not in (select distinct fjrb from Ffjrb) order by fjrb");
            int fjrb_arg_sl = 0;
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                fjrb_arg_sl = fjrb_arg_sl + DS_temp_0.Tables[0].Rows.Count;
            }
            if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
            {
                fjrb_arg_sl = fjrb_arg_sl + DS_temp_1.Tables[0].Rows.Count;
            }
            if (fjrb_arg_sl > 0)
            {
                int i_0 = 0;
                string[] fjrb_arg = new string[fjrb_arg_sl];

                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                    {
                        fjrb_arg[i_0] = DS_temp_0.Tables[0].Rows[i_0]["fjrb"].ToString();
                    }
                }

                if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
                {
                    for (int j_0 = 1; j_0 < DS_temp_1.Tables[0].Rows.Count; j_0++)
                    {
                        fjrb_arg[j_0 + i_0] = DS_temp_1.Tables[0].Rows[j_0]["fjrb"].ToString();
                    }
                }
                sql_s = "";

                //获得房类数量
                get_result = fjrb_arg_sl;

                //string  sql_s_0 = "insert into Fkfxsfx (";
                string insert_cs = "yydh,qymc,krly";

                string insert_value = "'" + yydh + "','" + qymc + "',''";
                for (i_0 = 1; i_0 < fjrb_arg_sl + 1; i_0++)
                {
                    insert_cs = insert_cs + ",fjrb_fs_" + i_0.ToString() + ",fjrb_fy_" + i_0.ToString();
                    insert_value = insert_value + ",'" + fjrb_arg[i_0 - 1] + "','" + fjrb_arg[i_0 - 1] + "'";
                }

                insert_cs = insert_cs + ",hj_r_fs,hj_r_fy,hj_y_fs,hj_y_fy,hj_n_fs,hj_n_fy,pjczl,pjfj,pjbl,jcb,czy_temp";
                insert_value = insert_value + ",'本日合计','本日合计','本月累计','本月累计','本年累计','本年累计','出租率','平均房价','占比','交叉比','" + czy + "'";
                sql_s = "insert into F_kfxsfx (" + insert_cs + ") values (" + insert_value + ")";
                B_Common.ExecuteSql(sql_s);

                DS_temp_0 = B_Common.GetList("select krly from Xkrly", "id>=0 order by order_asc,krly");
                DS_temp_1 = B_Common.GetList("select distinct krly from VS_syxfmx_cz", "id>=0 and xfsj>='" + cssj_year.ToString() + "' and krly not in (select distinct krly from Xkrly) order by krly");
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                    {
                        insert_value = "'" + yydh + "','" + qymc + "','" + DS_temp_0.Tables[0].Rows[i_0]["krly"].ToString() + "'";
                        for (int k_0 = 0; k_0 < fjrb_arg_sl*2; k_0++)
                        {
                            insert_value = insert_value + ",'0'";
                        }
                        insert_value = insert_value + ",'0','0','0','0','0','0','0%','0','0%','0','" + czy + "'";
                        sql_s = "insert into F_kfxsfx (" + insert_cs + ") values (" + insert_value + ")";
                        B_Common.ExecuteSql(sql_s);
                    }
                }

                if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp_1.Tables[0].Rows.Count; i_0++)
                    {
                        insert_value = "'" + yydh + "','" + qymc + "','" + DS_temp_1.Tables[0].Rows[i_0]["krly"].ToString() + "'";
                        for (int k_0 = 0; k_0 < fjrb_arg_sl * 2; k_0++)
                        {
                            insert_value = insert_value + ",'0'";
                        }
                        insert_value = insert_value + ",'0','0','0','0','0','0','0%','0','0%','0','" + czy + "'";
                        sql_s = "insert into F_kfxsfx (" + insert_cs + ") values (" + insert_value + ")";
                        B_Common.ExecuteSql(sql_s);
                    }


                }

                insert_value = "'" + yydh + "','" + qymc + "','" + "逾时" + "'";
                for (int k_0 = 0; k_0 < fjrb_arg_sl * 2; k_0++)
                {
                    insert_value = insert_value + ",'0'";
                }
                insert_value = insert_value + ",'0','0','0','0','0','0','0%','0','0%','0','" + czy + "'";
                sql_s = "insert into F_kfxsfx (" + insert_cs + ") values (" + insert_value + ")";
                B_Common.ExecuteSql(sql_s);


                insert_value = "'" + yydh + "','" + qymc + "','" + "加床" + "'";
                for (int k_0 = 0; k_0 < fjrb_arg_sl * 2; k_0++)
                {
                    insert_value = insert_value + ",'0'";
                }
                insert_value = insert_value + ",'0','0','0','0','0','0','0%','0','0%','0','" + czy + "'";
                sql_s = "insert into F_kfxsfx (" + insert_cs + ") values (" + insert_value + ")";
                B_Common.ExecuteSql(sql_s);

                insert_value = "'" + yydh + "','" + qymc + "','" + "本日合计" + "'";
                for (int k_0 = 0; k_0 < fjrb_arg_sl * 2; k_0++)
                {
                    insert_value = insert_value + ",'0'";
                }
                insert_value = insert_value + ",'0','0','0','0','0','0','0%','0','0%','0','" + czy + "'";
                sql_s = "insert into F_kfxsfx (" + insert_cs + ") values (" + insert_value + ")";
                B_Common.ExecuteSql(sql_s);

                insert_value = "'" + yydh + "','" + qymc + "','" + "本月累计" + "'";
                for (int k_0 = 0; k_0 < fjrb_arg_sl * 2; k_0++)
                {
                    insert_value = insert_value + ",'0'";
                }
                insert_value = insert_value + ",'0','0','0','0','0','0','0%','0','0%','0','" + czy + "'";
                sql_s = "insert into F_kfxsfx (" + insert_cs + ") values (" + insert_value + ")";
                B_Common.ExecuteSql(sql_s);


                insert_value = "'" + yydh + "','" + qymc + "','" + "本年累计" + "'";
                for (int k_0 = 0; k_0 < fjrb_arg_sl * 2; k_0++)
                {
                    insert_value = insert_value + ",'0'";
                }
                insert_value = insert_value + ",'0','0','0','0','0','0','0%','0','0%','0','" + czy + "'";
                sql_s = "insert into F_kfxsfx (" + insert_cs + ") values (" + insert_value + ")";
                B_Common.ExecuteSql(sql_s);

                //修改数据

                //能找到客人来源的.



                DS_temp = B_Common.GetList("select id,krly,hj_r_fs from F_kfxsfx", " yydh='" + yydh + "' and czy_temp='" + czy + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {
                        //排除选到设置进去的表头.
                        if (DS_temp.Tables[0].Rows[i_0]["hj_r_fs"].ToString() != "本日合计" && DS_temp.Tables[0].Rows[i_0]["krly"].ToString() != "逾时" && DS_temp.Tables[0].Rows[i_0]["krly"].ToString() != "加床" && DS_temp.Tables[0].Rows[i_0]["krly"].ToString() != "本日合计" && DS_temp.Tables[0].Rows[i_0]["krly"].ToString() != "本月累计" && DS_temp.Tables[0].Rows[i_0]["krly"].ToString() != "本年累计")
                        {
                            update_contain(yydh, qymc, DS_temp, i_0, B_Common, DS_temp_0, table_name, cssj, jssj, fjrb_arg_sl, fjrb_arg, zfs, zyye, cssj_yf, cssj_year, "and (xfxm not in('" + Szwgl.common_zw.ff_jsbtfy + "','" + Szwgl.common_zw.ff_jsqtfy + "','" + Szwgl.common_zw.ff_jcfy + "')) and krly='" + DS_temp.Tables[0].Rows[i_0]["krly"].ToString() + "'");
                            //如果要分出单审的房费把这个启用，其余关闭
                            //update_contain(yydh, qymc, DS_temp, i_0, B_Common, DS_temp_0, table_name, cssj, jssj, fjrb_arg_sl, fjrb_arg, zfs, zyye, cssj_yf, cssj_year, "and (xfxm not in('" + Szwgl.common_zw.ff_jsbtfy + "','" + Szwgl.common_zw.ff_jsqtfy + "','" + Szwgl.common_zw.ff_sqff + "','" + Szwgl.common_zw.ff_jcfy + "')) and krly='" + DS_temp.Tables[0].Rows[i_0]["krly"].ToString() + "'");


                        }


                    }
                }



                //逾时的



                DS_temp = B_Common.GetList("select id,krly from F_kfxsfx", " yydh='" + yydh + "' and czy_temp='" + czy + "' and krly='" + "逾时" + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {


                        update_contain(yydh, qymc, DS_temp, i_0, B_Common, DS_temp_0, table_name, cssj, jssj, fjrb_arg_sl, fjrb_arg, zfs, zyye, cssj_yf, cssj_year, "and (xfxm in('" + Szwgl.common_zw.ff_jsbtfy + "','" + Szwgl.common_zw.ff_jsqtfy + "'))   ");
                        //如果要分出单审的房费把这个启用，其余关闭
                        //update_contain(yydh, qymc, DS_temp, i_0, B_Common, DS_temp_0, table_name, cssj, jssj, fjrb_arg_sl, fjrb_arg, zfs, zyye, cssj_yf, cssj_year, "and (xfxm in('" + Szwgl.common_zw.ff_jsbtfy + "','" + Szwgl.common_zw.ff_jsqtfy + "','" + Szwgl.common_zw.ff_sqff + "'))   ");



                    }
                }




                //加床的

                

                DS_temp = B_Common.GetList("select id,krly from F_kfxsfx", " yydh='" + yydh + "' and czy_temp='" + czy + "' and krly='" + "加床" + "'");
               
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {



                        update_contain(yydh, qymc, DS_temp, i_0, B_Common, DS_temp_0, table_name, cssj, jssj, fjrb_arg_sl, fjrb_arg, zfs, zyye, cssj_yf, cssj_year, "and (xfxm in('" + Szwgl.common_zw.ff_jcfy + "'))   ");




                    }
                }


                //本日的

                DS_temp = B_Common.GetList("select id,krly from F_kfxsfx", " yydh='" + yydh + "' and czy_temp='" + czy + "' and krly='" + "本日合计" + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {

                        update_contain(yydh, qymc, DS_temp, i_0, B_Common, DS_temp_0, table_name, cssj, jssj, fjrb_arg_sl, fjrb_arg, zfs, zyye, cssj_yf, cssj_year, " ");

                    }
                }

                //update_contain_y_n

                //本月的

                DS_temp = B_Common.GetList("select id,krly from F_kfxsfx", " yydh='" + yydh + "' and czy_temp='" + czy + "' and krly='" + "本月累计" + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {

                        update_contain_y_n(yydh, qymc, DS_temp, i_0, B_Common, DS_temp_0, table_name, cssj, jssj, fjrb_arg_sl, fjrb_arg, zfs, zyye, cssj_yf, cssj_year, " and (xfsj between '" + cssj_yf.ToString() + "' and '" + jssj.ToString() + "')");

                    }
                }

                //本年的

                DS_temp = B_Common.GetList("select id,krly from F_kfxsfx", " yydh='" + yydh + "' and czy_temp='" + czy + "' and krly='" + "本年累计" + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {

                        update_contain_y_n(yydh, qymc, DS_temp, i_0, B_Common, DS_temp_0, table_name, cssj, jssj, fjrb_arg_sl, fjrb_arg, zfs, zyye, cssj_yf, cssj_year, " and (xfsj between '" + cssj_year.ToString() + "' and '" + jssj.ToString() + "')");

                    }
                }

                B_Common.ExecuteSql("update F_kfxsfx set krly='" + "其他未分类" + "' where krly='' and hj_r_fs<>'本日合计'");//DS_temp.Tables[0].Rows[i_0]["hj_r_fs"].ToString() != "本日合计"
                
            }
            DS_temp.Clear();
            DS_temp.Dispose();
            DS_temp_0.Clear();
            DS_temp_0.Dispose();
            DS_temp_1.Clear();
            DS_temp_1.Dispose();
            return get_result;
        }
    }
}
