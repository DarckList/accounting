using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using accounting.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace accounting
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
            NavigationPage navigationPage = new NavigationPage(new MainPage());
            
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
