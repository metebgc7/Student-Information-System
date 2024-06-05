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
    public partial class Teachers : Form
    {
        public Teachers()
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

        private void pnlStudents_Click(object sender, EventArgs e)
        {

            Students studentsForm = new Students();
            studentsForm.Show();
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

        private void picAddTeachers_Click(object sender, EventArgs e)
        {
            Add addForm = new Add("Teachers");
            addForm.Show();
        }

        private void get_data()
        {
            try
            {
                // Define your query
                string query = "SELECT * FROM [SchoolDB].[dbo].[Teacher]";

                // Create a new DataTable to hold the query results
                DataTable dataTable = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);

                // Fill the DataTable with the results from the SQL query
                adapter.Fill(dataTable);


                // Bind the DataTable to the DataGridView
                foreach (DataRow row in dataTable.Rows)
                {
                    string fullName = row["Name"] + " " + row["Surname"];
                    dataGridViewTeachers.Rows.Add(row["TeacherID"], fullName, row["Subject"], row["PhoneNumber"]);
                }

            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void picDeleteTeachers_Click(object sender, EventArgs e)
        {
            if (dataGridViewTeachers.SelectedRows.Count > 0)
            {
                // Assuming the first column contains the Teacher ID
                int teacherId = Convert.ToInt32(dataGridViewTeachers.SelectedRows[0].Cells[0].Value);

                try
                {
                    // Define the delete query
                    string query = "DELETE FROM [SchoolDB].[dbo].[Teacher] WHERE [TeacherID] = @TeacherID";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@TeacherID", teacherId);

                        // Open the connection if it is not already open
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                        }

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Inform the teacher about the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Teacher deleted successfully!");

                            // Optionally, refresh the data in the DataGridView
                            dataGridViewTeachers.Rows.Clear();
                            get_data();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the teacher.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a teacher to delete.");
            }
        }

        private void picSearchTeachers_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchTeachers.Text.Trim();
            SearchTeachers(searchValue);
        }

        private void SearchTeachers(string searchValue)
        {
            try
            {
                string query = @"
                SELECT 
                    TeacherID, 
                    Name, 
                    Surname, 
                    Subject, 
                    PhoneNumber
                FROM 
                    [SchoolDB].[dbo].[Teacher]
                WHERE 
                    Name LIKE @searchValue OR
                    Surname LIKE @searchValue OR
                    Subject LIKE @searchValue";

                DataTable dataTable = new DataTable();

                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

                dataGridViewTeachers.Rows.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    string fullName = row["Name"] + " " + row["Surname"];
                    dataGridViewTeachers.Rows.Add(row["TeacherID"], fullName, row["Subject"], row["PhoneNumber"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
