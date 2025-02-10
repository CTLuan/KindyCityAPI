using KindyCity.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Services
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly string _instanceName;

        public RedisService(IConnectionMultiplexer redis, IConfiguration configuration)
        {
            _redis = redis;
            _instanceName = configuration.GetSection("Redis:InstanceName").Value ?? "";
        }

        private IDatabase Database => _redis.GetDatabase();

        public void Save(string key, string value, TimeSpan ttl)
        {
            var fullKey = $"{_instanceName}{key}";
            Database.StringSet(fullKey, value, ttl);
        }

        public string? Get(string key)
        {
            var fullKey = $"{_instanceName}otp:{key}";
            var value = Database.StringGet(fullKey);
            return value.HasValue ? value.ToString() : null;
        }

        public void Delete(string key)
        {
            var fullKey = $"{_instanceName}{key}";
            Database.KeyDelete(fullKey);
        }
    }
}
