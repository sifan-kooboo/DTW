using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// BS_g_j_fx
	/// </summary>
	public partial class BS_g_j_fx
	{
		private readonly Hotel_app.DAL.BS_g_j_fx dal=new Hotel_app.DAL.BS_g_j_fx();
		public BS_g_j_fx()
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
		public int  Add(Hotel_app.Model.BS_g_j_fx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.BS_g_j_fx model)
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
		public Hotel_app.Model.BS_g_j_fx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.BS_g_j_fx GetModelByCache(int id)
		{
			
			string CacheKey = "BS_g_j_fxModel-" + id;
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
			return (Hotel_app.Model.BS_g_j_fx)objModel;
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
		public List<Hotel_app.Model.BS_g_j_fx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.BS_g_j_fx> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.BS_g_j_fx> modelList = new List<Hotel_app.Model.BS_g_j_fx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.BS_g_j_fx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.BS_g_j_fx();
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
					if(dt.Rows[n]["type"]!=null && dt.Rows[n]["type"].ToString()!="")
					{
					model.type=dt.Rows[n]["type"].ToString();
					}
					if(dt.Rows[n]["zfh"]!=null && dt.Rows[n]["zfh"].ToString()!="")
					{
						model.zfh=decimal.Parse(dt.Rows[n]["zfh"].ToString());
					}
					if(dt.Rows[n]["ds"]!=null && dt.Rows[n]["ds"].ToString()!="")
					{
						model.ds=decimal.Parse(dt.Rows[n]["ds"].ToString());
					}
					if(dt.Rows[n]["qt"]!=null && dt.Rows[n]["qt"].ToString()!="")
					{
						model.qt=decimal.Parse(dt.Rows[n]["qt"].ToString());
					}
					if(dt.Rows[n]["zyye"]!=null && dt.Rows[n]["zyye"].ToString()!="")
					{
						model.zyye=decimal.Parse(dt.Rows[n]["zyye"].ToString());
					}
					if(dt.Rows[n]["zzz"]!=null && dt.Rows[n]["zzz"].ToString()!="")
					{
						model.zzz=decimal.Parse(dt.Rows[n]["zzz"].ToString());
					}
					if(dt.Rows[n]["zgz_zjz"]!=null && dt.Rows[n]["zgz_zjz"].ToString()!="")
					{
						model.zgz_zjz=decimal.Parse(dt.Rows[n]["zgz_zjz"].ToString());
					}
					if(dt.Rows[n]["zsz"]!=null && dt.Rows[n]["zsz"].ToString()!="")
					{
						model.zsz=decimal.Parse(dt.Rows[n]["zsz"].ToString());
					}
					if(dt.Rows[n]["wj"]!=null && dt.Rows[n]["wj"].ToString()!="")
					{
						model.wj=decimal.Parse(dt.Rows[n]["wj"].ToString());
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

