using Engine.Logik.Warenlogistik;
using GUI_WPF.EventArgs;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WPF.ViewModels
{
    public class MainWindowViewModel : Prism.Mvvm.BindableBase
    {
        //Liste od Observable Collection (wird als source erwartet. Objekte an listen binden und anzeigen) anzeigen. (listbox / itembox)
        //modelschicht - recherchieren. Infos einholen (niedrige Prio)
        //content presenter für View models in xaml

        #region DelegateCommands

        #region Menueleiste

        #region Warenlogistik
        public DelegateCommand CommandBtnWarenlogistikClick { get; set; }
        public DelegateCommand CommandBtnUebersichtClick { get; set; }
        public DelegateCommand CommandBtnKatalogClick { get; set; }
        public DelegateCommand CommandBtnProdukteClick { get; set; }
        
        #region Katalog
        public DelegateCommand CommandBtnHinzufuegenClick { get; set; }
        public DelegateCommand CommandBtnEntfernenClick { get; set; }
        #endregion

        #region Produkte        
        public DelegateCommand CommandBtnAufstockenClick { get; set; }
        public DelegateCommand CommandBtnAuslagernClick { get; set; }
        #endregion

        #endregion

        #endregion

        #endregion

        #region Propertys        

        #region Visibility

        #region MenüItems
        private bool _subMenueWarenlogistikVisibility = false;
        public bool SubMenueWarenlogistikVisibility
        {
            get => _subMenueWarenlogistikVisibility;
            set
            {
                SetProperty(ref _subMenueWarenlogistikVisibility, value);
            }
        }

        private bool _subMenueProdukteVisibility = false;
        public bool SubMenueProdukteVisibility
        {
            get => _subMenueProdukteVisibility;
            set
            {
                SetProperty(ref _subMenueProdukteVisibility, value);
            }
        }

        private bool _subMenueKatalogVisibility = false;
        public bool SubMenueKatalogVisibility
        {
            get => _subMenueKatalogVisibility;
            set
            {
                SetProperty(ref _subMenueKatalogVisibility, value);
            }
        }
        #endregion

        #region UserControls
        //private bool _ucUebersichtVisibility = false;
        //public bool UCUebersichtVisibility
        //{
        //    get => _ucUebersichtVisibility;
        //    set
        //    {
        //        if (value)
        //        {
        //            HideAllUserControls();
        //        }
        //        SetProperty(ref _ucUebersichtVisibility, value);
        //    }
        //}
        #endregion

        #endregion

        private List<KatalogItem> _katalog;
        public List<KatalogItem> Katalog
        {
            get => _katalog;
            set
            {
                SetProperty(ref _katalog, value);
            }
        }


        private Prism.Mvvm.BindableBase? _selectedView;
        public Prism.Mvvm.BindableBase? SelectedView
        {
            get => _selectedView;
            set
            {
                SetProperty(ref _selectedView, value);
            }
        }
        #endregion

        #region variables
        Engine.Interface EngineInterface;
        #endregion

        public MainWindowViewModel()
        {
            EngineInterface = new Engine.Interface();
            //EngineInterface.Testrun();
            Katalog = EngineInterface.GetSpecificKatalog();
            
            InitializeCommands();
            
        }
        private void InitializeCommands()
        {
            CommandBtnWarenlogistikClick = new DelegateCommand(OnBtnWarenlogistikClick);
            CommandBtnUebersichtClick = new DelegateCommand(OnBtnUebersichtClick);
            CommandBtnKatalogClick = new DelegateCommand(OnBtnKatalogClick);
            CommandBtnProdukteClick = new DelegateCommand(OnBtnProdukteClick);

            CommandBtnHinzufuegenClick = new DelegateCommand(OnBtnHinzufuegenClick);
            CommandBtnEntfernenClick = new DelegateCommand(OnBtnEntfernenClick);

            CommandBtnAufstockenClick = new DelegateCommand(OnBtnAufstockenClick);
            CommandBtnAuslagernClick = new DelegateCommand(OnBtnAuslagernClick);
        }


        #region ButtonClickMethods
        private void OnBtnWarenlogistikClick()
        {
            SubMenueWarenlogistikVisibility = !SubMenueWarenlogistikVisibility;
            OnBtnUebersichtClick();
        }
        private void OnBtnUebersichtClick()
        {
            SelectedView = new UCUebersichtViewModel(EngineInterface.GetSpecificKatalog());
        }
        private void OnBtnKatalogClick()
        {
            SubMenueKatalogVisibility = !SubMenueKatalogVisibility;
        }
        private void OnBtnProdukteClick()
        {
            SubMenueProdukteVisibility = !SubMenueProdukteVisibility;
        }

        private void OnBtnHinzufuegenClick()
        {
            UCKatalogItemDialogViewModel tmpview = new UCKatalogItemDialogViewModel();
            tmpview.EventHandlerItemHinzufuegen += OnHinzufuegenEvent;
            SelectedView = tmpview;
        }

        private void OnHinzufuegenEvent(object sender, KatalogItemHinzufuegenEventArgs e)
        {
            EngineInterface.ProduktDemKatalogHinzufuegen(e.Item);
            KatalogItem item = e.Item;
        }
        private void OnEntfernenEvent(object sender, KatalogItemEntfernenEventArgs e)
        {
            Guid guid = e.GUID;
        }

        private void OnBtnEntfernenClick()
        {
            SelectedView = new UCKatalogItemDialogViewModel();
        }
        private void OnBtnAufstockenClick()
        {

        }
        private void OnBtnAuslagernClick()
        {

        }
        #endregion

    }
}
