using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:F_ftfx_7days
	/// </summary>
	public partial class F_ftfx_7days
	{
		public F_ftfx_7days()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "F_ftfx_7days"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from F_ftfx_7days");
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
		public int Add(Hotel_app.Model.F_ftfx_7days model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into F_ftfx_7days(");
			strSql.Append("yydh,qymc,zyzt,fx_value_1,fx_value_2,fx_value_3,fx_value_4,fx_value_5,fx_value_6,fx_value_7,czy,is_top,is_select)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@zyzt,@fx_value_1,@fx_value_2,@fx_value_3,@fx_value_4,@fx_value_5,@fx_value_6,@fx_value_7,@czy,@is_top,@is_select)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_1", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_2", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_3", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_4", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_5", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_6", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_7", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.zyzt;
			parameters[3].Value = model.fx_value_1;
			parameters[4].Value = model.fx_value_2;
			parameters[5].Value = model.fx_value_3;
			parameters[6].Value = model.fx_value_4;
			parameters[7].Value = model.fx_value_5;
			parameters[8].Value = model.fx_value_6;
			parameters[9].Value = model.fx_value_7;
			parameters[10].Value = model.czy;
			parameters[11].Value = model.is_top;
			parameters[12].Value = model.is_select;

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
		public bool Update(Hotel_app.Model.F_ftfx_7days model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update F_ftfx_7days set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("zyzt=@zyzt,");
			strSql.Append("fx_value_1=@fx_value_1,");
			strSql.Append("fx_value_2=@fx_value_2,");
			strSql.Append("fx_value_3=@fx_value_3,");
			strSql.Append("fx_value_4=@fx_value_4,");
			strSql.Append("fx_value_5=@fx_value_5,");
			strSql.Append("fx_value_6=@fx_value_6,");
			strSql.Append("fx_value_7=@fx_value_7,");
			strSql.Append("czy=@czy,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_1", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_2", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_3", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_4", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_5", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_6", SqlDbType.VarChar,50),
					new SqlParameter("@fx_value_7", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.zyzt;
			parameters[3].Value = model.fx_value_1;
			parameters[4].Value = model.fx_value_2;
			parameters[5].Value = model.fx_value_3;
			parameters[6].Value = model.fx_value_4;
			parameters[7].Value = model.fx_value_5;
			parameters[8].Value = model.fx_value_6;
			parameters[9].Value = model.fx_value_7;
			parameters[10].Value = model.czy;
			parameters[11].Value = model.is_top;
			parameters[12].Value = model.is_select;
			parameters[13].Value = model.id;

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
			strSql.Append("delete from F_ftfx_7days ");
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
			strSql.Append("delete from F_ftfx_7days ");
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
		public Hotel_app.Model.F_ftfx_7days GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,zyzt,fx_value_1,fx_value_2,fx_value_3,fx_value_4,fx_value_5,fx_value_6,fx_value_7,czy,is_top,is_select from F_ftfx_7days ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.F_ftfx_7days model=new Hotel_app.Model.F_ftfx_7days();
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
				if(ds.Tables[0].Rows[0]["zyzt"]!=null && ds.Tables[0].Rows[0]["zyzt"].ToString()!="")
				{
					model.zyzt=ds.Tables[0].Rows[0]["zyzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fx_value_1"]!=null && ds.Tables[0].Rows[0]["fx_value_1"].ToString()!="")
				{
					model.fx_value_1=ds.Tables[0].Rows[0]["fx_value_1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fx_value_2"]!=null && ds.Tables[0].Rows[0]["fx_value_2"].ToString()!="")
				{
					model.fx_value_2=ds.Tables[0].Rows[0]["fx_value_2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fx_value_3"]!=null && ds.Tables[0].Rows[0]["fx_value_3"].ToString()!="")
				{
					model.fx_value_3=ds.Tables[0].Rows[0]["fx_value_3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fx_value_4"]!=null && ds.Tables[0].Rows[0]["fx_value_4"].ToString()!="")
				{
					model.fx_value_4=ds.Tables[0].Rows[0]["fx_value_4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fx_value_5"]!=null && ds.Tables[0].Rows[0]["fx_value_5"].ToString()!="")
				{
					model.fx_value_5=ds.Tables[0].Rows[0]["fx_value_5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fx_value_6"]!=null && ds.Tables[0].Rows[0]["fx_value_6"].ToString()!="")
				{
					model.fx_value_6=ds.Tables[0].Rows[0]["fx_value_6"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fx_value_7"]!=null && ds.Tables[0].Rows[0]["fx_value_7"].ToString()!="")
				{
					model.fx_value_7=ds.Tables[0].Rows[0]["fx_value_7"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["is_top"]!=null && ds.Tables[0].Rows[0]["is_top"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_top"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_top"].ToString().ToLower()=="true"))
					{
						model.is_top=true;
					}
					else
					{
						model.is_top=false;
					}
				}
				if(ds.Tables[0].Rows[0]["is_select"]!=null && ds.Tables[0].Rows[0]["is_select"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_select"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_select"].ToString().ToLower()=="true"))
					{
						model.is_select=true;
					}
					else
					{
						model.is_select=false;
					}
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
			strSql.Append("select id,yydh,qymc,zyzt,fx_value_1,fx_value_2,fx_value_3,fx_value_4,fx_value_5,fx_value_6,fx_value_7,czy,is_top,is_select ");
			strSql.Append(" FROM F_ftfx_7days ");
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
			strSql.Append(" id,yydh,qymc,zyzt,fx_value_1,fx_value_2,fx_value_3,fx_value_4,fx_value_5,fx_value_6,fx_value_7,czy,is_top,is_select ");
			strSql.Append(" FROM F_ftfx_7days ");
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
			strSql.Append("select count(1) FROM F_ftfx_7days ");
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
			strSql.Append(")AS Row, T.*  from F_ftfx_7days T ");
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
			parameters[0].Value = "F_ftfx_7days";
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

