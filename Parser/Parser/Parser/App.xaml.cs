using System.Configuration;
using Autofac;
using Infrustructure.AutofacModules;

namespace Parser
{
    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static IContainer AppContainer;

        public App()
        {
            var connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacModules(connection));
            AppContainer = builder.Build();
            
        }
    }
}
