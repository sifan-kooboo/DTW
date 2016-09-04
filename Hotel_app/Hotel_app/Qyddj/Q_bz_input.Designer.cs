namespace Hotel_app.Qyddj
{
    partial class Q_bz_input
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Q_bz_input));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tB_bz = new System.Windows.Forms.TextBox();
            this.b_save = new System.Windows.Forms.Button();
            this.b_no = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tB_bz);
            this.panel1.Controls.Add(this.b_save);
            this.panel1.Controls.Add(this.b_no);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 208);
            this.panel1.TabIndex = 0;
            // 
            // tB_bz
            // 
            this.tB_bz.BackColor = System.Drawing.SystemColors.Window;
            this.tB_bz.Location = new System.Drawing.Point(3, 3);
            this.tB_bz.Multiline = true;
            this.tB_bz.Name = "tB_bz";
            this.tB_bz.Size = new System.Drawing.Size(393, 155);
            this.tB_bz.TabIndex = 0;
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(238, 164);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(76, 39);
            this.b_save.TabIndex = 8;
            this.b_save.Text = "确定";
            this.b_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_save.UseVisualStyleBackColor = false;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_no
            // 
            this.b_no.BackColor = System.Drawing.SystemColors.Control;
            this.b_no.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_no.Image = ((System.Drawing.Image)(resources.GetObject("b_no.Image")));
            this.b_no.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_no.Location = new System.Drawing.Point(320, 164);
            this.b_no.Name = "b_no";
            this.b_no.Padding = new System.Windows.Forms.Padding(5);
            this.b_no.Size = new System.Drawing.Size(76, 39);
            this.b_no.TabIndex = 5;
            this.b_no.Text = "退出";
            this.b_no.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_no.UseVisualStyleBackColor = false;
            this.b_no.Click += new System.EventHandler(this.b_no_Click);
            // 
            // Q_bz_input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(425, 232);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Q_bz_input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "请输入";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button b_no;
        private System.Windows.Forms.Button b_save;
        public System.Windows.Forms.TextBox tB_bz;
    }
}