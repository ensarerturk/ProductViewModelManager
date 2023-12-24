using ORMEntity.ProductOperations.CreateProduct;
using ORMEntity.ProductOperations.GetProductDetail;
using ORMEntity.ProductOperations.GetProducts;
using ORMEntity.ProductOperations.UpdateProduct;
using ProductManage.Models;

namespace ProductManage.Services;

// The IProductServices interface defines the contract for product-related services.
public interface IProductServices
{
    List<ProductViewModel> GetProducts();
    ProductDetailViewModel GetProductById(int id);
    void CreateProduct(CreateProductModel newProduct);
    void UpdateProduct(int id, UpdateProductModel updateProduct);
    void DeleteProduct(int id);
}