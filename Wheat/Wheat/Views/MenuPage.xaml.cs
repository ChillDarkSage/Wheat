using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheat.Models;
using Wheat.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wheat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public DishViewModel DishViewModel { get; set; }
        public MenuPage(DishViewModel dishViewModel)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.DishViewModel = dishViewModel;
            this.BindingContext = DishViewModel;
        }

        private void AddDish(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Views.AddDish() { BindingContext = DishViewModel });
            labelWelcome.IsVisible = false;
        }

        private void EditDish(object sender, EventArgs e)
        {
            Button button = sender as Button;
            DishModel dishToEdit = button.CommandParameter as DishModel;
            PopupNavigation.Instance.PushAsync(new Views.EditDish(dishToEdit) { BindingContext = DishViewModel });
        }
    }
}