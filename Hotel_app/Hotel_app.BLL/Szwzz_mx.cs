using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Szwzz_mx
	/// </summary>
	public partial class Szwzz_mx
	{
		private readonly Hotel_app.DAL.Szwzz_mx dal=new Hotel_app.DAL.Szwzz_mx();
		public Szwzz_mx()
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
		public int  Add(Hotel_app.Model.Szwzz_mx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Szwzz_mx model)
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
		public Hotel_app.Model.Szwzz_mx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Szwzz_mx GetModelByCache(int id)
		{
			
			string CacheKey = "Szwzz_mxModel-" + id;
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
			return (Hotel_app.Model.Szwzz_mx)objModel;
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
		public List<Hotel_app.Model.Szwzz_mx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Szwzz_mx> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Szwzz_mx> modelList = new List<Hotel_app.Model.Szwzz_mx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Szwzz_mx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Szwzz_mx();
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
					if(dt.Rows[n]["old_lsbh"]!=null && dt.Rows[n]["old_lsbh"].ToString()!="")
					{
					model.old_lsbh=dt.Rows[n]["old_lsbh"].ToString();
					}
					if(dt.Rows[n]["old_krxm"]!=null && dt.Rows[n]["old_krxm"].ToString()!="")
					{
					model.old_krxm=dt.Rows[n]["old_krxm"].ToString();
					}
					if(dt.Rows[n]["old_fjbh"]!=null && dt.Rows[n]["old_fjbh"].ToString()!="")
					{
					model.old_fjbh=dt.Rows[n]["old_fjbh"].ToString();
					}
					if(dt.Rows[n]["id_app"]!=null && dt.Rows[n]["id_app"].ToString()!="")
					{
					model.id_app=dt.Rows[n]["id_app"].ToString();
					}
					if(dt.Rows[n]["xfxm"]!=null && dt.Rows[n]["xfxm"].ToString()!="")
					{
					model.xfxm=dt.Rows[n]["xfxm"].ToString();
					}
					if(dt.Rows[n]["xfzy"]!=null && dt.Rows[n]["xfzy"].ToString()!="")
					{
					model.xfzy=dt.Rows[n]["xfzy"].ToString();
					}
					if(dt.Rows[n]["xfbz"]!=null && dt.Rows[n]["xfbz"].ToString()!="")
					{
					model.xfbz=dt.Rows[n]["xfbz"].ToString();
					}
					if(dt.Rows[n]["sjxfje"]!=null && dt.Rows[n]["sjxfje"].ToString()!="")
					{
						model.sjxfje=decimal.Parse(dt.Rows[n]["sjxfje"].ToString());
					}
					if(dt.Rows[n]["new_lsbh"]!=null && dt.Rows[n]["new_lsbh"].ToString()!="")
					{
					model.new_lsbh=dt.Rows[n]["new_lsbh"].ToString();
					}
					if(dt.Rows[n]["new_krxm"]!=null && dt.Rows[n]["new_krxm"].ToString()!="")
					{
					model.new_krxm=dt.Rows[n]["new_krxm"].ToString();
					}
					if(dt.Rows[n]["new_fjbh"]!=null && dt.Rows[n]["new_fjbh"].ToString()!="")
					{
					model.new_fjbh=dt.Rows[n]["new_fjbh"].ToString();
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["czsj"]!=null && dt.Rows[n]["czsj"].ToString()!="")
					{
						model.czsj=DateTime.Parse(dt.Rows[n]["czsj"].ToString());
					}
					if(dt.Rows[n]["zzrx"]!=null && dt.Rows[n]["zzrx"].ToString()!="")
					{
					model.zzrx=dt.Rows[n]["zzrx"].ToString();
					}
					if(dt.Rows[n]["is_top"]!=null && dt.Rows[n]["is_top"].ToString()!="")
					{
						if((dt.Rows[n]["is_top"].ToString()=="1")||(dt.Rows[n]["is_top"].ToString().ToLower()=="true"))
						{
						model.is_top=true;
						}
						else
						{
							model.is_top=false;
						}
					}
					if(dt.Rows[n]["is_select"]!=null && dt.Rows[n]["is_select"].ToString()!="")
					{
						if((dt.Rows[n]["is_select"].ToString()=="1")||(dt.Rows[n]["is_select"].ToString().ToLower()=="true"))
						{
						model.is_select=true;
						}
						else
						{
							model.is_select=false;
						}
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

