using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Sjzzd_ls
	/// </summary>
	public partial class Sjzzd_ls
	{
		public Sjzzd_ls()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.Sjzzd_ls model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sjzzd_ls(");
			strSql.Append("id,yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,shsc,shys,ddsj,krxm_lz,fjbh_lz)");
			strSql.Append(" values (");
			strSql.Append("@id,@yydh,@qymc,@jzbh,@lsbh,@is_top,@is_select,@krxm,@sktt,@fjbh,@xydw,@krly,@tfsj,@czsj,@czy,@czzt,@xyh,@jzzt,@sdcz,@syzd,@bz,@fp_print,@is_visible,@fkje,@xfje,@shsc,@shys,@ddsj,@krxm_lz,@fjbh_lz)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@tfsj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czzt", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,500),
					new SqlParameter("@fp_print", SqlDbType.Int,4),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@shys", SqlDbType.Bit,1),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@krxm_lz", SqlDbType.VarChar,500),
					new SqlParameter("@fjbh_lz", SqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.jzbh;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.is_top;
			parameters[6].Value = model.is_select;
			parameters[7].Value = model.krxm;
			parameters[8].Value = model.sktt;
			parameters[9].Value = model.fjbh;
			parameters[10].Value = model.xydw;
			parameters[11].Value = model.krly;
			parameters[12].Value = model.tfsj;
			parameters[13].Value = model.czsj;
			parameters[14].Value = model.czy;
			parameters[15].Value = model.czzt;
			parameters[16].Value = model.xyh;
			parameters[17].Value = model.jzzt;
			parameters[18].Value = model.sdcz;
			parameters[19].Value = model.syzd;
			parameters[20].Value = model.bz;
			parameters[21].Value = model.fp_print;
			parameters[22].Value = model.is_visible;
			parameters[23].Value = model.fkje;
			parameters[24].Value = model.xfje;
			parameters[25].Value = model.shsc;
			parameters[26].Value = model.shys;
			parameters[27].Value = model.ddsj;
			parameters[28].Value = model.krxm_lz;
			parameters[29].Value = model.fjbh_lz;

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
		public bool Update(Hotel_app.Model.Sjzzd_ls model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sjzzd_ls set ");
			strSql.Append("id=@id,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("jzbh=@jzbh,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("krly=@krly,");
			strSql.Append("tfsj=@tfsj,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("czy=@czy,");
			strSql.Append("czzt=@czzt,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("jzzt=@jzzt,");
			strSql.Append("sdcz=@sdcz,");
			strSql.Append("syzd=@syzd,");
			strSql.Append("bz=@bz,");
			strSql.Append("fp_print=@fp_print,");
			strSql.Append("is_visible=@is_visible,");
			strSql.Append("fkje=@fkje,");
			strSql.Append("xfje=@xfje,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("shys=@shys,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("krxm_lz=@krxm_lz,");
			strSql.Append("fjbh_lz=@fjbh_lz");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,200),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@tfsj", SqlDbType.DateTime),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czzt", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@jzzt", SqlDbType.VarChar,200),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,500),
					new SqlParameter("@fp_print", SqlDbType.Int,4),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@shys", SqlDbType.Bit,1),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@krxm_lz", SqlDbType.VarChar,500),
					new SqlParameter("@fjbh_lz", SqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.jzbh;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.is_top;
			parameters[6].Value = model.is_select;
			parameters[7].Value = model.krxm;
			parameters[8].Value = model.sktt;
			parameters[9].Value = model.fjbh;
			parameters[10].Value = model.xydw;
			parameters[11].Value = model.krly;
			parameters[12].Value = model.tfsj;
			parameters[13].Value = model.czsj;
			parameters[14].Value = model.czy;
			parameters[15].Value = model.czzt;
			parameters[16].Value = model.xyh;
			parameters[17].Value = model.jzzt;
			parameters[18].Value = model.sdcz;
			parameters[19].Value = model.syzd;
			parameters[20].Value = model.bz;
			parameters[21].Value = model.fp_print;
			parameters[22].Value = model.is_visible;
			parameters[23].Value = model.fkje;
			parameters[24].Value = model.xfje;
			parameters[25].Value = model.shsc;
			parameters[26].Value = model.shys;
			parameters[27].Value = model.ddsj;
			parameters[28].Value = model.krxm_lz;
			parameters[29].Value = model.fjbh_lz;

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
			strSql.Append("delete from Sjzzd_ls ");
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
		public Hotel_app.Model.Sjzzd_ls GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,shsc,shys,ddsj,krxm_lz,fjbh_lz from Sjzzd_ls ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.Sjzzd_ls model=new Hotel_app.Model.Sjzzd_ls();
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
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tfsj"]!=null && ds.Tables[0].Rows[0]["tfsj"].ToString()!="")
				{
					model.tfsj=DateTime.Parse(ds.Tables[0].Rows[0]["tfsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czzt"]!=null && ds.Tables[0].Rows[0]["czzt"].ToString()!="")
				{
					model.czzt=ds.Tables[0].Rows[0]["czzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh"]!=null && ds.Tables[0].Rows[0]["xyh"].ToString()!="")
				{
					model.xyh=ds.Tables[0].Rows[0]["xyh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jzzt"]!=null && ds.Tables[0].Rows[0]["jzzt"].ToString()!="")
				{
					model.jzzt=ds.Tables[0].Rows[0]["jzzt"].ToString();
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
				if(ds.Tables[0].Rows[0]["syzd"]!=null && ds.Tables[0].Rows[0]["syzd"].ToString()!="")
				{
					model.syzd=ds.Tables[0].Rows[0]["syzd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bz"]!=null && ds.Tables[0].Rows[0]["bz"].ToString()!="")
				{
					model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fp_print"]!=null && ds.Tables[0].Rows[0]["fp_print"].ToString()!="")
				{
					model.fp_print=int.Parse(ds.Tables[0].Rows[0]["fp_print"].ToString());
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
				if(ds.Tables[0].Rows[0]["fkje"]!=null && ds.Tables[0].Rows[0]["fkje"].ToString()!="")
				{
					model.fkje=decimal.Parse(ds.Tables[0].Rows[0]["fkje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje"]!=null && ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
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
				if(ds.Tables[0].Rows[0]["shys"]!=null && ds.Tables[0].Rows[0]["shys"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shys"].ToString()=="1")||(ds.Tables[0].Rows[0]["shys"].ToString().ToLower()=="true"))
					{
						model.shys=true;
					}
					else
					{
						model.shys=false;
					}
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["krxm_lz"]!=null && ds.Tables[0].Rows[0]["krxm_lz"].ToString()!="")
				{
					model.krxm_lz=ds.Tables[0].Rows[0]["krxm_lz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh_lz"]!=null && ds.Tables[0].Rows[0]["fjbh_lz"].ToString()!="")
				{
					model.fjbh_lz=ds.Tables[0].Rows[0]["fjbh_lz"].ToString();
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
			strSql.Append("select id,yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,shsc,shys,ddsj,krxm_lz,fjbh_lz ");
			strSql.Append(" FROM Sjzzd_ls ");
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
			strSql.Append(" id,yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,shsc,shys,ddsj,krxm_lz,fjbh_lz ");
			strSql.Append(" FROM Sjzzd_ls ");
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
			strSql.Append("select count(1) FROM Sjzzd_ls ");
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
			strSql.Append(")AS Row, T.*  from Sjzzd_ls T ");
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
			parameters[0].Value = "Sjzzd_ls";
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

