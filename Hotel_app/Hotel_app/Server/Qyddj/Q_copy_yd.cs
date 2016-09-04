using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Hotel_app.Model;

namespace Hotel_app.Server.Qyddj
{
    public class Q_copy_yd
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="sktt"></param>两个值,一个sk另一个tt
        /// <param name="old_lsbh"></param>
        /// <param name="ddsj"></param>
        /// <param name="lksj"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        
        public string copy_sk_yd(string yydh,string qymc,string sktt,string old_lsbh,string lsbh_new,string ddbh_new,string czy,DateTime czsj,string cznr,string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string insert_s = "";
            //string lsbh_new = "";
            if (sktt == "sk")
            {
                //lsbh_new = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);

                insert_s = "insert into Qskyd_mainrecord (yydh,qymc,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz)";
                insert_s = insert_s + " select yydh,qymc,'" + lsbh_new + "','"+ddbh_new+"',0,0,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,'',zyzt,krrx,kr_children,'" + DateTime.Now.ToShortDateString() + " 12:00:00',1,'" + DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00',qtyq,'" + czy + "','" + czsj + "','" + cznr + "',shsc,'" + common_file.common_sktt.sktt_sk + "','" + common_file.common_yddj.yddj_yd + "',ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz from Qskyd_mainrecord where lsbh='" + old_lsbh + "'   and  main_sec='"+common_file.common_app.main_sec_main+"'";
                B_Common.ExecuteSql(insert_s);

                //Q_ff_xyxf Q_ff_xyxf_new = new Q_ff_xyxf();
                //Q_ff_xyxf_new.Qyddj_otherfee_add(yydh, qymc, lsbh_new, "", sktt, "", czy);


                //insert_s = "delete from Qskyd_fjrb where lsbh='" + lsbh_new + "'";
                //B_Common.ExecuteSql(insert_s);
                DataSet DS_temp = B_Common.GetList("select * from Qskyd_fjrb", "lsbh='" + old_lsbh + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    insert_s = "update Qskyd_fjrb set fjrb='" + DS_temp.Tables[0].Rows[0]["fjrb"].ToString() + "',fjbh='',lzfs=1,fjjg='" + DS_temp.Tables[0].Rows[0]["fjjg"].ToString() + "',sjfjjg='" + DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString() + "',yh='" + DS_temp.Tables[0].Rows[0]["yh"].ToString() + "',yhbl='" + DS_temp.Tables[0].Rows[0]["yhbl"].ToString() + "' where lsbh='"+lsbh_new+"'";
                    B_Common.ExecuteSql(insert_s);
                }

                //insert_s = "insert into Qskyd_fjrb(yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,czy,czsj,cznr,fjbm,jcje)";
                //insert_s = insert_s + " select yydh,qymc,'" + lsbh_new + "',krxm,(select   top 1 sktt from Qskyd_mainrecord where lsbh='" + lsbh_new + "' and main_sec='" + common_file.common_app.main_sec_main + "'),(select  top 1  yddj from Qskyd_mainrecord where lsbh='" + old_lsbh + "' and main_sec='" + common_file.common_app.main_sec_main + "'),fjrb,'','" + DateTime.Now.ToShortDateString() + " 12:00:00','" + DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00',lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,czy,czsj,cznr,fjbm,0 from Qskyd_fjrb where lsbh='" + old_lsbh + "'";
                //B_Common.ExecuteSql(insert_s);
                
                Q_ff_xyxf Q_ff_xyxf_new = new Q_ff_xyxf();
                string krxm="";
                string sktt0="";
                string fjbh="";
                DS_temp = B_Common.GetList("select lsbh,krxm,sktt,fjbh  from  View_Qskzd", " lsbh='" + lsbh_new + "'  and  main_sec='" + common_file.common_app.main_sec_main + "'");
                if(DS_temp!=null && DS_temp.Tables[0].Rows.Count>0)
                {
                    krxm=DS_temp.Tables[0].Rows[0]["krxm"].ToString();
                    sktt=DS_temp.Tables[0].Rows[0]["sktt"].ToString();
                    fjbh=DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                }
                Q_ff_xyxf_new.Qyddj_otherfee_add(yydh, qymc, lsbh_new, krxm, sktt0, fjbh, czy);
                DS_temp.Clear();
                DS_temp.Dispose();
                //BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
                //BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            }
            else
                if (sktt == "tt")
                {
                    //lsbh_new = common_file.common_ddbh.ddbh("ttyd", "ttyddate", "ttydcounter", 6);
                    insert_s = "insert into Qttyd_mainrecord (yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,sdcz,syzd,tsyq,ddly)";
                    insert_s = insert_s + " select yydh,qymc,'" + lsbh_new + "','"+ddbh_new+"',0,0,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,'',zyzt,'" + DateTime.Now.ToShortDateString() + " 12:00:00',1,'" + DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00',qtyq,'" + czy + "','" + czsj + "','" + cznr + "',shsc,sktt,'" + common_file.common_yddj.yddj_yd + "',ffshys,sdcz,syzd,tsyq,ddly from Qttyd_mainrecord where lsbh='" + old_lsbh + "'";
                    B_Common.ExecuteSql(insert_s);
                    insert_s = "delete from Qskyd_fjrb where lsbh='" + lsbh_new + "'";
                    B_Common.ExecuteSql(insert_s);
                    insert_s = "insert into Qskyd_fjrb(yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,czy,czsj,cznr,fjbm,jcje)";
                    insert_s = insert_s + " select yydh,qymc,'" + lsbh_new + "',krxm,sktt,(select yddj from Qttyd_mainrecord where lsbh='" + lsbh_new + "' ),fjrb,'','" + DateTime.Now.ToShortDateString() + " 12:00:00','" + DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00',1,shqh,fjjg,sjfjjg,yh,yhbl,bz,czy,czsj,cznr,fjbm,0 from Qskyd_fjrb where lsbh='" + old_lsbh + "'";
                    B_Common.ExecuteSql(insert_s);
                }
            s = common_file.common_app.get_suc;
            return s;
        }
    }
}
