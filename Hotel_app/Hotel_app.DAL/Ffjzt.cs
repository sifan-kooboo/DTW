using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:Ffjzt
	/// </summary>
	public partial class Ffjzt
	{
		public Ffjzt()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Ffjzt"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ffjzt");
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
		public int Add(Hotel_app.Model.Ffjzt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ffjzt(");
			strSql.Append("yydh,qymc,zyzt,zyzt_second,zybz,fjrb_code,fjrb,fjbh,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name,krxm,ddsj,lksj,yd_ddsj,yd_lksj,bz,shlf,shts,shvip,lsbh,sktt,is_select,is_top,use_time,is_secret,czsj,cznr,czy,fjbm)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@zyzt,@zyzt_second,@zybz,@fjrb_code,@fjrb,@fjbh,@fjdh,@dhfj,@jdlh,@jdlh_name,@jdcs,@jdcs_name,@krxm,@ddsj,@lksj,@yd_ddsj,@yd_lksj,@bz,@shlf,@shts,@shvip,@lsbh,@sktt,@is_select,@is_top,@use_time,@is_secret,@czsj,@cznr,@czy,@fjbm)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt_second", SqlDbType.VarChar,50),
					new SqlParameter("@zybz", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb_code", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjdh", SqlDbType.VarChar,50),
					new SqlParameter("@dhfj", SqlDbType.VarChar,50),
					new SqlParameter("@jdlh", SqlDbType.VarChar,50),
					new SqlParameter("@jdlh_name", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs_name", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,120),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@yd_ddsj", SqlDbType.DateTime),
					new SqlParameter("@yd_lksj", SqlDbType.DateTime),
					new SqlParameter("@bz", SqlDbType.VarChar,1000),
					new SqlParameter("@shlf", SqlDbType.Bit,1),
					new SqlParameter("@shts", SqlDbType.Bit,1),
					new SqlParameter("@shvip", SqlDbType.Bit,1),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@use_time", SqlDbType.Decimal,9),
					new SqlParameter("@is_secret", SqlDbType.Bit,1),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,200),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@fjbm", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.zyzt;
			parameters[3].Value = model.zyzt_second;
			parameters[4].Value = model.zybz;
			parameters[5].Value = model.fjrb_code;
			parameters[6].Value = model.fjrb;
			parameters[7].Value = model.fjbh;
			parameters[8].Value = model.fjdh;
			parameters[9].Value = model.dhfj;
			parameters[10].Value = model.jdlh;
			parameters[11].Value = model.jdlh_name;
			parameters[12].Value = model.jdcs;
			parameters[13].Value = model.jdcs_name;
			parameters[14].Value = model.krxm;
			parameters[15].Value = model.ddsj;
			parameters[16].Value = model.lksj;
			parameters[17].Value = model.yd_ddsj;
			parameters[18].Value = model.yd_lksj;
			parameters[19].Value = model.bz;
			parameters[20].Value = model.shlf;
			parameters[21].Value = model.shts;
			parameters[22].Value = model.shvip;
			parameters[23].Value = model.lsbh;
			parameters[24].Value = model.sktt;
			parameters[25].Value = model.is_select;
			parameters[26].Value = model.is_top;
			parameters[27].Value = model.use_time;
			parameters[28].Value = model.is_secret;
			parameters[29].Value = model.czsj;
			parameters[30].Value = model.cznr;
			parameters[31].Value = model.czy;
			parameters[32].Value = model.fjbm;

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
		public bool Update(Hotel_app.Model.Ffjzt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ffjzt set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("zyzt=@zyzt,");
			strSql.Append("zyzt_second=@zyzt_second,");
			strSql.Append("zybz=@zybz,");
			strSql.Append("fjrb_code=@fjrb_code,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("fjdh=@fjdh,");
			strSql.Append("dhfj=@dhfj,");
			strSql.Append("jdlh=@jdlh,");
			strSql.Append("jdlh_name=@jdlh_name,");
			strSql.Append("jdcs=@jdcs,");
			strSql.Append("jdcs_name=@jdcs_name,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("yd_ddsj=@yd_ddsj,");
			strSql.Append("yd_lksj=@yd_lksj,");
			strSql.Append("bz=@bz,");
			strSql.Append("shlf=@shlf,");
			strSql.Append("shts=@shts,");
			strSql.Append("shvip=@shvip,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("use_time=@use_time,");
			strSql.Append("is_secret=@is_secret,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("cznr=@cznr,");
			strSql.Append("czy=@czy,");
			strSql.Append("fjbm=@fjbm");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt_second", SqlDbType.VarChar,50),
					new SqlParameter("@zybz", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb_code", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjdh", SqlDbType.VarChar,50),
					new SqlParameter("@dhfj", SqlDbType.VarChar,50),
					new SqlParameter("@jdlh", SqlDbType.VarChar,50),
					new SqlParameter("@jdlh_name", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs", SqlDbType.VarChar,50),
					new SqlParameter("@jdcs_name", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,120),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@yd_ddsj", SqlDbType.DateTime),
					new SqlParameter("@yd_lksj", SqlDbType.DateTime),
					new SqlParameter("@bz", SqlDbType.VarChar,1000),
					new SqlParameter("@shlf", SqlDbType.Bit,1),
					new SqlParameter("@shts", SqlDbType.Bit,1),
					new SqlParameter("@shvip", SqlDbType.Bit,1),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@use_time", SqlDbType.Decimal,9),
					new SqlParameter("@is_secret", SqlDbType.Bit,1),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,200),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@fjbm", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.zyzt;
			parameters[3].Value = model.zyzt_second;
			parameters[4].Value = model.zybz;
			parameters[5].Value = model.fjrb_code;
			parameters[6].Value = model.fjrb;
			parameters[7].Value = model.fjbh;
			parameters[8].Value = model.fjdh;
			parameters[9].Value = model.dhfj;
			parameters[10].Value = model.jdlh;
			parameters[11].Value = model.jdlh_name;
			parameters[12].Value = model.jdcs;
			parameters[13].Value = model.jdcs_name;
			parameters[14].Value = model.krxm;
			parameters[15].Value = model.ddsj;
			parameters[16].Value = model.lksj;
			parameters[17].Value = model.yd_ddsj;
			parameters[18].Value = model.yd_lksj;
			parameters[19].Value = model.bz;
			parameters[20].Value = model.shlf;
			parameters[21].Value = model.shts;
			parameters[22].Value = model.shvip;
			parameters[23].Value = model.lsbh;
			parameters[24].Value = model.sktt;
			parameters[25].Value = model.is_select;
			parameters[26].Value = model.is_top;
			parameters[27].Value = model.use_time;
			parameters[28].Value = model.is_secret;
			parameters[29].Value = model.czsj;
			parameters[30].Value = model.cznr;
			parameters[31].Value = model.czy;
			parameters[32].Value = model.fjbm;
			parameters[33].Value = model.id;

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
			strSql.Append("delete from Ffjzt ");
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
			strSql.Append("delete from Ffjzt ");
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
		public Hotel_app.Model.Ffjzt GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,zyzt,zyzt_second,zybz,fjrb_code,fjrb,fjbh,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name,krxm,ddsj,lksj,yd_ddsj,yd_lksj,bz,shlf,shts,shvip,lsbh,sktt,is_select,is_top,use_time,is_secret,czsj,cznr,czy,fjbm from Ffjzt ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.Ffjzt model=new Hotel_app.Model.Ffjzt();
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
				if(ds.Tables[0].Rows[0]["zyzt"]!=null && ds.Tables[0].Rows[0]["zyzt"].ToString()!="")
				{
					model.zyzt=ds.Tables[0].Rows[0]["zyzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zyzt_second"]!=null && ds.Tables[0].Rows[0]["zyzt_second"].ToString()!="")
				{
					model.zyzt_second=ds.Tables[0].Rows[0]["zyzt_second"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zybz"]!=null && ds.Tables[0].Rows[0]["zybz"].ToString()!="")
				{
					model.zybz=ds.Tables[0].Rows[0]["zybz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_code"]!=null && ds.Tables[0].Rows[0]["fjrb_code"].ToString()!="")
				{
					model.fjrb_code=ds.Tables[0].Rows[0]["fjrb_code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjdh"]!=null && ds.Tables[0].Rows[0]["fjdh"].ToString()!="")
				{
					model.fjdh=ds.Tables[0].Rows[0]["fjdh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["dhfj"]!=null && ds.Tables[0].Rows[0]["dhfj"].ToString()!="")
				{
					model.dhfj=ds.Tables[0].Rows[0]["dhfj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jdlh"]!=null && ds.Tables[0].Rows[0]["jdlh"].ToString()!="")
				{
					model.jdlh=ds.Tables[0].Rows[0]["jdlh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jdlh_name"]!=null && ds.Tables[0].Rows[0]["jdlh_name"].ToString()!="")
				{
					model.jdlh_name=ds.Tables[0].Rows[0]["jdlh_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jdcs"]!=null && ds.Tables[0].Rows[0]["jdcs"].ToString()!="")
				{
					model.jdcs=ds.Tables[0].Rows[0]["jdcs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jdcs_name"]!=null && ds.Tables[0].Rows[0]["jdcs_name"].ToString()!="")
				{
					model.jdcs_name=ds.Tables[0].Rows[0]["jdcs_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yd_ddsj"]!=null && ds.Tables[0].Rows[0]["yd_ddsj"].ToString()!="")
				{
					model.yd_ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["yd_ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["yd_lksj"]!=null && ds.Tables[0].Rows[0]["yd_lksj"].ToString()!="")
				{
					model.yd_lksj=DateTime.Parse(ds.Tables[0].Rows[0]["yd_lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["bz"]!=null && ds.Tables[0].Rows[0]["bz"].ToString()!="")
				{
					model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["shlf"]!=null && ds.Tables[0].Rows[0]["shlf"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shlf"].ToString()=="1")||(ds.Tables[0].Rows[0]["shlf"].ToString().ToLower()=="true"))
					{
						model.shlf=true;
					}
					else
					{
						model.shlf=false;
					}
				}
				if(ds.Tables[0].Rows[0]["shts"]!=null && ds.Tables[0].Rows[0]["shts"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shts"].ToString()=="1")||(ds.Tables[0].Rows[0]["shts"].ToString().ToLower()=="true"))
					{
						model.shts=true;
					}
					else
					{
						model.shts=false;
					}
				}
				if(ds.Tables[0].Rows[0]["shvip"]!=null && ds.Tables[0].Rows[0]["shvip"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shvip"].ToString()=="1")||(ds.Tables[0].Rows[0]["shvip"].ToString().ToLower()=="true"))
					{
						model.shvip=true;
					}
					else
					{
						model.shvip=false;
					}
				}
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
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
				if(ds.Tables[0].Rows[0]["use_time"]!=null && ds.Tables[0].Rows[0]["use_time"].ToString()!="")
				{
					model.use_time=decimal.Parse(ds.Tables[0].Rows[0]["use_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["is_secret"]!=null && ds.Tables[0].Rows[0]["is_secret"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["is_secret"].ToString()=="1")||(ds.Tables[0].Rows[0]["is_secret"].ToString().ToLower()=="true"))
					{
						model.is_secret=true;
					}
					else
					{
						model.is_secret=false;
					}
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cznr"]!=null && ds.Tables[0].Rows[0]["cznr"].ToString()!="")
				{
					model.cznr=ds.Tables[0].Rows[0]["cznr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbm"]!=null && ds.Tables[0].Rows[0]["fjbm"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["fjbm"].ToString()=="1")||(ds.Tables[0].Rows[0]["fjbm"].ToString().ToLower()=="true"))
					{
						model.fjbm=true;
					}
					else
					{
						model.fjbm=false;
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
			strSql.Append("select id,yydh,qymc,zyzt,zyzt_second,zybz,fjrb_code,fjrb,fjbh,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name,krxm,ddsj,lksj,yd_ddsj,yd_lksj,bz,shlf,shts,shvip,lsbh,sktt,is_select,is_top,use_time,is_secret,czsj,cznr,czy,fjbm ");
			strSql.Append(" FROM Ffjzt ");
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
			strSql.Append(" id,yydh,qymc,zyzt,zyzt_second,zybz,fjrb_code,fjrb,fjbh,fjdh,dhfj,jdlh,jdlh_name,jdcs,jdcs_name,krxm,ddsj,lksj,yd_ddsj,yd_lksj,bz,shlf,shts,shvip,lsbh,sktt,is_select,is_top,use_time,is_secret,czsj,cznr,czy,fjbm ");
			strSql.Append(" FROM Ffjzt ");
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
			strSql.Append("select count(1) FROM Ffjzt ");
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
			strSql.Append(")AS Row, T.*  from Ffjzt T ");
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
			parameters[0].Value = "Ffjzt";
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

