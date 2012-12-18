using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AuLicCore
{
    [Serializable()]
    public class SerializableFilenamesSaver
    {
        const string FILENAME = "filenames.bin";

        public SerializableFilenamesSaver()
        {
            if (File.Exists(FILENAME))
            {
                SerializableFilenamesSaver tempSaver = deserialize();
                this.members = tempSaver.members;
            }
            else
                this.members = new List<string>();
        }

        List<string> members;
        public List<string> Members
        {
            get
            {
                return this.members;
            }
        }

        public void Add(string s)
        {
            if (!members.Contains(s))
            {
                this.members.Add(s);
                serialize(this);
            }
        }

        public void Remove(string s)
        {
            if (members.Contains(s))
            {
                this.members.Remove(s);
                serialize(this);
            }
        }

        public static void serialize(SerializableFilenamesSaver data)
        {
            FileStream stream = File.Create(FILENAME);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, data);
            stream.Close();
        }

        public static SerializableFilenamesSaver deserialize()
        {
            SerializableFilenamesSaver result;
            FileStream stream = File.OpenRead(FILENAME);
            BinaryFormatter deserializer = new BinaryFormatter();
            result = (SerializableFilenamesSaver)deserializer.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
