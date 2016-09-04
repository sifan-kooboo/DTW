using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace jdgl_res_head_app.DAL
{
	/// <summary>
	/// 数据访问类:Ssyxfmx_cz
	/// </summary>
	public partial class Ssyxfmx_cz
	{
		public Ssyxfmx_cz()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Ssyxfmx_cz"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ssyxfmx_cz");
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
		public int Add(jdgl_res_head_app.Model.Ssyxfmx_cz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ssyxfmx_cz(");
			strSql.Append("yydh,qymc,id_app,krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq,is_select,is_top,shsc)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@id_app,@krly,@yxzj,@zjhm,@krsj,@xyh,@xydw,@xsy,@hykh,@krgj,@pq,@gj_sf,@gj_cs,@gj_dq,@is_select,@is_top,@shsc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@gj_sf", SqlDbType.VarChar,50),
					new SqlParameter("@gj_cs", SqlDbType.VarChar,50),
					new SqlParameter("@gj_dq", SqlDbType.VarChar,50),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.id_app;
			parameters[3].Value = model.krly;
			parameters[4].Value = model.yxzj;
			parameters[5].Value = model.zjhm;
			parameters[6].Value = model.krsj;
			parameters[7].Value = model.xyh;
			parameters[8].Value = model.xydw;
			parameters[9].Value = model.xsy;
			parameters[10].Value = model.hykh;
			parameters[11].Value = model.krgj;
			parameters[12].Value = model.pq;
			parameters[13].Value = model.gj_sf;
			parameters[14].Value = model.gj_cs;
			parameters[15].Value = model.gj_dq;
			parameters[16].Value = model.is_select;
			parameters[17].Value = model.is_top;
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
		public bool Update(jdgl_res_head_app.Model.Ssyxfmx_cz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ssyxfmx_cz set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("id_app=@id_app,");
			strSql.Append("krly=@krly,");
			strSql.Append("yxzj=@yxzj,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("krsj=@krsj,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("pq=@pq,");
			strSql.Append("gj_sf=@gj_sf,");
			strSql.Append("gj_cs=@gj_cs,");
			strSql.Append("gj_dq=@gj_dq,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("shsc=@shsc");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@gj_sf", SqlDbType.VarChar,50),
					new SqlParameter("@gj_cs", SqlDbType.VarChar,50),
					new SqlParameter("@gj_dq", SqlDbType.VarChar,50),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.id_app;
			parameters[3].Value = model.krly;
			parameters[4].Value = model.yxzj;
			parameters[5].Value = model.zjhm;
			parameters[6].Value = model.krsj;
			parameters[7].Value = model.xyh;
			parameters[8].Value = model.xydw;
			parameters[9].Value = model.xsy;
			parameters[10].Value = model.hykh;
			parameters[11].Value = model.krgj;
			parameters[12].Value = model.pq;
			parameters[13].Value = model.gj_sf;
			parameters[14].Value = model.gj_cs;
			parameters[15].Value = model.gj_dq;
			parameters[16].Value = model.is_select;
			parameters[17].Value = model.is_top;
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
			strSql.Append("delete from Ssyxfmx_cz ");
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
			strSql.Append("delete from Ssyxfmx_cz ");
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
		public jdgl_res_head_app.Model.Ssyxfmx_cz GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,id_app,krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq,is_select,is_top,shsc from Ssyxfmx_cz ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			jdgl_res_head_app.Model.Ssyxfmx_cz model=new jdgl_res_head_app.Model.Ssyxfmx_cz();
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
				if(ds.Tables[0].Rows[0]["id_app"]!=null && ds.Tables[0].Rows[0]["id_app"].ToString()!="")
				{
					model.id_app=ds.Tables[0].Rows[0]["id_app"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yxzj"]!=null && ds.Tables[0].Rows[0]["yxzj"].ToString()!="")
				{
					model.yxzj=ds.Tables[0].Rows[0]["yxzj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsj"]!=null && ds.Tables[0].Rows[0]["krsj"].ToString()!="")
				{
					model.krsj=ds.Tables[0].Rows[0]["krsj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh"]!=null && ds.Tables[0].Rows[0]["xyh"].ToString()!="")
				{
					model.xyh=ds.Tables[0].Rows[0]["xyh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xsy"]!=null && ds.Tables[0].Rows[0]["xsy"].ToString()!="")
				{
					model.xsy=ds.Tables[0].Rows[0]["xsy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krgj"]!=null && ds.Tables[0].Rows[0]["krgj"].ToString()!="")
				{
					model.krgj=ds.Tables[0].Rows[0]["krgj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pq"]!=null && ds.Tables[0].Rows[0]["pq"].ToString()!="")
				{
					model.pq=ds.Tables[0].Rows[0]["pq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gj_sf"]!=null && ds.Tables[0].Rows[0]["gj_sf"].ToString()!="")
				{
					model.gj_sf=ds.Tables[0].Rows[0]["gj_sf"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gj_cs"]!=null && ds.Tables[0].Rows[0]["gj_cs"].ToString()!="")
				{
					model.gj_cs=ds.Tables[0].Rows[0]["gj_cs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gj_dq"]!=null && ds.Tables[0].Rows[0]["gj_dq"].ToString()!="")
				{
					model.gj_dq=ds.Tables[0].Rows[0]["gj_dq"].ToString();
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
			strSql.Append("select id,yydh,qymc,id_app,krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq,is_select,is_top,shsc ");
			strSql.Append(" FROM Ssyxfmx_cz ");
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
			strSql.Append(" id,yydh,qymc,id_app,krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq,is_select,is_top,shsc ");
			strSql.Append(" FROM Ssyxfmx_cz ");
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
			strSql.Append("select count(1) FROM Ssyxfmx_cz ");
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
			strSql.Append(")AS Row, T.*  from Ssyxfmx_cz T ");
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
			parameters[0].Value = "Ssyxfmx_cz";
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

