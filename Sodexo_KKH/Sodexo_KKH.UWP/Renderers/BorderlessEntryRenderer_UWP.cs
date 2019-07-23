using Sodexo_KKH.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
[assembly: ExportRenderer(typeof(SuaveControls.MaterialForms.BorderlessEntry), typeof(BorderlessEntryRenderer_UWP))]

namespace Sodexo_KKH.UWP.Renderers
{
    public class BorderlessEntryRenderer_UWP : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.FontSize  = 20;
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(0);
            }
        }
    }
}
