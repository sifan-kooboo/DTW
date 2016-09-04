namespace Hotel_app.Xxtsz
{
    partial class X_common_one
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg_common = new Hotel_app.DataGridViewSummary();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tB_select = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_common)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dg_common);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 409);
            this.panel1.TabIndex = 2;
            // 
            // dg_common
            // 
            this.dg_common.AllowUserToAddRows = false;
            this.dg_common.AllowUserToResizeRows = false;
            this.dg_common.AutoGenerateColumns = false;
            this.dg_common.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_common.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_common.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_common.ColumnHeadersHeight = 30;
            this.dg_common.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_common.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dg_common.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_common.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_common.DisplaySumRowHeader = true;
            this.dg_common.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_common.EnableHeadersVisualStyles = false;
            this.dg_common.Location = new System.Drawing.Point(0, 0);
            this.dg_common.Name = "dg_common";
            this.dg_common.ReadOnly = true;
            this.dg_common.RowTemplate.Height = 26;
            this.dg_common.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_common.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_common.ShowRowNumber = true;
            this.dg_common.Size = new System.Drawing.Size(277, 407);
            this.dg_common.SummaryColumns = new string[] {
        "krly"};
            this.dg_common.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_common.SummaryRowSpace = 0;
            this.dg_common.SummaryRowVisible = true;
            this.dg_common.SumRowHeaderText = null;
            this.dg_common.SumRowHeaderTextBold = false;
            this.dg_common.TabIndex = 6;
            this.dg_common.DoubleClick += new System.EventHandler(this.dg_common_DoubleClick);
            this.dg_common.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_common_KeyDown);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "krly";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "有效证件";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // tB_select
            // 
            this.tB_select.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_select.Location = new System.Drawing.Point(12, 427);
            this.tB_select.Name = "tB_select";
            this.tB_select.Size = new System.Drawing.Size(280, 26);
            this.tB_select.TabIndex = 3;
            this.tB_select.TextChanged += new System.EventHandler(this.tB_select_TextChanged);
            this.tB_select.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_common_KeyDown);
            // 
            // X_common_one
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(304, 460);
            this.Controls.Add(this.tB_select);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "X_common_one";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "选择";
            this.Load += new System.EventHandler(this.X_common_one_Load);
            this.Shown += new System.EventHandler(this.X_common_one_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_common)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public DataGridViewSummary dg_common;
        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox tB_select;
    }
}