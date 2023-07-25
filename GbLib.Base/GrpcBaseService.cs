using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;

namespace GbLib.GrpcBaseService
{
    public abstract class GrpcBaseService<T> where T : class
    {
        public readonly ILogger<GrpcBaseService<T>> _logger;
        private T _client;
        public T Client { get => _client ?? (_client = GrpcChannel.ForAddress(ServerAddress).CreateGrpcService<T>()); }
        public abstract string ServerAddress { get; }

        public GrpcBaseService(ILogger<GrpcBaseService<T>> logger)
        {
            _logger = logger;
        }
    }
}