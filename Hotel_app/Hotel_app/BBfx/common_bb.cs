using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using Maticsoft.Common;

namespace Hotel_app.BBfx
{
   public static    class common_bb
    {
        //这三个值用来判断报表分析哪一种类型时使用这个一定要在表里有相对应的字段名称才可以
        public static string xsy_krly_xydw_xsy = "xsy";
        public static string xsy_krly_xydw_krly = "krly";
        public static string xsy_krly_xydw_xydw = "xydw";
        public static string xsy_krly_xydw_pq = "pq";
        public static string xsy_krly_xydw_krgj = "krgj";
        public static string xsy_krly_xydw_gj_sf = "gj_sf";
        public static string xsy_krly_xydw_gj_cs = "gj_cs";

        //日的成本单价来源于当月的初期成本
        public static string kc_rx_qc_r = "日期初";
        public static string kc_rx_rc_r = "日入库";
        public static string kc_rx_ck_r = "日出库";
        public static string kc_rx_tz_r = "日调整";
        public static string kc_rx_qm_r = "日期末";


        public static string kc_rx_qc_y = "月期初";
        public static string kc_rx_rc_y = "月入库";
        public static string kc_rx_ck_y = "月出库";
        public static string kc_rx_tz_y = "月调整";
        public static string kc_rx_qm_y = "月期末";


        public static string kc_cbtj_r = "日统计查询";
        public static string kc_cbtj_y = "月统计查询";




        public static string gz_type = "gz";
        public static string jz_type = "jz";
        private static  string defaulPath = "";//记录导出前上一次的路径

        public static int pddate(int yy, int mm, int ts)
        {
            int dd = 1;
            switch (mm)
            {
                case 2:
                    if (yy % 4 == 0)
                    {
                        dd = 29 - ts;
                    }
                    else
                    {
                        dd = 28 - ts;
                    }
                    break;
                case 4:
                    dd = 30 - ts;
                    break;
                case 6:
                    dd = 30 - ts;
                    break;
                case 9:
                    dd = 30 - ts;
                    break;
                case 11:
                    dd = 30 - ts;
                    break;
                default:
                    dd = 31 - ts;
                    break;
            }
            return dd;

        }

        public static DateTime judge_yfcssj(DateTime drrq, int tzts)
        {

            int yy0 = 200; int mm0 = 1; int dd0 = 1;
            yy0 = drrq.Year;
            mm0 = drrq.Month;
            dd0 = drrq.Day;
            int jsdate = 1;
            int csdate = 1;
            if (tzts > 0)
            {
                tzts = tzts - 1;
                if (mm0 == 1)
                {
                    if (dd0 < (31 - tzts))
                    {
                        jsdate = 1;
                    }
                    else
                    {
                        jsdate = 31 - tzts;
                    }
                }
                else
                {
                    csdate = pddate(yy0, mm0, tzts);
                    if ((dd0 >= csdate) && (mm0 != 12))
                    {
                        jsdate = pddate(yy0, mm0, tzts);
                    }

                    if ((dd0 < csdate) || (mm0 == 12))
                    {
                        if (mm0 != 1)
                        {
                            mm0 = mm0 - 1;
                            jsdate = pddate(yy0, mm0, tzts);
                        }
                    }
                }
            }
            else
                if (tzts == 0)
                {
                    jsdate = 1;
                }
                else if (tzts < 0)
                {
                    if (mm0 == 1)
                    { jsdate = 1; }
                    else
                    {
                        jsdate = 0 - tzts + 1;
                        if (dd0 + tzts <= 0)
                        { mm0 = mm0 - 1; }
                    }

                }
            DateTime result_date = DateTime.Parse(yy0.ToString() + "-" + mm0.ToString() + "-" + jsdate.ToString());
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Xqyxx", "id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["xtyysj"].ToString() != "")
                {
                    if (result_date < DateTime.Parse(DS_temp.Tables[0].Rows[0]["xtyysj"].ToString()))
                    {
                        result_date = DateTime.Parse(DS_temp.Tables[0].Rows[0]["xtyysj"].ToString());
                    }
                }
            }
            DS_temp.Clear();
            DS_temp.Dispose();
            return result_date;
        }


       //协议单位,销售员,国家省份，片区的数据
       public static DataSet GetData(string Time_begin, string Time_end,string fx_Type, string fxdr_value, string with_subCondition, string sub_type, string ls_condition)
       {
           DataSet ds = null;
           BLL.Common B_common = new Hotel_app.BLL.Common();
           //以下生成分析数据
           //string yydh, string qymc, string xsy_krly_xydw, string xsy_krly_xydw_value,
           //bool is_second, string second_value, string other_cond, string czy, 
           //string cssj, string jssj, DateTime czsj, string xxzs
           //string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
           object[] args = new object[12];
           args[0] = common_file.common_app.yydh;
           args[1] = common_file.common_app.qymc;
           args[2] = fx_Type;//销售员
           args[3] = fxdr_value;    //分析类别的值
           args[4] =Convert.ToBoolean(with_subCondition);
           args[5] = sub_type;//生成所有的
           args[6] = ls_condition;
           args[7] = common_file.common_app.czy;
           args[8] = Time_begin;
           args[9] = Time_end;
           args[10] = DateTime.Now;
           args[11] = common_file.common_app.xxzs;//生成所有的

           string result = common_file.common_app.get_failure;
           Hotel_app.Server.BBfx.B_xsy_krly_xydw B_xsy_krly_xydw_serevices = new Hotel_app.Server.BBfx.B_xsy_krly_xydw();

           result = B_xsy_krly_xydw_serevices.bbfx_add_app(common_file.common_app.yydh,common_file.common_app.qymc,
           fx_Type,//销售员
           fxdr_value,    //分析类别的值
           Convert.ToBoolean(with_subCondition),
           sub_type,
            ls_condition,
           common_file.common_app.czy,
           Time_begin,
           Time_end,
            DateTime.Now,
            common_file.common_app.xxzs);
           //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "bbfx_add_app", args);
           if (result!=null&&result== common_file.common_app.get_suc)
           {
               string sql = "id>=0  and   yydh='" + common_file.common_app.yydh + "'  and  type='" + fx_Type + "'  and  czy_temp='" + common_file.common_app.czy + "'  ";
               //if (ls_condition.Trim() != "")
               //{
                //   sql += ls_condition;
              // }
               ds = B_common.GetList(" select * from BQ_syxffx", sql);
           }
           return ds;
       }





       public static DataSet GetDatahy(string Time_begin, string Time_end, string fx_Type, string fxdr_value, string with_subCondition, string sub_type, string ls_condition)
       {
           DataSet ds = null;
           BLL.Common B_common = new Hotel_app.BLL.Common();
           //以下生成分析数据
           //string yydh, string qymc, string xsy_krly_xydw, string xsy_krly_xydw_value,
           //bool is_second, string second_value, string other_cond, string czy, 
           //string cssj, string jssj, DateTime czsj, string xxzs
           string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
           object[] args = new object[12];
           args[0] = common_file.common_app.yydh;
           args[1] = common_file.common_app.qymc;
           args[2] = fx_Type;//销售员
           args[3] = fxdr_value;    //分析类别的值
           args[4] = Convert.ToBoolean(with_subCondition);
           args[5] = sub_type;//生成所有的
           args[6] = ls_condition;
           args[7] = common_file.common_app.czy;
           args[8] = Time_begin;
           args[9] = Time_end;
           args[10] = DateTime.Now;
           args[11] = common_file.common_app.xxzs;//生成所有的

           Hotel_app.Server.BBfx.B_xsy_hykh B_xsy_hykh_services = new Hotel_app.Server.BBfx.B_xsy_hykh();
           string result = B_xsy_hykh_services.bbfx_add_app_hykh(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(),bool.Parse(args[4].ToString()), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(),DateTime.Parse(args[10].ToString()),args[11].ToString());
           //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "bbfx_add_app_hykh", args);
           if (result== common_file.common_app.get_suc)
           {
               string sql = "id>=0  and   yydh='" + common_file.common_app.yydh + "'  and  type='" + fx_Type + "'  and  czy_temp='" + common_file.common_app.czy + "'  ";
               ds = B_common.GetList(" select * from BQ_syxffx", sql);
           }
           return ds;
       }

       //记账，挂账统计分析   //Type是common_bb中的固定值
       public static DataSet GetFXData_j_g(string yydh, string qymc, string cssj, string jssj, string sel_cond, string type, string czy, string czsj, string xxzs)
       {
           DataSet ds = null;
           BLL.Common B_common = new Hotel_app.BLL.Common();
           string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
           object[] args = new object[9];
           args[0] = common_file.common_app.yydh;
           args[1] = common_file.common_app.qymc;
           args[2] = cssj.ToString();
           args[3] = jssj.ToString();
           args[4] = sel_cond;
           args[5] = type;
           args[6] = czy;
           args[7] = czsj;
           args[8] = xxzs;

           Hotel_app.Server.BBfx.B_g_j_fx B_g_j_fx_services = new Hotel_app.Server.BBfx.B_g_j_fx();
           string result = B_g_j_fx_services.get_g_j_fx_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString());
           //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "get_g_j_fx_app", args);
           if (result!=null&&result == common_file.common_app.get_suc)
           {
               string select_str = " id>=0  and  type='" + type + "'  and   czy_temp='" + czy + "'  and  yydh='" + common_file.common_app.yydh + "' ";
               if (sel_cond.Trim() != "")
               {
                   select_str += sel_cond;
               }
               ds = B_common.GetList(" select * from  BS_g_j_fx  ",select_str);
           }
           return ds;
       }

       //记账，挂账明细类别分析
       public static DataSet GetFxData_j_g_mx(string yydh, string qymc, string cssj, string jssj, string sel_cond, string type, string czy,string jzzt, string czsj, string xxzs)
       {
           //yydh, qymc, cssj, jssj, other_cond, type, jzzt, czy_temp, czsj, xxzs
           DataSet ds = null;
           BLL.Common B_common = new Hotel_app.BLL.Common();
           string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
           object[] args = new object[10];
           args[0] = common_file.common_app.yydh;
           args[1] = common_file.common_app.qymc;
           args[2] = cssj.ToString();
           args[3] = jssj.ToString();
           args[4] = sel_cond;
           args[5] = type;
           args[6] = jzzt;
           args[7] = common_file.common_app.czy;
           args[8] = DateTime.Now.ToString();
           args[9] = common_file.common_app.xxzs;

           Hotel_app.Server.BBfx.B_g_j_fx B_g_j_fx_services = new Hotel_app.Server.BBfx.B_g_j_fx();
           string result = B_g_j_fx_services.get_g_j_mxfxData(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString());

           //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "get_g_j_mxfx_app", args);
           if (result!=null&&result == common_file.common_app.get_suc)
           {
               string select_str = " id>=0  and  jzzt!=''   and   czy_temp='" + czy + "'  and  yydh='" + common_file.common_app.yydh + "' ";
               ds = B_common.GetList(" select * from  BB_g_j_mxfx_hz_temp  ", select_str);
           }
           return ds;

       }

       //记/挂账，明细详细分析
       public static DataSet GetFXData_j_g_Mx_xx(string yydh, string qymc, string cssj, string jssj, string sel_cond, string type, string czy, string jzzt, string czsj, string xxzs)
       {
           //yydh, qymc, cssj, jssj, other_cond, type, jzzt, czy_temp, czsj, xxzs
           DataSet ds = null;
           BLL.Common B_common = new Hotel_app.BLL.Common();
           string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
           object[] args = new object[10];
           args[0] = common_file.common_app.yydh;
           args[1] = common_file.common_app.qymc;
           args[2] = cssj.ToString();
           args[3] = jssj.ToString();
           args[4] = sel_cond;
           args[5] = type;
           args[6] = jzzt;
           args[7] = common_file.common_app.czy;
           args[8] = DateTime.Now.ToString();
           args[9] = common_file.common_app.xxzs;

           Hotel_app.Server.BBfx.B_g_j_fx B_g_j_fx_services = new Hotel_app.Server.BBfx.B_g_j_fx();
           string result = B_g_j_fx_services.get_g_j_mxfxData(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString());
           //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "get_g_j_mxfx_app", args);
           if (result== common_file.common_app.get_suc)
           {
               string select_str = " id>=0  and  jzzt!=''   and   czy_temp='" + czy + "'  and  yydh='" + common_file.common_app.yydh + "'  order by  jzzt  desc,xfsj  desc ";
               //if (sel_cond.Trim() != "")
               //{
               //    select_str += sel_cond;
               //}
               ds = B_common.GetList(" select * from  BB_g_j_mxfx_ls  ", select_str);
           }
           return ds;
       }

       //模拟进度条
       public static void displayprogress(ProgressBar pb1)
       {
           if (pb1 != null)
           {
               pb1.Value = 0; 
               pb1.Maximum = 100;
               pb1.Minimum = 0;
               for (int i = 0; i <=100; i++)
               {
                   if (i <= 100)
                   {
                       pb1.Step = 5;
                       pb1.Value = i;
                   }
               }
           }
       }




       /// <summary>
       /// 用于报表导出的
       /// </summary>
       /// <param name="ds"></param>
       public  static  void ExportToExcel(DataSet ds, Hashtable displaycol_nameList)
       {
           common_file.common_app.get_czsj();

           if (ds != null && ds.Tables[0].Rows.Count > 0)
           {
               string filePath = "";
               string fileName = "";
               string get_fileName = "";
               Hashtable nameList = new Hashtable();
               nameList = displaycol_nameList;
               SaveFileDialog saveFileDialog1;
               FolderBrowserDialog folderBrowserDialog1;
               //利用excel对象
               DataToExcel dte = new DataToExcel();
               try
               {
                   common_file.common_app.get_czsj();

                   if (ds.Tables[0].Rows.Count > 0)
                   {

                       common_file.common_app.get_czsj();

                       saveFileDialog1 = new SaveFileDialog();
                       saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";

                       folderBrowserDialog1 = new FolderBrowserDialog();
                       if (defaulPath.Trim() != "")
                       {
                           folderBrowserDialog1.SelectedPath = defaulPath;
                       }
                       if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                       {
                           common_file.common_app.get_czsj();

                           filePath = folderBrowserDialog1.SelectedPath + "\\";
                           defaulPath = folderBrowserDialog1.SelectedPath;
                           get_fileName = dte.DataExcel(ds.Tables[0], "标题", filePath, nameList).Trim();
                           if (get_fileName != "")
                           {
                               fileName = filePath + get_fileName;
                           }
                           else
                           {
                               return;
                           }
                       }
                   }
               }
               catch
               {
                   dte.KillExcelProcess();
               }

               if (get_fileName.Trim() != "")
               {
                   common_file.common_app.get_czsj();

                   common_file.common_app.Message_box_show(common_file.common_app.message_title, "导出成功!");
                   //Response.Redirect((ExcelFolder+"\\"+filename,true);
                   //StreamWriter aWriter = new StreamWriter(fileName); aWriter.Write(fileName); aWriter.Close();
               }
           }
           Cursor.Current = Cursors.Default;
       }


       //导出(导出分三种
       /// <summary>
       /// 用于Excel导出的类
       /// </summary>
       /// <param name="ds">要导出的数据集</param>
       /// <param naem="Type">类型，用来识别字段的</param>
       /// 
       public static void ExportMX(DataSet ds,string  Type)
       {
           common_file.common_app.get_czsj();
           if (common_file.common_roles.get_user_qx("B_bbfx_outPort", common_file.common_app.user_type) ==false)
           { return; }

           System.Collections.Hashtable nameList = new System.Collections.Hashtable();
           //生成列的中文对应表
           if (Type == "mx")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("krxm", "客人姓名");
               nameList.Add("fjrb", "房间类别");
               nameList.Add("fjbh", "房间编号");
               nameList.Add("sktt", "散客团体");
               nameList.Add("xfrq", "消费日期");
               nameList.Add("xfsj", "消费时间");
               nameList.Add("xfdr", "消费大类");
               nameList.Add("xfrb", "消费小类");
               nameList.Add("xfxm", "消费项目");
               nameList.Add("jjje", "进价金额");
               nameList.Add("sjxfje", "实际价格");
               nameList.Add("xfsl", "消费数量");
               nameList.Add("mxbh", "明细编号");
               nameList.Add("zjhm", "证件号码");
               nameList.Add("yxzj", "有效证件");
               nameList.Add("krly", "客人来源");
               nameList.Add("xydw", "协议单位");
               nameList.Add("xyh", "协议号");
               nameList.Add("krsj", "会员卡号");
               nameList.Add("krgj", "客人国家");
               nameList.Add("pq", "片区");
               nameList.Add("gj_sf", "省份");
               nameList.Add("gj_cs", "城市");
               nameList.Add("gj_dq", "地区");
               nameList.Add("xfzy", "消费摘要");
               nameList.Add("xfbz", "消费备注");
               nameList.Add("xsy", "销售员");
               nameList.Add("czy", "操作员");
           }
           if (Type == "MultiType")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("type", "类别");
               nameList.Add("fxdr", "分析大类");
               nameList.Add("fxrb", "分析类别");
               nameList.Add("zyye", "总营业额");
               nameList.Add("czfs", "出租房数");
               nameList.Add("pjczl", "平均出租率");
               nameList.Add("xd_pjczl", "相对平均出租率");

               nameList.Add("pjfj", "平均房价");
               nameList.Add("jcb", "交叉比");

               nameList.Add("cssj", "初始时间");
               nameList.Add("jssj", "结束时间");

               nameList.Add("pjbl", "平均比率");
               nameList.Add("xd_pjbl", "相对平均比率");
           }
           if (Type == "jzgzfx")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("jzzt", "账务主体");
               nameList.Add("type", "类别");
               nameList.Add("zfh", "房费总计");
               nameList.Add("ds", "代收");
               nameList.Add("qt", "其它");
               nameList.Add("zyye", "总营业额");
               nameList.Add("zzz", "转在住");
               nameList.Add("zgz_zjz", "记转挂/挂转记");
               nameList.Add("zsz", "转结账");
               nameList.Add("wj", "未结");
               nameList.Add("cssj", "统计起始时间");
               nameList.Add("jssj", "统计结束时间");
           }
           if (Type == "jzgzyefx")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("jzzt", "账务主体");
               nameList.Add("type", "类别");
               nameList.Add("zfh", "房费总计");
               nameList.Add("ds", "代收");
               nameList.Add("qt", "其它");
               nameList.Add("wj", "未结");
           }

           if (Type == "jzgztj")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("jzzt", "账务主体");


               nameList.Add("xfdr", "消费大类");
               nameList.Add("xfrb", "消费小类");
               nameList.Add("xfxm", "消费项目");

               nameList.Add("xfrq", "消费日期");
               nameList.Add("xfsj", "消费时间");
               nameList.Add("sjxfje", "消费金额");

               nameList.Add("xyh", "协议号");
           }
           if (Type == "jzgzxx")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("krxm", "客人姓名");
               nameList.Add("fjrb", "房间类别");
               nameList.Add("fjbh", "房间编号");
               nameList.Add("sktt", "散客团体");
               nameList.Add("xfrq", "消费日期");
               nameList.Add("xfsj", "消费时间");
               nameList.Add("xfdr", "消费大类");
               nameList.Add("xfrb", "消费小类");
               nameList.Add("xfxm", "消费项目");
               nameList.Add("xfbz", "消费备注");
               nameList.Add("xfzy", "消费摘要");
               nameList.Add("jjje", "进价金额");
               nameList.Add("sjxfje", "实际价格");
               nameList.Add("xfsl", "消费数量");
               nameList.Add("mxbh", "明细编号");
               nameList.Add("czy_bc", "操作员班次");
               nameList.Add("czsj", "操作时间");
               nameList.Add("tfsj", "离开时间");
               nameList.Add("syzd", "收银点");
               nameList.Add("xyh", "协议号");
               nameList.Add("jzzt", "账务主体");
               nameList.Add("fkfs", "付款方式");
           
           }
           if (Type == "cy")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("czy", "操作员");
               nameList.Add("krxm", "客人姓名");
               nameList.Add("lsbh", "临时编号");
               nameList.Add("fjbh", "房间编号");
               nameList.Add("sjfjjg", "实际房价");

               nameList.Add("shqh", "是否全含");
               nameList.Add("xydw", "协议单位");
               nameList.Add("krly", "客人来源");

               nameList.Add("sktt", "散客团体");
               nameList.Add("shtt", "是否团体");
               nameList.Add("ddsj", "抵达时间");
               nameList.Add("lksj", "离开时间");

               nameList.Add("lz", "是否联账");
               nameList.Add("lzbh", "联账编号");
               nameList.Add("fjdh", "房间电话");
               nameList.Add("dhfj", "分机号");

               nameList.Add("fkje", "付款金额");
               nameList.Add("xfje", "消费金额");
               nameList.Add("yj_xfje", "预收款_消费");
               nameList.Add("ye", "余额");
           }

           if (Type == "zdkrdqtj")
           {
               nameList = new Hashtable();
               nameList.Add("krxm", "客人姓名");
               nameList.Add("krxb", "客人性别");
               nameList.Add("yxzj", "有效证件");
               nameList.Add("zjhm", "证件号码");
               nameList.Add("krgj", "客人国家");
               nameList.Add("ddsj", "到店时间");
               nameList.Add("czsj", "离店时间");
           }

           if (Type == "hykxsfx")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("type", "类别");
               nameList.Add("fxdr", "分析大类");
               nameList.Add("fxrb", "分析类别");
               nameList.Add("zyye", "总营业额");
               nameList.Add("czfs", "出租房数");
               nameList.Add("pjczl", "平均出租率");
               nameList.Add("xd_pjczl", "相对平均出租率");

               nameList.Add("pjfj", "平均房价");
               nameList.Add("jcb", "交叉比");

               nameList.Add("cssj", "初始时间");
               nameList.Add("jssj", "结束时间");

               nameList.Add("pjbl", "平均比率");
               nameList.Add("xd_pjbl", "相对平均比率");
           }
           if (Type == "hykxffx")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("czy", "操作员");
               nameList.Add("krxm", "客人姓名");
               nameList.Add("lsbh", "临时编号");
               nameList.Add("fjbh", "房间编号");
               nameList.Add("fjrb", "房类");
               nameList.Add("sjfjjg", "实际房价");
               nameList.Add("xfsl", "数量");

               nameList.Add("xfrq", "消费日期");
               nameList.Add("xfsj", "消费时间");
               nameList.Add("xfdr", "大类");


               nameList.Add("xfrb", "小类");
               nameList.Add("xfxm", "项目");
               nameList.Add("jzbh", "结账编号");

               nameList.Add("xsy", "销售员");
               nameList.Add("hykh_bz", "会员卡号");

           }

           common_bb.ExportToExcel(ds, nameList);
           Cursor.Current = Cursors.Default;
       }







       internal static DataSet GetFXData_j_g_ye(string yydh, string qymc, string type, string czy_temp, string ls_cond, string czsj, string xxzs)
       {
           DataSet ds = null;
           BLL.Common B_common = new Hotel_app.BLL.Common();
           string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
           object[] args = new object[7];
           args[0] = common_file.common_app.yydh;
           args[1] = common_file.common_app.qymc;
           args[2] = type;
           args[3] = common_file.common_app.czy;
           args[4] = ls_cond;
           args[5] = DateTime.Now.ToString();
           args[6] = xxzs;

           Hotel_app.Server.BBfx.B_g_j_fx B_g_j_fx_services = new Hotel_app.Server.BBfx.B_g_j_fx();
           string result = B_g_j_fx_services.get_g_j_ye(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString());
           //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "get_g_j_ye", args);
           if (result != null && result == common_file.common_app.get_suc)
           {
               string select_str = " id>=0    and   czy_temp='" + czy_temp + "'  and  yydh='" + common_file.common_app.yydh + "' ";
               if (ls_cond.Trim() != "")
               {
                   select_str += ls_cond;
               }
               ds = B_common.GetList(" select * from  BBfx_s_g_j_ye_ls  ", select_str);
           }
           return ds;
       }
   }
}
