using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using System.Windows.Forms;
using Hotel_app.common_file;

namespace Hotel_app.Szwgl
{
    public  static  class common_zw
    {
        public static string zwcl_caiz = "拆账";
        public static string zwcl_bz = "补账";
        public static string zwcl_congz = "冲账";

        public static string jbjk_jb = "jb";//交班
        public static string jbjk_jk = "jb";//交款

        public static string zwzz_sk_tt = "单间-团队";
        public static string zwzz_sk_sk = "单间-单间";
        public static string zwzz_tt_sk = "团队-单间";
        public static string zwzz_tt_tt = "团队-团队";

        //从jjzwll里进入时有这几种状态
        public static string zwzz_jz_tt = "记账-团队";
        public static string zwzz_jz_sk = "记账-单间";

        public static string zwzz_gz_tt = "挂账-团队";
        public static string zwzz_gz_sk = "挂账-单间";

        public static string fwrx_abl = "按百分比率";
        public static string fwrx_sjje = "按实际金额";

        public static string dr_ff = "房费";
        public static string qtff = "其他费用";
        public static string dr_ds = "代收";
        public static string ff_kffy = "审核房费";
        //public static string ff_sqff = "审前房费";如果要分出单审的房费把这个启用，其余关闭
        public static string ff_jsqtfy = "加收全天房费";
        public static double ff_jsqtfy_sl = 1.0;
        public static string ff_jsbtfy = "加收半天房费";
        public static double ff_jsbtfy_sl = 0.5;
        public static string ff_jcfy = "加床房费";
        public static double ff_jcfy_sl = 0.5;
        public static string jb_jk_jb = "jb";
        public static string jb_jk_jk = "jk";

        public static string xydw_xy = "协议单位";
        public static string xydw_gz = "挂账单位";

        public static string gzpj_flage = "挂账批结";//这个只是用来标识是挂账批结的，不允许其撤销


        public static decimal GetValue(string colName, string TableName,string condition)
        {
            object obj = DbHelperSQL.GetSingle("select  " + colName + " from  " + TableName + "  " + condition);
            if (obj != null)
            {
                return decimal.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static void Get_xf_info(string xrbh,string  xfxm_temp,out string xftm, out string xfdr, out string xfrb,out string mxbh, out decimal xfje, out decimal jjje, out string xfxm)
        {
            xfdr = ""; xfrb = ""; mxbh = ""; xfje = 0; jjje = 0; xfxm = ""; string s_0 = ""; xftm = "";
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            if (xfxm_temp.Trim() != "")
            { s_0 = "  and  xfmx='" + xfxm_temp + "'"; }
            DataSet DS_temp = B_Common.GetList("select * from Xxfmx", "xrbh='" + xrbh + "'" + s_0);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            { 
                xfdr=DS_temp.Tables[0].Rows[0]["xfdr"].ToString();
                xfrb = DS_temp.Tables[0].Rows[0]["xfxr"].ToString();
                xfje =decimal.Parse (DS_temp.Tables[0].Rows[0]["xfje"].ToString());
                jjje = decimal.Parse(DS_temp.Tables[0].Rows[0]["jjje"].ToString());
                xfxm = DS_temp.Tables[0].Rows[0]["xfmx"].ToString();
                mxbh = DS_temp.Tables[0].Rows[0]["mxbh"].ToString();
                xftm = DS_temp.Tables[0].Rows[0]["xftm"].ToString();
            }
            DS_temp.Dispose();
        
        }

        public  static string Getjjje(string xrbh, string mxbh)//小类编号，明细编号
        {
            DataSet ds_temp; BLL.Xxfmx B_Xxfmx = new Hotel_app.BLL.Xxfmx();
            ds_temp = B_Xxfmx.GetList("id>=0  " + common_file.common_app.yydh_select + " and xrbh='" + xrbh + "'   and  mxbh='" + mxbh + "'");
            if (ds_temp!=null&&ds_temp.Tables[0].Rows.Count>0)
            {
                return ds_temp.Tables[0].Rows[0]["jjje"].ToString();
            }
            else
            {
                return "0.0";
            }
        }

        public static  string GetXfdrByXrbh(string xrbh) //由Xxfxr_xrbh来获取xfdr
        {
            if (xrbh.Trim() != "")
            {
                BLL.Xxfxr B_Xxfxr = new Hotel_app.BLL.Xxfxr();
                return B_Xxfxr.GetModelList("xrbh='" + xrbh + "'")[0].xfdr.ToString();
            }
            else
            {
                return "";
            }
        }

        public static  void display_new_commonform_1(string judge_type_0,out string xftm,out string xrbh_0,out string xfxm_0, int left_0,int top_0, string parameter)//重载带载入参数的
        {
            xrbh_0 = parameter;
            xfxm_0 = "";
            xftm = "";
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.parameter = parameter;
            X_common_one_new.Left = left_0 ;
            X_common_one_new.Top =top_0;
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                xrbh_0 = X_common_one_new.get_bh;
                xfxm_0 = X_common_one_new.get_value;
                xftm = X_common_one_new.get_tm;
            }
            X_common_one_new.Dispose();
            Cursor.Current = Cursors.Default;
        }

        //取消锁账
        public static void Unlock(string zwzd_id)
        {
            if (zwzd_id.Trim() != "")
            {
                //先检查是否有过夜审
                BLL.Common B_common = new Hotel_app.BLL.Common();
                DataSet ds_0 = null;
                ds_0 = B_common.GetList("select * from Sjzzd ", " id>=0 and  yydh='" + common_file.common_app.yydh + "' and  id='" + zwzd_id + "'  and shys=1 ");
                if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                {
                     if(common_file.common_app.message_box_show_select(common_file.common_app.message_title,"你是否真的要取消锁账?")==true)
                     {
                          string krxm=ds_0.Tables[0].Rows[0]["krxm"].ToString();
                          string sql=" update  Sjzzd  set  shys=0  where  yydh='"+common_file.common_app.yydh+"' and id='"+zwzd_id+"'";
                          if(B_common.ExecuteSql(sql)>0)
                          {
                               common_file.common_app.Message_box_show(common_file.common_app.message_title,"取消锁账成功");
                              common_file.common_czjl.add_czjl(common_file.common_app.yydh,common_file.common_app.qymc,common_file.common_app.czy,"取消锁账",krxm,"",DateTime.Now);
                          }
                     }
                }
            }
        }

        //团体成员房费设置
        public static string SetTTcyFF(string zd_id, string sktt)
        {
            string s = common_file.common_app.get_failure;
            if (zd_id.Trim() != "")
            {
                BLL.Common B_common = new Hotel_app.BLL.Common();
                StringBuilder sb = new StringBuilder();
                DataSet ds_0 = null;
                //查找团体成员主单(注意，这里的"sk"是指的团体成员
                if (sktt == "sk")
                {
                    sb = new StringBuilder();
                    ds_0 = B_common.GetList(" select * froM Qskyd_mainrecord ", " id>=0 and yydh='" + common_file.common_app.yydh + "' and  id='" + zd_id + "'  and main_sec='" + common_file.common_app.main_sec_main + "'");
                    if (ds_0.Tables[0].Rows.Count > 0)
                    {
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "真的要设置此客人房费自付嘛？") == true)
                        {
                            sb=new StringBuilder();
                            sb.Append(" update  Qskyd_mainrecord set  ffzf=1  where id='" + zd_id + "' and yydh='" + common_file.common_app.yydh + "'");
                            if (B_common.ExecuteSql(sb.ToString()) > 0)
                            {
                                s = common_file.common_app.get_suc;
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "设置成功");
                                common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "设置房费自付", "", ds_0.Tables[0].Rows[0]["lsbh"].ToString(), DateTime.Now);
                            }
                        }
                    }
                }
                //设置所有的团体成员的ffzf为1
                if (sktt == "tt")
                {
                    string ddbh_0 = "";
                    ds_0 = B_common.GetList(" select  *  from Qttyd_mainrecord  ", "  id>=0  and yydh='" + common_file.common_app.yydh + "' and id='" + zd_id + "'");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        ddbh_0 = ds_0.Tables[0].Rows[0]["ddbh"].ToString();
                        ds_0 = B_common.GetList("select * from Qskyd_mainrecord ", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and  ddbh='" + ddbh_0 + "'");
                        if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                        {
                            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你确定要设置该团下所有成员均房费自付嘛？") == true)
                            {
                                sb = new StringBuilder();
                                sb.Append(" update  Qskyd_mainrecord set  ffzf=1  where ddbh='" + ddbh_0 + "' and yydh='" + common_file.common_app.yydh + "'");
                                if (B_common.ExecuteSql(sb.ToString()) > 0)
                                {
                                    s = common_file.common_app.get_suc;
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "设置成功");
                                    common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "设置房费自付", "", ddbh_0, DateTime.Now);
                                }


                            }
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前团队下无任何成员！");
                        }
                    }
                }
            }
            return s;
        }

        //通过协议单位获取协议号(xy_Type为gz或者为xy)
        public static string GetxyhByxydw(string jzzt, string yydh,string  xy_Type)
        {
            if (jzzt.Trim() != "")
            {
                object xyh=null;
                if (xy_Type == "xy")
                {
                     xyh = DbHelperSQL.GetSingle("select top 1  xyh  from  Yxydw where  id>=0   and   xydw='" + jzzt + "'  and  rx='"+common_zw.xydw_xy+"' ");
                }
                if(xy_Type=="gz")
                {
                    xyh = DbHelperSQL.GetSingle(" select top 1 xyh from Yxydw where id>=0   and xydw='" + jzzt + "' and yydh='" + common_file.common_app.yydh + "' and rx='" + common_zw.xydw_gz + "' ");
                }
                if (xyh != null)
                {
                    return xyh.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }


        //检查挂账单位的挂账额度是否超出
        public static bool Check_gzed(string  xyh,string jzzt,decimal  gz_je,out string info)
        {
            bool Result = false; decimal gz_ed = 0, gz_ygje = 0; info = "";
            if (jzzt != ""&&xyh!="")
            {
                BLL.Common B_common = new Hotel_app.BLL.Common();
                DataSet ds = B_common.GetList(" SELECT  * FROM  Yxydw  ", "  yydh='" + common_file.common_app.yydh + "'  and   xydw='" + jzzt + "' and xyh='" + xyh + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataSet DS_1 = B_common.GetList(" SELECT sum(sjxfje)  as   gz_ygje   from VIEW_S_gz_ye ", " xfdr!='" + common_file.common_app.fkdr + "'  and   jzzt='" + jzzt + "'  and  xyh='" + xyh + "'");
                    if (DS_1 != null && ds.Tables[0].Rows.Count > 0 && DS_1.Tables[0].Rows[0]["gz_ygje"] != null && DS_1.Tables[0].Rows[0]["gz_ygje"].ToString() != "")
                    {
                        gz_ygje = decimal.Parse(DS_1.Tables[0].Rows[0]["gz_ygje"].ToString());
                    }
                    gz_ed = decimal.Parse(ds.Tables[0].Rows[0]["xsed"].ToString());
                    if (gz_je + gz_ygje - gz_ed < 0)
                    {
                        return Result = true;
                    }
                    else
                    {
                        info += "对不起,挂账单位:" + jzzt + "的授信金额最多为:" + gz_ed.ToString() + ",当前以经挂账的金额为" + gz_ygje.ToString() + ",本次挂账金额:" + gz_je.ToString() + ",以经超过挂账授信的余额:" + (gz_ed - gz_ygje).ToString() + ",如果仍然要挂账,请提高此单位的挂账额度!";
                    }
                }
                else
                {
                    info += "对不起,没有找到该挂账单位的挂账额度,请先设置此挂账单位的挂账额度";
                }
            }
            else
            {
                info += "对不起,没有找到该挂账单位,请检查挂账单位设置！";
            }
            return Result;
        }

        public static  string GetXyhByXxydw(string xydw)
        {
            string xyh = "";
            BLL.Yxydw B_Yxydw = new Hotel_app.BLL.Yxydw();
            Model.Yxydw M_yxydw = new Hotel_app.Model.Yxydw();
            List<Model.Yxydw> list_temp = B_Yxydw.GetModelList("  yydh='" + common_file.common_app.yydh + "' and  xydw='" + xydw + "'  and rx='" + common_file.common_xydw.xyrx_gzdw + "'");
            if (list_temp != null && list_temp.Count > 0)
            {
                return xyh = list_temp[0].xyh;
            }
            return xyh;
        }

        //检查记账总数是否超过临时限额
        public static bool Check_jzed(string  _jz_je, out string info)
        {
            bool Result = false; decimal jz_je = 0; info = "";
            BLL.Common  B_common=new Hotel_app.BLL.Common();
            BLL.Qcounter B_Qcounter = new Hotel_app.BLL.Qcounter();
            List<Model.Qcounter> list_temp = new List<Hotel_app.Model.Qcounter>();
            list_temp = B_Qcounter.GetModelList("  yydh='" + common_file.common_app.yydh + "'");
            try
            {
                jz_je = decimal.Parse(_jz_je);
            }
            catch 
            {
                 info+="系统错误,请联系系统管理员！";
                 return Result;
            }
            if (list_temp != null && list_temp.Count > 0)
            {
                 //计算统计的初始时间
                 int  tj_sj=-(list_temp[0].jz_ts);
                 decimal jz_total = list_temp[0].jz_ls_total;
                 decimal  jz_total_yj=0;
                 //string  cssj=DateTime.Parse(DateTime.Now.AddDays(tj_sj).ToShortDateString();
                 //统计当前时间段的计账总额
                
                DataSet  ds_0= B_common.GetList(" select sum(sjxfje)  as   jz_total from  VIEW_S_jz_ye  ",  "  xfdr!='"+common_app.fkdr+"' and  yydh='"+common_app.yydh+"'  and  xfsj>='"+DateTime.Now.AddDays(tj_sj).ToShortDateString()+"'  and xfsj<'"+DateTime.Now.ToString()+"'");
                if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                {
                    if (ds_0.Tables[0].Rows[0]["jz_total"] != null && ds_0.Tables[0].Rows[0]["jz_total"].ToString() != "")
                    {
                        jz_total_yj = decimal.Parse(ds_0.Tables[0].Rows[0]["jz_total"].ToString());
                        if (jz_total_yj + jz_je - jz_total > 0)
                        {
                            info += "对不起,当前以经记账为:" + jz_total_yj.ToString() + ",系统设置的记账总额为:" + jz_total.ToString() + ",此次记账:" + jz_je.ToString() + "以经超过了记账的剩余额度:" + (jz_total - jz_total_yj).ToString() + ",请联系系统管理员或者相应值班经理提升记账总额,系统当前无法记账这笔金额";
                            return Result = false;
                        }
                        else
                        {
                            return Result = true;
                        }
                    }
                    else
                    {
                        jz_total_yj = 0;
                        if (jz_total_yj + jz_je - jz_total > 0)
                        {
                            info += "对不起,当前以经记账为:" + jz_total_yj.ToString() + ",系统设置的记账总额为:" + jz_total.ToString() + ",此次记账:" + jz_je.ToString() + "以经超过了记账的剩余额度:" + (jz_total - jz_total_yj).ToString() + ",请联系系统管理员或者相应值班经理提升记账总额,系统当前无法记账这笔金额";
                            return Result = false;
                        }
                        else
                        {
                            return Result = true;
                        }

                    }
                }
            }
            else
            {
                info += "请联系系统管理员进行数据库的初始配置";
            }
            return Result;
        }
    }



}
