/**  版本信息模板在安装目录下，可自行修改。
* MT_Order.cs
*
* 功 能： N/A
* 类 名： MT_Order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-06-15 12:55:10   N/A    初版
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
namespace jdgl_res_head_app.DAL
{
	/// <summary>
	/// 数据访问类:MT_Order
	/// </summary>
	public partial class MT_Order
	{
		public MT_Order()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "MT_Order"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MT_Order");
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
		public int Add(jdgl_res_head_app.Model.MT_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MT_Order(");
			strSql.Append("channel_id,category_id,order_lsbh,user_id,fjrx_id,yd_name,yd_sex,yd_mobile,yd_email,crs,xhrs,yd_ddsj,yd_js,content,yd_ts,yd_jg,yd_statetime,yd_endtime,is_rz,state,add_time)");
			strSql.Append(" values (");
			strSql.Append("@channel_id,@category_id,@order_lsbh,@user_id,@fjrx_id,@yd_name,@yd_sex,@yd_mobile,@yd_email,@crs,@xhrs,@yd_ddsj,@yd_js,@content,@yd_ts,@yd_jg,@yd_statetime,@yd_endtime,@is_rz,@state,@add_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@order_lsbh", SqlDbType.NVarChar,150),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@fjrx_id", SqlDbType.Int,4),
					new SqlParameter("@yd_name", SqlDbType.NVarChar,150),
					new SqlParameter("@yd_sex", SqlDbType.NVarChar,50),
					new SqlParameter("@yd_mobile", SqlDbType.NVarChar,150),
					new SqlParameter("@yd_email", SqlDbType.NVarChar,150),
					new SqlParameter("@crs", SqlDbType.Int,4),
					new SqlParameter("@xhrs", SqlDbType.Int,4),
					new SqlParameter("@yd_ddsj", SqlDbType.VarChar,50),
					new SqlParameter("@yd_js", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@yd_ts", SqlDbType.Decimal,9),
					new SqlParameter("@yd_jg", SqlDbType.Decimal,9),
					new SqlParameter("@yd_statetime", SqlDbType.DateTime),
					new SqlParameter("@yd_endtime", SqlDbType.DateTime),
					new SqlParameter("@is_rz", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
			parameters[0].Value = model.channel_id;
			parameters[1].Value = model.category_id;
			parameters[2].Value = model.order_lsbh;
			parameters[3].Value = model.user_id;
			parameters[4].Value = model.fjrx_id;
			parameters[5].Value = model.yd_name;
			parameters[6].Value = model.yd_sex;
			parameters[7].Value = model.yd_mobile;
			parameters[8].Value = model.yd_email;
			parameters[9].Value = model.crs;
			parameters[10].Value = model.xhrs;
			parameters[11].Value = model.yd_ddsj;
			parameters[12].Value = model.yd_js;
			parameters[13].Value = model.content;
			parameters[14].Value = model.yd_ts;
			parameters[15].Value = model.yd_jg;
			parameters[16].Value = model.yd_statetime;
			parameters[17].Value = model.yd_endtime;
			parameters[18].Value = model.is_rz;
			parameters[19].Value = model.state;
			parameters[20].Value = model.add_time;

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
		public bool Update(jdgl_res_head_app.Model.MT_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MT_Order set ");
			strSql.Append("channel_id=@channel_id,");
			strSql.Append("category_id=@category_id,");
			strSql.Append("order_lsbh=@order_lsbh,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("fjrx_id=@fjrx_id,");
			strSql.Append("yd_name=@yd_name,");
			strSql.Append("yd_sex=@yd_sex,");
			strSql.Append("yd_mobile=@yd_mobile,");
			strSql.Append("yd_email=@yd_email,");
			strSql.Append("crs=@crs,");
			strSql.Append("xhrs=@xhrs,");
			strSql.Append("yd_ddsj=@yd_ddsj,");
			strSql.Append("yd_js=@yd_js,");
			strSql.Append("content=@content,");
			strSql.Append("yd_ts=@yd_ts,");
			strSql.Append("yd_jg=@yd_jg,");
			strSql.Append("yd_statetime=@yd_statetime,");
			strSql.Append("yd_endtime=@yd_endtime,");
			strSql.Append("is_rz=@is_rz,");
			strSql.Append("state=@state,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@channel_id", SqlDbType.Int,4),
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@order_lsbh", SqlDbType.NVarChar,150),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@fjrx_id", SqlDbType.Int,4),
					new SqlParameter("@yd_name", SqlDbType.NVarChar,150),
					new SqlParameter("@yd_sex", SqlDbType.NVarChar,50),
					new SqlParameter("@yd_mobile", SqlDbType.NVarChar,150),
					new SqlParameter("@yd_email", SqlDbType.NVarChar,150),
					new SqlParameter("@crs", SqlDbType.Int,4),
					new SqlParameter("@xhrs", SqlDbType.Int,4),
					new SqlParameter("@yd_ddsj", SqlDbType.VarChar,50),
					new SqlParameter("@yd_js", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@yd_ts", SqlDbType.Decimal,9),
					new SqlParameter("@yd_jg", SqlDbType.Decimal,9),
					new SqlParameter("@yd_statetime", SqlDbType.DateTime),
					new SqlParameter("@yd_endtime", SqlDbType.DateTime),
					new SqlParameter("@is_rz", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.channel_id;
			parameters[1].Value = model.category_id;
			parameters[2].Value = model.order_lsbh;
			parameters[3].Value = model.user_id;
			parameters[4].Value = model.fjrx_id;
			parameters[5].Value = model.yd_name;
			parameters[6].Value = model.yd_sex;
			parameters[7].Value = model.yd_mobile;
			parameters[8].Value = model.yd_email;
			parameters[9].Value = model.crs;
			parameters[10].Value = model.xhrs;
			parameters[11].Value = model.yd_ddsj;
			parameters[12].Value = model.yd_js;
			parameters[13].Value = model.content;
			parameters[14].Value = model.yd_ts;
			parameters[15].Value = model.yd_jg;
			parameters[16].Value = model.yd_statetime;
			parameters[17].Value = model.yd_endtime;
			parameters[18].Value = model.is_rz;
			parameters[19].Value = model.state;
			parameters[20].Value = model.add_time;
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
			strSql.Append("delete from MT_Order ");
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
			strSql.Append("delete from MT_Order ");
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
		public jdgl_res_head_app.Model.MT_Order GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,channel_id,category_id,order_lsbh,user_id,fjrx_id,yd_name,yd_sex,yd_mobile,yd_email,crs,xhrs,yd_ddsj,yd_js,content,yd_ts,yd_jg,yd_statetime,yd_endtime,is_rz,state,add_time from MT_Order ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			jdgl_res_head_app.Model.MT_Order model=new jdgl_res_head_app.Model.MT_Order();
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
		public jdgl_res_head_app.Model.MT_Order DataRowToModel(DataRow row)
		{
			jdgl_res_head_app.Model.MT_Order model=new jdgl_res_head_app.Model.MT_Order();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["channel_id"]!=null && row["channel_id"].ToString()!="")
				{
					model.channel_id=int.Parse(row["channel_id"].ToString());
				}
				if(row["category_id"]!=null && row["category_id"].ToString()!="")
				{
					model.category_id=int.Parse(row["category_id"].ToString());
				}
				if(row["order_lsbh"]!=null)
				{
					model.order_lsbh=row["order_lsbh"].ToString();
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["fjrx_id"]!=null && row["fjrx_id"].ToString()!="")
				{
					model.fjrx_id=int.Parse(row["fjrx_id"].ToString());
				}
				if(row["yd_name"]!=null)
				{
					model.yd_name=row["yd_name"].ToString();
				}
				if(row["yd_sex"]!=null)
				{
					model.yd_sex=row["yd_sex"].ToString();
				}
				if(row["yd_mobile"]!=null)
				{
					model.yd_mobile=row["yd_mobile"].ToString();
				}
				if(row["yd_email"]!=null)
				{
					model.yd_email=row["yd_email"].ToString();
				}
				if(row["crs"]!=null && row["crs"].ToString()!="")
				{
					model.crs=int.Parse(row["crs"].ToString());
				}
				if(row["xhrs"]!=null && row["xhrs"].ToString()!="")
				{
					model.xhrs=int.Parse(row["xhrs"].ToString());
				}
				if(row["yd_ddsj"]!=null)
				{
					model.yd_ddsj=row["yd_ddsj"].ToString();
				}
				if(row["yd_js"]!=null && row["yd_js"].ToString()!="")
				{
					model.yd_js=int.Parse(row["yd_js"].ToString());
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["yd_ts"]!=null && row["yd_ts"].ToString()!="")
				{
					model.yd_ts=decimal.Parse(row["yd_ts"].ToString());
				}
				if(row["yd_jg"]!=null && row["yd_jg"].ToString()!="")
				{
					model.yd_jg=decimal.Parse(row["yd_jg"].ToString());
				}
				if(row["yd_statetime"]!=null && row["yd_statetime"].ToString()!="")
				{
					model.yd_statetime=DateTime.Parse(row["yd_statetime"].ToString());
				}
				if(row["yd_endtime"]!=null && row["yd_endtime"].ToString()!="")
				{
					model.yd_endtime=DateTime.Parse(row["yd_endtime"].ToString());
				}
				if(row["is_rz"]!=null && row["is_rz"].ToString()!="")
				{
					model.is_rz=int.Parse(row["is_rz"].ToString());
				}
				if(row["state"]!=null && row["state"].ToString()!="")
				{
					model.state=int.Parse(row["state"].ToString());
				}
				if(row["add_time"]!=null && row["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(row["add_time"].ToString());
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
			strSql.Append("select id,channel_id,category_id,order_lsbh,user_id,fjrx_id,yd_name,yd_sex,yd_mobile,yd_email,crs,xhrs,yd_ddsj,yd_js,content,yd_ts,yd_jg,yd_statetime,yd_endtime,is_rz,state,add_time ");
			strSql.Append(" FROM MT_Order ");
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
			strSql.Append(" id,channel_id,category_id,order_lsbh,user_id,fjrx_id,yd_name,yd_sex,yd_mobile,yd_email,crs,xhrs,yd_ddsj,yd_js,content,yd_ts,yd_jg,yd_statetime,yd_endtime,is_rz,state,add_time ");
			strSql.Append(" FROM MT_Order ");
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
			strSql.Append("select count(1) FROM MT_Order ");
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
			strSql.Append(")AS Row, T.*  from MT_Order T ");
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
			parameters[0].Value = "MT_Order";
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

