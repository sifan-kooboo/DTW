using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Ygzdw
	/// </summary>
	public partial class Ygzdw
	{
		private readonly Hotel_app.DAL.Ygzdw dal=new Hotel_app.DAL.Ygzdw();
		public Ygzdw()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.Ygzdw model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Ygzdw model)
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
		public Hotel_app.Model.Ygzdw GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Ygzdw GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "YgzdwModel-" ;
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
			return (Hotel_app.Model.Ygzdw)objModel;
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
		public List<Hotel_app.Model.Ygzdw> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Ygzdw> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Ygzdw> modelList = new List<Hotel_app.Model.Ygzdw>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Ygzdw model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Ygzdw();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["dwrx"]!=null && dt.Rows[n]["dwrx"].ToString()!="")
					{
					model.dwrx=dt.Rows[n]["dwrx"].ToString();
					}
					if(dt.Rows[n]["gzdw"]!=null && dt.Rows[n]["gzdw"].ToString()!="")
					{
					model.gzdw=dt.Rows[n]["gzdw"].ToString();
					}
					if(dt.Rows[n]["nxr"]!=null && dt.Rows[n]["nxr"].ToString()!="")
					{
					model.nxr=dt.Rows[n]["nxr"].ToString();
					}
					if(dt.Rows[n]["nxdh"]!=null && dt.Rows[n]["nxdh"].ToString()!="")
					{
					model.nxdh=dt.Rows[n]["nxdh"].ToString();
					}
					if(dt.Rows[n]["nxcz"]!=null && dt.Rows[n]["nxcz"].ToString()!="")
					{
					model.nxcz=dt.Rows[n]["nxcz"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["nxdz"]!=null && dt.Rows[n]["nxdz"].ToString()!="")
					{
					model.nxdz=dt.Rows[n]["nxdz"].ToString();
					}
					if(dt.Rows[n]["xsy"]!=null && dt.Rows[n]["xsy"].ToString()!="")
					{
					model.xsy=dt.Rows[n]["xsy"].ToString();
					}
					if(dt.Rows[n]["zjm"]!=null && dt.Rows[n]["zjm"].ToString()!="")
					{
					model.zjm=dt.Rows[n]["zjm"].ToString();
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

