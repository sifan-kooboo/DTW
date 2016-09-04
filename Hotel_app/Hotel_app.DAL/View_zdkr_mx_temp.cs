using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:View_zdkr_mx_temp
	/// </summary>
	public partial class View_zdkr_mx_temp
	{
		public View_zdkr_mx_temp()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.View_zdkr_mx_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into View_zdkr_mx_temp(");
			strSql.Append("jdlh_name,jdcs_name,id,qymc,yydh,lsbh,krxm,xydw,krly,xsy,ddsj,lksj,czy,sktt,fjrb,fjbh,lzrs,lzfs,dqff,ddbh,zjhm,bz,czy_temp,main_sec,krxb,sjfjjg,yddj,shqh,Expr1)");
			strSql.Append(" values (");
			strSql.Append("@jdlh_name,@jdcs_name,@id,@qymc,@yydh,@lsbh,@krxm,@xydw,@krly,@xsy,@ddsj,@lksj,@czy,@sktt,@fjrb,@fjbh,@lzrs,@lzfs,@dqff,@ddbh,@zjhm,@bz,@czy_temp,@main_sec,@krxb,@sjfjjg,@yddj,@shqh,@Expr1)");
			SqlParameter[] parameters = {
					new SqlParameter("@jdlh_name", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs_name", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@lzrs", SqlDbType.Float,8),
					new SqlParameter("@lzfs", SqlDbType.Float,8),
					new SqlParameter("@dqff", SqlDbType.Float,8),
					new SqlParameter("@ddbh", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,300),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@Expr1", SqlDbType.VarChar,50)};
			parameters[0].Value = model.jdlh_name;
			parameters[1].Value = model.jdcs_name;
			parameters[2].Value = model.id;
			parameters[3].Value = model.qymc;
			parameters[4].Value = model.yydh;
			parameters[5].Value = model.lsbh;
			parameters[6].Value = model.krxm;
			parameters[7].Value = model.xydw;
			parameters[8].Value = model.krly;
			parameters[9].Value = model.xsy;
			parameters[10].Value = model.ddsj;
			parameters[11].Value = model.lksj;
			parameters[12].Value = model.czy;
			parameters[13].Value = model.sktt;
			parameters[14].Value = model.fjrb;
			parameters[15].Value = model.fjbh;
			parameters[16].Value = model.lzrs;
			parameters[17].Value = model.lzfs;
			parameters[18].Value = model.dqff;
			parameters[19].Value = model.ddbh;
			parameters[20].Value = model.zjhm;
			parameters[21].Value = model.bz;
			parameters[22].Value = model.czy_temp;
			parameters[23].Value = model.main_sec;
			parameters[24].Value = model.krxb;
			parameters[25].Value = model.sjfjjg;
			parameters[26].Value = model.yddj;
			parameters[27].Value = model.shqh;
			parameters[28].Value = model.Expr1;

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
		public bool Update(Hotel_app.Model.View_zdkr_mx_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update View_zdkr_mx_temp set ");
			strSql.Append("jdlh_name=@jdlh_name,");
			strSql.Append("jdcs_name=@jdcs_name,");
			strSql.Append("id=@id,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("krly=@krly,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("czy=@czy,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("lzrs=@lzrs,");
			strSql.Append("lzfs=@lzfs,");
			strSql.Append("dqff=@dqff,");
			strSql.Append("ddbh=@ddbh,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("bz=@bz,");
			strSql.Append("czy_temp=@czy_temp,");
			strSql.Append("main_sec=@main_sec,");
			strSql.Append("krxb=@krxb,");
			strSql.Append("sjfjjg=@sjfjjg,");
			strSql.Append("yddj=@yddj,");
			strSql.Append("shqh=@shqh,");
			strSql.Append("Expr1=@Expr1");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@jdlh_name", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs_name", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@lzrs", SqlDbType.Float,8),
					new SqlParameter("@lzfs", SqlDbType.Float,8),
					new SqlParameter("@dqff", SqlDbType.Float,8),
					new SqlParameter("@ddbh", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,300),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@Expr1", SqlDbType.VarChar,50)};
			parameters[0].Value = model.jdlh_name;
			parameters[1].Value = model.jdcs_name;
			parameters[2].Value = model.id;
			parameters[3].Value = model.qymc;
			parameters[4].Value = model.yydh;
			parameters[5].Value = model.lsbh;
			parameters[6].Value = model.krxm;
			parameters[7].Value = model.xydw;
			parameters[8].Value = model.krly;
			parameters[9].Value = model.xsy;
			parameters[10].Value = model.ddsj;
			parameters[11].Value = model.lksj;
			parameters[12].Value = model.czy;
			parameters[13].Value = model.sktt;
			parameters[14].Value = model.fjrb;
			parameters[15].Value = model.fjbh;
			parameters[16].Value = model.lzrs;
			parameters[17].Value = model.lzfs;
			parameters[18].Value = model.dqff;
			parameters[19].Value = model.ddbh;
			parameters[20].Value = model.zjhm;
			parameters[21].Value = model.bz;
			parameters[22].Value = model.czy_temp;
			parameters[23].Value = model.main_sec;
			parameters[24].Value = model.krxb;
			parameters[25].Value = model.sjfjjg;
			parameters[26].Value = model.yddj;
			parameters[27].Value = model.shqh;
			parameters[28].Value = model.Expr1;

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
			strSql.Append("delete from View_zdkr_mx_temp ");
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
		public Hotel_app.Model.View_zdkr_mx_temp GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 jdlh_name,jdcs_name,id,qymc,yydh,lsbh,krxm,xydw,krly,xsy,ddsj,lksj,czy,sktt,fjrb,fjbh,lzrs,lzfs,dqff,ddbh,zjhm,bz,czy_temp,main_sec,krxb,sjfjjg,yddj,shqh,Expr1 from View_zdkr_mx_temp ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.View_zdkr_mx_temp model=new Hotel_app.Model.View_zdkr_mx_temp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["jdlh_name"]!=null && ds.Tables[0].Rows[0]["jdlh_name"].ToString()!="")
				{
					model.jdlh_name=ds.Tables[0].Rows[0]["jdlh_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jdcs_name"]!=null && ds.Tables[0].Rows[0]["jdcs_name"].ToString()!="")
				{
					model.jdcs_name=ds.Tables[0].Rows[0]["jdcs_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xsy"]!=null && ds.Tables[0].Rows[0]["xsy"].ToString()!="")
				{
					model.xsy=ds.Tables[0].Rows[0]["xsy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lzrs"]!=null && ds.Tables[0].Rows[0]["lzrs"].ToString()!="")
				{
					model.lzrs=decimal.Parse(ds.Tables[0].Rows[0]["lzrs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzfs"]!=null && ds.Tables[0].Rows[0]["lzfs"].ToString()!="")
				{
					model.lzfs=decimal.Parse(ds.Tables[0].Rows[0]["lzfs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dqff"]!=null && ds.Tables[0].Rows[0]["dqff"].ToString()!="")
				{
					model.dqff=decimal.Parse(ds.Tables[0].Rows[0]["dqff"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ddbh"]!=null && ds.Tables[0].Rows[0]["ddbh"].ToString()!="")
				{
					model.ddbh=ds.Tables[0].Rows[0]["ddbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bz"]!=null && ds.Tables[0].Rows[0]["bz"].ToString()!="")
				{
					model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy_temp"]!=null && ds.Tables[0].Rows[0]["czy_temp"].ToString()!="")
				{
					model.czy_temp=ds.Tables[0].Rows[0]["czy_temp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["main_sec"]!=null && ds.Tables[0].Rows[0]["main_sec"].ToString()!="")
				{
					model.main_sec=ds.Tables[0].Rows[0]["main_sec"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxb"]!=null && ds.Tables[0].Rows[0]["krxb"].ToString()!="")
				{
					model.krxb=ds.Tables[0].Rows[0]["krxb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sjfjjg"]!=null && ds.Tables[0].Rows[0]["sjfjjg"].ToString()!="")
				{
					model.sjfjjg=decimal.Parse(ds.Tables[0].Rows[0]["sjfjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yddj"]!=null && ds.Tables[0].Rows[0]["yddj"].ToString()!="")
				{
					model.yddj=ds.Tables[0].Rows[0]["yddj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["shqh"]!=null && ds.Tables[0].Rows[0]["shqh"].ToString()!="")
				{
					model.shqh=ds.Tables[0].Rows[0]["shqh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Expr1"]!=null && ds.Tables[0].Rows[0]["Expr1"].ToString()!="")
				{
					model.Expr1=ds.Tables[0].Rows[0]["Expr1"].ToString();
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
			strSql.Append("select jdlh_name,jdcs_name,id,qymc,yydh,lsbh,krxm,xydw,krly,xsy,ddsj,lksj,czy,sktt,fjrb,fjbh,lzrs,lzfs,dqff,ddbh,zjhm,bz,czy_temp,main_sec,krxb,sjfjjg,yddj,shqh,Expr1 ");
			strSql.Append(" FROM View_zdkr_mx_temp ");
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
			strSql.Append(" jdlh_name,jdcs_name,id,qymc,yydh,lsbh,krxm,xydw,krly,xsy,ddsj,lksj,czy,sktt,fjrb,fjbh,lzrs,lzfs,dqff,ddbh,zjhm,bz,czy_temp,main_sec,krxb,sjfjjg,yddj,shqh,Expr1 ");
			strSql.Append(" FROM View_zdkr_mx_temp ");
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
			strSql.Append("select count(1) FROM View_zdkr_mx_temp ");
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
			strSql.Append(")AS Row, T.*  from View_zdkr_mx_temp T ");
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
			parameters[0].Value = "View_zdkr_mx_temp";
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

