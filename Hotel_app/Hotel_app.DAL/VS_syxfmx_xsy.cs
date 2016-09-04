using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:VS_syxfmx_xsy
	/// </summary>
	public partial class VS_syxfmx_xsy
	{
		public VS_syxfmx_xsy()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.VS_syxfmx_xsy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VS_syxfmx_xsy(");
			strSql.Append("xsy,id,yydh,qymc,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,jjje,xfje,sjxfje,xfsl,krly,yxzj,zjhm,krsj,xyh,xydw,krgj,hykh,pq,gj_sf,gj_cs,gj_dq,xsy_sl,id_app,jzbh,lsbh,Expr2,Expr3,mxbh,ddsj,lksj,czsj)");
			strSql.Append(" values (");
			strSql.Append("@xsy,@id,@yydh,@qymc,@krxm,@fjrb,@fjbh,@sktt,@xfrq,@xfsj,@czy,@xfdr,@xfrb,@xfxm,@jjje,@xfje,@sjxfje,@xfsl,@krly,@yxzj,@zjhm,@krsj,@xyh,@xydw,@krgj,@hykh,@pq,@gj_sf,@gj_cs,@gj_dq,@xsy_sl,@id_app,@jzbh,@lsbh,@Expr2,@Expr3,@mxbh,@ddsj,@lksj,@czsj)");
			SqlParameter[] parameters = {
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@jjje", SqlDbType.Decimal,17),
					new SqlParameter("@xfje", SqlDbType.Decimal,17),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,17),
					new SqlParameter("@xfsl", SqlDbType.Decimal,17),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@gj_sf", SqlDbType.VarChar,50),
					new SqlParameter("@gj_cs", SqlDbType.VarChar,50),
					new SqlParameter("@gj_dq", SqlDbType.VarChar,50),
					new SqlParameter("@xsy_sl", SqlDbType.Int,4),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@Expr2", SqlDbType.Decimal,9),
					new SqlParameter("@Expr3", SqlDbType.Decimal,9),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime)};
			parameters[0].Value = model.xsy;
			parameters[1].Value = model.id;
			parameters[2].Value = model.yydh;
			parameters[3].Value = model.qymc;
			parameters[4].Value = model.krxm;
			parameters[5].Value = model.fjrb;
			parameters[6].Value = model.fjbh;
			parameters[7].Value = model.sktt;
			parameters[8].Value = model.xfrq;
			parameters[9].Value = model.xfsj;
			parameters[10].Value = model.czy;
			parameters[11].Value = model.xfdr;
			parameters[12].Value = model.xfrb;
			parameters[13].Value = model.xfxm;
			parameters[14].Value = model.jjje;
			parameters[15].Value = model.xfje;
			parameters[16].Value = model.sjxfje;
			parameters[17].Value = model.xfsl;
			parameters[18].Value = model.krly;
			parameters[19].Value = model.yxzj;
			parameters[20].Value = model.zjhm;
			parameters[21].Value = model.krsj;
			parameters[22].Value = model.xyh;
			parameters[23].Value = model.xydw;
			parameters[24].Value = model.krgj;
			parameters[25].Value = model.hykh;
			parameters[26].Value = model.pq;
			parameters[27].Value = model.gj_sf;
			parameters[28].Value = model.gj_cs;
			parameters[29].Value = model.gj_dq;
			parameters[30].Value = model.xsy_sl;
			parameters[31].Value = model.id_app;
			parameters[32].Value = model.jzbh;
			parameters[33].Value = model.lsbh;
			parameters[34].Value = model.Expr2;
			parameters[35].Value = model.Expr3;
			parameters[36].Value = model.mxbh;
			parameters[37].Value = model.ddsj;
			parameters[38].Value = model.lksj;
			parameters[39].Value = model.czsj;

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
		public bool Update(Hotel_app.Model.VS_syxfmx_xsy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VS_syxfmx_xsy set ");
			strSql.Append("xsy=@xsy,");
			strSql.Append("id=@id,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("xfrq=@xfrq,");
			strSql.Append("xfsj=@xfsj,");
			strSql.Append("czy=@czy,");
			strSql.Append("xfdr=@xfdr,");
			strSql.Append("xfrb=@xfrb,");
			strSql.Append("xfxm=@xfxm,");
			strSql.Append("jjje=@jjje,");
			strSql.Append("xfje=@xfje,");
			strSql.Append("sjxfje=@sjxfje,");
			strSql.Append("xfsl=@xfsl,");
			strSql.Append("krly=@krly,");
			strSql.Append("yxzj=@yxzj,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("krsj=@krsj,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("pq=@pq,");
			strSql.Append("gj_sf=@gj_sf,");
			strSql.Append("gj_cs=@gj_cs,");
			strSql.Append("gj_dq=@gj_dq,");
			strSql.Append("xsy_sl=@xsy_sl,");
			strSql.Append("id_app=@id_app,");
			strSql.Append("jzbh=@jzbh,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("Expr2=@Expr2,");
			strSql.Append("Expr3=@Expr3,");
			strSql.Append("mxbh=@mxbh,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("czsj=@czsj");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@jjje", SqlDbType.Decimal,17),
					new SqlParameter("@xfje", SqlDbType.Decimal,17),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,17),
					new SqlParameter("@xfsl", SqlDbType.Decimal,17),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@gj_sf", SqlDbType.VarChar,50),
					new SqlParameter("@gj_cs", SqlDbType.VarChar,50),
					new SqlParameter("@gj_dq", SqlDbType.VarChar,50),
					new SqlParameter("@xsy_sl", SqlDbType.Int,4),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@Expr2", SqlDbType.Decimal,9),
					new SqlParameter("@Expr3", SqlDbType.Decimal,9),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime)};
			parameters[0].Value = model.xsy;
			parameters[1].Value = model.id;
			parameters[2].Value = model.yydh;
			parameters[3].Value = model.qymc;
			parameters[4].Value = model.krxm;
			parameters[5].Value = model.fjrb;
			parameters[6].Value = model.fjbh;
			parameters[7].Value = model.sktt;
			parameters[8].Value = model.xfrq;
			parameters[9].Value = model.xfsj;
			parameters[10].Value = model.czy;
			parameters[11].Value = model.xfdr;
			parameters[12].Value = model.xfrb;
			parameters[13].Value = model.xfxm;
			parameters[14].Value = model.jjje;
			parameters[15].Value = model.xfje;
			parameters[16].Value = model.sjxfje;
			parameters[17].Value = model.xfsl;
			parameters[18].Value = model.krly;
			parameters[19].Value = model.yxzj;
			parameters[20].Value = model.zjhm;
			parameters[21].Value = model.krsj;
			parameters[22].Value = model.xyh;
			parameters[23].Value = model.xydw;
			parameters[24].Value = model.krgj;
			parameters[25].Value = model.hykh;
			parameters[26].Value = model.pq;
			parameters[27].Value = model.gj_sf;
			parameters[28].Value = model.gj_cs;
			parameters[29].Value = model.gj_dq;
			parameters[30].Value = model.xsy_sl;
			parameters[31].Value = model.id_app;
			parameters[32].Value = model.jzbh;
			parameters[33].Value = model.lsbh;
			parameters[34].Value = model.Expr2;
			parameters[35].Value = model.Expr3;
			parameters[36].Value = model.mxbh;
			parameters[37].Value = model.ddsj;
			parameters[38].Value = model.lksj;
			parameters[39].Value = model.czsj;

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
			strSql.Append("delete from VS_syxfmx_xsy ");
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
		public Hotel_app.Model.VS_syxfmx_xsy GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 xsy,id,yydh,qymc,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,jjje,xfje,sjxfje,xfsl,krly,yxzj,zjhm,krsj,xyh,xydw,krgj,hykh,pq,gj_sf,gj_cs,gj_dq,xsy_sl,id_app,jzbh,lsbh,Expr2,Expr3,mxbh,ddsj,lksj,czsj from VS_syxfmx_xsy ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.VS_syxfmx_xsy model=new Hotel_app.Model.VS_syxfmx_xsy();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["xsy"]!=null && ds.Tables[0].Rows[0]["xsy"].ToString()!="")
				{
					model.xsy=ds.Tables[0].Rows[0]["xsy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfrq"]!=null && ds.Tables[0].Rows[0]["xfrq"].ToString()!="")
				{
					model.xfrq=DateTime.Parse(ds.Tables[0].Rows[0]["xfrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfsj"]!=null && ds.Tables[0].Rows[0]["xfsj"].ToString()!="")
				{
					model.xfsj=DateTime.Parse(ds.Tables[0].Rows[0]["xfsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfdr"]!=null && ds.Tables[0].Rows[0]["xfdr"].ToString()!="")
				{
					model.xfdr=ds.Tables[0].Rows[0]["xfdr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfrb"]!=null && ds.Tables[0].Rows[0]["xfrb"].ToString()!="")
				{
					model.xfrb=ds.Tables[0].Rows[0]["xfrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfxm"]!=null && ds.Tables[0].Rows[0]["xfxm"].ToString()!="")
				{
					model.xfxm=ds.Tables[0].Rows[0]["xfxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jjje"]!=null && ds.Tables[0].Rows[0]["jjje"].ToString()!="")
				{
					model.jjje=decimal.Parse(ds.Tables[0].Rows[0]["jjje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje"]!=null && ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sjxfje"]!=null && ds.Tables[0].Rows[0]["sjxfje"].ToString()!="")
				{
					model.sjxfje=decimal.Parse(ds.Tables[0].Rows[0]["sjxfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfsl"]!=null && ds.Tables[0].Rows[0]["xfsl"].ToString()!="")
				{
					model.xfsl=decimal.Parse(ds.Tables[0].Rows[0]["xfsl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yxzj"]!=null && ds.Tables[0].Rows[0]["yxzj"].ToString()!="")
				{
					model.yxzj=ds.Tables[0].Rows[0]["yxzj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsj"]!=null && ds.Tables[0].Rows[0]["krsj"].ToString()!="")
				{
					model.krsj=ds.Tables[0].Rows[0]["krsj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh"]!=null && ds.Tables[0].Rows[0]["xyh"].ToString()!="")
				{
					model.xyh=ds.Tables[0].Rows[0]["xyh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krgj"]!=null && ds.Tables[0].Rows[0]["krgj"].ToString()!="")
				{
					model.krgj=ds.Tables[0].Rows[0]["krgj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pq"]!=null && ds.Tables[0].Rows[0]["pq"].ToString()!="")
				{
					model.pq=ds.Tables[0].Rows[0]["pq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gj_sf"]!=null && ds.Tables[0].Rows[0]["gj_sf"].ToString()!="")
				{
					model.gj_sf=ds.Tables[0].Rows[0]["gj_sf"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gj_cs"]!=null && ds.Tables[0].Rows[0]["gj_cs"].ToString()!="")
				{
					model.gj_cs=ds.Tables[0].Rows[0]["gj_cs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gj_dq"]!=null && ds.Tables[0].Rows[0]["gj_dq"].ToString()!="")
				{
					model.gj_dq=ds.Tables[0].Rows[0]["gj_dq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xsy_sl"]!=null && ds.Tables[0].Rows[0]["xsy_sl"].ToString()!="")
				{
					model.xsy_sl=int.Parse(ds.Tables[0].Rows[0]["xsy_sl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["id_app"]!=null && ds.Tables[0].Rows[0]["id_app"].ToString()!="")
				{
					model.id_app=ds.Tables[0].Rows[0]["id_app"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jzbh"]!=null && ds.Tables[0].Rows[0]["jzbh"].ToString()!="")
				{
					model.jzbh=ds.Tables[0].Rows[0]["jzbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Expr2"]!=null && ds.Tables[0].Rows[0]["Expr2"].ToString()!="")
				{
					model.Expr2=decimal.Parse(ds.Tables[0].Rows[0]["Expr2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Expr3"]!=null && ds.Tables[0].Rows[0]["Expr3"].ToString()!="")
				{
					model.Expr3=decimal.Parse(ds.Tables[0].Rows[0]["Expr3"].ToString());
				}
				if(ds.Tables[0].Rows[0]["mxbh"]!=null && ds.Tables[0].Rows[0]["mxbh"].ToString()!="")
				{
					model.mxbh=ds.Tables[0].Rows[0]["mxbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
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
			strSql.Append("select xsy,id,yydh,qymc,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,jjje,xfje,sjxfje,xfsl,krly,yxzj,zjhm,krsj,xyh,xydw,krgj,hykh,pq,gj_sf,gj_cs,gj_dq,xsy_sl,id_app,jzbh,lsbh,Expr2,Expr3,mxbh,ddsj,lksj,czsj ");
			strSql.Append(" FROM VS_syxfmx_xsy ");
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
			strSql.Append(" xsy,id,yydh,qymc,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,jjje,xfje,sjxfje,xfsl,krly,yxzj,zjhm,krsj,xyh,xydw,krgj,hykh,pq,gj_sf,gj_cs,gj_dq,xsy_sl,id_app,jzbh,lsbh,Expr2,Expr3,mxbh,ddsj,lksj,czsj ");
			strSql.Append(" FROM VS_syxfmx_xsy ");
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
			strSql.Append("select count(1) FROM VS_syxfmx_xsy ");
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
			strSql.Append(")AS Row, T.*  from VS_syxfmx_xsy T ");
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
			parameters[0].Value = "VS_syxfmx_xsy";
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

