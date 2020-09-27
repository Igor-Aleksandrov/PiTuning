using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PItuning.Models;

namespace PItuning.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewObjectModelPage : ContentPage
    {
        public ObjectModel ObjectModel { get; set; }

        public NewObjectModelPage()
        {
            InitializeComponent();

            ObjectModel = new ObjectModel
            {
                TagName = "Controller name",
                Description = "This is a controller description.",
                Gp = 1.1,
                Dt = 13,
                Tau1 = 120,
                Tau2 = 0,
                Beta = 0
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddObjectModel", ObjectModel);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}