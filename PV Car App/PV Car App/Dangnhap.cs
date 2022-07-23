using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV_Car_App
{
    public partial class Dangnhap : Form
    {

        //![](A59F5608E51FC27A45A39652AF00914F.png;;;0.04382,0.04137)
        // Màn hình thiết kế đăng nhập ứng dụng
        public Dangnhap()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "niLCVyr9vM5P5Rze3p23qfjOrWGAN4CB9tOJnEJB",
            BasePath = "https://pv-car-app-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void Dangnhap_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("Không có kết nối Internet");
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            #region Condition
            if (string.IsNullOrWhiteSpace(username.Text) &&
               string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Hãy nhập hết các nội dung trên");
                return;
            }
            #endregion

            FirebaseResponse res1 = client.Get(@"Employee/" + txtEmployeecode.Text);

            Employee ResUser = res1.ResultAs<Employee>();// database result


            Employee CurUser = new Employee() // USER GIVEN INFO
            {
                Employeecode = txtEmployeecode.Text,
                Accountemployee = username.Text,
                Passwordemployee = password.Text
            };


            if (Employee.IsEqual(ResUser, CurUser))
            {
                Trangchinh trangchinh = new Trangchinh();
                trangchinh.Show();
                this.Hide();
            }

            else
            {
                Employee.ShowError();
            }
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
