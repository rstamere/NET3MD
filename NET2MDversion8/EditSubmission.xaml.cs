using NET1MDversion2;
namespace NET2MDversion8;

public partial class EditSubmission : ContentPage
{
    private Submission _submission; //added submission
    public EditSubmission()
	{
		InitializeComponent();
        SubmissionList.ItemsSource = App.schoolMan.SchoolInfo.Submissions;
    }
    private void RefreshList()
    {
        SubmissionList.ItemsSource = null;
        SubmissionList.ItemsSource = App.schoolMan.SchoolInfo.Submissions;
    }

    private async void SubmissionList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (IsEditingChx.IsChecked)
        {
            //edit mode
            if (SubmissionList.SelectedItem != null)
            {
                Submission submission = (Submission)SubmissionList.SelectedItem;
                await Navigation.PushModalAsync(new CreateSubmission(submission)); //go to create submission
            }
        }
        else
        {
            //delete mode
            if (SubmissionList.SelectedItem != null)
            {
                Submission submission = (Submission)SubmissionList.SelectedItem;
                bool answer = await DisplayAlert("Delete", "Are you sure you want to delete this submission? \n" + submission.ToString(), "Yes", "No");
                if (answer)
                {
                    App.schoolMan.SchoolInfo.Submissions.Remove(submission);
                    RefreshList();
                }
            }
        }
    }
    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        RefreshList();
    }
}