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
    public partial class Baocao : DevExpress.XtraEditors.XtraUserControl
    {
        private static Baocao _instance;
        public static Baocao Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Baocao();
                return _instance;
            }
        }
        IFirebaseClient client;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "niLCVyr9vM5P5Rze3p23qfjOrWGAN4CB9tOJnEJB",
            BasePath = "https://pv-car-app-default-rtdb.firebaseio.com/"
        };
        public Baocao()
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

        private void Baocao_Load(object sender, EventArgs e)
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
            FirebaseResponse res = client.Get(@"Report");
            Dictionary<string, Report> data = JsonConvert.DeserializeObject<Dictionary<string, Report>>(res.Body.ToString());
            PopulateRTB(data);
            MessageBox.Show("Máy chủ đã load xong hãy nhấn hiển thị");
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirebaseResponse res = client.Get(@"Report");
            Dictionary<string, Report> data = JsonConvert.DeserializeObject<Dictionary<string, Report>>(res.Body.ToString());
            PopulateDataGrid(data);
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report std = new Report()
            {
                Reportcode = txtReportcode.Text,
                Reportname = txtReportname.Text,
                Dayreport = txtDayreport.Text,
                Carimportprice = txtCarimportprice.Text,
                Revenue = txtRevenue.Text,
                Salaryemployee = txtSalaryemployee.Text,
                Totalmoney = txtTotalmoney.Text
            };
            var setter = client.Set("Report/" + txtReportcode.Text, std);
            MessageBox.Show("Dữ liệu được lưu trữ thành công!");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report std = new Report()
            {
                Reportcode = txtReportcode.Text,
                Reportname = txtReportname.Text,
                Dayreport = txtDayreport.Text,
                Carimportprice = txtCarimportprice.Text,
                Revenue = txtRevenue.Text,
                Salaryemployee = txtSalaryemployee.Text,
                Totalmoney = txtTotalmoney.Text
            };
            var setter = client.Update("Report/" + txtReportcode.Text, std);
            MessageBox.Show("Dữ liệu được cập nhật thành công!");
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = client.Delete("Report/" + txtReportcode.Text);
            MessageBox.Show("Dữ liệu đã được xóa thành công!");
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = client.Get("Report/" + txtReportcode.Text);
            Report std = result.ResultAs<Report>();
            txtReportname.Text = std.Reportname;
            txtDayreport.Text = std.Dayreport;
            txtCarimportprice.Text = std.Carimportprice;
            txtRevenue.Text = std.Revenue;
            txtSalaryemployee.Text = std.Salaryemployee;
            txtTotalmoney.Text = std.Totalmoney;
            MessageBox.Show("Dữ liệu được truy xuất thành công!");
        }

        void PopulateRTB(Dictionary<string, Report> record)
        {
            richTextBox1.Clear();
            foreach (var item in record)
            {
                richTextBox1.Text += item.Key + "\n";
                richTextBox1.Text += "Mã báo cáo" + item.Value.Reportcode + "\n";
                richTextBox1.Text += "Tên báo cáo" + item.Value.Reportname + "\n";
                richTextBox1.Text += "Ngày báo cáo" + item.Value.Dayreport + "\n";
                richTextBox1.Text += "Giá nhập ô tô" + item.Value.Carimportprice + "\n";
                richTextBox1.Text += "Doanh thu" + item.Value.Revenue + "\n";
                richTextBox1.Text += "Lương nhân viên" + item.Value.Salaryemployee + "\n";
                richTextBox1.Text += "Tổng tiền" + item.Value.Totalmoney + "\n";
            }
        }

        void PopulateDataGrid(Dictionary<string, Report> record)
        {
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.Columns.Add("Mã báo cáo", "Mã báo cáo");
            guna2DataGridView1.Columns.Add("Tên báo cáo", "Tên báo cáo");
            guna2DataGridView1.Columns.Add("Ngày báo cáo", "Ngày báo cáo");
            guna2DataGridView1.Columns.Add("Giá nhập ô tô", "Giá nhập ô tô");
            guna2DataGridView1.Columns.Add("Doanh thu", "Doanh thu");
            guna2DataGridView1.Columns.Add("Lương nhân viên", "Lương nhân viên");
            guna2DataGridView1.Columns.Add("Tổng tiền", "Tổng tiền");
            foreach (var item in record)
            {
                guna2DataGridView1.Rows.Add(item.Value.Reportcode, item.Value.Reportname, item.Value.Dayreport, item.Value.Carimportprice, item.Value.Revenue, item.Value.Salaryemployee, item.Value.Totalmoney);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtReportcode.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtReportcode.Cut();
            if (txtReportname.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtReportname.Cut();
            if (txtDayreport.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtDayreport.Cut();
            if (txtCarimportprice.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtCarimportprice.Cut();
            if (txtRevenue.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtRevenue.Cut();
            if (txtSalaryemployee.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtSalaryemployee.Cut();
            if (txtTotalmoney.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTotalmoney.Cut();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtReportcode.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtReportcode.Copy();
            if (txtReportname.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtReportname.Copy();
            if (txtDayreport.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtDayreport.Copy();
            if (txtCarimportprice.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtCarimportprice.Copy();
            if (txtRevenue.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtRevenue.Copy();
            if (txtSalaryemployee.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtSalaryemployee.Copy();
            if (txtTotalmoney.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTotalmoney.Copy();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtReportcode.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtReportcode.SelectionStart = txtReportcode.SelectionStart + txtReportcode.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtReportcode.Paste();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtReportname.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtReportname.SelectionStart = txtReportname.SelectionStart + txtReportname.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtReportname.Paste();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtDayreport.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtDayreport.SelectionStart = txtDayreport.SelectionStart + txtDayreport.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtDayreport.Paste();
            }
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtCarimportprice.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtCarimportprice.SelectionStart = txtCarimportprice.SelectionStart + txtCarimportprice.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtCarimportprice.Paste();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtRevenue.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtRevenue.SelectionStart = txtRevenue.SelectionStart + txtRevenue.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtRevenue.Paste();
            }
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtSalaryemployee.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtSalaryemployee.SelectionStart = txtSalaryemployee.SelectionStart + txtSalaryemployee.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtSalaryemployee.Paste();
            }
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTotalmoney.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show(
                            "Bạn có muốn dán lên lựa chọn hiện tại không?",
                            "Cắt ví dụ",
                            MessageBoxButtons.YesNo) ==
                        DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTotalmoney.SelectionStart = txtTotalmoney.SelectionStart + txtTotalmoney.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTotalmoney.Paste();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtReportcode.Font = fd.Font;
                txtReportname.Font = fd.Font;
                txtDayreport.Font = fd.Font;
                txtCarimportprice.Font = fd.Font;
                txtRevenue.Font = fd.Font;
                txtSalaryemployee.Font = fd.Font;
                txtTotalmoney.Font = fd.Font;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtReportcode.BackColor = fd.Color;
                txtReportname.BackColor = fd.Color;
                txtDayreport.BackColor = fd.Color;
                txtCarimportprice.BackColor = fd.Color;
                txtRevenue.BackColor = fd.Color;
                txtSalaryemployee.BackColor = fd.Color;
                txtTotalmoney.BackColor = fd.Color;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtReportcode.Undo();
            txtReportname.Undo();
            txtDayreport.Undo();
            txtCarimportprice.Undo();
            txtRevenue.Undo();
            txtSalaryemployee.Undo();
            txtTotalmoney.Undo();
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Vebieudo vebieudo = new Vebieudo();
            //this.Hide();
            vebieudo.Show();
            this.Show();
        }
    }
}
