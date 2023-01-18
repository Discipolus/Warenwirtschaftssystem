using Engine.Logik.Warenlogistik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WPF.ViewModels
{
    internal class KatalogItemListItemViewModel : Prism.Mvvm.BindableBase
    {
        #region Properties
        KatalogItem KatalogItem { get; set; }
        #endregion
        KatalogItemListItemViewModel()
        {

        }
    }
}
