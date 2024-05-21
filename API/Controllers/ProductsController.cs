using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductsController :ControllerBase // create Products ontroller 
    {
        private readonly IProductRepository _rep;

        //Reading data from database in API
        // get access to  DB context to allows us to query our database.
        public ProductsController(IProductRepository rep) // StoreContext -> from Data folder
        {
            _rep = rep;
        }

        [HttpGet] //https://localhost:5001/api/Products
        public async Task<ActionResult<List<Product>>> GetProducts(){ // Product -> from Entity
            var products = await _rep.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")] //https://localhost:5001/api/Products/id
        public async Task<ActionResult<Product>> GetProducts(int id){
            return await _rep.GetProductByIdAsync(id);
        }

        [HttpGet("brands")] //https://localhost:5001/api/Products/brands
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
            return Ok(await _rep.GetProductBrandsAsync());
        }

        [HttpGet("types")] //https://localhost:5001/api/Products/types
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes(){
            return Ok(await _rep.GetProductTypesAsync());
        } 
    }
}