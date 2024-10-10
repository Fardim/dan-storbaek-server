using dan_storbaek_server.Domains;

namespace dan_storbaek_server.Services
{
    public interface IBinaryStringService
    {
        BinaryStringStatus Analyze(string data);
    }
}
