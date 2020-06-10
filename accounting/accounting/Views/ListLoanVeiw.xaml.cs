using accounting.ViewModels;
using Xamarin.Forms;
using accounting.Services;
namespace accounting.Views
{
	
	public partial class ListLoanVeiw : ContentPage
	{
        ListLoanViewModel newListLoan = new ListLoanViewModel();
		public ListLoanVeiw ()
		{
			InitializeComponent ();
            movmentList.BindingContext = newListLoan;
		}

        private async void MovmentList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            LoanViewList selectedLoan = (LoanViewList)e.SelectedItem;

            bool date;
            if (int.Parse(selectedLoan.FinalySum) > 0) date = true;
            else date = false;
            await Navigation.PushAsync(new ListLoanSelectedVeiw(date, selectedLoan.Id));
        }
    }
}