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
    public partial class Khachhang : DevExpress.XtraEditors.XtraUserControl
    {

        //
        private static Khachhang _instance;
        public static Khachhang Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Khachhang();
                return _instance;
            }
        }
        IFirebaseClient client;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "niLCVyr9vM5P5Rze3p23qfjOrWGAN4CB9tOJnEJB",
            BasePath = "https://pv-car-app-default-rtdb.firebaseio.com/"
        };
        public Khachhang()
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

        private void Khachhang_Load(object sender, EventArgs e)
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

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"User");
            Dictionary<string, User> data = JsonConvert.DeserializeObject<Dictionary<string, User>>(res.Body.ToString());
            PopulateDataGrid(data);
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            User std = new User()
            {
                Customerscode = txtCustomerscode.Text,
                Fullnameofcustomer = txtFullnameofcustomer.Text,
                Userphonenumber = txtUserphonenumber.Text,
                Useraddress = txtUseraddress.Text,
                Useremail = txtUseremail.Text,
                Thepriceofthecarpurchased = txtThepriceofthecarpurchased.Text
            };
            var setter = client.Set("User/" + txtCustomerscode.Text, std);
            MessageBox.Show("Dữ liệu được lưu trữ thành công!");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            User std = new User()
            {
                Customerscode = txtCustomerscode.Text,
                Fullnameofcustomer = txtFullnameofcustomer.Text,
                Userphonenumber = txtUserphonenumber.Text,
                Useraddress = txtUseraddress.Text,
                Useremail = txtUseremail.Text,
                Thepriceofthecarpurchased = txtThepriceofthecarpurchased.Text
            };
            var setter = client.Update("User/" + txtCustomerscode.Text, std);
            MessageBox.Show("Dữ liệu được cập nhật thành công!");
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = client.Delete("User/" + txtCustomerscode.Text);
            MessageBox.Show("Dữ liệu đã được xóa thành công!");
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"User");
            Dictionary<string, User> data = JsonConvert.DeserializeObject<Dictionary<string, User>>(res.Body.ToString());
            PopulateRTB(data);
            MessageBox.Show("Máy chủ đã load xong hãy nhấn hiển thị");
        }
        void PopulateRTB(Dictionary<string, User> record)
        {
            richTextBox1.Clear();
            foreach (var item in record)
            {
                richTextBox1.Text += item.Key + "\n";
                richTextBox1.Text += "Mã khách hàng" + item.Value.Customerscode + "\n";
                richTextBox1.Text += "Họ tên khách hàng" + item.Value.Fullnameofcustomer + "\n";
                richTextBox1.Text += "Số điện thoại khách hàng" + item.Value.Userphonenumber + "\n";
                richTextBox1.Text += "Địa chỉ khách hàng" + item.Value.Useraddress + "\n";
                richTextBox1.Text += "Email khách hàng" + item.Value.Useremail + "\n";
                richTextBox1.Text += "Giá ô tô đã mua" + item.Value.Thepriceofthecarpurchased + "\n";
            }
        }

        void PopulateDataGrid(Dictionary<string, User> record)
        {
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.Columns.Add("Mã khách hàng", "Mã khách hàng");
            guna2DataGridView1.Columns.Add("Họ tên khách hàng", "Họ tên khách hàng");
            guna2DataGridView1.Columns.Add("Số điện thoại khách hàng", "Số điện thoại khách hàng");
            guna2DataGridView1.Columns.Add("Địa chỉ khách hàng", "Địa chỉ khách hàng");
            guna2DataGridView1.Columns.Add("Email khách hàng", "Email khách hàng");
            guna2DataGridView1.Columns.Add("Giá ô tô đã mua", "Giá ô tô đã mua");
            foreach (var item in record)
            {
                guna2DataGridView1.Rows.Add(item.Value.Customerscode, item.Value.Fullnameofcustomer, item.Value.Userphonenumber, item.Value.Useraddress, item.Value.Useremail, item.Value.Thepriceofthecarpurchased);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCustomerscode.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtCustomerscode.Cut();
            if (txtFullnameofcustomer.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtFullnameofcustomer.Cut();
            if (txtUserphonenumber.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtUserphonenumber.Cut();
            if (txtUseraddress.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtUseraddress.Cut();
            if (txtUseremail.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtUseremail.Cut();
            if (txtThepriceofthecarpurchased.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtThepriceofthecarpurchased.Cut();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCustomerscode.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtCustomerscode.Copy();
            if (txtFullnameofcustomer.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtFullnameofcustomer.Copy();
            if (txtUserphonenumber.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtUserphonenumber.Copy();
            if (txtUseraddress.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtUseraddress.Copy();
            if (txtUseremail.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtUseremail.Copy();
            if (txtThepriceofthecarpurchased.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtThepriceofthecarpurchased.Copy();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtCustomerscode.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtCustomerscode.SelectionStart = txtCustomerscode.SelectionStart + txtCustomerscode.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtCustomerscode.Paste();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtFullnameofcustomer.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtFullnameofcustomer.SelectionStart = txtFullnameofcustomer.SelectionStart + txtFullnameofcustomer.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtFullnameofcustomer.Paste();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtUserphonenumber.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtUserphonenumber.SelectionStart = txtUserphonenumber.SelectionStart + txtUserphonenumber.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtUserphonenumber.Paste();
            }
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtUseraddress.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtUseraddress.SelectionStart = txtUseraddress.SelectionStart + txtUseraddress.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtUseraddress.Paste();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtUseremail.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtUseremail.SelectionStart = txtUseremail.SelectionStart + txtUseremail.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtUseremail.Paste();
            }
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtThepriceofthecarpurchased.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtThepriceofthecarpurchased.SelectionStart = txtThepriceofthecarpurchased.SelectionStart + txtThepriceofthecarpurchased.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtThepriceofthecarpurchased.Paste();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtCustomerscode.Font = fd.Font;
                txtFullnameofcustomer.Font = fd.Font;
                txtUserphonenumber.Font = fd.Font;
                txtUseraddress.Font = fd.Font;
                txtUseremail.Font = fd.Font;
                txtThepriceofthecarpurchased.Font = fd.Font;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtCustomerscode.BackColor = fd.Color;
                txtFullnameofcustomer.BackColor = fd.Color;
                txtUserphonenumber.BackColor = fd.Color;
                txtUseraddress.BackColor = fd.Color;
                txtUseremail.BackColor = fd.Color;
                txtThepriceofthecarpurchased.BackColor = fd.Color;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCustomerscode.Undo();
            txtFullnameofcustomer.Undo();
            txtUserphonenumber.Undo();
            txtUseraddress.Undo();
            txtUseremail.Undo();
            txtThepriceofthecarpurchased.Undo();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = client.Get("User/" + txtCustomerscode.Text);
            User std = result.ResultAs<User>();
            txtFullnameofcustomer.Text = std.Fullnameofcustomer;
            txtUserphonenumber.Text = std.Userphonenumber;
            txtUseraddress.Text = std.Useraddress;
            txtUseremail.Text = std.Useremail;
            txtThepriceofthecarpurchased.Text = std.Thepriceofthecarpurchased;
            MessageBox.Show("Dữ liệu được truy xuất thành công!");
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Vebieudo vebieudo = new Vebieudo();
            //this.Hide();
            vebieudo.Show();
            this.Show();
        }
    }
}
