using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    [Serializable()]
    public abstract class SerializeableClass
    {
        protected string FILEEXTENSION;

        public abstract string FilePath
        {
            get;
        }

        public virtual void Save(string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            FileStream stream = File.Create(filePath);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, this);
            stream.Close();
        }

        public static SerializeableClass Load(string path)
        {
            SerializeableClass result;
            FileStream stream = File.OpenRead(path);
            BinaryFormatter deserializer = new BinaryFormatter();
            result = (SerializeableClass)deserializer.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
