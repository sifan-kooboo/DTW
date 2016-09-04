using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Hhyjf_df
	/// </summary>
	public partial class Hhyjf_df
	{
		public Hhyjf_df()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Hhyjf_df"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Hhyjf_df");
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
		public int Add(Hotel_app.Model.Hhyjf_df model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Hhyjf_df(");
			strSql.Append("yydh,qymc,lsbh_df,hykh,hykh_bz,krxm,dfjf,dfxm,dfsl,xfrq,xfsj,shsc,scsj,is_top,is_select,shqx,parent_hykh)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@lsbh_df,@hykh,@hykh_bz,@krxm,@dfjf,@dfxm,@dfsl,@xfrq,@xfsj,@shsc,@scsj,@is_top,@is_select,@shqx,@parent_hykh)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh_df", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@dfjf", SqlDbType.Decimal,9),
					new SqlParameter("@dfxm", SqlDbType.VarChar,250),
					new SqlParameter("@dfsl", SqlDbType.Decimal,9),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scsj", SqlDbType.DateTime),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shqx", SqlDbType.Bit,1),
					new SqlParameter("@parent_hykh", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh_df;
			parameters[3].Value = model.hykh;
			parameters[4].Value = model.hykh_bz;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.dfjf;
			parameters[7].Value = model.dfxm;
			parameters[8].Value = model.dfsl;
			parameters[9].Value = model.xfrq;
			parameters[10].Value = model.xfsj;
			parameters[11].Value = model.shsc;
			parameters[12].Value = model.scsj;
			parameters[13].Value = model.is_top;
			parameters[14].Value = model.is_select;
			parameters[15].Value = model.shqx;
			parameters[16].Value = model.parent_hykh;

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
		public bool Update(Hotel_app.Model.Hhyjf_df model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Hhyjf_df set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("lsbh_df=@lsbh_df,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("hykh_bz=@hykh_bz,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("dfjf=@dfjf,");
			strSql.Append("dfxm=@dfxm,");
			strSql.Append("dfsl=@dfsl,");
			strSql.Append("xfrq=@xfrq,");
			strSql.Append("xfsj=@xfsj,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("scsj=@scsj,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("shqx=@shqx,");
			strSql.Append("parent_hykh=@parent_hykh");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh_df", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@dfjf", SqlDbType.Decimal,9),
					new SqlParameter("@dfxm", SqlDbType.VarChar,250),
					new SqlParameter("@dfsl", SqlDbType.Decimal,9),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scsj", SqlDbType.DateTime),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shqx", SqlDbType.Bit,1),
					new SqlParameter("@parent_hykh", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh_df;
			parameters[3].Value = model.hykh;
			parameters[4].Value = model.hykh_bz;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.dfjf;
			parameters[7].Value = model.dfxm;
			parameters[8].Value = model.dfsl;
			parameters[9].Value = model.xfrq;
			parameters[10].Value = model.xfsj;
			parameters[11].Value = model.shsc;
			parameters[12].Value = model.scsj;
			parameters[13].Value = model.is_top;
			parameters[14].Value = model.is_select;
			parameters[15].Value = model.shqx;
			parameters[16].Value = model.parent_hykh;
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
			strSql.Append("delete from Hhyjf_df ");
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
			strSql.Append("delete from Hhyjf_df ");
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
		public Hotel_app.Model.Hhyjf_df GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,lsbh_df,hykh,hykh_bz,krxm,dfjf,dfxm,dfsl,xfrq,xfsj,shsc,scsj,is_top,is_select,shqx,parent_hykh from Hhyjf_df ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Hhyjf_df model=new Hotel_app.Model.Hhyjf_df();
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
				if(ds.Tables[0].Rows[0]["lsbh_df"]!=null && ds.Tables[0].Rows[0]["lsbh_df"].ToString()!="")
				{
					model.lsbh_df=ds.Tables[0].Rows[0]["lsbh_df"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh_bz"]!=null && ds.Tables[0].Rows[0]["hykh_bz"].ToString()!="")
				{
					model.hykh_bz=ds.Tables[0].Rows[0]["hykh_bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["dfjf"]!=null && ds.Tables[0].Rows[0]["dfjf"].ToString()!="")
				{
					model.dfjf=decimal.Parse(ds.Tables[0].Rows[0]["dfjf"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dfxm"]!=null && ds.Tables[0].Rows[0]["dfxm"].ToString()!="")
				{
					model.dfxm=ds.Tables[0].Rows[0]["dfxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["dfsl"]!=null && ds.Tables[0].Rows[0]["dfsl"].ToString()!="")
				{
					model.dfsl=decimal.Parse(ds.Tables[0].Rows[0]["dfsl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfrq"]!=null && ds.Tables[0].Rows[0]["xfrq"].ToString()!="")
				{
					model.xfrq=DateTime.Parse(ds.Tables[0].Rows[0]["xfrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfsj"]!=null && ds.Tables[0].Rows[0]["xfsj"].ToString()!="")
				{
					model.xfsj=DateTime.Parse(ds.Tables[0].Rows[0]["xfsj"].ToString());
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
				if(ds.Tables[0].Rows[0]["scsj"]!=null && ds.Tables[0].Rows[0]["scsj"].ToString()!="")
				{
					model.scsj=DateTime.Parse(ds.Tables[0].Rows[0]["scsj"].ToString());
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
				if(ds.Tables[0].Rows[0]["shqx"]!=null && ds.Tables[0].Rows[0]["shqx"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shqx"].ToString()=="1")||(ds.Tables[0].Rows[0]["shqx"].ToString().ToLower()=="true"))
					{
						model.shqx=true;
					}
					else
					{
						model.shqx=false;
					}
				}
				if(ds.Tables[0].Rows[0]["parent_hykh"]!=null && ds.Tables[0].Rows[0]["parent_hykh"].ToString()!="")
				{
					model.parent_hykh=ds.Tables[0].Rows[0]["parent_hykh"].ToString();
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
			strSql.Append("select id,yydh,qymc,lsbh_df,hykh,hykh_bz,krxm,dfjf,dfxm,dfsl,xfrq,xfsj,shsc,scsj,is_top,is_select,shqx,parent_hykh ");
			strSql.Append(" FROM Hhyjf_df ");
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
			strSql.Append(" id,yydh,qymc,lsbh_df,hykh,hykh_bz,krxm,dfjf,dfxm,dfsl,xfrq,xfsj,shsc,scsj,is_top,is_select,shqx,parent_hykh ");
			strSql.Append(" FROM Hhyjf_df ");
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
			strSql.Append("select count(1) FROM Hhyjf_df ");
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
			strSql.Append(")AS Row, T.*  from Hhyjf_df T ");
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
			parameters[0].Value = "Hhyjf_df";
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

