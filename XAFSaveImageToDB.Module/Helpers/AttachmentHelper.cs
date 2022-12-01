using ClassLibrary1;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XAFSaveImageToDB.Module.Helpers
{
    public static class AttachmentHelper
    {
        // I have tried to set attachment DB unit of work to singleton service, but the value always change in XAF.
        // so I quess this is a best solusion by passing uow on static field that initialized on main method
        public static UnitOfWork _uow;

        public static FileAttachment InsertAttachment(Guid id, string fileName, Stream file)
        {
            FileAttachment fileAttachment = _uow.FindObject<FileAttachment>(new BinaryOperator("Id", id));
            if (fileAttachment == null)
            {
                fileAttachment = new FileAttachment(_uow);
                fileAttachment.Id = id;
            }
            fileAttachment.LoadFromStream(fileName, file);
            _uow.CommitChanges();
            return fileAttachment;
        }
        public static FileAttachment GetAttachment(Guid id)
        {
            FileAttachment fileAttachment = _uow.FindObject<FileAttachment>(new BinaryOperator("Id", id));
            return fileAttachment;
        }
        public static void DeleteAttachment(Guid id)
        {
            var fileAttachment = _uow.FindObject<FileAttachment>(new BinaryOperator("Id", id));
            if (fileAttachment != null)
            {
                fileAttachment.Delete();
                _uow.CommitChanges();
            }
        }
    }
}
