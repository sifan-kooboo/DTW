using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Q_sfz_save
	/// </summary>
	public partial class Q_sfz_save
	{
		public Q_sfz_save()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Q_sfz_save"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Q_sfz_save");
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
		public int Add(Hotel_app.Model.Q_sfz_save model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Q_sfz_save(");
			strSql.Append("zjhm,krxm,krmz,krxb,krsr,krdz,department,startdate,enddate,krxp,shsc)");
			strSql.Append(" values (");
			strSql.Append("@zjhm,@krxm,@krmz,@krxb,@krsr,@krdz,@department,@startdate,@enddate,@krxp,@shsc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdz", SqlDbType.VarChar,200),
					new SqlParameter("@department", SqlDbType.VarChar,50),
					new SqlParameter("@startdate", SqlDbType.DateTime),
					new SqlParameter("@enddate", SqlDbType.DateTime),
					new SqlParameter("@krxp", SqlDbType.Image),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
			parameters[0].Value = model.zjhm;
			parameters[1].Value = model.krxm;
			parameters[2].Value = model.krmz;
			parameters[3].Value = model.krxb;
			parameters[4].Value = model.krsr;
			parameters[5].Value = model.krdz;
			parameters[6].Value = model.department;
			parameters[7].Value = model.startdate;
			parameters[8].Value = model.enddate;
			parameters[9].Value = model.krxp;
			parameters[10].Value = model.shsc;

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
		public bool Update(Hotel_app.Model.Q_sfz_save model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Q_sfz_save set ");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("krmz=@krmz,");
			strSql.Append("krxb=@krxb,");
			strSql.Append("krsr=@krsr,");
			strSql.Append("krdz=@krdz,");
			strSql.Append("department=@department,");
			strSql.Append("startdate=@startdate,");
			strSql.Append("enddate=@enddate,");
			strSql.Append("krxp=@krxp,");
			strSql.Append("shsc=@shsc");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdz", SqlDbType.VarChar,200),
					new SqlParameter("@department", SqlDbType.VarChar,50),
					new SqlParameter("@startdate", SqlDbType.DateTime),
					new SqlParameter("@enddate", SqlDbType.DateTime),
					new SqlParameter("@krxp", SqlDbType.Image),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.zjhm;
			parameters[1].Value = model.krxm;
			parameters[2].Value = model.krmz;
			parameters[3].Value = model.krxb;
			parameters[4].Value = model.krsr;
			parameters[5].Value = model.krdz;
			parameters[6].Value = model.department;
			parameters[7].Value = model.startdate;
			parameters[8].Value = model.enddate;
			parameters[9].Value = model.krxp;
			parameters[10].Value = model.shsc;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from Q_sfz_save ");
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
			strSql.Append("delete from Q_sfz_save ");
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
		public Hotel_app.Model.Q_sfz_save GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,zjhm,krxm,krmz,krxb,krsr,krdz,department,startdate,enddate,krxp,shsc from Q_sfz_save ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Q_sfz_save model=new Hotel_app.Model.Q_sfz_save();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krmz"]!=null && ds.Tables[0].Rows[0]["krmz"].ToString()!="")
				{
					model.krmz=ds.Tables[0].Rows[0]["krmz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxb"]!=null && ds.Tables[0].Rows[0]["krxb"].ToString()!="")
				{
					model.krxb=ds.Tables[0].Rows[0]["krxb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsr"]!=null && ds.Tables[0].Rows[0]["krsr"].ToString()!="")
				{
					model.krsr=DateTime.Parse(ds.Tables[0].Rows[0]["krsr"].ToString());
				}
				if(ds.Tables[0].Rows[0]["krdz"]!=null && ds.Tables[0].Rows[0]["krdz"].ToString()!="")
				{
					model.krdz=ds.Tables[0].Rows[0]["krdz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["department"]!=null && ds.Tables[0].Rows[0]["department"].ToString()!="")
				{
					model.department=ds.Tables[0].Rows[0]["department"].ToString();
				}
				if(ds.Tables[0].Rows[0]["startdate"]!=null && ds.Tables[0].Rows[0]["startdate"].ToString()!="")
				{
					model.startdate=DateTime.Parse(ds.Tables[0].Rows[0]["startdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["enddate"]!=null && ds.Tables[0].Rows[0]["enddate"].ToString()!="")
				{
					model.enddate=DateTime.Parse(ds.Tables[0].Rows[0]["enddate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["krxp"]!=null && ds.Tables[0].Rows[0]["krxp"].ToString()!="")
				{
					model.krxp=(byte[])ds.Tables[0].Rows[0]["krxp"];
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
			strSql.Append("select id,zjhm,krxm,krmz,krxb,krsr,krdz,department,startdate,enddate,krxp,shsc ");
			strSql.Append(" FROM Q_sfz_save ");
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
			strSql.Append(" id,zjhm,krxm,krmz,krxb,krsr,krdz,department,startdate,enddate,krxp,shsc ");
			strSql.Append(" FROM Q_sfz_save ");
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
			strSql.Append("select count(1) FROM Q_sfz_save ");
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
			strSql.Append(")AS Row, T.*  from Q_sfz_save T ");
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
			parameters[0].Value = "Q_sfz_save";
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

