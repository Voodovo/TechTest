using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechTest.Services.Interfaces
{
    public interface IConfigService
    {
        string GetValueAsString(string key);
        int GetValueAsInt(string key);
    }
}