using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace idc.version.Libs
{
    public class lDbConn
    {
        public string conString()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("DbContextSettings:ConnectionString").Value.ToString();
        }

        public string conStringLog()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("DbContextSettings:ConnectionString_log").Value.ToString();
        }

        public string conStringEtlData()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("DbContextSettings:ConnectionString_etldata").Value.ToString();
        }

        public string conStringCust()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("DbContextSettings:ConnectionString_cust").Value.ToString();
        }

        public string getAppSettingParam(string group, string api)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var config = builder.Build();
            return "" + config.GetSection(group + ":" + api).Value.ToString();
        }

        public string domainGetApi(string api)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var config = builder.Build();
            return "" + config.GetSection("APISettings:" + api).Value.ToString();
        }

        public string domainGetTokenCredential(string param)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return config.GetSection("TokenAuthentication:" + param).Value.ToString();
        }


        public string domainPostApi()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("DomainSettings:urlPostDomainAPI").Value.ToString();
        }

        public string getFromAddress()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("NotificationSetting:From").Value.ToString();
        }

        public string getTitleFrom()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("NotificationSetting:TitleFrom").Value.ToString();
        }

        public string getTitleTo()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("NotificationSetting:TitleTo").Value.ToString();
        }

        public string getSubjectNotification()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("NotificationSetting:SubjectNotification").Value.ToString();
        }

        public string getSmtpServer()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("NotificationSetting:SmtpServer").Value.ToString();
        }

        public string getSmtpPortNumber()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("NotificationSetting:SmtpPortNumber").Value.ToString();
        }

        public string getAuthenticateUsr()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("NotificationSetting:AuthenticateUsr").Value.ToString();
        }

        public string getAuthenticatePwd()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var config = builder.Build();
            return "" + config.GetSection("NotificationSetting:AuthenticatePwd").Value.ToString();
        }
    }
}
