using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PRBD_Framework;
using MoneyInTheBank.Model;
using System.Windows;

namespace MoneyInTheBank.ViewModel
{
    public class ManagerViewModel: ViewModelCommon
    {
        private ObservableCollection<Agency> _agencies;
        public ObservableCollection<Agency> Agencies
        {
            get => _agencies;
            set => SetProperty(ref _agencies, value);
        }

        private Manager _manager;
        public Manager Manager
        {
            get => _manager;
            set => SetProperty(ref _manager, value);
        }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => SetProperty(ref _clients, value);
        }

        private Agency _agency;
        public Agency SelectedAgency
        {
            get => _agency;
            set => SetProperty(ref _agency, value, () => DisplayClients());
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set => SetProperty(ref _selectedClient, value, () => { DisplayClientProfile(); });
        }
        private void DisplayClients()
        {
            NotifyColleagues(App.Messages.AGENCY_SELECTED, SelectedAgency);
            Clients = new ObservableCollection<Client>(SelectedAgency.GetAllClients());
        }

        public ManagerViewModel()
        {
            Manager = GetCurrentManager();
            if(Manager != null)
            {
                Agencies = new ObservableCollection<Agency>(Manager.GetAllAgencies());
                Register<Client>(App.Messages.CLIENT_UPDATED, client => { DisplayClients(); SelectedClient = null; });
                NewClientCommand = new RelayCommand(CreateNewCommand, CanCreateNewClient);
                Register(App.Messages.ADD_ACCOUNT_TO_USER, () => { SelectedClient = null; DisplayClientProfile(); });
                Register(App.Messages.REMOVE_ACCOUNT_FROM_USER, () => { SelectedClient = null; DisplayClientProfile(); });
            }
        }
        private bool CanCreateNewClient()
        {
            return SelectedAgency != null;
        }
        private void CreateNewCommand()
        {
            SelectedClient = new Client { ClientNumber = "0000" };
            Clients.Add(SelectedClient);
            DisplayClientProfile();
        }
        private void DisplayClientProfile()
        {
            NotifyColleagues(App.Messages.DISPLAY_CLIENT_PROFILE, SelectedClient);
        }

        public ICommand NewClientCommand { get; set; }
    }
}
