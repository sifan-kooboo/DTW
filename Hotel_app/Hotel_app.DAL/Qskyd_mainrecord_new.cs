using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用

namespace Hotel_app.DAL
{
    public class Qskyd_mainrecord_new
    {

        public Qskyd_mainrecord_new()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Hotel_app.Model.Qskyd_mainrecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Qskyd_mainrecord(");
            strSql.Append("yydh,qymc,lsbh,ddbh,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,sktt,yddj,ffshys,main_sec)");
            strSql.Append(" values (");
            strSql.Append("@yydh,@qymc,@lsbh,@ddbh,@hykh,@hyrx,@krxm,@tlkr,@krgj,@krmz,@yxzj,@zjhm,@krxb,@krsr,@krdh,@krsj,@krEmail,@krdz,@krjg,@krdw,@krzy,@cxmd,@qzrx,@qzhm,@zjyxq,@tlyxq,@tjrq,@lzka,@krly,@xyh,@xydw,@xsy,@ddrx,@ddwz,@zyzt,@krrx,@kr_children,@ddsj,@lzts,@lksj,@qtyq,@czy,@czsj,@cznr,@sktt,@yddj,@ffshys,@main_sec)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddbh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@tlkr", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,50),
					new SqlParameter("@krjg", SqlDbType.VarChar,50),
					new SqlParameter("@krdw", SqlDbType.VarChar,50),
					new SqlParameter("@krzy", SqlDbType.VarChar,50),
					new SqlParameter("@cxmd", SqlDbType.VarChar,50),
					new SqlParameter("@qzrx", SqlDbType.VarChar,50),
					new SqlParameter("@qzhm", SqlDbType.VarChar,50),
					new SqlParameter("@zjyxq", SqlDbType.DateTime),
					new SqlParameter("@tlyxq", SqlDbType.DateTime),
					new SqlParameter("@tjrq", SqlDbType.DateTime),
					new SqlParameter("@lzka", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddrx", SqlDbType.VarChar,50),
					new SqlParameter("@ddwz", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@krrx", SqlDbType.VarChar,50),
					new SqlParameter("@kr_children", SqlDbType.Int,4),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@qtyq", SqlDbType.Text),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@ffshys", SqlDbType.VarChar,50),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50)};
            parameters[0].Value = model.yydh;
            parameters[1].Value = model.qymc;
            parameters[2].Value = model.lsbh;
            parameters[3].Value = model.ddbh;
            parameters[6].Value = model.hykh;
            parameters[7].Value = model.hyrx;
            parameters[8].Value = model.krxm;
            parameters[9].Value = model.tlkr;
            parameters[10].Value = model.krgj;
            parameters[11].Value = model.krmz;
            parameters[12].Value = model.yxzj;
            parameters[13].Value = model.zjhm;
            parameters[14].Value = model.krxb;
            parameters[15].Value = model.krsr;
            parameters[16].Value = model.krdh;
            parameters[17].Value = model.krsj;
            parameters[18].Value = model.krEmail;
            parameters[19].Value = model.krdz;
            parameters[20].Value = model.krjg;
            parameters[21].Value = model.krdw;
            parameters[22].Value = model.krzy;
            parameters[23].Value = model.cxmd;
            parameters[24].Value = model.qzrx;
            parameters[25].Value = model.qzhm;
            parameters[26].Value = model.zjyxq;
            parameters[27].Value = model.tlyxq;
            parameters[28].Value = model.tjrq;
            parameters[29].Value = model.lzka;
            parameters[30].Value = model.krly;
            parameters[31].Value = model.xyh;
            parameters[32].Value = model.xydw;
            parameters[33].Value = model.xsy;
            parameters[34].Value = model.ddrx;
            parameters[35].Value = model.ddwz;
            parameters[36].Value = model.zyzt;
            parameters[37].Value = model.krrx;
            parameters[38].Value = model.kr_children;
            parameters[39].Value = model.ddsj;
            parameters[40].Value = model.lzts;
            parameters[41].Value = model.lksj;
            parameters[42].Value = model.qtyq;
            parameters[43].Value = model.czy;
            parameters[44].Value = model.czsj;
            parameters[45].Value = model.cznr;
            parameters[47].Value = model.sktt;
            parameters[48].Value = model.yddj;
            parameters[49].Value = model.ffshys;
            parameters[50].Value = model.main_sec;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


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
            StringBuilder strSql_2 = new StringBuilder();
            StringBuilder strSql_3 = new StringBuilder();
            DataSet DS_temp = DbHelperSQL.Query("select lsbh from Qskyd_mainrecord where id="+id);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (czzt == "xg" || czzt == "sc")
                {
                    strSql.Append("insert into Qskyd_mainrecord_temp (yydh,qymc,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,qxyy,ddly,hykh_bz)");
                    strSql.Append(" select yydh,qymc,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + cznr + "',shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,'" + qxyy + "',ddly,hykh_bz from Qskyd_mainrecord");
                    if (czzt == "xg")
                    {
                        strSql.Append(" where id=" + id);
                    }
                    else
                        if (czzt == "sc")
                        {
                            strSql.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                        }
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
                        strSql_2.Append("insert into Flfsz_temp (yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,czy,cznr,czsj,is_top,is_select)");
                        strSql_2.Append(" select yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,'" + czy + "','" + cznr + "','" + czsj + "',is_top,is_select from Flfsz");
                        strSql_2.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                        i = DbHelperSQL.ExecuteSql(strSql_2.ToString());
                        strSql_3.Append("insert into Qyddj_otherfee_temp (yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,czy,cznr,czsj,sdcz,is_top,is_select,mxbh)");
                        strSql_3.Append(" select yydh,qymc,lsbh,krxm,fjbh,sktt,fyrx,xfdr,xfrb,xfsl,xfxm,jjje,xfje,shsc,'" + czy + "','" + cznr + "','" + czsj + "',sdcz,is_top,is_select,mxbh from Qyddj_otherfee");
                        strSql_3.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                        i = DbHelperSQL.ExecuteSql(strSql_3.ToString());
                        

                    }
                }
                if (czzt == "jz")
                {
                    strSql.Append("insert into Qskyd_mainrecord_bak (yydh,qymc,jzbh,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz)");
                    strSql.Append(" select yydh,qymc,'" + jzbh + "',lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + cznr + "',shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz from Qskyd_mainrecord");
                    strSql.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    i = DbHelperSQL.ExecuteSql(strSql.ToString());

                    //历史客人
                    StringBuilder strSql0 = new StringBuilder();
                    strSql0.Append("insert into Qskyd_mainrecord_lskr (yydh,qymc,jzbh,lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,czy,czsj,cznr,shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz)");
                    strSql0.Append(" select yydh,qymc,'" + jzbh + "',lsbh,ddbh,is_top,is_select,hykh,hyrx,krxm,tlkr,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,ddyy,zyzt,krrx,kr_children,ddsj,lzts,lksj,qtyq,'" + czy + "','" + czsj + "','" + cznr + "',shsc,sktt,yddj,ffshys,main_sec,sdcz,ffzf,syzd,vip_type,tsyq,ddly,hykh_bz from Qskyd_mainrecord");
                    strSql0.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    i = DbHelperSQL.ExecuteSql(strSql0.ToString());


                    strSql_0.Append("insert into Qskyd_fjrb_bak (yydh,qymc,jzbh,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,fjbm,jcje)");
                    strSql_0.Append(" select yydh,qymc,'" + jzbh + "',lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,'" + czy + "','" + czsj + "','" + cznr + "',sdcz,fjbm,jcje from Qskyd_fjrb");
                    strSql_0.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    i = DbHelperSQL.ExecuteSql(strSql_0.ToString());

                    //历史客人
                    StringBuilder strSql_00 = new StringBuilder();
                    strSql_00.Append("insert into Qskyd_fjrb_lskr (yydh,qymc,jzbh,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,fjbm,jcje)");
                    strSql_00.Append(" select yydh,qymc,'" + jzbh + "',lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,'" + czy + "','" + czsj + "','" + cznr + "',sdcz,fjbm,jcje from Qskyd_fjrb");
                    strSql_00.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    i = DbHelperSQL.ExecuteSql(strSql_00.ToString());

                    strSql_1.Append("insert into Szwzd_bak (yydh,qymc,jzbh,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select)");
                    strSql_1.Append(" select yydh,qymc,'" + jzbh + "',lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select from Szwzd");
                    strSql_1.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    i = DbHelperSQL.ExecuteSql(strSql_1.ToString());
                    strSql_2.Append("insert into Flfsz_bak (yydh,qymc,jzbh,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,czy,cznr,czsj,is_top,is_select)");
                    strSql_2.Append(" select yydh,qymc,'" + jzbh + "',lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,'" + czy + "','" + cznr + "','" + czsj + "',is_top,is_select from Flfsz");
                    strSql_2.Append(" where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    i = DbHelperSQL.ExecuteSql(strSql_2.ToString());
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
