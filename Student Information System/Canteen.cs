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
    public partial class Canteen : Form
    {
        public Canteen()
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

        private void pnlUsers_Click(object sender, EventArgs e)
        {   
            Users usersForm = new Users();
            usersForm.Show();
            this.Hide();
        }

        private void picAddCanteen_Click(object sender, EventArgs e)
        {
            Add addForm = new Add("Canteen");
            addForm.Show();
        }

        private void get_data()
        {
            try
            {
                // Define your query
                string query = "SELECT * FROM [SchoolDB].[dbo].[Canteen]";

                // Create a new DataTable to hold the query results
                DataTable dataTable = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);

                // Fill the DataTable with the results from the SQL query
                adapter.Fill(dataTable);


                // Bind the DataTable to the DataGridView
                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridViewCanteen.Rows.Add(row["ProductID"], row["product_name"], row["product_price"]);
                }

            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void picDeleteCanteen_Click(object sender, EventArgs e)
        {
            if (dataGridViewCanteen.SelectedRows.Count > 0)
            {
                // Assuming the first column contains the Product ID
                int productId = Convert.ToInt32(dataGridViewCanteen.SelectedRows[0].Cells[0].Value);

                try
                {
                    // Define the delete query
                    string query = "DELETE FROM [SchoolDB].[dbo].[Canteen] WHERE [ProductID] = @ProductID";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@ProductID", productId);

                        // Open the connection if it is not already open
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                        }

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Inform the product about the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product deleted successfully!");

                            // Optionally, refresh the data in the DataGridView
                            dataGridViewCanteen.Rows.Clear();
                            get_data();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the product.");
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
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void picSearchCanteen_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchCanteen.Text.Trim();
            SearchProducts(searchValue);
        }

        private void SearchProducts(string searchValue)
        {
            try
            {
                string query = @"
                SELECT 
                    ProductID, 
                    product_name, 
                    product_price
                FROM 
                    [SchoolDB].[dbo].[Canteen]
                WHERE 
                    product_name LIKE @searchValue";

                DataTable dataTable = new DataTable();

                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

                dataGridViewCanteen.Rows.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridViewCanteen.Rows.Add(row["ProductID"], row["product_name"], row["product_price"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
