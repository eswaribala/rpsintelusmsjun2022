using Camunda.Api.Client;
using Camunda.Api.Client.Deployment;
using Camunda.Api.Client.ProcessInstance;

namespace CamundaFoodService.Bpmns
{
    public class BpmnService
    {
        private readonly CamundaClient camunda;
        public BpmnService(String RestApiService)
        {
            camunda = CamundaClient.Create(RestApiService);
        }
        public async Task DeployProcessDefinition()
        {
            var bpmnResourceStream = this.GetType()
                .Assembly
                .GetManifestResourceStream("CamundaFoodService.Processes.foodorderprocess.bpmn");

            try
            {
                await camunda.Deployments.Create(
                    "Food Order Deployment",
                    true,
                    true,
                    null,
                    null,
                    new ResourceDataContent(bpmnResourceStream, "foodorderprocess.bpmn"));
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to deploy process definition", e);
            }
        }

        public async Task CleanupProcessInstances()
        {
            var instances = await camunda.ProcessInstances
                .Query(new ProcessInstanceQuery
                {
                    ProcessDefinitionKey = "Process_"
                })
                .List();

            if (instances.Count > 0)
            {
                await camunda.ProcessInstances.Delete(new DeleteProcessInstances
                {
                    ProcessInstanceIds = instances.Select(i => i.Id).ToList()
                });
            }
        }
    }
}
