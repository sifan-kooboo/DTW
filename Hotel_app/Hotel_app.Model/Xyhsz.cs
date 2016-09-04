using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Xyhsz:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Xyhsz
	{
		public Xyhsz()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private decimal _yhbl=0M;
		private string _yh="";
		private bool _istop= false;
		private bool _isselect= false;
		/// <summary>
		/// 
		/// </summary>
		public int ID
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
		public decimal yhbl
		{
			set{ _yhbl=value;}
			get{return _yhbl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yh
		{
			set{ _yh=value;}
			get{return _yh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool istop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isselect
		{
			set{ _isselect=value;}
			get{return _isselect;}
		}
		#endregion Model

	}
}

