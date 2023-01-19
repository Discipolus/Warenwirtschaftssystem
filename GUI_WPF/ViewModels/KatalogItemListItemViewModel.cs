using Engine.Logik.Warenlogistik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WPF.ViewModels
{
    public class KatalogItemListItemViewModel : MyBase, IEditableObject
    {
        #region Properties
        private KatalogItem? _katalogItem = new KatalogItem("Produkt 1", new Engine.Konstrukte.MaßeTemplate(4,5,4), new List<int> { 0,1,2}, Guid.Parse("936DA01F-9ABD-4D9D-80C7-02AF85C822A8"));
        public KatalogItem? KatalogItem
        {
            get => _katalogItem;
            set
            {
                SetProperty(ref _katalogItem, value);
            }
        }
        private bool _editmode = false;
        public bool Editmode
        {
            get => _editmode;
            set
            {
                SetProperty(ref _editmode, value);
            }
        }
        private KatalogItem? save;
        #endregion
        public KatalogItemListItemViewModel()
        {
            KatalogItem = new KatalogItem();
        }
        public KatalogItemListItemViewModel(KatalogItem? katalogItem)
        {
            KatalogItem = katalogItem;
        }

        public void BeginEdit()
        {
            if (!Editmode)
            {
                Editmode = true;
                save = new KatalogItem(KatalogItem);
            }
        }
        public void CancelEdit()
        {
            if (Editmode)
            {
                Editmode = false;
                KatalogItem = new KatalogItem(save);
            }
            throw new NotImplementedException();
        }

        public void EndEdit()
        {
            if (Editmode)
            {
                Editmode = false;
                save = null;
            }
            throw new NotImplementedException();
        }
    }
}
