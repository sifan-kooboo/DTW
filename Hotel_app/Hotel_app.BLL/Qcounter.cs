using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Qcounter
	/// </summary>
	public partial class Qcounter
	{
		private readonly Hotel_app.DAL.Qcounter dal=new Hotel_app.DAL.Qcounter();
		public Qcounter()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hotel_app.Model.Qcounter model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Qcounter model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hotel_app.Model.Qcounter GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Qcounter GetModelByCache(int ID)
		{
			
			string CacheKey = "QcounterModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hotel_app.Model.Qcounter)objModel;
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
		public List<Hotel_app.Model.Qcounter> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Qcounter> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Qcounter> modelList = new List<Hotel_app.Model.Qcounter>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Qcounter model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Qcounter();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["bh"]!=null && dt.Rows[n]["bh"].ToString()!="")
					{
						model.bh=int.Parse(dt.Rows[n]["bh"].ToString());
					}
					if(dt.Rows[n]["skydcounter"]!=null && dt.Rows[n]["skydcounter"].ToString()!="")
					{
						model.skydcounter=int.Parse(dt.Rows[n]["skydcounter"].ToString());
					}
					if(dt.Rows[n]["skyddate"]!=null && dt.Rows[n]["skyddate"].ToString()!="")
					{
						model.skyddate=DateTime.Parse(dt.Rows[n]["skyddate"].ToString());
					}
					if(dt.Rows[n]["skdjcounter"]!=null && dt.Rows[n]["skdjcounter"].ToString()!="")
					{
						model.skdjcounter=int.Parse(dt.Rows[n]["skdjcounter"].ToString());
					}
					if(dt.Rows[n]["skdjdate"]!=null && dt.Rows[n]["skdjdate"].ToString()!="")
					{
						model.skdjdate=DateTime.Parse(dt.Rows[n]["skdjdate"].ToString());
					}
					if(dt.Rows[n]["ttydcounter"]!=null && dt.Rows[n]["ttydcounter"].ToString()!="")
					{
						model.ttydcounter=int.Parse(dt.Rows[n]["ttydcounter"].ToString());
					}
					if(dt.Rows[n]["ttyddate"]!=null && dt.Rows[n]["ttyddate"].ToString()!="")
					{
						model.ttyddate=DateTime.Parse(dt.Rows[n]["ttyddate"].ToString());
					}
					if(dt.Rows[n]["lsttdjcounter"]!=null && dt.Rows[n]["lsttdjcounter"].ToString()!="")
					{
						model.lsttdjcounter=int.Parse(dt.Rows[n]["lsttdjcounter"].ToString());
					}
					if(dt.Rows[n]["ttdjdate"]!=null && dt.Rows[n]["ttdjdate"].ToString()!="")
					{
						model.ttdjdate=DateTime.Parse(dt.Rows[n]["ttdjdate"].ToString());
					}
					if(dt.Rows[n]["ttdjcounter"]!=null && dt.Rows[n]["ttdjcounter"].ToString()!="")
					{
						model.ttdjcounter=int.Parse(dt.Rows[n]["ttdjcounter"].ToString());
					}
					if(dt.Rows[n]["lfcounter"]!=null && dt.Rows[n]["lfcounter"].ToString()!="")
					{
						model.lfcounter=int.Parse(dt.Rows[n]["lfcounter"].ToString());
					}
					if(dt.Rows[n]["lfdate"]!=null && dt.Rows[n]["lfdate"].ToString()!="")
					{
						model.lfdate=DateTime.Parse(dt.Rows[n]["lfdate"].ToString());
					}
					if(dt.Rows[n]["gzcounter"]!=null && dt.Rows[n]["gzcounter"].ToString()!="")
					{
						model.gzcounter=int.Parse(dt.Rows[n]["gzcounter"].ToString());
					}
					if(dt.Rows[n]["gzdate"]!=null && dt.Rows[n]["gzdate"].ToString()!="")
					{
						model.gzdate=DateTime.Parse(dt.Rows[n]["gzdate"].ToString());
					}
					if(dt.Rows[n]["jzcounter"]!=null && dt.Rows[n]["jzcounter"].ToString()!="")
					{
						model.jzcounter=int.Parse(dt.Rows[n]["jzcounter"].ToString());
					}
					if(dt.Rows[n]["jzdate"]!=null && dt.Rows[n]["jzdate"].ToString()!="")
					{
						model.jzdate=DateTime.Parse(dt.Rows[n]["jzdate"].ToString());
					}
					if(dt.Rows[n]["szcounter"]!=null && dt.Rows[n]["szcounter"].ToString()!="")
					{
						model.szcounter=int.Parse(dt.Rows[n]["szcounter"].ToString());
					}
					if(dt.Rows[n]["szdate"]!=null && dt.Rows[n]["szdate"].ToString()!="")
					{
						model.szdate=DateTime.Parse(dt.Rows[n]["szdate"].ToString());
					}
					if(dt.Rows[n]["qs"]!=null && dt.Rows[n]["qs"].ToString()!="")
					{
						model.qs=int.Parse(dt.Rows[n]["qs"].ToString());
					}
					if(dt.Rows[n]["qsdate"]!=null && dt.Rows[n]["qsdate"].ToString()!="")
					{
						model.qsdate=DateTime.Parse(dt.Rows[n]["qsdate"].ToString());
					}
					if(dt.Rows[n]["jbdate"]!=null && dt.Rows[n]["jbdate"].ToString()!="")
					{
						model.jbdate=DateTime.Parse(dt.Rows[n]["jbdate"].ToString());
					}
					if(dt.Rows[n]["jbcounter"]!=null && dt.Rows[n]["jbcounter"].ToString()!="")
					{
						model.jbcounter=int.Parse(dt.Rows[n]["jbcounter"].ToString());
					}
					if(dt.Rows[n]["zdpf"]!=null && dt.Rows[n]["zdpf"].ToString()!="")
					{
						if((dt.Rows[n]["zdpf"].ToString()=="1")||(dt.Rows[n]["zdpf"].ToString().ToLower()=="true"))
						{
						model.zdpf=true;
						}
						else
						{
							model.zdpf=false;
						}
					}
					if(dt.Rows[n]["shys"]!=null && dt.Rows[n]["shys"].ToString()!="")
					{
						if((dt.Rows[n]["shys"].ToString()=="1")||(dt.Rows[n]["shys"].ToString().ToLower()=="true"))
						{
						model.shys=true;
						}
						else
						{
							model.shys=false;
						}
					}
					if(dt.Rows[n]["zhbbsj"]!=null && dt.Rows[n]["zhbbsj"].ToString()!="")
					{
						model.zhbbsj=DateTime.Parse(dt.Rows[n]["zhbbsj"].ToString());
					}
					if(dt.Rows[n]["txftsl"]!=null && dt.Rows[n]["txftsl"].ToString()!="")
					{
						model.txftsl=int.Parse(dt.Rows[n]["txftsl"].ToString());
					}
					if(dt.Rows[n]["shgz"]!=null && dt.Rows[n]["shgz"].ToString()!="")
					{
						model.shgz=int.Parse(dt.Rows[n]["shgz"].ToString());
					}
					if(dt.Rows[n]["ybtqts"]!=null && dt.Rows[n]["ybtqts"].ToString()!="")
					{
						model.ybtqts=int.Parse(dt.Rows[n]["ybtqts"].ToString());
					}
					if(dt.Rows[n]["hycounter"]!=null && dt.Rows[n]["hycounter"].ToString()!="")
					{
						model.hycounter=int.Parse(dt.Rows[n]["hycounter"].ToString());
					}
					if(dt.Rows[n]["hydate"]!=null && dt.Rows[n]["hydate"].ToString()!="")
					{
						model.hydate=DateTime.Parse(dt.Rows[n]["hydate"].ToString());
					}
					if(dt.Rows[n]["lsbhcounter"]!=null && dt.Rows[n]["lsbhcounter"].ToString()!="")
					{
						model.lsbhcounter=int.Parse(dt.Rows[n]["lsbhcounter"].ToString());
					}
					if(dt.Rows[n]["lsbhdate"]!=null && dt.Rows[n]["lsbhdate"].ToString()!="")
					{
						model.lsbhdate=DateTime.Parse(dt.Rows[n]["lsbhdate"].ToString());
					}
					if(dt.Rows[n]["scsj"]!=null && dt.Rows[n]["scsj"].ToString()!="")
					{
						model.scsj=DateTime.Parse(dt.Rows[n]["scsj"].ToString());
					}
					if(dt.Rows[n]["zjk"]!=null && dt.Rows[n]["zjk"].ToString()!="")
					{
						model.zjk=decimal.Parse(dt.Rows[n]["zjk"].ToString());
					}
					if(dt.Rows[n]["zbjk"]!=null && dt.Rows[n]["zbjk"].ToString()!="")
					{
						model.zbjk=decimal.Parse(dt.Rows[n]["zbjk"].ToString());
					}
					if(dt.Rows[n]["xzsj"]!=null && dt.Rows[n]["xzsj"].ToString()!="")
					{
						model.xzsj=DateTime.Parse(dt.Rows[n]["xzsj"].ToString());
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
					if(dt.Rows[n]["scbz"]!=null && dt.Rows[n]["scbz"].ToString()!="")
					{
					model.scbz=dt.Rows[n]["scbz"].ToString();
					}
					if(dt.Rows[n]["jsbtsj"]!=null && dt.Rows[n]["jsbtsj"].ToString()!="")
					{
						model.jsbtsj=DateTime.Parse(dt.Rows[n]["jsbtsj"].ToString());
					}
					if(dt.Rows[n]["jsqtsj"]!=null && dt.Rows[n]["jsqtsj"].ToString()!="")
					{
						model.jsqtsj=DateTime.Parse(dt.Rows[n]["jsqtsj"].ToString());
					}
					if(dt.Rows[n]["tjkffs"]!=null && dt.Rows[n]["tjkffs"].ToString()!="")
					{
						model.tjkffs=int.Parse(dt.Rows[n]["tjkffs"].ToString());
					}
					if(dt.Rows[n]["xydwdate"]!=null && dt.Rows[n]["xydwdate"].ToString()!="")
					{
						model.xydwdate=DateTime.Parse(dt.Rows[n]["xydwdate"].ToString());
					}
					if(dt.Rows[n]["xydwcounter"]!=null && dt.Rows[n]["xydwcounter"].ToString()!="")
					{
						model.xydwcounter=int.Parse(dt.Rows[n]["xydwcounter"].ToString());
					}
					if(dt.Rows[n]["printzdpd"]!=null && dt.Rows[n]["printzdpd"].ToString()!="")
					{
						model.printzdpd=int.Parse(dt.Rows[n]["printzdpd"].ToString());
					}
					if(dt.Rows[n]["hyjfrxpd"]!=null && dt.Rows[n]["hyjfrxpd"].ToString()!="")
					{
						model.hyjfrxpd=int.Parse(dt.Rows[n]["hyjfrxpd"].ToString());
					}
					if(dt.Rows[n]["eating_time"]!=null && dt.Rows[n]["eating_time"].ToString()!="")
					{
						model.eating_time=int.Parse(dt.Rows[n]["eating_time"].ToString());
					}
					if(dt.Rows[n]["xsws"]!=null && dt.Rows[n]["xsws"].ToString()!="")
					{
						model.xsws=int.Parse(dt.Rows[n]["xsws"].ToString());
					}
					if(dt.Rows[n]["shlz"]!=null && dt.Rows[n]["shlz"].ToString()!="")
					{
						if((dt.Rows[n]["shlz"].ToString()=="1")||(dt.Rows[n]["shlz"].ToString().ToLower()=="true"))
						{
						model.shlz=true;
						}
						else
						{
							model.shlz=false;
						}
					}
					if(dt.Rows[n]["lsbhdfcounter"]!=null && dt.Rows[n]["lsbhdfcounter"].ToString()!="")
					{
						model.lsbhdfcounter=int.Parse(dt.Rows[n]["lsbhdfcounter"].ToString());
					}
					if(dt.Rows[n]["lsbhdfdate"]!=null && dt.Rows[n]["lsbhdfdate"].ToString()!="")
					{
						model.lsbhdfdate=DateTime.Parse(dt.Rows[n]["lsbhdfdate"].ToString());
					}
					if(dt.Rows[n]["ff_xfsj_rx"]!=null && dt.Rows[n]["ff_xfsj_rx"].ToString()!="")
					{
						model.ff_xfsj_rx=int.Parse(dt.Rows[n]["ff_xfsj_rx"].ToString());
					}
					if(dt.Rows[n]["ysk_pc"]!=null && dt.Rows[n]["ysk_pc"].ToString()!="")
					{
						model.ysk_pc=int.Parse(dt.Rows[n]["ysk_pc"].ToString());
					}
					if(dt.Rows[n]["ft_xs_krxm"]!=null && dt.Rows[n]["ft_xs_krxm"].ToString()!="")
					{
						if((dt.Rows[n]["ft_xs_krxm"].ToString()=="1")||(dt.Rows[n]["ft_xs_krxm"].ToString().ToLower()=="true"))
						{
						model.ft_xs_krxm=true;
						}
						else
						{
							model.ft_xs_krxm=false;
						}
					}
					if(dt.Rows[n]["ft_xs_fjjg"]!=null && dt.Rows[n]["ft_xs_fjjg"].ToString()!="")
					{
						if((dt.Rows[n]["ft_xs_fjjg"].ToString()=="1")||(dt.Rows[n]["ft_xs_fjjg"].ToString().ToLower()=="true"))
						{
						model.ft_xs_fjjg=true;
						}
						else
						{
							model.ft_xs_fjjg=false;
						}
					}
					if(dt.Rows[n]["ft_auto_refresh"]!=null && dt.Rows[n]["ft_auto_refresh"].ToString()!="")
					{
						if((dt.Rows[n]["ft_auto_refresh"].ToString()=="1")||(dt.Rows[n]["ft_auto_refresh"].ToString().ToLower()=="true"))
						{
						model.ft_auto_refresh=true;
						}
						else
						{
							model.ft_auto_refresh=false;
						}
					}
					if(dt.Rows[n]["jz_ts"]!=null && dt.Rows[n]["jz_ts"].ToString()!="")
					{
						model.jz_ts=int.Parse(dt.Rows[n]["jz_ts"].ToString());
					}
					if(dt.Rows[n]["jz_ls_total"]!=null && dt.Rows[n]["jz_ls_total"].ToString()!="")
					{
						model.jz_ls_total=decimal.Parse(dt.Rows[n]["jz_ls_total"].ToString());
					}
					if(dt.Rows[n]["Hhygl_qyqr"]!=null && dt.Rows[n]["Hhygl_qyqr"].ToString()!="")
					{
						if((dt.Rows[n]["Hhygl_qyqr"].ToString()=="1")||(dt.Rows[n]["Hhygl_qyqr"].ToString().ToLower()=="true"))
						{
						model.Hhygl_qyqr=true;
						}
						else
						{
							model.Hhygl_qyqr=false;
						}
					}
					if(dt.Rows[n]["VersionType"]!=null && dt.Rows[n]["VersionType"].ToString()!="")
					{
					model.VersionType=dt.Rows[n]["VersionType"].ToString();
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

