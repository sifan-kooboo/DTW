using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Qtsjy
	/// </summary>
	public partial class Qtsjy
	{
		public Qtsjy()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Qtsjy"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Qtsjy");
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
		public int Add(Hotel_app.Model.Qtsjy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Qtsjy(");
			strSql.Append("yydh,qymc,lsbh,fjbh,sktt,krxm,krsj,zjhm,xyh,xydw,hykh,tsrx,tsnr,tssj,czy,clbm,clnr,clsj,cly,is_top,is_select,shsc)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@lsbh,@fjbh,@sktt,@krxm,@krsj,@zjhm,@xyh,@xydw,@hykh,@tsrx,@tsnr,@tssj,@czy,@clbm,@clnr,@clsj,@cly,@is_top,@is_select,@shsc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,500),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@tsrx", SqlDbType.VarChar,50),
					new SqlParameter("@tsnr", SqlDbType.VarChar,500),
					new SqlParameter("@tssj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@clbm", SqlDbType.VarChar,50),
					new SqlParameter("@clnr", SqlDbType.VarChar,500),
					new SqlParameter("@clsj", SqlDbType.DateTime),
					new SqlParameter("@cly", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.fjbh;
			parameters[4].Value = model.sktt;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.krsj;
			parameters[7].Value = model.zjhm;
			parameters[8].Value = model.xyh;
			parameters[9].Value = model.xydw;
			parameters[10].Value = model.hykh;
			parameters[11].Value = model.tsrx;
			parameters[12].Value = model.tsnr;
			parameters[13].Value = model.tssj;
			parameters[14].Value = model.czy;
			parameters[15].Value = model.clbm;
			parameters[16].Value = model.clnr;
			parameters[17].Value = model.clsj;
			parameters[18].Value = model.cly;
			parameters[19].Value = model.is_top;
			parameters[20].Value = model.is_select;
			parameters[21].Value = model.shsc;

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
		public bool Update(Hotel_app.Model.Qtsjy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Qtsjy set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("krsj=@krsj,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("tsrx=@tsrx,");
			strSql.Append("tsnr=@tsnr,");
			strSql.Append("tssj=@tssj,");
			strSql.Append("czy=@czy,");
			strSql.Append("clbm=@clbm,");
			strSql.Append("clnr=@clnr,");
			strSql.Append("clsj=@clsj,");
			strSql.Append("cly=@cly,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("shsc=@shsc");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,500),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@tsrx", SqlDbType.VarChar,50),
					new SqlParameter("@tsnr", SqlDbType.VarChar,500),
					new SqlParameter("@tssj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@clbm", SqlDbType.VarChar,50),
					new SqlParameter("@clnr", SqlDbType.VarChar,500),
					new SqlParameter("@clsj", SqlDbType.DateTime),
					new SqlParameter("@cly", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.fjbh;
			parameters[4].Value = model.sktt;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.krsj;
			parameters[7].Value = model.zjhm;
			parameters[8].Value = model.xyh;
			parameters[9].Value = model.xydw;
			parameters[10].Value = model.hykh;
			parameters[11].Value = model.tsrx;
			parameters[12].Value = model.tsnr;
			parameters[13].Value = model.tssj;
			parameters[14].Value = model.czy;
			parameters[15].Value = model.clbm;
			parameters[16].Value = model.clnr;
			parameters[17].Value = model.clsj;
			parameters[18].Value = model.cly;
			parameters[19].Value = model.is_top;
			parameters[20].Value = model.is_select;
			parameters[21].Value = model.shsc;
			parameters[22].Value = model.id;

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
			strSql.Append("delete from Qtsjy ");
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
			strSql.Append("delete from Qtsjy ");
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
		public Hotel_app.Model.Qtsjy GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,lsbh,fjbh,sktt,krxm,krsj,zjhm,xyh,xydw,hykh,tsrx,tsnr,tssj,czy,clbm,clnr,clsj,cly,is_top,is_select,shsc from Qtsjy ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Qtsjy model=new Hotel_app.Model.Qtsjy();
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
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsj"]!=null && ds.Tables[0].Rows[0]["krsj"].ToString()!="")
				{
					model.krsj=ds.Tables[0].Rows[0]["krsj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh"]!=null && ds.Tables[0].Rows[0]["xyh"].ToString()!="")
				{
					model.xyh=ds.Tables[0].Rows[0]["xyh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tsrx"]!=null && ds.Tables[0].Rows[0]["tsrx"].ToString()!="")
				{
					model.tsrx=ds.Tables[0].Rows[0]["tsrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tsnr"]!=null && ds.Tables[0].Rows[0]["tsnr"].ToString()!="")
				{
					model.tsnr=ds.Tables[0].Rows[0]["tsnr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tssj"]!=null && ds.Tables[0].Rows[0]["tssj"].ToString()!="")
				{
					model.tssj=DateTime.Parse(ds.Tables[0].Rows[0]["tssj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["clbm"]!=null && ds.Tables[0].Rows[0]["clbm"].ToString()!="")
				{
					model.clbm=ds.Tables[0].Rows[0]["clbm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["clnr"]!=null && ds.Tables[0].Rows[0]["clnr"].ToString()!="")
				{
					model.clnr=ds.Tables[0].Rows[0]["clnr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["clsj"]!=null && ds.Tables[0].Rows[0]["clsj"].ToString()!="")
				{
					model.clsj=DateTime.Parse(ds.Tables[0].Rows[0]["clsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cly"]!=null && ds.Tables[0].Rows[0]["cly"].ToString()!="")
				{
					model.cly=ds.Tables[0].Rows[0]["cly"].ToString();
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
			strSql.Append("select id,yydh,qymc,lsbh,fjbh,sktt,krxm,krsj,zjhm,xyh,xydw,hykh,tsrx,tsnr,tssj,czy,clbm,clnr,clsj,cly,is_top,is_select,shsc ");
			strSql.Append(" FROM Qtsjy ");
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
			strSql.Append(" id,yydh,qymc,lsbh,fjbh,sktt,krxm,krsj,zjhm,xyh,xydw,hykh,tsrx,tsnr,tssj,czy,clbm,clnr,clsj,cly,is_top,is_select,shsc ");
			strSql.Append(" FROM Qtsjy ");
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
			strSql.Append("select count(1) FROM Qtsjy ");
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
			strSql.Append(")AS Row, T.*  from Qtsjy T ");
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
			parameters[0].Value = "Qtsjy";
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

