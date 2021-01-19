using Microsoft.EntityFrameworkCore;
using mobileserver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobileserver.DAL
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public async Task AddKHDTRecord(Food FOOD)
        {
            _context.Food.Add(FOOD);
            _context.SaveChangesAsync();
        }

        public async Task DeleteKHDTRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.Food.FirstOrDefault(t => Convert.ToString(t.idfood) == id);
            _context.Food.Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<List<Food>> GetFOODRecords()
        {
            return await _context.Food.OrderByDescending(m => EF.Property<string>(m, "idfood")).ToListAsync();
        }

        public async Task<Food> GetKHDTSingleRecord(string id)
        {
            return await _context.Food.FirstOrDefaultAsync(m => m.idfood == id);
        }

        public async Task UpdateKHDTRecord(Food FOOD)
        {
            _context.Food.Update(FOOD);
            _context.SaveChangesAsync();
        }
    }
}
