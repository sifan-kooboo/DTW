namespace Hotel_app.dxpt
{
    partial class dx_fs_detail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l_5 = new System.Windows.Forms.Label();
            this.dT_ddsj_js = new System.Windows.Forms.DateTimePicker();
            this.dT_ddsj_cs = new System.Windows.Forms.DateTimePicker();
            this.l_1 = new System.Windows.Forms.Label();
            this.tB_1 = new System.Windows.Forms.TextBox();
            this.tB_0 = new System.Windows.Forms.TextBox();
            this.l_0 = new System.Windows.Forms.Label();
            this.tB_2 = new System.Windows.Forms.TextBox();
            this.l_3 = new System.Windows.Forms.Label();
            this.l_2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tB_3 = new System.Windows.Forms.ComboBox();
            this.b_reSend = new System.Windows.Forms.Button();
            this.dg_detail = new Hotel_app.DataGridViewSummary();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_detail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(878, 425);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(872, 119);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dg_detail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(872, 300);
            this.panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_reSend);
            this.groupBox1.Controls.Add(this.tB_3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.l_1);
            this.groupBox1.Controls.Add(this.dT_ddsj_js);
            this.groupBox1.Controls.Add(this.dT_ddsj_cs);
            this.groupBox1.Controls.Add(this.tB_1);
            this.groupBox1.Controls.Add(this.l_5);
            this.groupBox1.Controls.Add(this.tB_0);
            this.groupBox1.Controls.Add(this.l_0);
            this.groupBox1.Controls.Add(this.tB_2);
            this.groupBox1.Controls.Add(this.l_3);
            this.groupBox1.Controls.Add(this.l_2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 117);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤";
            // 
            // l_5
            // 
            this.l_5.AutoSize = true;
            this.l_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_5.Location = new System.Drawing.Point(16, 84);
            this.l_5.Name = "l_5";
            this.l_5.Size = new System.Drawing.Size(53, 12);
            this.l_5.TabIndex = 72;
            this.l_5.Text = "发送时间";
            // 
            // dT_ddsj_js
            // 
            this.dT_ddsj_js.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_ddsj_js.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dT_ddsj_js.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dT_ddsj_js.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_ddsj_js.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dT_ddsj_js.Location = new System.Drawing.Point(257, 77);
            this.dT_ddsj_js.Name = "dT_ddsj_js";
            this.dT_ddsj_js.Size = new System.Drawing.Size(174, 26);
            this.dT_ddsj_js.TabIndex = 71;
            this.dT_ddsj_js.Value = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dT_ddsj_js.Enter += new System.EventHandler(this.dT_ddsj_cs_Enter);
            // 
            // dT_ddsj_cs
            // 
            this.dT_ddsj_cs.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_ddsj_cs.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dT_ddsj_cs.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dT_ddsj_cs.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_ddsj_cs.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dT_ddsj_cs.Location = new System.Drawing.Point(79, 77);
            this.dT_ddsj_cs.Name = "dT_ddsj_cs";
            this.dT_ddsj_cs.Size = new System.Drawing.Size(158, 26);
            this.dT_ddsj_cs.TabIndex = 70;
            this.dT_ddsj_cs.Value = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dT_ddsj_cs.Enter += new System.EventHandler(this.dT_ddsj_cs_Enter);
            // 
            // l_1
            // 
            this.l_1.AutoSize = true;
            this.l_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_1.Location = new System.Drawing.Point(438, 20);
            this.l_1.Name = "l_1";
            this.l_1.Size = new System.Drawing.Size(41, 12);
            this.l_1.TabIndex = 95;
            this.l_1.Text = "手机号";
            // 
            // tB_1
            // 
            this.tB_1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_1.ForeColor = System.Drawing.Color.Red;
            this.tB_1.Location = new System.Drawing.Point(499, 13);
            this.tB_1.Name = "tB_1";
            this.tB_1.Size = new System.Drawing.Size(354, 26);
            this.tB_1.TabIndex = 89;
            // 
            // tB_0
            // 
            this.tB_0.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_0.ForeColor = System.Drawing.Color.Red;
            this.tB_0.Location = new System.Drawing.Point(77, 13);
            this.tB_0.Name = "tB_0";
            this.tB_0.Size = new System.Drawing.Size(354, 26);
            this.tB_0.TabIndex = 0;
            // 
            // l_0
            // 
            this.l_0.AutoSize = true;
            this.l_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_0.Location = new System.Drawing.Point(21, 24);
            this.l_0.Name = "l_0";
            this.l_0.Size = new System.Drawing.Size(29, 12);
            this.l_0.TabIndex = 94;
            this.l_0.Text = "姓名";
            // 
            // tB_2
            // 
            this.tB_2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_2.ForeColor = System.Drawing.Color.Red;
            this.tB_2.Location = new System.Drawing.Point(77, 45);
            this.tB_2.Name = "tB_2";
            this.tB_2.Size = new System.Drawing.Size(354, 26);
            this.tB_2.TabIndex = 90;
            // 
            // l_3
            // 
            this.l_3.AutoSize = true;
            this.l_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_3.Location = new System.Drawing.Point(438, 50);
            this.l_3.Name = "l_3";
            this.l_3.Size = new System.Drawing.Size(53, 12);
            this.l_3.TabIndex = 93;
            this.l_3.Text = "发送状态";
            // 
            // l_2
            // 
            this.l_2.AutoSize = true;
            this.l_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_2.Location = new System.Drawing.Point(16, 52);
            this.l_2.Name = "l_2";
            this.l_2.Size = new System.Drawing.Size(53, 12);
            this.l_2.TabIndex = 92;
            this.l_2.Text = "内容摘要";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(499, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 30);
            this.button1.TabIndex = 96;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RestControlText);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(782, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 30);
            this.button2.TabIndex = 97;
            this.button2.Text = "关团";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(593, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 30);
            this.button3.TabIndex = 98;
            this.button3.Text = "查询";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(243, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "到";
            // 
            // tB_3
            // 
            this.tB_3.Font = new System.Drawing.Font("宋体", 12F);
            this.tB_3.FormattingEnabled = true;
            this.tB_3.Items.AddRange(new object[] {
            "成功",
            "失败"});
            this.tB_3.Location = new System.Drawing.Point(498, 43);
            this.tB_3.Name = "tB_3";
            this.tB_3.Size = new System.Drawing.Size(355, 24);
            this.tB_3.TabIndex = 100;
            // 
            // b_reSend
            // 
            this.b_reSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.b_reSend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_reSend.Location = new System.Drawing.Point(688, 74);
            this.b_reSend.Name = "b_reSend";
            this.b_reSend.Size = new System.Drawing.Size(71, 30);
            this.b_reSend.TabIndex = 101;
            this.b_reSend.Text = "重发";
            this.b_reSend.UseVisualStyleBackColor = true;
            this.b_reSend.Click += new System.EventHandler(this.b_reSend_Click);
            // 
            // dg_detail
            // 
            this.dg_detail.AutoGenerateColumns = false;
            this.dg_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dg_detail.DataSource = this.bindingSource1;
            this.dg_detail.DisplaySumRowHeader = false;
            this.dg_detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_detail.Location = new System.Drawing.Point(0, 0);
            this.dg_detail.Name = "dg_detail";
            this.dg_detail.RowTemplate.Height = 23;
            this.dg_detail.ShowRowNumber = true;
            this.dg_detail.Size = new System.Drawing.Size(872, 300);
            this.dg_detail.SummaryColumns = null;
            this.dg_detail.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_detail.SummaryRowSpace = 0;
            this.dg_detail.SummaryRowVisible = false;
            this.dg_detail.SumRowHeaderText = null;
            this.dg_detail.SumRowHeaderTextBold = false;
            this.dg_detail.TabIndex = 1;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "选择";
            this.Column7.Name = "Column7";
            this.Column7.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UserName";
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.Width = 75;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "phoneNo";
            this.Column1.HeaderText = "手机号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 75;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "information";
            this.Column3.HeaderText = "短信息内容";
            this.Column3.Name = "Column3";
            this.Column3.Width = 300;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "sendTime";
            this.Column4.HeaderText = "发送时间";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "sendStatus";
            this.Column5.HeaderText = "发送状态";
            this.Column5.Name = "Column5";
            this.Column5.Width = 75;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "czy";
            this.Column6.HeaderText = "操作员";
            this.Column6.Name = "Column6";
            // 
            // dx_fs_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 425);
            this.Controls.Add(this.panel1);
            this.Name = "dx_fs_detail";
            this.Text = "短信发送详细查询";
            this.Load += new System.EventHandler(this.dx_fs_detail_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_detail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel3;
        private DataGridViewSummary dg_detail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label l_5;
        public System.Windows.Forms.DateTimePicker dT_ddsj_js;
        public System.Windows.Forms.DateTimePicker dT_ddsj_cs;
        public System.Windows.Forms.Label l_1;
        public System.Windows.Forms.TextBox tB_1;
        public System.Windows.Forms.TextBox tB_0;
        public System.Windows.Forms.Label l_0;
        public System.Windows.Forms.TextBox tB_2;
        public System.Windows.Forms.Label l_3;
        public System.Windows.Forms.Label l_2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tB_3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button b_reSend;
    }
}