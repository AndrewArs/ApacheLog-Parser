using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using Microsoft.Win32;
using Parser.Core;
using Parser.ViewModels.Core;
using Services.MainWindowService;

namespace Parser.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IMainWindowService _mainWindowService;
        
        public MainWindowViewModel()
        {
            _mainWindowService = App.AppContainer.Resolve<IMainWindowService>();
        }

        public string FilePath { get; set; }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        /// <summary>
        /// Gets the parse command.
        /// </summary>
        /// <value>
        /// The parse command.
        /// </value>
        public ICommand ParseCommand { get { return new RelayCommand(async param => await Parse()); } }
        /// <summary>
        /// Gets the get file command.
        /// </summary>
        /// <value>
        /// The get file command.
        /// </value>
        public ICommand GetFileCommand { get { return new RelayCommand(param => GetFile()); } }

        /// <summary>
        /// Parses the file.
        /// </summary>
        /// <returns></returns>
        private async Task Parse()
        {
            await _mainWindowService.Parse(FilePath);
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        private void GetFile()
        {
            var ofd = new OpenFileDialog { Multiselect = false };
            ofd.ShowDialog();
            FilePath = ofd.FileName;

            IsEnabled = true;
        }
    }
}
