using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.State.Sidebar
{
    public class SidebarVisible : ISidebarVisible
    {
        private bool _isSidebarVisible;

        public bool IsSidebarVisible
        {
            get => _isSidebarVisible;
        }

        public event Action StateChanged;

        public void UpdateSidebarVisability(bool state)
        {
            _isSidebarVisible = state;
            StateChanged?.Invoke();
        }
    }
}
