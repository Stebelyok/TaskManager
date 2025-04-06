using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModels;

namespace TaskManager.State.Navigators
{
    public interface INavigator
    {
        public enum ViewType
        {
            Login,
            Register,
            Home
        }

        BaseViewModel CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
