/*
 *
  */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace xpButton
{
	#region ColorScheme ENUM
	/// <summary>
	/// 背景颜色设计类型
	/// </summary>
	public enum BackColorSchemeType
	{
		/// <summary>
		/// Office 2003 蓝色
		/// </summary>
		Office2003Blue,
		/// <summary>
		/// Office 2003 橙色
		/// </summary>
		Office2003Orange,
		/// <summary>
		/// Office 2003 银色
		/// </summary>
		Office2003Silver,
		/// <summary>
		/// Office 2003 绿色
		/// </summary>
		Office2003Green
	}
	#endregion
	
	/// <summary>
	///  Office2003Button 控件的实现
	/// </summary>
	[ToolboxBitmap(@"d:\OfficeButton.bmp")]
	public class xpOffice2003Button : ButtonBase
	{
		#region Custom Variables
		private BackColorSchemeType _bkgColorScheme = BackColorSchemeType.Office2003Blue;
		private bool _shadow = false;
		
		private Color _downColor1;
		private Color _downColor2;
		private Color _hoverColor;
		private StringFormat _txtFormat;
		#endregion
			
		/// <summary>
		/// 所需要的设计变量
		/// </summary>
		private System.ComponentModel.Container components = null;
				
		public xpOffice2003Button()
		{
            //　InitializeComponent() 调用被Windows窗体设计器支持
			// 
			//
			InitializeComponent();
			
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, false);
			
			ChangeColorScheme();
			
			_txtFormat = new StringFormat();
			_txtFormat.Alignment = StringAlignment.Center;
			_txtFormat.LineAlignment = StringAlignment.Center;
		}
		
		/// <summary>
		/// 清空资源
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		
		#region Windows Forms Designer generated code
		
		private void InitializeComponent()
		{
			// 
			// xpOffice2003Button
			// 
			this.Name = "xpOffice2003Button";
			this.Size = new System.Drawing.Size(150, 100);
		}
		#endregion
		
		#region Extended Properties	
		/// <summary>
		/// 背景颜色设计: 用来预置颜色设计.
		/// </summary>
		[Description("Color scheme to be used")]
		public BackColorSchemeType BackColorScheme
		{
			get{ return _bkgColorScheme; }
			set
			{
				if(value != _bkgColorScheme)
				{
					_bkgColorScheme = value;
					ChangeColorScheme();
					Invalidate();
				}
			}
		}
		
		/// <summary>
		/// 当按下鼠标时开始的背景颜色
        /// </summary>
		[Description("按下鼠标时梯度开始的颜色"),
		Category("梯度颜色")]
		public Color DownColor1
		{
			get{ return _downColor1; }
			set
			{ 
				if( (_downColor1 != value) )
				{
					_downColor1 = value; 
					ChangeColorScheme();
					Invalidate();
				}
			}
		}
		
		/// <summary>
		///　按下鼠标时梯度色结束的颜色 
		/// </summary>
        [Description("按下鼠标时梯度色结束的颜色 "),
       Category("梯度颜色")]
		public Color DownColor2
		{
			get{ return _downColor2; }
			set
			{ 
				if( (_downColor2 != value) )
				{
					_downColor2 = value; 
					ChangeColorScheme();
					Invalidate();
				}
			}
		}
		
		/// <summary>
		/// 鼠标悬浮在按钮上时的背景颜色
       	/// </summary>
		[Description("鼠标悬浮按钮的颜色")]
		public Color HoverColor
		{
			get{ return _hoverColor; }
			set
			{ 
				if( (_hoverColor != value) )
				{
					_hoverColor = value; 
					ChangeColorScheme();
					Invalidate();
				}
			}
		}
		
		/// <summary>
		/// 给文本画出阴影.
		/// </summary>
		[Description("文本显示阴影")]
		public bool ShowShadow
		{
			get{ return _shadow; }
			set
			{
				_shadow = value;
				Invalidate();
			}
		}
		#endregion
		
		protected override void	PaintNormalState(Graphics g)
		{
			g.FillRectangle(new LinearGradientBrush(ClientRectangle,
				BackColor1, BackColor2, 90, false), ClientRectangle);
			g.DrawString(Text, Font, new SolidBrush(ForeColor), 
				ClientRectangle, _txtFormat);
			
			if( ShowShadow )
			{
				SolidBrush tb1 = new SolidBrush(ForeColor);
				g.DrawString(Text, Font, tb1, ClientRectangle, _txtFormat);
				tb1.Dispose();
			}
		}
		
		protected override void PaintHoverState(Graphics g)
		{
			g.FillRectangle(new SolidBrush(HoverColor), ClientRectangle);
			g.DrawRectangle(new Pen(Color.Gray, 0.8f), ClientRectangle);
			g.DrawString(Text, Font, new SolidBrush(ForeColor), 
				ClientRectangle, _txtFormat);
			
			if( ShowShadow )
			{
				SolidBrush tb1 = new SolidBrush(ForeColor);
				g.DrawString(Text, Font, tb1, ClientRectangle, _txtFormat);
				tb1.Dispose();
			}
		}
		
		protected override void PaintClickedState(Graphics g)
		{
			g.FillRectangle(new LinearGradientBrush(ClientRectangle,
				DownColor1, DownColor2, 90, false), ClientRectangle);
			g.DrawString(Text, Font, new SolidBrush(ForeColor), 
				ClientRectangle, _txtFormat);
			
			if( ShowShadow )
			{
				SolidBrush tb1 = new SolidBrush(ForeColor);
				g.DrawString(Text, Font, tb1, ClientRectangle, _txtFormat);
				tb1.Dispose();
			}
		}
		
		protected override void PaintDisabledState(Graphics g)
		{
			g.FillRectangle(new SolidBrush(Color.Gray), ClientRectangle);
			g.DrawString(Text, Font, new SolidBrush(Color.White), 
				ClientRectangle, _txtFormat);
			
			if( ShowShadow )
			{
				SolidBrush tb1 = new SolidBrush(ForeColor);
				g.DrawString(Text, Font, tb1, ClientRectangle, _txtFormat);
				tb1.Dispose();
			}
		}
		
		private void ChangeColorScheme()
		{
			switch(BackColorScheme)
			{
				case BackColorSchemeType.Office2003Blue:
					BackColor = Color.FromArgb(159, 191, 236);
					BackColor1 = Color.FromArgb(159, 191, 236);
					BackColor2 = Color.FromArgb(54, 102, 187);
					DownColor1 = Color.FromArgb(251, 230, 148);
					DownColor2 = Color.FromArgb(239, 150, 21);
					HoverColor = Color.FromArgb(255, 153, 0);
					break;
				case BackColorSchemeType.Office2003Orange:
					BackColor = Color.FromArgb(251, 230, 148);
					BackColor1 = Color.FromArgb(251, 230, 148);
					BackColor2 = Color.FromArgb(239, 150, 21);
					DownColor1 = Color.FromArgb(31, 143, 255);
					DownColor2 = Color.FromArgb(0, 105, 209);
					HoverColor = Color.FromArgb(255, 191, 128);
					break;
				case BackColorSchemeType.Office2003Silver:
					BackColor = Color.FromArgb(225, 226, 236);
					BackColor1 = Color.FromArgb(225, 226, 236);
					BackColor2 = Color.FromArgb(150, 148, 178);
					DownColor1 = Color.FromArgb(165, 165, 165);
					DownColor2 = Color.FromArgb(214, 214, 214);
					HoverColor = Color.FromArgb(180, 178, 199);
					break;
				case BackColorSchemeType.Office2003Green:
					BackColor = Color.FromArgb(234, 240, 207);
					BackColor1 = Color.FromArgb(234, 240, 207);
					BackColor2 = Color.FromArgb(178, 193, 140);
					DownColor1 = Color.FromArgb(143, 166, 94);
					DownColor2 = Color.FromArgb(102, 118, 65);
					HoverColor = Color.FromArgb(175, 192, 140);
					break;
			}
			
			Invalidate();
		}
	}
}
