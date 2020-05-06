using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppShortcutsMasterDetailTest.Services;
using AppShortcutsMasterDetailTest.Views;
using AppShortcutsMasterDetailTest.Models;
using AppShortcutsMasterDetailTest.ViewModels;

namespace AppShortcutsMasterDetailTest
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override async void OnAppLinkRequestReceived(Uri uri)
        {
            var itemId = uri.ToString().Replace("stc://masterdetailtest/items/", "");

            if (!string.IsNullOrEmpty(itemId))
            {
                var item = await DependencyService.Get<IDataStore<Item>>().GetItemAsync(itemId);
                await (MainPage as MasterDetailPage)?.Detail.Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            }
            else
            {
                base.OnAppLinkRequestReceived(uri);
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
