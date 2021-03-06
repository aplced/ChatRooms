﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatRoomsClient.ChatRoomsService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatRoomsService.IChatRoomsService")]
    public interface IChatRoomsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/AllUsers", ReplyAction="http://tempuri.org/IChatRoomsService/AllUsersResponse")]
        System.Collections.Generic.List<ChatRoomsDataTypes.User> AllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/AllUsers", ReplyAction="http://tempuri.org/IChatRoomsService/AllUsersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<ChatRoomsDataTypes.User>> AllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/AllRooms", ReplyAction="http://tempuri.org/IChatRoomsService/AllRoomsResponse")]
        System.Collections.Generic.List<ChatRoomsDataTypes.Room> AllRooms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/AllRooms", ReplyAction="http://tempuri.org/IChatRoomsService/AllRoomsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<ChatRoomsDataTypes.Room>> AllRoomsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/CreateUser", ReplyAction="http://tempuri.org/IChatRoomsService/CreateUserResponse")]
        ChatRoomsDataTypes.User CreateUser(string alias);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/CreateUser", ReplyAction="http://tempuri.org/IChatRoomsService/CreateUserResponse")]
        System.Threading.Tasks.Task<ChatRoomsDataTypes.User> CreateUserAsync(string alias);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/CreateRoom", ReplyAction="http://tempuri.org/IChatRoomsService/CreateRoomResponse")]
        ChatRoomsDataTypes.Room CreateRoom(ChatRoomsDataTypes.User user, string name, System.Collections.Generic.List<ChatRoomsDataTypes.User> participants);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/CreateRoom", ReplyAction="http://tempuri.org/IChatRoomsService/CreateRoomResponse")]
        System.Threading.Tasks.Task<ChatRoomsDataTypes.Room> CreateRoomAsync(ChatRoomsDataTypes.User user, string name, System.Collections.Generic.List<ChatRoomsDataTypes.User> participants);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/InviteUsers", ReplyAction="http://tempuri.org/IChatRoomsService/InviteUsersResponse")]
        void InviteUsers(ChatRoomsDataTypes.User user, ChatRoomsDataTypes.Room room, System.Collections.Generic.List<ChatRoomsDataTypes.User> users);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/InviteUsers", ReplyAction="http://tempuri.org/IChatRoomsService/InviteUsersResponse")]
        System.Threading.Tasks.Task InviteUsersAsync(ChatRoomsDataTypes.User user, ChatRoomsDataTypes.Room room, System.Collections.Generic.List<ChatRoomsDataTypes.User> users);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/PostMessage", ReplyAction="http://tempuri.org/IChatRoomsService/PostMessageResponse")]
        void PostMessage(ChatRoomsDataTypes.User user, ChatRoomsDataTypes.Room room, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatRoomsService/PostMessage", ReplyAction="http://tempuri.org/IChatRoomsService/PostMessageResponse")]
        System.Threading.Tasks.Task PostMessageAsync(ChatRoomsDataTypes.User user, ChatRoomsDataTypes.Room room, string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatRoomsServiceChannel : ChatRoomsClient.ChatRoomsService.IChatRoomsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatRoomsServiceClient : System.ServiceModel.ClientBase<ChatRoomsClient.ChatRoomsService.IChatRoomsService>, ChatRoomsClient.ChatRoomsService.IChatRoomsService {
        
        public ChatRoomsServiceClient() {
        }
        
        public ChatRoomsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChatRoomsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatRoomsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatRoomsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<ChatRoomsDataTypes.User> AllUsers() {
            return base.Channel.AllUsers();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<ChatRoomsDataTypes.User>> AllUsersAsync() {
            return base.Channel.AllUsersAsync();
        }
        
        public System.Collections.Generic.List<ChatRoomsDataTypes.Room> AllRooms() {
            return base.Channel.AllRooms();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<ChatRoomsDataTypes.Room>> AllRoomsAsync() {
            return base.Channel.AllRoomsAsync();
        }
        
        public ChatRoomsDataTypes.User CreateUser(string alias) {
            return base.Channel.CreateUser(alias);
        }
        
        public System.Threading.Tasks.Task<ChatRoomsDataTypes.User> CreateUserAsync(string alias) {
            return base.Channel.CreateUserAsync(alias);
        }
        
        public ChatRoomsDataTypes.Room CreateRoom(ChatRoomsDataTypes.User user, string name, System.Collections.Generic.List<ChatRoomsDataTypes.User> participants) {
            return base.Channel.CreateRoom(user, name, participants);
        }
        
        public System.Threading.Tasks.Task<ChatRoomsDataTypes.Room> CreateRoomAsync(ChatRoomsDataTypes.User user, string name, System.Collections.Generic.List<ChatRoomsDataTypes.User> participants) {
            return base.Channel.CreateRoomAsync(user, name, participants);
        }
        
        public void InviteUsers(ChatRoomsDataTypes.User user, ChatRoomsDataTypes.Room room, System.Collections.Generic.List<ChatRoomsDataTypes.User> users) {
            base.Channel.InviteUsers(user, room, users);
        }
        
        public System.Threading.Tasks.Task InviteUsersAsync(ChatRoomsDataTypes.User user, ChatRoomsDataTypes.Room room, System.Collections.Generic.List<ChatRoomsDataTypes.User> users) {
            return base.Channel.InviteUsersAsync(user, room, users);
        }
        
        public void PostMessage(ChatRoomsDataTypes.User user, ChatRoomsDataTypes.Room room, string message) {
            base.Channel.PostMessage(user, room, message);
        }
        
        public System.Threading.Tasks.Task PostMessageAsync(ChatRoomsDataTypes.User user, ChatRoomsDataTypes.Room room, string message) {
            return base.Channel.PostMessageAsync(user, room, message);
        }
    }
}
