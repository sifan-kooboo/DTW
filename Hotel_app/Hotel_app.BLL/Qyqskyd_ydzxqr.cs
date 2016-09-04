using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Qyqskyd_ydzxqr
	/// </summary>
	public partial class Qyqskyd_ydzxqr
	{
		private readonly Hotel_app.DAL.Qyqskyd_ydzxqr dal=new Hotel_app.DAL.Qyqskyd_ydzxqr();
		public Qyqskyd_ydzxqr()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hotel_app.Model.Qyqskyd_ydzxqr model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Qyqskyd_ydzxqr model)
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
		public Hotel_app.Model.Qyqskyd_ydzxqr GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Qyqskyd_ydzxqr GetModelByCache(int id)
		{
			
			string CacheKey = "Qyqskyd_ydzxqrModel-" + id;
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
			return (Hotel_app.Model.Qyqskyd_ydzxqr)objModel;
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
		public List<Hotel_app.Model.Qyqskyd_ydzxqr> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Qyqskyd_ydzxqr> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Qyqskyd_ydzxqr> modelList = new List<Hotel_app.Model.Qyqskyd_ydzxqr>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Qyqskyd_ydzxqr model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Qyqskyd_ydzxqr();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
					}
					if(dt.Rows[n]["qrzt"]!=null && dt.Rows[n]["qrzt"].ToString()!="")
					{
					model.qrzt=dt.Rows[n]["qrzt"].ToString();
					}
					if(dt.Rows[n]["qrsj"]!=null && dt.Rows[n]["qrsj"].ToString()!="")
					{
						model.qrsj=DateTime.Parse(dt.Rows[n]["qrsj"].ToString());
					}
					if(dt.Rows[n]["qryy"]!=null && dt.Rows[n]["qryy"].ToString()!="")
					{
					model.qryy=dt.Rows[n]["qryy"].ToString();
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
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
					if(dt.Rows[n]["scsj"]!=null && dt.Rows[n]["scsj"].ToString()!="")
					{
						model.scsj=DateTime.Parse(dt.Rows[n]["scsj"].ToString());
					}
					if(dt.Rows[n]["fjrb"]!=null && dt.Rows[n]["fjrb"].ToString()!="")
					{
					model.fjrb=dt.Rows[n]["fjrb"].ToString();
					}
					if(dt.Rows[n]["sktt"]!=null && dt.Rows[n]["sktt"].ToString()!="")
					{
					model.sktt=dt.Rows[n]["sktt"].ToString();
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
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

