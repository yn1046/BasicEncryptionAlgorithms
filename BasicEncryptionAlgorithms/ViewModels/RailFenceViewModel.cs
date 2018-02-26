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
    public class RailFenceViewModel : INotifyPropertyChanged
    {
        public Models.RailFence Model { get; set; }
        
        public ICommand DoEncrypt { get; set; }
        public ICommand DoDecrypt { get; set; }

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

        public RailFenceViewModel()
        {
            Model = new Models.RailFence();
            DoEncrypt = new DelegateCommand(Encrypt);
            DoDecrypt = new DelegateCommand(Decrypt);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Encrypt()
        {
            try
            {
                var key = int.Parse(Model.Key);
                var Matrix = new char[Model.InputText.Length, key];
                var result = string.Empty;

                //fill matrix
                for (var i = 0; i < Model.InputText.Length; i++)
                    for (var j = 0; j < key; j++) Matrix[i, j] = '—';

                bool ascend = false;
                var k = 0;
                for (var i = 0; i < Model.InputText.Length; i++)
                {
                    if (k == 0) ascend = false;
                    if (k == key - 1) ascend = true;
                    Matrix[i, k] = Model.InputText[i];
                    if (ascend) k--;
                    else k++;
                }

                for (var j = 0; j < key; j++)
                {
                    for (var i = 0; i < Model.InputText.Length; i++) result += Matrix[i, j];
                    result += '\n';
                }

                TextMatrix = result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
            }
        }

        public void Decrypt()
        {
            try
            {
                var MatrixRows = Model.Matrix.Split('\n');
                var key = MatrixRows.Count() - 1;
                var length = MatrixRows[0].Length;

                var solution = string.Empty;
                var i = 0;
                bool ascend = false;
                for (var j = 0; j < length; j++)
                {
                    if (i == 0) ascend = false;
                    if (i == key - 1) ascend = true;
                    solution += MatrixRows[i][j];
                    if (ascend) i--;
                    else i++;
                }

                OutputText = solution;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
            }
        }
    }
}