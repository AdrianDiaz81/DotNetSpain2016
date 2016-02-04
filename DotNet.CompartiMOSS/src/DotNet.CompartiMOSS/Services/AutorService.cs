using System;
using System.Collections.Generic;
using DotNet.CompartiMOSS.Models;
using System.Linq;

namespace DotNet.CompartiMOSS.Services
{
    public class AutorService : IAutor
    {
        private IEnumerable<Autor> _collection;

        public AutorService()
        {
            _collection = new Autor[]{
                new Autor { Name = "Adrián Díaz", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/ADRIANDIAZ.PNG?RENDITIONID=6&width=228&height=300", Twitter="AdrianDiaz81", Blog="http://blogs.encamina.com/desarrollandosobresharepoint", JobTittle="MVP Office and Servers", Description="​Adrián Díaz es Ingeniero de Informática por la Universidad Politécnica de Valencia, MCPD de SharePoint 2010, MAP y MCC 2012. Cofundador del grupo de usuarios de SharePoint de Levante LevaPoint. Lleva desarrollando con tecnologías Microsoft más de 10 años y desde hace 3 años está centrado en el desarrollo sobre SharePoint. Actualmente trabaja en el departamento de desarrollo de ENCAMINA una consultora informática de Valencia que se destaca por realizar soluciones basadas en Tecnología Microsoft, principalmente en SharePoint", NameBlog="Desarrollando sobre SharePoint" },
                new Autor { Name = "Alberto Díaz", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/ALBERTODIAZMARTIN.PNG?RENDITIONID=6&width=228&height=300" },
                new Autor { Name = "Alberto Escola", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/ALBERTOESCOLA.JPG?RENDITIONID=6&width=228&height=300" },
                new Autor { Name = "Alberto Pascual", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/ALBERTOPASCUAL.JPG?RENDITIONID=6&width=228&height=300" },
                new Autor { Name = "Alejandro Garrido", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/ALEJANDROGARRIDO.JPG?RENDITIONID=6&width=228&height=300" },
                new Autor { Name = "Andres Ortiz", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/ANDRESORTIZ.JPG?RENDITIONID=6&width=228&height=300" },
                new Autor { Name = "Christian Buckley", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/BUCKLEY.JPG?RENDITIONID=6&width=228&height=300" },
                new Autor { Name = "Cristina Quesada", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/CRISTINAQUESADA.JPG?RENDITIONID=6&width=228&height=300" },
                new Autor { Name = "Daniel Seara", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/DANIELSEARA.PNG?RENDITIONID=6&width=228&height=300" },
                new Autor { Name = "David Sanchez Agular", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/DAVIDSANCHEZ.JPG?RENDITIONID=6&width=228&height=300" },
                new Autor { Name = "Diego Gampo", Image = "http://compartimoss.com/PUBLISHINGIMAGES/AUTORES/DIEGO_CAMPO.JPG?RENDITIONID=6&width=228&height=300" }
            };
        }
        public IEnumerable<Autor> GetAllAutor()
        {
            
            return _collection;
            
        }

        public Autor GetAutorByName(string name)
        {
            return _collection.Where(x => x.Name.Equals(name)).FirstOrDefault();
        }
    }
}
