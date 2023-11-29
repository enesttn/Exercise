
List<Category> categories = new List<Category>
{
    new Category{CategoryId=1, CategoryName="Computer"},
    new Category {CategoryId=2, CategoryName="Accessory"}
    
};


// Alternatif kullanım : categories.Add(new Category { CategoryId = 3, CategoryName = "Headphone" });


List<Product> products = new List<Product>
{
    new Product{ProductId=1, CategoryId=1, ProductName="HP Laptop", QuantityPerUnit="32 GB RAM", UnitPrice=10000, UnitsInStock=50},
    new Product{ProductId=2, CategoryId=1, ProductName="Lenovo Laptop", QuantityPerUnit="16 GB RAM", UnitPrice=8000, UnitsInStock=35},
    new Product{ProductId=3, CategoryId=1, ProductName="Toshiba Laptop", QuantityPerUnit="8 GB RAM", UnitPrice=6000, UnitsInStock=20},
    new Product{ProductId=4, CategoryId=1, ProductName="Apple iPhone", QuantityPerUnit="3 GB RAM", UnitPrice=5000, UnitsInStock=120},
    new Product{ProductId=5, CategoryId=1, ProductName="Xiaomi Phone", QuantityPerUnit="4 GB RAM", UnitPrice=4000, UnitsInStock=0}
};



GetProducts(products);



Console.WriteLine("------------Algoritmik");


foreach (var product in products) // Fiyatı 5000'den fazla olanlar ve stok sayısı 20 den fazla olanlar
{
    if (product.UnitPrice > 5000 && product.UnitsInStock > 20)
    {
        Console.WriteLine(product.ProductName);
    }
    
}


Console.WriteLine("------------Linq");



var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 20);

foreach (var product in result)
{
    Console.WriteLine(product.ProductName);
}




static List<Product> GetProducts(List<Product> products)
{
    List<Product> filteredProducts = new List<Product>(); //Where burada yaptığımızı yaparak arka planda bizim için bir liste oluşturur.
    
    foreach (var product in products)
    {
        if (product.UnitPrice>5000)
        {
            filteredProducts.Add(product);
        }

    }
    return filteredProducts;
}

static List<Product> GetProductsLinq(List<Product> products)
{
    return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 20).ToList(); /* products'ı tek tek gezer ve şarta uyanları oluşturduğu 
                                                                                     listeye atar. Böylelikle filtreleme gerçekleşmiş olur. */

}


class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public string QuantityPerUnit { get; set; }
    public int UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}

class Category
{ 
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}