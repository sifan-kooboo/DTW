using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_app.Model;
namespace jdgl_res_head_app.BLL
{
	/// <summary>
	/// Qskyd_mainrecord_lskr
	/// </summary>
	public partial class Qskyd_mainrecord_lskr
	{
		private readonly jdgl_res_head_app.DAL.Qskyd_mainrecord_lskr dal=new jdgl_res_head_app.DAL.Qskyd_mainrecord_lskr();
		public Qskyd_mainrecord_lskr()
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
		public int  Add(jdgl_res_head_app.Model.Qskyd_mainrecord_lskr model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(jdgl_res_head_app.Model.Qskyd_mainrecord_lskr model)
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
		public jdgl_res_head_app.Model.Qskyd_mainrecord_lskr GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public jdgl_res_head_app.Model.Qskyd_mainrecord_lskr GetModelByCache(int id)
		{
			
			string CacheKey = "Qskyd_mainrecord_lskrModel-" + id;
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
			return (jdgl_res_head_app.Model.Qskyd_mainrecord_lskr)objModel;
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
		public List<jdgl_res_head_app.Model.Qskyd_mainrecord_lskr> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<jdgl_res_head_app.Model.Qskyd_mainrecord_lskr> DataTableToList(DataTable dt)
		{
			List<jdgl_res_head_app.Model.Qskyd_mainrecord_lskr> modelList = new List<jdgl_res_head_app.Model.Qskyd_mainrecord_lskr>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				jdgl_res_head_app.Model.Qskyd_mainrecord_lskr model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new jdgl_res_head_app.Model.Qskyd_mainrecord_lskr();
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
					if(dt.Rows[n]["jzbh"]!=null && dt.Rows[n]["jzbh"].ToString()!="")
					{
					model.jzbh=dt.Rows[n]["jzbh"].ToString();
					}
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
					}
					if(dt.Rows[n]["ddbh"]!=null && dt.Rows[n]["ddbh"].ToString()!="")
					{
					model.ddbh=dt.Rows[n]["ddbh"].ToString();
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
					if(dt.Rows[n]["hykh"]!=null && dt.Rows[n]["hykh"].ToString()!="")
					{
					model.hykh=dt.Rows[n]["hykh"].ToString();
					}
					if(dt.Rows[n]["hyrx"]!=null && dt.Rows[n]["hyrx"].ToString()!="")
					{
					model.hyrx=dt.Rows[n]["hyrx"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["tlkr"]!=null && dt.Rows[n]["tlkr"].ToString()!="")
					{
					model.tlkr=dt.Rows[n]["tlkr"].ToString();
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
					if(dt.Rows[n]["krxb"]!=null && dt.Rows[n]["krxb"].ToString()!="")
					{
					model.krxb=dt.Rows[n]["krxb"].ToString();
					}
					if(dt.Rows[n]["krsr"]!=null && dt.Rows[n]["krsr"].ToString()!="")
					{
						model.krsr=DateTime.Parse(dt.Rows[n]["krsr"].ToString());
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
					if(dt.Rows[n]["krjg"]!=null && dt.Rows[n]["krjg"].ToString()!="")
					{
					model.krjg=dt.Rows[n]["krjg"].ToString();
					}
					if(dt.Rows[n]["krdw"]!=null && dt.Rows[n]["krdw"].ToString()!="")
					{
					model.krdw=dt.Rows[n]["krdw"].ToString();
					}
					if(dt.Rows[n]["krzy"]!=null && dt.Rows[n]["krzy"].ToString()!="")
					{
					model.krzy=dt.Rows[n]["krzy"].ToString();
					}
					if(dt.Rows[n]["cxmd"]!=null && dt.Rows[n]["cxmd"].ToString()!="")
					{
					model.cxmd=dt.Rows[n]["cxmd"].ToString();
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
					if(dt.Rows[n]["krly"]!=null && dt.Rows[n]["krly"].ToString()!="")
					{
					model.krly=dt.Rows[n]["krly"].ToString();
					}
					if(dt.Rows[n]["xyh"]!=null && dt.Rows[n]["xyh"].ToString()!="")
					{
					model.xyh=dt.Rows[n]["xyh"].ToString();
					}
					if(dt.Rows[n]["xydw"]!=null && dt.Rows[n]["xydw"].ToString()!="")
					{
					model.xydw=dt.Rows[n]["xydw"].ToString();
					}
					if(dt.Rows[n]["xsy"]!=null && dt.Rows[n]["xsy"].ToString()!="")
					{
					model.xsy=dt.Rows[n]["xsy"].ToString();
					}
					if(dt.Rows[n]["ddrx"]!=null && dt.Rows[n]["ddrx"].ToString()!="")
					{
					model.ddrx=dt.Rows[n]["ddrx"].ToString();
					}
					if(dt.Rows[n]["ddwz"]!=null && dt.Rows[n]["ddwz"].ToString()!="")
					{
					model.ddwz=dt.Rows[n]["ddwz"].ToString();
					}
					if(dt.Rows[n]["zyzt"]!=null && dt.Rows[n]["zyzt"].ToString()!="")
					{
					model.zyzt=dt.Rows[n]["zyzt"].ToString();
					}
					if(dt.Rows[n]["krrx"]!=null && dt.Rows[n]["krrx"].ToString()!="")
					{
					model.krrx=dt.Rows[n]["krrx"].ToString();
					}
					if(dt.Rows[n]["kr_children"]!=null && dt.Rows[n]["kr_children"].ToString()!="")
					{
						model.kr_children=int.Parse(dt.Rows[n]["kr_children"].ToString());
					}
					if(dt.Rows[n]["ddsj"]!=null && dt.Rows[n]["ddsj"].ToString()!="")
					{
						model.ddsj=DateTime.Parse(dt.Rows[n]["ddsj"].ToString());
					}
					if(dt.Rows[n]["ddyy"]!=null && dt.Rows[n]["ddyy"].ToString()!="")
					{
					model.ddyy=dt.Rows[n]["ddyy"].ToString();
					}
					if(dt.Rows[n]["lzts"]!=null && dt.Rows[n]["lzts"].ToString()!="")
					{
						model.lzts=int.Parse(dt.Rows[n]["lzts"].ToString());
					}
					if(dt.Rows[n]["lksj"]!=null && dt.Rows[n]["lksj"].ToString()!="")
					{
						model.lksj=DateTime.Parse(dt.Rows[n]["lksj"].ToString());
					}
					if(dt.Rows[n]["qtyq"]!=null && dt.Rows[n]["qtyq"].ToString()!="")
					{
					model.qtyq=dt.Rows[n]["qtyq"].ToString();
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["czsj"]!=null && dt.Rows[n]["czsj"].ToString()!="")
					{
						model.czsj=DateTime.Parse(dt.Rows[n]["czsj"].ToString());
					}
					if(dt.Rows[n]["cznr"]!=null && dt.Rows[n]["cznr"].ToString()!="")
					{
					model.cznr=dt.Rows[n]["cznr"].ToString();
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
					if(dt.Rows[n]["sktt"]!=null && dt.Rows[n]["sktt"].ToString()!="")
					{
					model.sktt=dt.Rows[n]["sktt"].ToString();
					}
					if(dt.Rows[n]["yddj"]!=null && dt.Rows[n]["yddj"].ToString()!="")
					{
					model.yddj=dt.Rows[n]["yddj"].ToString();
					}
					if(dt.Rows[n]["ffshys"]!=null && dt.Rows[n]["ffshys"].ToString()!="")
					{
						if((dt.Rows[n]["ffshys"].ToString()=="1")||(dt.Rows[n]["ffshys"].ToString().ToLower()=="true"))
						{
						model.ffshys=true;
						}
						else
						{
							model.ffshys=false;
						}
					}
					if(dt.Rows[n]["ffzf"]!=null && dt.Rows[n]["ffzf"].ToString()!="")
					{
						if((dt.Rows[n]["ffzf"].ToString()=="1")||(dt.Rows[n]["ffzf"].ToString().ToLower()=="true"))
						{
						model.ffzf=true;
						}
						else
						{
							model.ffzf=false;
						}
					}
					if(dt.Rows[n]["main_sec"]!=null && dt.Rows[n]["main_sec"].ToString()!="")
					{
					model.main_sec=dt.Rows[n]["main_sec"].ToString();
					}
					if(dt.Rows[n]["sdcz"]!=null && dt.Rows[n]["sdcz"].ToString()!="")
					{
						if((dt.Rows[n]["sdcz"].ToString()=="1")||(dt.Rows[n]["sdcz"].ToString().ToLower()=="true"))
						{
						model.sdcz=true;
						}
						else
						{
							model.sdcz=false;
						}
					}
					if(dt.Rows[n]["syzd"]!=null && dt.Rows[n]["syzd"].ToString()!="")
					{
					model.syzd=dt.Rows[n]["syzd"].ToString();
					}
					if(dt.Rows[n]["vip_type"]!=null && dt.Rows[n]["vip_type"].ToString()!="")
					{
					model.vip_type=dt.Rows[n]["vip_type"].ToString();
					}
					if(dt.Rows[n]["tsyq"]!=null && dt.Rows[n]["tsyq"].ToString()!="")
					{
					model.tsyq=dt.Rows[n]["tsyq"].ToString();
					}
					if(dt.Rows[n]["is_visible"]!=null && dt.Rows[n]["is_visible"].ToString()!="")
					{
						if((dt.Rows[n]["is_visible"].ToString()=="1")||(dt.Rows[n]["is_visible"].ToString().ToLower()=="true"))
						{
						model.is_visible=true;
						}
						else
						{
							model.is_visible=false;
						}
					}
					if(dt.Rows[n]["ddly"]!=null && dt.Rows[n]["ddly"].ToString()!="")
					{
					model.ddly=dt.Rows[n]["ddly"].ToString();
					}
					if(dt.Rows[n]["hykh_bz"]!=null && dt.Rows[n]["hykh_bz"].ToString()!="")
					{
					model.hykh_bz=dt.Rows[n]["hykh_bz"].ToString();
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

