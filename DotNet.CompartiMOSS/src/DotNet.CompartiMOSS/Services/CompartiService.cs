using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet.CompartiMOSS.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace DotNet.CompartiMOSS.Services
{
    public class CompartiService : ICompartiService
    {
        private const string url = "http://www.compartimoss.com/_api/search/query?querytext=##query##&QueryTemplatePropertiesUrl='spfile://webroot/queryparametertemplate.xml'&clienttype='Custom'";
        public async Task<List<Revista>> SearchNumbers()
        {
            try
            {
                var queryUrl = url.Replace("##query##", "'ContentTypeId:0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF3900242457EFB8B24247815D688C526CD44D007EC555B0C95F3146BBBC6A377D640C82*'");
                queryUrl += "&selectproperties='PublishingImage,Path,Url,Title,PublishingPageContentOWSHTML,MagazineNumber'&sortlist='NumberPublishDateOWSDATE:descending'&rowlimit=40";

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                string response = await httpClient.GetStringAsync(queryUrl);

                JObject body = JObject.Parse(response);
                var results = body["d"]["query"]["PrimaryQueryResult"]["RelevantResults"]["Table"]["Rows"]["results"];

                var numeros = new List<Revista>();
                foreach (var result in results)
                {
                    var magazine = new Revista
                    {
                        Titulo = result["Cells"]["results"][5]["Value"].ToString().Replace("CompartiMOSS\r\n            \r\n            \r\n            ", ""),
                        Editorial = result["Cells"]["results"][6]["Value"].ToString(),
                        UrlPDF = result["Cells"]["results"][4]["Value"].ToString(),
                        Numero = result["Cells"]["results"][7]["Value"].ToString(),
                        UrlPortada = result["Cells"]["results"][2]["Value"].ToString()
                    };

                    var regex = Regex.Match(magazine.UrlPortada, "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase);
                    if (regex.Success)
                        magazine.UrlPortada = "http://www.compartimoss.com" + regex.Groups[1].Value;

                    numeros.Add(magazine);
                }

                return numeros;
            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error en la carga de los números");
            }
        }

        public async Task<List<Autor>> SearchAuthors()
        {
            try
            {
                var queryUrl = url.Replace("##query##", "'ContentTypeId:0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF3900242457EFB8B24247815D688C526CD44D005BA4DEB48BBA154A8FFCC9390BF5C469*'");
                queryUrl += "&selectproperties='PublishingImage,Path,Url,Title,PublishingPageContentOWSHTML,TwitterOWSTEXT,BlogOWSLINK,JobTitle1OWSTEXT,ArticleAuthor'&sortlist='Title:ascending'&rowlimit=80";

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                var response = await httpClient.GetStringAsync(queryUrl);

                JObject body = JObject.Parse(response);
                var results = body["d"]["query"]["PrimaryQueryResult"]["RelevantResults"]["Table"]["Rows"]["results"];

                var authors = new List<Autor>();
                foreach (var result in results)
                {
                    var author = new Autor()
                    {
                        Name = result["Cells"]["results"][5]["Value"].ToString().Replace("CompartiMOSS\r\n            \r\n            \r\n            ", ""),
                        Description = result["Cells"]["results"][6]["Value"].ToString(),
                        Twitter = result["Cells"]["results"][7]["Value"].ToString(),
                        NameBlog = result["Cells"]["results"][8]["Value"].ToString(),
                        JobTittle = result["Cells"]["results"][9]["Value"].ToString(),
                        Blog = result["Cells"]["results"][4]["Value"].ToString(),
                        Image = result["Cells"]["results"][2]["Value"].ToString()
                    };
                    var regex = Regex.Match(author.Image, "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase);
                    if (regex.Success)
                        author.Image = "http://www.compartimoss.com" + regex.Groups[1].Value;

                    var regexBlog = Regex.Match(author.Blog, "<a.+?href=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase);
                    if (regexBlog.Success)
                        author.Blog = regexBlog.Groups[1].Value.Replace("&#58;", ":");

                    if (!string.IsNullOrEmpty(author.Twitter))
                        author.Twitter = author.Twitter.Replace("@", "http://twitter.com/");

                    authors.Add(author);
                }

                return authors;
            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error en la carga de los autores");
            }
        }


        public async Task<List<Articulos>> SearchArticles(string number)
        {
            try
            {
                var queryUrl = url.Replace("##query##", "'ContentTypeId:0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF3900242457EFB8B24247815D688C526CD44D00F13378E475791F478B08D72D8E52EDCE* MagazineNumber:"+number +"'");
                queryUrl += "&selectproperties='PublishingImage,Path,Url,Title,PublishingPageContentOWSHTML,MagazineNumber'&sortlist='NumberPublishDateOWSDATE:descending'&rowlimit=40";

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                string response = await httpClient.GetStringAsync(queryUrl);

                JObject body = JObject.Parse(response);
                var results = body["d"]["query"]["PrimaryQueryResult"]["RelevantResults"]["Table"]["Rows"]["results"];

                var articulos = new List<Articulos>();
                foreach (var result in results)
                {
                    var article = new Articulos()
                    {
                        Titulo = result["Cells"]["results"][5]["Value"].ToString().Replace("CompartiMOSS\r\n            \r\n            \r\n            ", ""),
                        Texto = result["Cells"]["results"][6]["Value"].ToString(),
                        LinkUrl = result["Cells"]["results"][4]["Value"].ToString(),
                        NumeroRevista = result["Cells"]["results"][7]["Value"].ToString(),
                        Autor = result["Cells"]["results"][2]["Value"].ToString()
                    };

                    articulos.Add(article);
                }

                return articulos;

            }
            catch (Exception)
            {
                throw new Exception("Se ha producido un error en la carga de los artículos");
            }

        }

        public async Task<List<Articulos>> SearchArticlesByAutor(string autor)
        {
            try
            {
                var queryUrl = url.Replace("##query##", "'ContentTypeId:0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF3900242457EFB8B24247815D688C526CD44D00F13378E475791F478B08D72D8E52EDCE* Autor:" +  autor + "'");
                queryUrl += "&selectproperties='PublishingImage,Path,Url,Title,PublishingPageContentOWSHTML,MagazineNumber'&sortlist='NumberPublishDateOWSDATE:descending'&rowlimit=40";

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                string response = await httpClient.GetStringAsync(queryUrl);

                JObject body = JObject.Parse(response);
                var results = body["d"]["query"]["PrimaryQueryResult"]["RelevantResults"]["Table"]["Rows"]["results"];

                var articulos = new List<Articulos>();
                foreach (var result in results)
                {
                    var article = new Articulos()
                    {
                        Titulo = result["Cells"]["results"][5]["Value"].ToString().Replace("CompartiMOSS\r\n            \r\n            \r\n            ", ""),
                        Texto = result["Cells"]["results"][6]["Value"].ToString(),
                        LinkUrl = result["Cells"]["results"][4]["Value"].ToString(),
                        NumeroRevista = result["Cells"]["results"][7]["Value"].ToString(),
                        Autor = result["Cells"]["results"][2]["Value"].ToString()
                    };

                    articulos.Add(article);
                }

                return articulos;

            }
            catch (Exception)
            {
                throw new Exception("Se ha producido un error en la carga de los artículos");
            }

        }

    }
}
