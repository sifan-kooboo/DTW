using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Q_sfz_save:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Q_sfz_save
	{
		public Q_sfz_save()
		{}
		#region Model
		private int _id;
		private string _zjhm;
		private string _krxm;
		private string _krmz;
		private string _krxb;
		private DateTime _krsr;
		private string _krdz;
		private string _department;
		private DateTime _startdate;
		private DateTime _enddate;
		private byte[] _krxp;
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
		public string zjhm
		{
			set{ _zjhm=value;}
			get{return _zjhm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krxm
		{
			set{ _krxm=value;}
			get{return _krxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krmz
		{
			set{ _krmz=value;}
			get{return _krmz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krxb
		{
			set{ _krxb=value;}
			get{return _krxb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime krsr
		{
			set{ _krsr=value;}
			get{return _krsr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krdz
		{
			set{ _krdz=value;}
			get{return _krdz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string department
		{
			set{ _department=value;}
			get{return _department;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime startdate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime enddate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] krxp
		{
			set{ _krxp=value;}
			get{return _krxp;}
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

