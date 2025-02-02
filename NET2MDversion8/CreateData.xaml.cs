using System;
using System.Windows;
using NET1MDversion2;
namespace NET2MDversion8;

public partial class CreateData : ContentPage
{
	public CreateData()
	{
		InitializeComponent();
	}
    //private schoolManager _schoolManager = App.schoolMan;

    private async void OnAddStudentClicked(object sender, EventArgs e)
    {
        try
        {
            string name = StudentName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                await DisplayAlert("Error", "Please input student name", "Ok");
                return;
            }
            string surname = StudentSurname.Text;
            if (string.IsNullOrWhiteSpace(surname))
            {
                await DisplayAlert("Error", "Please input student surname", "Ok");
                return;
            }
            if (StudentGender.SelectedItem == null)
            {
                await DisplayAlert("Error", "Please select a student gender", "Ok");
                return;
            }
            Person.GenderType gender = (Person.GenderType)Enum.Parse(typeof(Person.GenderType), StudentGender.SelectedItem.ToString());

            string studentIdNumber = StudentIDNumber.Text;
            if (string.IsNullOrWhiteSpace(studentIdNumber))
            {
                await DisplayAlert("Error", "Please input a student ID number", "Ok");
                return;
            }

            App.schoolMan.addStudent(name, surname, gender, studentIdNumber);
            await DisplayAlert("Success", "Student added successfully", "Ok");

            await Shell.Current.GoToAsync("//ViewData"); 
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error adding student: {ex.Message}", "Ok");
        }
    }
}