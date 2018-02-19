using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;


namespace WorkingWithTriggers.Behaviors
{
    public class EmailValidatorBehavior : Behavior<Entry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";


        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var isValid = IsEmailValid(e.NewTextValue);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }

        public static bool IsEmailValid(string email)
        {
            bool isValid = false;
            isValid = Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            return isValid;
        }
    }
}
