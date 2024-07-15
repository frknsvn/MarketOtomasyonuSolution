using MarketOtomasyonu.Alan.Modeller;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketOtomasyonu.Kalıcı
{
    public class UrunRepository : IUrunRepository
    {
        private readonly AppDbContext _context;

        public UrunRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Urun>> GetAllAsync()
        {
            return await _context.Urunler.ToListAsync();
        }

        public async Task<Urun> GetByIdAsync(int id)
        {
            return await _context.Urunler.FindAsync(id);
        }

        public async Task AddAsync(Urun urun)
        {
            await _context.Urunler.AddAsync(urun);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Urun urun)
        {
            _context.Urunler.Update(urun);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);
            if (urun != null)
            {
                _context.Urunler.Remove(urun);
                await _context.SaveChangesAsync();
            }
        }
    }
}
