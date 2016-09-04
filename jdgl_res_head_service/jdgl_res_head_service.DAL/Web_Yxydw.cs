using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace jdgl_res_head_service.DAL
{
	/// <summary>
	/// 数据访问类:Web_Yxydw
	/// </summary>
	public partial class Web_Yxydw
	{
		public Web_Yxydw()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Web_Yxydw"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Web_Yxydw");
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
		public int Add(jdgl_res_head_service.Model.Web_Yxydw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Web_Yxydw(");
			strSql.Append("krly,yydh,qymc,xyrx,krgj,pq,xyh,xyh_inner,rx,xydw,zjm,nxr,krdh,krcz,krEmail,krdz,xsy,shsc,bz,lzfs,fkje,xfje,clsj,xzxg,is_top,is_select,shsh,sign_image)");
			strSql.Append(" values (");
			strSql.Append("@krly,@yydh,@qymc,@xyrx,@krgj,@pq,@xyh,@xyh_inner,@rx,@xydw,@zjm,@nxr,@krdh,@krcz,@krEmail,@krdz,@xsy,@shsc,@bz,@lzfs,@fkje,@xfje,@clsj,@xzxg,@is_top,@is_select,@shsh,@sign_image)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@xyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xyh_inner", SqlDbType.VarChar,50),
					new SqlParameter("@rx", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@zjm", SqlDbType.VarChar,50),
					new SqlParameter("@nxr", SqlDbType.VarChar,50),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krcz", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,200),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@bz", SqlDbType.VarChar,300),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@clsj", SqlDbType.DateTime),
					new SqlParameter("@xzxg", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsh", SqlDbType.Bit,1),
					new SqlParameter("@sign_image", SqlDbType.Image)};
			parameters[0].Value = model.krly;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.xyrx;
			parameters[4].Value = model.krgj;
			parameters[5].Value = model.pq;
			parameters[6].Value = model.xyh;
			parameters[7].Value = model.xyh_inner;
			parameters[8].Value = model.rx;
			parameters[9].Value = model.xydw;
			parameters[10].Value = model.zjm;
			parameters[11].Value = model.nxr;
			parameters[12].Value = model.krdh;
			parameters[13].Value = model.krcz;
			parameters[14].Value = model.krEmail;
			parameters[15].Value = model.krdz;
			parameters[16].Value = model.xsy;
			parameters[17].Value = model.shsc;
			parameters[18].Value = model.bz;
			parameters[19].Value = model.lzfs;
			parameters[20].Value = model.fkje;
			parameters[21].Value = model.xfje;
			parameters[22].Value = model.clsj;
			parameters[23].Value = model.xzxg;
			parameters[24].Value = model.is_top;
			parameters[25].Value = model.is_select;
			parameters[26].Value = model.shsh;
			parameters[27].Value = model.sign_image;

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
		public bool Update(jdgl_res_head_service.Model.Web_Yxydw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Web_Yxydw set ");
			strSql.Append("krly=@krly,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("xyrx=@xyrx,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("pq=@pq,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("xyh_inner=@xyh_inner,");
			strSql.Append("rx=@rx,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("zjm=@zjm,");
			strSql.Append("nxr=@nxr,");
			strSql.Append("krdh=@krdh,");
			strSql.Append("krcz=@krcz,");
			strSql.Append("krEmail=@krEmail,");
			strSql.Append("krdz=@krdz,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("bz=@bz,");
			strSql.Append("lzfs=@lzfs,");
			strSql.Append("fkje=@fkje,");
			strSql.Append("xfje=@xfje,");
			strSql.Append("clsj=@clsj,");
			strSql.Append("xzxg=@xzxg,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("shsh=@shsh,");
			strSql.Append("sign_image=@sign_image");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@xyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xyh_inner", SqlDbType.VarChar,50),
					new SqlParameter("@rx", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@zjm", SqlDbType.VarChar,50),
					new SqlParameter("@nxr", SqlDbType.VarChar,50),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krcz", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,200),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@bz", SqlDbType.VarChar,300),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@clsj", SqlDbType.DateTime),
					new SqlParameter("@xzxg", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsh", SqlDbType.Bit,1),
					new SqlParameter("@sign_image", SqlDbType.Image),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.krly;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.xyrx;
			parameters[4].Value = model.krgj;
			parameters[5].Value = model.pq;
			parameters[6].Value = model.xyh;
			parameters[7].Value = model.xyh_inner;
			parameters[8].Value = model.rx;
			parameters[9].Value = model.xydw;
			parameters[10].Value = model.zjm;
			parameters[11].Value = model.nxr;
			parameters[12].Value = model.krdh;
			parameters[13].Value = model.krcz;
			parameters[14].Value = model.krEmail;
			parameters[15].Value = model.krdz;
			parameters[16].Value = model.xsy;
			parameters[17].Value = model.shsc;
			parameters[18].Value = model.bz;
			parameters[19].Value = model.lzfs;
			parameters[20].Value = model.fkje;
			parameters[21].Value = model.xfje;
			parameters[22].Value = model.clsj;
			parameters[23].Value = model.xzxg;
			parameters[24].Value = model.is_top;
			parameters[25].Value = model.is_select;
			parameters[26].Value = model.shsh;
			parameters[27].Value = model.sign_image;
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
			strSql.Append("delete from Web_Yxydw ");
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
			strSql.Append("delete from Web_Yxydw ");
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
		public jdgl_res_head_service.Model.Web_Yxydw GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,krly,yydh,qymc,xyrx,krgj,pq,xyh,xyh_inner,rx,xydw,zjm,nxr,krdh,krcz,krEmail,krdz,xsy,shsc,bz,lzfs,fkje,xfje,clsj,xzxg,is_top,is_select,shsh,sign_image from Web_Yxydw ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			jdgl_res_head_service.Model.Web_Yxydw model=new jdgl_res_head_service.Model.Web_Yxydw();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yydh"]!=null && ds.Tables[0].Rows[0]["yydh"].ToString()!="")
				{
					model.yydh=ds.Tables[0].Rows[0]["yydh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qymc"]!=null && ds.Tables[0].Rows[0]["qymc"].ToString()!="")
				{
					model.qymc=ds.Tables[0].Rows[0]["qymc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyrx"]!=null && ds.Tables[0].Rows[0]["xyrx"].ToString()!="")
				{
					model.xyrx=ds.Tables[0].Rows[0]["xyrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krgj"]!=null && ds.Tables[0].Rows[0]["krgj"].ToString()!="")
				{
					model.krgj=ds.Tables[0].Rows[0]["krgj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pq"]!=null && ds.Tables[0].Rows[0]["pq"].ToString()!="")
				{
					model.pq=ds.Tables[0].Rows[0]["pq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh"]!=null && ds.Tables[0].Rows[0]["xyh"].ToString()!="")
				{
					model.xyh=ds.Tables[0].Rows[0]["xyh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xyh_inner"]!=null && ds.Tables[0].Rows[0]["xyh_inner"].ToString()!="")
				{
					model.xyh_inner=ds.Tables[0].Rows[0]["xyh_inner"].ToString();
				}
				if(ds.Tables[0].Rows[0]["rx"]!=null && ds.Tables[0].Rows[0]["rx"].ToString()!="")
				{
					model.rx=ds.Tables[0].Rows[0]["rx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xydw"]!=null && ds.Tables[0].Rows[0]["xydw"].ToString()!="")
				{
					model.xydw=ds.Tables[0].Rows[0]["xydw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjm"]!=null && ds.Tables[0].Rows[0]["zjm"].ToString()!="")
				{
					model.zjm=ds.Tables[0].Rows[0]["zjm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nxr"]!=null && ds.Tables[0].Rows[0]["nxr"].ToString()!="")
				{
					model.nxr=ds.Tables[0].Rows[0]["nxr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krdh"]!=null && ds.Tables[0].Rows[0]["krdh"].ToString()!="")
				{
					model.krdh=ds.Tables[0].Rows[0]["krdh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krcz"]!=null && ds.Tables[0].Rows[0]["krcz"].ToString()!="")
				{
					model.krcz=ds.Tables[0].Rows[0]["krcz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krEmail"]!=null && ds.Tables[0].Rows[0]["krEmail"].ToString()!="")
				{
					model.krEmail=ds.Tables[0].Rows[0]["krEmail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krdz"]!=null && ds.Tables[0].Rows[0]["krdz"].ToString()!="")
				{
					model.krdz=ds.Tables[0].Rows[0]["krdz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xsy"]!=null && ds.Tables[0].Rows[0]["xsy"].ToString()!="")
				{
					model.xsy=ds.Tables[0].Rows[0]["xsy"].ToString();
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
				if(ds.Tables[0].Rows[0]["bz"]!=null && ds.Tables[0].Rows[0]["bz"].ToString()!="")
				{
					model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lzfs"]!=null && ds.Tables[0].Rows[0]["lzfs"].ToString()!="")
				{
					model.lzfs=decimal.Parse(ds.Tables[0].Rows[0]["lzfs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["fkje"]!=null && ds.Tables[0].Rows[0]["fkje"].ToString()!="")
				{
					model.fkje=decimal.Parse(ds.Tables[0].Rows[0]["fkje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje"]!=null && ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["clsj"]!=null && ds.Tables[0].Rows[0]["clsj"].ToString()!="")
				{
					model.clsj=DateTime.Parse(ds.Tables[0].Rows[0]["clsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xzxg"]!=null && ds.Tables[0].Rows[0]["xzxg"].ToString()!="")
				{
					model.xzxg=ds.Tables[0].Rows[0]["xzxg"].ToString();
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
				if(ds.Tables[0].Rows[0]["shsh"]!=null && ds.Tables[0].Rows[0]["shsh"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shsh"].ToString()=="1")||(ds.Tables[0].Rows[0]["shsh"].ToString().ToLower()=="true"))
					{
						model.shsh=true;
					}
					else
					{
						model.shsh=false;
					}
				}
				if(ds.Tables[0].Rows[0]["sign_image"]!=null && ds.Tables[0].Rows[0]["sign_image"].ToString()!="")
				{
					model.sign_image=(byte[])ds.Tables[0].Rows[0]["sign_image"];
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
			strSql.Append("select id,krly,yydh,qymc,xyrx,krgj,pq,xyh,xyh_inner,rx,xydw,zjm,nxr,krdh,krcz,krEmail,krdz,xsy,shsc,bz,lzfs,fkje,xfje,clsj,xzxg,is_top,is_select,shsh,sign_image ");
			strSql.Append(" FROM Web_Yxydw ");
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
			strSql.Append(" id,krly,yydh,qymc,xyrx,krgj,pq,xyh,xyh_inner,rx,xydw,zjm,nxr,krdh,krcz,krEmail,krdz,xsy,shsc,bz,lzfs,fkje,xfje,clsj,xzxg,is_top,is_select,shsh,sign_image ");
			strSql.Append(" FROM Web_Yxydw ");
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
			strSql.Append("select count(1) FROM Web_Yxydw ");
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
			strSql.Append(")AS Row, T.*  from Web_Yxydw T ");
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
			parameters[0].Value = "Web_Yxydw";
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

