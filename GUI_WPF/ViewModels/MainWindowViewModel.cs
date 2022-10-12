using Engine.Logik.Warenlogistik;
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
        #region DelegateCommands
        public DelegateCommand CommandBtnWarenlogistikClick { get; set; }
        #endregion

        #region Propertys        
        private string _myProperty;
        public string MyProperty
        {
            get => _myProperty;
            set
            {
                SetProperty(ref _myProperty, value);
            }
        }
        private bool _subMenueWarenlogistikVisibility = false;
        public bool SubMenueWarenlogistikVisibility
        {
            get => _subMenueWarenlogistikVisibility;
            set
            {
                SetProperty(ref _subMenueWarenlogistikVisibility, value);
            }
        }
        private SortedList<Guid, Produkt> _katalog;
        public SortedList<Guid, Produkt> Katalog
        {
            get => _katalog;
            set
            {
                SetProperty(ref _katalog, value);
            }
        }
        Engine.TestEngine tE;
        #endregion

        #region UserControls
        UserControls.Uebersicht _uebersicht;
        #endregion
        public MainWindowViewModel()
        {
            tE = new Engine.TestEngine();
            Katalog = tE.GetWarenKatalog();
            _uebersicht = new UserControls.Uebersicht();
            CommandBtnWarenlogistikClick = new DelegateCommand(OnBtnWarenlogistikClick);
        }


        #region ButtonClickMethods
        private void OnBtnWarenlogistikClick()
        {
            SubMenueWarenlogistikVisibility = !SubMenueWarenlogistikVisibility;
            OnBtnUebersichtClick();
        }
        private void OnBtnUebersichtClick()
        {
            
        }
        #endregion

    }
}
