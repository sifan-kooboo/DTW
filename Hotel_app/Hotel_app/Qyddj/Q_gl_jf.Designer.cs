namespace Hotel_app.Qyddj
{
    partial class Q_gl_jf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Q_gl_jf));
            this.p_gl = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_krxm = new System.Windows.Forms.TextBox();
            this.l_krxm = new System.Windows.Forms.Label();
            this.tb_jfsx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dT_jssj = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dT_qssj = new System.Windows.Forms.DateTimePicker();
            this.b_search = new System.Windows.Forms.Button();
            this.b_gl_exit = new System.Windows.Forms.Button();
            this.l_czy = new System.Windows.Forms.Label();
            this.p_gl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_gl
            // 
            this.p_gl.BackColor = System.Drawing.SystemColors.Control;
            this.p_gl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_gl.Controls.Add(this.groupBox1);
            this.p_gl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Underline);
            this.p_gl.Location = new System.Drawing.Point(7, 8);
            this.p_gl.Name = "p_gl";
            this.p_gl.Size = new System.Drawing.Size(290, 238);
            this.p_gl.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tb_krxm);
            this.groupBox1.Controls.Add(this.l_krxm);
            this.groupBox1.Controls.Add(this.tb_jfsx);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dT_jssj);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dT_qssj);
            this.groupBox1.Controls.Add(this.b_search);
            this.groupBox1.Controls.Add(this.b_gl_exit);
            this.groupBox1.Controls.Add(this.l_czy);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 223);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤";
            // 
            // tb_krxm
            // 
            this.tb_krxm.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_krxm.ForeColor = System.Drawing.Color.Red;
            this.tb_krxm.Location = new System.Drawing.Point(76, 92);
            this.tb_krxm.Name = "tb_krxm";
            this.tb_krxm.Size = new System.Drawing.Size(186, 26);
            this.tb_krxm.TabIndex = 115;
            // 
            // l_krxm
            // 
            this.l_krxm.AutoSize = true;
            this.l_krxm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_krxm.Location = new System.Drawing.Point(18, 99);
            this.l_krxm.Name = "l_krxm";
            this.l_krxm.Size = new System.Drawing.Size(53, 12);
            this.l_krxm.TabIndex = 114;
            this.l_krxm.Text = "客人姓名";
            // 
            // tb_jfsx
            // 
            this.tb_jfsx.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_jfsx.ForeColor = System.Drawing.Color.Red;
            this.tb_jfsx.Location = new System.Drawing.Point(76, 127);
            this.tb_jfsx.Name = "tb_jfsx";
            this.tb_jfsx.Size = new System.Drawing.Size(186, 26);
            this.tb_jfsx.TabIndex = 113;
            this.tb_jfsx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_value_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(18, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 110;
            this.label2.Text = "积分上限";
            // 
            // dT_jssj
            // 
            this.dT_jssj.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_jssj.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dT_jssj.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dT_jssj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_jssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dT_jssj.Location = new System.Drawing.Point(76, 60);
            this.dT_jssj.Name = "dT_jssj";
            this.dT_jssj.Size = new System.Drawing.Size(186, 26);
            this.dT_jssj.TabIndex = 109;
            this.dT_jssj.Enter += new System.EventHandler(this.dT_jssj_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(18, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 108;
            this.label1.Text = "结束时间";
            // 
            // dT_qssj
            // 
            this.dT_qssj.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_qssj.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dT_qssj.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dT_qssj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_qssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dT_qssj.Location = new System.Drawing.Point(76, 20);
            this.dT_qssj.Name = "dT_qssj";
            this.dT_qssj.Size = new System.Drawing.Size(186, 26);
            this.dT_qssj.TabIndex = 107;
            this.dT_qssj.Enter += new System.EventHandler(this.dT_qssj_Enter);
            // 
            // b_search
            // 
            this.b_search.BackColor = System.Drawing.SystemColors.Control;
            this.b_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_search.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_search.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_search.Image = ((System.Drawing.Image)(resources.GetObject("b_search.Image")));
            this.b_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_search.Location = new System.Drawing.Point(37, 168);
            this.b_search.Margin = new System.Windows.Forms.Padding(1);
            this.b_search.Name = "b_search";
            this.b_search.Padding = new System.Windows.Forms.Padding(1);
            this.b_search.Size = new System.Drawing.Size(72, 42);
            this.b_search.TabIndex = 98;
            this.b_search.Text = "查询";
            this.b_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_search.UseVisualStyleBackColor = false;
            this.b_search.Click += new System.EventHandler(this.b_search_Click);
            // 
            // b_gl_exit
            // 
            this.b_gl_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_gl_exit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_gl_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_gl_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_gl_exit.Image")));
            this.b_gl_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_gl_exit.Location = new System.Drawing.Point(176, 168);
            this.b_gl_exit.Margin = new System.Windows.Forms.Padding(1);
            this.b_gl_exit.Name = "b_gl_exit";
            this.b_gl_exit.Padding = new System.Windows.Forms.Padding(1);
            this.b_gl_exit.Size = new System.Drawing.Size(72, 42);
            this.b_gl_exit.TabIndex = 99;
            this.b_gl_exit.Text = "退出";
            this.b_gl_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_gl_exit.UseVisualStyleBackColor = false;
            this.b_gl_exit.Click += new System.EventHandler(this.b_gl_exit_Click);
            // 
            // l_czy
            // 
            this.l_czy.AutoSize = true;
            this.l_czy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_czy.Location = new System.Drawing.Point(18, 29);
            this.l_czy.Name = "l_czy";
            this.l_czy.Size = new System.Drawing.Size(53, 12);
            this.l_czy.TabIndex = 106;
            this.l_czy.Text = "起始时间";
            // 
            // Q_gl_jf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(307, 253);
            this.Controls.Add(this.p_gl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Q_gl_jf";
            this.Text = "历史客人过滤(积分)";
            this.Load += new System.EventHandler(this.Q_gl_jf_Load);
            this.p_gl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_gl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dT_qssj;
        public System.Windows.Forms.Button b_search;
        public System.Windows.Forms.Button b_gl_exit;
        public System.Windows.Forms.Label l_czy;
        private System.Windows.Forms.DateTimePicker dT_jssj;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_jfsx;
        private System.Windows.Forms.TextBox tb_krxm;
        public System.Windows.Forms.Label l_krxm;
    }
}