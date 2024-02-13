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

namespace BA.DietTrackApp.PL.Forms
{
    public partial class UserInfo : Form
    {
        public MainForm mainForm;
        UserManager userManager = new UserManager(new GenericRepository<User>(new AppDbContext()));
        public UserInfo()
        {
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            var data = userManager.Get(mainForm.tempint).UserName;
            label1.Text = $"ID: {mainForm.tempint} \nKullanıcı Adı: {data}";
        }

    }
}
