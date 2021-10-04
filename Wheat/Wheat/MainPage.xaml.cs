using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Wheat.Models;
using Wheat.ViewModel;
using Wheat.Views;
using Xamarin.Forms;

namespace Wheat
{
    public partial class MainPage : ContentPage
    {
        public DishViewModel DishViewModel { set; get; }
        public  MainPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                new Page().DisplayAlert("ex", ex.Message, "OK.");
            }
            NavigationPage.SetHasNavigationBar(this, false);
                DishViewModel = new DishViewModel();
                this.BindingContext = DishViewModel;
        }


        private void ChangePage(object sender, EventArgs e)
        {
            if (DishViewModel.DishModels.Count != 0)
                Navigation.PushAsync(new RandomDishPage(DishViewModel));
            else
                Navigation.PushAsync(new MenuPage(DishViewModel));
        }
    }
}
