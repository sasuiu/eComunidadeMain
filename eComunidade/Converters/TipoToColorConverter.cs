using eComunidade.Models.Enum;
using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace eComunidade.Converters
{
    public class TipoToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TipoOcorrencia tipo)
            {
                switch (tipo)
                {
                    case TipoOcorrencia.NaoSolucionada:
                        return Color.FromArgb("#FF0000"); // Vermelho
                    case TipoOcorrencia.EmSolucao:
                        return Color.FromArgb("#FF8C00"); // Laranja
                    case TipoOcorrencia.Solucionada:
                        return Color.FromArgb("#00FF00"); // Verde
                }
            }
            return Color.FromArgb("#000000"); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}