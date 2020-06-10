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
	public partial class GiveLoanView : ContentPage
	{
        GiveLoanViewModel giveLoanViewModel = new GiveLoanViewModel();
		public GiveLoanView ()
		{
			InitializeComponent ();
            giveLoanVeiwStack.BindingContext = giveLoanViewModel;
		}
        private async void SaveGiveLoanViewImgButton_Clicked(object sender, EventArgs e)
        {
            if (nameGives.Text != "")
            {
                if (surnameGives.Text != "")
                {
                    if (mobileNumberGives.Text != "")
                    {
                        if (endDateGiveLoan.Date.ToString() != "")
                        {
                            if (sumGives.Text != "")
                            {
                                giveLoanViewModel.Save();
                                await Navigation.PopAsync();
                            }
                            else sumGives.BackgroundColor = Color.Red;                          
                        }
                        else endDateGiveLoan.BackgroundColor = Color.Red;
                    }
                    else mobileNumberGives.BackgroundColor = Color.Red;
                }
                else surnameGives.BackgroundColor = Color.Red;
            }
            else nameGives.BackgroundColor = Color.Red;
        }
    }
}