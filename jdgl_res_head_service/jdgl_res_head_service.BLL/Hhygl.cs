using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_service.Model;
namespace jdgl_res_head_service.BLL
{
	/// <summary>
	/// Hhygl
	/// </summary>
	public partial class Hhygl
	{
		private readonly jdgl_res_head_service.DAL.Hhygl dal=new jdgl_res_head_service.DAL.Hhygl();
		public Hhygl()
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
		public int  Add(jdgl_res_head_service.Model.Hhygl model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(jdgl_res_head_service.Model.Hhygl model)
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
		public jdgl_res_head_service.Model.Hhygl GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public jdgl_res_head_service.Model.Hhygl GetModelByCache(int id)
		{
			
			string CacheKey = "HhyglModel-" + id;
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
			return (jdgl_res_head_service.Model.Hhygl)objModel;
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
		public List<jdgl_res_head_service.Model.Hhygl> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<jdgl_res_head_service.Model.Hhygl> DataTableToList(DataTable dt)
		{
			List<jdgl_res_head_service.Model.Hhygl> modelList = new List<jdgl_res_head_service.Model.Hhygl>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				jdgl_res_head_service.Model.Hhygl model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new jdgl_res_head_service.Model.Hhygl();
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
					if(dt.Rows[n]["hyrx"]!=null && dt.Rows[n]["hyrx"].ToString()!="")
					{
					model.hyrx=dt.Rows[n]["hyrx"].ToString();
					}
					if(dt.Rows[n]["hykh"]!=null && dt.Rows[n]["hykh"].ToString()!="")
					{
					model.hykh=dt.Rows[n]["hykh"].ToString();
					}
					if(dt.Rows[n]["hykh_bz"]!=null && dt.Rows[n]["hykh_bz"].ToString()!="")
					{
					model.hykh_bz=dt.Rows[n]["hykh_bz"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["krgj"]!=null && dt.Rows[n]["krgj"].ToString()!="")
					{
					model.krgj=dt.Rows[n]["krgj"].ToString();
					}
					if(dt.Rows[n]["krmz"]!=null && dt.Rows[n]["krmz"].ToString()!="")
					{
					model.krmz=dt.Rows[n]["krmz"].ToString();
					}
					if(dt.Rows[n]["yxzj"]!=null && dt.Rows[n]["yxzj"].ToString()!="")
					{
					model.yxzj=dt.Rows[n]["yxzj"].ToString();
					}
					if(dt.Rows[n]["zjhm"]!=null && dt.Rows[n]["zjhm"].ToString()!="")
					{
					model.zjhm=dt.Rows[n]["zjhm"].ToString();
					}
					if(dt.Rows[n]["krsr"]!=null && dt.Rows[n]["krsr"].ToString()!="")
					{
						model.krsr=DateTime.Parse(dt.Rows[n]["krsr"].ToString());
					}
					if(dt.Rows[n]["krxb"]!=null && dt.Rows[n]["krxb"].ToString()!="")
					{
					model.krxb=dt.Rows[n]["krxb"].ToString();
					}
					if(dt.Rows[n]["krdh"]!=null && dt.Rows[n]["krdh"].ToString()!="")
					{
					model.krdh=dt.Rows[n]["krdh"].ToString();
					}
					if(dt.Rows[n]["krsj"]!=null && dt.Rows[n]["krsj"].ToString()!="")
					{
					model.krsj=dt.Rows[n]["krsj"].ToString();
					}
					if(dt.Rows[n]["krEmail"]!=null && dt.Rows[n]["krEmail"].ToString()!="")
					{
					model.krEmail=dt.Rows[n]["krEmail"].ToString();
					}
					if(dt.Rows[n]["krdz"]!=null && dt.Rows[n]["krdz"].ToString()!="")
					{
					model.krdz=dt.Rows[n]["krdz"].ToString();
					}
					if(dt.Rows[n]["krzy"]!=null && dt.Rows[n]["krzy"].ToString()!="")
					{
					model.krzy=dt.Rows[n]["krzy"].ToString();
					}
					if(dt.Rows[n]["krdw"]!=null && dt.Rows[n]["krdw"].ToString()!="")
					{
					model.krdw=dt.Rows[n]["krdw"].ToString();
					}
					if(dt.Rows[n]["qzrx"]!=null && dt.Rows[n]["qzrx"].ToString()!="")
					{
					model.qzrx=dt.Rows[n]["qzrx"].ToString();
					}
					if(dt.Rows[n]["qzhm"]!=null && dt.Rows[n]["qzhm"].ToString()!="")
					{
					model.qzhm=dt.Rows[n]["qzhm"].ToString();
					}
					if(dt.Rows[n]["zjyxq"]!=null && dt.Rows[n]["zjyxq"].ToString()!="")
					{
						model.zjyxq=DateTime.Parse(dt.Rows[n]["zjyxq"].ToString());
					}
					if(dt.Rows[n]["tlyxq"]!=null && dt.Rows[n]["tlyxq"].ToString()!="")
					{
						model.tlyxq=DateTime.Parse(dt.Rows[n]["tlyxq"].ToString());
					}
					if(dt.Rows[n]["tjrq"]!=null && dt.Rows[n]["tjrq"].ToString()!="")
					{
						model.tjrq=DateTime.Parse(dt.Rows[n]["tjrq"].ToString());
					}
					if(dt.Rows[n]["lzka"]!=null && dt.Rows[n]["lzka"].ToString()!="")
					{
					model.lzka=dt.Rows[n]["lzka"].ToString();
					}
					if(dt.Rows[n]["bz"]!=null && dt.Rows[n]["bz"].ToString()!="")
					{
					model.bz=dt.Rows[n]["bz"].ToString();
					}
					if(dt.Rows[n]["djsj"]!=null && dt.Rows[n]["djsj"].ToString()!="")
					{
						model.djsj=DateTime.Parse(dt.Rows[n]["djsj"].ToString());
					}
					if(dt.Rows[n]["hyjf"]!=null && dt.Rows[n]["hyjf"].ToString()!="")
					{
						model.hyjf=decimal.Parse(dt.Rows[n]["hyjf"].ToString());
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
					if(dt.Rows[n]["xgsj"]!=null && dt.Rows[n]["xgsj"].ToString()!="")
					{
						model.xgsj=DateTime.Parse(dt.Rows[n]["xgsj"].ToString());
					}
					if(dt.Rows[n]["shxg"]!=null && dt.Rows[n]["shxg"].ToString()!="")
					{
						if((dt.Rows[n]["shxg"].ToString()=="1")||(dt.Rows[n]["shxg"].ToString().ToLower()=="true"))
						{
						model.shxg=true;
						}
						else
						{
							model.shxg=false;
						}
					}
					if(dt.Rows[n]["shqr"]!=null && dt.Rows[n]["shqr"].ToString()!="")
					{
						if((dt.Rows[n]["shqr"].ToString()=="1")||(dt.Rows[n]["shqr"].ToString().ToLower()=="true"))
						{
						model.shqr=true;
						}
						else
						{
							model.shqr=false;
						}
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
					if(dt.Rows[n]["fkje"]!=null && dt.Rows[n]["fkje"].ToString()!="")
					{
						model.fkje=decimal.Parse(dt.Rows[n]["fkje"].ToString());
					}
					if(dt.Rows[n]["parent_hykh"]!=null && dt.Rows[n]["parent_hykh"].ToString()!="")
					{
					model.parent_hykh=dt.Rows[n]["parent_hykh"].ToString();
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

