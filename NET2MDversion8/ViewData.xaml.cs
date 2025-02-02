using System;
using System.Globalization;
using System.Windows;
using NET1MDversion2;

namespace NET2MDversion8;

public partial class ViewData : ContentPage
{
	public ViewData()
	{
		InitializeComponent();
	}

    private void OnPrintClicked(object sender, EventArgs e)
    {
        //izmantojam schoolManager metodi, lai izdrukatu datus
        dataDisplayLabel.Text = App.schoolMan.print();
    }
    private void OnCreateClicked(object sender, EventArgs e)
    {
        App.schoolMan.createTestData(); //izmantojam schoolManager metodi, lai izveidotu testa datus
    }
    private async void OnSaveClicked(object sender, EventArgs e) //uzgenerets ar AI riku
    {
        try
        {
            App.schoolMan.save(@"C:\Temp\schooldata.xml");

            // Verify the file exists and contains data
            string filePath = @"C:\Temp\schooldata.xml";
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(fileContent))
                {
                    await DisplayAlert("Success", "Data saved successfully and file verified. Please check your Temp folder.", "Ok");
                }
                else
                {
                    await DisplayAlert("Warning", "Data saved but the file appears to be empty. Please check your Temp folder.", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "File not found after save attempt. Please check your Temp folder.", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error saving data: {ex.Message}", "Ok");
        }
    }
    private async void OnLoadClicked(object sender, EventArgs e) //uzgenerets ar AI riku
    {
        try
        {
            string filePath = @"C:\Temp\schooldata.xml";
            App.schoolMan.load(filePath);

            // Verify the file exists and contains data
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(fileContent))
                {
                    await DisplayAlert("Success", $"Data loaded successfully from {filePath}", "Ok");
                }
                else
                {
                    await DisplayAlert("Warning", "File loaded but appears to be empty. Please check your Temp folder.", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "File not found. Please check your Temp folder.", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error loading data: {ex.Message}", "Ok");
        }
    }

    private void OnRestartClicked(object sender, EventArgs e)
    {
        App.schoolMan.reset();
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        App.schoolMan.print();
    }
}