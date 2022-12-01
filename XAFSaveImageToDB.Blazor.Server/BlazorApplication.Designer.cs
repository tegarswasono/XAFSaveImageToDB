namespace XAFSaveImageToDB.Blazor.Server {
    partial class XAFSaveImageToDBBlazorApplication {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Blazor.SystemModule.SystemBlazorModule();
            this.module3 = new XAFSaveImageToDB.Module.XAFSaveImageToDBModule();
            this.module4 = new XAFSaveImageToDB.Module.Blazor.XAFSaveImageToDBBlazorModule();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.auditTrailModule = new DevExpress.ExpressApp.AuditTrail.AuditTrailModule();
            this.cloneObjectModule = new DevExpress.ExpressApp.CloneObject.CloneObjectModule();
            this.conditionalAppearanceModule = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
            this.fileAttachmentsBlazorModule = new DevExpress.ExpressApp.FileAttachments.Blazor.FileAttachmentsBlazorModule();
            this.validationModule = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.validationBlazorModule = new DevExpress.ExpressApp.Validation.Blazor.ValidationBlazorModule();
            this.viewVariantsModule = new DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule();

            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();

            //
            // auditTrailModule
            //
            this.auditTrailModule.AuditDataItemPersistentType = typeof(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent);
            //
            // validationModule
            //
            this.validationModule.AllowValidationDetailsAccess = false;
            // 
            // XAFSaveImageToDBBlazorApplication
            // 
            this.ApplicationName = "XAFSaveImageToDB";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module3);
            this.Modules.Add(this.module4);
            this.Modules.Add(this.securityModule1);
            this.Modules.Add(this.auditTrailModule);
            this.Modules.Add(this.cloneObjectModule);
            this.Modules.Add(this.conditionalAppearanceModule);
            this.Modules.Add(this.fileAttachmentsBlazorModule);
            this.Modules.Add(this.validationModule);
            this.Modules.Add(this.validationBlazorModule);
            this.Modules.Add(this.viewVariantsModule);
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.XAFSaveImageToDBBlazorApplication_DatabaseVersionMismatch);

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Blazor.SystemModule.SystemBlazorModule module2;
        private XAFSaveImageToDB.Module.XAFSaveImageToDBModule module3;
        private XAFSaveImageToDB.Module.Blazor.XAFSaveImageToDBBlazorModule module4;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
        private DevExpress.ExpressApp.AuditTrail.AuditTrailModule auditTrailModule;
        private DevExpress.ExpressApp.CloneObject.CloneObjectModule cloneObjectModule;
        private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule;
        private DevExpress.ExpressApp.FileAttachments.Blazor.FileAttachmentsBlazorModule fileAttachmentsBlazorModule;
        private DevExpress.ExpressApp.Validation.ValidationModule validationModule;
        private DevExpress.ExpressApp.Validation.Blazor.ValidationBlazorModule validationBlazorModule;
        private DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule viewVariantsModule;
    }
}
