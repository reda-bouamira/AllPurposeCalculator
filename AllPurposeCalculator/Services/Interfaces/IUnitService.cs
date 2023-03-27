using AllPurposeCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AllPurposeCalculator.Services.Interfaces
{
    public interface IUnitService
    {
        List<Unit> GetUnits();
    }
}
