using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// F_ftfx_7days:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class F_ftfx_7days
	{
		public F_ftfx_7days()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _zyzt="";
		private string _fx_value_1="";
		private string _fx_value_2="";
		private string _fx_value_3="";
		private string _fx_value_4="";
		private string _fx_value_5="";
		private string _fx_value_6="";
		private string _fx_value_7="";
		private string _czy="";
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
		public string zyzt
		{
			set{ _zyzt=value;}
			get{return _zyzt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fx_value_1
		{
			set{ _fx_value_1=value;}
			get{return _fx_value_1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fx_value_2
		{
			set{ _fx_value_2=value;}
			get{return _fx_value_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fx_value_3
		{
			set{ _fx_value_3=value;}
			get{return _fx_value_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fx_value_4
		{
			set{ _fx_value_4=value;}
			get{return _fx_value_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fx_value_5
		{
			set{ _fx_value_5=value;}
			get{return _fx_value_5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fx_value_6
		{
			set{ _fx_value_6=value;}
			get{return _fx_value_6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fx_value_7
		{
			set{ _fx_value_7=value;}
			get{return _fx_value_7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string czy
		{
			set{ _czy=value;}
			get{return _czy;}
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

