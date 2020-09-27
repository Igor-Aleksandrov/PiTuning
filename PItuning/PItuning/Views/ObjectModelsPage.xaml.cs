﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PItuning.Models;
using PItuning.Views;
using PItuning.ViewModels;

namespace PItuning.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObjectModelsPage : ContentPage
    {
        ObjectModelsViewModel viewModel;

        public ObjectModelsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ObjectModelsViewModel();
        }

        async void OnObjectModelSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var ObjectModel = args.SelectedItem as ObjectModel;
            if (ObjectModel == null)
                return;

            await Navigation.PushAsync(new ObjectModelDetailPage(new ObjectModelDetailViewModel(ObjectModel)));

            // Manually deselect ObjectModel.
            ObjectModelsListView.SelectedItem = null;
        }

        async void AddObjectModel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewObjectModelPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ObjectModels.Count == 0)
                viewModel.LoadObjectModelsCommand.Execute(null);
        }
    }
}