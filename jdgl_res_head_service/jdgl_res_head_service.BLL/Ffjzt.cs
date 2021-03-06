﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_service.Model;
namespace jdgl_res_head_service.BLL
{
	/// <summary>
	/// Ffjzt
	/// </summary>
	public partial class Ffjzt
	{
		private readonly jdgl_res_head_service.DAL.Ffjzt dal=new jdgl_res_head_service.DAL.Ffjzt();
		public Ffjzt()
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
		public int  Add(jdgl_res_head_service.Model.Ffjzt model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(jdgl_res_head_service.Model.Ffjzt model)
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
		public jdgl_res_head_service.Model.Ffjzt GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public jdgl_res_head_service.Model.Ffjzt GetModelByCache(int id)
		{
			
			string CacheKey = "FfjztModel-" + id;
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
			return (jdgl_res_head_service.Model.Ffjzt)objModel;
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
		public List<jdgl_res_head_service.Model.Ffjzt> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<jdgl_res_head_service.Model.Ffjzt> DataTableToList(DataTable dt)
		{
			List<jdgl_res_head_service.Model.Ffjzt> modelList = new List<jdgl_res_head_service.Model.Ffjzt>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				jdgl_res_head_service.Model.Ffjzt model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new jdgl_res_head_service.Model.Ffjzt();
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
					if(dt.Rows[n]["zyzt"]!=null && dt.Rows[n]["zyzt"].ToString()!="")
					{
					model.zyzt=dt.Rows[n]["zyzt"].ToString();
					}
					if(dt.Rows[n]["zyzt_second"]!=null && dt.Rows[n]["zyzt_second"].ToString()!="")
					{
					model.zyzt_second=dt.Rows[n]["zyzt_second"].ToString();
					}
					if(dt.Rows[n]["zybz"]!=null && dt.Rows[n]["zybz"].ToString()!="")
					{
					model.zybz=dt.Rows[n]["zybz"].ToString();
					}
					if(dt.Rows[n]["fjrb_code"]!=null && dt.Rows[n]["fjrb_code"].ToString()!="")
					{
					model.fjrb_code=dt.Rows[n]["fjrb_code"].ToString();
					}
					if(dt.Rows[n]["fjrb"]!=null && dt.Rows[n]["fjrb"].ToString()!="")
					{
					model.fjrb=dt.Rows[n]["fjrb"].ToString();
					}
					if(dt.Rows[n]["fjbh"]!=null && dt.Rows[n]["fjbh"].ToString()!="")
					{
					model.fjbh=dt.Rows[n]["fjbh"].ToString();
					}
					if(dt.Rows[n]["fjdh"]!=null && dt.Rows[n]["fjdh"].ToString()!="")
					{
					model.fjdh=dt.Rows[n]["fjdh"].ToString();
					}
					if(dt.Rows[n]["dhfj"]!=null && dt.Rows[n]["dhfj"].ToString()!="")
					{
					model.dhfj=dt.Rows[n]["dhfj"].ToString();
					}
					if(dt.Rows[n]["jdlh"]!=null && dt.Rows[n]["jdlh"].ToString()!="")
					{
					model.jdlh=dt.Rows[n]["jdlh"].ToString();
					}
					if(dt.Rows[n]["jdlh_name"]!=null && dt.Rows[n]["jdlh_name"].ToString()!="")
					{
					model.jdlh_name=dt.Rows[n]["jdlh_name"].ToString();
					}
					if(dt.Rows[n]["jdcs"]!=null && dt.Rows[n]["jdcs"].ToString()!="")
					{
					model.jdcs=dt.Rows[n]["jdcs"].ToString();
					}
					if(dt.Rows[n]["jdcs_name"]!=null && dt.Rows[n]["jdcs_name"].ToString()!="")
					{
					model.jdcs_name=dt.Rows[n]["jdcs_name"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["ddsj"]!=null && dt.Rows[n]["ddsj"].ToString()!="")
					{
						model.ddsj=DateTime.Parse(dt.Rows[n]["ddsj"].ToString());
					}
					if(dt.Rows[n]["lksj"]!=null && dt.Rows[n]["lksj"].ToString()!="")
					{
						model.lksj=DateTime.Parse(dt.Rows[n]["lksj"].ToString());
					}
					if(dt.Rows[n]["yd_ddsj"]!=null && dt.Rows[n]["yd_ddsj"].ToString()!="")
					{
						model.yd_ddsj=DateTime.Parse(dt.Rows[n]["yd_ddsj"].ToString());
					}
					if(dt.Rows[n]["yd_lksj"]!=null && dt.Rows[n]["yd_lksj"].ToString()!="")
					{
						model.yd_lksj=DateTime.Parse(dt.Rows[n]["yd_lksj"].ToString());
					}
					if(dt.Rows[n]["bz"]!=null && dt.Rows[n]["bz"].ToString()!="")
					{
					model.bz=dt.Rows[n]["bz"].ToString();
					}
					if(dt.Rows[n]["shlf"]!=null && dt.Rows[n]["shlf"].ToString()!="")
					{
						if((dt.Rows[n]["shlf"].ToString()=="1")||(dt.Rows[n]["shlf"].ToString().ToLower()=="true"))
						{
						model.shlf=true;
						}
						else
						{
							model.shlf=false;
						}
					}
					if(dt.Rows[n]["shts"]!=null && dt.Rows[n]["shts"].ToString()!="")
					{
						if((dt.Rows[n]["shts"].ToString()=="1")||(dt.Rows[n]["shts"].ToString().ToLower()=="true"))
						{
						model.shts=true;
						}
						else
						{
							model.shts=false;
						}
					}
					if(dt.Rows[n]["shvip"]!=null && dt.Rows[n]["shvip"].ToString()!="")
					{
						if((dt.Rows[n]["shvip"].ToString()=="1")||(dt.Rows[n]["shvip"].ToString().ToLower()=="true"))
						{
						model.shvip=true;
						}
						else
						{
							model.shvip=false;
						}
					}
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
					}
					if(dt.Rows[n]["sktt"]!=null && dt.Rows[n]["sktt"].ToString()!="")
					{
					model.sktt=dt.Rows[n]["sktt"].ToString();
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
					if(dt.Rows[n]["use_time"]!=null && dt.Rows[n]["use_time"].ToString()!="")
					{
						model.use_time=decimal.Parse(dt.Rows[n]["use_time"].ToString());
					}
					if(dt.Rows[n]["is_secret"]!=null && dt.Rows[n]["is_secret"].ToString()!="")
					{
						if((dt.Rows[n]["is_secret"].ToString()=="1")||(dt.Rows[n]["is_secret"].ToString().ToLower()=="true"))
						{
						model.is_secret=true;
						}
						else
						{
							model.is_secret=false;
						}
					}
					if(dt.Rows[n]["czsj"]!=null && dt.Rows[n]["czsj"].ToString()!="")
					{
						model.czsj=DateTime.Parse(dt.Rows[n]["czsj"].ToString());
					}
					if(dt.Rows[n]["cznr"]!=null && dt.Rows[n]["cznr"].ToString()!="")
					{
					model.cznr=dt.Rows[n]["cznr"].ToString();
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["fjbm"]!=null && dt.Rows[n]["fjbm"].ToString()!="")
					{
						if((dt.Rows[n]["fjbm"].ToString()=="1")||(dt.Rows[n]["fjbm"].ToString().ToLower()=="true"))
						{
						model.fjbm=true;
						}
						else
						{
							model.fjbm=false;
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

