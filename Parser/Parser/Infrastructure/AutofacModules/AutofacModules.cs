using Autofac;
using DAL.Context;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.GeolocationService;
using Services.MainWindowService;
using Services.ParserService;
using Module = Autofac.Module;

namespace Infrustructure.AutofacModules
{
    public class AutofacModules : Module
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacModules"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public AutofacModules(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <inheritdoc />
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<LogContext>(c =>
                new LogContext(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options));
            builder.RegisterType<LogRepository>().As<ILogRepository>();

            builder.RegisterType<GeolocationService>().As<IGeolocationService>();
            builder.RegisterType<ParserService>().As<IParserService>();
            builder.RegisterType<MainWindowService>().As<IMainWindowService>();
        }
    }
}
