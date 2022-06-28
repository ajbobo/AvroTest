using System;
using System.IO;
using Avro.IO;
using Avro.Specific;

namespace AvroTest
{
    class Serializer<T> where T : ISpecificRecord, new()
    {
        public string Serialize(T obj)
        {
            string base64;
            using (var stream = new MemoryStream())
            {
                SpecificDatumWriter<T> serializer = new SpecificDatumWriter<T>(obj.Schema);
                BinaryEncoder encoder = new BinaryEncoder(stream);
                serializer.Write(obj, encoder);
                base64 = Convert.ToBase64String(stream.ToArray());
            }
            return base64;
        }

        public T DeserializeString(string str)
        {
            byte[] data = Convert.FromBase64String(str);
            using (var stream = new MemoryStream(data))
            {
                T res = new T();
                SpecificDatumReader<T> deserializer = new SpecificDatumReader<T>(res.Schema, res.Schema);
                BinaryDecoder decoder = new BinaryDecoder(stream);
                deserializer.Read(res, decoder);
                return res;
            }
        }
    }
}
