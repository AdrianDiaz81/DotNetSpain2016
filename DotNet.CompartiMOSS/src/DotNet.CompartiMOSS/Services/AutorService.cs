using System;
using System.Collections.Generic;
using DotNet.CompartiMOSS.Models;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace DotNet.CompartiMOSS.Services
{
    public class AutorService : IAutor
    {
        private IEnumerable<Autor> _collection;

        public AutorService()
        {
            using (var redisClient = new RedisClient("dockerdotnetencamina.westus.cloudapp.azure.com", 6379))
            {
                _collection = redisClient.GetAll<Autor>().OrderBy(x=>x.Name);

            }

        }
        public async Task<IEnumerable<Autor>> GetAllAutor()
        {
            if (!_collection.Any())
            {
                var compartimossService = new CompartiService();
                _collection = await compartimossService.SearchAuthors();
                using (var redisClient = new RedisClient("dockerdotnetencamina.westus.cloudapp.azure.com", 6379))
                {
                    redisClient.StoreAll(_collection);
                }
            }

            return _collection;


        }

        public async Task<Autor> GetAutorByName(string name)
        {
            if (!_collection.Any())
            {
                var compartimossService = new CompartiService();
                _collection = await compartimossService.SearchAuthors();
                using (var redisClient = new RedisClient("dockerdotnetencamina.westus.cloudapp.azure.com", 6379))
                {
                    redisClient.StoreAll(_collection);
                }
            }
            return _collection.Where(x => x.Name.Equals(name)).FirstOrDefault();

        }
    }
}
