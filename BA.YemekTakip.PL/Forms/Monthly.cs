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
    public partial class Monthly : Form
    {
        FoodMealManager foodMealManager = new FoodMealManager(new FoodMealRepository(new AppDbContext()));
        public MainForm mainForm;

        public Monthly()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            // Son 30 gün içindeki öğünleri kullanıcı ve öğün tipine göre gruplayarak sorgula
            var data2 = foodMealManager.GetTablewMT().Where(x => x.Meal.Date <= mainForm.monthCalendar1.SelectionStart.Date && x.Meal.Date >= mainForm.monthCalendar1.SelectionStart.Date.AddDays(-30))
                .GroupBy(x => new { x.Meal.UserId, x.Meal.MealType.MTName })
                .Select(x => new { User = x.Key.UserId, mType = x.Key.MTName, Count = x.Count(), Sum = x.Sum(x => x.Food.Calori) })
                .OrderByDescending(x => x.Sum)
                .ToList();

            foreach (var item in data2)
            {
                listBox1.Items.Add("ID: " + item.User + " | Öğün Kategorisi: " + item.mType + " | Yenilen Yemek Sayısı: " + item.Count + " | Toplam Kalori: " + item.Sum);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            // Son 30 gün içindeki yemekleri kullanıcı ve yemek türüne göre gruplayarak sorgula
            var data2 = foodMealManager.GetTablewFT().Where(x => x.Meal.Date <= mainForm.monthCalendar1.SelectionStart.Date && x.Meal.Date >= mainForm.monthCalendar1.SelectionStart.Date.AddDays(-30))
                .GroupBy(x => new { x.Food.FoodTypeId, x.Meal.UserId, x.Food.FoodType.Name })
                .Select(x => new { User = x.Key.UserId, Count = x.Count(), Type = x.Key.Name })
                .OrderByDescending(x => x.Count)
                .ToList();

            foreach (var item in data2)
            {
                listBox1.Items.Add("ID: " + item.User + " numaralı kullanıcı " + item.Count + " kere " + item.Type + " yedi. ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            // Son 30 gün içindeki yemekleri adlarına göre gruplayarak sorgula
            var data = foodMealManager.GetAllTable().Where(x => x.Meal.Date <= mainForm.monthCalendar1.SelectionStart.Date && x.Meal.Date >= mainForm.monthCalendar1.SelectionStart.Date.AddDays(-30))
                .GroupBy(x => x.Food.FName)
                .Select(x => new { Food = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(20)
                .ToList();

            foreach (var item in data)
            {
                listBox1.Items.Add("Yemekler: " + item.Food + " | Yemek sayısı: " + item.Count);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            // Son 30 gün içindeki yemekleri adlarına ve öğün türüne göre gruplayarak sorgula
            var data = foodMealManager.GetTablewMT().Where(x => x.Meal.Date <= mainForm.monthCalendar1.SelectionStart.Date && x.Meal.Date >= mainForm.monthCalendar1.SelectionStart.Date.AddDays(-30))
                .GroupBy(x => new { x.Food.FName, x.Meal.MealTypeId, x.Meal.MealType.MTName })
                .Select(x => new { Food = x.Key.FName, mType = x.Key.MTName, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(20)
                .ToList();

            foreach (var item in data)
            {
                listBox1.Items.Add("Yemekler: " + item.Food + " | Öğün: " + item.mType + " | sayısı: " + item.Count);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.mainForm = mainForm;
            mainForm.OpenChildForm(reports, sender);
        }
    }
}
