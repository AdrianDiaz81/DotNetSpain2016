using System.Collections.Generic;
using System.Linq;
using DotNet.CompartiMOSS.Models;

namespace DotNet.CompartiMOSS.Services
{
    public class RevistaService : IRevista
    {
        private IEnumerable<Revista> _repository;

        public RevistaService()
        {
            _repository = new Revista[]
            {
                new Revista
                {
                    Id=1,
                    Titulo="Número 26 - Diciembre 2016",
                    UrlPortada= "http://compartimoss.com/PublishingImages/CompartiMOSS_26.jpg?RenditionID=5",
                    Editorial="Hola"
                    
                },
                new Revista
                {
                    Id=1,
                    Titulo="Número 25 - Septiempre 2016",
                    UrlPortada= "http://compartimoss.com/PublishingImages/CompartiMOSS_25.jpg?RenditionID=5"
                },
                new Revista
                {
                    Id=1,
                    Titulo="Número 24 - Junio 2016",
                    UrlPortada= "http://compartimoss.com/PublishingImages/NUMERO24.jpg?RenditionID=5"
                },
                new Revista
                {
                    Id=1,
                    Titulo="Número 23 - Marzo 2016",
                    UrlPortada= "http://compartimoss.com/PublishingImages/CompartiMOSS_23.jpg?RenditionID=5"
                },
                new Revista
                {
                    Id=1,
                    Titulo="Número 22 - Diciembre 2014",
                    UrlPortada= "http://compartimoss.com/PublishingImages/CompartiMOSS_22.png?RenditionID=5"
                },
                new Revista
                {
                    Id=1,
                    Titulo="Número 21",
                    UrlPortada= "http://compartimoss.com/PublishingImages/CompartiMOSS_21.jpg?RenditionID=5"
                },new Revista
                {
                    Id=1,
                    Titulo="Número 20",
                    UrlPortada= "http://compartimoss.com/PublishingImages/CompartiMOSS_20.jpg?RenditionID=5"
                },
                new Revista
                {
                    Id=1,
                    Titulo="Número 19",
                    UrlPortada= "http://compartimoss.com/PublishingImages/CompartiMOSS_19.jpg?RenditionID=5"
                }
            };
        }
        public Revista GetLastNumber()
        {
            return _repository.FirstOrDefault();
        }

        public IEnumerable<Revista> GetRevistas()
        {
            return _repository;
        }

        public Revista GetRevistaByTitle(string name)
        {
            return _repository.Where(x => x.Titulo.Equals(name)).FirstOrDefault();
        }
    }
}
