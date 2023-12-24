using ORMEntity.Common;
using ORMEntity.DBOperations;
using ProductManage.Models;

namespace ORMEntity.ProductOperations.GetProducts;

// The GetProductsQuery class handles the retrieval of a list of products.
public class GetProductsQuery
{
    private readonly ProductDbContext _productDbContext;

    public GetProductsQuery(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public List<ProductViewModel> Handle()
    {
        var productList = _productDbContext.Products.ToList();
        List<ProductViewModel> vm = new List<ProductViewModel>();
        foreach (var product in productList)
        {
            vm.Add(new ProductViewModel()
            {
                Name = product.Name,
                Price = product.Price,
                Genre = ((GenreEnum)product.GenreId).ToString()
            });
        }

        return vm;
    }
}

public class ProductViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Genre { get; set; }
}