using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// BBfx_s_g_j_ye_ls
	/// </summary>
	public partial class BBfx_s_g_j_ye_ls
	{
		private readonly Hotel_app.DAL.BBfx_s_g_j_ye_ls dal=new Hotel_app.DAL.BBfx_s_g_j_ye_ls();
		public BBfx_s_g_j_ye_ls()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hotel_app.Model.BBfx_s_g_j_ye_ls model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.BBfx_s_g_j_ye_ls model)
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
		public Hotel_app.Model.BBfx_s_g_j_ye_ls GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.BBfx_s_g_j_ye_ls GetModelByCache(int id)
		{
			
			string CacheKey = "BBfx_s_g_j_ye_lsModel-" + id;
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
			return (Hotel_app.Model.BBfx_s_g_j_ye_ls)objModel;
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
		public List<Hotel_app.Model.BBfx_s_g_j_ye_ls> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.BBfx_s_g_j_ye_ls> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.BBfx_s_g_j_ye_ls> modelList = new List<Hotel_app.Model.BBfx_s_g_j_ye_ls>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.BBfx_s_g_j_ye_ls model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.BBfx_s_g_j_ye_ls();
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
					if(dt.Rows[n]["jzzt"]!=null && dt.Rows[n]["jzzt"].ToString()!="")
					{
					model.jzzt=dt.Rows[n]["jzzt"].ToString();
					}
					if(dt.Rows[n]["xydw"]!=null && dt.Rows[n]["xydw"].ToString()!="")
					{
					model.xydw=dt.Rows[n]["xydw"].ToString();
					}
					if(dt.Rows[n]["ff_total"]!=null && dt.Rows[n]["ff_total"].ToString()!="")
					{
						model.ff_total=decimal.Parse(dt.Rows[n]["ff_total"].ToString());
					}
					if(dt.Rows[n]["ds_total"]!=null && dt.Rows[n]["ds_total"].ToString()!="")
					{
						model.ds_total=decimal.Parse(dt.Rows[n]["ds_total"].ToString());
					}
					if(dt.Rows[n]["qt_total"]!=null && dt.Rows[n]["qt_total"].ToString()!="")
					{
						model.qt_total=decimal.Parse(dt.Rows[n]["qt_total"].ToString());
					}
					if(dt.Rows[n]["ye_total"]!=null && dt.Rows[n]["ye_total"].ToString()!="")
					{
						model.ye_total=decimal.Parse(dt.Rows[n]["ye_total"].ToString());
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

