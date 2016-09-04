using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// RegisterInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RegisterInfo
	{
		public RegisterInfo()
		{}
		#region Model
		private int _id;
		private string _diskid;
		private string _cpuid;
		private string _machineid;
		private DateTime _registertime;
		private string _email;
		private string _username;
		private string _userguid;
		private string _mobile;
		private int _registeryears;
		private string _xxzs;
		private string _registerkey;
		private DateTime _startusetime;
		private DateTime _endusetime;
		private int _usetimes;
		private DateTime _lastlogintime;
		private string _registerkey_temp;
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
		public string DiskID
		{
			set{ _diskid=value;}
			get{return _diskid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CpuID
		{
			set{ _cpuid=value;}
			get{return _cpuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RegisterTime
		{
			set{ _registertime=value;}
			get{return _registertime;}
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
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserGuid
		{
			set{ _userguid=value;}
			get{return _userguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RegisterYears
		{
			set{ _registeryears=value;}
			get{return _registeryears;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xxzs
		{
			set{ _xxzs=value;}
			get{return _xxzs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegisterKey
		{
			set{ _registerkey=value;}
			get{return _registerkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime StartUseTime
		{
			set{ _startusetime=value;}
			get{return _startusetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndUseTime
		{
			set{ _endusetime=value;}
			get{return _endusetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UseTimes
		{
			set{ _usetimes=value;}
			get{return _usetimes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegisterKey_temp
		{
			set{ _registerkey_temp=value;}
			get{return _registerkey_temp;}
		}
		#endregion Model

	}
}

