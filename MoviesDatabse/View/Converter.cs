using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using MoviesDatabase.Model;

namespace MoviesDatabase.View
{
    [ValueConversion(typeof(Actor), typeof(string))]
    internal class Converter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Actor actor ? String.Format("{0} {1}", actor.FirstName, actor.LastName) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
