using SwiftparserData.Models;

namespace SwiftparserData.Repositories
{
    public interface ISwiftMessageRepository
    {
        Task InsertSwiftMessage(SwiftMessage message);
    }
}