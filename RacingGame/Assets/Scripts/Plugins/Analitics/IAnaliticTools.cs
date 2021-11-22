using System.Collections.Generic;

namespace Analytic
{
    internal interface IAnalyticTools
    {
        void SendMessage(string alias, IDictionary<string, object> eventData = null);
    }
}
