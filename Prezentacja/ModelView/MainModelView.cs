using Prezentacja.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.ModelView
{
    class MainModelView : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;  
        public MainModelView(NavigationStore navigationStore) {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
        }

        private void _navigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
