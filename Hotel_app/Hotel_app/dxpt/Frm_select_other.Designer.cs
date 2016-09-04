namespace Hotel_app.dxpt
{
    partial class Frm_select_other
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.b_selectFile = new System.Windows.Forms.Button();
            this.tB_0 = new System.Windows.Forms.TextBox();
            this.p_button = new System.Windows.Forms.Panel();
            this.b_inportInfo = new System.Windows.Forms.Button();
            this.b_cancell = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.p_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.p_button);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "外部内容导入";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.b_selectFile);
            this.panel1.Controls.Add(this.tB_0);
            this.panel1.Location = new System.Drawing.Point(19, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 95);
            this.panel1.TabIndex = 96;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "请选择您要导入文件：";
            // 
            // b_selectFile
            // 
            this.b_selectFile.Location = new System.Drawing.Point(251, 42);
            this.b_selectFile.Name = "b_selectFile";
            this.b_selectFile.Size = new System.Drawing.Size(80, 23);
            this.b_selectFile.TabIndex = 92;
            this.b_selectFile.Text = "选择文件...";
            this.b_selectFile.UseVisualStyleBackColor = true;
            this.b_selectFile.Click += new System.EventHandler(this.b_in_Click);
            // 
            // tB_0
            // 
            this.tB_0.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_0.ForeColor = System.Drawing.Color.Red;
            this.tB_0.Location = new System.Drawing.Point(14, 40);
            this.tB_0.Name = "tB_0";
            this.tB_0.Size = new System.Drawing.Size(231, 26);
            this.tB_0.TabIndex = 91;
            // 
            // p_button
            // 
            this.p_button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_button.Controls.Add(this.b_inportInfo);
            this.p_button.Controls.Add(this.b_cancell);
            this.p_button.Location = new System.Drawing.Point(19, 121);
            this.p_button.Name = "p_button";
            this.p_button.Size = new System.Drawing.Size(346, 54);
            this.p_button.TabIndex = 95;
            // 
            // b_inportInfo
            // 
            this.b_inportInfo.Location = new System.Drawing.Point(49, 13);
            this.b_inportInfo.Name = "b_inportInfo";
            this.b_inportInfo.Size = new System.Drawing.Size(75, 23);
            this.b_inportInfo.TabIndex = 93;
            this.b_inportInfo.Text = "导入";
            this.b_inportInfo.UseVisualStyleBackColor = true;
            this.b_inportInfo.Click += new System.EventHandler(this.b_inportInfo_Click);
            // 
            // b_cancell
            // 
            this.b_cancell.Location = new System.Drawing.Point(188, 13);
            this.b_cancell.Name = "b_cancell";
            this.b_cancell.Size = new System.Drawing.Size(75, 23);
            this.b_cancell.TabIndex = 94;
            this.b_cancell.Text = "取消";
            this.b_cancell.UseVisualStyleBackColor = true;
            this.b_cancell.Click += new System.EventHandler(this.b_cancell_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 7F);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 10);
            this.label2.TabIndex = 94;
            this.label2.Text = "*注意:导入文件格式为：姓名，手机号，备注信息*";
            // 
            // Frm_select_other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 181);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_select_other";
            this.Text = "数据源－文件";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.p_button.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_selectFile;
        public System.Windows.Forms.TextBox tB_0;
        private System.Windows.Forms.Panel p_button;
        private System.Windows.Forms.Button b_cancell;
        private System.Windows.Forms.Button b_inportInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
    }
}