using AppCallbackBase = Dapr.AppCallback.Autogen.Grpc.v1.AppCallback.AppCallbackBase;
using Dapr.Client.Autogen.Grpc.v1;
using Grpc.Core;

namespace Dapr.Grpc.Server
{
    public class HelloService : AppCallbackBase
    {
        public override async Task<InvokeResponse> OnInvoke(InvokeRequest request, ServerCallContext context)
        {
            switch (request.Method)
            {
                case "sayhi":
                    var response = new InvokeResponse();
                    //var input = ProtobufHelper.Deserialize<HelloRequest>(request.Data.Value);
                    //response.Data.Value = ProtobufHelper.Serialize(new HelloReply { Message = "ok" });
                    return response;

                default:

                    return await base.OnInvoke(request, context);
            }
        }
    }
}