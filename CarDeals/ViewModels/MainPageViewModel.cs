using CarDeals.Models;
using CarDeals.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarDeals.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        private VehicleService _vehicleService;

        readonly INavigationService _navigationService;

        public string Name { get; set; }
        private Vehicle _vehicle;
        public Vehicle Vehicle
        {
            get { return _vehicle; }
            set { SetProperty(ref _vehicle, value); }
        }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICommand GetVehiclesCommand { get; set; }
        public DelegateCommand<Vehicle> ItemSelectedCommand => new DelegateCommand<Vehicle>(OnItemSelectedCommand);
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _vehicleService = new VehicleService(ApiConstants.BASE_URL);
            GetVehiclesCommand = new Command(async () => await GetVehicles());
            Title = "Cars";
        }

        // sending parameter on navigatin
        private async void OnItemSelectedCommand(Vehicle senditem)
        {
            var parameter = new NavigationParameters();
            parameter.Add("item", senditem);

            await _navigationService.NavigateAsync("Detail", parameter);
        }

        private async Task GetVehicles()
        {
            var vehicles = await _vehicleService.GetVehicles();
            Vehicles = vehicles;
        }
    }
}
