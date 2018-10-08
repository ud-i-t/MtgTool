using MTGTool.Model.MovieObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MTGTool.Converter
{
    class CardMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<MovieObjectImage> lista = (values[1] as IEnumerable<MovieObjectImage>).Where(x => x.Visible).ToList();
            var bottom = (lista.Count - 1) * 50;
            return new Thickness(bottom, 0, 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
