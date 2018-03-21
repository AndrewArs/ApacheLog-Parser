using LogParserWebApi.DomainModels.Models;

namespace LogParserWebApi.Services.Services.ParseService
{
    public interface IParserService
    {
        Log Parse(string input);
    }
}
