using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGUILayer.ViewModels
{
    class MonsterDetailsViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public MonsterDetailsViewModel()
        {
            _message = "Model Connected";
        }
        public MonsterDetailsViewModel(string message)
        {
            _message = message;
        }
    }
}
