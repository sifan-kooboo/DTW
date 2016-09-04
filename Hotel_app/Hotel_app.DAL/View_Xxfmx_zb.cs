using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:View_Xxfmx_zb
	/// </summary>
	public partial class View_Xxfmx_zb
	{
		public View_Xxfmx_zb()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.View_Xxfmx_zb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Xxfmx_zb(");
			strSql.Append("mxbh,zb_sl,zb_sj,zb_jjje,zb_Total_cb)");
			strSql.Append(" values (");
			strSql.Append("@mxbh,@zb_sl,@zb_sj,@zb_jjje,@zb_Total_cb)");
			SqlParameter[] parameters = {
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@zb_sl", SqlDbType.Decimal,9),
					new SqlParameter("@zb_sj", SqlDbType.DateTime),
					new SqlParameter("@zb_jjje", SqlDbType.Decimal,9),
					new SqlParameter("@zb_Total_cb", SqlDbType.Decimal,9)};
			parameters[0].Value = model.mxbh;
			parameters[1].Value = model.zb_sl;
			parameters[2].Value = model.zb_sj;
			parameters[3].Value = model.zb_jjje;
			parameters[4].Value = model.zb_Total_cb;

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
		public bool Update(Hotel_app.Model.View_Xxfmx_zb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Xxfmx_zb set ");
			strSql.Append("mxbh=@mxbh,");
			strSql.Append("zb_sl=@zb_sl,");
			strSql.Append("zb_sj=@zb_sj,");
			strSql.Append("zb_jjje=@zb_jjje,");
			strSql.Append("zb_Total_cb=@zb_Total_cb");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@zb_sl", SqlDbType.Decimal,9),
					new SqlParameter("@zb_sj", SqlDbType.DateTime),
					new SqlParameter("@zb_jjje", SqlDbType.Decimal,9),
					new SqlParameter("@zb_Total_cb", SqlDbType.Decimal,9)};
			parameters[0].Value = model.mxbh;
			parameters[1].Value = model.zb_sl;
			parameters[2].Value = model.zb_sj;
			parameters[3].Value = model.zb_jjje;
			parameters[4].Value = model.zb_Total_cb;

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
			strSql.Append("delete from View_Xxfmx_zb ");
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
		public Hotel_app.Model.View_Xxfmx_zb GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 mxbh,zb_sl,zb_sj,zb_jjje,zb_Total_cb from View_Xxfmx_zb ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.View_Xxfmx_zb model=new Hotel_app.Model.View_Xxfmx_zb();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["mxbh"]!=null && ds.Tables[0].Rows[0]["mxbh"].ToString()!="")
				{
					model.mxbh=ds.Tables[0].Rows[0]["mxbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zb_sl"]!=null && ds.Tables[0].Rows[0]["zb_sl"].ToString()!="")
				{
					model.zb_sl=decimal.Parse(ds.Tables[0].Rows[0]["zb_sl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zb_sj"]!=null && ds.Tables[0].Rows[0]["zb_sj"].ToString()!="")
				{
					model.zb_sj=DateTime.Parse(ds.Tables[0].Rows[0]["zb_sj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zb_jjje"]!=null && ds.Tables[0].Rows[0]["zb_jjje"].ToString()!="")
				{
					model.zb_jjje=decimal.Parse(ds.Tables[0].Rows[0]["zb_jjje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zb_Total_cb"]!=null && ds.Tables[0].Rows[0]["zb_Total_cb"].ToString()!="")
				{
					model.zb_Total_cb=decimal.Parse(ds.Tables[0].Rows[0]["zb_Total_cb"].ToString());
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
			strSql.Append("select mxbh,zb_sl,zb_sj,zb_jjje,zb_Total_cb ");
			strSql.Append(" FROM View_Xxfmx_zb ");
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
			strSql.Append(" mxbh,zb_sl,zb_sj,zb_jjje,zb_Total_cb ");
			strSql.Append(" FROM View_Xxfmx_zb ");
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
			strSql.Append("select count(1) FROM View_Xxfmx_zb ");
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
			strSql.Append(")AS Row, T.*  from View_Xxfmx_zb T ");
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
			parameters[0].Value = "View_Xxfmx_zb";
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

