using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.DBUtility;
using Hotel_app.common_file_server;
using System.Data.SqlClient;
using Hotel_app.Server.Qyddj;

namespace Hotel_app.Server.Szwgl
{
    /// <summary>
    /// 此类包含:A Sjzmx_pz（平帐的方法）
    ///                 B  Func_zwclFunc_zwcl（记帐，挂，结帐用到的方法）
    /// </summary>
    public class Szwcl
    {
        public Hotel_app.BLL.Szw_temp B_szw_temp = new Hotel_app.BLL.Szw_temp();
        public Hotel_app.Model.Szw_temp M_Szw_temp;
        public Hotel_app.BLL.Qskyd_fjrb Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        public Hotel_app.Model.Qskyd_fjrb M_Qskyd_fjrb;
        public Hotel_app.BLL.Flfsz B_Flfsz = new Hotel_app.BLL.Flfsz();
        Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Qyddj_add_edit_delete();//房态及删除主单操作
        Qttyd_add_edit_delete Qttyd_add_edit_delete_new = new Qttyd_add_edit_delete();
        Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Hotel_app.Server.Ffjzt.Ffjzt_add_edit();//用于修改房态
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
        StringBuilder strSql = new StringBuilder();
        //批量写入时会用到的参数
        public string xydw = "";
        public string krly = "";

        public string bz = "";
        public string xxzs = common_app.xxzs;

        public BLL.Common B_common = new Hotel_app.BLL.Common();
        // 
        //挂帐/记帐/算帐(启用GUID来区别用户)
        public string Func_zwcl(string lsbh, string sktt, string xydw, string krly, string yydh, string czzt, string jzzt, string czy, string czy_bc, string cznr, string czsj, string syzd, string xxzs,string  czy_guid)
        {
            string s = common_app.get_failure;
            decimal fkje_temp = 0; //付款
            decimal xfje_temp = 0;//消费
            ds_temp = null;
            ds_xfxm_hz = null;
            this.xxzs = xxzs;


            string hykh = "";
            string phoneNo = "";
            if (krly.Equals(common_krly.krly_hyuan))
            {
                DataSet ds000 = B_common.GetList("  select   *  from Qskyd_mainrecord  ", " id>=0   and   yydh='" + yydh + "'  and  lsbh='" + lsbh + "'  and   main_sec='" + common_app.main_sec_main + "' ");
                if (ds000 != null && ds000.Tables[0].Rows.Count > 0)
                {
                    hykh = ds000.Tables[0].Rows[0]["hykh_bz"].ToString();
                    phoneNo = ds000.Tables[0].Rows[0]["krsj"].ToString();
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
            //先从当前的Szw_temp中查询到当前的lsbh,czy查询出的记录
            ds_temp = B_szw_temp.GetList("id>0  " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'  and czy_temp='" + czy_guid + "'");
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0) //有消费记录
            {
                //更新Szw_temp里面的对应记录的jzbh
                StringBuilder sb = new StringBuilder();
                sb.Append("update Szw_temp  set  jzbh='" + jzbh + "'  where id>0  " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'  and czy_temp='" + czy_guid + "'");
                if (B_common.ExecuteSql(sb.ToString()) > 0)//修改成功
                {
                    ds_temp = B_szw_temp.GetList("id>0  " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'  and czy_temp='" + czy_guid + "'");
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
                    fkje = Math.Abs(fkje_temp).ToString();//最终的付款金额(用绝对值存储)

                    //xfje
                    xfje = xfje_temp.ToString();


                    //帐务操作处理
                    if (Pladd(lsbh, sktt, jzbh, xydw, krly, yydh, czsj, syzd, czy, czy_bc, czzt, jzzt, cznr, bz, fkje, xfje, this.xxzs,hykh,xfje,phoneNo,czy_guid) == common_app.get_suc)
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
            }
            else   //没有消费记录（空结)
            {
                if (Pladd(lsbh, sktt, jzbh, xydw, krly, yydh, czsj, syzd, czy, czy_bc, czzt, jzzt, cznr, bz, "0", "0", this.xxzs, hykh, xfje, phoneNo, czy_guid) == common_app.get_suc)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            return s;
        }

        //平帐时用到的方法
        public string Sjzmx_pz(string id, string yydh, string qymc, string id_app, string jzbh, string lsbh, string krxm, string fjrb, string fjbh, string sktt,
    string xfrq, string xfsj, string czy, string xfdr, string xfrb, string xfxm, string xfbz, string xfzy, string xfje, string yh, string sjxfje, string xfsl,
    string czy_bc, string czzt, string czsj, string syzd, string add_edit_delete, string xxzs, string fkfs)
        {
            string s = common_file.common_app.get_failure;
            string xyh_temp = "";
            string jzzt = "";

            BLL.Sjzmx B_Sjzmx = new Hotel_app.BLL.Sjzmx();
            Model.Sjzmx M_Sjzmx = new Hotel_app.Model.Sjzmx();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                //id,yydh,qymc,id_app,jzbh,,lsbh,krxm,fjrb,fjbh,sktt,
                //xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy
                //xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,fkfs,add,xxzs,fkfs
                M_Sjzmx.yydh = yydh;
                M_Sjzmx.qymc = qymc;
                M_Sjzmx.id_app = id_app;
                M_Sjzmx.jzbh = jzbh;
                M_Sjzmx.lsbh = lsbh;
                M_Sjzmx.krxm = krxm;
                M_Sjzmx.fjrb = fjrb;
                M_Sjzmx.fjbh = fjbh;
                M_Sjzmx.sktt = sktt;

                M_Sjzmx.xfrq = Convert.ToDateTime(xfrq);
                M_Sjzmx.xfsj = Convert.ToDateTime(xfsj);
                M_Sjzmx.czy = czy;
                M_Sjzmx.xfdr = xfdr;
                M_Sjzmx.xfrb = xfrb;
                M_Sjzmx.xfxm = xfxm;
                M_Sjzmx.xfbz = xfbz;
                M_Sjzmx.xfzy = xfzy;

                M_Sjzmx.xfje = Convert.ToDecimal(xfje);
                M_Sjzmx.yh = yh;
                M_Sjzmx.sjxfje = Convert.ToDecimal(sjxfje);
                M_Sjzmx.xfsl = Convert.ToDecimal(xfsl);
                M_Sjzmx.czy_bc = czy_bc;
                M_Sjzmx.czzt = czzt;
                M_Sjzmx.czsj = Convert.ToDateTime(czsj);
                M_Sjzmx.syzd = syzd;
                M_Sjzmx.fkfs = fkfs;
                if (czzt == common_jzzt.czzt_sz)//结帐(结帐是直接从主单里面读）
                {
                    if (sktt == "sk")
                    {
                        M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>0  and  yydh='" + yydh + "' and  lsbh='" + lsbh + "'")[0];
                        xyh_temp = M_Qskyd_mainrecord.xyh;//直接读出协议号
                        jzzt = M_Qskyd_mainrecord.krxm;
                    }
                    if (sktt == "tt")
                    {
                        {
                            M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("id>0  and  yydh='" + yydh + "' and  lsbh='" + lsbh + "'")[0];
                            xyh_temp = M_Qttyd_mainrecord.xyh;//直接读出协议号
                            jzzt = M_Qttyd_mainrecord.krxm;
                        }
                    }
                }
                else if(czzt==common_jzzt.czzt_gz||czzt==common_jzzt.czzt_jz)
                {
                    object obj = DbHelperSQL.GetSingle("SELECT  xyh  from  Sjzzd where  id>0  and  yydh='" + yydh + "'  and  jzbh='" + jzbh + "'");
                    if (obj != null)
                    {
                        xyh_temp = obj.ToString();
                    }
                    else
                    {
                        xyh_temp = "";
                    }
                    obj = DbHelperSQL.GetSingle("SELECT  jzzt from Sjzzd where  id>0  and  yydh='" + yydh + "'  and  jzbh='" + jzbh + "'");
                    if (obj != null)
                    {
                        jzzt = obj.ToString();
                    }
                    else
                    {
                        jzzt = "";
                    }
                }
                M_Sjzmx.xyh = xyh_temp;
                M_Sjzmx.jzzt = jzzt;

                if (B_Sjzmx.Add(M_Sjzmx) > 0)
                {
                    if (czzt == common_jzzt.czzt_gz || czzt == common_jzzt.czzt_jz)//写入付款方式设置
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into Sfkfssz(yydh,qymc,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,fkrq,fksj,xfrq,xfsj,czy,czy_bc,syzd,id_app)");
                        strSql.Append(" select yydh,qymc,jzbh,'" + jzzt + "',lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,-xfje,-sjxfje,xfrq,xfsj,xfrq,xfsj,czy,'" + czy_bc + "','" + syzd + "',id_app   from  sjzmx");
                        strSql.Append(" where   yydh='"+yydh+"'  and  id_app='"+id_app+"'");
                        B_common.ExecuteSql(strSql.ToString());
                    }
                    s = common_file.common_app.get_suc;
                }
            }
            if (add_edit_delete == common_file.common_app.get_delete)
            {
                if (id != "")
                {
                    B_Sjzmx.Delete(Convert.ToInt32(id));
                    s = common_file.common_app.get_suc;
                }
            }
            return s;
        }


        /// 记、挂、结帐时的帐务处理
        /// 
        /// </summary>
        /// 先写入Sjzzd，同时写sjzmx,Ffkfssz
        /// 写入成功后，将zwmx里面的对应的记录写入到zwmx_bak,并删除当前lsbh对应下的zwmx记录(jzzt 结帐主体  ,czzt  记帐，结帐，挂帐)
        public string Pladd(string lsbh, string sk_tt, string jzbh, string xydw, string krly, string yydh, string czsj, string syzd, string czy, string czy_bc, string czzt, string jzzt, string cznr, string bz, string fkje, string xfje, string xxzs, string hykh, string xfje_send, string phoneNo, string czy_GUID)
        {
            string s = common_app.get_failure;
            decimal fkje_temp = decimal.Parse(fkje);
            decimal xfje_temp = decimal.Parse(xfje);
            string xyh = common_zw.GetxyhByxydw(xydw, yydh);
            if (fkje_temp == 0 && xfje_temp == 0)//空结的
            {
                strSql.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje)");
                if (sk_tt == "sk")
                {
                    strSql.Append(" select top 1 yydh,qymc,'" + lsbh + "','"+jzbh+"',krxm,sktt,fjbh,'" + xyh + "','" + xydw + "','" + krly + "','" + DateTime.Now + "','" + czsj + "','" + czy + "','" + czzt + "','" + jzzt + "','" + syzd + "','" + bz + "'," + fkje_temp + "," + xfje_temp + " from Qskyd_fjrb");
                }
                if (sk_tt == "tt")//团体的时候，房间编号为空
                {
                    strSql.Append("select top 1 yydh,qymc,'" + lsbh + "','"+jzbh+"',krxm,sktt,'','" + xyh + "','" + xydw + "','" + krly + "','" + DateTime.Now + "','" + czsj + "','" + czy + "','" + czzt + "','" + jzzt + "','" + syzd + "','" + bz + "'," + fkje_temp + "," + xfje_temp + " from Qttyd_mainrecord");
                }
                strSql.Append(" where lsbh='" + lsbh + "'");
                B_common.ExecuteSql(strSql.ToString());
            }
            else if(fkje_temp!=0||xfje_temp!=0)
            {
                //注意jzzd只写入一次(公共信息查一次就好)
                strSql.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje)");
                strSql.Append(" select top 1 yydh,qymc,'" + lsbh + "',jzbh,krxm,sktt,fjbh,'" + xyh + "','" + xydw + "','" + krly + "','" + DateTime.Now + "','" + czsj + "','" + czy + "','" + czzt + "','" + jzzt + "','" + syzd + "','" + bz + "'," + fkje_temp + "," + xfje_temp + " from Szw_temp");
                strSql.Append(" where lsbh='" + lsbh + "' and  czy_temp='" + czy_GUID + "'");
                BLL.Common B_common = new Hotel_app.BLL.Common();
                if (B_common.ExecuteSql(strSql.ToString()) > 0)//
                {
                    //修改Sjzmx 表里面的dj_pzsk项(平帐收款是直接写入Sjzmx里面的)
                    strSql = new StringBuilder();
                    strSql.Append(" update  Sjzmx  set   jzbh='" + jzbh + "',jzzt='" + jzzt + "'  where xfxm='" + common_app.dj_pzsk + "'");
                    B_common.ExecuteSql(strSql.ToString());

                    strSql = new StringBuilder();
                    strSql.Append("insert into Sjzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs ) ");
                    strSql.Append(" select yydh,qymc,id_app,jzbh,'" + lsbh + "',krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,'" + czy_bc + "','" + czzt + "','" + czsj + "','" + syzd + "','" + xyh + "','" + jzzt + "',fkfs  from Szw_temp");
                    strSql.Append(" where lsbh='" + lsbh + "' and  czy_temp='" + czy_GUID + "'  and  xfxm!='" + common_app.dj_pzsk + "'");
                    if (B_common.ExecuteSql(strSql.ToString()) >= 0)//写入jzmx成功后,
                    {
                        //提取fkdr为付款的项目写入Ffkfssz
                        strSql = new StringBuilder();
                        strSql.Append("insert into Sfkfssz(yydh,qymc,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,fkrq,fksj,xfrq,xfsj,czy,czy_bc,syzd,id_app)");
                        strSql.Append(" select yydh,qymc,jzbh,'" + jzzt + "',lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,-xfje,-sjxfje,xfrq,xfsj,xfrq,xfsj,czy,'" + czy_bc + "','" + syzd + "',id_app   from  Szw_temp");
                        strSql.Append(" where lsbh='" + lsbh + "'  and czy_temp='" + czy_GUID + "'  and  xfdr='" + common_app.fkdr + "'");
                        B_common.ExecuteSql(strSql.ToString());//写入sfkfssz表里面
                        //更新平帐收款时的付款方式设置内容(注意：记帐，挂帐没有平帐收款,这里一定要判断)
                        object fkfs_temp = DbHelperSQL.GetSingle("select fkfs  from Sjzmx where  jzbh='" + jzbh + "' and lsbh='" + lsbh + "' and xfxm='" + common_app.dj_pzsk + "'");
                        if (fkfs_temp != null)
                        {
                            B_common.ExecuteSql("update  Sfkfssz  set  fkfs='" + fkfs_temp.ToString() + "'  where  jzbh='" + jzbh + "' and lsbh='" + lsbh + "' and xfxm='" + common_app.dj_pzsk + "'");
                        }

                        //更新zwmx里面此lsbh对应的帐务的结帐编号
                        strSql = new StringBuilder();
                        strSql.Append("update  Szwmx  set  jzbh='" + jzbh + "'  where id>0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh + "'");
                        if (B_common.ExecuteSql(strSql.ToString()) >= 0)//更新成功
                        {
                            strSql = new StringBuilder();
                            strSql.Append("update Syjcz  set jzbh='" + jzbh + "'  where id>0 " + common_app.yydh_select + "  and  lsbh='" + lsbh + "'");
                            B_common.ExecuteSql(strSql.ToString());//押金更新成功(注意，不一定有押金)
                        }
                    }
                }
            }
            if (GetJzResult(lsbh, jzbh, czzt, sk_tt, czy, czsj, hykh, xfje_send,phoneNo,yydh) == common_app.get_suc)
                s = common_app.get_suc;

            return s;
        }


        //结帐,记帐,挂帐处理过程 
        public string GetJzResult(string lsbh, string jzbh, string czzt, string sk_tt, string czy, string czsj,string hykh,string xfje,string phoneNo,string yydh)
        {
            string s = common_app.get_failure;
            //记帐，挂帐，结帐的处理节
            if (czzt == common_file.common_jzzt.czzt_sz)//算帐
            {
                strSql = new StringBuilder();
                strSql.Append("delete from Syjcz where id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'");
                B_common.ExecuteSql(strSql.ToString());
                strSql = new StringBuilder();
                strSql.Append("delete from Szwmx  where id>0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh + "'");
                B_common.ExecuteSql(strSql.ToString());
            }
            //更新Ssyxfmx里的Jzbh
            B_common.ExecuteSql("update  Ssyxfmx  set  jzbh='" + jzbh + "'   where   lsbh='" + lsbh + "'");
            if (czzt == common_jzzt.czzt_gz || czzt == common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_sz)
            {
                //清除Szw_temp
                strSql = new StringBuilder();
                strSql.Append("delete from Szw_temp  where  id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'");
                if (B_common.ExecuteSql(strSql.ToString()) >= 0) //清除Szw_temp里面的数据了
                {
                    //调用修改房态的方法(第五步)
                    if (sk_tt == "sk")
                    {
                        M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'")[0];
                        id = M_Qskyd_mainrecord.id.ToString();

                        //删除主单记录（这里有包含主单记录删除时的备份）
                        if (Qyddj_add_edit_delete_new.delete_sz_xgft(id, "jz", common_file.common_jzzt.czzt_sz, "", jzbh, czy, czsj, xxzs) == common_app.get_suc)
                        {
                            s = common_app.get_suc;
                        }
                    }
                    else//是团体
                    {
                        M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("ID>0 " + common_app.yydh_select + "  AND lsbh='" + lsbh + "'")[0];
                        string tt_id = M_Qttyd_mainrecord.id.ToString();
                        //要成批更新团体所有成员的房态，并删除成员主单
                        string ddbh_temp = M_Qttyd_mainrecord.ddbh;

                        if (Qttyd_add_edit_delete_new.delete_sz_ttyd(tt_id, "jz", common_file.common_jzzt.czzt_sz, "", jzbh, czy, czsj, xxzs) == common_file.common_app.get_suc)
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                    //结帐成功后,更新会员的积分(挂-结，记-结，部分结，结帐都要加积分
                    //会员卡号,当前记录的lsbh，
                    if ((czzt == common_jzzt.czzt_sz) || (czzt == common_jzzt.czzt_jz) || (czzt == common_jzzt.czzt_gz) || (czzt == common_jzzt.czzt_bfsz))
                    {
                        string zjf = "0"; bool shsj = false;string hyrx_now="";//银卡
                        string dfjf="0";
                       string lsbh_df = common_file.common_ddbh.ddbh("df", "lsbhdfdate", "lsbhdfcounter", 6);
                       string qymc = "";
                       if (!yydh.Equals(""))
                       {
                           DataSet ds000 = B_common.GetList("  select   *  from Xqyxx  ", " id>=0   and   yydh='" + yydh + "'  ");
                           if (ds000 != null && ds000.Tables[0].Rows.Count > 0)
                           {
                               qymc = ds000.Tables[0].Rows[0]["qymc"].ToString();
                           }
                       }
                        IncHYScore(jzbh,lsbh, sk_tt,hykh,xfje,ref zjf,ref shsj);
                        //发送会员消费短信
                        Hhygl.Hhygl_verifyCode Hhygl_verifyCode_new = new Hotel_app.Server.Hhygl.Hhygl_verifyCode();
                        Hhygl_verifyCode_new.Hhygl_SendMsm(phoneNo, zjf, yydh, qymc, common_hyAction.hy_Action_hytf, czsj, "", "", "", hykh, xfje, xxzs);

                        BLL.Hhygl   B_Hhygl_new=new Hotel_app.BLL.Hhygl();
                        DataSet  ds111=B_Hhygl_new.GetList("  hykh_bz='"+hykh+"'  and id>=0  and  hykh_bz!='' ");
                        if(ds111!=null&&ds111.Tables[0].Rows.Count>0)
                        {
                            hyrx_now=ds111.Tables[0].Rows[0]["hykh_bz"].ToString();
                        }


                        //升级需要的积分数
                         BLL.Hhyjb   B_Hhyjb_new=new Hotel_app.BLL.Hhyjb();
                        DataSet  ds222=B_Hhyjb_new.GetList("  hyrx='"+common_app.hykh_rx+"'  and id>=0  and  qymc='"+qymc+"' ");
                        if(ds222!=null&&ds222.Tables[0].Rows.Count>0)
                        {
                            dfjf=ds222.Tables[0].Rows[0]["hykh_bz"].ToString();
                        }


                        if(!hyrx_now.Equals("")&&hyrx_now.Equals(common_app.hykh_rx))
                        {

                        //发送短信(判断当前的会员类型),是银卡才自动升级
                        if (shsj)//自动发送升级短信
                        {
                            Hhygl_verifyCode_new.Hhygl_SendMsm(phoneNo, zjf, yydh, qymc, common_hyAction.hy_Action_hytf, czsj, "", "", "", hykh, xfje, xxzs);
                            //调用升级会员的方法，扣除升级积分
                            Hhygl.Hhyjf_df Hhyjf_dr_new = new Hotel_app.Server.Hhygl.Hhyjf_df();
                            Hhyjf_dr_new.Hhyjfdf_add_edit("", yydh, qymc, "", hykh, "", dfjf, "升级金卡", "1", lsbh_df, hykh, common_app.chinese_add, xxzs);
                        }
                        }
                    }
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
        private void IncHYScore(string jzbh, string lsbh, string sk_tt, string hykh, string xfje,ref string  zjf,ref bool   shsj)
        {
            if (String.IsNullOrEmpty(jzbh) || String.IsNullOrEmpty(lsbh) || String.IsNullOrEmpty(sk_tt) || String.IsNullOrEmpty(hykh) )
                return;
            else
            {
                if (sk_tt == "sk"&&!hykh.Trim().Equals(""))// 是会员
                {
                    //发送退房短信，并自动升级会员信息
                    string proName = "GetHyJifenByHykh";
                    SqlParameter[] parms = new SqlParameter[9];
                   parms[0] = new SqlParameter("@qymc", SqlDbType.VarChar, 50);
                   parms[1] = new SqlParameter("@yydh", SqlDbType.VarChar, 50);
                   parms[2] = new SqlParameter("@hykh", SqlDbType.VarChar, 100);
                   parms[3] = new SqlParameter("@sjjfs", SqlDbType.Decimal);
                   parms[4] = new SqlParameter("@JifenTotalYe", SqlDbType.Decimal);
                   parms[5] = new SqlParameter("@shsj", SqlDbType.Bit);
                   parms[4].Direction=ParameterDirection.Output;
                   parms[5].Direction = ParameterDirection.Output;
                   DbHelperSQL.RunProcedure(proName, parms);
                   zjf = parms[4].ToString();
                   shsj = bool.Parse(parms[5].ToString());
                }
            }
        }
    }
}
