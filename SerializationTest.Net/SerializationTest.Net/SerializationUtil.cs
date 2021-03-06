using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SerializationTest.Net
{
    public class SerializationUtil
    {
        public static Stream Serialize<T>(T source)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            Stream stream = new MemoryStream();
            serializer.WriteObject(stream, source);
            return stream;
        }

        public static T Deserialize<T>(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            stream.Position = 0;
            return (T)serializer.ReadObject(stream);
        }

        public static T Clone<T>(T source)
        {
            return Deserialize<T>(Serialize<T>(source));
        }

    }

    internal static class StreamExtensions
    {
        internal static string ContentToString(this Stream stream)
        {
            stream.Position = 0;
            return new StreamReader(stream, Encoding.ASCII).ReadToEnd();
        }
    }
}