using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    //此类的作用是用于批量结帐(批量结分为按金额和时间，按金额要考虑的拆结帐主单的情况

    //批量结帐要注意的问题是：sjzzd中的jzzt要一致，否则不列入批量结的范围内
    class common_zw_pljz
    {

        DataSet ds;
        public decimal xfje = 0;
        public decimal fkje = 0;
        public decimal ljje = 0;//当前累计金额

        public DateTime dt_start = DateTime.Parse("1800-01-01");   //起始时间
        public DateTime dt_end = DateTime.Parse("1800-01-01"); //结束时间
        public string pljz_type = "";//批量结帐的类型(time,value)
        public string jjType = "";//结帐的类型(记帐，挂帐，还是记帐转挂帐,挂帐转记帐)
        public BLL.Sjzzd B_sjzzd = new Hotel_app.BLL.Sjzzd();
        public BLL.Common B_common = new Hotel_app.BLL.Common();


        //此函数是向Szw_temp中加载要批结的数据（分两个步骤完成的)
        public   void GetPLJZData(DateTime _dt_start, DateTime _dt_end, string _pljz_type,decimal pjje, string jzzt, string jjType,out string jzbh_last_return)
        {
            //删除Szw_temp中当前czy_guid的所有记录,这一步非常关键
            jzbh_last_return = "";
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from  Szw_temp  where  id>=0  and yydh='" + common_file.common_app.yydh + "'  and  czy_temp='" + common_file.common_app.czy_GUID + "' ");
            B_common.ExecuteSql(sb.ToString());

            dt_start = _dt_start;
            dt_end = _dt_end;
            decimal xfje = 0;
            decimal fkje = 0;
            decimal je_temp = 0;
            pljz_type = _pljz_type;
            if (pljz_type == "Time")//按时间批量结算(直接找到  结帐主单
            {
                jzbh_last_return = "";
                xfje = 0; fkje = 0; ljje = 0;
                List<string> lsbh_jzbh = new List<string>();
                ds = B_sjzzd.GetList(" id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   (czzt='" + common_file.common_jzzt.czzt_gz+"'  or  czzt='"+common_file.common_jzzt.czzt_jzzgz + "')   and  tfsj>='" + dt_start + "'  and  tfsj<='" + dt_end + "'  and  jzzt='" + jzzt + "'  order by  tfsj  asc");
                if (ds != null & ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        xfje = decimal.Parse(ds.Tables[0].Rows[i]["xfje"].ToString());
                        fkje = decimal.Parse(ds.Tables[0].Rows[i]["fkje"].ToString());
                        lsbh_jzbh.Add(ds.Tables[0].Rows[i]["lsbh"].ToString() + "|" + ds.Tables[0].Rows[i]["jzbh"].ToString());
                    }
                }
                //遍历所有出现的lsbh,向Szw_temp 中加入数据
                StringBuilder strsql_1;
                //
                for (int i = 0; i < lsbh_jzbh.Count; i++)
                {
                    //加载消费
                    string lsbh_temp_1 = lsbh_jzbh[i].Split('|')[0].ToString();
                    string jzbh_temp_1 = lsbh_jzbh[i].Split('|')[1].ToString();
                    strsql_1 = new StringBuilder();
                    strsql_1.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
                    strsql_1.Append(" select  yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,jzzt,fjrb,fjbh,sktt,xfrq,xfsj,'" + common_file.common_app.czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,'',sjxfje,'1',shsc,'0',mxbh,czsj,'"+common_file.common_app.czy_GUID+"' from Sjzmx");
                    strsql_1.Append("  where   jzbh='" + jzbh_temp_1 + "' and  xfdr!='"+common_file.common_app.fkdr+"'  and  jzzt='" + jzzt + "'");
                    B_common.ExecuteSql(strsql_1.ToString());

                    //加载付款
                    strsql_1 = new StringBuilder();
                    strsql_1.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
                    strsql_1.Append(" select  yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,jzzt,fjrb,fjbh,sktt,xfrq,xfsj,'" + common_file.common_app.czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,'',sjxfje,'1',shsc,'0',mxbh,czsj,'" + common_file.common_app.czy_GUID + "'  from Sjzmx");
                    strsql_1.Append("  where   jzbh='" + jzbh_temp_1 + "'  and  xfdr='" + common_file.common_app.fkdr + "'");
                    B_common.ExecuteSql(strsql_1.ToString());
                }


            }
            if (pljz_type == "Value")//按值计算
            {
                jzbh_last_return = "";
                decimal je_ljz = 0;//记录完成一次累加之后的累计值
                int j_0 = 0; List<string> lsbh_jzbh = new List<string>();
                ds = B_sjzzd.GetList(" id>=0 and yydh='" + common_file.common_app.yydh + "'  and   (czzt='" + common_file.common_jzzt.czzt_gz + "'  or  czzt='" + common_file.common_jzzt.czzt_jzzgz + "')  and jzzt='" + jzzt + "'  order by  tfsj  asc");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        je_temp += (Math.Abs(decimal.Parse(ds.Tables[0].Rows[i]["xfje"].ToString())) -Math.Abs(decimal.Parse(ds.Tables[0].Rows[i]["fkje"].ToString())));
                        if (je_temp < pjje)
                        {
                            j_0 = i;//记录当前累加时记录到哪条sjzzd
                            lsbh_jzbh.Add(ds.Tables[0].Rows[i]["lsbh"].ToString() + "|" + ds.Tables[0].Rows[i]["jzbh"].ToString());
                            je_ljz = je_temp;
                            continue;
                        }

                         //这一部是将最后一个sjzzd中要累加的记录找出来添加到Szw_temp中;
                        if (je_temp >= pjje)//当累计金额达到要结账的金额时
                        {
                            if (i == 0)
                            { j_0 = -1; }
                            else
                            { j_0 = i - 1; }
                            decimal je_chaer = pjje - je_ljz;//最后这条结账编号要拆出多少金额出来
                            string jzbh_last = ds.Tables[0].Rows[i]["jzbh"].ToString();
                            jzbh_last_return = jzbh_last;
                             //string jzbh_last=ds.Tables[0].Rows[i]["jzbh"].ToString();
                            BLL.Sjzmx B_Sjzmx = new Hotel_app.BLL.Sjzmx();
                            DataSet ds_temp = B_Sjzmx.GetList(" id>=0  and yydh='" + common_file.common_app.yydh + "'  and     jzbh='"+jzbh_last+"'");
                            //对最后一个lsbh执行类似拆账的操作
                            Fun_fj_chaizhang(je_chaer, jzbh_last, jzzt);
                            break;
                        }
                    }
                    //把第0-j_0条记录添加到Szw_temp中
                    System.Text.StringBuilder strsql_2 = new StringBuilder();
                    if (j_0 >= 0)
                    {
                        for (int i_0 = 0; i_0 <= j_0; i_0++)
                        {
                            string lsbh_temp_1 = lsbh_jzbh[i_0].Split('|')[0].ToString();
                            string jzbh_temp_1 = lsbh_jzbh[i_0].Split('|')[1].ToString();
                            strsql_2 = new StringBuilder();
                            strsql_2.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
                            strsql_2.Append(" select  yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,jzzt,fjrb,fjbh,sktt,xfrq,xfsj,'" + common_file.common_app.czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,'',sjxfje,'1',shsc,'0',mxbh,czsj,'" + common_file.common_app.czy_GUID + "' from Sjzmx");
                            strsql_2.Append("  where    jzbh='" + jzbh_temp_1 + "'  and  xfdr!='" + common_file.common_app.fkdr + "'  and  jzzt='" + jzzt + "'");
                            B_common.ExecuteSql(strsql_2.ToString());

                            strsql_2 = new StringBuilder();
                            strsql_2.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
                            strsql_2.Append(" select  yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,jzzt,fjrb,fjbh,sktt,xfrq,xfsj,'" + common_file.common_app.czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,'',sjxfje,'1',shsc,'0',mxbh,czsj,'" + common_file.common_app.czy_GUID + "'  from Sjzmx");
                            strsql_2.Append("  where   jzbh='" + jzbh_temp_1 + "'  and  xfdr='" + common_file.common_app.fkdr + "'");
                            B_common.ExecuteSql(strsql_2.ToString());
                        }
                    }
                }
            }
        }

        //这个函数执行的结果是，当最后一个jzbh中对应的消费条目按je_chaer的数量列入到Szw_temp中(最后一个lsbh中的i条记录插入到lsbh中)
        public void Fun_fj_chaizhang(decimal je_chaer, string jzbh,string jzzt)
        {
            BLL.Szwmx B_Szwmx = new Hotel_app.BLL.Szwmx();
            BLL.Common B_common = new Hotel_app.BLL.Common();
            StringBuilder strsql;
            decimal ljje = 0;
            string id_app;//当前要拆分的Id_app
            decimal je_temp = 0 ;//记录当前累加值
            int j = 0;
            DataSet ds = B_Szwmx.GetList(" id>=0  and yydh='" + common_file.common_app.yydh + "'  and jzbh='" + jzbh + "'    and xfdr!='"+common_file.common_app.fkdr+"'  order by xfsj  asc");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ljje += decimal.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString());
                    j = i;//记录当前累加的记录
                    if (ljje < je_chaer)
                    { je_temp = ljje; continue; }
                    if (ljje >= je_chaer)
                    {
                        if (ljje > je_chaer)
                        {
                            string Union_bh_new = common_file.common_ddbh.ddbh("lzbh", "szdate", "szcounter", 6);//算帐操作
                            string id_app_old = ds.Tables[0].Rows[i]["id_app"].ToString();
                            string id_app_new = common_file.common_ddbh.ddbh("gzpj", "jzdate", "jzcounter", 6);//前缀保留成挂帐分结

                            decimal je_need = je_chaer - je_temp;
                            decimal je_last = decimal.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString()) - je_need;
                            Fun_gzpj_chaizhang(id_app_old, id_app_new, Union_bh_new, je_need, je_last, DateTime.Now.ToString());
                        }
                        break;
                    }
                }
                //将0-第i条记录添加到Szw_temp中
                for (int i_0 = 0; i_0 <= j; i_0++)
                {
                    strsql = new StringBuilder();
                    strsql.Append("insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
                    strsql.Append(" select  yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,jzzt,fjrb,fjbh,sktt,xfrq,xfsj,'" + common_file.common_app.czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,'',sjxfje,xfsl,shsc,'0',mxbh,czsj,'" + common_file.common_app.czy_GUID + "'   from Sjzmx");
                    strsql.Append("  where     jzbh='" + jzbh+ "'  and  id_app='" + ds.Tables[0].Rows[i_0]["id_app"].ToString() + "'");
                    B_common.ExecuteSql(strsql.ToString());
                }
            }
        }


        //参照结账分结方法实现挂账批结中的账务拆分
        public void Fun_gzpj_chaizhang(string id_app_old, string id_app_new, string union_lzbh, decimal je_need, decimal je_last, string czsj)
        {
            BLL.Szwmx B_Szwmx = new Hotel_app.BLL.Szwmx();
            BLL.Common B_common = new Hotel_app.BLL.Common();
            StringBuilder strsql;
            Model.Szwmx M_Szwmx;

            M_Szwmx = B_Szwmx.GetModelList("id_app='" + id_app_old + "'  and id>=0  and  yydh='" + common_file.common_app.yydh + "'")[0];
            //decimal xfsl_need = je_need / (je_need + je_last) * M_Szwmx.xfsl; //拆出消费数量
            //decimal xfsl_last = M_Szwmx.xfsl - xfsl_need;

            double xfsl_need = common_file.common_sswl.Round_sswl(double.Parse((je_need / (je_need + je_last) * M_Szwmx.xfsl).ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel); //拆出消费数量
            double xfsl_last = double.Parse((M_Szwmx.xfsl).ToString()) - xfsl_need;

            //向Szw_union里面加入拆出来的两条记录(1表示是第一条记录，原来被拆的那条，0表示新加的那条)
            string temp_czsj = DateTime.Now.ToString();//保持两条的时间一致
            strsql = new StringBuilder();
            strsql.Append("insert into  Szw_union(yydh,qymc,union_bh,jzbh,id_app,czsj,is_first)");
            strsql.Append("  select yydh,qymc,'" + union_lzbh + "',jzbh,'" + id_app_old + "','" + temp_czsj + "',1   from Szwmx ");
            strsql.Append("  where  id_app='" + id_app_old + "'");
            B_common.ExecuteSql(strsql.ToString());//第一条(旧的记录)
            strsql = new StringBuilder();
            strsql.Append("insert into  Szw_union(yydh,qymc,union_bh,jzbh,id_app,czsj,is_first)");
            strsql.Append("  select yydh,qymc,'" + union_lzbh + "',jzbh,'" + id_app_new + "','" + temp_czsj + "',0   from Szwmx ");
            strsql.Append("  where id_app='" + id_app_old + "'");
            B_common.ExecuteSql(strsql.ToString());//第二条(新生成的一条记录)

            //第一步，拆分帐务明细表的记录
            strsql = new StringBuilder();
            strsql.Append("update  Szwmx  set  xfje=" + je_need + ", sjxfje=" + je_need + ", xfsl=" + xfsl_need + "  where id>=0  and yydh='" + common_file.common_app.yydh + "'  and id_app='" + id_app_old + "'");
            B_common.ExecuteSql(strsql.ToString());
            //注意这里的xfzy  以分结类型用"拆帐"来显示
            strsql = new StringBuilder();
            strsql.Append("insert into  Szwmx(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
            strsql.Append("  select  yydh,qymc,is_top,is_select,'" + id_app_new + "',jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,'" + common_zw.zwcl_caiz + "',jjje," + je_last + ",yh," + je_last + "," + xfsl_last + ",shsc,czy_bc,'" + common_zw.zwcl_caiz + "',czsj,syzd,is_visible,mxbh  from  Szwmx");
            strsql.Append("  where  id>=0 and id_app='" + id_app_old + "'");
            B_common.ExecuteSql(strsql.ToString());

            //结帐明细要一起分拆--针对记。挂
            strsql = new StringBuilder();
            strsql.Append("update  Sjzmx  set  xfje=" + je_need + ", sjxfje=" + je_need + ", xfsl=" + xfsl_need + "  where id>=0  and yydh='" + common_file.common_app.yydh + "'  and id_app='" + id_app_old + "'");
            B_common.ExecuteSql(strsql.ToString());

            strsql = new StringBuilder();
            strsql.Append("insert into  Sjzmx(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj)");
            strsql.Append("  select  yydh,qymc,is_top,is_select,'" + id_app_new + "',jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,'" + common_zw.zwcl_caiz + "',jjje," + je_last + ",yh," + je_last + "," + xfsl_last + ",shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj  from  Sjzmx");
            strsql.Append("  where  id>=0 and id_app='" + id_app_old + "'");
            B_common.ExecuteSql(strsql.ToString());

            //第二步，拆分ssyxfmx里面的记录
            strsql = new StringBuilder();
            strsql.Append(" update   Ssyxfmx  Set xfje=" + je_need + ",  sjxfje=" + je_need + ",xfsl=" + xfsl_need + ",czsj='"+temp_czsj+"'  where id>=0  and yydh='" + common_file.common_app.yydh + "' and id_app='" + id_app_old + "'");
            B_common.ExecuteSql(strsql.ToString());
            //
            strsql = new StringBuilder();
            strsql.Append("insert into Ssyxfmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,mxbh,ddsj,lksj,czsj )");
            strsql.Append(" select yydh,qymc,'" + id_app_new + "',jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,'" + common_zw.zwcl_caiz + "',jjje," + je_last + ",yh," + je_last + "," + xfsl_last + ",czy_bc,mxbh,ddsj,lksj,'" + temp_czsj + "'  from Ssyxfmx");
            strsql.Append(" where id_app='" + id_app_old + "'");
            B_common.ExecuteSql(strsql.ToString());

            //增加完成后直接向Ssyxfmx_cz里面加一条记录
            strsql = new StringBuilder();
            strsql.Append("insert into  Ssyxfmx_cz(yydh,qymc,id_app,krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq)");
            strsql.Append("  select  yydh,qymc,'" + id_app_new + "',krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq from Ssyxfmx_cz ");
            strsql.Append("  where id>=0  and id_app='" + id_app_old + "'");
            B_common.ExecuteSql(strsql.ToString());

            ////把新拆出来的一条记录加入到Szw_zz_fj_temp里面
            //strsql = new StringBuilder();
            //strsql.Append("insert into  Szw_zz_fj_temp(yydh,qymc,jzbh,id_app,lsbh,czy,czsj)");
            //strsql.Append("   select  yydh,qymc,jzbh,'" + id_app_new + "',lsbh,czy,'" + czsj + "'  from  Szwmx ");
            //strsql.Append("  where  id_app='" + id_app_old + "'");
            //B_common.ExecuteSql(strsql.ToString());
        }

    }
}
