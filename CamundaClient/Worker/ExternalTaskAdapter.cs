using CamundaClient.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CamundaClient.Worker
{
    public abstract class ExternalTaskAdapter
    {
        public IDictionary<string, List<Action<IDictionary<string, object>>>> Events = new Dictionary<string, List<Action<IDictionary<string, object>>>>();

        protected abstract void ExecuteTask(ExternalTask externalTask, ref Dictionary<string, object> resultVariables);
        
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            this.ExecuteTask(externalTask, ref resultVariables);

            if (Events.ContainsKey(externalTask.ProcessInstanceId))
            {
                var list = Events[externalTask.ProcessInstanceId];
                var data = resultVariables.ToDictionary(entry => entry.Key, entry => entry.Value);
                list.ForEach(x => x(data));
            }
        }
    }

}
