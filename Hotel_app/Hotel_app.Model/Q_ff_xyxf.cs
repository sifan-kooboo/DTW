using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Q_ff_xyxf:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Q_ff_xyxf
	{
		public Q_ff_xyxf()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _fyrx;
		private string _xfdr;
		private string _xfrb;
		private string _xfxm;
		private decimal _xfsl=1M;
		private decimal _jjje=0M;
		private decimal _xfje=0M;
		private bool _is_top= false;
		private bool _is_select= false;
		private string _mxbh;
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
		public string fyrx
		{
			set{ _fyrx=value;}
			get{return _fyrx;}
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
		public string xfrb
		{
			set{ _xfrb=value;}
			get{return _xfrb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfxm
		{
			set{ _xfxm=value;}
			get{return _xfxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal xfsl
		{
			set{ _xfsl=value;}
			get{return _xfsl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal jjje
		{
			set{ _jjje=value;}
			get{return _jjje;}
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
		/// 
		/// </summary>
		public string mxbh
		{
			set{ _mxbh=value;}
			get{return _mxbh;}
		}
		#endregion Model

	}
}

