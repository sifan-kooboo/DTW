using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Szwzz_mx
	/// </summary>
	public partial class Szwzz_mx
	{
		public Szwzz_mx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Szwzz_mx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Szwzz_mx");
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
		public int Add(Hotel_app.Model.Szwzz_mx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Szwzz_mx(");
			strSql.Append("yydh,qymc,old_lsbh,old_krxm,old_fjbh,id_app,xfxm,xfzy,xfbz,sjxfje,new_lsbh,new_krxm,new_fjbh,czy,czsj,zzrx,is_top,is_select,shsc)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@old_lsbh,@old_krxm,@old_fjbh,@id_app,@xfxm,@xfzy,@xfbz,@sjxfje,@new_lsbh,@new_krxm,@new_fjbh,@czy,@czsj,@zzrx,@is_top,@is_select,@shsc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@old_lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@old_krxm", SqlDbType.VarChar,100),
					new SqlParameter("@old_fjbh", SqlDbType.VarChar,100),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,100),
					new SqlParameter("@xfzy", SqlDbType.VarChar,200),
					new SqlParameter("@xfbz", SqlDbType.VarChar,200),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@new_lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@new_krxm", SqlDbType.VarChar,100),
					new SqlParameter("@new_fjbh", SqlDbType.VarChar,100),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@zzrx", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.old_lsbh;
			parameters[3].Value = model.old_krxm;
			parameters[4].Value = model.old_fjbh;
			parameters[5].Value = model.id_app;
			parameters[6].Value = model.xfxm;
			parameters[7].Value = model.xfzy;
			parameters[8].Value = model.xfbz;
			parameters[9].Value = model.sjxfje;
			parameters[10].Value = model.new_lsbh;
			parameters[11].Value = model.new_krxm;
			parameters[12].Value = model.new_fjbh;
			parameters[13].Value = model.czy;
			parameters[14].Value = model.czsj;
			parameters[15].Value = model.zzrx;
			parameters[16].Value = model.is_top;
			parameters[17].Value = model.is_select;
			parameters[18].Value = model.shsc;

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
		public bool Update(Hotel_app.Model.Szwzz_mx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Szwzz_mx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("old_lsbh=@old_lsbh,");
			strSql.Append("old_krxm=@old_krxm,");
			strSql.Append("old_fjbh=@old_fjbh,");
			strSql.Append("id_app=@id_app,");
			strSql.Append("xfxm=@xfxm,");
			strSql.Append("xfzy=@xfzy,");
			strSql.Append("xfbz=@xfbz,");
			strSql.Append("sjxfje=@sjxfje,");
			strSql.Append("new_lsbh=@new_lsbh,");
			strSql.Append("new_krxm=@new_krxm,");
			strSql.Append("new_fjbh=@new_fjbh,");
			strSql.Append("czy=@czy,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("zzrx=@zzrx,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("shsc=@shsc");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@old_lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@old_krxm", SqlDbType.VarChar,100),
					new SqlParameter("@old_fjbh", SqlDbType.VarChar,100),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,100),
					new SqlParameter("@xfzy", SqlDbType.VarChar,200),
					new SqlParameter("@xfbz", SqlDbType.VarChar,200),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@new_lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@new_krxm", SqlDbType.VarChar,100),
					new SqlParameter("@new_fjbh", SqlDbType.VarChar,100),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@zzrx", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.old_lsbh;
			parameters[3].Value = model.old_krxm;
			parameters[4].Value = model.old_fjbh;
			parameters[5].Value = model.id_app;
			parameters[6].Value = model.xfxm;
			parameters[7].Value = model.xfzy;
			parameters[8].Value = model.xfbz;
			parameters[9].Value = model.sjxfje;
			parameters[10].Value = model.new_lsbh;
			parameters[11].Value = model.new_krxm;
			parameters[12].Value = model.new_fjbh;
			parameters[13].Value = model.czy;
			parameters[14].Value = model.czsj;
			parameters[15].Value = model.zzrx;
			parameters[16].Value = model.is_top;
			parameters[17].Value = model.is_select;
			parameters[18].Value = model.shsc;
			parameters[19].Value = model.id;

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
			strSql.Append("delete from Szwzz_mx ");
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
			strSql.Append("delete from Szwzz_mx ");
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
		public Hotel_app.Model.Szwzz_mx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,old_lsbh,old_krxm,old_fjbh,id_app,xfxm,xfzy,xfbz,sjxfje,new_lsbh,new_krxm,new_fjbh,czy,czsj,zzrx,is_top,is_select,shsc from Szwzz_mx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Szwzz_mx model=new Hotel_app.Model.Szwzz_mx();
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
				if(ds.Tables[0].Rows[0]["old_lsbh"]!=null && ds.Tables[0].Rows[0]["old_lsbh"].ToString()!="")
				{
					model.old_lsbh=ds.Tables[0].Rows[0]["old_lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["old_krxm"]!=null && ds.Tables[0].Rows[0]["old_krxm"].ToString()!="")
				{
					model.old_krxm=ds.Tables[0].Rows[0]["old_krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["old_fjbh"]!=null && ds.Tables[0].Rows[0]["old_fjbh"].ToString()!="")
				{
					model.old_fjbh=ds.Tables[0].Rows[0]["old_fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["id_app"]!=null && ds.Tables[0].Rows[0]["id_app"].ToString()!="")
				{
					model.id_app=ds.Tables[0].Rows[0]["id_app"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfxm"]!=null && ds.Tables[0].Rows[0]["xfxm"].ToString()!="")
				{
					model.xfxm=ds.Tables[0].Rows[0]["xfxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfzy"]!=null && ds.Tables[0].Rows[0]["xfzy"].ToString()!="")
				{
					model.xfzy=ds.Tables[0].Rows[0]["xfzy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfbz"]!=null && ds.Tables[0].Rows[0]["xfbz"].ToString()!="")
				{
					model.xfbz=ds.Tables[0].Rows[0]["xfbz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sjxfje"]!=null && ds.Tables[0].Rows[0]["sjxfje"].ToString()!="")
				{
					model.sjxfje=decimal.Parse(ds.Tables[0].Rows[0]["sjxfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["new_lsbh"]!=null && ds.Tables[0].Rows[0]["new_lsbh"].ToString()!="")
				{
					model.new_lsbh=ds.Tables[0].Rows[0]["new_lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["new_krxm"]!=null && ds.Tables[0].Rows[0]["new_krxm"].ToString()!="")
				{
					model.new_krxm=ds.Tables[0].Rows[0]["new_krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["new_fjbh"]!=null && ds.Tables[0].Rows[0]["new_fjbh"].ToString()!="")
				{
					model.new_fjbh=ds.Tables[0].Rows[0]["new_fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zzrx"]!=null && ds.Tables[0].Rows[0]["zzrx"].ToString()!="")
				{
					model.zzrx=ds.Tables[0].Rows[0]["zzrx"].ToString();
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
			strSql.Append("select id,yydh,qymc,old_lsbh,old_krxm,old_fjbh,id_app,xfxm,xfzy,xfbz,sjxfje,new_lsbh,new_krxm,new_fjbh,czy,czsj,zzrx,is_top,is_select,shsc ");
			strSql.Append(" FROM Szwzz_mx ");
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
			strSql.Append(" id,yydh,qymc,old_lsbh,old_krxm,old_fjbh,id_app,xfxm,xfzy,xfbz,sjxfje,new_lsbh,new_krxm,new_fjbh,czy,czsj,zzrx,is_top,is_select,shsc ");
			strSql.Append(" FROM Szwzz_mx ");
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
			strSql.Append("select count(1) FROM Szwzz_mx ");
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
			strSql.Append(")AS Row, T.*  from Szwzz_mx T ");
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
			parameters[0].Value = "Szwzz_mx";
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

