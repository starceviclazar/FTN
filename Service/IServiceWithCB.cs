﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    [ServiceContract(CallbackContract=typeof(IServiceWithCBCallback))]
    public interface IServiceWithCB
    {
        [OperationContract]
        void Subscribe(int clientId, int rtuId);

		[OperationContract]
		void Unsubscribe(int clientId, int rtuId);
    }
}
