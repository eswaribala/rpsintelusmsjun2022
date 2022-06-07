using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Models;
using VehicleAPI.Repositories;

namespace VehicleAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleRepo _vehicleRepo;

        //DI

        public VehicleController(IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }


        // GET: api/<VehicleController>
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IEnumerable<Vehicle>> Get()
        {
            return await this._vehicleRepo.GetVehicles();
        }



        // GET api/<VehicleController>/5
        [HttpGet("{EngineNo}")]
        public async Task<Vehicle> Get(long EngineNo)
        {
            return await this._vehicleRepo.GetVehicleById(EngineNo);
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vehicle Vehicle)
        {
            await this._vehicleRepo.AddVehicle(Vehicle);
            return CreatedAtAction(nameof(Get),
                            new { id = Vehicle.EngineNo }, Vehicle);

        }

        // PUT api/<VehicleController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Vehicle Vehicle)
        {
            await this._vehicleRepo.UpdateVehicle(Vehicle);
            return CreatedAtAction(nameof(Get),
                            new { id = Vehicle.EngineNo}, Vehicle);
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{EngineNo}")]
        public async Task<IActionResult> Delete(long EngineNo)
        {

            if (await this._vehicleRepo.DeleteVehicle(EngineNo))
                return new OkResult();
            else
                return new BadRequestResult();

        }


    }
}
