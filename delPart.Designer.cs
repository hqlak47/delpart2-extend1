namespace delpart2_extend1
{
    partial class delPart
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.delPartition = new System.Windows.Forms.Button();
            this.completelyDel = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.cbDisk = new System.Windows.Forms.ComboBox();
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.cbPart = new System.Windows.Forms.ComboBox();
            this.l3 = new System.Windows.Forms.Label();
            this.lnum = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // delPartition
            // 
            this.delPartition.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delPartition.Location = new System.Drawing.Point(679, 188);
            this.delPartition.Name = "delPartition";
            this.delPartition.Size = new System.Drawing.Size(235, 109);
            this.delPartition.TabIndex = 1;
            this.delPartition.Text = "删除分区";
            this.delPartition.UseVisualStyleBackColor = true;
            this.delPartition.Click += new System.EventHandler(this.DeletePartitionButton_Click);
            // 
            // completelyDel
            // 
            this.completelyDel.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.completelyDel.Location = new System.Drawing.Point(679, 721);
            this.completelyDel.Name = "completelyDel";
            this.completelyDel.Size = new System.Drawing.Size(235, 109);
            this.completelyDel.TabIndex = 0;
            this.completelyDel.Text = "彻底删除";
            this.completelyDel.UseVisualStyleBackColor = true;
            this.completelyDel.Click += new System.EventHandler(this.ExtendPartitionButton_Click);
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(23, 12);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(614, 818);
            this.rtb.TabIndex = 2;
            this.rtb.Text = "";
            // 
            // cbDisk
            // 
            this.cbDisk.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDisk.FormattingEnabled = true;
            this.cbDisk.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbDisk.Location = new System.Drawing.Point(788, 590);
            this.cbDisk.Name = "cbDisk";
            this.cbDisk.Size = new System.Drawing.Size(121, 36);
            this.cbDisk.TabIndex = 6;
            this.cbDisk.Text = "0";
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l1.Location = new System.Drawing.Point(674, 590);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(54, 28);
            this.l1.TabIndex = 7;
            this.l1.Text = "磁盘";
            // 
            // l2
            // 
            this.l2.AutoSize = true;
            this.l2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l2.Location = new System.Drawing.Point(674, 647);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(54, 28);
            this.l2.TabIndex = 9;
            this.l2.Text = "分区";
            // 
            // cbPart
            // 
            this.cbPart.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPart.FormattingEnabled = true;
            this.cbPart.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbPart.Location = new System.Drawing.Point(788, 647);
            this.cbPart.Name = "cbPart";
            this.cbPart.Size = new System.Drawing.Size(121, 36);
            this.cbPart.TabIndex = 8;
            this.cbPart.Text = "4";
            // 
            // l3
            // 
            this.l3.AutoSize = true;
            this.l3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l3.Location = new System.Drawing.Point(674, 539);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(117, 28);
            this.l3.TabIndex = 10;
            this.l3.Text = "总磁盘数：";
            // 
            // lnum
            // 
            this.lnum.AutoSize = true;
            this.lnum.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnum.Location = new System.Drawing.Point(797, 539);
            this.lnum.Name = "lnum";
            this.lnum.Size = new System.Drawing.Size(24, 28);
            this.lnum.TabIndex = 11;
            this.lnum.Text = "0";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(679, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 109);
            this.button1.TabIndex = 12;
            this.button1.Text = "磁盘整理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnDefrag_Click);
            // 
            // BtnInfo
            // 
            this.BtnInfo.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnInfo.Location = new System.Drawing.Point(679, 370);
            this.BtnInfo.Name = "BtnInfo";
            this.BtnInfo.Size = new System.Drawing.Size(235, 109);
            this.BtnInfo.TabIndex = 13;
            this.BtnInfo.Text = "信息";
            this.BtnInfo.UseVisualStyleBackColor = true;
            this.BtnInfo.Click += new System.EventHandler(this.BtnInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 842);
            this.Controls.Add(this.BtnInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lnum);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.cbPart);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.cbDisk);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.completelyDel);
            this.Controls.Add(this.delPartition);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delPartition;
        private System.Windows.Forms.Button completelyDel;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.ComboBox cbDisk;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.ComboBox cbPart;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label lnum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnInfo;
    }
}

