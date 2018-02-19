using Xamarin.Forms;

namespace WorkingWithTriggers.Behaviors
{
    public class NumberValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var isValid = IsNumber(args.NewTextValue);

            ((Entry) sender).TextColor = isValid ? Color.Default : Color.Red;
        }

        public static bool IsNumber(string number)
        {
            int result;
            var isValid = int.TryParse(number, out result);
            return isValid;
        }
    }
}
/*
  The Entry box will allow only the numeric value.
 */