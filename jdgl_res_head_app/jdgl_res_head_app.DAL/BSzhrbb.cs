using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace jdgl_res_head_app.DAL
{
	/// <summary>
	/// 数据访问类:BSzhrbb
	/// </summary>
	public partial class BSzhrbb
	{
		public BSzhrbb()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "BSzhrbb"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BSzhrbb");
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
		public int Add(jdgl_res_head_app.Model.BSzhrbb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BSzhrbb(");
			strSql.Append("yydh,qymc,bbrq,rbxm,brrj,byrj,rbxm0,brrj0,byrj0,shsc)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@bbrq,@rbxm,@brrj,@byrj,@rbxm0,@brrj0,@byrj0,@shsc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bbrq", SqlDbType.DateTime),
					new SqlParameter("@rbxm", SqlDbType.VarChar,50),
					new SqlParameter("@brrj", SqlDbType.VarChar,50),
					new SqlParameter("@byrj", SqlDbType.VarChar,50),
					new SqlParameter("@rbxm0", SqlDbType.VarChar,50),
					new SqlParameter("@brrj0", SqlDbType.VarChar,50),
					new SqlParameter("@byrj0", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.bbrq;
			parameters[3].Value = model.rbxm;
			parameters[4].Value = model.brrj;
			parameters[5].Value = model.byrj;
			parameters[6].Value = model.rbxm0;
			parameters[7].Value = model.brrj0;
			parameters[8].Value = model.byrj0;
			parameters[9].Value = model.shsc;

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
		public bool Update(jdgl_res_head_app.Model.BSzhrbb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BSzhrbb set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("bbrq=@bbrq,");
			strSql.Append("rbxm=@rbxm,");
			strSql.Append("brrj=@brrj,");
			strSql.Append("byrj=@byrj,");
			strSql.Append("rbxm0=@rbxm0,");
			strSql.Append("brrj0=@brrj0,");
			strSql.Append("byrj0=@byrj0,");
			strSql.Append("shsc=@shsc");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bbrq", SqlDbType.DateTime),
					new SqlParameter("@rbxm", SqlDbType.VarChar,50),
					new SqlParameter("@brrj", SqlDbType.VarChar,50),
					new SqlParameter("@byrj", SqlDbType.VarChar,50),
					new SqlParameter("@rbxm0", SqlDbType.VarChar,50),
					new SqlParameter("@brrj0", SqlDbType.VarChar,50),
					new SqlParameter("@byrj0", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.bbrq;
			parameters[3].Value = model.rbxm;
			parameters[4].Value = model.brrj;
			parameters[5].Value = model.byrj;
			parameters[6].Value = model.rbxm0;
			parameters[7].Value = model.brrj0;
			parameters[8].Value = model.byrj0;
			parameters[9].Value = model.shsc;
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
			strSql.Append("delete from BSzhrbb ");
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
			strSql.Append("delete from BSzhrbb ");
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
		public jdgl_res_head_app.Model.BSzhrbb GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,bbrq,rbxm,brrj,byrj,rbxm0,brrj0,byrj0,shsc from BSzhrbb ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			jdgl_res_head_app.Model.BSzhrbb model=new jdgl_res_head_app.Model.BSzhrbb();
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
				if(ds.Tables[0].Rows[0]["bbrq"]!=null && ds.Tables[0].Rows[0]["bbrq"].ToString()!="")
				{
					model.bbrq=DateTime.Parse(ds.Tables[0].Rows[0]["bbrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["rbxm"]!=null && ds.Tables[0].Rows[0]["rbxm"].ToString()!="")
				{
					model.rbxm=ds.Tables[0].Rows[0]["rbxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["brrj"]!=null && ds.Tables[0].Rows[0]["brrj"].ToString()!="")
				{
					model.brrj=ds.Tables[0].Rows[0]["brrj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["byrj"]!=null && ds.Tables[0].Rows[0]["byrj"].ToString()!="")
				{
					model.byrj=ds.Tables[0].Rows[0]["byrj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["rbxm0"]!=null && ds.Tables[0].Rows[0]["rbxm0"].ToString()!="")
				{
					model.rbxm0=ds.Tables[0].Rows[0]["rbxm0"].ToString();
				}
				if(ds.Tables[0].Rows[0]["brrj0"]!=null && ds.Tables[0].Rows[0]["brrj0"].ToString()!="")
				{
					model.brrj0=ds.Tables[0].Rows[0]["brrj0"].ToString();
				}
				if(ds.Tables[0].Rows[0]["byrj0"]!=null && ds.Tables[0].Rows[0]["byrj0"].ToString()!="")
				{
					model.byrj0=ds.Tables[0].Rows[0]["byrj0"].ToString();
				}
				if(ds.Tables[0].Rows[0]["shsc"]!=null && ds.Tables[0].Rows[0]["shsc"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shsc"].ToString()=="1")||(ds.Tables[0].Rows[0]["shsc"].ToString().ToLower()=="true"))
					{
						model.shsc=true;
					}
					else
					{
						model.shsc=false;
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
			strSql.Append("select id,yydh,qymc,bbrq,rbxm,brrj,byrj,rbxm0,brrj0,byrj0,shsc ");
			strSql.Append(" FROM BSzhrbb ");
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
			strSql.Append(" id,yydh,qymc,bbrq,rbxm,brrj,byrj,rbxm0,brrj0,byrj0,shsc ");
			strSql.Append(" FROM BSzhrbb ");
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
			strSql.Append("select count(1) FROM BSzhrbb ");
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
			strSql.Append(")AS Row, T.*  from BSzhrbb T ");
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
			parameters[0].Value = "BSzhrbb";
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

