using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specidications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductsController :ControllerBase // create Products ontroller 
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        //Reading data from database in API
        // get access to  DB context to allows us to query our database.
        public ProductsController(IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBrandRepo,
        IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper)
        {
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
            _productBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;
        }

        [HttpGet] //https://localhost:5001/api/Products
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(){ // Product -> from Entity
            var spec = new ProductsWithTypesAndBrandsSpecification(); 
            var products = await _productsRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")] //https://localhost:5001/api/Products/id
        public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id){
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product =  await _productsRepo.GetEntitywithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")] //https://localhost:5001/api/Products/brands
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")] //https://localhost:5001/api/Products/types
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes(){
            return Ok(await _productTypeRepo.ListAllAsync());
        } 
    }
}