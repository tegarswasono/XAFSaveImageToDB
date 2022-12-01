using DevExpress.Xpo;
using System;
using System.IO;

namespace ClassLibrary1
{
    public class FileAttachment : XPLiteObject
    {
        public FileAttachment(Session session) : base(session) { }
        private Guid _id;
        private string _fileName;
        private string _desc;

        [Key(true)]
        public Guid Id
        {
            get { return _id; }
            set { SetPropertyValue(nameof(Id), ref _id, value); }
        }
        public string FileName
        {
            get { return _fileName; }
            set { SetPropertyValue(nameof(FileName), ref _fileName, value); }
        }
        public byte[] Varbinary
        {
            get { return GetPropertyValue<byte[]>(nameof(Varbinary)); }
            set { SetPropertyValue<byte[]>(nameof(Varbinary), value); }
        }
        public string Desc
        {
            get { return _desc; }
            set { SetPropertyValue(nameof(Desc), ref _desc, value); }
        }
        //untuk kirim
        public void LoadFromStream(string fileName, Stream stream)
        {
            FileName = fileName;
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            Varbinary = bytes;
        }
        //untuk tarik
        public void SaveToStream(Stream stream)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                throw new InvalidOperationException();
            }
            stream.Write(Varbinary, 0, Varbinary.Length);
            stream.Flush();
        }
    }
}
