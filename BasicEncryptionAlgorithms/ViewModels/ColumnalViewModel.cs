using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BasicEncryptionAlgorithms.ViewModels
{
    public class ColumnalViewModel : INotifyPropertyChanged
    {
        public Models.Columnal Model { get; set; }

        public string TextMatrix
        {
            get
            {
                return Model.Matrix;
            }
            set
            {
                Model.Matrix = value;
                NotifyPropertyChanged(nameof(TextMatrix));
            }
        }

        public string OutputText
        {
            get
            {
                return Model.OutputText;
            }
            set
            {
                Model.OutputText = value;
                NotifyPropertyChanged(nameof(OutputText));
            }
        }

        public ICommand DoEncrypt { get; set; }
        public ICommand DoDecrypt { get; set; }

        public ColumnalViewModel()
        {
            Model = new Models.Columnal();
            DoEncrypt = new DelegateCommand(Encrypt);
            DoEncrypt = new DelegateCommand(Decrypt);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Encrypt()
        {
            int height = Model.InputText.Length / Model.Key.Length;
            var Matrix = new int[Model.Key.Length, Model.InputText.Length];
            TextMatrix = "kek :)";
            MessageBox.Show("lax");
        }

        public void Decrypt()
        {

        }

    }
}
