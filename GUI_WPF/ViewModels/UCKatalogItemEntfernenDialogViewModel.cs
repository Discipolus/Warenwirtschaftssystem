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
    public class UCKatalogItemEntfernenDialogViewModel : Prism.Mvvm.BindableBase
    {
        #region Delegate Commands
        public DelegateCommand CommandBtnHinzufuegenClick { get; set; }
        public DelegateCommand CommandBtnEntfernenClick { get; set; }
        public DelegateCommand CommandBtnNeueEingabeClick { get; set; }

        #endregion

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
        public UCKatalogItemEntfernenDialogViewModel()
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
            CommandBtnEntfernenClick = new DelegateCommand(onBtnEntfernenClick);
            CommandBtnNeueEingabeClick = new DelegateCommand(onBtnNeueEingabeClick);
        }
        private void onBtnEntfernenClick()
        {
            Guid GUID = getGuidFromTextbox();
            if (GUID != Guid.Empty)
            {
                EventHandlerItemEntfernen.Invoke(this, new KatalogItemEntfernenEventArgs(GUID));
            }
        }
        private void onBtnNeueEingabeClick()
        {

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
