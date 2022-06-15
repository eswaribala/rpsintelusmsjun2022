using Camunda.Worker;

namespace CamundaFoodService.Handlers
{
    [HandlerTopics("readtask")]
    public class OrderHandler : IExternalTaskHandler
    {
        private readonly ILogger<OrderHandler> _logger;

        public OrderHandler(ILogger<OrderHandler> logger)
        {
            _logger = logger;
        }
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Food Order Data handler is called from Camunda...");
            try
            {
                _logger.LogInformation($"Food Order Data processing..........");
                //Mimicking operation
                Task.Delay(500).Wait();

                _logger.LogInformation($"Food Order Data processing, {externalTask.Variables["Code"].Value} ");
                _logger.LogInformation($"Food Order Data processing, {externalTask.Variables["Name"].Value} ");
                _logger.LogInformation($"Food Order Data processing, {externalTask.Variables["Qty"].Value} ");
                return new CompleteResult();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error occured!! error messge: {ex.Message}");
                //return failure
                return new BpmnErrorResult("Food Order Data Processing Failure",
                    "Error occured while processing payment..");
            }

        }
    }
}
