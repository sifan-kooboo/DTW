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
using Hotel_app.Ffjzt;
using Hotel_app.Qyddj;
using Hotel_app.Server.Qyddj;

namespace Hotel_app.common_file_server
{
    public class Common_pl_zwcl
    {
        /// <summary>
        /// 结帐时的批量帐务处理
        /// 
        /// </summary>
        /// 先写入Sjzzd，同时写sjzmx,Ffkfssz
        /// 写入成功后，将zwmx里面的对应的记录写入到zwmx_bak,并删除当前lsbh对应下的zwmx记录
        public static string Pladd(string lsbh, string jzbh, string xydw, string krly, string czsj, string syzd, string czy, string czy_bc, string jzzt, string cznr, string bz, string fkje, string xfje, string xxzs)
        {
            //修改房态时用到的变量
            string id = "";//主单的ID
            //
            Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Hotel_app.Ffjzt.Ffjzt_add_edit();//用于修改房态
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();//修改房态
            Hotel_app.BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            Hotel_app.Model.Qskyd_mainrecord M_Qskyd_mainrecord;
            Hotel_app.BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();

            Hotel_app.Server.Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();//房态及删除主单操作


            string s = common_app.get_failure;
            StringBuilder strSql = new StringBuilder();//注意jzzd只写入一次(公共信息查一次就好)
            strSql.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje)");
            strSql.Append(" select top 1 yydh,qymc,'" + lsbh + "',jzbh,krxm,sktt,fjbh,'" + xydw + "','" + krly + "','" + DateTime.Now + "','" + czsj + "','" + czy + "','" + common_file.common_jzzt.czzt_sz + "','" + common_file.common_jzzt.czzt_sz + "','" + syzd + "','" + bz + "','" + fkje + "','" + xfje + "'  from Szw_temp");
            strSql.Append(" where lsbh='" + lsbh + "' and  czy_temp='" + czy + "'");
            BLL.Common B_common = new Hotel_app.BLL.Common();
            if (B_common.ExecuteSql(strSql.ToString()) > 0)//写入主单成功后，写入jzmx
            {
                strSql = new StringBuilder();
                strSql.Append("insert into Sjzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,jzzt,fkfs ) ");
                strSql.Append(" select yydh,qymc,id_app,jzbh,'" + lsbh + "',krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,'" + czy_bc + "','" + jzzt + "','" + czsj + "','" + syzd + "','" + jzzt + "',fkfs  from Szw_temp");
                strSql.Append(" where lsbh='" + lsbh + "' and  czy_temp='" + czy + "'");
                if (B_common.ExecuteSql(strSql.ToString()) > 0)//写入jzmx成功后,
                {
                    //提取fkdr为付款的项目写入Ffkfssz
                    strSql = new StringBuilder();
                    strSql.Append("insert into Sfkfssz(yydh,qymc,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,fkrq,fksj,xfrq,xfsj,czy,czy_bc,syzd)");
                    strSql.Append(" select yydh,qymc,jzhb,'" + jzzt + "',lsbh,fjbh,krxm,fkfs,xfdr,xfxm,xfje,sjxfje,fkrq,fksj,xfrq,xfsj,czy,czy_bc,syzd from Szw_temp");
                    strSql.Append(" where lsbh='" + lsbh + "'  and czy_temp='" + czy + "'  and  xfdr='" + common_app.fkdr + "'");

                    //删除zwmx里面此lsbh对应的帐务(同时通过zwmx上面的触发器来写入到zwmx_bak里面）
                    strSql = new StringBuilder();
                    strSql.Append("update  Szwmx  set  jzbh='" + jzbh + "'  where id>0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh + "'");
                    if (B_common.ExecuteSql(strSql.ToString()) > 0)//更新成功
                    {
                        strSql = new StringBuilder();
                        strSql.Append("delete from Szwmx  where id>0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh + "'");
                        //删除的时候根据删除的触发器写入到对应的bak表中

                        if (B_common.ExecuteSql(strSql.ToString()) > 0)
                        {
                            //先更新押金操作表里面的jzbh，再删除yjcz表里面对应的记录，并写入其bak，写入Ffkfssz
                            strSql = new StringBuilder();
                            strSql.Append("update Syjcz  set jzbh='" + jzbh + "'  where id>0 " + common_app.yydh_select + "  and  lsbh='" + lsbh + "'");
                            if (B_common.ExecuteSql(strSql.ToString()) > 0)//押金更新成功
                            {
                                if (jzzt == common_file.common_jzzt.czzt_sz)//算帐
                                {
                                    strSql = new StringBuilder();
                                    strSql.Append("delete from Syjcz where id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'");
                                    if (B_common.ExecuteSql(strSql.ToString()) > 0)
                                    {
                                        //清除Szw_temp
                                        strSql = new StringBuilder();
                                        strSql.Append("delete from Szw_temp  where  id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'");
                                        if (B_common.ExecuteSql(strSql.ToString()) > 0) //清除Szw_temp里面的数据了
                                        {
                                            //调用修改房态的方法(第五步)
                                            M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'")[0];
                                            id = M_Qskyd_mainrecord.id.ToString();

                                            //删除主单并记录（这里有包含主单记录删除时的备份）
                                            if (Qyddj_add_edit_delete_new.delete_sz_xgft(id,"jz",common_file.common_jzzt.czzt_sz,"",jzbh,czy,czsj,xxzs) == common_app.get_suc)
                                            {
                                                s = common_app.get_suc;
                                            }
                                        }
                                    }
                                }
                                else if(jzzt==common_file.common_jzzt.czzt_gz||jzzt==common_file.common_jzzt.czzt_jz)//挂帐或者记帐
                                {
                                    strSql = new StringBuilder();
                                    strSql.Append("delete from Szw_temp  where  id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'");
                                    if (B_common.ExecuteSql(strSql.ToString()) > 0) //清除Szw_temp里面的数据了
                                    {
                                        //调用修改房态的方法(第五步)
                                        M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>0  " + common_app.yydh_select + "  and lsbh='" + lsbh + "'")[0];
                                        id = M_Qskyd_mainrecord.id.ToString();

                                        //删除主单并记录（这里有包含主单记录删除时的备份）
                                        if (Qyddj_add_edit_delete_new.delete_sz_xgft(id, "jz",jzzt,"",jzbh, czy, czsj, xxzs) == common_app.get_suc)
                                        {
                                            s = common_app.get_suc;
                                        }
                                    }  
                                }
                            }
                        }
                    }

                }
            }
            return s;
        }
    }
}
