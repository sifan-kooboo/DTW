using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Yxsy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Yxsy
	{
		public Yxsy()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private int _xs_level;
		private string _xsy;
		private string _zjm;
		private bool _is_top;
		private bool _is_select;
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
		public int xs_level
		{
			set{ _xs_level=value;}
			get{return _xs_level;}
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

