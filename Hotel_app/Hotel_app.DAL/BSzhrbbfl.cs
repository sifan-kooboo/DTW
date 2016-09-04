using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:BSzhrbbfl
	/// </summary>
	public partial class BSzhrbbfl
	{
		public BSzhrbbfl()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "BSzhrbbfl"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BSzhrbbfl");
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
		public int Add(Hotel_app.Model.BSzhrbbfl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BSzhrbbfl(");
			strSql.Append("yydh,qymc,bbrq,zfs,zyye,zfh,czfs,pjczl,pjfj,jcb,wjds,gztj,jztj,sztj,yjds,ljwj,ljyf,ljgz,ljjz,shsc,pjczl_nu)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@bbrq,@zfs,@zyye,@zfh,@czfs,@pjczl,@pjfj,@jcb,@wjds,@gztj,@jztj,@sztj,@yjds,@ljwj,@ljyf,@ljgz,@ljjz,@shsc,@pjczl_nu)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bbrq", SqlDbType.DateTime),
					new SqlParameter("@zfs", SqlDbType.Float,8),
					new SqlParameter("@zyye", SqlDbType.Float,8),
					new SqlParameter("@zfh", SqlDbType.Float,8),
					new SqlParameter("@czfs", SqlDbType.Float,8),
					new SqlParameter("@pjczl", SqlDbType.VarChar,53),
					new SqlParameter("@pjfj", SqlDbType.Float,8),
					new SqlParameter("@jcb", SqlDbType.Float,8),
					new SqlParameter("@wjds", SqlDbType.Float,8),
					new SqlParameter("@gztj", SqlDbType.Float,8),
					new SqlParameter("@jztj", SqlDbType.Float,8),
					new SqlParameter("@sztj", SqlDbType.Float,8),
					new SqlParameter("@yjds", SqlDbType.Float,8),
					new SqlParameter("@ljwj", SqlDbType.Float,8),
					new SqlParameter("@ljyf", SqlDbType.Float,8),
					new SqlParameter("@ljgz", SqlDbType.Float,8),
					new SqlParameter("@ljjz", SqlDbType.Float,8),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@pjczl_nu", SqlDbType.Float,8)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.bbrq;
			parameters[3].Value = model.zfs;
			parameters[4].Value = model.zyye;
			parameters[5].Value = model.zfh;
			parameters[6].Value = model.czfs;
			parameters[7].Value = model.pjczl;
			parameters[8].Value = model.pjfj;
			parameters[9].Value = model.jcb;
			parameters[10].Value = model.wjds;
			parameters[11].Value = model.gztj;
			parameters[12].Value = model.jztj;
			parameters[13].Value = model.sztj;
			parameters[14].Value = model.yjds;
			parameters[15].Value = model.ljwj;
			parameters[16].Value = model.ljyf;
			parameters[17].Value = model.ljgz;
			parameters[18].Value = model.ljjz;
			parameters[19].Value = model.shsc;
			parameters[20].Value = model.pjczl_nu;

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
		public bool Update(Hotel_app.Model.BSzhrbbfl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BSzhrbbfl set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("bbrq=@bbrq,");
			strSql.Append("zfs=@zfs,");
			strSql.Append("zyye=@zyye,");
			strSql.Append("zfh=@zfh,");
			strSql.Append("czfs=@czfs,");
			strSql.Append("pjczl=@pjczl,");
			strSql.Append("pjfj=@pjfj,");
			strSql.Append("jcb=@jcb,");
			strSql.Append("wjds=@wjds,");
			strSql.Append("gztj=@gztj,");
			strSql.Append("jztj=@jztj,");
			strSql.Append("sztj=@sztj,");
			strSql.Append("yjds=@yjds,");
			strSql.Append("ljwj=@ljwj,");
			strSql.Append("ljyf=@ljyf,");
			strSql.Append("ljgz=@ljgz,");
			strSql.Append("ljjz=@ljjz,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("pjczl_nu=@pjczl_nu");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bbrq", SqlDbType.DateTime),
					new SqlParameter("@zfs", SqlDbType.Float,8),
					new SqlParameter("@zyye", SqlDbType.Float,8),
					new SqlParameter("@zfh", SqlDbType.Float,8),
					new SqlParameter("@czfs", SqlDbType.Float,8),
					new SqlParameter("@pjczl", SqlDbType.VarChar,53),
					new SqlParameter("@pjfj", SqlDbType.Float,8),
					new SqlParameter("@jcb", SqlDbType.Float,8),
					new SqlParameter("@wjds", SqlDbType.Float,8),
					new SqlParameter("@gztj", SqlDbType.Float,8),
					new SqlParameter("@jztj", SqlDbType.Float,8),
					new SqlParameter("@sztj", SqlDbType.Float,8),
					new SqlParameter("@yjds", SqlDbType.Float,8),
					new SqlParameter("@ljwj", SqlDbType.Float,8),
					new SqlParameter("@ljyf", SqlDbType.Float,8),
					new SqlParameter("@ljgz", SqlDbType.Float,8),
					new SqlParameter("@ljjz", SqlDbType.Float,8),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@pjczl_nu", SqlDbType.Float,8),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.bbrq;
			parameters[3].Value = model.zfs;
			parameters[4].Value = model.zyye;
			parameters[5].Value = model.zfh;
			parameters[6].Value = model.czfs;
			parameters[7].Value = model.pjczl;
			parameters[8].Value = model.pjfj;
			parameters[9].Value = model.jcb;
			parameters[10].Value = model.wjds;
			parameters[11].Value = model.gztj;
			parameters[12].Value = model.jztj;
			parameters[13].Value = model.sztj;
			parameters[14].Value = model.yjds;
			parameters[15].Value = model.ljwj;
			parameters[16].Value = model.ljyf;
			parameters[17].Value = model.ljgz;
			parameters[18].Value = model.ljjz;
			parameters[19].Value = model.shsc;
			parameters[20].Value = model.pjczl_nu;
			parameters[21].Value = model.id;

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
			strSql.Append("delete from BSzhrbbfl ");
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
			strSql.Append("delete from BSzhrbbfl ");
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
		public Hotel_app.Model.BSzhrbbfl GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,bbrq,zfs,zyye,zfh,czfs,pjczl,pjfj,jcb,wjds,gztj,jztj,sztj,yjds,ljwj,ljyf,ljgz,ljjz,shsc,pjczl_nu from BSzhrbbfl ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.BSzhrbbfl model=new Hotel_app.Model.BSzhrbbfl();
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
				if(ds.Tables[0].Rows[0]["bbrq"]!=null && ds.Tables[0].Rows[0]["bbrq"].ToString()!="")
				{
					model.bbrq=DateTime.Parse(ds.Tables[0].Rows[0]["bbrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zfs"]!=null && ds.Tables[0].Rows[0]["zfs"].ToString()!="")
				{
					model.zfs=decimal.Parse(ds.Tables[0].Rows[0]["zfs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zyye"]!=null && ds.Tables[0].Rows[0]["zyye"].ToString()!="")
				{
					model.zyye=decimal.Parse(ds.Tables[0].Rows[0]["zyye"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zfh"]!=null && ds.Tables[0].Rows[0]["zfh"].ToString()!="")
				{
					model.zfh=decimal.Parse(ds.Tables[0].Rows[0]["zfh"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czfs"]!=null && ds.Tables[0].Rows[0]["czfs"].ToString()!="")
				{
					model.czfs=decimal.Parse(ds.Tables[0].Rows[0]["czfs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pjczl"]!=null && ds.Tables[0].Rows[0]["pjczl"].ToString()!="")
				{
					model.pjczl=ds.Tables[0].Rows[0]["pjczl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pjfj"]!=null && ds.Tables[0].Rows[0]["pjfj"].ToString()!="")
				{
					model.pjfj=decimal.Parse(ds.Tables[0].Rows[0]["pjfj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jcb"]!=null && ds.Tables[0].Rows[0]["jcb"].ToString()!="")
				{
					model.jcb=decimal.Parse(ds.Tables[0].Rows[0]["jcb"].ToString());
				}
				if(ds.Tables[0].Rows[0]["wjds"]!=null && ds.Tables[0].Rows[0]["wjds"].ToString()!="")
				{
					model.wjds=decimal.Parse(ds.Tables[0].Rows[0]["wjds"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gztj"]!=null && ds.Tables[0].Rows[0]["gztj"].ToString()!="")
				{
					model.gztj=decimal.Parse(ds.Tables[0].Rows[0]["gztj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jztj"]!=null && ds.Tables[0].Rows[0]["jztj"].ToString()!="")
				{
					model.jztj=decimal.Parse(ds.Tables[0].Rows[0]["jztj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sztj"]!=null && ds.Tables[0].Rows[0]["sztj"].ToString()!="")
				{
					model.sztj=decimal.Parse(ds.Tables[0].Rows[0]["sztj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yjds"]!=null && ds.Tables[0].Rows[0]["yjds"].ToString()!="")
				{
					model.yjds=decimal.Parse(ds.Tables[0].Rows[0]["yjds"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ljwj"]!=null && ds.Tables[0].Rows[0]["ljwj"].ToString()!="")
				{
					model.ljwj=decimal.Parse(ds.Tables[0].Rows[0]["ljwj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ljyf"]!=null && ds.Tables[0].Rows[0]["ljyf"].ToString()!="")
				{
					model.ljyf=decimal.Parse(ds.Tables[0].Rows[0]["ljyf"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ljgz"]!=null && ds.Tables[0].Rows[0]["ljgz"].ToString()!="")
				{
					model.ljgz=decimal.Parse(ds.Tables[0].Rows[0]["ljgz"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ljjz"]!=null && ds.Tables[0].Rows[0]["ljjz"].ToString()!="")
				{
					model.ljjz=decimal.Parse(ds.Tables[0].Rows[0]["ljjz"].ToString());
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
				if(ds.Tables[0].Rows[0]["pjczl_nu"]!=null && ds.Tables[0].Rows[0]["pjczl_nu"].ToString()!="")
				{
					model.pjczl_nu=decimal.Parse(ds.Tables[0].Rows[0]["pjczl_nu"].ToString());
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
			strSql.Append("select id,yydh,qymc,bbrq,zfs,zyye,zfh,czfs,pjczl,pjfj,jcb,wjds,gztj,jztj,sztj,yjds,ljwj,ljyf,ljgz,ljjz,shsc,pjczl_nu ");
			strSql.Append(" FROM BSzhrbbfl ");
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
			strSql.Append(" id,yydh,qymc,bbrq,zfs,zyye,zfh,czfs,pjczl,pjfj,jcb,wjds,gztj,jztj,sztj,yjds,ljwj,ljyf,ljgz,ljjz,shsc,pjczl_nu ");
			strSql.Append(" FROM BSzhrbbfl ");
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
			strSql.Append("select count(1) FROM BSzhrbbfl ");
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
			strSql.Append(")AS Row, T.*  from BSzhrbbfl T ");
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
			parameters[0].Value = "BSzhrbbfl";
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

