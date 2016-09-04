using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用

namespace Hotel_app.DAL
{
    public class Qttyd_mainrecord_new
    {
        public Qttyd_mainrecord_new()
        { }

        /// <summary>
        /// 删除或结账时的成批备份
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cznr"></param>主要是两个值，一个是“取消”，一个“未到”到common_yddj里去找
        /// <param name="qxyy"></param>取消原因
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="czzt"></param>状态有三种，修改"xg",删除"sc",结账退房"jz"(包含结账、挂账、记账)
        /// <param name="jzbh"></param>
        /// <returns></returns>
        public int Pladd(int id, string cznr, string qxyy, string czy, string czsj, string czzt, string jzbh)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql_0 = new StringBuilder();
            StringBuilder strSql_1 = new StringBuilder();
            StringBuilder strSql_3 = new StringBuilder();
            DataSet DS_temp = DbHelperSQL.Query("select lsbh from Qttyd_mainrecord where id=" + id);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (czzt == "xg" || czzt == "sc")
                {
                    strSql.Append("insert into Qttyd_mainrecord_temp (yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,sdcz,syzd,tsyq,qxyy,ddly)");
                    strSql.Append(" select yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + cznr + "',shsc,sktt,yddj,ffshys,sdcz,syzd,tsyq,'" + qxyy + "',ddly from Qttyd_mainrecord");
                    strSql.Append(" where id=" + id);
                    i = DbHelperSQL.ExecuteSql(strSql.ToString());
                    if (czzt == "sc")
                    {
                        strSql_0.Append("insert into Qskyd_fjrb_temp (yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,fjbm,jcje)");
                        strSql_0.Append(" select yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,'" + czy + "','" + czsj + "','" + cznr + "',sdcz,fjbm,jcje from Qskyd_fjrb");
                        strSql_0.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                        i = DbHelperSQL.ExecuteSql(strSql_0.ToString());
                        strSql_1.Append("insert into Szwzd_temp (yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select,cznr)");
                        strSql_1.Append(" select yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select,'" + cznr + "' from Szwzd");
                        strSql_1.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                        i = DbHelperSQL.ExecuteSql(strSql_1.ToString());
                        strSql_3.Append("insert into Qyddj_otherfee_temp (yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,czy,cznr,czsj,sdcz,is_top,is_select,mxbh)");
                        strSql_3.Append(" select yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,'" + czy + "','" + cznr + "','" + czsj + "',sdcz,is_top,is_select,mxbh from Qyddj_otherfee");
                        strSql_3.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                        i = DbHelperSQL.ExecuteSql(strSql_3.ToString());
                    }
                }
                if (czzt == "jz")
                {
                    strSql.Append("insert into Qttyd_mainrecord_bak (yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,sdcz,syzd,tsyq,jzbh,ddly)");
                    strSql.Append(" select yydh,qymc,lsbh,ddbh,is_top,is_select,krxm,krbh,krgj,krdh,krsj,krEmail,ydrxm,krdz,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + cznr + "',shsc,sktt,yddj,ffshys,sdcz,syzd,tsyq,'" + jzbh + "',ddly from Qttyd_mainrecord");
                    strSql.Append(" where id=" + id);
                    i = DbHelperSQL.ExecuteSql(strSql.ToString());
                    strSql_0.Append("insert into Qskyd_fjrb_bak (yydh,qymc,jzbh,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,fjbm,jcje)");
                    strSql_0.Append(" select yydh,qymc,'" + jzbh + "',lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,'" + czy + "','" + czsj + "','" + cznr + "',sdcz,fjbm,jcje from Qskyd_fjrb");
                    strSql_0.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    i = DbHelperSQL.ExecuteSql(strSql_0.ToString());
                    strSql_1.Append("insert into Szwzd_bak (yydh,qymc,jzbh,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select)");
                    strSql_1.Append(" select yydh,qymc,'" + jzbh + "',lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select from Szwzd");
                    strSql_1.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    i = DbHelperSQL.ExecuteSql(strSql_1.ToString());
                    strSql_3.Append("insert into Qyddj_otherfee_bak (yydh,qymc,jzbh,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,czy,cznr,czsj,sdcz,is_top,is_select,mxbh)");
                    strSql_3.Append(" select yydh,qymc,'" + jzbh + "',lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,'" + czy + "','" + cznr + "','" + czsj + "',sdcz,is_top,is_select,mxbh from Qyddj_otherfee");
                    strSql_3.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    i = DbHelperSQL.ExecuteSql(strSql_3.ToString());
                }
            }
            return i;
        }



    }
}
