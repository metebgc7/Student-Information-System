using System;
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
    public partial class homepage : Form
    {
        public homepage()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool mouseDown;
        private Point offset;
        private void MouseDown_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }




        private void homepage_Load(object sender, EventArgs e)
        {

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

        private void pnlUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users usersForm = new Users();
            usersForm.Show();
        }
    }
}
