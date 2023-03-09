using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021316.DomainModels;

namespace _19T1021316.DataLayers
{
    /// <summary>
    /// định nghĩa các phép xử lý dữ liệu liên quan đến tài khoản
    /// </summary>
    public interface IUserAccountDAL
    {
        /// <summary>
        /// kiểm tra thông tin đăng nhập 1 tài khoản, nếu đn thành công, trả về tt của tk, ngược lại, k thành công, trả về null.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);
            /// <summary>
            /// đổi mk của tk
            /// </summary>
            /// <param name="userName"></param>
            /// <param name="oldPassword"></param>
            /// <param name="newPassword"></param>
            /// <returns></returns>
        bool ChangePassword(string userName, string oldPassword, string newPassword);

    }
}
