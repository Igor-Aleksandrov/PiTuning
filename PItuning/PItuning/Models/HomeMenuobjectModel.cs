using System;
using System.Collections.Generic;
using System.Text;

namespace PItuning.Models
{
    public enum MenuObjectModelType
    {
        Controllers,
        About
    }
    public class HomeMenuObjectModel
    {
        public MenuObjectModelType Id { get; set; }

        public string Title { get; set; }
    }
}
