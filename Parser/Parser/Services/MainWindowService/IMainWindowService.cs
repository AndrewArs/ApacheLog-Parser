using System.Threading.Tasks;

namespace Services.MainWindowService
{
    public interface IMainWindowService
    {
        Task Parse(string dataPath);
    }
}