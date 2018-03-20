using LogParserWebApi.DomainModels;

namespace LogParserWebApi.Services
{
    public interface IParserService
    {
        Log Parse(string input);
    }
}
