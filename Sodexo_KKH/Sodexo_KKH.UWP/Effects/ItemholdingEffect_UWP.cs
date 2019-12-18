using Sodexo_KKH.Effects;
using Sodexo_KKH.UWP.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using GestureRecognizer = Windows.UI.Input.GestureRecognizer;

[assembly: ResolutionGroupName(ItemholdingEffect.EffectGroupName)]
[assembly: ExportEffect(typeof(ItemholdingEffect_UWP), ItemholdingEffect.EffectName)]
namespace Sodexo_KKH.UWP.Effects
{
    public class ItemholdingEffect_UWP : PlatformEffect
    {

        private FrameworkElement _nativeView;
        private ItemholdingEffect _itemholdingEffect;


        public ItemholdingEffect_UWP()
        {
        }

        protected override void OnAttached()
        {
            _itemholdingEffect = Element.Effects.OfType<ItemholdingEffect>().FirstOrDefault();
            _nativeView = Container;

            _nativeView.PointerReleased += _nativeView_PointerReleased;
        }

        private void _nativeView_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {

            var block = (e.OriginalSource as TextBlock);
            if (block != null)
            {
                var patientInfo = (block.DataContext as ViewCell).BindingContext;
                _itemholdingEffect?.ControlLongPressed(patientInfo);
            }
        }

       

        protected override void OnDetached()
        {
            _nativeView.PointerReleased -= _nativeView_PointerReleased;
        }

        
    }
}
