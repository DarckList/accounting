using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accounting.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace accounting.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TakeLoanView : ContentPage
	{
        TakeLoanViewModel takeLoanViewModel = new TakeLoanViewModel();

		public TakeLoanView ()
		{
			InitializeComponent ();
           takeLoanVeiwStack.BindingContext = takeLoanViewModel;
		}
    
        private async void SaveTakeLoanViewImgButton_Clicked(object sender, EventArgs e)
        {
            if (nameTakers.Text != "")
            {
                if (surnameTakers.Text!="")
                {
                    if (mobileNumberTakers.Text != "")
                    {
                        if (endDateTakeLoan.Date.ToString() != "")
                        {
                            if (sumTakers.Text != "")
                            {
                                takeLoanViewModel.Save();
                                await Navigation.PopAsync();
                            } else sumTakers.BackgroundColor = Color.Red;
                        } else endDateTakeLoan.BackgroundColor = Color.Red;
                    } else mobileNumberTakers.BackgroundColor = Color.Red;
                } else surnameTakers.BackgroundColor = Color.Red;
            } else nameTakers.BackgroundColor = Color.Red;
        }
    }
}