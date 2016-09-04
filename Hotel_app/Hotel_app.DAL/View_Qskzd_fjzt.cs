using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:View_Qskzd_fjzt
	/// </summary>
	public partial class View_Qskzd_fjzt
	{
		public View_Qskzd_fjzt()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.View_Qskzd_fjzt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Qskzd_fjzt(");
			strSql.Append("yydh,qymc,lsbh,hykh,krxm,krly,xydw,xsy,ddsj,lksj,czy,czsj,sktt,fjrb,fjbh,lzfs,fjjg,fkje,xfje,id,ddbh,is_top,is_select,hyrx,tlkr,zjhm,qtyq,main_sec,yddj,zyzt_zd,krgj,krmz,yxzj,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,xyh,krrx,cznr,syzd,tsyq,ffzf,ffshys,sjfjjg,yh,yhbl,bz,cxmd,krzy,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,ddrx,ddwz,ddyy,kr_children,lzts,vip_type,ddly,shqh,jcje,fjbm,shsc,zyzt,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@lsbh,@hykh,@krxm,@krly,@xydw,@xsy,@ddsj,@lksj,@czy,@czsj,@sktt,@fjrb,@fjbh,@lzfs,@fjjg,@fkje,@xfje,@id,@ddbh,@is_top,@is_select,@hyrx,@tlkr,@zjhm,@qtyq,@main_sec,@yddj,@zyzt_zd,@krgj,@krmz,@yxzj,@krxb,@krsr,@krdh,@krsj,@krEmail,@krdz,@krjg,@krdw,@xyh,@krrx,@cznr,@syzd,@tsyq,@ffzf,@ffshys,@sjfjjg,@yh,@yhbl,@bz,@cxmd,@krzy,@qzrx,@qzhm,@zjyxq,@tlyxq,@tjrq,@lzka,@ddrx,@ddwz,@ddyy,@kr_children,@lzts,@vip_type,@ddly,@shqh,@jcje,@fjbm,@shsc,@zyzt,@fjdh,@dhfj,@jdlh,@jdlh_name,@jdcs,@jdcs_name)");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,500),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ddbh", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@tlkr", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@qtyq", SqlDbType.VarChar,800),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt_zd", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,500),
					new SqlParameter("@krjg", SqlDbType.VarChar,500),
					new SqlParameter("@krdw", SqlDbType.VarChar,500),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@krrx", SqlDbType.VarChar,50),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@tsyq", SqlDbType.VarChar,800),
					new SqlParameter("@ffzf", SqlDbType.Bit,1),
					new SqlParameter("@ffshys", SqlDbType.Bit,1),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@yhbl", SqlDbType.Decimal,9),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@cxmd", SqlDbType.VarChar,500),
					new SqlParameter("@krzy", SqlDbType.VarChar,50),
					new SqlParameter("@qzrx", SqlDbType.VarChar,50),
					new SqlParameter("@qzhm", SqlDbType.VarChar,50),
					new SqlParameter("@zjyxq", SqlDbType.DateTime),
					new SqlParameter("@tlyxq", SqlDbType.DateTime),
					new SqlParameter("@tjrq", SqlDbType.DateTime),
					new SqlParameter("@lzka", SqlDbType.VarChar,50),
					new SqlParameter("@ddrx", SqlDbType.VarChar,50),
					new SqlParameter("@ddwz", SqlDbType.VarChar,50),
					new SqlParameter("@ddyy", SqlDbType.VarChar,200),
					new SqlParameter("@kr_children", SqlDbType.Int,4),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@vip_type", SqlDbType.VarChar,100),
					new SqlParameter("@ddly", SqlDbType.VarChar,50),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@jcje", SqlDbType.Decimal,9),
					new SqlParameter("@fjbm", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@fjdh", SqlDbType.VarChar,50),
					new SqlParameter("@dhfj", SqlDbType.VarChar,50),
					new SqlParameter("@jdlh", SqlDbType.VarChar,50),
					new SqlParameter("@jdlh_name", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs_name", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.hykh;
			parameters[4].Value = model.krxm;
			parameters[5].Value = model.krly;
			parameters[6].Value = model.xydw;
			parameters[7].Value = model.xsy;
			parameters[8].Value = model.ddsj;
			parameters[9].Value = model.lksj;
			parameters[10].Value = model.czy;
			parameters[11].Value = model.czsj;
			parameters[12].Value = model.sktt;
			parameters[13].Value = model.fjrb;
			parameters[14].Value = model.fjbh;
			parameters[15].Value = model.lzfs;
			parameters[16].Value = model.fjjg;
			parameters[17].Value = model.fkje;
			parameters[18].Value = model.xfje;
			parameters[19].Value = model.id;
			parameters[20].Value = model.ddbh;
			parameters[21].Value = model.is_top;
			parameters[22].Value = model.is_select;
			parameters[23].Value = model.hyrx;
			parameters[24].Value = model.tlkr;
			parameters[25].Value = model.zjhm;
			parameters[26].Value = model.qtyq;
			parameters[27].Value = model.main_sec;
			parameters[28].Value = model.yddj;
			parameters[29].Value = model.zyzt_zd;
			parameters[30].Value = model.krgj;
			parameters[31].Value = model.krmz;
			parameters[32].Value = model.yxzj;
			parameters[33].Value = model.krxb;
			parameters[34].Value = model.krsr;
			parameters[35].Value = model.krdh;
			parameters[36].Value = model.krsj;
			parameters[37].Value = model.krEmail;
			parameters[38].Value = model.krdz;
			parameters[39].Value = model.krjg;
			parameters[40].Value = model.krdw;
			parameters[41].Value = model.xyh;
			parameters[42].Value = model.krrx;
			parameters[43].Value = model.cznr;
			parameters[44].Value = model.syzd;
			parameters[45].Value = model.tsyq;
			parameters[46].Value = model.ffzf;
			parameters[47].Value = model.ffshys;
			parameters[48].Value = model.sjfjjg;
			parameters[49].Value = model.yh;
			parameters[50].Value = model.yhbl;
			parameters[51].Value = model.bz;
			parameters[52].Value = model.cxmd;
			parameters[53].Value = model.krzy;
			parameters[54].Value = model.qzrx;
			parameters[55].Value = model.qzhm;
			parameters[56].Value = model.zjyxq;
			parameters[57].Value = model.tlyxq;
			parameters[58].Value = model.tjrq;
			parameters[59].Value = model.lzka;
			parameters[60].Value = model.ddrx;
			parameters[61].Value = model.ddwz;
			parameters[62].Value = model.ddyy;
			parameters[63].Value = model.kr_children;
			parameters[64].Value = model.lzts;
			parameters[65].Value = model.vip_type;
			parameters[66].Value = model.ddly;
			parameters[67].Value = model.shqh;
			parameters[68].Value = model.jcje;
			parameters[69].Value = model.fjbm;
			parameters[70].Value = model.shsc;
			parameters[71].Value = model.zyzt;
			parameters[72].Value = model.fjdh;
			parameters[73].Value = model.dhfj;
			parameters[74].Value = model.jdlh;
			parameters[75].Value = model.jdlh_name;
			parameters[76].Value = model.jdcs;
			parameters[77].Value = model.jdcs_name;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.View_Qskzd_fjzt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Qskzd_fjzt set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("krly=@krly,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("czy=@czy,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("lzfs=@lzfs,");
			strSql.Append("fjjg=@fjjg,");
			strSql.Append("fkje=@fkje,");
			strSql.Append("xfje=@xfje,");
			strSql.Append("id=@id,");
			strSql.Append("ddbh=@ddbh,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("hyrx=@hyrx,");
			strSql.Append("tlkr=@tlkr,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("qtyq=@qtyq,");
			strSql.Append("main_sec=@main_sec,");
			strSql.Append("yddj=@yddj,");
			strSql.Append("zyzt_zd=@zyzt_zd,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("krmz=@krmz,");
			strSql.Append("yxzj=@yxzj,");
			strSql.Append("krxb=@krxb,");
			strSql.Append("krsr=@krsr,");
			strSql.Append("krdh=@krdh,");
			strSql.Append("krsj=@krsj,");
			strSql.Append("krEmail=@krEmail,");
			strSql.Append("krdz=@krdz,");
			strSql.Append("krjg=@krjg,");
			strSql.Append("krdw=@krdw,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("krrx=@krrx,");
			strSql.Append("cznr=@cznr,");
			strSql.Append("syzd=@syzd,");
			strSql.Append("tsyq=@tsyq,");
			strSql.Append("ffzf=@ffzf,");
			strSql.Append("ffshys=@ffshys,");
			strSql.Append("sjfjjg=@sjfjjg,");
			strSql.Append("yh=@yh,");
			strSql.Append("yhbl=@yhbl,");
			strSql.Append("bz=@bz,");
			strSql.Append("cxmd=@cxmd,");
			strSql.Append("krzy=@krzy,");
			strSql.Append("qzrx=@qzrx,");
			strSql.Append("qzhm=@qzhm,");
			strSql.Append("zjyxq=@zjyxq,");
			strSql.Append("tlyxq=@tlyxq,");
			strSql.Append("tjrq=@tjrq,");
			strSql.Append("lzka=@lzka,");
			strSql.Append("ddrx=@ddrx,");
			strSql.Append("ddwz=@ddwz,");
			strSql.Append("ddyy=@ddyy,");
			strSql.Append("kr_children=@kr_children,");
			strSql.Append("lzts=@lzts,");
			strSql.Append("vip_type=@vip_type,");
			strSql.Append("ddly=@ddly,");
			strSql.Append("shqh=@shqh,");
			strSql.Append("jcje=@jcje,");
			strSql.Append("fjbm=@fjbm,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("zyzt=@zyzt,");
			strSql.Append("fjdh=@fjdh,");
			strSql.Append("dhfj=@dhfj,");
			strSql.Append("jdlh=@jdlh,");
			strSql.Append("jdlh_name=@jdlh_name,");
			strSql.Append("jdcs=@jdcs,");
			strSql.Append("jdcs_name=@jdcs_name");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,500),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ddbh", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@tlkr", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@qtyq", SqlDbType.VarChar,800),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt_zd", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,500),
					new SqlParameter("@krjg", SqlDbType.VarChar,500),
					new SqlParameter("@krdw", SqlDbType.VarChar,500),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@krrx", SqlDbType.VarChar,50),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@tsyq", SqlDbType.VarChar,800),
					new SqlParameter("@ffzf", SqlDbType.Bit,1),
					new SqlParameter("@ffshys", SqlDbType.Bit,1),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@yhbl", SqlDbType.Decimal,9),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@cxmd", SqlDbType.VarChar,500),
					new SqlParameter("@krzy", SqlDbType.VarChar,50),
					new SqlParameter("@qzrx", SqlDbType.VarChar,50),
					new SqlParameter("@qzhm", SqlDbType.VarChar,50),
					new SqlParameter("@zjyxq", SqlDbType.DateTime),
					new SqlParameter("@tlyxq", SqlDbType.DateTime),
					new SqlParameter("@tjrq", SqlDbType.DateTime),
					new SqlParameter("@lzka", SqlDbType.VarChar,50),
					new SqlParameter("@ddrx", SqlDbType.VarChar,50),
					new SqlParameter("@ddwz", SqlDbType.VarChar,50),
					new SqlParameter("@ddyy", SqlDbType.VarChar,200),
					new SqlParameter("@kr_children", SqlDbType.Int,4),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@vip_type", SqlDbType.VarChar,100),
					new SqlParameter("@ddly", SqlDbType.VarChar,50),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@jcje", SqlDbType.Decimal,9),
					new SqlParameter("@fjbm", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@fjdh", SqlDbType.VarChar,50),
					new SqlParameter("@dhfj", SqlDbType.VarChar,50),
					new SqlParameter("@jdlh", SqlDbType.VarChar,50),
					new SqlParameter("@jdlh_name", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs_name", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.hykh;
			parameters[4].Value = model.krxm;
			parameters[5].Value = model.krly;
			parameters[6].Value = model.xydw;
			parameters[7].Value = model.xsy;
			parameters[8].Value = model.ddsj;
			parameters[9].Value = model.lksj;
			parameters[10].Value = model.czy;
			parameters[11].Value = model.czsj;
			parameters[12].Value = model.sktt;
			parameters[13].Value = model.fjrb;
			parameters[14].Value = model.fjbh;
			parameters[15].Value = model.lzfs;
			parameters[16].Value = model.fjjg;
			parameters[17].Value = model.fkje;
			parameters[18].Value = model.xfje;
			parameters[19].Value = model.id;
			parameters[20].Value = model.ddbh;
			parameters[21].Value = model.is_top;
			parameters[22].Value = model.is_select;
			parameters[23].Value = model.hyrx;
			parameters[24].Value = model.tlkr;
			parameters[25].Value = model.zjhm;
			parameters[26].Value = model.qtyq;
			parameters[27].Value = model.main_sec;
			parameters[28].Value = model.yddj;
			parameters[29].Value = model.zyzt_zd;
			parameters[30].Value = model.krgj;
			parameters[31].Value = model.krmz;
			parameters[32].Value = model.yxzj;
			parameters[33].Value = model.krxb;
			parameters[34].Value = model.krsr;
			parameters[35].Value = model.krdh;
			parameters[36].Value = model.krsj;
			parameters[37].Value = model.krEmail;
			parameters[38].Value = model.krdz;
			parameters[39].Value = model.krjg;
			parameters[40].Value = model.krdw;
			parameters[41].Value = model.xyh;
			parameters[42].Value = model.krrx;
			parameters[43].Value = model.cznr;
			parameters[44].Value = model.syzd;
			parameters[45].Value = model.tsyq;
			parameters[46].Value = model.ffzf;
			parameters[47].Value = model.ffshys;
			parameters[48].Value = model.sjfjjg;
			parameters[49].Value = model.yh;
			parameters[50].Value = model.yhbl;
			parameters[51].Value = model.bz;
			parameters[52].Value = model.cxmd;
			parameters[53].Value = model.krzy;
			parameters[54].Value = model.qzrx;
			parameters[55].Value = model.qzhm;
			parameters[56].Value = model.zjyxq;
			parameters[57].Value = model.tlyxq;
			parameters[58].Value = model.tjrq;
			parameters[59].Value = model.lzka;
			parameters[60].Value = model.ddrx;
			parameters[61].Value = model.ddwz;
			parameters[62].Value = model.ddyy;
			parameters[63].Value = model.kr_children;
			parameters[64].Value = model.lzts;
			parameters[65].Value = model.vip_type;
			parameters[66].Value = model.ddly;
			parameters[67].Value = model.shqh;
			parameters[68].Value = model.jcje;
			parameters[69].Value = model.fjbm;
			parameters[70].Value = model.shsc;
			parameters[71].Value = model.zyzt;
			parameters[72].Value = model.fjdh;
			parameters[73].Value = model.dhfj;
			parameters[74].Value = model.jdlh;
			parameters[75].Value = model.jdlh_name;
			parameters[76].Value = model.jdcs;
			parameters[77].Value = model.jdcs_name;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from View_Qskzd_fjzt ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hotel_app.Model.View_Qskzd_fjzt GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 yydh,qymc,lsbh,hykh,krxm,krly,xydw,xsy,ddsj,lksj,czy,czsj,sktt,fjrb,fjbh,lzfs,fjjg,fkje,xfje,id,ddbh,is_top,is_select,hyrx,tlkr,zjhm,qtyq,main_sec,yddj,zyzt_zd,krgj,krmz,yxzj,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,xyh,krrx,cznr,syzd,tsyq,ffzf,ffshys,sjfjjg,yh,yhbl,bz,cxmd,krzy,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,ddrx,ddwz,ddyy,kr_children,lzts,vip_type,ddly,shqh,jcje,fjbm,shsc,zyzt,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name from View_Qskzd_fjzt ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.View_Qskzd_fjzt model=new Hotel_app.Model.View_Qskzd_fjzt();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xsy"]!=null && ds.Tables[0].Rows[0]["xsy"].ToString()!="")
				{
					model.xsy=ds.Tables[0].Rows[0]["xsy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lzfs"]!=null && ds.Tables[0].Rows[0]["lzfs"].ToString()!="")
				{
					model.lzfs=decimal.Parse(ds.Tables[0].Rows[0]["lzfs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["fjjg"]!=null && ds.Tables[0].Rows[0]["fjjg"].ToString()!="")
				{
					model.fjjg=decimal.Parse(ds.Tables[0].Rows[0]["fjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["fkje"]!=null && ds.Tables[0].Rows[0]["fkje"].ToString()!="")
				{
					model.fkje=decimal.Parse(ds.Tables[0].Rows[0]["fkje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje"]!=null && ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ddbh"]!=null && ds.Tables[0].Rows[0]["ddbh"].ToString()!="")
				{
					model.ddbh=ds.Tables[0].Rows[0]["ddbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["is_top"]!=null && ds.Tables[0].Rows[0]["is_top"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_top"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_top"].ToString().ToLower()=="true"))
					{
						model.is_top=true;
					}
					else
					{
						model.is_top=false;
					}
				}
				if(ds.Tables[0].Rows[0]["is_select"]!=null && ds.Tables[0].Rows[0]["is_select"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_select"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_select"].ToString().ToLower()=="true"))
					{
						model.is_select=true;
					}
					else
					{
						model.is_select=false;
					}
				}
				if(ds.Tables[0].Rows[0]["hyrx"]!=null && ds.Tables[0].Rows[0]["hyrx"].ToString()!="")
				{
					model.hyrx=ds.Tables[0].Rows[0]["hyrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tlkr"]!=null && ds.Tables[0].Rows[0]["tlkr"].ToString()!="")
				{
					model.tlkr=ds.Tables[0].Rows[0]["tlkr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qtyq"]!=null && ds.Tables[0].Rows[0]["qtyq"].ToString()!="")
				{
					model.qtyq=ds.Tables[0].Rows[0]["qtyq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["main_sec"]!=null && ds.Tables[0].Rows[0]["main_sec"].ToString()!="")
				{
					model.main_sec=ds.Tables[0].Rows[0]["main_sec"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yddj"]!=null && ds.Tables[0].Rows[0]["yddj"].ToString()!="")
				{
					model.yddj=ds.Tables[0].Rows[0]["yddj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zyzt_zd"]!=null && ds.Tables[0].Rows[0]["zyzt_zd"].ToString()!="")
				{
					model.zyzt_zd=ds.Tables[0].Rows[0]["zyzt_zd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krgj"]!=null && ds.Tables[0].Rows[0]["krgj"].ToString()!="")
				{
					model.krgj=ds.Tables[0].Rows[0]["krgj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krmz"]!=null && ds.Tables[0].Rows[0]["krmz"].ToString()!="")
				{
					model.krmz=ds.Tables[0].Rows[0]["krmz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yxzj"]!=null && ds.Tables[0].Rows[0]["yxzj"].ToString()!="")
				{
					model.yxzj=ds.Tables[0].Rows[0]["yxzj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxb"]!=null && ds.Tables[0].Rows[0]["krxb"].ToString()!="")
				{
					model.krxb=ds.Tables[0].Rows[0]["krxb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsr"]!=null && ds.Tables[0].Rows[0]["krsr"].ToString()!="")
				{
					model.krsr=DateTime.Parse(ds.Tables[0].Rows[0]["krsr"].ToString());
				}
				if(ds.Tables[0].Rows[0]["krdh"]!=null && ds.Tables[0].Rows[0]["krdh"].ToString()!="")
				{
					model.krdh=ds.Tables[0].Rows[0]["krdh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsj"]!=null && ds.Tables[0].Rows[0]["krsj"].ToString()!="")
				{
					model.krsj=ds.Tables[0].Rows[0]["krsj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krEmail"]!=null && ds.Tables[0].Rows[0]["krEmail"].ToString()!="")
				{
					model.krEmail=ds.Tables[0].Rows[0]["krEmail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krdz"]!=null && ds.Tables[0].Rows[0]["krdz"].ToString()!="")
				{
					model.krdz=ds.Tables[0].Rows[0]["krdz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krjg"]!=null && ds.Tables[0].Rows[0]["krjg"].ToString()!="")
				{
					model.krjg=ds.Tables[0].Rows[0]["krjg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krdw"]!=null && ds.Tables[0].Rows[0]["krdw"].ToString()!="")
				{
					model.krdw=ds.Tables[0].Rows[0]["krdw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh"]!=null && ds.Tables[0].Rows[0]["xyh"].ToString()!="")
				{
					model.xyh=ds.Tables[0].Rows[0]["xyh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krrx"]!=null && ds.Tables[0].Rows[0]["krrx"].ToString()!="")
				{
					model.krrx=ds.Tables[0].Rows[0]["krrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cznr"]!=null && ds.Tables[0].Rows[0]["cznr"].ToString()!="")
				{
					model.cznr=ds.Tables[0].Rows[0]["cznr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["syzd"]!=null && ds.Tables[0].Rows[0]["syzd"].ToString()!="")
				{
					model.syzd=ds.Tables[0].Rows[0]["syzd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tsyq"]!=null && ds.Tables[0].Rows[0]["tsyq"].ToString()!="")
				{
					model.tsyq=ds.Tables[0].Rows[0]["tsyq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ffzf"]!=null && ds.Tables[0].Rows[0]["ffzf"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ffzf"].ToString()=="1")||(ds.Tables[0].Rows[0]["ffzf"].ToString().ToLower()=="true"))
					{
						model.ffzf=true;
					}
					else
					{
						model.ffzf=false;
					}
				}
				if(ds.Tables[0].Rows[0]["ffshys"]!=null && ds.Tables[0].Rows[0]["ffshys"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ffshys"].ToString()=="1")||(ds.Tables[0].Rows[0]["ffshys"].ToString().ToLower()=="true"))
					{
						model.ffshys=true;
					}
					else
					{
						model.ffshys=false;
					}
				}
				if(ds.Tables[0].Rows[0]["sjfjjg"]!=null && ds.Tables[0].Rows[0]["sjfjjg"].ToString()!="")
				{
					model.sjfjjg=decimal.Parse(ds.Tables[0].Rows[0]["sjfjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yh"]!=null && ds.Tables[0].Rows[0]["yh"].ToString()!="")
				{
					model.yh=ds.Tables[0].Rows[0]["yh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yhbl"]!=null && ds.Tables[0].Rows[0]["yhbl"].ToString()!="")
				{
					model.yhbl=decimal.Parse(ds.Tables[0].Rows[0]["yhbl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["bz"]!=null && ds.Tables[0].Rows[0]["bz"].ToString()!="")
				{
					model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cxmd"]!=null && ds.Tables[0].Rows[0]["cxmd"].ToString()!="")
				{
					model.cxmd=ds.Tables[0].Rows[0]["cxmd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krzy"]!=null && ds.Tables[0].Rows[0]["krzy"].ToString()!="")
				{
					model.krzy=ds.Tables[0].Rows[0]["krzy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qzrx"]!=null && ds.Tables[0].Rows[0]["qzrx"].ToString()!="")
				{
					model.qzrx=ds.Tables[0].Rows[0]["qzrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qzhm"]!=null && ds.Tables[0].Rows[0]["qzhm"].ToString()!="")
				{
					model.qzhm=ds.Tables[0].Rows[0]["qzhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjyxq"]!=null && ds.Tables[0].Rows[0]["zjyxq"].ToString()!="")
				{
					model.zjyxq=DateTime.Parse(ds.Tables[0].Rows[0]["zjyxq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tlyxq"]!=null && ds.Tables[0].Rows[0]["tlyxq"].ToString()!="")
				{
					model.tlyxq=DateTime.Parse(ds.Tables[0].Rows[0]["tlyxq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tjrq"]!=null && ds.Tables[0].Rows[0]["tjrq"].ToString()!="")
				{
					model.tjrq=DateTime.Parse(ds.Tables[0].Rows[0]["tjrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzka"]!=null && ds.Tables[0].Rows[0]["lzka"].ToString()!="")
				{
					model.lzka=ds.Tables[0].Rows[0]["lzka"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddrx"]!=null && ds.Tables[0].Rows[0]["ddrx"].ToString()!="")
				{
					model.ddrx=ds.Tables[0].Rows[0]["ddrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddwz"]!=null && ds.Tables[0].Rows[0]["ddwz"].ToString()!="")
				{
					model.ddwz=ds.Tables[0].Rows[0]["ddwz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddyy"]!=null && ds.Tables[0].Rows[0]["ddyy"].ToString()!="")
				{
					model.ddyy=ds.Tables[0].Rows[0]["ddyy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["kr_children"]!=null && ds.Tables[0].Rows[0]["kr_children"].ToString()!="")
				{
					model.kr_children=int.Parse(ds.Tables[0].Rows[0]["kr_children"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzts"]!=null && ds.Tables[0].Rows[0]["lzts"].ToString()!="")
				{
					model.lzts=int.Parse(ds.Tables[0].Rows[0]["lzts"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vip_type"]!=null && ds.Tables[0].Rows[0]["vip_type"].ToString()!="")
				{
					model.vip_type=ds.Tables[0].Rows[0]["vip_type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddly"]!=null && ds.Tables[0].Rows[0]["ddly"].ToString()!="")
				{
					model.ddly=ds.Tables[0].Rows[0]["ddly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["shqh"]!=null && ds.Tables[0].Rows[0]["shqh"].ToString()!="")
				{
					model.shqh=ds.Tables[0].Rows[0]["shqh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jcje"]!=null && ds.Tables[0].Rows[0]["jcje"].ToString()!="")
				{
					model.jcje=decimal.Parse(ds.Tables[0].Rows[0]["jcje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["fjbm"]!=null && ds.Tables[0].Rows[0]["fjbm"].ToString()!="")
				{
					model.fjbm=ds.Tables[0].Rows[0]["fjbm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["shsc"]!=null && ds.Tables[0].Rows[0]["shsc"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shsc"].ToString()=="1")||(ds.Tables[0].Rows[0]["shsc"].ToString().ToLower()=="true"))
					{
						model.shsc=true;
					}
					else
					{
						model.shsc=false;
					}
				}
				if(ds.Tables[0].Rows[0]["zyzt"]!=null && ds.Tables[0].Rows[0]["zyzt"].ToString()!="")
				{
					model.zyzt=ds.Tables[0].Rows[0]["zyzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjdh"]!=null && ds.Tables[0].Rows[0]["fjdh"].ToString()!="")
				{
					model.fjdh=ds.Tables[0].Rows[0]["fjdh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["dhfj"]!=null && ds.Tables[0].Rows[0]["dhfj"].ToString()!="")
				{
					model.dhfj=ds.Tables[0].Rows[0]["dhfj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jdlh"]!=null && ds.Tables[0].Rows[0]["jdlh"].ToString()!="")
				{
					model.jdlh=ds.Tables[0].Rows[0]["jdlh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jdlh_name"]!=null && ds.Tables[0].Rows[0]["jdlh_name"].ToString()!="")
				{
					model.jdlh_name=ds.Tables[0].Rows[0]["jdlh_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jdcs"]!=null && ds.Tables[0].Rows[0]["jdcs"].ToString()!="")
				{
					model.jdcs=ds.Tables[0].Rows[0]["jdcs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jdcs_name"]!=null && ds.Tables[0].Rows[0]["jdcs_name"].ToString()!="")
				{
					model.jdcs_name=ds.Tables[0].Rows[0]["jdcs_name"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select yydh,qymc,lsbh,hykh,krxm,krly,xydw,xsy,ddsj,lksj,czy,czsj,sktt,fjrb,fjbh,lzfs,fjjg,fkje,xfje,id,ddbh,is_top,is_select,hyrx,tlkr,zjhm,qtyq,main_sec,yddj,zyzt_zd,krgj,krmz,yxzj,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,xyh,krrx,cznr,syzd,tsyq,ffzf,ffshys,sjfjjg,yh,yhbl,bz,cxmd,krzy,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,ddrx,ddwz,ddyy,kr_children,lzts,vip_type,ddly,shqh,jcje,fjbm,shsc,zyzt,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name ");
			strSql.Append(" FROM View_Qskzd_fjzt ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" yydh,qymc,lsbh,hykh,krxm,krly,xydw,xsy,ddsj,lksj,czy,czsj,sktt,fjrb,fjbh,lzfs,fjjg,fkje,xfje,id,ddbh,is_top,is_select,hyrx,tlkr,zjhm,qtyq,main_sec,yddj,zyzt_zd,krgj,krmz,yxzj,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,xyh,krrx,cznr,syzd,tsyq,ffzf,ffshys,sjfjjg,yh,yhbl,bz,cxmd,krzy,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,ddrx,ddwz,ddyy,kr_children,lzts,vip_type,ddly,shqh,jcje,fjbm,shsc,zyzt,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name ");
			strSql.Append(" FROM View_Qskzd_fjzt ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM View_Qskzd_fjzt ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from View_Qskzd_fjzt T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "View_Qskzd_fjzt";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

