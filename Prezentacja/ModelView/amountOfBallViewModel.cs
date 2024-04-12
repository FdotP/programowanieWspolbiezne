using Dane.model;
using Logika;
using Prezentacja.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Prezentacja.ModelView
{
    class amountOfBallViewModel : ViewModelBase
    {
        Board board;
        BallFunctions ballFunctions = new BallFunctions();
        ObservableCollection<Ball> balls;
        public amountOfBallViewModel(Stores.NavigationStore navigationStore) {
            balls = new ObservableCollection<Ball>();
            submitCommand = new PassAmountOfBalls(generatedBalls, this);
            board = new Board(amount);
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

         
        public ObservableCollection<Ball> generatedBalls
        {
            get
            {
                return balls;
            }
            set
            {
                MessageBox.Show("Unable to...");
                balls = value;
                OnPropertyChanged(nameof(generatedBalls));
            }
        }

        public ICommand submitCommand { get; }

    }
}
