using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;
using WeatherAPP.Services.AccuWeather.Models;
using WeatherAPP.ViewModels.Views;
using WeatherAPP.Views;

namespace WeatherAPP
{
    public partial class App : Application
    {
        #region FIELDS

        private IServiceProvider _serviceProvider;

        #endregion



        #region CONSTRUCTORS

        public App()
        {
            // Config build
            IConfigurationSource accuweatherConfig = new JsonConfigurationSource()
            {
                Path = "Config/accuweather.json"
            };

            IConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.Add(accuweatherConfig);

            IConfiguration config = configBuilder.Build();


            // Services build
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton(config);
            services.AddSingleton<AccuWeatherConfiguration>();

            services.AddSingleton<IAccuWeatherService, AccuWeatherService>();

            services.AddSingleton<MainWindowVM>();

            services.AddTransient<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        #endregion
    }
}
