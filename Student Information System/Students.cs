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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
            get_data();
        }

        static string ConnString = "Data Source=METEHAN\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True";
        SqlConnection connect = new SqlConnection(ConnString);

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlHome_Click(object sender, EventArgs e)
        {


             homepage homepageForm = new homepage();
             homepageForm.Show();
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

        private void picAddStudents_Click(object sender, EventArgs e)
        {

            Add addForm = new Add("Students");
            addForm.Show();            
        }

        private void lblAttandanceStudents_Click(object sender, EventArgs e)
        {
            Attandance attandanceForm = new Attandance();
            attandanceForm.Show();
        }


        private void get_data()
        {
            try
            {
                string query = @"
            SELECT 
                s.StudentID, 
                s.name, 
                s.surname, 
                c.className, 
                s.gender, 
                CONVERT(VARCHAR(10), s.birthdate, 104) as birthdate, 
                s.student_tc
            FROM 
                [SchoolDB].[dbo].[Student] s
            INNER JOIN 
                [SchoolDB].[dbo].[Class] c
            ON 
                s.ClassID = c.ClassID";

                DataTable dataTable = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);

                adapter.Fill(dataTable);

                dataGridViewStudents.Rows.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string fullName = row["Name"] + " " + row["Surname"];
                    dataGridViewStudents.Rows.Add(row["StudentID"], fullName, row["className"], row["gender"], row["birthdate"], row["student_tc"]);
                }

                dataGridViewStudents.Columns["birthdate"].DefaultCellStyle.Format = "dd.MM.yyyy";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void picDeleteStudents_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(dataGridViewStudents.SelectedRows[0].Cells[0].Value);

                try
                {

                    string query = "DELETE FROM [SchoolDB].[dbo].[Student] WHERE [StudentID] = @StudentID";

                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);

                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                        }

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student deleted successfully!");
                            dataGridViewStudents.Rows.RemoveAt(dataGridViewStudents.SelectedRows[0].Index);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the student.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        private void picSearchStudents_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchStudents.Text.Trim();
            SearchStudents(searchValue);
        }

        private void SearchStudents(string searchValue)
        {
            try
            {
                string query = @"
                SELECT 
                    s.StudentID, 
                    s.name, 
                    s.surname, 
                    c.className, 
                    s.gender, 
                    s.birthdate, 
                    s.student_tc
                FROM 
                    [SchoolDB].[dbo].[Student] s
                INNER JOIN 
                    [SchoolDB].[dbo].[Class] c
                ON 
                    s.ClassID = c.ClassID
                WHERE 
                    s.StudentID LIKE @searchValue OR
                    s.name LIKE @searchValue OR
                    s.surname LIKE @searchValue";

                DataTable dataTable = new DataTable();

                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

                dataGridViewStudents.Rows.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string fullName = row["name"] + " " + row["surname"];
                    dataGridViewStudents.Rows.Add(row["StudentID"], fullName, row["className"], row["gender"], row["birthdate"], row["student_tc"]);
                }

                dataGridViewStudents.Columns["birthdate"].DefaultCellStyle.Format = "dd.MM.yyyy";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
