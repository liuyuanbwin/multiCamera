﻿namespace MultiCameraLive
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
            this.topButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPlayer
            // 
            this.mainPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPlayer.Location = new System.Drawing.Point(0, 1);
            this.mainPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.mainPlayer.Name = "mainPlayer";
            this.mainPlayer.Size = new System.Drawing.Size(626, 441);
            this.mainPlayer.TabIndex = 0;
            this.mainPlayer.Text = "videoSourcePlayer1";
            this.mainPlayer.VideoSource = null;
            this.mainPlayer.DoubleClick += new System.EventHandler(this.mainPlayer_DoubleClick);
            // 
            // subPlayer
            // 
            this.subPlayer.Location = new System.Drawing.Point(308, 1);
            this.subPlayer.Name = "subPlayer";
            this.subPlayer.Size = new System.Drawing.Size(317, 230);
            this.subPlayer.TabIndex = 1;
            this.subPlayer.Text = "videoSourcePlayer1";
            this.subPlayer.VideoSource = null;
            this.subPlayer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.subPlayer_MouseClick);
            this.subPlayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.subPlayer_MouseDown);
            this.subPlayer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.subPlayer_MouseMove);
            this.subPlayer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.subPlayer_MouseUp);
            // 
            // mainCameraList
            // 
            this.mainCameraList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainCameraList.FormattingEnabled = true;
            this.mainCameraList.Location = new System.Drawing.Point(6, 18);
            this.mainCameraList.Name = "mainCameraList";
            this.mainCameraList.Size = new System.Drawing.Size(98, 20);
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
            this.button1.Location = new System.Drawing.Point(6, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "小窗口/开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.topButton);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.mainCameraList);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 103);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主画面";
            this.groupBox1.Visible = false;
            // 
            // topButton
            // 
            this.topButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topButton.Location = new System.Drawing.Point(6, 73);
            this.topButton.Name = "topButton";
            this.topButton.Size = new System.Drawing.Size(98, 22);
            this.topButton.TabIndex = 6;
            this.topButton.Text = "置顶/开";
            this.topButton.UseVisualStyleBackColor = true;
            this.topButton.Click += new System.EventHandler(this.topButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(110, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 76);
            this.button3.TabIndex = 5;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.subCameraList);
            this.groupBox2.Location = new System.Drawing.Point(308, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(109, 49);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "小画面";
            this.groupBox2.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(76, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.subPlayer);
            this.Controls.Add(this.mainPlayer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "双画面直播";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closeCamera);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button topButton;
    }
}

