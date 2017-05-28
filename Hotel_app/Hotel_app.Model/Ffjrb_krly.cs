﻿using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Ffjrb_krly:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ffjrb_krly
	{
		public Ffjrb_krly()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _krly;
		private string _fjrb;
		private string _fjrb_code;
		private decimal _sjjg;
		private bool _is_top= false;
		private bool _is_select= false;
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
		public string yydh
		{
			set{ _yydh=value;}
			get{return _yydh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qymc
		{
			set{ _qymc=value;}
			get{return _qymc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krly
		{
			set{ _krly=value;}
			get{return _krly;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fjrb
		{
			set{ _fjrb=value;}
			get{return _fjrb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fjrb_code
		{
			set{ _fjrb_code=value;}
			get{return _fjrb_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal sjjg
		{
			set{ _sjjg=value;}
			get{return _sjjg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_top
		{
			set{ _is_top=value;}
			get{return _is_top;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_select
		{
			set{ _is_select=value;}
			get{return _is_select;}
		}
		#endregion Model

	}
}
