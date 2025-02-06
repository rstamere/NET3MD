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

    private void OnRestartClicked(object sender, EventArgs e)
    {
        App.schoolMan.reset();
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        App.schoolMan.print();
    }

}