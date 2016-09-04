namespace Hotel_app.update
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.xpGlowButton1 = new xpButton.xpGlowButton();
            this.downLoad = new xpButton.xpOffice2003Button();
            this.xpOffice2003Button1 = new xpButton.xpOffice2003Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "倒计时10秒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(93, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "10";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Hotel_app.update.Properties.Resources.Test;
            this.button1.Location = new System.Drawing.Point(39, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 91);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // xpGlowButton1
            // 
            this.xpGlowButton1.AllowDrop = true;
            this.xpGlowButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpGlowButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.xpGlowButton1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.xpGlowButton1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.xpGlowButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xpGlowButton1.BackgroundImage")));
            this.xpGlowButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.xpGlowButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.xpGlowButton1.HoverForeColor = System.Drawing.Color.White;
            this.xpGlowButton1.Location = new System.Drawing.Point(210, -3);
            this.xpGlowButton1.Name = "xpGlowButton1";
            this.xpGlowButton1.Size = new System.Drawing.Size(0, 0);
            this.xpGlowButton1.TabIndex = 7;
            // 
            // downLoad
            // 
            this.downLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.downLoad.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.downLoad.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.downLoad.BackColorScheme = xpButton.BackColorSchemeType.Office2003Blue;
            this.downLoad.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.downLoad.DownColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            this.downLoad.DownColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(150)))), ((int)(((byte)(21)))));
            this.downLoad.Font = new System.Drawing.Font("宋体", 10F);
            this.downLoad.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.downLoad.Location = new System.Drawing.Point(72, 95);
            this.downLoad.Name = "downLoad";
            this.downLoad.ShowShadow = false;
            this.downLoad.Size = new System.Drawing.Size(81, 28);
            this.downLoad.TabIndex = 6;
            this.downLoad.Text = "开始更新";
            this.downLoad.Click += new System.EventHandler(this.downLoad_Click);
            // 
            // xpOffice2003Button1
            // 
            this.xpOffice2003Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.xpOffice2003Button1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.xpOffice2003Button1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(102)))), ((int)(((byte)(187)))));
            this.xpOffice2003Button1.BackColorScheme = xpButton.BackColorSchemeType.Office2003Blue;
            this.xpOffice2003Button1.BackgroundImage = global::Hotel_app.update.Properties.Resources.Test;
            this.xpOffice2003Button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.xpOffice2003Button1.DownColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            this.xpOffice2003Button1.DownColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(150)))), ((int)(((byte)(21)))));
            this.xpOffice2003Button1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.xpOffice2003Button1.Location = new System.Drawing.Point(303, 235);
            this.xpOffice2003Button1.Name = "xpOffice2003Button1";
            this.xpOffice2003Button1.ShowShadow = false;
            this.xpOffice2003Button1.Size = new System.Drawing.Size(150, 100);
            this.xpOffice2003Button1.TabIndex = 9;
            this.xpOffice2003Button1.Text = "xpOffice2003Button1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(224, 141);
            this.Controls.Add(this.xpOffice2003Button1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.xpGlowButton1);
            this.Controls.Add(this.downLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 22F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动升级程序V1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.downLoad_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private xpButton.xpOffice2003Button downLoad;
        private xpButton.xpGlowButton xpGlowButton1;
        private System.Windows.Forms.Button button1;
        private xpButton.xpOffice2003Button xpOffice2003Button1;
    }
}

