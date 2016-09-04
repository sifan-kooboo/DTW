using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:VS_syxfmx_cz
	/// </summary>
	public partial class VS_syxfmx_cz
	{
		public VS_syxfmx_cz()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.VS_syxfmx_cz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VS_syxfmx_cz(");
			strSql.Append("yydh,id,qymc,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,jjje,sjxfje,xfsl,mxbh,zjhm,yxzj,krly,xydw,xyh,krsj,hykh,krgj,pq,gj_sf,gj_cs,gj_dq,id_app,jzbh,lsbh,xsy,xfzy,xfbz,ddsj,lksj,czsj)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@id,@qymc,@krxm,@fjrb,@fjbh,@sktt,@xfrq,@xfsj,@czy,@xfdr,@xfrb,@xfxm,@jjje,@sjxfje,@xfsl,@mxbh,@zjhm,@yxzj,@krly,@xydw,@xyh,@krsj,@hykh,@krgj,@pq,@gj_sf,@gj_cs,@gj_dq,@id_app,@jzbh,@lsbh,@xsy,@xfzy,@xfbz,@ddsj,@lksj,@czsj)");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
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
					new SqlParameter("@jjje", SqlDbType.Decimal,9),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@gj_sf", SqlDbType.VarChar,50),
					new SqlParameter("@gj_cs", SqlDbType.VarChar,50),
					new SqlParameter("@gj_dq", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@xfzy", SqlDbType.VarChar,200),
					new SqlParameter("@xfbz", SqlDbType.VarChar,200),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.id;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.krxm;
			parameters[4].Value = model.fjrb;
			parameters[5].Value = model.fjbh;
			parameters[6].Value = model.sktt;
			parameters[7].Value = model.xfrq;
			parameters[8].Value = model.xfsj;
			parameters[9].Value = model.czy;
			parameters[10].Value = model.xfdr;
			parameters[11].Value = model.xfrb;
			parameters[12].Value = model.xfxm;
			parameters[13].Value = model.jjje;
			parameters[14].Value = model.sjxfje;
			parameters[15].Value = model.xfsl;
			parameters[16].Value = model.mxbh;
			parameters[17].Value = model.zjhm;
			parameters[18].Value = model.yxzj;
			parameters[19].Value = model.krly;
			parameters[20].Value = model.xydw;
			parameters[21].Value = model.xyh;
			parameters[22].Value = model.krsj;
			parameters[23].Value = model.hykh;
			parameters[24].Value = model.krgj;
			parameters[25].Value = model.pq;
			parameters[26].Value = model.gj_sf;
			parameters[27].Value = model.gj_cs;
			parameters[28].Value = model.gj_dq;
			parameters[29].Value = model.id_app;
			parameters[30].Value = model.jzbh;
			parameters[31].Value = model.lsbh;
			parameters[32].Value = model.xsy;
			parameters[33].Value = model.xfzy;
			parameters[34].Value = model.xfbz;
			parameters[35].Value = model.ddsj;
			parameters[36].Value = model.lksj;
			parameters[37].Value = model.czsj;

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
		public bool Update(Hotel_app.Model.VS_syxfmx_cz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VS_syxfmx_cz set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("id=@id,");
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
			strSql.Append("sjxfje=@sjxfje,");
			strSql.Append("xfsl=@xfsl,");
			strSql.Append("mxbh=@mxbh,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("yxzj=@yxzj,");
			strSql.Append("krly=@krly,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("krsj=@krsj,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("pq=@pq,");
			strSql.Append("gj_sf=@gj_sf,");
			strSql.Append("gj_cs=@gj_cs,");
			strSql.Append("gj_dq=@gj_dq,");
			strSql.Append("id_app=@id_app,");
			strSql.Append("jzbh=@jzbh,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("xfzy=@xfzy,");
			strSql.Append("xfbz=@xfbz,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("czsj=@czsj");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
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
					new SqlParameter("@jjje", SqlDbType.Decimal,9),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@gj_sf", SqlDbType.VarChar,50),
					new SqlParameter("@gj_cs", SqlDbType.VarChar,50),
					new SqlParameter("@gj_dq", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@xfzy", SqlDbType.VarChar,200),
					new SqlParameter("@xfbz", SqlDbType.VarChar,200),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.id;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.krxm;
			parameters[4].Value = model.fjrb;
			parameters[5].Value = model.fjbh;
			parameters[6].Value = model.sktt;
			parameters[7].Value = model.xfrq;
			parameters[8].Value = model.xfsj;
			parameters[9].Value = model.czy;
			parameters[10].Value = model.xfdr;
			parameters[11].Value = model.xfrb;
			parameters[12].Value = model.xfxm;
			parameters[13].Value = model.jjje;
			parameters[14].Value = model.sjxfje;
			parameters[15].Value = model.xfsl;
			parameters[16].Value = model.mxbh;
			parameters[17].Value = model.zjhm;
			parameters[18].Value = model.yxzj;
			parameters[19].Value = model.krly;
			parameters[20].Value = model.xydw;
			parameters[21].Value = model.xyh;
			parameters[22].Value = model.krsj;
			parameters[23].Value = model.hykh;
			parameters[24].Value = model.krgj;
			parameters[25].Value = model.pq;
			parameters[26].Value = model.gj_sf;
			parameters[27].Value = model.gj_cs;
			parameters[28].Value = model.gj_dq;
			parameters[29].Value = model.id_app;
			parameters[30].Value = model.jzbh;
			parameters[31].Value = model.lsbh;
			parameters[32].Value = model.xsy;
			parameters[33].Value = model.xfzy;
			parameters[34].Value = model.xfbz;
			parameters[35].Value = model.ddsj;
			parameters[36].Value = model.lksj;
			parameters[37].Value = model.czsj;

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
			strSql.Append("delete from VS_syxfmx_cz ");
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
		public Hotel_app.Model.VS_syxfmx_cz GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 yydh,id,qymc,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,jjje,sjxfje,xfsl,mxbh,zjhm,yxzj,krly,xydw,xyh,krsj,hykh,krgj,pq,gj_sf,gj_cs,gj_dq,id_app,jzbh,lsbh,xsy,xfzy,xfbz,ddsj,lksj,czsj from VS_syxfmx_cz ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.VS_syxfmx_cz model=new Hotel_app.Model.VS_syxfmx_cz();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
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
				if(ds.Tables[0].Rows[0]["sjxfje"]!=null && ds.Tables[0].Rows[0]["sjxfje"].ToString()!="")
				{
					model.sjxfje=decimal.Parse(ds.Tables[0].Rows[0]["sjxfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfsl"]!=null && ds.Tables[0].Rows[0]["xfsl"].ToString()!="")
				{
					model.xfsl=decimal.Parse(ds.Tables[0].Rows[0]["xfsl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["mxbh"]!=null && ds.Tables[0].Rows[0]["mxbh"].ToString()!="")
				{
					model.mxbh=ds.Tables[0].Rows[0]["mxbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yxzj"]!=null && ds.Tables[0].Rows[0]["yxzj"].ToString()!="")
				{
					model.yxzj=ds.Tables[0].Rows[0]["yxzj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh"]!=null && ds.Tables[0].Rows[0]["xyh"].ToString()!="")
				{
					model.xyh=ds.Tables[0].Rows[0]["xyh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsj"]!=null && ds.Tables[0].Rows[0]["krsj"].ToString()!="")
				{
					model.krsj=ds.Tables[0].Rows[0]["krsj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krgj"]!=null && ds.Tables[0].Rows[0]["krgj"].ToString()!="")
				{
					model.krgj=ds.Tables[0].Rows[0]["krgj"].ToString();
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
				if(ds.Tables[0].Rows[0]["xsy"]!=null && ds.Tables[0].Rows[0]["xsy"].ToString()!="")
				{
					model.xsy=ds.Tables[0].Rows[0]["xsy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfzy"]!=null && ds.Tables[0].Rows[0]["xfzy"].ToString()!="")
				{
					model.xfzy=ds.Tables[0].Rows[0]["xfzy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfbz"]!=null && ds.Tables[0].Rows[0]["xfbz"].ToString()!="")
				{
					model.xfbz=ds.Tables[0].Rows[0]["xfbz"].ToString();
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
			strSql.Append("select yydh,id,qymc,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,jjje,sjxfje,xfsl,mxbh,zjhm,yxzj,krly,xydw,xyh,krsj,hykh,krgj,pq,gj_sf,gj_cs,gj_dq,id_app,jzbh,lsbh,xsy,xfzy,xfbz,ddsj,lksj,czsj ");
			strSql.Append(" FROM VS_syxfmx_cz ");
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
			strSql.Append(" yydh,id,qymc,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,jjje,sjxfje,xfsl,mxbh,zjhm,yxzj,krly,xydw,xyh,krsj,hykh,krgj,pq,gj_sf,gj_cs,gj_dq,id_app,jzbh,lsbh,xsy,xfzy,xfbz,ddsj,lksj,czsj ");
			strSql.Append(" FROM VS_syxfmx_cz ");
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
			strSql.Append("select count(1) FROM VS_syxfmx_cz ");
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
			strSql.Append(")AS Row, T.*  from VS_syxfmx_cz T ");
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
			parameters[0].Value = "VS_syxfmx_cz";
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

