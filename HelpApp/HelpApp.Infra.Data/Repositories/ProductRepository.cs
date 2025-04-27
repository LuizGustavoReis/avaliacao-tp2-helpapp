using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Set<Product>().ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            return await _context.Set<Product>().FindAsync(id);
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            _context.Set<Product>().Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
