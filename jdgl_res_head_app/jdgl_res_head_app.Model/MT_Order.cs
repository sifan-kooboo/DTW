/**  版本信息模板在安装目录下，可自行修改。
* MT_Order.cs
*
* 功 能： N/A
* 类 名： MT_Order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-06-15 12:55:10   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// MT_Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MT_Order
	{
		public MT_Order()
		{}
		#region Model
		private int _id;
		private int _channel_id;
		private int _category_id;
		private string _order_lsbh;
		private int _user_id;
		private int _fjrx_id;
		private string _yd_name;
		private string _yd_sex;
		private string _yd_mobile;
		private string _yd_email;
		private int _crs;
		private int _xhrs;
		private string _yd_ddsj;
		private int _yd_js;
		private string _content;
		private decimal _yd_ts;
		private decimal _yd_jg;
		private DateTime _yd_statetime;
		private DateTime _yd_endtime;
		private int _is_rz;
		private int _state;
		private DateTime _add_time;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int channel_id
		{
			set{ _channel_id=value;}
			get{return _channel_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int category_id
		{
			set{ _category_id=value;}
			get{return _category_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string order_lsbh
		{
			set{ _order_lsbh=value;}
			get{return _order_lsbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fjrx_id
		{
			set{ _fjrx_id=value;}
			get{return _fjrx_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yd_name
		{
			set{ _yd_name=value;}
			get{return _yd_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yd_sex
		{
			set{ _yd_sex=value;}
			get{return _yd_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yd_mobile
		{
			set{ _yd_mobile=value;}
			get{return _yd_mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yd_email
		{
			set{ _yd_email=value;}
			get{return _yd_email;}
		}
		/// <summary>
		/// 成人数
		/// </summary>
		public int crs
		{
			set{ _crs=value;}
			get{return _crs;}
		}
		/// <summary>
		/// 小孩数
		/// </summary>
		public int xhrs
		{
			set{ _xhrs=value;}
			get{return _xhrs;}
		}
		/// <summary>
		/// 预计到达时间
		/// </summary>
		public string yd_ddsj
		{
			set{ _yd_ddsj=value;}
			get{return _yd_ddsj;}
		}
		/// <summary>
		/// 预订间数
		/// </summary>
		public int yd_js
		{
			set{ _yd_js=value;}
			get{return _yd_js;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 预订天数
		/// </summary>
		public decimal yd_ts
		{
			set{ _yd_ts=value;}
			get{return _yd_ts;}
		}
		/// <summary>
		/// 预订总价
		/// </summary>
		public decimal yd_jg
		{
			set{ _yd_jg=value;}
			get{return _yd_jg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime yd_statetime
		{
			set{ _yd_statetime=value;}
			get{return _yd_statetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime yd_endtime
		{
			set{ _yd_endtime=value;}
			get{return _yd_endtime;}
		}
		/// <summary>
		/// 是否到店入住
		/// </summary>
		public int is_rz
		{
			set{ _is_rz=value;}
			get{return _is_rz;}
		}
		/// <summary>
		/// 订单状态
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

