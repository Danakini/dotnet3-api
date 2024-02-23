using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace idc.version.Controllers
{
    public class MessageController
    {
        public string GetMessage(string code) {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("message.json");

            var config = builder.Build();
            return config.GetSection(code).Value.ToString();
        }
    }
}
