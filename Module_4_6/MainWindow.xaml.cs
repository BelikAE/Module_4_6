using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Module_4_6
{
    enum Precipitation
    {
        sunny = 0,
        cloudy = 1,
        rain = 2,
        snow = 3
    }
    class WeatherControl : DependencyObject
    {
        private Precipitation precipitation;

        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public WeatherControl(string windDirection, int windSpeed, Precipitation precipitation, int temperature)
        {
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.precipitation = precipitation;
            this.Temperature = temperature;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int) value;
            if (v >= -50 && v <=50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return null;
            }
        }
    }
}

