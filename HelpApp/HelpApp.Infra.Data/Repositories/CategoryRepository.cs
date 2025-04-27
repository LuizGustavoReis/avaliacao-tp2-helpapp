using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpApp.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _context;

        public CategoryRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Set<Category>().ToListAsync();
        }

        public async Task<Category> GetById(int? id)
        {
            return await _context.Set<Category>().FindAsync(id);
        }

        public async Task<Category> Create(Category category)
        {
            await _context.Set<Category>().AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Set<Category>().Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Remove(Category category)
        {
            _context.Set<Category>().Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
