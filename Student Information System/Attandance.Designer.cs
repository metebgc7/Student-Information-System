namespace Student_Information_System
{
    partial class Attandance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attandance));
            this.picQuitStudents = new System.Windows.Forms.PictureBox();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picQuitStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // picQuitStudents
            // 
            this.picQuitStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQuitStudents.Image = ((System.Drawing.Image)(resources.GetObject("picQuitStudents.Image")));
            this.picQuitStudents.Location = new System.Drawing.Point(433, 1);
            this.picQuitStudents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picQuitStudents.Name = "picQuitStudents";
            this.picQuitStudents.Size = new System.Drawing.Size(57, 54);
            this.picQuitStudents.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuitStudents.TabIndex = 9;
            this.picQuitStudents.TabStop = false;
            this.picQuitStudents.Click += new System.EventHandler(this.picQuitStudents_Click);
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStudentID.Location = new System.Drawing.Point(77, 103);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(150, 32);
            this.lblStudentID.TabIndex = 11;
            this.lblStudentID.Text = "Student ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(146, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "Date :";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtStudentID.Location = new System.Drawing.Point(233, 103);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(145, 36);
            this.txtStudentID.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Montserrat Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(193, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 15;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedTextBox.Location = new System.Drawing.Point(233, 177);
            this.maskedTextBox.Mask = "00/00/0000";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(145, 36);
            this.maskedTextBox.TabIndex = 16;
            this.maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // Attandance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(491, 343);
            this.Controls.Add(this.maskedTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.picQuitStudents);
            this.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Attandance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attandance";
            ((System.ComponentModel.ISupportInitialize)(this.picQuitStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picQuitStudents;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
    }
}