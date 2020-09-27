﻿using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace PItuning.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://blog.opticontrols.com/site-map")));
        }

        public ICommand OpenWebCommand { get; }
    }
}