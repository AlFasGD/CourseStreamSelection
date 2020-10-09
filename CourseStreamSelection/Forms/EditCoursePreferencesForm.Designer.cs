namespace CourseStreamSelection.Forms
{
    partial class EditCoursePreferencesForm
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Semester 6", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Semester 7", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Semester 8", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "NNA-07-02",
            "Μοντελοποίηση και Προσομοίωση Υπολογιστικών Συστημάτων",
            "99999"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Θρασύβουλος-Κωνσταντίνος Τσιάτσος",
            "-69"}, -1);
            this.coursesListView = new System.Windows.Forms.ListView();
            this.codeHeader = new System.Windows.Forms.ColumnHeader();
            this.titleHeader = new System.Windows.Forms.ColumnHeader();
            this.ratingHeader = new System.Windows.Forms.ColumnHeader();
            this.coursesGroupBox = new System.Windows.Forms.GroupBox();
            this.setCourseRatingButton = new System.Windows.Forms.Button();
            this.resetSelectedCourseRatingsButton = new System.Windows.Forms.Button();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.courseRatingTextBox = new System.Windows.Forms.TextBox();
            this.professorsGroupBox = new System.Windows.Forms.GroupBox();
            this.setProfessorRatingButton = new System.Windows.Forms.Button();
            this.resetSelectedProfessorRatingsButton = new System.Windows.Forms.Button();
            this.professorsListView = new System.Windows.Forms.ListView();
            this.professorNameHeader = new System.Windows.Forms.ColumnHeader();
            this.professorRatingHeader = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.professorRatingTextBox = new System.Windows.Forms.TextBox();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.coursesGroupBox.SuspendLayout();
            this.professorsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // coursesListView
            // 
            this.coursesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coursesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.codeHeader,
            this.titleHeader,
            this.ratingHeader});
            this.coursesListView.FullRowSelect = true;
            listViewGroup1.Header = "Semester 6";
            listViewGroup1.Name = "semester6";
            listViewGroup2.Header = "Semester 7";
            listViewGroup2.Name = "semester7";
            listViewGroup3.Header = "Semester 8";
            listViewGroup3.Name = "semester8";
            this.coursesListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.coursesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.coursesListView.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.coursesListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.coursesListView.LabelWrap = false;
            this.coursesListView.Location = new System.Drawing.Point(6, 22);
            this.coursesListView.Name = "coursesListView";
            this.coursesListView.Size = new System.Drawing.Size(532, 272);
            this.coursesListView.TabIndex = 0;
            this.coursesListView.UseCompatibleStateImageBehavior = false;
            this.coursesListView.View = System.Windows.Forms.View.Details;
            this.coursesListView.SelectedIndexChanged += new System.EventHandler(this.SelectedCourseChanged);
            this.coursesListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CoursesListViewMouseUp);
            // 
            // codeHeader
            // 
            this.codeHeader.Text = "Code";
            this.codeHeader.Width = 86;
            // 
            // titleHeader
            // 
            this.titleHeader.Text = "Title";
            this.titleHeader.Width = 375;
            // 
            // ratingHeader
            // 
            this.ratingHeader.Text = "Rating";
            this.ratingHeader.Width = 50;
            // 
            // coursesGroupBox
            // 
            this.coursesGroupBox.Controls.Add(this.setCourseRatingButton);
            this.coursesGroupBox.Controls.Add(this.resetSelectedCourseRatingsButton);
            this.coursesGroupBox.Controls.Add(this.ratingLabel);
            this.coursesGroupBox.Controls.Add(this.courseRatingTextBox);
            this.coursesGroupBox.Controls.Add(this.coursesListView);
            this.coursesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.coursesGroupBox.Name = "coursesGroupBox";
            this.coursesGroupBox.Size = new System.Drawing.Size(544, 329);
            this.coursesGroupBox.TabIndex = 1;
            this.coursesGroupBox.TabStop = false;
            this.coursesGroupBox.Text = "Courses";
            // 
            // setCourseRatingButton
            // 
            this.setCourseRatingButton.Enabled = false;
            this.setCourseRatingButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.setCourseRatingButton.ForeColor = System.Drawing.Color.Blue;
            this.setCourseRatingButton.Location = new System.Drawing.Point(505, 299);
            this.setCourseRatingButton.Name = "setCourseRatingButton";
            this.setCourseRatingButton.Size = new System.Drawing.Size(34, 25);
            this.setCourseRatingButton.TabIndex = 4;
            this.setCourseRatingButton.Text = "Set";
            this.setCourseRatingButton.UseVisualStyleBackColor = true;
            this.setCourseRatingButton.Click += new System.EventHandler(this.SetCourseRatingRequested);
            // 
            // resetSelectedCourseRatingsButton
            // 
            this.resetSelectedCourseRatingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetSelectedCourseRatingsButton.Enabled = false;
            this.resetSelectedCourseRatingsButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resetSelectedCourseRatingsButton.ForeColor = System.Drawing.Color.Red;
            this.resetSelectedCourseRatingsButton.Location = new System.Drawing.Point(5, 299);
            this.resetSelectedCourseRatingsButton.Name = "resetSelectedCourseRatingsButton";
            this.resetSelectedCourseRatingsButton.Size = new System.Drawing.Size(269, 25);
            this.resetSelectedCourseRatingsButton.TabIndex = 3;
            this.resetSelectedCourseRatingsButton.Text = "Reset Selected Ratings";
            this.resetSelectedCourseRatingsButton.UseVisualStyleBackColor = true;
            this.resetSelectedCourseRatingsButton.Click += new System.EventHandler(this.ResetSelectedCourseRatingsRequested);
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.BackColor = System.Drawing.Color.Transparent;
            this.ratingLabel.Location = new System.Drawing.Point(403, 303);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(41, 15);
            this.ratingLabel.TabIndex = 2;
            this.ratingLabel.Text = "Rating";
            // 
            // courseRatingTextBox
            // 
            this.courseRatingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.courseRatingTextBox.Enabled = false;
            this.courseRatingTextBox.Location = new System.Drawing.Point(450, 300);
            this.courseRatingTextBox.MaxLength = 5;
            this.courseRatingTextBox.Name = "courseRatingTextBox";
            this.courseRatingTextBox.Size = new System.Drawing.Size(50, 23);
            this.courseRatingTextBox.TabIndex = 1;
            this.courseRatingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CourseRatingTextBoxKeyDown);
            this.courseRatingTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyUp);
            // 
            // professorsGroupBox
            // 
            this.professorsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.professorsGroupBox.Controls.Add(this.setProfessorRatingButton);
            this.professorsGroupBox.Controls.Add(this.resetSelectedProfessorRatingsButton);
            this.professorsGroupBox.Controls.Add(this.professorsListView);
            this.professorsGroupBox.Controls.Add(this.label1);
            this.professorsGroupBox.Controls.Add(this.professorRatingTextBox);
            this.professorsGroupBox.Location = new System.Drawing.Point(562, 12);
            this.professorsGroupBox.Name = "professorsGroupBox";
            this.professorsGroupBox.Size = new System.Drawing.Size(333, 329);
            this.professorsGroupBox.TabIndex = 2;
            this.professorsGroupBox.TabStop = false;
            this.professorsGroupBox.Text = "Professors";
            // 
            // setProfessorRatingButton
            // 
            this.setProfessorRatingButton.Enabled = false;
            this.setProfessorRatingButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.setProfessorRatingButton.ForeColor = System.Drawing.Color.Blue;
            this.setProfessorRatingButton.Location = new System.Drawing.Point(294, 299);
            this.setProfessorRatingButton.Name = "setProfessorRatingButton";
            this.setProfessorRatingButton.Size = new System.Drawing.Size(34, 25);
            this.setProfessorRatingButton.TabIndex = 4;
            this.setProfessorRatingButton.Text = "Set";
            this.setProfessorRatingButton.UseVisualStyleBackColor = true;
            this.setProfessorRatingButton.Click += new System.EventHandler(this.SetProfessorRatingRequested);
            // 
            // resetSelectedProfessorRatingsButton
            // 
            this.resetSelectedProfessorRatingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetSelectedProfessorRatingsButton.Enabled = false;
            this.resetSelectedProfessorRatingsButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resetSelectedProfessorRatingsButton.ForeColor = System.Drawing.Color.Red;
            this.resetSelectedProfessorRatingsButton.Location = new System.Drawing.Point(5, 299);
            this.resetSelectedProfessorRatingsButton.Name = "resetSelectedProfessorRatingsButton";
            this.resetSelectedProfessorRatingsButton.Size = new System.Drawing.Size(163, 25);
            this.resetSelectedProfessorRatingsButton.TabIndex = 3;
            this.resetSelectedProfessorRatingsButton.Text = "Reset Selected Ratings";
            this.resetSelectedProfessorRatingsButton.UseVisualStyleBackColor = true;
            this.resetSelectedProfessorRatingsButton.Click += new System.EventHandler(this.ResetSelectedProfessorRatingsRequested);
            // 
            // professorsListView
            // 
            this.professorsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.professorsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.professorNameHeader,
            this.professorRatingHeader});
            this.professorsListView.FullRowSelect = true;
            this.professorsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.professorsListView.HideSelection = false;
            listViewItem2.StateImageIndex = 0;
            this.professorsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.professorsListView.LabelWrap = false;
            this.professorsListView.Location = new System.Drawing.Point(6, 22);
            this.professorsListView.Name = "professorsListView";
            this.professorsListView.Size = new System.Drawing.Size(321, 272);
            this.professorsListView.TabIndex = 0;
            this.professorsListView.UseCompatibleStateImageBehavior = false;
            this.professorsListView.View = System.Windows.Forms.View.Details;
            this.professorsListView.SelectedIndexChanged += new System.EventHandler(this.SelectedProfessorChanged);
            this.professorsListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ProfessorsListViewMouseUp);
            // 
            // professorNameHeader
            // 
            this.professorNameHeader.Text = "Name";
            this.professorNameHeader.Width = 250;
            // 
            // professorRatingHeader
            // 
            this.professorRatingHeader.Text = "Rating";
            this.professorRatingHeader.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rating";
            // 
            // professorRatingTextBox
            // 
            this.professorRatingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.professorRatingTextBox.Enabled = false;
            this.professorRatingTextBox.Location = new System.Drawing.Point(239, 300);
            this.professorRatingTextBox.MaxLength = 5;
            this.professorRatingTextBox.Name = "professorRatingTextBox";
            this.professorRatingTextBox.Size = new System.Drawing.Size(50, 23);
            this.professorRatingTextBox.TabIndex = 1;
            this.professorRatingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProfessorRatingTextBoxKeyDown);
            this.professorRatingTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 375;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rating";
            this.columnHeader3.Width = 50;
            // 
            // EditCoursePreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 353);
            this.Controls.Add(this.professorsGroupBox);
            this.Controls.Add(this.coursesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditCoursePreferencesForm";
            this.Text = "Edit Course Preferences";
            this.coursesGroupBox.ResumeLayout(false);
            this.coursesGroupBox.PerformLayout();
            this.professorsGroupBox.ResumeLayout(false);
            this.professorsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView coursesListView;
        private System.Windows.Forms.ColumnHeader codeHeader;
        private System.Windows.Forms.ColumnHeader titleHeader;
        private System.Windows.Forms.ColumnHeader ratingHeader;
        private System.Windows.Forms.GroupBox coursesGroupBox;
        private System.Windows.Forms.GroupBox professorsGroupBox;
        private System.Windows.Forms.ListView professorsListView;
        private System.Windows.Forms.ColumnHeader professorNameHeader;
        private System.Windows.Forms.ColumnHeader professorRatingHeader;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button resetSelectedCourseRatingsButton;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.TextBox courseRatingTextBox;
        private System.Windows.Forms.Button resetSelectedProfessorRatingsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox professorRatingTextBox;
        private System.Windows.Forms.Button setCourseRatingButton;
        private System.Windows.Forms.Button setProfessorRatingButton;
    }
}