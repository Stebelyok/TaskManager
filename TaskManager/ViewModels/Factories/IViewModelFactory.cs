using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManager.State.Navigators.INavigator;

namespace TaskManager.ViewModels.Factories
{
    public interface IViewModelFactory
    {
        BaseViewModel CreateViewModel(ViewType viewType);
    }
}
