using LogParserWebApi.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace LogParserWebApi.Services.Services.ParseService
{
    public class ParserService : IParserService
    {
        private readonly string[] _ignorePaths = { ".css", ".js",
            ".jpg", ".gif", ".eps", ".bmp", ".JPG", ".jpeg", ".xbm", ".GIF" };
        private readonly Regex _regex;

        public List<string> Extensions { get; set; } = new List<string>();

        public ParserService()
        {
            _regex = new Regex(@"(?<host>[^ ]*) - - " +
                @"\[(?<date>[^ ]* [^ ]*)\] " +
                @"""(?<request_method>[^ ]*) (?<path>[^ ]*) [^ ]*"" " +
                @"(?<status>[^ ]*) (?<length>[^ ]*)", RegexOptions.Compiled);
        }

        public Log Parse(string input)
        {
            var match = _regex.Match(input);

            if (!match.Success)
            {
                return null;
            }

            var splitedPath = match.Groups["path"].Value.Split('?');

            if (_ignorePaths.Any(forbidden => splitedPath[0].EndsWith(forbidden)))
            {
                return null;
            }

            var res = new Log
            {
                Host = match.Groups["host"].Value,
                Date = DateTime.ParseExact(match.Groups["date"].Value,
                    "dd/MMM/yyyy:HH:mm:ss zzz",
                    CultureInfo.InvariantCulture),
                Route = splitedPath[0],
                StatusCode = int.Parse(match.Groups["status"].Value),
                Method = match.Groups["request_method"].Value
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
    }
}
