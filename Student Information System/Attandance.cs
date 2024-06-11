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
    public partial class Attandance : Form
    {

        static string ConnString = "Data Source=METEHAN\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True";
        SqlConnection connect = new SqlConnection(ConnString);


        public Attandance()
        {
            InitializeComponent();
        }

        private void picQuitStudents_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string studentID = txtStudentID.Text.Trim();
            string date = txtDate.Text.Trim();

            
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();

                // checck StudentID
                string checkStudentQuery = "SELECT COUNT(*) FROM Student WHERE StudentID = @StudentID";
                using (SqlCommand cmd = new SqlCommand(checkStudentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // attendance record
                        string insertAttendanceQuery = "INSERT INTO Attendance (StudentID, Date) VALUES (@StudentID, @Date)";
                        using (SqlCommand insertCmd = new SqlCommand(insertAttendanceQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@StudentID", studentID);
                            insertCmd.Parameters.AddWithValue("@Date", DateTime.Parse(date));

                            int rowsAffected = insertCmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Attendance recorded successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Failed to record attendance.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Student ID does not exist.");
                    }
                }
            }

            this.Close();
        }


    }
}
