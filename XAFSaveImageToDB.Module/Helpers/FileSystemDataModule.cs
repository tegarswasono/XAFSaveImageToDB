using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace XAFSaveImageToDB.Module.Helpers
{
    [Description("This module provides the FileSystemStoreObject and FileSystemLinkObject classes that enable you to store uploaded files in a file system instead of the database.")]
    public sealed partial class FileSystemDataModule : ModuleBase
    {
        public static int ReadBytesSize = 0x1000;
        public static string FileSystemStoreLocation = String.Format("{0}FileData", PathHelper.GetApplicationFolder());
        public FileSystemDataModule()
        {
            //InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        public static void CopyFileToStream(Guid id, Stream destination)
        {
            if (destination == null) return;
            var fileAttachment = AttachmentHelper.GetAttachment(id);
            fileAttachment.SaveToStream(destination);
        }
        public static void OpenFileWithDefaultProgram(string sourceFileName)
        {
            Guard.ArgumentNotNullOrEmpty(sourceFileName, "sourceFileName");
            System.Diagnostics.Process.Start(sourceFileName);
        }
        public static void CopyStream(Stream source, Stream destination)
        {
            if (source == null || destination == null) return;
            byte[] buffer = new byte[ReadBytesSize];
            int read = 0;
            while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
                destination.Write(buffer, 0, read);
        }
    }
}
