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
        public ProductsWithTypesAndBrandsSpecification(){
            AddInclude(x=> x.ProductType);
            AddInclude(x=> x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) 
            : base(x=>x.Id == id)
        {
            AddInclude(x=> x.ProductType);
            AddInclude(x=> x.ProductBrand);
        }
    }
}