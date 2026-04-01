using System;
using System.Windows.Data;

namespace Synapse_Download_Manager.Converters
{
    public class ProgressToStrokeDashOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int progress)
            {
                // StrokeDashArray is 100, so at 0% progress offset should be 100 (hidden)
                // At 100% progress offset should be 0 (fully visible)
                return 100 - progress;
            }
            return 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
