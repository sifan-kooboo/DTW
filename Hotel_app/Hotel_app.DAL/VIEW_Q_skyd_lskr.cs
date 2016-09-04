using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_Q_skyd_lskr
	/// </summary>
	public partial class VIEW_Q_skyd_lskr
	{
		public VIEW_Q_skyd_lskr()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.VIEW_Q_skyd_lskr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VIEW_Q_skyd_lskr(");
			strSql.Append("lsbh,hykh,hyrx,krxm,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,zyzt,krrx,kr_children,ddsj,ddyy,lzts,qtyq,lksj,czy,czsj,cznr,shsc,sktt,yddj,ffshys,ffzf,main_sec,sdcz,syzd,vip_type,tsyq,ddly,hykh_bz,fjrb,fjbh,lzfs,sjfjjg,jcje,qymc,yydh,yh,fjjg,id)");
			strSql.Append(" values (");
			strSql.Append("@lsbh,@hykh,@hyrx,@krxm,@krgj,@krmz,@yxzj,@zjhm,@krxb,@krsr,@krdh,@krsj,@krEmail,@krdz,@krjg,@krdw,@krzy,@cxmd,@qzrx,@qzhm,@zjyxq,@tlyxq,@tjrq,@lzka,@krly,@xyh,@xydw,@xsy,@ddrx,@ddwz,@zyzt,@krrx,@kr_children,@ddsj,@ddyy,@lzts,@qtyq,@lksj,@czy,@czsj,@cznr,@shsc,@sktt,@yddj,@ffshys,@ffzf,@main_sec,@sdcz,@syzd,@vip_type,@tsyq,@ddly,@hykh_bz,@fjrb,@fjbh,@lzfs,@sjfjjg,@jcje,@qymc,@yydh,@yh,@fjjg,@id)");
			SqlParameter[] parameters = {
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
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
					new SqlParameter("@ddyy", SqlDbType.VarChar,200),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@qtyq", SqlDbType.VarChar,800),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@ffshys", SqlDbType.Bit,1),
					new SqlParameter("@ffzf", SqlDbType.Bit,1),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@vip_type", SqlDbType.VarChar,100),
					new SqlParameter("@tsyq", SqlDbType.VarChar,800),
					new SqlParameter("@ddly", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@jcje", SqlDbType.Decimal,9),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.lsbh;
			parameters[1].Value = model.hykh;
			parameters[2].Value = model.hyrx;
			parameters[3].Value = model.krxm;
			parameters[4].Value = model.krgj;
			parameters[5].Value = model.krmz;
			parameters[6].Value = model.yxzj;
			parameters[7].Value = model.zjhm;
			parameters[8].Value = model.krxb;
			parameters[9].Value = model.krsr;
			parameters[10].Value = model.krdh;
			parameters[11].Value = model.krsj;
			parameters[12].Value = model.krEmail;
			parameters[13].Value = model.krdz;
			parameters[14].Value = model.krjg;
			parameters[15].Value = model.krdw;
			parameters[16].Value = model.krzy;
			parameters[17].Value = model.cxmd;
			parameters[18].Value = model.qzrx;
			parameters[19].Value = model.qzhm;
			parameters[20].Value = model.zjyxq;
			parameters[21].Value = model.tlyxq;
			parameters[22].Value = model.tjrq;
			parameters[23].Value = model.lzka;
			parameters[24].Value = model.krly;
			parameters[25].Value = model.xyh;
			parameters[26].Value = model.xydw;
			parameters[27].Value = model.xsy;
			parameters[28].Value = model.ddrx;
			parameters[29].Value = model.ddwz;
			parameters[30].Value = model.zyzt;
			parameters[31].Value = model.krrx;
			parameters[32].Value = model.kr_children;
			parameters[33].Value = model.ddsj;
			parameters[34].Value = model.ddyy;
			parameters[35].Value = model.lzts;
			parameters[36].Value = model.qtyq;
			parameters[37].Value = model.lksj;
			parameters[38].Value = model.czy;
			parameters[39].Value = model.czsj;
			parameters[40].Value = model.cznr;
			parameters[41].Value = model.shsc;
			parameters[42].Value = model.sktt;
			parameters[43].Value = model.yddj;
			parameters[44].Value = model.ffshys;
			parameters[45].Value = model.ffzf;
			parameters[46].Value = model.main_sec;
			parameters[47].Value = model.sdcz;
			parameters[48].Value = model.syzd;
			parameters[49].Value = model.vip_type;
			parameters[50].Value = model.tsyq;
			parameters[51].Value = model.ddly;
			parameters[52].Value = model.hykh_bz;
			parameters[53].Value = model.fjrb;
			parameters[54].Value = model.fjbh;
			parameters[55].Value = model.lzfs;
			parameters[56].Value = model.sjfjjg;
			parameters[57].Value = model.jcje;
			parameters[58].Value = model.qymc;
			parameters[59].Value = model.yydh;
			parameters[60].Value = model.yh;
			parameters[61].Value = model.fjjg;
			parameters[62].Value = model.id;

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
		public bool Update(Hotel_app.Model.VIEW_Q_skyd_lskr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VIEW_Q_skyd_lskr set ");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("hyrx=@hyrx,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("krmz=@krmz,");
			strSql.Append("yxzj=@yxzj,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("krxb=@krxb,");
			strSql.Append("krsr=@krsr,");
			strSql.Append("krdh=@krdh,");
			strSql.Append("krsj=@krsj,");
			strSql.Append("krEmail=@krEmail,");
			strSql.Append("krdz=@krdz,");
			strSql.Append("krjg=@krjg,");
			strSql.Append("krdw=@krdw,");
			strSql.Append("krzy=@krzy,");
			strSql.Append("cxmd=@cxmd,");
			strSql.Append("qzrx=@qzrx,");
			strSql.Append("qzhm=@qzhm,");
			strSql.Append("zjyxq=@zjyxq,");
			strSql.Append("tlyxq=@tlyxq,");
			strSql.Append("tjrq=@tjrq,");
			strSql.Append("lzka=@lzka,");
			strSql.Append("krly=@krly,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("ddrx=@ddrx,");
			strSql.Append("ddwz=@ddwz,");
			strSql.Append("zyzt=@zyzt,");
			strSql.Append("krrx=@krrx,");
			strSql.Append("kr_children=@kr_children,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("ddyy=@ddyy,");
			strSql.Append("lzts=@lzts,");
			strSql.Append("qtyq=@qtyq,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("czy=@czy,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("cznr=@cznr,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("yddj=@yddj,");
			strSql.Append("ffshys=@ffshys,");
			strSql.Append("ffzf=@ffzf,");
			strSql.Append("main_sec=@main_sec,");
			strSql.Append("sdcz=@sdcz,");
			strSql.Append("syzd=@syzd,");
			strSql.Append("vip_type=@vip_type,");
			strSql.Append("tsyq=@tsyq,");
			strSql.Append("ddly=@ddly,");
			strSql.Append("hykh_bz=@hykh_bz,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("lzfs=@lzfs,");
			strSql.Append("sjfjjg=@sjfjjg,");
			strSql.Append("jcje=@jcje,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("yh=@yh,");
			strSql.Append("fjjg=@fjjg,");
			strSql.Append("id=@id");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
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
					new SqlParameter("@ddyy", SqlDbType.VarChar,200),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@qtyq", SqlDbType.VarChar,800),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@ffshys", SqlDbType.Bit,1),
					new SqlParameter("@ffzf", SqlDbType.Bit,1),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@vip_type", SqlDbType.VarChar,100),
					new SqlParameter("@tsyq", SqlDbType.VarChar,800),
					new SqlParameter("@ddly", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@jcje", SqlDbType.Decimal,9),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.lsbh;
			parameters[1].Value = model.hykh;
			parameters[2].Value = model.hyrx;
			parameters[3].Value = model.krxm;
			parameters[4].Value = model.krgj;
			parameters[5].Value = model.krmz;
			parameters[6].Value = model.yxzj;
			parameters[7].Value = model.zjhm;
			parameters[8].Value = model.krxb;
			parameters[9].Value = model.krsr;
			parameters[10].Value = model.krdh;
			parameters[11].Value = model.krsj;
			parameters[12].Value = model.krEmail;
			parameters[13].Value = model.krdz;
			parameters[14].Value = model.krjg;
			parameters[15].Value = model.krdw;
			parameters[16].Value = model.krzy;
			parameters[17].Value = model.cxmd;
			parameters[18].Value = model.qzrx;
			parameters[19].Value = model.qzhm;
			parameters[20].Value = model.zjyxq;
			parameters[21].Value = model.tlyxq;
			parameters[22].Value = model.tjrq;
			parameters[23].Value = model.lzka;
			parameters[24].Value = model.krly;
			parameters[25].Value = model.xyh;
			parameters[26].Value = model.xydw;
			parameters[27].Value = model.xsy;
			parameters[28].Value = model.ddrx;
			parameters[29].Value = model.ddwz;
			parameters[30].Value = model.zyzt;
			parameters[31].Value = model.krrx;
			parameters[32].Value = model.kr_children;
			parameters[33].Value = model.ddsj;
			parameters[34].Value = model.ddyy;
			parameters[35].Value = model.lzts;
			parameters[36].Value = model.qtyq;
			parameters[37].Value = model.lksj;
			parameters[38].Value = model.czy;
			parameters[39].Value = model.czsj;
			parameters[40].Value = model.cznr;
			parameters[41].Value = model.shsc;
			parameters[42].Value = model.sktt;
			parameters[43].Value = model.yddj;
			parameters[44].Value = model.ffshys;
			parameters[45].Value = model.ffzf;
			parameters[46].Value = model.main_sec;
			parameters[47].Value = model.sdcz;
			parameters[48].Value = model.syzd;
			parameters[49].Value = model.vip_type;
			parameters[50].Value = model.tsyq;
			parameters[51].Value = model.ddly;
			parameters[52].Value = model.hykh_bz;
			parameters[53].Value = model.fjrb;
			parameters[54].Value = model.fjbh;
			parameters[55].Value = model.lzfs;
			parameters[56].Value = model.sjfjjg;
			parameters[57].Value = model.jcje;
			parameters[58].Value = model.qymc;
			parameters[59].Value = model.yydh;
			parameters[60].Value = model.yh;
			parameters[61].Value = model.fjjg;
			parameters[62].Value = model.id;

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
			strSql.Append("delete from VIEW_Q_skyd_lskr ");
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
		public Hotel_app.Model.VIEW_Q_skyd_lskr GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 lsbh,hykh,hyrx,krxm,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,zyzt,krrx,kr_children,ddsj,ddyy,lzts,qtyq,lksj,czy,czsj,cznr,shsc,sktt,yddj,ffshys,ffzf,main_sec,sdcz,syzd,vip_type,tsyq,ddly,hykh_bz,fjrb,fjbh,lzfs,sjfjjg,jcje,qymc,yydh,yh,fjjg,id from VIEW_Q_skyd_lskr ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.VIEW_Q_skyd_lskr model=new Hotel_app.Model.VIEW_Q_skyd_lskr();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hyrx"]!=null && ds.Tables[0].Rows[0]["hyrx"].ToString()!="")
				{
					model.hyrx=ds.Tables[0].Rows[0]["hyrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
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
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
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
				if(ds.Tables[0].Rows[0]["krzy"]!=null && ds.Tables[0].Rows[0]["krzy"].ToString()!="")
				{
					model.krzy=ds.Tables[0].Rows[0]["krzy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cxmd"]!=null && ds.Tables[0].Rows[0]["cxmd"].ToString()!="")
				{
					model.cxmd=ds.Tables[0].Rows[0]["cxmd"].ToString();
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
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh"]!=null && ds.Tables[0].Rows[0]["xyh"].ToString()!="")
				{
					model.xyh=ds.Tables[0].Rows[0]["xyh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xsy"]!=null && ds.Tables[0].Rows[0]["xsy"].ToString()!="")
				{
					model.xsy=ds.Tables[0].Rows[0]["xsy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddrx"]!=null && ds.Tables[0].Rows[0]["ddrx"].ToString()!="")
				{
					model.ddrx=ds.Tables[0].Rows[0]["ddrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddwz"]!=null && ds.Tables[0].Rows[0]["ddwz"].ToString()!="")
				{
					model.ddwz=ds.Tables[0].Rows[0]["ddwz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zyzt"]!=null && ds.Tables[0].Rows[0]["zyzt"].ToString()!="")
				{
					model.zyzt=ds.Tables[0].Rows[0]["zyzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krrx"]!=null && ds.Tables[0].Rows[0]["krrx"].ToString()!="")
				{
					model.krrx=ds.Tables[0].Rows[0]["krrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["kr_children"]!=null && ds.Tables[0].Rows[0]["kr_children"].ToString()!="")
				{
					model.kr_children=int.Parse(ds.Tables[0].Rows[0]["kr_children"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ddyy"]!=null && ds.Tables[0].Rows[0]["ddyy"].ToString()!="")
				{
					model.ddyy=ds.Tables[0].Rows[0]["ddyy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lzts"]!=null && ds.Tables[0].Rows[0]["lzts"].ToString()!="")
				{
					model.lzts=int.Parse(ds.Tables[0].Rows[0]["lzts"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qtyq"]!=null && ds.Tables[0].Rows[0]["qtyq"].ToString()!="")
				{
					model.qtyq=ds.Tables[0].Rows[0]["qtyq"].ToString();
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
				if(ds.Tables[0].Rows[0]["cznr"]!=null && ds.Tables[0].Rows[0]["cznr"].ToString()!="")
				{
					model.cznr=ds.Tables[0].Rows[0]["cznr"].ToString();
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
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yddj"]!=null && ds.Tables[0].Rows[0]["yddj"].ToString()!="")
				{
					model.yddj=ds.Tables[0].Rows[0]["yddj"].ToString();
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
				if(ds.Tables[0].Rows[0]["main_sec"]!=null && ds.Tables[0].Rows[0]["main_sec"].ToString()!="")
				{
					model.main_sec=ds.Tables[0].Rows[0]["main_sec"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sdcz"]!=null && ds.Tables[0].Rows[0]["sdcz"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["sdcz"].ToString()=="1")||(ds.Tables[0].Rows[0]["sdcz"].ToString().ToLower()=="true"))
					{
						model.sdcz=true;
					}
					else
					{
						model.sdcz=false;
					}
				}
				if(ds.Tables[0].Rows[0]["syzd"]!=null && ds.Tables[0].Rows[0]["syzd"].ToString()!="")
				{
					model.syzd=ds.Tables[0].Rows[0]["syzd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vip_type"]!=null && ds.Tables[0].Rows[0]["vip_type"].ToString()!="")
				{
					model.vip_type=ds.Tables[0].Rows[0]["vip_type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tsyq"]!=null && ds.Tables[0].Rows[0]["tsyq"].ToString()!="")
				{
					model.tsyq=ds.Tables[0].Rows[0]["tsyq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddly"]!=null && ds.Tables[0].Rows[0]["ddly"].ToString()!="")
				{
					model.ddly=ds.Tables[0].Rows[0]["ddly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh_bz"]!=null && ds.Tables[0].Rows[0]["hykh_bz"].ToString()!="")
				{
					model.hykh_bz=ds.Tables[0].Rows[0]["hykh_bz"].ToString();
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
				if(ds.Tables[0].Rows[0]["sjfjjg"]!=null && ds.Tables[0].Rows[0]["sjfjjg"].ToString()!="")
				{
					model.sjfjjg=decimal.Parse(ds.Tables[0].Rows[0]["sjfjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jcje"]!=null && ds.Tables[0].Rows[0]["jcje"].ToString()!="")
				{
					model.jcje=decimal.Parse(ds.Tables[0].Rows[0]["jcje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yh"]!=null && ds.Tables[0].Rows[0]["yh"].ToString()!="")
				{
					model.yh=ds.Tables[0].Rows[0]["yh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjjg"]!=null && ds.Tables[0].Rows[0]["fjjg"].ToString()!="")
				{
					model.fjjg=decimal.Parse(ds.Tables[0].Rows[0]["fjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
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
			strSql.Append("select lsbh,hykh,hyrx,krxm,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,zyzt,krrx,kr_children,ddsj,ddyy,lzts,qtyq,lksj,czy,czsj,cznr,shsc,sktt,yddj,ffshys,ffzf,main_sec,sdcz,syzd,vip_type,tsyq,ddly,hykh_bz,fjrb,fjbh,lzfs,sjfjjg,jcje,qymc,yydh,yh,fjjg,id ");
			strSql.Append(" FROM VIEW_Q_skyd_lskr ");
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
			strSql.Append(" lsbh,hykh,hyrx,krxm,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,krjg,krdw,krzy,cxmd,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,krly,xyh,xydw,xsy,ddrx,ddwz,zyzt,krrx,kr_children,ddsj,ddyy,lzts,qtyq,lksj,czy,czsj,cznr,shsc,sktt,yddj,ffshys,ffzf,main_sec,sdcz,syzd,vip_type,tsyq,ddly,hykh_bz,fjrb,fjbh,lzfs,sjfjjg,jcje,qymc,yydh,yh,fjjg,id ");
			strSql.Append(" FROM VIEW_Q_skyd_lskr ");
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
			strSql.Append("select count(1) FROM VIEW_Q_skyd_lskr ");
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
			strSql.Append(")AS Row, T.*  from VIEW_Q_skyd_lskr T ");
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
			parameters[0].Value = "VIEW_Q_skyd_lskr";
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

