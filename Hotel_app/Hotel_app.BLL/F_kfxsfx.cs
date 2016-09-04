using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// F_kfxsfx
	/// </summary>
	public partial class F_kfxsfx
	{
		private readonly Hotel_app.DAL.F_kfxsfx dal=new Hotel_app.DAL.F_kfxsfx();
		public F_kfxsfx()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hotel_app.Model.F_kfxsfx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.F_kfxsfx model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hotel_app.Model.F_kfxsfx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.F_kfxsfx GetModelByCache(int id)
		{
			
			string CacheKey = "F_kfxsfxModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hotel_app.Model.F_kfxsfx)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.F_kfxsfx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.F_kfxsfx> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.F_kfxsfx> modelList = new List<Hotel_app.Model.F_kfxsfx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.F_kfxsfx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.F_kfxsfx();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["krly"]!=null && dt.Rows[n]["krly"].ToString()!="")
					{
					model.krly=dt.Rows[n]["krly"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_1"]!=null && dt.Rows[n]["fjrb_fs_1"].ToString()!="")
					{
					model.fjrb_fs_1=dt.Rows[n]["fjrb_fs_1"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_1"]!=null && dt.Rows[n]["fjrb_fy_1"].ToString()!="")
					{
					model.fjrb_fy_1=dt.Rows[n]["fjrb_fy_1"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_2"]!=null && dt.Rows[n]["fjrb_fs_2"].ToString()!="")
					{
					model.fjrb_fs_2=dt.Rows[n]["fjrb_fs_2"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_2"]!=null && dt.Rows[n]["fjrb_fy_2"].ToString()!="")
					{
					model.fjrb_fy_2=dt.Rows[n]["fjrb_fy_2"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_3"]!=null && dt.Rows[n]["fjrb_fs_3"].ToString()!="")
					{
					model.fjrb_fs_3=dt.Rows[n]["fjrb_fs_3"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_3"]!=null && dt.Rows[n]["fjrb_fy_3"].ToString()!="")
					{
					model.fjrb_fy_3=dt.Rows[n]["fjrb_fy_3"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_4"]!=null && dt.Rows[n]["fjrb_fs_4"].ToString()!="")
					{
					model.fjrb_fs_4=dt.Rows[n]["fjrb_fs_4"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_4"]!=null && dt.Rows[n]["fjrb_fy_4"].ToString()!="")
					{
					model.fjrb_fy_4=dt.Rows[n]["fjrb_fy_4"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_5"]!=null && dt.Rows[n]["fjrb_fs_5"].ToString()!="")
					{
					model.fjrb_fs_5=dt.Rows[n]["fjrb_fs_5"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_5"]!=null && dt.Rows[n]["fjrb_fy_5"].ToString()!="")
					{
					model.fjrb_fy_5=dt.Rows[n]["fjrb_fy_5"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_6"]!=null && dt.Rows[n]["fjrb_fs_6"].ToString()!="")
					{
					model.fjrb_fs_6=dt.Rows[n]["fjrb_fs_6"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_6"]!=null && dt.Rows[n]["fjrb_fy_6"].ToString()!="")
					{
					model.fjrb_fy_6=dt.Rows[n]["fjrb_fy_6"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_7"]!=null && dt.Rows[n]["fjrb_fs_7"].ToString()!="")
					{
					model.fjrb_fs_7=dt.Rows[n]["fjrb_fs_7"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_7"]!=null && dt.Rows[n]["fjrb_fy_7"].ToString()!="")
					{
					model.fjrb_fy_7=dt.Rows[n]["fjrb_fy_7"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_8"]!=null && dt.Rows[n]["fjrb_fs_8"].ToString()!="")
					{
					model.fjrb_fs_8=dt.Rows[n]["fjrb_fs_8"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_8"]!=null && dt.Rows[n]["fjrb_fy_8"].ToString()!="")
					{
					model.fjrb_fy_8=dt.Rows[n]["fjrb_fy_8"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_9"]!=null && dt.Rows[n]["fjrb_fs_9"].ToString()!="")
					{
					model.fjrb_fs_9=dt.Rows[n]["fjrb_fs_9"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_9"]!=null && dt.Rows[n]["fjrb_fy_9"].ToString()!="")
					{
					model.fjrb_fy_9=dt.Rows[n]["fjrb_fy_9"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_10"]!=null && dt.Rows[n]["fjrb_fs_10"].ToString()!="")
					{
					model.fjrb_fs_10=dt.Rows[n]["fjrb_fs_10"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_10"]!=null && dt.Rows[n]["fjrb_fy_10"].ToString()!="")
					{
					model.fjrb_fy_10=dt.Rows[n]["fjrb_fy_10"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_11"]!=null && dt.Rows[n]["fjrb_fs_11"].ToString()!="")
					{
					model.fjrb_fs_11=dt.Rows[n]["fjrb_fs_11"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_11"]!=null && dt.Rows[n]["fjrb_fy_11"].ToString()!="")
					{
					model.fjrb_fy_11=dt.Rows[n]["fjrb_fy_11"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_12"]!=null && dt.Rows[n]["fjrb_fs_12"].ToString()!="")
					{
					model.fjrb_fs_12=dt.Rows[n]["fjrb_fs_12"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_12"]!=null && dt.Rows[n]["fjrb_fy_12"].ToString()!="")
					{
					model.fjrb_fy_12=dt.Rows[n]["fjrb_fy_12"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_13"]!=null && dt.Rows[n]["fjrb_fs_13"].ToString()!="")
					{
					model.fjrb_fs_13=dt.Rows[n]["fjrb_fs_13"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_13"]!=null && dt.Rows[n]["fjrb_fy_13"].ToString()!="")
					{
					model.fjrb_fy_13=dt.Rows[n]["fjrb_fy_13"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_14"]!=null && dt.Rows[n]["fjrb_fs_14"].ToString()!="")
					{
					model.fjrb_fs_14=dt.Rows[n]["fjrb_fs_14"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_14"]!=null && dt.Rows[n]["fjrb_fy_14"].ToString()!="")
					{
					model.fjrb_fy_14=dt.Rows[n]["fjrb_fy_14"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_15"]!=null && dt.Rows[n]["fjrb_fs_15"].ToString()!="")
					{
					model.fjrb_fs_15=dt.Rows[n]["fjrb_fs_15"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_15"]!=null && dt.Rows[n]["fjrb_fy_15"].ToString()!="")
					{
					model.fjrb_fy_15=dt.Rows[n]["fjrb_fy_15"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_16"]!=null && dt.Rows[n]["fjrb_fs_16"].ToString()!="")
					{
					model.fjrb_fs_16=dt.Rows[n]["fjrb_fs_16"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_16"]!=null && dt.Rows[n]["fjrb_fy_16"].ToString()!="")
					{
					model.fjrb_fy_16=dt.Rows[n]["fjrb_fy_16"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_17"]!=null && dt.Rows[n]["fjrb_fs_17"].ToString()!="")
					{
					model.fjrb_fs_17=dt.Rows[n]["fjrb_fs_17"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_17"]!=null && dt.Rows[n]["fjrb_fy_17"].ToString()!="")
					{
					model.fjrb_fy_17=dt.Rows[n]["fjrb_fy_17"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_18"]!=null && dt.Rows[n]["fjrb_fs_18"].ToString()!="")
					{
					model.fjrb_fs_18=dt.Rows[n]["fjrb_fs_18"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_18"]!=null && dt.Rows[n]["fjrb_fy_18"].ToString()!="")
					{
					model.fjrb_fy_18=dt.Rows[n]["fjrb_fy_18"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_19"]!=null && dt.Rows[n]["fjrb_fs_19"].ToString()!="")
					{
					model.fjrb_fs_19=dt.Rows[n]["fjrb_fs_19"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_19"]!=null && dt.Rows[n]["fjrb_fy_19"].ToString()!="")
					{
					model.fjrb_fy_19=dt.Rows[n]["fjrb_fy_19"].ToString();
					}
					if(dt.Rows[n]["fjrb_fs_20"]!=null && dt.Rows[n]["fjrb_fs_20"].ToString()!="")
					{
					model.fjrb_fs_20=dt.Rows[n]["fjrb_fs_20"].ToString();
					}
					if(dt.Rows[n]["fjrb_fy_20"]!=null && dt.Rows[n]["fjrb_fy_20"].ToString()!="")
					{
					model.fjrb_fy_20=dt.Rows[n]["fjrb_fy_20"].ToString();
					}
					if(dt.Rows[n]["hj_r_fs"]!=null && dt.Rows[n]["hj_r_fs"].ToString()!="")
					{
					model.hj_r_fs=dt.Rows[n]["hj_r_fs"].ToString();
					}
					if(dt.Rows[n]["hj_r_fy"]!=null && dt.Rows[n]["hj_r_fy"].ToString()!="")
					{
					model.hj_r_fy=dt.Rows[n]["hj_r_fy"].ToString();
					}
					if(dt.Rows[n]["hj_y_fs"]!=null && dt.Rows[n]["hj_y_fs"].ToString()!="")
					{
					model.hj_y_fs=dt.Rows[n]["hj_y_fs"].ToString();
					}
					if(dt.Rows[n]["hj_y_fy"]!=null && dt.Rows[n]["hj_y_fy"].ToString()!="")
					{
					model.hj_y_fy=dt.Rows[n]["hj_y_fy"].ToString();
					}
					if(dt.Rows[n]["hj_n_fs"]!=null && dt.Rows[n]["hj_n_fs"].ToString()!="")
					{
					model.hj_n_fs=dt.Rows[n]["hj_n_fs"].ToString();
					}
					if(dt.Rows[n]["hj_n_fy"]!=null && dt.Rows[n]["hj_n_fy"].ToString()!="")
					{
					model.hj_n_fy=dt.Rows[n]["hj_n_fy"].ToString();
					}
					if(dt.Rows[n]["pjczl"]!=null && dt.Rows[n]["pjczl"].ToString()!="")
					{
					model.pjczl=dt.Rows[n]["pjczl"].ToString();
					}
					if(dt.Rows[n]["pjfj"]!=null && dt.Rows[n]["pjfj"].ToString()!="")
					{
					model.pjfj=dt.Rows[n]["pjfj"].ToString();
					}
					if(dt.Rows[n]["pjbl"]!=null && dt.Rows[n]["pjbl"].ToString()!="")
					{
					model.pjbl=dt.Rows[n]["pjbl"].ToString();
					}
					if(dt.Rows[n]["jcb"]!=null && dt.Rows[n]["jcb"].ToString()!="")
					{
					model.jcb=dt.Rows[n]["jcb"].ToString();
					}
					if(dt.Rows[n]["czy_temp"]!=null && dt.Rows[n]["czy_temp"].ToString()!="")
					{
					model.czy_temp=dt.Rows[n]["czy_temp"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

