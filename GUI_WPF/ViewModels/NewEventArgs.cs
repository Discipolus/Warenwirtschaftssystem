using Engine.Logik.Warenlogistik;

namespace GUI_WPF.ViewModels
{
    public class NewEventArgs
    {
        public KatalogItem item;

        public NewEventArgs(KatalogItem item)
        {
            this.item = item;
        }
    }
}