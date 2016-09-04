namespace Hotel_app.control_user
{
    partial class UC_panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_panel));
            this.PB_open_close = new System.Windows.Forms.PictureBox();
            this.L_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_open_close)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_open_close
            // 
            this.PB_open_close.BackColor = System.Drawing.Color.Transparent;
            this.PB_open_close.Image = ((System.Drawing.Image)(resources.GetObject("PB_open_close.Image")));
            this.PB_open_close.Location = new System.Drawing.Point(2, 0);
            this.PB_open_close.Name = "PB_open_close";
            this.PB_open_close.Size = new System.Drawing.Size(20, 17);
            this.PB_open_close.TabIndex = 0;
            this.PB_open_close.TabStop = false;
            // 
            // L_title
            // 
            this.L_title.AutoSize = true;
            this.L_title.BackColor = System.Drawing.Color.Transparent;
            this.L_title.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.L_title.ForeColor = System.Drawing.SystemColors.Control;
            this.L_title.Location = new System.Drawing.Point(28, 3);
            this.L_title.Name = "L_title";
            this.L_title.Size = new System.Drawing.Size(50, 11);
            this.L_title.TabIndex = 1;
            this.L_title.Text = "A1第三层";
            // 
            // UC_panel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = global::Hotel_app.Properties.Resources.uc_p_title_bg;
            this.Controls.Add(this.L_title);
            this.Controls.Add(this.PB_open_close);
            this.Name = "UC_panel";
            this.Size = new System.Drawing.Size(437, 15);
            ((System.ComponentModel.ISupportInitialize)(this.PB_open_close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_open_close;
        private System.Windows.Forms.Label L_title;
    }
}
