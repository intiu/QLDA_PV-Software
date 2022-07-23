using DevExpress.XtraEditors;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV_Car_App
{
    public partial class Trangchu : DevExpress.XtraEditors.XtraUserControl
    {
        private static Trangchu _instance;
        public static Trangchu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Trangchu();
                return _instance;
            }
        }
        public Trangchu()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "AH6MOR5nj3YzwUvOvfHqkZ92FINoI7TZ9GS0Hphj",
            BasePath = "https://um-clone-app.firebaseio.com/"
        };

        IFirebaseClient client;

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void Trangchu_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("Không có kết nối Internet");
            }
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            label9.Text = string.Format("{0:0.00}%", fcpu);
            label10.Text = string.Format("{0:0.00}%", fram);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Lapkehoach lapkehoach = new Lapkehoach();
            //this.Hide();
            lapkehoach.Show();
            this.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            PDF pDF = new PDF();
            //this.Hide();
            pDF.Show();
            this.Show();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Soanthaovanban soanthaovanban = new Soanthaovanban();
            //this.Hide();
            soanthaovanban.Show();
            this.Show();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Xulybangtinh xulybangtinh = new Xulybangtinh();
            //this.Hide();
            xulybangtinh.Show();
            this.Show();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "https://kotlinlang.org/";
            Process.Start(a1);
        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
            var a2 = new ProcessStartInfo("msedge.exe");
            a2.Arguments = "https://www.devexpress.com/";
            Process.Start(a2);
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            var a3 = new ProcessStartInfo("msedge.exe");
            a3.Arguments = "https://awesomeopensource.com/project/ziyasal/FireSharp";
            Process.Start(a3);
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            var a4 = new ProcessStartInfo("msedge.exe");
            a4.Arguments = "https://www.nuget.org/packages/MetroModernUI/";
            Process.Start(a4);
        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            var a5 = new ProcessStartInfo("msedge.exe");
            a5.Arguments = "https://gunaframework.com/";
            Process.Start(a5);
        }
    }
}
