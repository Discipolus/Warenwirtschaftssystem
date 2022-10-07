using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WPF.ViewModels
{
    public class MainWindowViewModel : Prism.Mvvm.BindableBase
    {
        //booltovisibilityconverter
        //Liste od Observable Collection anzeigen. (listbox / itembox)
        //modelschicht - 
        private string myProperty;
        public string MyProperty
        {
            get => myProperty;
            set
            {
                SetProperty(ref myProperty, value);
            }
        }
        public MainWindowViewModel()
        {
            MyProperty = "Hallo";
            BtnClick = new DelegateCommand(OnBtnClick);
        }

        private void OnBtnClick()
        {
            MyProperty = "Hallo 234";
            //throw new NotImplementedException();
        }

        public DelegateCommand BtnClick {get; set;}
    }
}
