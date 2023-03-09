﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021316.DomainModels
{
    public class UserAccount
    {
        /// <summary>
        /// tài khoản người dùng
        /// </summary>
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleNames { get; set; }
        public string Photo { get; set; }

    }
}
