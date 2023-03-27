// See https://aka.ms/new-console-template for more information
using AllPurposeCalculator.Helpers;
using AllPurposeCalculator.Enums;
using AllPurposeCalculator.Data;
using AllPurposeCalculator.Services;
using Microsoft.Extensions.DependencyInjection;
using AllPurposeCalculator.Entities;
using AllPurposeCalculator.Services.Interfaces;
using AllPurposeCalculator.Business;

var serviceProvider = GetServiceProvider();  
var unitService = serviceProvider.GetService<IUnitService>();
var conversionService = serviceProvider.GetService<IConversionService>();

var calculator = new Calculator(conversionService, unitService);

var selectedApplication = Helper.GetSelectedOption<Application>("Select the application you want to use:");

switch (selectedApplication)
{
	case ((int)Application.UnitConverter):
        StartUnitConverter();
        break;
    case ((int)Application.CurrencyConverter):
        StartCurrencyConverter();
        break;
    case ((int)Application.LoanCalculator):
        StartLoanCalculator();
        break;
}

void StartUnitConverter()
{
    Console.WriteLine(Application.UnitConverter.GetDescription().GetFormatedHeadline());

    var selectedUnitType = Helper.GetSelectedOption<UnitType>("Select the converter you want to use:");

    GetUnitConversion((UnitType)selectedUnitType);

    Console.WriteLine("Thank you for using our little application!");

}

void StartCurrencyConverter()
{
    Console.WriteLine("We are still working on building the Currency Converter");
}

void StartLoanCalculator()
{
    Console.WriteLine("We are still working on building the Loan Calculator");
}

ServiceProvider GetServiceProvider()
{
    var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IUnitService, UnitService>()
            .AddSingleton<IConversionService, ConversionService>()
            .BuildServiceProvider();

    return serviceProvider;
}

void GetUnitConversion(UnitType unitType)
{
    Console.WriteLine(unitType.GetDescription().GetFormatedHeadline());

    var units = calculator.GetUnits().Where(x => x.UnitType == unitType.ToString()).ToList();

    double inputValue = Helper.Getinput<double>($"Enter the value you want to convert:");

    var unitsIdText = units.Select(x => new IdText
    {
        Id = x.Id,
        Text = x.Name
    }).ToList();

    var inputUnitId = Helper.GetSelectedOption("Select the unit of your current value:", unitsIdText);
    var outputUnitId = Helper.GetSelectedOption("Select the unit you want to convert to:", unitsIdText);

    var result = calculator.Convert(inputValue, inputUnitId, outputUnitId, unitType);

    Console.WriteLine($"Results: {Math.Round(result, 2)}{units.Where(x => x.Id == (int)outputUnitId).Select(x => x.ShortName).FirstOrDefault()}");
}