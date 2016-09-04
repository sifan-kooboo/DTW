using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:BQ_syxffx
	/// </summary>
	public partial class BQ_syxffx
	{
		public BQ_syxffx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "BQ_syxffx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BQ_syxffx");
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
		public int Add(Hotel_app.Model.BQ_syxffx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BQ_syxffx(");
			strSql.Append("yydh,qymc,type,fxdr,fxrb,zyye,zfh,czfs,pjczl,xd_pjczl,pjbl,xd_pjbl,pjfj,jcb,czy_temp,cssj,jssj)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@type,@fxdr,@fxrb,@zyye,@zfh,@czfs,@pjczl,@xd_pjczl,@pjbl,@xd_pjbl,@pjfj,@jcb,@czy_temp,@cssj,@jssj)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,200),
					new SqlParameter("@fxdr", SqlDbType.VarChar,200),
					new SqlParameter("@fxrb", SqlDbType.VarChar,200),
					new SqlParameter("@zyye", SqlDbType.Float,8),
					new SqlParameter("@zfh", SqlDbType.Float,8),
					new SqlParameter("@czfs", SqlDbType.Float,8),
					new SqlParameter("@pjczl", SqlDbType.VarChar,50),
					new SqlParameter("@xd_pjczl", SqlDbType.VarChar,50),
					new SqlParameter("@pjbl", SqlDbType.VarChar,50),
					new SqlParameter("@xd_pjbl", SqlDbType.VarChar,50),
					new SqlParameter("@pjfj", SqlDbType.Float,8),
					new SqlParameter("@jcb", SqlDbType.Float,8),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@cssj", SqlDbType.DateTime),
					new SqlParameter("@jssj", SqlDbType.DateTime)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.type;
			parameters[3].Value = model.fxdr;
			parameters[4].Value = model.fxrb;
			parameters[5].Value = model.zyye;
			parameters[6].Value = model.zfh;
			parameters[7].Value = model.czfs;
			parameters[8].Value = model.pjczl;
			parameters[9].Value = model.xd_pjczl;
			parameters[10].Value = model.pjbl;
			parameters[11].Value = model.xd_pjbl;
			parameters[12].Value = model.pjfj;
			parameters[13].Value = model.jcb;
			parameters[14].Value = model.czy_temp;
			parameters[15].Value = model.cssj;
			parameters[16].Value = model.jssj;

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
		public bool Update(Hotel_app.Model.BQ_syxffx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BQ_syxffx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("type=@type,");
			strSql.Append("fxdr=@fxdr,");
			strSql.Append("fxrb=@fxrb,");
			strSql.Append("zyye=@zyye,");
			strSql.Append("zfh=@zfh,");
			strSql.Append("czfs=@czfs,");
			strSql.Append("pjczl=@pjczl,");
			strSql.Append("xd_pjczl=@xd_pjczl,");
			strSql.Append("pjbl=@pjbl,");
			strSql.Append("xd_pjbl=@xd_pjbl,");
			strSql.Append("pjfj=@pjfj,");
			strSql.Append("jcb=@jcb,");
			strSql.Append("czy_temp=@czy_temp,");
			strSql.Append("cssj=@cssj,");
			strSql.Append("jssj=@jssj");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,200),
					new SqlParameter("@fxdr", SqlDbType.VarChar,200),
					new SqlParameter("@fxrb", SqlDbType.VarChar,200),
					new SqlParameter("@zyye", SqlDbType.Float,8),
					new SqlParameter("@zfh", SqlDbType.Float,8),
					new SqlParameter("@czfs", SqlDbType.Float,8),
					new SqlParameter("@pjczl", SqlDbType.VarChar,50),
					new SqlParameter("@xd_pjczl", SqlDbType.VarChar,50),
					new SqlParameter("@pjbl", SqlDbType.VarChar,50),
					new SqlParameter("@xd_pjbl", SqlDbType.VarChar,50),
					new SqlParameter("@pjfj", SqlDbType.Float,8),
					new SqlParameter("@jcb", SqlDbType.Float,8),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@cssj", SqlDbType.DateTime),
					new SqlParameter("@jssj", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.type;
			parameters[3].Value = model.fxdr;
			parameters[4].Value = model.fxrb;
			parameters[5].Value = model.zyye;
			parameters[6].Value = model.zfh;
			parameters[7].Value = model.czfs;
			parameters[8].Value = model.pjczl;
			parameters[9].Value = model.xd_pjczl;
			parameters[10].Value = model.pjbl;
			parameters[11].Value = model.xd_pjbl;
			parameters[12].Value = model.pjfj;
			parameters[13].Value = model.jcb;
			parameters[14].Value = model.czy_temp;
			parameters[15].Value = model.cssj;
			parameters[16].Value = model.jssj;
			parameters[17].Value = model.id;

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
			strSql.Append("delete from BQ_syxffx ");
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
			strSql.Append("delete from BQ_syxffx ");
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
		public Hotel_app.Model.BQ_syxffx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,type,fxdr,fxrb,zyye,zfh,czfs,pjczl,xd_pjczl,pjbl,xd_pjbl,pjfj,jcb,czy_temp,cssj,jssj from BQ_syxffx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.BQ_syxffx model=new Hotel_app.Model.BQ_syxffx();
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
				if(ds.Tables[0].Rows[0]["type"]!=null && ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=ds.Tables[0].Rows[0]["type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fxdr"]!=null && ds.Tables[0].Rows[0]["fxdr"].ToString()!="")
				{
					model.fxdr=ds.Tables[0].Rows[0]["fxdr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fxrb"]!=null && ds.Tables[0].Rows[0]["fxrb"].ToString()!="")
				{
					model.fxrb=ds.Tables[0].Rows[0]["fxrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zyye"]!=null && ds.Tables[0].Rows[0]["zyye"].ToString()!="")
				{
					model.zyye=decimal.Parse(ds.Tables[0].Rows[0]["zyye"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zfh"]!=null && ds.Tables[0].Rows[0]["zfh"].ToString()!="")
				{
					model.zfh=decimal.Parse(ds.Tables[0].Rows[0]["zfh"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czfs"]!=null && ds.Tables[0].Rows[0]["czfs"].ToString()!="")
				{
					model.czfs=decimal.Parse(ds.Tables[0].Rows[0]["czfs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pjczl"]!=null && ds.Tables[0].Rows[0]["pjczl"].ToString()!="")
				{
					model.pjczl=ds.Tables[0].Rows[0]["pjczl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xd_pjczl"]!=null && ds.Tables[0].Rows[0]["xd_pjczl"].ToString()!="")
				{
					model.xd_pjczl=ds.Tables[0].Rows[0]["xd_pjczl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pjbl"]!=null && ds.Tables[0].Rows[0]["pjbl"].ToString()!="")
				{
					model.pjbl=ds.Tables[0].Rows[0]["pjbl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xd_pjbl"]!=null && ds.Tables[0].Rows[0]["xd_pjbl"].ToString()!="")
				{
					model.xd_pjbl=ds.Tables[0].Rows[0]["xd_pjbl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pjfj"]!=null && ds.Tables[0].Rows[0]["pjfj"].ToString()!="")
				{
					model.pjfj=decimal.Parse(ds.Tables[0].Rows[0]["pjfj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jcb"]!=null && ds.Tables[0].Rows[0]["jcb"].ToString()!="")
				{
					model.jcb=decimal.Parse(ds.Tables[0].Rows[0]["jcb"].ToString());
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
			strSql.Append("select id,yydh,qymc,type,fxdr,fxrb,zyye,zfh,czfs,pjczl,xd_pjczl,pjbl,xd_pjbl,pjfj,jcb,czy_temp,cssj,jssj ");
			strSql.Append(" FROM BQ_syxffx ");
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
			strSql.Append(" id,yydh,qymc,type,fxdr,fxrb,zyye,zfh,czfs,pjczl,xd_pjczl,pjbl,xd_pjbl,pjfj,jcb,czy_temp,cssj,jssj ");
			strSql.Append(" FROM BQ_syxffx ");
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
			strSql.Append("select count(1) FROM BQ_syxffx ");
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
			strSql.Append(")AS Row, T.*  from BQ_syxffx T ");
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
			parameters[0].Value = "BQ_syxffx";
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

