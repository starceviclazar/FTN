﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RTUViewer.WcfService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfService.IServiceWithCB", CallbackContract=typeof(RTUViewer.WcfService.IServiceWithCBCallback))]
    public interface IServiceWithCB {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/Subscribe", ReplyAction="http://tempuri.org/IServiceWithCB/SubscribeResponse")]
        void Subscribe(int clientId, int rtuId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/Subscribe", ReplyAction="http://tempuri.org/IServiceWithCB/SubscribeResponse")]
        System.Threading.Tasks.Task SubscribeAsync(int clientId, int rtuId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/Unsubscribe", ReplyAction="http://tempuri.org/IServiceWithCB/UnsubscribeResponse")]
        void Unsubscribe(int clientId, int rtuId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/Unsubscribe", ReplyAction="http://tempuri.org/IServiceWithCB/UnsubscribeResponse")]
        System.Threading.Tasks.Task UnsubscribeAsync(int clientId, int rtuId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceWithCBCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/OnCallback", ReplyAction="http://tempuri.org/IServiceWithCB/OnCallbackResponse")]
        void OnCallback(int id, double value, System.DateTime date, int type);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceWithCBChannel : RTUViewer.WcfService.IServiceWithCB, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceWithCBClient : System.ServiceModel.DuplexClientBase<RTUViewer.WcfService.IServiceWithCB>, RTUViewer.WcfService.IServiceWithCB {
        
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
        
        public System.Threading.Tasks.Task SubscribeAsync(int clientId, int rtuId) {
            return base.Channel.SubscribeAsync(clientId, rtuId);
        }
        
        public void Unsubscribe(int clientId, int rtuId) {
            base.Channel.Unsubscribe(clientId, rtuId);
        }
        
        public System.Threading.Tasks.Task UnsubscribeAsync(int clientId, int rtuId) {
            return base.Channel.UnsubscribeAsync(clientId, rtuId);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfService.IMeasure")]
    public interface IMeasure {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMeasure/Measure", ReplyAction="http://tempuri.org/IMeasure/MeasureResponse")]
        void Measure(int rtuId, double value, System.DateTime time, int type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMeasure/Measure", ReplyAction="http://tempuri.org/IMeasure/MeasureResponse")]
        System.Threading.Tasks.Task MeasureAsync(int rtuId, double value, System.DateTime time, int type);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMeasureChannel : RTUViewer.WcfService.IMeasure, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MeasureClient : System.ServiceModel.ClientBase<RTUViewer.WcfService.IMeasure>, RTUViewer.WcfService.IMeasure {
        
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
        
        public System.Threading.Tasks.Task MeasureAsync(int rtuId, double value, System.DateTime time, int type) {
            return base.Channel.MeasureAsync(rtuId, value, time, type);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfService.IReport")]
    public interface IReport {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/GetReportAll", ReplyAction="http://tempuri.org/IReport/GetReportAllResponse")]
        string GetReportAll(System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/GetReportAll", ReplyAction="http://tempuri.org/IReport/GetReportAllResponse")]
        System.Threading.Tasks.Task<string> GetReportAllAsync(System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/GetReportRTU", ReplyAction="http://tempuri.org/IReport/GetReportRTUResponse")]
        string GetReportRTU(int id, System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/GetReportRTU", ReplyAction="http://tempuri.org/IReport/GetReportRTUResponse")]
        System.Threading.Tasks.Task<string> GetReportRTUAsync(int id, System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/GetReportTime", ReplyAction="http://tempuri.org/IReport/GetReportTimeResponse")]
        string GetReportTime(double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/GetReportTime", ReplyAction="http://tempuri.org/IReport/GetReportTimeResponse")]
        System.Threading.Tasks.Task<string> GetReportTimeAsync(double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/AverageReport", ReplyAction="http://tempuri.org/IReport/AverageReportResponse")]
        string AverageReport(int location, System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/AverageReport", ReplyAction="http://tempuri.org/IReport/AverageReportResponse")]
        System.Threading.Tasks.Task<string> AverageReportAsync(int location, System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/GetReportTimeLocation", ReplyAction="http://tempuri.org/IReport/GetReportTimeLocationResponse")]
        string GetReportTimeLocation(int id, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReport/GetReportTimeLocation", ReplyAction="http://tempuri.org/IReport/GetReportTimeLocationResponse")]
        System.Threading.Tasks.Task<string> GetReportTimeLocationAsync(int id, double value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReportChannel : RTUViewer.WcfService.IReport, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReportClient : System.ServiceModel.ClientBase<RTUViewer.WcfService.IReport>, RTUViewer.WcfService.IReport {
        
        public ReportClient() {
        }
        
        public ReportClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReportClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReportClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReportClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetReportAll(System.DateTime start, System.DateTime end) {
            return base.Channel.GetReportAll(start, end);
        }
        
        public System.Threading.Tasks.Task<string> GetReportAllAsync(System.DateTime start, System.DateTime end) {
            return base.Channel.GetReportAllAsync(start, end);
        }
        
        public string GetReportRTU(int id, System.DateTime start, System.DateTime end) {
            return base.Channel.GetReportRTU(id, start, end);
        }
        
        public System.Threading.Tasks.Task<string> GetReportRTUAsync(int id, System.DateTime start, System.DateTime end) {
            return base.Channel.GetReportRTUAsync(id, start, end);
        }
        
        public string GetReportTime(double value) {
            return base.Channel.GetReportTime(value);
        }
        
        public System.Threading.Tasks.Task<string> GetReportTimeAsync(double value) {
            return base.Channel.GetReportTimeAsync(value);
        }
        
        public string AverageReport(int location, System.DateTime start, System.DateTime end) {
            return base.Channel.AverageReport(location, start, end);
        }
        
        public System.Threading.Tasks.Task<string> AverageReportAsync(int location, System.DateTime start, System.DateTime end) {
            return base.Channel.AverageReportAsync(location, start, end);
        }
        
        public string GetReportTimeLocation(int id, double value) {
            return base.Channel.GetReportTimeLocation(id, value);
        }
        
        public System.Threading.Tasks.Task<string> GetReportTimeLocationAsync(int id, double value) {
            return base.Channel.GetReportTimeLocationAsync(id, value);
        }
    }
}
