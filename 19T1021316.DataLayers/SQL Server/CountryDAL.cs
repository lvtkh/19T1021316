using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using _19T1021316.DomainModels;

namespace _19T1021316.DataLayers.SQL_Server
{
    public class CountryDAL : _BaseDAL, ICountryDAL
    {
        /// <summary>
        /// ctor 
        /// </summary>
        /// <param name="connectionString"></param>
        public CountryDAL(string connectionString) : base(connectionString)
        {
        }

        public IList<Country> List()
        {
            List<Country> data = new List<Country>();
            using (SqlConnection connection = OpenConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT CountryName FROM Countries";
                cmd.CommandType = CommandType.Text;

                SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dbReader.Read())
                {
                    data.Add(new Country()
                    {
                        CountryName = Convert.ToString(dbReader["CountryName"])
                    });
                }
                dbReader.Close();

                //EntityFramework
                //Dapper

                connection.Close();
            }
            return data;
        }
    }
}
