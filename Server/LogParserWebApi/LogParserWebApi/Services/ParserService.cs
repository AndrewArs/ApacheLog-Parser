using LogParserWebApi.DomainModels;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LogParserWebApi.Services
{
    public class ParserService : IParserService
    {
        private readonly string[] _ignorePaths = { ".css", ".js", ".jpg", ".gif" };
        private Regex _regex;

        public ParserService()
        {
            _regex = new Regex(@"(?<host>\S+) - - " +
                @"\[(?<date>\S+ \S+)\] " +
                @"""(?<request_method>\S+) (?<path>\S+) (?<request_version>HTTP/.*)"" " +
                @"(?<status>\S+) (?<length>\S+)", RegexOptions.Compiled);
        }

        public Log Parse(string input)
        {
            var match = _regex.Match(input);

            if (match.Success)
            {
                var splitedPath = match.Groups["path"].Value.Split('?');

                foreach (var forbidden in _ignorePaths)
                {
                    if (splitedPath[0].Contains(forbidden))
                    {
                        return null;
                    }
                }

                var res = new Log
                {
                    Host = match.Groups["host"].Value,
                    Date = DateTime.ParseExact(match.Groups["date"].Value,
                    "dd/MMM/yyyy:HH:mm:ss zzz",
                    CultureInfo.InvariantCulture),
                    Route = splitedPath[0],
                    StatusCode = int.Parse(match.Groups["status"].Value),
                    Method = match.Groups["request_method"].Value,
                    HttpVersion = match.Groups["request_version"].Value
                };

                if (int.TryParse(match.Groups["length"].Value, out var length))
                {
                    res.Length = length;
                }

                if (splitedPath.Length > 1)
                {
                    res.UrlQueryParameters = splitedPath[1];
                }

                return res;
            }

            return null;
        }
    }
}
