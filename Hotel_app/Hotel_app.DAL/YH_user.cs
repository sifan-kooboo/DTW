using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:YH_user
	/// </summary>
	public partial class YH_user
	{
		public YH_user()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "YH_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YH_user");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.YH_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YH_user(");
			strSql.Append("yydh,qymc,yhbh,yhbm,yhxm,yhmm,R_lsbh,RoleName,is_top,is_select,zjm)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@yhbh,@yhbm,@yhxm,@yhmm,@R_lsbh,@RoleName,@is_top,@is_select,@zjm)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,100),
					new SqlParameter("@yhbh", SqlDbType.VarChar,50),
					new SqlParameter("@yhbm", SqlDbType.VarChar,50),
					new SqlParameter("@yhxm", SqlDbType.VarChar,50),
					new SqlParameter("@yhmm", SqlDbType.VarChar,50),
					new SqlParameter("@R_lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@zjm", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.yhbh;
			parameters[3].Value = model.yhbm;
			parameters[4].Value = model.yhxm;
			parameters[5].Value = model.yhmm;
			parameters[6].Value = model.R_lsbh;
			parameters[7].Value = model.RoleName;
			parameters[8].Value = model.is_top;
			parameters[9].Value = model.is_select;
			parameters[10].Value = model.zjm;

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
		public bool Update(Hotel_app.Model.YH_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YH_user set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("yhbh=@yhbh,");
			strSql.Append("yhbm=@yhbm,");
			strSql.Append("yhxm=@yhxm,");
			strSql.Append("yhmm=@yhmm,");
			strSql.Append("R_lsbh=@R_lsbh,");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("zjm=@zjm");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,100),
					new SqlParameter("@yhbh", SqlDbType.VarChar,50),
					new SqlParameter("@yhbm", SqlDbType.VarChar,50),
					new SqlParameter("@yhxm", SqlDbType.VarChar,50),
					new SqlParameter("@yhmm", SqlDbType.VarChar,50),
					new SqlParameter("@R_lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@zjm", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.yhbh;
			parameters[3].Value = model.yhbm;
			parameters[4].Value = model.yhxm;
			parameters[5].Value = model.yhmm;
			parameters[6].Value = model.R_lsbh;
			parameters[7].Value = model.RoleName;
			parameters[8].Value = model.is_top;
			parameters[9].Value = model.is_select;
			parameters[10].Value = model.zjm;
			parameters[11].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YH_user ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YH_user ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Hotel_app.Model.YH_user GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,yydh,qymc,yhbh,yhbm,yhxm,yhmm,R_lsbh,RoleName,is_top,is_select,zjm from YH_user ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Hotel_app.Model.YH_user model=new Hotel_app.Model.YH_user();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yhbh"]!=null && ds.Tables[0].Rows[0]["yhbh"].ToString()!="")
				{
					model.yhbh=ds.Tables[0].Rows[0]["yhbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yhbm"]!=null && ds.Tables[0].Rows[0]["yhbm"].ToString()!="")
				{
					model.yhbm=ds.Tables[0].Rows[0]["yhbm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yhxm"]!=null && ds.Tables[0].Rows[0]["yhxm"].ToString()!="")
				{
					model.yhxm=ds.Tables[0].Rows[0]["yhxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yhmm"]!=null && ds.Tables[0].Rows[0]["yhmm"].ToString()!="")
				{
					model.yhmm=ds.Tables[0].Rows[0]["yhmm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["R_lsbh"]!=null && ds.Tables[0].Rows[0]["R_lsbh"].ToString()!="")
				{
					model.R_lsbh=ds.Tables[0].Rows[0]["R_lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RoleName"]!=null && ds.Tables[0].Rows[0]["RoleName"].ToString()!="")
				{
					model.RoleName=ds.Tables[0].Rows[0]["RoleName"].ToString();
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
				if(ds.Tables[0].Rows[0]["zjm"]!=null && ds.Tables[0].Rows[0]["zjm"].ToString()!="")
				{
					model.zjm=ds.Tables[0].Rows[0]["zjm"].ToString();
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
			strSql.Append("select ID,yydh,qymc,yhbh,yhbm,yhxm,yhmm,R_lsbh,RoleName,is_top,is_select,zjm ");
			strSql.Append(" FROM YH_user ");
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
			strSql.Append(" ID,yydh,qymc,yhbh,yhbm,yhxm,yhmm,R_lsbh,RoleName,is_top,is_select,zjm ");
			strSql.Append(" FROM YH_user ");
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
			strSql.Append("select count(1) FROM YH_user ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from YH_user T ");
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
			parameters[0].Value = "YH_user";
			parameters[1].Value = "ID";
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

