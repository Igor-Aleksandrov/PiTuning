using PItuning.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PItuning.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuObjectModel> menuObjectModels;
        public MenuPage()
        {
            InitializeComponent();

            menuObjectModels = new List<HomeMenuObjectModel>
            {
                new HomeMenuObjectModel {Id = MenuObjectModelType.Controllers, Title="Controllers" },
                new HomeMenuObjectModel {Id = MenuObjectModelType.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuObjectModels;

            ListViewMenu.SelectedItem = menuObjectModels[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuObjectModel)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}