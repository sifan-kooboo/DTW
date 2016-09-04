using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// BBfx_zfs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BBfx_zfs
	{
		public BBfx_zfs()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private decimal _zfs=1M;
		private DateTime _rq;
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
		public decimal zfs
		{
			set{ _zfs=value;}
			get{return _zfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime rq
		{
			set{ _rq=value;}
			get{return _rq;}
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

