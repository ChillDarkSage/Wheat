using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Wheat.Models;
using Wheat.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wheat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDish : PopupPage
    {
        public DishModel DishToAdd { set; get; } = new DishModel(null, null, null, null);

        public AddDish()
        {
            InitializeComponent();
            SetBinding();
        }

        private void SetBinding()
        {
            entryName.SetBinding(Entry.TextProperty, new Binding("Name") { Source = DishToAdd, Mode = BindingMode.OneWayToSource });
            entryPrice.SetBinding(Entry.TextProperty, new Binding("Price") { Source = DishToAdd, Mode = BindingMode.OneWayToSource });
            entryPlace.SetBinding(Entry.TextProperty, new Binding("Place") { Source = DishToAdd, Mode = BindingMode.OneWayToSource });
            entryTaste.SetBinding(Entry.TextProperty, new Binding("Taste") { Source = DishToAdd, Mode = BindingMode.OneWayToSource });
            checkBoxIsNonStapleFood.SetBinding(CheckBox.IsCheckedProperty, new Binding("IsNonStapleFood") { Source = DishToAdd, Mode = BindingMode.OneWayToSource });
        }
    }
}