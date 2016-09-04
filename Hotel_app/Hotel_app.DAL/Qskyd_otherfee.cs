using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类Qskyd_otherfee。
	/// </summary>
	public class Qskyd_otherfee
	{
		public Qskyd_otherfee()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Qskyd_otherfee"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Qskyd_otherfee");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.Qskyd_otherfee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Qskyd_otherfee(");
			strSql.Append("yydh,qymc,is_select,is_top,lsbh,krxm,sktt,fjrb,fjbh,fyrx,xfxm,xfje,shsc,czy,cznr,czsj,sdcz)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@is_select,@is_top,@lsbh,@krxm,@sktt,@fjrb,@fjbh,@fyrx,@xfxm,@xfje,@shsc,@czy,@cznr,@czsj,@sdcz)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@fyrx", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@sdcz", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.is_select;
			parameters[3].Value = model.is_top;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.sktt;
			parameters[7].Value = model.fjrb;
			parameters[8].Value = model.fjbh;
			parameters[9].Value = model.fyrx;
			parameters[10].Value = model.xfxm;
			parameters[11].Value = model.xfje;
			parameters[12].Value = model.shsc;
			parameters[13].Value = model.czy;
			parameters[14].Value = model.cznr;
			parameters[15].Value = model.czsj;
			parameters[16].Value = model.sdcz;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Hotel_app.Model.Qskyd_otherfee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Qskyd_otherfee set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("fyrx=@fyrx,");
			strSql.Append("xfxm=@xfxm,");
			strSql.Append("xfje=@xfje,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("czy=@czy,");
			strSql.Append("cznr=@cznr,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("sdcz=@sdcz");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@fyrx", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@sdcz", SqlDbType.Bit,1)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.is_select;
			parameters[4].Value = model.is_top;
			parameters[5].Value = model.lsbh;
			parameters[6].Value = model.krxm;
			parameters[7].Value = model.sktt;
			parameters[8].Value = model.fjrb;
			parameters[9].Value = model.fjbh;
			parameters[10].Value = model.fyrx;
			parameters[11].Value = model.xfxm;
			parameters[12].Value = model.xfje;
			parameters[13].Value = model.shsc;
			parameters[14].Value = model.czy;
			parameters[15].Value = model.cznr;
			parameters[16].Value = model.czsj;
			parameters[17].Value = model.sdcz;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Qskyd_otherfee ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hotel_app.Model.Qskyd_otherfee GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,is_select,is_top,lsbh,krxm,sktt,fjrb,fjbh,fyrx,xfxm,xfje,shsc,czy,cznr,czsj,sdcz from Qskyd_otherfee ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Hotel_app.Model.Qskyd_otherfee model=new Hotel_app.Model.Qskyd_otherfee();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				if(ds.Tables[0].Rows[0]["is_select"].ToString()!="")
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
				if(ds.Tables[0].Rows[0]["is_top"].ToString()!="")
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
				model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				model.fyrx=ds.Tables[0].Rows[0]["fyrx"].ToString();
				model.xfxm=ds.Tables[0].Rows[0]["xfxm"].ToString();
				if(ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["shsc"].ToString()!="")
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
				model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				model.cznr=ds.Tables[0].Rows[0]["cznr"].ToString();
				if(ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sdcz"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["sdcz"].ToString()=="1")||(ds.Tables[0].Rows[0]["sdcz"].ToString().ToLower()=="true"))
					{
						model.sdcz=true;
					}
					else
					{
						model.sdcz=false;
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
			strSql.Append("select id,yydh,qymc,is_select,is_top,lsbh,krxm,sktt,fjrb,fjbh,fyrx,xfxm,xfje,shsc,czy,cznr,czsj,sdcz ");
			strSql.Append(" FROM Qskyd_otherfee ");
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
			strSql.Append(" id,yydh,qymc,is_select,is_top,lsbh,krxm,sktt,fjrb,fjbh,fyrx,xfxm,xfje,shsc,czy,cznr,czsj,sdcz ");
			strSql.Append(" FROM Qskyd_otherfee ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "Qskyd_otherfee";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

