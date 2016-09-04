using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Xxfmx_zbmx
	/// </summary>
	public partial class Xxfmx_zbmx
	{
		public Xxfmx_zbmx()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.Xxfmx_zbmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Xxfmx_zbmx(");
			strSql.Append("yydh,qymc,lsbh,drbh,xfdr,xrbh,xfxr,xftm,xfmx,mxbh,zb_sl,zb_zt,zb_sj,zb_czy,shsc,zb_jjje,zb_Total_cb)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@lsbh,@drbh,@xfdr,@xrbh,@xfxr,@xftm,@xfmx,@mxbh,@zb_sl,@zb_zt,@zb_sj,@zb_czy,@shsc,@zb_jjje,@zb_Total_cb)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@drbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xrbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfxr", SqlDbType.VarChar,50),
					new SqlParameter("@xftm", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx", SqlDbType.VarChar,100),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@zb_sl", SqlDbType.Decimal,9),
					new SqlParameter("@zb_zt", SqlDbType.VarChar,100),
					new SqlParameter("@zb_sj", SqlDbType.DateTime),
					new SqlParameter("@zb_czy", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@zb_jjje", SqlDbType.Decimal,9),
					new SqlParameter("@zb_Total_cb", SqlDbType.Decimal,9)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.drbh;
			parameters[4].Value = model.xfdr;
			parameters[5].Value = model.xrbh;
			parameters[6].Value = model.xfxr;
			parameters[7].Value = model.xftm;
			parameters[8].Value = model.xfmx;
			parameters[9].Value = model.mxbh;
			parameters[10].Value = model.zb_sl;
			parameters[11].Value = model.zb_zt;
			parameters[12].Value = model.zb_sj;
			parameters[13].Value = model.zb_czy;
			parameters[14].Value = model.shsc;
			parameters[15].Value = model.zb_jjje;
			parameters[16].Value = model.zb_Total_cb;

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
		public bool Update(Hotel_app.Model.Xxfmx_zbmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Xxfmx_zbmx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("drbh=@drbh,");
			strSql.Append("xfdr=@xfdr,");
			strSql.Append("xrbh=@xrbh,");
			strSql.Append("xfxr=@xfxr,");
			strSql.Append("xftm=@xftm,");
			strSql.Append("xfmx=@xfmx,");
			strSql.Append("mxbh=@mxbh,");
			strSql.Append("zb_sl=@zb_sl,");
			strSql.Append("zb_zt=@zb_zt,");
			strSql.Append("zb_sj=@zb_sj,");
			strSql.Append("zb_czy=@zb_czy,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("zb_jjje=@zb_jjje,");
			strSql.Append("zb_Total_cb=@zb_Total_cb");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@drbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xrbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfxr", SqlDbType.VarChar,50),
					new SqlParameter("@xftm", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx", SqlDbType.VarChar,100),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@zb_sl", SqlDbType.Decimal,9),
					new SqlParameter("@zb_zt", SqlDbType.VarChar,100),
					new SqlParameter("@zb_sj", SqlDbType.DateTime),
					new SqlParameter("@zb_czy", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@zb_jjje", SqlDbType.Decimal,9),
					new SqlParameter("@zb_Total_cb", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.drbh;
			parameters[4].Value = model.xfdr;
			parameters[5].Value = model.xrbh;
			parameters[6].Value = model.xfxr;
			parameters[7].Value = model.xftm;
			parameters[8].Value = model.xfmx;
			parameters[9].Value = model.mxbh;
			parameters[10].Value = model.zb_sl;
			parameters[11].Value = model.zb_zt;
			parameters[12].Value = model.zb_sj;
			parameters[13].Value = model.zb_czy;
			parameters[14].Value = model.shsc;
			parameters[15].Value = model.zb_jjje;
			parameters[16].Value = model.zb_Total_cb;
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
			strSql.Append("delete from Xxfmx_zbmx ");
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
			strSql.Append("delete from Xxfmx_zbmx ");
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
		public Hotel_app.Model.Xxfmx_zbmx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,lsbh,drbh,xfdr,xrbh,xfxr,xftm,xfmx,mxbh,zb_sl,zb_zt,zb_sj,zb_czy,shsc,zb_jjje,zb_Total_cb from Xxfmx_zbmx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Xxfmx_zbmx model=new Hotel_app.Model.Xxfmx_zbmx();
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
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["drbh"]!=null && ds.Tables[0].Rows[0]["drbh"].ToString()!="")
				{
					model.drbh=ds.Tables[0].Rows[0]["drbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfdr"]!=null && ds.Tables[0].Rows[0]["xfdr"].ToString()!="")
				{
					model.xfdr=ds.Tables[0].Rows[0]["xfdr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xrbh"]!=null && ds.Tables[0].Rows[0]["xrbh"].ToString()!="")
				{
					model.xrbh=ds.Tables[0].Rows[0]["xrbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfxr"]!=null && ds.Tables[0].Rows[0]["xfxr"].ToString()!="")
				{
					model.xfxr=ds.Tables[0].Rows[0]["xfxr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xftm"]!=null && ds.Tables[0].Rows[0]["xftm"].ToString()!="")
				{
					model.xftm=ds.Tables[0].Rows[0]["xftm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfmx"]!=null && ds.Tables[0].Rows[0]["xfmx"].ToString()!="")
				{
					model.xfmx=ds.Tables[0].Rows[0]["xfmx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mxbh"]!=null && ds.Tables[0].Rows[0]["mxbh"].ToString()!="")
				{
					model.mxbh=ds.Tables[0].Rows[0]["mxbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zb_sl"]!=null && ds.Tables[0].Rows[0]["zb_sl"].ToString()!="")
				{
					model.zb_sl=decimal.Parse(ds.Tables[0].Rows[0]["zb_sl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zb_zt"]!=null && ds.Tables[0].Rows[0]["zb_zt"].ToString()!="")
				{
					model.zb_zt=ds.Tables[0].Rows[0]["zb_zt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zb_sj"]!=null && ds.Tables[0].Rows[0]["zb_sj"].ToString()!="")
				{
					model.zb_sj=DateTime.Parse(ds.Tables[0].Rows[0]["zb_sj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zb_czy"]!=null && ds.Tables[0].Rows[0]["zb_czy"].ToString()!="")
				{
					model.zb_czy=ds.Tables[0].Rows[0]["zb_czy"].ToString();
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
				if(ds.Tables[0].Rows[0]["zb_jjje"]!=null && ds.Tables[0].Rows[0]["zb_jjje"].ToString()!="")
				{
					model.zb_jjje=decimal.Parse(ds.Tables[0].Rows[0]["zb_jjje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zb_Total_cb"]!=null && ds.Tables[0].Rows[0]["zb_Total_cb"].ToString()!="")
				{
					model.zb_Total_cb=decimal.Parse(ds.Tables[0].Rows[0]["zb_Total_cb"].ToString());
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
			strSql.Append("select id,yydh,qymc,lsbh,drbh,xfdr,xrbh,xfxr,xftm,xfmx,mxbh,zb_sl,zb_zt,zb_sj,zb_czy,shsc,zb_jjje,zb_Total_cb ");
			strSql.Append(" FROM Xxfmx_zbmx ");
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
			strSql.Append(" id,yydh,qymc,lsbh,drbh,xfdr,xrbh,xfxr,xftm,xfmx,mxbh,zb_sl,zb_zt,zb_sj,zb_czy,shsc,zb_jjje,zb_Total_cb ");
			strSql.Append(" FROM Xxfmx_zbmx ");
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
			strSql.Append("select count(1) FROM Xxfmx_zbmx ");
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
			strSql.Append(")AS Row, T.*  from Xxfmx_zbmx T ");
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
			parameters[0].Value = "Xxfmx_zbmx";
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

