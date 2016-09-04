using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:S_jbzd
	/// </summary>
	public partial class S_jbzd
	{
		public S_jbzd()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "S_jbzd"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from S_jbzd");
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
		public int Add(Hotel_app.Model.S_jbzd model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_jbzd(");
			strSql.Append("yydh,qymc,lsbh,syzd,czy_jb,czy_sb,j_s_bc,cssj,czsj,czy,bz,ysk,t_ysk,qtfk,qtsk_t_ysk,shsc,jb_jk_rx,t_ysk_qt,ysk_fs,jb_jk,qt_yyk)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@lsbh,@syzd,@czy_jb,@czy_sb,@j_s_bc,@cssj,@czsj,@czy,@bz,@ysk,@t_ysk,@qtfk,@qtsk_t_ysk,@shsc,@jb_jk_rx,@t_ysk_qt,@ysk_fs,@jb_jk,@qt_yyk)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@czy_jb", SqlDbType.VarChar,50),
					new SqlParameter("@czy_sb", SqlDbType.VarChar,50),
					new SqlParameter("@j_s_bc", SqlDbType.VarChar,50),
					new SqlParameter("@cssj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,300),
					new SqlParameter("@ysk", SqlDbType.Decimal,9),
					new SqlParameter("@t_ysk", SqlDbType.Decimal,9),
					new SqlParameter("@qtfk", SqlDbType.Decimal,9),
					new SqlParameter("@qtsk_t_ysk", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@jb_jk_rx", SqlDbType.VarChar,50),
					new SqlParameter("@t_ysk_qt", SqlDbType.Decimal,9),
					new SqlParameter("@ysk_fs", SqlDbType.Decimal,9),
					new SqlParameter("@jb_jk", SqlDbType.VarChar,50),
					new SqlParameter("@qt_yyk", SqlDbType.Decimal,9)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.syzd;
			parameters[4].Value = model.czy_jb;
			parameters[5].Value = model.czy_sb;
			parameters[6].Value = model.j_s_bc;
			parameters[7].Value = model.cssj;
			parameters[8].Value = model.czsj;
			parameters[9].Value = model.czy;
			parameters[10].Value = model.bz;
			parameters[11].Value = model.ysk;
			parameters[12].Value = model.t_ysk;
			parameters[13].Value = model.qtfk;
			parameters[14].Value = model.qtsk_t_ysk;
			parameters[15].Value = model.shsc;
			parameters[16].Value = model.jb_jk_rx;
			parameters[17].Value = model.t_ysk_qt;
			parameters[18].Value = model.ysk_fs;
			parameters[19].Value = model.jb_jk;
			parameters[20].Value = model.qt_yyk;

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
		public bool Update(Hotel_app.Model.S_jbzd model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_jbzd set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("syzd=@syzd,");
			strSql.Append("czy_jb=@czy_jb,");
			strSql.Append("czy_sb=@czy_sb,");
			strSql.Append("j_s_bc=@j_s_bc,");
			strSql.Append("cssj=@cssj,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("czy=@czy,");
			strSql.Append("bz=@bz,");
			strSql.Append("ysk=@ysk,");
			strSql.Append("t_ysk=@t_ysk,");
			strSql.Append("qtfk=@qtfk,");
			strSql.Append("qtsk_t_ysk=@qtsk_t_ysk,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("jb_jk_rx=@jb_jk_rx,");
			strSql.Append("t_ysk_qt=@t_ysk_qt,");
			strSql.Append("ysk_fs=@ysk_fs,");
			strSql.Append("jb_jk=@jb_jk,");
			strSql.Append("qt_yyk=@qt_yyk");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@czy_jb", SqlDbType.VarChar,50),
					new SqlParameter("@czy_sb", SqlDbType.VarChar,50),
					new SqlParameter("@j_s_bc", SqlDbType.VarChar,50),
					new SqlParameter("@cssj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,300),
					new SqlParameter("@ysk", SqlDbType.Decimal,9),
					new SqlParameter("@t_ysk", SqlDbType.Decimal,9),
					new SqlParameter("@qtfk", SqlDbType.Decimal,9),
					new SqlParameter("@qtsk_t_ysk", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@jb_jk_rx", SqlDbType.VarChar,50),
					new SqlParameter("@t_ysk_qt", SqlDbType.Decimal,9),
					new SqlParameter("@ysk_fs", SqlDbType.Decimal,9),
					new SqlParameter("@jb_jk", SqlDbType.VarChar,50),
					new SqlParameter("@qt_yyk", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.syzd;
			parameters[4].Value = model.czy_jb;
			parameters[5].Value = model.czy_sb;
			parameters[6].Value = model.j_s_bc;
			parameters[7].Value = model.cssj;
			parameters[8].Value = model.czsj;
			parameters[9].Value = model.czy;
			parameters[10].Value = model.bz;
			parameters[11].Value = model.ysk;
			parameters[12].Value = model.t_ysk;
			parameters[13].Value = model.qtfk;
			parameters[14].Value = model.qtsk_t_ysk;
			parameters[15].Value = model.shsc;
			parameters[16].Value = model.jb_jk_rx;
			parameters[17].Value = model.t_ysk_qt;
			parameters[18].Value = model.ysk_fs;
			parameters[19].Value = model.jb_jk;
			parameters[20].Value = model.qt_yyk;
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
			strSql.Append("delete from S_jbzd ");
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
			strSql.Append("delete from S_jbzd ");
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
		public Hotel_app.Model.S_jbzd GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,lsbh,syzd,czy_jb,czy_sb,j_s_bc,cssj,czsj,czy,bz,ysk,t_ysk,qtfk,qtsk_t_ysk,shsc,jb_jk_rx,t_ysk_qt,ysk_fs,jb_jk,qt_yyk from S_jbzd ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.S_jbzd model=new Hotel_app.Model.S_jbzd();
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
				if(ds.Tables[0].Rows[0]["czy_jb"]!=null && ds.Tables[0].Rows[0]["czy_jb"].ToString()!="")
				{
					model.czy_jb=ds.Tables[0].Rows[0]["czy_jb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy_sb"]!=null && ds.Tables[0].Rows[0]["czy_sb"].ToString()!="")
				{
					model.czy_sb=ds.Tables[0].Rows[0]["czy_sb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["j_s_bc"]!=null && ds.Tables[0].Rows[0]["j_s_bc"].ToString()!="")
				{
					model.j_s_bc=ds.Tables[0].Rows[0]["j_s_bc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cssj"]!=null && ds.Tables[0].Rows[0]["cssj"].ToString()!="")
				{
					model.cssj=DateTime.Parse(ds.Tables[0].Rows[0]["cssj"].ToString());
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
				if(ds.Tables[0].Rows[0]["ysk"]!=null && ds.Tables[0].Rows[0]["ysk"].ToString()!="")
				{
					model.ysk=decimal.Parse(ds.Tables[0].Rows[0]["ysk"].ToString());
				}
				if(ds.Tables[0].Rows[0]["t_ysk"]!=null && ds.Tables[0].Rows[0]["t_ysk"].ToString()!="")
				{
					model.t_ysk=decimal.Parse(ds.Tables[0].Rows[0]["t_ysk"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qtfk"]!=null && ds.Tables[0].Rows[0]["qtfk"].ToString()!="")
				{
					model.qtfk=decimal.Parse(ds.Tables[0].Rows[0]["qtfk"].ToString());
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
				if(ds.Tables[0].Rows[0]["jb_jk_rx"]!=null && ds.Tables[0].Rows[0]["jb_jk_rx"].ToString()!="")
				{
					model.jb_jk_rx=ds.Tables[0].Rows[0]["jb_jk_rx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["t_ysk_qt"]!=null && ds.Tables[0].Rows[0]["t_ysk_qt"].ToString()!="")
				{
					model.t_ysk_qt=decimal.Parse(ds.Tables[0].Rows[0]["t_ysk_qt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ysk_fs"]!=null && ds.Tables[0].Rows[0]["ysk_fs"].ToString()!="")
				{
					model.ysk_fs=decimal.Parse(ds.Tables[0].Rows[0]["ysk_fs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jb_jk"]!=null && ds.Tables[0].Rows[0]["jb_jk"].ToString()!="")
				{
					model.jb_jk=ds.Tables[0].Rows[0]["jb_jk"].ToString();
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
			strSql.Append("select id,yydh,qymc,lsbh,syzd,czy_jb,czy_sb,j_s_bc,cssj,czsj,czy,bz,ysk,t_ysk,qtfk,qtsk_t_ysk,shsc,jb_jk_rx,t_ysk_qt,ysk_fs,jb_jk,qt_yyk ");
			strSql.Append(" FROM S_jbzd ");
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
			strSql.Append(" id,yydh,qymc,lsbh,syzd,czy_jb,czy_sb,j_s_bc,cssj,czsj,czy,bz,ysk,t_ysk,qtfk,qtsk_t_ysk,shsc,jb_jk_rx,t_ysk_qt,ysk_fs,jb_jk,qt_yyk ");
			strSql.Append(" FROM S_jbzd ");
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
			strSql.Append("select count(1) FROM S_jbzd ");
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
			strSql.Append(")AS Row, T.*  from S_jbzd T ");
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
			parameters[0].Value = "S_jbzd";
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

