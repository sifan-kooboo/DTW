using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szw_print_jzd : Form
    {
        public string lsbh = "";
        public string sk_tt = "";//sk/tt
        public string jzbh = "";//是否有结账
        public string print_Type = "";//打印的类型
        public string zd_type = "";//要打印的是什么账单(jzd,yjd.....)
        public string TableName = "";//要从哪里提取数据
        string qymc = ""; string qymc_english = ""; string Address_chinese = ""; string Address_english = ""; string qydh = ""; string qycz = ""; string qyyb = ""; string website = "";
        string xf = ""; string fk = "";
        string czy_dy = common_file.common_app.czy;

        string krxm_lz = ""; string fjbh_lz = "";
        string ddsj = ""; string lksj = ""; string jzsj = "";//三个时间

        DataSet ds_printData; //要打印的数据
        DataSet ds_Temp;
        BLL.Common B_common = new Hotel_app.BLL.Common();
        public Szw_print_jzd(string _lsbh, string _fk, string _xf, string _tableName, string _zd_type, string _sk_tt, string _jzbh)
        {
            InitializeComponent();
            this.lsbh = _lsbh;
            this.TableName = _tableName;
            this.zd_type = _zd_type;
            this.fk = _fk;
            this.xf = _xf; this.zd_type = _zd_type;
            this.sk_tt = _sk_tt;
            this.jzbh = _jzbh;
            inital();
        }
        public void inital()
        {

            if (this.lsbh.Trim() != "")
            {
                BLL.Qcounter B_Qcounter = new Hotel_app.BLL.Qcounter();
                DataSet ds_tmp_0 = B_Qcounter.GetList("  id>=0  and yydh='" + common_file.common_app.yydh + "'");
                if (ds_tmp_0 != null && ds_tmp_0.Tables[0].Rows.Count > 0)
                {
                    //2012-11-09  更新后,这个值以经分成三部分
                    //

                    int print_Type_values = int.Parse(ds_tmp_0.Tables[0].Rows[0]["printzdpd"].ToString());
                    if (print_Type_values == 1)
                    {
                        print_Type = "A4";
                    }
                    if (print_Type_values == 2)
                    {
                        print_Type = "A5";
                    }
                    if (print_Type_values == 3)//3设置后，jzd用的是：cr_jzd_a4_yx_withNohead.rpt，yjd用的是：
                    {
                        print_Type = "A4_With_nohead";
                    }
                    if (print_Type_values == 4)
                    {
                        print_Type = "A4_With_head";
                    }
                }
                common_file.common_app.GetPrintInfo(ref  qymc, ref qymc_english, ref  Address_chinese, ref  Address_english, ref  qydh, ref qycz, ref qyyb, ref  website);

                //打印结账单
                if (zd_type == "jzd")
                {
                    if (jzbh != "")
                    {
                        ds_Temp = B_common.GetList("  select * from Sjzzd  ", "id>=0 and yydh='" + common_file.common_app.yydh + "'  and  jzbh='" + jzbh + "'");
                        if (ds_Temp != null && ds_Temp.Tables[0].Rows.Count > 0)
                        {
                            if (!ds_Temp.Tables[0].Rows[0]["czzt"].ToString().Contains("结账"))
                            {
                                ddsj = ds_Temp.Tables[0].Rows[0]["ddsj"].ToString();
                                lksj = ds_Temp.Tables[0].Rows[0]["tfsj"].ToString();
                                jzsj = ds_Temp.Tables[0].Rows[0]["tfsj"].ToString();
                                
                            }
                            if (ds_Temp.Tables[0].Rows[0]["czzt"].ToString().Contains("结账"))
                            {
                                ddsj = ds_Temp.Tables[0].Rows[0]["ddsj"].ToString();
                                lksj = ds_Temp.Tables[0].Rows[0]["tfsj"].ToString();
                                jzsj = ds_Temp.Tables[0].Rows[0]["czsj"].ToString();
                                czy_dy = ds_Temp.Tables[0].Rows[0]["czy"].ToString();
                            }
                            krxm_lz = ds_Temp.Tables[0].Rows[0]["krxm_lz"].ToString();
                            fjbh_lz = ds_Temp.Tables[0].Rows[0]["fjbh_lz"].ToString();
                        }
                        ds_printData = B_common.GetList(" select  *  from Sjzmx  ", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and  jzbh='" + jzbh + "'  order by xfsj desc ");
                    }
                    //结账前打印
                    if (jzbh.Trim() == "")
                    {
                        GetPrintinfo(ref krxm_lz, ref fjbh_lz, ref ddsj, ref lksj, this.lsbh, common_file.common_app.yydh, sk_tt);
                        //jzsj = "";
                        lksj = DateTime.Now.ToString();
                        jzsj = DateTime.Now.ToString();

                        DataSet ds_0 = B_common.GetList(" select distinct lsbh  from Szw_temp ", "  id>=0 and  czy_temp='" + common_file.common_app.czy + "' ");
                        if (ds_0 != null && ds_0.Tables[0].Rows.Count > 1)
                        {
                            ds_printData = B_common.GetList(" select  * from Szw_temp  ", " id>=0  and  lsbh  in  (select lsbh from  Flfsz  where lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'   and  shlz=1 ) )  and czy_temp='" + common_file.common_app.czy + "'  order by xfsj  desc ");
                        }
                        else
                        {
                            ds_printData = B_common.GetList(" select * from Szw_temp ", " id>=0  and lsbh='" + lsbh + "'  and czy_temp='" + common_file.common_app.czy + "'  order by xfsj desc ");
                        }
                    }
                    //ds = B_common.GetList("select * from " + TableName, " id>=0  and   yydh='" + common_file.common_app.yydh + "'  and  lsbh  in (select  lsbh from Flfsz  where lfbh  in (select lfbh from Flfsz where lsbh='"+lsbh+"'  and shlz='1' ) )  and  czy='" + common_file.common_app.czy + "'");
                    if (ds_printData != null && ds_printData.Tables[0].Rows.Count > 0)
                    {
                        if (zd_type == "jzd")
                        {
                            if (print_Type == "A4")
                            {
                                cr_jzd_a4 myreport = new cr_jzd_a4();
                                myreport.SetDataSource(ds_printData.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                myreport.SetParameterValue("qymc", qymc);
                                myreport.SetParameterValue("czy", czy_dy);

                                myreport.SetParameterValue("fkje_total", fk);
                                myreport.SetParameterValue("xfje_total", xf);
                                myreport.SetParameterValue("qymcyw", qymc_english);
                                myreport.SetParameterValue("qydh", qydh);
                                myreport.SetParameterValue("qycz", qycz);
                                myreport.SetParameterValue("qyyb", qyyb);
                                myreport.SetParameterValue("website", website);
                                myreport.SetParameterValue("qydz", Address_chinese);
                                myreport.SetParameterValue("qydzyw", Address_english);
                                myreport.SetParameterValue("krxm_lz", krxm_lz);
                                myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                                myreport.SetParameterValue("ddsj", ddsj);
                                myreport.SetParameterValue("lksj", lksj);
                                myreport.SetParameterValue("jzsj", jzsj);
                                myreport.PrintToPrinter(1, true, 0, 0);
                            }
                            if (print_Type == "A5")
                            {
                                cr_jzd_a5 myreport = new cr_jzd_a5();
                                myreport.SetDataSource(ds_printData.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                myreport.SetParameterValue("qymc", qymc);
                                myreport.SetParameterValue("czy", czy_dy);

                                myreport.SetParameterValue("fkje_total", fk);
                                myreport.SetParameterValue("xfje_total", xf);
                                myreport.SetParameterValue("qymcyw", qymc_english);
                                myreport.SetParameterValue("qydh", qydh);
                                myreport.SetParameterValue("qycz", qycz);
                                myreport.SetParameterValue("qyyb", qyyb);
                                myreport.SetParameterValue("website", website);
                                myreport.SetParameterValue("qydz", Address_chinese);
                                myreport.SetParameterValue("qydzyw", Address_english);
                                myreport.SetParameterValue("krxm_lz", krxm_lz);
                                myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                                myreport.SetParameterValue("ddsj", ddsj);
                                myreport.SetParameterValue("lksj", lksj);
                                myreport.SetParameterValue("jzsj", jzsj);

                                myreport.PrintToPrinter(1, true, 0, 0);

                            }
                            if (print_Type == "A4_With_head")
                            {
                                //读取表头的图片
                                cr_jzd_a4_yx myreport = new cr_jzd_a4_yx();

                                myreport.SetDataSource(ds_printData.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                //myreport.SetParameterValue("qymc", qymc);
                                myreport.SetParameterValue("czy", czy_dy);

                                myreport.SetParameterValue("fkje_total", fk);
                                myreport.SetParameterValue("xfje_total", xf);
                                // myreport.SetParameterValue("qymcyw", qymc_english);
                                myreport.SetParameterValue("qydh", qydh);
                                myreport.SetParameterValue("qycz", qycz);
                                myreport.SetParameterValue("qyyb", qyyb);
                                myreport.SetParameterValue("website", website);
                                myreport.SetParameterValue("qydz", Address_chinese);
                                myreport.SetParameterValue("qydzyw", Address_english);
                                myreport.SetParameterValue("krxm_lz", krxm_lz);
                                myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                                myreport.SetParameterValue("ddsj", ddsj);
                                myreport.SetParameterValue("lksj", lksj);
                                myreport.SetParameterValue("jzsj", jzsj);

                                myreport.PrintToPrinter(1, true, 0, 0);


                            }
                            if (print_Type == "A4_With_nohead")
                            {
                                cr_jzd_a4_yx_withNohead myreport = new cr_jzd_a4_yx_withNohead();
                                myreport.SetDataSource(ds_printData.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                //myreport.SetParameterValue("qymc", qymc);
                                myreport.SetParameterValue("czy", czy_dy);

                                myreport.SetParameterValue("fkje_total", fk);
                                myreport.SetParameterValue("xfje_total", xf);
                                // myreport.SetParameterValue("qymcyw", qymc_english);
                                // myreport.SetParameterValue("qydh", qydh);
                                // myreport.SetParameterValue("qycz", qycz);
                                //myreport.SetParameterValue("qyyb", qyyb);
                                //myreport.SetParameterValue("website", website);
                                //myreport.SetParameterValue("qydz", Address_chinese);
                                //myreport.SetParameterValue("qydzyw", Address_english);
                                myreport.SetParameterValue("krxm_lz", krxm_lz);
                                myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                                myreport.SetParameterValue("ddsj", ddsj);
                                myreport.SetParameterValue("lksj", lksj);
                                myreport.SetParameterValue("jzsj", jzsj);

                                myreport.PrintToPrinter(1, true, 0, 0);

                            }
                        }
                    }
                }
                if (zd_type == "yjd")
                {
                    ds_printData = B_common.GetList(" select * from Syjcz ", " id>=0  and lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'");
                    if (ds_printData != null && ds_printData.Tables[0].Rows.Count > 0)
                    {
                        if (print_Type == "A4")
                        {
                            cr_yjd_a4_dh myreport = new cr_yjd_a4_dh();
                            myreport.SetDataSource(ds_printData.Tables[0]);
                            //定义水晶报表的数据库连接信息
                            crystalReportViewer1.ReportSource = myreport;
                            myreport.SetParameterValue("qymc", qymc);
                            myreport.SetParameterValue("czy", czy_dy);
                            myreport.SetParameterValue("qymcyw", qymc_english);
                            myreport.SetParameterValue("qydh", qydh);
                            myreport.SetParameterValue("qycz", qycz);
                            myreport.SetParameterValue("qyyb", qyyb);
                            myreport.SetParameterValue("website", website);
                            myreport.SetParameterValue("qydz", Address_chinese);
                            myreport.SetParameterValue("qydzyw", Address_english);
                            //myreport.PrintOptions.PrinterName = System.Configuration.ConfigurationManager.AppSettings["printer"].ToString();
                            myreport.PrintToPrinter(1, true, 0, 0);

                        }
                        if (print_Type == "A4_With_nohead")
                        {
                            //cr_yjd_a4 myreport = new cr_yjd_a4();
                            cr_yjd_a4_withNoHead myreport = new cr_yjd_a4_withNoHead();
                            myreport.SetDataSource(ds_printData.Tables[0]);
                            //定义水晶报表的数据库连接信息
                            crystalReportViewer1.ReportSource = myreport;
                            //myreport.SetParameterValue("qymc", qymc);
                            myreport.SetParameterValue("czy", common_file.common_app.czy);
                            //myreport.SetParameterValue("qymcyw", qymc_english);
                            // myreport.SetParameterValue("qydh", qydh);
                            // myreport.SetParameterValue("qycz", qycz);
                            // myreport.SetParameterValue("qyyb", qyyb);
                            //myreport.SetParameterValue("website", website);
                            //myreport.SetParameterValue("qydz", Address_chinese);
                            // myreport.SetParameterValue("qydzyw", Address_english);
                            //myreport.PrintOptions.PrinterName = System.Configuration.ConfigurationManager.AppSettings["printer"].ToString();
                            try
                            {
                                myreport.PrintToPrinter(1, true, 0, 0);

                            }
                            catch (Exception ee)
                            {
                                MessageBox.Show(ee.ToString());
                            }
                        }


                        if (print_Type == "A5")
                        {
                            cr_yjd_a5 myreport = new cr_yjd_a5();
                            myreport.SetDataSource(ds_printData.Tables[0]);
                            //定义水晶报表的数据库连接信息
                            crystalReportViewer1.ReportSource = myreport;
                            myreport.SetParameterValue("qymc", qymc);
                            myreport.SetParameterValue("czy", czy_dy);
                            myreport.SetParameterValue("qymcyw", qymc_english);
                            myreport.SetParameterValue("qydh", qydh);
                            myreport.SetParameterValue("qycz", qycz);
                            myreport.SetParameterValue("qyyb", qyyb);
                            myreport.SetParameterValue("website", website);
                            myreport.SetParameterValue("qydz", Address_chinese);
                            myreport.SetParameterValue("qydzyw", Address_english);
                            myreport.PrintOptions.PrinterName = System.Configuration.ConfigurationManager.AppSettings["printer"].ToString();
                            myreport.PrintToPrinter(1, true, 0, 0);

                        }
                    }
                }
                if (zd_type == "jzd_gd")//改单后的打印
                {
                    if (jzbh != "")
                    {
                        ds_Temp = B_common.GetList("  select * from Sjzmx_gd_temp  ", "id>=0 and yydh='" + common_file.common_app.yydh + "'  and  jzbh='" + jzbh + "' ");
                        if (ds_Temp != null && ds_Temp.Tables[0].Rows.Count > 0)
                        {
                            ddsj = ds_Temp.Tables[0].Rows[0]["zd_ddsj"].ToString();
                            lksj = ds_Temp.Tables[0].Rows[0]["zd_tfsj"].ToString();
                            jzsj = ds_Temp.Tables[0].Rows[0]["zd_tfsj"].ToString();
                            krxm_lz = ds_Temp.Tables[0].Rows[0]["zd_krxm_lz"].ToString();
                            if (sk_tt == "tt")
                            {
                                fjbh_lz = "";
                            }
                            else
                            {
                                fjbh_lz = ds_Temp.Tables[0].Rows[0]["zd_fjbh_lz"].ToString();
                            }

                        }
                        ds_printData = B_common.GetList(" select  *  from Sjzmx_gd_temp  ", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and  jzbh='" + jzbh + "' and  czy_temp='" + common_file.common_app.czy + "'   order by id desc    ");
                    }

                    if (jzbh == "")//在住改单的打印
                    {
                        ds_Temp = B_common.GetList("  select * from Sjzmx_gd_temp  ", "id>=0 and yydh='" + common_file.common_app.yydh + "'  and  czy_temp='" + common_file.common_app.czy + "'  and jzbh=''  ");
                        if (ds_Temp != null && ds_Temp.Tables[0].Rows.Count > 0)
                        {
                            ddsj = ds_Temp.Tables[0].Rows[0]["zd_ddsj"].ToString();
                            lksj = ds_Temp.Tables[0].Rows[0]["zd_tfsj"].ToString();
                            jzsj = ds_Temp.Tables[0].Rows[0]["zd_tfsj"].ToString();

                            krxm_lz = ds_Temp.Tables[0].Rows[0]["zd_krxm_lz"].ToString();
                            if (sk_tt == "tt")
                            {
                                fjbh_lz = "";
                            }
                            else
                            {
                                fjbh_lz = ds_Temp.Tables[0].Rows[0]["zd_fjbh_lz"].ToString();
                            }
                        }
                        ds_printData = B_common.GetList(" select  *  from Sjzmx_gd_temp  ", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and  czy_temp='" + common_file.common_app.czy + "' order by id desc ");
                    }

                    if (print_Type == "A4")
                    {
                        cr_jzd_a4 myreport = new cr_jzd_a4();
                        myreport.SetDataSource(ds_printData.Tables[0]);
                        crystalReportViewer1.ReportSource = myreport;
                        myreport.SetParameterValue("qymc", qymc);
                        myreport.SetParameterValue("czy", czy_dy);

                        myreport.SetParameterValue("fkje_total", fk);
                        myreport.SetParameterValue("xfje_total", xf);
                        myreport.SetParameterValue("qymcyw", qymc_english);
                        myreport.SetParameterValue("qydh", qydh);
                        myreport.SetParameterValue("qycz", qycz);
                        myreport.SetParameterValue("qyyb", qyyb);
                        myreport.SetParameterValue("website", website);
                        myreport.SetParameterValue("qydz", Address_chinese);
                        myreport.SetParameterValue("qydzyw", Address_english);
                        myreport.SetParameterValue("krxm_lz", krxm_lz);
                        myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                        myreport.SetParameterValue("ddsj", ddsj);
                        myreport.SetParameterValue("lksj", lksj);
                        myreport.SetParameterValue("jzsj", jzsj);
                        myreport.PrintToPrinter(1, true, 0, 0);
                    }
                    if (print_Type == "A5")
                    {
                        cr_jzd_a5 myreport = new cr_jzd_a5();
                        myreport.SetDataSource(ds_printData.Tables[0]);
                        crystalReportViewer1.ReportSource = myreport;
                        myreport.SetParameterValue("qymc", qymc);
                        myreport.SetParameterValue("czy", czy_dy);

                        myreport.SetParameterValue("fkje_total", fk);
                        myreport.SetParameterValue("xfje_total", xf);
                        myreport.SetParameterValue("qymcyw", qymc_english);
                        myreport.SetParameterValue("qydh", qydh);
                        myreport.SetParameterValue("qycz", qycz);
                        myreport.SetParameterValue("qyyb", qyyb);
                        myreport.SetParameterValue("website", website);
                        myreport.SetParameterValue("qydz", Address_chinese);
                        myreport.SetParameterValue("qydzyw", Address_english);
                        myreport.SetParameterValue("krxm_lz", krxm_lz);
                        myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                        myreport.SetParameterValue("ddsj", ddsj);
                        myreport.SetParameterValue("lksj", lksj);
                        myreport.SetParameterValue("jzsj", jzsj);

                        myreport.PrintToPrinter(1, true, 0, 0);

                    }
                    if (print_Type == "A4_With_head")
                    {
                        //读取表头的图片
                        cr_jzd_a4_yx myreport = new cr_jzd_a4_yx();

                        myreport.SetDataSource(ds_printData.Tables[0]);
                        crystalReportViewer1.ReportSource = myreport;
                        //myreport.SetParameterValue("qymc", qymc);
                        myreport.SetParameterValue("czy", czy_dy);

                        myreport.SetParameterValue("fkje_total", fk);
                        myreport.SetParameterValue("xfje_total", xf);
                        // myreport.SetParameterValue("qymcyw", qymc_english);
                        myreport.SetParameterValue("qydh", qydh);
                        myreport.SetParameterValue("qycz", qycz);
                        myreport.SetParameterValue("qyyb", qyyb);
                        myreport.SetParameterValue("website", website);
                        myreport.SetParameterValue("qydz", Address_chinese);
                        myreport.SetParameterValue("qydzyw", Address_english);
                        myreport.SetParameterValue("krxm_lz", krxm_lz);
                        myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                        myreport.SetParameterValue("ddsj", ddsj);
                        myreport.SetParameterValue("lksj", lksj);
                        myreport.SetParameterValue("jzsj", jzsj);

                        myreport.PrintToPrinter(1, true, 0, 0);


                    }
                    if (print_Type == "A4_With_nohead")
                    {
                        cr_jzd_a4_yx_withNohead myreport = new cr_jzd_a4_yx_withNohead();
                        myreport.SetDataSource(ds_printData.Tables[0]);
                        crystalReportViewer1.ReportSource = myreport;
                        //myreport.SetParameterValue("qymc", qymc);
                        myreport.SetParameterValue("czy", czy_dy);

                        myreport.SetParameterValue("fkje_total", fk);
                        myreport.SetParameterValue("xfje_total", xf);
                        // myreport.SetParameterValue("qymcyw", qymc_english);
                        // myreport.SetParameterValue("qydh", qydh);
                        // myreport.SetParameterValue("qycz", qycz);
                        //myreport.SetParameterValue("qyyb", qyyb);
                        //myreport.SetParameterValue("website", website);
                        //myreport.SetParameterValue("qydz", Address_chinese);
                        //myreport.SetParameterValue("qydzyw", Address_english);
                        myreport.SetParameterValue("krxm_lz", krxm_lz);
                        myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                        myreport.SetParameterValue("ddsj", ddsj);
                        myreport.SetParameterValue("lksj", lksj);
                        myreport.SetParameterValue("jzsj", jzsj);
                        try
                        {
                            myreport.PrintToPrinter(1, true, 0, 0);
                        }
                        catch
                        {

                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "打印出错,请重启酒店管理系统重试!");
                        }

                    }
                }
            }
        }
        public void GetPrintinfo(ref string krxm_lz, ref string fjbh_lz, ref  string ddsj, ref string lksj, string lsbh, string yydh, string sktt)
        {
            krxm_lz = "";
            fjbh_lz = "";
            ddsj = "";
            BLL.Common B_common = new Hotel_app.BLL.Common();
            if (sktt == "sk")
            {
                DataSet ds_temp1 = B_common.GetList(" select * from Qskyd_fjrb ", "id>=0  and lsbh='" + lsbh + "'  and yydh='" + yydh + "'  order by  fjbh ");
                if (ds_temp1 != null && ds_temp1.Tables[0].Rows.Count > 0)
                {
                    krxm_lz = ds_temp1.Tables[0].Rows[0]["krxm"].ToString();
                    fjbh_lz = ds_temp1.Tables[0].Rows[0]["fjbh"].ToString();
                    ddsj = ds_temp1.Tables[0].Rows[0]["ddsj"].ToString();
                    lksj = ds_temp1.Tables[0].Rows[0]["lksj"].ToString();
                }
                DataSet ds_temp0 = B_common.GetList(" select * from Flfsz  ", " id>=0  and  lfbh in ( select lfbh from  Flfsz where lsbh='" + lsbh + "' and yydh='" + yydh + "'  and  shlz='1'  and fjbh!=''  )  and lsbh!='" + lsbh + "' ");
                if (ds_temp0 != null && ds_temp0.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_temp0.Tables[0].Rows.Count; i++)
                    {

                        krxm_lz += "|" + ds_temp0.Tables[0].Rows[i]["krxm"].ToString();
                        fjbh_lz += "|" + ds_temp0.Tables[0].Rows[i]["fjbh"].ToString();
                        //取当前lsbh的到达时间为到达时间
                    }
                }
            }
            if (sktt == "tt")
            {
                krxm_lz = "";
                fjbh_lz = "";
                ddsj = "";
                DataSet ds_temp1 = B_common.GetList(" select * from Qttyd_mainrecord ", "id>=0  and lsbh='" + lsbh + "'  and yydh='" + yydh + "'");
                if (ds_temp1 != null && ds_temp1.Tables[0].Rows.Count > 0)
                {
                    krxm_lz = ds_temp1.Tables[0].Rows[0]["krxm"].ToString();
                    ddsj = ds_temp1.Tables[0].Rows[0]["ddsj"].ToString();
                    lksj = ds_temp1.Tables[0].Rows[0]["lksj"].ToString();
                }
            }
        }
    }
}