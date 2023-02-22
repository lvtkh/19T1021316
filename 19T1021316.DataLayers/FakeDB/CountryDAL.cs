using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021316.DomainModels;

namespace _19T1021316.DataLayers.FakeDB
{
    public class CountryDAL : ICountryDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Country> List()
        {
            List<Country> data = new List<Country>();
            data.Add(new Country() { CountryName = "Việt Nam" });
            data.Add(new Country() { CountryName = "Trung Quốc" });
            data.Add(new Country() { CountryName = "Thái Lan" });

            return data;
        }
    }
}
