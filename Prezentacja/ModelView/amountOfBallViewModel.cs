using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.ModelView
{
    class amountOfBallViewModel : ViewModelBase
    {
        private int amount;
        public int Amount {
            get {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

    }
}
