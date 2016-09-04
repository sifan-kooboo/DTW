using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_S_jzzt_czzt_jzmx
	/// </summary>
	public partial class VIEW_S_jzzt_czzt_jzmx
	{
		public VIEW_S_jzzt_czzt_jzmx()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.VIEW_S_jzzt_czzt_jzmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VIEW_S_jzzt_czzt_jzmx(");
			strSql.Append("jzbh,jzzt,czzt,czsj)");
			strSql.Append(" values (");
			strSql.Append("@jzbh,@jzzt,@czzt,@czsj)");
			SqlParameter[] parameters = {
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@czzt", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime)};
			parameters[0].Value = model.jzbh;
			parameters[1].Value = model.jzzt;
			parameters[2].Value = model.czzt;
			parameters[3].Value = model.czsj;

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
		public bool Update(Hotel_app.Model.VIEW_S_jzzt_czzt_jzmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VIEW_S_jzzt_czzt_jzmx set ");
			strSql.Append("jzbh=@jzbh,");
			strSql.Append("jzzt=@jzzt,");
			strSql.Append("czzt=@czzt,");
			strSql.Append("czsj=@czsj");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@czzt", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime)};
			parameters[0].Value = model.jzbh;
			parameters[1].Value = model.jzzt;
			parameters[2].Value = model.czzt;
			parameters[3].Value = model.czsj;

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
			strSql.Append("delete from VIEW_S_jzzt_czzt_jzmx ");
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
		public Hotel_app.Model.VIEW_S_jzzt_czzt_jzmx GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 jzbh,jzzt,czzt,czsj from VIEW_S_jzzt_czzt_jzmx ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.VIEW_S_jzzt_czzt_jzmx model=new Hotel_app.Model.VIEW_S_jzzt_czzt_jzmx();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["jzbh"]!=null && ds.Tables[0].Rows[0]["jzbh"].ToString()!="")
				{
					model.jzbh=ds.Tables[0].Rows[0]["jzbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jzzt"]!=null && ds.Tables[0].Rows[0]["jzzt"].ToString()!="")
				{
					model.jzzt=ds.Tables[0].Rows[0]["jzzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czzt"]!=null && ds.Tables[0].Rows[0]["czzt"].ToString()!="")
				{
					model.czzt=ds.Tables[0].Rows[0]["czzt"].ToString();
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
			strSql.Append("select jzbh,jzzt,czzt,czsj ");
			strSql.Append(" FROM VIEW_S_jzzt_czzt_jzmx ");
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
			strSql.Append(" jzbh,jzzt,czzt,czsj ");
			strSql.Append(" FROM VIEW_S_jzzt_czzt_jzmx ");
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
			strSql.Append("select count(1) FROM VIEW_S_jzzt_czzt_jzmx ");
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
			strSql.Append(")AS Row, T.*  from VIEW_S_jzzt_czzt_jzmx T ");
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
			parameters[0].Value = "VIEW_S_jzzt_czzt_jzmx";
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

