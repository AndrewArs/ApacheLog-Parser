using DomainModels.Models;

namespace Services.ParserService
{
    public interface IParserService
    {
        Log Parse(string input);
    }
}