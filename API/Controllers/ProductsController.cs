using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductsController :ControllerBase // create Products ontroller 
    {
        private readonly StoreContext _context;

        //Reading data from database in API
        // get access to  DB context to allows us to query our database.
        public ProductsController(StoreContext context) // StoreContext -> from Data folder
        {
            _context = context; //access to all DB context methods inside our controller
        }

        [HttpGet] //https://localhost:5001/api/Products
        public async Task<ActionResult<List<Product>>> GetProducts(){ // Product -> from Entity
            var products = await _context.Products.ToListAsync();
            return products;
        }

        [HttpGet("{id}")] //https://localhost:5001/api/Products/id
        public async Task<ActionResult<Product>> GetProducts(int id){
            return await _context.Products.FindAsync(id) ;
        }
        
    }
}