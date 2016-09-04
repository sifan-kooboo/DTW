using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace jdgl_res_head_service.DAL
{
	/// <summary>
	/// 数据访问类:Xqyxx
	/// </summary>
	public partial class Xqyxx
	{
		public Xqyxx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Xqyxx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Xqyxx");
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
		public int Add(jdgl_res_head_service.Model.Xqyxx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Xqyxx(");
			strSql.Append("qy_type,yydh,qymc,zjm,gj,sf,sb,qybh,qydh,qycz,Email,nxr,qydz,xtyysj,hyxs,lx,qymcyw,wz,qydzyw,hyjfrx)");
			strSql.Append(" values (");
			strSql.Append("@qy_type,@yydh,@qymc,@zjm,@gj,@sf,@sb,@qybh,@qydh,@qycz,@Email,@nxr,@qydz,@xtyysj,@hyxs,@lx,@qymcyw,@wz,@qydzyw,@hyjfrx)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@qy_type", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@zjm", SqlDbType.VarChar,50),
					new SqlParameter("@gj", SqlDbType.VarChar,50),
					new SqlParameter("@sf", SqlDbType.VarChar,50),
					new SqlParameter("@sb", SqlDbType.VarChar,50),
					new SqlParameter("@qybh", SqlDbType.VarChar,50),
					new SqlParameter("@qydh", SqlDbType.VarChar,50),
					new SqlParameter("@qycz", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@nxr", SqlDbType.VarChar,50),
					new SqlParameter("@qydz", SqlDbType.VarChar,50),
					new SqlParameter("@xtyysj", SqlDbType.DateTime),
					new SqlParameter("@hyxs", SqlDbType.VarChar,50),
					new SqlParameter("@lx", SqlDbType.VarChar,50),
					new SqlParameter("@qymcyw", SqlDbType.VarChar,50),
					new SqlParameter("@wz", SqlDbType.VarChar,50),
					new SqlParameter("@qydzyw", SqlDbType.VarChar,300),
					new SqlParameter("@hyjfrx", SqlDbType.VarChar,50)};
			parameters[0].Value = model.qy_type;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.zjm;
			parameters[4].Value = model.gj;
			parameters[5].Value = model.sf;
			parameters[6].Value = model.sb;
			parameters[7].Value = model.qybh;
			parameters[8].Value = model.qydh;
			parameters[9].Value = model.qycz;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.nxr;
			parameters[12].Value = model.qydz;
			parameters[13].Value = model.xtyysj;
			parameters[14].Value = model.hyxs;
			parameters[15].Value = model.lx;
			parameters[16].Value = model.qymcyw;
			parameters[17].Value = model.wz;
			parameters[18].Value = model.qydzyw;
			parameters[19].Value = model.hyjfrx;

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
		public bool Update(jdgl_res_head_service.Model.Xqyxx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Xqyxx set ");
			strSql.Append("qy_type=@qy_type,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("zjm=@zjm,");
			strSql.Append("gj=@gj,");
			strSql.Append("sf=@sf,");
			strSql.Append("sb=@sb,");
			strSql.Append("qybh=@qybh,");
			strSql.Append("qydh=@qydh,");
			strSql.Append("qycz=@qycz,");
			strSql.Append("Email=@Email,");
			strSql.Append("nxr=@nxr,");
			strSql.Append("qydz=@qydz,");
			strSql.Append("xtyysj=@xtyysj,");
			strSql.Append("hyxs=@hyxs,");
			strSql.Append("lx=@lx,");
			strSql.Append("qymcyw=@qymcyw,");
			strSql.Append("wz=@wz,");
			strSql.Append("qydzyw=@qydzyw,");
			strSql.Append("hyjfrx=@hyjfrx");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@qy_type", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@zjm", SqlDbType.VarChar,50),
					new SqlParameter("@gj", SqlDbType.VarChar,50),
					new SqlParameter("@sf", SqlDbType.VarChar,50),
					new SqlParameter("@sb", SqlDbType.VarChar,50),
					new SqlParameter("@qybh", SqlDbType.VarChar,50),
					new SqlParameter("@qydh", SqlDbType.VarChar,50),
					new SqlParameter("@qycz", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@nxr", SqlDbType.VarChar,50),
					new SqlParameter("@qydz", SqlDbType.VarChar,50),
					new SqlParameter("@xtyysj", SqlDbType.DateTime),
					new SqlParameter("@hyxs", SqlDbType.VarChar,50),
					new SqlParameter("@lx", SqlDbType.VarChar,50),
					new SqlParameter("@qymcyw", SqlDbType.VarChar,50),
					new SqlParameter("@wz", SqlDbType.VarChar,50),
					new SqlParameter("@qydzyw", SqlDbType.VarChar,300),
					new SqlParameter("@hyjfrx", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.qy_type;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.zjm;
			parameters[4].Value = model.gj;
			parameters[5].Value = model.sf;
			parameters[6].Value = model.sb;
			parameters[7].Value = model.qybh;
			parameters[8].Value = model.qydh;
			parameters[9].Value = model.qycz;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.nxr;
			parameters[12].Value = model.qydz;
			parameters[13].Value = model.xtyysj;
			parameters[14].Value = model.hyxs;
			parameters[15].Value = model.lx;
			parameters[16].Value = model.qymcyw;
			parameters[17].Value = model.wz;
			parameters[18].Value = model.qydzyw;
			parameters[19].Value = model.hyjfrx;
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
			strSql.Append("delete from Xqyxx ");
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
			strSql.Append("delete from Xqyxx ");
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
		public jdgl_res_head_service.Model.Xqyxx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,qy_type,yydh,qymc,zjm,gj,sf,sb,qybh,qydh,qycz,Email,nxr,qydz,xtyysj,hyxs,lx,qymcyw,wz,qydzyw,hyjfrx from Xqyxx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			jdgl_res_head_service.Model.Xqyxx model=new jdgl_res_head_service.Model.Xqyxx();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qy_type"]!=null && ds.Tables[0].Rows[0]["qy_type"].ToString()!="")
				{
					model.qy_type=ds.Tables[0].Rows[0]["qy_type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjm"]!=null && ds.Tables[0].Rows[0]["zjm"].ToString()!="")
				{
					model.zjm=ds.Tables[0].Rows[0]["zjm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gj"]!=null && ds.Tables[0].Rows[0]["gj"].ToString()!="")
				{
					model.gj=ds.Tables[0].Rows[0]["gj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sf"]!=null && ds.Tables[0].Rows[0]["sf"].ToString()!="")
				{
					model.sf=ds.Tables[0].Rows[0]["sf"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sb"]!=null && ds.Tables[0].Rows[0]["sb"].ToString()!="")
				{
					model.sb=ds.Tables[0].Rows[0]["sb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qybh"]!=null && ds.Tables[0].Rows[0]["qybh"].ToString()!="")
				{
					model.qybh=ds.Tables[0].Rows[0]["qybh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qydh"]!=null && ds.Tables[0].Rows[0]["qydh"].ToString()!="")
				{
					model.qydh=ds.Tables[0].Rows[0]["qydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qycz"]!=null && ds.Tables[0].Rows[0]["qycz"].ToString()!="")
				{
					model.qycz=ds.Tables[0].Rows[0]["qycz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nxr"]!=null && ds.Tables[0].Rows[0]["nxr"].ToString()!="")
				{
					model.nxr=ds.Tables[0].Rows[0]["nxr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qydz"]!=null && ds.Tables[0].Rows[0]["qydz"].ToString()!="")
				{
					model.qydz=ds.Tables[0].Rows[0]["qydz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xtyysj"]!=null && ds.Tables[0].Rows[0]["xtyysj"].ToString()!="")
				{
					model.xtyysj=DateTime.Parse(ds.Tables[0].Rows[0]["xtyysj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["hyxs"]!=null && ds.Tables[0].Rows[0]["hyxs"].ToString()!="")
				{
					model.hyxs=ds.Tables[0].Rows[0]["hyxs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lx"]!=null && ds.Tables[0].Rows[0]["lx"].ToString()!="")
				{
					model.lx=ds.Tables[0].Rows[0]["lx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qymcyw"]!=null && ds.Tables[0].Rows[0]["qymcyw"].ToString()!="")
				{
					model.qymcyw=ds.Tables[0].Rows[0]["qymcyw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["wz"]!=null && ds.Tables[0].Rows[0]["wz"].ToString()!="")
				{
					model.wz=ds.Tables[0].Rows[0]["wz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qydzyw"]!=null && ds.Tables[0].Rows[0]["qydzyw"].ToString()!="")
				{
					model.qydzyw=ds.Tables[0].Rows[0]["qydzyw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hyjfrx"]!=null && ds.Tables[0].Rows[0]["hyjfrx"].ToString()!="")
				{
					model.hyjfrx=ds.Tables[0].Rows[0]["hyjfrx"].ToString();
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
			strSql.Append("select id,qy_type,yydh,qymc,zjm,gj,sf,sb,qybh,qydh,qycz,Email,nxr,qydz,xtyysj,hyxs,lx,qymcyw,wz,qydzyw,hyjfrx ");
			strSql.Append(" FROM Xqyxx ");
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
			strSql.Append(" id,qy_type,yydh,qymc,zjm,gj,sf,sb,qybh,qydh,qycz,Email,nxr,qydz,xtyysj,hyxs,lx,qymcyw,wz,qydzyw,hyjfrx ");
			strSql.Append(" FROM Xqyxx ");
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
			strSql.Append("select count(1) FROM Xqyxx ");
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
			strSql.Append(")AS Row, T.*  from Xqyxx T ");
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
			parameters[0].Value = "Xqyxx";
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

