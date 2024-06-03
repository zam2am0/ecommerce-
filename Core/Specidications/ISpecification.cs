using System.Linq.Expressions;

namespace Core.Specidications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
        Expression<Func<T,object>> OrderBy { get; }
        Expression<Func<T,object>> OrderByDescending { get; }
        //Pagination
        int Take {get;}  //able to take a certain amount of records or a certain amount of products
        int Skip {get;} //able to skip a certain amount of records
        bool IsPagingEnabled {get;}

    }
}