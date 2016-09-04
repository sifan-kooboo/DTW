namespace Hotel_app.Yhgl
{
    partial class YH_User_browse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YH_User_browse));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg_yhgl = new Hotel_app.DataGridViewSummary();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.r = new System.Windows.Forms.Panel();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_amend = new System.Windows.Forms.Button();
            this.b_new = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_yhgl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.r.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dg_yhgl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 467);
            this.panel1.TabIndex = 13;
            // 
            // dg_yhgl
            // 
            this.dg_yhgl.AllowUserToAddRows = false;
            this.dg_yhgl.AutoGenerateColumns = false;
            this.dg_yhgl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_yhgl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_yhgl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_yhgl.ColumnHeadersHeight = 30;
            this.dg_yhgl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_yhgl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3});
            this.dg_yhgl.DataSource = this.bindingSource1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_yhgl.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_yhgl.DisplaySumRowHeader = true;
            this.dg_yhgl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_yhgl.EnableHeadersVisualStyles = false;
            this.dg_yhgl.Location = new System.Drawing.Point(0, 0);
            this.dg_yhgl.Name = "dg_yhgl";
            this.dg_yhgl.RowTemplate.Height = 26;
            this.dg_yhgl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_yhgl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_yhgl.ShowRowNumber = true;
            this.dg_yhgl.Size = new System.Drawing.Size(464, 465);
            this.dg_yhgl.SummaryColumns = new string[] {
        "senior_dep"};
            this.dg_yhgl.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_yhgl.SummaryRowSpace = 0;
            this.dg_yhgl.SummaryRowVisible = true;
            this.dg_yhgl.SumRowHeaderText = null;
            this.dg_yhgl.SumRowHeaderTextBold = false;
            this.dg_yhgl.TabIndex = 5;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "选择";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 60;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "yhbh";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "yhxm";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "用户名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "yhbm";
            this.Column5.HeaderText = "用户部门";
            this.Column5.Name = "Column5";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RoleName";
            this.Column3.HeaderText = "角色";
            this.Column3.Name = "Column3";
            // 
            // r
            // 
            this.r.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.r.Controls.Add(this.b_delete);
            this.r.Controls.Add(this.b_exit);
            this.r.Controls.Add(this.b_amend);
            this.r.Controls.Add(this.b_new);
            this.r.Location = new System.Drawing.Point(483, 12);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(87, 466);
            this.r.TabIndex = 14;
            // 
            // b_delete
            // 
            this.b_delete.BackColor = System.Drawing.SystemColors.Control;
            this.b_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_delete.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_delete.Image = ((System.Drawing.Image)(resources.GetObject("b_delete.Image")));
            this.b_delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_delete.Location = new System.Drawing.Point(14, 307);
            this.b_delete.Margin = new System.Windows.Forms.Padding(1);
            this.b_delete.Name = "b_delete";
            this.b_delete.Padding = new System.Windows.Forms.Padding(1);
            this.b_delete.Size = new System.Drawing.Size(54, 61);
            this.b_delete.TabIndex = 6;
            this.b_delete.Text = "删除";
            this.b_delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_delete.UseVisualStyleBackColor = false;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_exit.Location = new System.Drawing.Point(14, 382);
            this.b_exit.Margin = new System.Windows.Forms.Padding(1);
            this.b_exit.Name = "b_exit";
            this.b_exit.Padding = new System.Windows.Forms.Padding(1);
            this.b_exit.Size = new System.Drawing.Size(54, 61);
            this.b_exit.TabIndex = 4;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // b_amend
            // 
            this.b_amend.BackColor = System.Drawing.SystemColors.Control;
            this.b_amend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_amend.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_amend.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_amend.Image = ((System.Drawing.Image)(resources.GetObject("b_amend.Image")));
            this.b_amend.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_amend.Location = new System.Drawing.Point(14, 231);
            this.b_amend.Margin = new System.Windows.Forms.Padding(1);
            this.b_amend.Name = "b_amend";
            this.b_amend.Padding = new System.Windows.Forms.Padding(1);
            this.b_amend.Size = new System.Drawing.Size(54, 61);
            this.b_amend.TabIndex = 5;
            this.b_amend.Text = "修改";
            this.b_amend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_amend.UseVisualStyleBackColor = false;
            this.b_amend.Click += new System.EventHandler(this.b_amend_Click);
            // 
            // b_new
            // 
            this.b_new.BackColor = System.Drawing.SystemColors.Control;
            this.b_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_new.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_new.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_new.Image = ((System.Drawing.Image)(resources.GetObject("b_new.Image")));
            this.b_new.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_new.Location = new System.Drawing.Point(14, 156);
            this.b_new.Margin = new System.Windows.Forms.Padding(1);
            this.b_new.Name = "b_new";
            this.b_new.Padding = new System.Windows.Forms.Padding(1);
            this.b_new.Size = new System.Drawing.Size(54, 61);
            this.b_new.TabIndex = 3;
            this.b_new.Text = "新增";
            this.b_new.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_new.UseVisualStyleBackColor = false;
            this.b_new.Click += new System.EventHandler(this.b_new_Click);
            // 
            // YH_User_browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(580, 488);
            this.Controls.Add(this.r);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "YH_User_browse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "用户管理";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_yhgl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.r.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public DataGridViewSummary dg_yhgl;
        private System.Windows.Forms.Panel r;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_amend;
        private System.Windows.Forms.Button b_new;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}