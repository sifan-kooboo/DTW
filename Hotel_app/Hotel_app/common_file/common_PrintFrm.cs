using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel_app.Szwgl;
using Hotel_app.Qyddj;

namespace Hotel_app.common_file
{

    /// <summary>
    /// 些窗体专门用于打印
    /// 2012-11-09   printzdpd  这个值以经分成了三部分
    /// 前两位表示结账单格式
    /// 中间两位表示押金单格式
    /// 后两位表示登记表的格式
    /// 以后还有其它的，以此类推
    /// </summary>
    public partial class common_PrintFrm : Form
    {
        public common_PrintFrm()
        {
            InitializeComponent();
        }

        public string lsbh = "";
        public string ddbh = "";
        public string sk_tt = "";//sk/tt
        public string jzbh = "";//是否有结账

        public string zd_type = "";//要打印的是什么账单(jzd,yjd.....)
        public string TableName = "";//要从哪里提取数据


        //打印时会用到的共公信息
        string qymc = ""; string qymc_english = ""; string Address_chinese = ""; string Address_english = ""; string qydh = ""; string qycz = ""; string qyyb = ""; string website = "";
        string xf = ""; string fk = "";
        string czy_dy = common_file.common_app.czy;//打印用的

        public string zjhm = "";
        public string ysk_tj = "0";

        string zd_jzd = "0";//结账单的值  
        string zd_jzd_type = "";
        int zd_jzd_times = 1;//打印次数

        int zd_gd_times = 1;//改单打印的次数

        string zd_yjd = "0";//押金单的值
        string zd_yjd_type = "";
        int zd_yjd_times = 1;//押金单打印次数

        int zd_yjd_gl_times = 1;//过滤的押金单打印的次数

        string zd_djb = "0";//登记表的值
        string zd_djb_type = "";
        int zd_djb_times = 1;//登记表打印次数

        string krxm_lz = ""; string fjbh_lz = "";
        string ddsj = ""; string lksj = ""; string jzsj = "";//三个时间

        DataSet ds_printData; //要打印的数据
        DataSet ds_Temp;
        DataSet ds;
        BLL.Common B_common = new Hotel_app.BLL.Common();

        //打印结账单用到的构造函数
        public common_PrintFrm(string _lsbh, string _fk, string _xf, string _tableName, string _zd_type, string _sk_tt, string _jzbh)
        {
            InitializeComponent();
            this.lsbh = _lsbh;
            this.TableName = _tableName;
            this.zd_type = _zd_type;
            this.fk = _fk;
            this.xf = _xf; this.zd_type = _zd_type;
            this.sk_tt = _sk_tt;
            this.jzbh = _jzbh;
            common_file.common_app.GetPrintInfo(ref  qymc, ref  qymc_english, ref  Address_chinese, ref Address_english, ref qydh, ref qycz, ref qyyb, ref website);
            SetZdType();
            inital();
        }

        //打印登记表用到的构造函数
        public common_PrintFrm(string _lsbh, string _sk_tt, string _czy, string _ddbh)
        {
            InitializeComponent();
            lsbh = _lsbh;
            sk_tt = _sk_tt;
            czy_dy = _czy;
            ddbh = _ddbh;
            common_file.common_app.GetPrintInfo(ref  qymc, ref  qymc_english, ref  Address_chinese, ref Address_english, ref qydh, ref qycz, ref qyyb, ref website);
            SetZdType();
            inital_1();
        }

        //区域打印押金单用到的构造函数
        public common_PrintFrm(string _zd_type, DataSet _ds_print)
        {
            InitializeComponent();
            zd_type = _zd_type;
            ds_printData = _ds_print;
            common_file.common_app.GetPrintInfo(ref  qymc, ref  qymc_english, ref  Address_chinese, ref Address_english, ref qydh, ref qycz, ref qyyb, ref website);
            SetZdType();
            inital_2();
        }

        //设置账单类型以及账单打印的次数
        public void SetZdType()
        {
            BLL.Qcounter B_Qcounter = new Hotel_app.BLL.Qcounter();
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds_tmp_0 = B_Qcounter.GetList("  id>=0  and yydh='" + common_file.common_app.yydh + "'");
            DataSet ds_tmp_1 = B_common.GetList(" select * from Qprint "," id>=0 and yydh='" + common_app.yydh + "'");
            if (ds_tmp_0 != null && ds_tmp_0.Tables[0].Rows.Count > 0)
            {
                int print_Type_values = int.Parse(ds_tmp_0.Tables[0].Rows[0]["printzdpd"].ToString());

                //获取账单的打印格式(前两位是结账单，中间两位是押金单，五六位是登记表)
                zd_jzd = print_Type_values.ToString().Trim().Substring(0, 2);
                zd_yjd = print_Type_values.ToString().Trim().Substring(2, 2);
                zd_djb = print_Type_values.ToString().Trim().Substring(4, 2);

                if (zd_jzd.Equals("11")) //A4有表头---怡庭用的结账单
                {
                    zd_jzd_type = "A4";
                }
                if (zd_jzd.Equals("10"))//A4无表头--华都用的结账单
                {
                    zd_jzd_type = "A4_With_nohead";
                }
                if (zd_jzd.Equals("21"))//A5有表头--怡庭有可能会用结账单
                {
                    zd_jzd_type = "A5";
                }
                if (zd_jzd.Equals("12"))//A4固定表头的(东海在用的)
                {
                    zd_jzd_type = "A4_yx_dh";
                }


                if (zd_yjd.Equals("11"))//A4有表头---怡庭用的押金单
                {
                    zd_yjd_type = "A4";
                }
                if (zd_yjd.Equals("10"))//A4无表头--华都用的押金单
                {
                    zd_yjd_type = "A4_With_nohead";
                }
                if (zd_yjd.Equals("12")) //A4东海特用的
                {
                    zd_yjd_type = "A4_yx_dh";
                }
                if (zd_yjd.Equals("21"))//A5有表头--怡庭有可能会用押金单
                {
                    zd_yjd_type = "A5";
                }


                if (zd_djb.Equals("11"))//A4有表头---怡庭可能会用的登记单
                {
                    zd_djb_type = "A4";
                }
                if (zd_djb.Equals("10"))//A4无表头--华都用的登记单
                {
                    zd_djb_type = "A4_With_nohead";
                }
                if(zd_djb.Equals("12"))
                {
                    zd_djb_type="A4_yx_dh";
                }
                if (zd_djb.Equals("21"))//A5有表头--怡庭会用登记单
                {
                    zd_djb_type = "A5";
                }



                if (ds_tmp_1 != null && ds_tmp_1.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_tmp_1.Tables[0].Rows.Count; i++)
                    {
                        if (ds_tmp_1.Tables[0].Rows[i]["zdType"].ToString().Equals("zd_jzd"))
                        {
                            zd_jzd_times = int.Parse(ds_tmp_1.Tables[0].Rows[i]["printTimes"].ToString());
                        }
                        if (ds_tmp_1.Tables[0].Rows[i]["zdType"].ToString().Equals("zd_yjd"))
                        {
                            zd_yjd_times = int.Parse(ds_tmp_1.Tables[0].Rows[i]["printTimes"].ToString());
                        }
                        if (ds_tmp_1.Tables[0].Rows[i]["zdType"].ToString().Equals("zd_yjd_gl"))
                        {
                            zd_gd_times = int.Parse(ds_tmp_1.Tables[0].Rows[i]["printTimes"].ToString());
                        }

                        if (ds_tmp_1.Tables[0].Rows[i]["zdType"].ToString().Equals("zd_djb"))
                        {
                            zd_djb_times = int.Parse(ds_tmp_1.Tables[0].Rows[i]["printTimes"].ToString());
                        }
                        if (ds_tmp_1.Tables[0].Rows[i]["zdType"].ToString().Equals("zd_gd"))
                        {
                            zd_gd_times = int.Parse(ds_tmp_1.Tables[0].Rows[i]["printTimes"].ToString());
                        }
                    }
                }
            }
            common_file.common_app.GetPrintInfo(ref  qymc, ref qymc_english, ref  Address_chinese, ref  Address_english, ref  qydh, ref qycz, ref qyyb, ref  website);

        }

        #region 打印结账单与押金单用到的部分
        public void inital()
        {

            if (this.lsbh.Trim() != "")
            {
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

                        DataSet ds_0 = B_common.GetList(" select distinct lsbh  from Szw_temp ", "  id>=0 and  czy_temp='" + common_file.common_app.czy_GUID + "' ");
                        if (ds_0 != null && ds_0.Tables[0].Rows.Count > 1)
                        {
                            ds_printData = B_common.GetList(" select  * from Szw_temp  ", " id>=0  and  lsbh  in  (select lsbh from  Flfsz  where lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'   and  shlz=1 ) )  and czy_temp='" + common_file.common_app.czy_GUID + "'  order by xfsj  desc ");
                        }
                        else
                        {
                            ds_printData = B_common.GetList(" select * from Szw_temp ", " id>=0  and lsbh='" + lsbh + "'  and czy_temp='" + common_file.common_app.czy_GUID + "'  order by xfsj desc ");
                        }
                    }
                    //ds = B_common.GetList("select * from " + TableName, " id>=0  and   yydh='" + common_file.common_app.yydh + "'  and  lsbh  in (select  lsbh from Flfsz  where lfbh  in (select lfbh from Flfsz where lsbh='"+lsbh+"'  and shlz='1' ) )  and  czy='" + common_file.common_app.czy + "'");
                    if (ds_printData != null && ds_printData.Tables[0].Rows.Count > 0)
                    {
                        if (zd_type == "jzd")
                        {
                            if (zd_jzd_type == "A4")
                            {
                                Hotel_app.Szwgl.cr_jzd_a4 myreport = new cr_jzd_a4();
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

                                for (int i = 0; i < zd_jzd_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }
                            }
                            if (zd_jzd_type == "A5")
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
                                for (int i = 0; i < zd_jzd_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }

                            }
                            if (zd_jzd_type == "A4_With_head")
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

                                for (int i = 0; i < zd_jzd_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }


                            }
                            if (zd_jzd_type == "A4_With_nohead")
                            {
                                cr_jzd_a4_yx_withNohead myreport = new cr_jzd_a4_yx_withNohead();
                                myreport.SetDataSource(ds_printData.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                myreport.SetParameterValue("czy", czy_dy);
                                myreport.SetParameterValue("fkje_total", fk);
                                myreport.SetParameterValue("xfje_total", xf);
                                myreport.SetParameterValue("krxm_lz", krxm_lz);
                                myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                                myreport.SetParameterValue("ddsj", ddsj);
                                myreport.SetParameterValue("lksj", lksj);
                                myreport.SetParameterValue("jzsj", jzsj);

                                for (int i = 0; i < zd_jzd_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }

                            }

                            if (zd_jzd_type == "A4_yx_dh")
                            {
                                cr_jzd_a4_yx myreport = new cr_jzd_a4_yx();
                                myreport.SetDataSource(ds_printData.Tables[0]);

                                //参数的不同(东海用的报表)

                                crystalReportViewer1.ReportSource = myreport;

                                //设置公共参数

                                myreport.SetParameterValue("qydz", Address_chinese);
                                myreport.SetParameterValue("qydzyw", Address_english);
                                myreport.SetParameterValue("qydh", qydh);
                                myreport.SetParameterValue("qycz", qycz);
                                myreport.SetParameterValue("website", website);

                                myreport.SetParameterValue("czy", czy_dy);
                                myreport.SetParameterValue("fkje_total", fk);
                                myreport.SetParameterValue("xfje_total", xf);
                                myreport.SetParameterValue("krxm_lz", krxm_lz);
                                myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                                myreport.SetParameterValue("ddsj", ddsj);
                                myreport.SetParameterValue("lksj", lksj);
                                myreport.SetParameterValue("jzsj", jzsj);

                                for (int i = 0; i < zd_jzd_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }
                            }



                        }
                    }
                }
                if (zd_type == "yjd")
                {

                    //这里确定押金单主单的抵时和离时





                    ddsj = "1800-01-01"; lksj = "1800-01-01";
                    ds_printData = B_common.GetList(" select * from Syjcz ", " id>=0  and lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'");
                    if (ds_printData != null && ds_printData.Tables[0].Rows.Count > 0)
                    {
                        DataSet ds_ls = null;
                        string jzbh_ls = ds_printData.Tables[0].Rows[0]["jzbh"].ToString();
                        if (jzbh_ls.Trim() != "")
                        {
                            ds_ls = B_common.GetList("select * From  Sjzzd ", " id>=0  and yydh='" + common_app.yydh + "' and jzbh='" + jzbh_ls + "'  ");
                            if (ds_ls != null&&ds_ls.Tables[0].Rows.Count>0)
                            {
                                ddsj = ds_ls.Tables[0].Rows[0]["ddsj"].ToString();
                                lksj = ds_ls.Tables[0].Rows[0]["tfsj"].ToString();
                            }
                        }
                        else
                        {
                            //没有退房的,去房间类别表里面打
                            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
                            ds_ls = B_Qskyd_fjrb.GetList(" id>=0  and  yydh='" + common_app.yydh + "' and  lsbh='" + lsbh + "' ");
                            if (ds_ls != null && ds_ls.Tables[0].Rows.Count > 0)
                            {
                                ddsj = ds_ls.Tables[0].Rows[0]["ddsj"].ToString();
                                lksj = ds_ls.Tables[0].Rows[0]["lksj"].ToString();
                            }
                        }
                    }




                    if (ds_printData != null && ds_printData.Tables[0].Rows.Count > 0)
                    {
                        //if (zd_yjd_type == "A4")
                        //{
                        //    cr_yjd_a4 myreport = new cr_yjd_a4();
                        //    myreport.SetDataSource(ds_printData.Tables[0]);
                        //    //定义水晶报表的数据库连接信息
                        //    crystalReportViewer1.ReportSource = myreport;
                        //    myreport.SetParameterValue("qymc", qymc);
                        //    myreport.SetParameterValue("czy", czy_dy);
                        //    myreport.SetParameterValue("qymcyw", qymc_english);
                        //    myreport.SetParameterValue("qydh", qydh);
                        //    myreport.SetParameterValue("qycz", qycz);
                        //    myreport.SetParameterValue("qyyb", qyyb);
                        //    myreport.SetParameterValue("website", website);
                        //    myreport.SetParameterValue("qydz", Address_chinese);
                        //    myreport.SetParameterValue("qydzyw", Address_english);

                        //    for (int i = 0; i < zd_yjd_times; i++)
                        //    {
                        //        myreport.PrintToPrinter(1, true, 0, 0);
                        //    }

                        //}
                        if (zd_yjd_type == "A4_With_nohead")
                        {
                            //cr_yjd_a4 myreport = new cr_yjd_a4();
                            cr_yjd_a4_withNoHead myreport = new cr_yjd_a4_withNoHead();
                            myreport.SetDataSource(ds_printData.Tables[0]);
                            //定义水晶报表的数据库连接信息
                            crystalReportViewer1.ReportSource = myreport;
                            //myreport.SetParameterValue("qymc", qymc);
                            myreport.SetParameterValue("czy", common_file.common_app.czy);

                            myreport.SetParameterValue("ddsj", ddsj);
                            myreport.SetParameterValue("yjls", lksj);
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
                                for (int i = 0; i < zd_yjd_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }

                            }
                            catch (Exception ee)
                            {
                                MessageBox.Show(ee.ToString());
                            }
                        }


                        if (zd_yjd_type == "A5")
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

                            myreport.SetParameterValue("ddsj", ddsj);
                            myreport.SetParameterValue("yjls", lksj);
                            for (int i = 0; i < zd_yjd_times; i++)
                            {
                                myreport.PrintToPrinter(1, true, 0, 0);
                            }

                        }


                        if (zd_yjd_type == "A4_yx_dh")
                        {
                            cr_yjd_a4_dh myreport = new cr_yjd_a4_dh();
                            myreport.SetDataSource(ds_printData.Tables[0]);
                            //定义水晶报表的数据库连接信息
                            crystalReportViewer1.ReportSource = myreport;
                            myreport.SetParameterValue("czy", czy_dy);


                            myreport.SetParameterValue("qydz", Address_chinese);
                            myreport.SetParameterValue("qydzyw", Address_english);
                            myreport.SetParameterValue("qydh", qydh);
                            myreport.SetParameterValue("qycz", qycz);
                            myreport.SetParameterValue("website", website);
                            myreport.SetParameterValue("ddsj", ddsj);
                            myreport.SetParameterValue("yjls", lksj);
                            for (int i = 0; i < zd_yjd_times; i++)
                            {
                                myreport.PrintToPrinter(1, true, 0, 0);
                            }
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
                        ds_printData = B_common.GetList(" select  *  from Sjzmx_gd_temp  ", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and  jzbh='" + jzbh + "' and  czy_temp='" + common_file.common_app.czy_GUID + "'   order by id desc    ");
                    }

                    if (jzbh == "")//在住改单的打印
                    {
                        ds_Temp = B_common.GetList("  select * from Sjzmx_gd_temp  ", "id>=0 and yydh='" + common_file.common_app.yydh + "'  and  czy_temp='" + common_file.common_app.czy_GUID + "'  and jzbh=''  ");
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
                        ds_printData = B_common.GetList(" select  *  from Sjzmx_gd_temp  ", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and  czy_temp='" + common_file.common_app.czy_GUID + "' order by id desc ");
                    }

                    if (zd_jzd_type == "A4")
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

                        for (int i = 0; i < zd_gd_times; i++)
                        {
                            myreport.PrintToPrinter(1, true, 0, 0);
                        }
                    }
                    if (zd_jzd_type == "A5")
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
                        for (int i = 0; i < zd_gd_times; i++)
                        {
                            myreport.PrintToPrinter(1, true, 0, 0);
                        }

                    }
                    if (zd_jzd_type == "A4_With_nohead")
                    {
                        cr_jzd_a4_yx_withNohead myreport = new cr_jzd_a4_yx_withNohead();
                        myreport.SetDataSource(ds_printData.Tables[0]);
                        crystalReportViewer1.ReportSource = myreport;
                        myreport.SetParameterValue("czy", czy_dy);
                        myreport.SetParameterValue("fkje_total", fk);
                        myreport.SetParameterValue("xfje_total", xf);
                        myreport.SetParameterValue("krxm_lz", krxm_lz);
                        myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                        myreport.SetParameterValue("ddsj", ddsj);
                        myreport.SetParameterValue("lksj", lksj);
                        myreport.SetParameterValue("jzsj", jzsj);
                        try
                        {
                            for (int i = 0; i < zd_gd_times; i++)
                            {
                                myreport.PrintToPrinter(1, true, 0, 0);
                            }
                        }
                        catch
                        {

                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "打印出错,请重启酒店管理系统重试!");
                        }

                    }

                    if (zd_jzd_type == "A4_yx_dh")
                    {
                        cr_jzd_a4_yx myreport = new cr_jzd_a4_yx();
                        myreport.SetDataSource(ds_printData.Tables[0]);
                        crystalReportViewer1.ReportSource = myreport;


                        myreport.SetParameterValue("qydz", Address_chinese);
                        myreport.SetParameterValue("qydzyw", Address_english);
                        myreport.SetParameterValue("qydh", qydh);
                        myreport.SetParameterValue("qycz", qycz);
                        myreport.SetParameterValue("website", website);

                        myreport.SetParameterValue("czy", czy_dy);
                        myreport.SetParameterValue("fkje_total", fk);
                        myreport.SetParameterValue("xfje_total", xf);
                        myreport.SetParameterValue("krxm_lz", krxm_lz);
                        myreport.SetParameterValue("fjbh_lz", fjbh_lz);
                        myreport.SetParameterValue("ddsj", ddsj);
                        myreport.SetParameterValue("lksj", lksj);
                        myreport.SetParameterValue("jzsj", jzsj);
                        try
                        {
                            for (int i = 0; i < zd_gd_times; i++)
                            {
                                myreport.PrintToPrinter(1, true, 0, 0);
                            }
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
        #endregion

        #region 打印登记单用的部分
        private void inital_1()
        {
            if (lsbh.Trim() != "" && sk_tt.Trim() != "")
            {
                ysk_tj = GetYsk(lsbh);
                if (sk_tt == "sk")
                {
                    ds = B_common.GetList(" SELECT * from  View_skyd_djb  ", "  lsbh='" + lsbh + "'  and yydh='" + common_file.common_app.yydh + "'");
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            if (zd_djb_type == "A4")
                            {
                                Hotel_app.Qyddj.Q_skyd_djb myreport = new Q_skyd_djb();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    if (ds.Tables[0].Rows[i]["zjhm"].ToString().Trim() != "")
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = (ds.Tables[0].Rows[i]["yxzj"].ToString() + ": ") as object;
                                    }
                                    else
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = ("") as object;
                                    }

                                }
                                myreport.SetDataSource(ds.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                myreport.SetParameterValue("czy", czy_dy);
                                myreport.SetParameterValue("ysk_tj", ysk_tj);
                                for (int i = 0; i < zd_djb_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }
                            }
                            if (zd_djb_type == "A4_With_nohead")
                            {
                                Hotel_app.Qyddj.Q_skyd_djb_A4 myreport = new Q_skyd_djb_A4();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    if (ds.Tables[0].Rows[i]["zjhm"].ToString().Trim() != "")
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = (ds.Tables[0].Rows[i]["yxzj"].ToString() + ": ") as object;
                                    }
                                    else
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = ("") as object;
                                    }

                                }
                                myreport.SetDataSource(ds.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                myreport.SetParameterValue("czy", czy_dy);
                                myreport.SetParameterValue("ysk_tj", ysk_tj);
                                for (int i = 0; i < zd_djb_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }
                            }

                            if (zd_djb_type == "A5")
                            {
                                Hotel_app.Qyddj.Q_skyd_djb myreport = new Q_skyd_djb();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    if (ds.Tables[0].Rows[i]["zjhm"].ToString().Trim() != "")
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = (ds.Tables[0].Rows[i]["yxzj"].ToString() + ": ") as object;
                                    }
                                    else
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = ("") as object;
                                    }

                                }
                                myreport.SetDataSource(ds.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                myreport.SetParameterValue("czy", czy_dy);
                                myreport.SetParameterValue("ysk_tj", ysk_tj);
                                for (int i = 0; i < zd_djb_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }
                            }

                            if (zd_djb_type == "A4_yx_dh")
                            {
                                Hotel_app.Qyddj.Q_skyd_djb_A4_dh myreport = new Q_skyd_djb_A4_dh();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    if (ds.Tables[0].Rows[i]["zjhm"].ToString().Trim() != "")
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = (ds.Tables[0].Rows[i]["yxzj"].ToString() + ": ") as object;
                                    }
                                    //else
                                    //{
                                    //    ds.Tables[0].Rows[i]["yxzj"] = ("") as object;
                                    //}

                                }
                                myreport.SetDataSource(ds.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;

                                myreport.SetParameterValue("qydz", Address_chinese);
                                myreport.SetParameterValue("qydzyw", Address_chinese);
                                myreport.SetParameterValue("qydh", qydh);
                                myreport.SetParameterValue("qycz", qycz);
                                myreport.SetParameterValue("website", website);

                                myreport.SetParameterValue("czy", czy_dy);
                                myreport.SetParameterValue("ysk_tj", ysk_tj);
                                for (int i = 0; i < zd_djb_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }
                            }

                        }
                        catch
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "打印出错,请正确设置打印机");
                        }

                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前订单没有任何在住客人信息,打印终止!");
                    }
                }
                if (sk_tt == "tt")
                {
                    ds = B_common.GetList(" SELECT  *   from  VIEW_Qttyd_djb  ", "  ddbh='" + ddbh + "'  and yydh='" + common_file.common_app.yydh + "'");
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            if (zd_djb_type == "A4_With_nohead")
                            {
                                Hotel_app.Qyddj.Q_ttyd_djb_A4 myreport = new Q_ttyd_djb_A4();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    if (ds.Tables[0].Rows[i]["zjhm"].ToString().Trim() != "")
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = (ds.Tables[0].Rows[i]["yxzj"].ToString() + ": ") as object;
                                    }
                                    else
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = ("") as object;
                                    }
                                    if (DateTime.Parse(ds.Tables[0].Rows[i]["krsr"].ToString().Trim()).Date.CompareTo(DateTime.Parse(common_file.common_app.cssj)) == 0)
                                    {
                                        ds.Tables[0].Rows[i]["krsr"] = "";
                                    }
                                }
                                myreport.SetDataSource(ds.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                myreport.SetParameterValue("czy", czy_dy);
                                myreport.SetParameterValue("ysk_tj", ysk_tj);
                                for (int i = 0; i < zd_djb_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }
                            }

                            if (zd_djb_type == "A5")
                            {
                                Hotel_app.Qyddj.Q_ttyd_djb myreport = new Q_ttyd_djb();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    if (ds.Tables[0].Rows[i]["zjhm"].ToString().Trim() != "")
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = (ds.Tables[0].Rows[i]["yxzj"].ToString() + ": ") as object;
                                    }
                                    else
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = ("") as object;
                                    }
                                    //if (DateTime.Parse(ds.Tables[0].Rows[i]["krsr"].ToString().Trim()).Date.CompareTo(DateTime.Parse(common_file.common_app.cssj)) == 0)
                                    //{
                                    //    ds.Tables[0].Rows[i]["krsr"] = "";
                                    //}
                                }
                                myreport.SetDataSource(ds.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;
                                myreport.SetParameterValue("czy", czy_dy);
                                myreport.SetParameterValue("ysk_tj", ysk_tj);
                                for (int i = 0; i < zd_djb_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }
                            }


                            if (zd_djb_type == "A4_yx_dh")
                            {
                                Hotel_app.Qyddj.Q_ttyd_djb_A4_dh myreport = new Q_ttyd_djb_A4_dh();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    if (ds.Tables[0].Rows[i]["zjhm"].ToString().Trim() != "")
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = (ds.Tables[0].Rows[i]["yxzj"].ToString() + ": ") as object;
                                    }
                                    else
                                    {
                                        ds.Tables[0].Rows[i]["yxzj"] = ("") as object;
                                    }
                                    //if (DateTime.Parse(ds.Tables[0].Rows[i]["krsr"].ToString().Trim()).Date.CompareTo(DateTime.Parse(common_file.common_app.cssj)) == 0)
                                    //{
                                    //    ds.Tables[0].Rows[i]["krsr"] = "";
                                    //}
                                }
                                myreport.SetDataSource(ds.Tables[0]);
                                crystalReportViewer1.ReportSource = myreport;


                                myreport.SetParameterValue("qydz", Address_chinese);
                                myreport.SetParameterValue("qydzyw", Address_chinese);
                                myreport.SetParameterValue("qydh", qydh);
                                myreport.SetParameterValue("qycz", qycz);
                                myreport.SetParameterValue("website", website);

                                myreport.SetParameterValue("czy", czy_dy);
                                myreport.SetParameterValue("ysk_tj", ysk_tj);
                                for (int i = 0; i < zd_djb_times; i++)
                                {
                                    myreport.PrintToPrinter(1, true, 0, 0);
                                }
                            }
                        }
                        catch
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "打印出错,请正确设置打印机");
                        }
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前订单没有任何在住客人信息,打印终止!");
                    }
                }
            }

        }

        private string GetYsk(string lsbh)
        {
            decimal ysk_tj = 0;
            DataSet ds = null;
            BLL.Szwzd B_szwzd = new Hotel_app.BLL.Szwzd();
            ds = B_szwzd.GetList("  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "' ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ysk_tj = decimal.Parse(ds.Tables[0].Rows[0]["fkje"].ToString());
            }
            else
            {
                ysk_tj = 0;
            }
            return ysk_tj.ToString();
        }
        #endregion

        #region 押金单区域打印的部分
        private void inital_2()
        {
            try
            {
                if (ds_printData != null && ds_printData.Tables[0].Rows.Count > 0)
                {
                    if (zd_yjd_type == "A4_With_nohead")
                    {
                        Szwgl.cr_yj_gl_print_A4 myreport = new cr_yj_gl_print_A4();
                        myreport.SetDataSource(ds_printData.Tables[0]);
                        //定义水晶报表的数据库连接信息
                        crystalReportViewer1.ReportSource = myreport;
                        for (int i = 0; i < zd_yjd_gl_times; i++)
                        {
                            myreport.PrintToPrinter(1, true, 0, 0);
                        }
                    }
                    if (zd_yjd_type == "A4_yx_dh")
                    {
                        Szwgl.cr_yj_gl_print_A4_dh myreport = new cr_yj_gl_print_A4_dh();
                        myreport.SetDataSource(ds_printData.Tables[0]);
                        //定义水晶报表的数据库连接信息
                        crystalReportViewer1.ReportSource = myreport;

                        myreport.SetParameterValue("qydz", Address_chinese);
                        myreport.SetParameterValue("qydzyw", Address_english);
                        myreport.SetParameterValue("qydh", qydh);
                        myreport.SetParameterValue("qycz", qycz);
                        myreport.SetParameterValue("website", website);




                        for (int i = 0; i < zd_yjd_gl_times; i++)
                        {
                            myreport.PrintToPrinter(1, true, 0, 0);
                        }
                    }
                    if (zd_yjd_type == "A5")
                    {
                        Szwgl.cr_yj_gl_print_A5 myreport = new cr_yj_gl_print_A5();
                        myreport.SetDataSource(ds_printData.Tables[0]);
                        //定义水晶报表的数据库连接信息
                        crystalReportViewer1.ReportSource = myreport;

                        //myreport.SetParameterValue("qymc", qymc);
                        //myreport.SetParameterValue("qymcyw", qymc_english);
                        //myreport.SetParameterValue("qydh", qydh);
                        //myreport.SetParameterValue("qycz", qycz);
                        //myreport.SetParameterValue("qyyb", qyyb);
                        //myreport.SetParameterValue("website", website);
                        //myreport.SetParameterValue("qydz", Address_chinese);
                        //myreport.SetParameterValue("qydzyw", Address_english);
                        for (int i = 0; i < zd_yjd_gl_times; i++)
                        {
                            myreport.PrintToPrinter(1, true, 0, 0);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "打印出错,请重启酒店管理系统重试!");
            }

 
        }
        #endregion
    }
}