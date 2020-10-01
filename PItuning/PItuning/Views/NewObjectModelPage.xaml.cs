using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PItuning.Models;
using PItuning.ViewModels;
using System.Diagnostics;

namespace PItuning.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewObjectModelPage : ContentPage
    {
        public NewObjectModelViewModel NewViewModel { get; private set; }
        public NewObjectModelPage(NewObjectModelViewModel vm)
        {
            InitializeComponent();
            NewViewModel = vm;
            this.BindingContext = NewViewModel;
        }
    }
}