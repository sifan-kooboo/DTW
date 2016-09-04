using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// BSzhrbb
	/// </summary>
	public partial class BSzhrbb
	{
		private readonly Hotel_app.DAL.BSzhrbb dal=new Hotel_app.DAL.BSzhrbb();
		public BSzhrbb()
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
		public int  Add(Hotel_app.Model.BSzhrbb model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.BSzhrbb model)
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
		public Hotel_app.Model.BSzhrbb GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.BSzhrbb GetModelByCache(int id)
		{
			
			string CacheKey = "BSzhrbbModel-" + id;
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
			return (Hotel_app.Model.BSzhrbb)objModel;
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
		public List<Hotel_app.Model.BSzhrbb> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.BSzhrbb> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.BSzhrbb> modelList = new List<Hotel_app.Model.BSzhrbb>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.BSzhrbb model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.BSzhrbb();
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
					if(dt.Rows[n]["bbrq"]!=null && dt.Rows[n]["bbrq"].ToString()!="")
					{
						model.bbrq=DateTime.Parse(dt.Rows[n]["bbrq"].ToString());
					}
					if(dt.Rows[n]["rbxm"]!=null && dt.Rows[n]["rbxm"].ToString()!="")
					{
					model.rbxm=dt.Rows[n]["rbxm"].ToString();
					}
					if(dt.Rows[n]["brrj"]!=null && dt.Rows[n]["brrj"].ToString()!="")
					{
					model.brrj=dt.Rows[n]["brrj"].ToString();
					}
					if(dt.Rows[n]["byrj"]!=null && dt.Rows[n]["byrj"].ToString()!="")
					{
					model.byrj=dt.Rows[n]["byrj"].ToString();
					}
					if(dt.Rows[n]["rbxm0"]!=null && dt.Rows[n]["rbxm0"].ToString()!="")
					{
					model.rbxm0=dt.Rows[n]["rbxm0"].ToString();
					}
					if(dt.Rows[n]["brrj0"]!=null && dt.Rows[n]["brrj0"].ToString()!="")
					{
					model.brrj0=dt.Rows[n]["brrj0"].ToString();
					}
					if(dt.Rows[n]["byrj0"]!=null && dt.Rows[n]["byrj0"].ToString()!="")
					{
					model.byrj0=dt.Rows[n]["byrj0"].ToString();
					}
					if(dt.Rows[n]["shsc"]!=null && dt.Rows[n]["shsc"].ToString()!="")
					{
						if((dt.Rows[n]["shsc"].ToString()=="1")||(dt.Rows[n]["shsc"].ToString().ToLower()=="true"))
						{
						model.shsc=true;
						}
						else
						{
							model.shsc=false;
						}
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

