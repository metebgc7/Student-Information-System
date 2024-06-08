using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_System
{
    public partial class homepage : Form
    {
        static string ConnString = "Data Source=METEHAN\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True";
        SqlConnection connect = new SqlConnection(ConnString);

        private Timer timer;
        public homepage()
        {
            InitializeComponent();
            UpdateLabels();

            timer = new Timer();
            timer.Interval = 5000; // 5 saniyede bir
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    connection.Open();

                    // Student number
                    int studentCount = GetRecordCount(connection, "Student");
                    lblDataStuNum.Text = studentCount.ToString();

                    // Teacher number
                    int teacherCount = GetRecordCount(connection, "Teacher");
                    lblDataTeachNum.Text = teacherCount.ToString();

                    // Class number
                    int classCount = GetRecordCount(connection, "Class");
                    lblDataClsNum.Text = classCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private int GetRecordCount(SqlConnection connection, string tableName)
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Sorguyu çalıştır ve sonucu al
                int count = (int)command.ExecuteScalar();
                return count;
            }
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
            
            Students studentsForm = new Students();
            studentsForm.Show();
            this.Hide();

        }

        private void pnlTeachers_Click(object sender, EventArgs e)
        {
            
            Teachers teachersForm = new Teachers();
            teachersForm.Show();
            this.Hide();


        }

        private void pnlClasses_Click(object sender, EventArgs e)
        {
            
            Classes classesForm = new Classes();
            classesForm.Show();
            this.Hide();
        }

        private void pnlCanteen_Click(object sender, EventArgs e)
        {
          
            Canteen canteenForm = new Canteen();
            canteenForm.Show();
            this.Hide();
        }

        private void pnlUsers_Click(object sender, EventArgs e)
        {
            
            Users usersForm = new Users();
            usersForm.Show();
            this.Hide();
        }
    }
}
