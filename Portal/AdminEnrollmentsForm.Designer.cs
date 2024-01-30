namespace Portal
{
    partial class AdminEnrollmentsForm
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
            this.radioStudent = new System.Windows.Forms.RadioButton();
            this.radioLecturer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEnrollmentAction = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveChangesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioStudent
            // 
            this.radioStudent.AutoSize = true;
            this.radioStudent.Location = new System.Drawing.Point(298, 107);
            this.radioStudent.Name = "radioStudent";
            this.radioStudent.Size = new System.Drawing.Size(62, 17);
            this.radioStudent.TabIndex = 0;
            this.radioStudent.TabStop = true;
            this.radioStudent.Text = "Student";
            this.radioStudent.UseVisualStyleBackColor = true;
            this.radioStudent.CheckedChanged += new System.EventHandler(this.radioStudent_CheckedChanged);
            // 
            // radioLecturer
            // 
            this.radioLecturer.AutoSize = true;
            this.radioLecturer.Location = new System.Drawing.Point(298, 84);
            this.radioLecturer.Name = "radioLecturer";
            this.radioLecturer.Size = new System.Drawing.Size(64, 17);
            this.radioLecturer.TabIndex = 1;
            this.radioLecturer.TabStop = true;
            this.radioLecturer.Text = "Lecturer";
            this.radioLecturer.UseVisualStyleBackColor = true;
            this.radioLecturer.CheckedChanged += new System.EventHandler(this.radioLecturer_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Category:";
            // 
            // cmbEnrollmentAction
            // 
            this.cmbEnrollmentAction.FormattingEnabled = true;
            this.cmbEnrollmentAction.Location = new System.Drawing.Point(298, 147);
            this.cmbEnrollmentAction.Name = "cmbEnrollmentAction";
            this.cmbEnrollmentAction.Size = new System.Drawing.Size(121, 21);
            this.cmbEnrollmentAction.TabIndex = 3;
            this.cmbEnrollmentAction.SelectedIndexChanged += new System.EventHandler(this.cmbEnrollmentAction_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose Action:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Choose Iteraction Between User and Subject:";
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(298, 222);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(121, 21);
            this.cmbUsers.TabIndex = 6;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // cmbSubjects
            // 
            this.cmbSubjects.FormattingEnabled = true;
            this.cmbSubjects.Location = new System.Drawing.Point(298, 266);
            this.cmbSubjects.Name = "cmbSubjects";
            this.cmbSubjects.Size = new System.Drawing.Size(121, 21);
            this.cmbSubjects.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Users";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Subjects";
            // 
            // saveChangesBtn
            // 
            this.saveChangesBtn.Location = new System.Drawing.Point(321, 304);
            this.saveChangesBtn.Name = "saveChangesBtn";
            this.saveChangesBtn.Size = new System.Drawing.Size(75, 23);
            this.saveChangesBtn.TabIndex = 10;
            this.saveChangesBtn.Text = "Save";
            this.saveChangesBtn.UseVisualStyleBackColor = true;
            this.saveChangesBtn.Click += new System.EventHandler(this.saveChangesBtn_Click);
            // 
            // AdminEnrollmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveChangesBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSubjects);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEnrollmentAction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioLecturer);
            this.Controls.Add(this.radioStudent);
            this.Name = "AdminEnrollmentsForm";
            this.Text = "AdminEnrollments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioStudent;
        private System.Windows.Forms.RadioButton radioLecturer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEnrollmentAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveChangesBtn;
    }
}