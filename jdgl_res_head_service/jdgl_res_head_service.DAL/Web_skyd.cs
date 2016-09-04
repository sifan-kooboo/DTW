using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace jdgl_res_head_service.DAL
{
	/// <summary>
	/// 数据访问类:Web_skyd
	/// </summary>
	public partial class Web_skyd
	{
		public Web_skyd()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Web_skyd"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Web_skyd");
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
		public int Add(jdgl_res_head_service.Model.Web_skyd model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Web_skyd(");
			strSql.Append("yydh,qymc,lsbh,ddbh,hykh,hykh_bz,hyrx,krxm,krbh,ydrxm,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,qtyq,krly,xyh,xydw,xsy,ddsj,lksj,czy,ydsj,sktt,yddj,vip_type,fjrb,fjbh,sjjg,jsjg,lzfs,lzts,lzrs,sfqr,ydxg,shxg,shsc)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@lsbh,@ddbh,@hykh,@hykh_bz,@hyrx,@krxm,@krbh,@ydrxm,@krgj,@krmz,@yxzj,@zjhm,@krxb,@krsr,@krdh,@krsj,@krEmail,@krdz,@qtyq,@krly,@xyh,@xydw,@xsy,@ddsj,@lksj,@czy,@ydsj,@sktt,@yddj,@vip_type,@fjrb,@fjbh,@sjjg,@jsjg,@lzfs,@lzts,@lzrs,@sfqr,@ydxg,@shxg,@shsc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddbh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,200),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krbh", SqlDbType.VarChar,100),
					new SqlParameter("@ydrxm", SqlDbType.VarChar,100),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,50),
					new SqlParameter("@qtyq", SqlDbType.VarChar,1000),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@ydsj", SqlDbType.DateTime),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@vip_type", SqlDbType.VarChar,100),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sjjg", SqlDbType.Decimal,9),
					new SqlParameter("@jsjg", SqlDbType.Decimal,9),
					new SqlParameter("@lzfs", SqlDbType.Int,4),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@lzrs", SqlDbType.Int,4),
					new SqlParameter("@sfqr", SqlDbType.Int,4),
					new SqlParameter("@ydxg", SqlDbType.VarChar,50),
					new SqlParameter("@shxg", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.ddbh;
			parameters[4].Value = model.hykh;
			parameters[5].Value = model.hykh_bz;
			parameters[6].Value = model.hyrx;
			parameters[7].Value = model.krxm;
			parameters[8].Value = model.krbh;
			parameters[9].Value = model.ydrxm;
			parameters[10].Value = model.krgj;
			parameters[11].Value = model.krmz;
			parameters[12].Value = model.yxzj;
			parameters[13].Value = model.zjhm;
			parameters[14].Value = model.krxb;
			parameters[15].Value = model.krsr;
			parameters[16].Value = model.krdh;
			parameters[17].Value = model.krsj;
			parameters[18].Value = model.krEmail;
			parameters[19].Value = model.krdz;
			parameters[20].Value = model.qtyq;
			parameters[21].Value = model.krly;
			parameters[22].Value = model.xyh;
			parameters[23].Value = model.xydw;
			parameters[24].Value = model.xsy;
			parameters[25].Value = model.ddsj;
			parameters[26].Value = model.lksj;
			parameters[27].Value = model.czy;
			parameters[28].Value = model.ydsj;
			parameters[29].Value = model.sktt;
			parameters[30].Value = model.yddj;
			parameters[31].Value = model.vip_type;
			parameters[32].Value = model.fjrb;
			parameters[33].Value = model.fjbh;
			parameters[34].Value = model.sjjg;
			parameters[35].Value = model.jsjg;
			parameters[36].Value = model.lzfs;
			parameters[37].Value = model.lzts;
			parameters[38].Value = model.lzrs;
			parameters[39].Value = model.sfqr;
			parameters[40].Value = model.ydxg;
			parameters[41].Value = model.shxg;
			parameters[42].Value = model.shsc;

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
		public bool Update(jdgl_res_head_service.Model.Web_skyd model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Web_skyd set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("lsbh=@lsbh,");
			strSql.Append("ddbh=@ddbh,");
			strSql.Append("hykh=@hykh,");
			strSql.Append("hykh_bz=@hykh_bz,");
			strSql.Append("hyrx=@hyrx,");
			strSql.Append("krxm=@krxm,");
			strSql.Append("krbh=@krbh,");
			strSql.Append("ydrxm=@ydrxm,");
			strSql.Append("krgj=@krgj,");
			strSql.Append("krmz=@krmz,");
			strSql.Append("yxzj=@yxzj,");
			strSql.Append("zjhm=@zjhm,");
			strSql.Append("krxb=@krxb,");
			strSql.Append("krsr=@krsr,");
			strSql.Append("krdh=@krdh,");
			strSql.Append("krsj=@krsj,");
			strSql.Append("krEmail=@krEmail,");
			strSql.Append("krdz=@krdz,");
			strSql.Append("qtyq=@qtyq,");
			strSql.Append("krly=@krly,");
			strSql.Append("xyh=@xyh,");
			strSql.Append("xydw=@xydw,");
			strSql.Append("xsy=@xsy,");
			strSql.Append("ddsj=@ddsj,");
			strSql.Append("lksj=@lksj,");
			strSql.Append("czy=@czy,");
			strSql.Append("ydsj=@ydsj,");
			strSql.Append("sktt=@sktt,");
			strSql.Append("yddj=@yddj,");
			strSql.Append("vip_type=@vip_type,");
			strSql.Append("fjrb=@fjrb,");
			strSql.Append("fjbh=@fjbh,");
			strSql.Append("sjjg=@sjjg,");
			strSql.Append("jsjg=@jsjg,");
			strSql.Append("lzfs=@lzfs,");
			strSql.Append("lzts=@lzts,");
			strSql.Append("lzrs=@lzrs,");
			strSql.Append("sfqr=@sfqr,");
			strSql.Append("ydxg=@ydxg,");
			strSql.Append("shxg=@shxg,");
			strSql.Append("shsc=@shsc");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddbh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,200),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@krbh", SqlDbType.VarChar,100),
					new SqlParameter("@ydrxm", SqlDbType.VarChar,100),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,50),
					new SqlParameter("@qtyq", SqlDbType.VarChar,1000),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@ydsj", SqlDbType.DateTime),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@vip_type", SqlDbType.VarChar,100),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sjjg", SqlDbType.Decimal,9),
					new SqlParameter("@jsjg", SqlDbType.Decimal,9),
					new SqlParameter("@lzfs", SqlDbType.Int,4),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@lzrs", SqlDbType.Int,4),
					new SqlParameter("@sfqr", SqlDbType.Int,4),
					new SqlParameter("@ydxg", SqlDbType.VarChar,50),
					new SqlParameter("@shxg", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.lsbh;
			parameters[3].Value = model.ddbh;
			parameters[4].Value = model.hykh;
			parameters[5].Value = model.hykh_bz;
			parameters[6].Value = model.hyrx;
			parameters[7].Value = model.krxm;
			parameters[8].Value = model.krbh;
			parameters[9].Value = model.ydrxm;
			parameters[10].Value = model.krgj;
			parameters[11].Value = model.krmz;
			parameters[12].Value = model.yxzj;
			parameters[13].Value = model.zjhm;
			parameters[14].Value = model.krxb;
			parameters[15].Value = model.krsr;
			parameters[16].Value = model.krdh;
			parameters[17].Value = model.krsj;
			parameters[18].Value = model.krEmail;
			parameters[19].Value = model.krdz;
			parameters[20].Value = model.qtyq;
			parameters[21].Value = model.krly;
			parameters[22].Value = model.xyh;
			parameters[23].Value = model.xydw;
			parameters[24].Value = model.xsy;
			parameters[25].Value = model.ddsj;
			parameters[26].Value = model.lksj;
			parameters[27].Value = model.czy;
			parameters[28].Value = model.ydsj;
			parameters[29].Value = model.sktt;
			parameters[30].Value = model.yddj;
			parameters[31].Value = model.vip_type;
			parameters[32].Value = model.fjrb;
			parameters[33].Value = model.fjbh;
			parameters[34].Value = model.sjjg;
			parameters[35].Value = model.jsjg;
			parameters[36].Value = model.lzfs;
			parameters[37].Value = model.lzts;
			parameters[38].Value = model.lzrs;
			parameters[39].Value = model.sfqr;
			parameters[40].Value = model.ydxg;
			parameters[41].Value = model.shxg;
			parameters[42].Value = model.shsc;
			parameters[43].Value = model.id;

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
			strSql.Append("delete from Web_skyd ");
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
			strSql.Append("delete from Web_skyd ");
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
		public jdgl_res_head_service.Model.Web_skyd GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,lsbh,ddbh,hykh,hykh_bz,hyrx,krxm,krbh,ydrxm,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,qtyq,krly,xyh,xydw,xsy,ddsj,lksj,czy,ydsj,sktt,yddj,vip_type,fjrb,fjbh,sjjg,jsjg,lzfs,lzts,lzrs,sfqr,ydxg,shxg,shsc from Web_skyd ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			jdgl_res_head_service.Model.Web_skyd model=new jdgl_res_head_service.Model.Web_skyd();
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
				if(ds.Tables[0].Rows[0]["lsbh"]!=null && ds.Tables[0].Rows[0]["lsbh"].ToString()!="")
				{
					model.lsbh=ds.Tables[0].Rows[0]["lsbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ddbh"]!=null && ds.Tables[0].Rows[0]["ddbh"].ToString()!="")
				{
					model.ddbh=ds.Tables[0].Rows[0]["ddbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh"]!=null && ds.Tables[0].Rows[0]["hykh"].ToString()!="")
				{
					model.hykh=ds.Tables[0].Rows[0]["hykh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hykh_bz"]!=null && ds.Tables[0].Rows[0]["hykh_bz"].ToString()!="")
				{
					model.hykh_bz=ds.Tables[0].Rows[0]["hykh_bz"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hyrx"]!=null && ds.Tables[0].Rows[0]["hyrx"].ToString()!="")
				{
					model.hyrx=ds.Tables[0].Rows[0]["hyrx"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krxm"]!=null && ds.Tables[0].Rows[0]["krxm"].ToString()!="")
				{
					model.krxm=ds.Tables[0].Rows[0]["krxm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krbh"]!=null && ds.Tables[0].Rows[0]["krbh"].ToString()!="")
				{
					model.krbh=ds.Tables[0].Rows[0]["krbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ydrxm"]!=null && ds.Tables[0].Rows[0]["ydrxm"].ToString()!="")
				{
					model.ydrxm=ds.Tables[0].Rows[0]["ydrxm"].ToString();
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
				if(ds.Tables[0].Rows[0]["krxb"]!=null && ds.Tables[0].Rows[0]["krxb"].ToString()!="")
				{
					model.krxb=ds.Tables[0].Rows[0]["krxb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["krsr"]!=null && ds.Tables[0].Rows[0]["krsr"].ToString()!="")
				{
					model.krsr=DateTime.Parse(ds.Tables[0].Rows[0]["krsr"].ToString());
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
				if(ds.Tables[0].Rows[0]["qtyq"]!=null && ds.Tables[0].Rows[0]["qtyq"].ToString()!="")
				{
					model.qtyq=ds.Tables[0].Rows[0]["qtyq"].ToString();
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
				if(ds.Tables[0].Rows[0]["ddsj"]!=null && ds.Tables[0].Rows[0]["ddsj"].ToString()!="")
				{
					model.ddsj=DateTime.Parse(ds.Tables[0].Rows[0]["ddsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lksj"]!=null && ds.Tables[0].Rows[0]["lksj"].ToString()!="")
				{
					model.lksj=DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["czy"]!=null && ds.Tables[0].Rows[0]["czy"].ToString()!="")
				{
					model.czy=ds.Tables[0].Rows[0]["czy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ydsj"]!=null && ds.Tables[0].Rows[0]["ydsj"].ToString()!="")
				{
					model.ydsj=DateTime.Parse(ds.Tables[0].Rows[0]["ydsj"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sktt"]!=null && ds.Tables[0].Rows[0]["sktt"].ToString()!="")
				{
					model.sktt=ds.Tables[0].Rows[0]["sktt"].ToString();
				}
				if(ds.Tables[0].Rows[0]["yddj"]!=null && ds.Tables[0].Rows[0]["yddj"].ToString()!="")
				{
					model.yddj=ds.Tables[0].Rows[0]["yddj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vip_type"]!=null && ds.Tables[0].Rows[0]["vip_type"].ToString()!="")
				{
					model.vip_type=ds.Tables[0].Rows[0]["vip_type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb"]!=null && ds.Tables[0].Rows[0]["fjrb"].ToString()!="")
				{
					model.fjrb=ds.Tables[0].Rows[0]["fjrb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjbh"]!=null && ds.Tables[0].Rows[0]["fjbh"].ToString()!="")
				{
					model.fjbh=ds.Tables[0].Rows[0]["fjbh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sjjg"]!=null && ds.Tables[0].Rows[0]["sjjg"].ToString()!="")
				{
					model.sjjg=decimal.Parse(ds.Tables[0].Rows[0]["sjjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jsjg"]!=null && ds.Tables[0].Rows[0]["jsjg"].ToString()!="")
				{
					model.jsjg=decimal.Parse(ds.Tables[0].Rows[0]["jsjg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzfs"]!=null && ds.Tables[0].Rows[0]["lzfs"].ToString()!="")
				{
					model.lzfs=int.Parse(ds.Tables[0].Rows[0]["lzfs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzts"]!=null && ds.Tables[0].Rows[0]["lzts"].ToString()!="")
				{
					model.lzts=int.Parse(ds.Tables[0].Rows[0]["lzts"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lzrs"]!=null && ds.Tables[0].Rows[0]["lzrs"].ToString()!="")
				{
					model.lzrs=int.Parse(ds.Tables[0].Rows[0]["lzrs"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sfqr"]!=null && ds.Tables[0].Rows[0]["sfqr"].ToString()!="")
				{
					model.sfqr=int.Parse(ds.Tables[0].Rows[0]["sfqr"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ydxg"]!=null && ds.Tables[0].Rows[0]["ydxg"].ToString()!="")
				{
					model.ydxg=ds.Tables[0].Rows[0]["ydxg"].ToString();
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
			strSql.Append("select id,yydh,qymc,lsbh,ddbh,hykh,hykh_bz,hyrx,krxm,krbh,ydrxm,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,qtyq,krly,xyh,xydw,xsy,ddsj,lksj,czy,ydsj,sktt,yddj,vip_type,fjrb,fjbh,sjjg,jsjg,lzfs,lzts,lzrs,sfqr,ydxg,shxg,shsc ");
			strSql.Append(" FROM Web_skyd ");
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
			strSql.Append(" id,yydh,qymc,lsbh,ddbh,hykh,hykh_bz,hyrx,krxm,krbh,ydrxm,krgj,krmz,yxzj,zjhm,krxb,krsr,krdh,krsj,krEmail,krdz,qtyq,krly,xyh,xydw,xsy,ddsj,lksj,czy,ydsj,sktt,yddj,vip_type,fjrb,fjbh,sjjg,jsjg,lzfs,lzts,lzrs,sfqr,ydxg,shxg,shsc ");
			strSql.Append(" FROM Web_skyd ");
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
			strSql.Append("select count(1) FROM Web_skyd ");
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
			strSql.Append(")AS Row, T.*  from Web_skyd T ");
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
			parameters[0].Value = "Web_skyd";
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

