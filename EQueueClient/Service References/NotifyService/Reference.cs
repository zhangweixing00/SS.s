﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EQueueClient.NotifyService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NotifyService.INotifyService")]
    public interface INotifyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INotifyService/SendMessage", ReplyAction="http://tempuri.org/INotifyService/SendMessageResponse")]
        void SendMessage(byte[] data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INotifyService/SendSimpleMessage", ReplyAction="http://tempuri.org/INotifyService/SendSimpleMessageResponse")]
        void SendSimpleMessage(string user, string info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INotifyService/BroadCast", ReplyAction="http://tempuri.org/INotifyService/BroadCastResponse")]
        void BroadCast(string info);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INotifyServiceChannel : EQueueClient.NotifyService.INotifyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NotifyServiceClient : System.ServiceModel.ClientBase<EQueueClient.NotifyService.INotifyService>, EQueueClient.NotifyService.INotifyService {
        
        public NotifyServiceClient() {
        }
        
        public NotifyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NotifyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NotifyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NotifyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SendMessage(byte[] data) {
            base.Channel.SendMessage(data);
        }
        
        public void SendSimpleMessage(string user, string info) {
            base.Channel.SendSimpleMessage(user, info);
        }
        
        public void BroadCast(string info) {
            base.Channel.BroadCast(info);
        }
    }
}
