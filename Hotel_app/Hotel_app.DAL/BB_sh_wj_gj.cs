using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:BB_sh_wj_gj
	/// </summary>
	public partial class BB_sh_wj_gj
	{
		public BB_sh_wj_gj()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "BB_sh_wj_gj"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BB_sh_wj_gj");
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
		public int Add(Hotel_app.Model.BB_sh_wj_gj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BB_sh_wj_gj(");
			strSql.Append("yydh,qymc,bbrq,ddsj,lksj,czsj,krxm,jzzt,xydw,krly,fjrb,fjbh,sktt,czzt,fx_zt,zfh,ds,qt,zyye,czy)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@bbrq,@ddsj,@lksj,@czsj,@krxm,@jzzt,@xydw,@krly,@fjrb,@fjbh,@sktt,@czzt,@fx_zt,@zfh,@ds,@qt,@zyye,@czy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bbrq", SqlDbType.DateTime),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@krxm", SqlDbType.VarChar,150),
					new SqlParameter("@jzzt", SqlDbType.VarChar,150),
					new SqlParameter("@xydw", SqlDbType.VarChar,300),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@czzt", SqlDbType.VarChar,50),
					new SqlParameter("@fx_zt", SqlDbType.VarChar,50),
					new SqlParameter("@zfh", SqlDbType.Decimal,9),
					new SqlParameter("@ds", SqlDbType.Decimal,9),
					new SqlParameter("@qt", SqlDbType.Decimal,9),
					new SqlParameter("@zyye", SqlDbType.Decimal,9),
					new SqlParameter("@czy", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.bbrq;
			parameters[3].Value = model.ddsj;
			parameters[4].Value = model.lksj;
			parameters[5].Value = model.czsj;
			parameters[6].Value = model.krxm;
			parameters[7].Value = model.jzzt;
			parameters[8].Value = model.xydw;
			parameters[9].Value = model.krly;
			parameters[10].Value = model.fjrb;
			parameters[11].Value = model.fjbh;
			parameters[12].Value = model.sktt;
			parameters[13].Value = model.czzt;
			parameters[14].Value = model.fx_zt;
			parameters[15].Value = model.zfh;
			parameters[16].Value = model.ds;
			parameters[17].Value = model.qt;
			parameters[18].Value = model.zyye;
			parameters[19].Value = model.czy;

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
		public bool Update(Hotel_app.Model.BB_sh_wj_gj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BB_sh_wj_gj set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("bbrq=@bbrq,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("jzzt=@jzzt,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("krly=@krly,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("czzt=@czzt,");
			strSql.Append("fx_zt=@fx_zt,");
			strSql.Append("zfh=@zfh,");
			strSql.Append("ds=@ds,");
			strSql.Append("qt=@qt,");
			strSql.Append("zyye=@zyye,");
			strSql.Append("czy=@czy");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bbrq", SqlDbType.DateTime),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@krxm", SqlDbType.VarChar,150),
					new SqlParameter("@jzzt", SqlDbType.VarChar,150),
					new SqlParameter("@xydw", SqlDbType.VarChar,300),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@czzt", SqlDbType.VarChar,50),
					new SqlParameter("@fx_zt", SqlDbType.VarChar,50),
					new SqlParameter("@zfh", SqlDbType.Decimal,9),
					new SqlParameter("@ds", SqlDbType.Decimal,9),
					new SqlParameter("@qt", SqlDbType.Decimal,9),
					new SqlParameter("@zyye", SqlDbType.Decimal,9),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.bbrq;
			parameters[3].Value = model.ddsj;
			parameters[4].Value = model.lksj;
			parameters[5].Value = model.czsj;
			parameters[6].Value = model.krxm;
			parameters[7].Value = model.jzzt;
			parameters[8].Value = model.xydw;
			parameters[9].Value = model.krly;
			parameters[10].Value = model.fjrb;
			parameters[11].Value = model.fjbh;
			parameters[12].Value = model.sktt;
			parameters[13].Value = model.czzt;
			parameters[14].Value = model.fx_zt;
			parameters[15].Value = model.zfh;
			parameters[16].Value = model.ds;
			parameters[17].Value = model.qt;
			parameters[18].Value = model.zyye;
			parameters[19].Value = model.czy;
			parameters[20].Value = model.id;

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
			strSql.Append("delete from BB_sh_wj_gj ");
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
			strSql.Append("delete from BB_sh_wj_gj ");
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
		public Hotel_app.Model.BB_sh_wj_gj GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,bbrq,ddsj,lksj,czsj,krxm,jzzt,xydw,krly,fjrb,fjbh,sktt,czzt,fx_zt,zfh,ds,qt,zyye,czy from BB_sh_wj_gj ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.BB_sh_wj_gj model=new Hotel_app.Model.BB_sh_wj_gj();
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
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jzzt"]!=null && ds.Tables[0].Rows[0]["jzzt"].ToString()!="")
				{
					model.jzzt=ds.Tables[0].Rows[0]["jzzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czzt"]!=null && ds.Tables[0].Rows[0]["czzt"].ToString()!="")
				{
					model.czzt=ds.Tables[0].Rows[0]["czzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fx_zt"]!=null && ds.Tables[0].Rows[0]["fx_zt"].ToString()!="")
				{
					model.fx_zt=ds.Tables[0].Rows[0]["fx_zt"].ToString();
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
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
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
			strSql.Append("select id,yydh,qymc,bbrq,ddsj,lksj,czsj,krxm,jzzt,xydw,krly,fjrb,fjbh,sktt,czzt,fx_zt,zfh,ds,qt,zyye,czy ");
			strSql.Append(" FROM BB_sh_wj_gj ");
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
			strSql.Append(" id,yydh,qymc,bbrq,ddsj,lksj,czsj,krxm,jzzt,xydw,krly,fjrb,fjbh,sktt,czzt,fx_zt,zfh,ds,qt,zyye,czy ");
			strSql.Append(" FROM BB_sh_wj_gj ");
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
			strSql.Append("select count(1) FROM BB_sh_wj_gj ");
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
			strSql.Append(")AS Row, T.*  from BB_sh_wj_gj T ");
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
			parameters[0].Value = "BB_sh_wj_gj";
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

