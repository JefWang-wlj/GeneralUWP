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
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace General_UWP_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            EnableBackButtonOnTitleBar((sender, args) =>
            {
                //this.rootFrame.Navigate(typeof(Views.About));
                // Get a hold of the current frame so that we can inspect the app back stack.

                if (this.rootFrame == null)
                    return;

                // Check to see if this is the top-most page on the app back stack.
                if (this.rootFrame.CanGoBack)// && !handled)
                {
                    // If not, set the event to handled and go back to the previous page in the app.
                    //handled = true;
                    this.rootFrame.GoBack();
                }

            });


        }

        void EnableBackButtonOnTitleBar(EventHandler<BackRequestedEventArgs> onBackRequested)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += onBackRequested;
        }


        private void HomeNavigationStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.rootFrame.Navigate(typeof(Views.Home));
            this.TitleTextBlock.Text = "Home";
        }

        private void AboutNavigationStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.rootFrame.Navigate(typeof(Views.About));
            this.TitleTextBlock.Text = "About";
        }

    }
}
