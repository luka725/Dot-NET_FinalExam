namespace Portal
{
    partial class AdministratorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEntityType = new System.Windows.Forms.ComboBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvStudentsSubjects = new System.Windows.Forms.DataGridView();
            this.viewGradesBtn = new System.Windows.Forms.Button();
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.dgvLecturers = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.callReportBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // cmbEntityType
            // 
            this.cmbEntityType.FormattingEnabled = true;
            this.cmbEntityType.Location = new System.Drawing.Point(12, 74);
            this.cmbEntityType.Name = "cmbEntityType";
            this.cmbEntityType.Size = new System.Drawing.Size(121, 21);
            this.cmbEntityType.TabIndex = 1;
            this.cmbEntityType.SelectedIndexChanged += new System.EventHandler(this.cmbEntityType_SelectedIndexChanged);
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(139, 72);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(75, 23);
            this.selectBtn.TabIndex = 2;
            this.selectBtn.Text = "Select";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "From The Dropdown Choose Which Task You Want to Done.";
            // 
            // dgvStudentsSubjects
            // 
            this.dgvStudentsSubjects.AllowUserToAddRows = false;
            this.dgvStudentsSubjects.AllowUserToDeleteRows = false;
            this.dgvStudentsSubjects.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvStudentsSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentsSubjects.Location = new System.Drawing.Point(15, 167);
            this.dgvStudentsSubjects.MultiSelect = false;
            this.dgvStudentsSubjects.Name = "dgvStudentsSubjects";
            this.dgvStudentsSubjects.ReadOnly = true;
            this.dgvStudentsSubjects.ShowEditingIcon = false;
            this.dgvStudentsSubjects.Size = new System.Drawing.Size(625, 271);
            this.dgvStudentsSubjects.TabIndex = 4;
            // 
            // viewGradesBtn
            // 
            this.viewGradesBtn.Location = new System.Drawing.Point(302, 138);
            this.viewGradesBtn.Name = "viewGradesBtn";
            this.viewGradesBtn.Size = new System.Drawing.Size(75, 23);
            this.viewGradesBtn.TabIndex = 5;
            this.viewGradesBtn.Text = "View Grades";
            this.viewGradesBtn.UseVisualStyleBackColor = true;
            this.viewGradesBtn.Click += new System.EventHandler(this.viewGradesBtn_Click);
            // 
            // cmbSubjects
            // 
            this.cmbSubjects.FormattingEnabled = true;
            this.cmbSubjects.Location = new System.Drawing.Point(15, 138);
            this.cmbSubjects.Name = "cmbSubjects";
            this.cmbSubjects.Size = new System.Drawing.Size(154, 21);
            this.cmbSubjects.TabIndex = 6;
            this.cmbSubjects.SelectedIndexChanged += new System.EventHandler(this.cmbSubjects_SelectedIndexChanged);
            // 
            // cmbStudents
            // 
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Location = new System.Drawing.Point(175, 138);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(121, 21);
            this.cmbStudents.TabIndex = 7;
            // 
            // dgvLecturers
            // 
            this.dgvLecturers.AllowUserToAddRows = false;
            this.dgvLecturers.AllowUserToDeleteRows = false;
            this.dgvLecturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLecturers.Enabled = false;
            this.dgvLecturers.Location = new System.Drawing.Point(646, 167);
            this.dgvLecturers.MultiSelect = false;
            this.dgvLecturers.Name = "dgvLecturers";
            this.dgvLecturers.ReadOnly = true;
            this.dgvLecturers.Size = new System.Drawing.Size(142, 144);
            this.dgvLecturers.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Subjects:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Students:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(643, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Lecturers:";
            // 
            // callReportBtn
            // 
            this.callReportBtn.Location = new System.Drawing.Point(713, 74);
            this.callReportBtn.Name = "callReportBtn";
            this.callReportBtn.Size = new System.Drawing.Size(75, 23);
            this.callReportBtn.TabIndex = 12;
            this.callReportBtn.Text = "View Report";
            this.callReportBtn.UseVisualStyleBackColor = true;
            this.callReportBtn.Click += new System.EventHandler(this.callReportBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(383, 138);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 13;
            this.refreshBtn.Text = "Refresh columns";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // AdministratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.callReportBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvLecturers);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.cmbSubjects);
            this.Controls.Add(this.viewGradesBtn);
            this.Controls.Add(this.dgvStudentsSubjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.cmbEntityType);
            this.Controls.Add(this.label1);
            this.Name = "AdministratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministratorForm_FormClosing);
            this.Load += new System.EventHandler(this.AdministratorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEntityType;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvStudentsSubjects;
        private System.Windows.Forms.Button viewGradesBtn;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.DataGridView dgvLecturers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button callReportBtn;
        private System.Windows.Forms.Button refreshBtn;
    }
}