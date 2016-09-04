using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Xxfmx
	/// </summary>
	public partial class Xxfmx
	{
		public Xxfmx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Xxfmx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Xxfmx");
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
		public int Add(Hotel_app.Model.Xxfmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Xxfmx(");
			strSql.Append("yydh,qymc,drbh,xfdr,xrbh,xfxr,mxbh,xfmx,zjm,xfgg,jjje,xfje,xftm,is_top,is_select,xf_cd,xf_dw,jldw,is_tj_kc,kcsl)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@drbh,@xfdr,@xrbh,@xfxr,@mxbh,@xfmx,@zjm,@xfgg,@jjje,@xfje,@xftm,@is_top,@is_select,@xf_cd,@xf_dw,@jldw,@is_tj_kc,@kcsl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@drbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xrbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfxr", SqlDbType.VarChar,50),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx", SqlDbType.VarChar,50),
					new SqlParameter("@zjm", SqlDbType.VarChar,50),
					new SqlParameter("@xfgg", SqlDbType.VarChar,50),
					new SqlParameter("@jjje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@xftm", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@xf_cd", SqlDbType.VarChar,50),
					new SqlParameter("@xf_dw", SqlDbType.VarChar,50),
					new SqlParameter("@jldw", SqlDbType.VarChar,50),
					new SqlParameter("@is_tj_kc", SqlDbType.Bit,1),
					new SqlParameter("@kcsl", SqlDbType.Decimal,9)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.drbh;
			parameters[3].Value = model.xfdr;
			parameters[4].Value = model.xrbh;
			parameters[5].Value = model.xfxr;
			parameters[6].Value = model.mxbh;
			parameters[7].Value = model.xfmx;
			parameters[8].Value = model.zjm;
			parameters[9].Value = model.xfgg;
			parameters[10].Value = model.jjje;
			parameters[11].Value = model.xfje;
			parameters[12].Value = model.xftm;
			parameters[13].Value = model.is_top;
			parameters[14].Value = model.is_select;
			parameters[15].Value = model.xf_cd;
			parameters[16].Value = model.xf_dw;
			parameters[17].Value = model.jldw;
			parameters[18].Value = model.is_tj_kc;
			parameters[19].Value = model.kcsl;

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
		public bool Update(Hotel_app.Model.Xxfmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Xxfmx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("drbh=@drbh,");
			strSql.Append("xfdr=@xfdr,");
			strSql.Append("xrbh=@xrbh,");
			strSql.Append("xfxr=@xfxr,");
			strSql.Append("mxbh=@mxbh,");
			strSql.Append("xfmx=@xfmx,");
			strSql.Append("zjm=@zjm,");
			strSql.Append("xfgg=@xfgg,");
			strSql.Append("jjje=@jjje,");
			strSql.Append("xfje=@xfje,");
			strSql.Append("xftm=@xftm,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("xf_cd=@xf_cd,");
			strSql.Append("xf_dw=@xf_dw,");
			strSql.Append("jldw=@jldw,");
			strSql.Append("is_tj_kc=@is_tj_kc,");
			strSql.Append("kcsl=@kcsl");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@drbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xrbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfxr", SqlDbType.VarChar,50),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfmx", SqlDbType.VarChar,50),
					new SqlParameter("@zjm", SqlDbType.VarChar,50),
					new SqlParameter("@xfgg", SqlDbType.VarChar,50),
					new SqlParameter("@jjje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@xftm", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@xf_cd", SqlDbType.VarChar,50),
					new SqlParameter("@xf_dw", SqlDbType.VarChar,50),
					new SqlParameter("@jldw", SqlDbType.VarChar,50),
					new SqlParameter("@is_tj_kc", SqlDbType.Bit,1),
					new SqlParameter("@kcsl", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.drbh;
			parameters[3].Value = model.xfdr;
			parameters[4].Value = model.xrbh;
			parameters[5].Value = model.xfxr;
			parameters[6].Value = model.mxbh;
			parameters[7].Value = model.xfmx;
			parameters[8].Value = model.zjm;
			parameters[9].Value = model.xfgg;
			parameters[10].Value = model.jjje;
			parameters[11].Value = model.xfje;
			parameters[12].Value = model.xftm;
			parameters[13].Value = model.is_top;
			parameters[14].Value = model.is_select;
			parameters[15].Value = model.xf_cd;
			parameters[16].Value = model.xf_dw;
			parameters[17].Value = model.jldw;
			parameters[18].Value = model.is_tj_kc;
			parameters[19].Value = model.kcsl;
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
			strSql.Append("delete from Xxfmx ");
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
			strSql.Append("delete from Xxfmx ");
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
		public Hotel_app.Model.Xxfmx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,drbh,xfdr,xrbh,xfxr,mxbh,xfmx,zjm,xfgg,jjje,xfje,xftm,is_top,is_select,xf_cd,xf_dw,jldw,is_tj_kc,kcsl from Xxfmx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Xxfmx model=new Hotel_app.Model.Xxfmx();
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
				if(ds.Tables[0].Rows[0]["mxbh"]!=null && ds.Tables[0].Rows[0]["mxbh"].ToString()!="")
				{
					model.mxbh=ds.Tables[0].Rows[0]["mxbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfmx"]!=null && ds.Tables[0].Rows[0]["xfmx"].ToString()!="")
				{
					model.xfmx=ds.Tables[0].Rows[0]["xfmx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjm"]!=null && ds.Tables[0].Rows[0]["zjm"].ToString()!="")
				{
					model.zjm=ds.Tables[0].Rows[0]["zjm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfgg"]!=null && ds.Tables[0].Rows[0]["xfgg"].ToString()!="")
				{
					model.xfgg=ds.Tables[0].Rows[0]["xfgg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jjje"]!=null && ds.Tables[0].Rows[0]["jjje"].ToString()!="")
				{
					model.jjje=decimal.Parse(ds.Tables[0].Rows[0]["jjje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje"]!=null && ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xftm"]!=null && ds.Tables[0].Rows[0]["xftm"].ToString()!="")
				{
					model.xftm=ds.Tables[0].Rows[0]["xftm"].ToString();
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
				if(ds.Tables[0].Rows[0]["xf_cd"]!=null && ds.Tables[0].Rows[0]["xf_cd"].ToString()!="")
				{
					model.xf_cd=ds.Tables[0].Rows[0]["xf_cd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xf_dw"]!=null && ds.Tables[0].Rows[0]["xf_dw"].ToString()!="")
				{
					model.xf_dw=ds.Tables[0].Rows[0]["xf_dw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jldw"]!=null && ds.Tables[0].Rows[0]["jldw"].ToString()!="")
				{
					model.jldw=ds.Tables[0].Rows[0]["jldw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["is_tj_kc"]!=null && ds.Tables[0].Rows[0]["is_tj_kc"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_tj_kc"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_tj_kc"].ToString().ToLower()=="true"))
					{
						model.is_tj_kc=true;
					}
					else
					{
						model.is_tj_kc=false;
					}
				}
				if(ds.Tables[0].Rows[0]["kcsl"]!=null && ds.Tables[0].Rows[0]["kcsl"].ToString()!="")
				{
					model.kcsl=decimal.Parse(ds.Tables[0].Rows[0]["kcsl"].ToString());
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
			strSql.Append("select id,yydh,qymc,drbh,xfdr,xrbh,xfxr,mxbh,xfmx,zjm,xfgg,jjje,xfje,xftm,is_top,is_select,xf_cd,xf_dw,jldw,is_tj_kc,kcsl ");
			strSql.Append(" FROM Xxfmx ");
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
			strSql.Append(" id,yydh,qymc,drbh,xfdr,xrbh,xfxr,mxbh,xfmx,zjm,xfgg,jjje,xfje,xftm,is_top,is_select,xf_cd,xf_dw,jldw,is_tj_kc,kcsl ");
			strSql.Append(" FROM Xxfmx ");
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
			strSql.Append("select count(1) FROM Xxfmx ");
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
			strSql.Append(")AS Row, T.*  from Xxfmx T ");
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
			parameters[0].Value = "Xxfmx";
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

