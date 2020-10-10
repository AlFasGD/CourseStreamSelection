using CourseStreamSelection.Databases;
using CourseStreamSelection.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CourseStreamSelection.Forms
{
    public partial class EditCoursePreferencesForm : Form
    {
        private static List<Course> courses = MainDatabase.Instance.Courses;
        private static List<string> professors = MainDatabase.Instance.Professors;

        private Profile profile;

        public event Action CourseRatingChanged;
        public event Action ProfessorRatingChanged;
        public event Action AnyRatingChanged
        {
            add
            {
                CourseRatingChanged += value;
                ProfessorRatingChanged += value;
            }
            remove
            {
                CourseRatingChanged -= value;
                ProfessorRatingChanged -= value;
            }
        }

        public EditCoursePreferencesForm(Profile p)
        {
            InitializeComponent();
            AddSelectAllEvents();

            SwitchProfile(p);
        }

        public void SwitchProfile(Profile newProfile)
        {
            profile = newProfile;
            LoadCurrentProfile();
        }

        private void AddSelectAllEvents()
        {
            AddSelectAllEventsToComponents(coursesGroupBox, HandleSelectAllCourses);
            AddSelectAllEventsToComponents(professorsGroupBox, HandleSelectAllProfessors);
        }

        #region Loading
        private void LoadCurrentProfile()
        {
            LoadCourses();
            LoadProfessors();
        }
        private void LoadCourses()
        {
            coursesListView.Items.Clear();

            foreach (var c in courses)
            {
                profile.CourseRatings.TryGetValue(c, out double? rating);
                var item = new ListViewItem(new string[] { c.Code, c.Name, rating.ToString() });
                item.Group = coursesListView.Groups[$"semester{c.Semester}"];
                coursesListView.Items.Add(item);
            }
        }
        private void LoadProfessors()
        {
            professorsListView.Items.Clear();

            foreach (var p in professors)
            {
                profile.ProfessorRatings.TryGetValue(p, out double? rating);
                var item = new ListViewItem(new string[] { p, rating.ToString() });
                professorsListView.Items.Add(item);
            }
        }
        #endregion

        private void HandleSelectAllCourses(object sender, KeyEventArgs e)
        {
            if (IsValidSelectAll(e))
                SelectAllElements(coursesListView);
        }
        private void HandleSelectAllProfessors(object sender, KeyEventArgs e)
        {
            if (IsValidSelectAll(e))
                SelectAllElements(professorsListView);
        }

        private static bool IsValidSelectAll(KeyEventArgs e)
        {
            return ModifierKeys == Keys.Control && e.KeyCode == Keys.A;
        }
        private static void SelectAllElements(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
                item.Selected = true;
        }
        private static void AddSelectAllEventsToComponents(Control control, KeyEventHandler handler)
        {
            foreach (Control c in control.Controls)
            {
                c.KeyDown += handler;
                AddSelectAllEventsToComponents(c, handler);
            }
        }

        #region Event Handling
        #region Form
        #endregion

        #region ListViews
        private void SelectedCourseChanged(object sender, EventArgs e)
        {
            UpdateCourseRatingComponents();
        }
        private void SelectedProfessorChanged(object sender, EventArgs e)
        {
            UpdateProfessorRatingComponents();
        }

        private void CoursesListViewMouseUp(object sender, MouseEventArgs e)
        {
            FocusAndSelectAll(courseRatingTextBox);
        }
        private void ProfessorsListViewMouseUp(object sender, MouseEventArgs e)
        {
            FocusAndSelectAll(professorRatingTextBox);
        }
        #endregion

        #region Buttons
        private void ResetSelectedCourseRatingsRequested(object sender, EventArgs e)
        {
            SetCurrentlySelectedCourseRatings(null);
        }
        private void ResetSelectedProfessorRatingsRequested(object sender, EventArgs e)
        {
            SetCurrentlySelectedProfessorRatings(null);
        }

        private void SetCourseRatingRequested(object sender, EventArgs e)
        {
            if (!TryParseDouble(courseRatingTextBox.Text, out double rating))
                return;

            SetCurrentlySelectedCourseRatings(rating);
        }
        private void SetProfessorRatingRequested(object sender, EventArgs e)
        {
            if (!TryParseDouble(professorRatingTextBox.Text, out double rating))
                return;

            SetCurrentlySelectedProfessorRatings(rating);
        }

        private static bool TryParseDouble(string text, out double value)
        {
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return true;
            return double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }
        #endregion

        #region Text Boxes
        private static void NavigateToNextElement(ListView view)
        {
            int max = int.MinValue;
            // Imagine if the Windows Forms API wasn't shit
            foreach (int i in view.SelectedIndices)
            {
                if (i > max)
                    max = i;
                view.Items[i].Selected = false;
            }

            int next = max;
            if (max < view.Items.Count - 1)
                next++;

            view.Items[next].Selected = true;
        }
        private static void NavigateToPreviousElement(ListView view)
        {
            int min = int.MaxValue;
            foreach (int i in view.SelectedIndices)
            {
                if (i < min)
                    min = i;
                view.Items[i].Selected = false;
            }

            int previous = min;
            if (min > 0)
                previous--;

            view.Items[previous].Selected = true;
        }

        private void TextBoxKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                case Keys.Up:
                    FocusAndSelectAll(sender as TextBox);
                    break;
            }
        }
        private void CourseRatingTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SetCourseRatingRequested(sender, e);
                    break;
                case Keys.Down:
                    SetCourseRatingRequested(sender, e);
                    NavigateToNextElement(coursesListView);
                    break;
                case Keys.Up:
                    SetCourseRatingRequested(sender, e);
                    NavigateToPreviousElement(coursesListView);
                    break;
                default:
                    return;
            }
            FocusAndSelectAll(courseRatingTextBox);
        }
        private void ProfessorRatingTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SetProfessorRatingRequested(sender, e);
                    break;
                case Keys.Down:
                    SetProfessorRatingRequested(sender, e);
                    NavigateToNextElement(professorsListView);
                    break;
                case Keys.Up:
                    SetProfessorRatingRequested(sender, e);
                    NavigateToPreviousElement(professorsListView);
                    break;
                default:
                    return;
            }
            FocusAndSelectAll(professorRatingTextBox);
        }
        #endregion

        #region Other Functions
        private void UpdateCourseRatingComponents()
        {
            resetSelectedCourseRatingsButton.Enabled = courseRatingTextBox.Enabled = setCourseRatingButton.Enabled = coursesListView.SelectedIndices.Count > 0;

            courseRatingTextBox.Text = "";

            if (coursesListView.SelectedIndices.Count == 0)
                return;

            if (!TryGetCurrentCourseRating(coursesListView.SelectedIndices[0], out double? expectedRating))
                return;

            if (expectedRating == null)
                return;

            foreach (int i in coursesListView.SelectedIndices)
                if (!TryGetCurrentCourseRating(i, out double? rating) || rating != expectedRating)
                    return;

            courseRatingTextBox.Text = expectedRating.ToString();
            FocusAndSelectAll(courseRatingTextBox);
        }
        private void UpdateProfessorRatingComponents()
        {
            resetSelectedProfessorRatingsButton.Enabled = professorRatingTextBox.Enabled = setProfessorRatingButton.Enabled = professorsListView.SelectedIndices.Count > 0;

            professorRatingTextBox.Text = "";

            if (professorsListView.SelectedIndices.Count == 0)
                return;

            if (!TryGetCurrentProfessorRating(professorsListView.SelectedIndices[0], out double? expectedRating))
                return;

            if (expectedRating == null)
                return;

            foreach (int i in professorsListView.SelectedIndices)
                if (!TryGetCurrentProfessorRating(i, out double? rating) || rating != expectedRating)
                    return;

            professorRatingTextBox.Text = expectedRating.ToString();
            FocusAndSelectAll(professorRatingTextBox);
        }

        private bool TryGetCurrentCourseRating(int index, out double? rating)
        {
            return profile.CourseRatings.TryGetValue(courses[index], out rating);
        }
        private bool TryGetCurrentProfessorRating(int index, out double? rating)
        {
            return profile.ProfessorRatings.TryGetValue(professors[index], out rating);
        }
        private void TrySetCurrentCourseRating(int index, double? rating)
        {
            var course = courses[index];
            if (profile.CourseRatings.ContainsKey(course))
                profile.CourseRatings[course] = rating;
            else
                profile.CourseRatings.Add(course, rating);
        }
        private void TrySetCurrentProfessorRating(int index, double? rating)
        {
            var professor = professors[index];
            if (profile.ProfessorRatings.ContainsKey(professor))
                profile.ProfessorRatings[professor] = rating;
            else
                profile.ProfessorRatings.Add(professor, rating);
        }
        private void SetCurrentlySelectedCourseRatings(double? rating)
        {
            foreach (int i in coursesListView.SelectedIndices)
            {
                TrySetCurrentCourseRating(i, rating);
                coursesListView.Items[i].SubItems[2].Text = rating.ToString();
            }
            CourseRatingChanged?.Invoke();
        }
        private void SetCurrentlySelectedProfessorRatings(double? rating)
        {
            foreach (int i in professorsListView.SelectedIndices)
            {
                TrySetCurrentProfessorRating(i, rating);
                professorsListView.Items[i].SubItems[1].Text = rating.ToString();
            }
            ProfessorRatingChanged?.Invoke();
        }
        #endregion
        #endregion

        private static void FocusAndSelectAll(TextBox textBox)
        {
            textBox.Focus();
            textBox.SelectAll();
        }
    }
}
