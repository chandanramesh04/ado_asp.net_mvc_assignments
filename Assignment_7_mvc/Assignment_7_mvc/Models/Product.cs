namespace Assignment_7_mvc.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ? ProductName { get; set; }
        public double Price { get; set; }

        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
{
new Product{ProductId=1, ProductName="Product1",Price=900.00},
new Product{ProductId=2, ProductName="Product2",Price=700.00},
new Product{ProductId=3, ProductName="Product3",Price=650.00},
new Product{ProductId=4, ProductName="Product4",Price=950.00},
new Product{ProductId=5, ProductName="Product5",Price=800.00},
};
        }

    }
}
