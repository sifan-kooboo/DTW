namespace Hotel_app.control_user
{
    partial class UC_roompic_title
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_roompic_title));
            this.pB_click = new System.Windows.Forms.PictureBox();
            this.l_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pB_click)).BeginInit();
            this.SuspendLayout();
            // 
            // pB_click
            // 
            this.pB_click.Image = ((System.Drawing.Image)(resources.GetObject("pB_click.Image")));
            this.pB_click.Location = new System.Drawing.Point(0, 1);
            this.pB_click.Name = "pB_click";
            this.pB_click.Size = new System.Drawing.Size(16, 16);
            this.pB_click.TabIndex = 1;
            this.pB_click.TabStop = false;
            this.pB_click.DoubleClick += new System.EventHandler(this.UC_roompic_title_DoubleClick);
            this.pB_click.Click += new System.EventHandler(this.pB_click_Click);
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_title.Location = new System.Drawing.Point(18, 3);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(63, 14);
            this.l_title.TabIndex = 2;
            this.l_title.Text = "A1楼A1层";
            // 
            // UC_roompic_title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.pB_click);
            this.Name = "UC_roompic_title";
            this.Size = new System.Drawing.Size(497, 18);
            this.DoubleClick += new System.EventHandler(this.UC_roompic_title_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pB_click)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pB_click;
        private System.Windows.Forms.Label l_title;
    }
}
