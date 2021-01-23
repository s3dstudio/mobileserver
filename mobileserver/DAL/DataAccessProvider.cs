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
            _context.SaveChanges();
        }

        public void DeleteFOODRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.Food.FirstOrDefault(t => Convert.ToString(t.idfood) == id);
            if (entity != null)
            {
                _context.Food.Remove(entity);
                _context.SaveChanges();
            }
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
            _context.SaveChanges();
        }

        //USER
        public async Task AddUSERRecord(Users USER)
        {
            _context.Users.Add(USER);
            _context.SaveChanges();
        }

        public void DeleteUSERRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.Users.FirstOrDefault(t => Convert.ToString(t.idUsers) == id);
            if (entity != null)
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
            }
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
            _context.SaveChanges();
        }

        //FOODSCARTS
        public async Task AddFCRecord(foodscart FC)
        {
            using (var context = _context)
            {
                context.foodscart.AddRange(FC);
                context.SaveChanges();
            }
        }

        public void DeleteFCRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.foodscart.FirstOrDefault(t => Convert.ToString(t.idcart) == id);
            if (entity != null)
            {
                _context.foodscart.Remove(entity);
                _context.SaveChanges();
            }
        }

        public async Task<List<foodscart>> GetFCRecords()
        {
            return await _context.foodscart.OrderByDescending(m => EF.Property<string>(m, "idcart")).ToListAsync();
        }

        public async Task<foodscart> GetFCSingleRecord(string id)
        {
            return await _context.foodscart.FirstOrDefaultAsync(m => m.idcart == id);
        }

        public async Task UpdateFCRecord(foodscart FC)
        {
            _context.foodscart.Update(FC);
            _context.SaveChanges();
        }

        //NOTIFICATIONS
        public async Task AddNTRecord(Notifications NT)
        {
            _context.Notifications.AddRangeAsync(NT);
            _context.SaveChanges();
        }

        public void DeleteNTRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.Notifications.FirstOrDefault(t => Convert.ToString(t.idnotification) == id);
            if (entity != null)
            {
                _context.Notifications.Remove(entity);
                _context.SaveChanges();
            }
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
            _context.SaveChanges();
        }

        //AllBills
        public async Task AddABRecord(AllBills NT)
        {
            _context.AllBills.Add(NT);
            _context.SaveChanges();
        }

        public void DeleteABRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.AllBills.FirstOrDefault(t => Convert.ToString(t.idCart) == id);
            if (entity != null)
            {
                _context.AllBills.Remove(entity);
                _context.SaveChanges();
            }
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
            _context.SaveChanges();
        }

        public async Task<List<Food>> GetFOOD(bool withChildren)
        {
            // Using the shadow property EF.Property<DateTime>(srcInfo)
            //if (withChildren)
            //{
            //    return await _context.Food.Include(s => s.AllBills).OrderByDescending(srcInfo => EF.Property<string>(srcInfo, "idCart")).ToListAsync();
            //}

            return await _context.Food.OrderByDescending(srcInfo => EF.Property<string>(srcInfo, "idfood")).ToListAsync();
        }

        public async Task AddFCDTRecord(FoodsCartDetail FC)
        {
            _context.FoodsCartDetail.Add(FC);
            _context.SaveChanges();
        }

        public async Task UpdateFCDTRecord(FoodsCartDetail FC)
        {
            _context.FoodsCartDetail.Update(FC);
            _context.SaveChanges();
        }

        public void DeleteFCDTRecord(string id)
        {
            Console.WriteLine(id);
            var entity = _context.FoodsCartDetail.FirstOrDefault(t => Convert.ToString(t.idfcdetail) == id);
            { 
                _context.FoodsCartDetail.Remove(entity);
                _context.SaveChanges();
            }
        }

        public async Task<FoodsCartDetail> GetFCDTSingleRecord(string id)
        {
            return await _context.FoodsCartDetail.FirstOrDefaultAsync(m => m.idfcdetail == id);
        }

        public async Task<List<FoodsCartDetail>> GetFCDTRecords()
        {
            return await _context.FoodsCartDetail.OrderByDescending(m => EF.Property<string>(m, "idfcdetail")).ToListAsync();
        }
    }
}
