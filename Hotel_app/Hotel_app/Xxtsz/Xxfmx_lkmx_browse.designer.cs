namespace Hotel_app.Xxtsz
{
    partial class Xxfmx_lkmx_browse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xxfmx_lkmx_browse));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg_xfmx_lkmx = new Hotel_app.DataGridViewSummary();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.r = new System.Windows.Forms.Panel();
            this.b_sh = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_amend = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_new = new System.Windows.Forms.Button();
            this.tB_select = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_xfmx_lkmx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.r.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dg_xfmx_lkmx);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 457);
            this.panel1.TabIndex = 10;
            // 
            // dg_xfmx_lkmx
            // 
            this.dg_xfmx_lkmx.AllowUserToAddRows = false;
            this.dg_xfmx_lkmx.AllowUserToDeleteRows = false;
            this.dg_xfmx_lkmx.AutoGenerateColumns = false;
            this.dg_xfmx_lkmx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_xfmx_lkmx.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_xfmx_lkmx.ColumnHeadersHeight = 30;
            this.dg_xfmx_lkmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_xfmx_lkmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column2,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column3,
            this.Column1});
            this.dg_xfmx_lkmx.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_xfmx_lkmx.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_xfmx_lkmx.DisplaySumRowHeader = true;
            this.dg_xfmx_lkmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_xfmx_lkmx.EnableHeadersVisualStyles = false;
            this.dg_xfmx_lkmx.Location = new System.Drawing.Point(0, 0);
            this.dg_xfmx_lkmx.Name = "dg_xfmx_lkmx";
            this.dg_xfmx_lkmx.RowTemplate.Height = 26;
            this.dg_xfmx_lkmx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_xfmx_lkmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_xfmx_lkmx.ShowRowNumber = false;
            this.dg_xfmx_lkmx.Size = new System.Drawing.Size(604, 455);
            this.dg_xfmx_lkmx.SummaryColumns = new string[] {
        "senior_dep"};
            this.dg_xfmx_lkmx.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_xfmx_lkmx.SummaryRowSpace = 0;
            this.dg_xfmx_lkmx.SummaryRowVisible = true;
            this.dg_xfmx_lkmx.SumRowHeaderText = null;
            this.dg_xfmx_lkmx.SumRowHeaderTextBold = false;
            this.dg_xfmx_lkmx.TabIndex = 5;
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
            this.Column2.DataPropertyName = "xfdr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "大类名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "xfxr";
            this.Column5.HeaderText = "小类名称";
            this.Column5.Name = "Column5";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "xfmx";
            this.Column7.HeaderText = "消费名称";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "xfsl";
            this.Column8.HeaderText = "入库数量";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "lksj";
            this.Column9.HeaderText = "入库时间";
            this.Column9.Name = "Column9";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "mxbh";
            this.Column3.HeaderText = "mxbh";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // r
            // 
            this.r.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.r.Controls.Add(this.b_sh);
            this.r.Controls.Add(this.b_delete);
            this.r.Controls.Add(this.b_amend);
            this.r.Controls.Add(this.b_exit);
            this.r.Controls.Add(this.b_new);
            this.r.Location = new System.Drawing.Point(624, 12);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(87, 455);
            this.r.TabIndex = 11;
            // 
            // b_sh
            // 
            this.b_sh.BackColor = System.Drawing.SystemColors.Control;
            this.b_sh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_sh.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_sh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_sh.Image = ((System.Drawing.Image)(resources.GetObject("b_sh.Image")));
            this.b_sh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_sh.Location = new System.Drawing.Point(12, 222);
            this.b_sh.Margin = new System.Windows.Forms.Padding(1);
            this.b_sh.Name = "b_sh";
            this.b_sh.Padding = new System.Windows.Forms.Padding(1);
            this.b_sh.Size = new System.Drawing.Size(52, 61);
            this.b_sh.TabIndex = 8;
            this.b_sh.Text = "审核";
            this.b_sh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_sh.UseVisualStyleBackColor = false;
            this.b_sh.Click += new System.EventHandler(this.b_sh_Click);
            // 
            // b_delete
            // 
            this.b_delete.BackColor = System.Drawing.SystemColors.Control;
            this.b_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_delete.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_delete.Image = ((System.Drawing.Image)(resources.GetObject("b_delete.Image")));
            this.b_delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_delete.Location = new System.Drawing.Point(12, 298);
            this.b_delete.Margin = new System.Windows.Forms.Padding(1);
            this.b_delete.Name = "b_delete";
            this.b_delete.Padding = new System.Windows.Forms.Padding(1);
            this.b_delete.Size = new System.Drawing.Size(52, 61);
            this.b_delete.TabIndex = 6;
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
            this.b_amend.Location = new System.Drawing.Point(12, 146);
            this.b_amend.Margin = new System.Windows.Forms.Padding(1);
            this.b_amend.Name = "b_amend";
            this.b_amend.Padding = new System.Windows.Forms.Padding(1);
            this.b_amend.Size = new System.Drawing.Size(52, 61);
            this.b_amend.TabIndex = 5;
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
            this.b_exit.Location = new System.Drawing.Point(12, 373);
            this.b_exit.Margin = new System.Windows.Forms.Padding(1);
            this.b_exit.Name = "b_exit";
            this.b_exit.Padding = new System.Windows.Forms.Padding(1);
            this.b_exit.Size = new System.Drawing.Size(52, 61);
            this.b_exit.TabIndex = 4;
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
            this.b_new.Location = new System.Drawing.Point(12, 71);
            this.b_new.Margin = new System.Windows.Forms.Padding(1);
            this.b_new.Name = "b_new";
            this.b_new.Padding = new System.Windows.Forms.Padding(1);
            this.b_new.Size = new System.Drawing.Size(52, 61);
            this.b_new.TabIndex = 3;
            this.b_new.Text = "新增";
            this.b_new.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_new.UseVisualStyleBackColor = false;
            this.b_new.Click += new System.EventHandler(this.b_new_Click);
            // 
            // tB_select
            // 
            this.tB_select.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_select.Location = new System.Drawing.Point(13, 474);
            this.tB_select.Name = "tB_select";
            this.tB_select.Size = new System.Drawing.Size(605, 26);
            this.tB_select.TabIndex = 12;
            this.tB_select.TextChanged += new System.EventHandler(this.tB_select_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(632, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "查询";
            // 
            // Xxfmx_lkmx_browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(722, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tB_select);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.r);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Xxfmx_lkmx_browse";
            this.Text = "入库明细管理";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_xfmx_lkmx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.r.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel r;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_amend;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_new;
        public DataGridViewSummary dg_xfmx_lkmx;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox tB_select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button b_sh;

    }
}