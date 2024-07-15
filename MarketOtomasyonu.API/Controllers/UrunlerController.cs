using MarketOtomasyonu.Uygulama;
using MarketOtomasyonu.Alan.DTOlar;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketOtomasyonu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        private readonly IUrunServisi _urunServisi;

        public UrunlerController(IUrunServisi urunServisi)
        {
            _urunServisi = urunServisi;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UrunDTO>>> GetAllUrunler()
        {
            var urunler = await _urunServisi.GetAllUrunlerAsync();
            return Ok(urunler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UrunDTO>> GetUrunById(int id)
        {
            var urun = await _urunServisi.GetUrunByIdAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            return Ok(urun);
        }

        [HttpPost]
        public async Task<ActionResult> AddUrun(UrunDTO urunDto)
        {
            await _urunServisi.AddUrunAsync(urunDto);
            return CreatedAtAction(nameof(GetUrunById), new { id = urunDto.Id }, urunDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUrun(int id, UrunDTO urunDto)
        {
            if (id != urunDto.Id)
            {
                return BadRequest();
            }
            await _urunServisi.UpdateUrunAsync(urunDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUrun(int id)
        {
            await _urunServisi.DeleteUrunAsync(id);
            return NoContent();
        }
    }
}
