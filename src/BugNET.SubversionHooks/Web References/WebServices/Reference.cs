﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace BugNET.SubversionHooks.WebServices {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BugNetServicesSoap", Namespace="http://bugnetproject.com/")]
    public partial class BugNetServices : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback LogInOperationCompleted;
        
        private System.Threading.SendOrPostCallback LogOutOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateNewIssueRevisionOperationCompleted;
        
        private System.Threading.SendOrPostCallback ChangeTreeNodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback MoveNodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddCategoryOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteCategoryOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BugNetServices() {
            this.Url = global::BugNET.SubversionHooks.Properties.Settings.Default.BugNetServicesUrl;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event LogInCompletedEventHandler LogInCompleted;
        
        /// <remarks/>
        public event LogOutCompletedEventHandler LogOutCompleted;
        
        /// <remarks/>
        public event CreateNewIssueRevisionCompletedEventHandler CreateNewIssueRevisionCompleted;
        
        /// <remarks/>
        public event ChangeTreeNodeCompletedEventHandler ChangeTreeNodeCompleted;
        
        /// <remarks/>
        public event MoveNodeCompletedEventHandler MoveNodeCompleted;
        
        /// <remarks/>
        public event AddCategoryCompletedEventHandler AddCategoryCompleted;
        
        /// <remarks/>
        public event DeleteCategoryCompletedEventHandler DeleteCategoryCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bugnetproject.com/LogIn", RequestNamespace="http://bugnetproject.com/", ResponseNamespace="http://bugnetproject.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool LogIn(string userName, string password) {
            object[] results = this.Invoke("LogIn", new object[] {
                        userName,
                        password});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void LogInAsync(string userName, string password) {
            this.LogInAsync(userName, password, null);
        }
        
        /// <remarks/>
        public void LogInAsync(string userName, string password, object userState) {
            if ((this.LogInOperationCompleted == null)) {
                this.LogInOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogInOperationCompleted);
            }
            this.InvokeAsync("LogIn", new object[] {
                        userName,
                        password}, this.LogInOperationCompleted, userState);
        }
        
        private void OnLogInOperationCompleted(object arg) {
            if ((this.LogInCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LogInCompleted(this, new LogInCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bugnetproject.com/LogOut", RequestNamespace="http://bugnetproject.com/", ResponseNamespace="http://bugnetproject.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void LogOut() {
            this.Invoke("LogOut", new object[0]);
        }
        
        /// <remarks/>
        public void LogOutAsync() {
            this.LogOutAsync(null);
        }
        
        /// <remarks/>
        public void LogOutAsync(object userState) {
            if ((this.LogOutOperationCompleted == null)) {
                this.LogOutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogOutOperationCompleted);
            }
            this.InvokeAsync("LogOut", new object[0], this.LogOutOperationCompleted, userState);
        }
        
        private void OnLogOutOperationCompleted(object arg) {
            if ((this.LogOutCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LogOutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bugnetproject.com/CreateNewIssueRevision", RequestNamespace="http://bugnetproject.com/", ResponseNamespace="http://bugnetproject.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CreateNewIssueRevision(int revision, int issueId, string repository, string revisionAuthor, string revisionDate, string revisionMessage) {
            object[] results = this.Invoke("CreateNewIssueRevision", new object[] {
                        revision,
                        issueId,
                        repository,
                        revisionAuthor,
                        revisionDate,
                        revisionMessage});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CreateNewIssueRevisionAsync(int revision, int issueId, string repository, string revisionAuthor, string revisionDate, string revisionMessage) {
            this.CreateNewIssueRevisionAsync(revision, issueId, repository, revisionAuthor, revisionDate, revisionMessage, null);
        }
        
        /// <remarks/>
        public void CreateNewIssueRevisionAsync(int revision, int issueId, string repository, string revisionAuthor, string revisionDate, string revisionMessage, object userState) {
            if ((this.CreateNewIssueRevisionOperationCompleted == null)) {
                this.CreateNewIssueRevisionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateNewIssueRevisionOperationCompleted);
            }
            this.InvokeAsync("CreateNewIssueRevision", new object[] {
                        revision,
                        issueId,
                        repository,
                        revisionAuthor,
                        revisionDate,
                        revisionMessage}, this.CreateNewIssueRevisionOperationCompleted, userState);
        }
        
        private void OnCreateNewIssueRevisionOperationCompleted(object arg) {
            if ((this.CreateNewIssueRevisionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateNewIssueRevisionCompleted(this, new CreateNewIssueRevisionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bugnetproject.com/ChangeTreeNode", RequestNamespace="http://bugnetproject.com/", ResponseNamespace="http://bugnetproject.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ChangeTreeNode(string nodeId, string newText, string oldText) {
            this.Invoke("ChangeTreeNode", new object[] {
                        nodeId,
                        newText,
                        oldText});
        }
        
        /// <remarks/>
        public void ChangeTreeNodeAsync(string nodeId, string newText, string oldText) {
            this.ChangeTreeNodeAsync(nodeId, newText, oldText, null);
        }
        
        /// <remarks/>
        public void ChangeTreeNodeAsync(string nodeId, string newText, string oldText, object userState) {
            if ((this.ChangeTreeNodeOperationCompleted == null)) {
                this.ChangeTreeNodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChangeTreeNodeOperationCompleted);
            }
            this.InvokeAsync("ChangeTreeNode", new object[] {
                        nodeId,
                        newText,
                        oldText}, this.ChangeTreeNodeOperationCompleted, userState);
        }
        
        private void OnChangeTreeNodeOperationCompleted(object arg) {
            if ((this.ChangeTreeNodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChangeTreeNodeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bugnetproject.com/MoveNode", RequestNamespace="http://bugnetproject.com/", ResponseNamespace="http://bugnetproject.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void MoveNode(string nodeId, string oldParentId, string newParentId, string index) {
            this.Invoke("MoveNode", new object[] {
                        nodeId,
                        oldParentId,
                        newParentId,
                        index});
        }
        
        /// <remarks/>
        public void MoveNodeAsync(string nodeId, string oldParentId, string newParentId, string index) {
            this.MoveNodeAsync(nodeId, oldParentId, newParentId, index, null);
        }
        
        /// <remarks/>
        public void MoveNodeAsync(string nodeId, string oldParentId, string newParentId, string index, object userState) {
            if ((this.MoveNodeOperationCompleted == null)) {
                this.MoveNodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMoveNodeOperationCompleted);
            }
            this.InvokeAsync("MoveNode", new object[] {
                        nodeId,
                        oldParentId,
                        newParentId,
                        index}, this.MoveNodeOperationCompleted, userState);
        }
        
        private void OnMoveNodeOperationCompleted(object arg) {
            if ((this.MoveNodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MoveNodeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bugnetproject.com/AddCategory", RequestNamespace="http://bugnetproject.com/", ResponseNamespace="http://bugnetproject.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int AddCategory(string projectId, string name, string parentCategoryId) {
            object[] results = this.Invoke("AddCategory", new object[] {
                        projectId,
                        name,
                        parentCategoryId});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void AddCategoryAsync(string projectId, string name, string parentCategoryId) {
            this.AddCategoryAsync(projectId, name, parentCategoryId, null);
        }
        
        /// <remarks/>
        public void AddCategoryAsync(string projectId, string name, string parentCategoryId, object userState) {
            if ((this.AddCategoryOperationCompleted == null)) {
                this.AddCategoryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddCategoryOperationCompleted);
            }
            this.InvokeAsync("AddCategory", new object[] {
                        projectId,
                        name,
                        parentCategoryId}, this.AddCategoryOperationCompleted, userState);
        }
        
        private void OnAddCategoryOperationCompleted(object arg) {
            if ((this.AddCategoryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddCategoryCompleted(this, new AddCategoryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bugnetproject.com/DeleteCategory", RequestNamespace="http://bugnetproject.com/", ResponseNamespace="http://bugnetproject.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteCategory(string CategoryId) {
            this.Invoke("DeleteCategory", new object[] {
                        CategoryId});
        }
        
        /// <remarks/>
        public void DeleteCategoryAsync(string CategoryId) {
            this.DeleteCategoryAsync(CategoryId, null);
        }
        
        /// <remarks/>
        public void DeleteCategoryAsync(string CategoryId, object userState) {
            if ((this.DeleteCategoryOperationCompleted == null)) {
                this.DeleteCategoryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteCategoryOperationCompleted);
            }
            this.InvokeAsync("DeleteCategory", new object[] {
                        CategoryId}, this.DeleteCategoryOperationCompleted, userState);
        }
        
        private void OnDeleteCategoryOperationCompleted(object arg) {
            if ((this.DeleteCategoryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteCategoryCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void LogInCompletedEventHandler(object sender, LogInCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LogInCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LogInCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void LogOutCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CreateNewIssueRevisionCompletedEventHandler(object sender, CreateNewIssueRevisionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateNewIssueRevisionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateNewIssueRevisionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ChangeTreeNodeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void MoveNodeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void AddCategoryCompletedEventHandler(object sender, AddCategoryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddCategoryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddCategoryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void DeleteCategoryCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591