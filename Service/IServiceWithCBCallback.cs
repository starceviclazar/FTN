using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Service
{
    interface IServiceWithCBCallback
    {
        [OperationContract]
        void OnCallback(string id, double value);
    }
}
