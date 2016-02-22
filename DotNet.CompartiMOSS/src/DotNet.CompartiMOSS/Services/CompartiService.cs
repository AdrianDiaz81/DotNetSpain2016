using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace DotNet.CompartiMOSS.Services
{
    public class CompartiService : ICompartiService
    {
        private const string url = "http://www.compartimoss.com/_api/search/query?querytext=##query##&QueryTemplatePropertiesUrl='spfile://webroot/queryparametertemplate.xml'&clienttype='Custom'";
        public async Task<List<Model.Revista>> SearchNumbers()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                var response = await httpClient.GetStringAsync("http://dockerdotnetencamina.westus.cloudapp.azure.com:8428/api/revista");

                return JsonConvert.DeserializeObject<List<Model.Revista>>(response);
            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error en la carga de los números");
            }
        }

        public async Task<List<Model.Autor>> SearchAuthors()
        {
            try
            {


                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                var response = await httpClient.GetStringAsync("http://dockerdotnetencamina.westus.cloudapp.azure.com:8427/api/autor");

                return JsonConvert.DeserializeObject<List<Model.Autor>>(response);

                                 
            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error en la carga de los autores");
            }
        }


        public async Task<List<Model.Articulos>> SearchArticles(string number)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                var response = await httpClient.GetStringAsync("http://dockerdotnetencamina.westus.cloudapp.azure.com:8429/api/articulo/"+number);

                return JsonConvert.DeserializeObject<List<Model.Articulos>>(response);
                

            }
            catch (Exception)
            {
                throw new Exception("Se ha producido un error en la carga de los artículos");
            }

        }

        public async Task<List<Model.Articulos>> SearchArticlesByAutor(string autor)
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

                var articulos = new List<Model.Articulos>();
                foreach (var result in results)
                {
                    var article = new Model.Articulos()
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
