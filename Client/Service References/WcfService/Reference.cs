﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.WcfService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfService.IServiceWithCB", CallbackContract=typeof(Client.WcfService.IServiceWithCBCallback))]
    public interface IServiceWithCB {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/Subscribe", ReplyAction="http://tempuri.org/IServiceWithCB/SubscribeResponse")]
        void Subscribe(int clientId, int rtuId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/Unsubscribe", ReplyAction="http://tempuri.org/IServiceWithCB/UnsubscribeResponse")]
        void Unsubscribe(int clientId, int rtuId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceWithCBCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/OnCallback", ReplyAction="http://tempuri.org/IServiceWithCB/OnCallbackResponse")]
        void OnCallback(int id, double value, System.DateTime date, int type);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceWithCBChannel : Client.WcfService.IServiceWithCB, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceWithCBClient : System.ServiceModel.DuplexClientBase<Client.WcfService.IServiceWithCB>, Client.WcfService.IServiceWithCB {
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Subscribe(int clientId, int rtuId) {
            base.Channel.Subscribe(clientId, rtuId);
        }
        
        public void Unsubscribe(int clientId, int rtuId) {
            base.Channel.Unsubscribe(clientId, rtuId);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfService.IMeasure")]
    public interface IMeasure {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMeasure/Measure", ReplyAction="http://tempuri.org/IMeasure/MeasureResponse")]
        void Measure(int rtuId, double value, System.DateTime time, int type);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMeasureChannel : Client.WcfService.IMeasure, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MeasureClient : System.ServiceModel.ClientBase<Client.WcfService.IMeasure>, Client.WcfService.IMeasure {
        
        public MeasureClient() {
        }
        
        public MeasureClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MeasureClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MeasureClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MeasureClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Measure(int rtuId, double value, System.DateTime time, int type) {
            base.Channel.Measure(rtuId, value, time, type);
        }
    }
}
