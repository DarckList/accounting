using System;
using System.Collections.Generic;
using Xamarin.Forms;
using accounting.Services;
using accounting.Views;

namespace accounting
{
    public partial class MainPage : MasterDetailPage
	{
        public List<MasterPageItem> menuList { get; set; }

		public MainPage ()
		{
			InitializeComponent ();
            menuList = new List<MasterPageItem>();
            var page1 = new MasterPageItem() { Title = "Домашня сторінка", Icone = ImageSource.FromResource( "accounting.Images.main.png"), TargetPye = typeof(HomeVeiw) };
            var page3 = new MasterPageItem() { Title = "Звіт" , Icone= ImageSource.FromResource("accounting.Images.piChart.png"), TargetPye = typeof(ReportsVeiw) };
            var page2 = new MasterPageItem() { Title = "Список дій", Icone = ImageSource.FromResource("accounting.Images.reports.png"), TargetPye = typeof(MovmentListVeiw) };
            var page4 = new MasterPageItem() { Title = "Список позик", Icone = ImageSource.FromResource("accounting.Images.reports.png"), TargetPye = typeof(ListLoanVeiw) };
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            NavigationDrawerList.ItemsSource = menuList;



            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomeVeiw)));
            

            HederStack.BindingContext = new
            {
                Image = ImageSource.FromResource("accounting.Images.mainPage.jpg"),
            };
		}


        private void NavigationDrawerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetPye;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false; 
        }
    }
}