using BA.DietTrackApp.BLL.Managers;
using BA.DietTrackApp.DAL.Context;
using BA.DietTrackApp.DAL.Repository;
using BA.DietTrackApp.Entity.Entities;
using BA.DietTrackApp.PL.Forms;
using Microsoft.EntityFrameworkCore;
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
    public partial class Login : Form
    {
        public MainForm mainForm;
        UserManager userManager = new UserManager(new GenericRepository<User>(new AppDbContext()));
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = buttonLogin;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            int id = userManager.IsAccountTrue(textBox1.Text, textBox2.Text);

            if (id == -1)
            {
                MessageBox.Show("Hatalı giriş");
                return;
            }
            else
            {
                mainForm.tempint = id;
                mainForm.buttonBreakfast.Enabled = true;
                mainForm.buttonDinner.Enabled = true;
                mainForm.buttonLunch.Enabled = true;
                mainForm.buttonSnacks.Enabled = true;
                mainForm.buttonReports.Enabled = true;
                mainForm.buttonHome.Enabled = true;
                UserInfo userInfo = new UserInfo();
                userInfo.mainForm = mainForm;
                mainForm.OpenChildForm(userInfo, sender);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount createAccountForm = new CreateAccount();
            createAccountForm.mainForm = mainForm;
            this.Close();
            mainForm.OpenChildForm(createAccountForm, sender);
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mainForm.ChangePassChar(this.textBox2);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mainForm.ChangePassChar(this.textBox2);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            mainForm.ChangePassChar(this.textBox2);
        }

    }
}
