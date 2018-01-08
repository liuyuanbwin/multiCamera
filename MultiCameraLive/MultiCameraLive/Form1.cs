using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using Size = System.Drawing.Size;

namespace MultiCameraLive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitCamera();
        }
        private FilterInfoCollection videoDevices;//摄像机数组
        private Boolean isShowSubPlayer;  //是否显示小窗口
        //初始化摄像头
        private void InitCamera()
        {
                isShowSubPlayer = true;
                try
                {
                    videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    int i = 1;
                    foreach (FilterInfo device in videoDevices)
                    {
                        mainCameraList.Items.Add("摄像头"+ i );
                        subCameraList.Items.Add("摄像头" + i );
                        i++;
                    }

                    if (videoDevices.Count <= 1)
                    {
                         FilterInfo info;
                         info = videoDevices[0];
                         VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                         videoSource.DesiredFrameSize = new System.Drawing.Size(214, 281);
                         videoSource.DesiredFrameRate = 1;
                         mainPlayer.VideoSource = videoSource;
                         mainPlayer.Start();
                         Log.WriteError("摄像头不足两个");
                        MessageBox.Show("摄像头数量错误,请确认所有摄像头已连接并且正确安装驱动!");
                    }
                    else
                    {
                        FilterInfo info;
                        info = videoDevices[0];
                        VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                        videoSource.DesiredFrameSize = new System.Drawing.Size(214, 281);
                        videoSource.DesiredFrameRate = 1;
                        mainPlayer.VideoSource = videoSource;
                        mainPlayer.Start();

                        FilterInfo subInfo;
                        subInfo = videoDevices[1];
                        VideoCaptureDevice subVideoSource = new VideoCaptureDevice(videoDevices[1].MonikerString);
                        subVideoSource.DesiredFrameSize = new System.Drawing.Size(214, 281);
                        subVideoSource.DesiredFrameRate = 1;
                        subPlayer.VideoSource = subVideoSource;
                        subPlayer.Start();
                    }
                }
                catch (Exception e)
                {
                Log.WriteError("初始化就失败了");
                    MessageBox.Show("摄像头初始化错误,请联系我!" + e);
                }
        }

        private void closeCamera(object sender, FormClosingEventArgs e)
        {
            mainPlayer.SignalToStop();
            mainPlayer.WaitForStop();
            mainPlayer.Stop();
            subPlayer.SignalToStop();
            subPlayer.WaitForStop();
            subPlayer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isShowSubPlayer = !isShowSubPlayer;
            subPlayer.Visible = isShowSubPlayer;
            if (isShowSubPlayer) {
                button1.Text = "小窗口/开";
            }
            else
            {
                button1.Text = "小窗口/关";
            }
        }

        private void mainCameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
             if(mainCameraList.SelectedIndex >= -1)
            {
                mainPlayer.SignalToStop();
                mainPlayer.WaitForStop();
                mainPlayer.Stop();
                subPlayer.SignalToStop();
                subPlayer.WaitForStop();
                subPlayer.Stop();

                FilterInfo info;
                info = videoDevices[mainCameraList.SelectedIndex];
                VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[mainCameraList.SelectedIndex].MonikerString);
                videoSource.DesiredFrameSize = new System.Drawing.Size(214, 281);
                videoSource.DesiredFrameRate = 1;
                mainPlayer.VideoSource = videoSource;
                mainPlayer.Start();

                if((subCameraList.SelectedIndex > -1))
                {
                    FilterInfo subInfo;
                    subInfo = videoDevices[subCameraList.SelectedIndex];
                    VideoCaptureDevice subVideoSource = new VideoCaptureDevice(videoDevices[subCameraList.SelectedIndex].MonikerString);
                    subVideoSource.DesiredFrameSize = new System.Drawing.Size(214, 281);
                    subVideoSource.DesiredFrameRate = 1;
                    subPlayer.VideoSource = subVideoSource;
                    subPlayer.Start();
                }
               
            }
        }

        private void subCameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subCameraList.SelectedIndex >= -1)
            {
                mainPlayer.SignalToStop();
                mainPlayer.WaitForStop();
                mainPlayer.Stop();
                subPlayer.SignalToStop();
                subPlayer.WaitForStop();
                subPlayer.Stop();

                if((mainCameraList.SelectedIndex > -1))
                {
                    FilterInfo info;
                    info = videoDevices[mainCameraList.SelectedIndex];
                    VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[mainCameraList.SelectedIndex].MonikerString);
                    videoSource.DesiredFrameSize = new System.Drawing.Size(214, 281);
                    videoSource.DesiredFrameRate = 1;
                    mainPlayer.VideoSource = videoSource;
                    mainPlayer.Start();
                }

                FilterInfo subInfo;
                subInfo = videoDevices[subCameraList.SelectedIndex];
                VideoCaptureDevice subVideoSource = new VideoCaptureDevice(videoDevices[subCameraList.SelectedIndex].MonikerString);
                subVideoSource.DesiredFrameSize = new System.Drawing.Size(214, 281);
                subVideoSource.DesiredFrameRate = 1;
                subPlayer.VideoSource = subVideoSource;
                subPlayer.Start();
            }
        }
    }
}
