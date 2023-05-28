using ETL.ResponseParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL;
internal class Program
{
    public static void Main(string[] args)
    {
        var products = ProductProvider.GetWBProducts("компьютер");
        var details = ProductProvider.GetWBSitePath(products.First());
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name}, {product.Id}" );
        }

        foreach (var detail in details)
        {
            Console.WriteLine(detail.Name);
        }
    }
}

