using System;
using System.Windows.Input;
using AppShortcutsMasterDetailTest.Models;
using Plugin.AppShortcuts;
using Plugin.AppShortcuts.Icons;
using Xamarin.Forms;

namespace AppShortcutsMasterDetailTest.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ICommand AddShortcutCommand { get; set; }
        
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
            AddShortcutCommand = new Command(AddShortcut);
        }

        private async void AddShortcut()
        {
            var sc = new Shortcut
            {
                Label = Item.Text,
                Description = Item.Text,
                Icon = new FavoriteIcon(),
                Uri = $"stc://masterdetailtest/items/{Item.Id}"
            };
            await CrossAppShortcuts.Current.AddShortcut(sc);
        }
    }
}
