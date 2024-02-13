using BA.DietTrackApp.BLL.Managers;
using BA.DietTrackApp.DAL.Context;
using BA.DietTrackApp.DAL.Repository;
using BA.DietTrackApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BA.DietTrackApp.PL
{
    public partial class CreateAccount : Form
    {
        UserManager userManager = new UserManager(new GenericRepository<User>(new AppDbContext()));
        public MainForm mainForm;
        public CreateAccount()
        {
            InitializeComponent();
            buttonSign.Enabled = false;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {

            User user = new User()
            {
                UserName = textBox2.Text,
                Password = textBox3.Text,
            };
            userManager.Add(user);
            this.Close();
            Login login = new Login();
            login.mainForm = mainForm;
            mainForm.OpenChildForm(login, sender);

            //IsAccExist = false ve IsPasswordStrongEnough = yes ise başarılı ve kapat
            //hatta böyle değilken butonu inaktif yap

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //kullanıcı adı yazdıkça IsAccExist çalışacak
            var isUserExist = userManager.IsUserExist(textBox2.Text);
            var isMailOk = userManager.IsValidEmail(textBox2.Text);
            var pass1 = userManager.IsStrongPassword(textBox3.Text);

            if (isMailOk)
            {
                if (isUserExist)
                {
                    label1.Text = "Bu mail adresi kullanılıyor.";
                }
                else
                {
                    label1.Text = "Mail adresi uygun.";
                }

            }
            else
            {
                label1.Text = "Geçerli bir adresi girin.";
            }

            if (!isUserExist && isMailOk && pass1 && textBox3.Text == textBox4.Text)
            {
                buttonSign.Enabled = true;
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.mainForm = mainForm;
            this.Close();
            mainForm.OpenChildForm(loginForm, sender);
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            textBox4.PasswordChar = '*';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var pass1 = userManager.IsStrongPassword(textBox3.Text);

            if (pass1)
                label2.Text = "Güçlü şifre";
            else
                label2.Text = "Zayıf şifre";

            var validmail = userManager.IsValidEmail(textBox2.Text);
            var isExist = userManager.IsUserExist(textBox2.Text);
            var pass2 = userManager.IsStrongPassword(textBox3.Text);
            if (!isExist && validmail && pass2 && textBox3.Text == textBox4.Text)
            {
                buttonSign.Enabled = true;
            }
            else
            {
                buttonSign.Enabled = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var pass1 = userManager.IsStrongPassword(textBox4.Text);
            var validmail = userManager.IsValidEmail(textBox2.Text);
            var isExist = userManager.IsUserExist(textBox2.Text);

            if (!isExist && validmail && pass1 && textBox3.Text == textBox4.Text)
            {
                buttonSign.Enabled = true;
            }
            else
            {
                buttonSign.Enabled = false;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mainForm.ChangePassChar(this.textBox3);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            mainForm.ChangePassChar(this.textBox4);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainForm.ChangePassChar(this.textBox3);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mainForm.ChangePassChar(this.textBox4);
        }
    }
}
