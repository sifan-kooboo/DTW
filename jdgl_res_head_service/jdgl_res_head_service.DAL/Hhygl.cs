using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace jdgl_res_head_service.DAL
{
	/// <summary>
	/// 数据访问类:Hhygl
	/// </summary>
	public partial class Hhygl
	{
		public Hhygl()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("id", "web_Hhygl"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from web_Hhygl");
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
		public int Add(jdgl_res_head_service.Model.Hhygl model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into web_Hhygl(");
			strSql.Append("yydh,qymc,hyrx,hykh,hykh_bz,krxm,krgj,krmz,yxzj,zjhm,krsr,krxb,krdh,krsj,krEmail,krdz,krzy,krdw,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,bz,djsj,hyjf,shsc,scsj,xgsj,shxg,shqr,is_top,is_select,fkje,parent_hykh)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@hyrx,@hykh,@hykh_bz,@krxm,@krgj,@krmz,@yxzj,@zjhm,@krsr,@krxb,@krdh,@krsj,@krEmail,@krdz,@krzy,@krdw,@qzrx,@qzhm,@zjyxq,@tlyxq,@tjrq,@lzka,@bz,@djsj,@hyjf,@shsc,@scsj,@xgsj,@shxg,@shqr,@is_top,@is_select,@fkje,@parent_hykh)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,200),
					new SqlParameter("@krzy", SqlDbType.VarChar,50),
					new SqlParameter("@krdw", SqlDbType.VarChar,50),
					new SqlParameter("@qzrx", SqlDbType.VarChar,50),
					new SqlParameter("@qzhm", SqlDbType.VarChar,50),
					new SqlParameter("@zjyxq", SqlDbType.DateTime),
					new SqlParameter("@tlyxq", SqlDbType.DateTime),
					new SqlParameter("@tjrq", SqlDbType.DateTime),
					new SqlParameter("@lzka", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@djsj", SqlDbType.DateTime),
					new SqlParameter("@hyjf", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scsj", SqlDbType.DateTime),
					new SqlParameter("@xgsj", SqlDbType.DateTime),
					new SqlParameter("@shxg", SqlDbType.Bit,1),
					new SqlParameter("@shqr", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@parent_hykh", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.hyrx;
			parameters[3].Value = model.hykh;
			parameters[4].Value = model.hykh_bz;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.krgj;
			parameters[7].Value = model.krmz;
			parameters[8].Value = model.yxzj;
			parameters[9].Value = model.zjhm;
			parameters[10].Value = model.krsr;
			parameters[11].Value = model.krxb;
			parameters[12].Value = model.krdh;
			parameters[13].Value = model.krsj;
			parameters[14].Value = model.krEmail;
			parameters[15].Value = model.krdz;
			parameters[16].Value = model.krzy;
			parameters[17].Value = model.krdw;
			parameters[18].Value = model.qzrx;
			parameters[19].Value = model.qzhm;
			parameters[20].Value = model.zjyxq;
			parameters[21].Value = model.tlyxq;
			parameters[22].Value = model.tjrq;
			parameters[23].Value = model.lzka;
			parameters[24].Value = model.bz;
			parameters[25].Value = model.djsj;
			parameters[26].Value = model.hyjf;
			parameters[27].Value = model.shsc;
			parameters[28].Value = model.scsj;
			parameters[29].Value = model.xgsj;
			parameters[30].Value = model.shxg;
			parameters[31].Value = model.shqr;
			parameters[32].Value = model.is_top;
			parameters[33].Value = model.is_select;
			parameters[34].Value = model.fkje;
			parameters[35].Value = model.parent_hykh;

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
		public bool Update(jdgl_res_head_service.Model.Hhygl model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update web_Hhygl set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("hyrx=@hyrx,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("hykh_bz=@hykh_bz,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("krmz=@krmz,");
			strSql.Append("yxzj=@yxzj,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("krsr=@krsr,");
			strSql.Append("krxb=@krxb,");
			strSql.Append("krdh=@krdh,");
			strSql.Append("krsj=@krsj,");
			strSql.Append("krEmail=@krEmail,");
			strSql.Append("krdz=@krdz,");
			strSql.Append("krzy=@krzy,");
			strSql.Append("krdw=@krdw,");
			strSql.Append("qzrx=@qzrx,");
			strSql.Append("qzhm=@qzhm,");
			strSql.Append("zjyxq=@zjyxq,");
			strSql.Append("tlyxq=@tlyxq,");
			strSql.Append("tjrq=@tjrq,");
			strSql.Append("lzka=@lzka,");
			strSql.Append("bz=@bz,");
			strSql.Append("djsj=@djsj,");
			strSql.Append("hyjf=@hyjf,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("scsj=@scsj,");
			strSql.Append("xgsj=@xgsj,");
			strSql.Append("shxg=@shxg,");
			strSql.Append("shqr=@shqr,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("fkje=@fkje,");
			strSql.Append("parent_hykh=@parent_hykh");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,200),
					new SqlParameter("@krzy", SqlDbType.VarChar,50),
					new SqlParameter("@krdw", SqlDbType.VarChar,50),
					new SqlParameter("@qzrx", SqlDbType.VarChar,50),
					new SqlParameter("@qzhm", SqlDbType.VarChar,50),
					new SqlParameter("@zjyxq", SqlDbType.DateTime),
					new SqlParameter("@tlyxq", SqlDbType.DateTime),
					new SqlParameter("@tjrq", SqlDbType.DateTime),
					new SqlParameter("@lzka", SqlDbType.VarChar,50),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@djsj", SqlDbType.DateTime),
					new SqlParameter("@hyjf", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scsj", SqlDbType.DateTime),
					new SqlParameter("@xgsj", SqlDbType.DateTime),
					new SqlParameter("@shxg", SqlDbType.Bit,1),
					new SqlParameter("@shqr", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@parent_hykh", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.hyrx;
			parameters[3].Value = model.hykh;
			parameters[4].Value = model.hykh_bz;
			parameters[5].Value = model.krxm;
			parameters[6].Value = model.krgj;
			parameters[7].Value = model.krmz;
			parameters[8].Value = model.yxzj;
			parameters[9].Value = model.zjhm;
			parameters[10].Value = model.krsr;
			parameters[11].Value = model.krxb;
			parameters[12].Value = model.krdh;
			parameters[13].Value = model.krsj;
			parameters[14].Value = model.krEmail;
			parameters[15].Value = model.krdz;
			parameters[16].Value = model.krzy;
			parameters[17].Value = model.krdw;
			parameters[18].Value = model.qzrx;
			parameters[19].Value = model.qzhm;
			parameters[20].Value = model.zjyxq;
			parameters[21].Value = model.tlyxq;
			parameters[22].Value = model.tjrq;
			parameters[23].Value = model.lzka;
			parameters[24].Value = model.bz;
			parameters[25].Value = model.djsj;
			parameters[26].Value = model.hyjf;
			parameters[27].Value = model.shsc;
			parameters[28].Value = model.scsj;
			parameters[29].Value = model.xgsj;
			parameters[30].Value = model.shxg;
			parameters[31].Value = model.shqr;
			parameters[32].Value = model.is_top;
			parameters[33].Value = model.is_select;
			parameters[34].Value = model.fkje;
			parameters[35].Value = model.parent_hykh;
			parameters[36].Value = model.id;

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
            strSql.Append("delete from web_Hhygl ");
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
            strSql.Append("delete from web_Hhygl ");
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
		public jdgl_res_head_service.Model.Hhygl GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,yydh,qymc,hyrx,hykh,hykh_bz,krxm,krgj,krmz,yxzj,zjhm,krsr,krxb,krdh,krsj,krEmail,krdz,krzy,krdw,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,bz,djsj,hyjf,shsc,scsj,xgsj,shxg,shqr,is_top,is_select,fkje,parent_hykh from web_Hhygl ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			jdgl_res_head_service.Model.Hhygl model=new jdgl_res_head_service.Model.Hhygl();
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
				if(ds.Tables[0].Rows[0]["hyrx"]!=null && ds.Tables[0].Rows[0]["hyrx"].ToString()!="")
				{
					model.hyrx=ds.Tables[0].Rows[0]["hyrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh_bz"]!=null && ds.Tables[0].Rows[0]["hykh_bz"].ToString()!="")
				{
					model.hykh_bz=ds.Tables[0].Rows[0]["hykh_bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krgj"]!=null && ds.Tables[0].Rows[0]["krgj"].ToString()!="")
				{
					model.krgj=ds.Tables[0].Rows[0]["krgj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krmz"]!=null && ds.Tables[0].Rows[0]["krmz"].ToString()!="")
				{
					model.krmz=ds.Tables[0].Rows[0]["krmz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yxzj"]!=null && ds.Tables[0].Rows[0]["yxzj"].ToString()!="")
				{
					model.yxzj=ds.Tables[0].Rows[0]["yxzj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjhm"]!=null && ds.Tables[0].Rows[0]["zjhm"].ToString()!="")
				{
					model.zjhm=ds.Tables[0].Rows[0]["zjhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsr"]!=null && ds.Tables[0].Rows[0]["krsr"].ToString()!="")
				{
					model.krsr=DateTime.Parse(ds.Tables[0].Rows[0]["krsr"].ToString());
				}
				if(ds.Tables[0].Rows[0]["krxb"]!=null && ds.Tables[0].Rows[0]["krxb"].ToString()!="")
				{
					model.krxb=ds.Tables[0].Rows[0]["krxb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krdh"]!=null && ds.Tables[0].Rows[0]["krdh"].ToString()!="")
				{
					model.krdh=ds.Tables[0].Rows[0]["krdh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsj"]!=null && ds.Tables[0].Rows[0]["krsj"].ToString()!="")
				{
					model.krsj=ds.Tables[0].Rows[0]["krsj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krEmail"]!=null && ds.Tables[0].Rows[0]["krEmail"].ToString()!="")
				{
					model.krEmail=ds.Tables[0].Rows[0]["krEmail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krdz"]!=null && ds.Tables[0].Rows[0]["krdz"].ToString()!="")
				{
					model.krdz=ds.Tables[0].Rows[0]["krdz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krzy"]!=null && ds.Tables[0].Rows[0]["krzy"].ToString()!="")
				{
					model.krzy=ds.Tables[0].Rows[0]["krzy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krdw"]!=null && ds.Tables[0].Rows[0]["krdw"].ToString()!="")
				{
					model.krdw=ds.Tables[0].Rows[0]["krdw"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qzrx"]!=null && ds.Tables[0].Rows[0]["qzrx"].ToString()!="")
				{
					model.qzrx=ds.Tables[0].Rows[0]["qzrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qzhm"]!=null && ds.Tables[0].Rows[0]["qzhm"].ToString()!="")
				{
					model.qzhm=ds.Tables[0].Rows[0]["qzhm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zjyxq"]!=null && ds.Tables[0].Rows[0]["zjyxq"].ToString()!="")
				{
					model.zjyxq=DateTime.Parse(ds.Tables[0].Rows[0]["zjyxq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tlyxq"]!=null && ds.Tables[0].Rows[0]["tlyxq"].ToString()!="")
				{
					model.tlyxq=DateTime.Parse(ds.Tables[0].Rows[0]["tlyxq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tjrq"]!=null && ds.Tables[0].Rows[0]["tjrq"].ToString()!="")
				{
					model.tjrq=DateTime.Parse(ds.Tables[0].Rows[0]["tjrq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzka"]!=null && ds.Tables[0].Rows[0]["lzka"].ToString()!="")
				{
					model.lzka=ds.Tables[0].Rows[0]["lzka"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bz"]!=null && ds.Tables[0].Rows[0]["bz"].ToString()!="")
				{
					model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["djsj"]!=null && ds.Tables[0].Rows[0]["djsj"].ToString()!="")
				{
					model.djsj=DateTime.Parse(ds.Tables[0].Rows[0]["djsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["hyjf"]!=null && ds.Tables[0].Rows[0]["hyjf"].ToString()!="")
				{
					model.hyjf=decimal.Parse(ds.Tables[0].Rows[0]["hyjf"].ToString());
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
				if(ds.Tables[0].Rows[0]["xgsj"]!=null && ds.Tables[0].Rows[0]["xgsj"].ToString()!="")
				{
					model.xgsj=DateTime.Parse(ds.Tables[0].Rows[0]["xgsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["shxg"]!=null && ds.Tables[0].Rows[0]["shxg"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shxg"].ToString()=="1")||(ds.Tables[0].Rows[0]["shxg"].ToString().ToLower()=="true"))
					{
						model.shxg=true;
					}
					else
					{
						model.shxg=false;
					}
				}
				if(ds.Tables[0].Rows[0]["shqr"]!=null && ds.Tables[0].Rows[0]["shqr"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["shqr"].ToString()=="1")||(ds.Tables[0].Rows[0]["shqr"].ToString().ToLower()=="true"))
					{
						model.shqr=true;
					}
					else
					{
						model.shqr=false;
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
				if(ds.Tables[0].Rows[0]["fkje"]!=null && ds.Tables[0].Rows[0]["fkje"].ToString()!="")
				{
					model.fkje=decimal.Parse(ds.Tables[0].Rows[0]["fkje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parent_hykh"]!=null && ds.Tables[0].Rows[0]["parent_hykh"].ToString()!="")
				{
					model.parent_hykh=ds.Tables[0].Rows[0]["parent_hykh"].ToString();
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
			strSql.Append("select id,yydh,qymc,hyrx,hykh,hykh_bz,krxm,krgj,krmz,yxzj,zjhm,krsr,krxb,krdh,krsj,krEmail,krdz,krzy,krdw,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,bz,djsj,hyjf,shsc,scsj,xgsj,shxg,shqr,is_top,is_select,fkje,parent_hykh ");
            strSql.Append(" FROM web_Hhygl ");
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
			strSql.Append(" id,yydh,qymc,hyrx,hykh,hykh_bz,krxm,krgj,krmz,yxzj,zjhm,krsr,krxb,krdh,krsj,krEmail,krdz,krzy,krdw,qzrx,qzhm,zjyxq,tlyxq,tjrq,lzka,bz,djsj,hyjf,shsc,scsj,xgsj,shxg,shqr,is_top,is_select,fkje,parent_hykh ");
			strSql.Append(" FROM web_Hhygl ");
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
            strSql.Append("select count(1) FROM web_Hhygl ");
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
            strSql.Append(")AS Row, T.*  from web_Hhygl T ");
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
			parameters[0].Value = "Hhygl";
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

