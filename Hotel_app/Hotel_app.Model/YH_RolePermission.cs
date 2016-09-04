using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// YH_RolePermission:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YH_RolePermission
	{
		public YH_RolePermission()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _r_lsbh;
		private string _r_rolesname;
		private string _p_lsbh;
		private string _a_appdr;
		private string _a_appname;
		private bool _p_value= false;
		private bool _is_top= false;
		private bool _is_select= false;
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
		public string R_lsbh
		{
			set{ _r_lsbh=value;}
			get{return _r_lsbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R_RolesName
		{
			set{ _r_rolesname=value;}
			get{return _r_rolesname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_lsbh
		{
			set{ _p_lsbh=value;}
			get{return _p_lsbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string A_Appdr
		{
			set{ _a_appdr=value;}
			get{return _a_appdr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string A_AppName
		{
			set{ _a_appname=value;}
			get{return _a_appname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool P_Value
		{
			set{ _p_value=value;}
			get{return _p_value;}
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

