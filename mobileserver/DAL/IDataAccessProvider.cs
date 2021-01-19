using mobileserver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobileserver.DAL
{
    public interface IDataAccessProvider
    {
        Task AddKHDTRecord(Food FOOD);
        Task UpdateKHDTRecord(Food FOOD);
        Task DeleteKHDTRecord(string id);
        Task<Food> GetKHDTSingleRecord(string id);
        Task<List<Food>> GetFOODRecords();
    }
}
