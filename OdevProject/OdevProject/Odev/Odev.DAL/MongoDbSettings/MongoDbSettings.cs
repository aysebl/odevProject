using System;
using System.Collections.Generic;
using System.Text;

namespace Odev.DAL.MongoDbSettings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        //    public string Host { get; set; }
        //    public int Port { get; set; }
        //    public string UserName { get; set; }
        //    public string Password { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
