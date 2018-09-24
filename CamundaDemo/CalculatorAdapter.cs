using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamundaClient.Dto;
using CamundaClient.Worker;

namespace CamundaDemo
{
    [ExternalTaskTopic("calculate")]
    [ExternalTaskVariableRequirements("x", "y")]
    class CalculationAdapter : ExternalTaskAdapter
    {
        protected override void ExecuteTask(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            long result = 0;
            try
            {
                long x = Convert.ToInt64(externalTask.Variables["x"].Value);
                long y = Convert.ToInt64(externalTask.Variables["y"].Value);
                result = x + y;
            }
            catch (Exception)
            {
            }
            resultVariables.Add("result", result);
        }
    }
}
