using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Helpers;

namespace PV_Car_App
{
    public partial class Trangchinh : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        //![](65EF33CCF0C1DD85F5DC2224294F31B9.png;;;0.03205,0.02793)
        
        // Màn hình chính khi design của ứng dụng
        public Trangchinh()
        {
            InitializeComponent();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Trangchu.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Trangchu.Instance);
                Trangchu.Instance.Dock = DockStyle.Fill;
                Trangchu.Instance.BringToFront();
            }
            Trangchu.Instance.BringToFront();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Oto.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Oto.Instance);
                Oto.Instance.Dock = DockStyle.Fill;
                Oto.Instance.BringToFront();
            }
            Oto.Instance.BringToFront();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Khachhang.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Khachhang.Instance);
                Khachhang.Instance.Dock = DockStyle.Fill;
                Khachhang.Instance.BringToFront();
            }
            Khachhang.Instance.BringToFront();
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Nhanvien.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Nhanvien.Instance);
                Nhanvien.Instance.Dock = DockStyle.Fill;
                Nhanvien.Instance.BringToFront();
            }
            Nhanvien.Instance.BringToFront();
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.Contains(Baocao.Instance))
            {
                fluentDesignFormContainer1.Controls.Add(Baocao.Instance);
                Baocao.Instance.Dock = DockStyle.Fill;
                Baocao.Instance.BringToFront();
            }
            Baocao.Instance.BringToFront();
        }
    }
}
