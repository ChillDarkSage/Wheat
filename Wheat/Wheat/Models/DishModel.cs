using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wheat.Models
{
    public class DishModel : ViewModelBase
    {
        private string name;

        private string price;

        private string place;

        private string taste;

        private bool isNonStapleFood;

        public DishModel(string name, string price, string place, string taste, bool isNonStapleFood = false)
        {
            Name = name;
            Price = price;
            Place = place;
            Taste = taste;
            IsNonStapleFood = isNonStapleFood;
        }

        public static DishModel Clone(DishModel dishModel)
        {
            DishModel newDishModel = 
                new DishModel(dishModel.name, dishModel.price, dishModel.place, dishModel.taste, dishModel.isNonStapleFood);
            return newDishModel;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        public string Price
        {
            get => price;

            set 
            {
                price = value;
                RaisePropertyChanged();
            }
        }


        public string Taste
        {
            set
            {
                taste = value;
                RaisePropertyChanged();

            }
            get => taste;
        }

        public string Place
        {
            set
            {
                place = value;
                RaisePropertyChanged();

            }
            get => place;
        }

        public bool IsNonStapleFood
        {
            set
            {
                isNonStapleFood = value;
                RaisePropertyChanged();
            }
            get => isNonStapleFood;
        }
    }
}