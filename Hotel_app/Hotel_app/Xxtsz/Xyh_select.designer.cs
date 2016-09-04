namespace Hotel_app.Xxtsz
{
    partial class Xyh_select
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
            this.dg_yhbl = new Hotel_app.DataGridViewSummary();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_yhbl)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_yhbl
            // 
            this.dg_yhbl.AllowUserToAddRows = false;
            this.dg_yhbl.AutoGenerateColumns = false;
            this.dg_yhbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_yhbl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_yhbl.ColumnHeadersHeight = 30;
            this.dg_yhbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_yhbl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dg_yhbl.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_yhbl.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_yhbl.DisplaySumRowHeader = true;
            this.dg_yhbl.EnableHeadersVisualStyles = false;
            this.dg_yhbl.Location = new System.Drawing.Point(8, 8);
            this.dg_yhbl.Name = "dg_yhbl";
            this.dg_yhbl.ReadOnly = true;
            this.dg_yhbl.RowTemplate.Height = 26;
            this.dg_yhbl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_yhbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_yhbl.ShowRowNumber = false;
            this.dg_yhbl.Size = new System.Drawing.Size(343, 356);
            this.dg_yhbl.SummaryColumns = new string[] {
        "krgj"};
            this.dg_yhbl.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_yhbl.SummaryRowSpace = 0;
            this.dg_yhbl.SummaryRowVisible = true;
            this.dg_yhbl.SumRowHeaderText = null;
            this.dg_yhbl.SumRowHeaderTextBold = false;
            this.dg_yhbl.TabIndex = 7;
            this.dg_yhbl.DoubleClick += new System.EventHandler(this.dg_yhbl_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "yh";
            this.Column1.HeaderText = "优惠";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "yhbl";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "优惠比率";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Xyh_select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(363, 376);
            this.Controls.Add(this.dg_yhbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Xyh_select";
            this.Text = "优惠";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_yhbl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DataGridViewSummary dg_yhbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}