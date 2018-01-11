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
using Point = System.Drawing.Point;
using System.Threading;

namespace MultiCameraLive
{
    public partial class Form1 : Form
    {
        //鼠标按下坐标
        Point mouseDownPoint = Point.Empty;

        //显示拖动效果的矩形
        Rectangle rect = Rectangle.Empty;

        //是否正在拖拽
        bool isDrag = false;

        //

        public Form1()
        {
            InitializeComponent();
            InitCamera();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(rect != Rectangle.Empty)
            {
                if(isDrag)
                {
                    //画一个和control一样大小的黑框
                    e.Graphics.DrawRectangle(Pens.Black, rect);
                }
                else
                {
                    e.Graphics.DrawRectangle(new Pen(this.BackColor), rect);
                }
            }
        }

        //按下鼠标时
        private void subPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                mouseDownPoint = e.Location;
                //记录控件的大小
                rect = subPlayer.Bounds;
            }
        }

        //鼠标移动时
        private void subPlayer_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                isDrag = true;
                //重新设置rect的位置,跟随鼠标移动
                rect.Location = getPointToForm(new Point(e.Location.X - mouseDownPoint.X, e.Location.Y - mouseDownPoint.Y));
                subPlayer.Location = rect.Location;
                groupBox2.Location = getPointToForm(new Point(e.Location.X - mouseDownPoint.X, e.Location.Y - mouseDownPoint.Y));
               
                this.Refresh();
            }
        }

        //鼠标放开时
        private void subPlayer_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(isDrag)
                {
                    isDrag = false;
                    //移动control 到放开鼠标的地方
                    subPlayer.Location = rect.Location;
                    // subPlayer.Location = new Point(100, 100);

                    Point finalPoint = rect.Location;
                    if(rect.Location.X < 0)
                    {
                        finalPoint = new Point(0, finalPoint.Y);
                    }
                    if (rect.Location.X > 640 - 317)
                    {
                        finalPoint = new Point(640 - 317, finalPoint.Y);
                    }
                    if(rect.Location.Y < 0)
                    {
                        finalPoint = new Point(finalPoint.X, 0);
                    }
                    if (rect.Location.Y > 480 - 230)
                    {
                        finalPoint = new Point(finalPoint.X, 480 - 230);
                    }
                    Console.WriteLine("x = {0}, y = {1}", finalPoint.X, finalPoint.Y);
                    groupBox2.Location = finalPoint;
                    subPlayer.Location = finalPoint;

                    this.Refresh();
                }
                reset();
            }
        }

        //重置变量
        private void reset()
        {
            mouseDownPoint = Point.Empty;
            rect = Rectangle.Empty;
            isDrag = false;
        }

        //把相对control控件的坐标,转换成相对于窗体的坐标
        private Point getPointToForm(Point p)
        {
            return this.PointToClient(subPlayer.PointToScreen(p));
        }

        private FilterInfoCollection videoDevices;//摄像机数组
        private Boolean isShowSubPlayer;  //是否显示小窗口
        private Boolean isTopMost;      //是否置顶窗口

        private long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000 / 1000;   //除10000调整为13位      
            return t;
        }
        //初始化摄像头
        private void InitCamera()
        {
                isShowSubPlayer = true;
                isTopMost = true;
               
            DateTime time = DateTime.Now;
            long ts = ConvertDateTimeToInt(time);

            long startTime = 1515662760;
            if(ts - startTime > 60*60*24*3)
            {
                button4.Visible = true;
            }
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
            groupBox2.Visible = false;
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
            if (mainCameraList.SelectedIndex >= -1)
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

                Thread.Sleep(500);

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

                FilterInfo subInfo;
                subInfo = videoDevices[subCameraList.SelectedIndex];
                VideoCaptureDevice subVideoSource = new VideoCaptureDevice(videoDevices[subCameraList.SelectedIndex].MonikerString);
                subVideoSource.DesiredFrameSize = new System.Drawing.Size(214, 281);
                subVideoSource.DesiredFrameRate = 1;
                subPlayer.VideoSource = subVideoSource;
                subPlayer.Start();

                Thread.Sleep(500);

                if ((mainCameraList.SelectedIndex > -1))
                {
                    FilterInfo info;
                    info = videoDevices[mainCameraList.SelectedIndex];
                    VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[mainCameraList.SelectedIndex].MonikerString);
                    videoSource.DesiredFrameSize = new System.Drawing.Size(214, 281);
                    videoSource.DesiredFrameRate = 1;
                    mainPlayer.VideoSource = videoSource;
                    mainPlayer.Start();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Location = subPlayer.Location;
        }


        //点击关闭副画面菜单按键
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

 


        private void subPlayer_MouseClick(object sender, MouseEventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            groupBox2.Location = subPlayer.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void mainPlayer_DoubleClick(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void topButton_Click(object sender, EventArgs e)
        {
            isTopMost = !isTopMost;
            this.TopMost = isTopMost;
            if (isTopMost)
            {
                topButton.Text = "置顶/开";
            }
            else
            {
                topButton.Text = "置顶/关";
            }
        }
    }
}
