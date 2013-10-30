namespace NamesDaysClient.Converters
{
    using System;
    using System.Globalization;
    using Windows.UI.Xaml.Data;

    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime? date = value as DateTime?;
            
            if (date == null)
            {
                return null;
            }

            CultureInfo bulgarianCulture = new CultureInfo("bg-BG");

            return string.Format(bulgarianCulture, "{0:m}", date);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}