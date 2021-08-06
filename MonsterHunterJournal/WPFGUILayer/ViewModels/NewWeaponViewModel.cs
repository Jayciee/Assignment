using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGUILayer.ViewModels
{
    class NewWeaponViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public NewWeaponViewModel()
        {
            _message = "Model Connected";
        }
        public NewWeaponViewModel(string message)
        {
            _message = message;
        }
    }
}
