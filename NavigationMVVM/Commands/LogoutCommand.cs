using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly CategoriaStore _accountStore;

        public LogoutCommand(CategoriaStore accountStore)
        {
            _accountStore = accountStore;
        }

        public override void Execute(object parameter)
        {
            _accountStore.Logout();
        }
    }
}
