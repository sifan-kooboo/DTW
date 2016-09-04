using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:RegisterInfo_temp
	/// </summary>
	public partial class RegisterInfo_temp
	{
		public RegisterInfo_temp()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "RegisterInfo_temp"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RegisterInfo_temp");
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
		public int Add(Hotel_app.Model.RegisterInfo_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RegisterInfo_temp(");
			strSql.Append("DiskID,CpuID,MachineID,RegisterTime,Email,UserName,UserGuid,mobile,RegisterYears,xxzs,RegisterKey,StartUseTime,EndUseTime,UseTimes,lastLoginTime,RegisterKey_temp)");
			strSql.Append(" values (");
			strSql.Append("@DiskID,@CpuID,@MachineID,@RegisterTime,@Email,@UserName,@UserGuid,@mobile,@RegisterYears,@xxzs,@RegisterKey,@StartUseTime,@EndUseTime,@UseTimes,@lastLoginTime,@RegisterKey_temp)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DiskID", SqlDbType.VarChar,1000),
					new SqlParameter("@CpuID", SqlDbType.VarChar,1000),
					new SqlParameter("@MachineID", SqlDbType.VarChar,1000),
					new SqlParameter("@RegisterTime", SqlDbType.DateTime),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserGuid", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@RegisterYears", SqlDbType.Int,4),
					new SqlParameter("@xxzs", SqlDbType.VarChar,50),
					new SqlParameter("@RegisterKey", SqlDbType.VarChar,200),
					new SqlParameter("@StartUseTime", SqlDbType.DateTime),
					new SqlParameter("@EndUseTime", SqlDbType.DateTime),
					new SqlParameter("@UseTimes", SqlDbType.Int,4),
					new SqlParameter("@lastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@RegisterKey_temp", SqlDbType.VarChar,50)};
			parameters[0].Value = model.DiskID;
			parameters[1].Value = model.CpuID;
			parameters[2].Value = model.MachineID;
			parameters[3].Value = model.RegisterTime;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.UserName;
			parameters[6].Value = model.UserGuid;
			parameters[7].Value = model.mobile;
			parameters[8].Value = model.RegisterYears;
			parameters[9].Value = model.xxzs;
			parameters[10].Value = model.RegisterKey;
			parameters[11].Value = model.StartUseTime;
			parameters[12].Value = model.EndUseTime;
			parameters[13].Value = model.UseTimes;
			parameters[14].Value = model.lastLoginTime;
			parameters[15].Value = model.RegisterKey_temp;

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
		public bool Update(Hotel_app.Model.RegisterInfo_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RegisterInfo_temp set ");
			strSql.Append("DiskID=@DiskID,");
			strSql.Append("CpuID=@CpuID,");
			strSql.Append("MachineID=@MachineID,");
			strSql.Append("RegisterTime=@RegisterTime,");
			strSql.Append("Email=@Email,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserGuid=@UserGuid,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("RegisterYears=@RegisterYears,");
			strSql.Append("xxzs=@xxzs,");
			strSql.Append("RegisterKey=@RegisterKey,");
			strSql.Append("StartUseTime=@StartUseTime,");
			strSql.Append("EndUseTime=@EndUseTime,");
			strSql.Append("UseTimes=@UseTimes,");
			strSql.Append("lastLoginTime=@lastLoginTime,");
			strSql.Append("RegisterKey_temp=@RegisterKey_temp");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@DiskID", SqlDbType.VarChar,1000),
					new SqlParameter("@CpuID", SqlDbType.VarChar,1000),
					new SqlParameter("@MachineID", SqlDbType.VarChar,1000),
					new SqlParameter("@RegisterTime", SqlDbType.DateTime),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserGuid", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@RegisterYears", SqlDbType.Int,4),
					new SqlParameter("@xxzs", SqlDbType.VarChar,50),
					new SqlParameter("@RegisterKey", SqlDbType.VarChar,200),
					new SqlParameter("@StartUseTime", SqlDbType.DateTime),
					new SqlParameter("@EndUseTime", SqlDbType.DateTime),
					new SqlParameter("@UseTimes", SqlDbType.Int,4),
					new SqlParameter("@lastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@RegisterKey_temp", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.DiskID;
			parameters[1].Value = model.CpuID;
			parameters[2].Value = model.MachineID;
			parameters[3].Value = model.RegisterTime;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.UserName;
			parameters[6].Value = model.UserGuid;
			parameters[7].Value = model.mobile;
			parameters[8].Value = model.RegisterYears;
			parameters[9].Value = model.xxzs;
			parameters[10].Value = model.RegisterKey;
			parameters[11].Value = model.StartUseTime;
			parameters[12].Value = model.EndUseTime;
			parameters[13].Value = model.UseTimes;
			parameters[14].Value = model.lastLoginTime;
			parameters[15].Value = model.RegisterKey_temp;
			parameters[16].Value = model.id;

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
			strSql.Append("delete from RegisterInfo_temp ");
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
			strSql.Append("delete from RegisterInfo_temp ");
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
		public Hotel_app.Model.RegisterInfo_temp GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,DiskID,CpuID,MachineID,RegisterTime,Email,UserName,UserGuid,mobile,RegisterYears,xxzs,RegisterKey,StartUseTime,EndUseTime,UseTimes,lastLoginTime,RegisterKey_temp from RegisterInfo_temp ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.RegisterInfo_temp model=new Hotel_app.Model.RegisterInfo_temp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DiskID"]!=null && ds.Tables[0].Rows[0]["DiskID"].ToString()!="")
				{
					model.DiskID=ds.Tables[0].Rows[0]["DiskID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CpuID"]!=null && ds.Tables[0].Rows[0]["CpuID"].ToString()!="")
				{
					model.CpuID=ds.Tables[0].Rows[0]["CpuID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MachineID"]!=null && ds.Tables[0].Rows[0]["MachineID"].ToString()!="")
				{
					model.MachineID=ds.Tables[0].Rows[0]["MachineID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RegisterTime"]!=null && ds.Tables[0].Rows[0]["RegisterTime"].ToString()!="")
				{
					model.RegisterTime=DateTime.Parse(ds.Tables[0].Rows[0]["RegisterTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UserName"]!=null && ds.Tables[0].Rows[0]["UserName"].ToString()!="")
				{
					model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UserGuid"]!=null && ds.Tables[0].Rows[0]["UserGuid"].ToString()!="")
				{
					model.UserGuid=ds.Tables[0].Rows[0]["UserGuid"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mobile"]!=null && ds.Tables[0].Rows[0]["mobile"].ToString()!="")
				{
					model.mobile=ds.Tables[0].Rows[0]["mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RegisterYears"]!=null && ds.Tables[0].Rows[0]["RegisterYears"].ToString()!="")
				{
					model.RegisterYears=int.Parse(ds.Tables[0].Rows[0]["RegisterYears"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xxzs"]!=null && ds.Tables[0].Rows[0]["xxzs"].ToString()!="")
				{
					model.xxzs=ds.Tables[0].Rows[0]["xxzs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RegisterKey"]!=null && ds.Tables[0].Rows[0]["RegisterKey"].ToString()!="")
				{
					model.RegisterKey=ds.Tables[0].Rows[0]["RegisterKey"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StartUseTime"]!=null && ds.Tables[0].Rows[0]["StartUseTime"].ToString()!="")
				{
					model.StartUseTime=DateTime.Parse(ds.Tables[0].Rows[0]["StartUseTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndUseTime"]!=null && ds.Tables[0].Rows[0]["EndUseTime"].ToString()!="")
				{
					model.EndUseTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndUseTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UseTimes"]!=null && ds.Tables[0].Rows[0]["UseTimes"].ToString()!="")
				{
					model.UseTimes=int.Parse(ds.Tables[0].Rows[0]["UseTimes"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lastLoginTime"]!=null && ds.Tables[0].Rows[0]["lastLoginTime"].ToString()!="")
				{
					model.lastLoginTime=DateTime.Parse(ds.Tables[0].Rows[0]["lastLoginTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RegisterKey_temp"]!=null && ds.Tables[0].Rows[0]["RegisterKey_temp"].ToString()!="")
				{
					model.RegisterKey_temp=ds.Tables[0].Rows[0]["RegisterKey_temp"].ToString();
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
			strSql.Append("select id,DiskID,CpuID,MachineID,RegisterTime,Email,UserName,UserGuid,mobile,RegisterYears,xxzs,RegisterKey,StartUseTime,EndUseTime,UseTimes,lastLoginTime,RegisterKey_temp ");
			strSql.Append(" FROM RegisterInfo_temp ");
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
			strSql.Append(" id,DiskID,CpuID,MachineID,RegisterTime,Email,UserName,UserGuid,mobile,RegisterYears,xxzs,RegisterKey,StartUseTime,EndUseTime,UseTimes,lastLoginTime,RegisterKey_temp ");
			strSql.Append(" FROM RegisterInfo_temp ");
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
			strSql.Append("select count(1) FROM RegisterInfo_temp ");
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
			strSql.Append(")AS Row, T.*  from RegisterInfo_temp T ");
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
			parameters[0].Value = "RegisterInfo_temp";
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

