namespace Hotel_app.Ffjzt
{
    partial class Ffjzt_select
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ffjzt_select));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg_fjzt = new Hotel_app.DataGridViewSummary();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fjbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip_info = new System.Windows.Forms.ToolTip(this.components);
            this.btn_ttpf = new System.Windows.Forms.Button();
            this.b_FindMore = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gB_pf = new System.Windows.Forms.GroupBox();
            this.gB_exit = new System.Windows.Forms.GroupBox();
            this.b_no = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_fjzt)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gB_pf.SuspendLayout();
            this.gB_exit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dg_fjzt);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 513);
            this.panel1.TabIndex = 8;
            // 
            // dg_fjzt
            // 
            this.dg_fjzt.AllowUserToAddRows = false;
            this.dg_fjzt.AllowUserToOrderColumns = true;
            this.dg_fjzt.AutoGenerateColumns = false;
            this.dg_fjzt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_fjzt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_fjzt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_fjzt.ColumnHeadersHeight = 30;
            this.dg_fjzt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_fjzt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column9,
            this.Column2,
            this.Column3,
            this.Column1,
            this.fjbh,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dg_fjzt.DataSource = this.bindingSource1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_fjzt.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_fjzt.DisplaySumRowHeader = true;
            this.dg_fjzt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_fjzt.EnableHeadersVisualStyles = false;
            this.dg_fjzt.Location = new System.Drawing.Point(0, 0);
            this.dg_fjzt.Name = "dg_fjzt";
            this.dg_fjzt.RowHeadersWidth = 60;
            this.dg_fjzt.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_fjzt.RowTemplate.Height = 30;
            this.dg_fjzt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_fjzt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_fjzt.ShowRowNumber = true;
            this.dg_fjzt.Size = new System.Drawing.Size(861, 511);
            this.dg_fjzt.SummaryColumns = new string[] {
        "fjbh"};
            this.dg_fjzt.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_fjzt.SummaryRowSpace = 10;
            this.dg_fjzt.SummaryRowVisible = true;
            this.dg_fjzt.SumRowHeaderText = "合计:";
            this.dg_fjzt.SumRowHeaderTextBold = false;
            this.dg_fjzt.TabIndex = 8;
            this.dg_fjzt.DoubleClick += new System.EventHandler(this.dg_fjzt_DoubleClick);
            this.dg_fjzt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_fjzt_KeyDown);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "选择";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 60;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "use_time";
            this.Column9.HeaderText = "次数";
            this.Column9.Name = "Column9";
            this.Column9.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "zyzt";
            this.Column2.HeaderText = "状态";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "zyzt_second";
            this.Column3.HeaderText = "参考状态";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "fjrb";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "房型";
            this.Column1.Name = "Column1";
            this.Column1.Width = 90;
            // 
            // fjbh
            // 
            this.fjbh.DataPropertyName = "fjbh";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fjbh.DefaultCellStyle = dataGridViewCellStyle3;
            this.fjbh.HeaderText = "房间编号";
            this.fjbh.Name = "fjbh";
            this.fjbh.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ddsj";
            this.Column5.HeaderText = "到达时间";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "lksj";
            this.Column6.HeaderText = "离开时间";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "yd_ddsj";
            this.Column7.HeaderText = "预订到时";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "yd_lksj";
            this.Column8.HeaderText = "预订离时";
            this.Column8.Name = "Column8";
            // 
            // btn_ttpf
            // 
            this.btn_ttpf.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ttpf.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ttpf.Image = ((System.Drawing.Image)(resources.GetObject("btn_ttpf.Image")));
            this.btn_ttpf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ttpf.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_ttpf.Location = new System.Drawing.Point(16, 13);
            this.btn_ttpf.Name = "btn_ttpf";
            this.btn_ttpf.Size = new System.Drawing.Size(73, 39);
            this.btn_ttpf.TabIndex = 12;
            this.btn_ttpf.Text = "排房";
            this.btn_ttpf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip_info.SetToolTip(this.btn_ttpf, "显示预离房");
            this.btn_ttpf.UseVisualStyleBackColor = false;
            this.btn_ttpf.Click += new System.EventHandler(this.btn_ttpf_Click);
            // 
            // b_FindMore
            // 
            this.b_FindMore.BackColor = System.Drawing.SystemColors.Control;
            this.b_FindMore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_FindMore.Image = ((System.Drawing.Image)(resources.GetObject("b_FindMore.Image")));
            this.b_FindMore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_FindMore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_FindMore.Location = new System.Drawing.Point(20, 13);
            this.b_FindMore.Name = "b_FindMore";
            this.b_FindMore.Size = new System.Drawing.Size(69, 39);
            this.b_FindMore.TabIndex = 12;
            this.b_FindMore.Text = "显示";
            this.b_FindMore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip_info.SetToolTip(this.b_FindMore, "显示预离房");
            this.b_FindMore.UseVisualStyleBackColor = false;
            this.b_FindMore.Click += new System.EventHandler(this.b_FindMore_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_FindMore);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(13, 531);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 58);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "显示当日离店房";
            // 
            // gB_pf
            // 
            this.gB_pf.Controls.Add(this.btn_ttpf);
            this.gB_pf.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gB_pf.Location = new System.Drawing.Point(138, 531);
            this.gB_pf.Name = "gB_pf";
            this.gB_pf.Size = new System.Drawing.Size(107, 58);
            this.gB_pf.TabIndex = 14;
            this.gB_pf.TabStop = false;
            this.gB_pf.Text = "排房";
            // 
            // gB_exit
            // 
            this.gB_exit.Controls.Add(this.b_no);
            this.gB_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gB_exit.Location = new System.Drawing.Point(265, 531);
            this.gB_exit.Name = "gB_exit";
            this.gB_exit.Size = new System.Drawing.Size(107, 58);
            this.gB_exit.TabIndex = 15;
            this.gB_exit.TabStop = false;
            this.gB_exit.Text = "退出";
            // 
            // b_no
            // 
            this.b_no.BackColor = System.Drawing.SystemColors.Control;
            this.b_no.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_no.Image = ((System.Drawing.Image)(resources.GetObject("b_no.Image")));
            this.b_no.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_no.Location = new System.Drawing.Point(16, 13);
            this.b_no.Name = "b_no";
            this.b_no.Padding = new System.Windows.Forms.Padding(5);
            this.b_no.Size = new System.Drawing.Size(73, 39);
            this.b_no.TabIndex = 3;
            this.b_no.Text = "退出";
            this.b_no.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_no.UseVisualStyleBackColor = false;
            this.b_no.Click += new System.EventHandler(this.b_no_Click);
            // 
            // Ffjzt_select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(885, 600);
            this.Controls.Add(this.gB_exit);
            this.Controls.Add(this.gB_pf);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ffjzt_select";
            this.Text = "房间选择";
            this.Load += new System.EventHandler(this.Ffjzt_select_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_fjzt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gB_pf.ResumeLayout(false);
            this.gB_exit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        public DataGridViewSummary dg_fjzt;
        private System.Windows.Forms.ToolTip toolTip_info;
        private System.Windows.Forms.Button btn_ttpf;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fjbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_FindMore;
        private System.Windows.Forms.GroupBox gB_pf;
        private System.Windows.Forms.GroupBox gB_exit;
        private System.Windows.Forms.Button b_no;
    }
}