namespace Portal
{
    partial class LecturerForm
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
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.subjectBtn = new System.Windows.Forms.Button();
            this.dgvSubject = new System.Windows.Forms.DataGridView();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).BeginInit();
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
            // cmbSubjects
            // 
            this.cmbSubjects.FormattingEnabled = true;
            this.cmbSubjects.Location = new System.Drawing.Point(15, 47);
            this.cmbSubjects.Name = "cmbSubjects";
            this.cmbSubjects.Size = new System.Drawing.Size(121, 21);
            this.cmbSubjects.TabIndex = 1;
            // 
            // subjectBtn
            // 
            this.subjectBtn.Location = new System.Drawing.Point(142, 47);
            this.subjectBtn.Name = "subjectBtn";
            this.subjectBtn.Size = new System.Drawing.Size(75, 23);
            this.subjectBtn.TabIndex = 2;
            this.subjectBtn.Text = "Select";
            this.subjectBtn.UseVisualStyleBackColor = true;
            this.subjectBtn.Click += new System.EventHandler(this.subjectBtn_Click);
            // 
            // dgvSubject
            // 
            this.dgvSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubject.Location = new System.Drawing.Point(15, 76);
            this.dgvSubject.Name = "dgvSubject";
            this.dgvSubject.Size = new System.Drawing.Size(773, 317);
            this.dgvSubject.TabIndex = 3;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(713, 399);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(75, 23);
            this.btnSaveChanges.TabIndex = 4;
            this.btnSaveChanges.Text = "Save";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.dgvSubject);
            this.Controls.Add(this.subjectBtn);
            this.Controls.Add(this.cmbSubjects);
            this.Controls.Add(this.label1);
            this.Name = "LecturerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lecturer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LecturerForm_FormClosing);
            this.Load += new System.EventHandler(this.LecturerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.Button subjectBtn;
        private System.Windows.Forms.DataGridView dgvSubject;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}