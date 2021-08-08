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
        private object _mainWindowContext;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private int _selectedMonsterId;
        public int SelectedMonsterId
        {
            get { return _selectedMonsterId; }
            set { _selectedMonsterId = value; }
        }
        public object MainWindowContext
        {
            get { return _mainWindowContext; }
            set { _mainWindowContext = value; }
        }
        public MonsterListViewModel()
        {
            _message = "Model Connected";
        }
        public MonsterListViewModel(string message)
        {
            _message = message;
        }
        public MonsterListViewModel(object mainWindowContext)
        {
            _mainWindowContext = mainWindowContext;
        }
    }
}
