namespace Hotel_app.Yhgl
{
    partial class YH_czjl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YH_czjl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_last = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.b_previous = new System.Windows.Forms.Button();
            this.b_first = new System.Windows.Forms.Button();
            this.b_search = new System.Windows.Forms.Button();
            this.b_refresh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dg_yhczjl = new Hotel_app.DataGridViewSummary();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bindingSource_yhczjl = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_yhczjl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_yhczjl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 46);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Controls.Add(this.b_last);
            this.panel8.Controls.Add(this.b_next);
            this.panel8.Controls.Add(this.b_previous);
            this.panel8.Controls.Add(this.b_first);
            this.panel8.Controls.Add(this.b_search);
            this.panel8.Controls.Add(this.b_refresh);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(787, 50);
            this.panel8.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.b_exit);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(733, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(52, 48);
            this.panel11.TabIndex = 12;
            // 
            // b_exit
            // 
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_exit.Location = new System.Drawing.Point(3, 6);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(40, 40);
            this.b_exit.TabIndex = 6;
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // b_last
            // 
            this.b_last.Image = ((System.Drawing.Image)(resources.GetObject("b_last.Image")));
            this.b_last.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_last.Location = new System.Drawing.Point(244, 6);
            this.b_last.Name = "b_last";
            this.b_last.Size = new System.Drawing.Size(40, 40);
            this.b_last.TabIndex = 9;
            this.b_last.UseVisualStyleBackColor = true;
            this.b_last.Click += new System.EventHandler(this.b_last_Click);
            // 
            // b_next
            // 
            this.b_next.Image = ((System.Drawing.Image)(resources.GetObject("b_next.Image")));
            this.b_next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_next.Location = new System.Drawing.Point(198, 6);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(40, 40);
            this.b_next.TabIndex = 8;
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // b_previous
            // 
            this.b_previous.Image = ((System.Drawing.Image)(resources.GetObject("b_previous.Image")));
            this.b_previous.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_previous.Location = new System.Drawing.Point(152, 6);
            this.b_previous.Name = "b_previous";
            this.b_previous.Size = new System.Drawing.Size(40, 40);
            this.b_previous.TabIndex = 7;
            this.b_previous.UseVisualStyleBackColor = true;
            this.b_previous.Click += new System.EventHandler(this.b_previous_Click);
            // 
            // b_first
            // 
            this.b_first.Image = ((System.Drawing.Image)(resources.GetObject("b_first.Image")));
            this.b_first.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_first.Location = new System.Drawing.Point(106, 6);
            this.b_first.Name = "b_first";
            this.b_first.Size = new System.Drawing.Size(40, 40);
            this.b_first.TabIndex = 5;
            this.b_first.UseVisualStyleBackColor = true;
            this.b_first.Click += new System.EventHandler(this.b_first_Click);
            // 
            // b_search
            // 
            this.b_search.Image = ((System.Drawing.Image)(resources.GetObject("b_search.Image")));
            this.b_search.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_search.Location = new System.Drawing.Point(57, 6);
            this.b_search.Name = "b_search";
            this.b_search.Size = new System.Drawing.Size(40, 40);
            this.b_search.TabIndex = 4;
            this.b_search.UseVisualStyleBackColor = true;
            this.b_search.Click += new System.EventHandler(this.b_search_Click);
            // 
            // b_refresh
            // 
            this.b_refresh.Image = ((System.Drawing.Image)(resources.GetObject("b_refresh.Image")));
            this.b_refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_refresh.Location = new System.Drawing.Point(11, 6);
            this.b_refresh.Name = "b_refresh";
            this.b_refresh.Size = new System.Drawing.Size(40, 40);
            this.b_refresh.TabIndex = 3;
            this.b_refresh.UseVisualStyleBackColor = true;
            this.b_refresh.Click += new System.EventHandler(this.b_refresh_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 429);
            this.panel2.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dg_yhczjl);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(5, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(777, 419);
            this.panel7.TabIndex = 4;
            // 
            // dg_yhczjl
            // 
            this.dg_yhczjl.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_yhczjl.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_yhczjl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_yhczjl.ColumnHeadersHeight = 25;
            this.dg_yhczjl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_yhczjl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dg_yhczjl.DisplaySumRowHeader = true;
            this.dg_yhczjl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_yhczjl.Location = new System.Drawing.Point(0, 0);
            this.dg_yhczjl.Name = "dg_yhczjl";
            this.dg_yhczjl.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dg_yhczjl.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_yhczjl.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_yhczjl.RowTemplate.Height = 25;
            this.dg_yhczjl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_yhczjl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_yhczjl.ShowRowNumber = true;
            this.dg_yhczjl.Size = new System.Drawing.Size(777, 419);
            this.dg_yhczjl.SummaryColumns = new string[] {
        "lzfs",
        "sjfjjg",
        "fjbh",
        "fkje",
        "xfje",
        "jcje"};
            this.dg_yhczjl.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_yhczjl.SummaryRowSpace = 0;
            this.dg_yhczjl.SummaryRowVisible = true;
            this.dg_yhczjl.SumRowHeaderText = "";
            this.dg_yhczjl.SumRowHeaderTextBold = true;
            this.dg_yhczjl.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "czy";
            this.Column1.HeaderText = "操作员";
            this.Column1.Name = "Column1";
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "czsj";
            this.Column2.HeaderText = "操作时间";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "cznr";
            this.Column3.HeaderText = "操作内容";
            this.Column3.Name = "Column3";
            this.Column3.Width = 370;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "czbz";
            this.Column4.HeaderText = "操作备注";
            this.Column4.Name = "Column4";
            this.Column4.Width = 370;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "czzy";
            this.Column5.HeaderText = "操作摘要";
            this.Column5.Name = "Column5";
            this.Column5.Width = 250;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(5, 424);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(777, 5);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(782, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 424);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 424);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(787, 5);
            this.panel3.TabIndex = 0;
            // 
            // YH_czjl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 475);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "YH_czjl";
            this.Text = "用户操作记录";
            this.Load += new System.EventHandler(this.YH_czjl_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_yhczjl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_yhczjl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_last;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Button b_previous;
        private System.Windows.Forms.Button b_first;
        private System.Windows.Forms.Button b_search;
        private System.Windows.Forms.Button b_refresh;
        private DataGridViewSummary dg_yhczjl;
        private System.Windows.Forms.BindingSource bindingSource_yhczjl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}