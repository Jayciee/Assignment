using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGUILayer.ViewModels
{
    public class MonsterListViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public MonsterListViewModel()
        {
            _message = "Model Connected";
        }
        public MonsterListViewModel(string message)
        {
            _message = message;
        }
    }
}
