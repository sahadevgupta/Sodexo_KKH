using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sodexo_KKH.Droid;
using Sodexo_KKH.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(HomeMasterDetailPage), typeof(IconNavigationPageRenderer))]
namespace Sodexo_KKH.Droid
{
    public class IconNavigationPageRenderer : PageRenderer
    {
        private static Android.Support.V7.Widget.Toolbar GetToolbar() => (MainApplication.ActivityContext as MainActivity)?.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var toolbar = GetToolbar();
            if (toolbar != null)
            {
                for (var i = 0; i < toolbar.ChildCount; i++)
                {
                    var imageButton = toolbar.GetChildAt(i) as Android.Widget.ImageButton;

                    //var drawerArrow = imageButton?.Drawable as DrawerArrowDrawable;
                    //if (drawerArrow == null)
                    //    continue;

                    //imageButton.SetImageDrawable(Forms.Context.GetDrawable(Resource.Drawable.newIcon));
                }
            }
        }
    }
}