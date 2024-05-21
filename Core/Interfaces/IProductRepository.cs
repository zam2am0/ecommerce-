using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        //methods
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync(); //Product -> from entities   
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}