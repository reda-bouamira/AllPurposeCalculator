using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPurposeCalculator.Enums
{
    public enum Application
    {
        [Description("Unit Converter")]
        UnitConverter = 1,
        [Description("Currency Converter")]
        CurrencyConverter = 2,
        [Description("Loan Calculator")]
        LoanCalculator = 3
    }

    public enum UnitType
    {
        [Description("Length")]
        Length = 1,
        [Description("Mass")]
        Mass = 2,
        [Description("Temperature")]
        Temperature = 3
    }

    public enum LengthUnit
    {
        [Description("Meters")]
        Meters = 1,
        [Description("Centimeters")]
        Centimeters = 2,
        [Description("Miles")]
        Miles = 3,
        [Description("Feet")]
        Feet = 4,
        [Description("Inches")]
        Inches = 5,
    }

    public enum MassUnit
    {
        [Description("Kilograms")]
        Kilograms = 1,
        [Description("Pounds")]
        Pounds = 2,
        [Description("Grams")]
        Grams = 3,
        [Description("Ounces")]
        Ounces = 4
    }

    public enum TemperatureUnit
    {
        [Description("Celcius")]
        Celcius = 1,
        [Description("Fahrentheit")]
        Fahrenheit = 2,
        [Description("Kelvin")]
        Kelvin = 3
    }


}
