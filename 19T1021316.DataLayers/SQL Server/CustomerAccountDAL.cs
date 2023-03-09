using _19T1021316.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021316.DataLayers.SQL_Server
{
    /// <summary>
    /// cài đặt cho tk của khách hàng
    /// </summary>
    public class CustomerAccountDAL : _BaseDAL, IUserAccountDAL
    {
        public CustomerAccountDAL(string connectionString) : base(connectionString)
        {
        }

        public UserAccount Authorize(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
