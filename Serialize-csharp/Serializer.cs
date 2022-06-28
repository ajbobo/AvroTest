using Microsoft.Hadoop.Avro;
using System;
using System.IO;

namespace AvroTest
{
    class Serializer<T>
    {
        private IAvroSerializer<T> _avroSerializer;

        public Serializer()
        {
            _avroSerializer = AvroSerializer.Create<T>();
        }

        public string Serialize(T obj)
        {
            string base64;
            using (var stream = new MemoryStream())
            {
                var binary = new BinaryWriter(stream);
                _avroSerializer.Serialize(stream, obj);
                base64 = Convert.ToBase64String(stream.ToArray());
            }
            return base64;
        }

        public T DeserializeString(string str) // This is not the method that Findmatch uses - That uses the apache.avro library instead
        {
            byte[] data = Convert.FromBase64String(str);
            using (var stream = new MemoryStream(data))
            {
                var reader = new BinaryReader(stream);
                return _avroSerializer.Deserialize(stream);
            }
        }
    }
}
