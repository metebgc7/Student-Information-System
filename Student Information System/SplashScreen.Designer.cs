namespace Student_Information_System
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.picLoadingGif = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // picLoadingGif
            // 
            this.picLoadingGif.Image = ((System.Drawing.Image)(resources.GetObject("picLoadingGif.Image")));
            this.picLoadingGif.Location = new System.Drawing.Point(253, 61);
            this.picLoadingGif.Name = "picLoadingGif";
            this.picLoadingGif.Size = new System.Drawing.Size(154, 145);
            this.picLoadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoadingGif.TabIndex = 0;
            this.picLoadingGif.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(277, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(592, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Welcome to Student Information System";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(684, 383);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLoadingGif);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            ((System.ComponentModel.ISupportInitialize)(this.picLoadingGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLoadingGif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}