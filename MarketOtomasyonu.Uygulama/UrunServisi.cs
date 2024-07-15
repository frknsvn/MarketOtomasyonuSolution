using MarketOtomasyonu.Alan.DTOlar;
using MarketOtomasyonu.Alan.Modeller;
using MarketOtomasyonu.Kalıcı;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketOtomasyonu.Uygulama
{
    public class UrunServisi : IUrunServisi
    {
        private readonly IUrunRepository _urunRepository;

        public UrunServisi(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }

        public async Task<IEnumerable<UrunDTO>> GetAllUrunlerAsync()
        {
            var urunler = await _urunRepository.GetAllAsync();
            return urunler.Select(p => new UrunDTO { Ad = p.Ad, Fiyat = p.Fiyat, Stok = p.Stok });
        }

        public async Task<UrunDTO> GetUrunByIdAsync(int id)
        {
            var urun = await _urunRepository.GetByIdAsync(id);
            if (urun == null)
            {
                return null;
            }
            return new UrunDTO { Ad = urun.Ad, Fiyat = urun.Fiyat, Stok = urun.Stok };
        }

        public async Task AddUrunAsync(UrunDTO urunDto)
        {
            var urun = new Urun { Ad = urunDto.Ad, Fiyat = urunDto.Fiyat, Stok = urunDto.Stok };
            await _urunRepository.AddAsync(urun);
        }

        public async Task UpdateUrunAsync(UrunDTO urunDto)
        {
            var urun = new Urun { Id = urunDto.Id, Ad = urunDto.Ad, Fiyat = urunDto.Fiyat, Stok = urunDto.Stok };
            await _urunRepository.UpdateAsync(urun);
        }

        public async Task DeleteUrunAsync(int id)
        {
            await _urunRepository.DeleteAsync(id);
        }
    }
}
