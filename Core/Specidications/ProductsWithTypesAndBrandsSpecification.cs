using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specidications
{
    public class ProductsWithTypesAndBrandsSpecification:BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        : base(x =>  //filtering
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )      
        {
            AddInclude(x=> x.ProductType); //filter
            AddInclude(x=> x.ProductBrand);//filter
            //sort
            AddOrderBy(x=> x.Name); //order depend name 
            //pagation
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1),productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort)
                {
                    case "priceAsc" :
                        AddOrderBy(p=> p.Price);
                        break;
                    case "priceDesc" :
                        AddOrderByDescending(p=> p.Price);
                        break;
                    default:
                        AddOrderBy(x=> x.Name); 
                        break;
                }
            }
            
        }
        public ProductsWithTypesAndBrandsSpecification(int id) 
            : base(x=>x.Id == id)
        {
            AddInclude(x=> x.ProductType);
            AddInclude(x=> x.ProductBrand);
        }
    }
}