using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Car_App
{
    class Employee
    {
        public string Employeecode { get; set; }
        public string Employeesfullname { get; set; }
        public string Employeeaddress { get; set; }
        public string Employeephonenumber { get; set; }
        public string Accountemployee { get; set; }
        public string Passwordemployee { get; set; }
        public string Employeeemail { get; set; }
        public string Employeesalary { get; set; }

        private static string error = "Tên đăng nhập không tồn tại !";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool IsEqual(Employee user1, Employee user2)
        {
            if (user1 == null || user2 == null) { return false; }

            if (user1.Accountemployee != user2.Accountemployee)
            {
                error = "Tên đăng nhập không tồn tại !";
                return false;
            }

            else if (user1.Passwordemployee != user2.Passwordemployee)
            {
                error = "Mật khẩu không hợp lệ !";
                return false;
            }

            return true;
        }
    }
}
