using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Authentication
{
    public enum AccountTypes
    {
        Manager = 1,
        Driver=2,
        Control=3
    }
}