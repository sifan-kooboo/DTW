using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// BSzhrbb:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BSzhrbb
	{
		public BSzhrbb()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private DateTime _bbrq;
		private string _rbxm;
		private string _brrj;
		private string _byrj;
		private string _rbxm0;
		private string _brrj0;
		private string _byrj0;
		private bool _shsc= false;
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
		public DateTime bbrq
		{
			set{ _bbrq=value;}
			get{return _bbrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rbxm
		{
			set{ _rbxm=value;}
			get{return _rbxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brrj
		{
			set{ _brrj=value;}
			get{return _brrj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string byrj
		{
			set{ _byrj=value;}
			get{return _byrj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rbxm0
		{
			set{ _rbxm0=value;}
			get{return _rbxm0;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brrj0
		{
			set{ _brrj0=value;}
			get{return _brrj0;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string byrj0
		{
			set{ _byrj0=value;}
			get{return _byrj0;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool shsc
		{
			set{ _shsc=value;}
			get{return _shsc;}
		}
		#endregion Model

	}
}

