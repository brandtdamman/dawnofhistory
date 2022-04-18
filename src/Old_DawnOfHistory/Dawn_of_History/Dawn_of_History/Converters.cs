using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Dawn_of_History
{
    class ShiftedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (Double)value / -2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    ///class PlayerListToName_Converter : IValueConverter
    ///{
    ///    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    ///    {
    ///       List<Player> lst = (List<Player>)value;
    ///        Int32 pNum = System.Convert.ToInt32(parameter);
    ///        return lst[pNum].Name;
    ///    }

    ///    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    ///    {
    ///       throw new NotImplementedException();
    ///    }
    ///}

    ///class PlayerListToVP_Converter : IValueConverter
    ///{
    ///    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    ///    {
    ///        List<Player> lst = (List<Player>)value;
    ///        Int32 pNum = System.Convert.ToInt32(parameter);
    ///        return lst[pNum].VpPoints;
    ///    }
 
    ///    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    ///    {
    ///        throw new NotImplementedException();
    ///    }
    ///}
}
