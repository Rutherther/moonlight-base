using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Moonlight;
using Moonlight.Clients;
using MoonlightBaseWPF.Annotations;
using MoonlightBaseWPF.Commands;

namespace MoonlightBaseWPF.ViewModels
{
    public class MoonlightMainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand SendInfoCommand { get; }

        public MoonlightMainViewModel(MoonlightAPI api)
        {
            Client client = api.Client;

            SendInfoCommand = new RelayCommand(() =>
            {
                client.ReceivePacket("info Hello from Moonlight library!"); // receive packet with message
            });
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
