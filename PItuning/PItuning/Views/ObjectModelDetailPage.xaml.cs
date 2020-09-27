using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PItuning.Models;
using PItuning.ViewModels;

namespace PItuning.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObjectModelDetailPage : ContentPage
    {
        ObjectModelDetailViewModel viewModel;

        public ObjectModelDetailPage(ObjectModelDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ObjectModelDetailPage()
        {
            InitializeComponent();

            var ObjectModel = new ObjectModel
            {
                TagName = "ObjectModel 1",
                Description = "This is an ObjectModel description."
            };

            viewModel = new ObjectModelDetailViewModel(ObjectModel);
            BindingContext = viewModel;
        }
    }
}