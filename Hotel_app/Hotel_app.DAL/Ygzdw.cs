using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Ygzdw
	/// </summary>
	public partial class Ygzdw
	{
		public Ygzdw()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.Ygzdw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ygzdw(");
			strSql.Append("ID,dwrx,gzdw,nxr,nxdh,nxcz,Email,nxdz,xsy,zjm)");
			strSql.Append(" values (");
			strSql.Append("@ID,@dwrx,@gzdw,@nxr,@nxdh,@nxcz,@Email,@nxdz,@xsy,@zjm)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@dwrx", SqlDbType.VarChar,50),
					new SqlParameter("@gzdw", SqlDbType.VarChar,50),
					new SqlParameter("@nxr", SqlDbType.VarChar,50),
					new SqlParameter("@nxdh", SqlDbType.VarChar,50),
					new SqlParameter("@nxcz", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@nxdz", SqlDbType.VarChar,200),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@zjm", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.dwrx;
			parameters[2].Value = model.gzdw;
			parameters[3].Value = model.nxr;
			parameters[4].Value = model.nxdh;
			parameters[5].Value = model.nxcz;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.nxdz;
			parameters[8].Value = model.xsy;
			parameters[9].Value = model.zjm;

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
		public bool Update(Hotel_app.Model.Ygzdw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ygzdw set ");
			strSql.Append("ID=@ID,");
			strSql.Append("dwrx=@dwrx,");
			strSql.Append("gzdw=@gzdw,");
			strSql.Append("nxr=@nxr,");
			strSql.Append("nxdh=@nxdh,");
			strSql.Append("nxcz=@nxcz,");
			strSql.Append("Email=@Email,");
			strSql.Append("nxdz=@nxdz,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("zjm=@zjm");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@dwrx", SqlDbType.VarChar,50),
					new SqlParameter("@gzdw", SqlDbType.VarChar,50),
					new SqlParameter("@nxr", SqlDbType.VarChar,50),
					new SqlParameter("@nxdh", SqlDbType.VarChar,50),
					new SqlParameter("@nxcz", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@nxdz", SqlDbType.VarChar,200),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@zjm", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.dwrx;
			parameters[2].Value = model.gzdw;
			parameters[3].Value = model.nxr;
			parameters[4].Value = model.nxdh;
			parameters[5].Value = model.nxcz;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.nxdz;
			parameters[8].Value = model.xsy;
			parameters[9].Value = model.zjm;

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
			strSql.Append("delete from Ygzdw ");
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
		public Hotel_app.Model.Ygzdw GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,dwrx,gzdw,nxr,nxdh,nxcz,Email,nxdz,xsy,zjm from Ygzdw ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.Ygzdw model=new Hotel_app.Model.Ygzdw();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dwrx"]!=null && ds.Tables[0].Rows[0]["dwrx"].ToString()!="")
				{
					model.dwrx=ds.Tables[0].Rows[0]["dwrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gzdw"]!=null && ds.Tables[0].Rows[0]["gzdw"].ToString()!="")
				{
					model.gzdw=ds.Tables[0].Rows[0]["gzdw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nxr"]!=null && ds.Tables[0].Rows[0]["nxr"].ToString()!="")
				{
					model.nxr=ds.Tables[0].Rows[0]["nxr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nxdh"]!=null && ds.Tables[0].Rows[0]["nxdh"].ToString()!="")
				{
					model.nxdh=ds.Tables[0].Rows[0]["nxdh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nxcz"]!=null && ds.Tables[0].Rows[0]["nxcz"].ToString()!="")
				{
					model.nxcz=ds.Tables[0].Rows[0]["nxcz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nxdz"]!=null && ds.Tables[0].Rows[0]["nxdz"].ToString()!="")
				{
					model.nxdz=ds.Tables[0].Rows[0]["nxdz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xsy"]!=null && ds.Tables[0].Rows[0]["xsy"].ToString()!="")
				{
					model.xsy=ds.Tables[0].Rows[0]["xsy"].ToString();
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
			strSql.Append("select ID,dwrx,gzdw,nxr,nxdh,nxcz,Email,nxdz,xsy,zjm ");
			strSql.Append(" FROM Ygzdw ");
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
			strSql.Append(" ID,dwrx,gzdw,nxr,nxdh,nxcz,Email,nxdz,xsy,zjm ");
			strSql.Append(" FROM Ygzdw ");
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
			strSql.Append("select count(1) FROM Ygzdw ");
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
			strSql.Append(")AS Row, T.*  from Ygzdw T ");
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
			parameters[0].Value = "Ygzdw";
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

