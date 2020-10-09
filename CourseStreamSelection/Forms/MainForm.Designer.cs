namespace CourseStreamSelection.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Α"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Δίκτυα Επικοινωνιών και Ασφάλεια Συστημάτων", System.Drawing.Color.Green, System.Drawing.SystemColors.Window, new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0%")}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Β");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Γ");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Δ");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Ε");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("ΣΤ");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Ζ");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Η");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Θ");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.profileGroupBox = new System.Windows.Forms.GroupBox();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.createNewProfileGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newProfileNameTextBox = new System.Windows.Forms.TextBox();
            this.createNewProfileButton = new System.Windows.Forms.Button();
            this.currentlySelectedGroupBox = new System.Windows.Forms.GroupBox();
            this.cloneProfileButton = new System.Windows.Forms.Button();
            this.renameProfileButton = new System.Windows.Forms.Button();
            this.currentProfileNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteProfileButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.unratedProfileWarning = new System.Windows.Forms.Label();
            this.courseStreamSelectionResultsListView = new System.Windows.Forms.ListView();
            this.indexHeader = new System.Windows.Forms.ColumnHeader();
            this.titleHeader = new System.Windows.Forms.ColumnHeader();
            this.preferenceHeader = new System.Windows.Forms.ColumnHeader();
            this.editCoursePreferencesButton = new System.Windows.Forms.Button();
            this.profileGroupBox.SuspendLayout();
            this.createNewProfileGroupBox.SuspendLayout();
            this.currentlySelectedGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // profileGroupBox
            // 
            this.profileGroupBox.Controls.Add(this.profileComboBox);
            this.profileGroupBox.Controls.Add(this.createNewProfileGroupBox);
            this.profileGroupBox.Controls.Add(this.currentlySelectedGroupBox);
            this.profileGroupBox.Location = new System.Drawing.Point(12, 12);
            this.profileGroupBox.Name = "profileGroupBox";
            this.profileGroupBox.Size = new System.Drawing.Size(484, 114);
            this.profileGroupBox.TabIndex = 0;
            this.profileGroupBox.TabStop = false;
            this.profileGroupBox.Text = "Profile";
            // 
            // profileComboBox
            // 
            this.profileComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.profileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileComboBox.FormattingEnabled = true;
            this.profileComboBox.Location = new System.Drawing.Point(117, 19);
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(149, 23);
            this.profileComboBox.Sorted = true;
            this.profileComboBox.TabIndex = 0;
            this.profileComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedProfileChanged);
            // 
            // createNewProfileGroupBox
            // 
            this.createNewProfileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createNewProfileGroupBox.Controls.Add(this.label2);
            this.createNewProfileGroupBox.Controls.Add(this.newProfileNameTextBox);
            this.createNewProfileGroupBox.Controls.Add(this.createNewProfileButton);
            this.createNewProfileGroupBox.Location = new System.Drawing.Point(278, 22);
            this.createNewProfileGroupBox.Name = "createNewProfileGroupBox";
            this.createNewProfileGroupBox.Size = new System.Drawing.Size(200, 83);
            this.createNewProfileGroupBox.TabIndex = 1;
            this.createNewProfileGroupBox.TabStop = false;
            this.createNewProfileGroupBox.Text = "Create New Profile";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // newProfileNameTextBox
            // 
            this.newProfileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newProfileNameTextBox.Location = new System.Drawing.Point(6, 26);
            this.newProfileNameTextBox.MaxLength = 32;
            this.newProfileNameTextBox.Name = "newProfileNameTextBox";
            this.newProfileNameTextBox.Size = new System.Drawing.Size(188, 23);
            this.newProfileNameTextBox.TabIndex = 0;
            this.newProfileNameTextBox.TextChanged += new System.EventHandler(this.NewProfileNameTextBoxTextChanged);
            this.newProfileNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewProfileNameTextBoxKeyDown);
            this.newProfileNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewProfileNameTextBoxKeyPress);
            // 
            // createNewProfileButton
            // 
            this.createNewProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createNewProfileButton.Enabled = false;
            this.createNewProfileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createNewProfileButton.ForeColor = System.Drawing.Color.Blue;
            this.createNewProfileButton.Location = new System.Drawing.Point(5, 53);
            this.createNewProfileButton.Name = "createNewProfileButton";
            this.createNewProfileButton.Size = new System.Drawing.Size(190, 25);
            this.createNewProfileButton.TabIndex = 1;
            this.createNewProfileButton.Text = "Create New Profile";
            this.createNewProfileButton.UseVisualStyleBackColor = true;
            this.createNewProfileButton.Click += new System.EventHandler(this.NewProfileCreationRequested);
            // 
            // currentlySelectedGroupBox
            // 
            this.currentlySelectedGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.currentlySelectedGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.currentlySelectedGroupBox.Controls.Add(this.cloneProfileButton);
            this.currentlySelectedGroupBox.Controls.Add(this.renameProfileButton);
            this.currentlySelectedGroupBox.Controls.Add(this.currentProfileNameTextBox);
            this.currentlySelectedGroupBox.Controls.Add(this.deleteProfileButton);
            this.currentlySelectedGroupBox.Location = new System.Drawing.Point(6, 22);
            this.currentlySelectedGroupBox.Name = "currentlySelectedGroupBox";
            this.currentlySelectedGroupBox.Size = new System.Drawing.Size(266, 83);
            this.currentlySelectedGroupBox.TabIndex = 0;
            this.currentlySelectedGroupBox.TabStop = false;
            this.currentlySelectedGroupBox.Text = "Currently Selected";
            // 
            // cloneProfileButton
            // 
            this.cloneProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cloneProfileButton.Enabled = false;
            this.cloneProfileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cloneProfileButton.ForeColor = System.Drawing.Color.Blue;
            this.cloneProfileButton.Location = new System.Drawing.Point(161, 53);
            this.cloneProfileButton.Name = "cloneProfileButton";
            this.cloneProfileButton.Size = new System.Drawing.Size(100, 25);
            this.cloneProfileButton.TabIndex = 2;
            this.cloneProfileButton.Text = "Clone";
            this.cloneProfileButton.UseVisualStyleBackColor = true;
            this.cloneProfileButton.Click += new System.EventHandler(this.ProfileCloneRequested);
            // 
            // renameProfileButton
            // 
            this.renameProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renameProfileButton.Enabled = false;
            this.renameProfileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.renameProfileButton.ForeColor = System.Drawing.Color.Blue;
            this.renameProfileButton.Location = new System.Drawing.Point(161, 25);
            this.renameProfileButton.Name = "renameProfileButton";
            this.renameProfileButton.Size = new System.Drawing.Size(100, 25);
            this.renameProfileButton.TabIndex = 2;
            this.renameProfileButton.Text = "Rename";
            this.renameProfileButton.UseVisualStyleBackColor = true;
            this.renameProfileButton.Click += new System.EventHandler(this.ProfileRenameRequested);
            // 
            // currentProfileNameTextBox
            // 
            this.currentProfileNameTextBox.Enabled = false;
            this.currentProfileNameTextBox.Location = new System.Drawing.Point(6, 26);
            this.currentProfileNameTextBox.MaxLength = 32;
            this.currentProfileNameTextBox.Name = "currentProfileNameTextBox";
            this.currentProfileNameTextBox.Size = new System.Drawing.Size(149, 23);
            this.currentProfileNameTextBox.TabIndex = 1;
            this.currentProfileNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentProfileNameTextBoxKeyDown);
            // 
            // deleteProfileButton
            // 
            this.deleteProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteProfileButton.Enabled = false;
            this.deleteProfileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteProfileButton.ForeColor = System.Drawing.Color.Red;
            this.deleteProfileButton.Location = new System.Drawing.Point(5, 53);
            this.deleteProfileButton.Name = "deleteProfileButton";
            this.deleteProfileButton.Size = new System.Drawing.Size(151, 25);
            this.deleteProfileButton.TabIndex = 3;
            this.deleteProfileButton.Text = "Delete";
            this.deleteProfileButton.UseVisualStyleBackColor = true;
            this.deleteProfileButton.Click += new System.EventHandler(this.ProfileRemovalRequested);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.unratedProfileWarning);
            this.groupBox1.Controls.Add(this.courseStreamSelectionResultsListView);
            this.groupBox1.Controls.Add(this.editCoursePreferencesButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 256);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ideal Course Stream";
            // 
            // unratedProfileWarning
            // 
            this.unratedProfileWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unratedProfileWarning.AutoSize = true;
            this.unratedProfileWarning.Location = new System.Drawing.Point(91, 113);
            this.unratedProfileWarning.Name = "unratedProfileWarning";
            this.unratedProfileWarning.Size = new System.Drawing.Size(302, 30);
            this.unratedProfileWarning.TabIndex = 0;
            this.unratedProfileWarning.Text = "Please take the time to rate all the available subjects and\r\nprofessors through t" +
    "he Edit Course Preferences window.\r\n";
            this.unratedProfileWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // courseStreamSelectionResultsListView
            // 
            this.courseStreamSelectionResultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexHeader,
            this.titleHeader,
            this.preferenceHeader});
            this.courseStreamSelectionResultsListView.FullRowSelect = true;
            this.courseStreamSelectionResultsListView.GridLines = true;
            this.courseStreamSelectionResultsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.courseStreamSelectionResultsListView.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.courseStreamSelectionResultsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.courseStreamSelectionResultsListView.Location = new System.Drawing.Point(6, 22);
            this.courseStreamSelectionResultsListView.Name = "courseStreamSelectionResultsListView";
            this.courseStreamSelectionResultsListView.Scrollable = false;
            this.courseStreamSelectionResultsListView.ShowGroups = false;
            this.courseStreamSelectionResultsListView.Size = new System.Drawing.Size(472, 199);
            this.courseStreamSelectionResultsListView.TabIndex = 3;
            this.courseStreamSelectionResultsListView.UseCompatibleStateImageBehavior = false;
            this.courseStreamSelectionResultsListView.View = System.Windows.Forms.View.Details;
            this.courseStreamSelectionResultsListView.Visible = false;
            // 
            // indexHeader
            // 
            this.indexHeader.Text = "Index";
            this.indexHeader.Width = 50;
            // 
            // titleHeader
            // 
            this.titleHeader.Text = "Title";
            this.titleHeader.Width = 348;
            // 
            // preferenceHeader
            // 
            this.preferenceHeader.Text = "Preference";
            this.preferenceHeader.Width = 70;
            // 
            // editCoursePreferencesButton
            // 
            this.editCoursePreferencesButton.Enabled = false;
            this.editCoursePreferencesButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.editCoursePreferencesButton.ForeColor = System.Drawing.Color.Blue;
            this.editCoursePreferencesButton.Location = new System.Drawing.Point(5, 226);
            this.editCoursePreferencesButton.Name = "editCoursePreferencesButton";
            this.editCoursePreferencesButton.Size = new System.Drawing.Size(474, 25);
            this.editCoursePreferencesButton.TabIndex = 2;
            this.editCoursePreferencesButton.Text = "Edit Course Preferences";
            this.editCoursePreferencesButton.UseVisualStyleBackColor = true;
            this.editCoursePreferencesButton.Click += new System.EventHandler(this.CoursePreferencesEditRequested);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.profileGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Course Stream Selection";
            this.Activated += new System.EventHandler(this.FormActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingRequested);
            this.Shown += new System.EventHandler(this.FormShown);
            this.Enter += new System.EventHandler(this.FormEntered);
            this.profileGroupBox.ResumeLayout(false);
            this.createNewProfileGroupBox.ResumeLayout(false);
            this.createNewProfileGroupBox.PerformLayout();
            this.currentlySelectedGroupBox.ResumeLayout(false);
            this.currentlySelectedGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox profileGroupBox;
        private System.Windows.Forms.Button deleteProfileButton;
        private System.Windows.Forms.ComboBox profileComboBox;
        private System.Windows.Forms.GroupBox currentlySelectedGroupBox;
        private System.Windows.Forms.Button renameProfileButton;
        private System.Windows.Forms.TextBox currentProfileNameTextBox;
        private System.Windows.Forms.GroupBox createNewProfileGroupBox;
        private System.Windows.Forms.TextBox newProfileNameTextBox;
        private System.Windows.Forms.Button createNewProfileButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button editCoursePreferencesButton;
        private System.Windows.Forms.Label unratedProfileWarning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView courseStreamSelectionResultsListView;
        private System.Windows.Forms.ColumnHeader indexHeader;
        private System.Windows.Forms.ColumnHeader titleHeader;
        private System.Windows.Forms.ColumnHeader preferenceHeader;
        private System.Windows.Forms.Button cloneProfileButton;
    }
}

