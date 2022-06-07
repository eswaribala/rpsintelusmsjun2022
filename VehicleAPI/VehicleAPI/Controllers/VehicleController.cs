using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Repositories;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleRepo _vehicleRepo;

        //DI

        public VehicleController(IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }


        // GET: api/<CatalogController>
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IEnumerable<Catalog>> Get()
        {
            return await this._CatalogRepository.GetAllCatalog();
        }




        // GET api/<CatalogController>/5
        [HttpGet("{CatalogId}")]
        public async Task<Catalog> Get(long CatalogId)
        {
            return await this._CatalogRepository.GetCatalogById(CatalogId);
        }

        // POST api/<CatalogController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Catalog Catalog)
        {
            await this._CatalogRepository.AddCatalog(Catalog);
            return CreatedAtAction(nameof(Get),
                            new { id = Catalog.CatalogId }, Catalog);

        }

        // PUT api/<CatalogController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Catalog Catalog)
        {
            await this._CatalogRepository.UpdateCatalog(Catalog);
            return CreatedAtAction(nameof(Get),
                            new { id = Catalog.CatalogId }, Catalog);
        }

        // DELETE api/<CatalogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (await this._CatalogRepository.DeleteCatalog(id))
                return new OkResult();
            else
                return new BadRequestResult();

        }


    }
}
