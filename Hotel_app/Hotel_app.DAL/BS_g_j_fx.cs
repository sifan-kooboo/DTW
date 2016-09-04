using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:BS_g_j_fx
	/// </summary>
	public partial class BS_g_j_fx
	{
		public BS_g_j_fx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "BS_g_j_fx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BS_g_j_fx");
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
		public int Add(Hotel_app.Model.BS_g_j_fx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_g_j_fx(");
			strSql.Append("yydh,qymc,jzzt,type,zfh,ds,qt,zyye,zzz,zgz_zjz,zsz,wj,czy_temp,cssj,jssj)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@jzzt,@type,@zfh,@ds,@qt,@zyye,@zzz,@zgz_zjz,@zsz,@wj,@czy_temp,@cssj,@jssj)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@type", SqlDbType.VarChar,200),
					new SqlParameter("@zfh", SqlDbType.Float,8),
					new SqlParameter("@ds", SqlDbType.Float,8),
					new SqlParameter("@qt", SqlDbType.Float,8),
					new SqlParameter("@zyye", SqlDbType.Float,8),
					new SqlParameter("@zzz", SqlDbType.Float,8),
					new SqlParameter("@zgz_zjz", SqlDbType.Float,8),
					new SqlParameter("@zsz", SqlDbType.Float,8),
					new SqlParameter("@wj", SqlDbType.Float,8),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@cssj", SqlDbType.DateTime),
					new SqlParameter("@jssj", SqlDbType.DateTime)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.jzzt;
			parameters[3].Value = model.type;
			parameters[4].Value = model.zfh;
			parameters[5].Value = model.ds;
			parameters[6].Value = model.qt;
			parameters[7].Value = model.zyye;
			parameters[8].Value = model.zzz;
			parameters[9].Value = model.zgz_zjz;
			parameters[10].Value = model.zsz;
			parameters[11].Value = model.wj;
			parameters[12].Value = model.czy_temp;
			parameters[13].Value = model.cssj;
			parameters[14].Value = model.jssj;

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
		public bool Update(Hotel_app.Model.BS_g_j_fx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_g_j_fx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("jzzt=@jzzt,");
			strSql.Append("type=@type,");
			strSql.Append("zfh=@zfh,");
			strSql.Append("ds=@ds,");
			strSql.Append("qt=@qt,");
			strSql.Append("zyye=@zyye,");
			strSql.Append("zzz=@zzz,");
			strSql.Append("zgz_zjz=@zgz_zjz,");
			strSql.Append("zsz=@zsz,");
			strSql.Append("wj=@wj,");
			strSql.Append("czy_temp=@czy_temp,");
			strSql.Append("cssj=@cssj,");
			strSql.Append("jssj=@jssj");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@type", SqlDbType.VarChar,200),
					new SqlParameter("@zfh", SqlDbType.Float,8),
					new SqlParameter("@ds", SqlDbType.Float,8),
					new SqlParameter("@qt", SqlDbType.Float,8),
					new SqlParameter("@zyye", SqlDbType.Float,8),
					new SqlParameter("@zzz", SqlDbType.Float,8),
					new SqlParameter("@zgz_zjz", SqlDbType.Float,8),
					new SqlParameter("@zsz", SqlDbType.Float,8),
					new SqlParameter("@wj", SqlDbType.Float,8),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@cssj", SqlDbType.DateTime),
					new SqlParameter("@jssj", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.jzzt;
			parameters[3].Value = model.type;
			parameters[4].Value = model.zfh;
			parameters[5].Value = model.ds;
			parameters[6].Value = model.qt;
			parameters[7].Value = model.zyye;
			parameters[8].Value = model.zzz;
			parameters[9].Value = model.zgz_zjz;
			parameters[10].Value = model.zsz;
			parameters[11].Value = model.wj;
			parameters[12].Value = model.czy_temp;
			parameters[13].Value = model.cssj;
			parameters[14].Value = model.jssj;
			parameters[15].Value = model.id;

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
			strSql.Append("delete from BS_g_j_fx ");
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
			strSql.Append("delete from BS_g_j_fx ");
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
		public Hotel_app.Model.BS_g_j_fx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,jzzt,type,zfh,ds,qt,zyye,zzz,zgz_zjz,zsz,wj,czy_temp,cssj,jssj from BS_g_j_fx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.BS_g_j_fx model=new Hotel_app.Model.BS_g_j_fx();
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
				if(ds.Tables[0].Rows[0]["type"]!=null && ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=ds.Tables[0].Rows[0]["type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zfh"]!=null && ds.Tables[0].Rows[0]["zfh"].ToString()!="")
				{
					model.zfh=decimal.Parse(ds.Tables[0].Rows[0]["zfh"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ds"]!=null && ds.Tables[0].Rows[0]["ds"].ToString()!="")
				{
					model.ds=decimal.Parse(ds.Tables[0].Rows[0]["ds"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qt"]!=null && ds.Tables[0].Rows[0]["qt"].ToString()!="")
				{
					model.qt=decimal.Parse(ds.Tables[0].Rows[0]["qt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zyye"]!=null && ds.Tables[0].Rows[0]["zyye"].ToString()!="")
				{
					model.zyye=decimal.Parse(ds.Tables[0].Rows[0]["zyye"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zzz"]!=null && ds.Tables[0].Rows[0]["zzz"].ToString()!="")
				{
					model.zzz=decimal.Parse(ds.Tables[0].Rows[0]["zzz"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zgz_zjz"]!=null && ds.Tables[0].Rows[0]["zgz_zjz"].ToString()!="")
				{
					model.zgz_zjz=decimal.Parse(ds.Tables[0].Rows[0]["zgz_zjz"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zsz"]!=null && ds.Tables[0].Rows[0]["zsz"].ToString()!="")
				{
					model.zsz=decimal.Parse(ds.Tables[0].Rows[0]["zsz"].ToString());
				}
				if(ds.Tables[0].Rows[0]["wj"]!=null && ds.Tables[0].Rows[0]["wj"].ToString()!="")
				{
					model.wj=decimal.Parse(ds.Tables[0].Rows[0]["wj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy_temp"]!=null && ds.Tables[0].Rows[0]["czy_temp"].ToString()!="")
				{
					model.czy_temp=ds.Tables[0].Rows[0]["czy_temp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cssj"]!=null && ds.Tables[0].Rows[0]["cssj"].ToString()!="")
				{
					model.cssj=DateTime.Parse(ds.Tables[0].Rows[0]["cssj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jssj"]!=null && ds.Tables[0].Rows[0]["jssj"].ToString()!="")
				{
					model.jssj=DateTime.Parse(ds.Tables[0].Rows[0]["jssj"].ToString());
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
			strSql.Append("select id,yydh,qymc,jzzt,type,zfh,ds,qt,zyye,zzz,zgz_zjz,zsz,wj,czy_temp,cssj,jssj ");
			strSql.Append(" FROM BS_g_j_fx ");
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
			strSql.Append(" id,yydh,qymc,jzzt,type,zfh,ds,qt,zyye,zzz,zgz_zjz,zsz,wj,czy_temp,cssj,jssj ");
			strSql.Append(" FROM BS_g_j_fx ");
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
			strSql.Append("select count(1) FROM BS_g_j_fx ");
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
			strSql.Append(")AS Row, T.*  from BS_g_j_fx T ");
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
			parameters[0].Value = "BS_g_j_fx";
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

