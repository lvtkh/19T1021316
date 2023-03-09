﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using _19T1021316.DomainModels;

namespace _19T1021316.Web
{
    public static class Converter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime? DMYStringToDateTime(string s, string format = "d/M/yyyy")
        {
            try
            {
                return DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }

        public static UserAccount CookieToUserAccount(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserAccount>(value);
        }
    }
}
