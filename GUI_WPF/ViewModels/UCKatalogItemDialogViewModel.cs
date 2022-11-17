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
    public class UCKatalogItemDialogViewModel : Prism.Mvvm.BindableBase
    {
        #region Delegate Commands
        public DelegateCommand CommandBtnHinzufuegenClick { get; set; }
        public DelegateCommand CommandBtnEntfernenClick { get; set; }
        public DelegateCommand CommandBtnNeueEingabeClick { get; set; }

        #endregion

        #region Propertys

        private string _textBoxName = "Name";
        public string TextBoxName
        {
            get => _textBoxName;
            set
            {
                SetProperty(ref _textBoxName, value);
            }
        }

        private string _textBoxMaßeX = "2.0";
        public string TextBoxMaßeX
        {
            get => _textBoxMaßeX;
            set
            {
                SetProperty(ref _textBoxMaßeX, value);
            }
        }
        private string _textBoxMaßeY = "0.3";
        public string TextBoxMaßeY
        {
            get => _textBoxMaßeY;
            set
            {
                SetProperty(ref _textBoxMaßeY, value);
            }
        }
        private string _textBoxMaßeZ = "0.1";
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
        }
        private void initializeDelegates()
        {
            CommandBtnHinzufuegenClick = new DelegateCommand(onbtnHinzufuegenClick);
            CommandBtnEntfernenClick = new DelegateCommand(onBtnEntfernenClick);
            CommandBtnNeueEingabeClick = new DelegateCommand(onBtnNeueEingabeClick);
        }
        private void onbtnHinzufuegenClick()
        {

        }
        private void onBtnEntfernenClick()
        {

        }
        private void onBtnNeueEingabeClick()
        {

        }


    }
}
