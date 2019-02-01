using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Data;


namespace Aras
{
    // permessions 

    public enum Permessions
    {
        Public = 0,
        AllUsers = 1,
        OnlyAdmin = 2
    }
    // a significant class to allow or dissallow a user

    internal static class Permit
    {
        public static Permessions currentPermission ;

        static Permit()
        {
            currentPermission = Permessions.Public;
        }
        internal static bool isAllowed( Permessions givenPermission)
        {
           return (currentPermission >= givenPermission);
        }

    }
}