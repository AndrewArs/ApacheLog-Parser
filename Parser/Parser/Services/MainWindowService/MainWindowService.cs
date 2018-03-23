using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using Services.GeolocationService;
using Services.ParserService;

namespace Services.MainWindowService
{
    public class MainWindowService : IMainWindowService
    {
        private readonly IGeolocationService _geolocationService;

        private readonly IParserService _parserService;

        private readonly ILogRepository _logRepository;

        public MainWindowService(IGeolocationService geolocationService, IParserService parserService,
            ILogRepository logRepository)
        {
            _geolocationService = geolocationService;
            _parserService = parserService;
            _logRepository = logRepository;
        }

        /// <summary>
        /// Parses the specified data path.
        /// </summary>
        /// <param name="dataPath">The data path.</param>
        /// <returns></returns>
        public async Task<bool> Parse(string dataPath)
        {
            using (var mmFile = MemoryMappedFile.CreateFromFile(dataPath))
            {
                var mmvStream = mmFile.CreateViewStream();

                using (var sr = new StreamReader(mmvStream, Encoding.ASCII))
                {
                    while (!sr.EndOfStream)
                    {
                        var logString = sr.ReadLine();
                        var log = _parserService.Parse(logString);

                        if (log == null)
                        {
                            continue;
                        }

                        log.Geolocation = await _geolocationService.GetGeolocation(log.Host);
                        _logRepository.Add(log);
                    }
                }
            }

            _logRepository.SaveChanges();
            
            return true;
        }
    }
}