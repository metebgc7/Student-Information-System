using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;



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
            timer.Interval = 5000; 
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


        private void btnGetFourth_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();

                
                string query = "SELECT StudentID, name, surname FROM Student";
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();

                // adding student data in a list
                List<Student> students = new List<Student>();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = reader.GetInt32(0),
                        FullName = reader.GetString(1) + " " + reader.GetString(2)
                    });
                }
                reader.Close();

                
                query = "SELECT StudentID, date FROM Attendance";
                command = new SqlCommand(query, connect);
                reader = command.ExecuteReader();

                // addin attendance data in a dictionary
                Dictionary<int, List<string>> attendanceData = new Dictionary<int, List<string>>();
                while (reader.Read())
                {
                    int studentId = reader.GetInt32(0);
                    string date = reader.GetDateTime(1).ToString("dd.MM.yyyy");

                    if (!attendanceData.ContainsKey(studentId))
                    {
                        attendanceData[studentId] = new List<string>();
                    }
                    attendanceData[studentId].Add(date);
                }
                reader.Close();

                
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string folderPath = Path.Combine(desktopPath, "Attendance Report");

                
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                
                string dateNow = DateTime.Now.ToString("dd.MM.yyyy");
                string filePath = Path.Combine(folderPath, $"Genel Devamsızlık Raporu {dateNow}.pdf");

                
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var titleFont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);

                
                var title = new Paragraph("ÖĞRENCİ RAPORU", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                
                document.Add(new Paragraph("\n"));

                
                PdfPTable table = new PdfPTable(3); 

                
                var headerFont = new Font(bf, 15, iTextSharp.text.Font.BOLD);
                PdfPCell cell1 = new PdfPCell(new Phrase("ID", headerFont));
                PdfPCell cell2 = new PdfPCell(new Phrase("Ad Soyad", headerFont));
                PdfPCell cell3 = new PdfPCell(new Phrase("Devamsızlık Tarihleri", headerFont));

                table.AddCell(cell1);
                table.AddCell(cell2);
                table.AddCell(cell3);

                // creating cells
                var contentFont = new Font(bf, 12, iTextSharp.text.Font.NORMAL);
                foreach (var student in students)
                {
                    table.AddCell(new Phrase(student.Id.ToString(), contentFont));
                    table.AddCell(new Phrase(student.FullName, contentFont));

                    // attendance datas
                    if (attendanceData.ContainsKey(student.Id))
                    {
                        string dates = string.Join("\n", attendanceData[student.Id]);
                        PdfPCell attendanceCell = new PdfPCell(new Phrase(dates, contentFont));
                        table.AddCell(attendanceCell);
                    }
                    else
                    {
                        table.AddCell(new Phrase("", contentFont));
                    }
                }

                document.Add(table);
                document.Close();

                MessageBox.Show($"PDF '{filePath}' olarak oluşturuldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public class Student
        {
            public int Id { get; set; }
            public string FullName { get; set; } 
        }


        private void btnGetSecond_Click(object sender, EventArgs e)
        {
            try
            {
                
                int studentId;
                if (!int.TryParse(txtStudentId2.Text, out studentId))
                {
                    MessageBox.Show("Lütfen geçerli bir öğrenci numarası giriniz.");
                    return;
                }

                connect.Open();

                
                string studentQuery = "SELECT name, surname FROM Student WHERE StudentID = @StudentID";
                SqlCommand studentCommand = new SqlCommand(studentQuery, connect);
                studentCommand.Parameters.AddWithValue("@StudentID", studentId);
                SqlDataReader studentReader = studentCommand.ExecuteReader();

                string studentName = "";
                string studentSurname = "";
                if (studentReader.Read())
                {
                    studentName = studentReader.GetString(0);
                    studentSurname = studentReader.GetString(1);
                }
                studentReader.Close();

                if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(studentSurname))
                {
                    MessageBox.Show("Böyle bir öğrenci numarası bulunamadı.");
                    return;
                }

                
                string query = "SELECT date FROM Attendance WHERE StudentID = @StudentID";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@StudentID", studentId);
                SqlDataReader reader = command.ExecuteReader();

                // adding attendance data in a lise 
                List<string> attendanceDates = new List<string>();
                while (reader.Read())
                {
                    attendanceDates.Add(reader.GetDateTime(0).ToString("dd.MM.yyyy"));
                }
                reader.Close();

                if (attendanceDates.Count == 0)
                {
                    MessageBox.Show("Bu öğrenci numarasına ait devamsızlık bilgisi bulunamadı.");
                    return;
                }

                
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string folderPath = Path.Combine(desktopPath, "Attendance Report");

                
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                
                string dateNow = DateTime.Now.ToString("dd.MM.yyyy");
                string filePath = Path.Combine(folderPath, $"{studentName} {studentSurname} devamsızlık raporu {dateNow}.pdf");

                // PDF creating
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var titleFont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
                var contentFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                
                var title = new Paragraph("ÖĞRENCİ DEVAMSIZLIK RAPORU", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                
                document.Add(new Paragraph("\n"));

                
                string attendanceText = $"{studentId} numaralı öğrencimiz olan {studentName} {studentSurname}, {string.Join(", ", attendanceDates)} tarihlerinde devamsızlık yapmıştır.";
                var attendanceParagraph = new Paragraph(attendanceText, contentFont);
                document.Add(attendanceParagraph);

                document.Close();

                MessageBox.Show($"PDF '{filePath}' olarak oluşturuldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnGetThird_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dateTimePickerThird.Value.Date;
                DateTime endDate = dateTimePickerFourth.Value.Date;

                connect.Open();

                // sql query for student and attendance data
                string query = @"
                    SELECT s.StudentID, s.name, s.surname, a.date
                    FROM Student s
                    LEFT JOIN Attendance a ON s.StudentID = a.StudentID
                    WHERE a.date BETWEEN @StartDate AND @EndDate OR a.date IS NULL
                    ORDER BY s.StudentID, a.date";

                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = command.ExecuteReader();

                // adding student and attendance datas in a dictionary
                Dictionary<int, StudentAttendance> studentAttendanceData = new Dictionary<int, StudentAttendance>();
                while (reader.Read())
                {
                    int studentId = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    string date = reader.IsDBNull(3) ? null : reader.GetDateTime(3).ToString("dd.MM.yyyy");

                    if (!studentAttendanceData.ContainsKey(studentId))
                    {
                        studentAttendanceData[studentId] = new StudentAttendance
                        {
                            Id = studentId,
                            FullName = $"{name} {surname}",
                            AttendanceDates = new List<string>()
                        };
                    }

                    if (date != null)
                    {
                        studentAttendanceData[studentId].AttendanceDates.Add(date);
                    }
                }
                reader.Close();

                //desktop path
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string folderPath = Path.Combine(desktopPath, "Attendance Report");

                
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // PDF file path
                string startDateFormatted = startDate.ToString("dd.MM.yyyy");
                string endDateFormatted = endDate.ToString("dd.MM.yyyy");
                string filePath = Path.Combine(folderPath, $"{startDateFormatted} - {endDateFormatted} devamsızlık raporu.pdf");

                // PDF creating
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var titleFont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
                var headerFont = new iTextSharp.text.Font(bf, 15, iTextSharp.text.Font.BOLD);
                var contentFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                
                var title = new Paragraph("DEVAMSIZLIK RAPORU", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                
                document.Add(new Paragraph("\n"));

               
                PdfPTable table = new PdfPTable(3); 

                
                PdfPCell cell1 = new PdfPCell(new Phrase("Öğrenci No", headerFont));
                PdfPCell cell2 = new PdfPCell(new Phrase("Ad Soyad", headerFont));
                PdfPCell cell3 = new PdfPCell(new Phrase("Devamsızlık Tarihleri", headerFont));

                table.AddCell(cell1);
                table.AddCell(cell2);
                table.AddCell(cell3);

                // creating cell
                foreach (var student in studentAttendanceData.Values)
                {
                    table.AddCell(new Phrase(student.Id.ToString(), contentFont));
                    table.AddCell(new Phrase(student.FullName, contentFont));

                    string dates = string.Join("\n", student.AttendanceDates);
                    PdfPCell attendanceCell = new PdfPCell(new Phrase(dates, contentFont));
                    table.AddCell(attendanceCell);
                }

                document.Add(table);
                document.Close();

                MessageBox.Show($" Rapor masaüstündeki Attandance Reports klasöründe oluşturuldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public class StudentAttendance
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public List<string> AttendanceDates { get; set; }
        }

        private void btnGetFirst_Click(object sender, EventArgs e)
        {
            try
            {
                
                int studentId;
                if (!int.TryParse(txtStudentId1.Text, out studentId))
                {
                    MessageBox.Show("Lütfen geçerli bir öğrenci numarası giriniz.");
                    return;
                }

                DateTime startDate = dateTimePickerFirst.Value.Date;
                DateTime endDate = dateTimePickerSecond.Value.Date;

                connect.Open();

                
                string studentQuery = "SELECT name, surname FROM Student WHERE StudentID = @StudentID";
                SqlCommand studentCommand = new SqlCommand(studentQuery, connect);
                studentCommand.Parameters.AddWithValue("@StudentID", studentId);
                SqlDataReader studentReader = studentCommand.ExecuteReader();

                string studentName = "";
                string studentSurname = "";
                if (studentReader.Read())
                {
                    studentName = studentReader.GetString(0);
                    studentSurname = studentReader.GetString(1);
                }
                studentReader.Close();

                if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(studentSurname))
                {
                    MessageBox.Show("Böyle bir öğrenci numarası bulunamadı.");
                    return;
                }

               
                string query = "SELECT date FROM Attendance WHERE StudentID = @StudentID AND date BETWEEN @StartDate AND @EndDate";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@StudentID", studentId);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = command.ExecuteReader();

                // adding the attendance dates in a list
                List<string> attendanceDates = new List<string>();
                while (reader.Read())
                {
                    attendanceDates.Add(reader.GetDateTime(0).ToString("dd.MM.yyyy"));
                }
                reader.Close();

                if (attendanceDates.Count == 0)
                {
                    MessageBox.Show("Belirtilen tarihler arasında bu öğrenciye ait devamsızlık bilgisi bulunamadı.");
                    return;
                }

                
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string folderPath = Path.Combine(desktopPath, "Attendance Report");

                
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // PDF file pathway
                string dateNow = DateTime.Now.ToString("dd.MM.yyyy");
                string filePath = Path.Combine(folderPath, $"{studentName} {studentSurname} devamsızlık raporu {dateNow}.pdf");

                // PDF creating
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var titleFont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
                var contentFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                
                var title = new Paragraph("ÖĞRENCİ DEVAMSIZLIK RAPORU", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                
                document.Add(new Paragraph("\n"));

                
                string attendanceText = $"{studentId} numaralı öğrencimiz olan {studentName} {studentSurname} şu tarihler arasında yaptığı devamsızlıklar aşağıda verilmiştir:";
                var attendanceParagraph = new Paragraph(attendanceText, contentFont);
                document.Add(attendanceParagraph);

                
                document.Add(new Paragraph("\n"));
                foreach (var date in attendanceDates)
                {
                    document.Add(new Paragraph(date, contentFont));
                }

                document.Close();

                MessageBox.Show($"PDF '{filePath}' olarak oluşturuldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

    }

}

