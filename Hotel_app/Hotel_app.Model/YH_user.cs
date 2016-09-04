using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// YH_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YH_user
	{
		public YH_user()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _yhbh;
		private string _yhbm;
		private string _yhxm;
		private string _yhmm;
		private string _r_lsbh;
		private string _rolename;
		private bool _is_top;
		private bool _is_select;
		private string _zjm="";
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
		public string yhbh
		{
			set{ _yhbh=value;}
			get{return _yhbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yhbm
		{
			set{ _yhbm=value;}
			get{return _yhbm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yhxm
		{
			set{ _yhxm=value;}
			get{return _yhxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yhmm
		{
			set{ _yhmm=value;}
			get{return _yhmm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R_lsbh
		{
			set{ _r_lsbh=value;}
			get{return _r_lsbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
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
		public string zjm
		{
			set{ _zjm=value;}
			get{return _zjm;}
		}
		#endregion Model

	}
}

