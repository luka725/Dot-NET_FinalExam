namespace Portal
{
    partial class AdminStudentForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPersonalId = new System.Windows.Forms.TextBox();
            this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
            this.addStudentSingularBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxStudents = new System.Windows.Forms.ComboBox();
            this.deleteStudentBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.updateStudentBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(18, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(124, 63);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(230, 63);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(336, 63);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtPersonalId
            // 
            this.txtPersonalId.Location = new System.Drawing.Point(442, 63);
            this.txtPersonalId.Name = "txtPersonalId";
            this.txtPersonalId.Size = new System.Drawing.Size(100, 20);
            this.txtPersonalId.TabIndex = 4;
            // 
            // dateTimePickerBirthDate
            // 
            this.dateTimePickerBirthDate.Location = new System.Drawing.Point(548, 63);
            this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            this.dateTimePickerBirthDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBirthDate.TabIndex = 5;
            // 
            // addStudentSingularBtn
            // 
            this.addStudentSingularBtn.Location = new System.Drawing.Point(754, 61);
            this.addStudentSingularBtn.Name = "addStudentSingularBtn";
            this.addStudentSingularBtn.Size = new System.Drawing.Size(34, 23);
            this.addStudentSingularBtn.TabIndex = 6;
            this.addStudentSingularBtn.Text = "add";
            this.addStudentSingularBtn.UseVisualStyleBackColor = true;
            this.addStudentSingularBtn.Click += new System.EventHandler(this.addStudentSingularBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Student Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Temprorary Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Personal ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(545, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Birth Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "First Name:";
            // 
            // comboBoxStudents
            // 
            this.comboBoxStudents.FormattingEnabled = true;
            this.comboBoxStudents.Location = new System.Drawing.Point(18, 131);
            this.comboBoxStudents.Name = "comboBoxStudents";
            this.comboBoxStudents.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStudents.TabIndex = 14;
            this.comboBoxStudents.DropDown += new System.EventHandler(this.comboBoxStudents_DropDown);
            // 
            // deleteStudentBtn
            // 
            this.deleteStudentBtn.Location = new System.Drawing.Point(145, 129);
            this.deleteStudentBtn.Name = "deleteStudentBtn";
            this.deleteStudentBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteStudentBtn.TabIndex = 15;
            this.deleteStudentBtn.Text = "Delete";
            this.deleteStudentBtn.UseVisualStyleBackColor = true;
            this.deleteStudentBtn.Click += new System.EventHandler(this.deleteStudentBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Or";
            // 
            // updateStudentBtn
            // 
            this.updateStudentBtn.Location = new System.Drawing.Point(250, 129);
            this.updateStudentBtn.Name = "updateStudentBtn";
            this.updateStudentBtn.Size = new System.Drawing.Size(75, 23);
            this.updateStudentBtn.TabIndex = 17;
            this.updateStudentBtn.Text = "Update";
            this.updateStudentBtn.UseVisualStyleBackColor = true;
            this.updateStudentBtn.Click += new System.EventHandler(this.updateStudentBtn_Click);
            // 
            // AdminStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updateStudentBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteStudentBtn);
            this.Controls.Add(this.comboBoxStudents);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addStudentSingularBtn);
            this.Controls.Add(this.dateTimePickerBirthDate);
            this.Controls.Add(this.txtPersonalId);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtName);
            this.Name = "AdminStudentForm";
            this.Text = "AdminStudentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPersonalId;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthDate;
        private System.Windows.Forms.Button addStudentSingularBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxStudents;
        private System.Windows.Forms.Button deleteStudentBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateStudentBtn;
    }
}