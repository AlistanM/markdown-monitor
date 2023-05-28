using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.ResponseParser.Models.WB
{
    internal class ProductWB
    {

        public float Rating { get; set; }
        public long BrandId { get; set; }
        public long KindId { get; set; }
        public long SubjectId { get; set; }
        [JsonProperty("PriceU")]
        public decimal OriginalPrice { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        [JsonProperty("SalePriceU")]
        public decimal Price { get; set; }
        public string Brand { get; set; }
    }
}