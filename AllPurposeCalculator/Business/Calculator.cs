using AllPurposeCalculator.Entities;
using AllPurposeCalculator.Enums;
using AllPurposeCalculator.Helpers;
using AllPurposeCalculator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOf;

namespace AllPurposeCalculator.Business
{
    public class Calculator
    {
        private readonly IConversionService conversionService;
        private readonly IUnitService unitService;

        public Calculator(IConversionService conversionService, IUnitService unitService)
        {
            this.conversionService = conversionService;
            this.unitService = unitService;
        }

        public double Convert(double input, int inputUnitId, int outputUnitId, UnitType unitType)
        {
            return this.conversionService.Convert(input, inputUnitId, outputUnitId, unitType);
        }

        public List<Unit> GetUnits()
        {
            var unitTypeNames = Helper.GetEnumNames<UnitType>();

            return this.unitService.GetUnits().Where(x => unitTypeNames.Contains(x.UnitType)).ToList();
        }
    }
}
