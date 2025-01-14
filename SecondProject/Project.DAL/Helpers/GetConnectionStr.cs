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
        public static string GetConnnection()
        {
            ConfigurationManager manager = new ConfigurationManager();
            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "SecondProject"));
            manager.AddJsonFile("appsettings.json");
            string? connection=manager.GetConnectionString("MsSql");
            if(connection==null)
            {
                throw new Exception("Connection not Found");
            }
            return connection;

        }
    }
}
