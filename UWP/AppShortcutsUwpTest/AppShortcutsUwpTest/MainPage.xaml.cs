using Plugin.AppShortcuts;
using Plugin.AppShortcuts.Icons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppShortcutsUwpTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var oldShortcuts = await CrossAppShortcuts.Current.GetShortcuts();
            foreach (var sc in oldShortcuts)
            {
                await CrossAppShortcuts.Current.RemoveShortcut(sc.ShortcutId);
            }

            var shortcut = new Shortcut()
            {
                Label = "Shortcut 1",
                Description = "My shortcut",
                Icon = new FavoriteIcon(),
                Uri = "asc://AppShortcutsApp/page/my_deeplink_page"
            };

            await CrossAppShortcuts.Current.AddShortcut(shortcut);
        }
    }
}
