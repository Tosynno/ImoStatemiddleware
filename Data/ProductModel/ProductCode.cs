using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImoStatemiddleware.Data.ProductModel
{
    [Table("ProductCode")]
    public class ProductCode
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string Productcodes { get; set; }
    }
}
