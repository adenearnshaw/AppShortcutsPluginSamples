using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShortcutsUwpTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnAppLinkRequestReceived(Uri uri)
        {
            var id = uri.ToString().Replace("asc://appshortcutsapp/page/", "");

            if (id == "my_deeplink_page")
                await MainPage.Navigation.PushAsync(new SecondPage());
            else
                base.OnAppLinkRequestReceived(uri);

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
