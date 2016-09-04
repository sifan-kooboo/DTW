namespace Hotel_app.Ffjzt
{
    partial class Fwx_other_browse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fwx_other_browse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.b_research = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_amend = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_new = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dg_wx_other = new Hotel_app.DataGridViewSummary();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fjbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_wx_other)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 422);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.b_research);
            this.panel3.Controls.Add(this.b_delete);
            this.panel3.Controls.Add(this.b_amend);
            this.panel3.Controls.Add(this.b_exit);
            this.panel3.Controls.Add(this.b_new);
            this.panel3.Location = new System.Drawing.Point(717, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(81, 394);
            this.panel3.TabIndex = 1;
            // 
            // b_research
            // 
            this.b_research.BackColor = System.Drawing.SystemColors.Control;
            this.b_research.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_research.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_research.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_research.Image = ((System.Drawing.Image)(resources.GetObject("b_research.Image")));
            this.b_research.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_research.Location = new System.Drawing.Point(10, 240);
            this.b_research.Margin = new System.Windows.Forms.Padding(1);
            this.b_research.Name = "b_research";
            this.b_research.Padding = new System.Windows.Forms.Padding(1);
            this.b_research.Size = new System.Drawing.Size(59, 59);
            this.b_research.TabIndex = 8;
            this.b_research.Text = "过滤";
            this.b_research.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_research.UseVisualStyleBackColor = false;
            // 
            // b_delete
            // 
            this.b_delete.BackColor = System.Drawing.SystemColors.Control;
            this.b_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_delete.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_delete.Image = ((System.Drawing.Image)(resources.GetObject("b_delete.Image")));
            this.b_delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_delete.Location = new System.Drawing.Point(10, 168);
            this.b_delete.Margin = new System.Windows.Forms.Padding(1);
            this.b_delete.Name = "b_delete";
            this.b_delete.Padding = new System.Windows.Forms.Padding(1);
            this.b_delete.Size = new System.Drawing.Size(59, 59);
            this.b_delete.TabIndex = 7;
            this.b_delete.Text = "删除";
            this.b_delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_delete.UseVisualStyleBackColor = false;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // b_amend
            // 
            this.b_amend.BackColor = System.Drawing.SystemColors.Control;
            this.b_amend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_amend.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_amend.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_amend.Image = ((System.Drawing.Image)(resources.GetObject("b_amend.Image")));
            this.b_amend.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_amend.Location = new System.Drawing.Point(10, 96);
            this.b_amend.Margin = new System.Windows.Forms.Padding(1);
            this.b_amend.Name = "b_amend";
            this.b_amend.Padding = new System.Windows.Forms.Padding(1);
            this.b_amend.Size = new System.Drawing.Size(59, 59);
            this.b_amend.TabIndex = 6;
            this.b_amend.Text = "修改";
            this.b_amend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_amend.UseVisualStyleBackColor = false;
            this.b_amend.Click += new System.EventHandler(this.b_amend_Click);
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_exit.Location = new System.Drawing.Point(10, 312);
            this.b_exit.Margin = new System.Windows.Forms.Padding(1);
            this.b_exit.Name = "b_exit";
            this.b_exit.Padding = new System.Windows.Forms.Padding(1);
            this.b_exit.Size = new System.Drawing.Size(59, 59);
            this.b_exit.TabIndex = 5;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // b_new
            // 
            this.b_new.BackColor = System.Drawing.SystemColors.Control;
            this.b_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_new.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_new.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_new.Image = ((System.Drawing.Image)(resources.GetObject("b_new.Image")));
            this.b_new.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_new.Location = new System.Drawing.Point(10, 24);
            this.b_new.Margin = new System.Windows.Forms.Padding(1);
            this.b_new.Name = "b_new";
            this.b_new.Padding = new System.Windows.Forms.Padding(1);
            this.b_new.Size = new System.Drawing.Size(59, 59);
            this.b_new.TabIndex = 4;
            this.b_new.Text = "新增";
            this.b_new.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_new.UseVisualStyleBackColor = false;
            this.b_new.Click += new System.EventHandler(this.b_new_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dg_wx_other);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 396);
            this.panel2.TabIndex = 0;
            // 
            // dg_wx_other
            // 
            this.dg_wx_other.AllowUserToAddRows = false;
            this.dg_wx_other.AllowUserToDeleteRows = false;
            this.dg_wx_other.AutoGenerateColumns = false;
            this.dg_wx_other.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_wx_other.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_wx_other.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_wx_other.ColumnHeadersHeight = 30;
            this.dg_wx_other.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_wx_other.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column2,
            this.Column3,
            this.Column1,
            this.fjbh,
            this.Column6,
            this.Column5});
            this.dg_wx_other.DataSource = this.bindingSource1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_wx_other.DefaultCellStyle = dataGridViewCellStyle5;
            this.dg_wx_other.DisplaySumRowHeader = true;
            this.dg_wx_other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_wx_other.EnableHeadersVisualStyles = false;
            this.dg_wx_other.Location = new System.Drawing.Point(0, 0);
            this.dg_wx_other.Name = "dg_wx_other";
            this.dg_wx_other.RowHeadersWidth = 60;
            this.dg_wx_other.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_wx_other.RowTemplate.Height = 30;
            this.dg_wx_other.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_wx_other.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_wx_other.ShowRowNumber = true;
            this.dg_wx_other.Size = new System.Drawing.Size(697, 394);
            this.dg_wx_other.SummaryColumns = new string[] {
        "fjbh"};
            this.dg_wx_other.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_wx_other.SummaryRowSpace = 0;
            this.dg_wx_other.SummaryRowVisible = true;
            this.dg_wx_other.SumRowHeaderText = null;
            this.dg_wx_other.SumRowHeaderTextBold = false;
            this.dg_wx_other.TabIndex = 9;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "选择";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "zyzt";
            this.Column2.HeaderText = "状态";
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "fjbh";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "房号";
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ddsj";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "开始时间";
            this.Column1.Name = "Column1";
            this.Column1.Width = 110;
            // 
            // fjbh
            // 
            this.fjbh.DataPropertyName = "lksj";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fjbh.DefaultCellStyle = dataGridViewCellStyle4;
            this.fjbh.HeaderText = "结束时间";
            this.fjbh.Name = "fjbh";
            this.fjbh.Width = 110;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "czy";
            this.Column6.HeaderText = "操作人员";
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "czsj";
            this.Column5.HeaderText = "设置时间";
            this.Column5.Name = "Column5";
            this.Column5.Width = 110;
            // 
            // Fwx_other_browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(810, 422);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Fwx_other_browse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "维修_其他房";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_wx_other)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public DataGridViewSummary dg_wx_other;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button b_new;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_amend;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_research;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fjbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}