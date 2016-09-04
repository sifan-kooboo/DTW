using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Xfkfs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Xfkfs
	{
		public Xfkfs()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _fkfs="";
		private string _zjm="";
		private bool _is_top= false;
		private bool _is_select= false;
		private bool _is_visible_bb= false;
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
		public string fkfs
		{
			set{ _fkfs=value;}
			get{return _fkfs;}
		}
		/// <summary>
		/// 助记码
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
		/// <summary>
		/// 
		/// </summary>
		public bool is_visible_bb
		{
			set{ _is_visible_bb=value;}
			get{return _is_visible_bb;}
		}
		#endregion Model

	}
}

