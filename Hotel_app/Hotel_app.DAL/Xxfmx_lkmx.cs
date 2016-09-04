using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Xxfmx_lkmx
	/// </summary>
	public partial class Xxfmx_lkmx
	{
		public Xxfmx_lkmx()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.Xxfmx_lkmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Xxfmx_lkmx(");
			strSql.Append("yydh,qymc,lsbh,lksj,czsj,czy,bz,drbh,xfdr,xrbh,xfxr,xftm,xfmx,mxbh,xfsl,shsc,jjdj,Total_cb)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@lsbh,@lksj,@czsj,@czy,@bz,@drbh,@xfdr,@xrbh,@xfxr,@xftm,@xfmx,@mxbh,@xfsl,@shsc,@jjdj,@Total_cb)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,250),
					new SqlParameter("@drbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xrbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfxr", SqlDbType.VarChar,50),
					new SqlParameter("@xftm", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx", SqlDbType.VarChar,100),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@jjdj", SqlDbType.Decimal,5),
					new SqlParameter("@Total_cb", SqlDbType.Decimal,5)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.lksj;
			parameters[4].Value = model.czsj;
			parameters[5].Value = model.czy;
			parameters[6].Value = model.bz;
			parameters[7].Value = model.drbh;
			parameters[8].Value = model.xfdr;
			parameters[9].Value = model.xrbh;
			parameters[10].Value = model.xfxr;
			parameters[11].Value = model.xftm;
			parameters[12].Value = model.xfmx;
			parameters[13].Value = model.mxbh;
			parameters[14].Value = model.xfsl;
			parameters[15].Value = model.shsc;
			parameters[16].Value = model.jjdj;
			parameters[17].Value = model.Total_cb;

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
		public bool Update(Hotel_app.Model.Xxfmx_lkmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Xxfmx_lkmx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("czy=@czy,");
			strSql.Append("bz=@bz,");
			strSql.Append("drbh=@drbh,");
			strSql.Append("xfdr=@xfdr,");
			strSql.Append("xrbh=@xrbh,");
			strSql.Append("xfxr=@xfxr,");
			strSql.Append("xftm=@xftm,");
			strSql.Append("xfmx=@xfmx,");
			strSql.Append("mxbh=@mxbh,");
			strSql.Append("xfsl=@xfsl,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("jjdj=@jjdj,");
			strSql.Append("Total_cb=@Total_cb");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,250),
					new SqlParameter("@drbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xrbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfxr", SqlDbType.VarChar,50),
					new SqlParameter("@xftm", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx", SqlDbType.VarChar,100),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@jjdj", SqlDbType.Decimal,5),
					new SqlParameter("@Total_cb", SqlDbType.Decimal,5),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.lksj;
			parameters[4].Value = model.czsj;
			parameters[5].Value = model.czy;
			parameters[6].Value = model.bz;
			parameters[7].Value = model.drbh;
			parameters[8].Value = model.xfdr;
			parameters[9].Value = model.xrbh;
			parameters[10].Value = model.xfxr;
			parameters[11].Value = model.xftm;
			parameters[12].Value = model.xfmx;
			parameters[13].Value = model.mxbh;
			parameters[14].Value = model.xfsl;
			parameters[15].Value = model.shsc;
			parameters[16].Value = model.jjdj;
			parameters[17].Value = model.Total_cb;
			parameters[18].Value = model.id;

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
			strSql.Append("delete from Xxfmx_lkmx ");
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
			strSql.Append("delete from Xxfmx_lkmx ");
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
		public Hotel_app.Model.Xxfmx_lkmx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,lsbh,lksj,czsj,czy,bz,drbh,xfdr,xrbh,xfxr,xftm,xfmx,mxbh,xfsl,shsc,jjdj,Total_cb from Xxfmx_lkmx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Xxfmx_lkmx model=new Hotel_app.Model.Xxfmx_lkmx();
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
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bz"]!=null && ds.Tables[0].Rows[0]["bz"].ToString()!="")
				{
					model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
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
				if(ds.Tables[0].Rows[0]["xfsl"]!=null && ds.Tables[0].Rows[0]["xfsl"].ToString()!="")
				{
					model.xfsl=decimal.Parse(ds.Tables[0].Rows[0]["xfsl"].ToString());
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
				if(ds.Tables[0].Rows[0]["jjdj"]!=null && ds.Tables[0].Rows[0]["jjdj"].ToString()!="")
				{
					model.jjdj=decimal.Parse(ds.Tables[0].Rows[0]["jjdj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Total_cb"]!=null && ds.Tables[0].Rows[0]["Total_cb"].ToString()!="")
				{
					model.Total_cb=decimal.Parse(ds.Tables[0].Rows[0]["Total_cb"].ToString());
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
			strSql.Append("select id,yydh,qymc,lsbh,lksj,czsj,czy,bz,drbh,xfdr,xrbh,xfxr,xftm,xfmx,mxbh,xfsl,shsc,jjdj,Total_cb ");
			strSql.Append(" FROM Xxfmx_lkmx ");
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
			strSql.Append(" id,yydh,qymc,lsbh,lksj,czsj,czy,bz,drbh,xfdr,xrbh,xfxr,xftm,xfmx,mxbh,xfsl,shsc,jjdj,Total_cb ");
			strSql.Append(" FROM Xxfmx_lkmx ");
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
			strSql.Append("select count(1) FROM Xxfmx_lkmx ");
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
			strSql.Append(")AS Row, T.*  from Xxfmx_lkmx T ");
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
			parameters[0].Value = "Xxfmx_lkmx";
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

