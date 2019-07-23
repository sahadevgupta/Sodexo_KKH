using Rg.Plugins.Popup.Pages;
using Sodexo_KKH.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sodexo_KKH.PopUpControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingViewPopup : PopupPage
	{
		public LoadingViewPopup ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var a = this.Parent as HomeMasterDetailPage;
            (a.Detail as NavigationPage).CurrentPage.Opacity = 0.5;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var a = this.Parent as HomeMasterDetailPage;
            (a.Detail as NavigationPage).CurrentPage.Opacity = 1;
        }
        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}