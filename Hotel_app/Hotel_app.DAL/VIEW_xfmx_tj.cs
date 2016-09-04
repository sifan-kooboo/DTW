using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_xfmx_tj
	/// </summary>
	public partial class VIEW_xfmx_tj
	{
		public VIEW_xfmx_tj()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.VIEW_xfmx_tj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VIEW_xfmx_tj(");
			strSql.Append("yydh,qymc,id_app,jzbh,lsbh,krxm,fjbh,fjrb,sktt,xfrq,xfsj,czy,czy_bc,xfsl,sjxfje,jjje,xfzy,xfbz,xfxm,xfrb,xfdr,mxbh)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@id_app,@jzbh,@lsbh,@krxm,@fjbh,@fjrb,@sktt,@xfrq,@xfsj,@czy,@czy_bc,@xfsl,@sjxfje,@jjje,@xfzy,@xfbz,@xfxm,@xfrb,@xfdr,@mxbh)");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czy_bc", SqlDbType.VarChar,50),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@jjje", SqlDbType.Decimal,9),
					new SqlParameter("@xfzy", SqlDbType.VarChar,50),
					new SqlParameter("@xfbz", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.id_app;
			parameters[3].Value = model.jzbh;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.fjbh;
			parameters[7].Value = model.fjrb;
			parameters[8].Value = model.sktt;
			parameters[9].Value = model.xfrq;
			parameters[10].Value = model.xfsj;
			parameters[11].Value = model.czy;
			parameters[12].Value = model.czy_bc;
			parameters[13].Value = model.xfsl;
			parameters[14].Value = model.sjxfje;
			parameters[15].Value = model.jjje;
			parameters[16].Value = model.xfzy;
			parameters[17].Value = model.xfbz;
			parameters[18].Value = model.xfxm;
			parameters[19].Value = model.xfrb;
			parameters[20].Value = model.xfdr;
			parameters[21].Value = model.mxbh;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.VIEW_xfmx_tj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VIEW_xfmx_tj set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("id_app=@id_app,");
			strSql.Append("jzbh=@jzbh,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("xfrq=@xfrq,");
			strSql.Append("xfsj=@xfsj,");
			strSql.Append("czy=@czy,");
			strSql.Append("czy_bc=@czy_bc,");
			strSql.Append("xfsl=@xfsl,");
			strSql.Append("sjxfje=@sjxfje,");
			strSql.Append("jjje=@jjje,");
			strSql.Append("xfzy=@xfzy,");
			strSql.Append("xfbz=@xfbz,");
			strSql.Append("xfxm=@xfxm,");
			strSql.Append("xfrb=@xfrb,");
			strSql.Append("xfdr=@xfdr,");
			strSql.Append("mxbh=@mxbh");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czy_bc", SqlDbType.VarChar,50),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@jjje", SqlDbType.Decimal,9),
					new SqlParameter("@xfzy", SqlDbType.VarChar,50),
					new SqlParameter("@xfbz", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.id_app;
			parameters[3].Value = model.jzbh;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.fjbh;
			parameters[7].Value = model.fjrb;
			parameters[8].Value = model.sktt;
			parameters[9].Value = model.xfrq;
			parameters[10].Value = model.xfsj;
			parameters[11].Value = model.czy;
			parameters[12].Value = model.czy_bc;
			parameters[13].Value = model.xfsl;
			parameters[14].Value = model.sjxfje;
			parameters[15].Value = model.jjje;
			parameters[16].Value = model.xfzy;
			parameters[17].Value = model.xfbz;
			parameters[18].Value = model.xfxm;
			parameters[19].Value = model.xfrb;
			parameters[20].Value = model.xfdr;
			parameters[21].Value = model.mxbh;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VIEW_xfmx_tj ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Hotel_app.Model.VIEW_xfmx_tj GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 yydh,qymc,id_app,jzbh,lsbh,krxm,fjbh,fjrb,sktt,xfrq,xfsj,czy,czy_bc,xfsl,sjxfje,jjje,xfzy,xfbz,xfxm,xfrb,xfdr,mxbh from VIEW_xfmx_tj ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.VIEW_xfmx_tj model=new Hotel_app.Model.VIEW_xfmx_tj();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["id_app"]!=null && ds.Tables[0].Rows[0]["id_app"].ToString()!="")
				{
					model.id_app=ds.Tables[0].Rows[0]["id_app"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jzbh"]!=null && ds.Tables[0].Rows[0]["jzbh"].ToString()!="")
				{
					model.jzbh=ds.Tables[0].Rows[0]["jzbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfrq"]!=null && ds.Tables[0].Rows[0]["xfrq"].ToString()!="")
				{
					model.xfrq=DateTime.Parse(ds.Tables[0].Rows[0]["xfrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfsj"]!=null && ds.Tables[0].Rows[0]["xfsj"].ToString()!="")
				{
					model.xfsj=DateTime.Parse(ds.Tables[0].Rows[0]["xfsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy_bc"]!=null && ds.Tables[0].Rows[0]["czy_bc"].ToString()!="")
				{
					model.czy_bc=ds.Tables[0].Rows[0]["czy_bc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfsl"]!=null && ds.Tables[0].Rows[0]["xfsl"].ToString()!="")
				{
					model.xfsl=decimal.Parse(ds.Tables[0].Rows[0]["xfsl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sjxfje"]!=null && ds.Tables[0].Rows[0]["sjxfje"].ToString()!="")
				{
					model.sjxfje=decimal.Parse(ds.Tables[0].Rows[0]["sjxfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jjje"]!=null && ds.Tables[0].Rows[0]["jjje"].ToString()!="")
				{
					model.jjje=decimal.Parse(ds.Tables[0].Rows[0]["jjje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfzy"]!=null && ds.Tables[0].Rows[0]["xfzy"].ToString()!="")
				{
					model.xfzy=ds.Tables[0].Rows[0]["xfzy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfbz"]!=null && ds.Tables[0].Rows[0]["xfbz"].ToString()!="")
				{
					model.xfbz=ds.Tables[0].Rows[0]["xfbz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfxm"]!=null && ds.Tables[0].Rows[0]["xfxm"].ToString()!="")
				{
					model.xfxm=ds.Tables[0].Rows[0]["xfxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfrb"]!=null && ds.Tables[0].Rows[0]["xfrb"].ToString()!="")
				{
					model.xfrb=ds.Tables[0].Rows[0]["xfrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfdr"]!=null && ds.Tables[0].Rows[0]["xfdr"].ToString()!="")
				{
					model.xfdr=ds.Tables[0].Rows[0]["xfdr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mxbh"]!=null && ds.Tables[0].Rows[0]["mxbh"].ToString()!="")
				{
					model.mxbh=ds.Tables[0].Rows[0]["mxbh"].ToString();
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
			strSql.Append("select yydh,qymc,id_app,jzbh,lsbh,krxm,fjbh,fjrb,sktt,xfrq,xfsj,czy,czy_bc,xfsl,sjxfje,jjje,xfzy,xfbz,xfxm,xfrb,xfdr,mxbh ");
			strSql.Append(" FROM VIEW_xfmx_tj ");
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
			strSql.Append(" yydh,qymc,id_app,jzbh,lsbh,krxm,fjbh,fjrb,sktt,xfrq,xfsj,czy,czy_bc,xfsl,sjxfje,jjje,xfzy,xfbz,xfxm,xfrb,xfdr,mxbh ");
			strSql.Append(" FROM VIEW_xfmx_tj ");
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
			strSql.Append("select count(1) FROM VIEW_xfmx_tj ");
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
			strSql.Append(")AS Row, T.*  from VIEW_xfmx_tj T ");
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
			parameters[0].Value = "VIEW_xfmx_tj";
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

