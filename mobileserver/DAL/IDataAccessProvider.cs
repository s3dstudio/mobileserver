using mobileserver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobileserver.DAL
{
    public interface IDataAccessProvider
    {
        Task AddFOODRecord(Food FOOD);
        Task UpdateFOODRecord(Food FOOD);
        void DeleteFOODRecord(string id);
        Task<Food> GetFOODSingleRecord(string id);
        Task<List<Food>> GetFOODRecords();

        Task AddUSERRecord(Users USERS);
        Task UpdateUSERRecord(Users USERS);
        void DeleteUSERRecord(string id);
        Task<Users> GetUSERSingleRecord(string id);
        Task<List<Users>> GetUSERRecords();

        Task AddFCRecord(foodscart FC);
        Task UpdateFCRecord(foodscart FC);
        void DeleteFCRecord(string id);
        Task<foodscart> GetFCSingleRecord(string id);
        Task<List<foodscart>> GetFCRecords();

        Task AddFCDTRecord(FoodsCartDetail FC);
        Task UpdateFCDTRecord(FoodsCartDetail FC);
        void DeleteFCDTRecord(string id);
        Task<FoodsCartDetail> GetFCDTSingleRecord(string id);
        Task<List<FoodsCartDetail>> GetFCDTRecords();

        Task AddNTRecord(Notifications NT);
        Task UpdateNTRecord(Notifications NT);
        void DeleteNTRecord(string id);
        Task<Notifications> GetNTSingleRecord(string id);
        Task<List<Notifications>> GetNTRecords();

        Task AddABRecord(AllBills NT);
        Task UpdateABRecord(AllBills NT);
        void DeleteABRecord(string id);
        Task<AllBills> GetABSingleRecord(string id);
        Task<List<AllBills>> GetABRecords();
        Task<List<Food>> GetFOOD(bool withChildren);
    }
}
