using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:BBfx_s_g_j_ye_ls
	/// </summary>
	public partial class BBfx_s_g_j_ye_ls
	{
		public BBfx_s_g_j_ye_ls()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.BBfx_s_g_j_ye_ls model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BBfx_s_g_j_ye_ls(");
			strSql.Append("yydh,qymc,jzzt,xydw,ff_total,ds_total,qt_total,ye_total,czy_temp)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@jzzt,@xydw,@ff_total,@ds_total,@qt_total,@ye_total,@czy_temp)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@ff_total", SqlDbType.Decimal,9),
					new SqlParameter("@ds_total", SqlDbType.Decimal,9),
					new SqlParameter("@qt_total", SqlDbType.Decimal,9),
					new SqlParameter("@ye_total", SqlDbType.Decimal,9),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.jzzt;
			parameters[3].Value = model.xydw;
			parameters[4].Value = model.ff_total;
			parameters[5].Value = model.ds_total;
			parameters[6].Value = model.qt_total;
			parameters[7].Value = model.ye_total;
			parameters[8].Value = model.czy_temp;

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
		public bool Update(Hotel_app.Model.BBfx_s_g_j_ye_ls model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BBfx_s_g_j_ye_ls set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("jzzt=@jzzt,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("ff_total=@ff_total,");
			strSql.Append("ds_total=@ds_total,");
			strSql.Append("qt_total=@qt_total,");
			strSql.Append("ye_total=@ye_total,");
			strSql.Append("czy_temp=@czy_temp");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@ff_total", SqlDbType.Decimal,9),
					new SqlParameter("@ds_total", SqlDbType.Decimal,9),
					new SqlParameter("@qt_total", SqlDbType.Decimal,9),
					new SqlParameter("@ye_total", SqlDbType.Decimal,9),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.jzzt;
			parameters[3].Value = model.xydw;
			parameters[4].Value = model.ff_total;
			parameters[5].Value = model.ds_total;
			parameters[6].Value = model.qt_total;
			parameters[7].Value = model.ye_total;
			parameters[8].Value = model.czy_temp;
			parameters[9].Value = model.id;

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
			strSql.Append("delete from BBfx_s_g_j_ye_ls ");
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
			strSql.Append("delete from BBfx_s_g_j_ye_ls ");
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
		public Hotel_app.Model.BBfx_s_g_j_ye_ls GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,jzzt,xydw,ff_total,ds_total,qt_total,ye_total,czy_temp from BBfx_s_g_j_ye_ls ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.BBfx_s_g_j_ye_ls model=new Hotel_app.Model.BBfx_s_g_j_ye_ls();
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
				if(ds.Tables[0].Rows[0]["jzzt"]!=null && ds.Tables[0].Rows[0]["jzzt"].ToString()!="")
				{
					model.jzzt=ds.Tables[0].Rows[0]["jzzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ff_total"]!=null && ds.Tables[0].Rows[0]["ff_total"].ToString()!="")
				{
					model.ff_total=decimal.Parse(ds.Tables[0].Rows[0]["ff_total"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ds_total"]!=null && ds.Tables[0].Rows[0]["ds_total"].ToString()!="")
				{
					model.ds_total=decimal.Parse(ds.Tables[0].Rows[0]["ds_total"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qt_total"]!=null && ds.Tables[0].Rows[0]["qt_total"].ToString()!="")
				{
					model.qt_total=decimal.Parse(ds.Tables[0].Rows[0]["qt_total"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ye_total"]!=null && ds.Tables[0].Rows[0]["ye_total"].ToString()!="")
				{
					model.ye_total=decimal.Parse(ds.Tables[0].Rows[0]["ye_total"].ToString());
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
			strSql.Append("select id,yydh,qymc,jzzt,xydw,ff_total,ds_total,qt_total,ye_total,czy_temp ");
			strSql.Append(" FROM BBfx_s_g_j_ye_ls ");
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
			strSql.Append(" id,yydh,qymc,jzzt,xydw,ff_total,ds_total,qt_total,ye_total,czy_temp ");
			strSql.Append(" FROM BBfx_s_g_j_ye_ls ");
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
			strSql.Append("select count(1) FROM BBfx_s_g_j_ye_ls ");
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
			strSql.Append(")AS Row, T.*  from BBfx_s_g_j_ye_ls T ");
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
			parameters[0].Value = "BBfx_s_g_j_ye_ls";
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

