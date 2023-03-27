using AllPurposeCalculator.Entities;
using AllPurposeCalculator.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPurposeCalculator.Data
{
    internal class UnitService : IUnitService
    {
        public List<Unit> GetUnits()
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\Resources\Units.json"))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Unit>>(json);
            }
        }
    }
}
