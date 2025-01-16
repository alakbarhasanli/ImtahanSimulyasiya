using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Helpers
{
    public static class GetConnectionStr
    {
        public static string GetConnection()
        {
            ConfigurationManager manager = new ConfigurationManager();
            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "FourthProject"));
            manager.AddJsonFile("appsettings.json");
            string? url=manager.GetConnectionString("MsSql");
            if(url==null)
            {
                throw new Exception("Url not found");
            }
            return url;

        }
    }
}
