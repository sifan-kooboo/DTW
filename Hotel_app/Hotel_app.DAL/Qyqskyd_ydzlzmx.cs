using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Qyqskyd_ydzlzmx
	/// </summary>
	public partial class Qyqskyd_ydzlzmx
	{
		public Qyqskyd_ydzlzmx()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Hotel_app.Model.Qyqskyd_ydzlzmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Qyqskyd_ydzlzmx(");
			strSql.Append("yydh,qymc,lsbh,fjrb,fjbh,sjjg,ddsj,lksj,ddrq,lkrq,lzrx,lzfs,shsc,scsj)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@lsbh,@fjrb,@fjbh,@sjjg,@ddsj,@lksj,@ddrq,@lkrq,@lzrx,@lzfs,@shsc,@scsj)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sjjg", SqlDbType.Decimal,9),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@ddrq", SqlDbType.DateTime),
					new SqlParameter("@lkrq", SqlDbType.DateTime),
					new SqlParameter("@lzrx", SqlDbType.VarChar,50),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scsj", SqlDbType.DateTime)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.fjrb;
			parameters[4].Value = model.fjbh;
			parameters[5].Value = model.sjjg;
			parameters[6].Value = model.ddsj;
			parameters[7].Value = model.lksj;
			parameters[8].Value = model.ddrq;
			parameters[9].Value = model.lkrq;
			parameters[10].Value = model.lzrx;
			parameters[11].Value = model.lzfs;
			parameters[12].Value = model.shsc;
			parameters[13].Value = model.scsj;

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
		public bool Update(Hotel_app.Model.Qyqskyd_ydzlzmx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Qyqskyd_ydzlzmx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("sjjg=@sjjg,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("ddrq=@ddrq,");
			strSql.Append("lkrq=@lkrq,");
			strSql.Append("lzrx=@lzrx,");
			strSql.Append("lzfs=@lzfs,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("scsj=@scsj");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sjjg", SqlDbType.Decimal,9),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@ddrq", SqlDbType.DateTime),
					new SqlParameter("@lkrq", SqlDbType.DateTime),
					new SqlParameter("@lzrx", SqlDbType.VarChar,50),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scsj", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.fjrb;
			parameters[4].Value = model.fjbh;
			parameters[5].Value = model.sjjg;
			parameters[6].Value = model.ddsj;
			parameters[7].Value = model.lksj;
			parameters[8].Value = model.ddrq;
			parameters[9].Value = model.lkrq;
			parameters[10].Value = model.lzrx;
			parameters[11].Value = model.lzfs;
			parameters[12].Value = model.shsc;
			parameters[13].Value = model.scsj;
			parameters[14].Value = model.id;

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
			strSql.Append("delete from Qyqskyd_ydzlzmx ");
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
			strSql.Append("delete from Qyqskyd_ydzlzmx ");
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
		public Hotel_app.Model.Qyqskyd_ydzlzmx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,lsbh,fjrb,fjbh,sjjg,ddsj,lksj,ddrq,lkrq,lzrx,lzfs,shsc,scsj from Qyqskyd_ydzlzmx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Qyqskyd_ydzlzmx model=new Hotel_app.Model.Qyqskyd_ydzlzmx();
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
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sjjg"]!=null && ds.Tables[0].Rows[0]["sjjg"].ToString()!="")
				{
					model.sjjg=decimal.Parse(ds.Tables[0].Rows[0]["sjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ddrq"]!=null && ds.Tables[0].Rows[0]["ddrq"].ToString()!="")
				{
					model.ddrq=DateTime.Parse(ds.Tables[0].Rows[0]["ddrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lkrq"]!=null && ds.Tables[0].Rows[0]["lkrq"].ToString()!="")
				{
					model.lkrq=DateTime.Parse(ds.Tables[0].Rows[0]["lkrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzrx"]!=null && ds.Tables[0].Rows[0]["lzrx"].ToString()!="")
				{
					model.lzrx=ds.Tables[0].Rows[0]["lzrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lzfs"]!=null && ds.Tables[0].Rows[0]["lzfs"].ToString()!="")
				{
					model.lzfs=decimal.Parse(ds.Tables[0].Rows[0]["lzfs"].ToString());
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
			strSql.Append("select id,yydh,qymc,lsbh,fjrb,fjbh,sjjg,ddsj,lksj,ddrq,lkrq,lzrx,lzfs,shsc,scsj ");
			strSql.Append(" FROM Qyqskyd_ydzlzmx ");
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
			strSql.Append(" id,yydh,qymc,lsbh,fjrb,fjbh,sjjg,ddsj,lksj,ddrq,lkrq,lzrx,lzfs,shsc,scsj ");
			strSql.Append(" FROM Qyqskyd_ydzlzmx ");
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
			strSql.Append("select count(1) FROM Qyqskyd_ydzlzmx ");
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
			strSql.Append(")AS Row, T.*  from Qyqskyd_ydzlzmx T ");
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
			parameters[0].Value = "Qyqskyd_ydzlzmx";
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

