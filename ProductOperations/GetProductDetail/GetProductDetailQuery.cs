using ORMEntity.Common;
using ORMEntity.DBOperations;

namespace ORMEntity.ProductOperations.GetProductDetail;

// The GetProductDetailQuery class handles the retrieval of detailed information for a product.
public class GetProductDetailQuery
{
    public int ProductId { get; set; }
    private readonly ProductDbContext _productDbContext;

    public GetProductDetailQuery(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public ProductDetailViewModel Handle()
    {
        var product = _productDbContext.Products.FirstOrDefault(p => p.Id == ProductId);
        if (product is null)
        {
            throw new InvalidOperationException("Product is empty");
        }
        ProductDetailViewModel vm = new ProductDetailViewModel();
        vm.Name = product.Name;
        vm.Price = product.Price;
        vm.Genre = ((GenreEnum)product.GenreId).ToString();   
        return vm;
    }
}

public class ProductDetailViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Genre { get; set; }
}