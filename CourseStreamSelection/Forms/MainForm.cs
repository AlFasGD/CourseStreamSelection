using CourseStreamSelection.Databases;
using CourseStreamSelection.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CourseStreamSelection.Forms
{
    public partial class MainForm : Form
    {
        private Profile currentlySelectedProfile;
        private MainDatabase mainDatabaseInstance = MainDatabase.Instance;

        private EditCoursePreferencesForm editCoursePreferencesForm;

        public MainForm()
        {
            InitializeComponent();
            LoadCourseStreams();
        }

        #region Loading
        private void LoadState()
        {
            profileComboBox.Items.AddRange(mainDatabaseInstance.Profiles.ToArray());
            if (profileComboBox.Items.Count > 0)
                profileComboBox.SelectedIndex = 0;
            UpdateEnabledStatus();
        }
        private void LoadCourseStreams()
        {
            courseStreamSelectionResultsListView.Items.Clear();

            foreach (var stream in MainDatabase.Instance.CourseStreams)
            {
                var item = new ListViewItem(new string[] { stream.Key, stream.Value, "" });
                courseStreamSelectionResultsListView.Items.Add(item);
            }
        }
        #endregion

        #region Event Handlers
        private void SelectedProfileChanged(object sender, EventArgs e)
        {
            currentlySelectedProfile = mainDatabaseInstance.GetProfile(profileComboBox.Text);
            currentProfileNameTextBox.Text = currentlySelectedProfile?.ToString();
            editCoursePreferencesForm?.SwitchProfile(currentlySelectedProfile);
            UpdateIdealCourseSelection();
        }

        #region Form
        private void FormActivated(object sender, EventArgs e)
        {
            UpdateIdealCourseSelection();
        }
        private void FormEntered(object sender, EventArgs e)
        {
            UpdateIdealCourseSelection();
        }
        private void FormShown(object sender, EventArgs e)
        {
            LoadState();
        }
        private void FormClosingRequested(object sender, FormClosingEventArgs e)
        {
            MainDatabase.Instance.SaveProfiles();
        }
        #endregion

        #region Buttons
        private void NewProfileCreationRequested(object sender, EventArgs e)
        {
            var created = mainDatabaseInstance.CreateNewProfile(newProfileNameTextBox.Text);
            if (created == null)
                return;

            UpdateEnabledStatus(true);
            profileComboBox.SelectedIndex = profileComboBox.Items.Add(created);
            newProfileNameTextBox.Text = "";
        }
        private void ProfileRemovalRequested(object sender, EventArgs e)
        {
            mainDatabaseInstance.RemoveProfile(currentlySelectedProfile);
            UpdateEnabledStatus();

            // I'd say this should be abstracted somewhere
            // Logic 100
            int indexToRemove = profileComboBox.SelectedIndex;

            profileComboBox.SelectedIndex = indexToRemove - 1;
            profileComboBox.Items.RemoveAt(indexToRemove);

            if (indexToRemove <= 0 && profileComboBox.Items.Count > 0)
                profileComboBox.SelectedIndex++;
        }
        private void ProfileRenameRequested(object sender, EventArgs e)
        {
            if (!mainDatabaseInstance.RenameProfile(currentlySelectedProfile, currentProfileNameTextBox.Text))
            {
                currentProfileNameTextBox.Text = currentlySelectedProfile.ToString();
                return;
            }

            profileComboBox.Items[profileComboBox.SelectedIndex] = currentlySelectedProfile;
        }
        private void ProfileCloneRequested(object sender, EventArgs e)
        {
            var cloned = mainDatabaseInstance.Clone(currentlySelectedProfile);
            currentlySelectedProfile = cloned;
            profileComboBox.Items.Add(cloned);
            profileComboBox.SelectedItem = cloned;
        }
        private void CoursePreferencesEditRequested(object sender, EventArgs e)
        {
            if (editCoursePreferencesForm == null || editCoursePreferencesForm.IsDisposed)
            {
                editCoursePreferencesForm = new EditCoursePreferencesForm(currentlySelectedProfile);
                editCoursePreferencesForm.AnyRatingChanged += UpdateIdealCourseSelection;
                editCoursePreferencesForm.Show();
            }
            else
            {
                editCoursePreferencesForm.Close();
                editCoursePreferencesForm = null;
            }
        }
        #endregion

        #region Text Boxes
        private void CurrentProfileNameTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProfileRenameRequested(sender, e);
        }
        private void NewProfileNameTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NewProfileCreationRequested(sender, e);
        }
        private void NewProfileNameTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            UpdateNewProfileEnabledStatus();
        }
        private void NewProfileNameTextBoxTextChanged(object sender, EventArgs e)
        {
            UpdateNewProfileEnabledStatus();
        }
        #endregion
        #endregion

        private void UpdateEnabledStatus()
        {
            var count = mainDatabaseInstance.ProfileCount;
            UpdateEnabledStatus(count > 0);
            if (count == 0)
                newProfileNameTextBox.Focus();
        }
        private void UpdateEnabledStatus(bool enabled)
        {
            var controls = new Control[]
            {
                editCoursePreferencesButton,
                currentProfileNameTextBox,
                deleteProfileButton,
                renameProfileButton,
                cloneProfileButton,
            };

            foreach (var c in controls)
                c.Enabled = enabled;
        }
        private void UpdateNewProfileEnabledStatus()
        {
            createNewProfileButton.Enabled = newProfileNameTextBox.Text.Any();
        }
        private void UpdateIdealCourseSelection()
        {
            if (unratedProfileWarning.Visible = !(courseStreamSelectionResultsListView.Visible = (currentlySelectedProfile?.HasRatedEverything ?? false)))
                return;

            var results = currentlySelectedProfile.GetCourseStreamSelectionResults().Results;
            for (int i = 0; i < results.Length; i++)
                courseStreamSelectionResultsListView.Items[i].SubItems[2].Text = results[i].ToString("P1");
        }
    }
}
