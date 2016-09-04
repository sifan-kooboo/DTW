using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Qskyd_fjrb_lskr
	/// </summary>
	public partial class Qskyd_fjrb_lskr
	{
		public Qskyd_fjrb_lskr()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Qskyd_fjrb_lskr"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Qskyd_fjrb_lskr");
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
		public int Add(Hotel_app.Model.Qskyd_fjrb_lskr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Qskyd_fjrb_lskr(");
			strSql.Append("yydh,qymc,jzbh,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,is_visible,fjbm,jcje)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@jzbh,@lsbh,@krxm,@sktt,@yddj,@fjrb,@fjbh,@ddsj,@lksj,@lzfs,@shqh,@fjjg,@sjfjjg,@yh,@yhbl,@bz,@is_top,@is_select,@shsc,@czy,@czsj,@cznr,@sdcz,@is_visible,@fjbm,@jcje)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@yhbl", SqlDbType.Decimal,9),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@fjbm", SqlDbType.VarChar,50),
					new SqlParameter("@jcje", SqlDbType.Decimal,9)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.jzbh;
			parameters[3].Value = model.lsbh;
			parameters[4].Value = model.krxm;
			parameters[5].Value = model.sktt;
			parameters[6].Value = model.yddj;
			parameters[7].Value = model.fjrb;
			parameters[8].Value = model.fjbh;
			parameters[9].Value = model.ddsj;
			parameters[10].Value = model.lksj;
			parameters[11].Value = model.lzfs;
			parameters[12].Value = model.shqh;
			parameters[13].Value = model.fjjg;
			parameters[14].Value = model.sjfjjg;
			parameters[15].Value = model.yh;
			parameters[16].Value = model.yhbl;
			parameters[17].Value = model.bz;
			parameters[18].Value = model.is_top;
			parameters[19].Value = model.is_select;
			parameters[20].Value = model.shsc;
			parameters[21].Value = model.czy;
			parameters[22].Value = model.czsj;
			parameters[23].Value = model.cznr;
			parameters[24].Value = model.sdcz;
			parameters[25].Value = model.is_visible;
			parameters[26].Value = model.fjbm;
			parameters[27].Value = model.jcje;

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
		public bool Update(Hotel_app.Model.Qskyd_fjrb_lskr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Qskyd_fjrb_lskr set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("jzbh=@jzbh,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("yddj=@yddj,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("lzfs=@lzfs,");
			strSql.Append("shqh=@shqh,");
			strSql.Append("fjjg=@fjjg,");
			strSql.Append("sjfjjg=@sjfjjg,");
			strSql.Append("yh=@yh,");
			strSql.Append("yhbl=@yhbl,");
			strSql.Append("bz=@bz,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("czy=@czy,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("cznr=@cznr,");
			strSql.Append("sdcz=@sdcz,");
			strSql.Append("is_visible=@is_visible,");
			strSql.Append("fjbm=@fjbm,");
			strSql.Append("jcje=@jcje");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@yhbl", SqlDbType.Decimal,9),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@fjbm", SqlDbType.VarChar,50),
					new SqlParameter("@jcje", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.jzbh;
			parameters[3].Value = model.lsbh;
			parameters[4].Value = model.krxm;
			parameters[5].Value = model.sktt;
			parameters[6].Value = model.yddj;
			parameters[7].Value = model.fjrb;
			parameters[8].Value = model.fjbh;
			parameters[9].Value = model.ddsj;
			parameters[10].Value = model.lksj;
			parameters[11].Value = model.lzfs;
			parameters[12].Value = model.shqh;
			parameters[13].Value = model.fjjg;
			parameters[14].Value = model.sjfjjg;
			parameters[15].Value = model.yh;
			parameters[16].Value = model.yhbl;
			parameters[17].Value = model.bz;
			parameters[18].Value = model.is_top;
			parameters[19].Value = model.is_select;
			parameters[20].Value = model.shsc;
			parameters[21].Value = model.czy;
			parameters[22].Value = model.czsj;
			parameters[23].Value = model.cznr;
			parameters[24].Value = model.sdcz;
			parameters[25].Value = model.is_visible;
			parameters[26].Value = model.fjbm;
			parameters[27].Value = model.jcje;
			parameters[28].Value = model.id;

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
			strSql.Append("delete from Qskyd_fjrb_lskr ");
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
			strSql.Append("delete from Qskyd_fjrb_lskr ");
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
		public Hotel_app.Model.Qskyd_fjrb_lskr GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,jzbh,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,is_visible,fjbm,jcje from Qskyd_fjrb_lskr ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Qskyd_fjrb_lskr model=new Hotel_app.Model.Qskyd_fjrb_lskr();
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
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yddj"]!=null && ds.Tables[0].Rows[0]["yddj"].ToString()!="")
				{
					model.yddj=ds.Tables[0].Rows[0]["yddj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzfs"]!=null && ds.Tables[0].Rows[0]["lzfs"].ToString()!="")
				{
					model.lzfs=decimal.Parse(ds.Tables[0].Rows[0]["lzfs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["shqh"]!=null && ds.Tables[0].Rows[0]["shqh"].ToString()!="")
				{
					model.shqh=ds.Tables[0].Rows[0]["shqh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjjg"]!=null && ds.Tables[0].Rows[0]["fjjg"].ToString()!="")
				{
					model.fjjg=decimal.Parse(ds.Tables[0].Rows[0]["fjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sjfjjg"]!=null && ds.Tables[0].Rows[0]["sjfjjg"].ToString()!="")
				{
					model.sjfjjg=decimal.Parse(ds.Tables[0].Rows[0]["sjfjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yh"]!=null && ds.Tables[0].Rows[0]["yh"].ToString()!="")
				{
					model.yh=ds.Tables[0].Rows[0]["yh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yhbl"]!=null && ds.Tables[0].Rows[0]["yhbl"].ToString()!="")
				{
					model.yhbl=decimal.Parse(ds.Tables[0].Rows[0]["yhbl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["bz"]!=null && ds.Tables[0].Rows[0]["bz"].ToString()!="")
				{
					model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
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
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cznr"]!=null && ds.Tables[0].Rows[0]["cznr"].ToString()!="")
				{
					model.cznr=ds.Tables[0].Rows[0]["cznr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sdcz"]!=null && ds.Tables[0].Rows[0]["sdcz"].ToString()!="")
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
				if(ds.Tables[0].Rows[0]["is_visible"]!=null && ds.Tables[0].Rows[0]["is_visible"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_visible"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_visible"].ToString().ToLower()=="true"))
					{
						model.is_visible=true;
					}
					else
					{
						model.is_visible=false;
					}
				}
				if(ds.Tables[0].Rows[0]["fjbm"]!=null && ds.Tables[0].Rows[0]["fjbm"].ToString()!="")
				{
					model.fjbm=ds.Tables[0].Rows[0]["fjbm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jcje"]!=null && ds.Tables[0].Rows[0]["jcje"].ToString()!="")
				{
					model.jcje=decimal.Parse(ds.Tables[0].Rows[0]["jcje"].ToString());
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
			strSql.Append("select id,yydh,qymc,jzbh,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,is_visible,fjbm,jcje ");
			strSql.Append(" FROM Qskyd_fjrb_lskr ");
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
			strSql.Append(" id,yydh,qymc,jzbh,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,is_visible,fjbm,jcje ");
			strSql.Append(" FROM Qskyd_fjrb_lskr ");
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
			strSql.Append("select count(1) FROM Qskyd_fjrb_lskr ");
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
			strSql.Append(")AS Row, T.*  from Qskyd_fjrb_lskr T ");
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
			parameters[0].Value = "Qskyd_fjrb_lskr";
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

