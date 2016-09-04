using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:BB_ysk_cy
	/// </summary>
	public partial class BB_ysk_cy
	{
		public BB_ysk_cy()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "BB_ysk_cy"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BB_ysk_cy");
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
		public int Add(Hotel_app.Model.BB_ysk_cy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BB_ysk_cy(");
			strSql.Append("yydh,qymc,czy,krxm,lsbh,fjbh,sjfjjg,shqh,xydw,krly,sktt,shtt,ddsj,lksj,lz,lzbh,fjdh,dhfj,fkje,xfje,yj_xfje,ye)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@czy,@krxm,@lsbh,@fjbh,@sjfjjg,@shqh,@xydw,@krly,@sktt,@shtt,@ddsj,@lksj,@lz,@lzbh,@fjdh,@dhfj,@fkje,@xfje,@yj_xfje,@ye)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@shtt", SqlDbType.Bit,1),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@lz", SqlDbType.VarChar,50),
					new SqlParameter("@lzbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjdh", SqlDbType.VarChar,50),
					new SqlParameter("@dhfj", SqlDbType.VarChar,50),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@yj_xfje", SqlDbType.Decimal,9),
					new SqlParameter("@ye", SqlDbType.Decimal,9)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.czy;
			parameters[3].Value = model.krxm;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.fjbh;
			parameters[6].Value = model.sjfjjg;
			parameters[7].Value = model.shqh;
			parameters[8].Value = model.xydw;
			parameters[9].Value = model.krly;
			parameters[10].Value = model.sktt;
			parameters[11].Value = model.shtt;
			parameters[12].Value = model.ddsj;
			parameters[13].Value = model.lksj;
			parameters[14].Value = model.lz;
			parameters[15].Value = model.lzbh;
			parameters[16].Value = model.fjdh;
			parameters[17].Value = model.dhfj;
			parameters[18].Value = model.fkje;
			parameters[19].Value = model.xfje;
			parameters[20].Value = model.yj_xfje;
			parameters[21].Value = model.ye;

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
		public bool Update(Hotel_app.Model.BB_ysk_cy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BB_ysk_cy set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("czy=@czy,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("sjfjjg=@sjfjjg,");
			strSql.Append("shqh=@shqh,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("krly=@krly,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("shtt=@shtt,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("lz=@lz,");
			strSql.Append("lzbh=@lzbh,");
			strSql.Append("fjdh=@fjdh,");
			strSql.Append("dhfj=@dhfj,");
			strSql.Append("fkje=@fkje,");
			strSql.Append("xfje=@xfje,");
			strSql.Append("yj_xfje=@yj_xfje,");
			strSql.Append("ye=@ye");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@shtt", SqlDbType.Bit,1),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@lz", SqlDbType.VarChar,50),
					new SqlParameter("@lzbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjdh", SqlDbType.VarChar,50),
					new SqlParameter("@dhfj", SqlDbType.VarChar,50),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@yj_xfje", SqlDbType.Decimal,9),
					new SqlParameter("@ye", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.czy;
			parameters[3].Value = model.krxm;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.fjbh;
			parameters[6].Value = model.sjfjjg;
			parameters[7].Value = model.shqh;
			parameters[8].Value = model.xydw;
			parameters[9].Value = model.krly;
			parameters[10].Value = model.sktt;
			parameters[11].Value = model.shtt;
			parameters[12].Value = model.ddsj;
			parameters[13].Value = model.lksj;
			parameters[14].Value = model.lz;
			parameters[15].Value = model.lzbh;
			parameters[16].Value = model.fjdh;
			parameters[17].Value = model.dhfj;
			parameters[18].Value = model.fkje;
			parameters[19].Value = model.xfje;
			parameters[20].Value = model.yj_xfje;
			parameters[21].Value = model.ye;
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
			strSql.Append("delete from BB_ysk_cy ");
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
			strSql.Append("delete from BB_ysk_cy ");
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
		public Hotel_app.Model.BB_ysk_cy GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,czy,krxm,lsbh,fjbh,sjfjjg,shqh,xydw,krly,sktt,shtt,ddsj,lksj,lz,lzbh,fjdh,dhfj,fkje,xfje,yj_xfje,ye from BB_ysk_cy ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.BB_ysk_cy model=new Hotel_app.Model.BB_ysk_cy();
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
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sjfjjg"]!=null && ds.Tables[0].Rows[0]["sjfjjg"].ToString()!="")
				{
					model.sjfjjg=decimal.Parse(ds.Tables[0].Rows[0]["sjfjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["shqh"]!=null && ds.Tables[0].Rows[0]["shqh"].ToString()!="")
				{
					model.shqh=ds.Tables[0].Rows[0]["shqh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["shtt"]!=null && ds.Tables[0].Rows[0]["shtt"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shtt"].ToString()=="1")||(ds.Tables[0].Rows[0]["shtt"].ToString().ToLower()=="true"))
					{
						model.shtt=true;
					}
					else
					{
						model.shtt=false;
					}
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lz"]!=null && ds.Tables[0].Rows[0]["lz"].ToString()!="")
				{
					model.lz=ds.Tables[0].Rows[0]["lz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lzbh"]!=null && ds.Tables[0].Rows[0]["lzbh"].ToString()!="")
				{
					model.lzbh=ds.Tables[0].Rows[0]["lzbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjdh"]!=null && ds.Tables[0].Rows[0]["fjdh"].ToString()!="")
				{
					model.fjdh=ds.Tables[0].Rows[0]["fjdh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["dhfj"]!=null && ds.Tables[0].Rows[0]["dhfj"].ToString()!="")
				{
					model.dhfj=ds.Tables[0].Rows[0]["dhfj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fkje"]!=null && ds.Tables[0].Rows[0]["fkje"].ToString()!="")
				{
					model.fkje=decimal.Parse(ds.Tables[0].Rows[0]["fkje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje"]!=null && ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yj_xfje"]!=null && ds.Tables[0].Rows[0]["yj_xfje"].ToString()!="")
				{
					model.yj_xfje=decimal.Parse(ds.Tables[0].Rows[0]["yj_xfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ye"]!=null && ds.Tables[0].Rows[0]["ye"].ToString()!="")
				{
					model.ye=decimal.Parse(ds.Tables[0].Rows[0]["ye"].ToString());
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
			strSql.Append("select id,yydh,qymc,czy,krxm,lsbh,fjbh,sjfjjg,shqh,xydw,krly,sktt,shtt,ddsj,lksj,lz,lzbh,fjdh,dhfj,fkje,xfje,yj_xfje,ye ");
			strSql.Append(" FROM BB_ysk_cy ");
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
			strSql.Append(" id,yydh,qymc,czy,krxm,lsbh,fjbh,sjfjjg,shqh,xydw,krly,sktt,shtt,ddsj,lksj,lz,lzbh,fjdh,dhfj,fkje,xfje,yj_xfje,ye ");
			strSql.Append(" FROM BB_ysk_cy ");
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
			strSql.Append("select count(1) FROM BB_ysk_cy ");
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
			strSql.Append(")AS Row, T.*  from BB_ysk_cy T ");
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
			parameters[0].Value = "BB_ysk_cy";
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

