using NET1MDversion2;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.ObjectModel;

namespace NET2MDversion8;

public partial class CreateSubmission : ContentPage
{
    private Submission _submission;
    public CreateSubmission()
	{
		InitializeComponent();
        BindingContext = App.schoolMan.SchoolInfo;
    }

    public CreateSubmission(Submission submission) //added for editing
    {
        InitializeComponent();
        _submission = submission;
        SubmissionAssignment.SelectedItem = _submission.Assignment;
        SubmissionStudent.SelectedItem = _submission.Student;
        SubmissionTime.Date = _submission.SubmissionTime;
        SubmissionScore.Text = _submission.Score.ToString();
        CreateSubmissionBtn.Text = "Update Submission";
    }

    private async void OnAddSubmissionClicked(object sender, EventArgs e) //man ir LOTI daudz kluudu parbaudes, bet cerams taa nav slikta lieta
    {
        try
        {
            var assignment = (Assignment)SubmissionAssignment.SelectedItem;
            if (assignment == null)
            {
                await DisplayAlert("Error", "Please select an assignment", "Ok");
                return;
            }

            var student = (Student)SubmissionStudent.SelectedItem;
            if (student == null)
            {
                await DisplayAlert("Error", "Please select a student", "Ok");
                return;
            }
            DateTime submissionTime = SubmissionTime.Date;

            if (!int.TryParse(SubmissionScore.Text, out int score))
            {
                await DisplayAlert("Error", "Score must be a number", "Ok");
                return;
            }
            if (score < 0 || score > 10)
            {
                await DisplayAlert("Error", "Score must be between 0 and 10", "Ok");
                return;
            }

            if (_submission == null) //adding
            {
                App.schoolMan.addSubmission(assignment, student, submissionTime, score);
                await DisplayAlert("Success", "Submission added successfully", "Ok");
                await Shell.Current.GoToAsync("//ViewData");
            }
            else //editing
            {
                _submission.Assignment = assignment;
                _submission.Student = student;
                _submission.SubmissionTime = submissionTime;
                _submission.Score = score;
                await DisplayAlert("Success", "Submission updated successfully", "Ok");
                await Navigation.PopModalAsync(); //edit submission page
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error adding submission: {ex.Message}", "Ok");
        }
    }
}