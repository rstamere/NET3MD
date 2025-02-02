namespace NET2MDversion8;
using NET1MDversion2;

public partial class EditAssignment : ContentPage
{
    private Assignment _assignment; //added assignment
    public EditAssignment()
	{
		InitializeComponent();
        AssignmentList.ItemsSource = App.schoolMan.SchoolInfo.Assignments;
    }
    private void RefreshList() //paldies pasniedzejai - sadi implementeet edit un delete funkcionalitati ir geniali (runa ir par visu datni)
    {
        AssignmentList.ItemsSource = null;
        AssignmentList.ItemsSource = App.schoolMan.SchoolInfo.Assignments;
    }

    private async void AssignmentList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (IsEditingChx.IsChecked)
        {
            //edit mode
            if (AssignmentList.SelectedItem != null)
            {
                Assignment assignment = (Assignment)AssignmentList.SelectedItem;
                await Navigation.PushModalAsync(new CreateAssignment(assignment)); //go to create assignment
            }
        }
        else
        {
            //delete mode
            if (AssignmentList.SelectedItem != null)
            {
                Assignment assignment = (Assignment)AssignmentList.SelectedItem;
                bool answer = await DisplayAlert("Delete", "Are you sure you want to delete this assignment? \n" + assignment.ToString(), "Yes", "No");
                if (answer)
                {
                    App.schoolMan.SchoolInfo.Assignments.Remove(assignment);
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