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


    public partial class Reports : Form
    {
        public MainForm mainForm;
        FoodMealManager foodMealManager = new FoodMealManager(new FoodMealRepository(new AppDbContext()));
        public Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var data02 = foodMealManager.GetTablewMT().OrderBy(x => x.Meal.MealTypeId).Where(x => x.Meal.UserId == mainForm.tempint && x.Meal.Date == mainForm.monthCalendar1.SelectionStart.Date).GroupBy(x => new { x.Meal.MealType.MTName, x.Food.FName }).Select(x => new { mType = x.Key.MTName, fName = x.Key.FName, pSum = x.Sum(x => x.Portion), cSum = x.Sum(x => x.Food.Calori) }).ToList();

            foreach (var item in data02)
            {
                listBox1.Items.Add(item.mType + " " + item.pSum + " tane " + item.fName + " toplam " + item.cSum + " kalori");
            }

            var data3 = foodMealManager.GetAllTable().Where(x => x.Meal.UserId == mainForm.tempint && x.Meal.Date == mainForm.monthCalendar1.SelectionStart.Date).Sum(x => x.Food.Calori);
            listBox1.Items.Add("_________________________________________________");
            listBox1.Items.Add("Toplam yenen kalori: " + data3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Weekly weekly = new Weekly();
            weekly.mainForm = mainForm;
            mainForm.OpenChildForm(weekly, sender);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Monthly monthly = new Monthly();
            monthly.mainForm = mainForm;
            mainForm.OpenChildForm(monthly, sender);
        }
    }
}
