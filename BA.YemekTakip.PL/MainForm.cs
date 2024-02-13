using BA.DietTrackApp.PL.Forms;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Runtime.InteropServices;

namespace BA.DietTrackApp.PL

{
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public DirectoryInfo soldir = TryGetSolutionDirectoryInfo();

        public int tempint;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }

        #region TopBarButtons

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Drag

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        #region Öðün Fonksiyonlar

        public bool IsNumeric(string text)
        {
            // TryParse yöntemini kullanarak dönüþümü deneyin
            return decimal.TryParse(text, out _);
        }

        public bool ControlAddFood(TextBox textBox,ComboBox comboBox)
        {
            if (textBox.Text.Contains(","))
            {
                textBox.Text = textBox.Text.Replace(",", ".");
                return true;
            }
            if (textBox.Text == string.Empty)
            {
                textBox.Text = "1";
                return true;
            }
            if (!IsNumeric(textBox.Text))
            {
                MessageBox.Show("Lütfen sayý deðeri giriniz.");
                return false;
            }
            if (!(monthCalendar1.SelectionStart.Date < DateTime.Now))
            {
                MessageBox.Show("Ýleri tarihe ekleme yapýlamaz.");
                return false;
            }
            if (comboBox.Text == string.Empty)
            {
                MessageBox.Show("Lütfen yemek seçiniz.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ChangePassChar(TextBox textBox)
        {
            if(textBox.PasswordChar == '*')
            {
                textBox.PasswordChar = '\0';
            }
            else
            {
                textBox.PasswordChar = '*';
            }
        }
        #endregion

        #region Rapor Fonksiyonlar



        #endregion



        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            this.panelCenter.Controls.Add(childForm);
            this.panelCenter.Tag = childForm;
            childForm.Show();
            labelBar.Text = childForm.Text;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.mainForm = this;
            OpenChildForm(userInfo, sender);
        }

        private void buttonBreakfast_Click(object sender, EventArgs e)
        {
            Breakfast breakfast = new Breakfast();
            breakfast.mainForm = this;
            OpenChildForm(breakfast, sender);
        }

        private void buttonLunch_Click(object sender, EventArgs e)
        {
            Lunch lunch = new Lunch();
            lunch.mainForm = this;
            OpenChildForm(lunch, sender);
        }

        private void buttonDinner_Click(object sender, EventArgs e)
        {
            Dinner dinner = new Dinner();
            dinner.mainForm = this;
            OpenChildForm(dinner, sender);
        }

        private void buttonSnacks_Click(object sender, EventArgs e)
        {
            Snacks snacks = new Snacks();
            snacks.mainForm = this;
            OpenChildForm(snacks, sender);
        }
        private void buttonReports_Click(object sender, EventArgs e)
        {
            Reports report = new Reports();
            report.mainForm = this;
            OpenChildForm(report, sender);
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string info = labelBar.Text;
            CalendarChanged(info, sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tempint.ToString());

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            buttonBreakfast.Enabled = false;
            buttonLunch.Enabled = false;
            buttonDinner.Enabled = false;
            buttonSnacks.Enabled = false;
            buttonReports.Enabled = false;
            buttonHome.Enabled = false;
            Login login = new Login();
            login.mainForm = this;
            OpenChildForm(login, sender);
        }

        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

        public void CalendarChanged(string info, object sender)
        {
            if (info == "Breakfast")
            {
                Breakfast breakfast = new Breakfast();
                breakfast.mainForm = this;
                OpenChildForm(breakfast, sender);
            }
            if (info == "Lunch")
            {
                Lunch lunch = new Lunch();
                lunch.mainForm = this;
                OpenChildForm(lunch, sender);
            }
            if (info == "Dinner")
            {
                Dinner dinner = new Dinner();
                dinner.mainForm = this;
                OpenChildForm(dinner, sender);
            }
            if (info == "Snacks")
            {
                Snacks snacks = new Snacks();
                snacks.mainForm = this;
                OpenChildForm(snacks, sender);
            }
        }
    }
}