using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_service.Model;
namespace jdgl_res_head_service.BLL
{
	/// <summary>
	/// Xqyxx
	/// </summary>
	public partial class Xqyxx
	{
		private readonly jdgl_res_head_service.DAL.Xqyxx dal=new jdgl_res_head_service.DAL.Xqyxx();
		public Xqyxx()
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
		public int  Add(jdgl_res_head_service.Model.Xqyxx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(jdgl_res_head_service.Model.Xqyxx model)
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
		public jdgl_res_head_service.Model.Xqyxx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public jdgl_res_head_service.Model.Xqyxx GetModelByCache(int id)
		{
			
			string CacheKey = "XqyxxModel-" + id;
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
			return (jdgl_res_head_service.Model.Xqyxx)objModel;
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
		public List<jdgl_res_head_service.Model.Xqyxx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<jdgl_res_head_service.Model.Xqyxx> DataTableToList(DataTable dt)
		{
			List<jdgl_res_head_service.Model.Xqyxx> modelList = new List<jdgl_res_head_service.Model.Xqyxx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				jdgl_res_head_service.Model.Xqyxx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new jdgl_res_head_service.Model.Xqyxx();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["qy_type"]!=null && dt.Rows[n]["qy_type"].ToString()!="")
					{
					model.qy_type=dt.Rows[n]["qy_type"].ToString();
					}
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["zjm"]!=null && dt.Rows[n]["zjm"].ToString()!="")
					{
					model.zjm=dt.Rows[n]["zjm"].ToString();
					}
					if(dt.Rows[n]["gj"]!=null && dt.Rows[n]["gj"].ToString()!="")
					{
					model.gj=dt.Rows[n]["gj"].ToString();
					}
					if(dt.Rows[n]["sf"]!=null && dt.Rows[n]["sf"].ToString()!="")
					{
					model.sf=dt.Rows[n]["sf"].ToString();
					}
					if(dt.Rows[n]["sb"]!=null && dt.Rows[n]["sb"].ToString()!="")
					{
					model.sb=dt.Rows[n]["sb"].ToString();
					}
					if(dt.Rows[n]["qybh"]!=null && dt.Rows[n]["qybh"].ToString()!="")
					{
					model.qybh=dt.Rows[n]["qybh"].ToString();
					}
					if(dt.Rows[n]["qydh"]!=null && dt.Rows[n]["qydh"].ToString()!="")
					{
					model.qydh=dt.Rows[n]["qydh"].ToString();
					}
					if(dt.Rows[n]["qycz"]!=null && dt.Rows[n]["qycz"].ToString()!="")
					{
					model.qycz=dt.Rows[n]["qycz"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["nxr"]!=null && dt.Rows[n]["nxr"].ToString()!="")
					{
					model.nxr=dt.Rows[n]["nxr"].ToString();
					}
					if(dt.Rows[n]["qydz"]!=null && dt.Rows[n]["qydz"].ToString()!="")
					{
					model.qydz=dt.Rows[n]["qydz"].ToString();
					}
					if(dt.Rows[n]["xtyysj"]!=null && dt.Rows[n]["xtyysj"].ToString()!="")
					{
						model.xtyysj=DateTime.Parse(dt.Rows[n]["xtyysj"].ToString());
					}
					if(dt.Rows[n]["hyxs"]!=null && dt.Rows[n]["hyxs"].ToString()!="")
					{
					model.hyxs=dt.Rows[n]["hyxs"].ToString();
					}
					if(dt.Rows[n]["lx"]!=null && dt.Rows[n]["lx"].ToString()!="")
					{
					model.lx=dt.Rows[n]["lx"].ToString();
					}
					if(dt.Rows[n]["qymcyw"]!=null && dt.Rows[n]["qymcyw"].ToString()!="")
					{
					model.qymcyw=dt.Rows[n]["qymcyw"].ToString();
					}
					if(dt.Rows[n]["wz"]!=null && dt.Rows[n]["wz"].ToString()!="")
					{
					model.wz=dt.Rows[n]["wz"].ToString();
					}
					if(dt.Rows[n]["qydzyw"]!=null && dt.Rows[n]["qydzyw"].ToString()!="")
					{
					model.qydzyw=dt.Rows[n]["qydzyw"].ToString();
					}
					if(dt.Rows[n]["hyjfrx"]!=null && dt.Rows[n]["hyjfrx"].ToString()!="")
					{
					model.hyjfrx=dt.Rows[n]["hyjfrx"].ToString();
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

