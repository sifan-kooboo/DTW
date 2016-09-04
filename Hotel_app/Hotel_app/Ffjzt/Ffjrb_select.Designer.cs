namespace Hotel_app.Ffjzt
{
    partial class Ffjrb_select
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg_fjrb = new Hotel_app.DataGridViewSummary();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_fjrb)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dg_fjrb);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 332);
            this.panel1.TabIndex = 0;
            // 
            // dg_fjrb
            // 
            this.dg_fjrb.AllowUserToAddRows = false;
            this.dg_fjrb.AutoGenerateColumns = false;
            this.dg_fjrb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_fjrb.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_fjrb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_fjrb.ColumnHeadersHeight = 30;
            this.dg_fjrb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_fjrb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dg_fjrb.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_fjrb.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_fjrb.DisplaySumRowHeader = true;
            this.dg_fjrb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_fjrb.EnableHeadersVisualStyles = false;
            this.dg_fjrb.Location = new System.Drawing.Point(0, 0);
            this.dg_fjrb.Name = "dg_fjrb";
            this.dg_fjrb.RowTemplate.Height = 26;
            this.dg_fjrb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_fjrb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_fjrb.ShowRowNumber = true;
            this.dg_fjrb.Size = new System.Drawing.Size(279, 332);
            this.dg_fjrb.SummaryColumns = new string[] {
        "fjrb"};
            this.dg_fjrb.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_fjrb.SummaryRowSpace = 10;
            this.dg_fjrb.SummaryRowVisible = true;
            this.dg_fjrb.SumRowHeaderText = "合计:";
            this.dg_fjrb.SumRowHeaderTextBold = false;
            this.dg_fjrb.TabIndex = 6;
            this.dg_fjrb.DoubleClick += new System.EventHandler(this.dataGridViewSummary1_DoubleClick);
            this.dg_fjrb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ffjrb_select_KeyDown);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "fjrb";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "房类";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Ffjrb_select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(304, 356);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Ffjrb_select";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "房型选择";
             this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ffjrb_select_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_fjrb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        public DataGridViewSummary dg_fjrb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}