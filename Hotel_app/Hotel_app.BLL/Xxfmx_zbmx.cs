using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Xxfmx_zbmx
	/// </summary>
	public partial class Xxfmx_zbmx
	{
		private readonly Hotel_app.DAL.Xxfmx_zbmx dal=new Hotel_app.DAL.Xxfmx_zbmx();
		public Xxfmx_zbmx()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hotel_app.Model.Xxfmx_zbmx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Xxfmx_zbmx model)
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
		public Hotel_app.Model.Xxfmx_zbmx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Xxfmx_zbmx GetModelByCache(int id)
		{
			
			string CacheKey = "Xxfmx_zbmxModel-" + id;
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
			return (Hotel_app.Model.Xxfmx_zbmx)objModel;
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
		public List<Hotel_app.Model.Xxfmx_zbmx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Xxfmx_zbmx> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Xxfmx_zbmx> modelList = new List<Hotel_app.Model.Xxfmx_zbmx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Xxfmx_zbmx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Xxfmx_zbmx();
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
					if(dt.Rows[n]["drbh"]!=null && dt.Rows[n]["drbh"].ToString()!="")
					{
					model.drbh=dt.Rows[n]["drbh"].ToString();
					}
					if(dt.Rows[n]["xfdr"]!=null && dt.Rows[n]["xfdr"].ToString()!="")
					{
					model.xfdr=dt.Rows[n]["xfdr"].ToString();
					}
					if(dt.Rows[n]["xrbh"]!=null && dt.Rows[n]["xrbh"].ToString()!="")
					{
					model.xrbh=dt.Rows[n]["xrbh"].ToString();
					}
					if(dt.Rows[n]["xfxr"]!=null && dt.Rows[n]["xfxr"].ToString()!="")
					{
					model.xfxr=dt.Rows[n]["xfxr"].ToString();
					}
					if(dt.Rows[n]["xftm"]!=null && dt.Rows[n]["xftm"].ToString()!="")
					{
					model.xftm=dt.Rows[n]["xftm"].ToString();
					}
					if(dt.Rows[n]["xfmx"]!=null && dt.Rows[n]["xfmx"].ToString()!="")
					{
					model.xfmx=dt.Rows[n]["xfmx"].ToString();
					}
					if(dt.Rows[n]["mxbh"]!=null && dt.Rows[n]["mxbh"].ToString()!="")
					{
					model.mxbh=dt.Rows[n]["mxbh"].ToString();
					}
					if(dt.Rows[n]["zb_sl"]!=null && dt.Rows[n]["zb_sl"].ToString()!="")
					{
						model.zb_sl=decimal.Parse(dt.Rows[n]["zb_sl"].ToString());
					}
					if(dt.Rows[n]["zb_zt"]!=null && dt.Rows[n]["zb_zt"].ToString()!="")
					{
					model.zb_zt=dt.Rows[n]["zb_zt"].ToString();
					}
					if(dt.Rows[n]["zb_sj"]!=null && dt.Rows[n]["zb_sj"].ToString()!="")
					{
						model.zb_sj=DateTime.Parse(dt.Rows[n]["zb_sj"].ToString());
					}
					if(dt.Rows[n]["zb_czy"]!=null && dt.Rows[n]["zb_czy"].ToString()!="")
					{
					model.zb_czy=dt.Rows[n]["zb_czy"].ToString();
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

