using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:hhyyz_dx
	/// </summary>
	public partial class hhyyz_dx
	{
		public hhyyz_dx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "hhyyz_dx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from hhyyz_dx");
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
		public int Add(Hotel_app.Model.hhyyz_dx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into hhyyz_dx(");
			strSql.Append("yydh,qymc,hy_action_flage,msm_content,enable,dxycsj,msm_content_2,msm_content_3,msm_content_4,msm_content_5)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@hy_action_flage,@msm_content,@enable,@dxycsj,@msm_content_2,@msm_content_3,@msm_content_4,@msm_content_5)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@hy_action_flage", SqlDbType.VarChar,50),
					new SqlParameter("@msm_content", SqlDbType.VarChar,5000),
					new SqlParameter("@enable", SqlDbType.Bit,1),
					new SqlParameter("@dxycsj", SqlDbType.Int,4),
					new SqlParameter("@msm_content_2", SqlDbType.VarChar,1000),
					new SqlParameter("@msm_content_3", SqlDbType.VarChar,1000),
					new SqlParameter("@msm_content_4", SqlDbType.VarChar,1000),
					new SqlParameter("@msm_content_5", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.hy_action_flage;
			parameters[3].Value = model.msm_content;
			parameters[4].Value = model.enable;
			parameters[5].Value = model.dxycsj;
			parameters[6].Value = model.msm_content_2;
			parameters[7].Value = model.msm_content_3;
			parameters[8].Value = model.msm_content_4;
			parameters[9].Value = model.msm_content_5;

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
		public bool Update(Hotel_app.Model.hhyyz_dx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update hhyyz_dx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("hy_action_flage=@hy_action_flage,");
			strSql.Append("msm_content=@msm_content,");
			strSql.Append("enable=@enable,");
			strSql.Append("dxycsj=@dxycsj,");
			strSql.Append("msm_content_2=@msm_content_2,");
			strSql.Append("msm_content_3=@msm_content_3,");
			strSql.Append("msm_content_4=@msm_content_4,");
			strSql.Append("msm_content_5=@msm_content_5");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@hy_action_flage", SqlDbType.VarChar,50),
					new SqlParameter("@msm_content", SqlDbType.VarChar,5000),
					new SqlParameter("@enable", SqlDbType.Bit,1),
					new SqlParameter("@dxycsj", SqlDbType.Int,4),
					new SqlParameter("@msm_content_2", SqlDbType.VarChar,1000),
					new SqlParameter("@msm_content_3", SqlDbType.VarChar,1000),
					new SqlParameter("@msm_content_4", SqlDbType.VarChar,1000),
					new SqlParameter("@msm_content_5", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.hy_action_flage;
			parameters[3].Value = model.msm_content;
			parameters[4].Value = model.enable;
			parameters[5].Value = model.dxycsj;
			parameters[6].Value = model.msm_content_2;
			parameters[7].Value = model.msm_content_3;
			parameters[8].Value = model.msm_content_4;
			parameters[9].Value = model.msm_content_5;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from hhyyz_dx ");
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
			strSql.Append("delete from hhyyz_dx ");
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
		public Hotel_app.Model.hhyyz_dx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,hy_action_flage,msm_content,enable,dxycsj,msm_content_2,msm_content_3,msm_content_4,msm_content_5 from hhyyz_dx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.hhyyz_dx model=new Hotel_app.Model.hhyyz_dx();
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
				if(ds.Tables[0].Rows[0]["hy_action_flage"]!=null && ds.Tables[0].Rows[0]["hy_action_flage"].ToString()!="")
				{
					model.hy_action_flage=ds.Tables[0].Rows[0]["hy_action_flage"].ToString();
				}
				if(ds.Tables[0].Rows[0]["msm_content"]!=null && ds.Tables[0].Rows[0]["msm_content"].ToString()!="")
				{
					model.msm_content=ds.Tables[0].Rows[0]["msm_content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["enable"]!=null && ds.Tables[0].Rows[0]["enable"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["enable"].ToString()=="1")||(ds.Tables[0].Rows[0]["enable"].ToString().ToLower()=="true"))
					{
						model.enable=true;
					}
					else
					{
						model.enable=false;
					}
				}
				if(ds.Tables[0].Rows[0]["dxycsj"]!=null && ds.Tables[0].Rows[0]["dxycsj"].ToString()!="")
				{
					model.dxycsj=int.Parse(ds.Tables[0].Rows[0]["dxycsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["msm_content_2"]!=null && ds.Tables[0].Rows[0]["msm_content_2"].ToString()!="")
				{
					model.msm_content_2=ds.Tables[0].Rows[0]["msm_content_2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["msm_content_3"]!=null && ds.Tables[0].Rows[0]["msm_content_3"].ToString()!="")
				{
					model.msm_content_3=ds.Tables[0].Rows[0]["msm_content_3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["msm_content_4"]!=null && ds.Tables[0].Rows[0]["msm_content_4"].ToString()!="")
				{
					model.msm_content_4=ds.Tables[0].Rows[0]["msm_content_4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["msm_content_5"]!=null && ds.Tables[0].Rows[0]["msm_content_5"].ToString()!="")
				{
					model.msm_content_5=ds.Tables[0].Rows[0]["msm_content_5"].ToString();
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
			strSql.Append("select id,yydh,qymc,hy_action_flage,msm_content,enable,dxycsj,msm_content_2,msm_content_3,msm_content_4,msm_content_5 ");
			strSql.Append(" FROM hhyyz_dx ");
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
			strSql.Append(" id,yydh,qymc,hy_action_flage,msm_content,enable,dxycsj,msm_content_2,msm_content_3,msm_content_4,msm_content_5 ");
			strSql.Append(" FROM hhyyz_dx ");
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
			strSql.Append("select count(1) FROM hhyyz_dx ");
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
			strSql.Append(")AS Row, T.*  from hhyyz_dx T ");
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
			parameters[0].Value = "hhyyz_dx";
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

