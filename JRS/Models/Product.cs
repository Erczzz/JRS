using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JRS.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
       
        public Product() { }

        public Product(int productId, string productName, double productPrice, int productStock)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductStock = productStock;
        }
    }
}
