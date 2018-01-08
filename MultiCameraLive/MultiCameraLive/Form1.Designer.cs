namespace MultiCameraLive
{
    partial class Form1
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
            this.mainPlayer = new AForge.Controls.VideoSourcePlayer();
            this.subPlayer = new AForge.Controls.VideoSourcePlayer();
            this.mainCameraList = new System.Windows.Forms.ComboBox();
            this.subCameraList = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPlayer
            // 
            this.mainPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPlayer.Location = new System.Drawing.Point(12, 12);
            this.mainPlayer.Name = "mainPlayer";
            this.mainPlayer.Size = new System.Drawing.Size(772, 537);
            this.mainPlayer.TabIndex = 0;
            this.mainPlayer.Text = "videoSourcePlayer1";
            this.mainPlayer.VideoSource = null;
            // 
            // subPlayer
            // 
            this.subPlayer.Location = new System.Drawing.Point(12, 12);
            this.subPlayer.Name = "subPlayer";
            this.subPlayer.Size = new System.Drawing.Size(317, 230);
            this.subPlayer.TabIndex = 1;
            this.subPlayer.Text = "videoSourcePlayer1";
            this.subPlayer.VideoSource = null;
            // 
            // mainCameraList
            // 
            this.mainCameraList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainCameraList.FormattingEnabled = true;
            this.mainCameraList.Location = new System.Drawing.Point(6, 20);
            this.mainCameraList.Name = "mainCameraList";
            this.mainCameraList.Size = new System.Drawing.Size(64, 20);
            this.mainCameraList.TabIndex = 2;
            this.mainCameraList.SelectedIndexChanged += new System.EventHandler(this.mainCameraList_SelectedIndexChanged);
            // 
            // subCameraList
            // 
            this.subCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subCameraList.FormattingEnabled = true;
            this.subCameraList.Location = new System.Drawing.Point(6, 20);
            this.subCameraList.Name = "subCameraList";
            this.subCameraList.Size = new System.Drawing.Size(64, 20);
            this.subCameraList.TabIndex = 3;
            this.subCameraList.SelectedIndexChanged += new System.EventHandler(this.subCameraList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(790, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "小窗口/开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.mainCameraList);
            this.groupBox1.Location = new System.Drawing.Point(790, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(76, 49);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主画面";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.subCameraList);
            this.groupBox2.Location = new System.Drawing.Point(790, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(76, 49);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "小画面";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.subPlayer);
            this.Controls.Add(this.mainPlayer);
            this.Name = "Form1";
            this.Text = "双画面直播";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closeCamera);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer mainPlayer;
        private AForge.Controls.VideoSourcePlayer subPlayer;
        private System.Windows.Forms.ComboBox mainCameraList;
        private System.Windows.Forms.ComboBox subCameraList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

