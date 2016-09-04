using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Qcounter
	/// </summary>
	public partial class Qcounter
	{
		public Qcounter()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Qcounter"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Qcounter");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.Qcounter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Qcounter(");
			strSql.Append("yydh,qymc,bh,skydcounter,skyddate,skdjcounter,skdjdate,ttydcounter,ttyddate,lsttdjcounter,ttdjdate,ttdjcounter,lfcounter,lfdate,gzcounter,gzdate,jzcounter,jzdate,szcounter,szdate,qs,qsdate,jbdate,jbcounter,zdpf,shys,zhbbsj,txftsl,shgz,ybtqts,hycounter,hydate,lsbhcounter,lsbhdate,scsj,zjk,zbjk,xzsj,shsc,scbz,jsbtsj,jsqtsj,tjkffs,xydwdate,xydwcounter,printzdpd,hyjfrxpd,eating_time,xsws,shlz,lsbhdfcounter,lsbhdfdate,ff_xfsj_rx,ysk_pc,ft_xs_krxm,ft_xs_fjjg,ft_auto_refresh,jz_ts,jz_ls_total,Hhygl_qyqr,VersionType)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@bh,@skydcounter,@skyddate,@skdjcounter,@skdjdate,@ttydcounter,@ttyddate,@lsttdjcounter,@ttdjdate,@ttdjcounter,@lfcounter,@lfdate,@gzcounter,@gzdate,@jzcounter,@jzdate,@szcounter,@szdate,@qs,@qsdate,@jbdate,@jbcounter,@zdpf,@shys,@zhbbsj,@txftsl,@shgz,@ybtqts,@hycounter,@hydate,@lsbhcounter,@lsbhdate,@scsj,@zjk,@zbjk,@xzsj,@shsc,@scbz,@jsbtsj,@jsqtsj,@tjkffs,@xydwdate,@xydwcounter,@printzdpd,@hyjfrxpd,@eating_time,@xsws,@shlz,@lsbhdfcounter,@lsbhdfdate,@ff_xfsj_rx,@ysk_pc,@ft_xs_krxm,@ft_xs_fjjg,@ft_auto_refresh,@jz_ts,@jz_ls_total,@Hhygl_qyqr,@VersionType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bh", SqlDbType.Int,4),
					new SqlParameter("@skydcounter", SqlDbType.Int,4),
					new SqlParameter("@skyddate", SqlDbType.DateTime),
					new SqlParameter("@skdjcounter", SqlDbType.Int,4),
					new SqlParameter("@skdjdate", SqlDbType.DateTime),
					new SqlParameter("@ttydcounter", SqlDbType.Int,4),
					new SqlParameter("@ttyddate", SqlDbType.DateTime),
					new SqlParameter("@lsttdjcounter", SqlDbType.Int,4),
					new SqlParameter("@ttdjdate", SqlDbType.DateTime),
					new SqlParameter("@ttdjcounter", SqlDbType.Int,4),
					new SqlParameter("@lfcounter", SqlDbType.Int,4),
					new SqlParameter("@lfdate", SqlDbType.DateTime),
					new SqlParameter("@gzcounter", SqlDbType.Int,4),
					new SqlParameter("@gzdate", SqlDbType.DateTime),
					new SqlParameter("@jzcounter", SqlDbType.Int,4),
					new SqlParameter("@jzdate", SqlDbType.DateTime),
					new SqlParameter("@szcounter", SqlDbType.Int,4),
					new SqlParameter("@szdate", SqlDbType.DateTime),
					new SqlParameter("@qs", SqlDbType.Int,4),
					new SqlParameter("@qsdate", SqlDbType.DateTime),
					new SqlParameter("@jbdate", SqlDbType.DateTime),
					new SqlParameter("@jbcounter", SqlDbType.Int,4),
					new SqlParameter("@zdpf", SqlDbType.Bit,1),
					new SqlParameter("@shys", SqlDbType.Bit,1),
					new SqlParameter("@zhbbsj", SqlDbType.DateTime),
					new SqlParameter("@txftsl", SqlDbType.Int,4),
					new SqlParameter("@shgz", SqlDbType.Int,4),
					new SqlParameter("@ybtqts", SqlDbType.Int,4),
					new SqlParameter("@hycounter", SqlDbType.Int,4),
					new SqlParameter("@hydate", SqlDbType.DateTime),
					new SqlParameter("@lsbhcounter", SqlDbType.Int,4),
					new SqlParameter("@lsbhdate", SqlDbType.DateTime),
					new SqlParameter("@scsj", SqlDbType.DateTime),
					new SqlParameter("@zjk", SqlDbType.Decimal,9),
					new SqlParameter("@zbjk", SqlDbType.Decimal,9),
					new SqlParameter("@xzsj", SqlDbType.DateTime),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scbz", SqlDbType.VarChar,50),
					new SqlParameter("@jsbtsj", SqlDbType.DateTime),
					new SqlParameter("@jsqtsj", SqlDbType.DateTime),
					new SqlParameter("@tjkffs", SqlDbType.Int,4),
					new SqlParameter("@xydwdate", SqlDbType.DateTime),
					new SqlParameter("@xydwcounter", SqlDbType.Int,4),
					new SqlParameter("@printzdpd", SqlDbType.Int,4),
					new SqlParameter("@hyjfrxpd", SqlDbType.Int,4),
					new SqlParameter("@eating_time", SqlDbType.Int,4),
					new SqlParameter("@xsws", SqlDbType.Int,4),
					new SqlParameter("@shlz", SqlDbType.Bit,1),
					new SqlParameter("@lsbhdfcounter", SqlDbType.Int,4),
					new SqlParameter("@lsbhdfdate", SqlDbType.DateTime),
					new SqlParameter("@ff_xfsj_rx", SqlDbType.Int,4),
					new SqlParameter("@ysk_pc", SqlDbType.Int,4),
					new SqlParameter("@ft_xs_krxm", SqlDbType.Bit,1),
					new SqlParameter("@ft_xs_fjjg", SqlDbType.Bit,1),
					new SqlParameter("@ft_auto_refresh", SqlDbType.Bit,1),
					new SqlParameter("@jz_ts", SqlDbType.Int,4),
					new SqlParameter("@jz_ls_total", SqlDbType.Decimal,5),
					new SqlParameter("@Hhygl_qyqr", SqlDbType.Bit,1),
					new SqlParameter("@VersionType", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.bh;
			parameters[3].Value = model.skydcounter;
			parameters[4].Value = model.skyddate;
			parameters[5].Value = model.skdjcounter;
			parameters[6].Value = model.skdjdate;
			parameters[7].Value = model.ttydcounter;
			parameters[8].Value = model.ttyddate;
			parameters[9].Value = model.lsttdjcounter;
			parameters[10].Value = model.ttdjdate;
			parameters[11].Value = model.ttdjcounter;
			parameters[12].Value = model.lfcounter;
			parameters[13].Value = model.lfdate;
			parameters[14].Value = model.gzcounter;
			parameters[15].Value = model.gzdate;
			parameters[16].Value = model.jzcounter;
			parameters[17].Value = model.jzdate;
			parameters[18].Value = model.szcounter;
			parameters[19].Value = model.szdate;
			parameters[20].Value = model.qs;
			parameters[21].Value = model.qsdate;
			parameters[22].Value = model.jbdate;
			parameters[23].Value = model.jbcounter;
			parameters[24].Value = model.zdpf;
			parameters[25].Value = model.shys;
			parameters[26].Value = model.zhbbsj;
			parameters[27].Value = model.txftsl;
			parameters[28].Value = model.shgz;
			parameters[29].Value = model.ybtqts;
			parameters[30].Value = model.hycounter;
			parameters[31].Value = model.hydate;
			parameters[32].Value = model.lsbhcounter;
			parameters[33].Value = model.lsbhdate;
			parameters[34].Value = model.scsj;
			parameters[35].Value = model.zjk;
			parameters[36].Value = model.zbjk;
			parameters[37].Value = model.xzsj;
			parameters[38].Value = model.shsc;
			parameters[39].Value = model.scbz;
			parameters[40].Value = model.jsbtsj;
			parameters[41].Value = model.jsqtsj;
			parameters[42].Value = model.tjkffs;
			parameters[43].Value = model.xydwdate;
			parameters[44].Value = model.xydwcounter;
			parameters[45].Value = model.printzdpd;
			parameters[46].Value = model.hyjfrxpd;
			parameters[47].Value = model.eating_time;
			parameters[48].Value = model.xsws;
			parameters[49].Value = model.shlz;
			parameters[50].Value = model.lsbhdfcounter;
			parameters[51].Value = model.lsbhdfdate;
			parameters[52].Value = model.ff_xfsj_rx;
			parameters[53].Value = model.ysk_pc;
			parameters[54].Value = model.ft_xs_krxm;
			parameters[55].Value = model.ft_xs_fjjg;
			parameters[56].Value = model.ft_auto_refresh;
			parameters[57].Value = model.jz_ts;
			parameters[58].Value = model.jz_ls_total;
			parameters[59].Value = model.Hhygl_qyqr;
			parameters[60].Value = model.VersionType;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Qcounter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Qcounter set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("bh=@bh,");
			strSql.Append("skydcounter=@skydcounter,");
			strSql.Append("skyddate=@skyddate,");
			strSql.Append("skdjcounter=@skdjcounter,");
			strSql.Append("skdjdate=@skdjdate,");
			strSql.Append("ttydcounter=@ttydcounter,");
			strSql.Append("ttyddate=@ttyddate,");
			strSql.Append("lsttdjcounter=@lsttdjcounter,");
			strSql.Append("ttdjdate=@ttdjdate,");
			strSql.Append("ttdjcounter=@ttdjcounter,");
			strSql.Append("lfcounter=@lfcounter,");
			strSql.Append("lfdate=@lfdate,");
			strSql.Append("gzcounter=@gzcounter,");
			strSql.Append("gzdate=@gzdate,");
			strSql.Append("jzcounter=@jzcounter,");
			strSql.Append("jzdate=@jzdate,");
			strSql.Append("szcounter=@szcounter,");
			strSql.Append("szdate=@szdate,");
			strSql.Append("qs=@qs,");
			strSql.Append("qsdate=@qsdate,");
			strSql.Append("jbdate=@jbdate,");
			strSql.Append("jbcounter=@jbcounter,");
			strSql.Append("zdpf=@zdpf,");
			strSql.Append("shys=@shys,");
			strSql.Append("zhbbsj=@zhbbsj,");
			strSql.Append("txftsl=@txftsl,");
			strSql.Append("shgz=@shgz,");
			strSql.Append("ybtqts=@ybtqts,");
			strSql.Append("hycounter=@hycounter,");
			strSql.Append("hydate=@hydate,");
			strSql.Append("lsbhcounter=@lsbhcounter,");
			strSql.Append("lsbhdate=@lsbhdate,");
			strSql.Append("scsj=@scsj,");
			strSql.Append("zjk=@zjk,");
			strSql.Append("zbjk=@zbjk,");
			strSql.Append("xzsj=@xzsj,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("scbz=@scbz,");
			strSql.Append("jsbtsj=@jsbtsj,");
			strSql.Append("jsqtsj=@jsqtsj,");
			strSql.Append("tjkffs=@tjkffs,");
			strSql.Append("xydwdate=@xydwdate,");
			strSql.Append("xydwcounter=@xydwcounter,");
			strSql.Append("printzdpd=@printzdpd,");
			strSql.Append("hyjfrxpd=@hyjfrxpd,");
			strSql.Append("eating_time=@eating_time,");
			strSql.Append("xsws=@xsws,");
			strSql.Append("shlz=@shlz,");
			strSql.Append("lsbhdfcounter=@lsbhdfcounter,");
			strSql.Append("lsbhdfdate=@lsbhdfdate,");
			strSql.Append("ff_xfsj_rx=@ff_xfsj_rx,");
			strSql.Append("ysk_pc=@ysk_pc,");
			strSql.Append("ft_xs_krxm=@ft_xs_krxm,");
			strSql.Append("ft_xs_fjjg=@ft_xs_fjjg,");
			strSql.Append("ft_auto_refresh=@ft_auto_refresh,");
			strSql.Append("jz_ts=@jz_ts,");
			strSql.Append("jz_ls_total=@jz_ls_total,");
			strSql.Append("Hhygl_qyqr=@Hhygl_qyqr,");
			strSql.Append("VersionType=@VersionType");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bh", SqlDbType.Int,4),
					new SqlParameter("@skydcounter", SqlDbType.Int,4),
					new SqlParameter("@skyddate", SqlDbType.DateTime),
					new SqlParameter("@skdjcounter", SqlDbType.Int,4),
					new SqlParameter("@skdjdate", SqlDbType.DateTime),
					new SqlParameter("@ttydcounter", SqlDbType.Int,4),
					new SqlParameter("@ttyddate", SqlDbType.DateTime),
					new SqlParameter("@lsttdjcounter", SqlDbType.Int,4),
					new SqlParameter("@ttdjdate", SqlDbType.DateTime),
					new SqlParameter("@ttdjcounter", SqlDbType.Int,4),
					new SqlParameter("@lfcounter", SqlDbType.Int,4),
					new SqlParameter("@lfdate", SqlDbType.DateTime),
					new SqlParameter("@gzcounter", SqlDbType.Int,4),
					new SqlParameter("@gzdate", SqlDbType.DateTime),
					new SqlParameter("@jzcounter", SqlDbType.Int,4),
					new SqlParameter("@jzdate", SqlDbType.DateTime),
					new SqlParameter("@szcounter", SqlDbType.Int,4),
					new SqlParameter("@szdate", SqlDbType.DateTime),
					new SqlParameter("@qs", SqlDbType.Int,4),
					new SqlParameter("@qsdate", SqlDbType.DateTime),
					new SqlParameter("@jbdate", SqlDbType.DateTime),
					new SqlParameter("@jbcounter", SqlDbType.Int,4),
					new SqlParameter("@zdpf", SqlDbType.Bit,1),
					new SqlParameter("@shys", SqlDbType.Bit,1),
					new SqlParameter("@zhbbsj", SqlDbType.DateTime),
					new SqlParameter("@txftsl", SqlDbType.Int,4),
					new SqlParameter("@shgz", SqlDbType.Int,4),
					new SqlParameter("@ybtqts", SqlDbType.Int,4),
					new SqlParameter("@hycounter", SqlDbType.Int,4),
					new SqlParameter("@hydate", SqlDbType.DateTime),
					new SqlParameter("@lsbhcounter", SqlDbType.Int,4),
					new SqlParameter("@lsbhdate", SqlDbType.DateTime),
					new SqlParameter("@scsj", SqlDbType.DateTime),
					new SqlParameter("@zjk", SqlDbType.Decimal,9),
					new SqlParameter("@zbjk", SqlDbType.Decimal,9),
					new SqlParameter("@xzsj", SqlDbType.DateTime),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scbz", SqlDbType.VarChar,50),
					new SqlParameter("@jsbtsj", SqlDbType.DateTime),
					new SqlParameter("@jsqtsj", SqlDbType.DateTime),
					new SqlParameter("@tjkffs", SqlDbType.Int,4),
					new SqlParameter("@xydwdate", SqlDbType.DateTime),
					new SqlParameter("@xydwcounter", SqlDbType.Int,4),
					new SqlParameter("@printzdpd", SqlDbType.Int,4),
					new SqlParameter("@hyjfrxpd", SqlDbType.Int,4),
					new SqlParameter("@eating_time", SqlDbType.Int,4),
					new SqlParameter("@xsws", SqlDbType.Int,4),
					new SqlParameter("@shlz", SqlDbType.Bit,1),
					new SqlParameter("@lsbhdfcounter", SqlDbType.Int,4),
					new SqlParameter("@lsbhdfdate", SqlDbType.DateTime),
					new SqlParameter("@ff_xfsj_rx", SqlDbType.Int,4),
					new SqlParameter("@ysk_pc", SqlDbType.Int,4),
					new SqlParameter("@ft_xs_krxm", SqlDbType.Bit,1),
					new SqlParameter("@ft_xs_fjjg", SqlDbType.Bit,1),
					new SqlParameter("@ft_auto_refresh", SqlDbType.Bit,1),
					new SqlParameter("@jz_ts", SqlDbType.Int,4),
					new SqlParameter("@jz_ls_total", SqlDbType.Decimal,5),
					new SqlParameter("@Hhygl_qyqr", SqlDbType.Bit,1),
					new SqlParameter("@VersionType", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.bh;
			parameters[3].Value = model.skydcounter;
			parameters[4].Value = model.skyddate;
			parameters[5].Value = model.skdjcounter;
			parameters[6].Value = model.skdjdate;
			parameters[7].Value = model.ttydcounter;
			parameters[8].Value = model.ttyddate;
			parameters[9].Value = model.lsttdjcounter;
			parameters[10].Value = model.ttdjdate;
			parameters[11].Value = model.ttdjcounter;
			parameters[12].Value = model.lfcounter;
			parameters[13].Value = model.lfdate;
			parameters[14].Value = model.gzcounter;
			parameters[15].Value = model.gzdate;
			parameters[16].Value = model.jzcounter;
			parameters[17].Value = model.jzdate;
			parameters[18].Value = model.szcounter;
			parameters[19].Value = model.szdate;
			parameters[20].Value = model.qs;
			parameters[21].Value = model.qsdate;
			parameters[22].Value = model.jbdate;
			parameters[23].Value = model.jbcounter;
			parameters[24].Value = model.zdpf;
			parameters[25].Value = model.shys;
			parameters[26].Value = model.zhbbsj;
			parameters[27].Value = model.txftsl;
			parameters[28].Value = model.shgz;
			parameters[29].Value = model.ybtqts;
			parameters[30].Value = model.hycounter;
			parameters[31].Value = model.hydate;
			parameters[32].Value = model.lsbhcounter;
			parameters[33].Value = model.lsbhdate;
			parameters[34].Value = model.scsj;
			parameters[35].Value = model.zjk;
			parameters[36].Value = model.zbjk;
			parameters[37].Value = model.xzsj;
			parameters[38].Value = model.shsc;
			parameters[39].Value = model.scbz;
			parameters[40].Value = model.jsbtsj;
			parameters[41].Value = model.jsqtsj;
			parameters[42].Value = model.tjkffs;
			parameters[43].Value = model.xydwdate;
			parameters[44].Value = model.xydwcounter;
			parameters[45].Value = model.printzdpd;
			parameters[46].Value = model.hyjfrxpd;
			parameters[47].Value = model.eating_time;
			parameters[48].Value = model.xsws;
			parameters[49].Value = model.shlz;
			parameters[50].Value = model.lsbhdfcounter;
			parameters[51].Value = model.lsbhdfdate;
			parameters[52].Value = model.ff_xfsj_rx;
			parameters[53].Value = model.ysk_pc;
			parameters[54].Value = model.ft_xs_krxm;
			parameters[55].Value = model.ft_xs_fjjg;
			parameters[56].Value = model.ft_auto_refresh;
			parameters[57].Value = model.jz_ts;
			parameters[58].Value = model.jz_ls_total;
			parameters[59].Value = model.Hhygl_qyqr;
			parameters[60].Value = model.VersionType;
			parameters[61].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Qcounter ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Qcounter ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Hotel_app.Model.Qcounter GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,yydh,qymc,bh,skydcounter,skyddate,skdjcounter,skdjdate,ttydcounter,ttyddate,lsttdjcounter,ttdjdate,ttdjcounter,lfcounter,lfdate,gzcounter,gzdate,jzcounter,jzdate,szcounter,szdate,qs,qsdate,jbdate,jbcounter,zdpf,shys,zhbbsj,txftsl,shgz,ybtqts,hycounter,hydate,lsbhcounter,lsbhdate,scsj,zjk,zbjk,xzsj,shsc,scbz,jsbtsj,jsqtsj,tjkffs,xydwdate,xydwcounter,printzdpd,hyjfrxpd,eating_time,xsws,shlz,lsbhdfcounter,lsbhdfdate,ff_xfsj_rx,ysk_pc,ft_xs_krxm,ft_xs_fjjg,ft_auto_refresh,jz_ts,jz_ls_total,Hhygl_qyqr,VersionType from Qcounter ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Hotel_app.Model.Qcounter model=new Hotel_app.Model.Qcounter();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bh"]!=null && ds.Tables[0].Rows[0]["bh"].ToString()!="")
				{
					model.bh=int.Parse(ds.Tables[0].Rows[0]["bh"].ToString());
				}
				if(ds.Tables[0].Rows[0]["skydcounter"]!=null && ds.Tables[0].Rows[0]["skydcounter"].ToString()!="")
				{
					model.skydcounter=int.Parse(ds.Tables[0].Rows[0]["skydcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["skyddate"]!=null && ds.Tables[0].Rows[0]["skyddate"].ToString()!="")
				{
					model.skyddate=DateTime.Parse(ds.Tables[0].Rows[0]["skyddate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["skdjcounter"]!=null && ds.Tables[0].Rows[0]["skdjcounter"].ToString()!="")
				{
					model.skdjcounter=int.Parse(ds.Tables[0].Rows[0]["skdjcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["skdjdate"]!=null && ds.Tables[0].Rows[0]["skdjdate"].ToString()!="")
				{
					model.skdjdate=DateTime.Parse(ds.Tables[0].Rows[0]["skdjdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ttydcounter"]!=null && ds.Tables[0].Rows[0]["ttydcounter"].ToString()!="")
				{
					model.ttydcounter=int.Parse(ds.Tables[0].Rows[0]["ttydcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ttyddate"]!=null && ds.Tables[0].Rows[0]["ttyddate"].ToString()!="")
				{
					model.ttyddate=DateTime.Parse(ds.Tables[0].Rows[0]["ttyddate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lsttdjcounter"]!=null && ds.Tables[0].Rows[0]["lsttdjcounter"].ToString()!="")
				{
					model.lsttdjcounter=int.Parse(ds.Tables[0].Rows[0]["lsttdjcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ttdjdate"]!=null && ds.Tables[0].Rows[0]["ttdjdate"].ToString()!="")
				{
					model.ttdjdate=DateTime.Parse(ds.Tables[0].Rows[0]["ttdjdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ttdjcounter"]!=null && ds.Tables[0].Rows[0]["ttdjcounter"].ToString()!="")
				{
					model.ttdjcounter=int.Parse(ds.Tables[0].Rows[0]["ttdjcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lfcounter"]!=null && ds.Tables[0].Rows[0]["lfcounter"].ToString()!="")
				{
					model.lfcounter=int.Parse(ds.Tables[0].Rows[0]["lfcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lfdate"]!=null && ds.Tables[0].Rows[0]["lfdate"].ToString()!="")
				{
					model.lfdate=DateTime.Parse(ds.Tables[0].Rows[0]["lfdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gzcounter"]!=null && ds.Tables[0].Rows[0]["gzcounter"].ToString()!="")
				{
					model.gzcounter=int.Parse(ds.Tables[0].Rows[0]["gzcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gzdate"]!=null && ds.Tables[0].Rows[0]["gzdate"].ToString()!="")
				{
					model.gzdate=DateTime.Parse(ds.Tables[0].Rows[0]["gzdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jzcounter"]!=null && ds.Tables[0].Rows[0]["jzcounter"].ToString()!="")
				{
					model.jzcounter=int.Parse(ds.Tables[0].Rows[0]["jzcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jzdate"]!=null && ds.Tables[0].Rows[0]["jzdate"].ToString()!="")
				{
					model.jzdate=DateTime.Parse(ds.Tables[0].Rows[0]["jzdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["szcounter"]!=null && ds.Tables[0].Rows[0]["szcounter"].ToString()!="")
				{
					model.szcounter=int.Parse(ds.Tables[0].Rows[0]["szcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["szdate"]!=null && ds.Tables[0].Rows[0]["szdate"].ToString()!="")
				{
					model.szdate=DateTime.Parse(ds.Tables[0].Rows[0]["szdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qs"]!=null && ds.Tables[0].Rows[0]["qs"].ToString()!="")
				{
					model.qs=int.Parse(ds.Tables[0].Rows[0]["qs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qsdate"]!=null && ds.Tables[0].Rows[0]["qsdate"].ToString()!="")
				{
					model.qsdate=DateTime.Parse(ds.Tables[0].Rows[0]["qsdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jbdate"]!=null && ds.Tables[0].Rows[0]["jbdate"].ToString()!="")
				{
					model.jbdate=DateTime.Parse(ds.Tables[0].Rows[0]["jbdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jbcounter"]!=null && ds.Tables[0].Rows[0]["jbcounter"].ToString()!="")
				{
					model.jbcounter=int.Parse(ds.Tables[0].Rows[0]["jbcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zdpf"]!=null && ds.Tables[0].Rows[0]["zdpf"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["zdpf"].ToString()=="1")||(ds.Tables[0].Rows[0]["zdpf"].ToString().ToLower()=="true"))
					{
						model.zdpf=true;
					}
					else
					{
						model.zdpf=false;
					}
				}
				if(ds.Tables[0].Rows[0]["shys"]!=null && ds.Tables[0].Rows[0]["shys"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shys"].ToString()=="1")||(ds.Tables[0].Rows[0]["shys"].ToString().ToLower()=="true"))
					{
						model.shys=true;
					}
					else
					{
						model.shys=false;
					}
				}
				if(ds.Tables[0].Rows[0]["zhbbsj"]!=null && ds.Tables[0].Rows[0]["zhbbsj"].ToString()!="")
				{
					model.zhbbsj=DateTime.Parse(ds.Tables[0].Rows[0]["zhbbsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["txftsl"]!=null && ds.Tables[0].Rows[0]["txftsl"].ToString()!="")
				{
					model.txftsl=int.Parse(ds.Tables[0].Rows[0]["txftsl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["shgz"]!=null && ds.Tables[0].Rows[0]["shgz"].ToString()!="")
				{
					model.shgz=int.Parse(ds.Tables[0].Rows[0]["shgz"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ybtqts"]!=null && ds.Tables[0].Rows[0]["ybtqts"].ToString()!="")
				{
					model.ybtqts=int.Parse(ds.Tables[0].Rows[0]["ybtqts"].ToString());
				}
				if(ds.Tables[0].Rows[0]["hycounter"]!=null && ds.Tables[0].Rows[0]["hycounter"].ToString()!="")
				{
					model.hycounter=int.Parse(ds.Tables[0].Rows[0]["hycounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["hydate"]!=null && ds.Tables[0].Rows[0]["hydate"].ToString()!="")
				{
					model.hydate=DateTime.Parse(ds.Tables[0].Rows[0]["hydate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lsbhcounter"]!=null && ds.Tables[0].Rows[0]["lsbhcounter"].ToString()!="")
				{
					model.lsbhcounter=int.Parse(ds.Tables[0].Rows[0]["lsbhcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lsbhdate"]!=null && ds.Tables[0].Rows[0]["lsbhdate"].ToString()!="")
				{
					model.lsbhdate=DateTime.Parse(ds.Tables[0].Rows[0]["lsbhdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["scsj"]!=null && ds.Tables[0].Rows[0]["scsj"].ToString()!="")
				{
					model.scsj=DateTime.Parse(ds.Tables[0].Rows[0]["scsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zjk"]!=null && ds.Tables[0].Rows[0]["zjk"].ToString()!="")
				{
					model.zjk=decimal.Parse(ds.Tables[0].Rows[0]["zjk"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zbjk"]!=null && ds.Tables[0].Rows[0]["zbjk"].ToString()!="")
				{
					model.zbjk=decimal.Parse(ds.Tables[0].Rows[0]["zbjk"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xzsj"]!=null && ds.Tables[0].Rows[0]["xzsj"].ToString()!="")
				{
					model.xzsj=DateTime.Parse(ds.Tables[0].Rows[0]["xzsj"].ToString());
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
				if(ds.Tables[0].Rows[0]["scbz"]!=null && ds.Tables[0].Rows[0]["scbz"].ToString()!="")
				{
					model.scbz=ds.Tables[0].Rows[0]["scbz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jsbtsj"]!=null && ds.Tables[0].Rows[0]["jsbtsj"].ToString()!="")
				{
					model.jsbtsj=DateTime.Parse(ds.Tables[0].Rows[0]["jsbtsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jsqtsj"]!=null && ds.Tables[0].Rows[0]["jsqtsj"].ToString()!="")
				{
					model.jsqtsj=DateTime.Parse(ds.Tables[0].Rows[0]["jsqtsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tjkffs"]!=null && ds.Tables[0].Rows[0]["tjkffs"].ToString()!="")
				{
					model.tjkffs=int.Parse(ds.Tables[0].Rows[0]["tjkffs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xydwdate"]!=null && ds.Tables[0].Rows[0]["xydwdate"].ToString()!="")
				{
					model.xydwdate=DateTime.Parse(ds.Tables[0].Rows[0]["xydwdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xydwcounter"]!=null && ds.Tables[0].Rows[0]["xydwcounter"].ToString()!="")
				{
					model.xydwcounter=int.Parse(ds.Tables[0].Rows[0]["xydwcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["printzdpd"]!=null && ds.Tables[0].Rows[0]["printzdpd"].ToString()!="")
				{
					model.printzdpd=int.Parse(ds.Tables[0].Rows[0]["printzdpd"].ToString());
				}
				if(ds.Tables[0].Rows[0]["hyjfrxpd"]!=null && ds.Tables[0].Rows[0]["hyjfrxpd"].ToString()!="")
				{
					model.hyjfrxpd=int.Parse(ds.Tables[0].Rows[0]["hyjfrxpd"].ToString());
				}
				if(ds.Tables[0].Rows[0]["eating_time"]!=null && ds.Tables[0].Rows[0]["eating_time"].ToString()!="")
				{
					model.eating_time=int.Parse(ds.Tables[0].Rows[0]["eating_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xsws"]!=null && ds.Tables[0].Rows[0]["xsws"].ToString()!="")
				{
					model.xsws=int.Parse(ds.Tables[0].Rows[0]["xsws"].ToString());
				}
				if(ds.Tables[0].Rows[0]["shlz"]!=null && ds.Tables[0].Rows[0]["shlz"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shlz"].ToString()=="1")||(ds.Tables[0].Rows[0]["shlz"].ToString().ToLower()=="true"))
					{
						model.shlz=true;
					}
					else
					{
						model.shlz=false;
					}
				}
				if(ds.Tables[0].Rows[0]["lsbhdfcounter"]!=null && ds.Tables[0].Rows[0]["lsbhdfcounter"].ToString()!="")
				{
					model.lsbhdfcounter=int.Parse(ds.Tables[0].Rows[0]["lsbhdfcounter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lsbhdfdate"]!=null && ds.Tables[0].Rows[0]["lsbhdfdate"].ToString()!="")
				{
					model.lsbhdfdate=DateTime.Parse(ds.Tables[0].Rows[0]["lsbhdfdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ff_xfsj_rx"]!=null && ds.Tables[0].Rows[0]["ff_xfsj_rx"].ToString()!="")
				{
					model.ff_xfsj_rx=int.Parse(ds.Tables[0].Rows[0]["ff_xfsj_rx"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ysk_pc"]!=null && ds.Tables[0].Rows[0]["ysk_pc"].ToString()!="")
				{
					model.ysk_pc=int.Parse(ds.Tables[0].Rows[0]["ysk_pc"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ft_xs_krxm"]!=null && ds.Tables[0].Rows[0]["ft_xs_krxm"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ft_xs_krxm"].ToString()=="1")||(ds.Tables[0].Rows[0]["ft_xs_krxm"].ToString().ToLower()=="true"))
					{
						model.ft_xs_krxm=true;
					}
					else
					{
						model.ft_xs_krxm=false;
					}
				}
				if(ds.Tables[0].Rows[0]["ft_xs_fjjg"]!=null && ds.Tables[0].Rows[0]["ft_xs_fjjg"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ft_xs_fjjg"].ToString()=="1")||(ds.Tables[0].Rows[0]["ft_xs_fjjg"].ToString().ToLower()=="true"))
					{
						model.ft_xs_fjjg=true;
					}
					else
					{
						model.ft_xs_fjjg=false;
					}
				}
				if(ds.Tables[0].Rows[0]["ft_auto_refresh"]!=null && ds.Tables[0].Rows[0]["ft_auto_refresh"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ft_auto_refresh"].ToString()=="1")||(ds.Tables[0].Rows[0]["ft_auto_refresh"].ToString().ToLower()=="true"))
					{
						model.ft_auto_refresh=true;
					}
					else
					{
						model.ft_auto_refresh=false;
					}
				}
				if(ds.Tables[0].Rows[0]["jz_ts"]!=null && ds.Tables[0].Rows[0]["jz_ts"].ToString()!="")
				{
					model.jz_ts=int.Parse(ds.Tables[0].Rows[0]["jz_ts"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jz_ls_total"]!=null && ds.Tables[0].Rows[0]["jz_ls_total"].ToString()!="")
				{
					model.jz_ls_total=decimal.Parse(ds.Tables[0].Rows[0]["jz_ls_total"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Hhygl_qyqr"]!=null && ds.Tables[0].Rows[0]["Hhygl_qyqr"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Hhygl_qyqr"].ToString()=="1")||(ds.Tables[0].Rows[0]["Hhygl_qyqr"].ToString().ToLower()=="true"))
					{
						model.Hhygl_qyqr=true;
					}
					else
					{
						model.Hhygl_qyqr=false;
					}
				}
				if(ds.Tables[0].Rows[0]["VersionType"]!=null && ds.Tables[0].Rows[0]["VersionType"].ToString()!="")
				{
					model.VersionType=ds.Tables[0].Rows[0]["VersionType"].ToString();
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
			strSql.Append("select ID,yydh,qymc,bh,skydcounter,skyddate,skdjcounter,skdjdate,ttydcounter,ttyddate,lsttdjcounter,ttdjdate,ttdjcounter,lfcounter,lfdate,gzcounter,gzdate,jzcounter,jzdate,szcounter,szdate,qs,qsdate,jbdate,jbcounter,zdpf,shys,zhbbsj,txftsl,shgz,ybtqts,hycounter,hydate,lsbhcounter,lsbhdate,scsj,zjk,zbjk,xzsj,shsc,scbz,jsbtsj,jsqtsj,tjkffs,xydwdate,xydwcounter,printzdpd,hyjfrxpd,eating_time,xsws,shlz,lsbhdfcounter,lsbhdfdate,ff_xfsj_rx,ysk_pc,ft_xs_krxm,ft_xs_fjjg,ft_auto_refresh,jz_ts,jz_ls_total,Hhygl_qyqr,VersionType ");
			strSql.Append(" FROM Qcounter ");
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
			strSql.Append(" ID,yydh,qymc,bh,skydcounter,skyddate,skdjcounter,skdjdate,ttydcounter,ttyddate,lsttdjcounter,ttdjdate,ttdjcounter,lfcounter,lfdate,gzcounter,gzdate,jzcounter,jzdate,szcounter,szdate,qs,qsdate,jbdate,jbcounter,zdpf,shys,zhbbsj,txftsl,shgz,ybtqts,hycounter,hydate,lsbhcounter,lsbhdate,scsj,zjk,zbjk,xzsj,shsc,scbz,jsbtsj,jsqtsj,tjkffs,xydwdate,xydwcounter,printzdpd,hyjfrxpd,eating_time,xsws,shlz,lsbhdfcounter,lsbhdfdate,ff_xfsj_rx,ysk_pc,ft_xs_krxm,ft_xs_fjjg,ft_auto_refresh,jz_ts,jz_ls_total,Hhygl_qyqr,VersionType ");
			strSql.Append(" FROM Qcounter ");
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
			strSql.Append("select count(1) FROM Qcounter ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Qcounter T ");
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
			parameters[0].Value = "Qcounter";
			parameters[1].Value = "ID";
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

