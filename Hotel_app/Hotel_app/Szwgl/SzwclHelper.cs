using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Maticsoft.DBUtility;

namespace Hotel_app.Szwgl
{
    public class SzwclHelper
    {
        //帐务处理前台操作类

        public Hotel_app.Model.Szw_temp M_Szw_temp;
        public Hotel_app.Model.Syjcz M_Syjcz;
        public Hotel_app.BLL.Szw_temp B_Szw_temp = new Hotel_app.BLL.Szw_temp();
        public Hotel_app.BLL.Ssyxfmx B_Ssyxfmc = new Hotel_app.BLL.Ssyxfmx();
        public Hotel_app.BLL.Syjcz B_Syjcz = new Hotel_app.BLL.Syjcz();
        public Hotel_app.BLL.Common B_common = new Hotel_app.BLL.Common();

        public Hotel_app.BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
        public Hotel_app.Model.Qskyd_mainrecord M_Qskyd_mainrecord;

        public Hotel_app.BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
        public Hotel_app.Model.Qttyd_mainrecord M_Qttyd_mainrecord;
        public Hotel_app.BLL.Flfsz B_Flfsz = new Hotel_app.BLL.Flfsz();

        public Hotel_app.BLL.Sjzmx B_Sjzmx = new Hotel_app.BLL.Sjzmx();
        public Hotel_app.BLL.Syjcz_bak B_Syjcz_bak = new Hotel_app.BLL.Syjcz_bak();

        public int id = 0;
        DataSet ds_temp_xfmx;
        DataSet ds_temp;
        public string lfbh_temp = "";
        public List<string> list_lsbh;//获取联房下所有的临时编号
        public string ddbh_temp = "";//团体的订单编号
        StringBuilder strSql;
        string sql = "";

        //记。挂。算帐时要根据SK/TT来获取
        string xydw_temp = "";
        string krly_temp = "";//

        //押金操作(以经放到服务端执行)
        public string Syjcz_add_edit(string id, string yydh, string qymc, string id_app, string jzbh, string lsbh, string krxm, string fjrb, string fjbh, string sktt, string xfrq, string xfsj,
    string czy, string xfdr, string xfrb, string xfxm, string xfbz, string xfzy, string fkfs, string xfje, string sjxfje, string czy_bc, string syzd, string add_edit_delete, string xxzs)
        {


            string s = common_file.common_app.get_failure;
            M_Syjcz = new Hotel_app.Model.Syjcz();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {


                M_Syjcz.yydh = yydh;
                M_Syjcz.qymc = qymc;
                M_Syjcz.id_app = id_app;
                M_Syjcz.jzbh = jzbh;
                M_Syjcz.lsbh = lsbh;
                M_Syjcz.krxm = krxm;
                M_Syjcz.fjrb = fjrb;
                M_Syjcz.fjbh = fjbh;
                M_Syjcz.sktt = sktt;
                M_Syjcz.xfrq = Convert.ToDateTime(xfrq);
                M_Syjcz.xfsj = Convert.ToDateTime(xfsj);
                M_Syjcz.czy = czy;
                M_Syjcz.xfdr = xfdr;
                M_Syjcz.xfrb = xfrb;
                M_Syjcz.xfxm = xfxm;
                M_Syjcz.xfbz = xfbz;
                M_Syjcz.xfzy = xfzy;
                M_Syjcz.fkfs = fkfs;
                M_Syjcz.xfje = Convert.ToDecimal(xfje);
                M_Syjcz.sjxfje = Convert.ToDecimal(sjxfje);
                M_Syjcz.czy_bc = czy_bc;
                M_Syjcz.syzd = syzd;

                if (B_Syjcz.Add(M_Syjcz) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Syjcz = B_Syjcz.GetModel(Convert.ToInt32(id));
                    M_Syjcz.yydh = yydh;
                    M_Syjcz.qymc = qymc;
                    M_Syjcz.id_app = id_app;
                    M_Syjcz.jzbh = jzbh;
                    M_Syjcz.lsbh = lsbh;
                    M_Syjcz.krxm = krxm;
                    M_Syjcz.fjrb = fjrb;
                    M_Syjcz.fjbh = fjbh;
                    M_Syjcz.sktt = sktt;
                    M_Syjcz.xfrq = Convert.ToDateTime(xfrq);
                    M_Syjcz.xfsj = Convert.ToDateTime(xfsj);
                    M_Syjcz.czy = czy;
                    M_Syjcz.xfdr = xfdr;
                    M_Syjcz.xfrb = xfrb;
                    M_Syjcz.xfxm = xfxm;
                    M_Syjcz.xfbz = xfbz;
                    M_Syjcz.xfzy = xfzy;
                    M_Syjcz.fkfs = fkfs;
                    M_Syjcz.xfje = Convert.ToDecimal(xfje);
                    M_Syjcz.sjxfje = Convert.ToDecimal(sjxfje);
                    M_Syjcz.czy_bc = czy_bc;
                    M_Syjcz.syzd = syzd;
                    M_Syjcz.id = int.Parse(id);
                    if (B_Syjcz.Update(M_Syjcz))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Syjcz.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }

        //获取消费名细记录
        public DataSet Zzwcl_Search(string lsbh, string sktt, string czy_GUID)
        {
            //查询当前操作员(lsbh+czy_GUID)是否在Szw_temp是否有记录，有就删除，没有就直接查询，填充该表
            //ds_temp_xfmx = B_Szw_temp.GetList("lsbh='" + lsbh + "'  and  czy_GUID='" + czy_GUID + "'");
            ds_temp_xfmx = B_Szw_temp.GetList("czy_temp='" + czy_GUID + "'");
            if (ds_temp_xfmx != null && ds_temp_xfmx.Tables[0].Rows.Count > 0)//记录存在，执行删除
            {
                sql = "delete  from  Szw_temp  where  id>=0 " + common_file.common_app.yydh_select + " and czy_temp='" + czy_GUID + "'";
                B_common.ExecuteSql(sql);
            }
            SearchData(lsbh, czy_GUID);
            return ds_temp_xfmx = B_Szw_temp.GetList("id>=0  " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'  and  czy_temp='" + czy_GUID + "'  order by  xfsj  desc");
        }

        //帐务浏览时的帐务查询
        public DataSet GetZwmx_zwll(string lsbh, string jzbh, string jjType)
        {
            DataSet ds_temp = new DataSet();
            ds_temp = B_common.GetList("select * from Sjzmx", "  id>=0 " + common_file.common_app.yydh_select + "  and jzbh='" + jzbh + "'");
            return ds_temp;
        }

        //结帐时的帐务
        public void GetZwmx(string lsbh, string sktt, string czy_GUID, string sel_con)
        {

            sql = "delete  from  Szw_temp  where  id>=0 " + common_file.common_app.yydh_select + " and czy_temp='" + czy_GUID + "'";
            if (sel_con.Trim() != "")
            { sql = sql + sel_con; }
            B_common.ExecuteSql(sql);
            // list_lsbh = new List<string>();
            if (sktt == "sk")//散客考虑联房
            {
                System.Text.StringBuilder strSql = new System.Text.StringBuilder();
                //检查当前的lsbh是否存在于lfsz表里面
                ds_temp = B_Flfsz.GetList("  id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh + "'  and   fjbh!=''   and shlz=1  ");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    //联房并且有联帐(2012-03-02华都会议更新,数据库有新增一个连帐的功能,这间有加到联房里面(获取此lfbh下所有的lsbh--查找押金和消费明细
                    lfbh_temp = ds_temp.Tables[0].Rows[0]["lfbh"].ToString();
                    ds_temp = B_Flfsz.GetList("id>=0  " + common_file.common_app.yydh_select + "  and lfbh='" + lfbh_temp + "'  and  fjbh!=''  and  shlz=1 ");
                    list_lsbh = new List<string>();
                    for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
                    {
                        if (ds_temp.Tables[0].Rows[i]["lsbh"].ToString() != lsbh)
                        {
                            list_lsbh.Add(ds_temp.Tables[0].Rows[i]["lsbh"].ToString());//所有的临时编号
                        }
                    }
                    list_lsbh.Add(lsbh);//注意，要先加上自己
                    foreach (string lsbh_temp in list_lsbh)
                    {
                        SearchData(lsbh_temp, czy_GUID);
                    }
                }
                else//没有联房，直接查找
                {
                    SearchData(lsbh, czy_GUID);
                }
            }
            if (sktt == "tt")//获取所有成员的帐务
            {
                //成员帐务都结清，团体可以进行结帐
                SearchData(lsbh, czy_GUID);
            }
        }


        //分结时的帐务  jjType标识是部分结，记/挂分结
        public DataSet GetZwmx_fj(string lsbh, string jzbh, string sktt, string jjType, string czy_GUID, string sel_con)
        {
            sql = "delete  from  Szw_temp  where  id>=0 " + common_file.common_app.yydh_select + " and czy_temp='" + czy_GUID + "'";
            if (sel_con.Trim() != "")
            {
                sql += sel_con;
            }
            B_common.ExecuteSql(sql);
            // if (jjType == common_file.common_jzzt.czzt_bfsz)//部分算帐
            if (jzbh.Trim() == "")//部分算账
            {
                if (jjType == common_file.common_jzzt.czzt_bfsz)
                {
                    string sql_0 = "";
                    DataSet ds_0 = B_common.GetList(" select * from Flfsz ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "'  and shlz=1  ");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        sql_0 = "  and   (lsbh  in ( select  lsbh  from Flfsz  where lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "'  and shlz=1   )   and  shlz=1  )   ) ";
                    }
                    else
                    {
                        sql_0 = "   and  lsbh='" + lsbh + "'  ";
                    }
                    //查询Szwmx表里面的数据，向szw_temp添加
                    strSql = new System.Text.StringBuilder();
                    strSql.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czy_temp)");
                    strSql.Append("  select yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,'',xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,'" + czy_GUID + "'  from Szwmx");
                    strSql.Append("  where   id>=0 " + common_file.common_app.yydh_select + "   and id_app  in  (select  id_app  from  Szw_zz_fj_temp where  id>=0 and czy='" + czy_GUID + "')        ");
                    strSql.Append(sql_0);
                }
                B_common.ExecuteSql(strSql.ToString());
                //查询jzmx表里面的数据，向szw_temp添加(结帐付款)--有可能有平帐收款的记录
                //要注意分结时候是否有多次分结，第二次再查询的时候，这时候该lsbh可能有以经有结过的帐务信息，查询时还要有一个条件为:jzbh=''; (当前平帐收款时所交的钱）
            }
            if (jzbh.Trim() != "")//记/挂  分结
            //挂/记分结
            // if (jjType == common_file.common_jzzt.czzt_gz || jjType == common_file.common_jzzt.czzt_jz || jjType == common_file.common_jzzt.czzt_jzzgz || jjType == common_file.common_jzzt.czzt_gzzjz)
            {
                strSql = new StringBuilder();
                strSql.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czy_temp )");
                strSql.Append("  select yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,'',xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,'" + czy_GUID + "'  from Szwmx");
                strSql.Append("  where  jzbh='" + jzbh + "'  and id>=0 " + common_file.common_app.yydh_select + "   and id_app  in  (select  id_app  from  Szw_zz_fj_temp where  id>=0 and czy='" + czy_GUID + "')  ");
                B_common.ExecuteSql(strSql.ToString());
            }
            //strSql = new StringBuilder();
            //strSql = new System.Text.StringBuilder();
            //strSql.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy_GUID,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj)");
            //strSql.Append("  select yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,'" + czy_GUID + "',xfdr,xfrb,xfxm,xfbz,xfzy,'',xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj  from Sjzmx");
            //strSql.Append("  where  jzbh='" + jzbh + "'  and id>=0 " + common_file.common_app.yydh_select + "    and   czzt='"+jjType+"'");
            //B_common.ExecuteSql(strSql.ToString());
            ds_temp_xfmx = B_Szw_temp.GetList("id>=0  " + common_file.common_app.yydh_select + "   and  czy_temp='" + czy_GUID + "'  order by  xfsj  desc");
            return ds_temp_xfmx;
        }

        //根据临时编号和操作员向Szw_temp添加押金以及所有的消费明细
        public void SearchData(string lsbh, string czy_GUID)
        {
            strSql = new System.Text.StringBuilder();
            //查询yjcz表里面的数据，向szw_temp添加
            strSql.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
            strSql.Append("  select  yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,-xfje,'',-sjxfje,'1',shsc,'0','',xfsj,'"+common_file.common_app.czy_GUID+"' from Syjcz");
            strSql.Append("  where  lsbh='" + lsbh + "'  and id>=0 " + common_file.common_app.yydh_select);
            B_common.ExecuteSql(strSql.ToString());
            //查询Szwmx表里面的数据，向szw_temp添加
            strSql = new System.Text.StringBuilder();
            strSql.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
            strSql.Append("  select yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,'',xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,'" + czy_GUID + "'  from Szwmx");
            strSql.Append("  where  lsbh='" + lsbh + "'  and id>=0 " + common_file.common_app.yydh_select);
            B_common.ExecuteSql(strSql.ToString());
            //查询jzmx表里面的数据，向szw_temp添加(结帐付款)
            strSql = new StringBuilder();
            strSql = new System.Text.StringBuilder();
            strSql.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
            strSql.Append("  select yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,'',xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,'" + czy_GUID + "'  from Sjzmx");
            strSql.Append("  where  lsbh='" + lsbh + "'  and id>=0 " + common_file.common_app.yydh_select + " and  jzbh='' ");
            B_common.ExecuteSql(strSql.ToString());
        }

        //获取消费项目列表(汇总)
        public DataSet Zzwcl_hz(string lsbh, string czy_GUID)
        {
            string sql = "select  xfxm,Sum(sjxfje) as  sjxfje  from  Szw_temp";
            ds_temp_xfmx = B_common.GetList(sql, " lsbh='" + lsbh + "'  and czy_temp='" + czy_GUID + "'  group by xfxm  order by xfxm desc");
            return ds_temp_xfmx;
        }

        //结帐，记帐，挂帐的处理过程  jjzt(结帐主体,挂/记时是所选的协议单位名称)
        public string Fun_zw(string lsbh, string jjType, string sk_tt, string jjzt, string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            if (sk_tt == "sk")
            {
                if (Fun_skzwcl(lsbh, sk_tt, jjType, jjzt) == common_file.common_app.get_suc)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else if (sk_tt == "tt")//团体或者会议
            {
                //操作之前，全判断该lsbh对应下的团体ddbh下所有成员的消费情况
                ds_temp = null;
                string ddbh_temp = DbHelperSQL.GetSingle("select ddbh  from  Qttyd_mainrecord  where  id>=0  " + common_file.common_app.yydh_select + " and lsbh='" + lsbh + "'").ToString();
                string sql = "select   *   from  Syjcz  ";
                ds_temp = B_common.GetList(sql, "  lsbh  in ( select lsbh  from Qskyd_mainrecord where id>=0  " + common_file.common_app.yydh_select + "  and ddbh='" + ddbh_temp + "')");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)//成员押金
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "不成结帐,团体成员有独立交押金,请先结清成员帐务,再进行团体帐务操作");
                    return s;
                }
                else//否则查找成员的消费情况
                {
                    sql = "select  *  from    Szwmx  ";
                    ds_temp = null;
                    ds_temp = B_common.GetList(sql, "  lsbh  in (select lsbh  from Qskyd_mainrecord where id>=0  " + common_file.common_app.yydh_select + "  and ddbh='" + ddbh_temp + "')");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "不成结帐,团体成员单独帐务还未结清,请先结清成员帐务,再进行团体帐务操作");
                        return s;
                    }
                }
                //成员帐务结清,团体结帐
                if (Fun_skzwcl(lsbh, sk_tt, jjType, jjzt) == common_file.common_app.get_suc)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            //结帐成功
            if (s == common_file.common_app.get_suc)
            {
                //要关掉当前处理帐务的所有窗体
                CloseStaticFrm(sk_tt);
            }
            return s;
        }

        private string Fun_skzwcl(string lsbh, string sk_tt, string jjzt_type, string jzzt)//散客帐务处理
        {
            string s = common_file.common_app.get_failure;
            string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
            object[] args = new object[14];
            args[0] = lsbh;
            args[1] = sk_tt;
            //散客或者团体的客人来源的获取
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds_0 = null;
            if (sk_tt == "sk")
            {
                ds_0 = B_common.GetList("select * from  Qskyd_mainrecord", "id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + lsbh + "'");
            }
            if (sk_tt == "tt")
            {
                ds_0 = B_common.GetList("select * from  Qttyd_mainrecord", "id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + lsbh + "'");
            }
            if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
            {
                xydw_temp = ds_0.Tables[0].Rows[0]["xydw"].ToString();
                krly_temp = ds_0.Tables[0].Rows[0]["krly"].ToString();
            }
            else
            {
                xydw_temp = ""; krly_temp = "";
            }
            args[2] = xydw_temp;
            args[3] = krly_temp;
            args[4] = common_file.common_app.yydh;
            args[5] = jjzt_type;
            args[6] = jzzt;
            args[7] = common_file.common_app.czy;
            args[8] = common_file.common_app.czy_bc;
            args[9] = jjzt_type;
            args[10] = DateTime.Now.ToString();
            args[11] = common_file.common_app.syzd;
            args[12] = common_file.common_app.xxzs;
            args[13] = common_file.common_app.czy_GUID;

            Hotel_app.Server.Szwgl.Szw_jzOrgzOrSZ Szw_jzOrgzOrSZ_services = new Hotel_app.Server.Szwgl.Szw_jzOrgzOrSZ();
            string result=Szw_jzOrgzOrSZ_services.Func_zwcl(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "FunCommon_zwcl", args);
            if (result != null && result == common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        //记帐转结帐，挂帐转结帐的处理过程
        public string Fun_jzorgzToSz(string lsbh, string jzbh, string jjType, string sk_tt, string czsj, string fkje, string xfje)
        {
            string s = common_file.common_app.get_failure;
            string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
            object[] args = new object[14];
            args[0] = lsbh;
            args[1] = jzbh;
            args[2] = common_file.common_app.yydh;
            args[3] = jjType;//jz/gz---jz
            args[4] = sk_tt;
            args[5] = common_file.common_app.czy;
            args[6] = czsj;
            args[7] = common_file.common_app.syzd;
            args[8] = common_file.common_app.czy_bc;
            args[9] = fkje;
            args[10] = xfje;
            args[11] = common_file.common_app.xxzs;
            args[12] = common_file.common_app.qymc;
            args[13] = common_file.common_app.czy_GUID;

            Hotel_app.Server.Szwgl.Szw_jzOrgzToSz Szw_jzOrgzToSz_services = new Hotel_app.Server.Szwgl.Szw_jzOrgzToSz();
            string  result=Szw_jzOrgzToSz_services.GetjzOrgzToSzResult(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Fun_jzOrgzToSZ", args);
            if (result != null && result== common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_suc;
            }
            return s;

        }

        //记帐分结，挂帐分结，算帐分结的处理过程
        public string Fun_jzOrgzOrszToFj(string lsbh, string jjType, string sk_tt, string czsj, string fkje, string xfje, string jzbh_old)
        {



            string s = common_file.common_app.get_failure;
            string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
            string[] args = new string[13];
            args[0] = lsbh;
            args[1] = jjType;  //记帐，挂帐，记分，挂分，部分算帐
            args[2] = sk_tt;
            args[3] = common_file.common_app.czy;
            args[4] = czsj;
            args[5] = common_file.common_app.syzd;
            args[6] = common_file.common_app.czy_bc;
            args[7] = fkje;
            args[8] = xfje;
            args[9] = common_file.common_app.xxzs;
            args[10] = common_file.common_app.yydh;
            args[11] = jzbh_old;
            args[12] = common_file.common_app.czy_GUID;

            Hotel_app.Server.Szwgl.Szw_jzOrgzOrszToFj Szw_jzOrgzOrszToFj_services = new Hotel_app.Server.Szwgl.Szw_jzOrgzOrszToFj();
            string result = Szw_jzOrgzOrszToFj_services.GetjzOrgzOrszToFjResult(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Fun_jzOrgzToFj", args);
            if (result != null && result== common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        //结帐，记帐,挂帐后窗体关闭
        public void CloseStaticFrm(string sk_tt)
        {
            if (common_file.common_form.Szw_Common_check_new != null)
            {
                common_file.common_form.Szw_Common_check_new.Close();
            }
            if (common_file.common_form.Szwcl_new != null)
            {
                common_file.common_form.Szwcl_new.Dispose();
                common_file.common_form.Szwcl_new.Close();
            }
            if (sk_tt == "sk")
            {
                if (common_file.common_form.Qskdj_new != null)
                {
                    common_file.common_form.Qskdj_new.Close();
                }
                if (common_file.common_form.Qskdj_browse_new != null)
                {
                    common_file.common_form.Qskdj_browse_new.refresh_app("");
                }
            }
            if (sk_tt == "tt")
            {
                if (common_file.common_form.Qttdj_new != null)
                {
                    common_file.common_form.Qttdj_new.Close();
                }
                if (common_file.common_form.Qttdj_browse_new != null)
                {
                    common_file.common_form.Qttdj_browse_new.refresh("");
                }
            }
        }

        //检查团体成员的帐务情况，返回真假，结清，返回真，没有结清返回假
        public bool CheckTTcyZwStatus(string lsbh)//团体的临时编号
        {
            DataSet ds_temp;
            string ddbh_temp = "";
            M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh + "'")[0];
            ddbh_temp = M_Qttyd_mainrecord.ddbh;
            ds_temp = B_common.GetList("select   *  from  Syjcz", "  lsbh in  (select  lsbh  from  Qskyd_mainrecord  where ddbh='" + ddbh_temp + "')");
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
            {
                ds_temp = B_common.GetList("select * from Szwmx", "  lsbh in  (select  lsbh  from  Qskyd_mainrecord  where ddbh='" + ddbh_temp + "')");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
                else//成员帐务都结清，团体可以进行结帐
                {
                    return true;
                }
            }
        }




        //更新20120613
        //历史账务的查询
        public DataSet GetZwData_ls(string lsbh)
        {
            DataSet ds = null;
            ds = B_common.GetList(" select * from  Szw_temp_bak ", "id>=0  and lsbh='" + lsbh + "'");
            return ds;
        }

        public DataSet GetZwData_hz(string lsbh)
        {
            DataSet ds_hz = null;
            string sql = "select  xfxm,Sum(sjxfje) as  sjxfje  from  Szw_temp_bak";
            ds_hz = B_common.GetList(sql, " lsbh='" + lsbh + "'   group by xfxm  order by xfxm desc");
            return ds_hz;
        }
    }
}
