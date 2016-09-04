using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// BB_dsfx_temp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BB_dsfx_temp
	{
		public BB_dsfx_temp()
		{}
		#region Model
		private int _id;
		private string _qymc;
		private string _yydh;
		private string _dsdr;
		private decimal _je;
		private string _czy_temp;
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
		public string qymc
		{
			set{ _qymc=value;}
			get{return _qymc;}
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
		public string dsdr
		{
			set{ _dsdr=value;}
			get{return _dsdr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal je
		{
			set{ _je=value;}
			get{return _je;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string czy_temp
		{
			set{ _czy_temp=value;}
			get{return _czy_temp;}
		}
		#endregion Model

	}
}

