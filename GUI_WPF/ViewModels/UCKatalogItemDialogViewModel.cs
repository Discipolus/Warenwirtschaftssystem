using Engine.Konstrukte;
using Engine.Logik.Warenlogistik;
using GUI_WPF.EventArgs;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GUI_WPF.ViewModels
{
    public class UCKatalogItemDialogViewModel : Prism.Mvvm.BindableBase
    {
        #region Delegate Commands
        public DelegateCommand CommandBtnHinzufuegenClick { get; set; }
        public DelegateCommand CommandBtnEntfernenClick { get; set; }
        public DelegateCommand CommandBtnNeueEingabeClick { get; set; }

        #endregion

        public event EventHandler<KatalogItemHinzufuegenEventArgs> EventHandlerItemHinzufuegen;
        public event EventHandler<KatalogItemEntfernenEventArgs> EventHandlerItemEntfernen;

        #region Propertys

        private string _textBoxName;
        public string TextBoxName
        {
            get => _textBoxName;
            set
            {
                SetProperty(ref _textBoxName, value);
            }
        }

        private string _textBoxMaßeX;
        public string TextBoxMaßeX
        {
            get => _textBoxMaßeX;
            set
            {
                SetProperty(ref _textBoxMaßeX, value);
            }
        }
        private string _textBoxMaßeY;
        public string TextBoxMaßeY
        {
            get => _textBoxMaßeY;
            set
            {
                SetProperty(ref _textBoxMaßeY, value);
            }
        }
        private string _textBoxMaßeZ;
        public string TextBoxMaßeZ
        {
            get => _textBoxMaßeZ;
            set
            {
                SetProperty(ref _textBoxMaßeZ, value);
            }
        }

        private string _textBoxLagerhaeuser;
        public string TextBoxLagerhaeuser
        {
            get => _textBoxLagerhaeuser;
            set
            {
                SetProperty(ref _textBoxLagerhaeuser, value);
            }
        }

        private string _textBoxGuid;
        public string TextBoxGuid
        {
            get => _textBoxGuid;
            set
            {
                SetProperty(ref _textBoxGuid, value);
            }
        }

        #endregion
        public UCKatalogItemDialogViewModel()
        {
            initializeDelegates();
            fillVariables();
        }
        private void fillVariables()
        {
            TextBoxGuid = "";
            TextBoxLagerhaeuser = "";
            TextBoxMaßeX = "";
            TextBoxMaßeY = "";
            TextBoxMaßeZ = "";
            TextBoxName = "";
        }
        private void initializeDelegates()
        {
            CommandBtnHinzufuegenClick = new DelegateCommand(onbtnHinzufuegenClick);
            CommandBtnEntfernenClick = new DelegateCommand(onBtnEntfernenClick);
            CommandBtnNeueEingabeClick = new DelegateCommand(onBtnNeueEingabeClick);
        }
        private KatalogItem? extractItem()
        {
            KatalogItem? item = null;
            MaßeTemplate? maße = getMaßeFromTextBox();
            List<int> lagerhäuser = getLagerhaeuserIndizesFromTextBox();
            Guid guid = getGuidFromTextbox();
            if (TextBoxName.Length > 0 && maße != null)
            {
                item = new KatalogItem(TextBoxName, maße, lagerhäuser, guid);             
            }
            else
            {
                string message = "Error occured: Name or Maße has an invalid value.";
                MessageBox.Show(message);
                Console.WriteLine(message);
            }
            return item;
        }
        private void onbtnHinzufuegenClick()
        {
            KatalogItem? item = extractItem();
            if (item != null)
            {
                EventHandlerItemHinzufuegen.Invoke(this, new KatalogItemHinzufuegenEventArgs(item));
            }

        }
        private void onBtnEntfernenClick()
        {
            Guid guid = getGuidFromTextbox();
            if (guid != Guid.Empty)
            {
                EventHandlerItemEntfernen.Invoke(this, new KatalogItemEntfernenEventArgs(guid));
            }
        }
        private void onBtnNeueEingabeClick()
        {

        }
        private MaßeTemplate? getMaßeFromTextBox()
        {
            try
            {
                return new MaßeTemplate(
                    Convert.ToDouble(TextBoxMaßeX),
                    Convert.ToDouble(TextBoxMaßeY),
                    Convert.ToDouble(TextBoxMaßeZ)
                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private List<int> getLagerhaeuserIndizesFromTextBox()
        {
            List<int> rueckgabe = new List<int>();
            if (TextBoxLagerhaeuser.Length > 0)
            {
                foreach (string s in TextBoxLagerhaeuser.Split(';'))
                {
                    try
                    {
                        rueckgabe.Add(Convert.ToInt32(s));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return rueckgabe;
        }
        private Guid getGuidFromTextbox()
        {
            Guid rueckgabe;
            if (Guid.TryParse(TextBoxGuid, out rueckgabe))
            {
                return rueckgabe;
            }
            else
            {
                string message = "Fehler bei der Convertierung der Eingabe zur GUID.";
                Console.WriteLine(message);
                MessageBox.Show(message);
            }
            return Guid.Empty;
        }
    }
}
