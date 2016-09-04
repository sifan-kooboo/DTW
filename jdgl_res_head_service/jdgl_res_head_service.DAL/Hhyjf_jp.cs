using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace jdgl_res_head_service.DAL
{
	/// <summary>
	/// 数据访问类:Hhyjf_jp
	/// </summary>
	public partial class Hhyjf_jp
	{
		public Hhyjf_jp()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Hhyjf_jp"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Hhyjf_jp");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(jdgl_res_head_service.Model.Hhyjf_jp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Hhyjf_jp(");
			strSql.Append("yydh,qymc,classname,Title,jpjf,simg,bimg,info,bz,isTuiJian,isshow,shsc,hyjfrx,is_top,is_select)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@classname,@Title,@jpjf,@simg,@bimg,@info,@bz,@isTuiJian,@isshow,@shsc,@hyjfrx,@is_top,@is_select)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@classname", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@jpjf", SqlDbType.Decimal,9),
					new SqlParameter("@simg", SqlDbType.VarChar,50),
					new SqlParameter("@bimg", SqlDbType.VarChar,50),
					new SqlParameter("@info", SqlDbType.VarChar,200),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@isTuiJian", SqlDbType.Bit,1),
					new SqlParameter("@isshow", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@hyjfrx", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.classname;
			parameters[3].Value = model.Title;
			parameters[4].Value = model.jpjf;
			parameters[5].Value = model.simg;
			parameters[6].Value = model.bimg;
			parameters[7].Value = model.info;
			parameters[8].Value = model.bz;
			parameters[9].Value = model.isTuiJian;
			parameters[10].Value = model.isshow;
			parameters[11].Value = model.shsc;
			parameters[12].Value = model.hyjfrx;
			parameters[13].Value = model.is_top;
			parameters[14].Value = model.is_select;

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
		public bool Update(jdgl_res_head_service.Model.Hhyjf_jp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Hhyjf_jp set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("classname=@classname,");
			strSql.Append("Title=@Title,");
			strSql.Append("jpjf=@jpjf,");
			strSql.Append("simg=@simg,");
			strSql.Append("bimg=@bimg,");
			strSql.Append("info=@info,");
			strSql.Append("bz=@bz,");
			strSql.Append("isTuiJian=@isTuiJian,");
			strSql.Append("isshow=@isshow,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("hyjfrx=@hyjfrx,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@classname", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@jpjf", SqlDbType.Decimal,9),
					new SqlParameter("@simg", SqlDbType.VarChar,50),
					new SqlParameter("@bimg", SqlDbType.VarChar,50),
					new SqlParameter("@info", SqlDbType.VarChar,200),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@isTuiJian", SqlDbType.Bit,1),
					new SqlParameter("@isshow", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@hyjfrx", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.classname;
			parameters[3].Value = model.Title;
			parameters[4].Value = model.jpjf;
			parameters[5].Value = model.simg;
			parameters[6].Value = model.bimg;
			parameters[7].Value = model.info;
			parameters[8].Value = model.bz;
			parameters[9].Value = model.isTuiJian;
			parameters[10].Value = model.isshow;
			parameters[11].Value = model.shsc;
			parameters[12].Value = model.hyjfrx;
			parameters[13].Value = model.is_top;
			parameters[14].Value = model.is_select;
			parameters[15].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Hhyjf_jp ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Hhyjf_jp ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public jdgl_res_head_service.Model.Hhyjf_jp GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,yydh,qymc,classname,Title,jpjf,simg,bimg,info,bz,isTuiJian,isshow,shsc,hyjfrx,is_top,is_select from Hhyjf_jp ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			jdgl_res_head_service.Model.Hhyjf_jp model=new jdgl_res_head_service.Model.Hhyjf_jp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["classname"]!=null && ds.Tables[0].Rows[0]["classname"].ToString()!="")
				{
					model.classname=ds.Tables[0].Rows[0]["classname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Title"]!=null && ds.Tables[0].Rows[0]["Title"].ToString()!="")
				{
					model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jpjf"]!=null && ds.Tables[0].Rows[0]["jpjf"].ToString()!="")
				{
					model.jpjf=decimal.Parse(ds.Tables[0].Rows[0]["jpjf"].ToString());
				}
				if(ds.Tables[0].Rows[0]["simg"]!=null && ds.Tables[0].Rows[0]["simg"].ToString()!="")
				{
					model.simg=ds.Tables[0].Rows[0]["simg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bimg"]!=null && ds.Tables[0].Rows[0]["bimg"].ToString()!="")
				{
					model.bimg=ds.Tables[0].Rows[0]["bimg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["info"]!=null && ds.Tables[0].Rows[0]["info"].ToString()!="")
				{
					model.info=ds.Tables[0].Rows[0]["info"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bz"]!=null && ds.Tables[0].Rows[0]["bz"].ToString()!="")
				{
					model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["isTuiJian"]!=null && ds.Tables[0].Rows[0]["isTuiJian"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["isTuiJian"].ToString()=="1")||(ds.Tables[0].Rows[0]["isTuiJian"].ToString().ToLower()=="true"))
					{
						model.isTuiJian=true;
					}
					else
					{
						model.isTuiJian=false;
					}
				}
				if(ds.Tables[0].Rows[0]["isshow"]!=null && ds.Tables[0].Rows[0]["isshow"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["isshow"].ToString()=="1")||(ds.Tables[0].Rows[0]["isshow"].ToString().ToLower()=="true"))
					{
						model.isshow=true;
					}
					else
					{
						model.isshow=false;
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
				if(ds.Tables[0].Rows[0]["hyjfrx"]!=null && ds.Tables[0].Rows[0]["hyjfrx"].ToString()!="")
				{
					model.hyjfrx=ds.Tables[0].Rows[0]["hyjfrx"].ToString();
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
			strSql.Append("select ID,yydh,qymc,classname,Title,jpjf,simg,bimg,info,bz,isTuiJian,isshow,shsc,hyjfrx,is_top,is_select ");
			strSql.Append(" FROM Hhyjf_jp ");
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
			strSql.Append(" ID,yydh,qymc,classname,Title,jpjf,simg,bimg,info,bz,isTuiJian,isshow,shsc,hyjfrx,is_top,is_select ");
			strSql.Append(" FROM Hhyjf_jp ");
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
			strSql.Append("select count(1) FROM Hhyjf_jp ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Hhyjf_jp T ");
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
			parameters[0].Value = "Hhyjf_jp";
			parameters[1].Value = "ID";
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

