using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProcessingTestApp.Helpers
{
    public static class ConfigurationHelper
    {
        /// <summary>
        /// ключ API для доступа к сервису новостей https://newsapi.org/
        /// </summary>
        public static string APIKey
        {
            get
            {
                var apiKey = ConfigurationManager.AppSettings["APIKey"];

                if (apiKey == null)
                    throw new ArgumentNullException("apiKey", "Не указан apiKey в конфигурационном файле");

                return apiKey;
            }
        }
    }
}
