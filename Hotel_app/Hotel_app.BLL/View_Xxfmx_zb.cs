using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// View_Xxfmx_zb
	/// </summary>
	public partial class View_Xxfmx_zb
	{
		private readonly Hotel_app.DAL.View_Xxfmx_zb dal=new Hotel_app.DAL.View_Xxfmx_zb();
		public View_Xxfmx_zb()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.View_Xxfmx_zb model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.View_Xxfmx_zb model)
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
		public Hotel_app.Model.View_Xxfmx_zb GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.View_Xxfmx_zb GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "View_Xxfmx_zbModel-" ;
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
			return (Hotel_app.Model.View_Xxfmx_zb)objModel;
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
		public List<Hotel_app.Model.View_Xxfmx_zb> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.View_Xxfmx_zb> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.View_Xxfmx_zb> modelList = new List<Hotel_app.Model.View_Xxfmx_zb>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.View_Xxfmx_zb model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.View_Xxfmx_zb();
					if(dt.Rows[n]["mxbh"]!=null && dt.Rows[n]["mxbh"].ToString()!="")
					{
					model.mxbh=dt.Rows[n]["mxbh"].ToString();
					}
					if(dt.Rows[n]["zb_sl"]!=null && dt.Rows[n]["zb_sl"].ToString()!="")
					{
						model.zb_sl=decimal.Parse(dt.Rows[n]["zb_sl"].ToString());
					}
					if(dt.Rows[n]["zb_sj"]!=null && dt.Rows[n]["zb_sj"].ToString()!="")
					{
						model.zb_sj=DateTime.Parse(dt.Rows[n]["zb_sj"].ToString());
					}
					if(dt.Rows[n]["zb_jjje"]!=null && dt.Rows[n]["zb_jjje"].ToString()!="")
					{
						model.zb_jjje=decimal.Parse(dt.Rows[n]["zb_jjje"].ToString());
					}
					if(dt.Rows[n]["zb_Total_cb"]!=null && dt.Rows[n]["zb_Total_cb"].ToString()!="")
					{
						model.zb_Total_cb=decimal.Parse(dt.Rows[n]["zb_Total_cb"].ToString());
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

