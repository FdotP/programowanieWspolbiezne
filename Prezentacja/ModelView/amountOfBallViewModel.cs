using Prezentacja.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prezentacja.ModelView
{
    class amountOfBallViewModel : ViewModelBase
    {
        public amountOfBallViewModel() {
            submit = new PassAmountOfBalls();
        }
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

        public ICommand submit { get; }

    }
}
