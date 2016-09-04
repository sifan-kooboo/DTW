namespace Hotel_app.Qyddj
{
    partial class Q_lskr_xf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Q_lskr_xf));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.b_exportToExcel = new System.Windows.Forms.Button();
            this.b_mx = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_last = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.b_previous = new System.Windows.Forms.Button();
            this.b_first = new System.Windows.Forms.Button();
            this.b_search = new System.Windows.Forms.Button();
            this.b_refresh = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dg_lskr = new Hotel_app.DataGridViewSummary();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_lskr)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.b_exportToExcel);
            this.panel2.Controls.Add(this.b_mx);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.b_last);
            this.panel2.Controls.Add(this.b_next);
            this.panel2.Controls.Add(this.b_previous);
            this.panel2.Controls.Add(this.b_first);
            this.panel2.Controls.Add(this.b_search);
            this.panel2.Controls.Add(this.b_refresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 50);
            this.panel2.TabIndex = 1;
            // 
            // b_exportToExcel
            // 
            this.b_exportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("b_exportToExcel.Image")));
            this.b_exportToExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_exportToExcel.Location = new System.Drawing.Point(157, 5);
            this.b_exportToExcel.Name = "b_exportToExcel";
            this.b_exportToExcel.Size = new System.Drawing.Size(40, 40);
            this.b_exportToExcel.TabIndex = 20;
            this.toolTip1.SetToolTip(this.b_exportToExcel, "导出到Excel");
            this.b_exportToExcel.UseVisualStyleBackColor = true;
            this.b_exportToExcel.Click += new System.EventHandler(this.b_exportToExcel_Click);
            // 
            // b_mx
            // 
            this.b_mx.Image = ((System.Drawing.Image)(resources.GetObject("b_mx.Image")));
            this.b_mx.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_mx.Location = new System.Drawing.Point(12, 4);
            this.b_mx.Name = "b_mx";
            this.b_mx.Size = new System.Drawing.Size(41, 40);
            this.b_mx.TabIndex = 19;
            this.toolTip1.SetToolTip(this.b_mx, "消费明细查看");
            this.b_mx.UseVisualStyleBackColor = true;
            this.b_mx.Click += new System.EventHandler(this.b_mx_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.b_exit);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(755, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(61, 48);
            this.panel11.TabIndex = 18;
            // 
            // b_exit
            // 
            this.b_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_exit.Location = new System.Drawing.Point(21, 0);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(40, 48);
            this.b_exit.TabIndex = 6;
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Visible = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // b_last
            // 
            this.b_last.Image = ((System.Drawing.Image)(resources.GetObject("b_last.Image")));
            this.b_last.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_last.Location = new System.Drawing.Point(349, 4);
            this.b_last.Name = "b_last";
            this.b_last.Size = new System.Drawing.Size(40, 40);
            this.b_last.TabIndex = 9;
            this.toolTip1.SetToolTip(this.b_last, "末条");
            this.b_last.UseVisualStyleBackColor = true;
            this.b_last.Click += new System.EventHandler(this.b_last_Click);
            // 
            // b_next
            // 
            this.b_next.Image = ((System.Drawing.Image)(resources.GetObject("b_next.Image")));
            this.b_next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_next.Location = new System.Drawing.Point(301, 5);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(40, 40);
            this.b_next.TabIndex = 8;
            this.toolTip1.SetToolTip(this.b_next, "下一条");
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // b_previous
            // 
            this.b_previous.Image = ((System.Drawing.Image)(resources.GetObject("b_previous.Image")));
            this.b_previous.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_previous.Location = new System.Drawing.Point(253, 4);
            this.b_previous.Name = "b_previous";
            this.b_previous.Size = new System.Drawing.Size(40, 40);
            this.b_previous.TabIndex = 7;
            this.toolTip1.SetToolTip(this.b_previous, "上一条");
            this.b_previous.UseVisualStyleBackColor = true;
            this.b_previous.Click += new System.EventHandler(this.b_previous_Click);
            // 
            // b_first
            // 
            this.b_first.Image = ((System.Drawing.Image)(resources.GetObject("b_first.Image")));
            this.b_first.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_first.Location = new System.Drawing.Point(205, 4);
            this.b_first.Name = "b_first";
            this.b_first.Size = new System.Drawing.Size(40, 40);
            this.b_first.TabIndex = 5;
            this.toolTip1.SetToolTip(this.b_first, "首条记录");
            this.b_first.UseVisualStyleBackColor = true;
            this.b_first.Click += new System.EventHandler(this.b_first_Click);
            // 
            // b_search
            // 
            this.b_search.Image = ((System.Drawing.Image)(resources.GetObject("b_search.Image")));
            this.b_search.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_search.Location = new System.Drawing.Point(109, 4);
            this.b_search.Name = "b_search";
            this.b_search.Size = new System.Drawing.Size(40, 40);
            this.b_search.TabIndex = 4;
            this.toolTip1.SetToolTip(this.b_search, "过滤");
            this.b_search.UseVisualStyleBackColor = true;
            this.b_search.Click += new System.EventHandler(this.b_search_Click);
            // 
            // b_refresh
            // 
            this.b_refresh.Image = ((System.Drawing.Image)(resources.GetObject("b_refresh.Image")));
            this.b_refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_refresh.Location = new System.Drawing.Point(61, 4);
            this.b_refresh.Name = "b_refresh";
            this.b_refresh.Size = new System.Drawing.Size(40, 40);
            this.b_refresh.TabIndex = 3;
            this.toolTip1.SetToolTip(this.b_refresh, "刷新");
            this.b_refresh.UseVisualStyleBackColor = true;
            this.b_refresh.Click += new System.EventHandler(this.b_refresh_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(10, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(798, 10);
            this.panel4.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(46, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 100);
            this.panel5.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(10, 374);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(798, 10);
            this.panel9.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Location = new System.Drawing.Point(46, 50);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(200, 100);
            this.panel10.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(808, 50);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(10, 334);
            this.panel8.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 50);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 334);
            this.panel6.TabIndex = 7;
            // 
            // dg_lskr
            // 
            this.dg_lskr.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_lskr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_lskr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_lskr.ColumnHeadersHeight = 25;
            this.dg_lskr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_lskr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column6,
            this.totalCost});
            this.dg_lskr.DisplaySumRowHeader = true;
            this.dg_lskr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_lskr.Location = new System.Drawing.Point(10, 60);
            this.dg_lskr.Name = "dg_lskr";
            this.dg_lskr.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dg_lskr.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_lskr.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_lskr.RowTemplate.Height = 25;
            this.dg_lskr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_lskr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_lskr.ShowRowNumber = true;
            this.dg_lskr.Size = new System.Drawing.Size(798, 314);
            this.dg_lskr.SummaryColumns = new string[] {
        "fjbh"};
            this.dg_lskr.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_lskr.SummaryRowSpace = 0;
            this.dg_lskr.SummaryRowVisible = true;
            this.dg_lskr.SumRowHeaderText = "";
            this.dg_lskr.SumRowHeaderTextBold = true;
            this.dg_lskr.TabIndex = 34;
            this.dg_lskr.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_lskr_CellDoubleClick);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "krxm";
            this.Column3.HeaderText = "姓名";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 220;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "yxzj";
            this.Column4.HeaderText = "证件类型";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 250;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "zjhm";
            this.Column6.HeaderText = "证件号码";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 250;
            // 
            // totalCost
            // 
            this.totalCost.DataPropertyName = "totalCost";
            this.totalCost.HeaderText = "消费累计";
            this.totalCost.Name = "totalCost";
            this.totalCost.ReadOnly = true;
            this.totalCost.Width = 150;
            // 
            // Q_lskr_xf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 384);
            this.Controls.Add(this.dg_lskr);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Name = "Q_lskr_xf";
            this.Text = "历史客人消费记录查询";
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_lskr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_last;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Button b_previous;
        private System.Windows.Forms.Button b_first;
        private System.Windows.Forms.Button b_search;
        private System.Windows.Forms.Button b_refresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private DataGridViewSummary dg_lskr;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button b_mx;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button b_exportToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCost;


    }
}