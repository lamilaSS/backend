using System;
using Microsoft.Extensions.Configuration;


namespace mcq_backend.Helper.AppHelper
{
    public class AppConfig
    {
        private static IConfiguration _currentConfig;
        public static void SetConfig(IConfiguration configuration)
        {
            _currentConfig = configuration;
        }
        public static string GetConnectionString(string key)
        {
            try
            {
                string connectionString = _currentConfig["ConnectionString:" + key];
                return connectionString;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
        }
        public static string GetRedisConnectionString()
        {
            try
            {
                string connectionString = _currentConfig["RedisCacheSettings:ConnectionString"];
                return connectionString;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
        }
    }
}