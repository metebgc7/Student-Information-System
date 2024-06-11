using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_System
{
    public partial class Add : Form
    {


        static string ConnString = "Data Source=METEHAN\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True";
        SqlConnection connect = new SqlConnection(ConnString);

        public Add(string _initial_tabview)
        {
            InitializeComponent();
            open_tabview(_initial_tabview);
            LoadClassesIntoComboBox();
        }

        private void LoadClassesIntoComboBox()
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT className FROM Class";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxClass.Items.Add(reader["className"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void open_tabview(string _tabview)
        {
            foreach (TabPage tab in tabControlAdd.TabPages)
            {
                if (tab.Text == _tabview)
                {
                    tabControlAdd.SelectedTab = tab;
                    return;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // data from textbox
            string productName = txtProductName.Text;
            decimal productPrice;

            // check the decimal value
            if (!decimal.TryParse(txtPriceCanteen.Text, out productPrice))
            {
                MessageBox.Show("Geçerli bir fiyat girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // save data
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Canteen (product_name, product_price) VALUES (@ProductName, @ProductPrice)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@ProductPrice", productPrice);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Veri başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Veri kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // data from textbox
            string className = txtClassName.Text;

            // save data
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Class (className) VALUES (@ClassName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassName", className);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Veri başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Veri kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // data from textbox
            string teacherName = txtNameTeachers.Text;
            string teacherSurname = txtSurnameTeachers.Text;
            string teacherSubject = txtSubjectTeachers.Text;

            txtPhoneNumberTeachers.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string teacherPhoneNumber = txtPhoneNumberTeachers.Text;
            txtPhoneNumberTeachers.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            // save data
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Teacher (name, surname, subject, PhoneNumber) VALUES (@Name, @Surname, @Subject, @PhoneNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", teacherName);
                        command.Parameters.AddWithValue("@Surname", teacherSurname);
                        command.Parameters.AddWithValue("@Subject", teacherSubject);
                        command.Parameters.AddWithValue("@PhoneNumber", teacherPhoneNumber);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Veri başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Veri kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                try
                {
                    connection.Open();

                    // take the classID choosen from combobox
                    string classQuery = "SELECT ClassID FROM Class WHERE ClassName = @className";
                    SqlCommand classCommand = new SqlCommand(classQuery, connection);
                    classCommand.Parameters.AddWithValue("@className", comboBoxClass.SelectedItem.ToString());
                    int classId = (int)classCommand.ExecuteScalar(); // ClassID'yi alıyoruz

                    // check the parent
                    string checkParentQuery = "SELECT ParentID FROM Parent WHERE phoneNumber = @phoneNumber";
                    SqlCommand checkParentCommand = new SqlCommand(checkParentQuery, connection);
                    checkParentCommand.Parameters.AddWithValue("@phoneNumber", maskedTextBoxPhoneNumber.Text);
                    object parentIdObj = checkParentCommand.ExecuteScalar();

                    int parentId;
                    if (parentIdObj != null)
                    {
                        // take the parentID (there is parent)
                        parentId = (int)parentIdObj;
                    }
                    else
                    {
                        // there is no parent, take the parent attributes and save
                        string parentQuery = "INSERT INTO Parent (name, surname, phoneNumber, email, address) OUTPUT INSERTED.ParentID VALUES (@name, @surname, @phoneNumber, @email, @address)";
                        SqlCommand parentCommand = new SqlCommand(parentQuery, connection);

                        // Parent parameters
                        parentCommand.Parameters.AddWithValue("@name", txtNameParent.Text);
                        parentCommand.Parameters.AddWithValue("@surname", txtSurnameParent.Text);
                        parentCommand.Parameters.AddWithValue("@phoneNumber", maskedTextBoxPhoneNumber.Text);
                        parentCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                        parentCommand.Parameters.AddWithValue("@address", txtAddress.Text);
                        
                        parentId = (int)parentCommand.ExecuteScalar();
                    }

                    //convertion for the datetime type
                    DateTime birthdate;
                    if (!DateTime.TryParse(maskedTextBoxBirthDate.Text, out birthdate))
                    {
                        MessageBox.Show("Doğum tarihi formatı yanlış. Lütfen doğru formatta girin.");
                        return;
                    }

                    // student table query
                    string studentQuery = "INSERT INTO Student (name, surname, gender, birthdate, student_tc, ClassID, ParentID) VALUES (@name, @surname, @gender, @birthdate, @student_tc, @classId, @parentId)";
                    using (SqlCommand studentCommand = new SqlCommand(studentQuery, connection))
                    {
                    
                        studentCommand.Parameters.AddWithValue("@name", txtNameStudent.Text);
                        studentCommand.Parameters.AddWithValue("@surname", txtSurnameStudent.Text);
                        studentCommand.Parameters.AddWithValue("@gender", comboBoxGender.SelectedItem.ToString());
                        studentCommand.Parameters.AddWithValue("@birthdate", birthdate);
                        studentCommand.Parameters.AddWithValue("@student_tc", maskedTextBoxIdNo.Text);
                        studentCommand.Parameters.AddWithValue("@classId", classId);
                        studentCommand.Parameters.AddWithValue("@parentId", parentId);

                        
                        studentCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kayıt başarılı!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

    }
}
