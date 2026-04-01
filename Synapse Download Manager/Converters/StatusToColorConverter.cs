using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Synapse_Download_Manager.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string status)
            {
                switch (status)
                {
                    case "Downloading":
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1A73E8"));
                    case "Completed":
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#34A853"));
                    case "Paused":
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FBBC04"));
                    default:
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5F6368"));
                }
            }
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5F6368"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
