using ORMEntity.DBOperations;
using ProductManage.Models;

namespace ORMEntity.ProductOperations.CreateProduct;

// The CreateProductCommand class handles the creation of a new product.
public class CreateProductCommand
{
    public CreateProductModel Model { get; set; }
    private readonly ProductDbContext _productDbContext;

    public CreateProductCommand(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public void Handle()
    {
        var product = _productDbContext.Products.SingleOrDefault(x => x.Name == Model.Name);
        if (product is not null)
        {
            throw new InvalidOperationException("That book already exist");
        }

        product = new Product();
        product.Name = Model.Name;
        product.Price = Model.Price;
        product.GenreId = Model.Genre;  
        
        _productDbContext.Products.Add(product);
        _productDbContext.SaveChanges();

    }
}

public class CreateProductModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Genre { get; set; }
}