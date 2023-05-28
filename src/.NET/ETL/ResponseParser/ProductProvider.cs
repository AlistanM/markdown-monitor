using ETL.ResponseParser.Models.WB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using static System.Net.WebRequestMethods;


namespace ETL.ResponseParser
{

    internal class ProductProvider
    {
        private const string WBSearchUrl = "https://search.wb.ru/exactmatch/ru/common/v4/search";
        private const string WBDetailUrl = "https://www.wildberries.ru/webapi/product/{0}/data";
        
        public static List<ProductWB> GetWBProducts(string searchString, int maxPages = 10)
        {
            var page = 1;
            var res = new List<ProductWB>();
            while(true)
            {
                var resPage = GetWBProductsPage(searchString, page);
                if(resPage != null)
                {
                    res.AddRange(resPage);
                }
                else
                { 
                    break; 
                }
                page++;
                if(page>maxPages)
                {
                    break;
                }
            }
            return res;
        }
        private static List<ProductWB> GetWBProductsPage(string searchString, int page)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters.Add("appType", "1");
            parameters.Add("curr", "rub");
            parameters.Add("dest", "-1257786");
            parameters.Add("page", page.ToString());
            parameters.Add("query", searchString);
            parameters.Add("resultset", "catalog");
            parameters.Add("sort", "popular");
            parameters.Add("spp", "0");
            parameters.Add("suppressSpellcheck", "false");

            var uri = new UriBuilder(WBSearchUrl);
            uri.Query = parameters.ToString();

            var res = HttpHelper.Get(uri.ToString());

            var productRes = JsonConvert.DeserializeObject<ProductResponseWB>(res);
            if (productRes.Data == null)
            {
                return null;
            }
            return productRes.Data.Products;
        }

        public static List<SitePathWB> GetWBSitePath (ProductWB product)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters.Add("subject", product.SubjectId.ToString());
            parameters.Add("kind", product.KindId.ToString());
            parameters.Add("brand", product.BrandId.ToString());

            var uri = new UriBuilder(string.Format(WBDetailUrl, product.Id));
            uri.Query= parameters.ToString();

            var res = HttpHelper.Get(uri.ToString());

            var detailRes = JsonConvert.DeserializeObject<DetailResponseWB>(res);
            return detailRes.Value.Data.SitePath;
        }
        //public static List<ProductOZON> GetOzonProducts();
    }
}