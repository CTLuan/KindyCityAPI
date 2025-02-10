using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Interfaces
{
    public interface IRedisService
    {
        void Save(string key, string value, TimeSpan ttl);
        string? Get(string key);
        void Delete(string key);
    }
}
