using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Hotel_app.Qyddj;

namespace Hotel_app.Server.Qyddj
{
    public class Qskyd_fjrb_add_edd_delete_1
    {
        Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edit_delete();
        Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Qyddj_add_edit_delete();
        Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Model.Qskyd_mainrecord();
        BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new BLL.Qskyd_mainrecord();

        //通过原来的主单信息来新增一条另外的主单，返回真假（mainRecord)
        //lsbh为原来的主单的
        //lsbh_news为新生成的那条的


        //通过房间类型得到房间价格
        //private decimal Get_JGByFjrb(string fjrb)
        //{
        //    decimal fjjg = 0;
        //    BLL.Ffjrb B_Ffjrb = new Hotel_app.BLL.Ffjrb();
        //    Model.Ffjrb M_Ffjrb = new Hotel_app.Model.Ffjrb();
        //    if (B_Ffjrb.GetModelList("fjrb='" + fjrb + "'")[0].sjjg != null)
        //    {
        //        return B_Ffjrb.GetModelList("fjrb='" + fjrb + "'")[0].sjjg;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //得到fjrb,lsbh,lzfs=1&&fjbh=""时的Qskyd_fjrb的模
        private Model.Qskyd_fjrb GetModel(string fjrb, string lsbh)
        {
            BLL.Qskyd_fjrb B_Qsky_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            if (B_Qsky_fjrb.GetModelList("lsbh='" + lsbh + "'  and fjrb='" + fjrb + "'").Count > 0)
            {
                return B_Qsky_fjrb.GetModelList("lsbh='" + lsbh + "'  and fjrb='" + fjrb + "'")[0];
            }
            else
            {
                return null;
            }

        }

        //添加到联房，先查询当前的lsbh有没有在flfsz表里，1.如果有读取lfbh就直接增加。2.如果没有就加新的记录把当前lsbh加进去
        //private string Flfsz_Add(string lsbh, string qymc, string lsbh_new, string yydh, string fjbh, string krxm, string sktt, string yddj, string czy, string lfbh_News)
        //{

        //    string s = common_file.common_app.get_failure;
        //    BLL.Flfsz B_flfsz = new Hotel_app.BLL.Flfsz();
        //    Model.Flfsz M_flfsz = new Hotel_app.Model.Flfsz();
        //    //生成新的联房编号
        //    M_flfsz.yydh = yydh;
        //    M_flfsz.qymc = qymc;
        //    M_flfsz.lfbh = lfbh_News;
        //    M_flfsz.lsbh = lsbh_new;
        //    M_flfsz.fjbh = fjbh;
        //    M_flfsz.krxm = krxm;
        //    M_flfsz.sktt = sktt;
        //    M_flfsz.yddj = yddj;
        //    M_flfsz.czy = czy;
        //    M_flfsz.czsj = DateTime.Now;
        //    M_flfsz.is_top = false;
        //    M_flfsz.is_select = false;
        //    if (B_flfsz.Add(M_flfsz) > 0)  //新增的那条加到联房表
        //    {
        //        s = common_file.common_app.get_suc;

        //    }
        //    return s;

        //}
        //查询当前的lsbh是否有加到联房表里面,有，就直接新增，没有就增加一条新，并把当前的lsbh加进去
        private bool lf_GetResult(string lsbh, string qymc, string lsbh_new, string yydh, string fjbh, string krxm, string sktt, string yddj, string czy,DateTime czsj, string xxzs)
        {
            bool result = false;
            BLL.Flfsz B_Flfsz = new Hotel_app.BLL.Flfsz();
            Model.Flfsz M_Flfsz = new Hotel_app.Model.Flfsz();
            Ffjzt.Flfsz_add_edit Flfsz_add_edit_new = new Hotel_app.Server.Ffjzt.Flfsz_add_edit();
            string lfbh_News = "";
            if (B_Flfsz.GetModelList("lsbh='" + lsbh + "'").Count > 0) //存在,直接把新记录加到里面去
            {
                lfbh_News = B_Flfsz.GetModelList("lsbh='" + lsbh + "'")[0].lfbh;
                if (Flfsz_add_edit_new.Flfsz_add_edit_delete("", yydh, qymc, lfbh_News, lsbh_new, fjbh, krxm, sktt, yddj, czy, czsj.ToString(), common_file.common_app.shlz, common_file.common_app.get_add, xxzs) == common_file.common_app.get_suc)
                {
                    result = true;
                }


            }
            else  //如果以前没有(就生成新的临时编号，并把两个都加进去）
            {

                lfbh_News = common_file.common_ddbh.ddbh("lf", "lfdate", "lfcounter", 6); //生成新的联房编号
                if (Flfsz_add_edit_new.Flfsz_add_edit_delete("", yydh, qymc, lfbh_News, lsbh_new, fjbh, krxm, sktt, yddj, czy, czsj.ToString(), common_file.common_app.shlz, common_file.common_app.get_add, xxzs) == common_file.common_app.get_suc)
                {
                    BLL.Common B_Common = new Hotel_app.BLL.Common();
                    DataSet ds_temp = B_Common.GetList("select * from Qskyd_fjrb","lsbh='"+lsbh+"'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {

                        if (Flfsz_add_edit_new.Flfsz_add_edit_delete("", yydh, qymc, lfbh_News, lsbh, ds_temp.Tables[0].Rows[0]["fjbh"].ToString(), ds_temp.Tables[0].Rows[0]["krxm"].ToString(), ds_temp.Tables[0].Rows[0]["sktt"].ToString(), ds_temp.Tables[0].Rows[0]["yddj"].ToString(), ds_temp.Tables[0].Rows[0]["czy"].ToString(), czsj.ToString(), common_file.common_app.shlz, common_file.common_app.get_add, xxzs) == common_file.common_app.get_suc)
                        {
                            result = true;
                        }
                    }
                    else
                    { result = true; }

                    ds_temp.Dispose();

                }

            }
            return result;
        }
        public string Qskyd_fjrb_add_edit_delete_app_1(string id, string yydh, string qymc, string lsbh, string krxm, string sktt, string yddj, string fjrb, string fjbh, DateTime ddsj, DateTime lksj, Decimal lzfs, string shqh, decimal fjjg, decimal sjfjjg, string yh, decimal yhbl, string bz, string czy, DateTime czsj, 
            string cznr, string zyzt, string add_edit_delete, string xxzs,string fjbm,decimal jcje)
        {
            string s = common_file.common_app.get_failure;
            BLL.Qskyd_fjrb B_temp = new Hotel_app.BLL.Qskyd_fjrb();
            Model.Qskyd_fjrb M_Qskyd_fjrb = new Hotel_app.Model.Qskyd_fjrb();
            Ffjzt.Flfsz_add_edit Flfsz_add_edit_new = new Hotel_app.Server.Ffjzt.Flfsz_add_edit();
            BLL.Common B_Common=new Hotel_app.BLL.Common();
            DataSet ds = new DataSet();
            int id_temp = 0; int id_temp2 = 0;
            int j_temp = 1;
            string lsbh_News = "";
            string ddbh_News = "";
            string lfbh_News = ""; int i_1 = 0;
            string old_fjbh = "";
            BLL.Flfsz B_flfsz = new Hotel_app.BLL.Flfsz();
            Model.Flfsz M_flfsz = new Hotel_app.Model.Flfsz();
            //if (sktt == common_file.common_sktt.sktt_sk || sktt == common_file.common_sktt.sktt_cz)
            {
                #region 预订新增房间类型
                //1.新增有房号的主单
                //2.修改新增主单里的房类信息把fjbh加进去并把lzfs设为1.
                //3.设置联房，要先去查看原来的临时编号有没有存在联房，有就不再重新生成联房编号，直接修改。
                //4.修改fjrb表，把没有房号的LZFS扣除1同时加到联房里，再修改现有主单里的房类信息

                if (add_edit_delete == common_file.common_app.get_add)
                {
                    if (yddj == common_file.common_yddj.yddj_yd)
                    {
                        if (lzfs > 1 && fjbh != "")
                        {
                            //新增客人主单
                            ds = B_Qskyd_mainrecord.GetList("lsbh='" + lsbh + "'");
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()));

                                lsbh_News = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                                ddbh_News = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                                s = common_file_server.Common_pl_Qskyd_mainRecord_add.Pladd(yydh, qymc, lsbh, lsbh_News, ddbh_News, czy, czsj.ToString(), "", "");//根据lsbh读起主单信息，添加一条有房号的记录。

                                if (s == common_file.common_app.get_suc)
                                {
                                    s = common_file.common_app.get_failure;
                                    //修改新增主单里的房类信息把fjbh加进去并把lzfs设为1.

                                    ds = B_temp.GetList("lsbh='" + lsbh_News + "'");
                                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                                    {
                                        Model.Qskyd_fjrb M_temp = B_temp.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["id"]));
                                        M_temp.fjbh = fjbh;
                                        M_temp.fjrb = fjrb;
                                        M_temp.fjjg = fjjg;
                                        M_temp.sjfjjg = sjfjjg;
                                        M_temp.yh = yh;
                                        M_temp.yhbl = yhbl;
                                        M_temp.shqh = shqh;
                                        M_temp.bz = bz;
                                        M_temp.lzfs = 1;
                                        M_temp.fjbm = fjbm;
                                        M_temp.jcje = jcje;
                                        if (B_temp.Update(M_temp))
                                        {




                                            Qskyd_fjrb_add_edit_delete_new.add_fjbh_yd_fjzt(M_temp.lsbh, M_temp.fjbh, M_temp.sktt, czsj, czy, xxzs);




                                            #region 当前主单以前没有联房过()
                                            if (B_flfsz.GetModelList("lsbh='" + lsbh + "'").Count == 0)
                                            {
                                                //生成新的联房编号
                                                lfbh_News = common_file.common_ddbh.ddbh("lf", "lfdate", "lfcounter", 6);

                                                s = Flfsz_add_edit_new.Flfsz_add_edit_delete("", yydh, qymc, lfbh_News, lsbh_News, fjbh, krxm, sktt, yddj, czy, czsj.ToString(), common_file.common_app.shlz, common_file.common_app.get_add, xxzs);
                                                
                                                
                                                if (s == common_file.common_app.get_suc)
                                                {

                                                    //主单增加到联房，增加新的一条无房号的记录到fjrb表
                                                    lzfs = lzfs - 1;
                                                    if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id.ToString(), yydh, qymc, lsbh, krxm, sktt, yddj, fjrb, "", ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh , yhbl, bz, czy, DateTime.Now, cznr,  zyzt, common_file.common_app.get_add, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                                    {
                                                        //新增临时编号到联房里面

                                                        string fjbh_0 = "";
                                                        DataSet DS_temp = B_Common.GetList("select fjbh from Qskyd_fjrb","lsbh='"+lsbh+"' and fjbh<>''") ;
                                                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                                                        {
                                                            fjbh_0 = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                                                        }

                                                        s = Flfsz_add_edit_new.Flfsz_add_edit_delete("", yydh, qymc, lfbh_News, lsbh, fjbh_0, krxm, sktt, yddj, czy, czsj.ToString(), common_file.common_app.shlz, common_file.common_app.get_add, xxzs);


                                                        //M_flfsz.yydh = yydh;
                                                        //M_flfsz.qymc = qymc;
                                                        //M_flfsz.lsbh = lsbh;
                                                        //M_flfsz.fjbh = "";
                                                        //M_flfsz.lfbh = lfbh_News;
                                                        //M_flfsz.krxm = krxm;
                                                        //M_flfsz.sktt = sktt;
                                                        //M_flfsz.yddj = yddj;
                                                        //M_flfsz.czy = czy;
                                                        //M_flfsz.czsj = czsj;
                                                        //if (B_flfsz.Add(M_flfsz) > 0)
                                                        //{
                                                        //    s = common_file.common_app.get_suc;
                                                        //}
                                                        //else
                                                        //{
                                                        //    return s;
                                                        //}



                                                    }
                                                    else
                                                    {
                                                        return s;
                                                    }
                                                }
                                                else
                                                {
                                                    return s;
                                                }
                                            }
                                            #endregion

                                            #region 当前主单有联房过
                                            else
                                            {
                                                //直接把新增的一条加到联房表，fjbh不存在的一条不管
                                                lfbh_News = B_flfsz.GetModelList("lsbh='" + lsbh + "'")[0].lfbh;

                                                s = Flfsz_add_edit_new.Flfsz_add_edit_delete("", yydh, qymc, lfbh_News, lsbh_News, fjbh, krxm, sktt, yddj, czy, czsj.ToString(), common_file.common_app.shlz, common_file.common_app.get_add, xxzs);
                                                if (s == common_file.common_app.get_suc)
                                                {
                                                    //主单增加到联房，增加新的一条无房号的记录到fjrb表
                                                    lzfs = lzfs - 1;
                                                    if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id.ToString(), yydh, qymc, lsbh, krxm, sktt, yddj, fjrb, "", ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh , yhbl, bz, czy, DateTime.Now, cznr, zyzt, common_file.common_app.get_add, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                                    {
                                                        s = common_file.common_app.get_suc;
                                                    }
                                                    else
                                                    {
                                                        return s;
                                                    }
                                                }
                                                else
                                                {
                                                    return s;
                                                }
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            return s;
                                        }
                                    }
                                }
                                else
                                {
                                    return s;
                                }
                            }
                        }//if (lzfs > 1 && fjbh != "")
                        else
                        {

                            j_temp = 1;
                            //如果原来已经有等一条已经排房的记录，新的（增加修改记录）房型一样且如果仍为1时的情况
                            if (B_temp.GetModelList("lsbh='" + lsbh + "' and fjrb='" + fjrb + "' and fjbh<>'' ").Count > 0)
                            {
                                j_temp = 3;

                            }
                            if (j_temp != 3)
                            {
                                //如果原来已经有等一条已经排房的记录，新的（增加修改记录）房型如果不一样且如果仍为1时的情况
                                #region 判断当前的临时编号对应的lzfs是否为1，并在fjrb表有多条记录的时候
                                if (B_temp.GetModelList("lsbh='" + lsbh + "' and fjrb<>'" + fjrb + "' and fjrb<>'' ").Count > 0)
                                {
                                    j_temp = 3;
                                }
                                #endregion

                                #region 只有一条记录的时候,直接修改fjrb,并加到联房表
                                else
                                {

                                    if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id.ToString(), yydh, qymc, lsbh, krxm, sktt, yddj, fjrb, fjbh, ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh, yhbl, bz, czy, czsj, cznr,  zyzt, add_edit_delete, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                    {
                                        s = common_file.common_app.get_suc;
                                    }
                                    else
                                    {
                                        return s;
                                    }
                                }
                            }
                            if (j_temp == 3)//输入房数为1时的判断，且原来有记录的情况
                            {
                                if (fjbh != "")
                                {
                                    //找到当前房间类型为1，而且还没有排房号的那条记录
                                    //M_Qskyd_fjrb = B_temp.GetModelList("lsbh='" + lsbh + "' and  fjrb='" + fjrb + "'  and  lzfs=1  and fjbh=''")[0];
                                    //得到主单的信息：
                                    lsbh_News = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                                    ddbh_News = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                                    //通过当前的主单信息新增一条新的记录
                                    if (common_file_server.Common_pl_Qskyd_mainRecord_add.Pladd(yydh, qymc, lsbh, lsbh_News, ddbh_News, czy, czsj.ToString(), "", "") == common_file.common_app.get_suc)
                                    {
                                        #region //修改fjrb表里当前生成这条记录的房间信息
                                        id_temp2 = GetModel("", lsbh_News).id;
                                        if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id_temp2.ToString(), yydh, qymc, lsbh_News, krxm, sktt, yddj, fjrb, fjbh, ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh, yhbl, bz, czy, czsj, "自动新增", zyzt, common_file.common_app.get_edit, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                        {
                                            if (lf_GetResult(lsbh, qymc, lsbh_News, yydh, fjbh, krxm, sktt, yddj, czy,czsj,xxzs))
                                            {
                                                s = common_file.common_app.get_suc;
                                            }
                                        }
                                        #endregion

                                    }
                                }
                                else
                                {
                                    if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id.ToString(), yydh, qymc, lsbh, krxm, sktt, yddj, fjrb, fjbh, ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh, yhbl, bz, czy, czsj, cznr, zyzt, add_edit_delete, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                    {
                                        s = common_file.common_app.get_suc;
                                    }
                                    else
                                    {
                                        return s;
                                    }

                                }

                            }




                                #endregion
                        }
                    }

                }
                #endregion
                #region 预订修改房间类型
                else
                    if (add_edit_delete == common_file.common_app.get_edit)
                    {
                        if (yddj == common_file.common_yddj.yddj_yd)
                        {
                            #region  新增主单lzfs > 1 && fjbh != ""

                            if (lzfs > 1 && fjbh != "")
                            {
                                //新增主单
                                //修改新增主单里的房类信息
                                //设置联房，要先去查看原来的临时编号有没有存在联房，有就不再重新生成联房编号

                                //把没有房号的LZFS扣除1同里加到联房里，再修改现有主单里的房类信息

                                ds = B_Qskyd_mainrecord.GetList("lsbh='" + lsbh + "'");
                                if (ds != null && ds.Tables[0].Rows.Count > 0)
                                {
                                    M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()));

                                    lsbh_News = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                                    ddbh_News = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);

                                    s = common_file_server.Common_pl_Qskyd_mainRecord_add.Pladd(yydh, qymc, lsbh, lsbh_News, ddbh_News, czy, czsj.ToString(), "", "");

                                    if (s == common_file.common_app.get_suc)
                                    {
                                        s = common_file.common_app.get_failure;
                                        //修改新增主单里的房类信息把fjbh加进去
                                        ds = B_temp.GetList("lsbh='" + lsbh_News + "'");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //修改新增主单的Qskyd_fjrb表的fjbh并加到联房
                                            Model.Qskyd_fjrb M_temp = B_temp.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["id"]));
                                            M_temp.fjbh = fjbh;
                                            M_temp.fjrb = fjrb;
                                            M_temp.fjjg = fjjg;
                                            M_temp.sjfjjg = sjfjjg;
                                            M_temp.yh = yh;
                                            M_temp.yhbl = yhbl;
                                            M_temp.shqh = shqh;
                                            M_temp.bz = bz;
                                            M_temp.lzfs = 1;
                                            M_temp.fjbm = fjbm;
                                            M_temp.jcje = jcje;
                                            //M_temp.id=Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                                            #region //以前没有联房的处理节
                                            if (B_flfsz.GetModelList("lsbh='" + lsbh + "'").Count == 0) //以前没有联房
                                            {
                                                
                                                

                                                lfbh_News = common_file.common_ddbh.ddbh("lf", "lfdate", "lfcounter", 6); //

                                                s = Flfsz_add_edit_new.Flfsz_add_edit_delete("", yydh, qymc, lfbh_News, lsbh_News, fjbh, krxm, sktt, yddj, czy, czsj.ToString(), common_file.common_app.shlz, common_file.common_app.get_add, xxzs);



                                                //增加到联房,修改新增的主单fjrb表里的fjbh并把lzfs-1；并增加到联房)

                                                if (B_temp.Update(M_temp) && s == common_file.common_app.get_suc)
                                                {
                                                    
                                                    
                                                    
                                                    Qskyd_fjrb_add_edit_delete_new.add_fjbh_yd_fjzt(M_temp.lsbh, M_temp.fjbh, M_temp.sktt, czsj,  czy,  xxzs);





                                                    ds = B_temp.GetList("lsbh='" + lsbh + "'  and  fjrb='' and id='" + id.ToString() + "'");
                                                    i_1 = 5;
                                                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                                                    {
                                                        i_1 = 6;
                                                    }
                                                    else
                                                    {
                                                        i_1 = 5;
                                                        ds = B_temp.GetList("lsbh='" + lsbh + "'  and  fjrb<>''  and id='" + id.ToString() + "'");
                                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                                        {
                                                            if (ds.Tables[0].Rows[0]["fjrb"].ToString() == fjrb)
                                                            { i_1 = 5; }
                                                            else { i_1 = 7; }

                                                        }
                                                    }


                                                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                                                    {
                                                        id_temp = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                                                        M_Qskyd_fjrb = B_temp.GetModel(id_temp);
                                                    }

                                                    if (i_1 == 5 || i_1 == 6 || i_1 == 7)
                                                    {
                                                        M_Qskyd_fjrb.lzfs = lzfs - 1;
                                                        M_Qskyd_fjrb.czy = czy;
                                                        M_Qskyd_fjrb.czsj = DateTime.Now;
                                                        M_Qskyd_fjrb.cznr = common_file.common_app.get_edit;
                                                        if (i_1 == 6 || i_1 == 7)
                                                        {
                                                            M_Qskyd_fjrb.fjrb = fjrb;
                                                            if (i_1 == 6)
                                                            {
                                                                M_Qskyd_fjrb.shqh = shqh;
                                                                M_Qskyd_fjrb.fjjg = fjjg;//decimal.Parse(common_file.common_get_fjjg.get_fjjg(fjrb));
                                                                M_Qskyd_fjrb.sjfjjg = sjfjjg;
                                                                M_Qskyd_fjrb.yh = yh;
                                                                M_Qskyd_fjrb.yhbl = yhbl;
                                                                M_Qskyd_fjrb.bz = bz;
                                                                M_Qskyd_fjrb.fjbm = fjbm;
                                                                M_Qskyd_fjrb.bz = bz;
                                                            }
                                                        }
                                                    }
                                                    if (B_temp.Update(M_Qskyd_fjrb)) //无房间编号的房类主单也加到联房表里面
                                                    {
                                                        s = Flfsz_add_edit_new.Flfsz_add_edit_delete("", yydh, qymc, lfbh_News, lsbh, "", krxm, sktt, yddj, czy, czsj.ToString(), common_file.common_app.shlz, common_file.common_app.get_add, xxzs);
                                                    }
                                                    else
                                                    {
                                                        return s;
                                                    }
                                                }
                                                else
                                                {
                                                    return s;
                                                }
                                            }

                                            #endregion

                                            #region 以前有联房
                                            else
                                            {
                                                //读出联房信息
                                                lfbh_News = B_flfsz.GetModelList("lsbh='" + lsbh + "'")[0].lfbh;
                                                //将新增主单加到联房表里面  同时  修改新增的一条fjrb表里面的信息
                                                M_Qskyd_fjrb = B_temp.GetModelList("lsbh='" + lsbh_News + "'")[0];
                                                //相同信息
                                                M_Qskyd_fjrb.fjrb = fjrb;
                                                M_Qskyd_fjrb.fjbh = fjbh;
                                                M_Qskyd_fjrb.cznr = common_file.common_app.get_edit;
                                                M_Qskyd_fjrb.czsj = DateTime.Now;
                                                M_Qskyd_fjrb.lzfs = 1;
                                                M_Qskyd_fjrb.fjjg = fjjg;
                                                M_Qskyd_fjrb.yh = yh;
                                                M_Qskyd_fjrb.yhbl = yhbl;
                                                M_Qskyd_fjrb.shqh = shqh;
                                                M_Qskyd_fjrb.bz = bz;
                                                M_Qskyd_fjrb.fjbm = fjbm;
                                                M_Qskyd_fjrb.jcje = jcje;


                                                s = Flfsz_add_edit_new.Flfsz_add_edit_delete("", yydh, qymc, lfbh_News, lsbh_News, fjbh, krxm, sktt, yddj, czy, czsj.ToString(), common_file.common_app.shlz, common_file.common_app.get_add, xxzs);
                                                
                                                
                                               
                                                if (s == common_file.common_app.get_suc && B_temp.Update(M_Qskyd_fjrb))
                                                {

                                                    Qskyd_fjrb_add_edit_delete_new.add_fjbh_yd_fjzt(M_Qskyd_fjrb.lsbh, M_Qskyd_fjrb.fjbh, M_Qskyd_fjrb.sktt, czsj, czy, xxzs);


                                                    //修改原来的fjrb表的信息

                                                    //M_Qskyd_fjrb = B_temp.GetModelList("lsbh='" + lsbh + "' and fjrb='" + fjrb + "'")[0];

                                                    M_Qskyd_fjrb = B_temp.GetModel(int.Parse(id));
                                                    M_Qskyd_fjrb.id = int.Parse(id);
                                                    M_Qskyd_fjrb.lzfs = lzfs - 1;
                                                    M_Qskyd_fjrb.fjrb = fjrb;
                                                    M_Qskyd_fjrb.fjjg = fjjg;
                                                    M_Qskyd_fjrb.sjfjjg = sjfjjg;
                                                    M_Qskyd_fjrb.yh = yh;
                                                    M_Qskyd_fjrb.yhbl = yhbl;
                                                    M_Qskyd_fjrb.shqh = shqh;
                                                    M_Qskyd_fjrb.bz = bz;
                                                    M_Qskyd_fjrb.fjbm = fjbm;
                                                    M_Qskyd_fjrb.jcje = jcje;
                                                    if (B_temp.Update(M_Qskyd_fjrb))
                                                    {
                                                        s = common_file.common_app.get_suc;
                                                    }
                                                    else
                                                    {
                                                        return s;
                                                    }

                                                }
                                                else
                                                {
                                                    return s;
                                                }

                                            }
                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        return s;
                                    }
                                }
                            }
                            #endregion


                            else
                            {
                                #region 判断当前的临时编号对应的lzfs是否为1，并在fjrb表有多条记录的时候

                                DataSet DS_temp_1;
                                DS_temp_1 = B_temp.GetList("id='"+id+"'");
                                if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
                                { 
                                    old_fjbh=DS_temp_1.Tables[0].Rows[0]["fjbh"].ToString();
                                }
                                j_temp = 1;
                                //如果原来已经有等一条已经排房的记录，新的（增加修改记录）房型一样且如果仍为1时的情况
                                if (B_temp.GetModelList("lsbh='" + lsbh + "' and fjrb='" + fjrb + "' and fjbh<>'' ").Count > 0)
                                {
                                    
                                    j_temp = 3;
                                }
                                if (j_temp != 3)
                                {
                                    if (B_temp.GetModelList("lsbh='" + lsbh + "' and fjrb<>'" + fjrb + "' and fjrb<>'' ").Count > 0)
                                    {
                                        j_temp = 3;

                                        if (old_fjbh == "" && fjbh != "")
                                        {
                                            if (B_temp.GetModelList("lsbh='" + lsbh + "' and fjrb<>'" + fjrb + "' and fjrb<>'' and fjbh='' ").Count > 0)
                                            {
                                                j_temp = 1;
                                            }
                                        }


                                    }
                                #endregion
                                    #region 只有一条记录的时候,直接修改fjrb,并加到联房表
                                    else
                                    {
                                        if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id.ToString(), yydh, qymc, lsbh, krxm, sktt, yddj, fjrb, fjbh, ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh, yhbl, bz, czy, czsj, cznr, zyzt, add_edit_delete, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                        {
                                            s = common_file.common_app.get_suc;
                                        }
                                        else
                                        {
                                            return s;
                                        }
                                    }
                                    #endregion
                                }

                                if (old_fjbh != "")
                                { j_temp = 1; }
                                if (j_temp == 3)
                                {


                                    if (fjbh != "")
                                    {
                                        //找到当前房间类型为1，而且还没有排房号的那条记录
                                        //M_Qskyd_fjrb = B_temp.GetModelList("lsbh='" + lsbh + "' and  fjrb='" + fjrb + "'  and  lzfs=1  and fjbh=''")[0];
                                        //得到主单的信息：
                                        lsbh_News = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                                        ddbh_News = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                                        //通过当前的主单信息新增一条新的记录
                                        if (common_file_server.Common_pl_Qskyd_mainRecord_add.Pladd(yydh, qymc, lsbh, lsbh_News, ddbh_News, czy, czsj.ToString(), "", "") == common_file.common_app.get_suc)
                                        {
                                            #region //修改fjrb表里当前生成这条记录的房间信息
                                            id_temp2 = GetModel("", lsbh_News).id;
                                            if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id_temp2.ToString(), yydh, qymc, lsbh_News, krxm, sktt, yddj, fjrb, fjbh, ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh, yhbl, bz, czy, czsj, "自动新增", zyzt, common_file.common_app.get_edit, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                            {
                                                //修改成功后，把当前原来fjrb表里面对应的那条记录删除
                                                if (GetModel(fjrb, lsbh) != null)
                                                {
                                                    id_temp2 = int.Parse(id);
                                                    if (B_temp.Delete(id_temp2))
                                                    {
                                                        //删除对应记录成功后，把新生成的记录加到联房里
                                                        #region 判断当前的lsbh在不在在联房表里面，然后做相应处理
                                                        if (lf_GetResult(lsbh, qymc, lsbh_News, yydh, fjbh, krxm, sktt, yddj, czy, czsj,xxzs))
                                                        {
                                                            s = common_file.common_app.get_suc;
                                                        }
                                                        #endregion
                                                    }
                                                }
                                            }
                                            #endregion

                                        }
                                    }
                                    else
                                    {
                                        if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id.ToString(), yydh, qymc, lsbh, krxm, sktt, yddj, fjrb, fjbh, ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh, yhbl, bz, czy, czsj, cznr, zyzt, add_edit_delete, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                        {
                                            s = common_file.common_app.get_suc;
                                        }
                                        else
                                        {
                                            return s;
                                        }

                                    }


                                }
                                else
                                {
                                    if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id.ToString(), yydh, qymc, lsbh, krxm, sktt, yddj, fjrb, fjbh, ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh, yhbl, bz, czy, czsj, cznr, zyzt, add_edit_delete, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                    {
                                        s = common_file.common_app.get_suc;
                                    }
                                }

                            }
                        }//if (yddj == common_file.common_yddj.yddj_yd)
                        else
                            if (yddj == common_file.common_yddj.yddj_dj)
                            {
                                if (Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id.ToString(), yydh, qymc, lsbh, krxm, sktt, yddj, fjrb, fjbh, ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh, yhbl, bz, czy, czsj, cznr, zyzt, add_edit_delete, xxzs,fjbm,jcje) == common_file.common_app.get_suc)
                                {
                                    s = common_file.common_app.get_suc;
                                }
                                else
                                {
                                    return s;
                                }
                            }//if (yddj == common_file.common_yddj.yddj_dj)
                    }
                #endregion
                    #region hy类型的时候
                    else
                        if (sktt == common_file.common_sktt.sktt_tt || sktt == common_file.common_sktt.sktt_hy)
                        {
                            if (add_edit_delete == common_file.common_app.get_add)
                            {
                                if (yddj == common_file.common_yddj.yddj_yd)
                                {
                                    //1.新增主单
                                    //2.修改房类Qskyd_Fjrb表，把fjbh写进，lzfs设为1.
                                    //3.修改没有带房号的临时编号lzfs减1


                                }

                            }
                            else
                                if (add_edit_delete == common_file.common_app.get_edit)
                                {

                                }
                        }
                    #endregion
            }
            ds.Dispose();
            return s;
        }
    }
}


