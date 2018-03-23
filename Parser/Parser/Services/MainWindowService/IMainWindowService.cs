using System.Threading.Tasks;

namespace Services.MainWindowService
{
    public interface IMainWindowService
    {
        Task<bool> Parse(string dataPath);
    }
}