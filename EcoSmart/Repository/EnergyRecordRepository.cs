using EcoSmart.Model;
using EcoSmart.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoSmart.Repository
{
    public class EnergyRecordRepository : IEnergyRecordRepository
    {
        private readonly EcoSmartDbContext _context;

        public EnergyRecordRepository(EcoSmartDbContext context)
        {
            _context = context;
        }

        public async Task<List<EnergyRecord>> GetAllAsync()
        {
            return await _context.EnergyRecords.ToListAsync();
        }

        public async Task<EnergyRecord> GetByIdAsync(int id)
        {
            return await _context.EnergyRecords.FindAsync(id);
        }

        public async Task AddAsync(EnergyRecord record)
        {
            await _context.EnergyRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EnergyRecord record)
        {
            _context.EnergyRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await GetByIdAsync(id);
            if (record != null)
            {
                _context.EnergyRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
