using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// RegisterInfo
	/// </summary>
	public partial class RegisterInfo
	{
		private readonly Hotel_app.DAL.RegisterInfo dal=new Hotel_app.DAL.RegisterInfo();
		public RegisterInfo()
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
		public int  Add(Hotel_app.Model.RegisterInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.RegisterInfo model)
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
		public Hotel_app.Model.RegisterInfo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.RegisterInfo GetModelByCache(int id)
		{
			
			string CacheKey = "RegisterInfoModel-" + id;
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
			return (Hotel_app.Model.RegisterInfo)objModel;
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
		public List<Hotel_app.Model.RegisterInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.RegisterInfo> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.RegisterInfo> modelList = new List<Hotel_app.Model.RegisterInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.RegisterInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.RegisterInfo();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["DiskID"]!=null && dt.Rows[n]["DiskID"].ToString()!="")
					{
					model.DiskID=dt.Rows[n]["DiskID"].ToString();
					}
					if(dt.Rows[n]["CpuID"]!=null && dt.Rows[n]["CpuID"].ToString()!="")
					{
					model.CpuID=dt.Rows[n]["CpuID"].ToString();
					}
					if(dt.Rows[n]["MachineID"]!=null && dt.Rows[n]["MachineID"].ToString()!="")
					{
					model.MachineID=dt.Rows[n]["MachineID"].ToString();
					}
					if(dt.Rows[n]["RegisterTime"]!=null && dt.Rows[n]["RegisterTime"].ToString()!="")
					{
						model.RegisterTime=DateTime.Parse(dt.Rows[n]["RegisterTime"].ToString());
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["UserName"]!=null && dt.Rows[n]["UserName"].ToString()!="")
					{
					model.UserName=dt.Rows[n]["UserName"].ToString();
					}
					if(dt.Rows[n]["UserGuid"]!=null && dt.Rows[n]["UserGuid"].ToString()!="")
					{
					model.UserGuid=dt.Rows[n]["UserGuid"].ToString();
					}
					if(dt.Rows[n]["mobile"]!=null && dt.Rows[n]["mobile"].ToString()!="")
					{
					model.mobile=dt.Rows[n]["mobile"].ToString();
					}
					if(dt.Rows[n]["RegisterYears"]!=null && dt.Rows[n]["RegisterYears"].ToString()!="")
					{
						model.RegisterYears=int.Parse(dt.Rows[n]["RegisterYears"].ToString());
					}
					if(dt.Rows[n]["xxzs"]!=null && dt.Rows[n]["xxzs"].ToString()!="")
					{
					model.xxzs=dt.Rows[n]["xxzs"].ToString();
					}
					if(dt.Rows[n]["RegisterKey"]!=null && dt.Rows[n]["RegisterKey"].ToString()!="")
					{
					model.RegisterKey=dt.Rows[n]["RegisterKey"].ToString();
					}
					if(dt.Rows[n]["StartUseTime"]!=null && dt.Rows[n]["StartUseTime"].ToString()!="")
					{
						model.StartUseTime=DateTime.Parse(dt.Rows[n]["StartUseTime"].ToString());
					}
					if(dt.Rows[n]["EndUseTime"]!=null && dt.Rows[n]["EndUseTime"].ToString()!="")
					{
						model.EndUseTime=DateTime.Parse(dt.Rows[n]["EndUseTime"].ToString());
					}
					if(dt.Rows[n]["UseTimes"]!=null && dt.Rows[n]["UseTimes"].ToString()!="")
					{
						model.UseTimes=int.Parse(dt.Rows[n]["UseTimes"].ToString());
					}
					if(dt.Rows[n]["lastLoginTime"]!=null && dt.Rows[n]["lastLoginTime"].ToString()!="")
					{
						model.lastLoginTime=DateTime.Parse(dt.Rows[n]["lastLoginTime"].ToString());
					}
					if(dt.Rows[n]["RegisterKey_temp"]!=null && dt.Rows[n]["RegisterKey_temp"].ToString()!="")
					{
					model.RegisterKey_temp=dt.Rows[n]["RegisterKey_temp"].ToString();
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

