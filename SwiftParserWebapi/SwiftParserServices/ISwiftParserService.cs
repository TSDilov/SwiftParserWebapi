using SwiftparserData.Models;

namespace SwiftParserServices
{
    public interface ISwiftParserService
    {
        Task ParseSwiftMessage(string messageText);
    }
}