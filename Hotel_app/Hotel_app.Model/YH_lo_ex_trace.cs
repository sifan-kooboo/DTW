using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// YH_lo_ex_trace:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YH_lo_ex_trace
	{
		public YH_lo_ex_trace()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _syzd;
		private string _yhbh;
		private string _yhxm;
		private string _lo_ex;
		private DateTime _login_time;
		private DateTime _exit_time;
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
		public string syzd
		{
			set{ _syzd=value;}
			get{return _syzd;}
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
		public string yhxm
		{
			set{ _yhxm=value;}
			get{return _yhxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lo_ex
		{
			set{ _lo_ex=value;}
			get{return _lo_ex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime login_time
		{
			set{ _login_time=value;}
			get{return _login_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime exit_time
		{
			set{ _exit_time=value;}
			get{return _exit_time;}
		}
		#endregion Model

	}
}

