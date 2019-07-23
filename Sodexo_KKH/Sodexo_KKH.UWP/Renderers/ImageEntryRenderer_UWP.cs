using Sodexo_KKH.Controls;
using Sodexo_KKH.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer_UWP))]
namespace Sodexo_KKH.UWP.Renderers
{
    public class ImageEntryRenderer_UWP : EntryRenderer
    {
        public ImageEntry _customEntry;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);



            if (Control != null)
            {
                _customEntry = Element as ImageEntry; 
                Control.FontSize = 20;
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                
            }
        }
    }
}
