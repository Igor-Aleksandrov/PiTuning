using PItuning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PItuning.ViewModels
{
    public class NewObjectModelViewModel : BaseViewModel
    {
        private ObjectModelsViewModel omvm;
        public ObjectModel ObjectModel { get; set; }
        public NewObjectModelViewModel()
        {
            ObjectModel = new ObjectModel
            {
                TagName = "Controller TagName",
                Description = "This is a controller description.",
                Gp = 1.1,
                Dt = 13,
                Tau1 = 120,
                Tau2 = 0,
                Beta = 0
            };

        }
        public ObjectModelsViewModel ListViewModel
        {
            get { return omvm; }
            set { SetProperty(ref omvm, value); }
        }
        string tagName = string.Empty;
        public string TagName
        {
            get { return ObjectModel.TagName; }
            set { if(SetProperty(ref tagName, value)) ObjectModel.TagName = tagName; }
        }
        string description = string.Empty;
        public string Description
        {
            get { return ObjectModel.Description; }
            set { if (SetProperty(ref description, value)) ObjectModel.Description = description; }
        }
        double dt = 0;
        public double Dt
        {
            get { return ObjectModel.Dt; }
            set { if (SetProperty(ref dt, value)) ObjectModel.Dt = dt; }
        }
        double tau1 = 0;
        public double Tau1
        {
            get { return ObjectModel.Tau1; }
            set { if (SetProperty(ref tau1, value)) ObjectModel.Tau1 = tau1; }
        }
        double tau2 = 0;
        public double Tau2
        {
            get { return ObjectModel.Tau2; }
            set { if (SetProperty(ref tau2, value)) ObjectModel.Tau2 = tau2; }
        }
        double beta = 0;
        public double Beta
        {
            get { return ObjectModel.Beta; }
            set { if (SetProperty(ref beta, value)) ObjectModel.Beta = beta; }
        }
        public bool IsValid
        {
            get
            {
                return true; //TODO checking
            }
        }
    }
}
