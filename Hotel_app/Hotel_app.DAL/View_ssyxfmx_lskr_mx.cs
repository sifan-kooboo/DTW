using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:View_ssyxfmx_lskr_mx
	/// </summary>
	public partial class View_ssyxfmx_lskr_mx
	{
		public View_ssyxfmx_lskr_mx()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.View_ssyxfmx_lskr_mx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_ssyxfmx_lskr_mx(");
			strSql.Append("fjrb,fjbh,xfrq,xfxm,sjxfje,zjhm,krxm,yydh,xfsj,xfdr,xfrb,yxzj,hykh,id)");
			strSql.Append(" values (");
			strSql.Append("@fjrb,@fjbh,@xfrq,@xfxm,@sjxfje,@zjhm,@krxm,@yydh,@xfsj,@xfdr,@xfrb,@yxzj,@hykh,@id)");
			SqlParameter[] parameters = {
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.fjrb;
			parameters[1].Value = model.fjbh;
			parameters[2].Value = model.xfrq;
			parameters[3].Value = model.xfxm;
			parameters[4].Value = model.sjxfje;
			parameters[5].Value = model.zjhm;
			parameters[6].Value = model.krxm;
			parameters[7].Value = model.yydh;
			parameters[8].Value = model.xfsj;
			parameters[9].Value = model.xfdr;
			parameters[10].Value = model.xfrb;
			parameters[11].Value = model.yxzj;
			parameters[12].Value = model.hykh;
			parameters[13].Value = model.id;

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
		public bool Update(Hotel_app.Model.View_ssyxfmx_lskr_mx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_ssyxfmx_lskr_mx set ");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("xfrq=@xfrq,");
			strSql.Append("xfxm=@xfxm,");
			strSql.Append("sjxfje=@sjxfje,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("xfsj=@xfsj,");
			strSql.Append("xfdr=@xfdr,");
			strSql.Append("xfrb=@xfrb,");
			strSql.Append("yxzj=@yxzj,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("id=@id");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.fjrb;
			parameters[1].Value = model.fjbh;
			parameters[2].Value = model.xfrq;
			parameters[3].Value = model.xfxm;
			parameters[4].Value = model.sjxfje;
			parameters[5].Value = model.zjhm;
			parameters[6].Value = model.krxm;
			parameters[7].Value = model.yydh;
			parameters[8].Value = model.xfsj;
			parameters[9].Value = model.xfdr;
			parameters[10].Value = model.xfrb;
			parameters[11].Value = model.yxzj;
			parameters[12].Value = model.hykh;
			parameters[13].Value = model.id;

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
			strSql.Append("delete from View_ssyxfmx_lskr_mx ");
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
		public Hotel_app.Model.View_ssyxfmx_lskr_mx GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 fjrb,fjbh,xfrq,xfxm,sjxfje,zjhm,krxm,yydh,xfsj,xfdr,xfrb,yxzj,hykh,id from View_ssyxfmx_lskr_mx ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.View_ssyxfmx_lskr_mx model=new Hotel_app.Model.View_ssyxfmx_lskr_mx();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfrq"]!=null && ds.Tables[0].Rows[0]["xfrq"].ToString()!="")
				{
					model.xfrq=DateTime.Parse(ds.Tables[0].Rows[0]["xfrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfxm"]!=null && ds.Tables[0].Rows[0]["xfxm"].ToString()!="")
				{
					model.xfxm=ds.Tables[0].Rows[0]["xfxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sjxfje"]!=null && ds.Tables[0].Rows[0]["sjxfje"].ToString()!="")
				{
					model.sjxfje=decimal.Parse(ds.Tables[0].Rows[0]["sjxfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfsj"]!=null && ds.Tables[0].Rows[0]["xfsj"].ToString()!="")
				{
					model.xfsj=DateTime.Parse(ds.Tables[0].Rows[0]["xfsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfdr"]!=null && ds.Tables[0].Rows[0]["xfdr"].ToString()!="")
				{
					model.xfdr=ds.Tables[0].Rows[0]["xfdr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfrb"]!=null && ds.Tables[0].Rows[0]["xfrb"].ToString()!="")
				{
					model.xfrb=ds.Tables[0].Rows[0]["xfrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yxzj"]!=null && ds.Tables[0].Rows[0]["yxzj"].ToString()!="")
				{
					model.yxzj=ds.Tables[0].Rows[0]["yxzj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
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
			strSql.Append("select fjrb,fjbh,xfrq,xfxm,sjxfje,zjhm,krxm,yydh,xfsj,xfdr,xfrb,yxzj,hykh,id ");
			strSql.Append(" FROM View_ssyxfmx_lskr_mx ");
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
			strSql.Append(" fjrb,fjbh,xfrq,xfxm,sjxfje,zjhm,krxm,yydh,xfsj,xfdr,xfrb,yxzj,hykh,id ");
			strSql.Append(" FROM View_ssyxfmx_lskr_mx ");
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
			strSql.Append("select count(1) FROM View_ssyxfmx_lskr_mx ");
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
			strSql.Append(")AS Row, T.*  from View_ssyxfmx_lskr_mx T ");
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
			parameters[0].Value = "View_ssyxfmx_lskr_mx";
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

