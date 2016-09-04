using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Q_lskr_xftj
	/// </summary>
	public partial class Q_lskr_xftj
	{
		public Q_lskr_xftj()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Q_lskr_xftj"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Q_lskr_xftj");
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
		public int Add(Hotel_app.Model.Q_lskr_xftj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Q_lskr_xftj(");
			strSql.Append("yydh,qymc,zjhm,krxm,lzcs,xfje_ff,xfje_cp,xfje_js,xfje_other,lzfs,shsc)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@zjhm,@krxm,@lzcs,@xfje_ff,@xfje_cp,@xfje_js,@xfje_other,@lzfs,@shsc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@lzcs", SqlDbType.Decimal,9),
					new SqlParameter("@xfje_ff", SqlDbType.Decimal,9),
					new SqlParameter("@xfje_cp", SqlDbType.Decimal,9),
					new SqlParameter("@xfje_js", SqlDbType.Decimal,9),
					new SqlParameter("@xfje_other", SqlDbType.Decimal,9),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.zjhm;
			parameters[3].Value = model.krxm;
			parameters[4].Value = model.lzcs;
			parameters[5].Value = model.xfje_ff;
			parameters[6].Value = model.xfje_cp;
			parameters[7].Value = model.xfje_js;
			parameters[8].Value = model.xfje_other;
			parameters[9].Value = model.lzfs;
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
		public bool Update(Hotel_app.Model.Q_lskr_xftj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Q_lskr_xftj set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("lzcs=@lzcs,");
			strSql.Append("xfje_ff=@xfje_ff,");
			strSql.Append("xfje_cp=@xfje_cp,");
			strSql.Append("xfje_js=@xfje_js,");
			strSql.Append("xfje_other=@xfje_other,");
			strSql.Append("lzfs=@lzfs,");
			strSql.Append("shsc=@shsc");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@lzcs", SqlDbType.Decimal,9),
					new SqlParameter("@xfje_ff", SqlDbType.Decimal,9),
					new SqlParameter("@xfje_cp", SqlDbType.Decimal,9),
					new SqlParameter("@xfje_js", SqlDbType.Decimal,9),
					new SqlParameter("@xfje_other", SqlDbType.Decimal,9),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.zjhm;
			parameters[3].Value = model.krxm;
			parameters[4].Value = model.lzcs;
			parameters[5].Value = model.xfje_ff;
			parameters[6].Value = model.xfje_cp;
			parameters[7].Value = model.xfje_js;
			parameters[8].Value = model.xfje_other;
			parameters[9].Value = model.lzfs;
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
			strSql.Append("delete from Q_lskr_xftj ");
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
			strSql.Append("delete from Q_lskr_xftj ");
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
		public Hotel_app.Model.Q_lskr_xftj GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,zjhm,krxm,lzcs,xfje_ff,xfje_cp,xfje_js,xfje_other,lzfs,shsc from Q_lskr_xftj ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Q_lskr_xftj model=new Hotel_app.Model.Q_lskr_xftj();
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
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lzcs"]!=null && ds.Tables[0].Rows[0]["lzcs"].ToString()!="")
				{
					model.lzcs=decimal.Parse(ds.Tables[0].Rows[0]["lzcs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje_ff"]!=null && ds.Tables[0].Rows[0]["xfje_ff"].ToString()!="")
				{
					model.xfje_ff=decimal.Parse(ds.Tables[0].Rows[0]["xfje_ff"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje_cp"]!=null && ds.Tables[0].Rows[0]["xfje_cp"].ToString()!="")
				{
					model.xfje_cp=decimal.Parse(ds.Tables[0].Rows[0]["xfje_cp"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje_js"]!=null && ds.Tables[0].Rows[0]["xfje_js"].ToString()!="")
				{
					model.xfje_js=decimal.Parse(ds.Tables[0].Rows[0]["xfje_js"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje_other"]!=null && ds.Tables[0].Rows[0]["xfje_other"].ToString()!="")
				{
					model.xfje_other=decimal.Parse(ds.Tables[0].Rows[0]["xfje_other"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzfs"]!=null && ds.Tables[0].Rows[0]["lzfs"].ToString()!="")
				{
					model.lzfs=decimal.Parse(ds.Tables[0].Rows[0]["lzfs"].ToString());
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
			strSql.Append("select id,yydh,qymc,zjhm,krxm,lzcs,xfje_ff,xfje_cp,xfje_js,xfje_other,lzfs,shsc ");
			strSql.Append(" FROM Q_lskr_xftj ");
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
			strSql.Append(" id,yydh,qymc,zjhm,krxm,lzcs,xfje_ff,xfje_cp,xfje_js,xfje_other,lzfs,shsc ");
			strSql.Append(" FROM Q_lskr_xftj ");
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
			strSql.Append("select count(1) FROM Q_lskr_xftj ");
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
			strSql.Append(")AS Row, T.*  from Q_lskr_xftj T ");
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
			parameters[0].Value = "Q_lskr_xftj";
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

