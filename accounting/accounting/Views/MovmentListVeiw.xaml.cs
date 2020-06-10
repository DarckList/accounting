using accounting.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using accounting.Services;

namespace accounting.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovmentListVeiw : ContentPage
	{
        MovmentListVeiwModel movmentListVeiwModel = new MovmentListVeiwModel();
		public MovmentListVeiw()
		{
			InitializeComponent ();
            movmentList.BindingContext = movmentListVeiwModel;
           
            Subscribe();
        }

        private async void MovmentList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedListItem = (MovmentListColection)e.SelectedItem;
            if (selectedListItem.TypeTransaction == "Зарплата" || selectedListItem.TypeTransaction == "Премія" ||
                selectedListItem.TypeTransaction == "Подарок" || selectedListItem.TypeTransaction == "Виграш")
            {
                await Navigation.PushAsync(new EnteringFundsVeiw(selectedListItem.Id));
            }
            else await Navigation.PushAsync(new ExpenseFundsVeiw(selectedListItem.Id));
        }


        private void Subscribe()
        {
            MessagingCenter.Subscribe<Page>(
                this, // кто подписывается на сообщения
                "Change",   // название сообщения
                (sender) => {
                    this.movmentListVeiwModel= new MovmentListVeiwModel();
                    movmentList.DescendantRemoved += (object send, ElementEventArgs e) =>
                    {

                    };
                    this.movmentList.BeginRefresh();
                    this.movmentList.EndRefresh();
                });    // вызываемое действие

        }
    }
}