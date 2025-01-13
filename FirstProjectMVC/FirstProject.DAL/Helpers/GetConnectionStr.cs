using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Helpers
{
    public static class GetConnectionStr
    {
        public static string GetConnection()
        {
            ConfigurationManager manager = new ConfigurationManager();
            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "FirstProjectMVC"));
            manager.AddJsonFile("appsettings.json");
            string? getconnection = manager.GetConnectionString("MsSql");
            if(getconnection==null)
            {
                throw new Exception("Doesnt found Connection");
            }
            return getconnection;
        }
    }
}
