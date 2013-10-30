namespace NamesDaysClient.Converters
{
    using System;
    using System.Linq;
    using Windows.UI.Xaml.Data;

    public class IndexToMonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int? index = value as int?;
            index--;
            return index;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int? month = value as int?;
            month++;
            return month++;
        }
    }
}