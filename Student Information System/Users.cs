﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_System
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            homepage homepageForm = new homepage();
            homepageForm.Show();
        }

        private void pnlStudents_Click(object sender, EventArgs e)
        {
            this.Hide();
            Students studentsForm = new Students();
            studentsForm.Show();
        }

        private void pnlTeachers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teachers teachersForm = new Teachers();
            teachersForm.Show();
        }

        private void pnlClasses_Click(object sender, EventArgs e)
        {
            this.Hide();
            Classes classesForm = new Classes();
            classesForm.Show();
        }

        private void pnlCanteen_Click(object sender, EventArgs e)
        {
            this.Hide();
            Canteen canteenForm = new Canteen();
            canteenForm.Show();
        }
    }
}
