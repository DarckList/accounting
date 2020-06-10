using System;

using accounting.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace accounting.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListLoanSelectedVeiw : ContentPage
	{
        ListLoanSelectedViewModel listloanSelected;
		public ListLoanSelectedVeiw (bool table, int id)
		{
			InitializeComponent ();
            listloanSelected = new ListLoanSelectedViewModel(table, id);
            giveLoanVeiwStack.BindingContext = listloanSelected;

        }

        private async void DeletLoan_Clicked(object sender, EventArgs e)
        {
            listloanSelected.Delet();
            await Navigation.PopAsync();
        }

        private async void SaveLoanSelected_Clicked(object sender, EventArgs e)
        {
            listloanSelected.Save();
            await Navigation.PopAsync();
        }
    }
}