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
	public partial class EnteringFundsVeiw : ContentPage
	{
        public static double calculateSum;
        EnteringFundsVeiwModel fundsData;
		public EnteringFundsVeiw ()
		{
            InitializeComponent();
            fundsData = new EnteringFundsVeiwModel();
            fundsVeiwStack.BindingContext = fundsData;
        }

        public EnteringFundsVeiw(int id)
        {
            InitializeComponent();
            fundsData = new EnteringFundsVeiwModel(id);
            fundsVeiwStack.BindingContext = fundsData;
        }

        protected override void OnAppearing()
        {
            if (calculateSum != 0) entrySum.Text = calculateSum.ToString();
            base.OnAppearing();
        }

        private async void Calculator_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SimpleCalculatorView(true));
        }

        private async void SaveEnteringFunds_Clicked(object sender, EventArgs e)
        {
            if (entrySum.Text != "")
            {
                if (enteringPicker.SelectedIndex >= 0)
                {
                    fundsData.Save();
                    await Navigation.PopAsync();
                }
                else enteringPicker.BackgroundColor = Color.Red;
            }
            else
            {
                entrySum.BackgroundColor = Color.Red;
            }
           
        }

        private async void DeletEntering_Clicked(object sender, EventArgs e)
        {
            fundsData.Delete();
            await Navigation.PopAsync();
        }
    }
}