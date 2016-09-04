using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Ssyxfmx_kc_sh_temp
	/// </summary>
	public partial class Ssyxfmx_kc_sh_temp
	{
		public Ssyxfmx_kc_sh_temp()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.Ssyxfmx_kc_sh_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ssyxfmx_kc_sh_temp(");
			strSql.Append("yydh,qymc,is_top,is_select,id_app,ckeckTime,xfsj,mxbh,xfsl,xfje,xfxm,ischecked,xftm,tjrq)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@is_top,@is_select,@id_app,@ckeckTime,@xfsj,@mxbh,@xfsl,@xfje,@xfxm,@ischecked,@xftm,@tjrq)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@ckeckTime", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@xfxm", SqlDbType.VarChar,200),
					new SqlParameter("@ischecked", SqlDbType.Bit,1),
					new SqlParameter("@xftm", SqlDbType.VarChar,50),
					new SqlParameter("@tjrq", SqlDbType.DateTime)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.is_top;
			parameters[3].Value = model.is_select;
			parameters[4].Value = model.id_app;
			parameters[5].Value = model.ckeckTime;
			parameters[6].Value = model.xfsj;
			parameters[7].Value = model.mxbh;
			parameters[8].Value = model.xfsl;
			parameters[9].Value = model.xfje;
			parameters[10].Value = model.xfxm;
			parameters[11].Value = model.ischecked;
			parameters[12].Value = model.xftm;
			parameters[13].Value = model.tjrq;

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
		public bool Update(Hotel_app.Model.Ssyxfmx_kc_sh_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ssyxfmx_kc_sh_temp set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("id_app=@id_app,");
			strSql.Append("ckeckTime=@ckeckTime,");
			strSql.Append("xfsj=@xfsj,");
			strSql.Append("mxbh=@mxbh,");
			strSql.Append("xfsl=@xfsl,");
			strSql.Append("xfje=@xfje,");
			strSql.Append("xfxm=@xfxm,");
			strSql.Append("ischecked=@ischecked,");
			strSql.Append("xftm=@xftm,");
			strSql.Append("tjrq=@tjrq");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@ckeckTime", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@xfxm", SqlDbType.VarChar,200),
					new SqlParameter("@ischecked", SqlDbType.Bit,1),
					new SqlParameter("@xftm", SqlDbType.VarChar,50),
					new SqlParameter("@tjrq", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.is_top;
			parameters[3].Value = model.is_select;
			parameters[4].Value = model.id_app;
			parameters[5].Value = model.ckeckTime;
			parameters[6].Value = model.xfsj;
			parameters[7].Value = model.mxbh;
			parameters[8].Value = model.xfsl;
			parameters[9].Value = model.xfje;
			parameters[10].Value = model.xfxm;
			parameters[11].Value = model.ischecked;
			parameters[12].Value = model.xftm;
			parameters[13].Value = model.tjrq;
			parameters[14].Value = model.id;

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
			strSql.Append("delete from Ssyxfmx_kc_sh_temp ");
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
			strSql.Append("delete from Ssyxfmx_kc_sh_temp ");
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
		public Hotel_app.Model.Ssyxfmx_kc_sh_temp GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,is_top,is_select,id_app,ckeckTime,xfsj,mxbh,xfsl,xfje,xfxm,ischecked,xftm,tjrq from Ssyxfmx_kc_sh_temp ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Ssyxfmx_kc_sh_temp model=new Hotel_app.Model.Ssyxfmx_kc_sh_temp();
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
				if(ds.Tables[0].Rows[0]["id_app"]!=null && ds.Tables[0].Rows[0]["id_app"].ToString()!="")
				{
					model.id_app=ds.Tables[0].Rows[0]["id_app"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ckeckTime"]!=null && ds.Tables[0].Rows[0]["ckeckTime"].ToString()!="")
				{
					model.ckeckTime=DateTime.Parse(ds.Tables[0].Rows[0]["ckeckTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfsj"]!=null && ds.Tables[0].Rows[0]["xfsj"].ToString()!="")
				{
					model.xfsj=DateTime.Parse(ds.Tables[0].Rows[0]["xfsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["mxbh"]!=null && ds.Tables[0].Rows[0]["mxbh"].ToString()!="")
				{
					model.mxbh=ds.Tables[0].Rows[0]["mxbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfsl"]!=null && ds.Tables[0].Rows[0]["xfsl"].ToString()!="")
				{
					model.xfsl=decimal.Parse(ds.Tables[0].Rows[0]["xfsl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje"]!=null && ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfxm"]!=null && ds.Tables[0].Rows[0]["xfxm"].ToString()!="")
				{
					model.xfxm=ds.Tables[0].Rows[0]["xfxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ischecked"]!=null && ds.Tables[0].Rows[0]["ischecked"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ischecked"].ToString()=="1")||(ds.Tables[0].Rows[0]["ischecked"].ToString().ToLower()=="true"))
					{
						model.ischecked=true;
					}
					else
					{
						model.ischecked=false;
					}
				}
				if(ds.Tables[0].Rows[0]["xftm"]!=null && ds.Tables[0].Rows[0]["xftm"].ToString()!="")
				{
					model.xftm=ds.Tables[0].Rows[0]["xftm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tjrq"]!=null && ds.Tables[0].Rows[0]["tjrq"].ToString()!="")
				{
					model.tjrq=DateTime.Parse(ds.Tables[0].Rows[0]["tjrq"].ToString());
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
			strSql.Append("select id,yydh,qymc,is_top,is_select,id_app,ckeckTime,xfsj,mxbh,xfsl,xfje,xfxm,ischecked,xftm,tjrq ");
			strSql.Append(" FROM Ssyxfmx_kc_sh_temp ");
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
			strSql.Append(" id,yydh,qymc,is_top,is_select,id_app,ckeckTime,xfsj,mxbh,xfsl,xfje,xfxm,ischecked,xftm,tjrq ");
			strSql.Append(" FROM Ssyxfmx_kc_sh_temp ");
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
			strSql.Append("select count(1) FROM Ssyxfmx_kc_sh_temp ");
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
			strSql.Append(")AS Row, T.*  from Ssyxfmx_kc_sh_temp T ");
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
			parameters[0].Value = "Ssyxfmx_kc_sh_temp";
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

