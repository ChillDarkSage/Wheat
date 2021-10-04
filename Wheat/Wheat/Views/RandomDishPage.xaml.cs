using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheat.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wheat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomDishPage : ContentPage
    {
        public RandomDishViewModel RandomDishViewModel { set; get; }

        private DishViewModel DishViewModel {  get; set; }

        public RandomDishPage(DishViewModel dishViewModel)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            RandomDishViewModel = new RandomDishViewModel(dishViewModel);
            this.BindingContext = RandomDishViewModel;
            this.DishViewModel = dishViewModel;
        }
        private void ChangePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.MenuPage(DishViewModel));
        }
    }
}