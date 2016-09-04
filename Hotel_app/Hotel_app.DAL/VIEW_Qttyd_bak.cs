using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_Qttyd_bak
	/// </summary>
	public partial class VIEW_Qttyd_bak
	{
		public VIEW_Qttyd_bak()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.VIEW_Qttyd_bak model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VIEW_Qttyd_bak(");
			strSql.Append("id,yydh,qymc,jzbh,lsbh,ddbh,krxm,krbh,yddj,sktt,krgj,krdz,krly,xyh,xydw,xsy,krdh,krsj,krEmail,ydrxm,ddsj,ddyy,lzts,lksj,qtyq,ddrx,ddwz,zyzt,czy,cznr,czsj,is_select,is_top,ffshys,shsc,sdcz,syzd,tsyq,ddly,fkje,xfje)");
			strSql.Append(" values (");
			strSql.Append("@id,@yydh,@qymc,@jzbh,@lsbh,@ddbh,@krxm,@krbh,@yddj,@sktt,@krgj,@krdz,@krly,@xyh,@xydw,@xsy,@krdh,@krsj,@krEmail,@ydrxm,@ddsj,@ddyy,@lzts,@lksj,@qtyq,@ddrx,@ddwz,@zyzt,@czy,@cznr,@czsj,@is_select,@is_top,@ffshys,@shsc,@sdcz,@syzd,@tsyq,@ddly,@fkje,@xfje)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krbh", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@ydrxm", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@ddyy", SqlDbType.VarChar,200),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@qtyq", SqlDbType.VarChar,800),
					new SqlParameter("@ddrx", SqlDbType.VarChar,50),
					new SqlParameter("@ddwz", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@ffshys", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@tsyq", SqlDbType.VarChar,500),
					new SqlParameter("@ddly", SqlDbType.VarChar,50),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.jzbh;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.ddbh;
			parameters[6].Value = model.krxm;
			parameters[7].Value = model.krbh;
			parameters[8].Value = model.yddj;
			parameters[9].Value = model.sktt;
			parameters[10].Value = model.krgj;
			parameters[11].Value = model.krdz;
			parameters[12].Value = model.krly;
			parameters[13].Value = model.xyh;
			parameters[14].Value = model.xydw;
			parameters[15].Value = model.xsy;
			parameters[16].Value = model.krdh;
			parameters[17].Value = model.krsj;
			parameters[18].Value = model.krEmail;
			parameters[19].Value = model.ydrxm;
			parameters[20].Value = model.ddsj;
			parameters[21].Value = model.ddyy;
			parameters[22].Value = model.lzts;
			parameters[23].Value = model.lksj;
			parameters[24].Value = model.qtyq;
			parameters[25].Value = model.ddrx;
			parameters[26].Value = model.ddwz;
			parameters[27].Value = model.zyzt;
			parameters[28].Value = model.czy;
			parameters[29].Value = model.cznr;
			parameters[30].Value = model.czsj;
			parameters[31].Value = model.is_select;
			parameters[32].Value = model.is_top;
			parameters[33].Value = model.ffshys;
			parameters[34].Value = model.shsc;
			parameters[35].Value = model.sdcz;
			parameters[36].Value = model.syzd;
			parameters[37].Value = model.tsyq;
			parameters[38].Value = model.ddly;
			parameters[39].Value = model.fkje;
			parameters[40].Value = model.xfje;

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
		public bool Update(Hotel_app.Model.VIEW_Qttyd_bak model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VIEW_Qttyd_bak set ");
			strSql.Append("id=@id,");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("jzbh=@jzbh,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("ddbh=@ddbh,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("krbh=@krbh,");
			strSql.Append("yddj=@yddj,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("krdz=@krdz,");
			strSql.Append("krly=@krly,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("krdh=@krdh,");
			strSql.Append("krsj=@krsj,");
			strSql.Append("krEmail=@krEmail,");
			strSql.Append("ydrxm=@ydrxm,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("ddyy=@ddyy,");
			strSql.Append("lzts=@lzts,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("qtyq=@qtyq,");
			strSql.Append("ddrx=@ddrx,");
			strSql.Append("ddwz=@ddwz,");
			strSql.Append("zyzt=@zyzt,");
			strSql.Append("czy=@czy,");
			strSql.Append("cznr=@cznr,");
			strSql.Append("czsj=@czsj,");
			strSql.Append("is_select=@is_select,");
			strSql.Append("is_top=@is_top,");
			strSql.Append("ffshys=@ffshys,");
			strSql.Append("shsc=@shsc,");
			strSql.Append("sdcz=@sdcz,");
			strSql.Append("syzd=@syzd,");
			strSql.Append("tsyq=@tsyq,");
			strSql.Append("ddly=@ddly,");
			strSql.Append("fkje=@fkje,");
			strSql.Append("xfje=@xfje");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krbh", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@ydrxm", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@ddyy", SqlDbType.VarChar,200),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@qtyq", SqlDbType.VarChar,800),
					new SqlParameter("@ddrx", SqlDbType.VarChar,50),
					new SqlParameter("@ddwz", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@ffshys", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@tsyq", SqlDbType.VarChar,500),
					new SqlParameter("@ddly", SqlDbType.VarChar,50),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.yydh;
			parameters[2].Value = model.qymc;
			parameters[3].Value = model.jzbh;
			parameters[4].Value = model.lsbh;
			parameters[5].Value = model.ddbh;
			parameters[6].Value = model.krxm;
			parameters[7].Value = model.krbh;
			parameters[8].Value = model.yddj;
			parameters[9].Value = model.sktt;
			parameters[10].Value = model.krgj;
			parameters[11].Value = model.krdz;
			parameters[12].Value = model.krly;
			parameters[13].Value = model.xyh;
			parameters[14].Value = model.xydw;
			parameters[15].Value = model.xsy;
			parameters[16].Value = model.krdh;
			parameters[17].Value = model.krsj;
			parameters[18].Value = model.krEmail;
			parameters[19].Value = model.ydrxm;
			parameters[20].Value = model.ddsj;
			parameters[21].Value = model.ddyy;
			parameters[22].Value = model.lzts;
			parameters[23].Value = model.lksj;
			parameters[24].Value = model.qtyq;
			parameters[25].Value = model.ddrx;
			parameters[26].Value = model.ddwz;
			parameters[27].Value = model.zyzt;
			parameters[28].Value = model.czy;
			parameters[29].Value = model.cznr;
			parameters[30].Value = model.czsj;
			parameters[31].Value = model.is_select;
			parameters[32].Value = model.is_top;
			parameters[33].Value = model.ffshys;
			parameters[34].Value = model.shsc;
			parameters[35].Value = model.sdcz;
			parameters[36].Value = model.syzd;
			parameters[37].Value = model.tsyq;
			parameters[38].Value = model.ddly;
			parameters[39].Value = model.fkje;
			parameters[40].Value = model.xfje;

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
			strSql.Append("delete from VIEW_Qttyd_bak ");
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
		public Hotel_app.Model.VIEW_Qttyd_bak GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,jzbh,lsbh,ddbh,krxm,krbh,yddj,sktt,krgj,krdz,krly,xyh,xydw,xsy,krdh,krsj,krEmail,ydrxm,ddsj,ddyy,lzts,lksj,qtyq,ddrx,ddwz,zyzt,czy,cznr,czsj,is_select,is_top,ffshys,shsc,sdcz,syzd,tsyq,ddly,fkje,xfje from VIEW_Qttyd_bak ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Hotel_app.Model.VIEW_Qttyd_bak model=new Hotel_app.Model.VIEW_Qttyd_bak();
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
				if(ds.Tables[0].Rows[0]["ddbh"]!=null && ds.Tables[0].Rows[0]["ddbh"].ToString()!="")
				{
					model.ddbh=ds.Tables[0].Rows[0]["ddbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krbh"]!=null && ds.Tables[0].Rows[0]["krbh"].ToString()!="")
				{
					model.krbh=ds.Tables[0].Rows[0]["krbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yddj"]!=null && ds.Tables[0].Rows[0]["yddj"].ToString()!="")
				{
					model.yddj=ds.Tables[0].Rows[0]["yddj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krgj"]!=null && ds.Tables[0].Rows[0]["krgj"].ToString()!="")
				{
					model.krgj=ds.Tables[0].Rows[0]["krgj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krdz"]!=null && ds.Tables[0].Rows[0]["krdz"].ToString()!="")
				{
					model.krdz=ds.Tables[0].Rows[0]["krdz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
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
				if(ds.Tables[0].Rows[0]["ydrxm"]!=null && ds.Tables[0].Rows[0]["ydrxm"].ToString()!="")
				{
					model.ydrxm=ds.Tables[0].Rows[0]["ydrxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ddyy"]!=null && ds.Tables[0].Rows[0]["ddyy"].ToString()!="")
				{
					model.ddyy=ds.Tables[0].Rows[0]["ddyy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lzts"]!=null && ds.Tables[0].Rows[0]["lzts"].ToString()!="")
				{
					model.lzts=int.Parse(ds.Tables[0].Rows[0]["lzts"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qtyq"]!=null && ds.Tables[0].Rows[0]["qtyq"].ToString()!="")
				{
					model.qtyq=ds.Tables[0].Rows[0]["qtyq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddrx"]!=null && ds.Tables[0].Rows[0]["ddrx"].ToString()!="")
				{
					model.ddrx=ds.Tables[0].Rows[0]["ddrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddwz"]!=null && ds.Tables[0].Rows[0]["ddwz"].ToString()!="")
				{
					model.ddwz=ds.Tables[0].Rows[0]["ddwz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zyzt"]!=null && ds.Tables[0].Rows[0]["zyzt"].ToString()!="")
				{
					model.zyzt=ds.Tables[0].Rows[0]["zyzt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cznr"]!=null && ds.Tables[0].Rows[0]["cznr"].ToString()!="")
				{
					model.cznr=ds.Tables[0].Rows[0]["cznr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czsj"]!=null && ds.Tables[0].Rows[0]["czsj"].ToString()!="")
				{
					model.czsj=DateTime.Parse(ds.Tables[0].Rows[0]["czsj"].ToString());
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
				if(ds.Tables[0].Rows[0]["ffshys"]!=null && ds.Tables[0].Rows[0]["ffshys"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ffshys"].ToString()=="1")||(ds.Tables[0].Rows[0]["ffshys"].ToString().ToLower()=="true"))
					{
						model.ffshys=true;
					}
					else
					{
						model.ffshys=false;
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
				if(ds.Tables[0].Rows[0]["tsyq"]!=null && ds.Tables[0].Rows[0]["tsyq"].ToString()!="")
				{
					model.tsyq=ds.Tables[0].Rows[0]["tsyq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddly"]!=null && ds.Tables[0].Rows[0]["ddly"].ToString()!="")
				{
					model.ddly=ds.Tables[0].Rows[0]["ddly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fkje"]!=null && ds.Tables[0].Rows[0]["fkje"].ToString()!="")
				{
					model.fkje=decimal.Parse(ds.Tables[0].Rows[0]["fkje"].ToString());
				}
				if(ds.Tables[0].Rows[0]["xfje"]!=null && ds.Tables[0].Rows[0]["xfje"].ToString()!="")
				{
					model.xfje=decimal.Parse(ds.Tables[0].Rows[0]["xfje"].ToString());
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
			strSql.Append("select id,yydh,qymc,jzbh,lsbh,ddbh,krxm,krbh,yddj,sktt,krgj,krdz,krly,xyh,xydw,xsy,krdh,krsj,krEmail,ydrxm,ddsj,ddyy,lzts,lksj,qtyq,ddrx,ddwz,zyzt,czy,cznr,czsj,is_select,is_top,ffshys,shsc,sdcz,syzd,tsyq,ddly,fkje,xfje ");
			strSql.Append(" FROM VIEW_Qttyd_bak ");
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
			strSql.Append(" id,yydh,qymc,jzbh,lsbh,ddbh,krxm,krbh,yddj,sktt,krgj,krdz,krly,xyh,xydw,xsy,krdh,krsj,krEmail,ydrxm,ddsj,ddyy,lzts,lksj,qtyq,ddrx,ddwz,zyzt,czy,cznr,czsj,is_select,is_top,ffshys,shsc,sdcz,syzd,tsyq,ddly,fkje,xfje ");
			strSql.Append(" FROM VIEW_Qttyd_bak ");
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
			strSql.Append("select count(1) FROM VIEW_Qttyd_bak ");
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
			strSql.Append(")AS Row, T.*  from VIEW_Qttyd_bak T ");
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
			parameters[0].Value = "VIEW_Qttyd_bak";
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

