using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:View_Xxfmx_lk
	/// </summary>
	public partial class View_Xxfmx_lk
	{
		public View_Xxfmx_lk()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.View_Xxfmx_lk model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_Xxfmx_lk(");
			strSql.Append("lksj,xfsl,jjdj,Total_cb,xfmx,mxbh,id,yydh,qymc)");
			strSql.Append(" values (");
			strSql.Append("@lksj,@xfsl,@jjdj,@Total_cb,@xfmx,@mxbh,@id,@yydh,@qymc)");
			SqlParameter[] parameters = {
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@jjdj", SqlDbType.Decimal,5),
					new SqlParameter("@Total_cb", SqlDbType.Decimal,5),
					new SqlParameter("@xfmx", SqlDbType.VarChar,100),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50)};
			parameters[0].Value = model.lksj;
			parameters[1].Value = model.xfsl;
			parameters[2].Value = model.jjdj;
			parameters[3].Value = model.Total_cb;
			parameters[4].Value = model.xfmx;
			parameters[5].Value = model.mxbh;
			parameters[6].Value = model.id;
			parameters[7].Value = model.yydh;
			parameters[8].Value = model.qymc;

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
		public bool Update(Hotel_app.Model.View_Xxfmx_lk model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_Xxfmx_lk set ");
			strSql.Append("lksj=@lksj,");
			strSql.Append("xfsl=@xfsl,");
			strSql.Append("jjdj=@jjdj,");
			strSql.Append("Total_cb=@Total_cb,");
			strSql.Append("xfmx=@xfmx,");
			strSql.Append("mxbh=@mxbh,");
			strSql.Append("id=@id,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@jjdj", SqlDbType.Decimal,5),
					new SqlParameter("@Total_cb", SqlDbType.Decimal,5),
					new SqlParameter("@xfmx", SqlDbType.VarChar,100),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50)};
			parameters[0].Value = model.lksj;
			parameters[1].Value = model.xfsl;
			parameters[2].Value = model.jjdj;
			parameters[3].Value = model.Total_cb;
			parameters[4].Value = model.xfmx;
			parameters[5].Value = model.mxbh;
			parameters[6].Value = model.id;
			parameters[7].Value = model.yydh;
			parameters[8].Value = model.qymc;

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
			strSql.Append("delete from View_Xxfmx_lk ");
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
		public Hotel_app.Model.View_Xxfmx_lk GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 lksj,xfsl,jjdj,Total_cb,xfmx,mxbh,id,yydh,qymc from View_Xxfmx_lk ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.View_Xxfmx_lk model=new Hotel_app.Model.View_Xxfmx_lk();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfsl"]!=null && ds.Tables[0].Rows[0]["xfsl"].ToString()!="")
				{
					model.xfsl=decimal.Parse(ds.Tables[0].Rows[0]["xfsl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jjdj"]!=null && ds.Tables[0].Rows[0]["jjdj"].ToString()!="")
				{
					model.jjdj=decimal.Parse(ds.Tables[0].Rows[0]["jjdj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Total_cb"]!=null && ds.Tables[0].Rows[0]["Total_cb"].ToString()!="")
				{
					model.Total_cb=decimal.Parse(ds.Tables[0].Rows[0]["Total_cb"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfmx"]!=null && ds.Tables[0].Rows[0]["xfmx"].ToString()!="")
				{
					model.xfmx=ds.Tables[0].Rows[0]["xfmx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mxbh"]!=null && ds.Tables[0].Rows[0]["mxbh"].ToString()!="")
				{
					model.mxbh=ds.Tables[0].Rows[0]["mxbh"].ToString();
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
			strSql.Append("select lksj,xfsl,jjdj,Total_cb,xfmx,mxbh,id,yydh,qymc ");
			strSql.Append(" FROM View_Xxfmx_lk ");
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
			strSql.Append(" lksj,xfsl,jjdj,Total_cb,xfmx,mxbh,id,yydh,qymc ");
			strSql.Append(" FROM View_Xxfmx_lk ");
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
			strSql.Append("select count(1) FROM View_Xxfmx_lk ");
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
			strSql.Append(")AS Row, T.*  from View_Xxfmx_lk T ");
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
			parameters[0].Value = "View_Xxfmx_lk";
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

