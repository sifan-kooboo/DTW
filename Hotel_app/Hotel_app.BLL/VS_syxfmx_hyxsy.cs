using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// VS_syxfmx_hyxsy
	/// </summary>
	public partial class VS_syxfmx_hyxsy
	{
		private readonly Hotel_app.DAL.VS_syxfmx_hyxsy dal=new Hotel_app.DAL.VS_syxfmx_hyxsy();
		public VS_syxfmx_hyxsy()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.VS_syxfmx_hyxsy model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.VS_syxfmx_hyxsy model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hotel_app.Model.VS_syxfmx_hyxsy GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.VS_syxfmx_hyxsy GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "VS_syxfmx_hyxsyModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hotel_app.Model.VS_syxfmx_hyxsy)objModel;
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
		public List<Hotel_app.Model.VS_syxfmx_hyxsy> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.VS_syxfmx_hyxsy> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.VS_syxfmx_hyxsy> modelList = new List<Hotel_app.Model.VS_syxfmx_hyxsy>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.VS_syxfmx_hyxsy model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.VS_syxfmx_hyxsy();
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
					if(dt.Rows[n]["fjrb"]!=null && dt.Rows[n]["fjrb"].ToString()!="")
					{
					model.fjrb=dt.Rows[n]["fjrb"].ToString();
					}
					if(dt.Rows[n]["fjbh"]!=null && dt.Rows[n]["fjbh"].ToString()!="")
					{
					model.fjbh=dt.Rows[n]["fjbh"].ToString();
					}
					if(dt.Rows[n]["xfrq"]!=null && dt.Rows[n]["xfrq"].ToString()!="")
					{
						model.xfrq=DateTime.Parse(dt.Rows[n]["xfrq"].ToString());
					}
					if(dt.Rows[n]["xfsj"]!=null && dt.Rows[n]["xfsj"].ToString()!="")
					{
						model.xfsj=DateTime.Parse(dt.Rows[n]["xfsj"].ToString());
					}
					if(dt.Rows[n]["xfdr"]!=null && dt.Rows[n]["xfdr"].ToString()!="")
					{
					model.xfdr=dt.Rows[n]["xfdr"].ToString();
					}
					if(dt.Rows[n]["xfrb"]!=null && dt.Rows[n]["xfrb"].ToString()!="")
					{
					model.xfrb=dt.Rows[n]["xfrb"].ToString();
					}
					if(dt.Rows[n]["xfxm"]!=null && dt.Rows[n]["xfxm"].ToString()!="")
					{
					model.xfxm=dt.Rows[n]["xfxm"].ToString();
					}
					if(dt.Rows[n]["id_app"]!=null && dt.Rows[n]["id_app"].ToString()!="")
					{
					model.id_app=dt.Rows[n]["id_app"].ToString();
					}
					if(dt.Rows[n]["jzbh"]!=null && dt.Rows[n]["jzbh"].ToString()!="")
					{
					model.jzbh=dt.Rows[n]["jzbh"].ToString();
					}
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
					}
					if(dt.Rows[n]["hykh"]!=null && dt.Rows[n]["hykh"].ToString()!="")
					{
					model.hykh=dt.Rows[n]["hykh"].ToString();
					}
					if(dt.Rows[n]["xsy"]!=null && dt.Rows[n]["xsy"].ToString()!="")
					{
					model.xsy=dt.Rows[n]["xsy"].ToString();
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["xfsl"]!=null && dt.Rows[n]["xfsl"].ToString()!="")
					{
						model.xfsl=decimal.Parse(dt.Rows[n]["xfsl"].ToString());
					}
					if(dt.Rows[n]["sjxfje"]!=null && dt.Rows[n]["sjxfje"].ToString()!="")
					{
						model.sjxfje=decimal.Parse(dt.Rows[n]["sjxfje"].ToString());
					}
					if(dt.Rows[n]["hykh_bz"]!=null && dt.Rows[n]["hykh_bz"].ToString()!="")
					{
					model.hykh_bz=dt.Rows[n]["hykh_bz"].ToString();
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

