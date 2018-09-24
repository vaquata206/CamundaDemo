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
                {"x", 25 },
                {"y", 20 }
            },new Dictionary<string, Action<IDictionary<string, object>>> {
                {"calculate",
                    (x) => {
                        Console.WriteLine("Tan dep trai");
                    }
                }
            });

            //System.Threading.Thread.Sleep(20000);

            //string processInstanceId1 = camunda.BpmnWorkflowService.StartProcessInstance("calculate", new Dictionary<string, object>()
            //{
            //    {"x", 25 },
            //    {"y", 30 }
            //}, new Dictionary<string, Action<IDictionary<string, object>>> {
            //    {"calculate",
            //        (x) => {
            //            Console.WriteLine("Tan dep trai " + x["result"]);
            //        }
            //    }
            //});

            Console.ReadLine();
            camunda.Shutdown();
        }
    }
}
