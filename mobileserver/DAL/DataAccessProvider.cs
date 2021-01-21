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

        //FOOD
        public async Task AddFOODRecord(Food FOOD)
        {
            _context.Food.Add(FOOD);
            _context.SaveChangesAsync();
        }

        public async Task DeleteFOODRecord(string id)
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

        public async Task<Food> GetFOODSingleRecord(string id)
        {
            return await _context.Food.FirstOrDefaultAsync(m => m.idfood == id);
        }

        public async Task UpdateFOODRecord(Food FOOD)
        {
            _context.Food.Update(FOOD);
            _context.SaveChangesAsync();
        }

        //USER
        public async Task AddUSERRecord(Users USER)
        {
            _context.Users.Add(USER);
            _context.SaveChangesAsync();
        }

        public async Task DeleteUSERRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.Users.FirstOrDefault(t => Convert.ToString(t.idUsers) == id);
            _context.Users.Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<List<Users>> GetUSERRecords()
        {
            return await _context.Users.OrderByDescending(m => EF.Property<string>(m, "idUsers")).ToListAsync();
        }

        public async Task<Users> GetUSERSingleRecord(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.idUsers == id);
        }

        public async Task UpdateUSERRecord(Users USER)
        {
            _context.Users.Update(USER);
            _context.SaveChangesAsync();
        }

        //FOODSCARTS
        public async Task AddFCRecord(FoodsCart FC)
        {
            _context.FoodsCart.Add(FC);
            _context.SaveChangesAsync();
        }

        public async Task DeleteFCRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.FoodsCart.FirstOrDefault(t => Convert.ToString(t.idCart) == id);
            _context.FoodsCart.Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<List<FoodsCart>> GetFCRecords()
        {
            return await _context.FoodsCart.OrderByDescending(m => EF.Property<string>(m, "idCart")).ToListAsync();
        }

        public async Task<FoodsCart> GetFCSingleRecord(string id)
        {
            return await _context.FoodsCart.FirstOrDefaultAsync(m => m.idCart == id);
        }

        public async Task UpdateFCRecord(FoodsCart FC)
        {
            _context.FoodsCart.Update(FC);
            _context.SaveChangesAsync();
        }

        //NOTIFICATIONS
        public async Task AddNTRecord(Notifications NT)
        {
            _context.Notifications.Add(NT);
            _context.SaveChangesAsync();
        }

        public async Task DeleteNTRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.Notifications.FirstOrDefault(t => Convert.ToString(t.idnotification) == id);
            _context.Notifications.Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<List<Notifications>> GetNTRecords()
        {
            return await _context.Notifications.OrderByDescending(m => EF.Property<string>(m, "idnotification")).ToListAsync();
        }

        public async Task<Notifications> GetNTSingleRecord(string id)
        {
            return await _context.Notifications.FirstOrDefaultAsync(m => m.idnotification == id);
        }

        public async Task UpdateNTRecord(Notifications FC)
        {
            _context.Notifications.Update(FC);
            _context.SaveChangesAsync();
        }

        //AllBills
        public async Task AddABRecord(AllBills NT)
        {
            _context.AllBills.Add(NT);
            _context.SaveChangesAsync();
        }

        public async Task DeleteABRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.AllBills.FirstOrDefault(t => Convert.ToString(t.idCart) == id);
            _context.AllBills.Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<List<AllBills>> GetABRecords()
        {
            return await _context.AllBills.OrderByDescending(m => EF.Property<string>(m, "idCart")).ToListAsync();
        }

        public async Task<AllBills> GetABSingleRecord(string id)
        {
            return await _context.AllBills.FirstOrDefaultAsync(m => m.idCart == id);
        }

        public async Task UpdateABRecord(AllBills FC)
        {
            _context.AllBills.Update(FC);
            _context.SaveChangesAsync();
        }

        public async Task<List<Food>> GetFOOD(bool withChildren)
        {
            // Using the shadow property EF.Property<DateTime>(srcInfo)
            if (withChildren)
            {
                return await _context.Food.Include(s => s.AllBills).OrderByDescending(srcInfo => EF.Property<string>(srcInfo, "idCart")).ToListAsync();
            }

            return await _context.Food.OrderByDescending(srcInfo => EF.Property<string>(srcInfo, "idfood")).ToListAsync();
        }
    }
}
