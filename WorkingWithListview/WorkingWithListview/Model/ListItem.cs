using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace WorkingWithListview.Model
{
    public class ListItem : BindableBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}
