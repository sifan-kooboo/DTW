using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:BQ_syxfmx_ls
	/// </summary>
	public partial class BQ_syxfmx_ls
	{
		public BQ_syxfmx_ls()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "BQ_syxfmx_ls"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BQ_syxfmx_ls");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.BQ_syxfmx_ls model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BQ_syxfmx_ls(");
			strSql.Append("yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfsj,xfdr,xfrb,xfxm,sjxfje,xfsl,xsy,krly,xydw,czy_temp,pq,krgj,gj_sf,gj_cs)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@id_app,@jzbh,@lsbh,@krxm,@fjrb,@fjbh,@sktt,@xfsj,@xfdr,@xfrb,@xfxm,@sjxfje,@xfsl,@xsy,@krly,@xydw,@czy_temp,@pq,@krgj,@gj_sf,@gj_cs)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@gj_sf", SqlDbType.VarChar,50),
					new SqlParameter("@gj_cs", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.id_app;
			parameters[3].Value = model.jzbh;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.fjrb;
			parameters[7].Value = model.fjbh;
			parameters[8].Value = model.sktt;
			parameters[9].Value = model.xfsj;
			parameters[10].Value = model.xfdr;
			parameters[11].Value = model.xfrb;
			parameters[12].Value = model.xfxm;
			parameters[13].Value = model.sjxfje;
			parameters[14].Value = model.xfsl;
			parameters[15].Value = model.xsy;
			parameters[16].Value = model.krly;
			parameters[17].Value = model.xydw;
			parameters[18].Value = model.czy_temp;
			parameters[19].Value = model.pq;
			parameters[20].Value = model.krgj;
			parameters[21].Value = model.gj_sf;
			parameters[22].Value = model.gj_cs;

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
		public bool Update(Hotel_app.Model.BQ_syxfmx_ls model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BQ_syxfmx_ls set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("id_app=@id_app,");
			strSql.Append("jzbh=@jzbh,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("xfsj=@xfsj,");
			strSql.Append("xfdr=@xfdr,");
			strSql.Append("xfrb=@xfrb,");
			strSql.Append("xfxm=@xfxm,");
			strSql.Append("sjxfje=@sjxfje,");
			strSql.Append("xfsl=@xfsl,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("krly=@krly,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("czy_temp=@czy_temp,");
			strSql.Append("pq=@pq,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("gj_sf=@gj_sf,");
			strSql.Append("gj_cs=@gj_cs");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@gj_sf", SqlDbType.VarChar,50),
					new SqlParameter("@gj_cs", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.id_app;
			parameters[3].Value = model.jzbh;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.fjrb;
			parameters[7].Value = model.fjbh;
			parameters[8].Value = model.sktt;
			parameters[9].Value = model.xfsj;
			parameters[10].Value = model.xfdr;
			parameters[11].Value = model.xfrb;
			parameters[12].Value = model.xfxm;
			parameters[13].Value = model.sjxfje;
			parameters[14].Value = model.xfsl;
			parameters[15].Value = model.xsy;
			parameters[16].Value = model.krly;
			parameters[17].Value = model.xydw;
			parameters[18].Value = model.czy_temp;
			parameters[19].Value = model.pq;
			parameters[20].Value = model.krgj;
			parameters[21].Value = model.gj_sf;
			parameters[22].Value = model.gj_cs;
			parameters[23].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BQ_syxfmx_ls ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BQ_syxfmx_ls ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public Hotel_app.Model.BQ_syxfmx_ls GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfsj,xfdr,xfrb,xfxm,sjxfje,xfsl,xsy,krly,xydw,czy_temp,pq,krgj,gj_sf,gj_cs from BQ_syxfmx_ls ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.BQ_syxfmx_ls model=new Hotel_app.Model.BQ_syxfmx_ls();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
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
				if(ds.Tables[0].Rows[0]["xfsj"]!=null && ds.Tables[0].Rows[0]["xfsj"].ToString()!="")
				{
					model.xfsj=DateTime.Parse(ds.Tables[0].Rows[0]["xfsj"].ToString());
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
				if(ds.Tables[0].Rows[0]["sjxfje"]!=null && ds.Tables[0].Rows[0]["sjxfje"].ToString()!="")
				{
					model.sjxfje=decimal.Parse(ds.Tables[0].Rows[0]["sjxfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfsl"]!=null && ds.Tables[0].Rows[0]["xfsl"].ToString()!="")
				{
					model.xfsl=decimal.Parse(ds.Tables[0].Rows[0]["xfsl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xsy"]!=null && ds.Tables[0].Rows[0]["xsy"].ToString()!="")
				{
					model.xsy=ds.Tables[0].Rows[0]["xsy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy_temp"]!=null && ds.Tables[0].Rows[0]["czy_temp"].ToString()!="")
				{
					model.czy_temp=ds.Tables[0].Rows[0]["czy_temp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pq"]!=null && ds.Tables[0].Rows[0]["pq"].ToString()!="")
				{
					model.pq=ds.Tables[0].Rows[0]["pq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krgj"]!=null && ds.Tables[0].Rows[0]["krgj"].ToString()!="")
				{
					model.krgj=ds.Tables[0].Rows[0]["krgj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gj_sf"]!=null && ds.Tables[0].Rows[0]["gj_sf"].ToString()!="")
				{
					model.gj_sf=ds.Tables[0].Rows[0]["gj_sf"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gj_cs"]!=null && ds.Tables[0].Rows[0]["gj_cs"].ToString()!="")
				{
					model.gj_cs=ds.Tables[0].Rows[0]["gj_cs"].ToString();
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
			strSql.Append("select id,yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfsj,xfdr,xfrb,xfxm,sjxfje,xfsl,xsy,krly,xydw,czy_temp,pq,krgj,gj_sf,gj_cs ");
			strSql.Append(" FROM BQ_syxfmx_ls ");
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
			strSql.Append(" id,yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfsj,xfdr,xfrb,xfxm,sjxfje,xfsl,xsy,krly,xydw,czy_temp,pq,krgj,gj_sf,gj_cs ");
			strSql.Append(" FROM BQ_syxfmx_ls ");
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
			strSql.Append("select count(1) FROM BQ_syxfmx_ls ");
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
			strSql.Append(")AS Row, T.*  from BQ_syxfmx_ls T ");
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
			parameters[0].Value = "BQ_syxfmx_ls";
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

