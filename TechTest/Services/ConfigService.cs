using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TechTest.Services.Interfaces;

namespace TechTest.Services
{
    public class ConfigService : IConfigService
    {
        public int GetValueAsInt(string key)
        {
            string val = GetValue(key);
            return int.Parse(val);
        }

        public string GetValueAsString(string key)
        {
            string val = GetValue(key);
            return val;
        }

        private string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}