using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ColorWheel;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
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
    public partial class Nhanvien : DevExpress.XtraEditors.XtraUserControl
    {
        private static Nhanvien _instance;
        public static Nhanvien Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Nhanvien();
                return _instance;
            }
        }
        IFirebaseClient client;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "niLCVyr9vM5P5Rze3p23qfjOrWGAN4CB9tOJnEJB",
            BasePath = "https://pv-car-app-default-rtdb.firebaseio.com/"
        };
        public Nhanvien()
        {
            InitializeComponent();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Vechungtoi vechungtoi = new Vechungtoi();
            //this.Hide();
            vechungtoi.Show();
            this.Show();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "https://www.facebook.com/phuong.lethanh.3158";
            Process.Start(a1);
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(barLinkContainerItem1);
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("Không có kết nối Internet");
            }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Lapkehoach lapkehoach = new Lapkehoach();
            //this.Hide();
            lapkehoach.Show();
            this.Show();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PDF pDF = new PDF();
            //this.Hide();
            pDF.Show();
            this.Show();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Soanthaovanban soanthaovanban = new Soanthaovanban();
            //this.Hide();
            soanthaovanban.Show();
            this.Show();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xulybangtinh xulybangtinh = new Xulybangtinh();
            //this.Hide();
            xulybangtinh.Show();
            this.Show();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Vediagram vediagram = new Vediagram();
            //this.Hide();
            vediagram.Show();
            this.Show();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("calc");
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Gmail gmail = new Gmail();
            //this.Hide();
            gmail.Show();
            this.Show();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Employee");
            Dictionary<string, Employee> data = JsonConvert.DeserializeObject<Dictionary<string, Employee>>(res.Body.ToString());
            PopulateRTB(data);
            MessageBox.Show("Máy chủ đã load xong hãy nhấn hiển thị");
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Employee");
            Dictionary<string, Employee> data = JsonConvert.DeserializeObject<Dictionary<string, Employee>>(res.Body.ToString());
            PopulateDataGrid(data);
        }

        void PopulateRTB(Dictionary<string, Employee> record)
        {
            richTextBox1.Clear();
            foreach (var item in record)
            {
                richTextBox1.Text += item.Key + "\n";
                richTextBox1.Text += "Mã nhân viên" + item.Value.Employeecode + "\n";
                richTextBox1.Text += "Tên nhân viên" + item.Value.Employeesfullname + "\n";
                richTextBox1.Text += "Địa chỉ nhân viên" + item.Value.Employeeaddress + "\n";
                richTextBox1.Text += "Số điện thoại nhân viên" + item.Value.Employeephonenumber + "\n";
                richTextBox1.Text += "Tài khoản nhân viên" + item.Value.Accountemployee + "\n";
                richTextBox1.Text += "Mật khẩu nhân viên" + item.Value.Passwordemployee + "\n";
                richTextBox1.Text += "Email nhân viên" + item.Value.Employeeemail + "\n";
                richTextBox1.Text += "Lương nhân viên" + item.Value.Employeesalary + "\n";
            }
        }

        void PopulateDataGrid(Dictionary<string, Employee> record)
        {
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.Columns.Add("Mã nhân viên", "Mã nhân viên");
            guna2DataGridView1.Columns.Add("Tên nhân viên", "Tên nhân viên");
            guna2DataGridView1.Columns.Add("Địa chỉ nhân viên", "Địa chỉ nhân viên");
            guna2DataGridView1.Columns.Add("Số điện thoại nhân viên", "Số điện thoại nhân viên");
            guna2DataGridView1.Columns.Add("Tài khoản nhân viên", "Tài khoản nhân viên");
            guna2DataGridView1.Columns.Add("Mật khẩu nhân viên", "Mật khẩu nhân viên");
            guna2DataGridView1.Columns.Add("Email nhân viên", "Email nhân viên");
            guna2DataGridView1.Columns.Add("Lương nhân viên", "Lương nhân viên");
            foreach (var item in record)
            {
                guna2DataGridView1.Rows.Add(item.Value.Employeecode, item.Value.Employeesfullname, item.Value.Employeeaddress, item.Value.Employeephonenumber, item.Value.Accountemployee, item.Value.Passwordemployee, item.Value.Employeeemail, item.Value.Employeesalary);
            }
        }
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Employee std = new Employee()
            {
                Employeecode = txtEmployeecode.Text,
                Employeesfullname = txtEmployeesfullname.Text,
                Employeeaddress = txtEmployeeaddress.Text,
                Employeephonenumber = txtEmployeephonenumber.Text,
                Accountemployee = txtAccountemployee.Text,
                Passwordemployee = txtPasswordemployee.Text,
                Employeeemail = txtEmployeeemail.Text,
                Employeesalary = txtEmployeesalary.Text
            };
            var setter = client.Set("Employee/" + txtEmployeecode.Text, std);
            MessageBox.Show("Dữ liệu được lưu trữ thành công!");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Employee std = new Employee()
            {
                Employeecode = txtEmployeecode.Text,
                Employeesfullname = txtEmployeesfullname.Text,
                Employeeaddress = txtEmployeeaddress.Text,
                Employeephonenumber = txtEmployeephonenumber.Text,
                Accountemployee = txtAccountemployee.Text,
                Passwordemployee = txtPasswordemployee.Text,
                Employeeemail = txtEmployeeemail.Text,
                Employeesalary = txtEmployeesalary.Text
            };
            var setter = client.Update("Employee/" + txtEmployeecode.Text, std);
            MessageBox.Show("Dữ liệu được cập nhật thành công!");
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = client.Delete("Employee/" + txtEmployeecode.Text);
            MessageBox.Show("Dữ liệu đã được xóa thành công!");
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = client.Get("Employee/" + txtEmployeecode.Text);
            Employee std = result.ResultAs<Employee>();
            txtEmployeesfullname.Text = std.Employeesfullname;
            txtEmployeeaddress.Text = std.Employeeaddress;
            txtEmployeephonenumber.Text = std.Employeephonenumber;
            txtAccountemployee.Text = std.Accountemployee;
            txtPasswordemployee.Text = std.Passwordemployee;
            txtEmployeeemail.Text = std.Employeeemail;
            txtEmployeesalary.Text = std.Employeesalary;
            MessageBox.Show("Dữ liệu được truy xuất thành công!");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtEmployeecode.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtEmployeecode.Cut();
            if (txtEmployeesfullname.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtEmployeesfullname.Cut();
            if (txtEmployeeaddress.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtEmployeeaddress.Cut();
            if (txtEmployeephonenumber.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtEmployeephonenumber.Cut();
            if (txtAccountemployee.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtAccountemployee.Cut();
            if (txtPasswordemployee.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtPasswordemployee.Cut();
            if (txtEmployeeemail.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtEmployeeemail.Cut();
            if (txtEmployeesalary.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtEmployeesalary.Cut();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtEmployeecode.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtEmployeecode.Copy();
            if (txtEmployeesfullname.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtEmployeesfullname.Copy();
            if (txtEmployeeaddress.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtEmployeeaddress.Copy();
            if (txtEmployeephonenumber.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtEmployeephonenumber.Copy();
            if (txtAccountemployee.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtAccountemployee.Copy();
            if (txtPasswordemployee.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtPasswordemployee.Copy();
            if (txtEmployeeemail.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtEmployeeemail.Copy();
            if (txtEmployeesalary.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtEmployeesalary.Copy();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtEmployeecode.Font = fd.Font;
                txtEmployeesfullname.Font = fd.Font;
                txtEmployeeaddress.Font = fd.Font;
                txtEmployeephonenumber.Font = fd.Font;
                txtAccountemployee.Font = fd.Font;
                txtPasswordemployee.Font = fd.Font;
                txtEmployeeemail.Font = fd.Font;
                txtEmployeesalary.Font = fd.Font;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtEmployeecode.BackColor = fd.Color;
                txtEmployeesfullname.BackColor = fd.Color;
                txtEmployeeaddress.BackColor = fd.Color;
                txtEmployeephonenumber.BackColor = fd.Color;
                txtAccountemployee.BackColor = fd.Color;
                txtPasswordemployee.BackColor = fd.Color;
                txtEmployeeemail.BackColor = fd.Color;
                txtEmployeesalary.BackColor = fd.Color;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtEmployeecode.Undo();
            txtEmployeesfullname.Undo();
            txtEmployeeaddress.Undo();
            txtEmployeephonenumber.Undo();
            txtAccountemployee.Undo();
            txtPasswordemployee.Undo();
            txtEmployeeemail.Undo();
            txtEmployeesalary.Undo();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtEmployeecode.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtEmployeecode.SelectionStart = txtEmployeecode.SelectionStart + txtEmployeecode.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtEmployeecode.Paste();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtEmployeesfullname.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtEmployeesfullname.SelectionStart = txtEmployeesfullname.SelectionStart + txtEmployeesfullname.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtEmployeesfullname.Paste();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtEmployeeaddress.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtEmployeeaddress.SelectionStart = txtEmployeeaddress.SelectionStart + txtEmployeeaddress.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtEmployeeaddress.Paste();
            }
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtEmployeephonenumber.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtEmployeephonenumber.SelectionStart = txtEmployeephonenumber.SelectionStart + txtEmployeephonenumber.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtEmployeephonenumber.Paste();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtAccountemployee.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtAccountemployee.SelectionStart = txtAccountemployee.SelectionStart + txtAccountemployee.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtAccountemployee.Paste();
            }
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtPasswordemployee.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtPasswordemployee.SelectionStart = txtPasswordemployee.SelectionStart + txtPasswordemployee.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtPasswordemployee.Paste();
            }
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtEmployeeemail.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtEmployeeemail.SelectionStart = txtEmployeeemail.SelectionStart + txtEmployeeemail.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtEmployeeemail.Paste();
            }
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtEmployeesalary.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtEmployeesalary.SelectionStart = txtEmployeesalary.SelectionStart + txtEmployeesalary.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtEmployeesalary.Paste();
            }
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Vebieudo vebieudo = new Vebieudo();
            //this.Hide();
            vebieudo.Show();
            this.Show();
        }
    }
}
