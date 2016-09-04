using System;
using System.Collections.Generic;
using System.Web;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
//using Microsoft.Office.Core;
using System.Diagnostics;
using System.Reflection;
//using Microsoft.Office;
using Maticsoft.Common;//Interop.Excel;   
  

namespace Hotel_app.common_file
{
   public  class common_DataSetToExcel
    {
       //此类用于导出(除BBFX的导出外，其它内容均利用这个类来导出
       static  string defaulPath = "";
       public static void ExportToExcel(DataSet ds, Hashtable displaycol_nameList,string  otherInfo)
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
                       if (  defaulPath.Trim() != "")
                       {
                           folderBrowserDialog1.SelectedPath = defaulPath;
                       }
                       if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                       {
                           common_file.common_app.get_czsj();

                           filePath = folderBrowserDialog1.SelectedPath + "\\";
                           defaulPath = folderBrowserDialog1.SelectedPath;
                           get_fileName = dte.DataExcel(ds.Tables[0], otherInfo, filePath, nameList).Trim();
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

       //Type用于标识哪个地方要用的
       public static void ExportMX(DataSet ds, string Type,string strTitle)
       {
           common_file.common_app.get_czsj();
           System.Collections.Hashtable nameList = new System.Collections.Hashtable();
           //生成列的中文对应表
           if (Type == "skdj_current"||Type=="skdj_lskr")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("lsbh", "临时编号");
               if (Type == "skdj_current")
               {
                   nameList.Add("ddbh", "订单号");
               }
               nameList.Add("hykh", "会员卡号");
               nameList.Add("hyrx", "会员类型");
               nameList.Add("krxm", "客人姓名");
               if (Type == "skdj_current")
               {
                   nameList.Add("tlkr", "同来客人");
               }
               nameList.Add("krgj", "客人国籍");
               nameList.Add("krmz", "客人民族");
               nameList.Add("yxzj", "有效证件");
               nameList.Add("zjhm", "证件号码");
               nameList.Add("krxb", "客人性别");
               nameList.Add("krsr", "客人生日");
               nameList.Add("krdh", "客人电话");
               nameList.Add("krsj", "客人手机");


               nameList.Add("krEmail", "客人Email");
               nameList.Add("krdz", "客人地址");
               nameList.Add("krjg", "客人籍贯");
               nameList.Add("krdw", "客人单位");
               nameList.Add("krzy", "客人职业");
               nameList.Add("cxmd", "出行目的");
               nameList.Add("qzrx", "签证类型");
               nameList.Add("qzhm", "签证号码");
               nameList.Add("zjyxq", "签证有效期");
               nameList.Add("tlyxq", "停留有效期");
               nameList.Add("tjrq", "入境日期 ");
               nameList.Add("lzka", "入境口岸");

               nameList.Add("krly", "客人来源");
               nameList.Add("xyh", "协议号");
               nameList.Add("xydw", "协议单位");
               nameList.Add("xsy", "销售员");
               nameList.Add("ddrx", "抵达类型");
               nameList.Add("ddwz", "抵达位置");
               nameList.Add("zyzt", "登记状态");
               nameList.Add("krrx", "客人类型");
               nameList.Add("kr_children", "携带小孩数");
               nameList.Add("ddsj", "抵达时间");
               nameList.Add("ddyy", "抵达原因");
               nameList.Add("lzts", "入住天数");
               nameList.Add("lksj", "离开时间");
               nameList.Add("qtyq", "其它要求");

               nameList.Add("czy", "操作员");
               nameList.Add("czsj", "操作时间");
               nameList.Add("cznr", "主单操作内容");
               nameList.Add("sktt", "散客团体");
               nameList.Add("yddj", "预订登记");
               nameList.Add("ffshys", "房费是否夜审");
               nameList.Add("ffzf", "房费自付");
               nameList.Add("main_sec", "主要次要客人");
               nameList.Add("syzd", "收银站点");
               nameList.Add("vip_type", "VIP类型");
               nameList.Add("tsyq", "特殊要求");


               nameList.Add("qxyy", "取消原因");
               nameList.Add("ddly", "到达来源");
               nameList.Add("yh", "优惠");

               if (Type == "skdj_current")
               {

                   nameList.Add("yhbl", "优惠比率");
                   nameList.Add("bz", "备注");

               }
               nameList.Add("fjjg", "参考房价");
               nameList.Add("sjfjjg", "实际房价");
               if (Type == "skdj_current")
               {
                   nameList.Add("shqh", "是否全含");
               }
               nameList.Add("lzfs", "入住房数");
               if (Type == "skdj_current")
               {
                   nameList.Add("fjbm", "房间保密");
                   nameList.Add("cznr0", "房类操作内容");
               }
               nameList.Add("jcje", "加床金额");
               nameList.Add("fjrb", "房间类别");
               nameList.Add("fjbh", "房间编号");
               if (Type == "skdj_current")
               {
                   nameList.Add("fkje", "付款金额");
                   nameList.Add("xfje", "消费金额");
               }
           
           }

           if (Type == "skyd_qx")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("lsbh", "临时编号");
               nameList.Add("ddbh", "订单号");
               nameList.Add("hykh", "会员卡号");
               nameList.Add("hyrx", "会员类型");
               nameList.Add("krxm", "客人姓名");
               nameList.Add("tlkr", "同来客人");
               nameList.Add("krgj", "客人国籍");
               nameList.Add("krmz", "客人民族");
               nameList.Add("yxzj", "有效证件");
               nameList.Add("zjhm", "证件号码");
               nameList.Add("krxb", "客人性别");
               nameList.Add("krsr", "客人生日");
               nameList.Add("krdh", "客人电话");
               nameList.Add("krsj", "客人手机");
               
               
               nameList.Add("krEmail", "客人Email");
               nameList.Add("krdz", "客人地址");
               nameList.Add("krjg", "客人籍贯");
               nameList.Add("krdw", "客人单位");
               nameList.Add("krzy", "客人职业");
               nameList.Add("cxmd", "出行目的");
               nameList.Add("qzrx", "签证类型");
               nameList.Add("qzhm", "签证号码");
               nameList.Add("zjyxq", "签证有效期");
               nameList.Add("tlyxq", "停留有效期");
               nameList.Add("tjrq", "入境日期 ");
               nameList.Add("lzka", "入境口岸");

               nameList.Add("krly", "客人来源");
               nameList.Add("xyh", "协议号");
               nameList.Add("xydw", "协议单位");
               nameList.Add("xsy", "销售员");
               nameList.Add("ddrx", "抵达类型");
               nameList.Add("ddwz", "抵达位置");
               nameList.Add("zyzt", "登记状态");
               nameList.Add("krrx", "客人类型");
               nameList.Add("kr_children", "携带小孩数");
               nameList.Add("ddsj", "抵达时间");
               nameList.Add("ddyy", "抵达原因");
               nameList.Add("lzts", "入住天数");
               nameList.Add("lksj", "离开时间");
               nameList.Add("qtyq", "其它要求");

               nameList.Add("czy", "操作员");
               nameList.Add("czsj", "操作时间");
               nameList.Add("cznr", "主单操作内容");
               nameList.Add("shsc", "是否上传");
               nameList.Add("sktt", "散客团体");
               nameList.Add("yddj", "预订登记");
               nameList.Add("ffshys", "房费是否夜审");
               nameList.Add("ffzf", "房费自付");
               nameList.Add("main_sec", "主要次要客人");
               nameList.Add("sdcz", "锁单操作");
               nameList.Add("syzd", "收银站点");
               nameList.Add("vip_type", "VIP类型");
               nameList.Add("tsyq", "特殊要求");


               nameList.Add("qxyy", "取消原因");
               nameList.Add("ddly", "到达来源");
               nameList.Add("hykh_bz", "会员卡号");

               nameList.Add("bz", "备注");
               nameList.Add("yhbl", "优惠比率");
               nameList.Add("yh", "优惠");
               nameList.Add("fjjg", "参考房价");
               nameList.Add("sjfjjg", "实际房价");
               nameList.Add("shqh", "是否全含");
               nameList.Add("lzfs", "入住房数");
               nameList.Add("fjbm", "房间保密");
               nameList.Add("jcje", "加床金额");
               nameList.Add("fjrb", "房间类别");
               nameList.Add("fjbh", "房间编号");
               nameList.Add("cznr0", "房类操作内容");
 

           }




           if (Type == "Xckcx")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("xfxm", "消费项目");
               nameList.Add("xfdr", "消费大类");
               nameList.Add("xfrb", "消费小类");
               nameList.Add("xfbz", "消费备注");
               nameList.Add("xfzy", "消费摘要");
               nameList.Add("jjje", "进价金额");
               nameList.Add("xfje", "参考价格");
               nameList.Add("sjxfje", "销售价格");
               nameList.Add("xfsl", "出库数量");
               nameList.Add("krxm", "消费客人");
               nameList.Add("fjrb", "房间类别");
               nameList.Add("fjbh", "房间编号");
               nameList.Add("sktt", "散客团队");
               nameList.Add("xfsj", "消费时间");
               nameList.Add("czy", "操作员");
           }

           if (Type == "Fkfxsfx_fxfs") //客房销售分析房数
           {
                            //yydh, qymc, krly, fjrb_fs_1, fjrb_fy_1, fjrb_fs_2, fjrb_fy_2, fjrb_fs_3, fjrb_fy_3, 
      //fjrb_fs_4, fjrb_fy_4, fjrb_fs_5, fjrb_fy_5, fjrb_fs_6, fjrb_fy_6, fjrb_fs_7, fjrb_fy_7, 
      //fjrb_fs_8, fjrb_fy_8, fjrb_fs_9, fjrb_fy_9, fjrb_fs_10, fjrb_fy_10, fjrb_fs_11, fjrb_fy_11, 
      //fjrb_fs_12, fjrb_fy_12, fjrb_fs_13, fjrb_fy_13, fjrb_fs_14, fjrb_fy_14, fjrb_fs_15, 
     // fjrb_fy_15, fjrb_fs_16, fjrb_fy_16, fjrb_fs_17, fjrb_fy_17, fjrb_fs_18, fjrb_fy_18, 
     // fjrb_fs_19, fjrb_fy_19, fjrb_fs_20, fjrb_fy_20, hj_r_fs, hj_r_fy, hj_y_fs, hj_y_fy, 
     // hj_n_fs, hj_n_fy, pjczl, pjfj, pjbl, jcb, czy_temp



               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("krly", "客人来源");
               nameList.Add("fjrb_fs_1", "来源/房类");
               nameList.Add("fjrb_fs_2", "房间类别");
               nameList.Add("fjrb_fs_3", "房间类别");
               nameList.Add("fjrb_fs_4", "房间类别");
               nameList.Add("fjrb_fs_5", "房间类别");
               nameList.Add("fjrb_fs_6", "房间类别");
               nameList.Add("fjrb_fs_7", "房间类别");
               nameList.Add("fjrb_fs_8", "房间类别");
               nameList.Add("fjrb_fs_9", "房间类别");
               nameList.Add("fjrb_fs_10", "房间类别");
               nameList.Add("fjrb_fs_11", "房间类别");
               nameList.Add("fjrb_fs_12", "房间类别");
               nameList.Add("fjrb_fs_13", "房间类别");
               nameList.Add("fjrb_fs_14", "房间类别");
               nameList.Add("fjrb_fs_15", "房间类别");
               nameList.Add("fjrb_fs_16", "房间类别");
               nameList.Add("fjrb_fs_17", "房间类别");
               nameList.Add("fjrb_fs_18", "房间类别");
               nameList.Add("fjrb_fs_19", "房间类别");
               nameList.Add("fjrb_fs_20", "房间类别");
               nameList.Add("hj_r_fs", "本日累计");
               nameList.Add("hj_y_fs", "本月累计");
               nameList.Add("hj_n_fs", "本年累计");
               nameList.Add("pjczl", "平均出租率");
               nameList.Add("pjfj", "平均房价");
               nameList.Add("pjbl", "平均比率");
               nameList.Add("jcb", "交叉比");
           }
           if (Type == "Fkfxsfx_fy")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("fjrb_fy_1", "来源/房类");
               nameList.Add("fjrb_fy_2", "房间类别");
               nameList.Add("fjrb_fy_3", "房间类别");
               nameList.Add("fjrb_fy_4", "房间类别");
               nameList.Add("fjrb_fy_5", "房间类别");
               nameList.Add("fjrb_fy_6", "房间类别");
               nameList.Add("fjrb_fy_7", "房间类别");
               nameList.Add("fjrb_fy_8", "房间类别");
               nameList.Add("fjrb_fy_9", "房间类别");
               nameList.Add("fjrb_fy_10", "房间类别");
               nameList.Add("fjrb_fy_11", "房间类别");
               nameList.Add("fjrb_fy_12", "房间类别");
               nameList.Add("fjrb_fy_13", "房间类别");
               nameList.Add("fjrb_fy_14", "房间类别");
               nameList.Add("fjrb_fy_15", "房间类别");
               nameList.Add("fjrb_fy_16", "房间类别");
               nameList.Add("fjrb_fy_17", "房间类别");
               nameList.Add("fjrb_fy_18", "房间类别");
               nameList.Add("fjrb_fy_19", "房间类别");
               nameList.Add("fjrb_fy_20", "房间类别");

               nameList.Add("hj_r_fy", "本日累计");
               nameList.Add("hj_y_fy", "本月累计");
               nameList.Add("hj_n_fy", "本年累计");

               nameList.Add("pjczl", "平均出租率");
               nameList.Add("pjfj", "平均房价");
               nameList.Add("pjbl", "平均比率");
               nameList.Add("jcb", "交叉比");
           }
           if (Type == "S_jbll_mx"||Type=="S_jkll_mx")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("lsbh", "交班主单编号");
               nameList.Add("syzd", "营业点");
               nameList.Add("syy", "操作员");
               nameList.Add("fkfs", "付款方式");
               nameList.Add("ysk_fs", "预收款_发生");
               nameList.Add("t_ysk_qt", "预收款_退订");
               nameList.Add("t_ysk", "退_预收款_账务");
               nameList.Add("ysk", "预收款_余额");
               nameList.Add("qtfk", "直付-找往来款");
               nameList.Add("qt_yyk", "前台结算总额");
               nameList.Add("qtsk_t_ysk", "财务结算总额");
           }
           if (Type == "S_jbll_t_ysk" || Type == "S_jkll_t_ysk" || Type == "S_jbll_ysk_fs" || Type == "S_jkll_ysk_fs" || Type == "S_jbll_ysk_td" || Type == "S_jkll_ysk_td" || Type == "S_jbll_ysk_ye" || Type == "S_jkll_ysk_ye" || Type == "S_jbll_ysk_qtfk" || Type == "S_jkll_ysk_qtfk"||Type=="S_jkll_zwmx_wj")
           {
               // yydh, qymc, jzbh, lsbh, lsbh_jb, id_app, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, 
              //  xfrb, xfxm, xfbz, xfzy, fkfs, xfje, sjxfje, czy_bc, shsc, syzd, czzt

               //t_ysk-----------BS_jzmx_ls_jb  退预收款-明细-账务
               //S_jbll_ysk_fs-- Syjcz_fs
               //S_jbll_ysk_td-- Syjcz_jb_td  
               //S_jbll_ysk_ye      Syjcz_jb  预收款明细--余额
               //S_jbll_ysk_qtfk    BS_jzmx_ls_jb---直付找往来款
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("lsbh_jb", "交班编号");
               nameList.Add("krxm", "客人姓名");
               nameList.Add("fjrb", "房间类别");
               nameList.Add("fjbh", "房间编号");
               nameList.Add("sktt", "散客团队");
               nameList.Add("xfrq", "消费日期");
               nameList.Add("xfsj", "消费时间");
               nameList.Add("czy", "操作员");
               nameList.Add("xfdr", "消费大类");
               nameList.Add("xfrb", "消费小类");
               nameList.Add("xfxm", "消费项目");
               nameList.Add("xfbz", "消费备注");
               nameList.Add("xfzy", "消费摘要");
               nameList.Add("fkfs", "付款方式");
               if(Type != "S_jbll_ysk_qtfk" &&Type != "S_jkll_ysk_qtfk")
               {
               nameList.Add("xfje", "参考金额");
               }
               nameList.Add("sjxfje", "消费金额");
               if (Type == "S_jbll_ysk_qtfk" || Type == "S_jkll_ysk_qtfk")
               {
                   nameList.Add("xfsl", "消费数量");
               }
               nameList.Add("czy_bc", "操作员班次");
               nameList.Add("syzd", "营业点");
               nameList.Add("czzt", "操作状态");
               if (Type == "S_jbll_ysk_td" || Type == "S_jkll_ysk_td")
               {
                   nameList.Add("czsj", "操作时间");
               }
               if (Type == "S_jbll_ysk_ye" || Type == "S_jkll_ysk_ye")
               {
                    
               }
               if (Type == "S_jbll_ysk_qtfk" || Type == "S_jkll_ysk_qtfk")
               {
                   nameList.Add("tfsj", "退房时间");
                   nameList.Add("czsj", "操作时间");
                   nameList.Add("jzzt", "账务主体");
                   nameList.Add("mxbh", "明细编号");
               }
               if (Type == "S_jkll_zwmx_wj")
               {
                   nameList.Add("jjje", "进价金额");
                   nameList.Add("yh", "优惠");
                   nameList.Add("czsj", "操作时间");
                   nameList.Add("jzzt", "账务主体");
                   nameList.Add("mxbh", "明细编号");

                   nameList.Add("ddsj", "到店时间");
                   nameList.Add("lksj", "离店时间");
                   nameList.Add("krly", "客人来源");
                   nameList.Add("xydw", "协议单位");

               }
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
           //记挂结账务浏览的打印
           if (Type == "jgjzwll")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("jzbh", "结账编号");
               nameList.Add("lsbh", "临时编号");
               nameList.Add("krxm", "客人姓名");
               nameList.Add("fjbh", "房间编号");
               nameList.Add("sktt", "散客团体");
               nameList.Add("xydw", "协议单位");

               nameList.Add("krly", "客人来源");

               nameList.Add("tfsj", "退房时间");
               nameList.Add("czsj", "操作时间");
               nameList.Add("czzt", "退房状态");
               nameList.Add("xyh", "协议号");
               nameList.Add("jzzt", "结账主体");
               nameList.Add("syzd", "收银点");
               nameList.Add("bz", "备注");
               nameList.Add("fp_print", "发票开具情况");
               nameList.Add("fkje", "付款金额");
               nameList.Add("xfje", "消费金额");
               nameList.Add("ddsj", "到达时间");
               nameList.Add("krxm_lz", "联账客人");
               nameList.Add("fjbh_lz", "联账房号");
           }

           if (strTitle.Trim() != "")
           {
               strTitle = common_app.qymc+"-"+ strTitle;
           }
           ExportToExcel(ds, nameList, strTitle);
           Cursor.Current = Cursors.Default;
       }



       public static void ExportMX(DataSet ds,int index_column,DataSet ds_inital_Title, string Type, string strTitle)
       {
           common_file.common_app.get_czsj();
           System.Collections.Hashtable nameList = new System.Collections.Hashtable();
           //生成列的中文对应表
           if (Type == "Fkfxsfx_fxfs") //客房销售分析房数
           {
               //yydh, qymc, krly, fjrb_fs_1, fjrb_fy_1, fjrb_fs_2, fjrb_fy_2, fjrb_fs_3, fjrb_fy_3, 
               //fjrb_fs_4, fjrb_fy_4, fjrb_fs_5, fjrb_fy_5, fjrb_fs_6, fjrb_fy_6, fjrb_fs_7, fjrb_fy_7, 
               //fjrb_fs_8, fjrb_fy_8, fjrb_fs_9, fjrb_fy_9, fjrb_fs_10, fjrb_fy_10, fjrb_fs_11, fjrb_fy_11, 
               //fjrb_fs_12, fjrb_fy_12, fjrb_fs_13, fjrb_fy_13, fjrb_fs_14, fjrb_fy_14, fjrb_fs_15, 
               // fjrb_fy_15, fjrb_fs_16, fjrb_fy_16, fjrb_fs_17, fjrb_fy_17, fjrb_fs_18, fjrb_fy_18, 
               // fjrb_fs_19, fjrb_fy_19, fjrb_fs_20, fjrb_fy_20, hj_r_fs, hj_r_fy, hj_y_fs, hj_y_fy, 
               // hj_n_fs, hj_n_fy, pjczl, pjfj, pjbl, jcb, czy_temp



               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");
               nameList.Add("krly", "客人来源");
               if (ds_inital_Title != null && ds_inital_Title.Tables[0].Rows.Count > 0)
               {
                   for (int i = 1; i < index_column+1; i++)
                   {
                       nameList.Add("fjrb_fs_" + i.ToString(), ds_inital_Title.Tables[0].Rows[0]["fjrb_fs_"+i.ToString()].ToString());
                   }

               }
               //nameList.Add("fjrb_fs_1", ds_inital_Title.Tables[0].Rows[0][0].ToString());
               //nameList.Add("fjrb_fs_2", "房间类别");
               //nameList.Add("fjrb_fs_3", "房间类别");
               //nameList.Add("fjrb_fs_4", "房间类别");
               //nameList.Add("fjrb_fs_5", "房间类别");
               //nameList.Add("fjrb_fs_6", "房间类别");
               //nameList.Add("fjrb_fs_7", "房间类别");
               //nameList.Add("fjrb_fs_8", "房间类别");
               //nameList.Add("fjrb_fs_9", "房间类别");
               //nameList.Add("fjrb_fs_10", "房间类别");
               //nameList.Add("fjrb_fs_11", "房间类别");
               //nameList.Add("fjrb_fs_12", "房间类别");
               //nameList.Add("fjrb_fs_13", "房间类别");
               //nameList.Add("fjrb_fs_14", "房间类别");
               //nameList.Add("fjrb_fs_15", "房间类别");
               //nameList.Add("fjrb_fs_16", "房间类别");
               //nameList.Add("fjrb_fs_17", "房间类别");
               //nameList.Add("fjrb_fs_18", "房间类别");
               //nameList.Add("fjrb_fs_19", "房间类别");
               //nameList.Add("fjrb_fs_20", "房间类别");
               nameList.Add("hj_r_fs", "本日累计");
               nameList.Add("hj_y_fs", "本月累计");
               nameList.Add("hj_n_fs", "本年累计");
               nameList.Add("pjczl", "平均出租率");
               nameList.Add("pjfj", "平均房价");
               nameList.Add("pjbl", "平均比率");
               nameList.Add("jcb", "交叉比");
           }

           if (Type == "Fkfxsfx_fy")
           {
               nameList = new Hashtable();
               nameList.Add("qymc", "企业名称");
               nameList.Add("yydh", "营业代号");

               if (ds_inital_Title != null && ds_inital_Title.Tables[0].Rows.Count > 0)
               {
                   for (int i = 1; i < index_column+1; i++)
                   {
                       nameList.Add("fjrb_fy_" + i.ToString(), ds_inital_Title.Tables[0].Rows[0]["fjrb_fy_" + i.ToString()].ToString());
                   }
               }
               //nameList.Add("fjrb_fy_1", "来源/房类");
               //nameList.Add("fjrb_fy_2", "房间类别");
               //nameList.Add("fjrb_fy_3", "房间类别");
               //nameList.Add("fjrb_fy_4", "房间类别");
               //nameList.Add("fjrb_fy_5", "房间类别");
               //nameList.Add("fjrb_fy_6", "房间类别");
               //nameList.Add("fjrb_fy_7", "房间类别");
               //nameList.Add("fjrb_fy_8", "房间类别");
               //nameList.Add("fjrb_fy_9", "房间类别");
               //nameList.Add("fjrb_fy_10", "房间类别");
               //nameList.Add("fjrb_fy_11", "房间类别");
               //nameList.Add("fjrb_fy_12", "房间类别");
               //nameList.Add("fjrb_fy_13", "房间类别");
               //nameList.Add("fjrb_fy_14", "房间类别");
               //nameList.Add("fjrb_fy_15", "房间类别");
               //nameList.Add("fjrb_fy_16", "房间类别");
               //nameList.Add("fjrb_fy_17", "房间类别");
               //nameList.Add("fjrb_fy_18", "房间类别");
               //nameList.Add("fjrb_fy_19", "房间类别");
               //nameList.Add("fjrb_fy_20", "房间类别");

               nameList.Add("hj_r_fy", "本日累计");
               nameList.Add("hj_y_fy", "本月累计");
               nameList.Add("hj_n_fy", "本年累计");

               nameList.Add("pjczl", "平均出租率");
               nameList.Add("pjfj", "平均房价");
               nameList.Add("pjbl", "平均比率");
               nameList.Add("jcb", "交叉比");
           }






           ExportToExcel(ds, nameList, strTitle);
           Cursor.Current = Cursors.Default;
       }


       public static string GetString(string time)
       {
           //object outString = null;
           object outString = (object)(string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", Convert.ToDateTime(time)));
           return outString.ToString();
       }






        //public static void CreateExcel(DataSet ds, string typeid, string FileName)
        //{
        //    HttpResponse resp;
        //    resp = System.Web.UI.Page.Response;
        //    resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //    resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
        //    string colHeaders = "", ls_item = "";
        //    int i = 0;

        //    //定义表对象和行对像，同时用DataSet对其值进行初始化 
        //    DataTable dt = ds.Tables[0];
        //    DataRow[] myRow = dt.Select("");
        //    // typeid=="1"时导出为EXCEL格式文档；typeid=="2"时导出为XML格式文档 
        //    if (typeid == "1")
        //    {
        //        //取得数据表各列标题，各标题之间以\t分割，最后一个列标题后加回车符 
        //        for (i = 0; i < dt.Columns.Count; i++)
        //        {
        //            if (i == dt.Columns.Count - 1)
        //            {
        //                colHeaders += dt.Columns[i].Caption.ToString() + "\n";
        //            }
        //            else
        //            {
        //                colHeaders += dt.Columns[i].Caption.ToString() + "\t";
        //            }
        //        }
        //        //向HTTP输出流中写入取得的数据信息 
        //        resp.Write(colHeaders);
        //        //逐行处理数据 
        //        foreach (DataRow row in myRow)
        //        {
        //            //在当前行中，逐列获得数据，数据之间以\t分割，结束时加回车符\n 
        //            for (i = 0; i < dt.Columns.Count; i++)
        //            {

        //                if (i == dt.Columns.Count - 1)
        //                {
        //                    ls_item += row[i].ToString() + "\n";
        //                }
        //                else
        //                {
        //                    ls_item += row[i].ToString() + "\t";
        //                }
        //            }
        //            //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据 
        //            resp.Write(ls_item);
        //            ls_item = "";
        //        }
        //    }
        //    else
        //    {
        //        if (typeid == "2")
        //        {
        //            //从DataSet中直接导出XML数据并且写到HTTP输出流中 
        //            resp.Write(ds.GetXml());
        //        }
        //    }
        //    //写缓冲区中的数据到HTTP头文档中 
        //    resp.End();
        //} 


        //public static void ExportToExcel(DataSet dataSet, string fileName)   
        //{   
  
              
        //    //Excel程序   
        //    Microsoft.Office.Interop.Excel.Application excelApplication = new Microsoft.Office.Interop.Excel.Application();   
        //    excelApplication.DisplayAlerts = false;   
        //    //工作簿   
        //    Workbook workbook = excelApplication.Workbooks.Add(Missing.Value);   
        //    //上一个工作簿   
        //    Worksheet lastWorksheet = (Worksheet)workbook.Worksheets.get_Item(workbook.Worksheets.Count);   
        //    //空白工作簿   
        //    Worksheet newSheet = (Worksheet)workbook.Worksheets.Add(Type.Missing, lastWorksheet, Type.Missing, Type.Missing);   
  
        //    foreach (System.Data.DataTable dt in dataSet.Tables)   
        //    {   
        //        newSheet.Name = dt.TableName;   
  
        //        for (int col = 0; col < dt.Columns.Count; col++)   
        //        {   
        //            newSheet.Cells[1, col + 1] = dt.Columns[col].ColumnName;   
        //        }   
        //        for (int row = 0; row < dt.Rows.Count; row++)   
        //        {   
        //            for (int col = 0; col < dt.Columns.Count; col++)   
        //            {   
        //                newSheet.Cells[row + 2, col + 1] = dt.Rows[row][col].ToString();   
        //            }   
        //        }   
        //    }   
  
        //    try  
        //    {   
        //        newSheet.Cells.Font.Size = 12;   
        //        ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Delete();   
        //        ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Delete();   
        //        ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Delete();   
        //        //((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Activate();   
        //        workbook.Close(true, fileName, System.Reflection.Missing.Value);   
        //        MessageBox.Show("成功导出Excel，请查看！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);   
        //        return;   
        //    }   
        //    catch (Exception e)   
        //    {   
        //        throw e;   
        //    }   
        //    finally  
        //    {   
        //        excelApplication.Quit();   
        //        Process[] excelProcesses = Process.GetProcessesByName("EXCEL");   
        //        DateTime startTime = new DateTime();   
  
        //        int processId = 0;   
        //        for (int i = 0; i < excelProcesses.Length; i++)   
        //        {   
        //            if (startTime < excelProcesses[i].StartTime)   
        //            {   
        //                startTime = excelProcesses[i].StartTime;   
        //                processId = i;   
        //            }   
        //        }   
  
        //        if (excelProcesses[processId].HasExited == false)   
        //        {   
        //            excelProcesses[processId].Kill();   
        //        }   
        //    }   
  
        //}   
  
  
    }  
}
