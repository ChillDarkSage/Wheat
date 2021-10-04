using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Wheat.Models;

namespace Wheat.ViewModel
{
    public class DishViewModel : ViewModelBase
    {
        private ObservableCollection<DishModel> dishModels;

        public RelayCommand<DishModel> AddCommand { get; private set; }
        public RelayCommand<DishModel> DelCommand { get; private set; }
        public RelayCommand ClearCommand { get; private set; }
        public RelayCommand<DishModel[]> EditCommand { get; private set;  }

        public ObservableCollection<DishModel> DishModels
        {
            get => dishModels;
            set
            {
                dishModels = value;
                RaisePropertyChanged();
            }
        }

        public DishViewModel()
        {
            dishModels = XMLIO.ReadAllDish();

            AddCommand = new RelayCommand<DishModel>(AddDish);
            DelCommand = new RelayCommand<DishModel>(DelDish);
            ClearCommand = new RelayCommand(Clear);
            EditCommand = new RelayCommand<DishModel[]>(EditDish);
        }
        
        public void AddDish(DishModel info)
        {
            if (!string.IsNullOrWhiteSpace(info.Name) && !string.IsNullOrWhiteSpace(info.Price))
            {
                DishModel dish = new DishModel(info.Name, info.Price, info.Place, info.Taste, info.IsNonStapleFood);
                dishModels.Add(dish);
                XMLIO.AddDish(dish);
            }
            PopupNavigation.Instance.PopAsync();

        }

        public void DelDish(DishModel info)
        {
            dishModels.Remove(info);
            XMLIO.DelDish(info);
        }

        public void Clear()
        {
            dishModels.Clear();
            XMLIO.Clear();
        }
        public void EditDish(DishModel[] infos)
        {
            DishModel oldInfo = infos[0];
            DishModel newInfo = infos[1];
            if (!string.IsNullOrWhiteSpace(newInfo.Name) && !string.IsNullOrWhiteSpace(newInfo.Price))
            {
                DishModel dish = new DishModel(newInfo.Name, newInfo.Price, newInfo.Place, newInfo.Taste, newInfo.IsNonStapleFood);
                dishModels.Remove(dishModels.FirstOrDefault(d =>
                d.Name == oldInfo.Name && d.Price == oldInfo.Price && d.Place == oldInfo.Place && d.Taste == oldInfo.Taste
                ));
                dishModels.Add(dish);
                XMLIO.EditDish(dish, oldInfo);
            }
            PopupNavigation.Instance.PopAsync();
        }
    }
}
