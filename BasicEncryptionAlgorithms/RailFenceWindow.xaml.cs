using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BasicEncryptionAlgorithms
{
    /// <summary>
    /// Логика взаимодействия для RailFenceWindow.xaml
    /// </summary>
    public partial class RailFenceWindow : Window
    {
        public RailFenceWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.RailFenceViewModel();
        }
    }
}
