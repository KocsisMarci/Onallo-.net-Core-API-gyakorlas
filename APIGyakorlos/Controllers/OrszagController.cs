using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIGyakorlos.Models;
using APIGyakorlos.Services;
using Org.BouncyCastle.Asn1.Mozilla;
using APIGyakorlos.DTOs;
namespace APIGyakorlos.Controllers
{
    [Route("/apiController")]
    [ApiController]
    public class OrszagController : ControllerBase
    {

        [HttpGet("GetAllOrszag")]

        public IActionResult GetAllOrszag()
        {
            try
            {
                List<Orszag> orszagok = new OrszagService().GetAll();

                if (orszagok.Count > 0)
                {
                    return Ok(orszagok);

                }

                else
                {
                    return BadRequest("Nincs találat (valószínűleg nincs ország rögzítve)");
                }
            }

            catch (Exception ex) {
                return BadRequest($"Hiba történt, bővebben: {ex.Message}");
            }
        }


        [HttpGet("GetOrszagById/{id}")]

        public IActionResult GetOrszagById(int id)
        {
            try
            {
                Orszag orszag = new OrszagService().GetById(id);
                if (orszag is not null) {
                    return Ok(orszag);
                }
                else
                {
                    return NotFound($"Nem található ország a megadott id-val ({id})");
                }
            }


            catch (Exception ex) {
                return StatusCode(400, $"Hiba történt a kérés során, bővebben: {ex.Message}");
            }
        }

        [HttpGet("GetAllNevFovaros")]

        public IActionResult GetAllNevFovaros()
        {
            try
            {
                List<NevFovaros> adottak = new OrszagService().GetAll().Select(o => new NevFovaros() { Nev = o.Nev, Fovaros = o.Fovaros }).ToList();

                if (adottak.Count > 0) {
                    return Ok(adottak);
                }

                else
                {
                    return BadRequest("Nem található ország");
                }

            }


            catch (Exception ex) {
                return StatusCode(400, $"Hiba történt a kérés során, bővebben: {ex.Message}");
            }
        }

        [HttpGet("GetNevFovarosById/{id}")]

        public IActionResult GetNevFovarosById(int id)
        {
            try
            {
                Orszag adottOrszag = new OrszagService().GetById(id);


                if (adottOrszag is not null)
                {
                    NevFovaros adott = new NevFovaros()
                    {
                        Nev = adottOrszag.Nev,
                        Fovaros = adottOrszag.Fovaros
                    };

                    return Ok(adott);
                }
                else
                {
                    return NotFound("Nincs ország rögzítve ilyen id-val");
                }
            }
            catch (Exception ex) {
                return BadRequest($"Hiba történt a kérés során, bővebben: {ex.Message}");
            }
        }
    }
}
