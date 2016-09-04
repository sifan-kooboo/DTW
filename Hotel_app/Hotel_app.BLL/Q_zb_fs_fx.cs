using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Q_zb_fs_fx
	/// </summary>
	public partial class Q_zb_fs_fx
	{
		private readonly Hotel_app.DAL.Q_zb_fs_fx dal=new Hotel_app.DAL.Q_zb_fs_fx();
		public Q_zb_fs_fx()
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
		public int  Add(Hotel_app.Model.Q_zb_fs_fx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Q_zb_fs_fx model)
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
		public Hotel_app.Model.Q_zb_fs_fx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Q_zb_fs_fx GetModelByCache(int id)
		{
			
			string CacheKey = "Q_zb_fs_fxModel-" + id;
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
			return (Hotel_app.Model.Q_zb_fs_fx)objModel;
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
		public List<Hotel_app.Model.Q_zb_fs_fx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Q_zb_fs_fx> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Q_zb_fs_fx> modelList = new List<Hotel_app.Model.Q_zb_fs_fx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Q_zb_fs_fx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Q_zb_fs_fx();
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
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
					}
					if(dt.Rows[n]["fjrb"]!=null && dt.Rows[n]["fjrb"].ToString()!="")
					{
					model.fjrb=dt.Rows[n]["fjrb"].ToString();
					}
					if(dt.Rows[n]["fjbh"]!=null && dt.Rows[n]["fjbh"].ToString()!="")
					{
					model.fjbh=dt.Rows[n]["fjbh"].ToString();
					}
					if(dt.Rows[n]["ddrq"]!=null && dt.Rows[n]["ddrq"].ToString()!="")
					{
						model.ddrq=DateTime.Parse(dt.Rows[n]["ddrq"].ToString());
					}
					if(dt.Rows[n]["lkrq"]!=null && dt.Rows[n]["lkrq"].ToString()!="")
					{
						model.lkrq=DateTime.Parse(dt.Rows[n]["lkrq"].ToString());
					}
					if(dt.Rows[n]["ddsj"]!=null && dt.Rows[n]["ddsj"].ToString()!="")
					{
						model.ddsj=DateTime.Parse(dt.Rows[n]["ddsj"].ToString());
					}
					if(dt.Rows[n]["lksj"]!=null && dt.Rows[n]["lksj"].ToString()!="")
					{
						model.lksj=DateTime.Parse(dt.Rows[n]["lksj"].ToString());
					}
					if(dt.Rows[n]["lzfs"]!=null && dt.Rows[n]["lzfs"].ToString()!="")
					{
						model.lzfs=decimal.Parse(dt.Rows[n]["lzfs"].ToString());
					}
					if(dt.Rows[n]["zyzt"]!=null && dt.Rows[n]["zyzt"].ToString()!="")
					{
					model.zyzt=dt.Rows[n]["zyzt"].ToString();
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

