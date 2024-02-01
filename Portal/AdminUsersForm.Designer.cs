namespace Portal
{
    partial class AdminUsersForm
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
            this.addUserSingularBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.deleteUserBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.updateStudentBtn = new System.Windows.Forms.Button();
            this.cmbNewlyUser = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbUserRoles = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 124);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(124, 124);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 167);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(124, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtPersonalId
            // 
            this.txtPersonalId.Location = new System.Drawing.Point(12, 213);
            this.txtPersonalId.Name = "txtPersonalId";
            this.txtPersonalId.Size = new System.Drawing.Size(100, 20);
            this.txtPersonalId.TabIndex = 4;
            // 
            // dateTimePickerBirthDate
            // 
            this.dateTimePickerBirthDate.Location = new System.Drawing.Point(12, 252);
            this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            this.dateTimePickerBirthDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBirthDate.TabIndex = 5;
            // 
            // addUserSingularBtn
            // 
            this.addUserSingularBtn.Location = new System.Drawing.Point(70, 278);
            this.addUserSingularBtn.Name = "addUserSingularBtn";
            this.addUserSingularBtn.Size = new System.Drawing.Size(90, 23);
            this.addUserSingularBtn.TabIndex = 6;
            this.addUserSingularBtn.Text = "add";
            this.addUserSingularBtn.UseVisualStyleBackColor = true;
            this.addUserSingularBtn.Click += new System.EventHandler(this.addUserSingularBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Temprorary Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Personal ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Birth Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "First Name:";
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(591, 123);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUsers.TabIndex = 14;
            // 
            // deleteUserBtn
            // 
            this.deleteUserBtn.Location = new System.Drawing.Point(484, 164);
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteUserBtn.TabIndex = 15;
            this.deleteUserBtn.Text = "Delete";
            this.deleteUserBtn.UseVisualStyleBackColor = true;
            this.deleteUserBtn.Click += new System.EventHandler(this.deleteUserBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(567, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Or";
            // 
            // updateStudentBtn
            // 
            this.updateStudentBtn.Location = new System.Drawing.Point(591, 164);
            this.updateStudentBtn.Name = "updateStudentBtn";
            this.updateStudentBtn.Size = new System.Drawing.Size(75, 23);
            this.updateStudentBtn.TabIndex = 17;
            this.updateStudentBtn.Text = "Update";
            this.updateStudentBtn.UseVisualStyleBackColor = true;
            this.updateStudentBtn.Click += new System.EventHandler(this.updateUserBtn_Click);
            // 
            // cmbNewlyUser
            // 
            this.cmbNewlyUser.FormattingEnabled = true;
            this.cmbNewlyUser.Location = new System.Drawing.Point(12, 84);
            this.cmbNewlyUser.Name = "cmbNewlyUser";
            this.cmbNewlyUser.Size = new System.Drawing.Size(121, 21);
            this.cmbNewlyUser.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Choose Role:";
            // 
            // cmbUserRoles
            // 
            this.cmbUserRoles.FormattingEnabled = true;
            this.cmbUserRoles.Location = new System.Drawing.Point(438, 123);
            this.cmbUserRoles.Name = "cmbUserRoles";
            this.cmbUserRoles.Size = new System.Drawing.Size(121, 21);
            this.cmbUserRoles.TabIndex = 20;
            this.cmbUserRoles.SelectedValueChanged += new System.EventHandler(this.cmbUserRoles_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(435, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Choose Role:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(588, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Choose User:";
            // 
            // AdminUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbUserRoles);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbNewlyUser);
            this.Controls.Add(this.updateStudentBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteUserBtn);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addUserSingularBtn);
            this.Controls.Add(this.dateTimePickerBirthDate);
            this.Controls.Add(this.txtPersonalId);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtName);
            this.Name = "AdminUsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create, Update or Delete Users";
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
        private System.Windows.Forms.Button addUserSingularBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Button deleteUserBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateStudentBtn;
        private System.Windows.Forms.ComboBox cmbNewlyUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbUserRoles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}