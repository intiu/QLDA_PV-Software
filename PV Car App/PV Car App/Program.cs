using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV_Car_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dangnhap());
        }

        // Sơ đồ Use case
        //![](FC4F8C0B36D1BCDF41882B1892488DE4.png;;;0.04528)

        // Sơ đồ Class Diagram
        //![](54ABF00B9123E850E9B1FE7164FC7EF4.png)

        // Dự án ứng dụng này trên MS Project
        //![](2A69DC44517E2C9A41187B5C14C9462D.png;;;0.05069,0.06076)
    }
}
