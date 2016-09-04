using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:DH_jl
	/// </summary>
	public partial class DH_jl
	{
		public DH_jl()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "DH_jl"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DH_jl");
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
		public int Add(Hotel_app.Model.DH_jl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DH_jl(");
			strSql.Append("yydh,qymc,RN,call_no,DN,receive_no,DA,xfrq,TI,xfsj,TA,sjxfje,DU,xfsj_bz,P#,lsbh,czsj,shsc,id_app,krxm,fjbh)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@RN,@call_no,@DN,@receive_no,@DA,@xfrq,@TI,@xfsj,@TA,@sjxfje,@DU,@xfsj_bz,@P#,@lsbh,@czsj,@shsc,@id_app,@krxm,@fjbh)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@RN", SqlDbType.VarChar,50),
					new SqlParameter("@call_no", SqlDbType.VarChar,50),
					new SqlParameter("@DN", SqlDbType.VarChar,50),
					new SqlParameter("@receive_no", SqlDbType.VarChar,50),
					new SqlParameter("@DA", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@TI", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@TA", SqlDbType.VarChar,50),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@DU", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj_bz", SqlDbType.VarChar,50),
					new SqlParameter("@P#", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.RN;
			parameters[3].Value = model.call_no;
			parameters[4].Value = model.DN;
			parameters[5].Value = model.receive_no;
			parameters[6].Value = model.DA;
			parameters[7].Value = model.xfrq;
			parameters[8].Value = model.TI;
			parameters[9].Value = model.xfsj;
			parameters[10].Value = model.TA;
			parameters[11].Value = model.sjxfje;
			parameters[12].Value = model.DU;
			parameters[13].Value = model.xfsj_bz;
			parameters[14].Value = model.P;
			parameters[15].Value = model.lsbh;
			parameters[16].Value = model.czsj;
			parameters[17].Value = model.shsc;
			parameters[18].Value = model.id_app;
			parameters[19].Value = model.krxm;
			parameters[20].Value = model.fjbh;

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
		public bool Update(Hotel_app.Model.DH_jl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DH_jl set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("RN=@RN,");
			strSql.Append("call_no=@call_no,");
			strSql.Append("DN=@DN,");
			strSql.Append("receive_no=@receive_no,");
			strSql.Append("DA=@DA,");
			strSql.Append("xfrq=@xfrq,");
			strSql.Append("TI=@TI,");
			strSql.Append("xfsj=@xfsj,");
			strSql.Append("TA=@TA,");
			strSql.Append("sjxfje=@sjxfje,");
			strSql.Append("DU=@DU,");
			strSql.Append("xfsj_bz=@xfsj_bz,");
			strSql.Append("P#=@P#,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("id_app=@id_app,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("fjbh=@fjbh");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@RN", SqlDbType.VarChar,50),
					new SqlParameter("@call_no", SqlDbType.VarChar,50),
					new SqlParameter("@DN", SqlDbType.VarChar,50),
					new SqlParameter("@receive_no", SqlDbType.VarChar,50),
					new SqlParameter("@DA", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@TI", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@TA", SqlDbType.VarChar,50),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@DU", SqlDbType.VarChar,50),
					new SqlParameter("@xfsj_bz", SqlDbType.VarChar,50),
					new SqlParameter("@P#", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.RN;
			parameters[3].Value = model.call_no;
			parameters[4].Value = model.DN;
			parameters[5].Value = model.receive_no;
			parameters[6].Value = model.DA;
			parameters[7].Value = model.xfrq;
			parameters[8].Value = model.TI;
			parameters[9].Value = model.xfsj;
			parameters[10].Value = model.TA;
			parameters[11].Value = model.sjxfje;
			parameters[12].Value = model.DU;
			parameters[13].Value = model.xfsj_bz;
			parameters[14].Value = model.P;
			parameters[15].Value = model.lsbh;
			parameters[16].Value = model.czsj;
			parameters[17].Value = model.shsc;
			parameters[18].Value = model.id_app;
			parameters[19].Value = model.krxm;
			parameters[20].Value = model.fjbh;
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
			strSql.Append("delete from DH_jl ");
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
			strSql.Append("delete from DH_jl ");
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
		public Hotel_app.Model.DH_jl GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,RN,call_no,DN,receive_no,DA,xfrq,TI,xfsj,TA,sjxfje,DU,xfsj_bz,P#,lsbh,czsj,shsc,id_app,krxm,fjbh from DH_jl ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.DH_jl model=new Hotel_app.Model.DH_jl();
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
				if(ds.Tables[0].Rows[0]["RN"]!=null && ds.Tables[0].Rows[0]["RN"].ToString()!="")
				{
					model.RN=ds.Tables[0].Rows[0]["RN"].ToString();
				}
				if(ds.Tables[0].Rows[0]["call_no"]!=null && ds.Tables[0].Rows[0]["call_no"].ToString()!="")
				{
					model.call_no=ds.Tables[0].Rows[0]["call_no"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DN"]!=null && ds.Tables[0].Rows[0]["DN"].ToString()!="")
				{
					model.DN=ds.Tables[0].Rows[0]["DN"].ToString();
				}
				if(ds.Tables[0].Rows[0]["receive_no"]!=null && ds.Tables[0].Rows[0]["receive_no"].ToString()!="")
				{
					model.receive_no=ds.Tables[0].Rows[0]["receive_no"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DA"]!=null && ds.Tables[0].Rows[0]["DA"].ToString()!="")
				{
					model.DA=ds.Tables[0].Rows[0]["DA"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfrq"]!=null && ds.Tables[0].Rows[0]["xfrq"].ToString()!="")
				{
					model.xfrq=DateTime.Parse(ds.Tables[0].Rows[0]["xfrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TI"]!=null && ds.Tables[0].Rows[0]["TI"].ToString()!="")
				{
					model.TI=ds.Tables[0].Rows[0]["TI"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfsj"]!=null && ds.Tables[0].Rows[0]["xfsj"].ToString()!="")
				{
					model.xfsj=DateTime.Parse(ds.Tables[0].Rows[0]["xfsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TA"]!=null && ds.Tables[0].Rows[0]["TA"].ToString()!="")
				{
					model.TA=ds.Tables[0].Rows[0]["TA"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sjxfje"]!=null && ds.Tables[0].Rows[0]["sjxfje"].ToString()!="")
				{
					model.sjxfje=decimal.Parse(ds.Tables[0].Rows[0]["sjxfje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DU"]!=null && ds.Tables[0].Rows[0]["DU"].ToString()!="")
				{
					model.DU=ds.Tables[0].Rows[0]["DU"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xfsj_bz"]!=null && ds.Tables[0].Rows[0]["xfsj_bz"].ToString()!="")
				{
					model.xfsj_bz=ds.Tables[0].Rows[0]["xfsj_bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["P#"]!=null && ds.Tables[0].Rows[0]["P#"].ToString()!="")
				{
					model.P=ds.Tables[0].Rows[0]["P#"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
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
				if(ds.Tables[0].Rows[0]["id_app"]!=null && ds.Tables[0].Rows[0]["id_app"].ToString()!="")
				{
					model.id_app=ds.Tables[0].Rows[0]["id_app"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
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
			strSql.Append("select id,yydh,qymc,RN,call_no,DN,receive_no,DA,xfrq,TI,xfsj,TA,sjxfje,DU,xfsj_bz,P#,lsbh,czsj,shsc,id_app,krxm,fjbh ");
			strSql.Append(" FROM DH_jl ");
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
			strSql.Append(" id,yydh,qymc,RN,call_no,DN,receive_no,DA,xfrq,TI,xfsj,TA,sjxfje,DU,xfsj_bz,P#,lsbh,czsj,shsc,id_app,krxm,fjbh ");
			strSql.Append(" FROM DH_jl ");
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
			strSql.Append("select count(1) FROM DH_jl ");
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
			strSql.Append(")AS Row, T.*  from DH_jl T ");
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
			parameters[0].Value = "DH_jl";
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

