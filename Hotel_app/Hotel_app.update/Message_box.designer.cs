namespace Hotel_app.update
{
    partial class Message_box
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Message_box));
            this.tB_content = new System.Windows.Forms.TextBox();
            this.b_yes = new System.Windows.Forms.Button();
            this.b_no = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.b_confirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_content
            // 
            this.tB_content.BackColor = System.Drawing.Color.DarkGreen;
            this.tB_content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_content.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_content.ForeColor = System.Drawing.SystemColors.Window;
            this.tB_content.Location = new System.Drawing.Point(72, 14);
            this.tB_content.Multiline = true;
            this.tB_content.Name = "tB_content";
            this.tB_content.Size = new System.Drawing.Size(550, 60);
            this.tB_content.TabIndex = 3;
            this.tB_content.Text = "请维持好秩序";
            this.tB_content.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // b_yes
            // 
            this.b_yes.BackColor = System.Drawing.Color.DimGray;
            this.b_yes.ForeColor = System.Drawing.SystemColors.Window;
            this.b_yes.Image = ((System.Drawing.Image)(resources.GetObject("b_yes.Image")));
            this.b_yes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_yes.Location = new System.Drawing.Point(189, 80);
            this.b_yes.Name = "b_yes";
            this.b_yes.Padding = new System.Windows.Forms.Padding(5);
            this.b_yes.Size = new System.Drawing.Size(95, 44);
            this.b_yes.TabIndex = 0;
            this.b_yes.Text = "是";
            this.b_yes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_yes.UseVisualStyleBackColor = false;
            this.b_yes.Visible = false;
            this.b_yes.Click += new System.EventHandler(this.b_yes_Click);
            // 
            // b_no
            // 
            this.b_no.BackColor = System.Drawing.Color.DimGray;
            this.b_no.ForeColor = System.Drawing.SystemColors.Window;
            this.b_no.Image = ((System.Drawing.Image)(resources.GetObject("b_no.Image")));
            this.b_no.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_no.Location = new System.Drawing.Point(409, 80);
            this.b_no.Name = "b_no";
            this.b_no.Padding = new System.Windows.Forms.Padding(5);
            this.b_no.Size = new System.Drawing.Size(95, 44);
            this.b_no.TabIndex = 1;
            this.b_no.Text = "否";
            this.b_no.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_no.UseVisualStyleBackColor = false;
            this.b_no.Visible = false;
            this.b_no.Click += new System.EventHandler(this.b_no_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // b_confirm
            // 
            this.b_confirm.BackColor = System.Drawing.Color.DimGray;
            this.b_confirm.ForeColor = System.Drawing.SystemColors.Window;
            this.b_confirm.Image = ((System.Drawing.Image)(resources.GetObject("b_confirm.Image")));
            this.b_confirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_confirm.Location = new System.Drawing.Point(299, 80);
            this.b_confirm.Name = "b_confirm";
            this.b_confirm.Padding = new System.Windows.Forms.Padding(5);
            this.b_confirm.Size = new System.Drawing.Size(95, 44);
            this.b_confirm.TabIndex = 2;
            this.b_confirm.Text = "确定";
            this.b_confirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_confirm.UseVisualStyleBackColor = false;
            this.b_confirm.Visible = false;
            this.b_confirm.Click += new System.EventHandler(this.b_confirm_Click);
            // 
            // Message_box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(628, 133);
            this.Controls.Add(this.b_confirm);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.b_no);
            this.Controls.Add(this.b_yes);
            this.Controls.Add(this.tB_content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Message_box";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Massage_box";
            this.Load += new System.EventHandler(this.Massage_box_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_content;
        private System.Windows.Forms.Button b_yes;
        private System.Windows.Forms.Button b_no;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button b_confirm;
    }
}