using System;
using System.Data;
using System.Configuration;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using Hotel_app.common_file;
using Hotel_app.Server.Hhygl;

namespace Hotel_app.Server.Szwgl
{
    ///记挂，挂, 算帐的处理
    /// <summary>
    /// 此类包含:A Sjzmx_pz（平帐的方法）
    ///                 B  Func_zwclFunc_zwcl（记帐，挂，结帐用到的方法）
    /// </summary>
    public class Szw_jzOrgzOrSZ
    {
        public Hotel_app.BLL.Szw_temp B_szw_temp = new Hotel_app.BLL.Szw_temp();
        public Hotel_app.Model.Szw_temp M_Szw_temp;
        public Hotel_app.BLL.Qskyd_fjrb Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        public Hotel_app.Model.Qskyd_fjrb M_Qskyd_fjrb;
        public Hotel_app.BLL.Flfsz B_Flfsz = new Hotel_app.BLL.Flfsz();
        Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();//房态及删除主单操作
        Hotel_app.Server.Qyddj.Qttyd_add_edit_delete Qttyd_add_edit_delete_new = new Hotel_app.Server.Qyddj.Qttyd_add_edit_delete();
        Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Ffjzt.Ffjzt_add_edit();//用于修改房态
        BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();//修改房态
        Hotel_app.BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        Hotel_app.Model.Qskyd_mainrecord M_Qskyd_mainrecord;
        Hotel_app.BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
        Hotel_app.Model.Qttyd_mainrecord M_Qttyd_mainrecord;
        Hotel_app.BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();

        Hotel_app.BLL.Qskyd_mainrecord_bak B_Qskyd_mainrecord_bak = new Hotel_app.BLL.Qskyd_mainrecord_bak();
        Hotel_app.Model.Qskyd_mainrecord_bak M_Qskyd_mainrecord_bak;

        //修改房态时用到的变量
        string id = "";//主单的ID

        public DataSet ds_temp;
        public DataSet ds_xfxm_hz;
        public string jzbh = "";//结/记/挂帐时生成的主单编号
        public string id_app = "";//是标识每一条帐务明细的（每条帐务都有不同的id_app)
        public string fkje = "";//付款大类的统计
        public string xfje = "";//所有消费的项目总和
        StringBuilder strSql;
        //批量写入时会用到的参数
        public string xydw = "";
        public string krly = "";

        public string bz = "";
        public string xxzs = common_app.xxzs;

        string krxm_lz = "";
        string fjbh_lz = "";
        string ddsj = "";
        string qymc = "";


        public BLL.Common B_common = new Hotel_app.BLL.Common();
        // 
        //挂帐/记帐/算帐
        public string Func_zwcl(string lsbh, string sktt, string xydw, string krly, string yydh, string czzt, string jzzt, string czy, string czy_bc, string cznr, string czsj, string syzd, string xxzs,string czy_GUID)
        {
            string s = common_app.get_failure;
            decimal fkje_temp = 0; //付款
            decimal xfje_temp = 0;//消费

            ds_temp = null;
            ds_xfxm_hz = null;
            this.xxzs = xxzs;

            krxm_lz = "";
            fjbh_lz = "";
            ddsj = "";
            //20120611更新(新增加了krxm_lz,fjbh_lz,ddsj)
            common_zw.GetJZinfo(ref krxm_lz, ref fjbh_lz, ref ddsj, lsbh, yydh, sktt);
            BLL.Xqyxx B_xqyxx = new Hotel_app.BLL.Xqyxx();
            qymc = B_xqyxx.GetList("id>=0  and yydh='" + yydh + "'").Tables[0].Rows[0]["qymc"].ToString();

            string hhykh_temp = "";//记录退房者的会员卡号
            string phoneNo = "";//当前退房者的电话
            //查询是否是会员及输入了会员卡
            if (sktt == "sk" && krly.Equals(common_krly.krly_hyuan))
            {
                DataSet ds666 = B_common.GetList(" SELECT  *  from   Qskyd_mainrecord   ", " id>=0  and  yydh='" + yydh + "'  and  lsbh='" + lsbh + "' ");
                if (ds666 != null && ds666.Tables[0].Rows.Count > 0)
                {
                    if (!ds666.Tables[0].Rows[0]["hykh_bz"].Equals(""))
                    {
                        hhykh_temp = ds666.Tables[0].Rows[0]["hykh_bz"].ToString();
                        phoneNo = ds666.Tables[0].Rows[0]["krsj"].ToString();
                    }
                }
            }


            //生成jzbh(要判断jzzt,来确定标识符前串)
            if (czzt == common_file.common_jzzt.czzt_bfsz || czzt == common_file.common_jzzt.czzt_sz)//部分结帐和结帐
            {
                jzbh = common_file.common_ddbh.ddbh("szcz", "jzdate", "jzcounter", 6);//算帐操作
            }
            if (czzt == common_file.common_jzzt.czzt_gz)
            {
                jzbh = common_file.common_ddbh.ddbh("gzcz", "jzdate", "jzcounter", 6);//挂帐操作
            }
            if (czzt == common_file.common_jzzt.czzt_jz)
            {
                jzbh = common_file.common_ddbh.ddbh("jzcz", "jzdate", "jzcounter", 6);//记帐操作
            }
            if (jzbh.Trim() != "")
            {
                common_file.common_czjl.add_czjl(yydh, qymc, czy, "生成结账编号", jzbh, jzbh, DateTime.Now);

                //先从当前的Szw_temp中查询到当前的lsbh,czy查询出的记录
                ds_temp = B_szw_temp.GetList("id>0  " + common_file.common_app.yydh_select + "  and czy_temp='" + czy_GUID + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0) //有消费记录
                {
                    common_file.common_czjl.add_czjl(yydh, qymc, czy, "进行账务处理", lsbh, jzbh, DateTime.Now);
                    //更新Szw_temp里面的对应记录的jzbh
                    StringBuilder sb = new StringBuilder();
                    sb.Append("update Szw_temp  set  jzbh='" + jzbh + "'  where id>0  " + common_file.common_app.yydh_select + "   and czy_temp='" + czy_GUID + "'");
                    if (B_common.ExecuteSql(sb.ToString()) > 0)//修改成功
                    {
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "更新Szw_temp中的结账编号为" + jzbh, lsbh, jzbh, DateTime.Now);
                        ds_temp = B_szw_temp.GetList("id>0  " + common_file.common_app.yydh_select + "  and czy_temp='" + czy_GUID + "'");
                        //计算出xfje和fkje
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
                            {
                                if (ds_temp.Tables[0].Rows[i]["xfxm"].ToString() == common_app.dj_ysk || ds_temp.Tables[0].Rows[i]["xfxm"].ToString() == common_app.dj_pzsk)
                                {
                                    fkje_temp += decimal.Parse(ds_temp.Tables[0].Rows[i]["sjxfje"].ToString());
                                }
                                else
                                {
                                    xfje_temp += decimal.Parse(ds_temp.Tables[0].Rows[i]["sjxfje"].ToString());
                                }
                            }
                        }
                        //fkje
                        //fkje = Math.Abs(fkje_temp).ToString();//最终的付款金额(用绝对值存储)
                        fkje = (-fkje_temp).ToString();
                        //xfje
                        xfje = xfje_temp.ToString();

                        //帐务操作处理
                        if (Pladd(lsbh, qymc, sktt, jzbh, xydw, krly, yydh, czsj, syzd, czy, czy_bc, czzt, jzzt, cznr, bz, fkje, xfje, xxzs, ds_temp, hhykh_temp, phoneNo,czy_GUID) == common_app.get_suc)
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                }
                else   //没有消费记录（空结)
                {
                    if (Pladd(lsbh, qymc, sktt, jzbh, xydw, krly, yydh, czsj, syzd, czy, czy_bc, czzt, jzzt, cznr, bz, "0", "0", xxzs, null, hhykh_temp, phoneNo,czy_GUID) == common_app.get_suc)
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
            }
            common_file.common_czjl.add_czjl(yydh, "", czy, "当前对帐务:" + lsbh + "进行" + czzt, czzt, czzt + "结果为" + s, Convert.ToDateTime(czsj));
            return s;
        }

        /// 记、挂、结帐时的帐务处理
        /// 
        /// </summary>
        /// 先写入Sjzzd，同时写sjzmx,Ffkfssz
        /// 写入成功后，将zwmx里面的对应的记录写入到zwmx_bak,并删除当前lsbh对应下的zwmx记录(jzzt 结帐主体  ,czzt  记帐，结帐，挂帐)
        public string Pladd(string lsbh, string qymc, string sk_tt, string jzbh, string xydw, string krly, string yydh, string czsj, string syzd, string czy, string czy_bc, string czzt, string jzzt, string cznr, string bz, string fkje, string xfje, string xxzs, DataSet ds_jzsj, string hhykh_temp, string phoneNo,string czy_GUID)
        {
            string s = common_app.get_failure;
            decimal fkje_temp = decimal.Parse(fkje);
            decimal xfje_temp = decimal.Parse(xfje);
            string xyh = "";//注意，只有gz的情况下才能有xydw common_zw.GetxyhByxydw(xydw, yydh);
            string xydw_temp = "";
            if (czzt == common_file.common_jzzt.czzt_gz)
            {
                xyh = common_zw.GetxyhByxydw(jzzt, yydh);
                xydw_temp = jzzt;
            }
            if (fkje_temp == 0 && xfje_temp == 0 && (ds_jzsj == null))//空结的
            {
                int result = 0;
                strSql = new StringBuilder();
                strSql.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,ddsj,krxm_lz,fjbh_lz,shys)");
                if (sk_tt == "sk")
                {
                    strSql.Append(" select top 1 yydh,qymc,'" + lsbh + "','" + jzbh + "',krxm,sktt,fjbh,'" + xyh + "','" + xydw_temp + "','" + krly + "','" + DateTime.Now + "','" + czsj + "','" + czy + "','" + czzt + "','" + jzzt + "','" + syzd + "','" + bz + "'," + fkje_temp + "," + xfje_temp + ",'" + ddsj + "','" + krxm_lz + "','" + fjbh_lz + "',1  from Qskyd_fjrb");
                }
                if (sk_tt == "tt")//团体的时候，房间编号为空
                {
                    strSql.Append("select top 1 yydh,qymc,'" + lsbh + "','" + jzbh + "',krxm,sktt,'','" + xyh + "','" + xydw + "','" + krly + "','" + DateTime.Now + "','" + czsj + "','" + czy + "','" + czzt + "','" + jzzt + "','" + syzd + "','" + bz + "'," + fkje_temp + "," + xfje_temp + ",'" + ddsj + "','" + krxm_lz + "','" + fjbh_lz + "',1   from Qttyd_mainrecord");
                }
                strSql.Append(" where lsbh='" + lsbh + "'");
                result = B_common.ExecuteSql(strSql.ToString());
                common_file.common_czjl.add_czjl(yydh, qymc, czy, "增加结账主单为:" + jzbh, lsbh, jzbh, DateTime.Now);
                if (result > 0 && GetJzResult(lsbh, jzbh, yydh, jzzt, syzd, czy_bc, czzt, sk_tt, czy, czsj, hhykh_temp, phoneNo,czy_GUID) == common_app.get_suc)
                {
                    s = common_app.get_suc;
                }
                // s = common_app.get_suc;
            }
            else //if (fkje_temp != 0 || xfje_temp != 0)
            {
                //获取krxm,房间编号
                string krxm_00 = "";
                string fjbh_00 = "";
                string sk_tt_00 = "";
                DataSet ds_00 = B_common.GetList(" select  * from  Qskyd_fjrb ", " id>=0  and lsbh='" + lsbh + "' and yydh='" + yydh + "'");
                if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                {
                    krxm_00 = ds_00.Tables[0].Rows[0]["krxm"].ToString();
                    fjbh_00 = ds_00.Tables[0].Rows[0]["fjbh"].ToString();
                    sk_tt_00 = ds_00.Tables[0].Rows[0]["sktt"].ToString();
                }
                //注意jzzd只写入一次(公共信息查一次就好)
                strSql = new StringBuilder();
                strSql.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,ddsj,krxm_lz,fjbh_lz,shys)");
                if (sk_tt == "sk")
                {

                    strSql.Append(" select top 1 yydh,qymc,'" + lsbh + "',jzbh,'" + krxm_00 + "','" + sk_tt_00 + "','" + fjbh_00 + "','" + xyh + "','" + xydw + "','" + krly + "','" + DateTime.Now + "','" + czsj + "','" + czy + "','" + czzt + "','" + jzzt + "','" + syzd + "','" + bz + "'," + fkje_temp + "," + xfje_temp + ",'" + ddsj + "','" + krxm_lz + "','" + fjbh_lz + "',1  from Szw_temp");
                }
                if (sk_tt == "tt")
                {
                    strSql.Append(" select top 1 yydh,qymc,'" + lsbh + "',jzbh,'" + krxm_00 + "','" + sk_tt_00 + "','','" + xyh + "','" + xydw + "','" + krly + "','" + DateTime.Now + "','" + czsj + "','" + czy + "','" + czzt + "','" + jzzt + "','" + syzd + "','" + bz + "'," + fkje_temp + "," + xfje_temp + ",'" + ddsj + "','" + krxm_lz + "','" + fjbh_lz + "',1   from Szw_temp");
                }
                strSql.Append(" where lsbh='" + lsbh + "' and  czy_temp='" + czy_GUID + "'");
                if (B_common.ExecuteSql(strSql.ToString()) > 0)//
                {
                    common_file.common_czjl.add_czjl(yydh, qymc, czy, "增加结账主单为:" + jzbh, lsbh, jzbh, DateTime.Parse(czsj));
                    //修改Sjzmx 表里面的dj_pzsk项(平帐收款是直接写入Sjzmx里面的)
                    //strSql = new StringBuilder();
                    //strSql.Append(" update  Sjzmx  set   jzbh='" + jzbh + "',jzzt='" + jzzt + "'  where xfxm='" + common_app.dj_pzsk + "'  and czy='" + czy + "' and lsbh='" + lsbh + "'");
                    //B_common.ExecuteSql(strSql.ToString());

                    strSql = new StringBuilder();
                    strSql.Append("insert into Sjzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh,tfsj ) ");
                    strSql.Append(" select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,'" + czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,'" + czy_bc + "','" + czzt + "','" + czsj + "','" + syzd + "','" + xyh + "','" + jzzt + "',fkfs,mxbh,'" + czsj + "'  from Szw_temp");
                    strSql.Append(" where  czy_temp='" + czy_GUID + "'");
                    B_common.ExecuteSql(strSql.ToString());//写入jzmx成功后,

                    B_common.ExecuteSql("  update  Ssyxfmx  set jzbh='" + jzbh + "'   where    yydh='" + yydh + "'  and id_app in (select id_app from Szw_temp where  czy_temp='" + czy_GUID + "')");

                    //更新zwmx里面此lsbh对应的帐务的结帐编号
                    B_common.ExecuteSql("update  Szwmx  set  jzbh='" + jzbh + "',czzt='" + czzt + "',czsj='" + czsj + "'  where id>0  " + common_file.common_app.yydh_select + "  and  id_app in (select id_app from Szw_temp where  czy_temp='" + czy_GUID + "')");

                    if (czzt == common_jzzt.czzt_sz)
                    {
                        B_common.ExecuteSql("update Syjcz  set jzbh='" + jzbh + "',czzt='" + czzt + "'  where id>0 " + common_app.yydh_select + "  and  id_app in (select id_app from Szw_temp where  czy_temp='" + czy_GUID + "')");
                        //备份押金
                        strSql = new StringBuilder();
                        strSql.Append(" insert into Syjcz_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt)");
                        strSql.Append("  select   yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt   from  Syjcz");
                        strSql.Append("  where  id_app  in (select  id_app  from Szw_temp  where czy_temp='" + czy_GUID + "')");
                        B_common.ExecuteSql(strSql.ToString());
                    }
                    if (czzt == common_jzzt.czzt_jz || czzt == common_jzzt.czzt_gz)
                    {
                        B_common.ExecuteSql("update Syjcz  set jzbh='" + jzbh + "',czzt='" + czzt + "'  where id>0 " + common_app.yydh_select + "  and  id_app in (select id_app from Szw_temp where  czy_temp='" + czy_GUID + "')");
                    }
                    if (GetJzResult(lsbh, jzbh, yydh, jzzt, syzd, czy_bc, czzt, sk_tt, czy, czsj, hhykh_temp, phoneNo,czy_GUID) == common_app.get_suc)
                    {
                        s = common_app.get_suc;
                    }

                }
            }
            //if (GetJzResult(lsbh, jzbh, yydh, jzzt, syzd, czy_bc, czzt, sk_tt, czy, czsj) == common_app.get_suc)
            //   s = common_app.get_suc;
            return s;
        }


        //结帐,记帐,挂帐处理过程 
        public string GetJzResult(string lsbh, string jzbh, string yydh, string jzzt, string syzd, string czy_bc, string czzt, string sk_tt, string czy, string czsj, string hhykh_bz, string phoneNo,string  czy_GUID)
        {
            string s = common_app.get_failure;
            //记帐，挂帐，结帐的处理节
            if (czzt == common_file.common_jzzt.czzt_sz)//算帐
            {
                strSql = new StringBuilder();
                strSql.Append("  insert into  Sfkfssz(yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,xfrq,xfsj,czrq,czsj,czy,czy_bc,syzd,id_app)");
                strSql.Append("  select  yydh,qymc,0,0,jzbh,'" + jzzt + "',lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,-xfje,-sjxfje,xfrq,xfsj,'" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "','" + czy + "','" + czy_bc + "','" + syzd + "',id_app  from Szw_temp  where   jzbh='" + jzbh + "' and xfdr='" + common_app.fkdr + "'");
                B_common.ExecuteSql(strSql.ToString());


                strSql = new StringBuilder();
                strSql.Append("delete from Syjcz where id>0  " + common_app.yydh_select + "  and   id_app  in (select  id_app  from Szw_temp  where czy_temp='" +czy_GUID  + "')");
                B_common.ExecuteSql(strSql.ToString());

                strSql = new StringBuilder();
                strSql.Append("delete from Szwmx  where id>=0  " + common_file.common_app.yydh_select + "  and jzbh<>'' and  jzbh='" + jzbh + "'");
                B_common.ExecuteSql(strSql.ToString());
            }
            if (czzt == common_jzzt.czzt_gz || czzt == common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_sz)
            {
                //调用修改房态的方法(第五步)
                if (sk_tt == "sk")
                {
                    //DataSet ds_temp0 = B_common.GetList(" select distinct  lsbh  from Szw_temp", " czy='" + czy + "'  and  yydh='" + yydh + "'");
                    DataSet ds_temp0 = B_common.GetList(" select * from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  )  and  shlz=1  ");


                    // B_common.GetList("select distinct  lsbh  from Flfsz", "  lfbh in (select lfbh From Flfsz where lsbh='" + lsbh + "'   )  and  shlz=1  and  yydh='" + yydh + "'");
                    if (ds_temp0 != null && ds_temp0.Tables[0].Rows.Count > 0)
                    {


                    }
                    else
                    {

                        ds_temp0 = B_common.GetList("select distinct  lsbh  from Qskyd_mainrecord", "   lsbh='" + lsbh + "'  and  yydh='" + yydh + "'");
                    }


                    if (ds_temp0 != null && ds_temp0.Tables[0].Rows.Count > 0)
                    {
                        s = common_app.get_failure;
                        for (int j = 0; j < ds_temp0.Tables[0].Rows.Count; j++)
                        {
                            string lsbh_0 = ds_temp0.Tables[0].Rows[j]["lsbh"].ToString();
                            M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh_0 + "'")[0];
                            id = M_Qskyd_mainrecord.id.ToString();
                            //删除主单记录（这里有包含主单记录删除时的备份）
                            // if (Qyddj_add_edit_delete_new.delete_sz_xgft(id, "jz", common_file.common_jzzt.czzt_sz, "", jzbh, czy, czsj, xxzs) == common_app.get_suc)
                            if (Qyddj_add_edit_delete_new.delete_sz_xgft(id, "jz", czzt, "", jzbh, czy, czsj, xxzs) == common_app.get_suc)
                            {
                                s = common_app.get_suc;
                            }
                        }
                    }
                    else
                    {
                        //M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'")[0];
                        DataSet ds_1 = B_common.GetList(" select * from  Qskyd_mainrecord ", "id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'  and  main_sec='" + common_file.common_app.main_sec_main + "'");
                        //M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'")[0];
                        if (ds_1 != null && ds_1.Tables[0].Rows.Count > 0)
                        {//M_Qskyd_mainrecord.id.ToString();
                            //删除主单记录（这里有包含主单记录删除时的备份
                            id = ds_1.Tables[0].Rows[0]["id"].ToString();
                            // if (Qyddj_add_edit_delete_new.delete_sz_xgft(id, "jz", common_file.common_jzzt.czzt_sz, "", jzbh, czy, czsj, xxzs) == common_app.get_suc)
                            if (Qyddj_add_edit_delete_new.delete_sz_xgft(id, "jz", czzt, "", jzbh, czy, czsj, xxzs) == common_app.get_suc)
                            {
                                s = common_app.get_suc;
                            }
                        }
                    }
                }
                else//是团体
                {
                    DataSet ds_1 = B_common.GetList(" select * from  Qttyd_mainrecord ", "id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "' ");
                    if (ds_1 != null && ds_1.Tables[0].Rows.Count > 0)
                    {
                        //M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("ID>0 " + common_app.yydh_select + "  AND LSBH='" + lsbh + "'")[0];
                        string tt_id = ds_1.Tables[0].Rows[0]["id"].ToString();// M_Qttyd_mainrecord.id.ToString();
                        //要成批更新团体所有成员的房态，并删除成员主单
                        //string ddbh_temp = M_Qttyd_mainrecord.ddbh;

                        // if (Qttyd_add_edit_delete_new.delete_sz_ttyd(tt_id, "jz", common_file.common_jzzt.czzt_sz, "", jzbh, czy, czsj, xxzs) == common_file.common_app.get_suc)
                        if (Qttyd_add_edit_delete_new.delete_sz_ttyd(tt_id, "jz", czzt, "", jzbh, czy, czsj, xxzs) == common_file.common_app.get_suc)
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                }

                if (s == common_app.get_suc)
                {
                    //备份到Szw_temp_bak，清除Szw_temp，并且更新bak表里面的tfsj为当前的操作时间
                    strSql = new StringBuilder();
                    strSql.Append(" insert into Szw_temp_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,jjje,xfje,yh,sjxfje,xfsl,shsc,mxbh,czsj,czy_temp)");
                    strSql.Append(" select yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,jjje,xfje,yh,sjxfje,xfsl,shsc,mxbh,czsj,czy_temp  from Szw_temp");
                    strSql.Append("  where czy_temp='" + czy_GUID + "'  and   xfxm!='" + common_app.dj_pzsk + "'");
                    B_common.ExecuteSql(strSql.ToString());

                    strSql = new StringBuilder();
                    strSql.Append("delete from Szw_temp  where  id>0   and    czy_temp='" + czy_GUID + "'");
                    if (B_common.ExecuteSql(strSql.ToString()) >= 0) //清除Szw_temp里面的数据了
                        //修改备份表的tfsj
                        if (sk_tt == "sk")
                        {
                            B_common.ExecuteSql(" update  Qskyd_mainrecord_bak  set  czsj='" + czsj + "'  where  jzbh='" + jzbh + "'");
                            B_common.ExecuteSql(" update  Qskyd_mainrecord_lskr  set  czsj='" + czsj + "'   where   jzbh='" + jzbh + "'");
                            //B_common.ExecuteSql(" update  Qskyd_mainrecord_temp set lksj='" + czsj + "'  where lsbh='" + lsbh + "'");
                        }
                    if (sk_tt == "tt")
                    {
                        string bak_ddbh_temp = DbHelperSQL.GetSingle(" Select  ddbh  from Qttyd_mainrecord_bak  where lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'").ToString();
                        string bak_jzbh_temp = DbHelperSQL.GetSingle(" select jzbh from Qttyd_mainrecord_bak where lsbh='" + lsbh + "' and jzbh='" + jzbh + "'").ToString();

                        B_common.ExecuteSql("  update Qttyd_mainrecord_bak set  czsj='" + czsj + "' where lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                        B_common.ExecuteSql(" update  Qskyd_mainrecord_bak  set  czsj='" + czsj + "'  where ddbh='" + bak_ddbh_temp + "' and jzbh='" + bak_jzbh_temp + "'");
                        B_common.ExecuteSql(" update  Qskyd_mainrecord_lskr  set  czsj='" + czsj + "'   where ddbh='" + bak_ddbh_temp + "'  and  jzbh='" + bak_jzbh_temp + "'");
                        B_common.ExecuteSql(" update  Qskyd_mainrecord_temp set czsj='" + czsj + "'  where ddbh='" + bak_ddbh_temp + "'");
                    }
                }

                //结帐成功后,更新会员的积分(挂-结，记-结，部分结，结帐都要加积分
                DataSet ds_temp_2;
                if (sk_tt == "sk")
                {
                    ds_temp_2 = B_common.GetList("select jzbh,lsbh,hykh,hykh_bz,krsj,xyh,xydw from Qskyd_mainrecord_bak", " id>=0 and jzbh='" + jzbh + "'");
                    if (ds_temp_2 != null && ds_temp_2.Tables[0].Rows.Count > 0)
                    {
                        for (int i_0 = 0; i_0 < ds_temp_2.Tables[0].Rows.Count; i_0++)
                        {
                            //有用到的时候才启用

                            //IncHYScore(ds_temp_2.Tables[0].Rows[i_0]["jzbh"].ToString(), ds_temp_2.Tables[0].Rows[i_0]["lsbh"].ToString(), sk_tt, ds_temp_2.Tables[0].Rows[i_0]["hykh_bz"].ToString(), yydh, qymc,ds_temp_2.Tables[0].Rows[i_0]["krsj"].ToString() , czsj);
                        }
                    }
                }
                else
                    if (sk_tt == "tt")
                    {

                    }
            }
            return s;
        }


        /// <summary>
        /// 结帐成功后更新积分
        /// </summary>
        /// <param name="hykh"></param>
        /// <param name="lsbh"></param>
        /// <param name="sk_tt"></param>
        /// <param name="Score"></param>
        private void IncHYScore(string jzbh, string lsbh, string sk_tt,string hhykh_bz,string yydh,string qymc,string phoneNo,string czsj)
        {
            if (sk_tt == "sk" && hhykh_bz.Trim() != "")
            {
                Hhygl.Hhygl_verifyCode Hhygl_verifyCode_new = new Hhygl.Hhygl_verifyCode();
                string hykh = "";//会员唯一识别号
                string hyrx = "";//银卡
                string krxm = "";
                string parent_hykh = "";
                decimal jbxs_temp = 1;
                decimal sjjfs = 0;//升级所需的积分数
                decimal bcxfs = 0;//本次产生的积分数
                decimal jfxs = 0;//积分系统

                string lsbh_df = common_file.common_ddbh.ddbh("df", "lsbhdfdate", "lsbhdfcounter", 6);
                //读出会员类型
                DataSet ds777 = B_common.GetList(" select  *  from  Hhygl  ", "  id>=0  and hykh_bz='" + hhykh_bz + "'");
                if (ds777 != null && ds777.Tables[0].Rows.Count > 0)
                {
                    if (ds777.Tables[0].Rows[0]["hyrx"].ToString().Equals(common_file_server.common_app.hyrx_yk))//是银卡类型
                    {
                        //统计其积分
                        hyrx = ds777.Tables[0].Rows[0]["hyrx"].ToString();
                        hykh = ds777.Tables[0].Rows[0]["hykh"].ToString();
                        krxm = ds777.Tables[0].Rows[0]["krxm"].ToString();
                        parent_hykh = ds777.Tables[0].Rows[0]["parent_hykh"].ToString();
                    }
                    if (ds777.Tables[0].Rows[0]["hyrx"].ToString().Equals(common_file_server.common_app.hyrx_jk))
                    {
                        hyrx = ds777.Tables[0].Rows[0]["hyrx"].ToString();
                        hykh = ds777.Tables[0].Rows[0]["hykh"].ToString();
                        krxm = ds777.Tables[0].Rows[0]["krxm"].ToString();
                        parent_hykh = ds777.Tables[0].Rows[0]["parent_hykh"].ToString();
                    }
                }

                DataSet ds_1000 = B_common.GetList(" select * from  Hhyjf_bl ", "   hyrx='" + hyrx + "'");
                if (ds_1000 != null && ds_1000.Tables[0].Rows.Count > 0)
                {
                    jfxs = decimal.Parse(ds_1000.Tables[0].Rows[0]["jfbl"].ToString());
                }
                else
                {
                    jfxs = 1;
                }






                SqlParameter[] parms1 = new SqlParameter[4];

                parms1[0] = new SqlParameter("@jzbh", SqlDbType.VarChar, 300);
                parms1[1] = new SqlParameter("@xfdr", SqlDbType.VarChar, 300);
                parms1[2] = new SqlParameter("@lsbh", SqlDbType.VarChar, 300);
                parms1[3] = new SqlParameter("@TotalFF", SqlDbType.Decimal);

                parms1[0].Value = jzbh;
                parms1[1].Value = common_zw.dr_ff;
                parms1[2].Value = lsbh;

                parms1[3].Direction = ParameterDirection.Output;
                DbHelperSQL.RunProcedure("GetHyFfByJzbh", parms1);
                bcxfs = decimal.Parse(parms1[3].Value.ToString()) * common_file_server.common_app.hyrx_yk_xs;

                DataSet ds888 = B_common.GetList(" select  *  from  Hhyjb  ", "  id>=0  and hyrx='" + common_file_server.common_app.hyrx_jk + "'");
                if (ds888 != null && ds888.Tables[0].Rows.Count > 0)
                {
                    //统计其积分
                    sjjfs = decimal.Parse(ds888.Tables[0].Rows[0]["dfjf"].ToString());
                    jbxs_temp = decimal.Parse(ds888.Tables[0].Rows[0]["jbxs"].ToString());
                }

                SqlParameter[] parms = new SqlParameter[6];

                parms[0] = new SqlParameter("@hykh", SqlDbType.VarChar, 300);
                parms[1] = new SqlParameter("@sjjfs", SqlDbType.Decimal);
                parms[2] = new SqlParameter("@sjjfxe", SqlDbType.Decimal);
                parms[3] = new SqlParameter("@hyrx", SqlDbType.VarChar, 100);

                parms[4] = new SqlParameter("@JifenTotalYe", SqlDbType.Decimal);
                parms[5] = new SqlParameter("@shsj", SqlDbType.Bit, 2);

                parms[0].Value = hykh;
                parms[1].Value = sjjfs;
                parms[2].Value = decimal.Parse(common_file_server.common_app.hyykTojkjfsx);
                parms[3].Value = common_file_server.common_app.hyrx_jk;

                parms[4].Direction = ParameterDirection.Output;
                parms[5].Direction = ParameterDirection.Output;

                DbHelperSQL.RunProcedure("GetHyJifenByHykh", parms);

                decimal JifenTotalYe = decimal.Parse(parms[4].Value.ToString());
                //如果启用会员短信提醒，则发送短信
                if (hhygl_shqr.hygl_shqr_add(yydh))
                {
                    Hhygl_verifyCode_new.Hhygl_SendMsm(phoneNo, JifenTotalYe.ToString(), yydh, qymc, common_hyAction.hy_Action_hytf, "", "", "", "", hhykh_bz, (bcxfs * jfxs).ToString(), common_app.xxzs);
                }
                decimal sjjfs_temp = decimal.Parse(ConfigurationManager.AppSettings["hyykToJkjf"].ToString()); //升级所需要的积分数
                if ((JifenTotalYe >= sjjfs_temp) && hyrx.Equals(common_file_server.common_app.hyrx_yk))
                {
                    //进行升级，减去相应积分（调用以前的升级方法）
                    Hhygl.Hhyjf_df Hhyjf_df_new = new Hhygl.Hhyjf_df();
                    Hhyjf_df_new.Hhyjfdf_add_edit("", yydh, qymc, hykh, hhykh_bz, krxm, sjjfs.ToString(), common_file_server.common_app.hyykTojk, "1", lsbh_df, parent_hykh, common_app.get_add, common_app.xxzs);

                    Hhygl.Hhygl_add_edit Hhygl_add_edit_new = new Hhygl.Hhygl_add_edit();

                    B_common.ExecuteSql("  update  Hhygl  set  shxg=1, scsj=getdate(),xgsj=getdate(),hyrx='" + common_file_server.common_app.hyrx_jk + "'    where  hykh='" + hykh + "'");
                    //如果启用会员短信提醒，则发送升级提醒
                    if (hhygl_shqr.hygl_shqr_add(yydh))
                    {
                        Hhygl_verifyCode_new.Hhygl_SendMsm(phoneNo, (JifenTotalYe - sjjfs_temp).ToString(), yydh, qymc, common_file_server.common_hyAction.hy_Action_promoteType, DateTime.Now.ToString(), "", "", "", hhykh_bz, "", common_app.xxzs);
                    }

                }
            }
        }


        //平帐时用到的方法
        public string Sjzmx_pz(string id, string yydh, string qymc, string id_app, string jzbh, string lsbh, string krxm, string fjrb, string fjbh, string sktt,
    string xfrq, string xfsj, string czy, string xfdr, string xfrb, string xfxm, string xfbz, string xfzy, string xfje, string yh, string sjxfje, string xfsl,
    string czy_bc, string czzt, string czsj, string syzd, string add_edit_delete, string xxzs, string fkfs, string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                if (jzbh.Trim() == "")
                {
                    strSql = new StringBuilder();
                    strSql.Append(" insert into Szw_temp(yydh,qymc,lsbh,is_top,is_select,id_app,jzbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,yh,sjxfje,xfsl,shsc,jjje,mxbh,czsj,czy_temp)");
                    strSql.Append(" values('" + yydh + "','" + qymc + "','" + lsbh + "',0,0,'" + id_app + "','" + jzbh + "','" + krxm + "','" + fjrb + "','" + fjbh + "','" + sktt + "','" + xfrq + "','" + xfsj + "','" + czy + "','" + xfdr + "','" + xfrb + "','" + xfxm + "','" + xfbz + "','" + xfzy + "(" + fkfs + ")" + "','" + fkfs + "'," + decimal.Parse(xfje) + ",'" + yh + "'," + decimal.Parse(sjxfje) + ",1,0,0,'','" + DateTime.Now.ToString() + "','" + czy_GUID + "')");
                    B_common.ExecuteSql(strSql.ToString());
                }
                if (jzbh.Trim() != "")
                {
                    strSql = new StringBuilder();
                    strSql.Append("  insert into  Sjzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh,tfsj)");
                    strSql.Append("  select  yydh,qymc,'" + id_app + "',jzbh,lsbh,krxm,'" + fjrb + "',fjbh,sktt,'" + xfrq + "','" + xfsj + "','" + czy + "','" + xfdr + "','" + xfrb + "','" + xfxm + "','" + xfbz + "','" + xfzy + "(" + fkfs + ")" + "',0," + xfje + ",'" + yh + "'," + sjxfje + ",1,'" + czy_bc + "',czzt,'" + czsj + "','" + syzd + "',xyh,jzzt,'" + fkfs + "','',tfsj   from  Sjzzd  ");
                    strSql.Append("  where   jzbh='" + jzbh + "'  and yydh='" + yydh + "'");
                    B_common.ExecuteSql(strSql.ToString());

                    strSql = new StringBuilder();
                    strSql.Append("  insert into  Sfkfssz(yydh,qymc,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,czrq,czsj,xfrq,xfsj,czy,czy_bc,syzd,id_app)");
                    //strSql.Append(" values('" + yydh + "','" + qymc + "','" + jzbh + "','" + jzzt + "','" + lsbh + "','" + fjbh + "','" + krxm + "','" + fkfs + "','" + xfdr + "','"+xfrb+"','" + xfxm + "','" + xfje + "','" + sjxfje + "','" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "','" + xfrq + "','" + xfsj + "','" + czy + "','" + czy_bc + "','" + syzd + "','" + id_app + "')");
                    strSql.Append("  select  yydh,qymc,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,-xfje,-sjxfje,xfrq,xfsj,xfrq,xfsj,czy,czy_bc,syzd,id_app  from  Sjzmx ");
                    strSql.Append("  where jzbh='" + jzbh + "'  and  id_app='" + id_app + "'  and yydh='" + yydh + "'");
                    B_common.ExecuteSql(strSql.ToString());

                    string ss = "";
                    ss = "  update  Szwzd_bak  set   fkje=fkje-(" + sjxfje + ")  where  id>=0 and  lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'";
                    B_common.ExecuteSql(ss);
                    ss = "  update  Sjzzd  set   fkje=fkje-(" + sjxfje + ")  where id>=0  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'";
                    B_common.ExecuteSql(ss);

                }
                s = common_file.common_app.get_suc;

            }
            if (add_edit_delete == common_file.common_app.get_delete)
            {
                if (jzbh != "" && id_app != "")
                {
                    B_common.ExecuteSql(" delete  from  Sjzmx  where  jzbh='" + jzbh + "' and id_app='" + id_app + "'  and yydh='" + yydh + "'");
                    B_common.ExecuteSql(" delete  from  Sjzmx  where jzbh='" + jzbh + "'  and id_app='" + id_app + "'  and yydh='" + yydh + "'");
                }
                B_common.ExecuteSql(" delete  from  Szw_temp   where  id_app='" + id_app + "' and yydh='" + yydh + "'");
                s = common_file.common_app.get_suc;
            }
            if (add_edit_delete == common_file.common_app.get_edit)//平帐收款的更改只限fkfs的修改
            {
                //如果是编辑，新生成的两个id_app是放在lsbh--新增一条相同的，krxm--对应修改后的
                if (id_app != "" && jzbh != "")
                {
                    //如果Sfkfssz里面有当前这条记录，那么同步更新
                    string fkfs_old_fkfs = "";
                    string fkfs_old_fksj = "1800-01-01";
                    decimal je_tz = decimal.Parse(fjrb.Trim());
                    decimal je_tz_fk = -je_tz;
                    //提取旧的付款方式的信息以及付款时间
                    DataSet ds_0 = B_common.GetList(" select * from  Sfkfssz ", " id>=0  and  id_app='" + id_app + "' and jzbh='" + jzbh + "'");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        fkfs_old_fkfs = ds_0.Tables[0].Rows[0]["fkfs"].ToString();
                        fkfs_old_fksj = ds_0.Tables[0].Rows[0]["xfsj"].ToString();
                    }
                    string xfbz_new = "上次付款方式为:(" + fkfs_old_fkfs + "),付款时间为:" + fkfs_old_fksj + "的付款方式有误,这条为冲抵上次付款错误自动生成的记录!";

                    StringBuilder sb = new StringBuilder();
                    sb.Append(" insert into  Sjzmx(yydh, qymc,id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, jjje, xfje, yh, sjxfje, xfsl, shsc, czy_bc, czzt, tfsj, czsj, syzd, is_visible, xyh, jzzt, fkfs, mxbh) ");
                    sb.Append(" select yydh, qymc, '" + lsbh + "', jzbh, lsbh, krxm, fjrb, fjbh, sktt,'" + DateTime.Parse(czsj).ToShortDateString() + "', '" + czsj + "','" + czy + "', xfdr, '" + common_app.dj_pzsk + "','" + common_app.dj_pzsk + "','" + xfbz_new + "',xfzy, jjje, " + je_tz_fk + ", yh, " + je_tz_fk + ", xfsl, shsc, czy_bc, czzt, tfsj, '" + czsj + "', syzd, is_visible, xyh, jzzt, fkfs, mxbh  from Sjzmx");
                    sb.Append(" where  id_app='" + id_app + "'  and jzbh='" + jzbh + "' ");
                    B_common.ExecuteSql(sb.ToString());

                    sb = new StringBuilder();
                    sb.Append(" insert into  Sfkfssz( yydh, qymc, jzbh, jzzt, lsbh, fjbh, krxm, fkfs, xfdr, xfrb, xfxm, xfje, sjxfje, czrq, czsj, xfrq, xfsj, czy, czy_bc, syzd, id_app)   ");
                    sb.Append(" select  yydh,qymc,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,'" + common_app.dj_pzsk + "','" + common_app.dj_pzsk + "'," + je_tz + "," + je_tz + ",'" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "','" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "','" + czy + "','" + czy_bc + "','" + syzd + "','" + lsbh + "'  from   Sjzmx");
                    sb.Append("  where  id_app='" + id_app + "' and jzbh='" + jzbh + "' ");
                    B_common.ExecuteSql(sb.ToString());

                    xfbz_new = "对上一条平账收款记录的调整,平账收款由(" + fkfs_old_fkfs + "调整为:" + fkfs + ")";
                    string xfzy_new = "平账收款(" + fkfs + ")";
                    sb = new StringBuilder();
                    sb.Append(" insert into  Sjzmx(yydh, qymc, id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, jjje, xfje, yh, sjxfje, xfsl, shsc, czy_bc, czzt, tfsj, czsj, syzd, xyh, jzzt, fkfs, mxbh) ");
                    sb.Append(" select yydh, qymc, '" + krxm + "', jzbh, lsbh, krxm, fjrb, fjbh, sktt,'" + DateTime.Parse(czsj).ToShortDateString() + "', '" + czsj + "', '" + czy + "', xfdr,'" + common_app.dj_pzsk + "','" + common_app.dj_pzsk + "', '" + xfbz_new + "', '" + xfzy_new + "', jjje," + je_tz + ", yh, " + je_tz + ", xfsl, shsc, '" + czy_bc + "', czzt, tfsj, '" + czsj + "', '" + syzd + "',  xyh, jzzt, '" + fkfs + "', mxbh  from Sjzmx");
                    sb.Append(" where  id_app='" + id_app + "'  and jzbh='" + jzbh + "' ");
                    B_common.ExecuteSql(sb.ToString());

                    sb = new StringBuilder();
                    sb.Append(" insert into  Sfkfssz( yydh, qymc,  jzbh, jzzt, lsbh, fjbh, krxm, fkfs, xfdr, xfrb, xfxm, xfje, sjxfje, czrq, czsj, xfrq, xfsj, czy, czy_bc, syzd, id_app )");
                    sb.Append(" select  yydh,qymc,jzbh,jzzt,lsbh,fjbh,krxm,'" + fkfs + "',xfdr,'" + common_app.dj_pzsk + "','" + common_app.dj_pzsk + "'," + je_tz_fk + "," + je_tz_fk + ",'" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "','" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "','" + czy + "','" + czy_bc + "','" + syzd + "','" + krxm + "'   from Sjzmx ");
                    sb.Append("  where  id_app='" + id_app + "' and jzbh='" + jzbh + "' ");
                    B_common.ExecuteSql(sb.ToString());

                }
                B_common.ExecuteSql(" update  Szw_temp  set fkfs='" + fkfs + "',xfzy='" + common_app.dj_pzsk + "(" + fkfs + ")'  where  id_app='" + id_app + "' and yydh='" + yydh + "'");
                s = common_app.get_suc;
                common_file.common_czjl.add_czjl(yydh, qymc, czy, "调整平帐收款的付款方式为:" + fkfs, common_app.dj_pzsk, "调整平帐收款项目的付款方式,操作执行的结果为:" + s, Convert.ToDateTime(czsj));
            }
            return s;
        }

    }
}

