using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using ProtoBuf;

namespace Dapr.Grpc
{
    public static class ProtobufHelper
    {
        public static ByteString Serialize<T>(T value)
        {
            using var mem = new MemoryStream();
            Serializer.Serialize(mem, value);
            return ByteString.FromStream(mem);
        }

        public static T Deserialize<T>(ByteString byteString)
        {
            using var mem = new MemoryStream(byteString.ToArray());
            return Serializer.Deserialize<T>(mem);
        }

        public static ExchangeData ConvertoHello<T>(T value)
        {
            var data = new ExchangeData();
            data.Value = Serialize(value);
            return data;
        }

        public static T UnpackHello<T>(Any any)
        {
            var data = any.Unpack<ExchangeData>();
            return Deserialize<T>(data.Value);
        }

        public static Any PackHello<T>(T value)
        {
            using var mem = new MemoryStream();
            Serializer.Serialize(mem, value);
            var data = new ExchangeData { Value = ByteString.FromStream(mem) };
            return Any.Pack(data);
        }
    }
}