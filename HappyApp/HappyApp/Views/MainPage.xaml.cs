using HappyApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HappyApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
    {
        private Random rnd = new Random();
        public MainPage ()
		{
			InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item == null)
                return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Detail = new NavigationPage(page);

            Detail = GetNavigationPage(item);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        private NavigationPage GetNavigationPage(MasterPageItem item)
        {
            Page page = null;
            switch (item.Id)
            {
                case 0:
                    page = new AboutPage();
                    break;
                case 1:
                    page = new ItemsPage();
                    break;
                default:
                    page = new NewItemPage();
                    break;
            }
            page.Title = item.Title;

            Color randomColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            return new NavigationPage(page)
            {
                BarBackgroundColor = randomColor
            };
        }
    }
}