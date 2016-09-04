using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:YH_RolePermission
	/// </summary>
	public partial class YH_RolePermission
	{
		public YH_RolePermission()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "YH_RolePermission"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YH_RolePermission");
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
		public int Add(Hotel_app.Model.YH_RolePermission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YH_RolePermission(");
			strSql.Append("yydh,qymc,R_lsbh,R_RolesName,p_lsbh,A_Appdr,A_AppName,P_Value,is_top,is_select)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@R_lsbh,@R_RolesName,@p_lsbh,@A_Appdr,@A_AppName,@P_Value,@is_top,@is_select)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,100),
					new SqlParameter("@R_lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@R_RolesName", SqlDbType.VarChar,50),
					new SqlParameter("@p_lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@A_Appdr", SqlDbType.VarChar,50),
					new SqlParameter("@A_AppName", SqlDbType.VarChar,50),
					new SqlParameter("@P_Value", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.R_lsbh;
			parameters[3].Value = model.R_RolesName;
			parameters[4].Value = model.p_lsbh;
			parameters[5].Value = model.A_Appdr;
			parameters[6].Value = model.A_AppName;
			parameters[7].Value = model.P_Value;
			parameters[8].Value = model.is_top;
			parameters[9].Value = model.is_select;

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
		public bool Update(Hotel_app.Model.YH_RolePermission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YH_RolePermission set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("R_lsbh=@R_lsbh,");
			strSql.Append("R_RolesName=@R_RolesName,");
			strSql.Append("p_lsbh=@p_lsbh,");
			strSql.Append("A_Appdr=@A_Appdr,");
			strSql.Append("A_AppName=@A_AppName,");
			strSql.Append("P_Value=@P_Value,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,100),
					new SqlParameter("@R_lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@R_RolesName", SqlDbType.VarChar,50),
					new SqlParameter("@p_lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@A_Appdr", SqlDbType.VarChar,50),
					new SqlParameter("@A_AppName", SqlDbType.VarChar,50),
					new SqlParameter("@P_Value", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.R_lsbh;
			parameters[3].Value = model.R_RolesName;
			parameters[4].Value = model.p_lsbh;
			parameters[5].Value = model.A_Appdr;
			parameters[6].Value = model.A_AppName;
			parameters[7].Value = model.P_Value;
			parameters[8].Value = model.is_top;
			parameters[9].Value = model.is_select;
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from YH_RolePermission ");
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
			strSql.Append("delete from YH_RolePermission ");
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
		public Hotel_app.Model.YH_RolePermission GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,yydh,qymc,R_lsbh,R_RolesName,p_lsbh,A_Appdr,A_AppName,P_Value,is_top,is_select from YH_RolePermission ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Hotel_app.Model.YH_RolePermission model=new Hotel_app.Model.YH_RolePermission();
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
				if(ds.Tables[0].Rows[0]["R_lsbh"]!=null && ds.Tables[0].Rows[0]["R_lsbh"].ToString()!="")
				{
					model.R_lsbh=ds.Tables[0].Rows[0]["R_lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["R_RolesName"]!=null && ds.Tables[0].Rows[0]["R_RolesName"].ToString()!="")
				{
					model.R_RolesName=ds.Tables[0].Rows[0]["R_RolesName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["p_lsbh"]!=null && ds.Tables[0].Rows[0]["p_lsbh"].ToString()!="")
				{
					model.p_lsbh=ds.Tables[0].Rows[0]["p_lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["A_Appdr"]!=null && ds.Tables[0].Rows[0]["A_Appdr"].ToString()!="")
				{
					model.A_Appdr=ds.Tables[0].Rows[0]["A_Appdr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["A_AppName"]!=null && ds.Tables[0].Rows[0]["A_AppName"].ToString()!="")
				{
					model.A_AppName=ds.Tables[0].Rows[0]["A_AppName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["P_Value"]!=null && ds.Tables[0].Rows[0]["P_Value"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["P_Value"].ToString()=="1")||(ds.Tables[0].Rows[0]["P_Value"].ToString().ToLower()=="true"))
					{
						model.P_Value=true;
					}
					else
					{
						model.P_Value=false;
					}
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
			strSql.Append("select ID,yydh,qymc,R_lsbh,R_RolesName,p_lsbh,A_Appdr,A_AppName,P_Value,is_top,is_select ");
			strSql.Append(" FROM YH_RolePermission ");
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
			strSql.Append(" ID,yydh,qymc,R_lsbh,R_RolesName,p_lsbh,A_Appdr,A_AppName,P_Value,is_top,is_select ");
			strSql.Append(" FROM YH_RolePermission ");
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
			strSql.Append("select count(1) FROM YH_RolePermission ");
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
			strSql.Append(")AS Row, T.*  from YH_RolePermission T ");
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
			parameters[0].Value = "YH_RolePermission";
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

