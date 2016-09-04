/*
 *
 * Author: Amit Bhandari
 *
 * Purpose: 
 *  
 */

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace xpButton
{
	/// <summary>
	/// GlowButton 控件的实现
	/// </summary>
	public class xpGlowButton : ButtonBase
	{
		private LinearGradientBrush _lgb, _rlgb;
		private Pen _pOutline, _hOutline;
		private StringFormat _txtFormat;
		private Color _hoverTxtColor = Color.White;
		
		/// <summary>
		/// 所需要的设计变量.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		public xpGlowButton()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, false);
			
			BackColor = BackColor1;
			_pOutline = new Pen(Color.White, 1.8f);
			_pOutline.Alignment = PenAlignment.Outset;			
			_hOutline = new Pen(Color.Black, 1);
			_hOutline.Alignment = PenAlignment.Outset;

			_txtFormat = new StringFormat();
			_txtFormat.Alignment = StringAlignment.Center;
			_txtFormat.LineAlignment = StringAlignment.Center;
		}
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
				
				if( _lgb != null )
					_lgb.Dispose();
				
				if( _rlgb != null )
					_rlgb.Dispose();
			}
			base.Dispose( disposing );
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// Windows窗体设计支持的方法，在源代码编辑器里不要改变方法内容，
        /// 否则窗体设计器不能加载这个方法T
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// xpGlowButton
			// 
			this.Name = "xpGlowButton";
			this.Size = new System.Drawing.Size(200, 100);
		}
		#endregion
		
		///<summary>
		/// 当鼠标悬浮在按钮上时的字体颜色
		/// </summary>
		[Description("当鼠标悬浮在按钮上时的字体颜色"),
		Category("Draw Extenders")]
		public Color HoverForeColor
		{
			get{ return _hoverTxtColor; }
			set
			{
				if(_hoverTxtColor != value)
					_hoverTxtColor = value;
			}
		}
		
		protected override void	PaintNormalState(Graphics g)
		{
			InitializeBrush();
			g.FillRectangle(_lgb, ClientRectangle);
			g.DrawRectangle(_pOutline, ClientRectangle);
			g.DrawString(Text, Font, new SolidBrush(ForeColor), 
				ClientRectangle, _txtFormat);
		}
		
		protected override void PaintHoverState(Graphics g)
		{
			InitializeBrush();
			g.FillRectangle(_lgb, ClientRectangle);
			g.DrawString(Text, Font, new SolidBrush(HoverForeColor), 
				ClientRectangle, _txtFormat);
		}
		
		protected override void PaintClickedState(Graphics g)
		{
			InitializeBrush();
			g.FillRectangle(_rlgb, ClientRectangle);
			g.DrawRectangle(_pOutline, ClientRectangle);
			g.DrawString(Text, Font, new SolidBrush(HoverForeColor), 
				ClientRectangle, _txtFormat);
		}
		
		protected override void PaintDisabledState(Graphics g)
		{
			InitializeBrush();
			g.FillRectangle(new SolidBrush(Color.Gray), ClientRectangle);
			g.DrawRectangle(new Pen(Color.White,2), ClientRectangle);
			g.DrawString(Text, Font, new SolidBrush(Color.White), 
				ClientRectangle, _txtFormat);
		}
		
		private void InitializeBrush()
		{
			if(_lgb == null)
				_lgb = new LinearGradientBrush(this.ClientRectangle,
			                BackColor1, BackColor2, 90, false);
			
			if(_rlgb == null)
				_rlgb = new LinearGradientBrush(this.ClientRectangle,
			                BackColor2, BackColor1, 90, false);
		}
	}
}
