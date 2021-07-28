using CarDeals.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDeals.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;
        public DelegateCommand GoBackToList { get; set; }
        public DetailViewModel(INavigationService navigationService):base(navigationService)
        {
            _navigationService = navigationService;
            GoBackToList = new DelegateCommand(moveBack);
        }

        //Accepting parameters
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("item"))
            {
                Vehicle = (Vehicle)parameters["item"];
                Vehicle.Id = Vehicle.Id;
                Name = Vehicle.Name;
                Manufacturer = Vehicle.Manufacturer;
                Model = Vehicle.Model;
                Year = Vehicle.Year;
                Colour = Vehicle.Colour;
                Price = Vehicle.Price;
                Descrition = Vehicle.Description;
                DateCreated = Vehicle.DateCreated;


            }
        }

        public void moveBack()
        {
            _navigationService.GoBackAsync();
        }

        private Vehicle _vehicle;
        public Vehicle Vehicle
        {
            get { return _vehicle; }
            set { SetProperty(ref _vehicle, value); }
        }

        public string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _manufacturer;
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { SetProperty(ref _manufacturer, value); }
        }

        private string _model;
        public string Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }

        private int _year;
        public int Year
        {
            get { return _year; }
            set { SetProperty(ref _year, value); }
        }

        private string _colour;
        public string Colour
        {
            get { return _colour; }
            set { SetProperty(ref _colour, value); }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private string _description;
        public string Descrition
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private DateTime _dateCreated;
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { SetProperty(ref _dateCreated, value); }
        }
    }
}
