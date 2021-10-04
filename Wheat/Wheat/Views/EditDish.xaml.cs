using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheat.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wheat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDish : PopupPage
    {
        public DishModel[] DishesToEdit { set; get; }

        public EditDish(DishModel dishToEdit)
        {
            InitializeComponent();
            DishesToEdit = new DishModel[] { dishToEdit, DishModel.Clone(dishToEdit) };
            SetBinding();
            this.grid.BindingContext = DishesToEdit;
        }

        private void SetBinding()
        {
            entryName.SetBinding(Entry.TextProperty, new Binding("Name") { Source = DishesToEdit[1], Mode = BindingMode.TwoWay });
            entryPrice.SetBinding(Entry.TextProperty, new Binding("Price") { Source = DishesToEdit[1], Mode = BindingMode.TwoWay });
            entryPlace.SetBinding(Entry.TextProperty, new Binding("Place") { Source = DishesToEdit[1], Mode = BindingMode.TwoWay });
            entryTaste.SetBinding(Entry.TextProperty, new Binding("Taste") { Source = DishesToEdit[1], Mode = BindingMode.TwoWay });
            checkBoxIsNonStapleFood.SetBinding(CheckBox.IsCheckedProperty, new Binding("IsNonStapleFood") { Source = DishesToEdit[1], Mode = BindingMode.TwoWay });
        }
    }
}