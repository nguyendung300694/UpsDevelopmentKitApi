using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpsApi
{
    public static class AppSettings
    {
        public static class UpsConfiguration
        {
            public const string RateRequestUrlUps = "https://onlinetools.ups.com/ship/v1/rating/Rate";
            public const string ShopRequestUrlUps = "https://onlinetools.ups.com/ship/v1/rating/Shop";
            public const string AccessLicenseNumberUps = "9D7BE954A85D0935";
            public const string UserNameUps = "i3dvrshipping";
            public const string PasswordUps = "i3DVR9991";
            public const string AccountNumber = "132R1V";

            public class UpsRatingType
            {
                public const string Rate = "Rate";
                public const string Shop = "Shop";
            }
        }
    }
}