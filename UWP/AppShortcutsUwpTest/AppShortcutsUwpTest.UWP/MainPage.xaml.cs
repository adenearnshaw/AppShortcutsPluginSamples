using Plugin.AppShortcuts.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace AppShortcutsUwpTest.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new AppShortcutsUwpTest.App());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            OnLaunchedEvent(e.Parameter.ToString());
        }

        public void OnLaunchedEvent(string arguments)
        {
            if (!string.IsNullOrEmpty(arguments))
            {
                var argsUri = JumplistArgumentsHelper.GetUriFromJumplistArguments(arguments);
                Xamarin.Forms.Application.Current.SendOnAppLinkRequestReceived(argsUri);
            }
        }
    }
}
