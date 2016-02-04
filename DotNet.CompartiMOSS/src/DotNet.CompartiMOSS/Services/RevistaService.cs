using System.Collections.Generic;
using System.Linq;
using DotNet.CompartiMOSS.Models;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace DotNet.CompartiMOSS.Services
{
    public class RevistaService : IRevista
    {
        private IEnumerable<Revista> _repository;

        public RevistaService()
        {
            using (var redisClient = new RedisClient("dockerdotnetencamina.westus.cloudapp.azure.com", 6379))
            {
                _repository = redisClient.Get<IEnumerable<Revista>>("revista");
                //_repository = redisClient.GetAll<Revista>();
            }
        }
        public async Task<Revista> GetLastNumber()
        {
            if (_repository == null)
            {
                var compartimossService = new CompartiService();
                _repository = await compartimossService.SearchNumbers();
                using (var redisClient = new RedisClient("dockerdotnetencamina.westus.cloudapp.azure.com", 6379))
                {
                    redisClient.Set<IEnumerable<Revista>>("revista",_repository);
                    //redisClient.StoreAll(_repository);
                }
            }
            return _repository.FirstOrDefault();
        }

        public async  Task<IEnumerable<Revista>> GetRevistas()
        {
            if (_repository==null)
            {
                var compartimossService = new CompartiService();
                _repository = await compartimossService.SearchNumbers();
                using (var redisClient = new RedisClient("dockerdotnetencamina.westus.cloudapp.azure.com", 6379))
                {
                    //   redisClient.StoreAll(_repository);
                    redisClient.Set<IEnumerable<Revista>>("revista", _repository);
                }
            }
            return _repository;
        }

        public async Task<Revista> GetRevistaByTitle(string name)
        {
            if (_repository == null)
            {
                var compartimossService = new CompartiService();
                _repository = await compartimossService.SearchNumbers();
                using (var redisClient = new RedisClient("dockerdotnetencamina.westus.cloudapp.azure.com", 6379))
                {
                    redisClient.Set<IEnumerable<Revista>>("revista", _repository);
                    //redisClient.StoreAll(_repository);
                }
            }
            return _repository.Where(x => x.Numero.Equals(name)).FirstOrDefault();
        }
    }
}
