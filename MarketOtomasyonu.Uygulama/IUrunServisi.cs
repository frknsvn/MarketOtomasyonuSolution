using MarketOtomasyonu.Alan.DTOlar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketOtomasyonu.Uygulama
{
    public interface IUrunServisi
    {
        Task<IEnumerable<UrunDTO>> GetAllUrunlerAsync();
        Task<UrunDTO> GetUrunByIdAsync(int id);
        Task AddUrunAsync(UrunDTO urunDto);
        Task UpdateUrunAsync(UrunDTO urunDto);
        Task DeleteUrunAsync(int id);
    }
}
