namespace Hotel_app.Szwgl
{
    partial class S_jkzd_add_0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S_jkzd_add_0));
            this.b_exit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.b_save = new System.Windows.Forms.Button();
            this.dT_czsj_cs = new System.Windows.Forms.DateTimePicker();
            this.l_syzd = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_exit.Location = new System.Drawing.Point(216, 71);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(68, 44);
            this.b_exit.TabIndex = 59;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.b_exit);
            this.panel2.Controls.Add(this.b_save);
            this.panel2.Controls.Add(this.dT_czsj_cs);
            this.panel2.Controls.Add(this.l_syzd);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 144);
            this.panel2.TabIndex = 11;
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(81, 71);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(68, 44);
            this.b_save.TabIndex = 58;
            this.b_save.Text = "重做";
            this.b_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_save.UseVisualStyleBackColor = false;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // dT_czsj_cs
            // 
            this.dT_czsj_cs.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_czsj_cs.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_czsj_cs.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dT_czsj_cs.Location = new System.Drawing.Point(96, 16);
            this.dT_czsj_cs.Name = "dT_czsj_cs";
            this.dT_czsj_cs.Size = new System.Drawing.Size(188, 26);
            this.dT_czsj_cs.TabIndex = 57;
            // 
            // l_syzd
            // 
            this.l_syzd.AutoSize = true;
            this.l_syzd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_syzd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_syzd.Location = new System.Drawing.Point(15, 24);
            this.l_syzd.Name = "l_syzd";
            this.l_syzd.Size = new System.Drawing.Size(63, 14);
            this.l_syzd.TabIndex = 56;
            this.l_syzd.Text = "重做日期";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 169);
            this.panel1.TabIndex = 1;
            // 
            // S_jkzd_add_0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 169);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "S_jkzd_add_0";
            this.Text = "重做交款";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.DateTimePicker dT_czsj_cs;
        private System.Windows.Forms.Label l_syzd;
        private System.Windows.Forms.Panel panel1;
    }
}