using Engine.Konstrukte;
using Engine.Logik.Warenlogistik;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WPF.ViewModels
{
    public class UCUebersichtViewModel : MyBase
    {
        public DelegateCommand CommandBtnCopy { get; set; }

        #region Propertys
        //private ObservableCollection<KatalogItem>? _katalogDarstellung;
        //public ObservableCollection<KatalogItem>? KatalogDarstellung
        //{
        //    get => _katalogDarstellung;
        //    set
        //    {
        //        SetProperty(ref _katalogDarstellung, value);
        //    }
        //}
        private static List<KatalogItem>? _katalogItems;
        public List<KatalogItem>? KatalogItems
        {
            get => _katalogItems;
            set
            {
                SetProperty(ref _katalogItems, value);
            }
        }
        #endregion
        public UCUebersichtViewModel() : this(new List<KatalogItem>()) {}
        public UCUebersichtViewModel(List<KatalogItem> katalogItems)
        {
            if (katalogItems.Count == 0)
            {
                if (KatalogItems == null)
                {
                    KatalogItems = generiereTestKatalogItemList();
                }
            }
            else
            {
                foreach (KatalogItem item in katalogItems)
                {
                    Add(item);
                }
                KatalogItems = katalogItems;
            }
            initialiseDelegates();
        }
        private void initialiseDelegates()
        {
            CommandBtnCopy = new DelegateCommand(obBtnCopyClick);
        }
        private void obBtnCopyClick()
        {
            
        }
        private List<KatalogItem> generiereTestKatalogItemList()
        {
            return new List<KatalogItem>()
            {
                    new KatalogItem("Produkt 1", new MaßeTemplate(1,1,1), 1),
                    new KatalogItem("Produkt 2", new MaßeTemplate(2,2,2), 2),
                    new KatalogItem("Produkt 3", new MaßeTemplate(6,1,2), 1),
                    new KatalogItem("Produkt 4", new MaßeTemplate(5,5,3), 2),
                    new KatalogItem("Produkt 5", new MaßeTemplate(1,1,1), 2)
            };
        }

    }
}
