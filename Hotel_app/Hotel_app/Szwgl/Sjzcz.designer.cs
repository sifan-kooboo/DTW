namespace Hotel_app.Szwgl
{
    partial class Sjzcz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sjzcz));
            this.b_xydw = new System.Windows.Forms.Button();
            this.tB_gzdw = new System.Windows.Forms.TextBox();
            this.lbl_jz_gz = new System.Windows.Forms.Label();
            this.P_yjcz = new System.Windows.Forms.Panel();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.P_yjcz.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_xydw
            // 
            this.b_xydw.BackColor = System.Drawing.Color.DimGray;
            this.b_xydw.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_xydw.Image = ((System.Drawing.Image)(resources.GetObject("b_xydw.Image")));
            this.b_xydw.Location = new System.Drawing.Point(386, 16);
            this.b_xydw.Name = "b_xydw";
            this.b_xydw.Size = new System.Drawing.Size(48, 33);
            this.b_xydw.TabIndex = 26;
            this.b_xydw.UseVisualStyleBackColor = false;
            this.b_xydw.Click += new System.EventHandler(this.b_xydw_Click);
            // 
            // tB_gzdw
            // 
            this.tB_gzdw.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_gzdw.Location = new System.Drawing.Point(92, 16);
            this.tB_gzdw.Multiline = true;
            this.tB_gzdw.Name = "tB_gzdw";
            this.tB_gzdw.ReadOnly = true;
            this.tB_gzdw.Size = new System.Drawing.Size(288, 33);
            this.tB_gzdw.TabIndex = 25;
            this.tB_gzdw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_jz_gz
            // 
            this.lbl_jz_gz.AutoSize = true;
            this.lbl_jz_gz.Font = new System.Drawing.Font("宋体", 9F);
            this.lbl_jz_gz.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_jz_gz.Location = new System.Drawing.Point(9, 26);
            this.lbl_jz_gz.Name = "lbl_jz_gz";
            this.lbl_jz_gz.Size = new System.Drawing.Size(65, 12);
            this.lbl_jz_gz.TabIndex = 24;
            this.lbl_jz_gz.Text = "记帐单位：";
            // 
            // P_yjcz
            // 
            this.P_yjcz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.P_yjcz.Controls.Add(this.b_exit);
            this.P_yjcz.Controls.Add(this.b_xydw);
            this.P_yjcz.Controls.Add(this.tB_gzdw);
            this.P_yjcz.Controls.Add(this.b_save);
            this.P_yjcz.Controls.Add(this.lbl_jz_gz);
            this.P_yjcz.Location = new System.Drawing.Point(12, 12);
            this.P_yjcz.Name = "P_yjcz";
            this.P_yjcz.Size = new System.Drawing.Size(629, 69);
            this.P_yjcz.TabIndex = 27;
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit.Font = new System.Drawing.Font("宋体", 9F);
            this.b_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_exit.Location = new System.Drawing.Point(536, 14);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(61, 38);
            this.b_exit.TabIndex = 27;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click_1);
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.Font = new System.Drawing.Font("宋体", 9F);
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(462, 13);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(68, 38);
            this.b_save.TabIndex = 10;
            this.b_save.Text = "记帐";
            this.b_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_save.UseVisualStyleBackColor = false;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // Sjzcz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(653, 93);
            this.Controls.Add(this.P_yjcz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Sjzcz";
            this.P_yjcz.ResumeLayout(false);
            this.P_yjcz.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_xydw;
        public System.Windows.Forms.TextBox tB_gzdw;
        private System.Windows.Forms.Label lbl_jz_gz;
        private System.Windows.Forms.Panel P_yjcz;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_exit;

    }
}