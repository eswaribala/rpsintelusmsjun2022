using Camunda.Api.Client;
using Camunda.Api.Client.ProcessDefinition;
using CamundaFoodService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CamundaFoodService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodOrderController : ControllerBase
    {
        private readonly ILogger<FoodOrderController> _logger;
        private IConfiguration _configuration;
        private CamundaClient _client;
        public FoodOrderController(ILogger<FoodOrderController> logger, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._logger = logger;
            _client = CamundaClient.Create(this._configuration["RestApiUri"]);
        }
        [HttpPost("startProcess")]
        public IActionResult StartProcess([FromBody] Food food,
            FoodOrderBPMNProcess FoodOrderBPMNProcess)
        {
            _logger.LogInformation("Starting the sample Camunda process...");
            try
            {
                Random random = new Random();

                //Creating process parameters
                StartProcessInstance processParams;

                //json to string
                String message = JsonConvert.SerializeObject(food);
                //string to c# pobject
               Food FoodObj = JsonConvert.DeserializeObject<Food>(message);



                processParams = new StartProcessInstance()
                    .SetVariable("Code", food.Code)
                   .SetVariable("Name", food.Name)
                   .SetVariable("Qty", food.Qty);
                

                _logger.LogInformation($"Camunda process to demonstrate Saga based orchestrator started..........");


                //Startinng the process
                var proceStartResult = _client.ProcessDefinitions.ByKey(FoodOrderBPMNProcess.ToString())
                    .StartProcessInstance(processParams);

                //return Ok("Done");

                return Ok(proceStartResult.Result.DefinitionId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error occured!! error messge: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("processDefinitions")]
        //camunda rest api calls
        public async Task<IActionResult> GetProcessDefinitions()
        {



            using var client = new HttpClient();

            var url = this._configuration["RestApiUri"] + "process-definition";
            //synchronous call
            var result = await client.GetAsync(url);
            return Ok(result.Content.ReadAsStringAsync());
            //return Ok(this._client.ProcessDefinitions);
        }


        public enum FoodOrderBPMNProcess
        {
            Process_Food_Order
        }
    }
}
