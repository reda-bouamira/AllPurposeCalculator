using AllPurposeCalculator.Enums;
using AllPurposeCalculator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPurposeCalculator.Services
{
    public class ConversionService : IConversionService
    {
        public double Convert(double input, int inputUnitId, int outputUnitId, UnitType unitType)
        {
            switch (unitType)
            {
                case UnitType.Length:
                    return ConvertLength(input, inputUnitId, outputUnitId);
                case UnitType.Mass:
                    return ConvertMass(input, inputUnitId, outputUnitId);
                case UnitType.Temperature:
                    return ConvertTemperature(input, inputUnitId, outputUnitId);
            }

            return 0;
        }

        private double ConvertLength(double input, int inputUnitId, int outputUnitId)
        {
            var conversion = new UnitOf.Length();

            switch ((LengthUnit)inputUnitId)
            {
                case LengthUnit.Meters:
                    conversion.FromMeters(input);
                    break;
                case LengthUnit.Centimeters:
                    conversion.FromCentimeters(input);
                    break;
                case LengthUnit.Miles:
                    conversion.FromMiles(input);
                    break;
                case LengthUnit.Feet:
                    conversion.FromFeet(input);
                    break;
                case LengthUnit.Inches:
                    conversion.FromInches(input);
                    break;
            }

            switch ((LengthUnit)outputUnitId)
            {
                case LengthUnit.Meters:
                    return conversion.ToMeters();
                case LengthUnit.Centimeters:
                    return conversion.ToCentimeters();
                case LengthUnit.Miles:
                    return conversion.ToMiles();
                case LengthUnit.Feet:
                    return conversion.ToFeet();
                case LengthUnit.Inches:
                    return conversion.ToInches();
            }

            return 0;
        }

        private double ConvertMass(double input, int inputUnitId, int outputUnitId)
        {
            var conversion = new UnitOf.Mass();

            switch ((MassUnit)inputUnitId)
            {
                case MassUnit.Kilograms:
                    conversion.FromKilograms(input);
                    break;
                case MassUnit.Pounds:
                    conversion.FromPounds(input);
                    break;
                case MassUnit.Grams:
                    conversion.FromGrams(input);
                    break;
                case MassUnit.Ounces:
                    conversion.FromOuncesUS(input);
                    break;
            }

            switch ((MassUnit)outputUnitId)
            {
                case MassUnit.Kilograms:
                    return conversion.ToKilograms();
                case MassUnit.Pounds:
                    return conversion.ToPounds();
                case MassUnit.Grams:
                    return conversion.ToGrams();
                case MassUnit.Ounces:
                    return conversion.ToOuncesUS();
            }

            return 0;
        }

        private double ConvertTemperature(double input, int inputUnitId, int outputUnitId)
        {
            var conversion = new UnitOf.Temperature();

            switch ((TemperatureUnit)inputUnitId)
            {
                case TemperatureUnit.Celcius:
                    conversion.FromCelsius(input);
                    break;
                case TemperatureUnit.Fahrenheit:
                    conversion.FromFahrenheit(input);
                    break;
                case TemperatureUnit.Kelvin:
                    conversion.FromKelvin(input);
                    break;
            }

            switch ((TemperatureUnit)outputUnitId)
            {
                case TemperatureUnit.Celcius:
                    return conversion.ToCelsius();
                case TemperatureUnit.Fahrenheit:
                    return conversion.ToFahrenheit();
                case TemperatureUnit.Kelvin:
                    return conversion.ToKelvin();
            }

            return 0;
        }
    }
}
