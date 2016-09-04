namespace Hotel_app.Qyddj
{
    partial class Q_sfz_temp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Q_sfz_temp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bs_Q_sfz_temp = new System.Windows.Forms.BindingSource(this.components);
            this.b_zl = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.r = new System.Windows.Forms.Panel();
            this.b_ReadCard = new System.Windows.Forms.Button();
            this.b_cx = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tB_gl = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dg_Q_sfz_temp = new Hotel_app.DataGridViewSummary();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Q_sfz_temp)).BeginInit();
            this.panel1.SuspendLayout();
            this.r.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Q_sfz_temp)).BeginInit();
            this.SuspendLayout();
            // 
            // b_zl
            // 
            this.b_zl.BackColor = System.Drawing.SystemColors.Control;
            this.b_zl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_zl.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_zl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_zl.Image = ((System.Drawing.Image)(resources.GetObject("b_zl.Image")));
            this.b_zl.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_zl.Location = new System.Drawing.Point(12, 228);
            this.b_zl.Margin = new System.Windows.Forms.Padding(1);
            this.b_zl.Name = "b_zl";
            this.b_zl.Padding = new System.Windows.Forms.Padding(1);
            this.b_zl.Size = new System.Drawing.Size(59, 59);
            this.b_zl.TabIndex = 3;
            this.b_zl.Text = "转入";
            this.b_zl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_zl.UseVisualStyleBackColor = false;
            this.b_zl.Click += new System.EventHandler(this.b_zl_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.r);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 480);
            this.panel1.TabIndex = 2;
            // 
            // r
            // 
            this.r.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.r.Controls.Add(this.b_ReadCard);
            this.r.Controls.Add(this.b_cx);
            this.r.Controls.Add(this.b_exit);
            this.r.Controls.Add(this.b_zl);
            this.r.Location = new System.Drawing.Point(712, 13);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(87, 454);
            this.r.TabIndex = 10;
            // 
            // b_ReadCard
            // 
            this.b_ReadCard.BackColor = System.Drawing.SystemColors.Control;
            this.b_ReadCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_ReadCard.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_ReadCard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_ReadCard.Image = ((System.Drawing.Image)(resources.GetObject("b_ReadCard.Image")));
            this.b_ReadCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_ReadCard.Location = new System.Drawing.Point(12, 156);
            this.b_ReadCard.Margin = new System.Windows.Forms.Padding(1);
            this.b_ReadCard.Name = "b_ReadCard";
            this.b_ReadCard.Padding = new System.Windows.Forms.Padding(1);
            this.b_ReadCard.Size = new System.Drawing.Size(59, 59);
            this.b_ReadCard.TabIndex = 7;
            this.b_ReadCard.Text = "暂停";
            this.b_ReadCard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_ReadCard.UseVisualStyleBackColor = false;
            this.b_ReadCard.Click += new System.EventHandler(this.b_stop_Click);
            // 
            // b_cx
            // 
            this.b_cx.BackColor = System.Drawing.SystemColors.Control;
            this.b_cx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_cx.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_cx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_cx.Image = ((System.Drawing.Image)(resources.GetObject("b_cx.Image")));
            this.b_cx.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_cx.Location = new System.Drawing.Point(12, 300);
            this.b_cx.Margin = new System.Windows.Forms.Padding(1);
            this.b_cx.Name = "b_cx";
            this.b_cx.Padding = new System.Windows.Forms.Padding(1);
            this.b_cx.Size = new System.Drawing.Size(59, 59);
            this.b_cx.TabIndex = 6;
            this.b_cx.Text = "查询";
            this.b_cx.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_cx.UseVisualStyleBackColor = false;
            this.b_cx.Click += new System.EventHandler(this.b_cx_Click);
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_exit.Location = new System.Drawing.Point(12, 372);
            this.b_exit.Margin = new System.Windows.Forms.Padding(1);
            this.b_exit.Name = "b_exit";
            this.b_exit.Padding = new System.Windows.Forms.Padding(1);
            this.b_exit.Size = new System.Drawing.Size(59, 59);
            this.b_exit.TabIndex = 4;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tB_gl);
            this.panel2.Controls.Add(this.dg_Q_sfz_temp);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 456);
            this.panel2.TabIndex = 0;
            // 
            // tB_gl
            // 
            this.tB_gl.BackColor = System.Drawing.Color.LimeGreen;
            this.tB_gl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_gl.Location = new System.Drawing.Point(183, 394);
            this.tB_gl.Name = "tB_gl";
            this.tB_gl.Size = new System.Drawing.Size(305, 26);
            this.tB_gl.TabIndex = 7;
            this.tB_gl.Visible = false;
            this.tB_gl.TextChanged += new System.EventHandler(this.tB_gl_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dg_Q_sfz_temp
            // 
            this.dg_Q_sfz_temp.AllowUserToAddRows = false;
            this.dg_Q_sfz_temp.AutoGenerateColumns = false;
            this.dg_Q_sfz_temp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_Q_sfz_temp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Q_sfz_temp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Q_sfz_temp.ColumnHeadersHeight = 30;
            this.dg_Q_sfz_temp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_Q_sfz_temp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column6,
            this.Column5});
            this.dg_Q_sfz_temp.DataSource = this.bs_Q_sfz_temp;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Q_sfz_temp.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_Q_sfz_temp.DisplaySumRowHeader = true;
            this.dg_Q_sfz_temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Q_sfz_temp.EnableHeadersVisualStyles = false;
            this.dg_Q_sfz_temp.Location = new System.Drawing.Point(0, 0);
            this.dg_Q_sfz_temp.Name = "dg_Q_sfz_temp";
            this.dg_Q_sfz_temp.RowTemplate.Height = 26;
            this.dg_Q_sfz_temp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_Q_sfz_temp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Q_sfz_temp.ShowRowNumber = true;
            this.dg_Q_sfz_temp.Size = new System.Drawing.Size(692, 454);
            this.dg_Q_sfz_temp.SummaryColumns = new string[] {
        "senior_dep"};
            this.dg_Q_sfz_temp.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_Q_sfz_temp.SummaryRowSpace = 0;
            this.dg_Q_sfz_temp.SummaryRowVisible = true;
            this.dg_Q_sfz_temp.SumRowHeaderText = null;
            this.dg_Q_sfz_temp.SumRowHeaderTextBold = false;
            this.dg_Q_sfz_temp.TabIndex = 6;
            this.dg_Q_sfz_temp.DoubleClick += new System.EventHandler(this.b_zl_Click);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "krxm";
            this.Column3.HeaderText = "客人";
            this.Column3.Name = "Column3";
            this.Column3.Width = 110;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "zjhm";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "证件号码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "krmz";
            this.Column2.HeaderText = "民族";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "krxb";
            this.Column4.HeaderText = "性别";
            this.Column4.Name = "Column4";
            this.Column4.Width = 70;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "krsr";
            this.Column6.HeaderText = "生日";
            this.Column6.Name = "Column6";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "krdz";
            this.Column5.HeaderText = "地址";
            this.Column5.Name = "Column5";
            this.Column5.Width = 250;
            // 
            // Q_sfz_temp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 480);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Q_sfz_temp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "临时客人";
            this.Load += new System.EventHandler(this.Q_sfz_temp_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Q_sfz_temp_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.bs_Q_sfz_temp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.r.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Q_sfz_temp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DataGridViewSummary dg_Q_sfz_temp;
        private System.Windows.Forms.BindingSource bs_Q_sfz_temp;
        private System.Windows.Forms.Button b_zl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel r;
        private System.Windows.Forms.Button b_cx;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tB_gl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button b_ReadCard;
    }
}