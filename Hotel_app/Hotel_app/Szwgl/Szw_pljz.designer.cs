namespace Hotel_app.Szwgl
{
    partial class Szw_pljz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Szw_pljz));
            this.p_xfxm = new System.Windows.Forms.Panel();
            this.cb_pjfs = new System.Windows.Forms.ComboBox();
            this.lbl_pjfs = new System.Windows.Forms.Label();
            this.dt_end = new System.Windows.Forms.DateTimePicker();
            this.lbl_zzsj = new System.Windows.Forms.Label();
            this.dt_start = new System.Windows.Forms.DateTimePicker();
            this.tB_xfbz = new System.Windows.Forms.TextBox();
            this.l_xfbz = new System.Windows.Forms.Label();
            this.tB_pjlx = new System.Windows.Forms.TextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.b_gzdw = new System.Windows.Forms.Button();
            this.tB_xfje = new System.Windows.Forms.TextBox();
            this.l_pjje = new System.Windows.Forms.Label();
            this.l_qssj = new System.Windows.Forms.Label();
            this.b_find = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.tB_gzdw = new System.Windows.Forms.TextBox();
            this.lbl_gzdw = new System.Windows.Forms.Label();
            this.tpinfo = new System.Windows.Forms.ToolTip(this.components);
            this.p_xfxm.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_xfxm
            // 
            this.p_xfxm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_xfxm.Controls.Add(this.cb_pjfs);
            this.p_xfxm.Controls.Add(this.lbl_pjfs);
            this.p_xfxm.Controls.Add(this.dt_end);
            this.p_xfxm.Controls.Add(this.lbl_zzsj);
            this.p_xfxm.Controls.Add(this.dt_start);
            this.p_xfxm.Controls.Add(this.tB_xfbz);
            this.p_xfxm.Controls.Add(this.l_xfbz);
            this.p_xfxm.Controls.Add(this.tB_pjlx);
            this.p_xfxm.Controls.Add(this.lbl_status);
            this.p_xfxm.Controls.Add(this.b_gzdw);
            this.p_xfxm.Controls.Add(this.tB_xfje);
            this.p_xfxm.Controls.Add(this.l_pjje);
            this.p_xfxm.Controls.Add(this.l_qssj);
            this.p_xfxm.Controls.Add(this.b_find);
            this.p_xfxm.Controls.Add(this.b_exit);
            this.p_xfxm.Controls.Add(this.tB_gzdw);
            this.p_xfxm.Controls.Add(this.lbl_gzdw);
            this.p_xfxm.Location = new System.Drawing.Point(17, 12);
            this.p_xfxm.Name = "p_xfxm";
            this.p_xfxm.Size = new System.Drawing.Size(295, 310);
            this.p_xfxm.TabIndex = 10;
            // 
            // cb_pjfs
            // 
            this.cb_pjfs.FormattingEnabled = true;
            this.cb_pjfs.Items.AddRange(new object[] {
            "按时间",
            "按金额"});
            this.cb_pjfs.Location = new System.Drawing.Point(89, 86);
            this.cb_pjfs.Name = "cb_pjfs";
            this.cb_pjfs.Size = new System.Drawing.Size(184, 20);
            this.cb_pjfs.TabIndex = 88;
            this.cb_pjfs.SelectedIndexChanged += new System.EventHandler(this.cb_pjfs_SelectedIndexChanged);
            // 
            // lbl_pjfs
            // 
            this.lbl_pjfs.AutoSize = true;
            this.lbl_pjfs.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_pjfs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_pjfs.Location = new System.Drawing.Point(13, 87);
            this.lbl_pjfs.Name = "lbl_pjfs";
            this.lbl_pjfs.Size = new System.Drawing.Size(63, 14);
            this.lbl_pjfs.TabIndex = 87;
            this.lbl_pjfs.Text = "批结方式";
            // 
            // dt_end
            // 
            this.dt_end.Enabled = false;
            this.dt_end.Location = new System.Drawing.Point(89, 149);
            this.dt_end.Name = "dt_end";
            this.dt_end.Size = new System.Drawing.Size(186, 21);
            this.dt_end.TabIndex = 86;
            this.tpinfo.SetToolTip(this.dt_end, "终止时间是当前时间到23点59分59秒结束");
            // 
            // lbl_zzsj
            // 
            this.lbl_zzsj.AutoSize = true;
            this.lbl_zzsj.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_zzsj.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_zzsj.Location = new System.Drawing.Point(10, 151);
            this.lbl_zzsj.Name = "lbl_zzsj";
            this.lbl_zzsj.Size = new System.Drawing.Size(63, 14);
            this.lbl_zzsj.TabIndex = 85;
            this.lbl_zzsj.Text = "终止时间";
            // 
            // dt_start
            // 
            this.dt_start.Enabled = false;
            this.dt_start.Location = new System.Drawing.Point(90, 117);
            this.dt_start.Name = "dt_start";
            this.dt_start.Size = new System.Drawing.Size(185, 21);
            this.dt_start.TabIndex = 84;
            this.tpinfo.SetToolTip(this.dt_start, "起始时间是当前日期的：0点0分0秒开始");
            // 
            // tB_xfbz
            // 
            this.tB_xfbz.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_xfbz.Location = new System.Drawing.Point(90, 215);
            this.tB_xfbz.Name = "tB_xfbz";
            this.tB_xfbz.Size = new System.Drawing.Size(185, 23);
            this.tB_xfbz.TabIndex = 6;
            // 
            // l_xfbz
            // 
            this.l_xfbz.AutoSize = true;
            this.l_xfbz.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_xfbz.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_xfbz.Location = new System.Drawing.Point(12, 218);
            this.l_xfbz.Name = "l_xfbz";
            this.l_xfbz.Size = new System.Drawing.Size(35, 14);
            this.l_xfbz.TabIndex = 83;
            this.l_xfbz.Text = "备注";
            this.tpinfo.SetToolTip(this.l_xfbz, "如果有备注，会所写批结的所有Sjzzd中");
            // 
            // tB_pjlx
            // 
            this.tB_pjlx.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_pjlx.Location = new System.Drawing.Point(91, 17);
            this.tB_pjlx.Name = "tB_pjlx";
            this.tB_pjlx.Size = new System.Drawing.Size(184, 23);
            this.tB_pjlx.TabIndex = 4;
            this.tB_pjlx.Text = "挂账批结";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_status.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_status.Location = new System.Drawing.Point(13, 20);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(63, 14);
            this.lbl_status.TabIndex = 81;
            this.lbl_status.Text = "批结类型";
            // 
            // b_gzdw
            // 
            this.b_gzdw.BackColor = System.Drawing.Color.DimGray;
            this.b_gzdw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_gzdw.Image = ((System.Drawing.Image)(resources.GetObject("b_gzdw.Image")));
            this.b_gzdw.Location = new System.Drawing.Point(223, 51);
            this.b_gzdw.Name = "b_gzdw";
            this.b_gzdw.Size = new System.Drawing.Size(52, 26);
            this.b_gzdw.TabIndex = 1;
            this.b_gzdw.UseVisualStyleBackColor = false;
            this.b_gzdw.Click += new System.EventHandler(this.b_krxm_Click);
            // 
            // tB_xfje
            // 
            this.tB_xfje.Enabled = false;
            this.tB_xfje.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_xfje.Location = new System.Drawing.Point(90, 182);
            this.tB_xfje.Name = "tB_xfje";
            this.tB_xfje.Size = new System.Drawing.Size(185, 23);
            this.tB_xfje.TabIndex = 5;
            this.tB_xfje.Text = "0";
            // 
            // l_pjje
            // 
            this.l_pjje.AutoSize = true;
            this.l_pjje.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_pjje.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_pjje.Location = new System.Drawing.Point(12, 185);
            this.l_pjje.Name = "l_pjje";
            this.l_pjje.Size = new System.Drawing.Size(63, 14);
            this.l_pjje.TabIndex = 59;
            this.l_pjje.Text = "批结金额";
            // 
            // l_qssj
            // 
            this.l_qssj.AutoSize = true;
            this.l_qssj.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_qssj.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_qssj.Location = new System.Drawing.Point(12, 121);
            this.l_qssj.Name = "l_qssj";
            this.l_qssj.Size = new System.Drawing.Size(63, 14);
            this.l_qssj.TabIndex = 57;
            this.l_qssj.Text = "起始时间";
            // 
            // b_find
            // 
            this.b_find.BackColor = System.Drawing.SystemColors.Control;
            this.b_find.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_find.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_find.Image = ((System.Drawing.Image)(resources.GetObject("b_find.Image")));
            this.b_find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_find.Location = new System.Drawing.Point(89, 244);
            this.b_find.Name = "b_find";
            this.b_find.Size = new System.Drawing.Size(72, 44);
            this.b_find.TabIndex = 3;
            this.b_find.Text = "过滤";
            this.b_find.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_find.UseVisualStyleBackColor = false;
            this.b_find.Click += new System.EventHandler(this.b_find_Click);
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_exit.Location = new System.Drawing.Point(201, 244);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(72, 44);
            this.b_exit.TabIndex = 4;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // tB_gzdw
            // 
            this.tB_gzdw.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_gzdw.Location = new System.Drawing.Point(90, 52);
            this.tB_gzdw.Name = "tB_gzdw";
            this.tB_gzdw.ReadOnly = true;
            this.tB_gzdw.Size = new System.Drawing.Size(128, 23);
            this.tB_gzdw.TabIndex = 0;
            // 
            // lbl_gzdw
            // 
            this.lbl_gzdw.AutoSize = true;
            this.lbl_gzdw.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_gzdw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_gzdw.Location = new System.Drawing.Point(13, 55);
            this.lbl_gzdw.Name = "lbl_gzdw";
            this.lbl_gzdw.Size = new System.Drawing.Size(63, 14);
            this.lbl_gzdw.TabIndex = 0;
            this.lbl_gzdw.Text = "挂账单位";
            // 
            // Szw_pljz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(328, 338);
            this.Controls.Add(this.p_xfxm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Szw_pljz";
            this.Text = "批量结账";
            this.p_xfxm.ResumeLayout(false);
            this.p_xfxm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_xfxm;
        public System.Windows.Forms.TextBox tB_xfbz;
        private System.Windows.Forms.Label l_xfbz;
        public System.Windows.Forms.TextBox tB_pjlx;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button b_gzdw;
        public System.Windows.Forms.TextBox tB_xfje;
        private System.Windows.Forms.Label l_pjje;
        private System.Windows.Forms.Label l_qssj;
        private System.Windows.Forms.Button b_find;
        private System.Windows.Forms.Button b_exit;
        public System.Windows.Forms.TextBox tB_gzdw;
        private System.Windows.Forms.Label lbl_gzdw;
        private System.Windows.Forms.DateTimePicker dt_start;
        private System.Windows.Forms.DateTimePicker dt_end;
        private System.Windows.Forms.Label lbl_zzsj;
        private System.Windows.Forms.ToolTip tpinfo;
        private System.Windows.Forms.ComboBox cb_pjfs;
        private System.Windows.Forms.Label lbl_pjfs;
    }
}