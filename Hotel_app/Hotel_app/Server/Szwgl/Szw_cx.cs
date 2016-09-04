using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Collections;
using Maticsoft.DBUtility;

namespace Hotel_app.Server.Szwgl
{
    //此类处理帐务的撤销(记账撤销，挂帐撤销，算帐撤销等等

    //能否撤销，直接先在前台判断撤销是否符合条件，符合条件的才会执行此操作
    //对于散客，部分结帐的撤消要注意，未结部分是否存在，不存在，不能撤销（包括记账分结，账分结，算账分结)
    //对于记账，挂账，算账的撤销，要注意的是当前的房间是否被占用，没有才可以，否则不行


    //对于有分结过的记账或者挂账，是不能撤销的！
    //多次分结时要考虑到：平帐收款项要从Sfkfssz里面删除掉，同时要找到相应的jzbh对应的pzsk，将其设置成空

    //对于团体要判断每个房间的占用情况，有一间当前被占用就不能执行操作（但是要提示出来)
    public class Szw_cx
    {
        StringBuilder strsql;
        BLL.Flfsz_bak B_Flfsz_bak = new Hotel_app.BLL.Flfsz_bak();
        BLL.Qttyd_mainrecord_bak B_Qttyd_mainrecord_bak = new Hotel_app.BLL.Qttyd_mainrecord_bak();
        BLL.Qskyd_mainrecord_bak B_Qskyd_mainrecord_bak = new Hotel_app.BLL.Qskyd_mainrecord_bak();
        BLL.Qskyd_fjrb_bak B_Qskyd_fjrb_bak = new Hotel_app.BLL.Qskyd_fjrb_bak();
        BLL.Szwzd_bak B_Szwzd_bak = new Hotel_app.BLL.Szwzd_bak();
        BLL.Sjzzd_bak B_Sjzzd_bak = new Hotel_app.BLL.Sjzzd_bak();
        BLL.Sjzmx_bak B_Sjzmx_bak = new Hotel_app.BLL.Sjzmx_bak();
        BLL.Syjcz_bak B_Syjcz_bak = new Hotel_app.BLL.Syjcz_bak();
        BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        BLL.Common B_Common = new Hotel_app.BLL.Common();


        //撤销的思路按新增主单--修改fjrb--到修改fjzt--修改Szwzd--删除相应的备份来实现
        Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();
        Qyddj.Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edit_delete();

        public string Fun_zwcx(string lsbh, string jzbh, string sk_tt, string yydh, string qymc, string czzt, string czy, string syzd, string czsj, string xxzs,string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            Qyddj.Qydcx Qydcx_new = new Hotel_app.Server.Qyddj.Qydcx();
            if (czzt == common_file.common_jzzt.czzt_gz || czzt == common_file.common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_sz || czzt == common_file.common_jzzt.czzt_jzzgz || czzt == common_file.common_jzzt.czzt_gzzjz)
            {
                s = Qydcx_new.yd_bak_cx(yydh, qymc, jzbh, czy, DateTime.Parse(czsj), xxzs);//撤销Qyddj部分
            }
            if (s == common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_failure;
            }
            //进行账务撤销
            s = Fun_zw_cx_help(lsbh, czzt, jzbh, yydh, qymc, czy, syzd, czsj, xxzs, czy_GUID);
            common_file.common_czjl.add_czjl(yydh, qymc, czy, czzt + "撤销", "结账编号:" + jzbh, "账务撤销", DateTime.Parse(czsj));
            return s;
        }





        //根据条件对涉及到帐务表的操作(这个方法，主要是针对一个lsbh以及一个czzt，对涉及帐务的几张表的处理
        //lsbh_old，只是针对转帐的时候才会有用到，其它的操作状态留空,此时的Jzbh为Jzbh_old
        public string Fun_zw_cx_help(string lsbh, string czzt, string jzbh, string yydh, string qymc, string czy, string syzd, string czsj, string xxzs,string  czy_GUID)
        {
            string s = common_file.common_app.get_failure;

            #region 记帐，挂帐撤销
            if (czzt == common_file.common_jzzt.czzt_gz || czzt == common_file.common_jzzt.czzt_jzzgz || czzt == common_file.common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_gzzjz)
            {
                //删除jzzd
                strsql = new StringBuilder();
                strsql.Append(" delete from Sjzzd  where id>=0  and yydh='" + yydh + "' and lsbh='" + lsbh + "' and   jzbh='" + jzbh + "'  and czzt='" + czzt + "'");
                B_Common.ExecuteSql(strsql.ToString());

                //删除Sjzmx
                strsql = new StringBuilder();
                strsql.Append(" delete from Sjzmx where id>=0  and yydh='" + yydh + "'  and   jzbh='" + jzbh + "' ");
                B_Common.ExecuteSql(strsql.ToString());
                //strsql = new StringBuilder();
                //strsql.Append(" update  Sjzmx  set jzbh=''  where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and  jzbh='" + jzbh + "'   and  xfxm='" + common_file.common_app.dj_pzsk + "'");
                //B_Common.ExecuteSql(strsql.ToString());

                //把相应的Syjcz及Szwmx表里面的记录的jzbh清除掉
                strsql = new StringBuilder();
                strsql.Append("  update  Syjcz  set  jzbh=''  where id>=0  and yydh='" + yydh + "'  and jzbh='" + jzbh + "'");
                B_Common.ExecuteSql(strsql.ToString());

                strsql = new StringBuilder();
                strsql.Append(" update Szwmx set  jzbh='',czzt='"+common_file.common_yddj.yddj_dj+"',czsj='"+czsj+"'  where id>=0  and yydh='" + yydh + "'  and  jzbh='" + jzbh + "'");
                B_Common.ExecuteSql(strsql.ToString());

                strsql = new StringBuilder();
                strsql.Append(" update Ssyxfmx  set  jzbh=''    where id>=0  and yydh='" + yydh + "'   and jzbh='" + jzbh + "'");
                B_Common.ExecuteSql(strsql.ToString());

                strsql = new StringBuilder();
                strsql.Append(" delete from  Szw_temp_bak   where id>=0  and yydh='" + yydh + "'   and jzbh='" + jzbh + "'");
                B_Common.ExecuteSql(strsql.ToString());

                //删除Sfkfssz里面的记录
                strsql = new StringBuilder();
                strsql.Append(" delete from Sfkfssz  where id>=0  and yydh='" + yydh + "'    and jzbh='" + jzbh + "'");
                B_Common.ExecuteSql(strsql.ToString());
                s = common_file.common_app.get_suc;
            }
            #endregion


            #region    算帐的撤销
            if (czzt == common_file.common_jzzt.czzt_sz)
            {
                //删除jzzd
                DataSet ds_temp = B_Common.GetList(" select  *  from Flfsz ", " lsbh in  (select  lsbh from Flfsz  where lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "' and yydh='" + common_file.common_app.yydh + "'))");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds_temp.Tables[0].Rows.Count; j++)
                    {
                        s = common_file.common_app.get_failure;
                        lsbh = ds_temp.Tables[0].Rows[j]["lsbh"].ToString();
                        strsql = new StringBuilder();
                        strsql.Append(" delete from Sjzzd   where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and  jzbh='" + jzbh + "'  and czzt='" + czzt + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        //删除Sjzmx
                        strsql = new StringBuilder();
                        //strsql.Append(" delete from Sjzmx  where  id>=0  and yydh='"+yydh+"'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'  and xfxm!='"+common_file.common_app.dj_pzsk+"' ");
                        strsql.Append(" delete from Sjzmx where id>=0 and yydh='" + yydh + "'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        ////清除平帐收款的jzbh
                        //strsql = new StringBuilder();
                        //strsql.Append(" update  Sjzmx  set  jzbh=''   where id>=0  and yydh='"+yydh+"'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'  and xfxm='" + common_file.common_app.dj_pzsk + "'");
                        //B_Common.ExecuteSql(strsql.ToString());

                        //重建Szwmx及Syjcz  
                        strsql = new StringBuilder();
                        strsql.Append("  insert  into  Szwmx(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
                        strsql.Append(" select  yydh,qymc,is_top,is_select,id_app,'',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,'"+common_file.common_yddj.yddj_dj+"',czsj,syzd,is_visible,mxbh  from Szwmx_bak ");
                        strsql.Append("  where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        strsql = new StringBuilder();
                        strsql.Append(" insert into  Syjcz(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd)");
                        strsql.Append(" select yydh,qymc,is_top,is_select,id_app,'',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd  from Syjcz_bak");
                        strsql.Append("  where  id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'");
                        B_Common.ExecuteSql(strsql.ToString());


                        //删除Sfkfssz
                        strsql = new StringBuilder();
                        strsql.Append(" delete from Sfkfssz  where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        //更新
                        strsql = new StringBuilder();
                        strsql.Append(" update Ssyxfmx  set jzbh=''    where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        strsql = new StringBuilder();
                        strsql.Append(" delete from Szwmx_bak where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        strsql = new StringBuilder();
                        strsql.Append(" delete from Syjcz_bak where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and  jzbh='" + jzbh + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        B_Common.ExecuteSql("  delete from Szw_temp where lsbh='" + lsbh + "'  and  czy_temp='" + czy_GUID + "'");
                        s = common_file.common_app.get_suc;
                        //common_file.common_czjl.add_czjl(yydh, qymc, czy, czzt + "撤销", "结账编号:" + jzbh, "账务撤销", DateTime.Parse(czsj));

                    }
                }
                else
                {
                    strsql = new StringBuilder();
                    strsql.Append(" delete from Sjzzd   where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and  jzbh='" + jzbh + "'  and czzt='" + czzt + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    //删除Sjzmx
                    strsql = new StringBuilder();
                    //strsql.Append(" delete from Sjzmx  where  id>=0  and yydh='"+yydh+"'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'  and xfxm!='"+common_file.common_app.dj_pzsk+"' ");
                    strsql.Append(" delete from Sjzmx where id>=0 and yydh='" + yydh + "'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    ////清除平帐收款的jzbh
                    //strsql = new StringBuilder();
                    //strsql.Append(" update  Sjzmx  set  jzbh=''   where id>=0  and yydh='"+yydh+"'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'  and xfxm='" + common_file.common_app.dj_pzsk + "'");
                    //B_Common.ExecuteSql(strsql.ToString());

                    //重建Szwmx及Syjcz  
                    strsql = new StringBuilder();
                    strsql.Append("  insert  into  Szwmx(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
                    strsql.Append(" select  yydh,qymc,is_top,is_select,id_app,'',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,'"+common_file.common_yddj.yddj_dj+"',czsj,syzd,is_visible,mxbh  from Szwmx_bak ");
                    strsql.Append("  where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    strsql = new StringBuilder();
                    strsql.Append(" insert into  Syjcz(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd)");
                    strsql.Append(" select yydh,qymc,is_top,is_select,id_app,'',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd  from Syjcz_bak");
                    strsql.Append("  where  id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());


                    //删除Sfkfssz
                    strsql = new StringBuilder();
                    strsql.Append(" delete from Sfkfssz  where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    //更新
                    strsql = new StringBuilder();
                    strsql.Append(" update Ssyxfmx  set jzbh=''   where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    strsql = new StringBuilder();
                    strsql.Append(" delete from Szwmx_bak where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    strsql = new StringBuilder();
                    strsql.Append(" delete from Syjcz_bak where id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and  jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    B_Common.ExecuteSql("  delete from Szw_temp where lsbh='" + lsbh + "'  and  czy_temp='" + czy_GUID + "'");
                    s = common_file.common_app.get_suc;
                }
            }
            #endregion


            #region 部分结帐的撤销(部分算帐，记账分结，挂账分结)
            if (czzt == common_file.common_jzzt.czzt_bfsz || czzt == common_file.common_jzzt.czzt_gzfj || czzt == common_file.common_jzzt.czzt_jzfj)
            {
                decimal xfje_bfsz = 0;
                decimal fkje_bfsz = 0;
                string jzbh_old = "";//分结之备份到备份表的jzbh(czzt_bfsz时没有)
                DataSet ds_temp_bfsz_1 = B_Common.GetList(" select *  from  Sjzzd_bak ", "  id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "'  and  jzbh_new='" + jzbh + "'");
                if (ds_temp_bfsz_1 != null && ds_temp_bfsz_1.Tables[0].Rows.Count > 0)
                {
                    jzbh_old = ds_temp_bfsz_1.Tables[0].Rows[0]["jzbh"].ToString();
                }
                DataSet ds_temp_bfsz_2 = B_Common.GetList(" select *  from  Sjzzd ", " id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                if (ds_temp_bfsz_2 != null && ds_temp_bfsz_2.Tables[0].Rows.Count > 0)
                {
                    // xfje_bfsz =decimal.Parse( common_file.common_sswl.Round_sswl(double.Parse(ds_temp_bfsz_2.Tables[0].Rows[0]["xfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    //  fkje_bfsz = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds_temp_bfsz_2.Tables[0].Rows[0]["fkje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString()); 
                    xfje_bfsz = decimal.Parse(ds_temp_bfsz_2.Tables[0].Rows[0]["xfje"].ToString());
                    fkje_bfsz = decimal.Parse(ds_temp_bfsz_2.Tables[0].Rows[0]["fkje"].ToString());
                }

                #region 部分算帐部分
                if (czzt == common_file.common_jzzt.czzt_bfsz)
                {
                    DataSet ds_0 = B_Common.GetList(" select  *  from Sjzmx ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  jzbh='" + jzbh + "'");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_0.Tables[0].Rows.Count; i++)
                        {
                            if (ds_0.Tables[0].Rows[i]["xfdr"].ToString() != common_file.common_app.fkdr)
                            {
                                strsql = new StringBuilder();
                                strsql.Append(" update Szwzd set  xfje=xfje+" + decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds_0.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString()) + "  where id>=0  and lsbh='" + ds_0.Tables[0].Rows[i]["lsbh"].ToString() + "' ");
                                B_Common.ExecuteSql(strsql.ToString());
                            }
                        }
                        //decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString())
                    }

                    //处理Sjzzd
                    strsql = new StringBuilder();
                    strsql.Append(" delete from Sjzzd  where id>=0 and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());
                    //处理Sjzmx及Sjzmx_bak
                    strsql = new StringBuilder();
                    strsql.Append(" delete from Sjzmx where  id>=0 and yydh='" + yydh + "' and    jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    //删除Sfkfssz中的消费项目
                    strsql = new StringBuilder();
                    strsql.Append(" delete from  Sfkfssz   where id>=0 and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    strsql = new StringBuilder();
                    strsql.Append("  Insert into Szwmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
                    strsql.Append(" select yydh,qymc,id_app,'',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,'0',czy_bc,'" + common_file.common_yddj.yddj_dj + "',czsj,syzd,is_visible,mxbh  from Szwmx_bak");
                    strsql.Append("  where id>=0 and  yydh='" + yydh + "'    and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    //清除Ssyxfmx里面相应记录的Jzbh
                    B_Common.ExecuteSql("  update  Ssyxfmx  set  jzbh=''    where id_app  in (select  id_app from Szwmx_bak where id>=0  and yydh='" + yydh + "'    and jzbh='" + jzbh + "')");

                    //删除备份
                    strsql = new StringBuilder();
                    strsql.Append(" delete from Szwmx_bak where id>=0 and yydh='" + yydh + "'    and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());
                    s = common_file.common_app.get_suc;
                    common_file.common_czjl.add_czjl(yydh, qymc, czy, czzt + "撤销", "结账编号:" + jzbh, "账务撤销", DateTime.Parse(czsj));
                }
                #endregion

                #region   记账分结与挂账分结
                if (czzt == common_file.common_jzzt.czzt_gzfj || czzt == common_file.common_jzzt.czzt_jzfj)
                {


                    DataSet ds_0 = B_Common.GetList(" select  *  from Sjzmx ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  jzbh='" + jzbh + "' and  xfdr!='"+common_file.common_app.fkdr+"'");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_0.Tables[0].Rows.Count; i++)
                        {
                            if (ds_0.Tables[0].Rows[i]["xfdr"].ToString() != common_file.common_app.fkdr)
                            {
                                strsql = new StringBuilder();
                                strsql.Append(" update Szwzd_bak  set  xfje=xfje+" + decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds_0.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString()) + "  where id>=0  and lsbh='" + ds_0.Tables[0].Rows[i]["lsbh"].ToString() + "' ");
                                B_Common.ExecuteSql(strsql.ToString());
                            }
                        }
                        //decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString())
                    }

                    //B_Common.ExecuteSql("  update Szwzd_bak set xfje=xfje+" + xfje_bfsz + "  where id>=0  and lsbh='" + lsbh + "'  and jzbh='" + jzbh_old + "'");
                    B_Common.ExecuteSql(" update  Sjzzd  set  xfje=xfje+" + xfje_bfsz + "  where id>=0  and lsbh='" + lsbh + "' and jzbh='" + jzbh_old + "'");
                    //处理Sjzzd---删除分结的主单
                    strsql = new StringBuilder();
                    strsql.Append(" delete from Sjzzd  where id>=0 and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    string czzt_temp = "";
                    if (czzt == common_file.common_jzzt.czzt_gzfj)
                    { czzt_temp = common_file.common_jzzt.czzt_gz; }
                    if (czzt == common_file.common_jzzt.czzt_jzfj)
                    { czzt_temp = common_file.common_jzzt.czzt_jz; }

                    //B_Common.ExecuteSql(" delete from Sjzzd where  yydh='" + yydh + "'  and lsbh='" + lsbh + "'  and   jzbh='" + jzbh_old + "'");
                    //strsql = new StringBuilder(); 
                    //strsql.Append(" insert into  Sjzzd(yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,shsc,shys)");
                    //strsql.Append(" select  yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,shsc,0  from Sjzzd_bak ");
                    //strsql.Append("  where lsbh='" + lsbh + "'  and jzbh='" + jzbh_old + "' and jzbh_new='" + jzbh + "'");
                    //B_Common.ExecuteSql(strsql.ToString());

                    B_Common.ExecuteSql(" delete from Sjzzd_bak  where id>=0 and yydh='" + yydh + "' and lsbh='" + lsbh + "'  and  jzbh_new='" + jzbh + "'  and jzbh='" + jzbh_old + "'");

                    //处理Sjzmx及Sjzmx_bak
                    B_Common.ExecuteSql(" update  Sjzmx  set  jzbh='" + jzbh_old + "',czzt='" + czzt_temp + "'   where  id>=0  and  yydh='" + yydh + "'    and jzbh='" + jzbh + "' and xfxm!='" + common_file.common_app.dj_pzsk + "'");

                    //删除结账明里面的平账收款项目
                    B_Common.ExecuteSql("  delete from  Sjzmx  where   jzbh='" + jzbh + "' and  xfxm='" + common_file.common_app.dj_pzsk + "'");

                    //删除Sfkfssz中的平账收款项目
                    strsql = new StringBuilder();
                    strsql.Append(" delete from  Sfkfssz   where id>=0 and yydh='" + yydh + "'  and lsbh='" + lsbh + "' and jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    //还原Ssyxmf里面的Jzbh为旧的结账编号
                    B_Common.ExecuteSql("  update  Ssyxfmx  set  jzbh='"+jzbh_old+"'   where id_app in (select  id_app  from Sjzmx_bak where jzbh_new='" + jzbh + "'  and jzbh='" + jzbh_old + "')");

                    //处理Szwmx表
                    strsql = new StringBuilder();
                    strsql.Append("  Insert into Szwmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
                    strsql.Append(" select yydh,qymc,id_app,'" + jzbh_old + "',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,'0',czy_bc,czzt,czsj,syzd,is_visible,mxbh from Szwmx_bak");
                    strsql.Append("  where id>=0 and  yydh='" + yydh + "'  and  jzbh='" + jzbh + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    //删除相应的BAK里面的记录
                    B_Common.ExecuteSql(" delete from Sjzmx_bak  where id>=0  and  jzbh_new='" + jzbh + "'  and jzbh='" + jzbh_old + "' and yydh='" + yydh + "'");
                    B_Common.ExecuteSql(" delete from Szwmx_bak  where jzbh='" + jzbh + "' and yydh='" + yydh + "'");

                    s = common_file.common_app.get_suc;
                    common_file.common_czjl.add_czjl(yydh, qymc, czy, czzt + "撤销", "结账编号:" + jzbh, "撤销后的结账编号为:"+jzbh_old+",账务撤销成功", DateTime.Parse(czsj));
                }
                #endregion
            }
            #endregion


            #region 挂账/记账  转结账的撤销

            if (czzt == common_file.common_jzzt.czzt_jzzsz || czzt == common_file.common_jzzt.czzt_gzzsz)
            {
                B_Common.ExecuteSql(" delete  from  Sjzzd  where  id>=0   and jzbh='" + jzbh + "'  and  yydh='" + yydh + "'");
                DataSet ds_temp = B_Common.GetList(" select   *  from   Sjzzd_bak ", " id>=0  and  jzbh_new='" + jzbh + "'  and  yydh='" + common_file.common_app.yydh + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
                    {
                        string jzbh_old = ds_temp.Tables[0].Rows[i]["jzbh"].ToString();
                        string lsbh_old = ds_temp.Tables[0].Rows[i]["lsbh"].ToString();
                        string xfje = ds_temp.Tables[0].Rows[i]["xfje"].ToString();
                        string zsz_bz_temp = czzt + "撤销";
                        DataSet ds_temp_1 = B_Common.GetList("select  * from Sjzzd ", " id>=0  and  jzbh='" + jzbh_old + "'  and lsbh='" + lsbh_old + "'");
                        if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
                        {
                            B_Common.ExecuteSql(" update  Sjzzd  set   xfje='" + xfje + "'  where  jzbh='" + jzbh_old + "'  and lsbh='" + lsbh_old + "'");
                        }
                        else
                        {
                            strsql = new StringBuilder();
                            strsql.Append(" insert  into  Sjzzd(yydh,qymc,jzbh,lsbh,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,fkje,xfje,shsc,shys,ddsj,krxm_lz,fjbh_lz)");
                            strsql.Append("  select  yydh,qymc,jzbh,lsbh,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,'" + zsz_bz_temp + "',fp_print,fkje,xfje,0,0,ddsj,krxm_lz,fjbh_lz   from Sjzzd_bak");
                            strsql.Append("  where  jzbh='" + jzbh_old + "'  and  jzbh_new ='" + jzbh + "' ");
                            B_Common.ExecuteSql(strsql.ToString());
                        }
                        B_Common.ExecuteSql(" delete  from  Sjzzd_bak  where  jzbh='" + jzbh_old + "' and jzbh_new='" + jzbh + "'");

                        //删除消费
                        B_Common.ExecuteSql(" delete  from Sjzmx  where  jzbh='" + jzbh + "'  and lsbh='" + lsbh_old + "'  and  xfdr!='" + common_file.common_app.fkdr + "'");
                        //更新押金
                        B_Common.ExecuteSql("  update  Sjzmx  set  jzbh='" + jzbh_old + "'  where lsbh='" + lsbh_old + "' and  jzbh='" + jzbh + "'  and  xfdr='" + common_file.common_app.fkdr + "'");

                        //更新Sjzzd的付款金额
                        decimal fkje_total = 0;
                        DataSet ds_temp_2 = B_Common.GetList(" select Sum(sjxfje) as  total   from  Sjzmx", " id>=0  and   lsbh='" + lsbh_old + "'  and jzbh='" + jzbh_old + "'  and  xfdr='" + common_file.common_app.fkdr + "'  and  xfxm!='" + common_file.common_app.dj_pzsk + "'");
                        if (ds_temp_2 != null && ds_temp_2.Tables[0].Rows.Count > 0)
                        {
                            if (ds_temp_2.Tables[0].Rows[0]["total"].ToString() == "")
                            {
                                fkje_total = 0;
                            }
                            else
                            {
                                fkje_total = -decimal.Parse(ds_temp_2.Tables[0].Rows[0]["total"].ToString());
                            }
                        }
                        B_Common.ExecuteSql("  update Sjzzd  set   fkje=" + fkje_total + "  where id>=0  and  lsbh='" + lsbh_old + "'  and jzbh='" + jzbh_old + "'");

                        //还原消费明细
                        strsql = new StringBuilder();
                        strsql.Append(" insert into  Sjzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfzy,xfbz,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh,tfsj)");
                        strsql.Append(" select  yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfzy,xfbz,jjje,xfje,yh,sjxfje,xfsl,0,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh,tfsj  from  Sjzmx_bak ");
                        strsql.Append(" where   jzbh='" + jzbh_old + "'  and  jzbh_new='" + jzbh + "' and  lsbh='" + lsbh_old + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        //删除备份
                        B_Common.ExecuteSql("  delete  from   Sjzmx_bak   where  jzbh='" + jzbh_old + "'  and  lsbh='" + lsbh_old + "'  and jzbh_new='" + jzbh + "'");

                        //还原Szwmx
                        strsql = new StringBuilder();
                        strsql.Append(" insert into Szwmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
                        strsql.Append("  select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh  from Szwmx_bak");
                        strsql.Append("  where  jzbh='" + jzbh_old + "'  and yydh='" + yydh + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        strsql = new StringBuilder();
                        strsql.Append(" delete  from  Szwmx_bak   where  jzbh='" + jzbh_old + "'  and yydh='" + yydh + "'");
                        B_Common.ExecuteSql(strsql.ToString());

                        //获取主单的操作
                        string czzt_old_0 = "";
                        DataSet ds_temp_0 = B_Common.GetList("select  * from  Sjzzd  ", " Id>=0  and   jzbh='" + jzbh_old + "'  and  yydh='" + yydh + "'");
                        if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                        {
                            czzt_old_0 = ds_temp_0.Tables[0].Rows[0]["czzt"].ToString();
                            B_Common.ExecuteSql(" update  Sjzmx   set   czzt='" + czzt_old_0 + "'  where   jzbh='" + jzbh_old + "'  and   xfdr='" + common_file.common_app.fkdr + "' and yydh='" + yydh + "'");
                        }
                        ds_temp_0.Dispose();
                        //还原押金
                        strsql = new StringBuilder();
                        strsql.Append(" insert into  Syjcz(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt)");
                        strsql.Append(" select yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt   from Syjcz_bak");
                        strsql.Append("  where  jzbh='" + jzbh_old + "'  and yydh='" + yydh + "' ");
                        B_Common.ExecuteSql(strsql.ToString());

                        B_Common.ExecuteSql("  delete from Syjcz_bak  where jzbh='" + jzbh_old + "'  and yydh='" + yydh + "'");
                        B_Common.ExecuteSql(" update Ssyxfmx  set  jzbh='" + jzbh_old + "'   where  jzbh='" + jzbh + "'  and lsbh='" + lsbh_old + "'");
                    }
                }
                B_Common.ExecuteSql("  delete from Sjzmx where jzbh='" + jzbh + "'  and  xfxm='" + common_file.common_app.dj_pzsk + "'");
                B_Common.ExecuteSql("  delete from Sfkfssz  where   jzbh='" + jzbh + "'");
                common_file.common_czjl.add_czjl(yydh,qymc,czy,czzt+"撤销","结账编号:"+jzbh,"账务撤销",DateTime.Parse(czsj));
                s = common_file.common_app.get_suc;
            }
            #endregion


            //这个不用撤销的
            #region     记账 挂账转在住
            if (czzt == common_zw.zwzz_gz_sk || czzt == common_zw.zwzz_gz_tt || czzt == common_zw.zwzz_jz_sk || czzt == common_zw.zwzz_jz_tt)
            {
                string lsbh_old = "";
                string czzt_old = (czzt == common_zw.zwzz_gz_sk || czzt == common_zw.zwzz_gz_tt) ? common_file.common_jzzt.czzt_gz : common_file.common_jzzt.czzt_jz;
                if (lsbh_old.Trim() != "")
                {
                    //恢复主单
                    strsql = new StringBuilder();
                    strsql.Append("insert into Sjzzd(yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,shsc,shys)");
                    strsql.Append("  select yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,'" + czzt_old + "',xyh,jzzt,sdcz,syzd,'" + czzt + "撤销" + "',fp_print,is_visible,fkje,xfje,0,shys  from Sjzzd_bak");
                    strsql.Append("  where  yydh='" + yydh + "'  and czzt='" + czzt + "'  and lsbh='" + lsbh_old + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    B_Common.ExecuteSql(" delete from Sjzzd_bak  where  lsbh='" + lsbh_old + "' and   czzt='" + czzt + "'");

                    //恢复Sjzmx
                    strsql = new StringBuilder();
                    strsql.Append("  insert into  Sjzmx(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh)");
                    strsql.Append("  select yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,'" + czzt_old + "',czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh  from Sjzmx_bak ");
                    strsql.Append("  where  lsbh='" + lsbh_old + "'  and jzbh='" + jzbh + "' and  czzt='" + czzt + "'");
                    B_Common.ExecuteSql(strsql.ToString());

                    B_Common.ExecuteSql("  delete  from Sjzzd_bak where lsbh='" + lsbh_old + "'  and czzt='" + czzt + "'");

                    //恢复Szwmx
                    B_Common.ExecuteSql("  Update  Szwmx  set  jzbh='" + jzbh + "', lsbh='" + lsbh_old + "'  where  id_app  in (select  id_app  from Szwzz_mx  where lsbh_old='" + lsbh_old + "' and lsbh_new='" + lsbh + "')");

                    B_Common.ExecuteSql("  delete  from Szwmx_bak  where  id_app  in (select  id_app  from Szwzz_mx  where lsbh_old='" + lsbh_old + "' and lsbh_new='" + lsbh + "')");

                    //恢复Syjcz

                    B_Common.ExecuteSql("  update Syjcz set  jzbh='" + jzbh + "',lsbh='" + lsbh_old + "',xfzy='" + czzt + "撤销" + "'  where id_app  in (select  id_app  from Szwzz_mx  where lsbh_old='" + lsbh_old + "' and lsbh_new='" + lsbh + "')");
                    B_Common.ExecuteSql("  delete from Syjcz_bak  where  where id_app  in (select  id_app  from Szwzz_mx  where lsbh_old='" + lsbh_old + "' and lsbh_new='" + lsbh + "')");

                    //更新转入的Szwzd的值
                    DataSet ds_temp = new DataSet();
                    decimal fkje_0 = 0;
                    decimal xfje_0 = 0;
                    ds_temp = B_Common.GetList(" select  *  from  Sjzzd", "where  lsbh='" + lsbh_old + "'  and jzbh='" + jzbh + "' and czzt='" + czzt_old + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        xfje_0 = decimal.Parse(ds_temp.Tables[0].Rows[0]["xfje"].ToString());
                        fkje_0 = decimal.Parse(ds_temp.Tables[0].Rows[0]["fkje"].ToString());
                    }
                    B_Common.ExecuteSql("  update Szwzd set  xfje=xfje-(" + xfje_0 + "),fkje=fkje-(" + fkje_0 + ")  where  lsbh='" + lsbh + "'");

                    s = common_file.common_app.get_suc;
                }
            }

            #endregion


            //20120702更新，撤销成功的时候，要加一条记录到lskr_del
            if (s == common_file.common_app.get_suc)
            {
                DbHelperSQL.ExecuteSql("  insert into  Qskyd_lskr_delete(yydh,qymc,lsbh,czsj)  values('" + yydh + "','" + qymc + "','" + lsbh + "','" + czsj + "')");
            }
            return s;

        }
    }
}
