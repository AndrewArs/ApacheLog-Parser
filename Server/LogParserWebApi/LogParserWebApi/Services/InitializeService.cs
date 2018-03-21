using System.Diagnostics;
using LogParserWebApi.DAL;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace LogParserWebApi.Services
{
    public class InitializeService : IInitializeService
    {
        private readonly IParserService _parserService;

        private readonly ILogRepository _logRepository;

        private const string DataSource = @"Assets\access";

        public InitializeService(IParserService parserService, ILogRepository logsRepository)
        {
            _parserService = parserService;
            _logRepository = logsRepository;
        }

        public long Initialize()
        {
            var sw = new Stopwatch();
            sw.Start();


            //var logs = File.ReadAllLines(DataSource);
            //foreach (var logStr in logs)
            //{
            //    var log = _parserService.Parse(logStr);

            //    if (log != null)
            //    {
            //        _logRepository.Add(log);
            //    }
            //}


            //using (var mmFile = MemoryMappedFile.CreateFromFile(DataSource))
            //{
            //    var mmvStream = mmFile.CreateViewStream();

            //    using (var sr = new StreamReader(mmvStream, Encoding.ASCII))
            //    {
            //        while (!sr.EndOfStream)
            //        {
            //            var logString = sr.ReadLine();
            //            var log = _parserService.Parse(logString);

            //            if (log != null)
            //            {
            //                _logRepository.Add(log);
            //            }
            //        }
            //    }
            //}


            using (var sr = new StreamReader(DataSource))
            {
                while (!sr.EndOfStream)
                {
                    var logString = sr.ReadLine();
                    var log = _parserService.Parse(logString);

                    if (log != null)
                    {
                        _logRepository.Add(log);
                    }
                }
            }

            return sw.ElapsedMilliseconds;
        }
    }
}
