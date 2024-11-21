using EcoSmart.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoSmart.Repository
{
    public interface IEnergyRecordRepository
    {
        Task<List<EnergyRecord>> GetAllAsync();  
        Task<EnergyRecord> GetByIdAsync(int id);  
        Task AddAsync(EnergyRecord record);  
        Task UpdateAsync(EnergyRecord record);  
        Task DeleteAsync(int id);  
}
}