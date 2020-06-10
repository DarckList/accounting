using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using accounting.ViewModels;

namespace accounting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeVeiw : ContentPage
	{
        HomeVeiwModel homeVeiwModelList = new HomeVeiwModel();
        public HomeVeiw()
		{
			InitializeComponent ();
            MonthBalance.BindingContext = homeVeiwModelList;
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EnteringFundsVeiw());
        }

        private async void ExpenseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseFundsVeiw());
        }

        private async void TakeLoan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TakeLoanView());
        }

        private async void GetLoan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GiveLoanView());
        }
    }
}