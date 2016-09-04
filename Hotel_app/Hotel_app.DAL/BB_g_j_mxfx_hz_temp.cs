using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:BB_g_j_mxfx_hz_temp
	/// </summary>
	public partial class BB_g_j_mxfx_hz_temp
	{
		public BB_g_j_mxfx_hz_temp()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.BB_g_j_mxfx_hz_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BB_g_j_mxfx_hz_temp(");
			strSql.Append("qymc,yydh,jzzt,xyh,xfdr,xfrb,xfxm,xfrq,xfsj,sjxfje,czy_temp)");
			strSql.Append(" values (");
			strSql.Append("@qymc,@yydh,@jzzt,@xyh,@xfdr,@xfrb,@xfxm,@xfrq,@xfsj,@sjxfje,@czy_temp)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@qymc", SqlDbType.VarChar,100),
					new SqlParameter("@yydh", SqlDbType.VarChar,100),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj", SqlDbType.VarChar,50),
					new SqlParameter("@sjxfje", SqlDbType.VarChar,50),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50)};
			parameters[0].Value = model.qymc;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.jzzt;
			parameters[3].Value = model.xyh;
			parameters[4].Value = model.xfdr;
			parameters[5].Value = model.xfrb;
			parameters[6].Value = model.xfxm;
			parameters[7].Value = model.xfrq;
			parameters[8].Value = model.xfsj;
			parameters[9].Value = model.sjxfje;
			parameters[10].Value = model.czy_temp;

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
		public bool Update(Hotel_app.Model.BB_g_j_mxfx_hz_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BB_g_j_mxfx_hz_temp set ");
			strSql.Append("qymc=@qymc,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("jzzt=@jzzt,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("xfdr=@xfdr,");
			strSql.Append("xfrb=@xfrb,");
			strSql.Append("xfxm=@xfxm,");
			strSql.Append("xfrq=@xfrq,");
			strSql.Append("xfsj=@xfsj,");
			strSql.Append("sjxfje=@sjxfje,");
			strSql.Append("czy_temp=@czy_temp");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@qymc", SqlDbType.VarChar,100),
					new SqlParameter("@yydh", SqlDbType.VarChar,100),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj", SqlDbType.VarChar,50),
					new SqlParameter("@sjxfje", SqlDbType.VarChar,50),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.qymc;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.jzzt;
			parameters[3].Value = model.xyh;
			parameters[4].Value = model.xfdr;
			parameters[5].Value = model.xfrb;
			parameters[6].Value = model.xfxm;
			parameters[7].Value = model.xfrq;
			parameters[8].Value = model.xfsj;
			parameters[9].Value = model.sjxfje;
			parameters[10].Value = model.czy_temp;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from BB_g_j_mxfx_hz_temp ");
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
			strSql.Append("delete from BB_g_j_mxfx_hz_temp ");
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
		public Hotel_app.Model.BB_g_j_mxfx_hz_temp GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,qymc,yydh,jzzt,xyh,xfdr,xfrb,xfxm,xfrq,xfsj,sjxfje,czy_temp from BB_g_j_mxfx_hz_temp ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.BB_g_j_mxfx_hz_temp model=new Hotel_app.Model.BB_g_j_mxfx_hz_temp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jzzt"]!=null && ds.Tables[0].Rows[0]["jzzt"].ToString()!="")
				{
					model.jzzt=ds.Tables[0].Rows[0]["jzzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh"]!=null && ds.Tables[0].Rows[0]["xyh"].ToString()!="")
				{
					model.xyh=ds.Tables[0].Rows[0]["xyh"].ToString();
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
				if(ds.Tables[0].Rows[0]["xfrq"]!=null && ds.Tables[0].Rows[0]["xfrq"].ToString()!="")
				{
					model.xfrq=ds.Tables[0].Rows[0]["xfrq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfsj"]!=null && ds.Tables[0].Rows[0]["xfsj"].ToString()!="")
				{
					model.xfsj=ds.Tables[0].Rows[0]["xfsj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sjxfje"]!=null && ds.Tables[0].Rows[0]["sjxfje"].ToString()!="")
				{
					model.sjxfje=ds.Tables[0].Rows[0]["sjxfje"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy_temp"]!=null && ds.Tables[0].Rows[0]["czy_temp"].ToString()!="")
				{
					model.czy_temp=ds.Tables[0].Rows[0]["czy_temp"].ToString();
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
			strSql.Append("select id,qymc,yydh,jzzt,xyh,xfdr,xfrb,xfxm,xfrq,xfsj,sjxfje,czy_temp ");
			strSql.Append(" FROM BB_g_j_mxfx_hz_temp ");
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
			strSql.Append(" id,qymc,yydh,jzzt,xyh,xfdr,xfrb,xfxm,xfrq,xfsj,sjxfje,czy_temp ");
			strSql.Append(" FROM BB_g_j_mxfx_hz_temp ");
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
			strSql.Append("select count(1) FROM BB_g_j_mxfx_hz_temp ");
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
			strSql.Append(")AS Row, T.*  from BB_g_j_mxfx_hz_temp T ");
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
			parameters[0].Value = "BB_g_j_mxfx_hz_temp";
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

