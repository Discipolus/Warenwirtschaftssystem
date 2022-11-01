using Engine.Logik.Warenlogistik;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WPF.ViewModels
{
    public class UCUebersichtViewModel : Prism.Mvvm.BindableBase
    {
        private static List<KatalogItem> _testliste;
        public static List<KatalogItem> testliste { get; set; } = new List<KatalogItem>()
        {
            new KatalogItem("Produkt 1", new double[3] {1,1,1}, 1),
            new KatalogItem("Produkt 2", new double[3] {2,2,2}, 2),
            new KatalogItem("Produkt 3", new double[3] {6,1,2}, 1),
            new KatalogItem("Produkt 4", new double[3] {5,5,3}, 2),
            new KatalogItem("Produkt 5", new double[3] {1,1,1}, 2)
        };

        #region Propertys
        private ObservableCollection<string[]>? _katalogDarstellung;
        public ObservableCollection<string[]>? KatalogDarstellung
        {
            get => _katalogDarstellung;
            set
            {
                SetProperty(ref _katalogDarstellung, value);
            }
        }
        private List<KatalogItem>? _katalogItems;
        public List<KatalogItem>? KatalogItems
        {
            get => _katalogItems;
            set
            {
                SetProperty(ref _katalogItems, value);
            }
        }
        #endregion
        public UCUebersichtViewModel() : this(new List<string[]>())
        {
             
        }
        public UCUebersichtViewModel(List<string[]> darzustellendeElemente)
        {
            KatalogDarstellung = new ObservableCollection<string[]>(darzustellendeElemente);
        }
        public UCUebersichtViewModel(List<KatalogItem> katalogItems)
        {
            KatalogItems = katalogItems;
        }

    }
}
