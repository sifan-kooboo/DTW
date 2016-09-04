using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Ygzdw:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ygzdw
	{
		public Ygzdw()
		{}
		#region Model
		private int _id;
		private string _dwrx;
		private string _gzdw;
		private string _nxr;
		private string _nxdh;
		private string _nxcz;
		private string _email;
		private string _nxdz;
		private string _xsy;
		private string _zjm;
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
		public string dwrx
		{
			set{ _dwrx=value;}
			get{return _dwrx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gzdw
		{
			set{ _gzdw=value;}
			get{return _gzdw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nxr
		{
			set{ _nxr=value;}
			get{return _nxr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nxdh
		{
			set{ _nxdh=value;}
			get{return _nxdh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nxcz
		{
			set{ _nxcz=value;}
			get{return _nxcz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nxdz
		{
			set{ _nxdz=value;}
			get{return _nxdz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xsy
		{
			set{ _xsy=value;}
			get{return _xsy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zjm
		{
			set{ _zjm=value;}
			get{return _zjm;}
		}
		#endregion Model

	}
}

