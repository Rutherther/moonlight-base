using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Moonlight;
using Moonlight.Core;
using Moonlight.Local.Extensions;
using Moonlight.Translation;
using MoonlightBaseWPF.Extensions;
using MoonlightBaseWPF.ViewModels;

namespace MoonlightBaseWPF
{
    public partial class App : IServiceConfiguration
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try // prevent whole process crash on exception
            {
                AppConfig config = new AppConfig
                {
                    Configuration = (App)App.Current
                };

                MoonlightAPI api = new MoonlightAPI(config)
                {
                    Language = Language.CZ
                };

#if DEBUG
                api.AllocConsole();
#endif

                api.DeferPackets(); // handle packets in separate thread to prevent slowing down NosTale
                                    // this is useful if you don't need to modify or cancel packets...
                                    // and if you don't need 'to send packets at precise time right after particular packet etc.
                                    // to disable this use api.SyncPackets(); that is the default behavior

                api.CreateLocalClient(); // creates local client so it will be middleware for real game packet send/receive

                MoonlightMainWindow nosDamage = new MoonlightMainWindow
                {
                    DataContext = api.Services.GetService<MoonlightMainViewModel>()
                };

                nosDamage.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ConfigureServices(MoonlightAPI api, IServiceCollection services)
        {
            services.AddSingleton(api);

            services.AddServices();
            services.AddViewModels();
        }
    }
}
