using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;
using XAFSaveImageToDB.Module.Helpers;

namespace XAFSaveImageToDB.Module.BusinessObjects
{
    [DefaultClassOptions]
    [FileAttachment("File")]
    [RuleCriteria("RuleCriteria for ImageStoreObjectDemo", DefaultContexts.Save, nameof(ImageEkstentionValidation), CustomMessageTemplate = "Attachment Only Allowed (*.jpg, *.jpeg, *.png) file")]
    [RuleCriteria("RuleCriteria for ImageStoreObjectDemo1", DefaultContexts.Save, nameof(ImageSizeValidation), CustomMessageTemplate = "Attachment Size Should be lower than 2 MB")]
    public class ImageStoreObjectDemo : BaseObject
    {
        public ImageStoreObjectDemo(Session session) : base(session) { }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool IsNewObject
        {
            get { return Session.IsNewObject(this); }
        }
        private bool ImageEkstentionValidation
        {
            get
            {
                if (File != null && !string.IsNullOrEmpty(File.FileName))
                {
                    var fileName = File.FileName;
                    if (!fileName.Contains(".jpg") && !fileName.Contains(".jpeg") && !fileName.Contains(".png"))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private bool ImageSizeValidation
        {
            get
            {
                if (File != null && !string.IsNullOrEmpty(File.FileName))
                {
                    if (File.Size > 10000000) // 10 MB
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never), ImmediatePostData]
        public FileSystemStoreObject File
        {
            get { return GetPropertyValue<FileSystemStoreObject>("File"); }
            set { SetPropertyValue<FileSystemStoreObject>("File", value); }
        }

        [NonPersistent]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        public byte[] ImagePreview
        {
            get
            {
                if (File != null)
                {
                    if (File.FileName != null)
                    {
                        var fileAttachment = AttachmentHelper.GetAttachment(File.Oid);
                        if (fileAttachment != null)
                        {
                            return fileAttachment.Varbinary;
                        }
                    }
                }
                return new byte[1];
            }
        }
    }
}
