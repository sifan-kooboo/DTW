using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Hotel_app.DAL
{
	/// <summary>
	/// 数据访问类:F_kfxsfx
	/// </summary>
	public partial class F_kfxsfx
	{
		public F_kfxsfx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "F_kfxsfx"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from F_kfxsfx");
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
		public int Add(Hotel_app.Model.F_kfxsfx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into F_kfxsfx(");
			strSql.Append("yydh,qymc,krly,fjrb_fs_1,fjrb_fy_1,fjrb_fs_2,fjrb_fy_2,fjrb_fs_3,fjrb_fy_3,fjrb_fs_4,fjrb_fy_4,fjrb_fs_5,fjrb_fy_5,fjrb_fs_6,fjrb_fy_6,fjrb_fs_7,fjrb_fy_7,fjrb_fs_8,fjrb_fy_8,fjrb_fs_9,fjrb_fy_9,fjrb_fs_10,fjrb_fy_10,fjrb_fs_11,fjrb_fy_11,fjrb_fs_12,fjrb_fy_12,fjrb_fs_13,fjrb_fy_13,fjrb_fs_14,fjrb_fy_14,fjrb_fs_15,fjrb_fy_15,fjrb_fs_16,fjrb_fy_16,fjrb_fs_17,fjrb_fy_17,fjrb_fs_18,fjrb_fy_18,fjrb_fs_19,fjrb_fy_19,fjrb_fs_20,fjrb_fy_20,hj_r_fs,hj_r_fy,hj_y_fs,hj_y_fy,hj_n_fs,hj_n_fy,pjczl,pjfj,pjbl,jcb,czy_temp)");
			strSql.Append(" values (");
			strSql.Append("@yydh,@qymc,@krly,@fjrb_fs_1,@fjrb_fy_1,@fjrb_fs_2,@fjrb_fy_2,@fjrb_fs_3,@fjrb_fy_3,@fjrb_fs_4,@fjrb_fy_4,@fjrb_fs_5,@fjrb_fy_5,@fjrb_fs_6,@fjrb_fy_6,@fjrb_fs_7,@fjrb_fy_7,@fjrb_fs_8,@fjrb_fy_8,@fjrb_fs_9,@fjrb_fy_9,@fjrb_fs_10,@fjrb_fy_10,@fjrb_fs_11,@fjrb_fy_11,@fjrb_fs_12,@fjrb_fy_12,@fjrb_fs_13,@fjrb_fy_13,@fjrb_fs_14,@fjrb_fy_14,@fjrb_fs_15,@fjrb_fy_15,@fjrb_fs_16,@fjrb_fy_16,@fjrb_fs_17,@fjrb_fy_17,@fjrb_fs_18,@fjrb_fy_18,@fjrb_fs_19,@fjrb_fy_19,@fjrb_fs_20,@fjrb_fy_20,@hj_r_fs,@hj_r_fy,@hj_y_fs,@hj_y_fy,@hj_n_fs,@hj_n_fy,@pjczl,@pjfj,@pjbl,@jcb,@czy_temp)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb_fs_1", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_1", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_2", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_2", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_3", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_3", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_4", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_4", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_5", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_5", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_6", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_6", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_7", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_7", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_8", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_8", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_9", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_9", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_10", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_10", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_11", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_11", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_12", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_12", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_13", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_13", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_14", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_14", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_15", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_15", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_16", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_16", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_17", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_17", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_18", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_18", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_19", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_19", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_20", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_20", SqlDbType.VarChar,53),
					new SqlParameter("@hj_r_fs", SqlDbType.VarChar,53),
					new SqlParameter("@hj_r_fy", SqlDbType.VarChar,53),
					new SqlParameter("@hj_y_fs", SqlDbType.VarChar,53),
					new SqlParameter("@hj_y_fy", SqlDbType.VarChar,53),
					new SqlParameter("@hj_n_fs", SqlDbType.VarChar,53),
					new SqlParameter("@hj_n_fy", SqlDbType.VarChar,53),
					new SqlParameter("@pjczl", SqlDbType.VarChar,50),
					new SqlParameter("@pjfj", SqlDbType.VarChar,53),
					new SqlParameter("@pjbl", SqlDbType.VarChar,50),
					new SqlParameter("@jcb", SqlDbType.VarChar,53),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.krly;
			parameters[3].Value = model.fjrb_fs_1;
			parameters[4].Value = model.fjrb_fy_1;
			parameters[5].Value = model.fjrb_fs_2;
			parameters[6].Value = model.fjrb_fy_2;
			parameters[7].Value = model.fjrb_fs_3;
			parameters[8].Value = model.fjrb_fy_3;
			parameters[9].Value = model.fjrb_fs_4;
			parameters[10].Value = model.fjrb_fy_4;
			parameters[11].Value = model.fjrb_fs_5;
			parameters[12].Value = model.fjrb_fy_5;
			parameters[13].Value = model.fjrb_fs_6;
			parameters[14].Value = model.fjrb_fy_6;
			parameters[15].Value = model.fjrb_fs_7;
			parameters[16].Value = model.fjrb_fy_7;
			parameters[17].Value = model.fjrb_fs_8;
			parameters[18].Value = model.fjrb_fy_8;
			parameters[19].Value = model.fjrb_fs_9;
			parameters[20].Value = model.fjrb_fy_9;
			parameters[21].Value = model.fjrb_fs_10;
			parameters[22].Value = model.fjrb_fy_10;
			parameters[23].Value = model.fjrb_fs_11;
			parameters[24].Value = model.fjrb_fy_11;
			parameters[25].Value = model.fjrb_fs_12;
			parameters[26].Value = model.fjrb_fy_12;
			parameters[27].Value = model.fjrb_fs_13;
			parameters[28].Value = model.fjrb_fy_13;
			parameters[29].Value = model.fjrb_fs_14;
			parameters[30].Value = model.fjrb_fy_14;
			parameters[31].Value = model.fjrb_fs_15;
			parameters[32].Value = model.fjrb_fy_15;
			parameters[33].Value = model.fjrb_fs_16;
			parameters[34].Value = model.fjrb_fy_16;
			parameters[35].Value = model.fjrb_fs_17;
			parameters[36].Value = model.fjrb_fy_17;
			parameters[37].Value = model.fjrb_fs_18;
			parameters[38].Value = model.fjrb_fy_18;
			parameters[39].Value = model.fjrb_fs_19;
			parameters[40].Value = model.fjrb_fy_19;
			parameters[41].Value = model.fjrb_fs_20;
			parameters[42].Value = model.fjrb_fy_20;
			parameters[43].Value = model.hj_r_fs;
			parameters[44].Value = model.hj_r_fy;
			parameters[45].Value = model.hj_y_fs;
			parameters[46].Value = model.hj_y_fy;
			parameters[47].Value = model.hj_n_fs;
			parameters[48].Value = model.hj_n_fy;
			parameters[49].Value = model.pjczl;
			parameters[50].Value = model.pjfj;
			parameters[51].Value = model.pjbl;
			parameters[52].Value = model.jcb;
			parameters[53].Value = model.czy_temp;

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
		public bool Update(Hotel_app.Model.F_kfxsfx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update F_kfxsfx set ");
			strSql.Append("yydh=@yydh,");
			strSql.Append("qymc=@qymc,");
			strSql.Append("krly=@krly,");
			strSql.Append("fjrb_fs_1=@fjrb_fs_1,");
			strSql.Append("fjrb_fy_1=@fjrb_fy_1,");
			strSql.Append("fjrb_fs_2=@fjrb_fs_2,");
			strSql.Append("fjrb_fy_2=@fjrb_fy_2,");
			strSql.Append("fjrb_fs_3=@fjrb_fs_3,");
			strSql.Append("fjrb_fy_3=@fjrb_fy_3,");
			strSql.Append("fjrb_fs_4=@fjrb_fs_4,");
			strSql.Append("fjrb_fy_4=@fjrb_fy_4,");
			strSql.Append("fjrb_fs_5=@fjrb_fs_5,");
			strSql.Append("fjrb_fy_5=@fjrb_fy_5,");
			strSql.Append("fjrb_fs_6=@fjrb_fs_6,");
			strSql.Append("fjrb_fy_6=@fjrb_fy_6,");
			strSql.Append("fjrb_fs_7=@fjrb_fs_7,");
			strSql.Append("fjrb_fy_7=@fjrb_fy_7,");
			strSql.Append("fjrb_fs_8=@fjrb_fs_8,");
			strSql.Append("fjrb_fy_8=@fjrb_fy_8,");
			strSql.Append("fjrb_fs_9=@fjrb_fs_9,");
			strSql.Append("fjrb_fy_9=@fjrb_fy_9,");
			strSql.Append("fjrb_fs_10=@fjrb_fs_10,");
			strSql.Append("fjrb_fy_10=@fjrb_fy_10,");
			strSql.Append("fjrb_fs_11=@fjrb_fs_11,");
			strSql.Append("fjrb_fy_11=@fjrb_fy_11,");
			strSql.Append("fjrb_fs_12=@fjrb_fs_12,");
			strSql.Append("fjrb_fy_12=@fjrb_fy_12,");
			strSql.Append("fjrb_fs_13=@fjrb_fs_13,");
			strSql.Append("fjrb_fy_13=@fjrb_fy_13,");
			strSql.Append("fjrb_fs_14=@fjrb_fs_14,");
			strSql.Append("fjrb_fy_14=@fjrb_fy_14,");
			strSql.Append("fjrb_fs_15=@fjrb_fs_15,");
			strSql.Append("fjrb_fy_15=@fjrb_fy_15,");
			strSql.Append("fjrb_fs_16=@fjrb_fs_16,");
			strSql.Append("fjrb_fy_16=@fjrb_fy_16,");
			strSql.Append("fjrb_fs_17=@fjrb_fs_17,");
			strSql.Append("fjrb_fy_17=@fjrb_fy_17,");
			strSql.Append("fjrb_fs_18=@fjrb_fs_18,");
			strSql.Append("fjrb_fy_18=@fjrb_fy_18,");
			strSql.Append("fjrb_fs_19=@fjrb_fs_19,");
			strSql.Append("fjrb_fy_19=@fjrb_fy_19,");
			strSql.Append("fjrb_fs_20=@fjrb_fs_20,");
			strSql.Append("fjrb_fy_20=@fjrb_fy_20,");
			strSql.Append("hj_r_fs=@hj_r_fs,");
			strSql.Append("hj_r_fy=@hj_r_fy,");
			strSql.Append("hj_y_fs=@hj_y_fs,");
			strSql.Append("hj_y_fy=@hj_y_fy,");
			strSql.Append("hj_n_fs=@hj_n_fs,");
			strSql.Append("hj_n_fy=@hj_n_fy,");
			strSql.Append("pjczl=@pjczl,");
			strSql.Append("pjfj=@pjfj,");
			strSql.Append("pjbl=@pjbl,");
			strSql.Append("jcb=@jcb,");
			strSql.Append("czy_temp=@czy_temp");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb_fs_1", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_1", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_2", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_2", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_3", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_3", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_4", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_4", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_5", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_5", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_6", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_6", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_7", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_7", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_8", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_8", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_9", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_9", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_10", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_10", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_11", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_11", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_12", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_12", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_13", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_13", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_14", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_14", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_15", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_15", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_16", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_16", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_17", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_17", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_18", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_18", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_19", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_19", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fs_20", SqlDbType.VarChar,53),
					new SqlParameter("@fjrb_fy_20", SqlDbType.VarChar,53),
					new SqlParameter("@hj_r_fs", SqlDbType.VarChar,53),
					new SqlParameter("@hj_r_fy", SqlDbType.VarChar,53),
					new SqlParameter("@hj_y_fs", SqlDbType.VarChar,53),
					new SqlParameter("@hj_y_fy", SqlDbType.VarChar,53),
					new SqlParameter("@hj_n_fs", SqlDbType.VarChar,53),
					new SqlParameter("@hj_n_fy", SqlDbType.VarChar,53),
					new SqlParameter("@pjczl", SqlDbType.VarChar,50),
					new SqlParameter("@pjfj", SqlDbType.VarChar,53),
					new SqlParameter("@pjbl", SqlDbType.VarChar,50),
					new SqlParameter("@jcb", SqlDbType.VarChar,53),
					new SqlParameter("@czy_temp", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.yydh;
			parameters[1].Value = model.qymc;
			parameters[2].Value = model.krly;
			parameters[3].Value = model.fjrb_fs_1;
			parameters[4].Value = model.fjrb_fy_1;
			parameters[5].Value = model.fjrb_fs_2;
			parameters[6].Value = model.fjrb_fy_2;
			parameters[7].Value = model.fjrb_fs_3;
			parameters[8].Value = model.fjrb_fy_3;
			parameters[9].Value = model.fjrb_fs_4;
			parameters[10].Value = model.fjrb_fy_4;
			parameters[11].Value = model.fjrb_fs_5;
			parameters[12].Value = model.fjrb_fy_5;
			parameters[13].Value = model.fjrb_fs_6;
			parameters[14].Value = model.fjrb_fy_6;
			parameters[15].Value = model.fjrb_fs_7;
			parameters[16].Value = model.fjrb_fy_7;
			parameters[17].Value = model.fjrb_fs_8;
			parameters[18].Value = model.fjrb_fy_8;
			parameters[19].Value = model.fjrb_fs_9;
			parameters[20].Value = model.fjrb_fy_9;
			parameters[21].Value = model.fjrb_fs_10;
			parameters[22].Value = model.fjrb_fy_10;
			parameters[23].Value = model.fjrb_fs_11;
			parameters[24].Value = model.fjrb_fy_11;
			parameters[25].Value = model.fjrb_fs_12;
			parameters[26].Value = model.fjrb_fy_12;
			parameters[27].Value = model.fjrb_fs_13;
			parameters[28].Value = model.fjrb_fy_13;
			parameters[29].Value = model.fjrb_fs_14;
			parameters[30].Value = model.fjrb_fy_14;
			parameters[31].Value = model.fjrb_fs_15;
			parameters[32].Value = model.fjrb_fy_15;
			parameters[33].Value = model.fjrb_fs_16;
			parameters[34].Value = model.fjrb_fy_16;
			parameters[35].Value = model.fjrb_fs_17;
			parameters[36].Value = model.fjrb_fy_17;
			parameters[37].Value = model.fjrb_fs_18;
			parameters[38].Value = model.fjrb_fy_18;
			parameters[39].Value = model.fjrb_fs_19;
			parameters[40].Value = model.fjrb_fy_19;
			parameters[41].Value = model.fjrb_fs_20;
			parameters[42].Value = model.fjrb_fy_20;
			parameters[43].Value = model.hj_r_fs;
			parameters[44].Value = model.hj_r_fy;
			parameters[45].Value = model.hj_y_fs;
			parameters[46].Value = model.hj_y_fy;
			parameters[47].Value = model.hj_n_fs;
			parameters[48].Value = model.hj_n_fy;
			parameters[49].Value = model.pjczl;
			parameters[50].Value = model.pjfj;
			parameters[51].Value = model.pjbl;
			parameters[52].Value = model.jcb;
			parameters[53].Value = model.czy_temp;
			parameters[54].Value = model.id;

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
			strSql.Append("delete from F_kfxsfx ");
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
			strSql.Append("delete from F_kfxsfx ");
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
		public Hotel_app.Model.F_kfxsfx GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,yydh,qymc,krly,fjrb_fs_1,fjrb_fy_1,fjrb_fs_2,fjrb_fy_2,fjrb_fs_3,fjrb_fy_3,fjrb_fs_4,fjrb_fy_4,fjrb_fs_5,fjrb_fy_5,fjrb_fs_6,fjrb_fy_6,fjrb_fs_7,fjrb_fy_7,fjrb_fs_8,fjrb_fy_8,fjrb_fs_9,fjrb_fy_9,fjrb_fs_10,fjrb_fy_10,fjrb_fs_11,fjrb_fy_11,fjrb_fs_12,fjrb_fy_12,fjrb_fs_13,fjrb_fy_13,fjrb_fs_14,fjrb_fy_14,fjrb_fs_15,fjrb_fy_15,fjrb_fs_16,fjrb_fy_16,fjrb_fs_17,fjrb_fy_17,fjrb_fs_18,fjrb_fy_18,fjrb_fs_19,fjrb_fy_19,fjrb_fs_20,fjrb_fy_20,hj_r_fs,hj_r_fy,hj_y_fs,hj_y_fy,hj_n_fs,hj_n_fy,pjczl,pjfj,pjbl,jcb,czy_temp from F_kfxsfx ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Hotel_app.Model.F_kfxsfx model=new Hotel_app.Model.F_kfxsfx();
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
				if(ds.Tables[0].Rows[0]["krly"]!=null && ds.Tables[0].Rows[0]["krly"].ToString()!="")
				{
					model.krly=ds.Tables[0].Rows[0]["krly"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_1"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_1"].ToString()!="")
				{
					model.fjrb_fs_1=ds.Tables[0].Rows[0]["fjrb_fs_1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_1"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_1"].ToString()!="")
				{
					model.fjrb_fy_1=ds.Tables[0].Rows[0]["fjrb_fy_1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_2"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_2"].ToString()!="")
				{
					model.fjrb_fs_2=ds.Tables[0].Rows[0]["fjrb_fs_2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_2"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_2"].ToString()!="")
				{
					model.fjrb_fy_2=ds.Tables[0].Rows[0]["fjrb_fy_2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_3"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_3"].ToString()!="")
				{
					model.fjrb_fs_3=ds.Tables[0].Rows[0]["fjrb_fs_3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_3"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_3"].ToString()!="")
				{
					model.fjrb_fy_3=ds.Tables[0].Rows[0]["fjrb_fy_3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_4"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_4"].ToString()!="")
				{
					model.fjrb_fs_4=ds.Tables[0].Rows[0]["fjrb_fs_4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_4"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_4"].ToString()!="")
				{
					model.fjrb_fy_4=ds.Tables[0].Rows[0]["fjrb_fy_4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_5"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_5"].ToString()!="")
				{
					model.fjrb_fs_5=ds.Tables[0].Rows[0]["fjrb_fs_5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_5"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_5"].ToString()!="")
				{
					model.fjrb_fy_5=ds.Tables[0].Rows[0]["fjrb_fy_5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_6"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_6"].ToString()!="")
				{
					model.fjrb_fs_6=ds.Tables[0].Rows[0]["fjrb_fs_6"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_6"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_6"].ToString()!="")
				{
					model.fjrb_fy_6=ds.Tables[0].Rows[0]["fjrb_fy_6"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_7"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_7"].ToString()!="")
				{
					model.fjrb_fs_7=ds.Tables[0].Rows[0]["fjrb_fs_7"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_7"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_7"].ToString()!="")
				{
					model.fjrb_fy_7=ds.Tables[0].Rows[0]["fjrb_fy_7"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_8"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_8"].ToString()!="")
				{
					model.fjrb_fs_8=ds.Tables[0].Rows[0]["fjrb_fs_8"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_8"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_8"].ToString()!="")
				{
					model.fjrb_fy_8=ds.Tables[0].Rows[0]["fjrb_fy_8"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_9"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_9"].ToString()!="")
				{
					model.fjrb_fs_9=ds.Tables[0].Rows[0]["fjrb_fs_9"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_9"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_9"].ToString()!="")
				{
					model.fjrb_fy_9=ds.Tables[0].Rows[0]["fjrb_fy_9"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_10"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_10"].ToString()!="")
				{
					model.fjrb_fs_10=ds.Tables[0].Rows[0]["fjrb_fs_10"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_10"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_10"].ToString()!="")
				{
					model.fjrb_fy_10=ds.Tables[0].Rows[0]["fjrb_fy_10"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_11"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_11"].ToString()!="")
				{
					model.fjrb_fs_11=ds.Tables[0].Rows[0]["fjrb_fs_11"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_11"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_11"].ToString()!="")
				{
					model.fjrb_fy_11=ds.Tables[0].Rows[0]["fjrb_fy_11"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_12"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_12"].ToString()!="")
				{
					model.fjrb_fs_12=ds.Tables[0].Rows[0]["fjrb_fs_12"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_12"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_12"].ToString()!="")
				{
					model.fjrb_fy_12=ds.Tables[0].Rows[0]["fjrb_fy_12"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_13"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_13"].ToString()!="")
				{
					model.fjrb_fs_13=ds.Tables[0].Rows[0]["fjrb_fs_13"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_13"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_13"].ToString()!="")
				{
					model.fjrb_fy_13=ds.Tables[0].Rows[0]["fjrb_fy_13"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_14"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_14"].ToString()!="")
				{
					model.fjrb_fs_14=ds.Tables[0].Rows[0]["fjrb_fs_14"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_14"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_14"].ToString()!="")
				{
					model.fjrb_fy_14=ds.Tables[0].Rows[0]["fjrb_fy_14"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_15"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_15"].ToString()!="")
				{
					model.fjrb_fs_15=ds.Tables[0].Rows[0]["fjrb_fs_15"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_15"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_15"].ToString()!="")
				{
					model.fjrb_fy_15=ds.Tables[0].Rows[0]["fjrb_fy_15"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_16"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_16"].ToString()!="")
				{
					model.fjrb_fs_16=ds.Tables[0].Rows[0]["fjrb_fs_16"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_16"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_16"].ToString()!="")
				{
					model.fjrb_fy_16=ds.Tables[0].Rows[0]["fjrb_fy_16"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_17"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_17"].ToString()!="")
				{
					model.fjrb_fs_17=ds.Tables[0].Rows[0]["fjrb_fs_17"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_17"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_17"].ToString()!="")
				{
					model.fjrb_fy_17=ds.Tables[0].Rows[0]["fjrb_fy_17"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_18"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_18"].ToString()!="")
				{
					model.fjrb_fs_18=ds.Tables[0].Rows[0]["fjrb_fs_18"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_18"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_18"].ToString()!="")
				{
					model.fjrb_fy_18=ds.Tables[0].Rows[0]["fjrb_fy_18"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_19"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_19"].ToString()!="")
				{
					model.fjrb_fs_19=ds.Tables[0].Rows[0]["fjrb_fs_19"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_19"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_19"].ToString()!="")
				{
					model.fjrb_fy_19=ds.Tables[0].Rows[0]["fjrb_fy_19"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fs_20"]!=null && ds.Tables[0].Rows[0]["fjrb_fs_20"].ToString()!="")
				{
					model.fjrb_fs_20=ds.Tables[0].Rows[0]["fjrb_fs_20"].ToString();
				}
				if(ds.Tables[0].Rows[0]["fjrb_fy_20"]!=null && ds.Tables[0].Rows[0]["fjrb_fy_20"].ToString()!="")
				{
					model.fjrb_fy_20=ds.Tables[0].Rows[0]["fjrb_fy_20"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hj_r_fs"]!=null && ds.Tables[0].Rows[0]["hj_r_fs"].ToString()!="")
				{
					model.hj_r_fs=ds.Tables[0].Rows[0]["hj_r_fs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hj_r_fy"]!=null && ds.Tables[0].Rows[0]["hj_r_fy"].ToString()!="")
				{
					model.hj_r_fy=ds.Tables[0].Rows[0]["hj_r_fy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hj_y_fs"]!=null && ds.Tables[0].Rows[0]["hj_y_fs"].ToString()!="")
				{
					model.hj_y_fs=ds.Tables[0].Rows[0]["hj_y_fs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hj_y_fy"]!=null && ds.Tables[0].Rows[0]["hj_y_fy"].ToString()!="")
				{
					model.hj_y_fy=ds.Tables[0].Rows[0]["hj_y_fy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hj_n_fs"]!=null && ds.Tables[0].Rows[0]["hj_n_fs"].ToString()!="")
				{
					model.hj_n_fs=ds.Tables[0].Rows[0]["hj_n_fs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hj_n_fy"]!=null && ds.Tables[0].Rows[0]["hj_n_fy"].ToString()!="")
				{
					model.hj_n_fy=ds.Tables[0].Rows[0]["hj_n_fy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pjczl"]!=null && ds.Tables[0].Rows[0]["pjczl"].ToString()!="")
				{
					model.pjczl=ds.Tables[0].Rows[0]["pjczl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pjfj"]!=null && ds.Tables[0].Rows[0]["pjfj"].ToString()!="")
				{
					model.pjfj=ds.Tables[0].Rows[0]["pjfj"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pjbl"]!=null && ds.Tables[0].Rows[0]["pjbl"].ToString()!="")
				{
					model.pjbl=ds.Tables[0].Rows[0]["pjbl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jcb"]!=null && ds.Tables[0].Rows[0]["jcb"].ToString()!="")
				{
					model.jcb=ds.Tables[0].Rows[0]["jcb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["czy_temp"]!=null && ds.Tables[0].Rows[0]["czy_temp"].ToString()!="")
				{
					model.czy_temp=ds.Tables[0].Rows[0]["czy_temp"].ToString();
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
			strSql.Append("select id,yydh,qymc,krly,fjrb_fs_1,fjrb_fy_1,fjrb_fs_2,fjrb_fy_2,fjrb_fs_3,fjrb_fy_3,fjrb_fs_4,fjrb_fy_4,fjrb_fs_5,fjrb_fy_5,fjrb_fs_6,fjrb_fy_6,fjrb_fs_7,fjrb_fy_7,fjrb_fs_8,fjrb_fy_8,fjrb_fs_9,fjrb_fy_9,fjrb_fs_10,fjrb_fy_10,fjrb_fs_11,fjrb_fy_11,fjrb_fs_12,fjrb_fy_12,fjrb_fs_13,fjrb_fy_13,fjrb_fs_14,fjrb_fy_14,fjrb_fs_15,fjrb_fy_15,fjrb_fs_16,fjrb_fy_16,fjrb_fs_17,fjrb_fy_17,fjrb_fs_18,fjrb_fy_18,fjrb_fs_19,fjrb_fy_19,fjrb_fs_20,fjrb_fy_20,hj_r_fs,hj_r_fy,hj_y_fs,hj_y_fy,hj_n_fs,hj_n_fy,pjczl,pjfj,pjbl,jcb,czy_temp ");
			strSql.Append(" FROM F_kfxsfx ");
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
			strSql.Append(" id,yydh,qymc,krly,fjrb_fs_1,fjrb_fy_1,fjrb_fs_2,fjrb_fy_2,fjrb_fs_3,fjrb_fy_3,fjrb_fs_4,fjrb_fy_4,fjrb_fs_5,fjrb_fy_5,fjrb_fs_6,fjrb_fy_6,fjrb_fs_7,fjrb_fy_7,fjrb_fs_8,fjrb_fy_8,fjrb_fs_9,fjrb_fy_9,fjrb_fs_10,fjrb_fy_10,fjrb_fs_11,fjrb_fy_11,fjrb_fs_12,fjrb_fy_12,fjrb_fs_13,fjrb_fy_13,fjrb_fs_14,fjrb_fy_14,fjrb_fs_15,fjrb_fy_15,fjrb_fs_16,fjrb_fy_16,fjrb_fs_17,fjrb_fy_17,fjrb_fs_18,fjrb_fy_18,fjrb_fs_19,fjrb_fy_19,fjrb_fs_20,fjrb_fy_20,hj_r_fs,hj_r_fy,hj_y_fs,hj_y_fy,hj_n_fs,hj_n_fy,pjczl,pjfj,pjbl,jcb,czy_temp ");
			strSql.Append(" FROM F_kfxsfx ");
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
			strSql.Append("select count(1) FROM F_kfxsfx ");
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
			strSql.Append(")AS Row, T.*  from F_kfxsfx T ");
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
			parameters[0].Value = "F_kfxsfx";
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

