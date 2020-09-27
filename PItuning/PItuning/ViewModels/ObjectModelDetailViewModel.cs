using System;

using PItuning.Models;

namespace PItuning.ViewModels
{
    public class ObjectModelDetailViewModel : BaseViewModel
    {
        public ObjectModel ObjectModel { get; set; }
        public ObjectModelDetailViewModel(ObjectModel oM = null)
        {
            Title = oM?.TagName;
            ObjectModel = oM;
        }
    }
}
