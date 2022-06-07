 using System.Runtime.Serialization.Formatters.Binary;
 using System.IO;
namespace Hekki
{
    class Deep 
    {
        public static T DeepCopys<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}