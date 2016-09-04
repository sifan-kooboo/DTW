using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_service.Model;
namespace jdgl_res_head_service.BLL
{
	/// <summary>
	/// Web_Yxydw
	/// </summary>
	public partial class Web_Yxydw
	{
		private readonly jdgl_res_head_service.DAL.Web_Yxydw dal=new jdgl_res_head_service.DAL.Web_Yxydw();
		public Web_Yxydw()
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
		public int  Add(jdgl_res_head_service.Model.Web_Yxydw model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(jdgl_res_head_service.Model.Web_Yxydw model)
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
		public jdgl_res_head_service.Model.Web_Yxydw GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public jdgl_res_head_service.Model.Web_Yxydw GetModelByCache(int id)
		{
			
			string CacheKey = "Web_YxydwModel-" + id;
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
			return (jdgl_res_head_service.Model.Web_Yxydw)objModel;
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
		public List<jdgl_res_head_service.Model.Web_Yxydw> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<jdgl_res_head_service.Model.Web_Yxydw> DataTableToList(DataTable dt)
		{
			List<jdgl_res_head_service.Model.Web_Yxydw> modelList = new List<jdgl_res_head_service.Model.Web_Yxydw>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				jdgl_res_head_service.Model.Web_Yxydw model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new jdgl_res_head_service.Model.Web_Yxydw();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["krly"]!=null && dt.Rows[n]["krly"].ToString()!="")
					{
					model.krly=dt.Rows[n]["krly"].ToString();
					}
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["xyrx"]!=null && dt.Rows[n]["xyrx"].ToString()!="")
					{
					model.xyrx=dt.Rows[n]["xyrx"].ToString();
					}
					if(dt.Rows[n]["krgj"]!=null && dt.Rows[n]["krgj"].ToString()!="")
					{
					model.krgj=dt.Rows[n]["krgj"].ToString();
					}
					if(dt.Rows[n]["pq"]!=null && dt.Rows[n]["pq"].ToString()!="")
					{
					model.pq=dt.Rows[n]["pq"].ToString();
					}
					if(dt.Rows[n]["xyh"]!=null && dt.Rows[n]["xyh"].ToString()!="")
					{
					model.xyh=dt.Rows[n]["xyh"].ToString();
					}
					if(dt.Rows[n]["xyh_inner"]!=null && dt.Rows[n]["xyh_inner"].ToString()!="")
					{
					model.xyh_inner=dt.Rows[n]["xyh_inner"].ToString();
					}
					if(dt.Rows[n]["rx"]!=null && dt.Rows[n]["rx"].ToString()!="")
					{
					model.rx=dt.Rows[n]["rx"].ToString();
					}
					if(dt.Rows[n]["xydw"]!=null && dt.Rows[n]["xydw"].ToString()!="")
					{
					model.xydw=dt.Rows[n]["xydw"].ToString();
					}
					if(dt.Rows[n]["zjm"]!=null && dt.Rows[n]["zjm"].ToString()!="")
					{
					model.zjm=dt.Rows[n]["zjm"].ToString();
					}
					if(dt.Rows[n]["nxr"]!=null && dt.Rows[n]["nxr"].ToString()!="")
					{
					model.nxr=dt.Rows[n]["nxr"].ToString();
					}
					if(dt.Rows[n]["krdh"]!=null && dt.Rows[n]["krdh"].ToString()!="")
					{
					model.krdh=dt.Rows[n]["krdh"].ToString();
					}
					if(dt.Rows[n]["krcz"]!=null && dt.Rows[n]["krcz"].ToString()!="")
					{
					model.krcz=dt.Rows[n]["krcz"].ToString();
					}
					if(dt.Rows[n]["krEmail"]!=null && dt.Rows[n]["krEmail"].ToString()!="")
					{
					model.krEmail=dt.Rows[n]["krEmail"].ToString();
					}
					if(dt.Rows[n]["krdz"]!=null && dt.Rows[n]["krdz"].ToString()!="")
					{
					model.krdz=dt.Rows[n]["krdz"].ToString();
					}
					if(dt.Rows[n]["xsy"]!=null && dt.Rows[n]["xsy"].ToString()!="")
					{
					model.xsy=dt.Rows[n]["xsy"].ToString();
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
					if(dt.Rows[n]["bz"]!=null && dt.Rows[n]["bz"].ToString()!="")
					{
					model.bz=dt.Rows[n]["bz"].ToString();
					}
					if(dt.Rows[n]["lzfs"]!=null && dt.Rows[n]["lzfs"].ToString()!="")
					{
						model.lzfs=decimal.Parse(dt.Rows[n]["lzfs"].ToString());
					}
					if(dt.Rows[n]["fkje"]!=null && dt.Rows[n]["fkje"].ToString()!="")
					{
						model.fkje=decimal.Parse(dt.Rows[n]["fkje"].ToString());
					}
					if(dt.Rows[n]["xfje"]!=null && dt.Rows[n]["xfje"].ToString()!="")
					{
						model.xfje=decimal.Parse(dt.Rows[n]["xfje"].ToString());
					}
					if(dt.Rows[n]["clsj"]!=null && dt.Rows[n]["clsj"].ToString()!="")
					{
						model.clsj=DateTime.Parse(dt.Rows[n]["clsj"].ToString());
					}
					if(dt.Rows[n]["xzxg"]!=null && dt.Rows[n]["xzxg"].ToString()!="")
					{
					model.xzxg=dt.Rows[n]["xzxg"].ToString();
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
					if(dt.Rows[n]["shsh"]!=null && dt.Rows[n]["shsh"].ToString()!="")
					{
						if((dt.Rows[n]["shsh"].ToString()=="1")||(dt.Rows[n]["shsh"].ToString().ToLower()=="true"))
						{
						model.shsh=true;
						}
						else
						{
							model.shsh=false;
						}
					}
					if(dt.Rows[n]["sign_image"]!=null && dt.Rows[n]["sign_image"].ToString()!="")
					{
						model.sign_image=(byte[])dt.Rows[n]["sign_image"];
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

