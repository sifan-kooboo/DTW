using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// BQ_syxffx
	/// </summary>
	public partial class BQ_syxffx
	{
		private readonly Hotel_app.DAL.BQ_syxffx dal=new Hotel_app.DAL.BQ_syxffx();
		public BQ_syxffx()
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
		public int  Add(Hotel_app.Model.BQ_syxffx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.BQ_syxffx model)
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
		public Hotel_app.Model.BQ_syxffx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.BQ_syxffx GetModelByCache(int id)
		{
			
			string CacheKey = "BQ_syxffxModel-" + id;
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
			return (Hotel_app.Model.BQ_syxffx)objModel;
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
		public List<Hotel_app.Model.BQ_syxffx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.BQ_syxffx> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.BQ_syxffx> modelList = new List<Hotel_app.Model.BQ_syxffx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.BQ_syxffx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.BQ_syxffx();
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
					if(dt.Rows[n]["type"]!=null && dt.Rows[n]["type"].ToString()!="")
					{
					model.type=dt.Rows[n]["type"].ToString();
					}
					if(dt.Rows[n]["fxdr"]!=null && dt.Rows[n]["fxdr"].ToString()!="")
					{
					model.fxdr=dt.Rows[n]["fxdr"].ToString();
					}
					if(dt.Rows[n]["fxrb"]!=null && dt.Rows[n]["fxrb"].ToString()!="")
					{
					model.fxrb=dt.Rows[n]["fxrb"].ToString();
					}
					if(dt.Rows[n]["zyye"]!=null && dt.Rows[n]["zyye"].ToString()!="")
					{
						model.zyye=decimal.Parse(dt.Rows[n]["zyye"].ToString());
					}
					if(dt.Rows[n]["zfh"]!=null && dt.Rows[n]["zfh"].ToString()!="")
					{
						model.zfh=decimal.Parse(dt.Rows[n]["zfh"].ToString());
					}
					if(dt.Rows[n]["czfs"]!=null && dt.Rows[n]["czfs"].ToString()!="")
					{
						model.czfs=decimal.Parse(dt.Rows[n]["czfs"].ToString());
					}
					if(dt.Rows[n]["pjczl"]!=null && dt.Rows[n]["pjczl"].ToString()!="")
					{
					model.pjczl=dt.Rows[n]["pjczl"].ToString();
					}
					if(dt.Rows[n]["xd_pjczl"]!=null && dt.Rows[n]["xd_pjczl"].ToString()!="")
					{
					model.xd_pjczl=dt.Rows[n]["xd_pjczl"].ToString();
					}
					if(dt.Rows[n]["pjbl"]!=null && dt.Rows[n]["pjbl"].ToString()!="")
					{
					model.pjbl=dt.Rows[n]["pjbl"].ToString();
					}
					if(dt.Rows[n]["xd_pjbl"]!=null && dt.Rows[n]["xd_pjbl"].ToString()!="")
					{
					model.xd_pjbl=dt.Rows[n]["xd_pjbl"].ToString();
					}
					if(dt.Rows[n]["pjfj"]!=null && dt.Rows[n]["pjfj"].ToString()!="")
					{
						model.pjfj=decimal.Parse(dt.Rows[n]["pjfj"].ToString());
					}
					if(dt.Rows[n]["jcb"]!=null && dt.Rows[n]["jcb"].ToString()!="")
					{
						model.jcb=decimal.Parse(dt.Rows[n]["jcb"].ToString());
					}
					if(dt.Rows[n]["czy_temp"]!=null && dt.Rows[n]["czy_temp"].ToString()!="")
					{
					model.czy_temp=dt.Rows[n]["czy_temp"].ToString();
					}
					if(dt.Rows[n]["cssj"]!=null && dt.Rows[n]["cssj"].ToString()!="")
					{
						model.cssj=DateTime.Parse(dt.Rows[n]["cssj"].ToString());
					}
					if(dt.Rows[n]["jssj"]!=null && dt.Rows[n]["jssj"].ToString()!="")
					{
						model.jssj=DateTime.Parse(dt.Rows[n]["jssj"].ToString());
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

