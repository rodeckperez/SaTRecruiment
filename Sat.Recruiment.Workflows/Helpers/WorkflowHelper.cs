using Sat.Recruiment.Common.Enums;
using Sat.Recruiment.Common.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Sat.Recruiment.Workflows.Helpers
{
    [ExcludeFromCodeCoverage]
    public  class WorkflowHelper
    {
        public static void FailFlowExecution<T>(Response<T> response)
        {
            response.Data = default(T);
            response.Messages.Add(new Message("An error has occurred", "GenericRequestFail", MessageType.Error));
        }
    }
}
