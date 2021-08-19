using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Settings
{
    public class MongoDbConfig
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}