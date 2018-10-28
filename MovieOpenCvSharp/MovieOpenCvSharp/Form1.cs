using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;


namespace MovieOpenCvSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoCapture vcap = new VideoCapture(textBox1.Text);

            while (vcap.IsOpened())
            {
                Mat mat = new Mat();

                if (vcap.Read(mat))
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();//Memory release
                    }

                    if (mat.IsContinuous())
                    {
                        pictureBox1.Image = BitmapConverter.ToBitmap(mat);
                    }
                    else
                    {
                        break;
                    }
                    Application.DoEvents(); // Not recommended
                }
                else
                {
                    break;
                }
                Thread.Sleep((int)(1000 / vcap.Fps));
                mat.Dispose();//Memory release
            }

            vcap.Dispose();//Memory release
        }
    }
}
