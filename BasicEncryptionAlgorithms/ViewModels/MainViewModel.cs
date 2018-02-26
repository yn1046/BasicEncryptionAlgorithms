using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicEncryptionAlgorithms.ViewModels
{
    public class MainViewModel
    {
        public ICommand DoOpenRailFence { get; set; }

        public MainViewModel()
        {
            DoOpenRailFence = new DelegateCommand(OpenRailFence);
        }

        public void OpenRailFence()
        {
            var window = new RailFenceWindow();
            window.Show();
        }
    }
}
