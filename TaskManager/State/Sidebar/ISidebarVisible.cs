using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.State.Sidebar
{
    public interface ISidebarVisible
    {
        bool IsSidebarVisible { get; }

        event Action StateChanged;

        void UpdateSidebarVisability(bool state);
    }
}
