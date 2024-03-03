using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.ModelView
{
    class MainModelView : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get;}
        public MainModelView() { 
            CurrentViewModel = new amountOfBallViewModel();
        }
    }
}
