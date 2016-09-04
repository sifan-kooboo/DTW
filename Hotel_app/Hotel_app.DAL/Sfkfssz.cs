using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Sfkfssz
	/// </summary>
	public partial class Sfkfssz
	{
		public Sfkfssz()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Sfkfssz"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sfkfssz");
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
		public int Add(Hotel_app.Model.Sfkfssz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sfkfssz(");
			strSql.Append("yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,czrq,czsj,xfrq,xfsj,czy,czy_bc,syzd,id_app)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@is_top,@is_select,@jzbh,@jzzt,@lsbh,@fjbh,@krxm,@fkfs,@xfdr,@xfrb,@xfxm,@xfje,@sjxfje,@czrq,@czsj,@xfrq,@xfsj,@czy,@czy_bc,@syzd,@id_app)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fkfs", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@czrq", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czy_bc", SqlDbType.VarChar,50),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.is_top;
			parameters[3].Value = model.is_select;
			parameters[4].Value = model.jzbh;
			parameters[5].Value = model.jzzt;
			parameters[6].Value = model.lsbh;
			parameters[7].Value = model.fjbh;
			parameters[8].Value = model.krxm;
			parameters[9].Value = model.fkfs;
			parameters[10].Value = model.xfdr;
			parameters[11].Value = model.xfrb;
			parameters[12].Value = model.xfxm;
			parameters[13].Value = model.xfje;
			parameters[14].Value = model.sjxfje;
			parameters[15].Value = model.czrq;
			parameters[16].Value = model.czsj;
			parameters[17].Value = model.xfrq;
			parameters[18].Value = model.xfsj;
			parameters[19].Value = model.czy;
			parameters[20].Value = model.czy_bc;
			parameters[21].Value = model.syzd;
			parameters[22].Value = model.id_app;

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
		public bool Update(Hotel_app.Model.Sfkfssz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sfkfssz set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("jzbh=@jzbh,");
			strSql.Append("jzzt=@jzzt,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("fkfs=@fkfs,");
			strSql.Append("xfdr=@xfdr,");
			strSql.Append("xfrb=@xfrb,");
			strSql.Append("xfxm=@xfxm,");
			strSql.Append("xfje=@xfje,");
			strSql.Append("sjxfje=@sjxfje,");
			strSql.Append("czrq=@czrq,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("xfrq=@xfrq,");
			strSql.Append("xfsj=@xfsj,");
			strSql.Append("czy=@czy,");
			strSql.Append("czy_bc=@czy_bc,");
			strSql.Append("syzd=@syzd,");
			strSql.Append("id_app=@id_app");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fkfs", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@czrq", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czy_bc", SqlDbType.VarChar,50),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.is_top;
			parameters[3].Value = model.is_select;
			parameters[4].Value = model.jzbh;
			parameters[5].Value = model.jzzt;
			parameters[6].Value = model.lsbh;
			parameters[7].Value = model.fjbh;
			parameters[8].Value = model.krxm;
			parameters[9].Value = model.fkfs;
			parameters[10].Value = model.xfdr;
			parameters[11].Value = model.xfrb;
			parameters[12].Value = model.xfxm;
			parameters[13].Value = model.xfje;
			parameters[14].Value = model.sjxfje;
			parameters[15].Value = model.czrq;
			parameters[16].Value = model.czsj;
			parameters[17].Value = model.xfrq;
			parameters[18].Value = model.xfsj;
			parameters[19].Value = model.czy;
			parameters[20].Value = model.czy_bc;
			parameters[21].Value = model.syzd;
			parameters[22].Value = model.id_app;
			parameters[23].Value = model.id;

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
			strSql.Append("delete from Sfkfssz ");
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
			strSql.Append("delete from Sfkfssz ");
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
		public Hotel_app.Model.Sfkfssz GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,czrq,czsj,xfrq,xfsj,czy,czy_bc,syzd,id_app from Sfkfssz ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Sfkfssz model=new Hotel_app.Model.Sfkfssz();
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
				if(ds.Tables[0].Rows[0]["jzbh"]!=null && ds.Tables[0].Rows[0]["jzbh"].ToString()!="")
				{
					model.jzbh=ds.Tables[0].Rows[0]["jzbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jzzt"]!=null && ds.Tables[0].Rows[0]["jzzt"].ToString()!="")
				{
					model.jzzt=ds.Tables[0].Rows[0]["jzzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fkfs"]!=null && ds.Tables[0].Rows[0]["fkfs"].ToString()!="")
				{
					model.fkfs=ds.Tables[0].Rows[0]["fkfs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfdr"]!=null && ds.Tables[0].Rows[0]["xfdr"].ToString()!="")
				{
					model.xfdr=ds.Tables[0].Rows[0]["xfdr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfrb"]!=null && ds.Tables[0].Rows[0]["xfrb"].ToString()!="")
				{
					model.xfrb=ds.Tables[0].Rows[0]["xfrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfxm"]!=null && ds.Tables[0].Rows[0]["xfxm"].ToString()!="")
				{
					model.xfxm=ds.Tables[0].Rows[0]["xfxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfje"]!=null && ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sjxfje"]!=null && ds.Tables[0].Rows[0]["sjxfje"].ToString()!="")
				{
					model.sjxfje=decimal.Parse(ds.Tables[0].Rows[0]["sjxfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czrq"]!=null && ds.Tables[0].Rows[0]["czrq"].ToString()!="")
				{
					model.czrq=DateTime.Parse(ds.Tables[0].Rows[0]["czrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfrq"]!=null && ds.Tables[0].Rows[0]["xfrq"].ToString()!="")
				{
					model.xfrq=DateTime.Parse(ds.Tables[0].Rows[0]["xfrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfsj"]!=null && ds.Tables[0].Rows[0]["xfsj"].ToString()!="")
				{
					model.xfsj=DateTime.Parse(ds.Tables[0].Rows[0]["xfsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy_bc"]!=null && ds.Tables[0].Rows[0]["czy_bc"].ToString()!="")
				{
					model.czy_bc=ds.Tables[0].Rows[0]["czy_bc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["syzd"]!=null && ds.Tables[0].Rows[0]["syzd"].ToString()!="")
				{
					model.syzd=ds.Tables[0].Rows[0]["syzd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["id_app"]!=null && ds.Tables[0].Rows[0]["id_app"].ToString()!="")
				{
					model.id_app=ds.Tables[0].Rows[0]["id_app"].ToString();
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
			strSql.Append("select id,yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,czrq,czsj,xfrq,xfsj,czy,czy_bc,syzd,id_app ");
			strSql.Append(" FROM Sfkfssz ");
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
			strSql.Append(" id,yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,czrq,czsj,xfrq,xfsj,czy,czy_bc,syzd,id_app ");
			strSql.Append(" FROM Sfkfssz ");
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
			strSql.Append("select count(1) FROM Sfkfssz ");
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
			strSql.Append(")AS Row, T.*  from Sfkfssz T ");
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
			parameters[0].Value = "Sfkfssz";
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

