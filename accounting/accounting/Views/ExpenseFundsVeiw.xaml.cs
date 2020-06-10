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
	public partial class ExpenseFundsVeiw : ContentPage
	{
        public static double calculateSum = 0;
        ExpenseFundsVeiwModel expenseData;
        public ExpenseFundsVeiw ()
		{
            InitializeComponent();
            expenseData = new ExpenseFundsVeiwModel();
            fundsVeiwStack.BindingContext = expenseData;
        }

        public ExpenseFundsVeiw(int id)
        {
            InitializeComponent();
            expenseData = new ExpenseFundsVeiwModel(id);
            fundsVeiwStack.BindingContext = expenseData;
        }


        protected override void OnAppearing()
        {   if(calculateSum!=0) entrySum.Text = calculateSum.ToString();
            base.OnAppearing();
        }

        private async void Calculator_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SimpleCalculatorView(false));
        }

        private async void SaveExpenseFunds_Clicked(object sender, EventArgs e)
        {
            if (entrySum.Text!="")
            {
                if (expensePicker.SelectedIndex>= 0)
                {
                    MessagingCenter.Send<Page>(this, "Change");
                    expenseData.Save();
                    await Navigation.PopAsync();
                }
                else expensePicker.BackgroundColor = Color.Red;
            }
            else
            {
                entrySum.BackgroundColor = Color.Red;
            }
        }

        private async void DeletExpenseFunds_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<Page>(this,"Change");
            expenseData.Delete();
            await Navigation.PopAsync();
            

        }
    }
}