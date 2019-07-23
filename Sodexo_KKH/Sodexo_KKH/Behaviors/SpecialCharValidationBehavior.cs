﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Sodexo_KKH.Behaviors
{
    public class SpecialCharValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
            //bindable.Unfocused += Bindable_Unfocused;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
            //bindable.Unfocused -= Bindable_Unfocused;
        }
        void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((Entry)sender == null)
                return;

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = string.Empty;
                return;
            }

            if (GetCount(e.NewTextValue, '.') > 1)
            {
                ((Entry)sender).Text = e.OldTextValue;
                return;
            }
            if (e.NewTextValue.StartsWith("-") && e.NewTextValue.Length == 1)
            {
                return;
            }
            if (e.NewTextValue.EndsWith("."))
            {
                return;
            }
            string Reg = $"[!@#$%^&*(),.?\":|<>]";
            bool isValid = Regex.IsMatch(e.NewTextValue,Reg);
            
            if (isValid)
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
            else
            {
                ((Entry)sender).Text = e.NewTextValue;
            }
        }

        int GetCount(string source, char ch)
        {
            int count = 0;
            foreach (char c in source)
                if (c == ch) count++;

            return count;
        }
    }
}
