using System.Globalization;

namespace StudySync.Converters
{
    public class BoolToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool isEditing)
                return "Add";

            var parameters = parameter as string; // "Save,Add"
            if (parameters == null)
                return isEditing ? "Save" : "Add";

            var parts = parameters.Split(',');
            return isEditing ? parts[0] : parts[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}