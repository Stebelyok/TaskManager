﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.State.Navigators;

namespace TaskManager.Commands
{
    public class RenavigateCommand : ICommand
    {
        private readonly IRenavigator _renavigator;

        public RenavigateCommand(IRenavigator renavigator)
        {
            _renavigator = renavigator;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _renavigator.Renavigate();
        }
    }
}
