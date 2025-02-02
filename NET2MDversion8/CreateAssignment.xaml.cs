using NET1MDversion2;
namespace NET2MDversion8;

public partial class CreateAssignment : ContentPage
{
    private Assignment _assignment; //added assignment
    public CreateAssignment()
	{
		InitializeComponent();
        BindingContext = App.schoolMan.SchoolInfo;
    }
    public CreateAssignment(Assignment assignment)
    {
        InitializeComponent();
        _assignment = assignment;
        AssignmentDescription.Text = _assignment.Description;
        AssignmentDate.Date = _assignment.Deadline;
        AssignmentCourse.SelectedItem = _assignment.Course;
        AddAssignmentBtn.Text = "Edit Assignment";
    }
    private async void OnAddAssignmentClicked(object sender, EventArgs e)
    {
        try
        {
            //TimeSpan selectedTime = AssignmentTime.Time
            DateTime deadline = AssignmentDate.Date;
            var course = (Course)AssignmentCourse.SelectedItem;

            if (course == null)
            {
                await DisplayAlert("Error", "Please select a course", "Ok");
                return;
            }

            TeacherLabel.Text = $"Teacher: {course.Teacher.ToString()}";

            string description = AssignmentDescription.Text;

            if (string.IsNullOrWhiteSpace(description))
            {
                await DisplayAlert("Error", "Please enter a description", "Ok");
                return;
            }
            if (_assignment == null) //izveidojam jaunu assignment
            {
                App.schoolMan.addAssignment(deadline, course, description);
                await DisplayAlert("Success", "Assignment added successfully", "Ok");
                await Shell.Current.GoToAsync("//ViewData");
            }
            else //redigejam assignment
            {
                _assignment.Description = description;
                _assignment.Deadline = deadline;
                _assignment.Course = course;
                await DisplayAlert("Success", "Assignment edited successfully", "Ok");
                await Navigation.PopModalAsync(); //go to edit assignment
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error adding/editing assignment: {ex.Message}", "Ok");
        }

    }
}