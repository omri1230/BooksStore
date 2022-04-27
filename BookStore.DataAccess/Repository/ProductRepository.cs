using BooksStore.DataAccess;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;

namespace BookStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var prodactFromDb = _db.Products.FirstOrDefault(p => p.Id == product.Id);
            if (prodactFromDb != null)
            {
                prodactFromDb.Title = product.Title;
                prodactFromDb.Description = product.Description;
                prodactFromDb.ISBN = product.ISBN;
                prodactFromDb.Author = product.Author;
                prodactFromDb.ListPrice = product.ListPrice;
                prodactFromDb.Price = product.Price;
                prodactFromDb.Price50 = product.Price50;
                prodactFromDb.Price100 = product.Price100;
                prodactFromDb.Category = product.Category;
                prodactFromDb.CoverType = product.CoverType;
                if (product.ImageUrl != null)
                {
                    prodactFromDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
