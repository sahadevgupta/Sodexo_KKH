using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sodexo_KKH.Controls
{
    public class ExtendedEntry: Entry
    {
        public ExtendedEntry()
        {
            this.FontFamily = Device.RuntimePlatform == Device.UWP ? "Assets/Fonts/Sansation-Regular.ttf#Sansation" : "Sansation-Regular.ttf#Sansation-Regular";
        }
    }
}
