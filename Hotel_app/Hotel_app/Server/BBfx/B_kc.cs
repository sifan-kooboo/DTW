using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hotel_app.Server.BBfx
{
    public class B_kc
    {
        //用于记录夜审时库存生成的日期  renew_tj_kc指示是否重新重计出库
        public string kc_fx(string yydh, string qymc, string czsj, string _renew_tj_kc, string czy_temp, string xxzs)
        {
            string s = common_file.common_app.get_suc;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            int i = 0;
            //首先要查询当天是否有统计过
            DataSet ds = B_Common.GetList(" select  *  from  sqs_ck_tj_date   ", " czsj   between '" + DateTime.Parse(czsj).ToShortDateString() + "' and '" + DateTime.Parse(czsj).ToShortDateString() + " 23:59:59" + "'");
            if ((ds == null || (ds != null && ds.Tables[0].Rows.Count <= 0)))
            {
                DbHelperSQL.ExecuteSql(" insert into  sqs_ck_tj_date(yydh,qymc,tj_rq,czsj,bz)  values('" + yydh + "','" + qymc + "','" + DateTime.Parse(czsj).Date.AddDays(-1) + "','" + czsj + "','新增出库统计成功')");
                i = 1;
            }
            else
            {
                //更新操作时间以及备注信息
                B_Common.ExecuteSql("  update  sqs_ck_tj_date  set  czsj='" + czsj + "',bz='" + ds.Tables[0].Rows[0]["bz"].ToString() + "|由于重做夜审,更新当天的统计时间'  where  id='" + ds.Tables[0].Rows[0]["id"].ToString() + "'  ");
                i = 1;
            }
            if (i == 1)
            {
                Record_kc_tj_mx(yydh, qymc, czsj, czy_temp);
            }
            s = common_file.common_app.get_suc;

            //Gen_r_kc_bb(yydh, qymc, czsj, "", czy_temp, xxzs);

            return s;
        }



        //将要统计的项目详细
        public void Record_kc_tj_mx(string yydh, string qymc, string czsj, string czy_temp)
        {
            string s = common_file.common_app.get_suc;
            string tj_qssj = DateTime.Parse(czsj).AddDays(-1).ToShortDateString();
            string tj_jssj = DateTime.Parse(czsj).ToShortDateString();
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet ds_tj = B_Common.GetList("  select  * from View_kc_notsh ", " 1=1 ");
            if (ds_tj != null && ds_tj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds_tj.Tables[0].Rows.Count; i++)
                {
                    string aa = "  insert  into  Ssyxfmx_kc_sh_temp(yydh,qymc,ckeckTime,xfrq,id_app,mxbh,xfsl,xfje,xfxm,xftm)  values('" + yydh + "','" + qymc + "','" + czsj + "','" + tj_qssj + "','" + ds_tj.Tables[0].Rows[i]["id_app"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["mxbh"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["xfsl"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["xfje"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["xfxm"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["xftm"].ToString() + "')";
                    try
                    {
                        B_Common.ExecuteSql("  insert  into  Ssyxfmx_kc_sh_temp(yydh,qymc,ckeckTime,tjrq,id_app,mxbh,xfsl,xfje,xfxm,xftm,xfsj)  values('" + yydh + "','" + qymc + "','" + czsj + "','" + tj_qssj + "','" + ds_tj.Tables[0].Rows[i]["id_app"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["mxbh"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["xfsl"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["xfje"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["xfxm"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["xftm"].ToString() + "','" + ds_tj.Tables[0].Rows[i]["xfsj"].ToString() + "')");

                    }
                    catch (Exception ee)
                    {
                        FileStream filest = new FileStream(@"F:\ls\测试\error.txt", FileMode.Append, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(filest);
                        sw.Write(ee.ToString() + "</br>" + aa);
                        sw.Close();
                        filest.Dispose();
                    }
                }
            }
            //执行统计更新(更新每种代销品的库存数据)    isCheck字段用来标识些条记录是否被用于库存统计过了

            BLL.Ssyxfmx_kc_sh_temp B_Ssyxfmx_kc_sh_temp_new = new Hotel_app.BLL.Ssyxfmx_kc_sh_temp();
            List<Model.Ssyxfmx_kc_sh_temp> lists = new List<Hotel_app.Model.Ssyxfmx_kc_sh_temp>();
            int id = 0; decimal xf_sl = 0; string mxbh = ""; string xftm = "";
            BLL.Xxfmx B_Xxfmx = new Hotel_app.BLL.Xxfmx();
            List<Model.Xxfmx> list_1 = new List<Hotel_app.Model.Xxfmx>();
            //lists = B_Ssyxfmx_kc_sh_temp_new.GetModelList("   isChecked=0  ");
            lists = B_Ssyxfmx_kc_sh_temp_new.GetModelList(" ischecked=0 ");
            if (lists != null && lists.Count > 0)
            {
                foreach (Model.Ssyxfmx_kc_sh_temp Ssyxfmx_kc_sh_temp in lists)
                {
                    id = Ssyxfmx_kc_sh_temp.id;
                    xf_sl = Ssyxfmx_kc_sh_temp.xfsl;
                    mxbh = Ssyxfmx_kc_sh_temp.mxbh;
                    xftm = Ssyxfmx_kc_sh_temp.xftm;
                    //更新库存
                    list_1 = B_Xxfmx.GetModelList("  mxbh='" + mxbh + "'  and  xftm='" + xftm + "' ");
                    if (list_1 != null && list_1.Count > 0)
                    {
                        Model.Xxfmx M_Xxfmx = list_1[0];
                        M_Xxfmx.id = list_1[0].id;
                        M_Xxfmx.kcsl = list_1[0].kcsl - xf_sl;
                        if (B_Xxfmx.Update(M_Xxfmx))
                        {
                            common_file.common_czjl.add_czjl(yydh, qymc, czy_temp, M_Xxfmx.xfmx, xf_sl.ToString(), "新增消费", DateTime.Parse(czsj));
                            common_file.common_czjl.add_czjl(yydh, qymc, czy_temp, "更新库存数量", M_Xxfmx.mxbh, xf_sl.ToString(), DateTime.Parse(czsj));
                            Ssyxfmx_kc_sh_temp.ischecked = true;
                            Ssyxfmx_kc_sh_temp.id = id;
                            B_Ssyxfmx_kc_sh_temp_new.Update(Ssyxfmx_kc_sh_temp);
                        }
                    }
                }
            }

        }


        //当日出库(库存--出库   在表Ssyxfmx中jjje和sjxfje表示的都为总价,在表Xxfmx中都按单价处理)

        private void Get_kc_ck(string qymc, string yydh, string mxbh, string czsj, string czy_temp, decimal dj_qc, ref  decimal sl_r_ck)
        {
            decimal xf_Today_sl = 0, xf_Today_cb = 0, xf_Today_yye = 0; DataSet ds; sl_r_ck = 0;
            string tj_rq = (DateTime.Parse(czsj).AddDays(-1)).ToShortDateString();//出库的日期
            BLL.Common B_common = new Hotel_app.BLL.Common();

            //获取当日的出库数量
            string sel_s = " yydh='" + yydh + "' and xfsj>='" + tj_rq + "'  and  xfsj<'"+DateTime.Parse(czsj).ToShortDateString()+"'  and   ischecked='1'  and mxbh='" + mxbh + "'";
            ds = B_common.GetList(" select  *  from  Ssyxfmx_kc_sh_temp ", sel_s);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    xf_Today_sl += decimal.Parse(ds.Tables[0].Rows[i]["xfsl"].ToString());
                    xf_Today_yye += decimal.Parse(ds.Tables[0].Rows[i]["xfje"].ToString());
                }
                xf_Today_cb = xf_Today_sl * dj_qc;
                sl_r_ck = xf_Today_sl;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into BB_kc_mx(yydh,qymc,xfdr,drbh,xfxr,xrbh,xfxm,mxbh,sl,rq,xftm,jjdj,xsdj,yhbl,sjxsdj,Total_cb,Total_yye,rx,xfsj) ");
            sb.Append("  select  yydh,qymc,xfdr,drbh,xfxr,xrbh,xfmx,mxbh,'" + xf_Today_sl + "','" + tj_rq + "',xftm,'" + dj_qc + "',xfje,1,xfje,'" + xf_Today_cb + "','" + xf_Today_yye + "','" + Xxtsz.common_kc.kc_rx_ck_r + "','" + tj_rq + "'  from   Xxfmx     ");
            sb.Append("  where   yydh='" + yydh + "'  and   mxbh='" + mxbh + "'");
            //sb.Append(sel_s);
            B_common.ExecuteSql(sb.ToString());
            common_file.common_czjl.add_czjl(yydh, qymc, czy_temp, Xxtsz.common_kc.kc_rx_ck_r, DateTime.Parse(czsj).AddDays(-1).ToShortDateString(), "新增", DateTime.Parse(czsj));
        }

        //生成当日入库
        private void Get_Import_Today(string qymc, string yydh, string mxbh, string czy_temp, string czsj, ref decimal sl_r_rk)
        {
            decimal rk_Today_sl = 0, rk_cb = 0; sl_r_rk = rk_Today_sl = 0;
            decimal xsdj = 0, sjxsdj = 0; StringBuilder sb;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds = null;
            ds = B_common.GetList(" select * from Xxfmx ", "  yydh='" + yydh + "' and  mxbh='" + mxbh + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sjxsdj = xsdj = decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
            }
            string sel_s = " id>=0  and      yydh='" + yydh + "'   and mxbh='" + mxbh + "'  and lksj>='" + DateTime.Parse(czsj).AddDays(-1).ToShortDateString() + "'  and lksj<'" + DateTime.Parse(czsj).ToShortDateString() + "'";
            ds = B_common.GetList(" SELECT sum(xfsl)   as  rk_Today_sl,sum(Total_cb) as rk_cb  FROM View_Xxfmx_lk ", sel_s);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["rk_Today_sl"] != null && ds.Tables[0].Rows[0]["rk_Today_sl"].ToString() != "" && ds.Tables[0].Rows[0]["rk_cb"] != null && ds.Tables[0].Rows[0]["rk_cb"].ToString() != "")
                {
                    sl_r_rk = rk_Today_sl = decimal.Parse(ds.Tables[0].Rows[0]["rk_Today_sl"].ToString());
                    rk_cb = decimal.Parse(ds.Tables[0].Rows[0]["rk_cb"].ToString());
                }
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0&&ds.Tables[0].Rows[0]["rk_Today_sl"] != null && ds.Tables[0].Rows[0]["rk_Today_sl"].ToString() != "")
            {
                sb = new StringBuilder();
                sb.Append(" insert into BB_kc_mx(yydh,qymc,xfdr,drbh,xfxr,xrbh,xfxm,mxbh,sl,rq,xftm,jjdj,xsdj,yhbl,sjxsdj,Total_cb,Total_yye,rx,xfsj) ");
                sb.Append("  select  yydh,qymc,xfdr,drbh,xfxr,xrbh,xfmx,mxbh,'" + rk_Today_sl + "','" + DateTime.Parse(czsj).AddDays(-1).ToShortDateString() + "',xftm,jjdj,'" + xsdj + "','1','" + sjxsdj + "',Total_cb,'" + rk_Today_sl * sjxsdj + "','" + Xxtsz.common_kc.kc_rx_rc_r + "',lksj   from   Xxfmx_lkmx  where  ");
                //sb.Append("  where   yydh='" + yydh + "'  and   mxbh='" + mxbh + "' ");
                sb.Append(sel_s);
                B_common.ExecuteSql(sb.ToString());
            }
            else
            {
                sb = new StringBuilder();
                sb.Append(" insert into BB_kc_mx(yydh,qymc,xfdr,drbh,xfxr,xrbh,xfxm,mxbh,sl,rq,xftm,jjdj,xsdj,yhbl,sjxsdj,Total_cb,Total_yye,rx,xfsj) ");
                sb.Append("  select  yydh,qymc,xfdr,drbh,xfxr,xrbh,xfmx,mxbh,'0','" + DateTime.Parse(czsj).AddDays(-1).ToShortDateString() + "',xftm,jjje,'" + xsdj + "','1','" + sjxsdj + "',0,'0','" + Xxtsz.common_kc.kc_rx_rc_r + "','"+DateTime.Parse(czsj).AddDays(-1).ToShortDateString()+"'   from   Xxfmx    ");
                sb.Append("  where   yydh='" + yydh + "'  and   mxbh='" + mxbh + "' ");
                B_common.ExecuteSql(sb.ToString());
            }
            common_file.common_czjl.add_czjl(yydh, qymc, czy_temp, Xxtsz.common_kc.kc_rx_rc_r, DateTime.Parse(czsj).AddDays(-1).ToShortDateString(), "新增", DateTime.Parse(czsj));
        }


        //通过日期和mxbh获取商品期初的成本价及当前日期的期初数量
        private void Get_qc_Info(string qymc, string yydh, string czsj, string mxbh, ref decimal jjje_qc_y, ref decimal kcsl_qc_y, ref decimal kcsl_qc_r, ref decimal sl_r_tz)
        {
            jjje_qc_y = 0; kcsl_qc_y = 0; kcsl_qc_r = 0; decimal sjxsdj = 0;
            //提前统计的天数
            int ybtqts = 0;
            int i = 0;
            DataSet DS_temp;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DS_temp = B_Common.GetList("select ybtqts from Qcounter", " id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["ybtqts"].ToString() != "")
                {
                    ybtqts = int.Parse(DS_temp.Tables[0].Rows[0]["ybtqts"].ToString());
                }
            }

            DateTime rq = DateTime.Parse(DateTime.Parse(czsj).ToShortDateString()).AddDays(-1);
            DateTime yfcssj = common_bb.judge_yfcssj(rq, ybtqts);
            DS_temp = B_Common.GetList(" select * from BB_Kc_y_tj ", " id>=0  and yydh='" + yydh + "' and  rq='" + yfcssj.ToShortDateString() + "'  and   rx='" + Xxtsz.common_kc.kc_rx_qc_y + "'   and   mxbh='" + mxbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                jjje_qc_y = decimal.Parse(DS_temp.Tables[0].Rows[0]["jjje"].ToString());
                kcsl_qc_y = decimal.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                sjxsdj = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjxsdj"].ToString());
                kcsl_qc_r = kcsl_qc_y;
            }
            string sel_s = "   xfsj>='" + yfcssj.ToShortDateString() + "'  and   xfsj<'" + rq.ToShortDateString() + " 23:59:59" + "'   and mxbh='" + mxbh + "'  and  ischecked=1 ";
            DS_temp = B_Common.GetList("select sum(xfsl ) as zck from Ssyxfmx_kc_sh_temp  ", sel_s);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["zck"] != null && DS_temp.Tables[0].Rows[0]["zck"].ToString() != "")
                {
                    kcsl_qc_r = kcsl_qc_r - decimal.Parse(DS_temp.Tables[0].Rows[0]["zck"].ToString());
                }
            }
            sel_s = "   lksj    between  '" + yfcssj.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'   and mxbh='" + mxbh + "'  ";
            DS_temp = B_Common.GetList("select sum(xfsl ) as zrk  from View_Xxfmx_lk   ", sel_s);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["zrk"] != null && DS_temp.Tables[0].Rows[0]["zrk"].ToString() != "")
                {

                    kcsl_qc_r = kcsl_qc_r + decimal.Parse(DS_temp.Tables[0].Rows[0]["zrk"].ToString());
                }
            }
            sel_s = "   zb_sj    between  '" + yfcssj.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'   and mxbh='" + mxbh + "'  ";
            DS_temp = B_Common.GetList("select sum(zb_sl ) as zzb  from View_Xxfmx_zb   ", sel_s);
            {
                if (DS_temp.Tables[0].Rows[0]["zzb"] != null && DS_temp.Tables[0].Rows[0]["zzb"].ToString() != "")
                {

                    kcsl_qc_r = kcsl_qc_r + decimal.Parse(DS_temp.Tables[0].Rows[0]["zzb"].ToString());
                }
            }



            //判断当日是否有期初行，如果没有(第一天启用库存统计的，那么自动增加当天的期初行
            sel_s = "   yydh='" + yydh + "'  and   rx='" + Xxtsz.common_kc.kc_rx_qc_r + "' and mxbh='" + mxbh + "' and  rq='" + rq.ToShortDateString() + "'";
            DS_temp = B_Common.GetList("select *  from  BB_kc_mx    ", sel_s);
            if (DS_temp == null || DS_temp.Tables[0].Rows.Count <= 0)
            {
                StringBuilder sb = new StringBuilder();
                sb = new StringBuilder();
                sb.Append(" insert into  BB_kc_mx(yydh,qymc,xfdr,drbh,xfxr,xrbh,xfxm,mxbh,sl,rq,xftm,jjdj,xsdj,yhbl,sjxsdj,Total_cb,Total_yye,rx,xfsj) ");
                sb.Append("  select  yydh,qymc,xfdr,drbh,xfxr,xrbh,xfmx,mxbh,'" + kcsl_qc_r + "','" + rq.ToShortDateString() + "',xftm,'" + jjje_qc_y + "','"+sjxsdj+"','1','"+sjxsdj+"','" + jjje_qc_y * kcsl_qc_r + "','" + sjxsdj * kcsl_qc_r + "','" + Xxtsz.common_kc.kc_rx_qc_r + "','" + DateTime.Parse(czsj).AddDays(-1).ToShortDateString() + "'  from   Xxfmx   ");
                sb.Append("  where   yydh='" + yydh + "'  and   mxbh='" + mxbh + "'");
                B_Common.ExecuteSql(sb.ToString());
 
            }




        }

         
        //日审成功后生成日出库表(如果当日是期末那么,会自动生成当期的月出库期末,如果当日是期初,生成月期初库存 )
        public void Gen_r_kc_bb(string yydh, string qymc, string czsj, string _renew_tj_kc, string czy_temp, string xxzs)
        {
            int ybtqts = 0;
            DataSet DS_temp; bool shqm_y = false, shqc_y = false; BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet ds = null;
            DS_temp = B_Common.GetList("select ybtqts from Qcounter", " id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["ybtqts"].ToString() != "")
                {
                    ybtqts = int.Parse(DS_temp.Tables[0].Rows[0]["ybtqts"].ToString());
                }
            }


            //看是否要生成期末库存
            DateTime rq = DateTime.Parse(DateTime.Parse(czsj).ToShortDateString()).AddDays(-1);
            DateTime rq_Now = DateTime.Parse(DateTime.Parse(czsj).ToShortDateString());
            //找到本月的期初时间
            DateTime yfcssj = common_bb.judge_yfcssj(rq, ybtqts);
            //后一天的期初
            DateTime yfcssj_new = common_bb.judge_yfcssj(rq_Now, ybtqts);

            if (yfcssj_new > yfcssj) //当天为期末(生成期末报表) 
            {
                shqm_y = true;
            }
            if(yfcssj.ToShortDateString().Equals(rq.ToShortDateString()))
            {
                shqc_y=true;
            }


            //生成日统计出库报表
            string mxbh = ""; decimal sjxfje = 0;
            decimal jjje_qc_y = 0, sl_qc_y = 0, sl_r_rk = 0, sl_r_ck = 0, sl_r_qm_kc = 0, sl_r_qc_kc = 0, sl_r_tz_kc = 0;
            BLL.Xxfmx B_Xxfmx = new Hotel_app.BLL.Xxfmx();


            ds = B_Xxfmx.GetList("  yydh='" + yydh + "'  and is_tj_kc=1 ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    mxbh = ds.Tables[0].Rows[j]["mxbh"].ToString();
                    sjxfje = decimal.Parse(ds.Tables[0].Rows[j]["xfje"].ToString());

                    Get_qc_Info(qymc, yydh, czsj, mxbh, ref jjje_qc_y, ref sl_qc_y, ref sl_r_qc_kc, ref sl_r_tz_kc);
                    Get_kc_ck(qymc, yydh, mxbh, czsj, czy_temp, jjje_qc_y, ref sl_r_ck);
                    Get_Import_Today(qymc, yydh, mxbh, czy_temp, czsj, ref sl_r_rk);
                    Get_Tz_Today(qymc, yydh, mxbh, czy_temp, czsj,ref  sl_r_tz_kc);

                    //生成日审后当天的库存数
                    sl_r_qm_kc = sl_r_qc_kc + sl_r_rk - sl_r_ck + sl_r_tz_kc;
                    StringBuilder sb = new StringBuilder();
                    sb.Append(" insert into BB_kc_mx(yydh,qymc,xfdr,drbh,xfxr,xrbh,xfxm,mxbh,sl,rq,xftm,jjdj,xsdj,yhbl,sjxsdj,Total_cb,Total_yye,rx,xfsj) ");
                    sb.Append("  select  yydh,qymc,xfdr,drbh,xfxr,xrbh,xfmx,mxbh,'" + sl_r_qm_kc + "','" + DateTime.Parse(czsj).AddDays(-1).ToShortDateString() + "',xftm,'" + jjje_qc_y + "',xfje,'1',xfje,'" + jjje_qc_y * sl_r_qm_kc + "','" + sjxfje * sl_r_qm_kc + "','" + Xxtsz.common_kc.kc_rx_qm_r + "','"+rq.ToShortDateString()+" 23:59:59'   from   Xxfmx   ");
                    sb.Append("  where   yydh='" + yydh + "'  and   mxbh='" + mxbh + "'");
                    B_Common.ExecuteSql(sb.ToString());


                    //生成下一日的期初行
                    sb = new StringBuilder();
                    sb.Append(" insert into  BB_kc_mx(yydh,qymc,xfdr,drbh,xfxr,xrbh,xfxm,mxbh,sl,rq,xftm,jjdj,xsdj,yhbl,sjxsdj,Total_cb,Total_yye,rx,xfsj) ");
                    sb.Append("  select  yydh,qymc,xfdr,drbh,xfxr,xrbh,xfmx,mxbh,'" + sl_r_qm_kc + "','" + DateTime.Parse(czsj).ToShortDateString() + "',xftm,'" + jjje_qc_y + "',xfje,'1',xfje,'" + jjje_qc_y * sl_r_qm_kc + "','" + sjxfje * sl_r_qm_kc + "','" + Xxtsz.common_kc.kc_rx_qc_r + "','"+DateTime.Parse(czsj).AddDays(-1).ToShortDateString()+"'  from   Xxfmx   ");
                    sb.Append("  where   yydh='" + yydh + "'  and   mxbh='" + mxbh + "'");
                    B_Common.ExecuteSql(sb.ToString());
                }
            }
            if (shqm_y) //是期末的话就成生月报表
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    jjje_qc_y = 0; sl_qc_y = 0; sl_r_qc_kc = 0; sl_r_tz_kc = 0;

                    decimal sl_y_qm_kc = 0; decimal sl_y_rk = 0; decimal sl_y_ck = 0; DataSet ds_000 = null;

                    decimal sl_y_tz = 0; decimal je_y_tz_cb = 0;
                    decimal je_y_rk_cb = 0, jjje_qc_y_jc = 0, je_y_ck=0;//加权销售成本
                    decimal sl_qm_y = 0; decimal xfje = 0, je_y_qm_cb = 0;
                    StringBuilder sb; string sel_s;
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        mxbh = ds.Tables[0].Rows[j]["mxbh"].ToString();
                        xfje = decimal.Parse(ds.Tables[0].Rows[j]["xfje"].ToString());
                        Get_qc_Info(qymc, yydh, czsj, mxbh, ref jjje_qc_y, ref sl_qc_y, ref sl_r_qc_kc, ref sl_r_tz_kc);

                        //本月总入库
                        sel_s = " id>=0  and      yydh='" + yydh + "'   and mxbh='" + mxbh + "'  and lksj>='" + yfcssj.ToShortDateString() + "'  and lksj<'" + DateTime.Parse(czsj).ToShortDateString() + "'";
                        ds_000 = B_Common.GetList(" SELECT sum(xfsl)   as  rk_Today_sl,sum(Total_cb) as rk_cb  FROM View_Xxfmx_lk ", sel_s);
                        if (ds_000 != null && ds_000.Tables[0].Rows.Count > 0)
                        {
                            if (ds_000.Tables[0].Rows[0]["rk_Today_sl"] != null && ds_000.Tables[0].Rows[0]["rk_Today_sl"].ToString() != "" && ds_000.Tables[0].Rows[0]["rk_cb"] != null && ds_000.Tables[0].Rows[0]["rk_cb"].ToString() != "")
                            {
                                sl_y_rk = decimal.Parse(ds_000.Tables[0].Rows[0]["rk_Today_sl"].ToString());
                                je_y_rk_cb = decimal.Parse(ds_000.Tables[0].Rows[0]["rk_cb"].ToString());
                            }
                        }
                        if (ds_000 != null && ds_000.Tables[0].Rows.Count > 0)
                        {
                            sb = new StringBuilder();
                            sb.Append(" insert into   bb_kc_y_tj (yydh, qymc, rq, xfdr, drbh, xfxr, xrbh, xfmx, mxbh, xftm, jjje, sjxsdj, yhbl, xsdj, sl, Total_cb, Total_yye, bz, rx )");
                            //sb.Append(" select                    yydh,qymc,'" + DateTime.Parse(DateTime.Parse(czsj).ToShortDateString()) + "',xfdr,drbh,xfxr,xrbh,xfmx,mxbh,xftm,jjdj,'" + xfje + "',1,'" + xfje + "','" + sl_y_rk + "','" + je_y_qm_cb + "','" + xfje * sl_y_rk + "','','" + Xxtsz.common_kc.kc_rx_rc_y + "'  from  Xxfmx_lkmx   where  ");
                            sb.Append(" select                    yydh,qymc,'" + rq.ToShortDateString() + "',xfdr,drbh,xfxr,xrbh,xfmx,mxbh,xftm,jjdj,'" + xfje + "',1,'" + xfje + "','" + sl_y_rk + "','" + je_y_rk_cb + "','" + xfje * sl_y_rk + "','','" + Xxtsz.common_kc.kc_rx_rc_y + "'  from  Xxfmx_lkmx   where  ");
                            sb.Append(sel_s);
                            B_Common.ExecuteSql(sb.ToString());
                        }
                        else//本月没有入库
                        {

                            sb = new StringBuilder();
                            sb.Append(" insert into   bb_kc_y_tj (yydh, qymc, rq, xfdr, drbh, xfxr, xrbh, xfmx, mxbh, xftm, jjje, sjxsdj, yhbl, xsdj, sl, Total_cb, Total_yye, bz, rx )");
                            sb.Append(" select                    yydh,qymc,'" + rq.ToShortDateString() + "',xfdr,drbh,xfxr,xrbh,xfmx,mxbh,xftm,jjdj,'" + xfje + "',1,'" + xfje + "','0','0','0','','" + Xxtsz.common_kc.kc_rx_rc_y + "'  from  Xxfmx_lkmx  where 1=1  ");
                            B_Common.ExecuteSql(sb.ToString());
                        }


                        //本月总出库
                        sel_s = " yydh='" + yydh + "' and xfsj>='" + yfcssj + "' and xfsj<='"+rq.ToShortDateString()+" 23:59:59'   and   ischecked='1'  and mxbh='" + mxbh + "'";
                        ds_000 = B_Common.GetList(" select  *  from  Ssyxfmx_kc_sh_temp ", sel_s);
                        if (ds_000 != null && ds_000.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds_000.Tables[0].Rows.Count; k++)
                            {
                                sl_y_ck += decimal.Parse(ds_000.Tables[0].Rows[k]["xfsl"].ToString());
                                je_y_ck += decimal.Parse(ds_000.Tables[0].Rows[k]["xfje"].ToString());
                            }
                        }
                        if (ds_000 != null && ds_000.Tables[0].Rows.Count > 0)
                        {

                            sb = new StringBuilder();
                            sb.Append(" insert into   bb_kc_y_tj (yydh, qymc, rq, xfdr, drbh, xfxr, xrbh, xfmx, mxbh, xftm, jjje, sjxsdj, yhbl, xsdj, sl, Total_cb, Total_yye, bz, rx )");
                            sb.Append(" select                    yydh,qymc,'" + rq.ToShortDateString() + "',xfdr,drbh,xfxr,xrbh,xfmx,mxbh,xftm,'" + jjje_qc_y + "','" + xfje + "',1,'" + xfje + "','" + sl_y_ck + "','" + je_y_ck + "','" + xfje * sl_y_ck + "','','" + Xxtsz.common_kc.kc_rx_ck_y + "'  from  Xxfmx ");
                            sb.Append("  where  yydh='" + yydh + "' and mxbh='" + mxbh + "'");
                            B_Common.ExecuteSql(sb.ToString());
                        }
                        else
                        {
                            sb = new StringBuilder();
                            sb.Append(" insert into   bb_kc_y_tj (yydh, qymc, rq, xfdr, drbh, xfxr, xrbh, xfmx, mxbh, xftm, jjje, sjxsdj, yhbl, xsdj, sl, Total_cb, Total_yye, bz, rx )");
                            sb.Append(" select                    yydh,qymc,'" + rq.ToShortDateString() +"',xfdr,drbh,xfxr,xrbh,xfmx,mxbh,xftm,'" + jjje_qc_y + "','" + xfje + "',1,'" + xfje + "','0','0','0','','" + Xxtsz.common_kc.kc_rx_ck_y + "'  from  Xxfmx ");
                            sb.Append("  where  yydh='" + yydh + "' and mxbh='" + mxbh + "'");
                            B_Common.ExecuteSql(sb.ToString());

                        }




                        //本月总调整
                        sel_s = "   zb_sj    between  '" + yfcssj.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'   and mxbh='" + mxbh + "'  ";
                        ds_000 = B_Common.GetList("select sum(zb_sl ) as zzb_sl,sum(zb_total_cb)  as  zb_Total_cb   from View_Xxfmx_zb   ", sel_s);
                        {
                            if (ds_000.Tables[0].Rows.Count > 0 && ds_000.Tables[0].Rows[0]["zzb_sl"] != null && ds_000.Tables[0].Rows[0]["zzb_sl"].ToString() != "")
                            {

                                sl_y_tz = sl_y_tz + decimal.Parse(ds_000.Tables[0].Rows[0]["zzb_sl"].ToString());
                                je_y_tz_cb = je_y_tz_cb + decimal.Parse(ds_000.Tables[0].Rows[0]["zb_Total_cb"].ToString());
                            }
                        }
                        if (ds_000.Tables[0].Rows.Count > 0 && ds_000.Tables[0].Rows[0]["zzb_sl"] != null && ds_000.Tables[0].Rows[0]["zzb_sl"].ToString() != "")
                        {
                        sb = new StringBuilder();
                        sb.Append(" insert into   bb_kc_y_tj (yydh, qymc, rq, xfdr, drbh, xfxr, xrbh, xfmx, mxbh, xftm, jjje, sjxsdj, yhbl, xsdj, sl, Total_cb, Total_yye, bz, rx )");
                        sb.Append(" select                    yydh,qymc,'" +rq.ToShortDateString() + "',xfdr,drbh,xfxr,xrbh,xfmx,mxbh,xftm,zb_jjje,'" + xfje + "',1,'" + xfje + "','" + sl_y_tz + "','" + je_y_tz_cb + "','" + xfje * sl_y_tz + "','','" + Xxtsz.common_kc.kc_rx_tz_y + "'  from   Xxfmx_zbmx  where ");
                        sb.Append(sel_s);
                        B_Common.ExecuteSql(sb.ToString());
                        }
                        else
                        {
                            sb = new StringBuilder();
                            sb.Append(" insert into   bb_kc_y_tj (yydh, qymc, rq, xfdr, drbh, xfxr, xrbh, xfmx, mxbh, xftm, jjje, sjxsdj, yhbl, xsdj, sl, Total_cb, Total_yye, bz, rx )");
                            sb.Append(" select                    yydh,qymc,'" + rq.ToShortDateString() + "',xfdr,drbh,xfxr,xrbh,xfmx,mxbh,xftm,zb_jjje,'" + xfje + "',1,'" + xfje + "','0','0','0','','" + Xxtsz.common_kc.kc_rx_tz_y + "'  from   Xxfmx_zbmx  ");
                            sb.Append(" where  yydh='" + yydh + "' and mxbh='" + mxbh + "'");
                            B_Common.ExecuteSql(sb.ToString());
                        }


                        sl_y_qm_kc = sl_qc_y + sl_y_rk - sl_y_ck + sl_y_tz;
                        //计算本期的销售成本
                        //总成本
                        //计算出下一个月的期初成本值
                        jjje_qc_y_jc = (jjje_qc_y * sl_qc_y + je_y_rk_cb + je_y_tz_cb) / (sl_qc_y + sl_y_rk + sl_y_tz);
                        //下月的期初数量
                        sl_qm_y = sl_qc_y + sl_y_rk - sl_y_ck + sl_y_tz;
                        //期末的库存金额
                        je_y_qm_cb = jjje_qc_y_jc * sl_qm_y;
                        decimal je_y_qm_yye = xfje * sl_qm_y;
                        //生成期末库存
                        sb = new StringBuilder();
                        sb.Append(" insert into   bb_kc_y_tj (yydh, qymc, rq, xfdr, drbh, xfxr, xrbh, xfmx, mxbh, xftm, jjje, sjxsdj, yhbl, xsdj, sl, Total_cb, Total_yye, bz, rx )");
                        sb.Append(" select                               yydh,qymc,'" + rq.ToShortDateString() + "',xfdr,drbh,xfxr,xrbh,xfmx,mxbh,xftm,'" + jjje_qc_y_jc + "',xfje,1,xfje,'" + sl_qm_y + "','" + je_y_qm_cb + "','" + je_y_qm_yye + "','','" + Xxtsz.common_kc.kc_rx_qm_y + "'  from  Xxfmx  ");
                        sb.Append("  where   mxbh='" + mxbh + "'  and yydh='" + yydh + "'");
                        B_Common.ExecuteSql(sb.ToString());

                        //插入下月期初库存
                        sb = new StringBuilder();
                        sb.Append(" insert into   bb_kc_y_tj (yydh, qymc, rq, xfdr, drbh, xfxr, xrbh, xfmx, mxbh, xftm, jjje, sjxsdj, yhbl, xsdj, sl, Total_cb, Total_yye, bz, rx )");
                        sb.Append(" select                               yydh,qymc,'" + DateTime.Parse(DateTime.Parse(czsj).ToShortDateString()) + "',xfdr,drbh,xfxr,xrbh,xfmx,mxbh,xftm,'" + jjje_qc_y_jc + "',xfje,1,xfje,'" + sl_qm_y + "','" + je_y_qm_cb + "','" + je_y_qm_yye + "','','" + Xxtsz.common_kc.kc_rx_qc_y + "'  from  Xxfmx  ");
                        sb.Append("  where   mxbh='" + mxbh + "'  and yydh='" + yydh + "'");
                        B_Common.ExecuteSql(sb.ToString());
                    }
                }
            }
        }

        private void Get_Tz_Today(string qymc, string yydh, string mxbh, string czy_temp, string czsj, ref decimal sl_r_tz_kc)
        {
            decimal tz_Today_sl = 0, tz_cb = 0; tz_Today_sl = sl_r_tz_kc = 0; decimal sjxsdj = 0; decimal xsdj = 0;
            StringBuilder sb;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds = null;
            ds = B_common.GetList(" select * from Xxfmx ", "  yydh='" + yydh + "' and  mxbh='" + mxbh + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sjxsdj = xsdj = decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
            }
            string sel_s = " id>=0  and      yydh='" + yydh + "'   and mxbh='" + mxbh + "'  and zb_sj>='" + DateTime.Parse(czsj).AddDays(-1).ToShortDateString() + "'  and zb_sj<'" + DateTime.Parse(czsj).ToShortDateString() + "'";
            ds = B_common.GetList(" SELECT sum(zb_sl)  as  tz_Today_sl,sum(zb_Total_cb) as tz_cb  FROM View_Xxfmx_zb ", sel_s);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["tz_Today_sl"] != null && ds.Tables[0].Rows[0]["tz_Today_sl"].ToString() != "" && ds.Tables[0].Rows[0]["tz_cb"] != null && ds.Tables[0].Rows[0]["tz_cb"].ToString() != "")
                {
                    sl_r_tz_kc = tz_Today_sl = decimal.Parse(ds.Tables[0].Rows[0]["tz_Today_sl"].ToString());
                    tz_cb = decimal.Parse(ds.Tables[0].Rows[0]["tz_cb"].ToString());
                }
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["tz_Today_sl"] != null && ds.Tables[0].Rows[0]["tz_Today_sl"].ToString() != "")
            {
                sb = new StringBuilder();
                sb.Append(" insert into BB_kc_mx(yydh,qymc,xfdr,drbh,xfxr,xrbh,xfxm,mxbh,sl,rq,xftm,jjdj,xsdj,yhbl,sjxsdj,Total_cb,Total_yye,rx,xfsj) ");
                sb.Append("  select  yydh,qymc,xfdr,drbh,xfxr,xrbh,xfmx,mxbh,'" + tz_Today_sl + "','" + DateTime.Parse(czsj).AddDays(-1).ToShortDateString() + "',xftm,zb_jjje,'" + xsdj + "','1','" + sjxsdj + "',zb_Total_cb,'" + tz_Today_sl * sjxsdj + "','" + Xxtsz.common_kc.kc_rx_tz_r + "',zb_sj   from   Xxfmx_zbmx  where  ");
                //sb.Append("  where   yydh='" + yydh + "'  and   mxbh='" + mxbh + "' ");
                sb.Append(sel_s);
                B_common.ExecuteSql(sb.ToString());
            }
            else
            {
                sb = new StringBuilder();
                sb.Append(" insert into BB_kc_mx(yydh,qymc,xfdr,drbh,xfxr,xrbh,xfxm,mxbh,sl,rq,xftm,jjdj,xsdj,yhbl,sjxsdj,Total_cb,Total_yye,rx,xfsj) ");
                sb.Append("  select  yydh,qymc,xfdr,drbh,xfxr,xrbh,xfmx,mxbh,'0','" + DateTime.Parse(czsj).AddDays(-1).ToShortDateString() + "',xftm,jjje,'" + xsdj + "','1','" + sjxsdj + "',0,'0','" + Xxtsz.common_kc.kc_rx_tz_r + "','" + DateTime.Parse(czsj).AddDays(-1).ToShortDateString() + "'   from   Xxfmx    ");
                sb.Append("  where   yydh='" + yydh + "'  and   mxbh='" + mxbh + "' ");
                B_common.ExecuteSql(sb.ToString());
            }
            common_file.common_czjl.add_czjl(yydh, qymc, czy_temp, Xxtsz.common_kc.kc_rx_rc_r, DateTime.Parse(czsj).AddDays(-1).ToShortDateString(), "新增", DateTime.Parse(czsj));
        }


        public string  BB_kc_y_r_cbtj(string qymc, string yydh, string rq, string rx, string czy_temp, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            DataSet ds = null; DataSet ds_0 = null; string mxbh = "";
            DbHelperSQL.ExecuteSql(" delete from  BB_kc_y_r_cbtj  where czy_temp='" + czy_temp + "'  and yydh='" + yydh + "'");
            BLL.Common  B_common=new Hotel_app.BLL.Common();

            if (rx == Xxtsz.common_kc.kc_cbtj_r)//如果是查询日的
            {
                ds = B_common.GetList(" select * from  BB_kc_mx ", "  yydh='" + yydh + "' and  rq>='" + rq + "' and rq<'" + DateTime.Parse(rq).AddDays(1).ToShortDateString() + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                { 
                    //生成临时表
                    ds_0 = B_common.GetList(" select * from  BB_kc_mx ", "  yydh='" + yydh + "' and  rq>='" + rq + "' and rq<'" + DateTime.Parse(rq).AddDays(1).ToShortDateString() + "'  and rx='"+Xxtsz.common_kc.kc_rx_qc_r+"'");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_0.Tables[0].Rows.Count; i++)
                        {
                            mxbh = ds_0.Tables[0].Rows[i]["mxbh"].ToString();
                            Insert_Qc_Row(yydh, qymc, ds_0.Tables[0].Rows[i]["xfdr"].ToString(), ds_0.Tables[0].Rows[i]["xfxr"].ToString(), ds_0.Tables[0].Rows[i]["xfxm"].ToString(), ds_0.Tables[0].Rows[i]["mxbh"].ToString(), ds_0.Tables[0].Rows[i]["xftm"].ToString(), ds_0.Tables[0].Rows[i]["jjdj"].ToString(), ds_0.Tables[0].Rows[i]["sl"].ToString(),rx,czy_temp,rq);
                            Update_Qc_Row(yydh, mxbh, czy_temp, Xxtsz.common_kc.kc_rx_ck_r, rq,"","");
                            Update_Qc_Row(yydh, mxbh, czy_temp, Xxtsz.common_kc.kc_rx_rc_r, rq, "", "");
                            Update_Qc_Row(yydh, mxbh, czy_temp, Xxtsz.common_kc.kc_rx_tz_r, rq, "", "");
                            Update_Qc_Row(yydh, mxbh, czy_temp, Xxtsz.common_kc.kc_rx_qm_r, rq, "", "");
                        }
                    }
                }
 
            }

            if (rx == Xxtsz.common_kc.kc_cbtj_y)//如果是查询月的（找到月期初的时间)
            {
                int ybtqts = 0;
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                ds = B_Common.GetList("select ybtqts from Qcounter", " id>=0");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ybtqts"].ToString() != "")
                    {
                        ybtqts = int.Parse(ds.Tables[0].Rows[0]["ybtqts"].ToString());
                    }
                }
                //找到本月的期初时间
                DateTime yfcssj = common_bb.judge_yfcssj(DateTime.Parse(rq), ybtqts);

                //找到下一月的期初时间
                DateTime temp_rq = DateTime.Parse(rq);
                int day_0 = DateTime.Parse(rq).Day;
                if (day_0 >= 15)
                {
                    temp_rq = temp_rq.AddDays(-10).AddMonths(1);

                }
                else
                {
                    temp_rq = temp_rq.AddMonths(1);
                }

                DateTime yfcssj_next = common_bb.judge_yfcssj(temp_rq, ybtqts);
                ds = B_common.GetList(" select * from  BB_kc_y_tj ", "  yydh='" + yydh + "' and  rq>='" + yfcssj.ToShortDateString() + "' and rq<'" + yfcssj_next.ToShortDateString() + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //生成临时表
                    ds_0 = B_common.GetList(" select * from  BB_kc_y_tj ", "  yydh='" + yydh + "' and  rq>='" + yfcssj.ToShortDateString() + "' and rq<'" + yfcssj_next.ToShortDateString() + "'  and rx='" + Xxtsz.common_kc.kc_rx_qc_y + "'");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_0.Tables[0].Rows.Count; i++)
                        {
                            mxbh = ds_0.Tables[0].Rows[i]["mxbh"].ToString();
                            Insert_Qc_Row(yydh, qymc, ds_0.Tables[0].Rows[i]["xfdr"].ToString(), ds_0.Tables[0].Rows[i]["xfxr"].ToString(), ds_0.Tables[0].Rows[i]["xfmx"].ToString(), ds_0.Tables[0].Rows[i]["mxbh"].ToString(), ds_0.Tables[0].Rows[i]["xftm"].ToString(), ds_0.Tables[0].Rows[i]["jjje"].ToString(), ds_0.Tables[0].Rows[i]["sl"].ToString(), rx, czy_temp, rq);
                            Update_Qc_Row(yydh, mxbh, czy_temp, Xxtsz.common_kc.kc_rx_ck_y, rq, yfcssj.ToString(), yfcssj_next.ToString());
                            Update_Qc_Row(yydh, mxbh, czy_temp, Xxtsz.common_kc.kc_rx_rc_y, rq, yfcssj.ToString(), yfcssj_next.ToString());
                            Update_Qc_Row(yydh, mxbh, czy_temp, Xxtsz.common_kc.kc_rx_tz_y, rq, yfcssj.ToString(), yfcssj_next.ToString());
                            Update_Qc_Row(yydh, mxbh, czy_temp, Xxtsz.common_kc.kc_rx_qm_y, rq, yfcssj.ToString(), yfcssj_next.ToString());
                        }
                    }
                }
            }
           return   s = common_file.common_app.get_suc;

        }

        private void Insert_Qc_Row(string  yydh,string qymc,string  xfdr,string xfxr,string xfxm,string  mxbh,string  xftm,string jjdj_qc,string  sl_qc,string rx,string czy_temp,string rq)
        {
            BLL.Common B_common = new Hotel_app.BLL.Common();
            StringBuilder  sb=new StringBuilder();
            sb.Append("  insert into  BB_kc_y_r_cbtj(yydh,qymc,xfdr,xfxr,xfmx,mxbh,xftm,jjdj_qc,sl_qc,jjdj_rk,sl_rk,jjdj_ck,sl_ck,jjdj_tz,sl_tz,jjdj_qm,sl_qm,rx,czy_temp,rq )");
            sb.Append("  values('"+yydh+"','"+qymc+"','"+xfdr+"','"+xfxr+"','"+xfxm+"','"+mxbh+"','"+xftm+"','"+jjdj_qc+"','"+sl_qc+"','0','0','"+jjdj_qc+"','0','0','0','0','0','"+rx+"','"+czy_temp+"','"+rq+"')");
            B_common.ExecuteSql(sb.ToString());
        }

        private void Update_Qc_Row(string yydh, string mxbh, string czy_temp, string rx, string rq, string yfcssj_1, string yfcssj_2)
        {
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet  ds=null;

            string jjdj_ls="0";string sl_ls="0"; string  sel_con="",select_sql="";


            if (rx == Xxtsz.common_kc.kc_rx_ck_r || rx == Xxtsz.common_kc.kc_rx_rc_r || rx == Xxtsz.common_kc.kc_rx_tz_r || rx == Xxtsz.common_kc.kc_rx_qm_r)
            {
                select_sql = " rq>='" + rq.ToString() + "'  and  rq<'"+DateTime.Parse(rq.ToString()).AddDays(1).ToShortDateString()+"'   and  mxbh='" + mxbh + "' and  rx='" + rx + "'";
            }

            if (rx == Xxtsz.common_kc.kc_rx_ck_y || rx == Xxtsz.common_kc.kc_rx_rc_y || rx == Xxtsz.common_kc.kc_rx_tz_y || rx == Xxtsz.common_kc.kc_rx_qm_y)
            {
                if (rx == Xxtsz.common_kc.kc_rx_ck_y)
                {
                    rx = Xxtsz.common_kc.kc_rx_ck_r;
                }
                if (rx == Xxtsz.common_kc.kc_rx_rc_y)
                {
                    rx = Xxtsz.common_kc.kc_rx_rc_r;
                }
                if (rx == Xxtsz.common_kc.kc_rx_tz_y)
                {
                    rx = Xxtsz.common_kc.kc_rx_tz_r;
                }

                select_sql = " rq>='" + yfcssj_1 + "' and rq<'" + yfcssj_2 + "'   and  mxbh='" + mxbh + "' and  rx='"+rx+"'";
            }


            ds = B_common.GetList(" select * from  BB_kc_mx ", select_sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    jjdj_ls= ds.Tables[0].Rows[0]["jjdj"].ToString();
                    sl_ls= ds.Tables[0].Rows[0]["sl"].ToString(); 
                }
            }
            if (rx == Xxtsz.common_kc.kc_rx_ck_r || rx == Xxtsz.common_kc.kc_rx_ck_y)
            {
                sel_con="  jjdj_ck='"+jjdj_ls+"',sl_ck='"+sl_ls+"' ";
            }
            if (rx == Xxtsz.common_kc.kc_rx_rc_r || rx == Xxtsz.common_kc.kc_rx_rc_y)
            {
                sel_con = "  jjdj_rk='" + jjdj_ls + "',sl_rk='" + sl_ls + "' ";
            }
            if(rx==Xxtsz.common_kc.kc_rx_tz_r||rx==Xxtsz.common_kc.kc_rx_tz_y){

                sel_con = "  jjdj_tz='" + jjdj_ls + "',sl_tz='" + sl_ls + "' ";
            }
            if (rx == Xxtsz.common_kc.kc_rx_qm_r || rx == Xxtsz.common_kc.kc_rx_qm_y)
            {
                sel_con = "  jjdj_qm='" + jjdj_ls + "',sl_qm='" + sl_ls + "' ";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("  update   BB_kc_y_r_cbtj  set ");
            sb.Append(sel_con);
            sb.Append(" where  mxbh='" + mxbh + "' and yydh='" + yydh + "' and  czy_temp='"+czy_temp+"'  and rq='"+rq+"'");

            try
            {
                B_common.ExecuteSql(sb.ToString());
            }
            catch 
            {
                common_file.common_czjl.add_errorlog(sb.ToString(), "", DateTime.Now.ToString());
            }
        
        }
    }
}
