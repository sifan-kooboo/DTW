using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Xxfdr:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Xxfdr
	{
		public Xxfdr()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _drbh;
		private string _xfdr;
		private decimal _xfje=0M;
		private bool _is_top= false;
		private bool _is_select= false;
		private bool _is_visible_bb= true;
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
		public string drbh
		{
			set{ _drbh=value;}
			get{return _drbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfdr
		{
			set{ _xfdr=value;}
			get{return _xfdr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal xfje
		{
			set{ _xfje=value;}
			get{return _xfje;}
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
		/// <summary>
		/// 是否要在报表里显示
		/// </summary>
		public bool is_visible_bb
		{
			set{ _is_visible_bb=value;}
			get{return _is_visible_bb;}
		}
		#endregion Model

	}
}

