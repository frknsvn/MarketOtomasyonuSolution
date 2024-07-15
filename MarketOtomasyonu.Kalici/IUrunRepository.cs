using MarketOtomasyonu.Alan.Modeller;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketOtomasyonu.Kalıcı
{
    public interface IUrunRepository
    {
        Task<IEnumerable<Urun>> GetAllAsync();
        Task<Urun> GetByIdAsync(int id);
        Task AddAsync(Urun urun);
        Task UpdateAsync(Urun urun);
        Task DeleteAsync(int id);
    }
}
