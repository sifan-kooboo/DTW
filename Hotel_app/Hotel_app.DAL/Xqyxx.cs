/**  版本信息模板在安装目录下，可自行修改。
* Xqyxx.cs
*
* 功 能： N/A
* 类 名： Xqyxx
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-20 11:27:25   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Xqyxx
	/// </summary>
	public partial class Xqyxx
	{
		public Xqyxx()
		{}
		#region  BasicMethod

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
		public int Add(Hotel_app.Model.Xqyxx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Xqyxx(");
			strSql.Append("qy_type,yydh,qymc,zjm,gj,sf,sb,qybh,qydh,qycz,Email,nxr,qydz,xtyysj,hyxs,lx,qymcyw,wz,qydzyw,hyjfrx,Softname)");
			strSql.Append(" values (");
			strSql.Append("@qy_type,@yydh,@qymc,@zjm,@gj,@sf,@sb,@qybh,@qydh,@qycz,@Email,@nxr,@qydz,@xtyysj,@hyxs,@lx,@qymcyw,@wz,@qydzyw,@hyjfrx,@Softname)");
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
					new SqlParameter("@hyjfrx", SqlDbType.VarChar,50),
					new SqlParameter("@Softname", SqlDbType.VarChar,50)};
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
			parameters[20].Value = model.Softname;

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
		public bool Update(Hotel_app.Model.Xqyxx model)
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
			strSql.Append("hyjfrx=@hyjfrx,");
			strSql.Append("Softname=@Softname");
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
					new SqlParameter("@Softname", SqlDbType.VarChar,50),
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
			parameters[20].Value = model.Softname;
			parameters[21].Value = model.id;

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
		public Hotel_app.Model.Xqyxx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,qy_type,yydh,qymc,zjm,gj,sf,sb,qybh,qydh,qycz,Email,nxr,qydz,xtyysj,hyxs,lx,qymcyw,wz,qydzyw,hyjfrx,Softname from Xqyxx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Xqyxx model=new Hotel_app.Model.Xqyxx();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hotel_app.Model.Xqyxx DataRowToModel(DataRow row)
		{
			Hotel_app.Model.Xqyxx model=new Hotel_app.Model.Xqyxx();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["qy_type"]!=null)
				{
					model.qy_type=row["qy_type"].ToString();
				}
				if(row["yydh"]!=null)
				{
					model.yydh=row["yydh"].ToString();
				}
				if(row["qymc"]!=null)
				{
					model.qymc=row["qymc"].ToString();
				}
				if(row["zjm"]!=null)
				{
					model.zjm=row["zjm"].ToString();
				}
				if(row["gj"]!=null)
				{
					model.gj=row["gj"].ToString();
				}
				if(row["sf"]!=null)
				{
					model.sf=row["sf"].ToString();
				}
				if(row["sb"]!=null)
				{
					model.sb=row["sb"].ToString();
				}
				if(row["qybh"]!=null)
				{
					model.qybh=row["qybh"].ToString();
				}
				if(row["qydh"]!=null)
				{
					model.qydh=row["qydh"].ToString();
				}
				if(row["qycz"]!=null)
				{
					model.qycz=row["qycz"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["nxr"]!=null)
				{
					model.nxr=row["nxr"].ToString();
				}
				if(row["qydz"]!=null)
				{
					model.qydz=row["qydz"].ToString();
				}
				if(row["xtyysj"]!=null && row["xtyysj"].ToString()!="")
				{
					model.xtyysj=DateTime.Parse(row["xtyysj"].ToString());
				}
				if(row["hyxs"]!=null)
				{
					model.hyxs=row["hyxs"].ToString();
				}
				if(row["lx"]!=null)
				{
					model.lx=row["lx"].ToString();
				}
				if(row["qymcyw"]!=null)
				{
					model.qymcyw=row["qymcyw"].ToString();
				}
				if(row["wz"]!=null)
				{
					model.wz=row["wz"].ToString();
				}
				if(row["qydzyw"]!=null)
				{
					model.qydzyw=row["qydzyw"].ToString();
				}
				if(row["hyjfrx"]!=null)
				{
					model.hyjfrx=row["hyjfrx"].ToString();
				}
				if(row["Softname"]!=null)
				{
					model.Softname=row["Softname"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,qy_type,yydh,qymc,zjm,gj,sf,sb,qybh,qydh,qycz,Email,nxr,qydz,xtyysj,hyxs,lx,qymcyw,wz,qydzyw,hyjfrx,Softname ");
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
			strSql.Append(" id,qy_type,yydh,qymc,zjm,gj,sf,sb,qybh,qydh,qycz,Email,nxr,qydz,xtyysj,hyxs,lx,qymcyw,wz,qydzyw,hyjfrx,Softname ");
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

