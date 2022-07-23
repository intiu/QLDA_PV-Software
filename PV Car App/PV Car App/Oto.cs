using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ColorWheel;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
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
using Newtonsoft.Json;

namespace PV_Car_App
{
    public partial class Oto : DevExpress.XtraEditors.XtraUserControl
    {
        private static Oto _instance;
        public static Oto Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Oto();
                return _instance;
            }
        }
        IFirebaseClient client;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "niLCVyr9vM5P5Rze3p23qfjOrWGAN4CB9tOJnEJB",
            BasePath = "https://pv-car-app-default-rtdb.firebaseio.com/"
        };
        public Oto()
        {
            InitializeComponent();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "https://www.facebook.com/phuong.lethanh.3158";
            Process.Start(a1);
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Vechungtoi vechungtoi = new Vechungtoi();
            //this.Hide();
            vechungtoi.Show();
            this.Show();
        }

        private void Oto_Load(object sender, EventArgs e)
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
            FirebaseResponse res = client.Get(@"Car");
            Dictionary<string, Car> data = JsonConvert.DeserializeObject<Dictionary<string, Car>>(res.Body.ToString());
            PopulateDataGrid(data);
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Car std = new Car()
            {
                Carcode = txtCarcode.Text,
                Carmanufacturer = txtCarmanufacturer.Text,
                Carname = txtCarname.Text,
                Rangeofcar = txtRangeofcar.Text,
                Carcolor = txtCarcolor.Text,
                Additionalinformationaboutthecar = txtAdditionalinformationaboutthecar.Text,
                Numberofcars = txtNumberofcars.Text,
                Carimportdate = txtCarimportdate.Text,
                Carprice = txtCarprice.Text
            };
            var setter = client.Set("Car/" + txtCarcode.Text, std);
            MessageBox.Show("Dữ liệu được lưu trữ thành công!");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Car std = new Car()
            {
                Carcode = txtCarcode.Text,
                Carmanufacturer = txtCarmanufacturer.Text,
                Carname = txtCarname.Text,
                Rangeofcar = txtRangeofcar.Text,
                Carcolor = txtCarcolor.Text,
                Additionalinformationaboutthecar = txtAdditionalinformationaboutthecar.Text,
                Numberofcars = txtNumberofcars.Text,
                Carimportdate = txtCarimportdate.Text,
                Carprice = txtCarprice.Text
            };
            var setter = client.Update("Car/" + txtCarcode.Text, std);
            MessageBox.Show("Dữ liệu được cập nhật thành công!");
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = client.Delete("Car/" + txtCarcode.Text);
            MessageBox.Show("Dữ liệu đã được xóa thành công!");
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = client.Get("Car/" + txtCarcode.Text);
            Car std = result.ResultAs<Car>();
            txtCarmanufacturer.Text = std.Carmanufacturer;
            txtCarname.Text = std.Carname;
            txtRangeofcar.Text = std.Rangeofcar;
            txtCarcolor.Text = std.Carcolor;
            txtAdditionalinformationaboutthecar.Text = std.Additionalinformationaboutthecar;
            txtNumberofcars.Text = std.Numberofcars;
            txtCarimportdate.Text = std.Carimportdate;
            txtCarprice.Text = std.Carprice;
            MessageBox.Show("Dữ liệu được truy xuất thành công!");
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        void PopulateRTB(Dictionary<string, Car> record)
        {
            richTextBox1.Clear();
            foreach (var item in record)
            {
                richTextBox1.Text += item.Key + "\n";
                richTextBox1.Text += "Mã ô tô" + item.Value.Carcode + "\n";
                richTextBox1.Text += "Hãng ô tô" + item.Value.Carmanufacturer + "\n";
                richTextBox1.Text += "Tên ô tô" + item.Value.Carname + "\n";
                richTextBox1.Text += "Loại ô tô" + item.Value.Rangeofcar + "\n";
                richTextBox1.Text += "Màu sắc ô tô" + item.Value.Carcolor + "\n";
                richTextBox1.Text += "Thông tin bổ sung về ô tô" + item.Value.Additionalinformationaboutthecar + "\n";
                richTextBox1.Text += "Số lượng ô tô" + item.Value.Numberofcars + "\n";
                richTextBox1.Text += "Ngày nhập ô tô" + item.Value.Carimportdate + "\n";
                richTextBox1.Text += "Giá ô tô" + item.Value.Carprice + "\n";
            }
        }

        void PopulateDataGrid(Dictionary<string, Car> record)
        {
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.Columns.Add("Mã ô tô", "Mã ô tô");
            guna2DataGridView1.Columns.Add("Hãng ô tô", "Hãng ô tô");
            guna2DataGridView1.Columns.Add("Tên ô tô", "Tên ô tô");
            guna2DataGridView1.Columns.Add("Loại ô tô", "Loại ô tô");
            guna2DataGridView1.Columns.Add("Màu sắc ô tô", "Màu sắc ô tô");
            guna2DataGridView1.Columns.Add("Thông tin bổ sung về ô tô", "Thông tin bổ sung về ô tô");
            guna2DataGridView1.Columns.Add("Số lượng ô tô", "Số lượng ô tô");
            guna2DataGridView1.Columns.Add("Ngày nhập ô tô", "Ngày nhập ô tô");
            guna2DataGridView1.Columns.Add("Giá ô tô", "Giá ô tô");
            foreach (var item in record)
            {
                guna2DataGridView1.Rows.Add(item.Value.Carcode, item.Value.Carmanufacturer, item.Value.Carname, item.Value.Rangeofcar, item.Value.Carcolor, item.Value.Additionalinformationaboutthecar, item.Value.Numberofcars, item.Value.Carimportdate, item.Value.Carprice);
            }
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Car");
            Dictionary<string, Car> data = JsonConvert.DeserializeObject<Dictionary<string, Car>>(res.Body.ToString());
            PopulateRTB(data);
            MessageBox.Show("Máy chủ đã load xong hãy nhấn hiển thị");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCarcode.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtCarcode.Cut();
            if (txtCarmanufacturer.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtCarmanufacturer.Cut();
            if (txtCarname.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtCarname.Cut();
            if (txtRangeofcar.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtRangeofcar.Cut();
            if (txtCarcolor.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtCarcolor.Cut();
            if (txtAdditionalinformationaboutthecar.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtAdditionalinformationaboutthecar.Cut();
            if (txtNumberofcars.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtNumberofcars.Cut();
            if (txtCarimportdate.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtCarimportdate.Cut();
            if (txtCarprice.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtCarprice.Cut();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCarcode.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtCarcode.Copy();
            if (txtCarmanufacturer.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtCarmanufacturer.Copy();
            if (txtCarname.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtCarname.Copy();
            if (txtRangeofcar.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtRangeofcar.Copy();
            if (txtCarcolor.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtCarcolor.Copy();
            if (txtAdditionalinformationaboutthecar.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtAdditionalinformationaboutthecar.Copy();
            if (txtNumberofcars.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtNumberofcars.Copy();
            if (txtCarimportdate.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtCarimportdate.Copy();
            if (txtCarprice.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtCarprice.Copy();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtCarcode.Font = fd.Font;
                txtCarmanufacturer.Font = fd.Font;
                txtCarname.Font = fd.Font;
                txtRangeofcar.Font = fd.Font;
                txtCarcolor.Font = fd.Font;
                txtAdditionalinformationaboutthecar.Font = fd.Font;
                txtNumberofcars.Font = fd.Font;
                txtCarimportdate.Font = fd.Font;
                txtCarprice.Font = fd.Font;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtCarcode.BackColor = fd.Color;
                txtCarmanufacturer.BackColor = fd.Color;
                txtCarname.BackColor = fd.Color;
                txtRangeofcar.BackColor = fd.Color;
                txtCarcolor.BackColor = fd.Color;
                txtAdditionalinformationaboutthecar.BackColor = fd.Color;
                txtNumberofcars.BackColor = fd.Color;
                txtCarimportdate.BackColor = fd.Color;
                txtCarprice.BackColor = fd.Color;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCarcode.Undo();
            txtCarmanufacturer.Undo();
            txtCarname.Undo();
            txtRangeofcar.Undo();
            txtCarcolor.Undo();
            txtAdditionalinformationaboutthecar.Undo();
            txtNumberofcars.Undo();
            txtCarimportdate.Undo();
            txtCarprice.Undo();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtCarcode.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtCarcode.SelectionStart = txtCarcode.SelectionStart + txtCarcode.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtCarcode.Paste();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtCarmanufacturer.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtCarmanufacturer.SelectionStart = txtCarmanufacturer.SelectionStart + txtCarmanufacturer.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtCarmanufacturer.Paste();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtCarname.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtCarname.SelectionStart = txtCarname.SelectionStart + txtCarname.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtCarname.Paste();
            }
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtRangeofcar.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtRangeofcar.SelectionStart = txtRangeofcar.SelectionStart + txtRangeofcar.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtRangeofcar.Paste();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtCarcolor.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtCarcolor.SelectionStart = txtCarcolor.SelectionStart + txtCarcolor.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtCarcolor.Paste();
            }
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtAdditionalinformationaboutthecar.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtAdditionalinformationaboutthecar.SelectionStart = txtAdditionalinformationaboutthecar.SelectionStart + txtAdditionalinformationaboutthecar.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtAdditionalinformationaboutthecar.Paste();
            }
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtNumberofcars.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtNumberofcars.SelectionStart = txtNumberofcars.SelectionStart + txtNumberofcars.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtNumberofcars.Paste();
            }
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtCarimportdate.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtCarimportdate.SelectionStart = txtCarimportdate.SelectionStart + txtCarimportdate.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtCarimportdate.Paste();
            }
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtCarprice.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtCarprice.SelectionStart = txtCarprice.SelectionStart + txtCarprice.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtCarprice.Paste();
            }
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Vebieudo vebieudo = new Vebieudo();
            //this.Hide();
            vebieudo.Show();
            this.Show();
        }
    }
}
