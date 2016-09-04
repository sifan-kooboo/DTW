using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:S_jbmx
	/// </summary>
	public partial class S_jbmx
	{
		public S_jbmx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "S_jbmx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from S_jbmx");
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
		public int Add(Hotel_app.Model.S_jbmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_jbmx(");
			strSql.Append("yydh,qymc,lsbh,syzd,syy,syy_rb_visible,fkfs,qtfk,ysk,t_ysk,qtsk_t_ysk,shsc,t_ysk_qt,ysk_fs,qt_yyk)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@lsbh,@syzd,@syy,@syy_rb_visible,@fkfs,@qtfk,@ysk,@t_ysk,@qtsk_t_ysk,@shsc,@t_ysk_qt,@ysk_fs,@qt_yyk)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@syy", SqlDbType.VarChar,50),
					new SqlParameter("@syy_rb_visible", SqlDbType.VarChar,50),
					new SqlParameter("@fkfs", SqlDbType.VarChar,50),
					new SqlParameter("@qtfk", SqlDbType.Decimal,9),
					new SqlParameter("@ysk", SqlDbType.Decimal,9),
					new SqlParameter("@t_ysk", SqlDbType.Decimal,9),
					new SqlParameter("@qtsk_t_ysk", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@t_ysk_qt", SqlDbType.Decimal,9),
					new SqlParameter("@ysk_fs", SqlDbType.Decimal,9),
					new SqlParameter("@qt_yyk", SqlDbType.Decimal,9)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.syzd;
			parameters[4].Value = model.syy;
			parameters[5].Value = model.syy_rb_visible;
			parameters[6].Value = model.fkfs;
			parameters[7].Value = model.qtfk;
			parameters[8].Value = model.ysk;
			parameters[9].Value = model.t_ysk;
			parameters[10].Value = model.qtsk_t_ysk;
			parameters[11].Value = model.shsc;
			parameters[12].Value = model.t_ysk_qt;
			parameters[13].Value = model.ysk_fs;
			parameters[14].Value = model.qt_yyk;

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
		public bool Update(Hotel_app.Model.S_jbmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_jbmx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("syzd=@syzd,");
			strSql.Append("syy=@syy,");
			strSql.Append("syy_rb_visible=@syy_rb_visible,");
			strSql.Append("fkfs=@fkfs,");
			strSql.Append("qtfk=@qtfk,");
			strSql.Append("ysk=@ysk,");
			strSql.Append("t_ysk=@t_ysk,");
			strSql.Append("qtsk_t_ysk=@qtsk_t_ysk,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("t_ysk_qt=@t_ysk_qt,");
			strSql.Append("ysk_fs=@ysk_fs,");
			strSql.Append("qt_yyk=@qt_yyk");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@syy", SqlDbType.VarChar,50),
					new SqlParameter("@syy_rb_visible", SqlDbType.VarChar,50),
					new SqlParameter("@fkfs", SqlDbType.VarChar,50),
					new SqlParameter("@qtfk", SqlDbType.Decimal,9),
					new SqlParameter("@ysk", SqlDbType.Decimal,9),
					new SqlParameter("@t_ysk", SqlDbType.Decimal,9),
					new SqlParameter("@qtsk_t_ysk", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@t_ysk_qt", SqlDbType.Decimal,9),
					new SqlParameter("@ysk_fs", SqlDbType.Decimal,9),
					new SqlParameter("@qt_yyk", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.syzd;
			parameters[4].Value = model.syy;
			parameters[5].Value = model.syy_rb_visible;
			parameters[6].Value = model.fkfs;
			parameters[7].Value = model.qtfk;
			parameters[8].Value = model.ysk;
			parameters[9].Value = model.t_ysk;
			parameters[10].Value = model.qtsk_t_ysk;
			parameters[11].Value = model.shsc;
			parameters[12].Value = model.t_ysk_qt;
			parameters[13].Value = model.ysk_fs;
			parameters[14].Value = model.qt_yyk;
			parameters[15].Value = model.id;

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
			strSql.Append("delete from S_jbmx ");
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
			strSql.Append("delete from S_jbmx ");
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
		public Hotel_app.Model.S_jbmx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,lsbh,syzd,syy,syy_rb_visible,fkfs,qtfk,ysk,t_ysk,qtsk_t_ysk,shsc,t_ysk_qt,ysk_fs,qt_yyk from S_jbmx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.S_jbmx model=new Hotel_app.Model.S_jbmx();
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
				if(ds.Tables[0].Rows[0]["syzd"]!=null && ds.Tables[0].Rows[0]["syzd"].ToString()!="")
				{
					model.syzd=ds.Tables[0].Rows[0]["syzd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["syy"]!=null && ds.Tables[0].Rows[0]["syy"].ToString()!="")
				{
					model.syy=ds.Tables[0].Rows[0]["syy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["syy_rb_visible"]!=null && ds.Tables[0].Rows[0]["syy_rb_visible"].ToString()!="")
				{
					model.syy_rb_visible=ds.Tables[0].Rows[0]["syy_rb_visible"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fkfs"]!=null && ds.Tables[0].Rows[0]["fkfs"].ToString()!="")
				{
					model.fkfs=ds.Tables[0].Rows[0]["fkfs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qtfk"]!=null && ds.Tables[0].Rows[0]["qtfk"].ToString()!="")
				{
					model.qtfk=decimal.Parse(ds.Tables[0].Rows[0]["qtfk"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ysk"]!=null && ds.Tables[0].Rows[0]["ysk"].ToString()!="")
				{
					model.ysk=decimal.Parse(ds.Tables[0].Rows[0]["ysk"].ToString());
				}
				if(ds.Tables[0].Rows[0]["t_ysk"]!=null && ds.Tables[0].Rows[0]["t_ysk"].ToString()!="")
				{
					model.t_ysk=decimal.Parse(ds.Tables[0].Rows[0]["t_ysk"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qtsk_t_ysk"]!=null && ds.Tables[0].Rows[0]["qtsk_t_ysk"].ToString()!="")
				{
					model.qtsk_t_ysk=decimal.Parse(ds.Tables[0].Rows[0]["qtsk_t_ysk"].ToString());
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
				if(ds.Tables[0].Rows[0]["t_ysk_qt"]!=null && ds.Tables[0].Rows[0]["t_ysk_qt"].ToString()!="")
				{
					model.t_ysk_qt=decimal.Parse(ds.Tables[0].Rows[0]["t_ysk_qt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ysk_fs"]!=null && ds.Tables[0].Rows[0]["ysk_fs"].ToString()!="")
				{
					model.ysk_fs=decimal.Parse(ds.Tables[0].Rows[0]["ysk_fs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qt_yyk"]!=null && ds.Tables[0].Rows[0]["qt_yyk"].ToString()!="")
				{
					model.qt_yyk=decimal.Parse(ds.Tables[0].Rows[0]["qt_yyk"].ToString());
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
			strSql.Append("select id,yydh,qymc,lsbh,syzd,syy,syy_rb_visible,fkfs,qtfk,ysk,t_ysk,qtsk_t_ysk,shsc,t_ysk_qt,ysk_fs,qt_yyk ");
			strSql.Append(" FROM S_jbmx ");
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
			strSql.Append(" id,yydh,qymc,lsbh,syzd,syy,syy_rb_visible,fkfs,qtfk,ysk,t_ysk,qtsk_t_ysk,shsc,t_ysk_qt,ysk_fs,qt_yyk ");
			strSql.Append(" FROM S_jbmx ");
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
			strSql.Append("select count(1) FROM S_jbmx ");
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
			strSql.Append(")AS Row, T.*  from S_jbmx T ");
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
			parameters[0].Value = "S_jbmx";
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

