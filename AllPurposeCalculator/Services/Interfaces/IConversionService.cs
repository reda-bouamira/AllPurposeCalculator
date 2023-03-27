using AllPurposeCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPurposeCalculator.Services.Interfaces
{
    public interface IConversionService
    {
        double Convert(double input, int inputUnitId, int outputUnitId, UnitType unitType);
    }
}
