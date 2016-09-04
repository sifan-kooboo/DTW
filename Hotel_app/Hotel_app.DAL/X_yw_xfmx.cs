using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:X_yw_xfmx
	/// </summary>
	public partial class X_yw_xfmx
	{
		public X_yw_xfmx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "X_yw_xfmx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from X_yw_xfmx");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.X_yw_xfmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into X_yw_xfmx(");
			strSql.Append("id,yydh,qymc,language_bh,language_type,xfmx_china,xfmx_yw,rx)");
			strSql.Append(" values (");
			strSql.Append("@id,@yydh,@qymc,@language_bh,@language_type,@xfmx_china,@xfmx_yw,@rx)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@language_bh", SqlDbType.VarChar,50),
					new SqlParameter("@language_type", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx_china", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx_yw", SqlDbType.VarChar,50),
					new SqlParameter("@rx", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.language_bh;
			parameters[4].Value = model.language_type;
			parameters[5].Value = model.xfmx_china;
			parameters[6].Value = model.xfmx_yw;
			parameters[7].Value = model.rx;

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
		public bool Update(Hotel_app.Model.X_yw_xfmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update X_yw_xfmx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("language_bh=@language_bh,");
			strSql.Append("language_type=@language_type,");
			strSql.Append("xfmx_china=@xfmx_china,");
			strSql.Append("xfmx_yw=@xfmx_yw,");
			strSql.Append("rx=@rx");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@language_bh", SqlDbType.VarChar,50),
					new SqlParameter("@language_type", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx_china", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx_yw", SqlDbType.VarChar,50),
					new SqlParameter("@rx", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.language_bh;
			parameters[3].Value = model.language_type;
			parameters[4].Value = model.xfmx_china;
			parameters[5].Value = model.xfmx_yw;
			parameters[6].Value = model.rx;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from X_yw_xfmx ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
			strSql.Append("delete from X_yw_xfmx ");
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
		public Hotel_app.Model.X_yw_xfmx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,language_bh,language_type,xfmx_china,xfmx_yw,rx from X_yw_xfmx ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			Hotel_app.Model.X_yw_xfmx model=new Hotel_app.Model.X_yw_xfmx();
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
				if(ds.Tables[0].Rows[0]["language_bh"]!=null && ds.Tables[0].Rows[0]["language_bh"].ToString()!="")
				{
					model.language_bh=ds.Tables[0].Rows[0]["language_bh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["language_type"]!=null && ds.Tables[0].Rows[0]["language_type"].ToString()!="")
				{
					model.language_type=ds.Tables[0].Rows[0]["language_type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfmx_china"]!=null && ds.Tables[0].Rows[0]["xfmx_china"].ToString()!="")
				{
					model.xfmx_china=ds.Tables[0].Rows[0]["xfmx_china"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfmx_yw"]!=null && ds.Tables[0].Rows[0]["xfmx_yw"].ToString()!="")
				{
					model.xfmx_yw=ds.Tables[0].Rows[0]["xfmx_yw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["rx"]!=null && ds.Tables[0].Rows[0]["rx"].ToString()!="")
				{
					model.rx=ds.Tables[0].Rows[0]["rx"].ToString();
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
			strSql.Append("select id,yydh,qymc,language_bh,language_type,xfmx_china,xfmx_yw,rx ");
			strSql.Append(" FROM X_yw_xfmx ");
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
			strSql.Append(" id,yydh,qymc,language_bh,language_type,xfmx_china,xfmx_yw,rx ");
			strSql.Append(" FROM X_yw_xfmx ");
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
			strSql.Append("select count(1) FROM X_yw_xfmx ");
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
			strSql.Append(")AS Row, T.*  from X_yw_xfmx T ");
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
			parameters[0].Value = "X_yw_xfmx";
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

