using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamundaClient;

namespace CamundaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CamundaEngineClient camunda = new CamundaEngineClient(new System.Uri("http://localhost:8080/engine-rest/engine/default/"), null, null);
            camunda.Startup();
            string processInstanceId = camunda.BpmnWorkflowService.StartProcessInstance("calculate", new Dictionary<string, object>()
            {
                {"x", 15 },
                {"y", 20 }
            });
            Console.ReadLine();
            camunda.Shutdown();
        }
    }
}
