using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Xbc:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Xbc
	{
		public Xbc()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _bc;
		private int _bc_order=1;
		private string _zjm;
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
		public string bc
		{
			set{ _bc=value;}
			get{return _bc;}
		}
		/// <summary>
		/// 顺序
		/// </summary>
		public int bc_order
		{
			set{ _bc_order=value;}
			get{return _bc_order;}
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

