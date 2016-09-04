namespace Hotel_app.Xxtsz
{
    partial class Xkrgj_select
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
            this.dg_gj = new Hotel_app.DataGridViewSummary();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tB_select = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_gj)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dg_gj);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 414);
            this.panel1.TabIndex = 1;
            // 
            // dg_gj
            // 
            this.dg_gj.AllowUserToAddRows = false;
            this.dg_gj.AutoGenerateColumns = false;
            this.dg_gj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_gj.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_gj.ColumnHeadersHeight = 30;
            this.dg_gj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_gj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dg_gj.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_gj.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_gj.DisplaySumRowHeader = true;
            this.dg_gj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_gj.EnableHeadersVisualStyles = false;
            this.dg_gj.Location = new System.Drawing.Point(0, 0);
            this.dg_gj.Name = "dg_gj";
            this.dg_gj.ReadOnly = true;
            this.dg_gj.RowTemplate.Height = 26;
            this.dg_gj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_gj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_gj.ShowRowNumber = true;
            this.dg_gj.Size = new System.Drawing.Size(363, 412);
            this.dg_gj.SummaryColumns = new string[] {
        "krgj"};
            this.dg_gj.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_gj.SummaryRowSpace = 0;
            this.dg_gj.SummaryRowVisible = true;
            this.dg_gj.SumRowHeaderText = null;
            this.dg_gj.SumRowHeaderTextBold = false;
            this.dg_gj.TabIndex = 6;
            this.dg_gj.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_gj_ColumnHeaderMouseClick);
            this.dg_gj.DoubleClick += new System.EventHandler(this.dg_gj_DoubleClick);
            this.dg_gj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_gj_KeyDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "pq";
            this.Column1.HeaderText = "片区";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "krgj";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "国家";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // tB_select
            // 
            this.tB_select.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_select.Location = new System.Drawing.Point(13, 431);
            this.tB_select.Name = "tB_select";
            this.tB_select.Size = new System.Drawing.Size(363, 26);
            this.tB_select.TabIndex = 2;
            this.tB_select.TextChanged += new System.EventHandler(this.tB_select_TextChanged);
            this.tB_select.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_gj_KeyDown);
            // 
            // Xkrgj_select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(393, 466);
            this.Controls.Add(this.tB_select);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Xkrgj_select";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "国家";
            this.Load += new System.EventHandler(this.Xgj_select_Load);
            this.Shown += new System.EventHandler(this.Xkrgj_select_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_gj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        public DataGridViewSummary dg_gj;
        private System.Windows.Forms.TextBox tB_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}