using ORMEntity.DBOperations;
using ORMEntity.ProductOperations.CreateProduct;
using ORMEntity.ProductOperations.DeleteProduct;
using ORMEntity.ProductOperations.GetProductDetail;
using ORMEntity.ProductOperations.GetProducts;
using ORMEntity.ProductOperations.UpdateProduct;

namespace ProductManage.Services;

// The ProductServices class implements the IProductServices interface for product-related operations.
public class ProductServices : IProductServices
{
    private readonly ProductDbContext _productDbContext;
    
    public ProductServices(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public List<ProductViewModel> GetProducts()
    {
        GetProductsQuery getProductsQuery = new GetProductsQuery(_productDbContext);
        var result = getProductsQuery.Handle();
        return result;

    }

    public ProductDetailViewModel GetProductById(int id)
    {
        GetProductDetailQuery getProductsQuery = new GetProductDetailQuery(_productDbContext);
        getProductsQuery.ProductId = id;
        var result = getProductsQuery.Handle();
        return result;
    }

    public void CreateProduct(CreateProductModel newProduct)
    {
        CreateProductCommand createProductCommand = new CreateProductCommand(_productDbContext);
        createProductCommand.Model = newProduct;
        createProductCommand.Handle();
        
    }

    public void UpdateProduct(int id, UpdateProductModel updateProduct)
    {
        UpdateProductCommand updateProductCommand = new UpdateProductCommand(_productDbContext);
        updateProductCommand.ProductId = id;
        updateProductCommand.Model = updateProduct;
        updateProductCommand.handle();
    }

    public void DeleteProduct(int id)
    {
        DeleteProductCommand deleteProductCommand = new DeleteProductCommand(_productDbContext);
        deleteProductCommand.ProductId = id;
        deleteProductCommand.handle();
    }
}
